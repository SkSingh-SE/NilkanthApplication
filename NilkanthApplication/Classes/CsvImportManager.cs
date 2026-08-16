using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication.Classes
{
    // Silently imports PLC CSV from FTP in the background.
    // Runs 24x7 on background ThreadPool with zero CPU/UI load.
    // All DB work uses its own isolated SqlConnection.
    public class CsvImportManager
    {
        private static readonly string _connStr =
            ConfigurationManager.ConnectionStrings["DataConnectionString"].ToString();

        private static readonly SemaphoreSlim _importLock = new SemaphoreSlim(1, 1);
        private CancellationTokenSource _cts;
        private bool _isRunning = false;

        public static CsvImportManager Instance { get; } = new CsvImportManager();

        public CsvImportManager() { }

        // Starts continuous 24x7 background polling with 0% CPU load
        public void StartContinuousImport(int intervalSeconds = 10)
        {
            if (_isRunning) return;
            _isRunning = true;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        await RunOnceAsync();
                    }
                    catch { /* Silent catch so the background loop never terminates */ }

                    try
                    {
                        // Non-blocking kernel timer — 0% CPU usage, releases thread to pool
                        await Task.Delay(TimeSpan.FromSeconds(intervalSeconds), token);
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
                _isRunning = false;
            }, token);
        }

        public void StopContinuousImport()
        {
            _isRunning = false;
            try
            {
                _cts?.Cancel();
            }
            catch { }
        }

        // Called from MainScreen timer tick (async void).
        // FTP download is async; DB inserts run on Task.Run — UI is never blocked.
        public async Task<bool> RunOnceAsync()
        {
            // Thread concurrency lock: strictly 1 import at a time
            if (!await _importLock.WaitAsync(0))
                return false;

            try
            {
                // Read lastReadDateTime on calling thread (lightweight SP call)
                DataTable lastReadDT = Functions.GetTableDataBySP("ImportCSVLastRead_Select");
                if (lastReadDT == null || lastReadDT.Rows.Count == 0)
                    return false;

                DateTime lastRead = Convert.ToDateTime(lastReadDT.Rows[0][2].ToString());

                string ftpUrl      = ConfigurationManager.AppSettings["FtpUrl"]      ?? "ftp://192.168.1.150/DAT0000/SAMPLE/SMP0000.CSV";
                string ftpUser     = ConfigurationManager.AppSettings["FtpUser"]     ?? "admin";
                string ftpPass     = ConfigurationManager.AppSettings["FtpPassword"] ?? "6982";
                bool   ftpPassive  = false;
                bool.TryParse(ConfigurationManager.AppSettings["FtpUsePassive"], out ftpPassive);

                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpUrl));
                req.UsePassive   = ftpPassive;
                req.UseBinary    = true;
                req.KeepAlive    = false; // Ensure socket is released immediately for PLC/HMI
                req.Credentials  = new NetworkCredential(ftpUser, ftpPass);
                req.Method       = WebRequestMethods.Ftp.DownloadFile;
                req.Proxy        = GlobalProxySelection.GetEmptyWebProxy();
                req.Timeout      = 10000;

                // ── Async FTP download ──────────────────────────────────────
                List<string[]> rowsToInsert;
                using (var ftpTask = Task.Factory.FromAsync(req.BeginGetResponse, req.EndGetResponse, null))
                using (FtpWebResponse response = (FtpWebResponse)await ftpTask)
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = await reader.ReadToEndAsync();

                    // Parse CSV lines — fast, no IO, stays on current context
                    rowsToInsert = ParseRows(content, lastRead);
                }

                if (rowsToInsert.Count == 0)
                {
                    return false;
                }

                // ── All DB work on background thread with its own connection ─
                int inserted = await Task.Run(() => InsertRows(rowsToInsert));

                if (inserted > 0)
                {
                    FtpLogger.LogSuccess("Background Auto-Import", $"Successfully imported {inserted} new records from {ftpUrl}");
                    NotifyMain($"Auto-imported {inserted} new PLC records.");
                    return true;
                }

                return false;
            }
            catch (WebException wex)
            {
                string ftpUrl = ConfigurationManager.AppSettings["FtpUrl"] ?? "ftp://192.168.1.150/DAT0000/SAMPLE/SMP0000.CSV";
                FtpLogger.LogError("Background Auto-Import", "FTP Connection Failed / Refused", wex, ftpUrl);
                NotifyMain("FTP Error: " + FtpLogger.DiagnoseError(wex));
                return false;
            }
            catch (Exception ex)
            {
                FtpLogger.LogError("Background Auto-Import", "CSV Import Process Error", ex);
                NotifyMain("CSV Import Error: " + ex.Message);
                return false;
            }
            finally
            {
                _importLock.Release();
            }
        }

        // ── Parse CSV content into filtered rows ────────────────────────────
        private static List<string[]> ParseRows(string content, DateTime lastRead)
        {
            var rows = new List<string[]>();
            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < lines.Length; i++) // skip header row
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] cols = line.Split(',');
                if (cols.Length < 9) continue;

                DateTime plcDate;
                if (!DateTime.TryParse(cols[0].Trim(), out plcDate)) continue;
                if (plcDate <= lastRead) continue;

                rows.Add(cols);
            }

            return rows;
        }

        // ── Runs entirely on thread pool — own SqlConnection, no SQLHelper ──
        private static int InsertRows(List<string[]> rows)
        {
            int inserted = 0;
            DateTime? maxInsertedDate = null;

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                foreach (var cols in rows)
                {
                    DateTime plcDate;
                    if (!DateTime.TryParse(cols[0].Trim(), out plcDate)) continue;

                    int batchNo = 0, cycle = 0;
                    int.TryParse(cols[8].Trim(), out batchNo);
                    if (cols.Length > 10) int.TryParse(cols[10].Trim(), out cycle);

                    // Duplicate check: BatchNo + Cycle + PLCDate (date only)
                    using (SqlCommand chk = new SqlCommand(
                        "SELECT COUNT(1) FROM PLCData WHERE BatchNo=@b AND Cycle=@c AND CAST(PLCDate AS DATE)=@d",
                        conn))
                    {
                        chk.Parameters.AddWithValue("@b", batchNo);
                        chk.Parameters.AddWithValue("@c", cycle);
                        chk.Parameters.AddWithValue("@d", plcDate.ToString("yyyy-MM-dd"));
                        int exists = (int)chk.ExecuteScalar();
                        if (exists > 0) continue;
                    }

                    // Insert via SP
                    using (SqlCommand cmd = new SqlCommand("ImportCSVTOPLCData", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PLCDate",       plcDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@Customer",       Col(cols, 1));
                        cmd.Parameters.AddWithValue("@ClientName",     Col(cols, 2));
                        cmd.Parameters.AddWithValue("@SiteName",       Col(cols, 3));
                        cmd.Parameters.AddWithValue("@RecipeName",     Col(cols, 4));
                        cmd.Parameters.AddWithValue("@TruckNo",        Col(cols, 5));
                        cmd.Parameters.AddWithValue("@DriverName",     Col(cols, 6));
                        cmd.Parameters.AddWithValue("@BatchSize",      Dbl(cols, 7));
                        cmd.Parameters.AddWithValue("@BatchNo",        Dbl(cols, 8));
                        cmd.Parameters.AddWithValue("@SetCycle",       Dbl(cols, 9));
                        cmd.Parameters.AddWithValue("@Cycle",          Dbl(cols, 10));
                        cmd.Parameters.AddWithValue("@Bin1Set",        Dbl(cols, 11));
                        cmd.Parameters.AddWithValue("@Bin1Actual",     Dbl(cols, 12));
                        cmd.Parameters.AddWithValue("@Bin2Set",        Dbl(cols, 13));
                        cmd.Parameters.AddWithValue("@Bin2Actual",     Dbl(cols, 14));
                        cmd.Parameters.AddWithValue("@Bin3Set",        Dbl(cols, 15));
                        cmd.Parameters.AddWithValue("@Bin3Actual",     Dbl(cols, 16));
                        cmd.Parameters.AddWithValue("@Bin4Set",        Dbl(cols, 17));
                        cmd.Parameters.AddWithValue("@Bin4Actual",     Dbl(cols, 18));
                        cmd.Parameters.AddWithValue("@CementSet",      Dbl(cols, 19));
                        cmd.Parameters.AddWithValue("@CementActual",   Dbl(cols, 20));
                        cmd.Parameters.AddWithValue("@FlyashSet",      Dbl(cols, 21));
                        cmd.Parameters.AddWithValue("@FlyashActual",   Dbl(cols, 22));
                        cmd.Parameters.AddWithValue("@WaterSet",       Dbl(cols, 23));
                        cmd.Parameters.AddWithValue("@WaterActual",    Dbl(cols, 24));
                        cmd.Parameters.AddWithValue("@AdditiveSet",    Dbl(cols, 25));
                        cmd.Parameters.AddWithValue("@AdditiveActual", Dbl(cols, 26));
                        cmd.Parameters.AddWithValue("@TotalActual",    Dbl(cols, 27));
                        cmd.Parameters.AddWithValue("@SilicaSet",      Dbl(cols, 28));
                        cmd.Parameters.AddWithValue("@SilicaActual",   Dbl(cols, 29));
                        cmd.Parameters.AddWithValue("@GGBSSet",        Dbl(cols, 30));
                        cmd.Parameters.AddWithValue("@GGBSActual",     Dbl(cols, 31));

                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            inserted++;
                            if (maxInsertedDate == null || plcDate > maxInsertedDate.Value)
                                maxInsertedDate = plcDate;
                        }
                    }
                }

                // Update last read timestamp after all inserts
                if (inserted > 0 && maxInsertedDate.HasValue)
                {
                    using (SqlCommand upd = new SqlCommand("ImportCSVLastRead_Update", conn))
                    {
                        upd.CommandType = CommandType.StoredProcedure;
                        upd.Parameters.AddWithValue("@LastReadDateTime", maxInsertedDate.Value);
                        upd.ExecuteNonQuery();
                    }
                }
            }

            return inserted;
        }

        // ── Helpers ─────────────────────────────────────────────────────────
        private static string Col(string[] cols, int i) =>
            i < cols.Length ? cols[i].Trim() : "";

        private static double Dbl(string[] cols, int i)
        {
            if (i >= cols.Length) return 0;
            double v;
            return double.TryParse(cols[i].Trim(), out v) ? v : 0;
        }

        private void NotifyMain(string message)
        {
            try
            {
                if (Application.OpenForms["MainScreen"] is MainScreen main)
                    main.SetNotification(message);
            }
            catch { }
        }
    }
}
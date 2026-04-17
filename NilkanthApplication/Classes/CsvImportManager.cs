using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace NilkanthApplication.Classes
{
    // Lightweight CSV importer that downloads the PLC CSV from FTP, skips already-existing rows
    // and inserts new records using the existing stored procedure. It reports status to MainScreen.lblNotification.
    public class CsvImportManager
    {
        public CsvImportManager() { }

        public async Task<bool> RunOnceAsync()
        {
            try
            {
                var importcsvlastread = Functions.GetTableDataBySP("ImportCSVLastRead_Select");
                if (importcsvlastread == null || importcsvlastread.Rows.Count == 0)
                    return false;

                DateTime lastreaddatetime = Convert.ToDateTime(importcsvlastread.Rows[0][2].ToString());

                // Read FTP settings from config (fallback to previous hard-coded values)
                string ftpUrl = ConfigurationManager.AppSettings["FtpUrl"] ?? "ftp://192.168.1.150/DAT0000/SAMPLE/SMP0000.CSV";
                string ftpUser = ConfigurationManager.AppSettings["FtpUser"] ?? "admin";
                string ftpPass = ConfigurationManager.AppSettings["FtpPassword"] ?? "6982";
                bool ftpUsePassive = false;
                bool.TryParse(ConfigurationManager.AppSettings["FtpUsePassive"], out ftpUsePassive);

                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpUrl));
                reqFTP.UsePassive = ftpUsePassive;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPass);
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.Proxy = GlobalProxySelection.GetEmptyWebProxy();

                // Download on background thread
                using (var task = Task.Factory.FromAsync(reqFTP.BeginGetResponse, reqFTP.EndGetResponse, null))
                using (FtpWebResponse response = (FtpWebResponse)await task)
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string content = await reader.ReadToEndAsync();
                    string[] allLines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    var rowsToInsert = new List<string[]>();

                    for (int i = 1; i < allLines.Length; i++) // skip header
                    {
                        string line = allLines[i];
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] cols = line.Split(',');
                        if (cols.Length < 9)
                            continue;

                        DateTime plcDate = Convert.ToDateTime(cols[0]);
                        if (plcDate <= lastreaddatetime)
                            continue;

                        rowsToInsert.Add(cols);
                    }

                    if (rowsToInsert.Count == 0)
                        return false;

                    int inserted = 0;
                    foreach (var cols in rowsToInsert)
                    {
                        int batchNo = 0; int cycle = 0;
                        int.TryParse(cols[8].Trim(), out batchNo);
                        int.TryParse(cols[10].Trim(), out cycle);

                        // Server-side uniqueness is best, but do a quick existence check here to avoid duplicates
                        var existsObj = Functions.GetSingleValue($"select count(1) from Trip_PLCData where BatchNo={batchNo} and Cycle={cycle}");
                        int exists = 0;
                        try { exists = Convert.ToInt32(existsObj); } catch { exists = 0; }
                        if (exists > 0)
                            continue;

                        SQLHelper._objCmd = new System.Data.SqlClient.SqlCommand();
                        SQLHelper._objCmd.Parameters.Clear();
                        SQLHelper._objCmd.Parameters.AddWithValue("@PLCDate", Convert.ToDateTime(cols[0].ToString()));
                        SQLHelper._objCmd.Parameters.AddWithValue("@Customer", cols[1].ToString());
                        SQLHelper._objCmd.Parameters.AddWithValue("@ClientName", cols[2].ToString());
                        SQLHelper._objCmd.Parameters.AddWithValue("@SiteName", cols[3].ToString());
                        SQLHelper._objCmd.Parameters.AddWithValue("@RecipeName", cols[4].ToString());
                        SQLHelper._objCmd.Parameters.AddWithValue("@TruckNo", cols[5].ToString());
                        SQLHelper._objCmd.Parameters.AddWithValue("@DriverName", cols[6].ToString());
                        SQLHelper._objCmd.Parameters.AddWithValue("@BatchSize", cols[7].ToString().Trim() != "" ? Convert.ToDouble(cols[7].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@BatchNo", cols[8].ToString().Trim() != "" ? Convert.ToDouble(cols[8].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@SetCycle", cols[9].ToString().Trim() != "" ? Convert.ToDouble(cols[9].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Cycle", cols[10].ToString().Trim() != "" ? Convert.ToDouble(cols[10].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Set", cols.Length > 11 && cols[11].ToString().Trim() != "" ? Convert.ToDouble(cols[11].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Actual", cols.Length > 12 && cols[12].ToString().Trim() != "" ? Convert.ToDouble(cols[12].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Set", cols.Length > 13 && cols[13].ToString().Trim() != "" ? Convert.ToDouble(cols[13].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Actual", cols.Length > 14 && cols[14].ToString().Trim() != "" ? Convert.ToDouble(cols[14].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Set", cols.Length > 15 && cols[15].ToString().Trim() != "" ? Convert.ToDouble(cols[15].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Actual", cols.Length > 16 && cols[16].ToString().Trim() != "" ? Convert.ToDouble(cols[16].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Set", cols.Length > 17 && cols[17].ToString().Trim() != "" ? Convert.ToDouble(cols[17].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Actual", cols.Length > 18 && cols[18].ToString().Trim() != "" ? Convert.ToDouble(cols[18].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@CementSet", cols.Length > 19 && cols[19].ToString().Trim() != "" ? Convert.ToDouble(cols[19].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@CementActual", cols.Length > 20 && cols[20].ToString().Trim() != "" ? Convert.ToDouble(cols[20].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@FlyashSet", cols.Length > 21 && cols[21].ToString().Trim() != "" ? Convert.ToDouble(cols[21].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@FlyashActual", cols.Length > 22 && cols[22].ToString().Trim() != "" ? Convert.ToDouble(cols[22].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@WaterSet", cols.Length > 23 && cols[23].ToString().Trim() != "" ? Convert.ToDouble(cols[23].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@WaterActual", cols.Length > 24 && cols[24].ToString().Trim() != "" ? Convert.ToDouble(cols[24].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveSet", cols.Length > 25 && cols[25].ToString().Trim() != "" ? Convert.ToDouble(cols[25].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveActual", cols.Length > 26 && cols[26].ToString().Trim() != "" ? Convert.ToDouble(cols[26].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@TotalActual", cols.Length > 27 && cols[27].ToString().Trim() != "" ? Convert.ToDouble(cols[27].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@SilicaSet", cols.Length > 28 && cols[28].ToString().Trim() != "" ? Convert.ToDouble(cols[28].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@SilicaActual", cols.Length > 29 && cols[29].ToString().Trim() != "" ? Convert.ToDouble(cols[29].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@GGBSSet", cols.Length > 30 && cols[30].ToString().Trim() != "" ? Convert.ToDouble(cols[30].ToString()) : 0);
                        SQLHelper._objCmd.Parameters.AddWithValue("@GGBSActual", cols.Length > 31 && cols[31].ToString().Trim() != "" ? Convert.ToDouble(cols[31].ToString()) : 0);

                        string text2 = Queries.InsertBySP("ImportCSVTOPLCData");
                        if (string.IsNullOrWhiteSpace(text2))
                            inserted++;
                    }

                    if (inserted > 0)
                    {
                        DateTime lastInserted = Convert.ToDateTime(rowsToInsert[rowsToInsert.Count - 1][0]);
                        SQLHelper._objCmd = new System.Data.SqlClient.SqlCommand();
                        SQLHelper._objCmd.Parameters.Clear();
                        SQLHelper._objCmd.Parameters.AddWithValue("@LastReadDateTime", lastInserted);
                        string upd = Queries.UpdateBySP("ImportCSVLastRead_Update");
                        NotifyMain($"Imported {inserted} new PLC records.");
                        return true;
                    }
                }

                return false;
            }
            catch (WebException wex)
            {
                NotifyMain("FTP Error: " + wex.Message);
                return false;
            }
            catch (Exception ex)
            {
                NotifyMain("CSV Import Error: " + ex.Message);
                return false;
            }
        }

        private void NotifyMain(string message)
        {
            try
            {
                if (Application.OpenForms["MainScreen"] is MainScreen main)
                {
                    main.SetNotification(message);
                }
                else
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }
    }
}

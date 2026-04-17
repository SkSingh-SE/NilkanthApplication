using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication.Classes
{
    public class PlcSyncManager
    {
        private readonly string _apiUrl = "https://nilkantherp.com";
        private readonly string _apiKey = "qThtrF6v+yzhjms+qKhy3sMddtuJ2aU1M1bNv9vEIsY=";
        private string _companyName = "YourCompany";
        private string _locationName = "YourLocation";
        private string _plantName = "Plant-1";
        private static readonly HttpClient _httpClient = new HttpClient();

        public PlcSyncManager() { }

        //  MAIN METHOD TO CALL FROM TIMER
        public async Task<bool> ExecuteSyncAsync()
        {
            try
            {
                if (!await IsInternetAvailableAsync())
                    return false;

                if (!UpdateCompanyInfo())
                    return false;

                var results = await Task.WhenAll(
                    SyncPLCData(),
                    SyncBreakDown(),
                    SyncNotes()
                );

                bool anySuccess = results.Any(r => r);
                return anySuccess;
            }
            catch
            {
                return false;
            }
        }


        private async Task<bool> SyncPLCData()
        {
            try
            {
                var records = GetDataFromSP();
                if (records.Count == 0)
                    return false;

                bool success = await SendToApiAsync("/api/ingest/plc-data", records);

                if (success)
                {
                    records.ForEach(r => MarkAsSynced(r.Id));
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }


        private async Task<bool> SyncBreakDown()
        {
            try
            {
                var records = GetBreakdownForSync();
                if (records.Count == 0)
                    return false;

                bool success = await SendToApiAsync("/api/ingest/breakdowns", records);

                if (success)
                {
                    records.ForEach(r => MarkBreakdownSynced(r.Id));
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }


        private async Task<bool> SyncNotes()
        {
            try
            {
                var records = GetNotesForSync();
                if (records.Count == 0)
                    return false;

                bool success = await SendToApiAsync("/api/ingest/notes", records);

                if (success)
                {
                    records.ForEach(r => MarkNotesSynced(r.Id));
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }



        private bool UpdateCompanyInfo()
        {
            try
            {
                var companyDT = Functions.GetTableDataBySP("CompanyMaster_Select");
                if (companyDT.Rows.Count > 0)
                {
                    _companyName = companyDT.Rows[0]["CompanyName"].ToString();
                    _locationName = companyDT.Rows[0]["Location"].ToString();
                    _plantName = companyDT.Rows[0]["PlantName"].ToString();
                    if (string.IsNullOrWhiteSpace(_companyName) ||string.IsNullOrWhiteSpace(_locationName) ||string.IsNullOrWhiteSpace(_plantName))
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //  GET DATA
        private List<PlcJson> GetDataFromSP()
        {
            var list = new List<PlcJson>();

            DataTable dt = Functions.GetTableDataBySP("GetPlcDataForSync");

            if (dt == null || dt.Rows.Count == 0)
                return list;

            foreach (DataRow row in dt.Rows)
            {
                DateTime plcDate = Convert.ToDateTime(row["PLCDate"]);

                var item = new PlcJson
                {
                    ProductionDate = plcDate.ToString("yyyy-MM-dd"),
                    ProductionTime = plcDate.ToString("HH:mm:ss"),

                    Id = Convert.ToInt32(row["Id"]),
                    BatchNumber = Convert.ToInt32(row["BatchNo"]),
                    Cycle = Convert.ToInt32(row["Cycle"]),
                    RecipeName = row["RecipeName"]?.ToString(),
                    TruckNumber = row["TruckNo"]?.ToString(),
                    Name = row["Customer"]?.ToString(),
                    ClientName = row["ClientName"]?.ToString(),
                    SiteName = row["SiteName"]?.ToString(),
                    DriverName = row["DriverName"]?.ToString(),

                    BatchCapacity = Convert.ToDecimal(row["BatchSize"]),
                    SetCycle = Convert.ToInt32(row["SetCycle"]),

                    SetAggregation1 = Convert.ToDecimal(row["Bin1Set"]),
                    Aggregation1 = Convert.ToDecimal(row["Bin1Actual"]),
                    SetAggregation2 = Convert.ToDecimal(row["Bin2Set"]),
                    Aggregation2 = Convert.ToDecimal(row["Bin2Actual"]),
                    SetAggregation3 = Convert.ToDecimal(row["Bin3Set"]),
                    Aggregation3 = Convert.ToDecimal(row["Bin3Actual"]),
                    SetAggregation4 = Convert.ToDecimal(row["Bin4Set"]),
                    Aggregation4 = Convert.ToDecimal(row["Bin4Actual"]),

                    SetCement = Convert.ToDecimal(row["CementSet"]),
                    Cement = Convert.ToDecimal(row["CementActual"]),
                    SetFlyash = Convert.ToDecimal(row["FlyashSet"]),
                    Flyash = Convert.ToDecimal(row["FlyashActual"]),
                    SetWater = Convert.ToDecimal(row["WaterSet"]),
                    Water = Convert.ToDecimal(row["WaterActual"]),
                    SetAdmixture = Convert.ToDecimal(row["AdditiveSet"]),
                    Admixture = Convert.ToDecimal(row["AdditiveActual"]),
                    SetSilica = Convert.ToDecimal(row["SilicaSet"]),
                    Silica = Convert.ToDecimal(row["SilicaActual"]),
                    SetGgbs = Convert.ToDecimal(row["GGBSSet"]),
                    Ggbs = Convert.ToDecimal(row["GGBSActual"]),

                    TotalActual = Convert.ToDecimal(row["TotalActual"])
                };

                list.Add(item);
            }

            return list;
        }

        private async Task<bool> IsInternetAvailableAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        private void AddHeaders()
        {
            _httpClient.DefaultRequestHeaders.Remove("X-API-Key");
            _httpClient.DefaultRequestHeaders.Remove("X-Company-Name");
            _httpClient.DefaultRequestHeaders.Remove("X-Location-Name");
            _httpClient.DefaultRequestHeaders.Remove("X-Plant-Name");

            _httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-Company-Name", _companyName);
            _httpClient.DefaultRequestHeaders.Add("X-Location-Name", _locationName);
            _httpClient.DefaultRequestHeaders.Add("X-Plant-Name", _plantName);
        }

        private async Task<bool> SendToApiAsync(string endpoint, object data)
        {
            try
            {
                AddHeaders();

                var payload = JsonConvert.SerializeObject(new { data }, Formatting.Indented);

                // 🔍 Print to Output Window (Visual Studio)
                System.Diagnostics.Debug.WriteLine(payload);

                // 🔍 Optional: Save to file
                System.IO.File.AppendAllText(
                    "LastSyncPayload.json",
                    $"[{DateTime.Now}]\n{payload}\n\n"
                );
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_apiUrl}{endpoint}", content);

                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
        }


        //  MARK AS SYNCED USING SP
        private void MarkAsSynced(int PlcDataId)
        {
            SQLHelper._objCmd = new SqlCommand();
            SQLHelper._objCmd.Parameters.Clear();
            SQLHelper._objCmd.Parameters.AddWithValue("@PlcDataId", PlcDataId);
            var result = Queries.UpdateBySP("MarkPlcDataSynced");
            if (result != "")
            {
                Functions.DBKeyErrors(result);
            }
        }

        private List<BreakdownDto> GetBreakdownForSync()
        {
            var list = new List<BreakdownDto>();

            DataTable dt = Functions.GetTableDataBySP("GetBreakdownForSync");

            if (dt == null || dt.Rows.Count == 0)
                return list;

            foreach (DataRow row in dt.Rows)
            {
                var item = new BreakdownDto
                {
                    Id = Convert.ToInt32(row["ID"]),
                    ModelNo = row["ModelNo"]?.ToString(),
                    SerialNo = row["SerialNo"]?.ToString(),
                    FaultStartDate = Convert.ToDateTime(row["FaultStartDate"]).ToString("yyyy-MM-dd"),
                    FaultStopDate = Convert.ToDateTime(row["FaultStopDate"]).ToString("yyyy-MM-dd"),
                    InchargeName = row["InchargeName"]?.ToString(),
                    EngineerName = row["EngineerName"]?.ToString(),
                    EngineerMobileNo = row["EngineerMobileNo"]?.ToString(),
                    FaultTypeNames = row["FaultTypeNames"]?.ToString(),
                    ActualFaultNames = row["ActualFaultNames"]?.ToString(),
                    WorkCarriedOutNames = row["WorkCarriedOutNames"]?.ToString()
                };

                list.Add(item);
            }

            return list;
        }
        private void MarkBreakdownSynced(int id)
        {
            SQLHelper._objCmd = new SqlCommand();
            SQLHelper._objCmd.Parameters.Clear();
            SQLHelper._objCmd.Parameters.AddWithValue("@ID", id);
            var result = Queries.UpdateBySP("MarkBreakdownSynced");
            if (result != "")
            {
                Functions.DBKeyErrors(result);
            }
        }

        private List<NotesDto> GetNotesForSync()
        {
            var list = new List<NotesDto>();

            DataTable dt = Functions.GetTableDataBySP("GetNotesForSync");

            if (dt == null || dt.Rows.Count == 0)
                return list;

            foreach (DataRow row in dt.Rows)
            {
                var item = new NotesDto
                {
                    Id = Convert.ToInt32(row["ID"]),
                    NoteDate = Convert.ToDateTime(row["NoteDate"]).ToString("yyyy-MM-dd"),
                    NoteRemarks = row["NoteRemarks"]?.ToString()
                };

                list.Add(item);
            }

            return list;
        }

        private void MarkNotesSynced(int id)
        {
            SQLHelper._objCmd = new SqlCommand();
            SQLHelper._objCmd.Parameters.Clear();
            SQLHelper._objCmd.Parameters.AddWithValue("@ID", id);
            var result = Queries.UpdateBySP("MarkNotesSynced");
            if (result != "")
            {
                Functions.DBKeyErrors(result);
            }
        }


    }
}

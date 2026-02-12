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
        private readonly string _apiUrl = "http://192.168.1.82:8000";
        private readonly string _apiKey = "nk-ingest-2026-secret-key";
        private string _companyName = "YourCompany";
        private string _locationName = "YourLocation";
        private string _plantName = "Plant-1";

        public PlcSyncManager() { }

        // 🔥 MAIN METHOD TO CALL FROM TIMER
        public async Task ExecuteSyncAsync()
        {
            if (!IsInternetAvailable())
                return;

            if (!UpdateCompanyInfo())
                return;

            var records = GetDataFromSP();

            if (records == null || records.Count == 0)
                return;

            string payload = BuildPayload(records);

            bool isSuccess = await SendToApi(payload);

            if (isSuccess)
            {
                foreach (var record in records)
                {
                    MarkAsSynced(record.Id); // or use your Primary Key
                }
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

        // 🌐 INTERNET CHECK
        private bool IsInternetAvailable()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync("http://192.168.1.82:8000/health").Result;
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        // 🧾 BUILD JSON WRAPPER
        private string BuildPayload(List<PlcJson> data)
        {
            var wrapper = new
            {
                data = data
            };

            return JsonConvert.SerializeObject(wrapper);
        }

        // 🚀 SEND TO API WITH HEADERS
        private async Task<bool> SendToApi(string payload)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-API-Key", _apiKey);
                    client.DefaultRequestHeaders.Add("X-Company-Name", _companyName);
                    client.DefaultRequestHeaders.Add("X-Location-Name", _locationName);
                    client.DefaultRequestHeaders.Add("X-Plant-Name", _plantName);

                    var content = new StringContent(payload, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(_apiUrl, content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
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
    }
}

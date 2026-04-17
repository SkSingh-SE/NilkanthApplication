using Microsoft.Reporting.WinForms;
using NilkanthApplication.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NilkanthApplication
{
    public class ReportPdfService
    {
        private readonly string _mainRdlcPath;

        public ReportPdfService(string mainRdlcPath)
        {
            _mainRdlcPath = mainRdlcPath;
        }

        public async Task<TripReportResult> GenerateTripReportPdfAsync(
    List<int> batchNumbers,
    string fromDate,
    string toDate = "")
        {
            try
            {
                string batches = string.Join(",", batchNumbers);

                //  MAIN DATA (same as ReportTrip_Load)
                DataTable dt3 = await Task.Run(() =>
                    Functions.GetTableDataBySPWithParam(
                        "TripReportData_Select3",
                        $"@BatchNos='{batches}',@Date='{fromDate}',@Date2='{(string.IsNullOrWhiteSpace(toDate) ? "" : toDate)}'")
                );

                if (dt3 == null || dt3.Rows.Count == 0)
                    throw new Exception("No data returned for report.");

                DataTable dt2ForTotal = null;

                //  CREATE LOCAL REPORT
                LocalReport report = new LocalReport();
                //report.ReportPath = _mainRdlcPath;
                report.EnableExternalImages = true;

                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("TripDS3", dt3));
                report.ReportEmbeddedResource = "NilkanthApplication.MultipalTrip.rdlc";

                //  IMPORTANT — EXACT COPY OF FORM SUBREPORT LOGIC
                report.SubreportProcessing += (sender, e) =>
                {
                    string batchNo = e.Parameters["BatchNo"].Values.First();

                    DataTable dt1 = Functions.GetTableDataBySPWithParam(
                        "TripReportData_Select1",
                        $"@BatchNo='{batchNo}',@Date='{fromDate}',@Date2='{(string.IsNullOrWhiteSpace(toDate) ? "" : toDate)}'");

                    DataTable dt2 = Functions.GetTableDataBySPWithParam(
                        "TripReportData_Select2",
                        $"@BatchNo='{batchNo}',@Date='{fromDate}',@Date2='{(string.IsNullOrWhiteSpace(toDate) ? "" : toDate)}'");

                    dt2ForTotal = dt2;

                    e.DataSources.Add(new ReportDataSource("TripDS1", dt1));
                    e.DataSources.Add(new ReportDataSource("TripDS2", dt2));
                    e.DataSources.Add(new ReportDataSource("TripDS3", dt3));
                };

                //  SET PARAMETERS
                report.SetParameters(new ReportParameter[]
                {
            new ReportParameter("cycle_starttime", ""),
            new ReportParameter("cycle_endtime", ""),
            new ReportParameter("total_duration", ""),
            new ReportParameter("BatchNo", batches),
            new ReportParameter("Date", fromDate)
                });

                //  IMPORTANT — MUST REFRESH BEFORE RENDER
                report.Refresh();

                //  RENDER PDF (use simple overload)
                byte[] pdfBytes = report.Render("PDF");

                //  SAVE FILE
                string reportsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NilkanthReports");
                if (!Directory.Exists(reportsDir))
                    Directory.CreateDirectory(reportsDir);

                string fileName = $"BatchReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = Path.Combine(reportsDir, fileName);

                File.WriteAllBytes(filePath, pdfBytes);

                string companyName = "";
                if (dt3.Columns.Contains("CompanyName") && dt3.Rows.Count > 0)
                    companyName = dt3.Rows[0]["CompanyName"].ToString();

                decimal totalActualCuM = 0;
                if (dt2ForTotal != null && dt2ForTotal.Rows.Count > 0)
                {
                    DataRow row = dt2ForTotal.AsEnumerable().FirstOrDefault(r => r["Title"].ToString() == "Total Act");

                    if (row != null)
                    {
                        totalActualCuM = row != null ? Convert.ToDecimal(row["Total"]) : 0;
                    }
                }


                //Extractor data for TripReportResult DTO to return to caller (for display in UI or other use)
                var result = new TripReportResult();

                result.FilePath = filePath;

                // -------- Static --------
                result.Date = fromDate;
                result.BatchNo = batches;

                // -------- Extract from dt3 (Main header data) --------
                if (dt3.Rows.Count > 0)
                {
                    var row = dt3.Rows[0];



                    result.CustomerName = dt3.Columns.Contains("ClientName")
                        ? row["ClientName"]?.ToString()
                        : "-";

                    result.Site = dt3.Columns.Contains("BatchNo")
                        ? row["BatchNo"]?.ToString()
                        : "-";
                    result.Site = dt3.Columns.Contains("SiteName")
                        ? row["SiteName"]?.ToString()
                        : "-";
                    result.SetCuM = dt3.Columns.Contains("SetBatches")
                        ? row["SetBatches"]?.ToString()
                        : "-";
                    result.ActCuM = dt3.Columns.Contains("ActCUM")
                        ? row["ActCUM"]?.ToString()
                        : "-";
                    result.DriverName = dt3.Columns.Contains("DriverName") ? row["DriverName"]?.ToString()
                        : "-";
                    result.TruckNo = dt3.Columns.Contains("TruckNo") ? row["TruckNo"]?.ToString()
                        : "-";
                    result.CompanyName = dt3.Columns.Contains("CompanyName")
                        ? row["CompanyName"]?.ToString()
                        : "-";

                }


                return result;


            }
            catch (Exception ex)
            {
                throw new Exception("Failed to generate PDF: " + ex.Message, ex);
            }
        }


        public async Task<ConsumptionReportResult> GenerateConsumptionPdf(
        string applyDate, string applyTime, string applyYearMonth,
        string fromDate, string toDate, string year, string month,
        string fromTime, string toTime, string client, string site,
        string recipe, string truckNo, string mqube)
        {
            DataTable dt = await Task.Run(() =>
                Functions.GetTableDataBySPWithParam("ConsumptionReportData_Select",
                $"@ApplyDateFilter='{applyDate}',@ApplyTimeFilter='{applyTime}',@ApplyYearMonthFilter='{applyYearMonth}'," +
                $"@Year='{year}',@Month='{month}',@FromDate='{fromDate}',@ToDate='{toDate}',@FromTime='{fromTime}'," +
                $"@ToTime='{toTime}',@Client='{client}',@Site='{site}',@Recipe='{recipe}',@TruckNo='{truckNo}'"));

            LocalReport report = new LocalReport();
            //report.ReportPath = _mainRdlcPath;
            report.DataSources.Add(new ReportDataSource("ConsumptionDS", dt));
            report.ReportEmbeddedResource = "NilkanthApplication.Consumption.rdlc";

            // -------- COMPANY DATA --------
            DataTable dtCompany = Functions.GetTableData(
                "select top 1 CompanyName, Address, MobileNo, GstNo, CompanyLogo, ShowHeader from CompanyMaster");

            string companyName = "";
            string companyAddress = "";
            string companyMobile = "";
            string companyGst = "";
            byte[] logoBytes = null;
            bool showHeader = false;

            if (dtCompany.Rows.Count > 0)
            {
                var row = dtCompany.Rows[0];

                companyName = row["CompanyName"].ToString();
                companyAddress = row["Address"].ToString();
                companyMobile = row["MobileNo"].ToString();
                companyGst = row["GstNo"].ToString();
                showHeader = Convert.ToBoolean(row["ShowHeader"]);

                if (row["CompanyLogo"] != DBNull.Value)
                    logoBytes = (byte[])row["CompanyLogo"];
            }

            // -------- REPORT PARAMETERS --------
            ReportParameter[] parameters = new ReportParameter[]
            {
            new ReportParameter("From_Date", fromDate ?? ""),
            new ReportParameter("To_Date", toDate ?? ""),
            new ReportParameter("From_Time", fromTime ?? ""),
            new ReportParameter("To_Time", toTime ?? ""),
            new ReportParameter("Client_Name", client ?? ""),
            new ReportParameter("Site_Name", site ?? ""),
            new ReportParameter("Recipe_Name", recipe ?? ""),
            new ReportParameter("Truck_No", truckNo ?? ""),
            new ReportParameter("Year", year ?? ""),
            new ReportParameter("Month", month ?? ""),
            new ReportParameter("MQube", mqube ?? ""),

            new ReportParameter("CompanyName", companyName),
            new ReportParameter("CompanyAddress", companyAddress),
            new ReportParameter("CompanyMobile", companyMobile),
            new ReportParameter("CompanyGST", companyGst),
            new ReportParameter("ShowHeader", showHeader.ToString()),
            new ReportParameter("CompanyLogo",logoBytes != null ? Convert.ToBase64String(logoBytes) : null,true)
            };

            report.SetParameters(parameters);
            report.Refresh();

            byte[] pdfBytes = report.Render("PDF");

            string reportsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NilkanthReports");

            if (!Directory.Exists(reportsDir))
                Directory.CreateDirectory(reportsDir);

            string filePath = Path.Combine(reportsDir, $"Consumption_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            File.WriteAllBytes(filePath, pdfBytes);

            return new ConsumptionReportResult
            {
                FilePath = filePath,
                ClientName = client,
                FromDate = fromDate,
                ToDate = toDate,
                TotalCuM = mqube,
                CompanyName = (string)Functions.GetSingleValue("select CompanyName from CompanyMaster")
            };
        }

        public async Task<ProductionReportResult> GenerateProductionReportPdf(
       string applyDate, string applyYearMonth,
       string fromDate, string toDate,
       string year, string month,
       string fromBatch, string toBatch,
       string client, string site, string recipe, string truck)
        {
            try
            {


                DataTable dt = await Task.Run(() =>
                    Functions.GetTableDataBySPWithParam("ProductReportData_Select",
                    $"@ApplyDateFilter='{applyDate}',@FromDate='{fromDate}',@ToDate='{toDate}'," +
                    $"@ApplyYearMonthFilter='{applyYearMonth}',@Year='{year}',@Month='{month}'," +
                    $"@FromBatchNo='{fromBatch}',@ToBatchNo='{toBatch}',@Client='{client}'," +
                    $"@Site='{site}',@Recipe='{recipe}',@TruckNo='{truck}'"));

                LocalReport report = new LocalReport();
                //report.ReportPath = _mainRdlcPath;
                report.DataSources.Add(new ReportDataSource("ProductionDS", dt));
                report.ReportEmbeddedResource = "NilkanthApplication.Production.rdlc";

                DataTable dtCompany = Functions.GetTableData("select top 1 CompanyName, Address, MobileNo, GstNo, CompanyLogo, ShowHeader from CompanyMaster");
                string companyName = "";
                string companyAddress = "";
                string companyMobile = "";
                string companyGst = "";
                byte[] logoBytes = null;
                bool showHeader = false;

                if (dtCompany.Rows.Count > 0)
                {
                    var row = dtCompany.Rows[0];

                    companyName = row["CompanyName"].ToString();
                    companyAddress = row["Address"].ToString();
                    companyMobile = row["MobileNo"].ToString();
                    companyGst = row["GstNo"].ToString();
                    showHeader = Convert.ToBoolean(row["ShowHeader"]);
                    if (row["CompanyLogo"] != DBNull.Value)
                    {
                        logoBytes = (byte[])row["CompanyLogo"];
                    }
                }
                // ---------- REPORT PARAMETERS ----------
                ReportParameter[] parameters = new ReportParameter[]
                {
                new ReportParameter("From_Date", fromDate ?? ""),
                new ReportParameter("To_Date", toDate ?? ""),
                new ReportParameter("Client_Name", client ?? ""),
                new ReportParameter("From_Batch", fromBatch ?? ""),
                new ReportParameter("To_Batch", toBatch ?? ""),
                new ReportParameter("Site_Name", site ?? ""),
                new ReportParameter("Recipe_Name", recipe ?? ""),
                new ReportParameter("Truck_No", truck ?? ""),
                new ReportParameter("Year", year ?? ""),
                new ReportParameter("Month", month ?? ""),
                new ReportParameter("CompanyName", companyName),
                new ReportParameter("CompanyAddress", companyAddress),
                new ReportParameter("CompanyMobile", companyMobile),
                new ReportParameter("CompanyGST", companyGst),
                new ReportParameter("ShowHeader", showHeader.ToString()),
                new ReportParameter("CompanyLogo",logoBytes != null ? Convert.ToBase64String(logoBytes) : null,true)
            };

                report.SetParameters(parameters);


                report.Refresh();

                byte[] pdfBytes = report.Render("PDF");

                string reportsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"NilkanthReports");
                if (!Directory.Exists(reportsDir))
                    Directory.CreateDirectory(reportsDir);

                string filePath = Path.Combine(reportsDir, $"Production_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
                File.WriteAllBytes(filePath, pdfBytes);

                // calculate total CuM from grid result (same logic as screen)
                double total = 0;
                foreach (DataRow row in dt.Rows)
                    total += Convert.ToDouble(row["MQube"]);

                return new ProductionReportResult
                {
                    FilePath = filePath,
                    ClientName = client,
                    FromDate = fromDate,
                    ToDate = toDate,
                    TotalCuM = total.ToString("0.00"),
                    CompanyName = (string)Functions.GetSingleValue("select CompanyName from CompanyMaster")
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeliveryChallanResult> GenerateDeliveryChallanPdf(int deliveryChallanId)
        {
            try
            {
                DataTable dt = await Task.Run(() =>
                    Functions.GetTableDataBySPWithParam(
                        "DeliveryChallan_Report",
                        $"@DeliveryChallanId='{deliveryChallanId}'"));

                if (dt == null || dt.Rows.Count == 0)
                    throw new Exception("No data returned for Delivery Challan.");

                LocalReport report = new LocalReport();
                //report.ReportPath = _mainRdlcPath;

                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("DeliveryChallanReportDataSet", dt));
                report.ReportEmbeddedResource = "NilkanthApplication.rptDeliveryChallan.rdlc";

                report.Refresh();

                byte[] pdfBytes = report.Render("PDF");

                string reportsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NilkanthReports");

                if (!Directory.Exists(reportsDir))
                    Directory.CreateDirectory(reportsDir);

                string filePath = Path.Combine(
                    reportsDir,
                    $"DeliveryChallan_{deliveryChallanId}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                File.WriteAllBytes(filePath, pdfBytes);

                var result = new DeliveryChallanResult();

                result.FilePath = filePath;

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];

                    result.ClientName = dt.Columns.Contains("ClientName") ? row["ClientName"]?.ToString() : "-";
                    result.Date = dt.Columns.Contains("DeliveryChallanDate") ? row["DeliveryChallanDate"]?.ToString() : "-";
                    result.ChallanNo = dt.Columns.Contains("DeliveryChallanNo") ? row["DeliveryChallanNo"]?.ToString() : "-";
                    result.BatchNo = dt.Columns.Contains("BatchNo") ? row["BatchNo"]?.ToString() : "-";
                    result.DriverName = dt.Columns.Contains("DriverName") ? row["DriverName"]?.ToString() : "-";
                    result.TruckNo = dt.Columns.Contains("TruckNo") ? row["TruckNo"]?.ToString() : "-";
                    result.CycleStart = dt.Columns.Contains("CycleStartTime") ? row["CycleStartTime"]?.ToString() : "-";
                    result.CycleEnd = dt.Columns.Contains("CycleEndTime") ? row["CycleEndTime"]?.ToString() : "-";
                    result.CompanyName = dt.Columns.Contains("CompanyName") ? row["CompanyName"]?.ToString() : "-";
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to generate Delivery Challan PDF: " + ex.Message, ex);
            }
        }
    }
}

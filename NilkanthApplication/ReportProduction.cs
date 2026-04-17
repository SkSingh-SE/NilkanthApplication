using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class ReportProduction : Form
    {
        string Aplyear = "";
        string Aplmonth = "";
        string fromdate = "";
        string todate = "";
        string client = "";
        string site = "";
        string recipe = "";
        string truckno = "";
        string frombatch = "";
        string tobatch = "";
        string appDate = "False";
        string appYearMonth = "False";
        

        public ReportProduction(string applydate,string applyyearmonth, string fdate, string tdate, string year, string month, string fbatch, string tbatch, string clientname, string sitename, string recipename, string trucknum)
        {
            InitializeComponent();

            this.appDate = applydate;
            this.appYearMonth = applyyearmonth;

            if (this.appDate != "False")
            {
                this.fromdate = fdate;
                this.todate = tdate;
            }

            if(this.appYearMonth != "False")
            {
                this.Aplyear = year;
                this.Aplmonth = month;
            }
            
            this.frombatch = fbatch;
            this.tobatch = tbatch;
            this.client = clientname;
            this.site = sitename;
            this.recipe = recipename;
            this.truckno = trucknum;
        }

        private void ReportProduction_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetSPResult();
                reportViewer1.Visible = true;
                this.reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ProductionDS", dt));

                string fdate = "";
                string tdate = "";

                if (this.appDate != "False")
                {
                    fdate = Convert.ToDateTime(this.fromdate).Date.ToShortDateString();
                    tdate = Convert.ToDateTime(this.todate).Date.ToShortDateString();
                }

                DataTable dtCompany = Functions.GetTableData("select top 1 CompanyName, Address, MobileNo, GstNo, CompanyLogo, ShowHeader from CompanyMaster");
                string companyName = "";
                string companyAddress = "";
                string companyMobile = "";
                string companyGst = "";
                string companyLogoBase64 = "";
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
                        companyLogoBase64 = Convert.ToBase64String(logoBytes);
                    }
                }

                ReportParameter p1 = new ReportParameter("From_Date", fdate);
                ReportParameter p2 = new ReportParameter("To_Date", tdate);
                ReportParameter p3 = new ReportParameter("Client_Name", client);
                ReportParameter p4 = new ReportParameter("From_Batch", frombatch);
                ReportParameter p5 = new ReportParameter("To_Batch", tobatch);
                ReportParameter p6 = new ReportParameter("Site_Name", site);
                ReportParameter p7 = new ReportParameter("Recipe_Name", recipe);
                ReportParameter p8 = new ReportParameter("Truck_No", truckno);
                ReportParameter p9 = new ReportParameter("Year", Aplyear);
                ReportParameter p10 = new ReportParameter("Month", Aplmonth);

                ReportParameter p11 = new ReportParameter("CompanyName", companyName);
                ReportParameter p12 = new ReportParameter("CompanyAddress", companyAddress);
                ReportParameter p13 = new ReportParameter("CompanyMobile", companyMobile);
                ReportParameter p14 = new ReportParameter("CompanyGST", companyGst);
                ReportParameter p15 = new ReportParameter("ShowHeader", showHeader.ToString());
                ReportParameter logoParam = new ReportParameter("CompanyLogo", logoBytes != null ? Convert.ToBase64String(logoBytes) : null, true);

                reportViewer1.LocalReport.SetParameters(new ReportParameter[]
                {
                    p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,
                    p11,p12,p13,p14,p15
                });
                reportViewer1.LocalReport.SetParameters(logoParam);


                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.reportViewer1.RefreshReport();
        }
        private void Print(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.PrintDialog();
                PageSetupDialog setupDlg = new PageSetupDialog();
                PrintDocument printDoc = new PrintDocument();
                setupDlg.Document = printDoc;
                setupDlg.AllowMargins = false;
                setupDlg.AllowOrientation = false;
                setupDlg.AllowPaper = false;
                setupDlg.AllowPrinter = false;
                setupDlg.Reset();
                printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 900, 900);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable GetSPResult()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Functions.GetTableDataBySPWithParam("ProductReportData_Select", string.Concat(new string[]
               {
                        
                        "@ApplyDateFilter='",
                        this.appDate,
                        "',@FromDate='",
                        fromdate,
                        "',@ToDate='",
                        todate,
                        "',@ApplyYearMonthFilter='",
                        this.appYearMonth,
                        "',@Year='",
                        Aplyear,
                        "',@Month='",
                        Aplmonth,
                        "',@FromBatchNo='",
                        frombatch,
                        "',@ToBatchNo='",
                        tobatch,
                        "',@Client='",
                        client,
                        "',@Site='",
                        site,
                        "',@Recipe='",
                        recipe,
                        "',@TruckNo='",
                        truckno,
                        "'"

               }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // MainScreen mainScreen = new MainScreen();
                base.Hide();
                //mainScreen.Show();
                //mainScreen.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class ReportTrip : Form
    {

        string batches = "";
        //string tobatch = "";
        string date = "";
        string toDate = "";
        DataTable dt3Global;
        //public ReportTrip(string[] BatchDateDetails)
        public ReportTrip(string batchnos,string fromDate, string toDate = "")
        {
            InitializeComponent();
            this.batches = batchnos;
            date = fromDate;
            this.toDate = toDate;
            //this.tobatch = tobatchno;
        }

        private void ReportTrip_Load(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt1 = GetSPResult1();
                //DataTable dt2 = GetSPResult2();
                DataTable dt3 = GetSPResult3();
                dt3Global = dt3;


                reportViewer1.Visible = true;
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                string exeFolder = Application.StartupPath;
                string reportPath = Path.Combine(exeFolder, "MultipalTrip.rdlc");

                //reportViewer1.LocalReport.ReportPath = @"D:\Nishant\Projects\NilkanthApplication\Project\NilkanthApplication\NilkanthApplication\MultipalTrip.rdlc";
                //reportViewer1.LocalReport.ReportPath = "MultipalTrip.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                
                //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TripDS2", dt2));
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TripDS3", dt3));
                //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TripDS1", dt1));
                this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(prcProcessSubreport);

                //string[] startTimeArr = dt1.Rows[0][1].ToString().Split(':');
                //string cycleStartTime = startTimeArr[0] + ":" + startTimeArr[1] + "   : 00" + startTimeArr[2];

                //string[] endTimeArr = dt1.Rows[dt1.Rows.Count - 1][1].ToString().Split(':');
                //string cycleEndTime = endTimeArr[0] + ":" + endTimeArr[1] + "   : 00" + endTimeArr[2];

                //DateTime d1 = new DateTime(2023, 01, 01, Convert.ToInt32(startTimeArr[0]), Convert.ToInt32(startTimeArr[1]), Convert.ToInt32(startTimeArr[2]));
                //DateTime d2 = new DateTime(2023, 01, 01, Convert.ToInt32(endTimeArr[0]), Convert.ToInt32(endTimeArr[1]), Convert.ToInt32(endTimeArr[2]));

                //TimeSpan ts = d2 - d1;
                //string diffHours = "", diffMinutes = "", diffSeconds = "";

                //diffHours = ts.Hours >= 0 && ts.Hours < 10 ? "0" + ts.Hours : ts.Hours.ToString();
                //diffMinutes = ts.Minutes >= 0 && ts.Minutes < 10 ? "0" + ts.Minutes : ts.Minutes.ToString();
                //diffSeconds = ts.Seconds >= 0 && ts.Seconds < 10 ? "0" + ts.Seconds : ts.Seconds.ToString();

                //string totalDuration = diffHours + ":" + diffMinutes + "   : 00" + diffSeconds;

                ReportParameter p1 = new ReportParameter("cycle_starttime", "");
                ReportParameter p2 = new ReportParameter("cycle_endtime", "");
                ReportParameter p3 = new ReportParameter("total_duration", "");
                //ReportParameter p4 = new ReportParameter("BatchNo", this.batch);
                ReportParameter p4 = new ReportParameter("BatchNo", this.batches);
                ReportParameter p5 = new ReportParameter("Date", this.date);

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p2 });
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p3 });
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p4 });
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p5 });

                //SubreportProcessingEventHandler



                //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TripDS1", dt1));
                this.reportViewer1.Refresh();
                this.reportViewer1.RefreshReport();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.reportViewer1.RefreshReport();
        }

        void prcProcessSubreport(object sender, SubreportProcessingEventArgs e)
        {
            int showVarPInKg = 0;

            if (dt3Global != null && dt3Global.Rows.Count > 0)
            {
                // assuming same flag for all batches
                showVarPInKg = Convert.ToInt32(dt3Global.Rows[0]["ShowVarPInKg"]);
            }

            if (e.ReportPath == "MultipalTripSub")
            {
                var mainSource = ((LocalReport)sender).DataSources["TripDS3"];
                string batchNo = e.Parameters["BatchNo"].Values.First();

                
                //var subSource = ((List<TripReportData>)mainSource.Value).Single(a => a.BatchNo == batchNo);
                DataTable dt1 = GetSPResult1(batchNo);
                e.DataSources.Add(new ReportDataSource("TripDS1", dt1));
                DataTable dt2 = GetSPResult2(batchNo);
                e.DataSources.Add(new ReportDataSource("TripDS2", dt2));
                DataTable dt3 = dt3Global;
                e.DataSources.Add(new ReportDataSource("TripDS3", dt3));
                //string BatchNo = e.Parameters["BatchNo"].Values[0].ToString();
                //DataTable dt = GetSPResult(BatchNo);
                //e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TripDS1", dt));




                string[] startTimeArr = dt1.Rows[0][1].ToString().Split(':');
                string cycleStartTime = startTimeArr[0] + ":" + startTimeArr[1] + "   : 00" + startTimeArr[2];

                string[] endTimeArr = dt1.Rows[dt1.Rows.Count - 1][1].ToString().Split(':');
                string cycleEndTime = endTimeArr[0] + ":" + endTimeArr[1] + "   : 00" + endTimeArr[2];

                DateTime d1 = new DateTime(2023, 01, 01, Convert.ToInt32(startTimeArr[0]), Convert.ToInt32(startTimeArr[1]), Convert.ToInt32(startTimeArr[2]));
                DateTime d2 = new DateTime(2023, 01, 01, Convert.ToInt32(endTimeArr[0]), Convert.ToInt32(endTimeArr[1]), Convert.ToInt32(endTimeArr[2]));

                TimeSpan ts = d2 - d1;
                string diffHours = "", diffMinutes = "", diffSeconds = "";

                diffHours = ts.Hours >= 0 && ts.Hours < 10 ? "0" + ts.Hours : ts.Hours.ToString();
                diffMinutes = ts.Minutes >= 0 && ts.Minutes < 10 ? "0" + ts.Minutes : ts.Minutes.ToString();
                diffSeconds = ts.Seconds >= 0 && ts.Seconds < 10 ? "0" + ts.Seconds : ts.Seconds.ToString();

                string totalDuration = diffHours + ":" + diffMinutes + "   : 00" + diffSeconds;

                //ReportParameter p1 = new ReportParameter("cycle_starttime", cycleStartTime);
                //ReportParameter p2 = new ReportParameter("cycle_endtime", cycleEndTime);
                //ReportParameter p3 = new ReportParameter("total_duration", totalDuration);
                //ReportParameter p4 = new ReportParameter("BatchNo", batchNo);

                //e.Parameters["cycle_starttime"].Values[0] = cycleStartTime;
                //e.Parameters["cycle_endtime"].Values[0] = cycleEndTime;
                //e.Parameters["total_duration"].Values[0] = totalDuration;
                //e.Parameters["BatchNo"].Values[0] = batchNo;

                //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p2 });
                //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p3 });
                //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p4 });
            }
        }

       

        private DataTable GetSPResult1(string BNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Functions.GetTableDataBySPWithParam("TripReportData_Select1", string.Concat(new string[]
               {
                        "@BatchNo='",
                        BNo,
                        "',@Date='",
                        this.date,
                         "',@Date2='",
                        string.IsNullOrWhiteSpace(this.toDate) ? null : this.toDate,
                        "'"
               }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private DataTable GetSPResult2(string BNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Functions.GetTableDataBySPWithParam("TripReportData_Select2", string.Concat(new string[]
               {
                        "@BatchNo='",
                         BNo,
                        "',@Date='",
                        this.date,
                         "',@Date2='",
                        string.IsNullOrWhiteSpace(this.toDate) ? null : this.toDate,
                        "'"
               }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        private DataTable GetSPResult3()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Functions.GetTableDataBySPWithParam("TripReportData_Select3", string.Concat(new string[]
               {
                        "@BatchNos='",
                        this.batches,
                        "',@Date='",
                        this.date,
                        //"'"
                        "',@Date2='",
                        string.IsNullOrWhiteSpace(this.toDate) ? null : this.toDate,
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
    public class TripReportData
    {
        public int BatchNo { get; set; }

        public double CycleNo { get; set; }

        public string Time { get; set; }

        public double Bin1 { get; set; }

        public double Bin2 { get; set; }

        public double Bin3 { get; set; }

        public double Bin4 { get; set; }

        public double Cement { get; set; }

        public double Flyash { get; set; }

        public double Water { get; set; }

        public double Aditive { get; set; }

        public double Total { get; set; }
    }
}

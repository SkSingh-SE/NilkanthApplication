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
    public partial class ReportDeliveryChallan : Form
    {
        private int _deliveryChallanId;
        public ReportDeliveryChallan(int deliveryChallanId)
        {
            InitializeComponent();
            _deliveryChallanId = deliveryChallanId;
        }

        private void ReportDeliveryChallan_Load(object sender, EventArgs e)
        {
            DataTable dataTable = GetDeliveryReportBySP();
            reportViewer1.Visible = true;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            ReportDataSource rds = new ReportDataSource("DeliveryChallanReportDataSet", dataTable);
            string reportPath = Path.Combine(Application.StartupPath, @"..\..\rptDeliveryChallan.rdlc");
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.RefreshReport();
        }
        private DataTable GetDeliveryReportBySP()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Functions.GetTableDataBySPWithParam("DeliveryChallan_Report", string.Concat(new string[]
               {
                        "@DeliveryChallanId='",
                        this._deliveryChallanId.ToString(),
                        "'"
               }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
    }
}

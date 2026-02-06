using Org.BouncyCastle.Asn1.Cms;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class ConsumptionReport : Form
    {
        public ConsumptionReport()
        {
            this.InitializeComponent();
            this.contextMenuStrip1.ItemClicked += this.ContextMenuStrip1_ItemClicked;
        }
        bool isPageLoad = false;
        private void ConsumptionReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.isPageLoad = true;
                this.BindClient();
                this.BindSite("");
                this.BindRecipe("");
                this.BindTruck("");
                this.BindComparisonGrid();
                this.BindYear();
                this.BindClientMaster();
                this.ShowWhatsapp();
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.chkApplyTimeFilter.Enabled = false;
                isPageLoad = false;

                string fDate = DateTime.Now.ToShortDateString();
                string[] fDateArr = fDate.Split('-');
                string fDateVal = "01" + "-" + fDateArr[1] + "-" + fDateArr[2];

                this.dtpFromDate.Value = Convert.ToDateTime(fDateVal);
                this.chkApplyDateFilter.Checked = true;
                this.dtpFromTime.Enabled = false;
                this.dtpToTime.Enabled = false;
                this.cmbYear.Enabled = false;
                this.cmbMonth.Enabled = false;
                //this.BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindClient()
        {
            try
            {
                this.dataTable = new DataTable();
                this.dataTable = Functions.GetTableDataBySP("PLCData_ClientName_Select");
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Client";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbClient.DataSource = this.dataTable;
                this.cmbClient.DisplayMember = "ClientName";
                this.cmbClient.ValueMember = "SrNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindSite(string ClientName)
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_SiteName_Select", string.Concat(new string[]
                {
                        "@ClientName='",
                        ClientName,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Site";
                dataTable.Rows.InsertAt(dataRow, 0);


                this.cmbSite.DataSource = this.dataTable;
                this.cmbSite.DisplayMember = "SiteName";
                this.cmbSite.ValueMember = "SrNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindRecipe(string ClientName)
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_RecipeName_Select", string.Concat(new string[]
                {
                        "@ClientName='",
                        ClientName,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Recipe";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbRecipe.DataSource = this.dataTable;
                this.cmbRecipe.DisplayMember = "RecipeName";
                this.cmbRecipe.ValueMember = "SrNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindTruck(string ClientName)
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_TruckNo_Select", string.Concat(new string[]
                {
                        "@ClientName='",
                        ClientName,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Truck";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbTruckNo.DataSource = this.dataTable;
                this.cmbTruckNo.DisplayMember = "TruckNo";
                this.cmbTruckNo.ValueMember = "SrNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindYear()
        {
            try
            {
                this.dataTable = new DataTable();
                this.dataTable = Functions.GetTableDataBySP("Dashboard_Year_Select");
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Year";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbYear.DataSource = this.dataTable;
                this.cmbYear.DisplayMember = "YEARS";
                this.cmbYear.ValueMember = "SrNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindMonth(string year)
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_Month_Select", string.Concat(new string[]
                {
                        "@Year='",
                        year,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Month";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbMonth.DataSource = this.dataTable;
                this.cmbMonth.DisplayMember = "Month";
                this.cmbMonth.ValueMember = "MonthNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ConsumptionReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    MainScreen mainScreen = new MainScreen();
                    base.Hide();
                    mainScreen.Show();
                    mainScreen.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                this.contextMenuStrip1.Items.Clear();
                this.contextMenuStrip1.Items.Add("Excel");
                this.contextMenuStrip1.Items.Add("PDF");
                this.contextMenuStrip1.Show(this.btnExport, new Point(0, this.btnExport.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = MessageBox.Show("Are you sure, You want to LogOff?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                if (flag)
                {
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                MainScreen mainScreen = new MainScreen();
                base.Hide();
                mainScreen.Show();
                mainScreen.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                MainScreen mainScreen = new MainScreen();
                base.Hide();
                mainScreen.Show();
                mainScreen.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                MainScreen mainScreen = new MainScreen();
                base.Hide();
                mainScreen.Show();
                mainScreen.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void BindGrid()
        {
            if (this.isPageLoad == false)
            {
                try
                {
                    this.dataTable = new DataTable();

                    //input date string as dd-MM-yyyy HH:mm:ss format
                    string fdate = this.dtpFromDate.Value.ToString();
                    string tdate = this.dtpToDate.Value.ToString();

                    string fromdate = Convert.ToDateTime(fdate).Year.ToString() + "-" + Convert.ToDateTime(fdate).Month.ToString() + "-" + Convert.ToDateTime(fdate).Day.ToString() + " 00:00:00.000";
                    string todate = Convert.ToDateTime(tdate).Year.ToString() + "-" + Convert.ToDateTime(tdate).Month.ToString() + "-" + Convert.ToDateTime(tdate).Day.ToString() + " 00:00:00.000";

                    string client = "";

                    if (cmbClient.SelectedIndex > 0)
                        client = cmbClient.Text;

                    string site = "";

                    if (cmbSite.SelectedIndex > 0)
                        site = cmbSite.Text;

                    string recipe = "";

                    if (cmbRecipe.SelectedIndex > 0)
                        recipe = cmbRecipe.Text;

                    string truckno = "";
                    if (cmbTruckNo.SelectedIndex > 0)
                        truckno = cmbTruckNo.Text;

                    string year = "";
                    if (cmbYear.SelectedIndex > 0)
                        year = cmbYear.Text;

                    string month = "";
                    if (cmbMonth.SelectedIndex > 0)
                        month = cmbMonth.Text;

                    string fromtime = this.dtpFromTime.Value.ToShortTimeString();
                    string totime = this.dtpToTime.Value.ToShortTimeString();

                    this.dataTable = Functions.GetTableDataBySPWithParam("ConsumptionReportData_Select", string.Concat(new string[]
                    {
                        "@ApplyDateFilter='",
                        this.chkApplyDateFilter.Checked.ToString(),
                        "',@ApplyTimeFilter='",
                        this.chkApplyTimeFilter.Checked.ToString(),
                        "',@ApplyYearMonthFilter='",
                        this.chkApplyYearMonth.Checked.ToString(),
                        "',@Year='",
                        year,
                        "',@Month='",
                        month,
                        "',@FromDate='",
                        fromdate,
                        "',@ToDate='",
                        todate,
                        "',@FromTime='",
                        fromtime,
                        "',@ToTime='",
                        totime,
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

                    this.dgvList.DataSource = this.dataTable;
                    bool flag3 = this.dgvList.Rows.Count > 0;
                    if (flag3)
                    {
                        this.dgvList.CurrentCell = this.dgvList.Rows[0].Cells[1];
                        this.dgvList.Rows[0].Selected = true;
                    }
                    dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dgvList.ColumnHeadersHeight = 40;
                    dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //this.dgvList.Columns["AvgSet"].Visible = false;
                    //this.dgvList.Columns["PID"].Visible = false;
                    //this.dgvList.Columns["TransType"].Visible = false;
                    totalActual = 0;
                    totalAvgSet = 0;
                    //avgSet = 0;
                    MQube = 0;
                    for (int i = 0; i < this.dgvList.Rows.Count; i++)
                    {
                        bool flag4 = (i + 1) % 2 != 0;
                        if (flag4)
                        {
                            this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 226, 239, 218);
                        }
                        else
                        {
                            this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                        totalActual = totalActual + Convert.ToDouble(dgvList.Rows[i].Cells[3].Value);
                        ////totalAvgSet = totalAvgSet + Convert.ToDouble(dgvList.Rows[i].Cells[6].Value);
                    }

                    /*if (totalAvgSet == 0)
                    //    MQube = 0;
                    //else
                    //{
                    //    //avgSet = totalSet / this.dgvList.Rows.Count;
                    //    MQube = totalActual / totalAvgSet;
                    //}

                    //MQube = Math.Round(MQube, 2);
                    //lblMQube.Text = string.Format("{0:0.00}", MQube).ToString();*/

                    foreach (DataGridViewColumn column in dgvList.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    //

                    DataTable dataTableMqube = new DataTable();

                    dataTableMqube = Functions.GetTableDataBySPWithParam("ConsumptionReportTotalMqube", string.Concat(new string[]
                    {
                        "@ApplyDateFilter='",
                        this.chkApplyDateFilter.Checked.ToString(),
                        "',@ApplyTimeFilter='",
                        this.chkApplyTimeFilter.Checked.ToString(),
                        "',@ApplyYearMonthFilter='",
                        this.chkApplyYearMonth.Checked.ToString(),
                        "',@Year='",
                        year,
                        "',@Month='",
                        month,
                        "',@FromDate='",
                        fromdate,
                        "',@ToDate='",
                        todate,
                        "',@FromTime='",
                        fromtime,
                        "',@ToTime='",
                        totime,
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

                    for(int i = 0; i<dataTableMqube.Rows.Count; i++)
                    {
                        MQube = MQube + Convert.ToDouble(dataTableMqube.Rows[i][0]);
                    }

                    lblMQube.Text = string.Format("{0:0.00}", MQube).ToString();

                    //

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.contextMenuStrip1.Hide();
                this.contextMenuStrip1.Close();
                Functions.ExportGrid(this.dgvList, e.ClickedItem.Text, "ConsumptionReport", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            bool @checked = this.chkApplyDateFilter.Checked;
            if (@checked)
            {
                this.BindGrid();
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            bool @checked = this.chkApplyDateFilter.Checked;
            if (@checked)
            {
                this.BindGrid();
            }
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.SelectedIndex > 0)
            {
                this.BindSite(this.cmbClient.Text);
                this.BindRecipe(this.cmbClient.Text);
                this.BindTruck(this.cmbClient.Text);
            }
            else
            {
                this.BindSite("");
                this.BindRecipe("");
                this.BindTruck("");
            }

            this.BindGrid();
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void cmbRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void cmbTruckNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private double MQube = 0.00;

        private double totalActual = 0.00;

        private double totalAvgSet = 0.00;

        //private double avgSet = 0.00;

        private DataTable dataTable = null;

        private ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkApplyDateFilter.Checked)
            {
                this.chkApplyTimeFilter.Enabled = true;
                this.chkApplyYearMonth.Enabled = false;
                this.dtpFromDate.Enabled = true;
                this.dtpToDate.Enabled = true;
            }
            else
            {
                this.chkApplyTimeFilter.Enabled = false;
                this.chkApplyYearMonth.Enabled = true;
                this.dtpFromDate.Enabled = false;
                this.dtpToDate.Enabled = false;
            }

            this.BindGrid();
        }

        private void chkApplyTimeFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkApplyTimeFilter.Checked)
            {
                this.dtpFromTime.Enabled = true;
                this.dtpToTime.Enabled = true;
            }
            else
            {
                this.dtpFromTime.Enabled = false;
                this.dtpToTime.Enabled = false;
            }
            this.BindGrid();
        }

        private void dtpFromTime_ValueChanged(object sender, EventArgs e)
        {
            bool @checked = this.chkApplyTimeFilter.Checked;
            if (@checked)
            {
                this.BindGrid();
            }
        }

        private void dtpToTime_ValueChanged(object sender, EventArgs e)
        {
            bool @checked = this.chkApplyTimeFilter.Checked;
            if (@checked)
            {
                this.BindGrid();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string fdate = this.dtpFromDate.Value.ToString();
                string tdate = this.dtpToDate.Value.ToString();

                string fromdate = Convert.ToDateTime(fdate).Year.ToString() + "-" + Convert.ToDateTime(fdate).Month.ToString() + "-" + Convert.ToDateTime(fdate).Day.ToString() + " 00:00:00.000";
                string todate = Convert.ToDateTime(tdate).Year.ToString() + "-" + Convert.ToDateTime(tdate).Month.ToString() + "-" + Convert.ToDateTime(tdate).Day.ToString() + " 00:00:00.000";

                string year = "";
                if (cmbYear.SelectedIndex > 0)
                    year = cmbYear.Text;

                string month = "";
                if (cmbMonth.SelectedIndex > 0)
                    month = cmbMonth.Text;

                string client = "";

                if (cmbClient.SelectedIndex > 0)
                    client = cmbClient.Text;

                string site = "";

                if (cmbSite.SelectedIndex > 0)
                    site = cmbSite.Text;

                string recipe = "";

                if (cmbRecipe.SelectedIndex > 0)
                    recipe = cmbRecipe.Text;

                string truckno = "";
                if (cmbTruckNo.SelectedIndex > 0)
                    truckno = cmbTruckNo.Text;

                string fromtime = this.dtpFromTime.Value.ToShortTimeString();
                string totime = this.dtpToTime.Value.ToShortTimeString();

                ReportConsumption rpt = new ReportConsumption(this.chkApplyDateFilter.Checked.ToString(), this.chkApplyTimeFilter.Checked.ToString(), this.chkApplyYearMonth.Checked.ToString(), fromdate, todate, year, month, fromtime, totime, client, site, recipe, truckno, string.Format("{0:0.00}", MQube).ToString());
                rpt.Show();
                rpt.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            chkApplyDateFilter.Checked = false;
            chkApplyTimeFilter.Checked = false;
            chkApplyYearMonth.Checked = false;
            cmbMonth.DataSource = null;
            cmbYear.SelectedIndex = 0;
            if (cmbClient.SelectedIndex == 0)
            {
                cmbSite.SelectedIndex = 0;
                cmbRecipe.SelectedIndex = 0;
                cmbTruckNo.SelectedIndex = 0;
            }
            else
                cmbClient.SelectedIndex = 0;

            this.BindGrid();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbYear.SelectedIndex > 0)
                this.BindMonth(this.cmbYear.Text);
            else
                this.cmbMonth.DataSource = null;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void chkApplyYearMonth_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = chkApplyYearMonth.Checked;
            if (!@checked)
            {
                this.cmbYear.Enabled = false;
                this.cmbMonth.Enabled = false;
                this.cmbMonth.DataSource = null;
                this.cmbYear.SelectedIndex = 0;
                this.chkApplyDateFilter.Enabled = true;
                this.BindGrid();
            }
            else
            {
                this.cmbYear.Enabled = true;
                this.cmbMonth.Enabled = true;
                this.chkApplyDateFilter.Enabled = false;
                this.chkApplyTimeFilter.Enabled = false;
                this.dtpFromDate.Enabled = false;
                this.dtpToDate.Enabled = false;
            }

        }

        void BindClientMaster()
        {
            try
            {
                this.dataTable = new DataTable();
                DataTable dataTableClientDetails = new DataTable();
                DataColumn dtColumn1 = new DataColumn();
                dtColumn1.DataType = typeof(string);
                dtColumn1.ColumnName = "ID";
                dtColumn1.Caption = "ID";
                dataTableClientDetails.Columns.Add(dtColumn1);

                DataColumn dtColumn2 = new DataColumn();
                dtColumn2.DataType = typeof(string);
                dtColumn2.ColumnName = "ClientDetails";
                dtColumn2.Caption = "ClientDetails";
                dataTableClientDetails.Columns.Add(dtColumn2);

                DataColumn dtColumn3 = new DataColumn();
                dtColumn3.DataType = typeof(string);
                dtColumn3.ColumnName = "MobileNo";
                dtColumn3.Caption = "MobileNo";
                dataTableClientDetails.Columns.Add(dtColumn3);

                this.dataTable = Functions.GetTableDataBySP("ClientMaster_SelectAll");
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Client";
                dataTable.Rows.InsertAt(dataRow, 0);

                if (this.dataTable != null && this.dataTable.Rows.Count > 0)
                {
                    for (int a = 0; a < dataTable.Rows.Count; a++)
                    {
                        dataRow = dataTableClientDetails.NewRow();
                        dataRow[0] = Convert.ToInt32(dataTable.Rows[a]["ID"]);
                        string clientDetails = dataTable.Rows[a]["CompanyName"].ToString() + "-" +
                                dataTable.Rows[a]["PersonName"].ToString() + "-" +
                                dataTable.Rows[a]["MobileNo"].ToString();
                        dataRow[1] = clientDetails;
                        dataRow[2] = dataTable.Rows[a]["MobileNo"];
                        dataTableClientDetails.Rows.InsertAt(dataRow, (a + 1));
                    }
                }

                this.cmbClientDetails.DataSource = dataTableClientDetails;
                this.cmbClientDetails.DisplayMember = "ClientDetails";
                this.cmbClientDetails.ValueMember = "MobileNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void ShowWhatsapp()
        {
            bool IsShowWhatsapp = Convert.ToBoolean(Functions.GetSingleValue("select ShowWhatsapp from CompanyMaster"));
            if (IsShowWhatsapp)
            {
                lblClient.Visible = true;
                cmbClientDetails.Visible = true;
                btnSendWhatsApp.Visible = true;
            }
            else
            {
                lblClient.Visible = false;
                cmbClientDetails.Visible = false;
                btnSendWhatsApp.Visible = false;
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialStockList materialList = new MaterialStockList();
                base.Hide();
                materialList.Show();
                materialList.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void BindComparisonGrid()
        {
            try
            {
                DataTable dtComparison = new DataTable();
                dtComparison = Functions.GetTableDataBySP("MaterialActualComparison");

                BindingSource bsComparison = new BindingSource();
                bsComparison.DataSource = dtComparison;

                dgvComparison.DataSource = null;
                dgvComparison.DataSource = bsComparison;

                dgvComparison.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in dgvComparison.Rows)
                {
                    row.ReadOnly = true;
                }

                // Column Settings
                dgvComparison.Columns["SrNo"].HeaderText = "Sr No";
                dgvComparison.Columns["MaterialName"].HeaderText = "Material Name";
                dgvComparison.Columns["ActualStock"].HeaderText = "Actual Stock";
                dgvComparison.Columns["AddedStock"].HeaderText = "Added Stock";
                dgvComparison.Columns["AvailableStock"].HeaderText = "Available Stock";

                // Header Style Same as First Grid
                dgvComparison.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgvComparison.ColumnHeadersHeight = 40;
                dgvComparison.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dgvComparison.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dgvList.Columns[e.ColumnIndex].Name == "MaterialName")
                {
                string materialName = dgvList.Rows[e.RowIndex].Cells["MaterialName"].Value.ToString();
                MaterialStock materialStock = new MaterialStock(materialName);
                materialStock.ShowDialog();
                }
            }
        }
    }
}


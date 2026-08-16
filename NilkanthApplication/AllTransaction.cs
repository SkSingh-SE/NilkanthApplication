using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class AllTransaction : Form
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string ApiKey = "", ApiUrl = "";

        public AllTransaction()
        {
            this.InitializeComponent();

            this.contextMenuStrip1.ItemClicked += this.ContextMenuStrip1_ItemClicked;
        }

        
        bool isPageLoad = false;

        private void SetBusy(bool busy, string message = "")
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetBusy(busy, message)));
                return;
            }
            this.Enabled                = !busy;
            Cursor.Current              = busy ? Cursors.WaitCursor : Cursors.Default;
            statusStrip1.Enabled        = true;
            tsslOperationStatus.Text    = message;
            tsslOperationStatus.Visible = busy;
            tspbOperation.Visible       = busy;
        }

        private void ShowTopMessage(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            // Always-on-top MessageBox using a hidden TopMost owner form
            using (Form owner = new Form())
            {
                owner.TopMost        = true;
                owner.ShowInTaskbar  = false;
                owner.FormBorderStyle = FormBorderStyle.None;
                owner.Size           = new System.Drawing.Size(1, 1);
                owner.StartPosition  = FormStartPosition.CenterScreen;
                owner.Show();
                MessageBox.Show(owner, message, title, MessageBoxButtons.OK, icon);
            }
        }

        private void AllTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                isPageLoad = true;
                this.BindClient();
                this.BindFromBatchNo("");
                this.BindToBatchNo("");

                this.BindSite("");
                this.BindRecipe("");
                this.BindTruck("");
                this.BindYear();
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.lblFilterStatus.Text = "Filter By : All Columns";
                DataTable dt = Queries.AccessDT;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["PageName"].ToString() == "PLC Data")
                        {
                            if (dt.Rows[i]["PageDelete"].ToString() == "True")
                            {
                                btnDeleteAllPLCData.Enabled = true;
                            }
                            else
                            {
                                btnDeleteAllPLCData.Enabled = false;
                            }
                        }
                    }
                }
                isPageLoad = false;

                string fDate = DateTime.Now.ToShortDateString();
                string[] fDateArr = fDate.Split('-');
                string fDateVal = "01" + "-" + fDateArr[1] + "-" + fDateArr[2];

                this.dtpFromDate.Value = Convert.ToDateTime(fDateVal);
                this.chkApplyDateFilter.Checked = true;
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

        void BindFromBatchNo(string ClientName)
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_BatchNo_Select", string.Concat(new string[]
                {
                        "@ClientName='",
                        ClientName,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Batch";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbFromBatch.DataSource = this.dataTable;
                this.cmbFromBatch.DisplayMember = "BatchNo";
                this.cmbFromBatch.ValueMember = "SrNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindToBatchNo(string ClientName)
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_BatchNo_Select", string.Concat(new string[]
                {
                        "@ClientName='",
                        ClientName,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Batch";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbToBatch.DataSource = this.dataTable;
                this.cmbToBatch.DisplayMember = "BatchNo";
                this.cmbToBatch.ValueMember = "SrNo";

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

        private void AllTransaction_FormClosing(object sender, FormClosingEventArgs e)
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

                    string frombatchno = "0";
                    if (cmbFromBatch.SelectedIndex > 0)
                        frombatchno = cmbFromBatch.Text;

                    string tobatchno = "0";
                    if (cmbToBatch.SelectedIndex > 0)
                        tobatchno = cmbToBatch.Text;

                    string year = "";
                    if (cmbYear.SelectedIndex > 0)
                        year = cmbYear.Text;

                    string month = "";
                    if (cmbMonth.SelectedIndex > 0)
                        month = cmbMonth.Text;


                    this.dataTable = Functions.GetTableDataBySPWithParam("PLCData_SelectAll", string.Concat(new string[]
                    {
                        "@ApplyDateFilter='",
                        this.chkApplyDateFilter.Checked.ToString(),
                        "',@ApplyYearMonthFilter='",
                        this.chkApplyYearMonth.Checked.ToString(),
                        "',@FromDate='",
                        fromdate,
                        "',@ToDate='",
                        todate,
                        "',@Year='",
                        year,
                        "',@Month='",
                        month,
                        "',@Client='",
                        client,
                        "',@FromBatchNo='",
                        frombatchno,
                        "',@ToBatchNo='",
                        tobatchno,
                        "',@Site='",
                        site,
                        "',@Recipe='",
                        recipe,
                        "',@TruckNo='",
                        truckno,
                        "'"
                }));

                    this.dgvList.DataSource = this.dataTable;
                    // Use default row selection (no checkbox column). Enable full-row selection and multi-select.
                    this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dgvList.MultiSelect = true;

                    //bool flag3 = this.dgvList.Rows.Count > 0;
                    //if (flag3)
                    //{
                    //    this.dgvList.CurrentCell = this.dgvList.Rows[0].Cells[1];
                    //    this.dgvList.Rows[0].Selected = true;
                    //}
                    //this.dgvList.Columns["PID"].Visible = false;
                    //this.dgvList.Columns["TransType"].Visible = false;
                    //for (int i = 0; i < this.dgvList.Rows.Count; i++)
                    //{
                    //    //dgvList.Rows[i].Cells[10].Value = Convert.ToInt32(dgvList.Rows[i].Cells[10]);
                    //    bool flag4 = (i + 1) % 2 != 0;
                    //    if (flag4)
                    //    {
                    //        this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 226, 239, 218);
                    //    }
                    //    else
                    //    {
                    //        this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //    }
                    //}
                    try
                    {
                        // Keep grid read-only but allow row selection
                        this.dgvList.ReadOnly = true;
                        foreach (DataGridViewColumn col in this.dgvList.Columns)
                        {
                            col.ReadOnly = true;
                        }

                        // hide Id column if present (case-insensitive)
                        var idCol = this.dgvList.Columns
                            .Cast<DataGridViewColumn>()
                            .FirstOrDefault(c => string.Equals(c.Name, "Id", StringComparison.OrdinalIgnoreCase) || string.Equals(c.Name, "ID", StringComparison.OrdinalIgnoreCase) || string.Equals(c.Name, "SrNo", StringComparison.OrdinalIgnoreCase) || string.Equals(c.Name, "PID", StringComparison.OrdinalIgnoreCase));
                        if (idCol != null)
                            idCol.Visible = false;
                    }
                    catch { }

                    dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dgvList.ColumnHeadersHeight = 40;
                    dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                Functions.ExportGrid(this.dgvList, e.ClickedItem.Text, "AllTransaction", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool flag = this.dgvList.CurrentCell != null;
                if (flag)
                {
                    int columnIndex = this.dgvList.CurrentCell.ColumnIndex;
                    this.columnname = this.dgvList.Columns[columnIndex].Name;
                    this.lblFilterStatus.Text = "Filter By : " + this.columnname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.columnname = "";
                this.lblFilterStatus.Text = "Filter By : All Columns";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkApplyDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = this.chkApplyDateFilter.Checked;
            if (@checked)
            {
                this.chkApplyYearMonth.Enabled = false;
                this.dtpFromDate.Enabled = true;
                this.dtpToDate.Enabled = true;
            }
            else
            {
                this.chkApplyYearMonth.Enabled = true;
                this.dtpFromDate.Enabled = false;
                this.dtpToDate.Enabled = false;
            }

            this.BindGrid();
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

        private DataTable dataTable = null;

        private string columnname = "";

        private ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

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

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.SelectedIndex > 0)
            {
                this.BindSite(this.cmbClient.Text);
                this.BindRecipe(this.cmbClient.Text);
                this.BindTruck(this.cmbClient.Text);
                this.BindFromBatchNo(this.cmbClient.Text);
                this.BindToBatchNo(this.cmbClient.Text);

            }
            else
            {
                this.BindSite("");
                this.BindRecipe("");
                this.BindTruck("");
                this.BindFromBatchNo("");
                this.BindToBatchNo("");
            }

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
                this.dtpFromDate.Enabled = true;
                this.dtpToDate.Enabled = true;
                this.BindGrid();
            }
            else
            {
                this.cmbYear.Enabled = true;
                this.cmbMonth.Enabled = true;
                this.chkApplyDateFilter.Enabled = false;
                this.dtpFromDate.Enabled = false;
                this.dtpToDate.Enabled = false;
            }
        }

        private void cmbFromBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void cmbToBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            chkApplyDateFilter.Checked = false;
            chkApplyYearMonth.Checked = false;
            cmbMonth.DataSource = null;
            cmbYear.SelectedIndex = 0;
            if (cmbClient.SelectedIndex == 0)
            {
                this.BindSite("");
                this.BindRecipe("");
                this.BindTruck("");
                this.BindFromBatchNo("");
                this.BindToBatchNo("");
            }
            else
                cmbClient.SelectedIndex = 0;

            this.BindGrid();
        }
        
       

        private async void btnImportCSV_Click(object sender, EventArgs e)
        {
            SetBusy(true, "Importing CSV from FTP, please wait...");
            try
            {
                var result = await Task.Run(() => Functions.ImportCSV());
                
                // Immediately refresh grid
                this.BindGrid();

                SetBusy(false);
                string msg = result.inserted > 0
                    ? $"Data imported successfully ({result.inserted} record(s) added)."
                    : "Data is already up to date.";
                ShowTopMessage(msg, "PLC Import");
            }
            catch (Exception ex)
            {
                SetBusy(false);
                ShowTopMessage(ex.Message, "Import CSV - Error", MessageBoxIcon.Hand);
            }
        }

        private async void btnUploadData_Click(object sender, EventArgs e)
        {
            SetBusy(true, "Uploading data to server, please wait...");
            try
            {
                await Task.Run(() =>
                {
                    GetApiDetails();
                    PLCDataSendInAPI();
                    UpdateUserBasedOnFromToDate();
                });
                SetBusy(false);
                ShowTopMessage("Data uploaded successfully.", "Upload Data");
            }
            catch (Exception ex)
            {
                SetBusy(false);
                ShowTopMessage(ex.Message, "Upload Data - Error", MessageBoxIcon.Hand);
            }
        }

        public void GetApiDetails()
        {
            DataTable dataTableApiDetails = Functions.GetTableDataBySP("PLCData_GetAPIKeyAndUrl");

            if (dataTableApiDetails.Rows.Count > 0)
            {
                ApiKey = dataTableApiDetails.Rows[0]["ApiKey"].ToString();
                ApiUrl = dataTableApiDetails.Rows[0]["ApiUrl"].ToString();
            }

        }

        public void PLCDataSendInAPI()
        {
            try
            {
                DataTable dataTable = Functions.GetTableDataBySP("PLCData_SelectForSendInAPI");

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dataTable);

                if (JSONString.Length > 0)
                {
                    JSONString = "{ \"api_key\":\"" + ApiKey + "\", \"data\":" + JSONString + "}";
                }

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ApiUrl + "store-production-data");
                var json = JSONString;
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = client.PostAsync(ApiUrl + "store-production-data", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;

                    //var options = new JsonSerializerOptions
                    //{
                    //    PropertyNameCaseInsensitive = true
                    //};

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        SQLHelper._objCmd = new SqlCommand();
                        SQLHelper._objCmd.Parameters.Clear();
                        SQLHelper._objCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(dataTable.Rows[i]["Id"].ToString()));

                        string text3 = Queries.UpdateBySP("PLCData_Update_AfterSendInAPI");

                        bool flag4 = text3 != "";
                        if (flag4)
                        {
                            bool flag5 = Functions.DBKeyErrors(text3);
                            bool flag6 = !flag5;
                            if (flag6)
                            {
                                MessageBox.Show(text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }

                    //var postResponse = System.Text.Json.JsonSerializer.Deserialize<PostResponse>(responseContent, options);
                    var postResponse = JsonConvert.DeserializeObject<PostResponse>(responseContent);
                    if (postResponse.IsSuccess)
                        MessageBox.Show("Data uploaded successfully!");
                    else
                        MessageBox.Show(postResponse.Message);

                    //MessageBox.Show("Post successful! ID: " + postResponse.Id);
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.Close();
        }
        public void UpdateUserBasedOnFromToDate()
        {
            try
            {
                string JSONString = "{ \"api_key\":\"" + ApiKey + "\"}";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ApiUrl + "get-api-key-detail");
                var json = JSONString;
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = client.PostAsync(ApiUrl + "get-api-key-detail", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    JObject res = JObject.Parse(responseContent);
                    FromDate = Convert.ToDateTime(res["from_date"].ToString());
                    ToDate = Convert.ToDateTime(res["to_date"].ToString());
                    DateTime currentDate = DateTime.Now;

                    bool CurDateIsBetweenRange = WithInRange(currentDate);

                    SQLHelper._objCmd = new SqlCommand();
                    SQLHelper._objCmd.Parameters.Clear();
                    SQLHelper._objCmd.Parameters.AddWithValue("@flag", CurDateIsBetweenRange);

                    string text3 = Queries.UpdateBySP("UserMaster_Update_WithCheckDateInAPI");

                    bool flag4 = text3 != "";
                    if (flag4)
                    {
                        bool flag5 = Functions.DBKeyErrors(text3);
                        bool flag6 = !flag5;
                        if (flag6)
                        {
                            MessageBox.Show(text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.Close();
        }

        private void ResizeButtonIcons(int size)
        {
            var sz = new Size(size, size);
            foreach (System.Windows.Forms.Button btn in new[] {
                btnUploadData, btnManualImport, btnImportCSV, btnResetImportDate,
                btnDeletePLCData, btnDeleteAllPLCData, btnClearFilter, btnBack, btnExport })
            {
                if (btn.Image != null)
                    btn.Image = new System.Drawing.Bitmap(btn.Image, sz);
            }
        }

        private async void btnManualImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select CSV File to Import";
            ofd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string filePath = ofd.FileName;
            SetBusy(true, "Importing CSV file, please wait...");
            try
            {
                var result = await Task.Run(() => Functions.ImportCSVManual(filePath));
                
                // Immediately refresh grid
                this.BindGrid();

                SetBusy(false);
                string msg = result.inserted > 0
                    ? $"Data imported successfully ({result.inserted} record(s) added)."
                    : "Data is already up to date.";
                ShowTopMessage(msg, "Manual Import");
            }
            catch (Exception ex)
            {
                SetBusy(false);
                ShowTopMessage(ex.Message, "Manual Import - Error", MessageBoxIcon.Hand);
            }
        }

        private void btnResetImportDate_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Password verification
                PasswordDialog pwd = new PasswordDialog("cHhpaobjTCc=", "Enter Password to Reset Import Date", showCancel: true);
                if (pwd.ShowDialog(this) != DialogResult.OK || !pwd.IsAuthorized)
                    return;

                // Step 2: Read current LastReadDateTime to pre-fill the picker
                var importcsvlastread = Functions.GetTableDataBySP("ImportCSVLastRead_Select");
                DateTime current = DateTime.Now;
                if (importcsvlastread != null && importcsvlastread.Rows.Count > 0)
                    DateTime.TryParse(importcsvlastread.Rows[0][2].ToString(), out current);

                // Step 3: Show date picker dialog
                DateTime selectedDate = current;
                using (Form datePicker = new Form())
                {
                    // Same design as PasswordDialog
                    datePicker.Text = "Reset CSV Import Date";
                    datePicker.ClientSize = new System.Drawing.Size(413, 175);
                    datePicker.StartPosition = FormStartPosition.CenterParent;
                    datePicker.FormBorderStyle = FormBorderStyle.FixedDialog;
                    datePicker.MaximizeBox = false;
                    datePicker.MinimizeBox = false;
                    datePicker.BackColor = System.Drawing.Color.White;
                    datePicker.Icon = this.Icon;

                    // Label — same font/position as PasswordDialog lblMessage
                    var lbl = new System.Windows.Forms.Label
                    {
                        Text = "Select new Last Read Date & Time :",
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular),
                        Location = new System.Drawing.Point(27, 20),
                        AutoSize = true
                    };

                    // Input — same position/size as PasswordDialog txtPassword
                    var dtp = new System.Windows.Forms.DateTimePicker
                    {
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "dd-MM-yyyy HH:mm:ss",
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular),
                        CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular),
                        Location = new System.Drawing.Point(30, 50),
                        Size = new System.Drawing.Size(350, 26),
                        Value = current
                    };

                    // OK button — same as PasswordDialog btnOk (Location: 177, 103)
                    var btnOk = new System.Windows.Forms.Button
                    {
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold),
                        ForeColor = System.Drawing.Color.White,
                        Image = Properties.Resources.OK,
                        Location = new System.Drawing.Point(200, 103),
                        Size = new System.Drawing.Size(110, 37),
                        UseVisualStyleBackColor = false,
                        DialogResult = DialogResult.OK
                    };
                    btnOk.FlatAppearance.BorderSize = 0;
                    btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                    btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

                    // Cancel button — same as PasswordDialog btnCancel (Location: 38, 103)
                    var btnCancelPicker = new System.Windows.Forms.Button
                    {
                        Text = "Cancel",
                        Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold),
                        ForeColor = System.Drawing.Color.White,
                        BackColor = System.Drawing.Color.FromArgb(255, 90, 10),
                        TextAlign = System.Drawing.ContentAlignment.TopCenter,
                        Padding = new System.Windows.Forms.Padding(0, 2, 0, 2),
                        Size = new System.Drawing.Size(110, 37),
                        Location = new System.Drawing.Point(68, 103),
                        UseVisualStyleBackColor = false,
                        Cursor = System.Windows.Forms.Cursors.Hand,
                        CausesValidation = false,
                        TabStop = false,
                        DialogResult = DialogResult.Cancel
                    };
                    btnCancelPicker.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 0);
                    btnCancelPicker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(200, 70, 0);
                    btnCancelPicker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 130, 20);

                    datePicker.Controls.AddRange(new System.Windows.Forms.Control[] { lbl, dtp, btnCancelPicker, btnOk });
                    datePicker.AcceptButton = btnOk;
                    datePicker.CancelButton = btnCancelPicker;

                    if (datePicker.ShowDialog(this) != DialogResult.OK)
                        return;

                    selectedDate = dtp.Value;
                }

                // Step 4: Update ImportCSVLastRead in DB
                SQLHelper._objCmd = new System.Data.SqlClient.SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@LastReadDateTime", selectedDate);
                string result = Queries.UpdateBySP("ImportCSVLastRead_Update");

                if (!string.IsNullOrWhiteSpace(result) && !Functions.DBKeyErrors(result))
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(
                        $"Import date reset to {selectedDate:dd-MM-yyyy HH:mm:ss}.\nNext import will fetch records from this date onwards.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : Reset Import Date", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnDeleteAllPLCData_Click(object sender, EventArgs e)
        {
            try
            {

                PasswordToDeletePLCData passToDelete = new PasswordToDeletePLCData();
                base.Hide();
                passToDelete.Show();
                passToDelete.BringToFront();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnDeletePLCData_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect selected rows (FullRowSelect + MultiSelect)
                var selectedRows = this.dgvList.SelectedRows;
                if (selectedRows == null || selectedRows.Count == 0)
                {
                    MessageBox.Show("Please select at least one PLC record (Ctrl+Click or Shift+Click) to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var ids = new System.Collections.Generic.List<int>();
                // find id column
                int idIndex = -1;
                for (int i = 0; i < this.dgvList.Columns.Count; i++)
                {
                    var n = this.dgvList.Columns[i].Name;
                    if (string.Equals(n, "Id", StringComparison.OrdinalIgnoreCase) || string.Equals(n, "ID", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(n, "SrNo", StringComparison.OrdinalIgnoreCase) || string.Equals(n, "PID", StringComparison.OrdinalIgnoreCase))
                    {
                        idIndex = i; break;
                    }
                }

                foreach (DataGridViewRow row in selectedRows)
                {
                    try
                    {
                        object v = null;
                        if (idIndex != -1)
                            v = row.Cells[idIndex].Value;
                        else if (row.Cells.Count > 0)
                            v = row.Cells[0].Value;

                        if (v != null && int.TryParse(v.ToString(), out int id))
                            ids.Add(id);
                    }
                    catch { }
                }

                if (ids.Count == 0)
                {
                    MessageBox.Show("No valid IDs found in selected rows.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
                using (PasswordDialog dlg = new PasswordDialog("cHhpaobjTCc=", "Enter password to delete PLC Data."))
                {
                    if (dlg.ShowDialog() != DialogResult.OK || !dlg.IsAuthorized)
                    {
                        MessageBox.Show("Wrong password. Operation cancelled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                var confirm = MessageBox.Show($"Are you sure you want to delete {ids.Count} selected record(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                string idsCsv = string.Join(",", ids);
                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@Ids", idsCsv);

                string result = Queries.DeleteBySP("PLCData_DeleteSelected");
                if (!string.IsNullOrWhiteSpace(result))
                {
                    bool handled = Functions.DBKeyErrors(result);
                    if (!handled) MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Selected PLC data deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public bool WithInRange(DateTime value)
        {
            return (FromDate <= value) && (value <= ToDate);
        }
    }
    public class PostResponse
    {
        //public int Id { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}


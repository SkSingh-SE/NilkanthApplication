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
                                btnDeletePLCData.Enabled = true;
                            }
                            else
                            {
                                btnDeletePLCData.Enabled = false;
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
                    dgvList.Columns[2].Visible = false;

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

        private void btnDeletePLCData_Click(object sender, EventArgs e)
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

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.ImportCSV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : ImportCSV", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            GetApiDetails();
            PLCDataSendInAPI();
            UpdateUserBasedOnFromToDate();
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

        private void btnManualImport_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.ImportCSVManual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : ImportCSV", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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


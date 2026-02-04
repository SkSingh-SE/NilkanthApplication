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
    public partial class TripReport : Form
    {
        public TripReport()
        {
            this.InitializeComponent();
            this.contextMenuStrip1.ItemClicked += this.ContextMenuStrip1_ItemClicked;
        }

        private void TripReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.lblErrorMsg.Visible = false;
                this.cmbFromBatch.SelectedIndexChanged -= new EventHandler(cmbFromBatch_SelectedIndexChanged);
                this.BindFromBatchNo("");
                this.cmbFromBatch.SelectedIndexChanged += new EventHandler(cmbFromBatch_SelectedIndexChanged);
                this.cmbToBatch.SelectedIndexChanged -= new EventHandler(cmbToBatch_SelectedIndexChanged);
                this.BindToBatchNo("");
                this.cmbToBatch.SelectedIndexChanged += new EventHandler(cmbToBatch_SelectedIndexChanged);
                this.cmbBatchNo.SelectedIndexChanged -= new EventHandler(cmbBatchNo_SelectedIndexChanged);
                this.BindBatchNo("");
                this.cmbBatchNo.SelectedIndexChanged += new EventHandler(cmbBatchNo_SelectedIndexChanged);
                this.BindChkLstBatch("");
                
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.chkLastBatch.Checked = true;
                //this.BindGrid();
                this.BindClient();
                this.ShowWhatsapp();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindChkLstBatch(string ClientName)
        {
            chkLstBatchNo.Items.Clear();

            this.dataTable = new DataTable();

            this.dataTable = Functions.GetTableDataBySPWithParam("Trip_PLCData_BatchNo_Select", string.Concat(new string[]
            {
                        "@ClientName='",
                        ClientName,
                        "'"
            }));

            for (int i = 0; i < this.dataTable.Rows.Count; i++)
            {
                chkLstBatchNo.Items.Add(this.dataTable.Rows[i]["BatchNoWithDate"].ToString());
            }
        }

        void BindBatchNo(string ClientName)
        {
            try
            {
                this.dataTable = new DataTable();
                
                this.dataTable = Functions.GetTableDataBySPWithParam("Trip_PLCData_BatchNo_Select", string.Concat(new string[]
                {
                        "@ClientName='",
                        ClientName,
                        "'"
                }));

                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = 0;
                dataRow[1] = "Select Batch";
                dataTable.Rows.InsertAt(dataRow, 0);

                this.cmbBatchNo.DataSource = this.dataTable;
                this.cmbBatchNo.DisplayMember = "BatchNoWithDate";
                this.cmbBatchNo.ValueMember = "SrNo";

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

                this.dataTable = Functions.GetTableDataBySPWithParam("Trip_PLCData_BatchNo_Select", string.Concat(new string[]
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
                this.cmbFromBatch.DisplayMember = "BatchNoWithDate";
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

                this.dataTable = Functions.GetTableDataBySPWithParam("Trip_PLCData_BatchNo_Select", string.Concat(new string[]
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
                this.cmbToBatch.DisplayMember = "BatchNoWithDate";
                this.cmbToBatch.ValueMember = "SrNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void TripReport_FormClosing(object sender, FormClosingEventArgs e)
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

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.contextMenuStrip1.Items.Clear();
        //        this.contextMenuStrip1.Items.Add("Excel");
        //        this.contextMenuStrip1.Items.Add("PDF");
        //        this.contextMenuStrip1.Show(this.btnExport, new Point(0, this.btnExport.Height));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //}

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

        private void BindGrid(string bno = "", string date = "")
        {
            try
            {
                this.dataSet = new DataSet();

                string batchno = bno;
                string date_ = date;

                if (cmbBatchNo.SelectedIndex > 0 && (bno == "" && date == ""))
                {
                    string[] BatchDateDetails = cmbBatchNo.Text.Split(' ');
                    batchno = BatchDateDetails[0];
                    string[] DateDetails = BatchDateDetails[1].Split('(');
                    date_ = DateDetails[1].Substring(0, DateDetails[1].Length - 1);
                }
                
                this.dataSet = Functions.GetTablesDataBySPWithParam("TripReportData_Select", string.Concat(new string[]
                {
                        "@BatchNo='",
                        batchno,
                        "',@Date='",
                        date_,
                        "'"
                }));

                if (this.dataSet != null)
                {

                    for (int i = 0; i < this.dataSet.Tables[1].Rows.Count; i++)
                    {
                        DataRow dr = this.dataSet.Tables[0].NewRow();
                        dr[0] = "";
                        dr[1] = this.dataSet.Tables[1].Rows[i][1].ToString();
                        dr[2] = this.dataSet.Tables[1].Rows[i][2].ToString();
                        dr[3] = this.dataSet.Tables[1].Rows[i][3].ToString();
                        dr[4] = this.dataSet.Tables[1].Rows[i][4].ToString();
                        dr[5] = this.dataSet.Tables[1].Rows[i][5].ToString();
                        dr[6] = this.dataSet.Tables[1].Rows[i][6].ToString();
                        dr[7] = this.dataSet.Tables[1].Rows[i][7].ToString();
                        dr[8] = this.dataSet.Tables[1].Rows[i][8].ToString();
                        dr[9] = this.dataSet.Tables[1].Rows[i][9].ToString();
                        dr[10] = this.dataSet.Tables[1].Rows[i][10].ToString();
                        dr[11] = this.dataSet.Tables[1].Rows[i][11].ToString();
                        dr[12] = this.dataSet.Tables[1].Rows[i][12].ToString();

                        this.dataSet.Tables[0].Rows.Add(dr);
                    }

                    this.dgvList.DataSource = this.dataSet.Tables[0];
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
                    //this.dgvList.Columns["PID"].Visible = false;
                    //this.dgvList.Columns["TransType"].Visible = false;
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

                    }

                    for (int i = this.dgvList.Rows.Count - 1; i > this.dgvList.Rows.Count - 6; i--)
                    {
                        bool flag4 = (i + 1) % 2 != 0;
                        if (flag4)
                        {
                            this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.FromName("lightblue");
                        }
                        else
                        {
                            this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.FromName("lightgray");
                        }

                    }

                    foreach (DataGridViewColumn column in dgvList.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                }
                else
                {
                    this.dgvList.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                this.contextMenuStrip1.Hide();
                this.contextMenuStrip1.Close();
                Functions.ExportGrid(this.dgvList, e.ClickedItem.Text, "TripReport", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private DataSet dataSet = null;

        private DataTable dataTable = null;

        private ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
            if(cmbBatchNo.SelectedIndex > 0)
            {
                cmbFromBatch.SelectedIndex = 0;
                cmbToBatch.SelectedIndex = 0;

                UncheckAllOptionsInCheckBoxList();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //string batchno = "";
                //string tobatchno = "";
                //bool flag=false;

                //if(cmbBatchNo.SelectedIndex > 0)
                //{
                //    batchno = cmbBatchNo.Text;
                //    tobatchno = cmbBatchNo.Text;
                //    this.lblErrorMsg.Visible = false;
                //    flag = true;
                //}
                //else if(cmbFromBatch.SelectedIndex > 0 && cmbToBatch.SelectedIndex > 0)
                //{
                //    batchno = cmbFromBatch.Text;
                //    tobatchno = cmbToBatch.Text;
                //    this.lblErrorMsg.Visible = false;
                //    flag = true;
                //}
                //else
                //{
                //    this.lblErrorMsg.Visible = true;
                //}

                string batchnos = "";
                string[] BatchDateDetails;
                string[] toBatchDetails;
                string selecteddate = "";
                bool flag = false;

                if (chkLstBatchNo.CheckedItems.Count > 0)
                {
                    chkLastBatch.Checked = false;
                    cmbBatchNo.SelectedIndex = 0;
                }

                if (cmbBatchNo.SelectedIndex > 0)
                {
                    BatchDateDetails = cmbBatchNo.Text.Split(' ');
                    //BatchDateDetails = new string[1];
                    batchnos += BatchDateDetails[0] + ",";
                    selecteddate = BatchDateDetails[1].Replace("(", "").Replace(")", "");
                    //BatchDateDetails[0] = cmbBatchNo.Text;
                    this.lblErrorMsg.Visible = false;
                    flag = true;
                }
                else if (cmbFromBatch.SelectedIndex > 0 && cmbToBatch.SelectedIndex > 0)
                {
                    BatchDateDetails = cmbFromBatch.Text.Split(' ');
                    selecteddate = BatchDateDetails[1].Replace("(", "").Replace(")", "");
                    toBatchDetails = cmbToBatch.Text.Split(' ');

                    for (int i = Convert.ToInt32(BatchDateDetails[0]); i >= Convert.ToInt32(toBatchDetails[0]); i--)
                    {
                        batchnos += i + ",";
                    }

                    this.lblErrorMsg.Visible = false;
                    flag = true;


                    ////string[] FromBatchDateDetails = cmbFromBatch.Text.Split(' ');
                    ////string[] ToBatchDateDetails = cmbToBatch.Text.Split(' ');
                    //int batchCnt = 0;

                    //for (int i = Convert.ToInt32(cmbFromBatch.SelectedValue); i <= Convert.ToInt32(cmbToBatch.SelectedValue); i++)
                    //{
                    //    batchCnt += 1;
                    //}

                    //BatchDateDetails = new string[batchCnt];
                    //int batchIndex = 0;
                    //for (int i = Convert.ToInt32(cmbFromBatch.SelectedValue); i <= Convert.ToInt32(cmbToBatch.SelectedValue); i++)
                    //{
                    //    //cmbFromBatch.SelectedIndex = i;
                    //    DataRowView drv;
                    //    //string frombatchtext = cmbFromBatch.Items[i].ToString();
                    //    //string temp = cmbFromBatch.SelectedText;
                    //    //string temp1 = cmbFromBatch.SelectedItem.ToString();
                    //    drv = (DataRowView)cmbFromBatch.Items[i];
                    //    //string temp2 = drv[1].ToString();
                    //    BatchDateDetails[batchIndex] = drv[1].ToString();
                    //    batchIndex += 1;
                    //}
                    ////for(int i = Convert.ToInt32(FromBatchDateDetails[0]); i <= Convert.ToInt32(ToBatchDateDetails[0]); i++)
                    ////{
                    ////    batchnos += i + ",";
                    ////}

                    //this.lblErrorMsg.Visible = false;
                    //flag = true;
                }
                else if (chkLstBatchNo.CheckedItems.Count > 0)
                {

                    for (int a = 0; a < chkLstBatchNo.CheckedItems.Count; a++)
                    {
                        BatchDateDetails = chkLstBatchNo.CheckedItems[a].ToString().Split(' ');
                        batchnos += BatchDateDetails[0] + ",";
                        if (a == 0)
                            selecteddate = BatchDateDetails[1].Replace("(", "").Replace(")", "");
                    }

                    this.lblErrorMsg.Visible = false;
                    flag = true;

                    //int batchCnt = 0;

                    //for (int a = 0; a < chkLstBatchNo.CheckedItems.Count; a++)
                    //{
                    //    batchCnt += 1;
                    //}

                    //BatchDateDetails = new string[batchCnt];

                    //for (int a = 0; a < chkLstBatchNo.CheckedItems.Count; a++)
                    //{
                    //    BatchDateDetails[a] = chkLstBatchNo.CheckedItems[a].ToString();
                    //    //string[] BatchDateDetails = chkLstBatchNo.CheckedItems[a].ToString().Split(' ');
                    //    //batchnos += BatchDateDetails[0] + ",";
                    //}

                    //this.lblErrorMsg.Visible = false;
                    //flag = true;
                }
                else
                {
                    this.lblErrorMsg.Visible = true;
                }


                //if (this.chkApplyBatchFilter.Checked)
                //{
                //    if (cmbFromBatch.SelectedIndex > 0)
                //        batchno = cmbFromBatch.Text;

                //    if (cmbToBatch.SelectedIndex > 0)
                //        tobatchno = cmbToBatch.Text;
                //}
                //else
                //{
                //    batchno = cmbBatchNo.Text;
                //    tobatchno = cmbBatchNo.Text;
                //}

                if (flag == true)
                {
                    ReportTrip rpt = new ReportTrip(batchnos, selecteddate);
                    //ReportTrip rpt = new ReportTrip(BatchDateDetails);
                    rpt.Show();
                    rpt.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkLastBatch_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = this.chkLastBatch.Checked;
            if (@checked)
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySP("GetLastBatchNo");

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    //cmbBatchNo.SelectedValue = dataTable.Rows[0][1].ToString();
                    //this.cmbBatchNo.DataSource = null;

                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = 0;
                    dataRow[1] = "Select Batch";
                    dataTable.Rows.InsertAt(dataRow, 0);

                    this.cmbBatchNo.SelectedIndexChanged -= new EventHandler(cmbBatchNo_SelectedIndexChanged);

                    this.cmbBatchNo.DataSource = this.dataTable;
                    this.cmbBatchNo.DisplayMember = "BatchNoWithDate";
                    this.cmbBatchNo.ValueMember = "SrNo";
                    this.cmbBatchNo.SelectedIndex = 1;

                    this.cmbBatchNo.SelectedIndexChanged += new EventHandler(cmbBatchNo_SelectedIndexChanged);

                    string[] BatchDateDetails = dataTable.Rows[1][1].ToString().Split(' ');
                    string[] DateDetails = BatchDateDetails[1].Split('(');
                    BindGrid(BatchDateDetails[0], DateDetails[1].Substring(0, DateDetails[1].Length - 1));
                    //BindGrid(dataTable.Rows[1][1].ToString());
                }
            }
            else
            {
                this.cmbBatchNo.DataSource = null;
                //cmbBatchNo.SelectedIndex = 0;
                this.BindBatchNo("");
                BindGrid();
            }
        }

        private void cmbFromBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFromBatch.SelectedIndex > 0)
            {
                cmbBatchNo.SelectedIndex = 0;
                chkLastBatch.Checked = false;

                //this.cmbFromBatch.SelectedIndexChanged -= new EventHandler(cmbFromBatch_SelectedIndexChanged);
                //this.chkLstBatchNo.chkLstBatchNo_ItemCheck -= new EventHandler(chkLstBatchNo_ItemCheck);

                UncheckAllOptionsInCheckBoxList();

            }
        }

        private void cmbToBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbToBatch.SelectedIndex > 0)
            {
                cmbBatchNo.SelectedIndex = 0;
                chkLastBatch.Checked = false;
            }
        }

        private void btnClearBatches_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstBatchNo.Items.Count; i++)
            {
                chkLstBatchNo.SetItemChecked(i, false);
            }
            cmbFromBatch.SelectedIndex = 0;
            cmbToBatch.SelectedIndex = 0;
            chkLastBatch.Checked = true;
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.ImportCSV();
                reloadBatchNo();
                this.chkLastBatch.Checked = true;
                chkLastBatch_CheckedChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : ImportCSV", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnManualImport_Click(object sender, EventArgs e)
        {
            try
            {
                Functions.ImportCSVManual();
                reloadBatchNo();
                this.chkLastBatch.Checked = true;
                chkLastBatch_CheckedChanged(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : ImportCSV", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void reloadBatchNo()
        {
            this.BindFromBatchNo("");
            this.BindToBatchNo("");
            this.BindBatchNo("");
            this.BindChkLstBatch("");
        }

        private void chkLstBatchNo_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //if(chkLstBatchNo.CheckedItems.Count > 0)
            //{
            //    chkLastBatch.Checked = false;
            //    cmbBatchNo.SelectedIndex = 0;
            //}
        }

        private void UncheckAllOptionsInCheckBoxList()
        {
            for (int i = 0; i < chkLstBatchNo.Items.Count; i++)
            {
                chkLstBatchNo.SetItemChecked(i, false);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //this.Controls.Clear();
            //InitializeComponent();
            this.TripReport_Load(sender, e);
            this.chkLastBatch_CheckedChanged(sender, e);
        }

        void BindClient()
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

                if(this.dataTable != null && this.dataTable.Rows.Count > 0)
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

        private void btnSendWhatsApp_Click(object sender, EventArgs e)
        {
            string mobileno = cmbClientDetails.SelectedValue.ToString();
            string selectedbatch = cmbBatchNo.SelectedValue.ToString();
            MessageBox.Show(selectedbatch);
        }

        void ShowWhatsapp()
        {
            bool IsShowWhatsapp = Convert.ToBoolean(Functions.GetSingleValue("select ShowWhatsapp from CompanyMaster"));
            if(IsShowWhatsapp)
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

        private void btnDeliveryChallan_Click(object sender, EventArgs e)
        {
            try
            {
                DeliveryChallanList deliveryChallanList = new DeliveryChallanList();
                base.Hide();
                deliveryChallanList.Show();
                deliveryChallanList.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}


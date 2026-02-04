using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class DeliveryChallan : Form
    {
        private DataTable dataTable = null;

        private int editID;

        public DeliveryChallan(int ID)
        {
            InitializeComponent();
            this.editID = ID;
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
                this.cmbClientDetails.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void GenerateDeliveryChallanNo()
        {
            Object LastDeliveryChallanNo = Functions.GetSingleValue("select DeliveryChallanNo from DeliveryChallan order by ID desc");
            DateTime date_ = DateTime.Now;

            if(LastDeliveryChallanNo == null)
                txtChallanNo.Text = "DC/" + date_.Year + "/1";
            else
            {
                string[] DeliveryChallanNoDetails = LastDeliveryChallanNo.ToString().Split('/');
                txtChallanNo.Text = "DC/" + date_.Year + "/" + (Convert.ToInt32(DeliveryChallanNoDetails[2]) + 1);
            }

        }

        private void DeliveryChallan_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindBatchNo("");
                this.BindClient();
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.lblId.Text = this.editID.ToString();
                this.GenerateDeliveryChallanNo();
                
                bool flag = this.lblId.Text.Trim() != "0";
                if (flag)
                {
                    this.SetEditValues();
                }

                Point point = new Point();
                point.X = 12;
                point.Y = 625;
                pictureBox1.Location = point;
                pictureBox1.Width = 1350;

                Point point1 = new Point();
                point1.X = 12;
                point1.Y = 635;
                lblUserName.Location = point1;

                Point point2 = new Point();
                point2.X = 12;
                point2.Y = 655;
                lblVersion.Location = point2;

                Point point3 = new Point();
                point3.X = 1300;
                point3.Y = 635;
                btnLogout.Location = point3;

                Point point4 = new Point();
                point4.X = 1200;
                point4.Y = 19;
                btnBack.Location = point4;
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

        private void cmbBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string batchno, date_;
            batchno = date_ = "";
            if (cmbBatchNo.SelectedIndex > 0)
            {
                string[] BatchDateDetails = cmbBatchNo.Text.Split(' ');
                batchno = BatchDateDetails[0];
                string[] DateDetails = BatchDateDetails[1].Split('(');
                date_ = DateDetails[1].Substring(0, DateDetails[1].Length - 1);

                GetAndFillTripDetails(batchno, date_);
            }
            else
                ResetTripDetails();


        }
        void GetAndFillTripDetails(string batchno, string date)
        {
            try
            {
               dataTable = Functions.GetTableDataBySPWithParam("TripReportData_Select3", string.Concat(new string[]
               {
                        "@BatchNos='",
                        batchno,
                        "',@Date='",
                        date,
                        "'"
                        //"',@ToBatchNo='",
                        //this.tobatch,
                        //"'"
               }));

               if(dataTable.Rows.Count > 0)
               {
                    txtCompanyName.Text = dataTable.Rows[0]["Customer"].ToString();
                    txtClientName.Text = dataTable.Rows[0]["ClientName"].ToString();
                    txtSiteName.Text = dataTable.Rows[0]["SiteName"].ToString();
                    txtRecipeName.Text = dataTable.Rows[0]["RecipeName"].ToString();
                    dtDate.Text = dataTable.Rows[0]["Date"].ToString();
                    txtBatchNo.Text = dataTable.Rows[0]["BatchNo"].ToString();
                    txtTruckNo.Text = dataTable.Rows[0]["TruckNo"].ToString();
                    txtDriverName.Text = dataTable.Rows[0]["DriverName"].ToString();
                    txtQtyInBatch.Text = dataTable.Rows[0]["SetBatches"].ToString();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        void ResetTripDetails()
        {
            txtCompanyName.Text = "";
            txtClientName.Text = "";
            txtSiteName.Text = "";
            txtRecipeName.Text = "";
            dtDate.Text = "";
            txtBatchNo.Text = "";
            txtTruckNo.Text = "";
            txtDriverName.Text = "";
            txtQtyInBatch.Text = "";
        }

        private void txtTotalOrderQty_TextChanged(object sender, EventArgs e)
        {
            if(txtTotalOrderQty.Text != "" && Convert.ToDouble(txtTotalOrderQty.Text) > 0)
            {
                double QtyInBatch = Convert.ToDouble(txtQtyInBatch.Text);
                double TotalOrderQty = Convert.ToDouble(txtTotalOrderQty.Text);
                txtRemainingQty.Text = (TotalOrderQty - QtyInBatch).ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@DeliveryChallanNo", txtChallanNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@PartyID", cmbClientDetails.SelectedValue);
                SQLHelper._objCmd.Parameters.AddWithValue("@TotalOrderQty", Convert.ToDouble(txtTotalOrderQty.Text.ToString()));
                SQLHelper._objCmd.Parameters.AddWithValue("@SetCUM", Convert.ToDouble(txtQtyInBatch.Text.ToString()));
                SQLHelper._objCmd.Parameters.AddWithValue("@RemainingQty", Convert.ToDouble(txtRemainingQty.Text.ToString()));
                SQLHelper._objCmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@ClientName", txtClientName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@SiteName", txtSiteName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@DeliveryChallanDate", dtDate.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@TruckNo", txtTruckNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@DriverName", txtDriverName.Text.ToString().Trim());

                string text2;

                if (lblId.Text.Trim() == "0")
                {
                    text2 = Queries.InsertBySP("DeliveryChallan_Insert");
                }
                else
                {
                    SQLHelper._objCmd.Parameters.AddWithValue("@ID", lblId.Text.ToString().Trim());
                    text2 = Queries.UpdateBySP("DeliveryChallan_Update");
                }
                bool flag1 = text2 != "";
                if (flag1)
                {
                    bool flag2 = Functions.DBKeyErrors(text2);
                    bool flag3 = !flag2;
                    if (flag3)
                    {
                        MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    DeliveryChallanList deliveryChallanList = new DeliveryChallanList();
                    base.Hide();
                    deliveryChallanList.Show();
                    deliveryChallanList.BringToFront();

                    //if (lblId.Text.Trim() == "0")
                    //    MessageBox.Show("Data Inserted Successfully");
                    //else
                    //    MessageBox.Show("Data Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void SetEditValues()
        {
            try
            {
                DataTable tableData = Functions.GetTableData("select top 1 * from DeliveryChallan where ID=" + this.lblId.Text.Trim());
                bool flag = tableData != null && tableData.Rows.Count > 0;
                if (flag)
                {
                    txtChallanNo.Text = tableData.Rows[0]["DeliveryChallanNo"].ToString();
                    txtCompanyName.Text = tableData.Rows[0]["CompanyName"].ToString();
                    txtClientName.Text = tableData.Rows[0]["ClientName"].ToString();
                    txtSiteName.Text = tableData.Rows[0]["SiteName"].ToString();
                    txtRecipeName.Text = tableData.Rows[0]["RecipeName"].ToString();
                    dtDate.Text = tableData.Rows[0]["DeliveryChallanDate"].ToString();
                    txtBatchNo.Text = tableData.Rows[0]["BatchNo"].ToString();
                    txtTruckNo.Text = tableData.Rows[0]["TruckNo"].ToString();
                    txtDriverName.Text = tableData.Rows[0]["DriverName"].ToString();
                    txtQtyInBatch.Text = tableData.Rows[0]["SetCUM"].ToString();
                    txtTotalOrderQty.Text = tableData.Rows[0]["TotalOrderQty"].ToString();
                    txtRemainingQty.Text = tableData.Rows[0]["RemainingQty"].ToString();
                    cmbClientDetails.SelectedValue = tableData.Rows[0]["PartyID"].ToString();
                    DateTime date_ = Convert.ToDateTime(dtDate.Text);
                    string batchDetails = txtBatchNo.Text + " (" + date_.ToString("dd-MM-yyyy") + ")";
                    cmbBatchNo.SelectedText = batchDetails;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

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
    public partial class MaterialStock : Form
    {
        private DataTable dataTable = null;

        private int editID;

        private string selectmaterial = "";
        public MaterialStock(int ID)
        {
            InitializeComponent();
            this.editID = ID;
        }
        public MaterialStock(string materialName)
        {
            InitializeComponent();
            selectmaterial = materialName;
        }
        private void MaterialStock_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindMaterialStock();
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.lblId.Text = this.editID.ToString();

                bool flag = this.lblId.Text.Trim() != "0";
                if (flag)
                {
                    this.SetEditValues();
                }
                if (!string.IsNullOrEmpty(selectmaterial))
                {
                    textBoxMarginName.Text = selectmaterial;
                }

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
                MaterialStockList materiallist = new MaterialStockList();
                base.Hide();
                materiallist.Show();
                materiallist.BringToFront();
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



        //void ResetTripDetails()
        //{
        //    txtCompanyName.Text = "";
        //    txtClientName.Text = "";
        //    txtSiteName.Text = "";
        //    txtRecipeName.Text = "";
        //    dtDate.Text = "";
        //    txtBatchNo.Text = "";
        //    txtTruckNo.Text = "";
        //    txtDriverName.Text = "";
        //    txtQtyInBatch.Text = "";
        //}


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = !this.CValidtion();
                if (!flag)
                {


                    SQLHelper._objCmd = new SqlCommand();
                    SQLHelper._objCmd.Parameters.Clear();
                    SQLHelper._objCmd.Parameters.AddWithValue("@Materialname", textBoxMarginName.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Actualvalue", txtAmount.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Date", dtDate.Text.ToString().Trim());
                    string text2;

                    if (lblId.Text.Trim() == "0")
                    {
                        text2 = Queries.InsertBySP("MaterialStock_Insert");
                    }
                    else
                    {
                        SQLHelper._objCmd.Parameters.AddWithValue("@ID", lblId.Text.ToString().Trim());
                        text2 = Queries.UpdateBySP("MaterialStock_Update");
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
                        MaterialStockList materialStockList = new MaterialStockList();
                        base.Hide();
                        materialStockList.Show();
                        materialStockList.BringToFront();

                        //if (lblId.Text.Trim() == "0")
                        //    MessageBox.Show("Data Inserted Successfully");
                        //else
                        //    MessageBox.Show("Data Updated Successfully");
                    }
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
                DataTable tableData = Functions.GetTableData("select top 1 * from MaterialStock where ID=" + this.lblId.Text.Trim());
                bool flag = tableData != null && tableData.Rows.Count > 0;
                if (flag)
                {
                    textBoxMarginName.Text = tableData.Rows[0]["MaterialName"].ToString();
                    dtDate.Text = tableData.Rows[0]["Date"].ToString();
                    txtAmount.Text = tableData.Rows[0]["Actualvalue"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindMaterialStock()
        {
            try
            {
                DataTable dt = Functions.GetTableDataBySP("MaterialsNamedropdown");

                // Default Select️ Select Option Add
                DataRow dr = dt.NewRow();
                dr["MaterialName"] = "Select Material";
                dt.Rows.InsertAt(dr, 0);

                textBoxMarginName.DataSource = dt;
                textBoxMarginName.DisplayMember = "MaterialName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private bool CValidtion()
        {
            try
            {
                
                if (textBoxMarginName.SelectedIndex == 0)
                {
                    MessageBox.Show("Enter material name", "Missing", MessageBoxButtons.OK);
                    this.textBoxMarginName.Focus();
                    return false;
                }
                bool flag1 = this.txtAmount.Text.Trim().Length <= 0;
                if (flag1)
                {
                    MessageBox.Show("Enter Amount", "Missing", MessageBoxButtons.OK);
                    this.txtAmount.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }
    }
}

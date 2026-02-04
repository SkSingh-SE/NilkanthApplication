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
    public partial class Client : Form
    {
        private int editID;

        public Client(int ID)
        {
            InitializeComponent();
            this.editID = ID;
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
                ClientList partyList = new ClientList();
                base.Hide();
                partyList.Show();
                partyList.BringToFront();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // GST Validation (Blank OR <= 15)
            if (!string.IsNullOrWhiteSpace(textBoxGSTNo.Text) && textBoxGSTNo.Text.Trim().Length > 15)
            {
                MessageBox.Show("GST No should not exceed 15 characters.");
                textBoxGSTNo.Focus();
                return;
            }

            // PAN Validation (Blank OR <= 10)
            if (!string.IsNullOrWhiteSpace(textBoxPANNo.Text) && textBoxPANNo.Text.Trim().Length > 10)
            {
                MessageBox.Show("PAN No should not exceed 10 characters.");
                textBoxPANNo.Focus();
                return;
            }

            // Mobile Validation (Blank OR <= 14)
            if (!string.IsNullOrWhiteSpace(txtMobileNo.Text) && txtMobileNo.Text.Trim().Length > 14)
            {
                MessageBox.Show("Mobile No should not exceed 14 characters.");
                txtMobileNo.Focus();
                return;
            }
            try
            {
                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@PersonName", txtPersonName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@GSTNo", textBoxGSTNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@PANNo", textBoxPANNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@OtherDetails", textBoxOtherDetails.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@ShortAddress", textBoxShortAddress.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@SiteAddress", textBoxSiteAddress.Text.ToString().Trim());


                string text2;

                if (lblId.Text.Trim() == "0")
                {
                    text2 = Queries.InsertBySP("ClientMaster_Insert");
                }
                else
                {
                    SQLHelper._objCmd.Parameters.AddWithValue("@ID", lblId.Text.ToString().Trim());
                    text2 = Queries.UpdateBySP("ClientMaster_Update");
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
                    ClientList partyList = new ClientList();
                    base.Hide();
                    partyList.Show();
                    partyList.BringToFront();

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

        private void Client_Load(object sender, EventArgs e)
        {
            this.lblId.Text = this.editID.ToString();
            this.lblUserName.Text = "User Name : " + Queries.UserName;

            bool flag = this.lblId.Text.Trim() != "0";
            if (flag)
            {
                this.SetEditValues();
            }

            //Point point = new Point();
            //point.X = 12;
            //point.Y = 625;
            //pictureBox1.Location = point;
            //pictureBox1.Width = 1350;

            //Point point1 = new Point();
            //point1.X = 12;
            //point1.Y = 635;
            //lblUserName.Location = point1;

            //Point point2 = new Point();
            //point2.X = 12;
            //point2.Y = 655;
            //lblVersion.Location = point2;

            //Point point3 = new Point();
            //point3.X = 1300;
            //point3.Y = 635;
            //btnLogout.Location = point3;

            //Point point4 = new Point();
            //point4.X = 1200;
            //point4.Y = 19;
            //btnBack.Location = point4;

            //Point point5 = new Point();
            //point5.X = 1200;
            //point5.Y = 19;
            //btnBack.Location = point4;

            //Point point6 = new Point();
            //point6.X = 400;
            //point6.Y = 180;
            //lblCompanyName.Location = point6;

            //Point point7 = new Point();
            //point7.X = 535;
            //point7.Y = 180;
            //txtCompanyName.Location = point7;

            //Point point8 = new Point();
            //point8.X = 400;
            //point8.Y = 231;
            //lblPersonName.Location = point8;

            //Point point9 = new Point();
            //point9.X = 535;
            //point9.Y = 231;
            //txtPersonName.Location = point9;

            //Point point10 = new Point();
            //point10.X = 400;
            //point10.Y = 281;
            //lblMobileNo.Location = point10;

            //Point point11 = new Point();
            //point11.X = 535;
            //point11.Y = 281;
            //txtMobileNo.Location = point11;
            
            //Point point12 = new Point();
            //point12.X = 400;
            //point13.Y = 291;
            //textBoxGSTNo.Location = point13;

            //Point point12 = new Point();
            //point12.X = 780;
            //point12.Y = 331;
            //btnSave.Location = point12;

        }

        private void SetEditValues()
        {
            try
            {
                DataTable tableData = Functions.GetTableData("select top 1 * from ClientMaster where ID=" + this.lblId.Text.Trim());
                bool flag = tableData != null && tableData.Rows.Count > 0;
                if (flag)
                {
                    this.txtCompanyName.Text = tableData.Rows[0]["CompanyName"].ToString();
                    this.txtPersonName.Text = tableData.Rows[0]["PersonName"].ToString();
                    this.txtMobileNo.Text = tableData.Rows[0]["MobileNo"].ToString();
                    this.textBoxGSTNo.Text = tableData.Rows[0]["GSTNo"].ToString();
                    this.textBoxPANNo.Text = tableData.Rows[0]["PANNo"].ToString();
                    this.textBoxOtherDetails.Text = tableData.Rows[0]["OtherDetails"].ToString();
                    this.textBoxShortAddress.Text = tableData.Rows[0]["ShortAddress"].ToString();
                    this.textBoxSiteAddress.Text = tableData.Rows[0]["SiteAddress"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

    }
}

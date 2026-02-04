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
    public partial class UserRightMaster : Form
    {
        public UserRightMaster(int ID, string PrePageName)
        {
            InitializeComponent();
            this.editID = ID;
            this.PPageName = PrePageName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@UserID", cmbUsers.SelectedValue.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@PageName", cmbPages.SelectedItem.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@PageAddEdit", chkAddEdit.Checked == true ? true : false);
                SQLHelper._objCmd.Parameters.AddWithValue("@PageView", chkView.Checked == true ? true : false);
                SQLHelper._objCmd.Parameters.AddWithValue("@PageDelete", chkDelete.Checked == true ? true : false);

                string text2;

                if (lblId.Text.Trim() == "0")
                {
                    text2 = Queries.InsertBySP("UserRights_Insert");
                }
                else
                {
                    SQLHelper._objCmd.Parameters.AddWithValue("@ID", lblId.Text.ToString().Trim());
                    text2 = Queries.UpdateBySP("UserRights_Update");
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
                    UserRights userrights = new UserRights();
                    base.Hide();
                    userrights.Show();
                    userrights.BringToFront();

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

        private void UserRightMaster_Load(object sender, EventArgs e)
        {
            this.lblId.Text = this.editID.ToString();
            this.lblUserName.Text = "User Name : " + Queries.UserName;

            string query = "SELECT ID,UserName from UserMaster SELECT * FROM UserMaster WHERE IsActive=1 AND IsDeleted=0";
            Functions.Fill_Combo(cmbUsers, query, "UserName", "ID", "--Please Select--", "0");
            cmbUsers.SelectedIndex = 0;
            cmbPages.SelectedIndex = 0;

            bool flag = this.lblId.Text.Trim() != "0";
            if (flag)
            {
                this.SetEditValues();
            }
        }

        private void SetEditValues()
        {
            try
            {
                DataTable tableData = Functions.GetTableData("select top 1 * from UserRights where ID=" + this.lblId.Text.Trim());
                bool flag = tableData != null && tableData.Rows.Count > 0;
                if (flag)
                {
                    this.cmbUsers.SelectedValue = tableData.Rows[0]["UserID"].ToString();
                    this.cmbPages.SelectedItem = tableData.Rows[0]["PageName"].ToString();
                    if (tableData.Rows[0]["PageAddEdit"].ToString() == "True")
                        chkAddEdit.Checked = true;
                    else
                        chkAddEdit.Checked = false;

                    if (tableData.Rows[0]["PageView"].ToString() == "True")
                        chkView.Checked = true;
                    else
                        chkView.Checked = false;

                    if (tableData.Rows[0]["PageDelete"].ToString() == "True")
                        chkDelete.Checked = true;
                    else
                        chkDelete.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void UserRightMaster_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                MainScreen masterData = new MainScreen();
                base.Hide();
                masterData.Show();
                masterData.BringToFront();

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
                UserRights userrights = new UserRights();
                base.Hide();
                userrights.Show();
                userrights.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private int editID;

        private string PPageName;

        private void chkAddEdit_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = chkAddEdit.Checked;
            if(@checked)
            {
                chkView.Checked = true;
                chkView.Enabled = false;
            }
            else
            {
                chkView.Enabled = true;
                chkView.Checked = false;
            }
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = chkDelete.Checked;
            if (@checked)
            {
                chkView.Checked = true;
                chkView.Enabled = false;
            }
            else
            {
                chkView.Enabled = true;
                chkView.Checked = false;
            }
        }
    }
}

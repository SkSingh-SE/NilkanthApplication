
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class UserRights : Form
    {
        public UserRights()
        {
            this.InitializeComponent();
        }

        private void UserRights_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnNew.Focus();
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.lblFilterStatus.Text = "Filter By : All Columns";
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void UserRights_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    MainScreen masterData = new MainScreen();
                    base.Hide();
                    masterData.Show();
                    masterData.BringToFront();
                }
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
                //bool flag = this.addindex >= 0 || this.editindex >= 0;
                //if (flag)
                //{
                //    bool flag2 = this.addindex >= 0;
                //    if (flag2)
                //    {
                //        this.dgvList.Rows.RemoveAt(this.addindex);
                //    }
                //    else
                //    {
                //        bool flag3 = this.editindex >= 0;
                //        if (flag3)
                //        {
                //            this.dgvList.Rows[this.editindex].Cells["UserName"].ErrorText = "";
                //        }
                //    }
                //    this.addindex = -1;
                //    this.editindex = -1;
                //    this.dgvList.CancelEdit();
                //    this.BindGrid();//false
                //}
                //else
                //{
                //    MainScreen masterData = new MainScreen();
                //    base.Hide();
                //    masterData.Show();
                //    masterData.BringToFront();
                //}
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
                User user = new User();
                base.Hide();
                user.Show();
                user.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                UserRightMaster userrightmaster = new UserRightMaster(0, "UserRight");
                base.Hide();
                userrightmaster.Show();
                userrightmaster.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = this.dgvList.CurrentRow == null;
                if (!flag)
                {
                    DataGridViewRow currentRow = this.dgvList.CurrentRow;
                    string value = currentRow.Cells["ID"].Value.ToString();
                    //string text = currentRow.Cells["Status"].Value.ToString();
                    bool flag2 = true;
                    bool flag3 = Convert.ToInt32(value) > 0 && flag2;
                    if (flag3)
                    {
                        UserRightMaster userrightmaster = new UserRightMaster(Convert.ToInt32(value), "UserRight");
                        base.Hide();
                        userrightmaster.Show();
                        userrightmaster.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("No Row Selected for edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void BindGrid()
        {
            try
            {
                this.dataTable = new DataTable();
                this.dataTable = Functions.GetTableDataBySP("UserRights_Select");
                this.bindingSource = new BindingSource();
                this.bindingSource.DataSource = this.dataTable;
                this.dgvList.DataSource = null;
                this.dgvList.DataSource = this.bindingSource;
                //this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (object obj in ((IEnumerable)this.dgvList.Rows))
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                    dataGridViewRow.ReadOnly = true;
                }
                bool flag2 = this.dgvList.Rows.Count > 0;
                if (flag2)
                {
                    this.dgvList.CurrentCell = this.dgvList.Rows[0].Cells[1];
                    this.dgvList.Rows[0].Selected = true;
                }
                this.dgvList.Columns["ID"].Visible = false;
                this.dgvList.Columns["UserName"].HeaderText = "User";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_Sorted(object sender, EventArgs e)
        {
            try
            {
                foreach (object obj in ((IEnumerable)this.dgvList.Rows))
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                    dataGridViewRow.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private DataTable dataTable = null;

        private BindingSource bindingSource = null;
    }
}


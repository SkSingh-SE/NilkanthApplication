
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
    public partial class BreakdownList : Form
    {
        public BreakdownList()
        {
            this.InitializeComponent();
        }

        private void BreakdownList_Load(object sender, EventArgs e)
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

        private void BreakdownList_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Breakdown breakdown = new Breakdown(0);
                base.Hide();
                breakdown.Show();
                breakdown.BringToFront();
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
                    bool flag2 = true;
                    bool flag3 = Convert.ToInt32(value) > 0 && flag2;
                    if (flag3)
                    {
                        Breakdown breakdown = new Breakdown(Convert.ToInt32(value));
                        base.Hide();
                        breakdown.Show();
                        breakdown.BringToFront();
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
                this.dataTable = Functions.GetTableDataBySP("Breakdown_SelectAll");
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
                this.dgvList.Columns["ModelNo"].HeaderText = "Model No";
                this.dgvList.Columns["SerialNo"].HeaderText = "Serial No";
                this.dgvList.Columns["FaultStartDate"].HeaderText = "Fault Start Date";
                this.dgvList.Columns["FaultStopDate"].HeaderText = "Fault Stop Date";
                this.dgvList.Columns["InchargeName"].HeaderText = "Incharge Name";
                this.dgvList.Columns["EngineerName"].HeaderText = "Engineer Name";
                this.dgvList.Columns["FaultTypeIDs"].Visible = false;
                this.dgvList.Columns["ActualFaultIDs"].Visible = false;
                this.dgvList.Columns["WorkCarriedOutIDs"].Visible = false;
                //this.dgvList.Columns["FaultTypeID"].Visible = false;
                //this.dgvList.Columns["ActualFaultID"].Visible = false;
                //this.dgvList.Columns["WorkCarriedOutID"].Visible = false;
                this.dgvList.Columns["FaultTypeNames"].HeaderText = "Fault Type";
                this.dgvList.Columns["ActualFaultNames"].HeaderText = "Actual Fault";
                this.dgvList.Columns["WorkCarriedOutNames"].HeaderText = "Work Carried Out";

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = this.dgvList.CurrentRow == null;
                if (!flag)
                {
                    bool flag2 = MessageBox.Show("Are you sure, You want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (flag2)
                    {
                        DataGridViewRow currentRow = this.dgvList.CurrentRow;
                        string value = currentRow.Cells["ID"].Value.ToString();
                        bool flag3 = Convert.ToInt32(value) > 0;
                        if (flag3)
                        {
                            try
                            {
                                SQLHelper._objCmd = new SqlCommand();
                                SQLHelper._objCmd.Parameters.Clear();
                                //SQLHelper._objCmd.Parameters.AddWithValue("@ModifiedBy", Queries.UserID);
                                SQLHelper._objCmd.Parameters.AddWithValue("@ID", value);
                                string text = Queries.UpdateBySP("Breakdown_Delete");
                                bool flag4 = text != "";
                                if (flag4)
                                {
                                    bool flag5 = Functions.DBKeyErrors(text);
                                    bool flag6 = !flag5;
                                    if (flag6)
                                    {
                                        MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                }
                                else
                                {
                                    //this.addindex = -1;
                                    //this.editindex = -1;
                                    this.BindGrid();
                                    this.btnDelete.Focus();
                                    MessageBox.Show("Data Deleted Successfully");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Row Selected for delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}


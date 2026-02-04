using System;
using System.Collections;
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
    public partial class ClientList : Form
    {
        public ClientList()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyMaster companyMaster = new CompanyMaster();
                base.Hide();
                companyMaster.Show();
                companyMaster.BringToFront();
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

        private void PartyList_Load(object sender, EventArgs e)
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

        private DataTable dataTable = null;

        private BindingSource bindingSource = null;

        private void BindGrid()
        {
            try
            {
                this.dataTable = new DataTable();
                this.dataTable = Functions.GetTableDataBySP("ClientMaster_SelectAll");
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
                this.dgvList.Columns["CompanyName"].HeaderText = "Company Name";
                this.dgvList.Columns["PersonName"].HeaderText = "Person Name";
                this.dgvList.Columns["MobileNo"].HeaderText = "Mobile No";
                this.dgvList.Columns["IsDeleted"].Visible = false;

                dgvList.Height = 550;
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
                btnDelete.Location = point4;

                Point point5 = new Point();
                point5.X = 1100;
                point5.Y = 19;
                btnNew.Location = point5;

                Point point6 = new Point();
                point6.X = 1000;
                point6.Y = 19;
                btnEdit.Location = point6;

                Point point7 = new Point();
                point7.X = 900;
                point7.Y = 19;
                btnBack.Location = point7;

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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Client party = new Client(0);
                base.Hide();
                party.Show();
                party.BringToFront();
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
                        Client client = new Client(Convert.ToInt32(value));
                        base.Hide();
                        client.Show();
                        client.BringToFront();
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
                                string text = Queries.UpdateBySP("ClientMaster_Delete");
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

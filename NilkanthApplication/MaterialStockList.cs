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
    public partial class MaterialStockList : Form
    {
        public MaterialStockList()
        {
            InitializeComponent();
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
                ConsumptionReport consumptionReport = new ConsumptionReport();
                base.Hide();
                consumptionReport.Show();
                consumptionReport.BringToFront();
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

        private void MaterialStockList_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnNew.Focus();
                this.lblUserName.Text = "User Name : " + Queries.UserName;
             
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
                this.dataTable = Functions.GetTableDataBySP("MaterialStock_SelectAll");
                this.bindingSource = new BindingSource();
                this.bindingSource.DataSource = this.dataTable;
                this.dgvList.DataSource = null;
                this.dgvList.DataSource = this.bindingSource;
                this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                this.dgvList.Columns["MaterialName"].HeaderText = "MaterialName";
                this.dgvList.Columns["Date"].HeaderText = "Date";
                this.dgvList.Columns["Actualvalue"].HeaderText = "Actualvalue";
                this.dgvList.Columns["IsDeleted"].Visible = false;

                //dgvList.Height = 500;
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
                //btnDelete.Location = point4;

                //Point point5 = new Point();
                //point5.X = 1100;
                //point5.Y = 19;
                //btnNew.Location = point5;

                //Point point6 = new Point();
                //point6.X = 1000;
                //point6.Y = 19;
                //btnEdit.Location = point6;

                //Point point7 = new Point();
                //point7.X = 900;
                //point7.Y = 19;
                //btnBack.Location = point7;

                //Point point8 = new Point();
                //point8.X = 800;
                //point8.Y = 17;
                //btnPrint.Location = point8;

                // === Align buttons dynamically at the end ===
                int marginRight = 20;
                int spacing = 10;
                int topY = 19;
                Button[] buttons = { btnDelete, btnNew, btnEdit, btnBack};

                int currentX = this.ClientSize.Width - marginRight;

                foreach (Button btn in buttons)
                {
                    currentX -= btn.Width;
                    btn.Location = new Point(currentX, topY);
                    currentX -= spacing;
                }

                // === Position Logout Button Dynamically ===
                int dgvBottomY = dgvList.Location.Y + dgvList.Height;
                int marginTop = 10;
                int btnX = this.ClientSize.Width - btnLogout.Width - marginRight;
                int btnY = dgvBottomY + marginTop;
                btnLogout.Location = new Point(btnX, btnY);


                dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgvList.ColumnHeadersHeight = 40;
                dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
                MaterialStock materialStock = new MaterialStock(0);
                base.Hide();
                materialStock.Show();
                materialStock.BringToFront();
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
                        MaterialStock materialstork = new MaterialStock(Convert.ToInt32(value));
                        base.Hide();
                        materialstork.Show();
                        materialstork.BringToFront();
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
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool hasCurrentRow = this.dgvList.CurrentRow != null;
                    if (hasCurrentRow)
                    {
                        var spResult = string.Empty;
                        DataGridViewRow currentRow = this.dgvList.CurrentRow;
                        string value = currentRow.Cells["ID"].Value.ToString();
                        if (Convert.ToInt32(value) > 0)
                        {
                            SQLHelper._objCmd = new SqlCommand();
                            SQLHelper._objCmd.Parameters.Clear();
                            SQLHelper._objCmd.Parameters.AddWithValue("@ID", value.ToString().Trim());
                            spResult = Queries.UpdateBySP("MaterialStock_Delete");
                            if (string.IsNullOrEmpty(spResult))
                            {
                                BindGrid();
                            }
                            else
                            {
                                MessageBox.Show(spResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No Row Selected for delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Row Selected for delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


    }
}

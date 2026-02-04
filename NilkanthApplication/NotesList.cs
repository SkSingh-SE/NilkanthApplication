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
    public partial class NotesList : Form
    {
        public NotesList()
        {
            InitializeComponent();
        }

        private void NotesList_Load(object sender, EventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Notes notes = new Notes(0);
                base.Hide();
                notes.Show();
                notes.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private DataTable dataTable = null;

        private BindingSource bindingSource = null;

        private void BindGrid(string filterDate = null)
        {
            try
            {
                this.dataTable = new DataTable();
                if (filterDate == null)
                {
                    // No date filter → get all
                    dataTable = Functions.GetTableDataBySP("Notes_SelectAll");
                    lblFilterStatus.Text = "Filter By : All Columns";
                }
                else
                {
                    // Date filter applied
                    dataTable = Functions.GetTableDataBySPWithParam("Notes_SelectAll", string.Concat(new string[]
                    {
                "@Date='",
                filterDate.ToString(),
                "'"
                    }));
                    lblFilterStatus.Text = $"Filter By : Date ({filterDate:dd-MMM-yyyy})";
                }

                this.bindingSource = new BindingSource();
                this.bindingSource.DataSource = this.dataTable;
                this.dgvList.DataSource = null;
                this.dgvList.DataSource = this.bindingSource;

                // Enable row selection
                this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvList.MultiSelect = false; // Allow only one row to be selected
                this.dgvList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
                this.dgvList.DefaultCellStyle.SelectionForeColor = Color.White; 
                this.dgvList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); 
                this.dgvList.DefaultCellStyle.Font = new Font("Segoe UI", 12F); 
                this.dgvList.EnableHeadersVisualStyles = false; 
                this.dgvList.RowTemplate.Height = 30; 

                // Add hover effect by handling CellMouseEnter and CellMouseLeave events
                this.dgvList.CellMouseEnter += (s, e) =>
                {
                    if (e.RowIndex >= 0)
                        this.dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 255); // Light blue on hover
                };
                this.dgvList.CellMouseLeave += (s, e) =>
                {
                    if (e.RowIndex >= 0 && !this.dgvList.Rows[e.RowIndex].Selected)
                        this.dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 240, 240); // Restore alternating color
                };

                // Make rows read-only
                foreach (DataGridViewRow row in this.dgvList.Rows)
                {
                    row.ReadOnly = true;
                }

                // Select first row if available
                if (this.dgvList.Rows.Count > 0)
                {
                    this.dgvList.CurrentCell = this.dgvList.Rows[0].Cells[1];
                    this.dgvList.Rows[0].Selected = true;
                }

                // Configure columns
                this.dgvList.Columns["ID"].Visible = false;
                this.dgvList.Columns["NoteDate"].HeaderText = "Date";
                this.dgvList.Columns["NoteDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dgvList.Columns["NoteRemarks"].HeaderText = "Remarks";
                this.dgvList.Columns["NoteRemarks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvList.Columns["NoteRemarks"].DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Enable word wrap for Remarks
                this.dgvList.Columns["IsDeleted"].Visible = false;

                // Maintain original size and position
                dgvList.Height = 550;
                Point point = new Point { X = 12, Y = 625 };
                pictureBox1.Location = point;
                pictureBox1.Width = 1350;

                Point point1 = new Point { X = 12, Y = 635 };
                lblUserName.Location = point1;

                Point point2 = new Point { X = 12, Y = 655 };
                lblVersion.Location = point2;

                Point point3 = new Point { X = 1300, Y = 635 };
                btnLogout.Location = point3;

                Point point4 = new Point { X = 1200, Y = 19 };
                btnDelete.Location = point4;

                Point point5 = new Point { X = 1100, Y = 19 };
                btnNew.Location = point5;

                Point point6 = new Point { X = 1000, Y = 19 };
                btnEdit.Location = point6;

                Point point7 = new Point { X = 900, Y = 19 };
                btnBack.Location = point7;

                // Maintain original header styling
                dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgvList.ColumnHeadersHeight = 40;
                dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvList.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Notes notes = new Notes(Convert.ToInt32(value));
                        base.Hide();
                        notes.Show();
                        notes.BringToFront();
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
                                string text = Queries.UpdateBySP("Notes_Delete");
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedDate = dateTimePicker1.Value.Date;
                BindGrid(selectedDate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

    }
}

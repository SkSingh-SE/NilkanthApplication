
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
    public partial class User : Form
    {
        public User()
        {
            this.InitializeComponent();
            this.contextMenuStrip1.ItemClicked += this.ContextMenuStrip1_ItemClicked;
        }

        private void User_Load(object sender, EventArgs e)
        {
            try
            {
                this.populategiedcombobox();
                DataTable dt = Queries.AccessDT;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["PageName"].ToString() == "Users")
                        {
                            if (dt.Rows[i]["PageAddEdit"].ToString() == "True")
                            {
                                btnNew.Enabled = true;
                                btnEdit.Enabled = true;
                            }
                            else
                            {
                                btnNew.Enabled = false;
                                btnEdit.Enabled = false;
                            }
                            if (dt.Rows[i]["PageDelete"].ToString() == "True")
                            {
                                btnDelete.Enabled = true;
                            }
                            else
                            {
                                btnDelete.Enabled = false;
                            }
                            //if (dt.Rows[i]["PageView"].ToString() == "True")
                            //{
                            //    btnSave.Visible = true;
                            //}
                            //else
                            //{
                            //    btnSave.Visible = false;
                            //}
                        }
                    }
                }
                else
                    this.btnNew.Focus();

                this.lblUserName.Text = "User Name : " + Queries.UserName;
                this.txtSearch.Text = "Enter Users Details for Search......";
                this.lblFilterStatus.Text = "Filter By : All Columns";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void User_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string headerText = this.dgvList.Columns[e.ColumnIndex].HeaderText;
                bool flag = !headerText.Equals("User");
                if (!flag)
                {
                    bool flag2 = string.IsNullOrEmpty(e.FormattedValue.ToString());
                    if (flag2)
                    {
                        this.dgvList.Rows[e.RowIndex].ErrorText = "User Name must not be empty";
                        MessageBox.Show("User Name must not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvList.Rows[e.RowIndex].ErrorText = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                this.dgvList.CurrentRow.Cells["UserName"].ErrorText = "";
                bool flag = this.addindex != -1 || this.editindex != -1;
                if (flag)
                {
                    bool flag2 = this.dgvList.CurrentRow.Cells["UserName"].Value == DBNull.Value;
                    if (flag2)
                    {
                        this.dgvList.CurrentRow.Cells["UserName"].ErrorText = "User Name must not be empty";
                        MessageBox.Show("User Name must not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        e.Cancel = true;
                    }
                    else
                    {
                        bool flag3 = this.dgvList.CurrentRow.Cells["UserName"].Value.ToString().Contains(" ");
                        if (flag3)
                        {
                            this.dgvList.CurrentRow.Cells["UserName"].ErrorText = "User Name Cannot Contain WhiteSpace";
                            MessageBox.Show("User Name Cannot Contain WhiteSpace", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            e.Cancel = true;
                        }
                        else
                        {
                            bool flag4 = this.dgvList.CurrentRow.Cells["ID"].Value != null;
                            if (flag4)
                            {
                                int num = Convert.ToInt32(Functions.GetSingleValue("select COUNT(*) from UserMaster where LOWER(UserName)='" + this.dgvList.CurrentRow.Cells["UserName"].Value.ToString().Trim().ToLower() + "' and IsDeleted=0 and ID!=" + this.dgvList.CurrentRow.Cells["ID"].Value.ToString().Trim()).ToString());
                                bool flag5 = num > 0;
                                if (flag5)
                                {
                                    this.dgvList.CurrentRow.Cells["UserName"].ErrorText = "User Name Already Exist...";
                                    MessageBox.Show("User Name Already Exist...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            bool flag6 = this.dgvList.CurrentRow.Cells["AuthenticationMode"].Value.ToString().Trim().ToLower() != "application";
                            if (flag6)
                            {
                                string text = this.dgvList.CurrentRow.Cells["UserName"].Value.ToString().Trim().ToLower();
                                bool flag7 = text.Contains("\\");
                                if (flag7)
                                {
                                    text = text.Split(new char[]
                                    {
                                        '\\'
                                    })[1].ToString();
                                }
                                bool flag8 = text.Contains("/");
                                if (flag8)
                                {
                                    text = text.Split(new char[]
                                    {
                                        '/'
                                    })[1].ToString();
                                }
                                bool flag9 = this.DoesUserExist(text);
                                bool flag10 = !flag9;
                                if (flag10)
                                {
                                    this.dgvList.CurrentRow.Cells["UserName"].ErrorText = "User Name Not Exist in domain.";
                                    MessageBox.Show("User Name Not Exist in domain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    e.Cancel = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (object obj in ((IEnumerable)this.dgvList.Rows))
                {
                    DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                    bool isNewRow = dataGridViewRow.IsNewRow;
                    if (isNewRow)
                    {
                        dataGridViewRow.ReadOnly = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = this.dgvList.CurrentRow;
                bool flag = currentRow != null && currentRow.Cells["ID"].Value != null;
                if (flag)
                {
                    string text = currentRow.Cells["ID"].Value.ToString();
                    bool flag2 = this.addindex >= 0 && e.RowIndex == this.addindex && text == "0";
                    if (flag2)
                    {
                        bool flag3 = true;
                        bool flag4 = flag3;
                        if (flag4)
                        {
                            try
                            {
                                SQLHelper._objCmd = new SqlCommand();
                                SQLHelper._objCmd.Parameters.Clear();
                                SQLHelper._objCmd.Parameters.AddWithValue("@AuthenticationMode", currentRow.Cells["AuthenticationMode"].Value.ToString().Trim());
                                SQLHelper._objCmd.Parameters.AddWithValue("@UserName", currentRow.Cells["UserName"].Value.ToString().Trim().ToUpper());
                                SQLHelper._objCmd.Parameters.AddWithValue("@Password", currentRow.Cells["Password"].Value.ToString().Trim());
                                SQLHelper._objCmd.Parameters.AddWithValue("@Access", currentRow.Cells["Access"].Value.ToString().Trim());
                                SQLHelper._objCmd.Parameters.AddWithValue("@IsActive", currentRow.Cells["IsActive"].Value.ToString().Trim());
                                SQLHelper._objCmd.Parameters.AddWithValue("@ModifiedBy", Queries.UserID);
                                string text2 = Queries.InsertBySP("UserMaster_Insert");
                                bool flag5 = text2 != "";
                                if (flag5)
                                {
                                    bool flag6 = Functions.DBKeyErrors(text2);
                                    bool flag7 = !flag6;
                                    if (flag7)
                                    {
                                        MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                }
                                else
                                {
                                    this.addindex = -1;
                                    this.dgvList.EndEdit();
                                    this.RebindDataTable();
                                    foreach (object obj in ((IEnumerable)this.dgvList.Rows))
                                    {
                                        DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
                                        dataGridViewRow.ReadOnly = true;
                                    }
                                    this.btnNew.Focus();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This user is not exists in domain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        bool flag8 = this.editindex >= 0 && e.RowIndex == this.editindex && Convert.ToInt32(text) > 0;
                        if (flag8)
                        {
                            bool flag9 = true;
                            bool flag10 = flag9;
                            if (flag10)
                            {
                                try
                                {
                                    SQLHelper._objCmd = new SqlCommand();
                                    SQLHelper._objCmd.Parameters.Clear();
                                    SQLHelper._objCmd.Parameters.AddWithValue("@AuthenticationMode", currentRow.Cells["AuthenticationMode"].Value.ToString().Trim());
                                    SQLHelper._objCmd.Parameters.AddWithValue("@UserName", currentRow.Cells["UserName"].Value.ToString().Trim().ToUpper());
                                    SQLHelper._objCmd.Parameters.AddWithValue("@Password", currentRow.Cells["Password"].Value.ToString().Trim());
                                    SQLHelper._objCmd.Parameters.AddWithValue("@Access", currentRow.Cells["Access"].Value.ToString().Trim());
                                    SQLHelper._objCmd.Parameters.AddWithValue("@IsActive", currentRow.Cells["IsActive"].Value.ToString().Trim());
                                    SQLHelper._objCmd.Parameters.AddWithValue("@ModifiedBy", Queries.UserID);
                                    SQLHelper._objCmd.Parameters.AddWithValue("@ID", currentRow.Cells["ID"].Value.ToString().Trim());
                                    string text3 = Queries.UpdateBySP("UserMaster_Update");
                                    bool flag11 = text3 != "";
                                    if (flag11)
                                    {
                                        bool flag12 = Functions.DBKeyErrors(text3);
                                        bool flag13 = !flag12;
                                        if (flag13)
                                        {
                                            MessageBox.Show(text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                        }
                                    }
                                    else
                                    {
                                        this.editindex = -1;
                                        this.dgvList.EndEdit();
                                        this.RebindDataTable();
                                        foreach (object obj2 in ((IEnumerable)this.dgvList.Rows))
                                        {
                                            DataGridViewRow dataGridViewRow2 = (DataGridViewRow)obj2;
                                            dataGridViewRow2.ReadOnly = true;
                                        }
                                        this.btnEdit.Focus();
                                    }
                                }
                                catch (Exception ex2)
                                {
                                    MessageBox.Show(ex2.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                            }
                            else
                            {
                                MessageBox.Show("This user is not exists in domain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }
                }
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public bool DoesUserExist(string userName)
        {
            string name = ConfigurationManager.AppSettings["DomainName"];
            bool result;
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, name))
            {
                using (UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, userName))
                {
                    result = (userPrincipal != null);
                }
            }
            return result;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                this.contextMenuStrip1.Items.Clear();
                this.contextMenuStrip1.Items.Add("Excel");
                this.contextMenuStrip1.Items.Add("PDF");
                this.contextMenuStrip1.Show(this.btnExport, new Point(0, this.btnExport.Height));
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
                bool flag = this.addindex >= 0 || this.editindex >= 0;
                if (flag)
                {
                    bool flag2 = this.addindex >= 0;
                    if (flag2)
                    {
                        this.dgvList.Rows.RemoveAt(this.addindex);
                    }
                    else
                    {
                        bool flag3 = this.editindex >= 0;
                        if (flag3)
                        {
                            this.dgvList.Rows[this.editindex].Cells["UserName"].ErrorText = "";
                        }
                    }
                    this.addindex = -1;
                    this.editindex = -1;
                    this.dgvList.CancelEdit();
                    this.BindGrid(false);
                }
                else
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dataRow = this.dataTable.NewRow();
                dataRow["ID"] = "0";
                dataRow["AuthenticationMode"] = "Application";
                dataRow["Access"] = "User";
                this.dataTable.Rows.Add(dataRow);
                this.bindingSource.DataSource = this.dataTable;
                this.addindex = this.dataTable.Rows.Count - 1;
                this.dgvList.DataSource = this.bindingSource;
                this.dgvList.CurrentCell = this.dgvList.Rows[this.addindex].Cells[1];
                this.dgvList.Rows[this.addindex].Selected = true;
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
                int rowIndex = this.dgvList.SelectedCells[0].RowIndex;
                this.dgvList.Rows[rowIndex].ReadOnly = false;
                this.editindex = rowIndex;
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
                                SQLHelper._objCmd.Parameters.AddWithValue("@ModifiedBy", Queries.UserID);
                                SQLHelper._objCmd.Parameters.AddWithValue("@ID", value);
                                string text = Queries.UpdateBySP("UserMaster_Delete");
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
                                    this.addindex = -1;
                                    this.editindex = -1;
                                    this.populategiedcombobox();
                                    this.BindGrid(true);
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

        private void BindGrid(bool isdelete)
        {
            try
            {
                this.dataTable = new DataTable();
                bool flag = this.txtSearch.Text == "Enter Users Details for Search......";
                string text;
                if (flag)
                {
                    text = "";
                }
                else
                {
                    text = this.txtSearch.Text.Trim();
                }
                this.dataTable = Functions.GetTableDataBySPWithParam("UserMaster_SelectAll", string.Concat(new string[]
                {
                    "@Search='",
                    text,
                    "',@FieldName='",
                    this.columnname,
                    "'"
                }));
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
                this.dgvList.Columns["AuthenticationMode"].Visible = false;
                this.dgvList.Columns["Access"].Visible = false;
                this.dgvList.Columns["cbAuthenticationMode"].Width = 200;
                this.dgvList.Columns["cbAccess"].Width = 150;
                this.dgvList.Columns["IsActive"].Width = 150;
                //this.dgvList.Columns["Password"].Width = 150;
                //this.dgvList.Columns["UserName"].Width = this.dgvList.Width - this.dgvList.Columns["cbAuthenticationMode"].Width - this.dgvList.Columns["Password"].Width - this.dgvList.Columns["cbAccess"].Width - this.dgvList.Columns["IsActive"].Width - 52;
                this.dgvList.Columns["UserName"].Width = this.dgvList.Width - this.dgvList.Columns["cbAuthenticationMode"].Width - this.dgvList.Columns["cbAccess"].Width - this.dgvList.Columns["IsActive"].Width - 52;
                this.dgvList.Columns["cbAuthenticationMode"].HeaderText = "Authentication Mode";
                this.dgvList.Columns["UserName"].HeaderText = "User";
                this.dgvList.Columns["cbAccess"].HeaderText = "Access";
                this.dgvList.Columns["IsActive"].HeaderText = "Active";
                if (isdelete)
                {
                    this.dgvList.Columns["cbAccess"].DisplayIndex = 5;
                }
                for (int i = 0; i < this.dgvList.Rows.Count; i++)
                {
                    bool flag3 = (i + 1) % 2 != 0;
                    if (flag3)
                    {
                        this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 226, 239, 218);
                    }
                    else
                    {
                        this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                }
                this.dgvList.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvList.Columns["IsActive"].SortMode = DataGridViewColumnSortMode.Automatic;
                this.dgvList.Columns["cbAuthenticationMode"].SortMode = DataGridViewColumnSortMode.Automatic;
                this.dgvList.Columns["cbAccess"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void RebindDataTable()
        {
            try
            {
                this.dataTable = new DataTable();
                bool flag = this.txtSearch.Text == "Enter Users Details for Search......";
                string text;
                if (flag)
                {
                    text = "";
                }
                else
                {
                    text = this.txtSearch.Text.Trim();
                }
                this.dataTable = Functions.GetTableDataBySPWithParam("UserMaster_SelectAll", string.Concat(new string[]
                {
                    "@Search='",
                    text,
                    "',@FieldName='",
                    this.columnname,
                    "'"
                }));
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
                Functions.ExportGrid(this.dgvList, e.ClickedItem.Text, "User", false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                bool flag = this.dgvList.Columns.Count == 6;
                if (flag)
                {
                    this.dgvList.Columns.Insert(1, this.dgvcbc);
                    this.dgvList.Columns.Insert(4, this.dgvcbc1);
                }
                else
                {
                    this.dgvList.Columns["ID"].Visible = false;
                    this.dgvList.Columns["AuthenticationMode"].Visible = false;
                    this.dgvList.Columns["Access"].Visible = false;
                    this.dgvList.Columns["cbAuthenticationMode"].Width = 200;
                    this.dgvList.Columns["cbAccess"].Width = 150;
                    this.dgvList.Columns["IsActive"].Width = 150;
                    this.dgvList.Columns["Password"].Width = 150;
                    this.dgvList.Columns["UserName"].Width = this.dgvList.Width - this.dgvList.Columns["cbAuthenticationMode"].Width - this.dgvList.Columns["Password"].Width - this.dgvList.Columns["cbAccess"].Width - this.dgvList.Columns["IsActive"].Width - 52;
                    this.dgvList.Columns["UserName"].Width = this.dgvList.Width - this.dgvList.Columns["cbAuthenticationMode"].Width - this.dgvList.Columns["cbAccess"].Width - this.dgvList.Columns["IsActive"].Width - 52;
                    this.dgvList.Columns["cbAuthenticationMode"].HeaderText = "Authentication Mode";
                    this.dgvList.Columns["UserName"].HeaderText = "User";
                    this.dgvList.Columns["cbAccess"].HeaderText = "Access";
                    this.dgvList.Columns["IsActive"].HeaderText = "Active";
                    for (int i = 0; i < this.dgvList.Rows.Count; i++)
                    {
                        bool flag2 = (i + 1) % 2 != 0;
                        if (flag2)
                        {
                            this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 226, 239, 218);
                        }
                        else
                        {
                            this.dgvList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                    this.dgvList.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                bool flag = this.dgvList.CurrentCell.EditType != null;
                if (flag)
                {
                    bool flag2 = this.dgvList.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl);
                    if (flag2)
                    {
                        TextBox textBox = (TextBox)e.Control;
                        string headerText = this.dgvList.Columns[this.dgvList.CurrentCell.ColumnIndex].HeaderText;
                        bool flag3 = headerText.Equals("User");
                        if (flag3)
                        {
                            textBox.MaxLength = 30;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void populategiedcombobox()
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("AuthenticationMode");
                DataRow dataRow = dataTable.NewRow();
                //dataRow[0] = "Windows";
                //dataTable.Rows.InsertAt(dataRow, 0);
                DataRow dataRow2 = dataTable.NewRow();
                dataRow2[0] = "Application";
                dataTable.Rows.InsertAt(dataRow2, 0);
                this.dgvcbc.DataSource = dataTable;
                this.dgvcbc.ValueMember = "AuthenticationMode";
                this.dgvcbc.DisplayMember = "AuthenticationMode";
                this.dgvcbc.HeaderText = "AuthenticationMode Selection";
                this.dgvcbc.Name = "cbAuthenticationMode";
                this.dgvcbc.DataPropertyName = "AuthenticationMode";
                this.dgvcbc.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("Access");
                DataRow dataRow3 = dataTable2.NewRow();
                dataRow3[0] = "Admin";
                dataTable2.Rows.InsertAt(dataRow3, 0);
                //DataRow dataRow4 = dataTable2.NewRow();
                //dataRow4[0] = "Officer";
                DataRow dataRow4 = dataTable2.NewRow();
                dataRow4[0] = "User";
                dataTable2.Rows.InsertAt(dataRow4, 1);
                this.dgvcbc1.DataSource = dataTable2;
                this.dgvcbc1.ValueMember = "Access";
                this.dgvcbc1.DisplayMember = "Access";
                this.dgvcbc1.HeaderText = "Access Selection";
                this.dgvcbc1.Name = "cbAccess";
                this.dgvcbc1.DataPropertyName = "Access";
                this.dgvcbc1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                bool flag = e.KeyCode == Keys.Return;
                if (flag)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool flag = this.txtSearch.Text != "Enter Users Details for Search......" && this.addindex == -1 && this.editindex == -1;
                if (flag)
                {
                    this.BindGrid(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                bool flag = this.txtSearch.Text.Trim() == "";
                if (flag)
                {
                    this.txtSearch.Text = "Enter Users Details for Search......";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                bool flag = this.txtSearch.Text == "Enter Users Details for Search......";
                if (flag)
                {
                    this.txtSearch.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool flag = this.dgvList.CurrentCell != null;
                if (flag)
                {
                    int columnIndex = this.dgvList.CurrentCell.ColumnIndex;
                    this.columnname = this.dgvList.Columns[columnIndex].Name;
                    bool flag2 = this.columnname == "cbAuthenticationMode";
                    if (flag2)
                    {
                        this.columnname = "AuthenticationMode";
                    }
                    else
                    {
                        bool flag3 = this.columnname == "cbAccess";
                        if (flag3)
                        {
                            this.columnname = "Access";
                        }
                    }
                    this.lblFilterStatus.Text = "Filter By : " + this.columnname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.columnname = "";
                this.lblFilterStatus.Text = "Filter By : All Columns";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private DataTable dataTable = null;

        private BindingSource bindingSource = null;

        private int addindex = -1;

        private int editindex = -1;

        private ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

        private DataGridViewComboBoxColumn dgvcbc = new DataGridViewComboBoxColumn();

        private DataGridViewComboBoxColumn dgvcbc1 = new DataGridViewComboBoxColumn();

        private string columnname = "";

        private void btnRights_Click(object sender, EventArgs e)
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
    }
}


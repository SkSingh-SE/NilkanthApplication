using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class DeliveryChallanList : Form
    {
        private string whatsappApiKey;
        private string apiKey;
        private readonly Dictionary<string, ComboBox> filterComboBoxes = new Dictionary<string, ComboBox>();
        private FlowLayoutPanel flpFilters;
        private Button btnFilter;
        private Button btnResetFilters;
        private string sortColumn = "ID";
        private bool sortDescending = true;
        public DeliveryChallanList()
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
                TripReport tripData = new TripReport();
                base.Hide();
                tripData.Show();
                tripData.BringToFront();
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

        private void DeliveryChallanList_Load(object sender, EventArgs e)
        {
            try
            {
                whatsappApiKey = ConfigurationManager.AppSettings["WhatsappKey"];
                apiKey = ConfigurationManager.AppSettings["APIKey"];

                ShowWhatsapp();
                BindClientMaster();
                InitializeAdvancedFilters();
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
                long? selectedId = GetSelectedDeliveryChallanId();
                if (!ValidateFilters())
                    return;

                this.dataTable = GetFilteredDeliveryChallans();
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
                this.dgvList.Columns["ID"].Visible = false;
                this.dgvList.Columns["DeliveryChallanNo"].HeaderText = "No";
                //this.dgvList.Columns["TotalOrderQty"].HeaderText = "Total Order Qty";
                this.dgvList.Columns["SetCUM"].HeaderText = "Qty In Batch(Set CUM)";
                //this.dgvList.Columns["RemainingQty"].HeaderText = "Remaining Qty";
                this.dgvList.Columns["CompanyName"].HeaderText = "Company Name";
                this.dgvList.Columns["ClientName"].HeaderText = "Client Name";
                this.dgvList.Columns["SiteName"].HeaderText = "Site Name";
                this.dgvList.Columns["RecipeName"].HeaderText = "Recipe Name";
                this.dgvList.Columns["DeliveryChallanDate"].HeaderText = "Date";
                this.dgvList.Columns["BatchNo"].HeaderText = "Batch No";
                this.dgvList.Columns["TruckNo"].HeaderText = "Truck No";
                this.dgvList.Columns["DriverName"].HeaderText = "Driver Name";
                this.dgvList.Columns["PartyName"].HeaderText = "Party Name";
                this.dgvList.Columns["PartyID"].Visible = false;
                this.dgvList.Columns["IsDeleted"].Visible = false;

                foreach (DataGridViewColumn column in this.dgvList.Columns)
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;

                RestoreSelectedDeliveryChallan(selectedId);
                UpdateSortGlyph();
                UpdateFilterStatus();

                //dgvList.Dock = DockStyle.Fill;
                //dgvList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                pictureBox1.Dock = DockStyle.Bottom;
                pictureBox1.Height = 5;
                pictureBox1.Width = this.ClientSize.Width;

                lblUserName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

                lblUserName.Location = new Point(12, this.ClientSize.Height - 70);
                lblVersion.Location = new Point(12, this.ClientSize.Height - 50);

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
                int whatsappOffsetY = 8;

                Button[] buttons = { btnDelete, btnNew, btnEdit, btnBack, btnPrint, btnSendWhatsApp };

                int currentX = this.ClientSize.Width - marginRight;

                foreach (Button btn in buttons)
                {
                    currentX -= btn.Width;

                    if (btn == btnSendWhatsApp)
                        btn.Location = new Point(currentX, topY + whatsappOffsetY);
                    else
                        btn.Location = new Point(currentX, topY);

                    currentX -= spacing;
                }

                this.cmbClientDetails.Location = new Point(btnSendWhatsApp.Location.X - cmbClientDetails.Width - spacing, btnSendWhatsApp.Location.Y + 10);
                this.lblClient.Location = new Point(cmbClientDetails.Location.X - lblClient.Width - spacing, cmbClientDetails.Location.Y + 3);

                // === Position Logout Button Dynamically ===

                btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btnLogout.Location = new Point(
                    this.ClientSize.Width - btnLogout.Width - 20,
                    this.ClientSize.Height - btnLogout.Height - 40
                );

                dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgvList.ColumnHeadersHeight = 40;
                dgvList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                LayoutScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void InitializeAdvancedFilters()
        {
            flpFilters = new FlowLayoutPanel
            {
                Name = "flpFilters",
                Location = new Point(12, 82),
                Height = 49,
                AutoScroll = false,
                WrapContents = false,
                Padding = new Padding(4, 2, 4, 2),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            AddListFilter("FromBatchNo", "From Batch No.", "BatchNo");
            AddListFilter("ToBatchNo", "To Batch No.", "BatchNo");
            AddListFilter("ClientName", "Client Name", "ClientName");
            AddListFilter("SiteName", "Site Name", "SiteName");
            AddListFilter("RecipeName", "Recipe Name", "RecipeName");
            AddListFilter("TruckNo", "Truck No", "TruckNo");
            AddListFilter("DriverName", "Driver Name", "DriverName");
            AddFilterButtons();

            Controls.Add(flpFilters);
            flpFilters.BringToFront();
            dgvList.ColumnHeaderMouseClick += dgvList_ColumnHeaderMouseClick;
            Resize += DeliveryChallanList_Resize;
            LayoutScreen();
        }

        private void AddListFilter(string name, string caption, string databaseField)
        {
            Panel panel = CreateFilterPanel(caption, 205);
            ComboBox comboBox = new ComboBox
            {
                Name = "cmb" + name,
                Location = new Point(5, 19),
                Width = 190,
                Font = new Font("Microsoft Sans Serif", 9F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Tag = databaseField
            };
            comboBox.Items.Add("Selection");
            comboBox.SelectedIndex = 0;
            comboBox.DropDown += FilterComboBox_DropDown;
            comboBox.KeyDown += FilterControl_KeyDown;
            panel.Controls.Add(comboBox);
            filterComboBoxes.Add(name, comboBox);
            flpFilters.Controls.Add(panel);
        }

        private void FilterComboBox_DropDown(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            try
            {
                string selectedValue = comboBox.SelectedIndex > 0 ? Convert.ToString(comboBox.SelectedItem) : null;
                List<string> values = GetDeliveryChallanFilterValues(Convert.ToString(comboBox.Tag));
                if (Convert.ToString(comboBox.Tag) == "DeliveryChallanNo" || Convert.ToString(comboBox.Tag) == "BatchNo")
                    values.Sort((left, right) => CompareNaturalValues(left, right));

                comboBox.BeginUpdate();
                comboBox.Items.Clear();
                comboBox.Items.Add("Selection");
                comboBox.Items.AddRange(values.Cast<object>().ToArray());
                int selectedIndex = string.IsNullOrEmpty(selectedValue) ? 0 : comboBox.FindStringExact(selectedValue);
                comboBox.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
                comboBox.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load filter list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Panel CreateFilterPanel(string caption, int width)
        {
            Panel panel = new Panel { Width = width, Height = 45, Margin = new Padding(3, 0, 3, 2) };
            panel.Controls.Add(new Label
            {
                AutoSize = true,
                Text = caption,
                Location = new Point(3, 1),
                Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular)
            });
            return panel;
        }

        private void AddFilterButtons()
        {
            Panel panel = CreateFilterPanel("List Actions", 220);
            btnFilter = CreateSmallButton("btnFilter", "Search ", 5, btnFilter_Click);
            btnResetFilters = CreateSmallButton("btnResetFilters", "Reset / Clear", 112, btnResetFilters_Click);
            panel.Controls.Add(btnFilter);
            panel.Controls.Add(btnResetFilters);
            flpFilters.Controls.Add(panel);
        }

        private static Button CreateSmallButton(string name, string text, int x, EventHandler clickHandler)
        {
            Button button = new Button
            {
                Name = name,
                Text = text,
                Location = new Point(x, 18),
                Size = new Size(102, 27),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(112, 173, 71),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            button.Click += clickHandler;
            return button;
        }

        private void LayoutScreen()
        {
            if (flpFilters == null)
                return;

            flpFilters.Width = Math.Max(400, ClientSize.Width - 24);
            ResizeFilterRow();
            dgvList.Location = new Point(12, flpFilters.Bottom + 8);
            dgvList.Width = Math.Max(400, ClientSize.Width - 24);
            dgvList.Height = Math.Max(120, pictureBox1.Top - dgvList.Top - 6);
        }

        private void ResizeFilterRow()
        {
            const int filterCount = 7;
            const int controlHorizontalMargin = 6;
            const int minimumFilterWidth = 80;
            const int minimumActionsWidth = 170;
            const int preferredActionsWidth = 220;

            int availableWidth = flpFilters.ClientSize.Width
                - flpFilters.Padding.Horizontal
                - ((filterCount + 1) * controlHorizontalMargin);
            int actionsWidth = Math.Min(preferredActionsWidth,
                Math.Max(minimumActionsWidth, availableWidth / 6));
            int filterWidth = Math.Max(minimumFilterWidth,
                (availableWidth - actionsWidth) / filterCount);

            foreach (ComboBox comboBox in filterComboBoxes.Values)
            {
                Panel panel = comboBox.Parent as Panel;
                if (panel == null)
                    continue;

                panel.Width = filterWidth;
                comboBox.Width = Math.Max(60, panel.ClientSize.Width - 10);
            }

            Panel actionsPanel = btnFilter == null ? null : btnFilter.Parent as Panel;
            if (actionsPanel == null)
                return;

            actionsPanel.Width = Math.Max(minimumActionsWidth,
                availableWidth - (filterWidth * filterCount));

            int buttonWidth = Math.Max(75, (actionsPanel.ClientSize.Width - 15) / 2);
            btnFilter.Location = new Point(5, 18);
            btnFilter.Width = buttonWidth;
            btnResetFilters.Location = new Point(10 + buttonWidth, 18);
            btnResetFilters.Width = buttonWidth;
        }

        private void DeliveryChallanList_Resize(object sender, EventArgs e)
        {
            LayoutScreen();
        }

        private bool ValidateFilters()
        {
            string fromBatch = GetFilterText("FromBatchNo");
            string toBatch = GetFilterText("ToBatchNo");

            if (!string.IsNullOrEmpty(fromBatch) && !string.IsNullOrEmpty(toBatch) &&
                CompareNaturalValues(fromBatch, toBatch) > 0)
            {
                ShowRangeError("From Batch No. cannot be greater than To Batch No.", filterComboBoxes["FromBatchNo"]);
                return false;
            }

            return true;
        }

        private DataTable GetFilteredDeliveryChallans()
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["DataConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.SP_GetFilteredDeliveryChallans", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                AddNullableFilterParameter(command, "@FromBatchNo", GetFilterText("FromBatchNo"), 100);
                AddNullableFilterParameter(command, "@ToBatchNo", GetFilterText("ToBatchNo"), 100);
                AddNullableFilterParameter(command, "@ClientName", GetFilterText("ClientName"), 250);
                AddNullableFilterParameter( command, "@SiteName", GetFilterText("SiteName"), 250);
                AddNullableFilterParameter(command, "@RecipeName", GetFilterText("RecipeName"), 250);
                AddNullableFilterParameter( command, "@TruckNo", GetFilterText("TruckNo"), 100);
                AddNullableFilterParameter(command, "@DriverName", GetFilterText("DriverName"), 250);
                command.Parameters.Add("@SortColumn", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(sortColumn) ? "ID" : sortColumn;
                command.Parameters.Add("@SortDescending", SqlDbType.Bit).Value = sortDescending;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        private List<string> GetDeliveryChallanFilterValues(string fieldName)
        {
            string columnName;
            switch (fieldName)
            {
                case "ClientName": columnName = "d.ClientName"; break;
                case "SiteName": columnName = "d.SiteName"; break;
                case "RecipeName": columnName = "d.RecipeName"; break;
                case "BatchNo": columnName = "d.BatchNo"; break;
                case "TruckNo": columnName = "d.TruckNo"; break;
                case "DriverName": columnName = "d.DriverName"; break;
                default: throw new ArgumentException("Invalid Delivery Challan filter field.", "fieldName");
            }

            string sql = "SELECT DISTINCT " + columnName + " FROM DeliveryChallan d WHERE d.IsDeleted = 0 AND NULLIF(LTRIM(RTRIM(" + columnName + ")), '') IS NOT NULL ORDER BY " + columnName;
            List<string> values = new List<string>();
            string connectionString = ConfigurationManager.ConnectionStrings["DataConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        values.Add(Convert.ToString(reader[0]).Trim());
                }
            }
            return values;
        }

        private static void AddNullableFilterParameter(SqlCommand command,string name,string value,int size)
        {
            string normalized = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
            command.Parameters.Add(name, SqlDbType.NVarChar, size).Value = normalized == null ? (object)DBNull.Value : normalized;
        }

        private string GetFilterText(string name)
        {
            ComboBox comboBox;
            if (!filterComboBoxes.TryGetValue(name, out comboBox) || comboBox.SelectedIndex <= 0)
                return null;
            string value = Convert.ToString(comboBox.SelectedItem).Trim();
            return value.Length == 0 ? null : value;
        }

        private static int CompareNaturalValues(string left, string right)
        {
            decimal leftNumber;
            decimal rightNumber;
            if (decimal.TryParse(left, out leftNumber) && decimal.TryParse(right, out rightNumber))
                return leftNumber.CompareTo(rightNumber);

            int leftSlash = left.LastIndexOf('/');
            int rightSlash = right.LastIndexOf('/');
            if (leftSlash >= 0 && rightSlash >= 0 &&
                string.Equals(left.Substring(0, leftSlash), right.Substring(0, rightSlash), StringComparison.OrdinalIgnoreCase) &&
                decimal.TryParse(left.Substring(leftSlash + 1), out leftNumber) &&
                decimal.TryParse(right.Substring(rightSlash + 1), out rightNumber))
                return leftNumber.CompareTo(rightNumber);

            return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);
        }

        private static void ShowRangeError(string message, Control control)
        {
            MessageBox.Show(message, "Invalid Filter Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
            control.Focus();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            foreach (ComboBox comboBox in filterComboBoxes.Values)
                comboBox.SelectedIndex = 0;
            sortColumn = "ID";
            sortDescending = true;
            BindGrid();
        }

        private void FilterControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnFilter.PerformClick();
            }
        }

        private void dgvList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;
            string clickedColumn = dgvList.Columns[e.ColumnIndex].Name;
            if (string.Equals(sortColumn, clickedColumn, StringComparison.OrdinalIgnoreCase))
                sortDescending = !sortDescending;
            else
            {
                sortColumn = clickedColumn;
                sortDescending = false;
            }
            BindGrid();
        }

        private void UpdateSortGlyph()
        {
            foreach (DataGridViewColumn column in dgvList.Columns)
                column.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
            if (dgvList.Columns.Contains(sortColumn))
                dgvList.Columns[sortColumn].HeaderCell.SortGlyphDirection = sortDescending ? System.Windows.Forms.SortOrder.Descending : System.Windows.Forms.SortOrder.Ascending;
        }

        private void UpdateFilterStatus()
        {
            int activeCount = filterComboBoxes.Values.Count(c => c.SelectedIndex > 0);
            lblFilterStatus.Text = activeCount == 0 ? "Filter By : All Columns" : string.Format("Filter By : {0} active filter(s)", activeCount);
        }

        private long? GetSelectedDeliveryChallanId()
        {
            if (dgvList.CurrentRow == null || !dgvList.Columns.Contains("ID"))
                return null;
            long id;
            return long.TryParse(Convert.ToString(dgvList.CurrentRow.Cells["ID"].Value), out id) ? (long?)id : null;
        }

        private void RestoreSelectedDeliveryChallan(long? selectedId)
        {
            DataGridViewRow rowToSelect = null;
            if (selectedId.HasValue)
            {
                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    if (Convert.ToInt64(row.Cells["ID"].Value) == selectedId.Value)
                    {
                        rowToSelect = row;
                        break;
                    }
                }
            }
            if (rowToSelect == null && dgvList.Rows.Count > 0)
                rowToSelect = dgvList.Rows[0];
            if (rowToSelect != null)
            {
                dgvList.ClearSelection();
                dgvList.CurrentCell = rowToSelect.Cells["DeliveryChallanNo"];
                rowToSelect.Selected = true;
            }
        }
        void BindClientMaster()
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
                this.cmbClientDetails.ValueMember = "MobileNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void ShowWhatsapp()
        {
            bool IsShowWhatsapp = Convert.ToBoolean(Functions.GetSingleValue("select ShowWhatsapp from CompanyMaster"));
            if (IsShowWhatsapp)
            {
                lblClient.Visible = true;
                cmbClientDetails.Visible = true;
                btnSendWhatsApp.Visible = true;
            }
            else
            {
                lblClient.Visible = false;
                cmbClientDetails.Visible = false;
                btnSendWhatsApp.Visible = false;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DeliveryChallan deliveryChallan = new DeliveryChallan(0);
                base.Hide();
                deliveryChallan.Show();
                deliveryChallan.BringToFront();
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
                        DeliveryChallan notes = new DeliveryChallan(Convert.ToInt32(value));
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                bool hasCurrentRow = this.dgvList.CurrentRow != null;
                if (hasCurrentRow)
                {
                    DataGridViewRow currentRow = this.dgvList.CurrentRow;
                    string deliveryId = currentRow.Cells["ID"].Value.ToString();
                    if (Convert.ToInt32(deliveryId) > 0)
                    {
                        ReportDeliveryChallan challan = new ReportDeliveryChallan(Convert.ToInt32(deliveryId));
                        challan.Show();
                        challan.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("No Row Selected for delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {

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
                            spResult = Queries.UpdateBySP("DeliveryChallan_Delete");
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

        private async void btnSendWhatsApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClientDetails.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select client for WhatsApp.");
                    return;
                }
                if (dgvList.CurrentRow == null)
                {
                    MessageBox.Show("Please select Delivery Challan.");
                    return;
                }

                Functions.SetBusy(this, statusStrip1, tsslOperationStatus, tspbOperation, true, "Sending WhatsApp...", btnSendWhatsApp, lblFilterStatus);
                await Task.Yield();

                int deliveryId = Convert.ToInt32(dgvList.CurrentRow.Cells["ID"].Value);

                string mobile = cmbClientDetails.SelectedValue.ToString();

                // RDLC path
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;

                while (rootPath.Contains("bin"))
                    rootPath = Directory.GetParent(rootPath).Parent.FullName;

                string rdlcPath = Path.Combine(rootPath, "rptDeliveryChallan.rdlc");

                // Generate PDF
                var pdfService = new ReportPdfService(rdlcPath);
                var result = await pdfService.GenerateDeliveryChallanPdf(deliveryId);

                // Upload file to server
                string publicUrl = await FileUploadHelper.UploadFile(
                    result.FilePath,
                    Functions.GetUploadUrl()
                );
                // Extract client name for template parameter
                if (cmbClientDetails.SelectedItem is DataRowView drv)
                {
                    var parts = drv["ClientDetails"].ToString().Split('-');
                    result.ClientName = parts.Length > 0 ? parts[1].Trim() : "";
                }
                // Template parameters
                string Safe(string v) => string.IsNullOrWhiteSpace(v) ? "-" : v;

                var values = new Dictionary<int, string>
                {
                    {1, Safe(result.ClientName)},
                    {2, Safe(result.Date)},
                    {3, Safe(result.ChallanNo)},
                    {4, Safe(result.BatchNo)},
                    {5, Safe(result.DriverName)},
                    {6, Safe(result.TruckNo)},
                    {7, Safe(result.CycleStart)},
                    {8, Safe(result.CycleEnd)},
                    {9, Safe(result.CompanyName)}
                };

                var whatsappService = new WhatsAppService(whatsappApiKey);

                bool sent = await whatsappService.SendTemplateWithDocument(
                    mobile,
                    "challan",
                    publicUrl,
                    values,
                    "delivery-challan",
                    $"Delivery_Challan_{result.ChallanNo}.pdf"
                );

                MessageBox.Show(sent ? "WhatsApp sent successfully!" : "Failed to send WhatsApp.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Functions.SetBusy(this, statusStrip1, tsslOperationStatus, tspbOperation, false, "", btnSendWhatsApp, lblFilterStatus);
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

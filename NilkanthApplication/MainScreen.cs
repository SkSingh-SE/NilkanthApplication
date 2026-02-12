
using NilkanthApplication.Classes;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using Microsoft.Identity.Client;

namespace NilkanthApplication
{
    public partial class MainScreen : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        private int xpos = 0, ypos = 490;
        public string mode = "Left-to-Right";
        string currentyear = DateTime.Now.Year.ToString();

        private System.Windows.Forms.Timer _syncTimer;
        private PlcSyncManager _syncManager;
        private bool _isSyncRunning = false;
        public MainScreen()
        {
            this.InitializeComponent();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            CheckForIllegalCrossThreadCalls = false;

            tabControl1.SelectedIndexChanged += (s, e) =>
            {
                HighlightFirstRow(dgvProductionData);
                HighlightFirstRow(dgvTotalProdForSelectedMon);
            };

            //StartPosition = FormStartPosition.Manual;
            //Rectangle screen = Screen.FromPoint(System.Windows.Forms.Cursor.Position).WorkingArea;
            //int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            //int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            //Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            //Size = new Size(w, h);
        }

        #region Timer Elapsed Event Handler
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (mode == "Left-to-Right")
            {
                if (this.Width == xpos)
                {
                    this.lblNotification.Location = new System.Drawing.Point(0, ypos);
                    xpos = 0;
                }
                else
                {
                    this.lblNotification.Location = new System.Drawing.Point(xpos, ypos);
                    xpos += 2;
                }
            }
        }
        #endregion

        private void MainScreen_Load(object sender, EventArgs e)
        {
            try
            {
                _syncManager = new PlcSyncManager();

                _syncTimer = new System.Windows.Forms.Timer();
                _syncTimer.Interval = 60000; // 60 seconds
                _syncTimer.Tick += SyncTimer_Tick;
                _syncTimer.Start();

                //this.Location = new Point(0, 0);
                //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Text = ConfigurationManager.AppSettings["CompanyName"];
                this.lblUserName.Text = "User Name : " + Queries.UserName;
                bool flag = Queries.AccessLevel == "Admin";
                if (flag)
                {
                }
                DataTable dt = Queries.AccessDT;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["PageName"].ToString() == "Users")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                btnUsers.Enabled = true;
                            }
                            else
                            {
                                btnUsers.Enabled = false;
                            }
                        }
                        else if (dt.Rows[i]["PageName"].ToString() == "Company")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                btnCompanyMaster.Enabled = true;
                            }
                            else
                            {
                                btnCompanyMaster.Enabled = false;
                            }
                        }
                        else if (dt.Rows[i]["PageName"].ToString() == "PLC Data")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                btnAllData.Enabled = true;
                            }
                            else
                            {
                                btnAllData.Enabled = false;
                            }
                        }
                        else if (dt.Rows[i]["PageName"].ToString() == "Production")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                btnProductionRpt.Enabled = true;
                            }
                            else
                            {
                                btnProductionRpt.Enabled = false;
                            }
                        }
                        else if (dt.Rows[i]["PageName"].ToString() == "Consumption")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                btnConsumptionRpt.Enabled = true;
                            }
                            else
                            {
                                btnConsumptionRpt.Enabled = false;
                            }
                        }
                        else if (dt.Rows[i]["PageName"].ToString() == "Trip")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                btnTripRpt.Enabled = true;
                            }
                            else
                            {
                                btnTripRpt.Enabled = false;
                            }
                        }
                        else if (dt.Rows[i]["PageName"].ToString() == "PLC Connect")
                        {
                            if (dt.Rows[i]["PageView"].ToString() == "True")
                            {
                                //btnPLCConnect.Enabled = true;
                            }
                            else
                            {
                                //btnPLCConnect.Enabled = false;
                            }
                        }
                    }
                }

                //this.BindChart();
                this.BindCurrentMonthTotalProd();
                this.GetTotalProductionMQube();


                this.year_dataTable = new DataTable();
                this.year_dataTable = Functions.GetTableDataBySP("Dashboard_Year_Select");
                if (this.year_dataTable != null && this.year_dataTable.Rows.Count > 0 && this.year_dataTable.Columns.Count > 1 && this.year_dataTable.Rows[0][1] != DBNull.Value)
                {
                    currentyear = this.year_dataTable.Rows[0][1].ToString();
                }

                this.BindYear();
                this.BindTotalProdYear();
                //this.BindTotalProdForMonth(year);
                xpos = lblNotification.Location.X;
                ypos = lblNotification.Location.Y;
                mode = "Left-to-Right";
                timer.Interval = 500;
                timer.Start();
                //string pass = "0987";
                //string pass = "1705";
                //string pass = "6982";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : MainScreen_Load", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private async void SyncTimer_Tick(object sender, EventArgs e)
        {
            if (_isSyncRunning)
                return;

            try
            {
                _isSyncRunning = true;
                await _syncManager.ExecuteSyncAsync();
            }
            catch (Exception ex)
            {
                // Optional: log error
                // File.WriteAllText("sync_error.txt", ex.ToString());
            }
            finally
            {
                _isSyncRunning = false;
            }
        }

        void BindYear()
        {
            try
            {
                this.year_dataTable = new DataTable();
                this.year_dataTable = Functions.GetTableDataBySP("Dashboard_Year_Select");

                if (this.year_dataTable != null && this.year_dataTable.Rows.Count > 0)
                {
                    this.cmbYear.DataSource = this.year_dataTable;
                    this.cmbYear.DisplayMember = "YEARS";
                    this.cmbYear.ValueMember = "SrNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : BindYear", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void BindTotalProdYear()
        {
            try
            {
                this.year_dataTable = new DataTable();
                this.year_dataTable = Functions.GetTableDataBySP("Dashboard_Year_Select");

                if (this.year_dataTable != null && this.year_dataTable.Rows.Count > 0)
                {
                    this.cmbTotalProdYear.DataSource = this.year_dataTable;
                    this.cmbTotalProdYear.DisplayMember = "YEARS";
                    this.cmbTotalProdYear.ValueMember = "SrNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : BindTotalProdYear", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void BindChart(string year)
        {
            try
            {

                this.dataTable = new DataTable();
                this.dataTable = Functions.GetTableDataBySPWithParam("Dashboard_ChartDataForYear", string.Concat(new string[]
                {
                        "@Year='",
                        year,
                        "'"
                }));

                if (this.dataTable != null && this.dataTable.Rows.Count > 0)
                {
                    this.chartTotalProdCurrentYear.DataSource = this.dataTable;
                    this.chartTotalProdCurrentYear.Series["TotalProduction"].XValueMember = "Month";
                    this.chartTotalProdCurrentYear.Series["TotalProduction"].YValueMembers = "TotalProduction";
                    this.chartTotalProdCurrentYear.Titles.Clear();
                    this.chartTotalProdCurrentYear.Titles.Add("Total Production Chart For Current Year");
                    this.chartTotalProdCurrentYear.Series["TotalProduction"].ChartType = SeriesChartType.Column;
                    this.chartTotalProdCurrentYear.Series["TotalProduction"].IsValueShownAsLabel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : BindChart", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void BindTotalProdForMonth(string year)
        {
            try
            {

                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySPWithParam("Dashboard_TotalProdForMonth", string.Concat(new string[]
                {
                        "@Year='",
                        year,
                        "'"
                }));

                this.TotalProdForMonth_dataTable = new DataTable();
                DataColumn dtColumn1 = new DataColumn();
                dtColumn1.DataType = typeof(string);
                dtColumn1.ColumnName = "Month";
                dtColumn1.Caption = "Month";
                this.TotalProdForMonth_dataTable.Columns.Add(dtColumn1);

                DataColumn dtColumn2 = new DataColumn();
                dtColumn2.DataType = typeof(double);
                dtColumn2.ColumnName = "Total";
                dtColumn2.Caption = "Total";
                this.TotalProdForMonth_dataTable.Columns.Add(dtColumn2);

                if (this.dataTable != null && this.dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dataTable.Rows.Count; i++)
                    {
                        DataRow dataRow = this.TotalProdForMonth_dataTable.NewRow();
                        dataRow[0] = this.dataTable.Rows[i][1];
                        dataRow[1] = this.dataTable.Rows[i][2];

                        this.TotalProdForMonth_dataTable.Rows.Add(dataRow);
                    }

                    dgvTotalProdForMonth.DataSource = this.TotalProdForMonth_dataTable;
                    this.dgvTotalProdForMonth.Columns[1].Width = 130;

                    foreach (DataGridViewColumn column in dgvTotalProdForMonth.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    string month = this.TotalProdForMonth_dataTable.Rows[0][0].ToString();
                    TotalProdForSelectedMonth(month, year);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : BindTotalProdForMonth", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        void BindCurrentMonthTotalProd()
        {
            try
            {
                this.CurMonData_dataTable = new DataTable();

                DataColumn dtColumn1 = new DataColumn();
                dtColumn1.DataType = typeof(string);
                dtColumn1.ColumnName = "Title";
                dtColumn1.Caption = "";
                this.CurMonData_dataTable.Columns.Add(dtColumn1);

                DataColumn dtColumn2 = new DataColumn();
                dtColumn2.DataType = typeof(double);
                dtColumn2.ColumnName = "Daily";
                dtColumn2.Caption = "Daily";
                this.CurMonData_dataTable.Columns.Add(dtColumn2);

                DataColumn dtColumn3 = new DataColumn();
                dtColumn3.DataType = typeof(double);
                dtColumn3.ColumnName = "Weekly";
                dtColumn3.Caption = "Weekly";
                this.CurMonData_dataTable.Columns.Add(dtColumn3);

                DataColumn dtColumn4 = new DataColumn();
                dtColumn4.DataType = typeof(double);
                dtColumn4.ColumnName = "Monthly";
                dtColumn4.Caption = "Monthly";
                this.CurMonData_dataTable.Columns.Add(dtColumn4);

                DataColumn dtColumn5 = new DataColumn();
                dtColumn5.DataType = typeof(decimal);
                dtColumn5.ColumnName = "Total";
                dtColumn5.Caption = "Total";
                dtColumn5.DefaultValue = 0.00;
                this.CurMonData_dataTable.Columns.Add(dtColumn5);

                this.dataTable = new DataTable();
                this.dataTable = Functions.GetTableDataBySP("Dashboard_CurrentMonthData");

                if (this.dataTable != null && this.dataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dataTable.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            DataRow dataRow11 = this.CurMonData_dataTable.NewRow();
                            dataRow11[0] = this.dataTable.Columns[12].ColumnName;
                            dataRow11[1] = this.dataTable.Rows[i][12];
                            dataRow11[2] = 0.0;
                            dataRow11[3] = 0.0;
                            dataRow11[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow11);

                            DataRow dataRow1 = this.CurMonData_dataTable.NewRow();
                            dataRow1[0] = this.dataTable.Columns[2].ColumnName;
                            dataRow1[1] = this.dataTable.Rows[i][2];
                            dataRow1[2] = 0.0;
                            dataRow1[3] = 0.0;
                            dataRow1[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow1);

                            DataRow dataRow2 = this.CurMonData_dataTable.NewRow();
                            dataRow2[0] = this.dataTable.Columns[3].ColumnName;
                            dataRow2[1] = this.dataTable.Rows[i][3];
                            dataRow2[2] = 0.0;
                            dataRow2[3] = 0.0;
                            dataRow2[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow2);

                            DataRow dataRow3 = this.CurMonData_dataTable.NewRow();
                            dataRow3[0] = this.dataTable.Columns[4].ColumnName;
                            dataRow3[1] = this.dataTable.Rows[i][4];
                            dataRow3[2] = 0.0;
                            dataRow3[3] = 0.0;
                            dataRow3[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow3);

                            DataRow dataRow4 = this.CurMonData_dataTable.NewRow();
                            dataRow4[0] = this.dataTable.Columns[5].ColumnName;
                            dataRow4[1] = this.dataTable.Rows[i][5];
                            dataRow4[2] = 0.0;
                            dataRow4[3] = 0.0;
                            dataRow4[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow4);

                            DataRow dataRow5 = this.CurMonData_dataTable.NewRow();
                            dataRow5[0] = this.dataTable.Columns[6].ColumnName;
                            dataRow5[1] = this.dataTable.Rows[i][6];
                            dataRow5[2] = 0.0;
                            dataRow5[3] = 0.0;
                            dataRow5[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow5);

                            DataRow dataRow6 = this.CurMonData_dataTable.NewRow();
                            dataRow6[0] = this.dataTable.Columns[7].ColumnName;
                            dataRow6[1] = this.dataTable.Rows[i][7];
                            dataRow6[2] = 0.0;
                            dataRow6[3] = 0.0;
                            dataRow6[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow6);

                            DataRow dataRow7 = this.CurMonData_dataTable.NewRow();
                            dataRow7[0] = this.dataTable.Columns[8].ColumnName;
                            dataRow7[1] = this.dataTable.Rows[i][8];
                            dataRow7[2] = 0.0;
                            dataRow7[3] = 0.0;
                            dataRow7[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow7);

                            DataRow dataRow8 = this.CurMonData_dataTable.NewRow();
                            dataRow8[0] = this.dataTable.Columns[9].ColumnName;
                            dataRow8[1] = this.dataTable.Rows[i][9];
                            dataRow8[2] = 0.0;
                            dataRow8[3] = 0.0;
                            dataRow8[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow8);

                            DataRow dataRow9 = this.CurMonData_dataTable.NewRow();
                            dataRow9[0] = this.dataTable.Columns[10].ColumnName;
                            dataRow9[1] = this.dataTable.Rows[i][10];
                            dataRow9[2] = 0.0;
                            dataRow9[3] = 0.0;
                            dataRow9[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow9);

                            DataRow dataRow10 = this.CurMonData_dataTable.NewRow();
                            dataRow10[0] = this.dataTable.Columns[11].ColumnName;
                            dataRow10[1] = this.dataTable.Rows[i][11];
                            dataRow10[2] = 0.0;
                            dataRow10[3] = 0.0;
                            dataRow10[4] = 0.0;
                            this.CurMonData_dataTable.Rows.Add(dataRow10);

                        }
                        if (i == 1)
                        {
                            this.CurMonData_dataTable.Rows[0][2] = this.dataTable.Rows[i][12];
                            this.CurMonData_dataTable.Rows[1][2] = this.dataTable.Rows[i][2];
                            this.CurMonData_dataTable.Rows[2][2] = this.dataTable.Rows[i][3];
                            this.CurMonData_dataTable.Rows[3][2] = this.dataTable.Rows[i][4];
                            this.CurMonData_dataTable.Rows[4][2] = this.dataTable.Rows[i][5];
                            this.CurMonData_dataTable.Rows[5][2] = this.dataTable.Rows[i][6];
                            this.CurMonData_dataTable.Rows[6][2] = this.dataTable.Rows[i][7];
                            this.CurMonData_dataTable.Rows[7][2] = this.dataTable.Rows[i][8];
                            this.CurMonData_dataTable.Rows[8][2] = this.dataTable.Rows[i][9];
                            this.CurMonData_dataTable.Rows[9][2] = this.dataTable.Rows[i][10];
                            this.CurMonData_dataTable.Rows[10][2] = this.dataTable.Rows[i][11];

                        }
                        if (i == 2)
                        {
                            this.CurMonData_dataTable.Rows[0][3] = this.dataTable.Rows[i][12];
                            this.CurMonData_dataTable.Rows[1][3] = this.dataTable.Rows[i][2];
                            this.CurMonData_dataTable.Rows[2][3] = this.dataTable.Rows[i][3];
                            this.CurMonData_dataTable.Rows[3][3] = this.dataTable.Rows[i][4];
                            this.CurMonData_dataTable.Rows[4][3] = this.dataTable.Rows[i][5];
                            this.CurMonData_dataTable.Rows[5][3] = this.dataTable.Rows[i][6];
                            this.CurMonData_dataTable.Rows[6][3] = this.dataTable.Rows[i][7];
                            this.CurMonData_dataTable.Rows[7][3] = this.dataTable.Rows[i][8];
                            this.CurMonData_dataTable.Rows[8][3] = this.dataTable.Rows[i][9];
                            this.CurMonData_dataTable.Rows[9][3] = this.dataTable.Rows[i][10];
                            this.CurMonData_dataTable.Rows[10][3] = this.dataTable.Rows[i][11];

                        }
                        if (i == 3)
                        {
                            this.CurMonData_dataTable.Rows[0][4] = this.dataTable.Rows[i][12];
                            this.CurMonData_dataTable.Rows[1][4] = this.dataTable.Rows[i][2];
                            this.CurMonData_dataTable.Rows[2][4] = this.dataTable.Rows[i][3];
                            this.CurMonData_dataTable.Rows[3][4] = this.dataTable.Rows[i][4];
                            this.CurMonData_dataTable.Rows[4][4] = this.dataTable.Rows[i][5];
                            this.CurMonData_dataTable.Rows[5][4] = this.dataTable.Rows[i][6];
                            this.CurMonData_dataTable.Rows[6][4] = this.dataTable.Rows[i][7];
                            this.CurMonData_dataTable.Rows[7][4] = this.dataTable.Rows[i][8];
                            this.CurMonData_dataTable.Rows[8][4] = this.dataTable.Rows[i][9];
                            this.CurMonData_dataTable.Rows[9][4] = this.dataTable.Rows[i][10];
                            this.CurMonData_dataTable.Rows[10][4] = this.dataTable.Rows[i][11];
                            //this.CurMonData_dataTable.Rows[10][4] = string.Format("{0:0.00}", this.CurMonData_dataTable.Rows[10][4]);

                        }
                    }

                    this.dgvProductionData.DataSource = this.CurMonData_dataTable;

                    this.dgvProductionData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    this.dgvProductionData.ColumnHeadersHeight = 40;
                    this.dgvProductionData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    this.dgvProductionData.RowTemplate.Height = 40;
                    this.dgvProductionData.Columns[0].Width = 290;
                    this.dgvProductionData.Columns[1].Width = 220;
                    this.dgvProductionData.Columns[2].Width = 220;
                    this.dgvProductionData.Columns[3].Width = 220;
                    this.dgvProductionData.Columns[4].Width = 220;
                    /*bool flag3 = this.dgvProductionData.Rows.Count > 0;
                    if (flag3)
                    {
                        this.dgvProductionData.CurrentCell = this.dgvProductionData.Rows[0].Cells[1];
                        this.dgvProductionData.Rows[0].Selected = true;
                    }*/
                    //this.dgvList.Columns["PID"].Visible = false;
                    //this.dgvList.Columns["TransType"].Visible = false;

                    foreach (DataGridViewColumn column in dgvProductionData.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    //for (int i = 0; i < this.dgvProductionData.Rows.Count; i++)
                    //{
                    //    bool flag4 = (i + 1) % 2 != 0;
                    //    if (flag4)
                    //    {
                    //        this.dgvProductionData.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 226, 239, 218);
                    //    }
                    //    else
                    //    {
                    //        this.dgvProductionData.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    //    }

                    //    if (i == this.dgvProductionData.Rows.Count - 1)
                    //        this.dgvProductionData.Rows[i].DefaultCellStyle.BackColor = Color.FromName("lightblue");
                    //}
                    // Select 2nd row by default (fallback to first)
                    HighlightFirstRow(dgvProductionData);

                    if (dgvProductionData.Rows.Count > 1)
                    {
                        dgvProductionData.CurrentCell =
                            dgvProductionData.Rows[1].Cells[1];
                        dgvProductionData.Rows[1].Selected = true;
                    }

                    //this.dgvProductionData.Rows[this.dgvProductionData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromName("Blue");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error : BindCurrentMonthTotalProd", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void HighlightFirstRow(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0) return;

            var row = dgv.Rows[0];

            row.DefaultCellStyle.BackColor = Color.FromArgb(48, 108, 207);
            row.DefaultCellStyle.ForeColor = Color.White;
            row.DefaultCellStyle.Font =
                new Font(dgv.Font, FontStyle.Bold);

            row.DefaultCellStyle.SelectionBackColor =
                row.DefaultCellStyle.BackColor;
            row.DefaultCellStyle.SelectionForeColor =
                row.DefaultCellStyle.ForeColor;
        }

        void GetTotalProductionMQube()
        {
            DataTable dataTableTotalMqube = new DataTable();
            dataTableTotalMqube = Functions.GetTableDataBySP("Dashboard_GetTotalProdMQube");

            if (dataTableTotalMqube != null && dataTableTotalMqube.Rows.Count > 0)
            {
                lblTotalProdMqube.Text = "Total Production M³ : " + dataTableTotalMqube.Rows[0][0].ToString();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Login login = new Login();
            //    base.Hide();
            //    login.Show();
            //    login.BringToFront();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}

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

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    Login login = new Login();
                    base.Hide();
                    login.Show();
                    login.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnWeighBridge_Click(object sender, EventArgs e)
        {
            try
            {
                ReadData weighBridge = new ReadData();
                base.Hide();
                weighBridge.Show();
                weighBridge.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                PasswordForUsersForm passForUsersForm = new PasswordForUsersForm();
                base.Hide();
                passForUsersForm.Show();
                passForUsersForm.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btnAllData_Click(object sender, EventArgs e)
        {
            try
            {
                AllTransaction user = new AllTransaction();
                base.Hide();
                user.Show();
                user.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void btnCompanyMaster_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyMaster company = new CompanyMaster();
                base.Hide();
                company.Show();
                company.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnConsumptionRpt_Click(object sender, EventArgs e)
        {
            try
            {
                ConsumptionReport consumptionData = new ConsumptionReport();
                base.Hide();
                consumptionData.Show();
                consumptionData.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnTripRpt_Click(object sender, EventArgs e)
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

        private void btnProductionRpt_Click(object sender, EventArgs e)
        {
            try
            {
                ProductionReport productData = new ProductionReport();
                base.Hide();
                productData.Show();
                productData.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private DataTable dataTable = null;

        private DataTable CurMonData_dataTable = null;

        private DataTable TotalProdForMonth_dataTable = null;

        private DataTable TotalProdForSelectedMonth_dataTable = null;

        private DataTable year_dataTable = null;

        /*private void dgvTotalProdForMonth_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(IsANonHeaderButtonCell(e))
            {
                TotalProdForSelectedMonth(e);
            }
        }

        private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dgvTotalProdForMonth.Columns[cellEvent.ColumnIndex] is
                DataGridViewButtonColumn &&
                cellEvent.RowIndex != -1)
            { return true; }
            else { return (false); }
        }*/

        private void dgvTotalProdForMonth_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedMonth(e);

        }

        private void SelectedMonth(DataGridViewCellEventArgs e)
        {
            this.TotalProdForSelectedMonth_dataTable = new DataTable();
            string month = dgvTotalProdForMonth.Rows[e.RowIndex].Cells[0].Value.ToString();
            string year = "";
            if (cmbYear.SelectedIndex > 0)
                year = cmbYear.Text;
            else
                year = currentyear;

            TotalProdForSelectedMonth(month, year);
        }

        private void TotalProdForSelectedMonth(string month, string year)
        {

            this.TotalProdForSelectedMonth_dataTable = new DataTable();
            this.dataTable = new DataTable();

            this.dataTable = Functions.GetTableDataBySPWithParam("Dashboard_TotalProdForSelectedMonth", string.Concat(new string[]
            {
                        "@Month='",
                        month,
                        "',@Year='",
                        year,
                        "'"
            }));

            DataColumn dtColumn1 = new DataColumn();
            dtColumn1.DataType = typeof(string);
            dtColumn1.ColumnName = "";
            dtColumn1.Caption = "";
            this.TotalProdForSelectedMonth_dataTable.Columns.Add(dtColumn1);

            DataColumn dtColumn2 = new DataColumn();
            dtColumn2.DataType = typeof(double);
            dtColumn2.ColumnName = "";
            dtColumn2.Caption = "";
            this.TotalProdForSelectedMonth_dataTable.Columns.Add(dtColumn2);

            if (this.dataTable != null && this.dataTable.Rows.Count > 0)
            {

                DataRow dataRow1 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow1[0] = this.dataTable.Columns[0].ColumnName;
                dataRow1[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow1);

                DataRow dataRow2 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow2[0] = this.dataTable.Columns[1].ColumnName;
                dataRow2[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow2);

                DataRow dataRow3 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow3[0] = this.dataTable.Columns[2].ColumnName;
                dataRow3[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow3);

                DataRow dataRow4 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow4[0] = this.dataTable.Columns[3].ColumnName;
                dataRow4[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow4);

                DataRow dataRow5 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow5[0] = this.dataTable.Columns[4].ColumnName;
                dataRow5[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow5);

                DataRow dataRow6 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow6[0] = this.dataTable.Columns[5].ColumnName;
                dataRow6[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow6);

                DataRow dataRow7 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow7[0] = this.dataTable.Columns[6].ColumnName;
                dataRow7[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow7);

                DataRow dataRow8 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow8[0] = this.dataTable.Columns[7].ColumnName;
                dataRow8[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow8);

                DataRow dataRow9 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow9[0] = this.dataTable.Columns[8].ColumnName;
                dataRow9[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow9);

                DataRow dataRow10 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow10[0] = this.dataTable.Columns[9].ColumnName;
                dataRow10[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow10);

                DataRow dataRow11 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                dataRow11[0] = this.dataTable.Columns[10].ColumnName;
                dataRow11[1] = 0.0;
                this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow11);

                //DataRow dataRow12 = this.TotalProdForSelectedMonth_dataTable.NewRow();
                //dataRow11[0] = this.dataTable.Columns[10].ColumnName;
                //dataRow11[1] = 0.0;
                //this.TotalProdForSelectedMonth_dataTable.Rows.Add(dataRow11);

                for (int a = 0; a < this.dataTable.Rows.Count; a++)
                {
                    if (a == 0)
                    {
                        this.TotalProdForSelectedMonth_dataTable.Rows[0][1] = this.dataTable.Rows[a][0];
                        this.TotalProdForSelectedMonth_dataTable.Rows[1][1] = this.dataTable.Rows[a][1];
                        this.TotalProdForSelectedMonth_dataTable.Rows[2][1] = this.dataTable.Rows[a][2];
                        this.TotalProdForSelectedMonth_dataTable.Rows[3][1] = this.dataTable.Rows[a][3];
                        this.TotalProdForSelectedMonth_dataTable.Rows[4][1] = this.dataTable.Rows[a][4];
                        this.TotalProdForSelectedMonth_dataTable.Rows[5][1] = this.dataTable.Rows[a][5];
                        this.TotalProdForSelectedMonth_dataTable.Rows[6][1] = this.dataTable.Rows[a][6];
                        this.TotalProdForSelectedMonth_dataTable.Rows[7][1] = this.dataTable.Rows[a][7];
                        this.TotalProdForSelectedMonth_dataTable.Rows[8][1] = this.dataTable.Rows[a][8];
                        this.TotalProdForSelectedMonth_dataTable.Rows[9][1] = this.dataTable.Rows[a][9];
                        this.TotalProdForSelectedMonth_dataTable.Rows[10][1] = this.dataTable.Rows[a][10];
                    }

                }

                this.dgvTotalProdForSelectedMon.DataSource = this.TotalProdForSelectedMonth_dataTable;
                this.dgvTotalProdForSelectedMon.Columns[0].Width = 230;
                this.dgvTotalProdForSelectedMon.Columns[1].Width = 180;
                //this.dgvTotalProdForSelectedMon.Columns[2].Width = 129;
                //this.dgvTotalProdForSelectedMon.Columns[3].Width = 129;
                //this.dgvTotalProdForSelectedMon.Columns[4].Width = 129;
                //this.dgvTotalProdForSelectedMon.Columns[5].Width = 129;
                //this.dgvTotalProdForSelectedMon.Columns[6].Width = 129;
                //this.dgvTotalProdForSelectedMon.Columns[7].Width = 129;
                //this.dgvTotalProdForSelectedMon.Columns[8].Width = 129;

                if (this.dgvTotalProdForSelectedMon.Rows.Count > 0)
                {
                    int selectIndex = this.dgvTotalProdForSelectedMon.Rows.Count > 1 ? 1 : 0;
                    this.dgvTotalProdForSelectedMon.CurrentCell =
                        this.dgvTotalProdForSelectedMon.Rows[selectIndex].Cells[1];
                    this.dgvTotalProdForSelectedMon.Rows[selectIndex].Selected = true;
                }

                foreach (DataGridViewColumn column in dgvTotalProdForSelectedMon.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                HighlightFirstRow(dgvTotalProdForSelectedMon);
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedIndex > 0)
                this.BindTotalProdForMonth(cmbYear.Text);
            else
                this.BindTotalProdForMonth(currentyear);
        }

        /*private void btnPLCConnect_Click(object sender, EventArgs e)
        {
            try
            {
                PLCConnect plcConnect = new PLCConnect();
                plcConnect.Show();
                plcConnect.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }*/

        /*static async Task Main()
        {
            // TODO Specify the Dataverse environment name to connect with.
            // See https://learn.microsoft.com/power-apps/developer/data-platform/webapi/compose-http-requests-handle-errors#web-api-url-and-versions
            string resource = "https://org2fc997e3.api.crm8.dynamics.com";

            // Azure Active Directory app registration shared by all Power App samples.
            var clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";
            var redirectUri = "http://localhost"; // Loopback for the interactive login.

            // For your custom apps, you will need to register them with Azure AD yourself.
            // See https://docs.microsoft.com/powerapps/developer/data-platform/walkthrough-register-app-azure-active-directory

            #region Authentication

            var authBuilder = PublicClientApplicationBuilder.Create(clientId)
                           .WithAuthority(AadAuthorityAudience.AzureAdMultipleOrgs)
                           .WithRedirectUri(redirectUri)
                           .Build();
            var scope = resource + "/.default";
            string[] scopes = { scope };

            AuthenticationResult token =
               await authBuilder.AcquireTokenInteractive(scopes).ExecuteAsync();
            #endregion Authentication

            #region Client configuration

            var client = new HttpClient
            {
                // See https://docs.microsoft.com/powerapps/developer/data-platform/webapi/compose-http-requests-handle-errors#web-api-url-and-versions
                BaseAddress = new Uri(resource + "/api/data/v9.2/"),
                Timeout = new TimeSpan(0, 2, 0)    // Standard two minute timeout on web service calls.
            };

            // Default headers for each Web API call.
            // See https://docs.microsoft.com/powerapps/developer/data-platform/webapi/compose-http-requests-handle-errors#http-headers
            HttpRequestHeaders headers = client.DefaultRequestHeaders;
            headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            headers.Add("OData-MaxVersion", "4.0");
            headers.Add("OData-Version", "4.0");
            headers.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            #endregion Client configuration

            #region Web API call

            // Invoke the Web API 'WhoAmI' unbound function.
            // See https://docs.microsoft.com/powerapps/developer/data-platform/webapi/compose-http-requests-handle-errors
            // See https://docs.microsoft.com/powerapps/developer/data-platform/webapi/use-web-api-functions#unbound-functions
            var response = await client.GetAsync("WhoAmI");

            if (response.IsSuccessStatusCode)
            {
                // Parse the JSON formatted service response (WhoAmIResponse) to obtain the user ID value.
                // See https://learn.microsoft.com/power-apps/developer/data-platform/webapi/reference/whoamiresponse
                Guid userId = new();

                string jsonContent = await response.Content.ReadAsStringAsync();

                // Using System.Text.Json
                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    JsonElement root = doc.RootElement;
                    JsonElement userIdElement = root.GetProperty("UserId");
                    userId = userIdElement.GetGuid();
                }

                // Alternate code, but requires that the WhoAmIResponse class be defined (see below).
                // WhoAmIResponse whoAmIresponse = JsonSerializer.Deserialize<WhoAmIResponse>(jsonContent);
                // userId = whoAmIresponse.UserId;

                Console.WriteLine($"Your user ID is {userId}");
            }
            else
            {
                Console.WriteLine("Web API call failed");
                Console.WriteLine("Reason: " + response.ReasonPhrase);
            }
            #endregion Web API call
        }*/

        private void btnPlcDataToCRM_Click(object sender, EventArgs e)
        {
            this.dataTable = new DataTable();
            this.dataTable = Functions.GetTableDataBySP("PLCDataForCRM");

            if (this.dataTable != null && this.dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataTable.Rows.Count; i++)
                {
                    DateTime plcdate = Convert.ToDateTime(this.dataTable.Rows[i][1].ToString());
                    string customer = this.dataTable.Rows[i][2].ToString();
                    string client = this.dataTable.Rows[i][3].ToString();
                    string site = this.dataTable.Rows[i][4].ToString();
                    string recipe = this.dataTable.Rows[i][5].ToString();
                    string truckno = this.dataTable.Rows[i][6].ToString();
                    string driver = this.dataTable.Rows[i][7].ToString();
                    double batchsize = Convert.ToDouble(this.dataTable.Rows[i][8].ToString());
                    int batchno = Convert.ToInt32(this.dataTable.Rows[i][9].ToString());
                    int setcycle = Convert.ToInt32(this.dataTable.Rows[i][10].ToString());
                    int cycle = Convert.ToInt32(this.dataTable.Rows[i][11].ToString());
                    double bin1set = Convert.ToDouble(this.dataTable.Rows[i][12].ToString());
                    int bin1actual = Convert.ToInt32(this.dataTable.Rows[i][13].ToString());
                    double bin2set = Convert.ToDouble(this.dataTable.Rows[i][14].ToString());
                    int bin2actual = Convert.ToInt32(this.dataTable.Rows[i][15].ToString());
                    double bin3set = Convert.ToDouble(this.dataTable.Rows[i][16].ToString());
                    int bin3actual = Convert.ToInt32(this.dataTable.Rows[i][17].ToString());
                    double bin4set = Convert.ToDouble(this.dataTable.Rows[i][18].ToString());
                    int bin4actual = Convert.ToInt32(this.dataTable.Rows[i][19].ToString());
                    double cementset = Convert.ToDouble(this.dataTable.Rows[i][20].ToString());
                    int cementactual = Convert.ToInt32(this.dataTable.Rows[i][21].ToString());
                    double flyashset = Convert.ToDouble(this.dataTable.Rows[i][22].ToString());
                    int flyashactual = Convert.ToInt32(this.dataTable.Rows[i][23].ToString());
                    double waterset = Convert.ToDouble(this.dataTable.Rows[i][24].ToString());
                    int wateractual = Convert.ToInt32(this.dataTable.Rows[i][25].ToString());
                    double aditiveset = Convert.ToDouble(this.dataTable.Rows[i][26].ToString());
                    double aditiveactual = Convert.ToDouble(this.dataTable.Rows[i][27].ToString());
                    double totalactual = Convert.ToDouble(this.dataTable.Rows[i][28].ToString());
                    double silicaset = Convert.ToDouble(this.dataTable.Rows[i][29].ToString());
                    int silicaactual = Convert.ToInt32(this.dataTable.Rows[i][30].ToString());
                    double ggbsset = Convert.ToDouble(this.dataTable.Rows[i][31].ToString());
                    int ggbsactual = Convert.ToInt32(this.dataTable.Rows[i][32].ToString());

                }
            }
        }

        //private void btnImportCSV_Click(object sender, EventArgs e)
        //{
        //    //Creating object of datatable  
        //    DataTable tblcsv = new DataTable();
        //    DataTable importcsvlastread = new DataTable();
        //    //creating columns  
        //    tblcsv.Columns.Add("PLCDate");
        //    tblcsv.Columns.Add("ReadDataDateTime");
        //    tblcsv.Columns.Add("Customer");
        //    tblcsv.Columns.Add("ClientName");
        //    tblcsv.Columns.Add("SiteName");
        //    tblcsv.Columns.Add("RecipeName");
        //    tblcsv.Columns.Add("TruckNo");
        //    tblcsv.Columns.Add("DriverName");
        //    tblcsv.Columns.Add("BatchSize");
        //    tblcsv.Columns.Add("BatchNo");
        //    tblcsv.Columns.Add("SetCycle");
        //    tblcsv.Columns.Add("Cycle");
        //    tblcsv.Columns.Add("Bin1Set");
        //    tblcsv.Columns.Add("Bin1Actual");
        //    tblcsv.Columns.Add("Bin2Set");
        //    tblcsv.Columns.Add("Bin2Actual");
        //    tblcsv.Columns.Add("Bin3Set");
        //    tblcsv.Columns.Add("Bin3Actual");
        //    tblcsv.Columns.Add("Bin4Set");
        //    tblcsv.Columns.Add("Bin4Actual");
        //    tblcsv.Columns.Add("CementSet");
        //    tblcsv.Columns.Add("CementActual");
        //    tblcsv.Columns.Add("FlyashSet");
        //    tblcsv.Columns.Add("FlyashActual");
        //    tblcsv.Columns.Add("WaterSet");
        //    tblcsv.Columns.Add("WaterActual");
        //    tblcsv.Columns.Add("AdditiveSet");
        //    tblcsv.Columns.Add("AdditiveActual");
        //    tblcsv.Columns.Add("TotalActual");
        //    tblcsv.Columns.Add("SilicaSet");
        //    tblcsv.Columns.Add("SilicaActual");
        //    tblcsv.Columns.Add("GGBSSet");
        //    tblcsv.Columns.Add("GGBSActual");

        //    //getting full file path of Uploaded file  
        //    //string CSVFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        //    string CSVFilePath = @"D:\Nishant\csvfile-1.csv";
        //    //Reading All text  
        //    string ReadCSV = File.ReadAllText(CSVFilePath);

        //    importcsvlastread =  Functions.GetTableDataBySP("ImportCSVLastRead_Select");
        //    DateTime lastreaddatetime = Convert.ToDateTime(importcsvlastread.Rows[0][2].ToString());
        //    int dd = lastreaddatetime.Day;
        //    int mm = lastreaddatetime.Month;
        //    int yy = lastreaddatetime.Year;
        //    string dms = mm.ToString() + '-' + dd.ToString() + '-' + yy.ToString() + ' ' + lastreaddatetime.ToLongTimeString();
        //    DateTime lastreaddatetime_ = Convert.ToDateTime(dms);

        //    //spliting row after new line  
        //    foreach (string csvRow in ReadCSV.Split('\n'))
        //    {
        //        if(csvRow != "")
        //        { 
        //            string[] csvRowArr = csvRow.Split(',');
        //            if(Convert.ToDateTime(csvRowArr[0].ToString()) <= lastreaddatetime_)
        //            {
        //                continue;
        //            }
        //            else
        //            { 
        //                if (!string.IsNullOrEmpty(csvRow))
        //                {
        //                    //Adding each row into datatable  
        //                    tblcsv.Rows.Add();
        //                    int count = 0;
        //                    foreach (string FileRec in csvRow.Split(','))
        //                    {
        //                        if(count == 0)
        //                        {
        //                            DateTime plcDate = Convert.ToDateTime(FileRec);
        //                            tblcsv.Rows[tblcsv.Rows.Count - 1][count] = plcDate.ToString();
        //                            count++;
        //                        }
        //                        else
        //                        { 
        //                            tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
        //                            count++;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    //Calling insert Functions
        //    DateTime UpdateDateTime = Convert.ToDateTime(tblcsv.Rows[tblcsv.Rows.Count - 1][0].ToString());
        //    //string UpdateDateTime_ = (UpdateDateTime.Month.ToString() + '-' + UpdateDateTime.Day.ToString() + '-' +UpdateDateTime.Year.ToString() + ' ' + UpdateDateTime.ToLongTimeString()).ToString();
        //    string UpdateDateTime_ = UpdateDateTime.ToString();

        //    bool addFlag = InsertCSVRecords(tblcsv);
        //    if (addFlag)
        //    {
        //        SQLHelper._objCmd = new SqlCommand();
        //        SQLHelper._objCmd.Parameters.Clear();
        //        SQLHelper._objCmd.Parameters.AddWithValue("@LastReadDateTime", UpdateDateTime_);

        //        string text3 = Queries.UpdateBySP("ImportCSVLastRead_Update");

        //        bool flag4 = text3 != "";
        //        if (flag4)
        //        {
        //            bool flag5 = Functions.DBKeyErrors(text3);
        //            bool flag6 = !flag5;
        //            if (flag6)
        //            {
        //                MessageBox.Show(text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //            }
        //        }
        //        MessageBox.Show("CSV File Imported Successfully");
        //    }
        //}
        //private bool InsertCSVRecords(DataTable csvdt)
        //{
        //    int addCount = 0;
        //    for (int a = 0; a< csvdt.Rows.Count; a++)
        //    {
        //        int csvdtbatchno = Convert.ToInt32(csvdt.Rows[a][8].ToString());
        //        int csvcycle = Convert.ToInt32(csvdt.Rows[a][10].ToString());

        //        this.dataTable = new DataTable();
        //        this.dataTable = Functions.GetTableDataBySPWithParam("ImportCSVBatchno_Cycle_Select", string.Concat(new string[]
        //                {

        //                "@BatchNo='",
        //                csvdtbatchno.ToString(),
        //                "',@Cycle='",
        //                csvcycle.ToString(),
        //                "'"
        //            }));

        //        if (this.dataTable.Rows.Count == 0)
        //        {
        //            SQLHelper._objCmd = new SqlCommand();
        //            SQLHelper._objCmd.Parameters.Clear();
        //            SQLHelper._objCmd.Parameters.AddWithValue("@PLCDate", csvdt.Rows[a][0]);
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Customer", csvdt.Rows[a][1].ToString());
        //            SQLHelper._objCmd.Parameters.AddWithValue("@ClientName", csvdt.Rows[a][2].ToString());
        //            SQLHelper._objCmd.Parameters.AddWithValue("@SiteName", csvdt.Rows[a][3].ToString());
        //            SQLHelper._objCmd.Parameters.AddWithValue("@RecipeName", csvdt.Rows[a][4].ToString());
        //            SQLHelper._objCmd.Parameters.AddWithValue("@TruckNo", csvdt.Rows[a][5].ToString());
        //            SQLHelper._objCmd.Parameters.AddWithValue("@DriverName", csvdt.Rows[a][6].ToString());
        //            SQLHelper._objCmd.Parameters.AddWithValue("@BatchSize", Convert.ToDouble(csvdt.Rows[a][7].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@BatchNo", Convert.ToDouble(csvdt.Rows[a][8].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@SetCycle", Convert.ToDouble(csvdt.Rows[a][9].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Cycle", Convert.ToDouble(csvdt.Rows[a][10].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Set", Convert.ToDouble(csvdt.Rows[a][11].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Actual", Convert.ToDouble(csvdt.Rows[a][12].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Set", Convert.ToDouble(csvdt.Rows[a][13].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Actual", Convert.ToDouble(csvdt.Rows[a][14].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Set", Convert.ToDouble(csvdt.Rows[a][15].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Actual", Convert.ToDouble(csvdt.Rows[a][16].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Set", Convert.ToDouble(csvdt.Rows[a][17].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Actual", Convert.ToDouble(csvdt.Rows[a][18].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@CementSet", Convert.ToDouble(csvdt.Rows[a][19].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@CementActual", Convert.ToDouble(csvdt.Rows[a][20].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@FlyashSet", Convert.ToDouble(csvdt.Rows[a][21].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@FlyashActual", Convert.ToDouble(csvdt.Rows[a][22].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@WaterSet", Convert.ToDouble(csvdt.Rows[a][23].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@WaterActual", Convert.ToDouble(csvdt.Rows[a][24].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveSet", Convert.ToDouble(csvdt.Rows[a][25].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveActual", Convert.ToDouble(csvdt.Rows[a][26].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@SilicaSet", Convert.ToDouble(csvdt.Rows[a][27].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@SilicaActual", Convert.ToDouble(csvdt.Rows[a][28].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@GGBSSet", Convert.ToDouble(csvdt.Rows[a][29].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@GGBSActual", Convert.ToDouble(csvdt.Rows[a][30].ToString()));
        //            SQLHelper._objCmd.Parameters.AddWithValue("@TotalActual", Convert.ToDouble(csvdt.Rows[a][31].ToString()));

        //            string text2 = Queries.InsertBySP("ImportCSVTOPLCData");

        //            bool flag1 = text2 != "";
        //            if (flag1)
        //                MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //            else
        //                addCount++;
        //        }
        //        else
        //            addCount++;
        //    }

        //    if (addCount == csvdt.Rows.Count)
        //        return true;
        //    else
        //        return false;

        //    /*connection();*/
        //    //creating object of SqlBulkCopy    
        //    /*SqlBulkCopy objbulk = new SqlBulkCopy(con);*/
        //    //assigning Destination table name    
        //    /*objbulk.DestinationTableName = "Employee";*/
        //    //Mapping Table column    
        //    /*objbulk.ColumnMappings.Add("Name", "Name");
        //    objbulk.ColumnMappings.Add("City", "City");
        //    objbulk.ColumnMappings.Add("Address", "Address");
        //    objbulk.ColumnMappings.Add("Designation", "Designation");*/
        //    //inserting Datatable Records to DataBase    
        //    /*con.Open();
        //    objbulk.WriteToServer(csvdt);
        //    con.Close();*/
        //}

        private void btnBreakdown_Click(object sender, EventArgs e)
        {
            try
            {
                BreakdownList breakdownList = new BreakdownList();
                base.Hide();
                breakdownList.Show();
                breakdownList.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmbTotalProdYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTotalProdYear.SelectedIndex > 0)
                this.BindChart(cmbTotalProdYear.Text);
            else
                this.BindChart(currentyear);
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            try
            {
                NotesList noteslist = new NotesList();
                base.Hide();
                noteslist.Show();
                noteslist.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void flowPanelButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnHelpDoc_Click(object sender, EventArgs e)
        {
            try
            {
                HelpDocuments hDoc = new HelpDocuments();
                base.Hide();
                hDoc.Show();
                hDoc.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}



using System.Drawing;
using System.Windows.Forms;

namespace NilkanthApplication
{
	public partial class MainScreen : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnWeighBridge = new System.Windows.Forms.Button();
            this.chartTotalProdCurrentYear = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CurrentYearTotalProd = new System.Windows.Forms.TabPage();
            this.lblTotalProdMqube = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTotalProdYear = new System.Windows.Forms.ComboBox();
            this.lblNotification = new System.Windows.Forms.Label();
            this.CurrentMonthProduction = new System.Windows.Forms.TabPage();
            this.dgvProductionData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalProductionForMonth = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.dgvTotalProdForMonth = new System.Windows.Forms.DataGridView();
            this.dgvTotalProdForSelectedMon = new System.Windows.Forms.DataGridView();
            this.btnPlcDataToCRM = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnBreakdown = new System.Windows.Forms.Button();
            this.btnHelpDoc = new System.Windows.Forms.Button();
            this.btnConsumptionRpt = new System.Windows.Forms.Button();
            this.btnCompanyMaster = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnProductionRpt = new System.Windows.Forms.Button();
            this.btnAllData = new System.Windows.Forms.Button();
            this.btnTripRpt = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalProdCurrentYear)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CurrentYearTotalProd.SuspendLayout();
            this.CurrentMonthProduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionData)).BeginInit();
            this.TotalProductionForMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalProdForMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalProdForSelectedMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1288, 770);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 38);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(43, 672);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 17);
            this.lblUserName.TabIndex = 15;
            this.lblUserName.Text = "UserName";
            // 
            // btnWeighBridge
            // 
            this.btnWeighBridge.Location = new System.Drawing.Point(857, 646);
            this.btnWeighBridge.Name = "btnWeighBridge";
            this.btnWeighBridge.Size = new System.Drawing.Size(155, 33);
            this.btnWeighBridge.TabIndex = 19;
            this.btnWeighBridge.Text = "Test WeighBridge";
            this.btnWeighBridge.UseVisualStyleBackColor = true;
            this.btnWeighBridge.Visible = false;
            this.btnWeighBridge.Click += new System.EventHandler(this.btnWeighBridge_Click);
            // 
            // chartTotalProdCurrentYear
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartTotalProdCurrentYear.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTotalProdCurrentYear.Legends.Add(legend1);
            this.chartTotalProdCurrentYear.Location = new System.Drawing.Point(279, 6);
            this.chartTotalProdCurrentYear.Name = "chartTotalProdCurrentYear";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "TotalProduction";
            this.chartTotalProdCurrentYear.Series.Add(series1);
            this.chartTotalProdCurrentYear.Size = new System.Drawing.Size(1033, 461);
            this.chartTotalProdCurrentYear.TabIndex = 37;
            this.chartTotalProdCurrentYear.Text = "Chart1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Home);
            this.tabControl1.Controls.Add(this.CurrentYearTotalProd);
            this.tabControl1.Controls.Add(this.CurrentMonthProduction);
            this.tabControl1.Controls.Add(this.TotalProductionForMonth);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(9, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1353, 548);
            this.tabControl1.TabIndex = 38;

            // 
            // Home
            // 
            this.Home.Controls.Add(this.pictureBox1);
            this.Home.Location = new System.Drawing.Point(4, 38);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(1345, 506);
            this.Home.TabIndex = 3;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.homepage;
            this.pictureBox1.Location = new System.Drawing.Point(17, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1306, 495);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CurrentYearTotalProd
            // 
            this.CurrentYearTotalProd.Controls.Add(this.lblTotalProdMqube);
            this.CurrentYearTotalProd.Controls.Add(this.label3);
            this.CurrentYearTotalProd.Controls.Add(this.cmbTotalProdYear);
            this.CurrentYearTotalProd.Controls.Add(this.chartTotalProdCurrentYear);
            this.CurrentYearTotalProd.Controls.Add(this.lblNotification);
            this.CurrentYearTotalProd.Location = new System.Drawing.Point(4, 38);
            this.CurrentYearTotalProd.Name = "CurrentYearTotalProd";
            this.CurrentYearTotalProd.Padding = new System.Windows.Forms.Padding(3);
            this.CurrentYearTotalProd.Size = new System.Drawing.Size(1345, 506);
            this.CurrentYearTotalProd.TabIndex = 0;
            this.CurrentYearTotalProd.Text = "Year Total Production";
            this.CurrentYearTotalProd.UseVisualStyleBackColor = true;
            // 
            // lblTotalProdMqube
            // 
            this.lblTotalProdMqube.AutoSize = true;
            this.lblTotalProdMqube.Location = new System.Drawing.Point(1, 190);
            this.lblTotalProdMqube.Name = "lblTotalProdMqube";
            this.lblTotalProdMqube.Size = new System.Drawing.Size(172, 29);
            this.lblTotalProdMqube.TabIndex = 44;
            this.lblTotalProdMqube.Text = "Total Prod m³";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 29);
            this.label3.TabIndex = 39;
            this.label3.Text = "Select Year";
            // 
            // cmbTotalProdYear
            // 
            this.cmbTotalProdYear.FormattingEnabled = true;
            this.cmbTotalProdYear.Location = new System.Drawing.Point(154, 35);
            this.cmbTotalProdYear.Name = "cmbTotalProdYear";
            this.cmbTotalProdYear.Size = new System.Drawing.Size(121, 37);
            this.cmbTotalProdYear.TabIndex = 38;
            this.cmbTotalProdYear.SelectedIndexChanged += new System.EventHandler(this.cmbTotalProdYear_SelectedIndexChanged);
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblNotification.ForeColor = System.Drawing.Color.Red;
            this.lblNotification.Location = new System.Drawing.Point(-4, 485);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(232, 24);
            this.lblNotification.TabIndex = 43;
            this.lblNotification.Text = ".......Notification Text.....";
            // 
            // CurrentMonthProduction
            // 
            this.CurrentMonthProduction.Controls.Add(this.dgvProductionData);
            this.CurrentMonthProduction.Controls.Add(this.label1);
            this.CurrentMonthProduction.Location = new System.Drawing.Point(4, 38);
            this.CurrentMonthProduction.Name = "CurrentMonthProduction";
            this.CurrentMonthProduction.Padding = new System.Windows.Forms.Padding(3);
            this.CurrentMonthProduction.Size = new System.Drawing.Size(1345, 506);
            this.CurrentMonthProduction.TabIndex = 1;
            this.CurrentMonthProduction.Text = "Current Month Production";
            this.CurrentMonthProduction.UseVisualStyleBackColor = true;

            // -------------------------------
            // label1 (Header)
            // -------------------------------
            this.label1.Dock = DockStyle.Top;
            this.label1.Height = 35;
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Name = "label1";
            this.label1.TabIndex = 1;
            this.label1.Text = "Production";
            // 
            // dgvProductionData
            // 
            this.dgvProductionData.AllowUserToAddRows = false;
            this.dgvProductionData.AllowUserToDeleteRows = false;
            this.dgvProductionData.AllowUserToResizeColumns = true;
            this.dgvProductionData.AllowUserToResizeRows = true;

            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvProductionData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductionData.BackgroundColor = System.Drawing.SystemColors.Window;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvProductionData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductionData.ColumnHeadersHeight = 25;
            this.dgvProductionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductionData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductionData.EnableHeadersVisualStyles = false;
            //this.dgvProductionData.Location = new System.Drawing.Point(6, 39);
            this.dgvProductionData.ReadOnly = true;
            this.dgvProductionData.Name = "dgvProductionData";

            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvProductionData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductionData.RowHeadersWidth = 50;
            this.dgvProductionData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductionData.RowsDefaultCellStyle.BackColor = Color.White;

            this.dgvProductionData.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(226, 239, 218);

            this.dgvProductionData.RowTemplate.Height = 28;
            this.dgvProductionData.Dock = DockStyle.Fill;
            this.dgvProductionData.TabIndex = 8;

            // Optional polish
            this.dgvProductionData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductionData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductionData.MultiSelect = false;

            // -------------------------------
            // Highlight first row by default
            // -------------------------------
           

            // 
            // TotalProductionForMonth
            // 
            this.TotalProductionForMonth.Controls.Add(this.label2);
            this.TotalProductionForMonth.Controls.Add(this.cmbYear);
            this.TotalProductionForMonth.Controls.Add(this.dgvTotalProdForMonth);
            this.TotalProductionForMonth.Controls.Add(this.dgvTotalProdForSelectedMon);
            this.TotalProductionForMonth.Location = new System.Drawing.Point(4, 38);
            this.TotalProductionForMonth.Name = "TotalProductionForMonth";
            this.TotalProductionForMonth.Padding = new System.Windows.Forms.Padding(3);
            this.TotalProductionForMonth.Size = new System.Drawing.Size(1345, 506);
            this.TotalProductionForMonth.TabIndex = 2;
            this.TotalProductionForMonth.Text = "Total Production For Month";
            this.TotalProductionForMonth.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select Year";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(161, 20);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 37);
            this.cmbYear.TabIndex = 11;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // dgvTotalProdForMonth
            // 
            this.dgvTotalProdForMonth.AllowUserToAddRows = false;
            this.dgvTotalProdForMonth.AllowUserToDeleteRows = false;
            this.dgvTotalProdForMonth.AllowUserToResizeColumns = false;
            this.dgvTotalProdForMonth.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForMonth.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTotalProdForMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotalProdForMonth.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForMonth.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTotalProdForMonth.ColumnHeadersHeight = 25;
            this.dgvTotalProdForMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTotalProdForMonth.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTotalProdForMonth.EnableHeadersVisualStyles = false;
            this.dgvTotalProdForMonth.Location = new System.Drawing.Point(359, 84);
            this.dgvTotalProdForMonth.Name = "dgvTotalProdForMonth";
            this.dgvTotalProdForMonth.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForMonth.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTotalProdForMonth.RowHeadersVisible = false;
            this.dgvTotalProdForMonth.RowHeadersWidth = 50;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForMonth.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTotalProdForMonth.RowTemplate.Height = 28;
            this.dgvTotalProdForMonth.Size = new System.Drawing.Size(240, 415);
            this.dgvTotalProdForMonth.TabIndex = 10;
            this.dgvTotalProdForMonth.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotalProdForMonth_CellClick);
            // 
            // dgvTotalProdForSelectedMon
            // 
            this.dgvTotalProdForSelectedMon.AllowUserToAddRows = false;
            this.dgvTotalProdForSelectedMon.AllowUserToDeleteRows = false;
            this.dgvTotalProdForSelectedMon.AllowUserToResizeColumns = false;
            this.dgvTotalProdForSelectedMon.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForSelectedMon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTotalProdForSelectedMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTotalProdForSelectedMon.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForSelectedMon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvTotalProdForSelectedMon.ColumnHeadersHeight = 25;
            this.dgvTotalProdForSelectedMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTotalProdForSelectedMon.ColumnHeadersVisible = false;
            this.dgvTotalProdForSelectedMon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTotalProdForSelectedMon.EnableHeadersVisualStyles = false;
            this.dgvTotalProdForSelectedMon.Location = new System.Drawing.Point(604, 84);
            this.dgvTotalProdForSelectedMon.Name = "dgvTotalProdForSelectedMon";
            this.dgvTotalProdForSelectedMon.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForSelectedMon.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTotalProdForSelectedMon.RowHeadersVisible = false;
            this.dgvTotalProdForSelectedMon.RowHeadersWidth = 50;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalProdForSelectedMon.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvTotalProdForSelectedMon.RowTemplate.Height = 28;
            this.dgvTotalProdForSelectedMon.Size = new System.Drawing.Size(415, 415);
            this.dgvTotalProdForSelectedMon.TabIndex = 9;

           
            // 
            // btnPlcDataToCRM
            // 
            this.btnPlcDataToCRM.Location = new System.Drawing.Point(857, 677);
            this.btnPlcDataToCRM.Name = "btnPlcDataToCRM";
            this.btnPlcDataToCRM.Size = new System.Drawing.Size(173, 35);
            this.btnPlcDataToCRM.TabIndex = 40;
            this.btnPlcDataToCRM.Text = "PLC Data To CRM";
            this.btnPlcDataToCRM.UseVisualStyleBackColor = true;
            this.btnPlcDataToCRM.Visible = false;
            this.btnPlcDataToCRM.Click += new System.EventHandler(this.btnPlcDataToCRM_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 690);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Version : 2";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::NilkanthApplication.Properties.Resources.HelplineNo;
            this.pictureBox3.Location = new System.Drawing.Point(1032, 647);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(254, 75);
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            // 
            // btnNotes
            // 
            this.btnNotes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNotes.FlatAppearance.BorderSize = 0;
            this.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(213)))));
            this.btnNotes.Image = global::NilkanthApplication.Properties.Resources.Notes1;
            this.btnNotes.Location = new System.Drawing.Point(413, 647);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(182, 67);
            this.btnNotes.TabIndex = 53;
            this.btnNotes.Text = "&N";
            this.btnNotes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNotes.UseVisualStyleBackColor = true;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnBreakdown
            // 
            this.btnBreakdown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBreakdown.FlatAppearance.BorderSize = 0;
            this.btnBreakdown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBreakdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBreakdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBreakdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(196)))));
            this.btnBreakdown.Image = global::NilkanthApplication.Properties.Resources.breakdown;
            this.btnBreakdown.Location = new System.Drawing.Point(597, 650);
            this.btnBreakdown.Name = "btnBreakdown";
            this.btnBreakdown.Size = new System.Drawing.Size(256, 62);
            this.btnBreakdown.TabIndex = 51;
            this.btnBreakdown.Text = "&b";
            this.btnBreakdown.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBreakdown.UseVisualStyleBackColor = true;
            this.btnBreakdown.Click += new System.EventHandler(this.btnBreakdown_Click);
            // 
            // btnHelpDoc
            // 
            this.btnHelpDoc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHelpDoc.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHelpDoc.FlatAppearance.BorderSize = 0;
            this.btnHelpDoc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnHelpDoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnHelpDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelpDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(213)))));
            this.btnHelpDoc.Image = global::NilkanthApplication.Properties.Resources.HelpDesk;
            this.btnHelpDoc.Location = new System.Drawing.Point(165, 646);
            this.btnHelpDoc.Name = "btnHelpDoc";
            this.btnHelpDoc.Size = new System.Drawing.Size(247, 67);
            this.btnHelpDoc.TabIndex = 44;
            this.btnHelpDoc.Text = "&h";
            this.btnHelpDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelpDoc.UseVisualStyleBackColor = true;
            this.btnHelpDoc.Click += new System.EventHandler(this.btnHelpDoc_Click);
            // 
            // btnConsumptionRpt
            // 
            this.btnConsumptionRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsumptionRpt.FlatAppearance.BorderSize = 0;
            this.btnConsumptionRpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnConsumptionRpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnConsumptionRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumptionRpt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(196)))));
            this.btnConsumptionRpt.Image = global::NilkanthApplication.Properties.Resources.creport;
            this.btnConsumptionRpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsumptionRpt.Location = new System.Drawing.Point(917, 12);
            this.btnConsumptionRpt.Name = "btnConsumptionRpt";
            this.btnConsumptionRpt.Size = new System.Drawing.Size(287, 68);
            this.btnConsumptionRpt.TabIndex = 33;
            this.btnConsumptionRpt.Text = "&c";
            this.btnConsumptionRpt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnConsumptionRpt.UseVisualStyleBackColor = true;
            this.btnConsumptionRpt.Click += new System.EventHandler(this.btnConsumptionRpt_Click);
            // 
            // btnCompanyMaster
            // 
            this.btnCompanyMaster.BackColor = System.Drawing.Color.White;
            this.btnCompanyMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompanyMaster.FlatAppearance.BorderSize = 0;
            this.btnCompanyMaster.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCompanyMaster.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCompanyMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompanyMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(196)))));
            this.btnCompanyMaster.Image = global::NilkanthApplication.Properties.Resources.company;
            this.btnCompanyMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompanyMaster.Location = new System.Drawing.Point(182, 12);
            this.btnCompanyMaster.Name = "btnCompanyMaster";
            this.btnCompanyMaster.Size = new System.Drawing.Size(247, 67);
            this.btnCompanyMaster.TabIndex = 32;
            this.btnCompanyMaster.Text = "&o";
            this.btnCompanyMaster.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCompanyMaster.UseVisualStyleBackColor = false;
            this.btnCompanyMaster.Click += new System.EventHandler(this.btnCompanyMaster_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(213)))));
            this.btnUsers.Image = global::NilkanthApplication.Properties.Resources.users;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(-3, 15);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(187, 60);
            this.btnUsers.TabIndex = 30;
            this.btnUsers.Tag = "";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnProductionRpt
            // 
            this.btnProductionRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductionRpt.FlatAppearance.BorderSize = 0;
            this.btnProductionRpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnProductionRpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnProductionRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductionRpt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(207)))));
            this.btnProductionRpt.Image = global::NilkanthApplication.Properties.Resources.prodreport;
            this.btnProductionRpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductionRpt.Location = new System.Drawing.Point(660, 12);
            this.btnProductionRpt.Name = "btnProductionRpt";
            this.btnProductionRpt.Size = new System.Drawing.Size(263, 67);
            this.btnProductionRpt.TabIndex = 35;
            this.btnProductionRpt.Text = "&p";
            this.btnProductionRpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductionRpt.UseVisualStyleBackColor = true;
            this.btnProductionRpt.Click += new System.EventHandler(this.btnProductionRpt_Click);
            // 
            // btnAllData
            // 
            this.btnAllData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllData.FlatAppearance.BorderSize = 0;
            this.btnAllData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAllData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAllData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(196)))));
            this.btnAllData.Image = global::NilkanthApplication.Properties.Resources.plcdata;
            this.btnAllData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllData.Location = new System.Drawing.Point(418, 13);
            this.btnAllData.Name = "btnAllData";
            this.btnAllData.Size = new System.Drawing.Size(251, 67);
            this.btnAllData.TabIndex = 31;
            this.btnAllData.Text = "&d";
            this.btnAllData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllData.UseVisualStyleBackColor = true;
            this.btnAllData.Click += new System.EventHandler(this.btnAllData_Click);
            // 
            // btnTripRpt
            // 
            this.btnTripRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripRpt.FlatAppearance.BorderSize = 0;
            this.btnTripRpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnTripRpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnTripRpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripRpt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(208)))));
            this.btnTripRpt.Image = global::NilkanthApplication.Properties.Resources.tripreport;
            this.btnTripRpt.Location = new System.Drawing.Point(1205, 12);
            this.btnTripRpt.Name = "btnTripRpt";
            this.btnTripRpt.Size = new System.Drawing.Size(152, 67);
            this.btnTripRpt.TabIndex = 34;
            this.btnTripRpt.Text = "&t";
            this.btnTripRpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTripRpt.UseVisualStyleBackColor = true;
            this.btnTripRpt.Click += new System.EventHandler(this.btnTripRpt_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox2.Location = new System.Drawing.Point(9, 640);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1349, 10);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.Image = global::NilkanthApplication.Properties.Resources.Logout;
            this.btnLogout.Location = new System.Drawing.Point(1289, 653);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(65, 54);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "&l";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1361, 717);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBreakdown);
            this.Controls.Add(this.btnHelpDoc);
            this.Controls.Add(this.btnConsumptionRpt);
            this.Controls.Add(this.btnCompanyMaster);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnProductionRpt);
            this.Controls.Add(this.btnAllData);
            this.Controls.Add(this.btnPlcDataToCRM);
            this.Controls.Add(this.btnTripRpt);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnWeighBridge);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTotalProdCurrentYear)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CurrentYearTotalProd.ResumeLayout(false);
            this.CurrentYearTotalProd.PerformLayout();
            this.CurrentMonthProduction.ResumeLayout(false);
            this.CurrentMonthProduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionData)).EndInit();
            this.TotalProductionForMonth.ResumeLayout(false);
            this.TotalProductionForMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalProdForMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalProdForSelectedMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.Button btnCancel;

		private global::System.Windows.Forms.Label lblUserName;

		private global::System.Windows.Forms.Button btnLogout;

		private global::System.Windows.Forms.Button btnWeighBridge;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnAllData;
        private System.Windows.Forms.Button btnCompanyMaster;
        private System.Windows.Forms.Button btnConsumptionRpt;
        private System.Windows.Forms.Button btnTripRpt;
        private System.Windows.Forms.Button btnProductionRpt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTotalProdCurrentYear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CurrentYearTotalProd;
        private System.Windows.Forms.TabPage CurrentMonthProduction;
        private System.Windows.Forms.TabPage TotalProductionForMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductionData;
        private System.Windows.Forms.DataGridView dgvTotalProdForSelectedMon;
        private System.Windows.Forms.DataGridView dgvTotalProdForMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTotalProdYear;
        private System.Windows.Forms.Button btnPlcDataToCRM;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Button btnHelpDoc;
        private System.Windows.Forms.Button btnBreakdown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNotes;
        private System.Windows.Forms.Label lblTotalProdMqube;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

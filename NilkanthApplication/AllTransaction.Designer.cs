
namespace NilkanthApplication
{
	public partial class AllTransaction : global::System.Windows.Forms.Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllTransaction));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFilterStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkApplyDateFilter = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkApplyYearMonth = new System.Windows.Forms.CheckBox();
            this.cmbToBatch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFromBatch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTruckNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRecipe = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.btnDeletePLCData = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnUploadData = new System.Windows.Forms.Button();
            this.btnManualImport = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(173)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.Location = new System.Drawing.Point(8, 151);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersWidth = 50;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(1347, 454);
            this.dgvList.TabIndex = 7;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            this.dgvList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_RowHeaderMouseClick);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 624);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(84, 20);
            this.lblUserName.TabIndex = 33;
            this.lblUserName.Text = "UerName";
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(612, 734);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 34);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilterStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1359, 32);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFilterStatus
            // 
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(78, 25);
            this.lblFilterStatus.Text = "Filter By:";
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkApplyDateFilter.Location = new System.Drawing.Point(28, 74);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(192, 29);
            this.chkApplyDateFilter.TabIndex = 71;
            this.chkApplyDateFilter.Text = "Apply Date Filter :";
            this.chkApplyDateFilter.UseVisualStyleBackColor = true;
            this.chkApplyDateFilter.CheckedChanged += new System.EventHandler(this.chkApplyDateFilter_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(422, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 25);
            this.label6.TabIndex = 70;
            this.label6.Text = "To Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(190, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 69;
            this.label5.Text = "From Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(497, 73);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(122, 30);
            this.dtpToDate.TabIndex = 68;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(285, 73);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(122, 30);
            this.dtpFromDate.TabIndex = 67;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(83, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 69);
            this.label1.TabIndex = 72;
            this.label1.Text = "PLC Data";
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(495, 111);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 33);
            this.cmbMonth.TabIndex = 104;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(436, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 25);
            this.label12.TabIndex = 103;
            this.label12.Text = "Month";
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(284, 111);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 33);
            this.cmbYear.TabIndex = 102;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(235, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 25);
            this.label11.TabIndex = 101;
            this.label11.Text = "Year";
            // 
            // chkApplyYearMonth
            // 
            this.chkApplyYearMonth.AutoSize = true;
            this.chkApplyYearMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkApplyYearMonth.Location = new System.Drawing.Point(29, 112);
            this.chkApplyYearMonth.Name = "chkApplyYearMonth";
            this.chkApplyYearMonth.Size = new System.Drawing.Size(252, 29);
            this.chkApplyYearMonth.TabIndex = 100;
            this.chkApplyYearMonth.Text = "Apply Year Month Filter :";
            this.chkApplyYearMonth.UseVisualStyleBackColor = true;
            this.chkApplyYearMonth.CheckedChanged += new System.EventHandler(this.chkApplyYearMonth_CheckedChanged);
            // 
            // cmbToBatch
            // 
            this.cmbToBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbToBatch.FormattingEnabled = true;
            this.cmbToBatch.Location = new System.Drawing.Point(1227, 70);
            this.cmbToBatch.Name = "cmbToBatch";
            this.cmbToBatch.Size = new System.Drawing.Size(122, 33);
            this.cmbToBatch.TabIndex = 116;
            this.cmbToBatch.SelectedIndexChanged += new System.EventHandler(this.cmbToBatch_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(1144, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 115;
            this.label3.Text = "To Batch";
            // 
            // cmbFromBatch
            // 
            this.cmbFromBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbFromBatch.FormattingEnabled = true;
            this.cmbFromBatch.Location = new System.Drawing.Point(1005, 71);
            this.cmbFromBatch.Name = "cmbFromBatch";
            this.cmbFromBatch.Size = new System.Drawing.Size(122, 33);
            this.cmbFromBatch.TabIndex = 114;
            this.cmbFromBatch.SelectedIndexChanged += new System.EventHandler(this.cmbFromBatch_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(902, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 113;
            this.label2.Text = "From Batch";
            // 
            // cmbTruckNo
            // 
            this.cmbTruckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbTruckNo.FormattingEnabled = true;
            this.cmbTruckNo.Location = new System.Drawing.Point(1227, 114);
            this.cmbTruckNo.Name = "cmbTruckNo";
            this.cmbTruckNo.Size = new System.Drawing.Size(122, 33);
            this.cmbTruckNo.TabIndex = 112;
            this.cmbTruckNo.SelectedIndexChanged += new System.EventHandler(this.cmbTruckNo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(1151, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 25);
            this.label9.TabIndex = 111;
            this.label9.Text = "TruckNo";
            // 
            // cmbRecipe
            // 
            this.cmbRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbRecipe.FormattingEnabled = true;
            this.cmbRecipe.Location = new System.Drawing.Point(1005, 114);
            this.cmbRecipe.Name = "cmbRecipe";
            this.cmbRecipe.Size = new System.Drawing.Size(122, 33);
            this.cmbRecipe.TabIndex = 110;
            this.cmbRecipe.SelectedIndexChanged += new System.EventHandler(this.cmbRecipe_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(938, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 25);
            this.label8.TabIndex = 109;
            this.label8.Text = "Recipe";
            // 
            // cmbSite
            // 
            this.cmbSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(759, 112);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(122, 33);
            this.cmbSite.TabIndex = 108;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(715, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 25);
            this.label7.TabIndex = 107;
            this.label7.Text = "Site";
            // 
            // cmbClient
            // 
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(761, 70);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(122, 33);
            this.cmbClient.TabIndex = 106;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(699, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 105;
            this.label4.Text = "Client";
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.CausesValidation = false;
            this.btnImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportCSV.FlatAppearance.BorderSize = 0;
            this.btnImportCSV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnImportCSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCSV.Image = global::NilkanthApplication.Properties.Resources.import_icon_1;
            this.btnImportCSV.Location = new System.Drawing.Point(673, 4);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(172, 64);
            this.btnImportCSV.TabIndex = 119;
            this.btnImportCSV.Text = "&Import CSV";
            this.btnImportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnDeletePLCData
            // 
            this.btnDeletePLCData.CausesValidation = false;
            this.btnDeletePLCData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePLCData.FlatAppearance.BorderSize = 0;
            this.btnDeletePLCData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDeletePLCData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDeletePLCData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePLCData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePLCData.Image = global::NilkanthApplication.Properties.Resources.Delete;
            this.btnDeletePLCData.Location = new System.Drawing.Point(843, 3);
            this.btnDeletePLCData.Name = "btnDeletePLCData";
            this.btnDeletePLCData.Size = new System.Drawing.Size(155, 64);
            this.btnDeletePLCData.TabIndex = 118;
            this.btnDeletePLCData.Text = "&Delete PLC Data";
            this.btnDeletePLCData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletePLCData.UseVisualStyleBackColor = true;
            this.btnDeletePLCData.Click += new System.EventHandler(this.btnDeletePLCData_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.CausesValidation = false;
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClearFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilter.Image = global::NilkanthApplication.Properties.Resources.ClearFilter;
            this.btnClearFilter.Location = new System.Drawing.Point(995, 4);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(117, 64);
            this.btnClearFilter.TabIndex = 117;
            this.btnClearFilter.Text = "&Clear Filter";
            this.btnClearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox1.Location = new System.Drawing.Point(7, 606);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1351, 10);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.CausesValidation = false;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Image = global::NilkanthApplication.Properties.Resources.Logout;
            this.btnLogout.Location = new System.Drawing.Point(1262, 611);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(81, 64);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::NilkanthApplication.Properties.Resources.Export;
            this.btnExport.Location = new System.Drawing.Point(1224, -1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 64);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "E&xport";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBack
            // 
            this.btnBack.CausesValidation = false;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::NilkanthApplication.Properties.Resources.back;
            this.btnBack.Location = new System.Drawing.Point(1112, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 64);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "&Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHome.CausesValidation = false;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Image = global::NilkanthApplication.Properties.Resources.Home;
            this.btnHome.Location = new System.Drawing.Point(12, 10);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(83, 61);
            this.btnHome.TabIndex = 5;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnUploadData
            // 
            this.btnUploadData.CausesValidation = false;
            this.btnUploadData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadData.FlatAppearance.BorderSize = 0;
            this.btnUploadData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnUploadData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnUploadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadData.Image = global::NilkanthApplication.Properties.Resources.upload_icon;
            this.btnUploadData.Location = new System.Drawing.Point(329, 5);
            this.btnUploadData.Name = "btnUploadData";
            this.btnUploadData.Size = new System.Drawing.Size(137, 64);
            this.btnUploadData.TabIndex = 120;
            this.btnUploadData.Text = "&Upload Data";
            this.btnUploadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUploadData.UseVisualStyleBackColor = true;
            this.btnUploadData.Click += new System.EventHandler(this.btnUploadData_Click);
            // 
            // btnManualImport
            // 
            this.btnManualImport.CausesValidation = false;
            this.btnManualImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManualImport.FlatAppearance.BorderSize = 0;
            this.btnManualImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnManualImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnManualImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualImport.Image = global::NilkanthApplication.Properties.Resources.import_icon_1;
            this.btnManualImport.Location = new System.Drawing.Point(468, 5);
            this.btnManualImport.Name = "btnManualImport";
            this.btnManualImport.Size = new System.Drawing.Size(206, 64);
            this.btnManualImport.TabIndex = 122;
            this.btnManualImport.Text = "Manual Import";
            this.btnManualImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManualImport.UseVisualStyleBackColor = true;
            this.btnManualImport.Click += new System.EventHandler(this.btnManualImport_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 645);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 20);
            this.label10.TabIndex = 123;
            this.label10.Text = "Version : 2";
            // 
            // AllTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1359, 698);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnManualImport);
            this.Controls.Add(this.btnUploadData);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.btnDeletePLCData);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.cmbToBatch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFromBatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTruckNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbRecipe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkApplyYearMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkApplyDateFilter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllTransaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllTransaction_FormClosing);
            this.Load += new System.EventHandler(this.AllTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.DataGridView dgvList;

		private global::System.Windows.Forms.Button btnHome;

		private global::System.Windows.Forms.Button btnBack;

		private global::System.Windows.Forms.Button btnExport;

		private global::System.Windows.Forms.Label lblUserName;

		private global::System.Windows.Forms.PictureBox pictureBox1;

		private global::System.Windows.Forms.Button btnLogout;

		private global::System.Windows.Forms.Button btnCancel;

		private global::System.Windows.Forms.StatusStrip statusStrip1;

		private global::System.Windows.Forms.ToolStripStatusLabel lblFilterStatus;

		private global::System.Windows.Forms.CheckBox chkApplyDateFilter;

		private global::System.Windows.Forms.Label label6;

		private global::System.Windows.Forms.Label label5;

		private global::System.Windows.Forms.DateTimePicker dtpToDate;

		private global::System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkApplyYearMonth;
        private System.Windows.Forms.ComboBox cmbToBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFromBatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTruckNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRecipe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnDeletePLCData;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.Button btnUploadData;
        private System.Windows.Forms.Button btnManualImport;
        private System.Windows.Forms.Label label10;
    }
}

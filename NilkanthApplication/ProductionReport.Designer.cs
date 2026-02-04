
namespace NilkanthApplication
{
    public partial class ProductionReport : global::System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionReport));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRecipe = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTruckNo = new System.Windows.Forms.ComboBox();
            this.chkApplyDateFilter = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMQube = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFromBatch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbToBatch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.chkApplyYearMonth = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSendWhatsApp = new System.Windows.Forms.Button();
            this.cmbClientDetails = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
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
            this.dgvList.Location = new System.Drawing.Point(6, 149);
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(1351, 477);
            this.dgvList.TabIndex = 7;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(9, 657);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 17);
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
            this.btnCancel.Location = new System.Drawing.Point(260, 657);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 34);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(405, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 70;
            this.label6.Text = "To Date";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(180, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "From Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(478, 75);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(121, 26);
            this.dtpToDate.TabIndex = 68;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "";
            this.dtpFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(275, 74);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(117, 26);
            this.dtpFromDate.TabIndex = 67;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(709, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 76;
            this.label4.Text = "Client";
            // 
            // cmbClient
            // 
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(767, 74);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(122, 28);
            this.cmbClient.TabIndex = 77;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(723, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 78;
            this.label7.Text = "Site";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cmbSite
            // 
            this.cmbSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(767, 115);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(122, 28);
            this.cmbSite.TabIndex = 79;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(944, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 80;
            this.label8.Text = "Recipe";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cmbRecipe
            // 
            this.cmbRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbRecipe.FormattingEnabled = true;
            this.cmbRecipe.Location = new System.Drawing.Point(1011, 115);
            this.cmbRecipe.Name = "cmbRecipe";
            this.cmbRecipe.Size = new System.Drawing.Size(122, 28);
            this.cmbRecipe.TabIndex = 81;
            this.cmbRecipe.SelectedIndexChanged += new System.EventHandler(this.cmbRecipe_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(1158, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 82;
            this.label9.Text = "TruckNo";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // cmbTruckNo
            // 
            this.cmbTruckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbTruckNo.FormattingEnabled = true;
            this.cmbTruckNo.Location = new System.Drawing.Point(1234, 115);
            this.cmbTruckNo.Name = "cmbTruckNo";
            this.cmbTruckNo.Size = new System.Drawing.Size(122, 28);
            this.cmbTruckNo.TabIndex = 83;
            this.cmbTruckNo.SelectedIndexChanged += new System.EventHandler(this.cmbTruckNo_SelectedIndexChanged);
            // 
            // chkApplyDateFilter
            // 
            this.chkApplyDateFilter.AutoSize = true;
            this.chkApplyDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkApplyDateFilter.Location = new System.Drawing.Point(12, 74);
            this.chkApplyDateFilter.Name = "chkApplyDateFilter";
            this.chkApplyDateFilter.Size = new System.Drawing.Size(166, 24);
            this.chkApplyDateFilter.TabIndex = 84;
            this.chkApplyDateFilter.Text = "Apply Date Filter :";
            this.chkApplyDateFilter.UseVisualStyleBackColor = true;
            this.chkApplyDateFilter.CheckedChanged += new System.EventHandler(this.chkApplyDateFilter_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(543, 644);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(210, 58);
            this.label10.TabIndex = 86;
            this.label10.Text = "MQube:";
            // 
            // lblMQube
            // 
            this.lblMQube.AutoSize = true;
            this.lblMQube.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.lblMQube.Location = new System.Drawing.Point(736, 644);
            this.lblMQube.Name = "lblMQube";
            this.lblMQube.Size = new System.Drawing.Size(54, 58);
            this.lblMQube.TabIndex = 87;
            this.lblMQube.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(908, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 88;
            this.label2.Text = "From Batch";
            // 
            // cmbFromBatch
            // 
            this.cmbFromBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbFromBatch.FormattingEnabled = true;
            this.cmbFromBatch.Location = new System.Drawing.Point(1011, 75);
            this.cmbFromBatch.Name = "cmbFromBatch";
            this.cmbFromBatch.Size = new System.Drawing.Size(122, 28);
            this.cmbFromBatch.TabIndex = 89;
            this.cmbFromBatch.SelectedIndexChanged += new System.EventHandler(this.cmbFromBatch_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(1150, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "To Batch";
            // 
            // cmbToBatch
            // 
            this.cmbToBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbToBatch.FormattingEnabled = true;
            this.cmbToBatch.Location = new System.Drawing.Point(1233, 74);
            this.cmbToBatch.Name = "cmbToBatch";
            this.cmbToBatch.Size = new System.Drawing.Size(122, 28);
            this.cmbToBatch.TabIndex = 91;
            this.cmbToBatch.SelectedIndexChanged += new System.EventHandler(this.cmbToBatch_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(97, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 58);
            this.label1.TabIndex = 93;
            this.label1.Text = "Production Report";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.btnClearFilter.Location = new System.Drawing.Point(559, 6);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(118, 64);
            this.btnClearFilter.TabIndex = 94;
            this.btnClearFilter.Text = "&Clear Filter";
            this.btnClearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.CausesValidation = false;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::NilkanthApplication.Properties.Resources.PrintIcon;
            this.btnPrint.Location = new System.Drawing.Point(674, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(116, 64);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox1.Location = new System.Drawing.Point(4, 628);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1354, 10);
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
            this.btnLogout.Location = new System.Drawing.Point(1270, 642);
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
            this.btnExport.Location = new System.Drawing.Point(902, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(126, 64);
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
            this.btnBack.Location = new System.Drawing.Point(788, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(124, 64);
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
            this.btnHome.Location = new System.Drawing.Point(12, 1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(83, 61);
            this.btnHome.TabIndex = 5;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // chkApplyYearMonth
            // 
            this.chkApplyYearMonth.AutoSize = true;
            this.chkApplyYearMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkApplyYearMonth.Location = new System.Drawing.Point(12, 115);
            this.chkApplyYearMonth.Name = "chkApplyYearMonth";
            this.chkApplyYearMonth.Size = new System.Drawing.Size(215, 24);
            this.chkApplyYearMonth.TabIndex = 95;
            this.chkApplyYearMonth.Text = "Apply Year Month Filter :";
            this.chkApplyYearMonth.UseVisualStyleBackColor = true;
            this.chkApplyYearMonth.CheckedChanged += new System.EventHandler(this.chkApplyYearMonth_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(222, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 20);
            this.label11.TabIndex = 96;
            this.label11.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(271, 114);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 28);
            this.cmbYear.TabIndex = 97;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(419, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 98;
            this.label12.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(478, 114);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 28);
            this.cmbMonth.TabIndex = 99;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 680);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 17);
            this.label13.TabIndex = 100;
            this.label13.Text = "Version : 2";
            // 
            // btnSendWhatsApp
            // 
            this.btnSendWhatsApp.CausesValidation = false;
            this.btnSendWhatsApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendWhatsApp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendWhatsApp.FlatAppearance.BorderSize = 0;
            this.btnSendWhatsApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSendWhatsApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSendWhatsApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendWhatsApp.Image = global::NilkanthApplication.Properties.Resources.WhatsAppIcon_1;
            this.btnSendWhatsApp.Location = new System.Drawing.Point(1321, 21);
            this.btnSendWhatsApp.Name = "btnSendWhatsApp";
            this.btnSendWhatsApp.Size = new System.Drawing.Size(35, 35);
            this.btnSendWhatsApp.TabIndex = 129;
            this.btnSendWhatsApp.UseVisualStyleBackColor = true;
            // 
            // cmbClientDetails
            // 
            this.cmbClientDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbClientDetails.FormattingEnabled = true;
            this.cmbClientDetails.Location = new System.Drawing.Point(1096, 25);
            this.cmbClientDetails.Name = "cmbClientDetails";
            this.cmbClientDetails.Size = new System.Drawing.Size(219, 28);
            this.cmbClientDetails.TabIndex = 128;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblClient.Location = new System.Drawing.Point(1038, 28);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(52, 20);
            this.lblClient.TabIndex = 127;
            this.lblClient.Text = "Client";
            // 
            // ProductionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1361, 711);
            this.Controls.Add(this.btnSendWhatsApp);
            this.Controls.Add(this.cmbClientDetails);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkApplyYearMonth);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbToBatch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFromBatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.chkApplyDateFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMQube);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbTruckNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbRecipe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpToDate);
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
            this.Name = "ProductionReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductReport_FormClosing);
            this.Load += new System.EventHandler(this.ProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
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

        private global::System.Windows.Forms.Label label6;

        private global::System.Windows.Forms.Label label5;

        private global::System.Windows.Forms.DateTimePicker dtpToDate;

        private global::System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRecipe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTruckNo;
        private System.Windows.Forms.CheckBox chkApplyDateFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMQube;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFromBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbToBatch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.CheckBox chkApplyYearMonth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSendWhatsApp;
        private System.Windows.Forms.ComboBox cmbClientDetails;
        private System.Windows.Forms.Label lblClient;
    }
}

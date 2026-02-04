
namespace NilkanthApplication
{
    public partial class TripReport : global::System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TripReport));
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.chkLastBatch = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFromBatch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbToBatch = new System.Windows.Forms.ComboBox();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.chkLstBatchNo = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbClientDetails = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnSendWhatsApp = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnManualImport = new System.Windows.Forms.Button();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.btnClearBatches = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnDeliveryChallan = new System.Windows.Forms.Button();
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
            this.dgvList.Location = new System.Drawing.Point(121, 114);
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
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.Height = 28;
            this.dgvList.Size = new System.Drawing.Size(1235, 508);
            this.dgvList.TabIndex = 7;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 653);
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
            this.btnCancel.Location = new System.Drawing.Point(1053, 748);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 34);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(239, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 72;
            this.label2.Text = "Batch";
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(298, 80);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(122, 28);
            this.cmbBatchNo.TabIndex = 73;
            this.cmbBatchNo.SelectedIndexChanged += new System.EventHandler(this.cmbBatchNo_SelectedIndexChanged);
            // 
            // chkLastBatch
            // 
            this.chkLastBatch.AutoSize = true;
            this.chkLastBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLastBatch.Location = new System.Drawing.Point(104, 82);
            this.chkLastBatch.Name = "chkLastBatch";
            this.chkLastBatch.Size = new System.Drawing.Size(113, 24);
            this.chkLastBatch.TabIndex = 75;
            this.chkLastBatch.Text = "Last Batch";
            this.chkLastBatch.UseVisualStyleBackColor = true;
            this.chkLastBatch.CheckedChanged += new System.EventHandler(this.chkLastBatch_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(90, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(287, 58);
            this.label12.TabIndex = 95;
            this.label12.Text = "Trip Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(497, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 96;
            this.label1.Text = "From Batch";
            // 
            // cmbFromBatch
            // 
            this.cmbFromBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbFromBatch.FormattingEnabled = true;
            this.cmbFromBatch.Location = new System.Drawing.Point(600, 80);
            this.cmbFromBatch.Name = "cmbFromBatch";
            this.cmbFromBatch.Size = new System.Drawing.Size(122, 28);
            this.cmbFromBatch.TabIndex = 97;
            this.cmbFromBatch.SelectedIndexChanged += new System.EventHandler(this.cmbFromBatch_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(744, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 98;
            this.label3.Text = "To Batch";
            // 
            // cmbToBatch
            // 
            this.cmbToBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbToBatch.FormattingEnabled = true;
            this.cmbToBatch.Location = new System.Drawing.Point(827, 80);
            this.cmbToBatch.Name = "cmbToBatch";
            this.cmbToBatch.Size = new System.Drawing.Size(122, 28);
            this.cmbToBatch.TabIndex = 99;
            this.cmbToBatch.SelectedIndexChanged += new System.EventHandler(this.cmbToBatch_SelectedIndexChanged);
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(566, 656);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(308, 20);
            this.lblErrorMsg.TabIndex = 101;
            this.lblErrorMsg.Text = "Please Select Batch OR From To Batch";
            // 
            // chkLstBatchNo
            // 
            this.chkLstBatchNo.FormattingEnabled = true;
            this.chkLstBatchNo.Location = new System.Drawing.Point(5, 114);
            this.chkLstBatchNo.Name = "chkLstBatchNo";
            this.chkLstBatchNo.Size = new System.Drawing.Size(110, 508);
            this.chkLstBatchNo.TabIndex = 102;
            this.chkLstBatchNo.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLstBatchNo_ItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 676);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 123;
            this.label4.Text = "Version : 2";
            // 
            // cmbClientDetails
            // 
            this.cmbClientDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbClientDetails.FormattingEnabled = true;
            this.cmbClientDetails.Location = new System.Drawing.Point(1034, 80);
            this.cmbClientDetails.Name = "cmbClientDetails";
            this.cmbClientDetails.Size = new System.Drawing.Size(250, 28);
            this.cmbClientDetails.TabIndex = 125;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblClient.Location = new System.Drawing.Point(976, 83);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(52, 20);
            this.lblClient.TabIndex = 124;
            this.lblClient.Text = "Client";
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
            this.btnSendWhatsApp.Location = new System.Drawing.Point(1290, 75);
            this.btnSendWhatsApp.Name = "btnSendWhatsApp";
            this.btnSendWhatsApp.Size = new System.Drawing.Size(35, 35);
            this.btnSendWhatsApp.TabIndex = 126;
            this.btnSendWhatsApp.UseVisualStyleBackColor = true;
            this.btnSendWhatsApp.Click += new System.EventHandler(this.btnSendWhatsApp_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.CausesValidation = false;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::NilkanthApplication.Properties.Resources.Refresh1;
            this.btnRefresh.Location = new System.Drawing.Point(427, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(138, 64);
            this.btnRefresh.TabIndex = 122;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.btnManualImport.Location = new System.Drawing.Point(571, 8);
            this.btnManualImport.Name = "btnManualImport";
            this.btnManualImport.Size = new System.Drawing.Size(194, 64);
            this.btnManualImport.TabIndex = 121;
            this.btnManualImport.Text = "Manual Import";
            this.btnManualImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManualImport.UseVisualStyleBackColor = true;
            this.btnManualImport.Click += new System.EventHandler(this.btnManualImport_Click);
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
            this.btnImportCSV.Location = new System.Drawing.Point(766, 8);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(171, 64);
            this.btnImportCSV.TabIndex = 120;
            this.btnImportCSV.Text = "PLC &Import";
            this.btnImportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnClearBatches
            // 
            this.btnClearBatches.CausesValidation = false;
            this.btnClearBatches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearBatches.FlatAppearance.BorderSize = 0;
            this.btnClearBatches.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClearBatches.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClearBatches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearBatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearBatches.Image = global::NilkanthApplication.Properties.Resources.ClearFilter;
            this.btnClearBatches.Location = new System.Drawing.Point(937, 7);
            this.btnClearBatches.Name = "btnClearBatches";
            this.btnClearBatches.Size = new System.Drawing.Size(193, 64);
            this.btnClearBatches.TabIndex = 103;
            this.btnClearBatches.Text = "&Clear Batches";
            this.btnClearBatches.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearBatches.UseVisualStyleBackColor = true;
            this.btnClearBatches.Click += new System.EventHandler(this.btnClearBatches_Click);
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
            this.btnPrint.Location = new System.Drawing.Point(1126, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 64);
            this.btnPrint.TabIndex = 74;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox1.Location = new System.Drawing.Point(5, 625);
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
            this.btnLogout.Location = new System.Drawing.Point(1263, 641);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(81, 64);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            this.btnBack.Location = new System.Drawing.Point(1238, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(116, 64);
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
            this.btnHome.Location = new System.Drawing.Point(12, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(83, 61);
            this.btnHome.TabIndex = 5;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnDeliveryChallan
            // 
            this.btnDeliveryChallan.BackColor = System.Drawing.Color.Blue;
            this.btnDeliveryChallan.Location = new System.Drawing.Point(216, 652);
            this.btnDeliveryChallan.Name = "btnDeliveryChallan";
            this.btnDeliveryChallan.Size = new System.Drawing.Size(228, 43);
            this.btnDeliveryChallan.TabIndex = 127;
            this.btnDeliveryChallan.Text = "Delivery Challan";
            this.btnDeliveryChallan.UseVisualStyleBackColor = false;
            this.btnDeliveryChallan.Click += new System.EventHandler(this.btnDeliveryChallan_Click);
            // 
            // TripReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1361, 711);
            this.Controls.Add(this.btnDeliveryChallan);
            this.Controls.Add(this.btnSendWhatsApp);
            this.Controls.Add(this.cmbClientDetails);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnManualImport);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.btnClearBatches);
            this.Controls.Add(this.chkLstBatchNo);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.cmbToBatch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbFromBatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkLastBatch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbBatchNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TripReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TripReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TripReport_FormClosing);
            this.Load += new System.EventHandler(this.TripReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private global::System.ComponentModel.IContainer components = null;

        private global::System.Windows.Forms.DataGridView dgvList;

        private global::System.Windows.Forms.Button btnHome;

        private global::System.Windows.Forms.Button btnBack;

        private global::System.Windows.Forms.Label lblUserName;

        private global::System.Windows.Forms.PictureBox pictureBox1;

        private global::System.Windows.Forms.Button btnLogout;

        private global::System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkLastBatch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFromBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbToBatch;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.CheckedListBox chkLstBatchNo;
        private System.Windows.Forms.Button btnClearBatches;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.Button btnManualImport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbClientDetails;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Button btnSendWhatsApp;
        private System.Windows.Forms.Button btnDeliveryChallan;
    }
}


namespace NilkanthApplication
{
    partial class DeliveryChallan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.txtTruckNo = new System.Windows.Forms.TextBox();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChallanNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbClientDetails = new System.Windows.Forms.ComboBox();
            this.txtQtyInBatch = new System.Windows.Forms.TextBox();
            this.txtTotalOrderQty = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemainingQty = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(101, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(405, 58);
            this.label11.TabIndex = 153;
            this.label11.Text = "Delivery Challan";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(662, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 17);
            this.lblId.TabIndex = 152;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
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
            this.btnBack.Location = new System.Drawing.Point(1205, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(144, 64);
            this.btnBack.TabIndex = 150;
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
            this.btnHome.TabIndex = 151;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(213, 143);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(409, 28);
            this.cmbBatchNo.TabIndex = 155;
            this.cmbBatchNo.SelectedIndexChanged += new System.EventHandler(this.cmbBatchNo_SelectedIndexChanged);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.Location = new System.Drawing.Point(28, 334);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(177, 25);
            this.lblCompanyName.TabIndex = 156;
            this.lblCompanyName.Text = "Customer Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(120, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 157;
            this.label1.Text = "Batch :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 158;
            this.label2.Text = "Company Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(64, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 159;
            this.label3.Text = "Client Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(82, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 25);
            this.label4.TabIndex = 160;
            this.label4.Text = "Site Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(54, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 161;
            this.label5.Text = "Recipe Name :";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCompanyName.Location = new System.Drawing.Point(213, 381);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(409, 30);
            this.txtCompanyName.TabIndex = 162;
            // 
            // txtClientName
            // 
            this.txtClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtClientName.Location = new System.Drawing.Point(213, 419);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(409, 30);
            this.txtClientName.TabIndex = 163;
            // 
            // txtSiteName
            // 
            this.txtSiteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSiteName.Location = new System.Drawing.Point(213, 457);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(409, 30);
            this.txtSiteName.TabIndex = 164;
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRecipeName.Location = new System.Drawing.Point(213, 494);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(409, 30);
            this.txtRecipeName.TabIndex = 165;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(716, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 25);
            this.label6.TabIndex = 166;
            this.label6.Text = "Batch Details";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDriverName.Location = new System.Drawing.Point(901, 490);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(409, 30);
            this.txtDriverName.TabIndex = 174;
            // 
            // txtTruckNo
            // 
            this.txtTruckNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTruckNo.Location = new System.Drawing.Point(901, 453);
            this.txtTruckNo.Name = "txtTruckNo";
            this.txtTruckNo.Size = new System.Drawing.Size(409, 30);
            this.txtTruckNo.TabIndex = 173;
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBatchNo.Location = new System.Drawing.Point(901, 415);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(409, 30);
            this.txtBatchNo.TabIndex = 172;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(750, 493);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 25);
            this.label7.TabIndex = 170;
            this.label7.Text = "Driver Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(781, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 25);
            this.label8.TabIndex = 169;
            this.label8.Text = "Truck No :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(781, 415);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 25);
            this.label9.TabIndex = 168;
            this.label9.Text = "Batch No :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(823, 378);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 25);
            this.label10.TabIndex = 167;
            this.label10.Text = "Date :";
            // 
            // txtChallanNo
            // 
            this.txtChallanNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtChallanNo.Location = new System.Drawing.Point(213, 178);
            this.txtChallanNo.Name = "txtChallanNo";
            this.txtChallanNo.Size = new System.Drawing.Size(409, 30);
            this.txtChallanNo.TabIndex = 176;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(70, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 25);
            this.label12.TabIndex = 175;
            this.label12.Text = "Challan No :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(121, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 25);
            this.label13.TabIndex = 177;
            this.label13.Text = "Client :";
            // 
            // cmbClientDetails
            // 
            this.cmbClientDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbClientDetails.FormattingEnabled = true;
            this.cmbClientDetails.Location = new System.Drawing.Point(213, 216);
            this.cmbClientDetails.Name = "cmbClientDetails";
            this.cmbClientDetails.Size = new System.Drawing.Size(409, 28);
            this.cmbClientDetails.TabIndex = 178;
            // 
            // txtQtyInBatch
            // 
            this.txtQtyInBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtQtyInBatch.Location = new System.Drawing.Point(901, 215);
            this.txtQtyInBatch.Name = "txtQtyInBatch";
            this.txtQtyInBatch.Size = new System.Drawing.Size(409, 30);
            this.txtQtyInBatch.TabIndex = 182;
            // 
            // txtTotalOrderQty
            // 
            this.txtTotalOrderQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTotalOrderQty.Location = new System.Drawing.Point(901, 178);
            this.txtTotalOrderQty.Name = "txtTotalOrderQty";
            this.txtTotalOrderQty.Size = new System.Drawing.Size(409, 30);
            this.txtTotalOrderQty.TabIndex = 181;
            this.txtTotalOrderQty.TextChanged += new System.EventHandler(this.txtTotalOrderQty_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(751, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 50);
            this.label14.TabIndex = 180;
            this.label14.Text = "Qty In Batch :\r\n(Set Cu.M)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(719, 179);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(175, 25);
            this.label15.TabIndex = 179;
            this.label15.Text = "Total Order Qty :";
            // 
            // txtRemainingQty
            // 
            this.txtRemainingQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRemainingQty.Location = new System.Drawing.Point(213, 252);
            this.txtRemainingQty.Name = "txtRemainingQty";
            this.txtRemainingQty.Size = new System.Drawing.Size(409, 30);
            this.txtRemainingQty.TabIndex = 184;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(36, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(166, 25);
            this.label16.TabIndex = 183;
            this.label16.Text = "Remaining Qty :";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 676);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(87, 17);
            this.lblVersion.TabIndex = 188;
            this.lblVersion.Text = "Version : 2";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 653);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 17);
            this.lblUserName.TabIndex = 187;
            this.lblUserName.Text = "UerName";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox1.Location = new System.Drawing.Point(5, 625);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1351, 10);
            this.pictureBox1.TabIndex = 186;
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
            this.btnLogout.TabIndex = 185;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::NilkanthApplication.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(1178, 535);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 42);
            this.btnSave.TabIndex = 189;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(901, 381);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(409, 22);
            this.dtDate.TabIndex = 190;
            // 
            // DeliveryChallan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1361, 711);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txtRemainingQty);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtQtyInBatch);
            this.Controls.Add(this.txtTotalOrderQty);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbClientDetails);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtChallanNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.txtTruckNo);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRecipeName);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.cmbBatchNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Name = "DeliveryChallan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryChallan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DeliveryChallan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.TextBox txtTruckNo;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChallanNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbClientDetails;
        private System.Windows.Forms.TextBox txtQtyInBatch;
        private System.Windows.Forms.TextBox txtTotalOrderQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRemainingQty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtDate;
    }
}
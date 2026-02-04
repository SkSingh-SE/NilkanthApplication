
namespace NilkanthApplication
{
    partial class Breakdown
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Breakdown));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.txtInchargeName = new System.Windows.Forms.TextBox();
            this.txtEngineerName = new System.Windows.Forms.TextBox();
            this.dtFaultStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtFaultStopDate = new System.Windows.Forms.DateTimePicker();
            this.btnAddFaultType = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddActualFault = new System.Windows.Forms.Button();
            this.btnAddWorkCout = new System.Windows.Forms.Button();
            this.toolTipFaultType = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipActualFault = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipWorkCarriedOut = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.chkLstFaultType = new System.Windows.Forms.CheckedListBox();
            this.chkLstActualFault = new System.Windows.Forms.CheckedListBox();
            this.chkLstWorkCarriedOut = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(345, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model No :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(349, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Serial No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(287, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fault Start Date :";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(544, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 20);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
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
            this.btnCancel.Location = new System.Drawing.Point(280, 656);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 34);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(630, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 29);
            this.label6.TabIndex = 37;
            this.label6.Text = "Fault Stop Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(292, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 29);
            this.label7.TabIndex = 39;
            this.label7.Text = "Incharge Name :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 646);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(93, 20);
            this.lblUserName.TabIndex = 49;
            this.lblUserName.Text = "UserName";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(94, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 69);
            this.label11.TabIndex = 94;
            this.label11.Text = "Breakdown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(290, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 29);
            this.label1.TabIndex = 95;
            this.label1.Text = "Engineer Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(11, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 58);
            this.label5.TabIndex = 96;
            this.label5.Text = "Fault \r\nType :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(445, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 58);
            this.label8.TabIndex = 97;
            this.label8.Text = "Actual\r\nFault :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(893, 340);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 87);
            this.label9.TabIndex = 98;
            this.label9.Text = "Work\r\nCarried\r\nOut :";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelNo.Location = new System.Drawing.Point(489, 93);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(457, 35);
            this.txtModelNo.TabIndex = 100;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(489, 135);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(457, 35);
            this.txtSerialNo.TabIndex = 101;
            // 
            // txtInchargeName
            // 
            this.txtInchargeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInchargeName.Location = new System.Drawing.Point(489, 221);
            this.txtInchargeName.Name = "txtInchargeName";
            this.txtInchargeName.Size = new System.Drawing.Size(457, 35);
            this.txtInchargeName.TabIndex = 102;
            // 
            // txtEngineerName
            // 
            this.txtEngineerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEngineerName.Location = new System.Drawing.Point(489, 265);
            this.txtEngineerName.Name = "txtEngineerName";
            this.txtEngineerName.Size = new System.Drawing.Size(457, 35);
            this.txtEngineerName.TabIndex = 103;
            // 
            // dtFaultStartDate
            // 
            this.dtFaultStartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFaultStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFaultStartDate.Location = new System.Drawing.Point(489, 178);
            this.dtFaultStartDate.Name = "dtFaultStartDate";
            this.dtFaultStartDate.Size = new System.Drawing.Size(135, 35);
            this.dtFaultStartDate.TabIndex = 104;
            // 
            // dtFaultStopDate
            // 
            this.dtFaultStopDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFaultStopDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFaultStopDate.Location = new System.Drawing.Point(811, 178);
            this.dtFaultStopDate.Name = "dtFaultStopDate";
            this.dtFaultStopDate.Size = new System.Drawing.Size(135, 35);
            this.dtFaultStopDate.TabIndex = 105;
            // 
            // btnAddFaultType
            // 
            this.btnAddFaultType.CausesValidation = false;
            this.btnAddFaultType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFaultType.FlatAppearance.BorderSize = 0;
            this.btnAddFaultType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddFaultType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddFaultType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFaultType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFaultType.Image = global::NilkanthApplication.Properties.Resources.add_option_icon_1;
            this.btnAddFaultType.Location = new System.Drawing.Point(397, 334);
            this.btnAddFaultType.Name = "btnAddFaultType";
            this.btnAddFaultType.Size = new System.Drawing.Size(30, 30);
            this.btnAddFaultType.TabIndex = 106;
            this.btnAddFaultType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipFaultType.SetToolTip(this.btnAddFaultType, "Add Fault Type");
            this.btnAddFaultType.UseVisualStyleBackColor = true;
            this.btnAddFaultType.Click += new System.EventHandler(this.btnAddFaultType_Click);
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
            this.btnLogout.Location = new System.Drawing.Point(1270, 629);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(81, 64);
            this.btnLogout.TabIndex = 50;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox1.Location = new System.Drawing.Point(12, 616);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1344, 10);
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
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
            this.btnBack.Location = new System.Drawing.Point(1205, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(144, 64);
            this.btnBack.TabIndex = 45;
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
            this.btnHome.Location = new System.Drawing.Point(12, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(83, 61);
            this.btnHome.TabIndex = 46;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::NilkanthApplication.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(1224, 568);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddActualFault
            // 
            this.btnAddActualFault.CausesValidation = false;
            this.btnAddActualFault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddActualFault.FlatAppearance.BorderSize = 0;
            this.btnAddActualFault.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddActualFault.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddActualFault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddActualFault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddActualFault.Image = global::NilkanthApplication.Properties.Resources.add_option_icon_1;
            this.btnAddActualFault.Location = new System.Drawing.Point(839, 334);
            this.btnAddActualFault.Name = "btnAddActualFault";
            this.btnAddActualFault.Size = new System.Drawing.Size(30, 30);
            this.btnAddActualFault.TabIndex = 107;
            this.btnAddActualFault.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipActualFault.SetToolTip(this.btnAddActualFault, "Add Actual Fault");
            this.btnAddActualFault.UseVisualStyleBackColor = true;
            this.btnAddActualFault.Click += new System.EventHandler(this.btnAddActualFault_Click);
            // 
            // btnAddWorkCout
            // 
            this.btnAddWorkCout.CausesValidation = false;
            this.btnAddWorkCout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddWorkCout.FlatAppearance.BorderSize = 0;
            this.btnAddWorkCout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAddWorkCout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddWorkCout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWorkCout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWorkCout.Image = global::NilkanthApplication.Properties.Resources.add_option_icon_1;
            this.btnAddWorkCout.Location = new System.Drawing.Point(1297, 335);
            this.btnAddWorkCout.Name = "btnAddWorkCout";
            this.btnAddWorkCout.Size = new System.Drawing.Size(30, 30);
            this.btnAddWorkCout.TabIndex = 108;
            this.btnAddWorkCout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipWorkCarriedOut.SetToolTip(this.btnAddWorkCout, "Add Work Carried Out");
            this.btnAddWorkCout.UseVisualStyleBackColor = true;
            this.btnAddWorkCout.Click += new System.EventHandler(this.btnAddWorkCout_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 668);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 20);
            this.label10.TabIndex = 109;
            this.label10.Text = "Version : 2";
            // 
            // chkLstFaultType
            // 
            this.chkLstFaultType.CheckOnClick = true;
            this.chkLstFaultType.FormattingEnabled = true;
            this.chkLstFaultType.Location = new System.Drawing.Point(82, 335);
            this.chkLstFaultType.Name = "chkLstFaultType";
            this.chkLstFaultType.Size = new System.Drawing.Size(309, 96);
            this.chkLstFaultType.TabIndex = 110;
            // 
            // chkLstActualFault
            // 
            this.chkLstActualFault.CheckOnClick = true;
            this.chkLstActualFault.FormattingEnabled = true;
            this.chkLstActualFault.Location = new System.Drawing.Point(524, 335);
            this.chkLstActualFault.Name = "chkLstActualFault";
            this.chkLstActualFault.Size = new System.Drawing.Size(309, 96);
            this.chkLstActualFault.TabIndex = 111;
            // 
            // chkLstWorkCarriedOut
            // 
            this.chkLstWorkCarriedOut.CheckOnClick = true;
            this.chkLstWorkCarriedOut.FormattingEnabled = true;
            this.chkLstWorkCarriedOut.Location = new System.Drawing.Point(982, 335);
            this.chkLstWorkCarriedOut.Name = "chkLstWorkCarriedOut";
            this.chkLstWorkCarriedOut.Size = new System.Drawing.Size(309, 96);
            this.chkLstWorkCarriedOut.TabIndex = 112;
            // 
            // Breakdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1361, 700);
            this.Controls.Add(this.chkLstWorkCarriedOut);
            this.Controls.Add(this.chkLstActualFault);
            this.Controls.Add(this.chkLstFaultType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAddWorkCout);
            this.Controls.Add(this.btnAddActualFault);
            this.Controls.Add(this.btnAddFaultType);
            this.Controls.Add(this.dtFaultStopDate);
            this.Controls.Add(this.dtFaultStartDate);
            this.Controls.Add(this.txtEngineerName);
            this.Controls.Add(this.txtInchargeName);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Breakdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Right Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Breakdown_FormClosing);
            this.Load += new System.EventHandler(this.Breakdown_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.TextBox txtInchargeName;
        private System.Windows.Forms.TextBox txtEngineerName;
        private System.Windows.Forms.DateTimePicker dtFaultStartDate;
        private System.Windows.Forms.DateTimePicker dtFaultStopDate;
        private System.Windows.Forms.Button btnAddFaultType;
        private System.Windows.Forms.Button btnAddActualFault;
        private System.Windows.Forms.Button btnAddWorkCout;
        private System.Windows.Forms.ToolTip toolTipFaultType;
        private System.Windows.Forms.ToolTip toolTipActualFault;
        private System.Windows.Forms.ToolTip toolTipWorkCarriedOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox chkLstFaultType;
        private System.Windows.Forms.CheckedListBox chkLstActualFault;
        private System.Windows.Forms.CheckedListBox chkLstWorkCarriedOut;
    }
}
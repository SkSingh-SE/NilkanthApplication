
using System.Drawing;
using System.Windows.Forms;

namespace NilkanthApplication
{
    partial class CompanyMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyMaster));
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.labelModelNumber = new System.Windows.Forms.Label();
            this.txtModelNumber = new System.Windows.Forms.TextBox();
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.labelBin1Label = new System.Windows.Forms.Label();
            this.txtBin1Label = new System.Windows.Forms.TextBox();
            this.labelBin2Label = new System.Windows.Forms.Label();
            this.txtBin2Label = new System.Windows.Forms.TextBox();
            this.labelBin3Label = new System.Windows.Forms.Label();
            this.txtBin3Label = new System.Windows.Forms.TextBox();
            this.labelBin4Label = new System.Windows.Forms.Label();
            this.txtBin4Label = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.labelCementLabel = new System.Windows.Forms.Label();
            this.txtCementLabel = new System.Windows.Forms.TextBox();
            this.labelFlyashLabel = new System.Windows.Forms.Label();
            this.txtFlyashLabel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelGGBSLabel = new System.Windows.Forms.Label();
            this.txtGGBSLabel = new System.Windows.Forms.TextBox();
            this.labelSelicaLabel = new System.Windows.Forms.Label();
            this.txtSilicaLabel = new System.Windows.Forms.TextBox();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.labelApiUrl = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.labelApiKey = new System.Windows.Forms.Label();
            this.chkShowActCUMInTrip = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.labelField1Label = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelField2Label = new System.Windows.Forms.Label();
            this.txtField1Label = new System.Windows.Forms.TextBox();
            this.txtField2Label = new System.Windows.Forms.TextBox();
            this.txtField2Value = new System.Windows.Forms.TextBox();
            this.txtField1Value = new System.Windows.Forms.TextBox();
            this.btnPartyDetails = new System.Windows.Forms.Button();
            this.chkShowWhatsapp = new System.Windows.Forms.CheckBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkShowVarPInKg = new System.Windows.Forms.CheckBox();
            this.chkShowHeader = new System.Windows.Forms.CheckBox();
            this.labelTripReportFlag = new System.Windows.Forms.Label();
            this.textPanNo = new System.Windows.Forms.TextBox();
            this.labelPanNo = new System.Windows.Forms.Label();
            this.textMobileNo = new System.Windows.Forms.TextBox();
            this.labelMobileNo = new System.Windows.Forms.Label();
            this.labelGstNo = new System.Windows.Forms.Label();
            this.textGstNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelCompanyName.Location = new System.Drawing.Point(244, 102);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(179, 25);
            this.labelCompanyName.TabIndex = 1;
            this.labelCompanyName.Text = "Company Name :";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCompanyName.Location = new System.Drawing.Point(431, 95);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(604, 30);
            this.txtCompanyName.TabIndex = 0;
            // 
            // labelModelNumber
            // 
            this.labelModelNumber.AutoSize = true;
            this.labelModelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelModelNumber.Location = new System.Drawing.Point(258, 127);
            this.labelModelNumber.Name = "labelModelNumber";
            this.labelModelNumber.Size = new System.Drawing.Size(165, 25);
            this.labelModelNumber.TabIndex = 3;
            this.labelModelNumber.Text = "Model Number :";
            // 
            // txtModelNumber
            // 
            this.txtModelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtModelNumber.Location = new System.Drawing.Point(431, 125);
            this.txtModelNumber.Name = "txtModelNumber";
            this.txtModelNumber.Size = new System.Drawing.Size(604, 30);
            this.txtModelNumber.TabIndex = 1;
            this.txtModelNumber.DoubleClick += new System.EventHandler(this.txtModelNumber_DoubleClick);
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.AutoSize = true;
            this.labelSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSerialNumber.Location = new System.Drawing.Point(261, 157);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(162, 25);
            this.labelSerialNumber.TabIndex = 5;
            this.labelSerialNumber.Text = "Serial Number :";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSerialNumber.Location = new System.Drawing.Point(431, 155);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(604, 30);
            this.txtSerialNumber.TabIndex = 2;
            this.txtSerialNumber.DoubleClick += new System.EventHandler(this.txtSerialNumber_DoubleClick);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelAddress.Location = new System.Drawing.Point(316, 187);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(105, 25);
            this.labelAddress.TabIndex = 7;
            this.labelAddress.Text = "Address :";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rtbDescription.Location = new System.Drawing.Point(431, 185);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(604, 56);
            this.rtbDescription.TabIndex = 3;
            this.rtbDescription.Text = "";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(950, 34);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 17);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "0";
            this.lblId.Visible = false;
            // 
            // labelBin1Label
            // 
            this.labelBin1Label.AutoSize = true;
            this.labelBin1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelBin1Label.Location = new System.Drawing.Point(295, 409);
            this.labelBin1Label.Name = "labelBin1Label";
            this.labelBin1Label.Size = new System.Drawing.Size(127, 25);
            this.labelBin1Label.TabIndex = 37;
            this.labelBin1Label.Text = "Bin1 Label :";
            // 
            // txtBin1Label
            // 
            this.txtBin1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBin1Label.Location = new System.Drawing.Point(432, 407);
            this.txtBin1Label.Name = "txtBin1Label";
            this.txtBin1Label.Size = new System.Drawing.Size(604, 30);
            this.txtBin1Label.TabIndex = 38;
            // 
            // labelBin2Label
            // 
            this.labelBin2Label.AutoSize = true;
            this.labelBin2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelBin2Label.Location = new System.Drawing.Point(295, 438);
            this.labelBin2Label.Name = "labelBin2Label";
            this.labelBin2Label.Size = new System.Drawing.Size(127, 25);
            this.labelBin2Label.TabIndex = 39;
            this.labelBin2Label.Text = "Bin2 Label :";
            // 
            // txtBin2Label
            // 
            this.txtBin2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBin2Label.Location = new System.Drawing.Point(432, 436);
            this.txtBin2Label.Name = "txtBin2Label";
            this.txtBin2Label.Size = new System.Drawing.Size(604, 30);
            this.txtBin2Label.TabIndex = 40;
            // 
            // labelBin3Label
            // 
            this.labelBin3Label.AutoSize = true;
            this.labelBin3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelBin3Label.Location = new System.Drawing.Point(295, 466);
            this.labelBin3Label.Name = "labelBin3Label";
            this.labelBin3Label.Size = new System.Drawing.Size(127, 25);
            this.labelBin3Label.TabIndex = 41;
            this.labelBin3Label.Text = "Bin3 Label :";
            // 
            // txtBin3Label
            // 
            this.txtBin3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBin3Label.Location = new System.Drawing.Point(432, 464);
            this.txtBin3Label.Name = "txtBin3Label";
            this.txtBin3Label.Size = new System.Drawing.Size(604, 30);
            this.txtBin3Label.TabIndex = 42;
            // 
            // labelBin4Label
            // 
            this.labelBin4Label.AutoSize = true;
            this.labelBin4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelBin4Label.Location = new System.Drawing.Point(295, 495);
            this.labelBin4Label.Name = "labelBin4Label";
            this.labelBin4Label.Size = new System.Drawing.Size(127, 25);
            this.labelBin4Label.TabIndex = 43;
            this.labelBin4Label.Text = "Bin4 Label :";
            // 
            // txtBin4Label
            // 
            this.txtBin4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBin4Label.Location = new System.Drawing.Point(432, 493);
            this.txtBin4Label.Name = "txtBin4Label";
            this.txtBin4Label.Size = new System.Drawing.Size(604, 30);
            this.txtBin4Label.TabIndex = 44;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(9, 910);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 17);
            this.lblUserName.TabIndex = 49;
            this.lblUserName.Text = "UserName";
            // 
            // labelCementLabel
            // 
            this.labelCementLabel.AutoSize = true;
            this.labelCementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelCementLabel.Location = new System.Drawing.Point(263, 525);
            this.labelCementLabel.Name = "labelCementLabel";
            this.labelCementLabel.Size = new System.Drawing.Size(159, 25);
            this.labelCementLabel.TabIndex = 51;
            this.labelCementLabel.Text = "Cement Label :";
            // 
            // txtCementLabel
            // 
            this.txtCementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCementLabel.Location = new System.Drawing.Point(432, 523);
            this.txtCementLabel.Name = "txtCementLabel";
            this.txtCementLabel.Size = new System.Drawing.Size(604, 30);
            this.txtCementLabel.TabIndex = 52;
            // 
            // labelFlyashLabel
            // 
            this.labelFlyashLabel.AutoSize = true;
            this.labelFlyashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelFlyashLabel.Location = new System.Drawing.Point(274, 557);
            this.labelFlyashLabel.Name = "labelFlyashLabel";
            this.labelFlyashLabel.Size = new System.Drawing.Size(148, 25);
            this.labelFlyashLabel.TabIndex = 53;
            this.labelFlyashLabel.Text = "Flyash Label :";
            // 
            // txtFlyashLabel
            // 
            this.txtFlyashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFlyashLabel.Location = new System.Drawing.Point(432, 553);
            this.txtFlyashLabel.Name = "txtFlyashLabel";
            this.txtFlyashLabel.Size = new System.Drawing.Size(604, 30);
            this.txtFlyashLabel.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(94, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(421, 58);
            this.label11.TabIndex = 94;
            this.label11.Text = "Company Details";
            // 
            // labelGGBSLabel
            // 
            this.labelGGBSLabel.AutoSize = true;
            this.labelGGBSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelGGBSLabel.Location = new System.Drawing.Point(277, 618);
            this.labelGGBSLabel.Name = "labelGGBSLabel";
            this.labelGGBSLabel.Size = new System.Drawing.Size(145, 25);
            this.labelGGBSLabel.TabIndex = 95;
            this.labelGGBSLabel.Text = "GGBS Label :";
            // 
            // txtGGBSLabel
            // 
            this.txtGGBSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtGGBSLabel.Location = new System.Drawing.Point(432, 613);
            this.txtGGBSLabel.Name = "txtGGBSLabel";
            this.txtGGBSLabel.Size = new System.Drawing.Size(604, 30);
            this.txtGGBSLabel.TabIndex = 96;
            // 
            // labelSelicaLabel
            // 
            this.labelSelicaLabel.AutoSize = true;
            this.labelSelicaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSelicaLabel.Location = new System.Drawing.Point(285, 588);
            this.labelSelicaLabel.Name = "labelSelicaLabel";
            this.labelSelicaLabel.Size = new System.Drawing.Size(137, 25);
            this.labelSelicaLabel.TabIndex = 97;
            this.labelSelicaLabel.Text = "Silica Label :";
            // 
            // txtSilicaLabel
            // 
            this.txtSilicaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSilicaLabel.Location = new System.Drawing.Point(432, 583);
            this.txtSilicaLabel.Name = "txtSilicaLabel";
            this.txtSilicaLabel.Size = new System.Drawing.Size(604, 30);
            this.txtSilicaLabel.TabIndex = 98;
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtApiUrl.Location = new System.Drawing.Point(431, 377);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(604, 30);
            this.txtApiUrl.TabIndex = 102;
            this.txtApiUrl.DoubleClick += new System.EventHandler(this.txtApiUrl_DoubleClick);
            // 
            // labelApiUrl
            // 
            this.labelApiUrl.AutoSize = true;
            this.labelApiUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelApiUrl.Location = new System.Drawing.Point(330, 379);
            this.labelApiUrl.Name = "labelApiUrl";
            this.labelApiUrl.Size = new System.Drawing.Size(90, 25);
            this.labelApiUrl.TabIndex = 101;
            this.labelApiUrl.Text = "Api Url :";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtApiKey.Location = new System.Drawing.Point(431, 345);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(604, 30);
            this.txtApiKey.TabIndex = 100;
            this.txtApiKey.DoubleClick += new System.EventHandler(this.txtApiKey_DoubleClick);
            // 
            // labelApiKey
            // 
            this.labelApiKey.AutoSize = true;
            this.labelApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelApiKey.Location = new System.Drawing.Point(320, 347);
            this.labelApiKey.Name = "labelApiKey";
            this.labelApiKey.Size = new System.Drawing.Size(101, 25);
            this.labelApiKey.TabIndex = 99;
            this.labelApiKey.Text = "Api Key :";
            // 
            // chkShowActCUMInTrip
            // 
            this.chkShowActCUMInTrip.AutoSize = true;
            this.chkShowActCUMInTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowActCUMInTrip.Location = new System.Drawing.Point(432, 652);
            this.chkShowActCUMInTrip.Name = "chkShowActCUMInTrip";
            this.chkShowActCUMInTrip.Size = new System.Drawing.Size(139, 21);
            this.chkShowActCUMInTrip.TabIndex = 103;
            this.chkShowActCUMInTrip.Text = "Show Act CU.M\r\n";
            this.chkShowActCUMInTrip.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 931);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 17);
            this.label16.TabIndex = 104;
            this.label16.Text = "Version : 2";
            // 
            // labelField1Label
            // 
            this.labelField1Label.AutoSize = true;
            this.labelField1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelField1Label.Location = new System.Drawing.Point(277, 713);
            this.labelField1Label.Name = "labelField1Label";
            this.labelField1Label.Size = new System.Drawing.Size(143, 25);
            this.labelField1Label.TabIndex = 105;
            this.labelField1Label.Text = "Field1 Label :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(666, 711);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(146, 25);
            this.label18.TabIndex = 106;
            this.label18.Text = "Field1 Value :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(665, 746);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(146, 25);
            this.label19.TabIndex = 108;
            this.label19.Text = "Field2 Value :";
            // 
            // labelField2Label
            // 
            this.labelField2Label.AutoSize = true;
            this.labelField2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelField2Label.Location = new System.Drawing.Point(276, 748);
            this.labelField2Label.Name = "labelField2Label";
            this.labelField2Label.Size = new System.Drawing.Size(143, 25);
            this.labelField2Label.TabIndex = 107;
            this.labelField2Label.Text = "Field2 Label :";
            // 
            // txtField1Label
            // 
            this.txtField1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtField1Label.Location = new System.Drawing.Point(431, 708);
            this.txtField1Label.Name = "txtField1Label";
            this.txtField1Label.Size = new System.Drawing.Size(229, 30);
            this.txtField1Label.TabIndex = 109;
            // 
            // txtField2Label
            // 
            this.txtField2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtField2Label.Location = new System.Drawing.Point(430, 743);
            this.txtField2Label.Name = "txtField2Label";
            this.txtField2Label.Size = new System.Drawing.Size(229, 30);
            this.txtField2Label.TabIndex = 110;
            // 
            // txtField2Value
            // 
            this.txtField2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtField2Value.Location = new System.Drawing.Point(795, 743);
            this.txtField2Value.Name = "txtField2Value";
            this.txtField2Value.Size = new System.Drawing.Size(240, 30);
            this.txtField2Value.TabIndex = 112;
            // 
            // txtField1Value
            // 
            this.txtField1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtField1Value.Location = new System.Drawing.Point(796, 708);
            this.txtField1Value.Name = "txtField1Value";
            this.txtField1Value.Size = new System.Drawing.Size(239, 30);
            this.txtField1Value.TabIndex = 111;
            // 
            // btnPartyDetails
            // 
            this.btnPartyDetails.BackColor = System.Drawing.Color.Blue;
            this.btnPartyDetails.ForeColor = System.Drawing.Color.White;
            this.btnPartyDetails.Location = new System.Drawing.Point(521, 15);
            this.btnPartyDetails.Name = "btnPartyDetails";
            this.btnPartyDetails.Size = new System.Drawing.Size(214, 58);
            this.btnPartyDetails.TabIndex = 113;
            this.btnPartyDetails.Text = "Clients";
            this.btnPartyDetails.UseVisualStyleBackColor = false;
            this.btnPartyDetails.Click += new System.EventHandler(this.btnPartyDetails_Click);
            // 
            // chkShowWhatsapp
            // 
            this.chkShowWhatsapp.AutoSize = true;
            this.chkShowWhatsapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowWhatsapp.Location = new System.Drawing.Point(795, 652);
            this.chkShowWhatsapp.Name = "chkShowWhatsapp";
            this.chkShowWhatsapp.Size = new System.Drawing.Size(145, 21);
            this.chkShowWhatsapp.TabIndex = 114;
            this.chkShowWhatsapp.Text = "Show Whatsapp";
            this.chkShowWhatsapp.UseVisualStyleBackColor = true;
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
            this.btnLogout.Location = new System.Drawing.Point(1266, 899);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(81, 64);
            this.btnLogout.TabIndex = 50;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NilkanthApplication.Properties.Resources.Line;
            this.pictureBox1.Location = new System.Drawing.Point(9, 870);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1348, 10);
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
            this.btnBack.Location = new System.Drawing.Point(1116, 7);
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
            this.btnSave.Location = new System.Drawing.Point(904, 789);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkShowVarPInKg
            // 
            this.chkShowVarPInKg.AutoSize = true;
            this.chkShowVarPInKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowVarPInKg.Location = new System.Drawing.Point(432, 679);
            this.chkShowVarPInKg.Name = "chkShowVarPInKg";
            this.chkShowVarPInKg.Size = new System.Drawing.Size(158, 21);
            this.chkShowVarPInKg.TabIndex = 115;
            this.chkShowVarPInKg.Text = "Show Var % In Kg";
            this.chkShowVarPInKg.UseVisualStyleBackColor = true;
            // 
            // chkShowHeader
            // 
            this.chkShowHeader.AutoSize = true;
            this.chkShowHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.chkShowHeader.Location = new System.Drawing.Point(795, 679);
            this.chkShowHeader.Name = "chkShowHeader";
            this.chkShowHeader.Size = new System.Drawing.Size(126, 21);
            this.chkShowHeader.TabIndex = 116;
            this.chkShowHeader.Text = "Show Header";
            this.chkShowHeader.UseVisualStyleBackColor = true;
            // 
            // labelTripReportFlag
            // 
            this.labelTripReportFlag.AutoSize = true;
            this.labelTripReportFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelTripReportFlag.Location = new System.Drawing.Point(242, 648);
            this.labelTripReportFlag.Name = "labelTripReportFlag";
            this.labelTripReportFlag.Size = new System.Drawing.Size(180, 25);
            this.labelTripReportFlag.TabIndex = 117;
            this.labelTripReportFlag.Text = "Trip Report Flag :";
            // 
            // textPanNo
            // 
            this.textPanNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textPanNo.Location = new System.Drawing.Point(430, 274);
            this.textPanNo.Name = "textPanNo";
            this.textPanNo.Size = new System.Drawing.Size(604, 30);
            this.textPanNo.TabIndex = 121;
            // 
            // labelPanNo
            // 
            this.labelPanNo.AutoSize = true;
            this.labelPanNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelPanNo.Location = new System.Drawing.Point(319, 276);
            this.labelPanNo.Name = "labelPanNo";
            this.labelPanNo.Size = new System.Drawing.Size(102, 25);
            this.labelPanNo.TabIndex = 120;
            this.labelPanNo.Text = "PAN No :";
            // 
            // textMobileNo
            // 
            this.textMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textMobileNo.Location = new System.Drawing.Point(430, 309);
            this.textMobileNo.Name = "textMobileNo";
            this.textMobileNo.Size = new System.Drawing.Size(604, 30);
            this.textMobileNo.TabIndex = 123;
            // 
            // labelMobileNo
            // 
            this.labelMobileNo.AutoSize = true;
            this.labelMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelMobileNo.Location = new System.Drawing.Point(301, 311);
            this.labelMobileNo.Name = "labelMobileNo";
            this.labelMobileNo.Size = new System.Drawing.Size(122, 25);
            this.labelMobileNo.TabIndex = 122;
            this.labelMobileNo.Text = "Mobile No :";
            // 
            // labelGstNo
            // 
            this.labelGstNo.AutoSize = true;
            this.labelGstNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelGstNo.Location = new System.Drawing.Point(319, 244);
            this.labelGstNo.Name = "labelGstNo";
            this.labelGstNo.Size = new System.Drawing.Size(103, 25);
            this.labelGstNo.TabIndex = 118;
            this.labelGstNo.Text = "GST No :";
            // 
            // textGstNo
            // 
            this.textGstNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textGstNo.Location = new System.Drawing.Point(430, 242);
            this.textGstNo.Name = "textGstNo";
            this.textGstNo.Size = new System.Drawing.Size(604, 30);
            this.textGstNo.TabIndex = 119;
            // 
            // CompanyMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1380, 960);
            this.Controls.Add(this.textMobileNo);
            this.Controls.Add(this.labelMobileNo);
            this.Controls.Add(this.textPanNo);
            this.Controls.Add(this.labelPanNo);
            this.Controls.Add(this.textGstNo);
            this.Controls.Add(this.labelGstNo);
            this.Controls.Add(this.labelTripReportFlag);
            this.Controls.Add(this.chkShowHeader);
            this.Controls.Add(this.chkShowVarPInKg);
            this.Controls.Add(this.chkShowWhatsapp);
            this.Controls.Add(this.btnPartyDetails);
            this.Controls.Add(this.txtField2Value);
            this.Controls.Add(this.txtField1Value);
            this.Controls.Add(this.txtField2Label);
            this.Controls.Add(this.txtField1Label);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labelField2Label);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.labelField1Label);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chkShowActCUMInTrip);
            this.Controls.Add(this.txtApiUrl);
            this.Controls.Add(this.labelApiUrl);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.labelApiKey);
            this.Controls.Add(this.txtSilicaLabel);
            this.Controls.Add(this.labelSelicaLabel);
            this.Controls.Add(this.txtGGBSLabel);
            this.Controls.Add(this.labelGGBSLabel);
            this.Controls.Add(this.txtFlyashLabel);
            this.Controls.Add(this.labelFlyashLabel);
            this.Controls.Add(this.txtCementLabel);
            this.Controls.Add(this.labelCementLabel);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.txtBin4Label);
            this.Controls.Add(this.labelBin4Label);
            this.Controls.Add(this.txtBin3Label);
            this.Controls.Add(this.labelBin3Label);
            this.Controls.Add(this.txtBin2Label);
            this.Controls.Add(this.labelBin2Label);
            this.Controls.Add(this.txtBin1Label);
            this.Controls.Add(this.labelBin1Label);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.labelSerialNumber);
            this.Controls.Add(this.txtModelNumber);
            this.Controls.Add(this.labelModelNumber);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.labelCompanyName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompanyMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompanyMaster_FormClosing);
            this.Load += new System.EventHandler(this.CompanyMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyMaster));

        //    this.labelCompanyName = new System.Windows.Forms.Label();
        //    this.txtCompanyName = new System.Windows.Forms.TextBox();
        //    this.labelModelNumber = new System.Windows.Forms.Label();
        //    this.txtModelNumber = new System.Windows.Forms.TextBox();
        //    this.labelSerialNumber = new System.Windows.Forms.Label();
        //    this.txtSerialNumber = new System.Windows.Forms.TextBox();
        //    this.labelAddress = new System.Windows.Forms.Label();
        //    this.rtbDescription = new System.Windows.Forms.RichTextBox();
        //    this.lblId = new System.Windows.Forms.Label();
        //    this.labelBin1Label = new System.Windows.Forms.Label();
        //    this.txtBin1Label = new System.Windows.Forms.TextBox();
        //    this.labelBin2Label = new System.Windows.Forms.Label();
        //    this.txtBin2Label = new System.Windows.Forms.TextBox();
        //    this.labelBin3Label = new System.Windows.Forms.Label();
        //    this.txtBin3Label = new System.Windows.Forms.TextBox();
        //    this.labelBin4Label = new System.Windows.Forms.Label();
        //    this.txtBin4Label = new System.Windows.Forms.TextBox();
        //    this.lblUserName = new Label { Text = "UserName", Location = new Point(10, 20), AutoSize = true };
        //    this.labelCementLabel = new System.Windows.Forms.Label();
        //    this.txtCementLabel = new System.Windows.Forms.TextBox();
        //    this.labelFlyashLabel = new System.Windows.Forms.Label();
        //    this.txtFlyashLabel = new System.Windows.Forms.TextBox();
        //    this.label11 = new Label
        //    {
        //        Text = "Company Details",
        //        Font = new Font("Microsoft Sans Serif", 28, FontStyle.Bold),
        //        AutoSize = true,
        //        Location = new Point(110, 18)
        //    };
        //    this.labelGGBSLabel = new System.Windows.Forms.Label();
        //    this.txtGGBSLabel = new System.Windows.Forms.TextBox();
        //    this.labelSelicaLabel = new System.Windows.Forms.Label();
        //    this.txtSilicaLabel = new System.Windows.Forms.TextBox();
        //    this.txtApiUrl = new System.Windows.Forms.TextBox();
        //    this.labelApiUrl = new System.Windows.Forms.Label();
        //    this.txtApiKey = new System.Windows.Forms.TextBox();
        //    this.labelApiKey = new System.Windows.Forms.Label();
        //    this.chkShowActCUMInTrip = new System.Windows.Forms.CheckBox();
        //    this.label16 = new Label { Text = "Version : 2", Location = new Point(10, 40), AutoSize = true };
        //    this.labelField1Label = new System.Windows.Forms.Label();
        //    this.label18 = new System.Windows.Forms.Label();
        //    this.label19 = new System.Windows.Forms.Label();
        //    this.labelField2Label = new System.Windows.Forms.Label();
        //    this.txtField1Label = new System.Windows.Forms.TextBox();
        //    this.txtField2Label = new System.Windows.Forms.TextBox();
        //    this.txtField2Value = new System.Windows.Forms.TextBox();
        //    this.txtField1Value = new System.Windows.Forms.TextBox();
        //    this.btnPartyDetails = new Button
        //    {
        //        Text = "Clients",
        //        BackColor = Color.Blue,
        //        ForeColor = Color.White,
        //        Location = new Point(520, 15),
        //        Size = new Size(180, 50)
        //    };
        //    this.btnLogout = new Button
        //    {
        //        Image = Properties.Resources.Logout,
        //        FlatStyle = FlatStyle.Flat,
        //        Size = new Size(80, 60),
        //        Location = new Point(1250, 10)
        //    };
        //    this.pictureBox1 = new PictureBox
        //    {
        //        Image = Properties.Resources.Line,
        //        Dock = DockStyle.Top,
        //        Height = 10
        //    };
        //    this.btnBack = new Button
        //    {
        //        Text = "Back",
        //        Image = Properties.Resources.back,
        //        TextImageRelation = TextImageRelation.ImageBeforeText,
        //        Location = new Point(1200, 10),
        //        Size = new Size(140, 60)
        //    };
        //    this.btnHome = new Button
        //    {
        //        Image = Properties.Resources.Home,
        //        FlatStyle = FlatStyle.Flat,
        //        Location = new Point(12, 10),
        //        Size = new Size(80, 60)
        //    };
        //    this.btnSave = new Button
        //    {
        //        Image = Properties.Resources.Save,
        //        Width = 140,
        //        Height = 40,
        //        Margin = new Padding(10)
        //    };
        //    this.chkShowVarInKg = new CheckBox { Text = "Show Var % In Kg", AutoSize = true };
        //    this.chkShowHeader = new CheckBox { Text = "Show Header", AutoSize = true };
        //    this.chkShowWhatsapp = new CheckBox { Text = "Show Whatsapp", AutoSize = true };
        //    this.labelTripReportFlag = new Label { Text = "Trip Report Flag :", Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold) };
        //    this.textPanNo = new System.Windows.Forms.TextBox();
        //    this.labelPanNo = new System.Windows.Forms.Label();
        //    this.textMobileNo = new System.Windows.Forms.TextBox();
        //    this.labelMobileNo = new System.Windows.Forms.Label();
        //    this.labelGstNo = new System.Windows.Forms.Label();
        //    this.textGstNo = new System.Windows.Forms.TextBox();
        //    this.SuspendLayout();

        //    // ================= FORM =================
        //    this.Text = "Company Master";
        //    this.WindowState = FormWindowState.Maximized;
        //    this.BackColor = Color.White;
        //    this.Icon = (Icon)resources.GetObject("$this.Icon");
        //    this.AutoScaleMode = AutoScaleMode.Font;

        //    // ================= ROOT =================
        //    TableLayoutPanel root = new TableLayoutPanel
        //    {
        //        Dock = DockStyle.Fill,
        //        RowCount = 3,
        //        ColumnCount = 1
        //    };
        //    root.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
        //    root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        //    root.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
        //    this.Controls.Add(root);

        //    // ================= HEADER =================
        //    Panel header = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

          
        //    this.btnHome.FlatAppearance.BorderSize = 0;
        //    this.btnHome.Click += btnHome_Click;

        //    this.btnPartyDetails.Click += btnPartyDetails_Click;

        //    this.btnBack.Click += btnBack_Click;

        //    header.Controls.AddRange(new Control[] { this.btnHome, this.label11, this.btnPartyDetails, this.btnBack });
        //    root.Controls.Add(header, 0, 0);

        //    // ================= CONTENT =================
        //    Panel content = new Panel
        //    {
        //        Dock = DockStyle.Fill,
        //        AutoScroll = true,
        //        Padding = new Padding(40)
        //    };
        //    root.Controls.Add(content, 0, 1);

        //    TableLayoutPanel form = new TableLayoutPanel
        //    {
        //        Dock = DockStyle.Top,
        //        AutoSize = true,
        //        ColumnCount = 2
        //    };
        //    form.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220));
        //    form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        //    content.Controls.Add(form);

        //    void AddRow(string text, Control control)
        //    {
        //        Label lbl = new Label
        //        {
        //            Text = text,
        //            Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
        //            AutoSize = true,
        //            Margin = new Padding(3, 10, 3, 3)
        //        };
        //        control.Font = new Font("Microsoft Sans Serif", 12);
        //        control.Width = 600;

        //        form.Controls.Add(lbl);
        //        form.Controls.Add(control);
        //    }

        //    // ================= CONTROLS =================
        //    this.lblId = new Label { Text = "0", Visible = false };


        //    this.rtbDescription.Height = 60;



        //    this.chkShowActCUMInTrip.Text = "Show Act CU.M";
        //    this.chkShowActCUMInTrip.AutoSize = true;

        //    // ================= ADD ROWS =================
        //    AddRow("Company Name :", txtCompanyName);
        //    AddRow("Model Number :", txtModelNumber);
        //    AddRow("Serial Number :", txtSerialNumber);
        //    AddRow("Address :", rtbDescription);
        //    AddRow("GST No :", textGstNo);
        //    AddRow("PAN No :", textPanNo);
        //    AddRow("Mobile No :", textMobileNo);
        //    AddRow("API Key :", txtApiKey);
        //    AddRow("API Url :", txtApiUrl);

        //    AddRow("Bin1 Label :", txtBin1Label);
        //    AddRow("Bin2 Label :", txtBin2Label);
        //    AddRow("Bin3 Label :", txtBin3Label);
        //    AddRow("Bin4 Label :", txtBin4Label);

        //    AddRow("Cement Label :", txtCementLabel);
        //    AddRow("Flyash Label :", txtFlyashLabel);
        //    AddRow("Silica Label :", txtSilicaLabel);
        //    AddRow("GGBS Label :", txtGGBSLabel);

        //    AddRow("Field1 Label :", txtField1Label);
        //    AddRow("Field1 Value :", txtField1Value);
        //    AddRow("Field2 Label :", txtField2Label);
        //    AddRow("Field2 Value :", txtField2Value);

        //    form.Controls.Add(this.labelTripReportFlag);
        //    var flags = new FlowLayoutPanel { AutoSize = true };
        //    flags.Controls.AddRange(new Control[] {
        //                            this.chkShowActCUMInTrip,
        //                            this.chkShowVarInKg,
        //                            this.chkShowHeader,
        //                            this.chkShowWhatsapp
        //                        });
        //    form.Controls.Add(flags);

        //    this.btnSave.Click += btnSave_Click;

        //    form.Controls.Add(new Label());
        //    form.Controls.Add(btnSave);

        //    // ================= FOOTER =================
        //    Panel footer = new Panel { Dock = DockStyle.Fill };


        //    this.btnLogout.FlatAppearance.BorderSize = 0;
        //    this.btnLogout.Click += btnLogout_Click;

        //    footer.Controls.AddRange(new Control[] { this.pictureBox1, this.lblUserName, this.label16, this.btnLogout });
        //    root.Controls.Add(footer, 0, 2);

        //    // ================= EVENTS =================
        //    this.txtModelNumber.DoubleClick += txtModelNumber_DoubleClick;
        //    this.txtSerialNumber.DoubleClick += txtSerialNumber_DoubleClick;
        //    this.txtApiKey.DoubleClick += txtApiKey_DoubleClick;
        //    this.txtApiUrl.DoubleClick += txtApiUrl_DoubleClick;

        //    this.Load += CompanyMaster_Load;
        //    this.FormClosing += CompanyMaster_FormClosing;

        //    this.ResumeLayout(false);
        //}




        #endregion
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label labelModelNumber;
        private System.Windows.Forms.TextBox txtModelNumber;
        private System.Windows.Forms.Label labelSerialNumber;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label labelBin1Label;
        private System.Windows.Forms.TextBox txtBin1Label;
        private System.Windows.Forms.Label labelBin2Label;
        private System.Windows.Forms.TextBox txtBin2Label;
        private System.Windows.Forms.Label labelBin3Label;
        private System.Windows.Forms.TextBox txtBin3Label;
        private System.Windows.Forms.Label labelBin4Label;
        private System.Windows.Forms.TextBox txtBin4Label;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label labelCementLabel;
        private System.Windows.Forms.TextBox txtCementLabel;
        private System.Windows.Forms.Label labelFlyashLabel;
        private System.Windows.Forms.TextBox txtFlyashLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelGGBSLabel;
        private System.Windows.Forms.TextBox txtGGBSLabel;
        private System.Windows.Forms.Label labelSelicaLabel;
        private System.Windows.Forms.TextBox txtSilicaLabel;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.Label labelApiUrl;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label labelApiKey;
        private System.Windows.Forms.CheckBox chkShowActCUMInTrip;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelField1Label;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelField2Label;
        private System.Windows.Forms.TextBox txtField1Label;
        private System.Windows.Forms.TextBox txtField2Label;
        private System.Windows.Forms.TextBox txtField2Value;
        private System.Windows.Forms.TextBox txtField1Value;
        private System.Windows.Forms.Button btnPartyDetails;
        private System.Windows.Forms.CheckBox chkShowWhatsapp;
        private System.Windows.Forms.CheckBox chkShowVarPInKg;
        private System.Windows.Forms.CheckBox chkShowHeader;
        private System.Windows.Forms.Label labelTripReportFlag;
        private System.Windows.Forms.TextBox textPanNo;
        private System.Windows.Forms.Label labelPanNo;
        private System.Windows.Forms.TextBox textMobileNo;
        private System.Windows.Forms.Label labelMobileNo;
        private System.Windows.Forms.Label labelGstNo;
        private System.Windows.Forms.TextBox textGstNo;
    }
}
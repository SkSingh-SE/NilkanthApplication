using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class CompanyMaster : Form
    {
        string AddEditPAges, ViewPAge, DeletePage;
        string CompanyName, Location, PlantName;
        private bool isFormLoading = true;
        public CompanyMaster()
        {
            InitializeComponent();
        }

        public string textboxName = "";
        byte[] companyLogoBytes = null;

        public bool rdonlModelNo
        {
            get
            {
                return txtModelNumber.ReadOnly;
            }
            set
            {
                txtModelNumber.ReadOnly = value;
            }
        }

        public bool rdonlSerialNo
        {
            get
            {
                return txtSerialNumber.ReadOnly;
            }
            set
            {
                txtSerialNumber.ReadOnly = value;
            }
        }

        public bool rdonlApiKey
        {
            get
            {
                return txtApiKey.ReadOnly;
            }
            set
            {
                txtApiKey.ReadOnly = value;
            }
        }

        public bool rdonlApiUrl
        {
            get
            {
                return txtApiUrl.ReadOnly;
            }
            set
            {
                txtApiUrl.ReadOnly = value;
            }
        }

        public bool rdonCompanyName
        {
            get
            {
                return txtCompanyName.ReadOnly;
            }
            set
            {
                txtCompanyName.ReadOnly = value;
            }
        }

        public bool rdonLocation
        {
            get { return textLocation.ReadOnly; }
            set { textLocation.ReadOnly = value; }
        }

        public bool rdonPlantName
        {
            get { return textPlantName.ReadOnly; }
            set { textPlantName.ReadOnly = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ErrMsg = "";
                if (txtField1Label.Text != "" && txtField1Value.Text == "")
                    ErrMsg += "Field1 Value,";

                if (txtField2Label.Text != "" && txtField2Value.Text == "")
                    ErrMsg += "Field2 Value";
                else
                {
                    if (ErrMsg.Length > 0)
                        ErrMsg = ErrMsg.Substring(0, ErrMsg.Length - 1);
                }

                // GST Validation (Blank OR <= 15)
                if (!string.IsNullOrWhiteSpace(textGstNo.Text) && textGstNo.Text.Trim().Length > 15)
                {
                    MessageBox.Show("GST No should not exceed 15 characters.");
                    textGstNo.Focus();
                    return;
                }

                // PAN Validation (Blank OR <= 10)
                if (!string.IsNullOrWhiteSpace(textPanNo.Text) && textPanNo.Text.Trim().Length > 10)
                {
                    MessageBox.Show("PAN No should not exceed 10 characters.");
                    textPanNo.Focus();
                    return;
                }

                // Mobile Validation (Blank OR <= 14)
                if (!string.IsNullOrWhiteSpace(textMobileNo.Text) && textMobileNo.Text.Trim().Length > 14)
                {
                    MessageBox.Show("Mobile No should not exceed 14 characters.");
                    textMobileNo.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtReportFooDesc.Text) && txtReportFooDesc.Text.Trim().Length > 200)
                {
                    MessageBox.Show("Footer text should not exceed 200 characters.");
                    txtReportFooDesc.Focus();
                    return;
                }

                if (chkIsMobileAppSync.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
                    {
                        MessageBox.Show("Company Name should not blank.");
                        txtCompanyName.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textLocation.Text))
                    {
                        MessageBox.Show("Location should not blank.");
                        textLocation.Focus();
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textPlantName.Text))
                    {
                        MessageBox.Show("Plant Name should not blank.");
                        textPlantName.Focus();
                        return;
                    }
                }
                bool isUpdate = lblId.Text != "0";

                if (ErrMsg != "")
                    MessageBox.Show("Please Fill " + ErrMsg);
                else
                {
                    SQLHelper._objCmd = new SqlCommand();
                    SQLHelper._objCmd.Parameters.Clear();
                    SQLHelper._objCmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.ToString().Trim()); // Name to Company Name
                    SQLHelper._objCmd.Parameters.AddWithValue("@ModelNumber", txtModelNumber.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@SerialNumber", txtSerialNumber.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Address", rtbDescription.Text.ToString().Trim()); // Description to Address
                    SQLHelper._objCmd.Parameters.AddWithValue("@GstNo", textGstNo.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@PanNo", textPanNo.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@MobileNo", textMobileNo.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@ApiKey", txtApiKey.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@ApiUrl", txtApiUrl.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Label", txtBin1Label.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Label", txtBin2Label.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Label", txtBin3Label.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Label", txtBin4Label.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@CementLabel", txtCementLabel.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@FlyashLabel", txtFlyashLabel.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@SilicaLabel", txtSilicaLabel.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@GGBSLabel", txtGGBSLabel.Text.ToString().Trim().ToUpper());
                    SQLHelper._objCmd.Parameters.AddWithValue("@RptFooter", txtReportFooDesc.Text.ToString().Trim());

                    string Field1Label = txtField1Label.Text == null || txtField1Label.Text == "" ? "" : txtField1Label.Text.ToString().Trim().ToUpper();
                    string Field1Value = txtField1Value.Text == null || txtField1Value.Text == "" ? "" : txtField1Value.Text.ToString().Trim().ToUpper();
                    string Field2Label = txtField2Label.Text == null || txtField2Label.Text == "" ? "" : txtField2Label.Text.ToString().Trim().ToUpper();
                    string Field2Value = txtField2Value.Text == null || txtField2Value.Text == "" ? "" : txtField2Value.Text.ToString().Trim().ToUpper();

                    SQLHelper._objCmd.Parameters.AddWithValue("@Field1Label", Field1Label);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Field1Value", Field1Value);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Field2Label", Field2Label);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Field2Value", Field2Value);

                    // Ensure DBNull.Value is passed when there is no logo bytes.
                    var logoParam = SQLHelper._objCmd.Parameters.Add("@CompanyLogo", SqlDbType.VarBinary, -1);
                    logoParam.Value = companyLogoBytes ?? (object)DBNull.Value;

                    SQLHelper._objCmd.Parameters.AddWithValue("@Location", textLocation.Text.ToString().Trim());
                    SQLHelper._objCmd.Parameters.AddWithValue("@PlantName", textPlantName.Text.ToString().Trim());

                    if (chkShowActCUMInTrip.Checked == true)
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowActCUMInTrip", 1);
                    else
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowActCUMInTrip", 0);

                    if (chkShowWhatsapp.Checked == true)
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowWhatsapp", 1);
                    else
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowWhatsapp", 0);

                    if (chkShowVarPInKg.Checked == true)
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowVarPInKg", 1);
                    else
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowVarPInKg", 0);

                    if (chkShowHeader.Checked == true)
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowHeader", 1);
                    else
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowHeader", 0);

                    if (chkShowDlvChallan.Checked == true)
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowDeliveryChallan", 1);
                    else
                        SQLHelper._objCmd.Parameters.AddWithValue("@ShowDeliveryChallan", 0);

                    if (chkIsMobileAppSync.Checked == true)
                        SQLHelper._objCmd.Parameters.AddWithValue("@IsMobileAppSync", 1);
                    else
                        SQLHelper._objCmd.Parameters.AddWithValue("@IsMobileAppSync", 0);

                    // When company is saved/updated locally mark it as not synced so sync process can send updates
                    SQLHelper._objCmd.Parameters.AddWithValue("@IsSynced", 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@SyncedOn", DBNull.Value);

                    string text2;

                    if (lblId.Text.Trim() == "0")
                    {
                        text2 = Queries.InsertBySP("CompanyMaster_Insert");
                    }
                    else
                    {
                        SQLHelper._objCmd.Parameters.AddWithValue("@Id", lblId.Text.ToString().Trim());

                        text2 = Queries.UpdateBySP("CompanyMaster_Update");
                    }
                    bool flag1 = text2 != "";
                    if (flag1)
                    {
                        bool flag2 = Functions.DBKeyErrors(text2);
                        bool flag3 = !flag2;
                        if (flag3)
                        {
                            MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        if (lblId.Text.Trim() == "0")
                            MessageBox.Show("Data Inserted Successfully");
                        else
                            MessageBox.Show("Data Updated Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void CompanyMaster_Load(object sender, EventArgs e)
        {
            this.BindCompanyMasterData();
            this.lblUserName.Text = "User Name : " + Queries.UserName;

            //Queries.AccessDT = Functions.GetTableDataBySPWithParam("UserRightWiseDisplayPages", Queries.UserID.ToString());
            DataTable dt = Queries.AccessDT;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["PageName"].ToString() == "Company")
                    {
                        if (dt.Rows[i]["PageAddEdit"].ToString() == "True")
                        {
                            btnSave.Enabled = true;
                        }
                        else
                        {
                            btnSave.Enabled = false;
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
            isFormLoading = false;
        }


        private void BindCompanyMasterData()
        {
            try
            {
                this.dataTable = new DataTable();

                this.dataTable = Functions.GetTableDataBySP("CompanyMaster_Select");

                if (this.dataTable.Rows.Count > 0)
                {
                    lblId.Text = this.dataTable.Rows[0]["Id"].ToString();
                    txtCompanyName.Text = this.dataTable.Rows[0]["CompanyName"].ToString();
                    if (!string.IsNullOrWhiteSpace(txtCompanyName.Text))
                    {
                        txtCompanyName.ReadOnly = true;
                    }
                    txtModelNumber.Text = this.dataTable.Rows[0]["ModelNumber"].ToString();
                    //txtModelNumber.Enabled = false;
                    txtModelNumber.ReadOnly = true;
                    txtSerialNumber.Text = this.dataTable.Rows[0]["SerialNumber"].ToString();
                    //txtSerialNumber.Enabled = false;
                    txtSerialNumber.ReadOnly = true;
                    rtbDescription.Text = this.dataTable.Rows[0]["Address"].ToString();
                    textGstNo.Text = this.dataTable.Rows[0]["GstNo"].ToString();
                    textPanNo.Text = this.dataTable.Rows[0]["PanNo"].ToString();
                    textMobileNo.Text = this.dataTable.Rows[0]["MobileNo"].ToString();
                    txtApiKey.Text = this.dataTable.Rows[0]["ApiKey"].ToString();
                    txtApiKey.ReadOnly = true;
                    txtApiUrl.Text = this.dataTable.Rows[0]["ApiUrl"].ToString();
                    txtApiUrl.ReadOnly = true;
                    txtBin1Label.Text = this.dataTable.Rows[0]["Bin1Label"].ToString();
                    txtBin2Label.Text = this.dataTable.Rows[0]["Bin2Label"].ToString();
                    txtBin3Label.Text = this.dataTable.Rows[0]["Bin3Label"].ToString();
                    txtBin4Label.Text = this.dataTable.Rows[0]["Bin4Label"].ToString();
                    txtCementLabel.Text = this.dataTable.Rows[0]["CementLabel"].ToString();
                    txtFlyashLabel.Text = this.dataTable.Rows[0]["FlyashLabel"].ToString();
                    txtSilicaLabel.Text = this.dataTable.Rows[0]["SilicaLabel"].ToString();
                    txtGGBSLabel.Text = this.dataTable.Rows[0]["GGBSLabel"].ToString();

                    chkShowActCUMInTrip.Checked = GetBoolValue(dataTable.Rows[0]["ShowActCUMInTrip"]);
                    chkShowWhatsapp.Checked = GetBoolValue(dataTable.Rows[0]["ShowWhatsapp"]);
                    chkShowDlvChallan.Checked = GetBoolValue(dataTable.Rows[0]["ShowDeliveryChallan"]);
                    chkShowVarPInKg.Checked = GetBoolValue(dataTable.Rows[0]["ShowVarPInKg"]);
                    chkShowHeader.Checked = GetBoolValue(dataTable.Rows[0]["ShowHeader"]);
                    chkIsMobileAppSync.Checked = GetBoolValue(dataTable.Rows[0]["IsMobileAppSync"]);

                    txtField1Label.Text = this.dataTable.Rows[0]["Field1Label"].ToString();
                    txtField1Value.Text = this.dataTable.Rows[0]["Field1Value"].ToString();
                    txtField2Label.Text = this.dataTable.Rows[0]["Field2Label"].ToString();
                    txtField2Value.Text = this.dataTable.Rows[0]["Field2Value"].ToString();

                    txtReportFooDesc.Text = this.dataTable.Rows[0]["RptFooter"].ToString();
                    textLocation.Text = this.dataTable.Rows[0]["Location"].ToString();
                    if (!string.IsNullOrWhiteSpace(textLocation.Text))
                    {
                        textLocation.ReadOnly = true;
                    }
                    textPlantName.Text = this.dataTable.Rows[0]["PlantName"].ToString();
                    if (!string.IsNullOrWhiteSpace(textPlantName.Text))
                    {
                        textPlantName.ReadOnly = true;
                    }

                    if (this.dataTable.Rows[0]["CompanyLogo"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])this.dataTable.Rows[0]["CompanyLogo"];
                        companyLogoBytes = imgBytes;

                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            picCompanyLogo.Image = Image.FromStream(ms);
                        }
                    }
                    CompanyName = txtCompanyName.Text;
                    Location = textLocation.Text;
                    PlantName = textPlantName.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool GetBoolValue(object value)
        {
            if (value == DBNull.Value || value == null)
                return false;

            return Convert.ToBoolean(value);
        }
        private void CompanyMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    MainScreen mainScreen = new MainScreen();
                    base.Hide();
                    mainScreen.Show();
                    mainScreen.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private DataTable dataTable = null;

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void txtApiKey_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "ApiKey";
                if (this.rdonlApiKey == true)
                {
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtApiUrl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "ApiUrl";
                if (this.rdonlApiUrl == true)
                {
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkShowWhatsapp_CheckedChanged(object sender, EventArgs e)
        {
            if (isFormLoading)
                return;
            //1843
            if (chkShowWhatsapp.Checked)
            {
                using (PasswordDialog dlg = new PasswordDialog("5l2NV3ZieMYSA=", "Enter password to enable Whatsapp"))
                {
                    if (dlg.ShowDialog() != DialogResult.OK || !dlg.IsAuthorized)
                    {
                        chkShowWhatsapp.Checked = false;
                    }
                }
            }
        }

        private void chkShowHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (isFormLoading)
                return;

            if (chkShowHeader.Checked)
            {
                if (companyLogoBytes == null)
                {
                    MessageBox.Show("Please upload company logo before enabling Show Header.");
                    chkShowHeader.Checked = false;
                    return;
                }
            }
        }

        private void chkShowDlvChallan_CheckedChanged(object sender, EventArgs e)
        {
            if (isFormLoading)
                return;
            //1705
            if (chkShowDlvChallan.Checked)
            {
                using (PasswordDialog dlg = new PasswordDialog("5l2NV3ZieMYSA=", "Enter password to enable Delivery Challan"))
                {
                    if (dlg.ShowDialog() != DialogResult.OK || !dlg.IsAuthorized)
                    {
                        chkShowDlvChallan.Checked = false;
                    }
                }
            }
        }

        private void chkAppSync_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isFormLoading)
                    return;
                //1843
                if (chkIsMobileAppSync.Checked)
                {
                    // Validate required fields before showing password dialog so user can cancel and update them
                    var missing = new List<string>();
                    if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
                        missing.Add("Company Name");
                    if (string.IsNullOrWhiteSpace(textLocation.Text))
                        missing.Add("Location");
                    if (string.IsNullOrWhiteSpace(textPlantName.Text))
                        missing.Add("Plant Name");

                    if (missing.Count > 0)
                    {
                        chkIsMobileAppSync.Checked = false;
                        string msg = "Please add the following before enabling Mobile App Sync: " + string.Join(", ", missing) + ".";
                        MessageBox.Show(msg, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        string first = missing[0];
                        if (first == "Company Name")
                            txtCompanyName.Focus();
                        else if (first == "Location")
                            textLocation.Focus();
                        else if (first == "Plant Name")
                            textPlantName.Focus();

                        return;
                    }

                    using (PasswordDialog dlg = new PasswordDialog("5l2NV3ZieMYSA=", "Enter password to enable sync data with mobile app."))
                    {
                        if (dlg.ShowDialog() != DialogResult.OK || !dlg.IsAuthorized)
                        {
                            chkIsMobileAppSync.Checked = false;
                        }
                        else
                        {
                            // Make sure these fields are not editable and warn the user
                            txtCompanyName.ReadOnly = true;
                            textLocation.ReadOnly = true;
                            textPlantName.ReadOnly = true;

                            MessageBox.Show("Make sure Company name, Location and Plant should not be editable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    // When mobile sync is disabled make the fields editable again
                    txtCompanyName.ReadOnly = false;
                    textLocation.ReadOnly = false;
                    textPlantName.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtCompanyName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "CompanyName";
                if (this.rdonCompanyName == true)
                {
                    if(this.chkIsMobileAppSync.Checked)
                    {
                        MessageBox.Show("Company Name cannot be modified when Mobile App Sync is enabled.");
                        return;
                    }
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void textLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "Location";
                if (this.rdonLocation == true)
                {
                    if (this.chkIsMobileAppSync.Checked)
                    {
                        MessageBox.Show("Location cannot be modified when Mobile App Sync is enabled.");
                        return;
                    }
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void textPlantName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "PlantName";
                if (this.rdonPlantName == true)
                {
                    if (this.chkIsMobileAppSync.Checked)
                    {
                        MessageBox.Show("Plant Name cannot be modified when Mobile App Sync is enabled.");
                        return;
                    }
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void btnPartyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                ClientList partyList = new ClientList();
                base.Hide();
                partyList.Show();
                partyList.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                companyLogoBytes = File.ReadAllBytes(ofd.FileName);
                picCompanyLogo.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnRemoveLogo_Click(object sender, EventArgs e)
        {
            // Clear byte data
            companyLogoBytes = null;

            // Remove image from PictureBox
            picCompanyLogo.Image = null;

            // Optional: Reset background / placeholder
            picCompanyLogo.BackColor = Color.LightGray; // or default

            // Optional: show message (UX)
            MessageBox.Show("Logo will be removed successfully after save!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtModelNumber_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "ModelNumber";
                if (this.rdonlModelNo == true)
                {
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtSerialNumber_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.textboxName = "SerialNumber";
                if (this.rdonlSerialNo == true)
                {
                    PasswordToEdit passToEdit = new PasswordToEdit(textboxName);
                    base.Hide();
                    passToEdit.Show();
                    passToEdit.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

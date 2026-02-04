using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = ConfigurationManager.AppSettings["CompanyName"];
                this.txtUserName.Text = "OPP";
                this.txtPassword.Text = "6982";
                this.btnLogin.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private bool CValidate()
        {
            try
            {
                bool flag = this.txtUserName.Text.Trim().Length <= 0;
                if (flag)
                {
                    MessageBox.Show("Enter Username", "Missing", MessageBoxButtons.OK);
                    this.txtUserName.Focus();
                    return false;
                }
                bool flag2 = this.txtPassword.Text.Trim().Length <= 0;
                if (flag2)
                {
                    MessageBox.Show("Enter Password", "Missing", MessageBoxButtons.OK);
                    this.txtPassword.Focus();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = !this.CValidate();
                if (!flag)
                {

                    string sqlStr;
                    EncryptDecryptClass edc = new EncryptDecryptClass();
                    string EncPass = edc.Encrypt(this.txtPassword.Text, true);
                    sqlStr = string.Concat(new string[]
                    {
                            "select Top 1 * from UserMaster where LOWER(UserName)='",
                            this.txtUserName.Text.Trim().ToLower(),
                            "' and Password='",
                            EncPass,
                            //this.txtPassword.Text.Trim(),
                            "' and IsActive=1 and IsDeleted=0"
                    });

                    DataTable tableData = Functions.GetTableData(sqlStr);
                    bool flag3 = tableData != null && tableData.Rows.Count > 0;
                    if (flag3)
                    {
                        Queries.UserID = Convert.ToInt32(tableData.Rows[0]["ID"].ToString());
                        Queries.UserName = tableData.Rows[0]["UserName"].ToString();
                        Queries.WeighBridgeName = "PLC1";
                        Queries.AccessLevel = tableData.Rows[0]["Access"].ToString();

                        Queries.AccessDT = Functions.GetTableDataBySPWithParam("UserRightWiseDisplayPages", Queries.UserID.ToString());
                        
                        MainScreen mainScreen = new MainScreen();
                        base.Hide();
                        mainScreen.Show();
                        mainScreen.BringToFront();
                    }
                    else
                    {
                        this.lblMessage.Visible = true;
                        this.txtUserName.Text = "";
                        this.txtPassword.Text = "";
                        this.txtUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Visible = true;
                this.lblMessage.Text = ex.Message;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class PasswordForUsersForm : Form
    {
        public PasswordForUsersForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = txtPass.Text;

                EncryptDecryptClass edc = new EncryptDecryptClass();
                string EncPass = edc.Encrypt(pass, true);

                if (EncPass == "cHhpaobjTCc=")
                {
                    this.lblMsg.Visible = false;
                    User user = new User();
                    base.Hide();
                    user.Show();
                    user.BringToFront();
                }
                else
                {
                    this.lblMsg.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void PasswordForUsersForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
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
    }
}

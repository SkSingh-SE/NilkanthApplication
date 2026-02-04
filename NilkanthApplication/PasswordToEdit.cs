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
    public partial class PasswordToEdit : Form
    {
        string _txtMode = "";
        public PasswordToEdit(string txtMode)
        {
            InitializeComponent();
            _txtMode = txtMode;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            
            EncryptDecryptClass edc = new EncryptDecryptClass();
            string EncPass = edc.Encrypt(pass, true);

            if (EncPass == "1VhlIlEw5kc=")
            {
                CompanyMaster cm = new CompanyMaster();
                base.Hide();
                cm.Show();
                cm.BringToFront();
                //if (_txtMode == "ModelNumber")
                    cm.rdonlModelNo = false;
                //if(_txtMode == "SerialNumber")
                    cm.rdonlSerialNo = false;

                cm.rdonlApiKey = false;
                cm.rdonlApiUrl = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyMaster cm = new CompanyMaster();
                base.Hide();
                cm.Show();
                cm.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordToEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    CompanyMaster companyMaster = new CompanyMaster();
                    base.Hide();
                    companyMaster.Show();
                    companyMaster.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

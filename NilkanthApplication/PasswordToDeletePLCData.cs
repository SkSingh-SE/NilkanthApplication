using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class PasswordToDeletePLCData : Form
    {
        public PasswordToDeletePLCData()
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
                    bool flag = MessageBox.Show("Are you sure, You want to Delete PLC Data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                    if (flag)
                    {
                        SQLHelper._objCmd = new SqlCommand();
                        SQLHelper._objCmd.Parameters.Clear();
                        string text2 = Queries.DeleteBySP("PLCData_DeleteAll");

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
                            MessageBox.Show("PLC Data deleted successfully");
                        
                        AllTransaction allTran = new AllTransaction();
                        base.Hide();
                        allTran.Show();
                        allTran.BringToFront();
                    }
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
                AllTransaction allTransaction = new AllTransaction();
                base.Hide();
                allTransaction.Show();
                allTransaction.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void PasswordToDeletePLCData_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool flag = e.CloseReason == CloseReason.UserClosing;
                if (flag)
                {
                    AllTransaction allTransaction = new AllTransaction();
                    base.Hide();
                    allTransaction.Show();
                    allTransaction.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class PasswordDialog : Form
    {
        private readonly string _expectedEncryptedPassword;

        public bool IsAuthorized { get; private set; } = false;

        public PasswordDialog(string expectedEncryptedPassword, string message = "Enter Password")
        {
            InitializeComponent();

            _expectedEncryptedPassword = expectedEncryptedPassword;
            lblMessage.Text = message;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Password cannot be empty.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            EncryptDecryptClass edc = new EncryptDecryptClass();
            string encrypted = edc.Encrypt(enteredPassword, true);

            if (encrypted == _expectedEncryptedPassword)
            {
                IsAuthorized = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Password.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsAuthorized = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
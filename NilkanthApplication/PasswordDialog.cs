using System;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class PasswordDialog : Form
    {
        private readonly string _expectedEncryptedPassword;

        public bool IsAuthorized { get; private set; } = false;

        public PasswordDialog(string expectedEncryptedPassword, string message = "Enter Password", bool showCancel = false)
        {
            InitializeComponent();

            _expectedEncryptedPassword = expectedEncryptedPassword;
            lblMessage.Text = message;

            btnCancel.Visible = showCancel;

            int formWidth = this.ClientSize.Width;
            int btnWidth = btnOk.Width;
            int btnY = btnOk.Location.Y;

            if (showCancel)
            {
                int gap = 20;
                int totalWidth = btnWidth * 2 + gap;
                int startX = (formWidth - totalWidth) / 2;
                btnCancel.Location = new System.Drawing.Point(startX, btnY);
                btnOk.Location = new System.Drawing.Point(startX + btnWidth + gap, btnY);
            }
            else
            {
                btnOk.Location = new System.Drawing.Point((formWidth - btnWidth) / 2, btnY);
            }
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
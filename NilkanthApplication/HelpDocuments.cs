using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class HelpDocuments : Form
    {
        int leftcontrol = 1;

        public HelpDocuments()
        {
            InitializeComponent();
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

        private void HelpDocuments_Load(object sender, EventArgs e)
        {
            /*dgvList.ColumnCount = 3;
            dgvList.Columns[0].Name = "";
            dgvList.Columns[1].Name = "";
            dgvList.Columns[2].Name = "";
            /*string[] row = new string[] { "File1", "File2", "File3" };
            dgvList.Rows.Add(row);
            row = new string[] { "File4", "File5", "File6" };
            dgvList.Rows.Add(row);*/

            /*string[] row = new string[3];   
            for (int a = 0; a <= 10; a++)
            {
                for(int b=0; b<3; b++)
                {
                    row[b] = "File" + b;
                }
                dgvList.Rows.Add(row);
            }*/

            this.lblUserName.Text = "User Name : " + Queries.UserName;
            dgvList.ColumnCount = 5;
            dgvList.Columns[0].Name = "";
            dgvList.Columns[1].Name = "";
            dgvList.Columns[2].Name = "";
            dgvList.Columns[3].Name = "";
            dgvList.Columns[4].Name = "";
            string[] row = new string[5];
            string path = Application.StartupPath + "/HelpDoc/PDF";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            int rw = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(files.Length / 5.0)));
            int index = 0;
            for(int a = 0; a< rw; a++)
            {
                for(int b=0;b<5;b++)
                {
                    if (index < files.Length)
                    {
                        row[b] = files[index].Name;
                        
                    }
                    else
                    {
                        row[b] = "";
                    }
                    index += 1;
                }
                dgvList.Rows.Add(row);
            }

            //C:\Program Files\Google\Chrome\Application\chrome.exe
            //System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            //string strNamedDestination = @"D:\Nishant\Projects\NilkanthApplication\Project\NilkanthApplication\NilkanthApplication\bin\Debug\HelpDoc\PDF\"; // Must be defined in PDF file.


            /*bool flagFirst = true;
            int topValue = 150;
            //string dir = AppDomain.CurrentDomain.BaseDirectory + "/HelpDoc/PDF";
            string path = Application.StartupPath + "/HelpDoc/PDF";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();

            for(int a = 0; a<files.Length; a++)
            {
                if(flagFirst)
                {
                    LinkLabel l = new LinkLabel();
                    this.Controls.Add(l);
                    l.Top = topValue;
                    l.Left = 100;
                    l.Text = files[a].Name;
                    leftcontrol += 1;
                    flagFirst = false;
                }
                else
                {
                    LinkLabel l = new LinkLabel();
                    this.Controls.Add(l);
                    topValue += 30;
                    l.Top = topValue;
                    l.Left = 100;
                    l.Text = files[a].Name;
                    leftcontrol += 1;
                }
            }*/

            /*LinkLabel l1 = new LinkLabel();
            this.Controls.Add(l1);
            l1.Top = 150;
            l1.Left = 100;
            l1.Text = "Link" + leftcontrol;
            leftcontrol += 1;

            LinkLabel l2 = new LinkLabel();
            this.Controls.Add(l2);
            l2.Top = 180;
            l2.Left = 100;
            l2.Text = "Link" + leftcontrol;
            leftcontrol += 1;

            LinkLabel l3 = new LinkLabel();
            this.Controls.Add(l3);
            l3.Top = 210;
            l3.Left = 100;
            l3.Text = "Link" + leftcontrol;
            leftcontrol += 1;

            LinkLabel l4 = new LinkLabel();
            this.Controls.Add(l4);
            l4.Top = 240;
            l4.Left = 100;
            l4.Text = "Link" + leftcontrol;
            leftcontrol += 1;

            LinkLabel l5 = new LinkLabel();
            this.Controls.Add(l5);
            l5.Top = 270;
            l5.Left = 100;
            l5.Text = "Link" + leftcontrol;
            leftcontrol += 1; */
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
            {
                string fileName = dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string strFilePath = Application.StartupPath  + "/HelpDoc/PDF/" + fileName;
                string strParams = "\"" + strFilePath + "\"";
                System.Diagnostics.Process.Start("chrome.exe", strParams);
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
    }
}

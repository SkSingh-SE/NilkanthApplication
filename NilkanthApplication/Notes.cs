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
    public partial class Notes : Form
    {
        private int editID;

        public Notes(int ID)
        {
            InitializeComponent();
            this.editID = ID;
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            this.lblId.Text = this.editID.ToString();
            this.lblUserName.Text = "User Name : " + Queries.UserName;

            bool flag = this.lblId.Text.Trim() != "0";
            if (flag)
            {
                this.SetEditValues();
            }

            Point point = new Point();
            point.X = 12;
            point.Y = 625;
            pictureBox1.Location = point;
            pictureBox1.Width = 1350;

            Point point1 = new Point();
            point1.X = 12;
            point1.Y = 635;
            lblUserName.Location = point1;

            Point point2 = new Point();
            point2.X = 12;
            point2.Y = 655;
            lblVersion.Location = point2;

            Point point3 = new Point();
            point3.X = 1300;
            point3.Y = 635;
            btnLogout.Location = point3;

            Point point4 = new Point();
            point4.X = 1200;
            point4.Y = 19;
            btnBack.Location = point4;

            Point point5 = new Point();
            point5.X = 1200;
            point5.Y = 19;
            btnBack.Location = point4;

            Point point6 = new Point();
            point6.X = 400;
            point6.Y = 140;
            lblDate.Location = point6;

            Point point7 = new Point();
            point7.X = 535;
            point7.Y = 140;
            dtDate.Location = point7;

            Point point8 = new Point();
            point8.X = 400;
            point8.Y = 191;
            lblRemarks.Location = point8;

            Point point9 = new Point();
            point9.X = 535;
            point9.Y = 191;
            txtRemarks.Location = point9;

            Point point10 = new Point();
            point10.X = 780;
            point10.Y = 485;
            btnSave.Location = point10;
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
                NotesList noteslist = new NotesList();
                base.Hide();
                noteslist.Show();
                noteslist.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@NoteDate", dtDate.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@NoteRemarks", txtRemarks.Text.ToString().Trim());
                
                string text2;

                if (lblId.Text.Trim() == "0")
                {
                    text2 = Queries.InsertBySP("Notes_Insert");
                }
                else
                {
                    SQLHelper._objCmd.Parameters.AddWithValue("@ID", lblId.Text.ToString().Trim());
                    text2 = Queries.UpdateBySP("Notes_Update");
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
                    NotesList noteslist = new NotesList();
                    base.Hide();
                    noteslist.Show();
                    noteslist.BringToFront();

                    //if (lblId.Text.Trim() == "0")
                    //    MessageBox.Show("Data Inserted Successfully");
                    //else
                    //    MessageBox.Show("Data Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void SetEditValues()
        {
            try
            {
                DataTable tableData = Functions.GetTableData("select top 1 * from Notes where ID=" + this.lblId.Text.Trim());
                bool flag = tableData != null && tableData.Rows.Count > 0;
                if (flag)
                {
                    this.dtDate.Text = tableData.Rows[0]["NoteDate"].ToString();
                    this.txtRemarks.Text = tableData.Rows[0]["NoteRemarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

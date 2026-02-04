using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class Breakdown : Form
    {
        public Breakdown(int ID)
        {
            InitializeComponent();
            this.editID = ID;
        }

        private void Breakdown_Load(object sender, EventArgs e)
        {
            this.lblId.Text = this.editID.ToString();
            this.lblUserName.Text = "User Name : " + Queries.UserName;

            GetAndFillModelNoSerialNo();
            BindFaultType();
            BindActualFault();
            BindWorkCarriedOut();

            bool flag = this.lblId.Text.Trim() != "0";
            if (flag)
            {
                this.SetEditValues();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@ModelNo", txtModelNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@SerialNo", txtSerialNo.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@FaultStartDate", dtFaultStartDate.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@FaultStopDate", dtFaultStopDate.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@InchargeName", txtInchargeName.Text.ToString().Trim());
                SQLHelper._objCmd.Parameters.AddWithValue("@EngineerName", txtEngineerName.Text.ToString().Trim());
                //SQLHelper._objCmd.Parameters.AddWithValue("@FaultTypeID", cmbFaultType.SelectedValue.ToString().Trim());
                //SQLHelper._objCmd.Parameters.AddWithValue("@ActualFaultID", cmbActualFault.SelectedValue.ToString().Trim());
                //SQLHelper._objCmd.Parameters.AddWithValue("@WorkCarriedOutID", cmbWorkCarriedOut.SelectedValue.ToString().Trim());

                string FaultTypeIDs = "";
                //string FaultTypes = "";

                if (chkLstFaultType.CheckedItems.Count > 0)
                {
                    foreach (ListItem item in chkLstFaultType.CheckedItems)
                    {
                        //string[] IDs = item.ToString().Split('-');
                        //FaultTypeIDs += IDs[0] + ",";
                        //FaultTypes += IDs[1] + ",";
                        FaultTypeIDs += item.ID + ",";
                    }

                    FaultTypeIDs = FaultTypeIDs.Substring(0, FaultTypeIDs.Length - 1);
                    //FaultTypes = FaultTypes.Substring(0, FaultTypes.Length - 1);
                }

                string ActualFaultIDs = "";
                //string ActualFaults = "";
                if (chkLstActualFault.CheckedItems.Count > 0)
                {
                    foreach (ListItem item in chkLstActualFault.CheckedItems)
                    {
                        //string[] IDs = item.ToString().Split('-');
                        //ActualFaultIDs += IDs[0] + ",";
                        //ActualFaults += IDs[1] + ",";
                        ActualFaultIDs += item.ID + ",";
                    }

                    ActualFaultIDs = ActualFaultIDs.Substring(0, ActualFaultIDs.Length - 1);
                    //ActualFaults = ActualFaults.Substring(0, ActualFaults.Length - 1);
                }

                string WorkCarriedOutIDs = "";
                //string WorkCarriedOuts = "";
                if (chkLstWorkCarriedOut.CheckedItems.Count > 0)
                {
                    foreach (ListItem item in chkLstWorkCarriedOut.CheckedItems)
                    {
                        //string[] IDs = item.ToString().Split('-');
                        //WorkCarriedOutIDs += IDs[0] + ",";
                        //WorkCarriedOuts += IDs[1] + ",";
                        WorkCarriedOutIDs += item.ID + ",";
                    }

                    WorkCarriedOutIDs = WorkCarriedOutIDs.Substring(0, WorkCarriedOutIDs.Length - 1);
                    //WorkCarriedOuts = WorkCarriedOuts.Substring(0, WorkCarriedOuts.Length - 1);
                }

                SQLHelper._objCmd.Parameters.AddWithValue("@FaultTypeIDs", FaultTypeIDs);
                //SQLHelper._objCmd.Parameters.AddWithValue("@FaultTypes", FaultTypes);
                SQLHelper._objCmd.Parameters.AddWithValue("@ActualFaultIDs", ActualFaultIDs);
                //SQLHelper._objCmd.Parameters.AddWithValue("@ActualFaults", ActualFaults);
                SQLHelper._objCmd.Parameters.AddWithValue("@WorkCarriedOutIDs", WorkCarriedOutIDs);
                //SQLHelper._objCmd.Parameters.AddWithValue("@WorkCarriedOuts", WorkCarriedOuts);

                string text2;

                if (lblId.Text.Trim() == "0")
                {
                    text2 = Queries.InsertBySP("Breakdown_Insert");
                }
                else
                {
                    SQLHelper._objCmd.Parameters.AddWithValue("@ID", lblId.Text.ToString().Trim());
                    text2 = Queries.UpdateBySP("Breakdown_Update");
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
                    BreakdownList breakdownlist = new BreakdownList();
                    base.Hide();
                    breakdownlist.Show();
                    breakdownlist.BringToFront();

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
                DataTable tableData = Functions.GetTableData("select top 1 * from Breakdown where ID=" + this.lblId.Text.Trim());
                bool flag = tableData != null && tableData.Rows.Count > 0;
                if (flag)
                {
                    this.txtModelNo.Text = tableData.Rows[0]["ModelNo"].ToString();
                    this.txtSerialNo.Text = tableData.Rows[0]["SerialNo"].ToString();
                    this.dtFaultStartDate.Text = tableData.Rows[0]["FaultStartDate"].ToString();
                    this.dtFaultStopDate.Text = tableData.Rows[0]["FaultStopDate"].ToString();
                    this.txtInchargeName.Text = tableData.Rows[0]["InchargeName"].ToString();
                    this.txtEngineerName.Text = tableData.Rows[0]["EngineerName"].ToString();
                    string FaultTypeIDs = tableData.Rows[0]["FaultTypeIDs"].ToString();
                    string[] FaultTypeIDsDetails_ = FaultTypeIDs.Split(',');
                    Int64[] FaultTypeIDs_ = Array.ConvertAll(FaultTypeIDsDetails_, s => Int64.Parse(s));
                    string ActualFaultIDs = tableData.Rows[0]["ActualFaultIDs"].ToString();
                    string[] ActualFaultIDsDetails_ = ActualFaultIDs.Split(',');
                    Int64[] ActualFaultIDs_ = Array.ConvertAll(ActualFaultIDsDetails_, s => Int64.Parse(s));
                    string WorkCarriedOutIDs = tableData.Rows[0]["WorkCarriedOutIDs"].ToString();
                    string[] WorkCarriedOutIDsDetails_ = WorkCarriedOutIDs.Split(',');
                    Int64[] WorkCarriedOutIDs_ = Array.ConvertAll(WorkCarriedOutIDsDetails_, s => Int64.Parse(s));

                    ListItem[] faultyItems = chkLstFaultType.Items.Cast<ListItem>().ToArray();
                    foreach (ListItem li in faultyItems)
                    {
                        if (FaultTypeIDs_.Contains<Int64>(Convert.ToInt64(li.ID)))
                        {
                            chkLstFaultType.SetItemChecked(li.Index, true);
                        }
                    }

                    ListItem[] actualFaultyItems = chkLstActualFault.Items.Cast<ListItem>().ToArray();
                    foreach (ListItem li in actualFaultyItems)
                    {
                        if (ActualFaultIDs_.Contains<Int64>(Convert.ToInt64(li.ID)))
                        {
                            chkLstActualFault.SetItemChecked(li.Index, true);
                        }
                    }

                    ListItem[] workList = chkLstWorkCarriedOut.Items.Cast<ListItem>().ToArray();

                    foreach (ListItem li in workList)
                    {
                        if (WorkCarriedOutIDs_.Contains<Int64>(Convert.ToInt64(li.ID)))
                        {
                            chkLstWorkCarriedOut.SetItemChecked(li.Index, true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Breakdown_FormClosing(object sender, FormClosingEventArgs e)
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
                BreakdownList breakdownlist = new BreakdownList();
                base.Hide();
                breakdownlist.Show();
                breakdownlist.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private int editID;



        private void btnAddFaultType_Click(object sender, EventArgs e)
        {
            try
            {
                FaultType fltType = new FaultType();
                base.Hide();
                fltType.Show();
                fltType.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnAddActualFault_Click(object sender, EventArgs e)
        {
            try
            {
                ActualFault actFault = new ActualFault();
                base.Hide();
                actFault.Show();
                actFault.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnAddWorkCout_Click(object sender, EventArgs e)
        {
            try
            {
                WorkCarriedOut workCarriedOut = new WorkCarriedOut();
                base.Hide();
                workCarriedOut.Show();
                workCarriedOut.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        void BindFaultType()
        {
            string FaultTypeDetails = "";
            chkLstFaultType.Items.Clear();

            string query = "select ID,Name from FaultType where IsDeleted=0";
            DataTable dataTableFaultType = Functions.GetTableData(query);

            List<ListItem> FaultTypeList = new List<ListItem>();
            FaultTypeList = ConvertDataTable<ListItem>(dataTableFaultType);

            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = FaultTypeList;

            //chkLstFaultType.di = bindingSource;

            //List<ListItem> FaultTypeList = List<ListItem>(dataTableFaultType)
            //chkLstFaultType.Items.Add(FaultTypeList);
            int faulttypeindex = 0;
            for (int i = 0; i < dataTableFaultType.Rows.Count; i++)
            {
                //FaultTypeDetails = dataTableFaultType.Rows[i]["ID"].ToString() + "-" + dataTableFaultType.Rows[i]["Name"].ToString();
                ListItem Li = new ListItem();
                Li.Index = faulttypeindex;
                Li.ID = Convert.ToInt64(dataTableFaultType.Rows[i]["ID"].ToString());
                Li.Name = dataTableFaultType.Rows[i]["Name"].ToString();
                chkLstFaultType.Items.Add(Li);
                faulttypeindex += 1;
            }

        }

        void GetAndFillModelNoSerialNo()
        {
            string query = "select ModelNumber,SerialNumber from CompanyMaster";
            DataTable dataTable = Functions.GetTableData(query);

            if(dataTable.Rows.Count > 0)
            {
                txtModelNo.Text = dataTable.Rows[0][0].ToString();
                txtSerialNo.Text = dataTable.Rows[0][1].ToString();
                txtModelNo.Enabled = txtSerialNo.Enabled = false;
            }
        }
        
        void BindActualFault()
        {
            string ActualFaultDetails = "";
            chkLstActualFault.Items.Clear();

            string query1 = "select ID,Name from ActualFault where IsDeleted=0";
            DataTable dataTableActualFault = Functions.GetTableData(query1);

            List<ListItem> ActualFaultList = new List<ListItem>();
            ActualFaultList = ConvertDataTable<ListItem>(dataTableActualFault);

            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = FaultTypeList;

            //chkLstFaultType.di = bindingSource;

            //List<ListItem> FaultTypeList = List<ListItem>(dataTableFaultType)
            //chkLstFaultType.Items.Add(FaultTypeList);
            int actualfaultindex = 0;
            for (int i = 0; i < dataTableActualFault.Rows.Count; i++)
            {
                //FaultTypeDetails = dataTableFaultType.Rows[i]["ID"].ToString() + "-" + dataTableFaultType.Rows[i]["Name"].ToString();
                ListItem Li = new ListItem();
                Li.Index = actualfaultindex;
                Li.ID = Convert.ToInt64(dataTableActualFault.Rows[i]["ID"].ToString());
                Li.Name = dataTableActualFault.Rows[i]["Name"].ToString();
                chkLstActualFault.Items.Add(Li);
                actualfaultindex += 1;
            }

            //for (int i = 0; i < dataTableActualFault.Rows.Count; i++)
            //{
            //    ActualFaultDetails = dataTableActualFault.Rows[i]["ID"].ToString() + "-" + dataTableActualFault.Rows[i]["Name"].ToString();
            //    chkLstActualFault.Items.Add(ActualFaultDetails);
            //}
        }

        void BindWorkCarriedOut()
        {
            string WorkCarriedOutDetails = "";
            chkLstWorkCarriedOut.Items.Clear();

            string query2 = "select ID,Name from WorkCarriedOut where IsDeleted=0";
            DataTable dataTableWorkCarriedOut = Functions.GetTableData(query2);

            List<ListItem> WorkCarriedOutList = new List<ListItem>();
            WorkCarriedOutList = ConvertDataTable<ListItem>(dataTableWorkCarriedOut);

            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = FaultTypeList;

            //chkLstFaultType.di = bindingSource;

            //List<ListItem> FaultTypeList = List<ListItem>(dataTableFaultType)
            //chkLstFaultType.Items.Add(FaultTypeList);
            int workcarriedoutindex = 0;
            for (int i = 0; i < dataTableWorkCarriedOut.Rows.Count; i++)
            {
                //FaultTypeDetails = dataTableFaultType.Rows[i]["ID"].ToString() + "-" + dataTableFaultType.Rows[i]["Name"].ToString();
                ListItem Li = new ListItem();
                Li.Index = workcarriedoutindex;
                Li.ID = Convert.ToInt64(dataTableWorkCarriedOut.Rows[i]["ID"].ToString());
                Li.Name = dataTableWorkCarriedOut.Rows[i]["Name"].ToString();
                chkLstWorkCarriedOut.Items.Add(Li);
                workcarriedoutindex += 1;
            }

            //for (int i = 0; i < dataTableWorkCarriedOut.Rows.Count; i++)
            //{
            //    WorkCarriedOutDetails = dataTableWorkCarriedOut.Rows[i]["ID"].ToString() + "-" + dataTableWorkCarriedOut.Rows[i]["Name"].ToString();
            //    chkLstWorkCarriedOut.Items.Add(WorkCarriedOutDetails);
            //}
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
    public class ListItem
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public Int64 ID { get; set; }

        public override string ToString()
        {
            return Name; // This ensures the Text property is displayed
        }
    }
}

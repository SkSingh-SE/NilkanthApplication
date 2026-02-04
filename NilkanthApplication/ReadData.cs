using NilkanthApplication;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class ReadData : Form
    {
        private DataTable dataTable = null;
        modbus mb = new modbus();
        SerialPort sp = new SerialPort();
        System.Timers.Timer timer = new System.Timers.Timer();
        int readdata = 0;
        bool isPolling = false;
        int pollCount;

        #region GUI Delegate Declarations
        public delegate void GUIDelegate(string paramString);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        #region Delegate Functions
        public void DoGUIClear()
        {
            if (this.InvokeRequired)
            {
                GUIClear delegateMethod = new GUIClear(this.DoGUIClear);
                this.Invoke(delegateMethod);
            }
            else
                this.lstRegisterValues.Items.Clear();
        }
        public void DoGUIStatus(string paramString)
        {
            if (this.InvokeRequired)
            {
                GUIStatus delegateMethod = new GUIStatus(this.DoGUIStatus);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
                this.lblStatus.Text = paramString;
        }
        public void DoGUIUpdate(string paramString)
        {
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { paramString });
            }
            else
                this.lstRegisterValues.Items.Add(paramString);
        }
        #endregion

        public ReadData()
        {
            InitializeComponent();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

        }

        private void ReadData_Load(object sender, EventArgs e)
        {

            try
            {
                //string portname = ConfigurationManager.AppSettings["portname"].ToString();
                string portname = "COM3";
                int baudrate = Convert.ToInt32(ConfigurationManager.AppSettings["baudrate"].ToString());
                int databits = Convert.ToInt32(ConfigurationManager.AppSettings["databits"].ToString());

                StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigurationManager.AppSettings["stopbits"].ToString(), true);
                Parity parity = (Parity)Enum.Parse(typeof(Parity), ConfigurationManager.AppSettings["parity"].ToString(), true);

                pollCount = 0;
                this.dataTable = Functions.GetTableDataBySP("PLCAddressValueDetails_Select");
                //Open COM port using provided settings:
                if (this.dataTable != null && this.dataTable.Rows.Count > 0 && mb.Open(portname, baudrate, databits, parity, stopBits))
                {
                    //Disable double starts:
                    // btnStart.Enabled = false;

                    //Set polling flag:
                    isPolling = true;

                    //Start timer using provided values:
                    timer.AutoReset = true;
                    //timer.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["samplerate"].ToString());
                    timer.Interval = 1000;

                    //timer.Start();
                    //PollFunction();

                }
            }
            catch (Exception err)
            {
                DoGUIStatus("Error in modbus " + err.Message);
            }

        }

        #region Timer Elapsed Event Handler
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isPolling)
                PollBitFunction();
        }
        #endregion


        private void StopPoll()
        {
            //Stop timer and close COM port:
            isPolling = false;
            timer.Stop();
            mb.Close();

            //btnStart.Enabled = true;

            //lblStatus.Text = mb.modbusStatus;
        }


        /*private void btnStart_Click(object sender, EventArgs e)
        {
            StartPoll();
        }*/

        public float GetSingle(ushort highOrderValue, ushort lowOrderValue)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(lowOrderValue).Concat(BitConverter.GetBytes(highOrderValue)).ToArray(), 0);
        }
        static string HexToText(int intno)
        {
            string hexValue = intno.ToString("X");
            int numberChars = hexValue.Length;

            string returnvalue = "";
            for (int i = 0; i < numberChars; i += 2)
            {
                returnvalue += Convert.ToChar(Convert.ToByte(hexValue.Substring(i, 2), 16));
            }
            char[] chararr = returnvalue.ToCharArray();
            Array.Reverse(chararr);
            string strmain = new string(chararr);
            return strmain;

        }

        private void PollBitFunction()
        {
            try
            {
                int readDataBit = 0;

                ushort sAddress = Convert.ToUInt16(this.dataTable.Rows[0][3].ToString());
                ushort length = Convert.ToUInt16(this.dataTable.Rows[0][5].ToString());
                short[] values = new short[Convert.ToInt32(length)];

                while (!mb.SendFc3(Convert.ToByte(ConfigurationManager.AppSettings["slaveid"].ToString()), sAddress, length, ref values)) ;
                readDataBit = Convert.ToInt32(values[0].ToString());
                if (readDataBit == 1 && sAddress == 35069)
                {
                    readdata = 1;
                    //PollFunction();
                }
                if (readDataBit == 0 && readdata == 1)
                {
                    readdata = 0;
                    PollFunction();
                }
            }
            catch (Exception err)
            {
                DoGUIStatus("Error in modbus read: " + err.Message);
            }
        }

        #region Poll Function
        private void PollFunction()
        {
            isPolling = false;
            //Update GUI:
            //DoGUIClear();
            DoGUIUpdate("\n");
            pollCount++;
            DoGUIStatus("Poll count: " + pollCount.ToString());

            //Read registers and display data in desired format:
            try
            {
                string itemString = "", plcDate = "", customer = "", clientName = "", siteName = "", recipeName = "", truckNo = "", driverName = "";
                int yy = 0, MM = 0, dd = 0, hh = 0, mm = 0, ss = 0;
                double batchSize = 0, batchNo = 0, setCycle = 0, cycle = 0, bin1Set = 0, bin1Actual = 0, bin2Set = 0, bin2Actual = 0, bin3Set = 0, bin3Actual = 0, bin4Set = 0, bin4Actual = 0,
                    cementSet = 0, cementActual = 0, flyashSet = 0, flyashActual = 0, waterSet = 0, waterActual = 0, additiveSet = 0, additiveActual = 0, totalActual = 0,
                    silicaSet = 0, silicaActual = 0, ggbsSet = 0, ggbsActual = 0;

                //this.dataTable = Functions.GetTableDataBySP("PLCAddressValueDetails_Select");
                for (int i = 1; i < this.dataTable.Rows.Count; i++)
                {

                    ushort sAddress = Convert.ToUInt16(this.dataTable.Rows[i][3].ToString());
                    ushort length = Convert.ToUInt16(this.dataTable.Rows[i][5].ToString());
                    short[] values = new short[Convert.ToInt32(length)];
                    while (!mb.SendFc3(Convert.ToByte(ConfigurationManager.AppSettings["slaveid"].ToString()), sAddress, length, ref values)) ;
                    string dataType = this.dataTable.Rows[i][4].ToString();
                    if (dataType == "String")
                    {
                        if (length == 5)
                            length = 3;
                        else
                            length = Convert.ToUInt16(length / 2);
                    }

                    int address, a = 0;
                    switch (dataType)
                    {
                        case "Decimal":

                            address = sAddress;
                            itemString = "[" + Convert.ToString(address) + "] = " + values[a].ToString() + "\n";

                            switch (address)
                            {
                                case 33793:
                                    setCycle = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33794:
                                    cycle = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 34034:
                                    batchNo = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33962:
                                    bin1Actual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33964:
                                    bin2Actual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33966:
                                    bin3Actual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33968:
                                    bin4Actual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33970:
                                    cementActual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33972:
                                    flyashActual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 33974:
                                    waterActual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 34018:
                                    silicaActual = Convert.ToDouble(values[a].ToString());
                                    break;
                                //case 34962:
                                case 33938:
                                    ggbsActual = Convert.ToDouble(values[a].ToString());
                                    break;
                                case 36864:
                                    yy = Convert.ToInt32(values[a].ToString());
                                    break;
                                case 36865:
                                    MM = Convert.ToInt32(values[a].ToString());
                                    break;
                                case 36866:
                                    dd = Convert.ToInt32(values[a].ToString());
                                    break;
                                case 36867:
                                    hh = Convert.ToInt32(values[a].ToString());
                                    break;
                                case 36868:
                                    mm = Convert.ToInt32(values[a].ToString());
                                    break;
                                case 36869:
                                    ss = Convert.ToInt32(values[a].ToString());
                                    break;
                            }
                            DoGUIUpdate(itemString);
                            break;
                        case "Float":
                            address = sAddress;
                            double returnedValue = GetSingle((ushort)values[2 * a + 1], unchecked((ushort)values[2 * a]));
                            itemString = "[" + Convert.ToString(address) + "] = " + returnedValue + "\n";

                            switch (address)
                            {
                                case 33850:
                                    silicaSet = returnedValue;
                                    break;
                                //case 33852:
                                case 33848:
                                    ggbsSet = returnedValue; //ggbsSet and bin1Set address same check it.
                                    break;
                                case 33852:
                                    bin1Set = returnedValue;
                                    break;
                                case 33854:
                                    bin2Set = returnedValue;
                                    break;
                                case 33856:
                                    bin3Set = returnedValue;
                                    break;
                                case 33858:
                                    bin4Set = returnedValue;
                                    break;
                                case 33860:
                                    cementSet = returnedValue;
                                    break;
                                case 33862:
                                    flyashSet = returnedValue;
                                    break;
                                case 33864:
                                    waterSet = returnedValue;
                                    break;
                                case 33866:
                                    additiveSet = returnedValue;
                                    break;
                                case 34882:
                                    totalActual = returnedValue;
                                    break;
                                case 33976:
                                    additiveActual = returnedValue;
                                    break;
                                case 35840:
                                    batchSize = returnedValue;
                                    break;
                            }
                            DoGUIUpdate(itemString);
                            break;
                        case "String":
                            string convertvalue = "";
                            int intValue = (int)values[2 * a];
                            if (intValue > 0)
                                convertvalue += HexToText(intValue);
                            //intValue <<= 16;
                            intValue = (int)values[2 * a + 1];
                            if (intValue > 0)
                                convertvalue += HexToText(intValue);
                            //intValue <<= 16;
                            intValue = (int)values[2 * a + 2];
                            if (intValue > 0)
                                convertvalue += HexToText(intValue);
                            //intValue <<= 16;
                            if (length == 4)
                            {
                                intValue = (int)values[2 * a + 3];
                                if (intValue > 0)
                                    convertvalue += HexToText(intValue);
                            }
                            else if (length == 6)
                            {
                                intValue = (int)values[2 * a + 3];
                                if (intValue > 0)
                                    convertvalue += HexToText(intValue);
                                //intValue <<= 16;
                                intValue = (int)values[2 * a + 4];
                                if (intValue > 0)
                                    convertvalue += HexToText(intValue);
                                //intValue <<= 16;
                                intValue = (int)values[2 * a + 5];
                                if (intValue > 0)
                                    convertvalue += HexToText(intValue);
                            }

                            address = sAddress;
                            itemString = "[" + Convert.ToString(address) + "] = " + convertvalue + "\n";
                            switch (address)
                            {
                                case 32770:
                                    truckNo = convertvalue;
                                    break;
                                case 32776:
                                    clientName = convertvalue;
                                    break;
                                case 32780:
                                    siteName = convertvalue;
                                    break;
                                case 32784:
                                    driverName = convertvalue;
                                    break;
                                case 32818:
                                    recipeName = convertvalue;
                                    break;
                                case 36494:
                                    customer = convertvalue;
                                    break;
                            }
                            DoGUIUpdate(itemString);
                            break;
                    }
                }
                //StopPoll();
                DoGUIUpdate(itemString);

                plcDate = yy.ToString() + "-" + MM.ToString() + "-" + dd.ToString() + " " + hh.ToString() + ":" + mm.ToString() + ":" + ss.ToString() + ".000";

                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@PLCDate", Convert.ToDateTime(plcDate));
                SQLHelper._objCmd.Parameters.AddWithValue("@Customer", customer);
                SQLHelper._objCmd.Parameters.AddWithValue("@ClientName", clientName);
                SQLHelper._objCmd.Parameters.AddWithValue("@SiteName", siteName);
                SQLHelper._objCmd.Parameters.AddWithValue("@RecipeName", recipeName);
                SQLHelper._objCmd.Parameters.AddWithValue("@TruckNo", truckNo);
                SQLHelper._objCmd.Parameters.AddWithValue("@DriverName", driverName);
                SQLHelper._objCmd.Parameters.AddWithValue("@BatchSize", batchSize);
                SQLHelper._objCmd.Parameters.AddWithValue("@BatchNo", batchNo);
                SQLHelper._objCmd.Parameters.AddWithValue("@SetCycle", setCycle);
                SQLHelper._objCmd.Parameters.AddWithValue("@Cycle", cycle);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Set", bin1Set);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Actual", bin1Actual);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Set", bin2Set);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Actual", bin2Actual);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Set", bin3Set);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Actual", bin3Actual);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Set", bin4Set);
                SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Actual", bin4Actual);
                SQLHelper._objCmd.Parameters.AddWithValue("@CementSet", cementSet);
                SQLHelper._objCmd.Parameters.AddWithValue("@CementActual", cementActual);
                SQLHelper._objCmd.Parameters.AddWithValue("@FlyashSet", flyashSet);
                SQLHelper._objCmd.Parameters.AddWithValue("@FlyashActual", flyashActual);
                SQLHelper._objCmd.Parameters.AddWithValue("@WaterSet", waterSet);
                SQLHelper._objCmd.Parameters.AddWithValue("@WaterActual", waterActual);
                SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveSet", additiveSet);
                SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveActual", additiveActual);
                SQLHelper._objCmd.Parameters.AddWithValue("@TotalActual", totalActual);
                SQLHelper._objCmd.Parameters.AddWithValue("@SilicaSet", silicaSet);
                SQLHelper._objCmd.Parameters.AddWithValue("@SilicaActual", silicaActual);
                SQLHelper._objCmd.Parameters.AddWithValue("@GGBSSet", ggbsSet);
                SQLHelper._objCmd.Parameters.AddWithValue("@GGBSActual", ggbsActual);

                string text2 = Queries.InsertBySP("PLCData_Insert");
                isPolling = true;
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


            }
            catch (Exception err)
            {
                DoGUIStatus("Error in modbus read: " + err.Message);
            }

        }
        #endregion

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPoll();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PollFunction();
        }
    }
}

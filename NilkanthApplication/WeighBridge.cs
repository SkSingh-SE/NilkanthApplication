
using NilkanthApplication.WBConfiguration;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NilkanthApplication
{
    public partial class WeighBridge : Form
    {
        public WeighBridge()
        {
            this.InitializeComponent();
            this.SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(this.PinChanged);
            this.ComPort.DataReceived += this.port_DataReceived_1;
        }

        private void btnGetSerialPorts_Click(object sender, EventArgs e)
        {
            int num = -1;
            string b = null;
            string[] portNames = SerialPort.GetPortNames();
            do
            {
                num++;
                this.cboPorts.Items.Add(portNames[num]);
            }
            while (!(portNames[num] == b) && num != portNames.GetUpperBound(0));
            Array.Sort<string>(portNames);
            bool flag = num == portNames.GetUpperBound(0);
            if (flag)
            {
                b = portNames[0];
            }
            this.cboPorts.Text = portNames[0];
            this.cboBaudRate.Items.Add(300);
            this.cboBaudRate.Items.Add(600);
            this.cboBaudRate.Items.Add(1200);
            this.cboBaudRate.Items.Add(2400);
            this.cboBaudRate.Items.Add(9600);
            this.cboBaudRate.Items.Add(14400);
            this.cboBaudRate.Items.Add(19200);
            this.cboBaudRate.Items.Add(38400);
            this.cboBaudRate.Items.Add(57600);
            this.cboBaudRate.Items.Add(115200);
            this.cboBaudRate.Items.ToString();
            this.cboBaudRate.Text = this.cboBaudRate.Items[0].ToString();
            this.cboDataBits.Items.Add(7);
            this.cboDataBits.Items.Add(8);
            this.cboDataBits.Text = this.cboDataBits.Items[0].ToString();
            this.cboStopBits.Items.Add("One");
            this.cboStopBits.Items.Add("OnePointFive");
            this.cboStopBits.Items.Add("Two");
            this.cboStopBits.Text = this.cboStopBits.Items[0].ToString();
            this.cboParity.Items.Add("None");
            this.cboParity.Items.Add("Even");
            this.cboParity.Items.Add("Mark");
            this.cboParity.Items.Add("Odd");
            this.cboParity.Items.Add("Space");
            this.cboParity.Text = this.cboParity.Items[0].ToString();
            this.cboHandShaking.Items.Add("None");
            this.cboHandShaking.Items.Add("XOnXOff");
            this.cboHandShaking.Items.Add("RequestToSend");
            this.cboHandShaking.Items.Add("RequestToSendXOnXOff");
            this.cboHandShaking.Text = this.cboHandShaking.Items[0].ToString();
        }

        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            this.InputData = this.ComPort.ReadExisting();
            bool flag = this.InputData != string.Empty;
            if (flag)
            {
                base.BeginInvoke(new WeighBridge.SetTextCallback(this.SetText), new object[]
                {
                    this.InputData
                });
            }
        }

        private void SetText(string text)
        {
            RichTextBox richTextBox = this.rtbIncoming;
            richTextBox.Text += text;
        }

        internal void PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange eventType = e.EventType;
            this.lblCTSStatus.BackColor = Color.Green;
            this.lblDSRStatus.BackColor = Color.Green;
            this.lblRIStatus.BackColor = Color.Green;
            this.lblBreakStatus.BackColor = Color.Green;
            SerialPinChange serialPinChange = eventType;
            SerialPinChange serialPinChange2 = serialPinChange;
            if (serialPinChange2 <= SerialPinChange.DsrChanged)
            {
                if (serialPinChange2 != SerialPinChange.CtsChanged)
                {
                    if (serialPinChange2 == SerialPinChange.DsrChanged)
                    {
                        bool flag = this.ComPort.DsrHolding;
                        this.lblDSRStatus.BackColor = Color.Red;
                    }
                }
                else
                {
                    bool flag = this.ComPort.CDHolding;
                    this.lblCTSStatus.BackColor = Color.Red;
                }
            }
            else if (serialPinChange2 != SerialPinChange.CDChanged)
            {
                if (serialPinChange2 != SerialPinChange.Break)
                {
                    if (serialPinChange2 == SerialPinChange.Ring)
                    {
                        this.lblRIStatus.BackColor = Color.Red;
                    }
                }
                else
                {
                    this.lblBreakStatus.BackColor = Color.Red;
                }
            }
            else
            {
                bool flag = this.ComPort.CtsHolding;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
        }

        private void btnPortState_Click(object sender, EventArgs e)
        {
            bool flag = this.btnPortState.Text == "Closed";
            if (flag)
            {
                this.btnPortState.Text = "Open";
                this.ComPort.PortName = Convert.ToString(this.cboPorts.Text);
                this.ComPort.BaudRate = Convert.ToInt32(this.cboBaudRate.Text);
                this.ComPort.DataBits = (int)Convert.ToInt16(this.cboDataBits.Text);
                this.ComPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cboStopBits.Text);
                this.ComPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), this.cboHandShaking.Text);
                this.ComPort.Parity = (Parity)Enum.Parse(typeof(Parity), this.cboParity.Text);
                this.ComPort.Open();
            }
            else
            {
                bool flag2 = this.btnPortState.Text == "Open";
                if (flag2)
                {
                    this.btnPortState.Text = "Closed";
                    this.ComPort.Close();
                }
            }
        }

        private void rtbOutgoing_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = e.KeyChar == '\r';
            if (flag)
            {
                this.ComPort.Write("\r\n");
                this.rtbOutgoing.Text = "";
            }
            else
            {
                bool flag2 = e.KeyChar < ' ' || e.KeyChar > '~';
                if (flag2)
                {
                    e.Handled = true;
                }
                else
                {
                    this.ComPort.Write(e.KeyChar.ToString());
                }
            }
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            this.ComPort.Write("Hello World!" + Environment.NewLine);
        }

        private void btnHyperTerm_Click(object sender, EventArgs e)
        {
            string text = this.txtCommand.Text;
            int num = 0;
            int length = text.Length;
            for (int i = 0; i < length; i++)
            {
                string text2 = text.Substring(num, 1);
                this.ComPort.Write(text2);
                num++;
            }
        }

        private void WeighBridge_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = e.CloseReason == CloseReason.UserClosing;
            if (flag)
            {
                bool isOpen = this.ComPort.IsOpen;
                if (isOpen)
                {
                    this.ComPort.Close();
                }
                MainScreen mainScreen = new MainScreen();
                base.Hide();
                mainScreen.Show();
                mainScreen.BringToFront();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool isOpen = this.ComPort.IsOpen;
            if (isOpen)
            {
                this.ComPort.Close();
            }
            MainScreen mainScreen = new MainScreen();
            base.Hide();
            mainScreen.Show();
            mainScreen.BringToFront();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = this.ComPort.IsOpen;
                if (isOpen)
                {
                    this.rtbIncoming.Text = this.ComPort.ReadExisting();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnReadLine_Click(object sender, EventArgs e)
        {
            try
            {
                bool isOpen = this.ComPort.IsOpen;
                if (isOpen)
                {
                    this.rtbIncoming.Text = this.ComPort.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnGetbyIP_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(this.txtIP.Text.Trim(), Convert.ToInt32(this.txtIPPort.Text.Trim()));
                NetworkStream stream = tcpClient.GetStream();
                byte[] array = new byte[1000768];
                stream.Read(array, 0, tcpClient.ReceiveBufferSize);
                string @string = Encoding.ASCII.GetString(array);
                MessageBox.Show("Weight: " + @string);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private SerialPort ComPort = new SerialPort();

        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;

        private string InputData = string.Empty;

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);

        private delegate void SetTextCallback(string text);

        public string GetWeight()
        {
            string returndata = "0";
            string ipAddress = "";
            bool ipenabled = true;
            int port = 0;

            int baudRate = 2400;
            int dataBits = 1;
            string portName = "COM1";
            StopBits stopBits = StopBits.One;
            Parity parity = Parity.Even;
            byte parityReplace = 63;
            Handshake handshake = Handshake.None;
            bool discardNull = false;

            int commandText = 5;
            string commandType = "ASCII";

            var wbconfig = (WBConfig)ConfigurationManager.GetSection("weighBridges");

            foreach (WBInstanceElement instance in wbconfig.WBInstances)
            {
                if (instance.Name == Queries.WeighBridgeName)
                {
                    ipAddress = instance.IPAddress;
                    port = instance.IPPort;
                    ipenabled = instance.IPEnabled;
                    baudRate = instance.BaudRate;
                    dataBits = instance.DataBits;
                    portName = instance.PortName;
                    stopBits = (StopBits)instance.StopBits;
                    parity = (Parity)Enum.Parse(typeof(Parity), instance.Parity, true);
                    parityReplace = (byte)instance.ParityReplace;
                    handshake = (Handshake)Enum.Parse(typeof(Handshake), instance.HandShake, true);
                    discardNull = instance.DiscardNull;
                    commandText = instance.CommandText;
                    commandType = instance.CommandType;
                }
            }

            if (ipenabled)
            {
                try
                {
                    System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
                    System.Net.Sockets.NetworkStream serverStream;
                    clientSocket.Connect(ipAddress.Trim(), port);
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[1000768];
                    serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                    returndata = System.Text.Encoding.ASCII.GetString(inStream);

                    //MessageBox.Show("Weight: " + returndata);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("IP Address : " + ex.Message);
                }
            }
            else
            {
                SerialPort serialPort = new SerialPort();
                try
                {
                    byte[] myoutstream = new byte[20];
                    myoutstream = new Byte[] { (Byte)commandText };

                    string _commandText = commandText.ToString("X");

                    serialPort.BaudRate = baudRate;
                    serialPort.DataBits = dataBits;
                    serialPort.PortName = portName;
                    serialPort.StopBits = stopBits;
                    serialPort.Parity = parity;
                    serialPort.ParityReplace = parityReplace;
                    serialPort.Handshake = handshake;
                    serialPort.DiscardNull = discardNull;

                    serialPort.Open();
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                    serialPort.Write(myoutstream, 0, myoutstream.Length);
                    serialPort.DiscardInBuffer();
                    int bytes = serialPort.BytesToRead;

                    byte[] instream = new Byte[10024];
                    serialPort.Read(instream, 0, 10024);
                    returndata = System.Text.Encoding.ASCII.GetString(instream);

                    int attempt = 0;
                    while (attempt < 1)
                    {
                        Thread.Sleep(250);
                        serialPort.Read(instream, 0, 10024);
                        returndata = System.Text.Encoding.ASCII.GetString(instream);
                        attempt++;
                    }

                    // MessageBox.Show("Weight: " + returndata);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Com : " + ex.Message);
                }
                finally
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();
                    serialPort.Close();
                }
            }

            return returndata;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || c == '.')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        private void btnNewCode_Click(object sender, EventArgs e)
        {
            try
            {
                string weight = this.GetWeight();
                //string text = RemoveSpecialCharacters(weight);
                txtNewLogic.Text = string.Format("{0:0,0.00}", weight.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}



namespace NilkanthApplication
{
	public partial class WeighBridge : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeighBridge));
            this.btnGetSerialPorts = new System.Windows.Forms.Button();
            this.rtbIncoming = new System.Windows.Forms.RichTextBox();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboHandShaking = new System.Windows.Forms.ComboBox();
            this.lblBreakStatus = new System.Windows.Forms.Label();
            this.lblCTSStatus = new System.Windows.Forms.Label();
            this.lblDSRStatus = new System.Windows.Forms.Label();
            this.lblRIStatus = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnPortState = new System.Windows.Forms.Button();
            this.btnHello = new System.Windows.Forms.Button();
            this.rtbOutgoing = new System.Windows.Forms.RichTextBox();
            this.btnHyperTerm = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnReadLine = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtIPPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGetbyIP = new System.Windows.Forms.Button();
            this.btnNewCode = new System.Windows.Forms.Button();
            this.txtNewLogic = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetSerialPorts
            // 
            this.btnGetSerialPorts.Location = new System.Drawing.Point(12, 27);
            this.btnGetSerialPorts.Name = "btnGetSerialPorts";
            this.btnGetSerialPorts.Size = new System.Drawing.Size(75, 23);
            this.btnGetSerialPorts.TabIndex = 0;
            this.btnGetSerialPorts.Text = "Ports";
            this.btnGetSerialPorts.UseVisualStyleBackColor = true;
            this.btnGetSerialPorts.Click += new System.EventHandler(this.btnGetSerialPorts_Click);
            // 
            // rtbIncoming
            // 
            this.rtbIncoming.Location = new System.Drawing.Point(12, 278);
            this.rtbIncoming.Name = "rtbIncoming";
            this.rtbIncoming.Size = new System.Drawing.Size(260, 96);
            this.rtbIncoming.TabIndex = 1;
            this.rtbIncoming.Text = "";
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(190, 29);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(121, 21);
            this.cboPorts.TabIndex = 2;
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(190, 56);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cboBaudRate.TabIndex = 3;
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(190, 83);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(121, 21);
            this.cboDataBits.TabIndex = 4;
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(190, 110);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(121, 21);
            this.cboStopBits.TabIndex = 5;
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(190, 137);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 21);
            this.cboParity.TabIndex = 6;
            // 
            // cboHandShaking
            // 
            this.cboHandShaking.FormattingEnabled = true;
            this.cboHandShaking.Location = new System.Drawing.Point(190, 164);
            this.cboHandShaking.Name = "cboHandShaking";
            this.cboHandShaking.Size = new System.Drawing.Size(121, 21);
            this.cboHandShaking.TabIndex = 7;
            // 
            // lblBreakStatus
            // 
            this.lblBreakStatus.AutoSize = true;
            this.lblBreakStatus.Location = new System.Drawing.Point(24, 206);
            this.lblBreakStatus.Name = "lblBreakStatus";
            this.lblBreakStatus.Size = new System.Drawing.Size(35, 13);
            this.lblBreakStatus.TabIndex = 8;
            this.lblBreakStatus.Text = "Break";
            this.lblBreakStatus.Visible = false;
            // 
            // lblCTSStatus
            // 
            this.lblCTSStatus.AutoSize = true;
            this.lblCTSStatus.Location = new System.Drawing.Point(79, 206);
            this.lblCTSStatus.Name = "lblCTSStatus";
            this.lblCTSStatus.Size = new System.Drawing.Size(28, 13);
            this.lblCTSStatus.TabIndex = 9;
            this.lblCTSStatus.Text = "CTS";
            this.lblCTSStatus.Visible = false;
            // 
            // lblDSRStatus
            // 
            this.lblDSRStatus.AutoSize = true;
            this.lblDSRStatus.Location = new System.Drawing.Point(130, 206);
            this.lblDSRStatus.Name = "lblDSRStatus";
            this.lblDSRStatus.Size = new System.Drawing.Size(30, 13);
            this.lblDSRStatus.TabIndex = 10;
            this.lblDSRStatus.Text = "DSR";
            this.lblDSRStatus.Visible = false;
            // 
            // lblRIStatus
            // 
            this.lblRIStatus.AutoSize = true;
            this.lblRIStatus.Location = new System.Drawing.Point(188, 206);
            this.lblRIStatus.Name = "lblRIStatus";
            this.lblRIStatus.Size = new System.Drawing.Size(18, 13);
            this.lblRIStatus.TabIndex = 11;
            this.lblRIStatus.Text = "RI";
            this.lblRIStatus.Visible = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 180);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 12;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnPortState
            // 
            this.btnPortState.Location = new System.Drawing.Point(12, 56);
            this.btnPortState.Name = "btnPortState";
            this.btnPortState.Size = new System.Drawing.Size(75, 23);
            this.btnPortState.TabIndex = 13;
            this.btnPortState.Text = "Closed";
            this.btnPortState.UseVisualStyleBackColor = true;
            this.btnPortState.Click += new System.EventHandler(this.btnPortState_Click);
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(12, 85);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(75, 23);
            this.btnHello.TabIndex = 14;
            this.btnHello.Text = "Send Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // rtbOutgoing
            // 
            this.rtbOutgoing.Location = new System.Drawing.Point(9, 241);
            this.rtbOutgoing.Name = "rtbOutgoing";
            this.rtbOutgoing.Size = new System.Drawing.Size(214, 31);
            this.rtbOutgoing.TabIndex = 15;
            this.rtbOutgoing.Text = "";
            this.rtbOutgoing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbOutgoing_KeyPress);
            // 
            // btnHyperTerm
            // 
            this.btnHyperTerm.Location = new System.Drawing.Point(391, 196);
            this.btnHyperTerm.Name = "btnHyperTerm";
            this.btnHyperTerm.Size = new System.Drawing.Size(75, 23);
            this.btnHyperTerm.TabIndex = 16;
            this.btnHyperTerm.Text = "HyperTerm";
            this.btnHyperTerm.UseVisualStyleBackColor = true;
            this.btnHyperTerm.Click += new System.EventHandler(this.btnHyperTerm_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(366, 225);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(100, 20);
            this.txtCommand.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(391, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Select Port :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Baud Rate :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Data Bits :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Stop Bits :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Parity :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hand Shaking :";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(391, 276);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 25;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnReadLine
            // 
            this.btnReadLine.Location = new System.Drawing.Point(391, 319);
            this.btnReadLine.Name = "btnReadLine";
            this.btnReadLine.Size = new System.Drawing.Size(75, 23);
            this.btnReadLine.TabIndex = 26;
            this.btnReadLine.Text = "Read Line";
            this.btnReadLine.UseVisualStyleBackColor = true;
            this.btnReadLine.Click += new System.EventHandler(this.btnReadLine_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "IP Address :";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(74, 399);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(170, 20);
            this.txtIP.TabIndex = 28;
            // 
            // txtIPPort
            // 
            this.txtIPPort.Location = new System.Drawing.Point(74, 425);
            this.txtIPPort.Name = "txtIPPort";
            this.txtIPPort.Size = new System.Drawing.Size(170, 20);
            this.txtIPPort.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Port : ";
            // 
            // btnGetbyIP
            // 
            this.btnGetbyIP.Location = new System.Drawing.Point(283, 397);
            this.btnGetbyIP.Name = "btnGetbyIP";
            this.btnGetbyIP.Size = new System.Drawing.Size(75, 23);
            this.btnGetbyIP.TabIndex = 31;
            this.btnGetbyIP.Text = "Get By IP";
            this.btnGetbyIP.UseVisualStyleBackColor = true;
            this.btnGetbyIP.Click += new System.EventHandler(this.btnGetbyIP_Click);
            // 
            // btnNewCode
            // 
            this.btnNewCode.Location = new System.Drawing.Point(32, 464);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(75, 23);
            this.btnNewCode.TabIndex = 32;
            this.btnNewCode.Text = "New Logic";
            this.btnNewCode.UseVisualStyleBackColor = true;
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // txtNewLogic
            // 
            this.txtNewLogic.Location = new System.Drawing.Point(133, 466);
            this.txtNewLogic.Name = "txtNewLogic";
            this.txtNewLogic.Size = new System.Drawing.Size(299, 20);
            this.txtNewLogic.TabIndex = 33;
            // 
            // WeighBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(547, 510);
            this.Controls.Add(this.txtNewLogic);
            this.Controls.Add(this.btnNewCode);
            this.Controls.Add(this.btnGetbyIP);
            this.Controls.Add(this.txtIPPort);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnReadLine);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnHyperTerm);
            this.Controls.Add(this.rtbOutgoing);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.btnPortState);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblRIStatus);
            this.Controls.Add(this.lblDSRStatus);
            this.Controls.Add(this.lblCTSStatus);
            this.Controls.Add(this.lblBreakStatus);
            this.Controls.Add(this.cboHandShaking);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.cboStopBits);
            this.Controls.Add(this.cboDataBits);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.rtbIncoming);
            this.Controls.Add(this.btnGetSerialPorts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WeighBridge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Serial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WeighBridge_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.Button btnGetSerialPorts;

		private global::System.Windows.Forms.RichTextBox rtbIncoming;

		private global::System.Windows.Forms.ComboBox cboPorts;

		private global::System.Windows.Forms.ComboBox cboBaudRate;

		private global::System.Windows.Forms.ComboBox cboDataBits;

		private global::System.Windows.Forms.ComboBox cboStopBits;

		private global::System.Windows.Forms.ComboBox cboParity;

		private global::System.Windows.Forms.ComboBox cboHandShaking;

		private global::System.Windows.Forms.Label lblBreakStatus;

		private global::System.Windows.Forms.Label lblCTSStatus;

		private global::System.Windows.Forms.Label lblDSRStatus;

		private global::System.Windows.Forms.Label lblRIStatus;

		private global::System.Windows.Forms.Button btnTest;

		private global::System.Windows.Forms.Button btnPortState;

		private global::System.Windows.Forms.Button btnHello;

		private global::System.Windows.Forms.RichTextBox rtbOutgoing;

		private global::System.Windows.Forms.Button btnHyperTerm;

		private global::System.Windows.Forms.TextBox txtCommand;

		private global::System.Windows.Forms.Button btnCancel;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.Label label4;

		private global::System.Windows.Forms.Label label5;

		private global::System.Windows.Forms.Label label6;

		private global::System.Windows.Forms.Button btnRead;

		private global::System.Windows.Forms.Button btnReadLine;

		private global::System.Windows.Forms.Label label7;

		private global::System.Windows.Forms.TextBox txtIP;

		private global::System.Windows.Forms.TextBox txtIPPort;

		private global::System.Windows.Forms.Label label8;

		private global::System.Windows.Forms.Button btnGetbyIP;
        private System.Windows.Forms.Button btnNewCode;
        private System.Windows.Forms.TextBox txtNewLogic;
    }
}

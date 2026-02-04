using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NilkanthApplication
{
    public partial class PLCConnect : Form
    {
        Process proc;
        public PLCConnect()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp); 
        private void PLCConnect_Load(object sender, EventArgs e)
        {
            //Process p = Process.Start(@"C:\Users\Tripearltech\Desktop\Anydesk.exe");
            //proc = Process.Start(@"C:\Program Files\RealVNC\VNC Viewer\vncviewer.exe");

            ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files\RealVNC\VNC Viewer\vncviewer.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            proc= Process.Start(startInfo);

            proc.WaitForInputIdle();
            
            while(proc.MainWindowHandle==IntPtr.Zero)
            {
                Thread.Sleep(100);
                proc.Refresh();
            }
            
            SetParent(proc.MainWindowHandle, this.Handle);
            
        }

        private void PLCConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            proc.Kill();
            this.Hide();
        }

    }
}

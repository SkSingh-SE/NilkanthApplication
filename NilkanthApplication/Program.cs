using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NilkanthApplication.Classes;

namespace NilkanthApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 1. Safely kill any existing duplicate/zombie processes of this application
            KillPreviousInstances();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 2. Start 24x7 continuous PLC CSV polling as soon as app starts (0% CPU load)
            CsvImportManager.Instance.StartContinuousImport(intervalSeconds: 10);

            Application.Run(new Login());
        }

        // Safely terminates any previous running instances of NilkanthApplication
        private static void KillPreviousInstances()
        {
            try
            {
                Process current = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(current.ProcessName);

                foreach (Process process in processes)
                {
                    if (process.Id != current.Id)
                    {
                        try
                        {
                            // Attempt graceful close first
                            if (!process.CloseMainWindow())
                            {
                                process.Kill();
                            }
                            else
                            {
                                if (!process.WaitForExit(1000))
                                {
                                    process.Kill();
                                }
                            }
                            process.WaitForExit(2000);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
    }
}

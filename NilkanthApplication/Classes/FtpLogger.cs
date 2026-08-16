using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace NilkanthApplication.Classes
{
    // Industrial Diagnostic & Logging Engine for FTP Connections
    public static class FtpLogger
    {
        private static readonly object _lock = new object();
        private static string _logDirectory;

        static FtpLogger()
        {
            try
            {
                _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }
            }
            catch { }
        }

        public static string LogDirectory => _logDirectory;

        public static void LogInfo(string context, string message)
        {
            Write("INFO", context, message, null);
        }

        public static void LogSuccess(string context, string message)
        {
            Write("SUCCESS", context, message, null);
        }

        public static void LogError(string context, string message, Exception ex = null, string targetUrl = "")
        {
            string diagnosis = DiagnoseError(ex);
            string fullMessage = message;
            if (!string.IsNullOrEmpty(targetUrl))
                fullMessage += $" | Target: {targetUrl}";
            if (!string.IsNullOrEmpty(diagnosis))
                fullMessage += $"\n    [Diagnosis]: {diagnosis}";

            Write("ERROR", context, fullMessage, ex);
        }

        // Smart Diagnostic Classifier: explains exact root cause
        public static string DiagnoseError(Exception ex)
        {
            if (ex == null) return "";

            if (ex is WebException wex)
            {
                if (wex.Response is FtpWebResponse ftpRes)
                {
                    switch (ftpRes.StatusCode)
                    {
                        case FtpStatusCode.NotLoggedIn:
                            return "FTP Login Failed (530): Username or Password in App.config is incorrect.";
                        case FtpStatusCode.ActionNotTakenFileUnavailable:
                            return "File Not Found (550): CSV file does not exist on FTP server or SD card/USB is unmounted.";
                        case FtpStatusCode.ServiceNotAvailable:
                            return "Service Not Available (421): FTP service on PLC/HMI is overloaded or shutting down.";
                        default:
                            return $"FTP Protocol Error: {ftpRes.StatusCode} ({ftpRes.StatusDescription?.Trim()})";
                    }
                }

                if (wex.InnerException is SocketException sex)
                {
                    switch (sex.SocketErrorCode)
                    {
                        case SocketError.ConnectionRefused:
                            return $"Connection Refused (Socket Error 10061): Target PLC/HMI actively refused port 21. FTP server service is disabled on HMI, PLC is rebooting, or single-session limit was reached.";
                        case SocketError.TimedOut:
                            return $"Connection Timeout (Socket Error 10060): Target device did not respond. Ethernet cable disconnected, PLC powered off, or network switch issue.";
                        case SocketError.HostUnreachable:
                            return $"Host Unreachable (Socket Error 10065): PC cannot route to PLC IP. Ensure PC static IP is on the same subnet (e.g., 192.168.1.xxx).";
                        case SocketError.NetworkUnreachable:
                            return $"Network Unreachable (Socket Error 10051): Local network adapter is disabled or disconnected.";
                        default:
                            return $"Socket Error: {sex.SocketErrorCode} (Code {sex.ErrorCode}) - {sex.Message}";
                    }
                }

                if (wex.Status == WebExceptionStatus.ConnectFailure)
                    return "Connection Failure: Unable to establish TCP socket connection with FTP server (Port 21).";
                if (wex.Status == WebExceptionStatus.Timeout)
                    return "Timeout: FTP server did not respond within the 10-second timeout window.";
            }

            if (ex.InnerException != null)
                return DiagnoseError(ex.InnerException);

            return ex.Message;
        }

        private static void Write(string level, string context, string message, Exception ex)
        {
            try
            {
                lock (_lock)
                {
                    string filePath = Path.Combine(_logDirectory, $"FtpSync_{DateTime.Now:yyyy-MM-dd}.log");
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string line = $"[{timestamp}] [{level}] [{context}] {message}";

                    if (ex != null && level == "ERROR")
                    {
                        line += $"\n    [Exception Details]: {ex.Message}";
                    }

                    File.AppendAllText(filePath, line + Environment.NewLine);
                }
            }
            catch { }
        }

        // Opens the log directory in Windows Explorer
        public static void OpenLogFolder()
        {
            try
            {
                if (Directory.Exists(_logDirectory))
                {
                    System.Diagnostics.Process.Start("explorer.exe", _logDirectory);
                }
            }
            catch { }
        }
    }
}

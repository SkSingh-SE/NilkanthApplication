using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

public class Functions : SQLHelper
{
    public static void setFormBoarderStyle(Form frm)
    {
        frm.FormBorderStyle = FormBorderStyle.FixedDialog;
    }

    public static void ClearTextBoxes(Control.ControlCollection cc)
    {
        foreach (Control ctrl in cc)
        {
            TextBox tb = ctrl as TextBox;
            if (tb != null)
                tb.Clear();
            else
                ClearTextBoxes(ctrl.Controls);
        }
    }
    static public Object GetSingleValue(string sqlstr)
    {

        Object cnt = SQLHelper.ExecuteScalarPassQuery(sqlstr);
        return cnt;
    }
    public static bool DBKeyErrors(string Errmsg)
    {
        if ((Errmsg.IndexOf("COLUMN REFERENCE") > 0) || (Errmsg.IndexOf("COLUMN FOREIGN KEY") > 0))
        {
            MessageBox.Show("You cannot insert or delete record. One or more references exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }
        else if (Errmsg.IndexOf("PRIMARY KEY") > 0)
        {
            MessageBox.Show("Record already exist !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void resetAllControls(Control objForm)
    {
        foreach (Control cnt in objForm.Controls)
            findControl(cnt);
    }
    private static void findControl(Control cnt)
    {
        if (cnt != null)
        {
            if (cnt.GetType().ToString() == "System.Windows.Forms.ComboBox" ||
                cnt.GetType().ToString() == "System.Windows.Forms.TextBox" ||
                cnt.GetType().ToString() == "System.Windows.Forms.CheckBox" ||
                cnt.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
                clearControl(cnt);
            else
                foreach (Control cnt1 in cnt.Controls)
                    findControl(cnt1);
        }
    }
    private static void clearControl(Control cnt)
    {
        if (cnt.GetType().ToString() == "System.Windows.Forms.ComboBox")
        {
            System.Windows.Forms.ComboBox cbo = (System.Windows.Forms.ComboBox)cnt;
            if (cbo.DropDownStyle == ComboBoxStyle.DropDownList && cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
            else if (cbo.DropDownStyle != ComboBoxStyle.DropDownList)
                cbo.Text = "";
        }
        else if (cnt.GetType().ToString() == "System.Windows.Forms.CheckBox")
        {
            System.Windows.Forms.CheckBox cbo = (System.Windows.Forms.CheckBox)cnt;
            cbo.Checked = false;
        }
        else if (cnt.GetType().ToString() == "System.Windows.Forms.TextBox")
        {
            System.Windows.Forms.TextBox cbo = (System.Windows.Forms.TextBox)cnt;
            cbo.Text = "";
        }
        else if (cnt.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
        {
            System.Windows.Forms.DateTimePicker cbo = (System.Windows.Forms.DateTimePicker)cnt;
            cbo.Text = "";
        }
    }
    public static void Fill_Combo(ComboBox combo, string query, string textfield, string valuefield, string defText, string defVal)
    {
        string sql = query;
        DataSet ds_combo = new DataSet();
        ds_combo.Clear();
        ds_combo = SQLHelper.FetchDataSet(sql);
        if (ds_combo == null) return;
        if (defText != "" && defVal != "")
        {
            DataRow dtRow = ds_combo.Tables[0].NewRow();
            dtRow[0] = defVal;
            dtRow[1] = defText;
            ds_combo.Tables[0].Rows.InsertAt(dtRow, 0);
        }
        combo.DataSource = ds_combo.Tables[0].DefaultView;
        combo.DisplayMember = textfield;
        combo.ValueMember = valuefield;
        if (defText != "" && defVal != "")
        {
            combo.SelectedValue = "0";
        }
    }
    static public DataTable GetTableData(string SqlStr)
    {
        return (SQLHelper.FetchDataTable(SqlStr));
    }
    static public DataTable GetTableDataBySP(string storeProcName)
    {
        return (SQLHelper.FetchDataTableBySP(storeProcName, "", null));
    }
    static public DataTable GetTableDataBySP(string storeProcName, string ParamName, object ParamValue)
    {
        return (SQLHelper.FetchDataTableBySP(storeProcName, ParamName, ParamValue));
    }
    static public DataTable GetTableDataBySPWithParam(string storeProcName, string paramString)
    {
        return (SQLHelper.GetTableBySPWithParam(storeProcName, paramString));
    }
    static public DataSet GetTablesDataBySPWithParam(string storeProcName, string paramString)
    {
        return (SQLHelper.GetTablesBySPWithParam(storeProcName, paramString));
    }

    public static DataTable DataGridViewToDataTable(DataGridView dataGridView, string filename)
    {
        var dt = new DataTable();
        foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
        {
            //if (dataGridViewColumn.Visible)
            //{
            dt.Columns.Add(dataGridViewColumn.Name);
            //}
        }
        var cell = new object[dataGridView.Columns.Count];
        foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
        {
            if (dataGridViewRow.Cells[0].Value.ToString() != "0")
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
        }


        for (int i = 0; i < dt.Columns.Count; i++)
        {
            if (dt.Columns[i].ColumnName.StartsWith("cb"))
                dt.Columns.RemoveAt(i);
        }

        if (filename == "BinLocation")
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName.Equals("SiteID"))
                    dt.Columns.RemoveAt(i);
            }
        }

        DataView view = dt.DefaultView;
        if (filename != "Logs")
        {
            if (dt.Columns[1].ColumnName != "")
                view.Sort = dt.Columns[1].ColumnName + " ASC";
        }
        else
        {
            view.Sort = "ID DESC";
        }

        return view.ToTable();
    }
    public static void ExportGrid(DataGridView dgvForExport, string exporttype, string filename, bool IsLandscape = false)
    {
        if (exporttype == "Excel")
        {
            if (dgvForExport.Rows.Count > 0)

            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "Excel Workbook (*.xlsx)|*.xlsx";

                save.FileName = filename + ".xlsx";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to write data in disk" + ex.Message);

                        }

                    }
                    if (!ErrorMessage)

                    {
                        Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                        // creating new WorkBook within Excel application  
                        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                        // creating new Excelsheet in workbook  
                        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                        // see the excel sheet behind the program  
                        app.Visible = true;
                        // get the reference of first sheet. By default its name is Sheet1.  
                        // store its reference to worksheet  
                        worksheet = workbook.Sheets["Sheet1"];
                        worksheet = workbook.ActiveSheet;
                        // changing the name of active sheet  
                        worksheet.Name = "Exported";
                        //// storing header part in Excel  
                        //for (int i = 1; i < dgvForExport.Columns.Count + 1; i++)
                        //{
                        //    worksheet.Cells[1, i] = dgvForExport.Columns[i - 1].HeaderText;
                        //}
                        //// storing Each row and column value to excel sheet  
                        //for (int i = 0; i < dgvForExport.Rows.Count - 1; i++)
                        //{
                        //    for (int j = 0; j < dgvForExport.Columns.Count; j++)
                        //    {
                        //        worksheet.Cells[i + 2, j + 1] = dgvForExport.Rows[i].Cells[j].Value.ToString();
                        //    }
                        //}


                        DataTable dtSort = DataGridViewToDataTable(dgvForExport, filename);
                        // storing header part in Excel  
                        for (int i = 1; i < dtSort.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i] = dtSort.Columns[i - 1].ColumnName;
                        }
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < dtSort.Rows.Count; i++)
                        {
                            for (int j = 0; j < dtSort.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1] = dtSort.Rows[i][j].ToString();
                            }
                        }

                        // save the application  
                        workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        // Exit from the application  
                        app.Quit();
                        MessageBox.Show("Data Export Successfully", "info");
                    }
                }


            }
            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }
        else
        {
            if (dgvForExport.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = filename + ".pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try
                        {
                            DataTable dtSort = DataGridViewToDataTable(dgvForExport, filename);
                            PdfPTable pTable = new PdfPTable(dtSort.Columns.Count);

                            //pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;


                            //pTable.SetTotalWidth(new float[] { PageSize.A4.Rotate().Width });
                            float[] cellwidth = new float[dtSort.Columns.Count];
                            var totalwidth = 0;
                            for (int i = 0; i < dtSort.Columns.Count; i++)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(dtSort.Columns[i].ColumnName));
                                totalwidth += dgvForExport.Columns[dtSort.Columns[i].ColumnName].Width * 3;
                                cellwidth[i] = dgvForExport.Columns[dtSort.Columns[i].ColumnName].Width * 3;

                                pTable.AddCell(pCell);
                            }

                            for (int j = 0; j < dtSort.Rows.Count; j++)
                            {
                                for (int k = 0; k < dtSort.Columns.Count; k++)
                                {
                                    string name = dtSort.Rows[j][k].ToString();
                                    pTable.AddCell(name);
                                }

                            }
                            var cellwidthper = new float[dtSort.Columns.Count];
                            for (int i = 0; i < dtSort.Columns.Count; i++)
                            {
                                cellwidthper[i] = cellwidth[i] / totalwidth * 100;
                            }
                            if (IsLandscape)
                                pTable.SetTotalWidth(cellwidthper);
                            //pTable.SetWidths(cellwidthper);
                            //foreach (DataGridViewColumn col in dv.Columns)

                            //{

                            //    PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                            //    pTable.AddCell(pCell);

                            //}

                            //foreach (DataGridViewRow row in dv.Rows)
                            //{
                            //    foreach (DataGridViewCell dcell in row.Cells)

                            //    {

                            //        if (dcell.Value != null)
                            //        {
                            //            string name = dcell.Value.ToString();
                            //            pTable.AddCell(name);

                            //        }
                            //        else
                            //        {
                            //            pTable.AddCell("");
                            //        }
                            //    }
                            //}

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                //Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                if (IsLandscape)
                                {
                                    Document document = new Document(PageSize.A1.Rotate(), 10f, 10f, 10f, 10f);
                                    document.SetPageSize(PageSize.A1.Rotate());
                                    PdfWriter.GetInstance(document, fileStream);

                                    document.Open();

                                    document.Add(pTable);

                                    document.Close();
                                }
                                else
                                {
                                    Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                                    document.SetPageSize(PageSize.A4);
                                    PdfWriter.GetInstance(document, fileStream);

                                    document.Open();

                                    document.Add(pTable);

                                    document.Close();
                                }

                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }
    }
    public static String TitleCaseString(String s)
    {
        if (s == null) return s;

        String[] words = s.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length == 0) continue;

            Char firstChar = Char.ToUpper(words[i][0]);
            String rest = "";
            if (words[i].Length > 1)
            {
                rest = words[i].Substring(1).ToLower();
            }
            words[i] = firstChar + rest;
        }
        return String.Join(" ", words);
    }
    public static void ImportCSV()
    {
        Stream myStream = null;
        StreamReader reader = null;
        DateTime lastreaddatetime_;
        DataTable tblcsv = new DataTable();
        DataTable importcsvlastread = new DataTable();
        string dms1 = "";
        try
        {
            //Creating object of datatable  
            
            
            //creating columns  
            tblcsv.Columns.Add("PLCDate");
            //tblcsv.Columns.Add("ReadDataDateTime");
            tblcsv.Columns.Add("Customer");
            tblcsv.Columns.Add("ClientName");
            tblcsv.Columns.Add("SiteName");
            tblcsv.Columns.Add("RecipeName");
            tblcsv.Columns.Add("TruckNo");
            tblcsv.Columns.Add("DriverName");
            tblcsv.Columns.Add("BatchSize");
            tblcsv.Columns.Add("BatchNo");
            tblcsv.Columns.Add("SetCycle");
            tblcsv.Columns.Add("Cycle");
            tblcsv.Columns.Add("Bin1Set");
            tblcsv.Columns.Add("Bin1Actual");
            tblcsv.Columns.Add("Bin2Set");
            tblcsv.Columns.Add("Bin2Actual");
            tblcsv.Columns.Add("Bin3Set");
            tblcsv.Columns.Add("Bin3Actual");
            tblcsv.Columns.Add("Bin4Set");
            tblcsv.Columns.Add("Bin4Actual");
            tblcsv.Columns.Add("CementSet");
            tblcsv.Columns.Add("CementActual");
            tblcsv.Columns.Add("FlyashSet");
            tblcsv.Columns.Add("FlyashActual");
            tblcsv.Columns.Add("WaterSet");
            tblcsv.Columns.Add("WaterActual");
            tblcsv.Columns.Add("AdditiveSet");
            tblcsv.Columns.Add("AdditiveActual");
            tblcsv.Columns.Add("TotalActual");
            tblcsv.Columns.Add("SilicaSet");
            tblcsv.Columns.Add("SilicaActual");
            tblcsv.Columns.Add("GGBSSet");
            tblcsv.Columns.Add("GGBSActual");

            importcsvlastread = Functions.GetTableDataBySP("ImportCSVLastRead_Select");
            DateTime lastreaddatetime = Convert.ToDateTime(importcsvlastread.Rows[0][2].ToString());
            int dd = lastreaddatetime.Day;
            int mm = lastreaddatetime.Month;
            int yy = lastreaddatetime.Year;
            //string dms = mm.ToString() + '-' + dd.ToString() + '-' + yy.ToString() + ' ' + lastreaddatetime.ToLongTimeString();
            dms1 = dd.ToString() + '-' + mm.ToString() + '-' + yy.ToString() + ' ' + lastreaddatetime.ToLongTimeString();
            lastreaddatetime_ = Convert.ToDateTime(dms1);
            //MessageBox.Show("Inside import csv");
            //MessageBox.Show("FTP Check");
            FtpWebRequest reqFTP;
            String ftpserver = "ftp://192.168.1.150/DAT0000/SAMPLE/SMP0000.CSV";
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpserver));
            reqFTP.UsePassive = false;
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential("admin", "6982");
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.Proxy = GlobalProxySelection.GetEmptyWebProxy();
            //MessageBox.Show("FTP Check");
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            //MessageBox.Show(response.StatusDescription);
            //MessageBox.Show("FTP Check completed");

            Stream responseStream = response.GetResponseStream();
            reader = new StreamReader(responseStream);
            //MessageBox.Show("get response completed");
            readFromCSV(reader, lastreaddatetime_,tblcsv);
            
        }
        catch (WebException ex)
        {
            /*MessageBox.Show("In Catch");
            MessageBox.Show(ex.Message.ToString());
            MessageBox.Show(ex.Status.ToString());*/
            FtpWebResponse response = (FtpWebResponse)ex.Response;
            if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            {
                MessageBox.Show(ex.Message.ToString(), "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            //if(ex.Status.ToString() == "ConnectFailure")
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    ofd.Multiselect = false;
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        if ((myStream = ofd.OpenFile()) != null)
            //        {
            //            myStream = ofd.OpenFile();
            //            reader = new StreamReader(myStream);
            //            lastreaddatetime_ = Convert.ToDateTime(dms1);
            //            readFromCSV(reader, lastreaddatetime_, tblcsv);
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString(), "Error : ImportCSV", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    public static void ImportCSVManual()
    {
        
        Stream myStream = null;
        StreamReader reader = null;
        DateTime lastreaddatetime_;
        DataTable tblcsv = new DataTable();
        DataTable importcsvlastread = new DataTable();
        string dms1 = "";

        tblcsv.Columns.Add("PLCDate");
        //tblcsv.Columns.Add("ReadDataDateTime");
        tblcsv.Columns.Add("Customer");
        tblcsv.Columns.Add("ClientName");
        tblcsv.Columns.Add("SiteName");
        tblcsv.Columns.Add("RecipeName");
        tblcsv.Columns.Add("TruckNo");
        tblcsv.Columns.Add("DriverName");
        tblcsv.Columns.Add("BatchSize");
        tblcsv.Columns.Add("BatchNo");
        tblcsv.Columns.Add("SetCycle");
        tblcsv.Columns.Add("Cycle");
        tblcsv.Columns.Add("Bin1Set");
        tblcsv.Columns.Add("Bin1Actual");
        tblcsv.Columns.Add("Bin2Set");
        tblcsv.Columns.Add("Bin2Actual");
        tblcsv.Columns.Add("Bin3Set");
        tblcsv.Columns.Add("Bin3Actual");
        tblcsv.Columns.Add("Bin4Set");
        tblcsv.Columns.Add("Bin4Actual");
        tblcsv.Columns.Add("CementSet");
        tblcsv.Columns.Add("CementActual");
        tblcsv.Columns.Add("FlyashSet");
        tblcsv.Columns.Add("FlyashActual");
        tblcsv.Columns.Add("WaterSet");
        tblcsv.Columns.Add("WaterActual");
        tblcsv.Columns.Add("AdditiveSet");
        tblcsv.Columns.Add("AdditiveActual");
        tblcsv.Columns.Add("TotalActual");
        tblcsv.Columns.Add("SilicaSet");
        tblcsv.Columns.Add("SilicaActual");
        tblcsv.Columns.Add("GGBSSet");
        tblcsv.Columns.Add("GGBSActual");

        importcsvlastread = Functions.GetTableDataBySP("ImportCSVLastRead_Select");
        DateTime lastreaddatetime = Convert.ToDateTime(importcsvlastread.Rows[0][2].ToString());
        

        int dd = lastreaddatetime.Day;
        int mm = lastreaddatetime.Month;
        int yy = lastreaddatetime.Year;
        //string dms = mm.ToString() + '-' + dd.ToString() + '-' + yy.ToString() + ' ' + lastreaddatetime.ToLongTimeString();
        dms1 = dd.ToString() + '-' + mm.ToString() + '-' + yy.ToString() + ' ' + lastreaddatetime.ToLongTimeString();
        lastreaddatetime_ = Convert.ToDateTime(dms1);
        
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Multiselect = false;
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            if ((myStream = ofd.OpenFile()) != null)
            {
                myStream = ofd.OpenFile();
                reader = new StreamReader(myStream);
                lastreaddatetime_ = Convert.ToDateTime(dms1);
                readFromCSV(reader, lastreaddatetime_, tblcsv);
            }
        }
    }

    static void readFromCSV(StreamReader reader, DateTime lastreaddatetime_, DataTable tblcsv)
    {
        string[] allLines = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //MessageBox.Show("read completed");
        string readcsvfile = "";
        for (int a = 1; a < allLines.Length; a++)
        {
            readcsvfile = allLines[a].ToString();

            if (readcsvfile != "")
            {
                string[] csvRowArr = readcsvfile.Split(',');
                if (csvRowArr.Length > 0)
                {
                    if (Convert.ToDateTime(csvRowArr[0].ToString()) <= lastreaddatetime_)
                    {
                        continue;
                    }
                    else
                    {

                        //Adding each row into datatable  
                        tblcsv.Rows.Add();
                        int count = 0;
                        foreach (string FileRec in readcsvfile.Split(','))
                        {
                            if (count == 0)
                            {
                                DateTime plcDate = Convert.ToDateTime(FileRec);
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = plcDate.ToString();
                                count++;
                            }
                            else
                            {
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                                count++;
                            }
                        }

                    }
                }
            }
        }

        /*if (allLines.Length > 0)
            MessageBox.Show(allLines.Length.ToString());

        return;

        //getting full file path of Uploaded file  
        //string CSVFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        string CSVFilePath = @"ftp://192.168.1.150//DAT0000//SAMPLE//SMP0000.CSV";
        //Reading All text  
        string ReadCSV = File.ReadAllText(CSVFilePath);

        importcsvlastread = Functions.GetTableDataBySP("ImportCSVLastRead_Select");
        DateTime lastreaddatetime = Convert.ToDateTime(importcsvlastread.Rows[0][2].ToString());
        int dd = lastreaddatetime.Day;
        int mm = lastreaddatetime.Month;
        int yy = lastreaddatetime.Year;
        string dms = mm.ToString() + '-' + dd.ToString() + '-' + yy.ToString() + ' ' + lastreaddatetime.ToLongTimeString();
        DateTime lastreaddatetime_ = Convert.ToDateTime(dms);

        //spliting row after new line  
        foreach (string csvRow in ReadCSV.Split('\n'))
        {
            if (csvRow != "")
            {
                string[] csvRowArr = csvRow.Split(',');
                if (Convert.ToDateTime(csvRowArr[0].ToString()) <= lastreaddatetime_)
                {
                    continue;
                }
                else
                {
                    if (!string.IsNullOrEmpty(csvRow))
                    {
                        //Adding each row into datatable  
                        tblcsv.Rows.Add();
                        int count = 0;
                        foreach (string FileRec in csvRow.Split(','))
                        {
                            if (count == 0)
                            {
                                DateTime plcDate = Convert.ToDateTime(FileRec);
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = plcDate.ToString();
                                count++;
                            }
                            else
                            {
                                tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                                count++;
                            }
                        }
                    }
                }
            }
        }*/

        //Calling insert Functions
        if (tblcsv != null)
        {
            DateTime UpdateDateTime = Convert.ToDateTime(tblcsv.Rows[tblcsv.Rows.Count - 1][0].ToString());
            //string UpdateDateTime_ = (UpdateDateTime.Month.ToString() + '-' + UpdateDateTime.Day.ToString() + '-' +UpdateDateTime.Year.ToString() + ' ' + UpdateDateTime.ToLongTimeString()).ToString();
            string UpdateDateTime_ = UpdateDateTime.ToString();

            bool addFlag = InsertCSVRecords(tblcsv);
            if (addFlag)
            {
                SQLHelper._objCmd = new SqlCommand();
                SQLHelper._objCmd.Parameters.Clear();
                SQLHelper._objCmd.Parameters.AddWithValue("@LastReadDateTime", Convert.ToDateTime(UpdateDateTime_));

                string text3 = Queries.UpdateBySP("ImportCSVLastRead_Update");

                bool flag4 = text3 != "";
                if (flag4)
                {
                    bool flag5 = Functions.DBKeyErrors(text3);
                    bool flag6 = !flag5;
                    if (flag6)
                    {
                        MessageBox.Show(text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                MessageBox.Show("CSV File Imported Successfully");
            }
        }
    }

    static bool InsertCSVRecords(DataTable csvdt)
    {
        bool flag = false;
        try
        {
            int addCount = 0;
            DataTable dataTable = null;
            for (int a = 0; a < csvdt.Rows.Count; a++)
            {
                int csvdtbatchno = Convert.ToInt32(csvdt.Rows[a][8].ToString());
                int csvcycle = Convert.ToInt32(csvdt.Rows[a][10].ToString());

                //dataTable = new DataTable();
                //dataTable = Functions.GetTableDataBySPWithParam("ImportCSVBatchno_Cycle_Select", string.Concat(new string[]
                //        {

                //        "@BatchNo='",
                //        csvdtbatchno.ToString(),
                //        "',@Cycle='",
                //        csvcycle.ToString(),
                //        "'"
                //    }));

                //if (dataTable.Rows.Count == 0 && csvdt.Rows[a][0].ToString().Trim() != "")
                //{
                    SQLHelper._objCmd = new SqlCommand();
                    SQLHelper._objCmd.Parameters.Clear();
                    SQLHelper._objCmd.Parameters.AddWithValue("@PLCDate", Convert.ToDateTime(csvdt.Rows[a][0].ToString()));
                    SQLHelper._objCmd.Parameters.AddWithValue("@Customer", csvdt.Rows[a][1].ToString());
                    SQLHelper._objCmd.Parameters.AddWithValue("@ClientName", csvdt.Rows[a][2].ToString());
                    SQLHelper._objCmd.Parameters.AddWithValue("@SiteName", csvdt.Rows[a][3].ToString());
                    SQLHelper._objCmd.Parameters.AddWithValue("@RecipeName", csvdt.Rows[a][4].ToString());
                    SQLHelper._objCmd.Parameters.AddWithValue("@TruckNo", csvdt.Rows[a][5].ToString());
                    SQLHelper._objCmd.Parameters.AddWithValue("@DriverName", csvdt.Rows[a][6].ToString());
                    SQLHelper._objCmd.Parameters.AddWithValue("@BatchSize", csvdt.Rows[a][7].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][7].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@BatchNo", csvdt.Rows[a][8].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][8].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@SetCycle", csvdt.Rows[a][9].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][9].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Cycle", csvdt.Rows[a][10].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][10].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Set", csvdt.Rows[a][11].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][11].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin1Actual", csvdt.Rows[a][12].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][12].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Set", csvdt.Rows[a][13].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][13].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin2Actual", csvdt.Rows[a][14].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][14].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Set", csvdt.Rows[a][15].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][15].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin3Actual", csvdt.Rows[a][16].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][16].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Set", csvdt.Rows[a][17].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][17].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@Bin4Actual", csvdt.Rows[a][18].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][18].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@CementSet", csvdt.Rows[a][19].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][19].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@CementActual", csvdt.Rows[a][20].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][20].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@FlyashSet", csvdt.Rows[a][21].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][21].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@FlyashActual", csvdt.Rows[a][22].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][22].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@WaterSet", csvdt.Rows[a][23].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][23].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@WaterActual", csvdt.Rows[a][24].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][24].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveSet", csvdt.Rows[a][25].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][25].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@AdditiveActual", csvdt.Rows[a][26].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][26].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@TotalActual", csvdt.Rows[a][27].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][27].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@SilicaSet", csvdt.Rows[a][28].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][28].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@SilicaActual", csvdt.Rows[a][29].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][29].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@GGBSSet", csvdt.Rows[a][30].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][30].ToString()) : 0);
                    SQLHelper._objCmd.Parameters.AddWithValue("@GGBSActual", csvdt.Rows[a][31].ToString().Trim() != "" ? Convert.ToDouble(csvdt.Rows[a][31].ToString()) : 0);


                    string text2 = Queries.InsertBySP("ImportCSVTOPLCData");

                    bool flag1 = text2 != "";
                    if (flag1)
                        MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                        addCount++;
                //}
                //else
                    //addCount++;
            }

            if (addCount == csvdt.Rows.Count)
                flag = true;
            else
                flag = false;

            /*connection();*/
            //creating object of SqlBulkCopy    
            /*SqlBulkCopy objbulk = new SqlBulkCopy(con);*/
            //assigning Destination table name    
            /*objbulk.DestinationTableName = "Employee";*/
            //Mapping Table column    
            /*objbulk.ColumnMappings.Add("Name", "Name");
            objbulk.ColumnMappings.Add("City", "City");
            objbulk.ColumnMappings.Add("Address", "Address");
            objbulk.ColumnMappings.Add("Designation", "Designation");*/
            //inserting Datatable Records to DataBase    
            /*con.Open();
            objbulk.WriteToServer(csvdt);
            con.Close();*/
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString(), "Error : InsertCSVRecords", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        return flag;
    }
}

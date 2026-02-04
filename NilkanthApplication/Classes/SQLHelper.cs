using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

public class SQLHelper
{
    #region Private Static Data Objects

    static private string cnstr = ConfigurationManager.ConnectionStrings["DataConnectionString"].ToString();
    static private SqlConnection _objConn;
    static public SqlCommand _objCmd;
    static private SqlDataAdapter _objDA;
    static private DataTable _objDT;
    static private DataSet _objDS;
    static public SqlTransaction _objTrs;
    static private string _ConnectionString;
    #endregion

    #region Custom Properties And Class Constructor

    static public void WriteErrorLogs(string error)
    {
        StreamWriter sr = null;
        try
        {
            string fileName = Application.StartupPath + "\\ErrorLogs.txt";
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            sr = new StreamWriter(fileName);
            sr.WriteLine(DateTime.Now.ToString() + " Error: " + error);
        }
        catch (Exception ae)
        {
            MessageBox.Show(ae.Message);
        }
        finally
        {
            sr.Close();
            sr.Flush();
        }
    }
    /// <summary>
    /// SQLHelper Class Initialier
    /// </summary>
    public SQLHelper()
    {
        _objDA = new SqlDataAdapter();
        _objDT = new DataTable();
        _objDS = new DataSet();
    }

    /// <summary>
    /// Property To Assign Connection String
    /// </summary>
    static public string ConnectionString
    {
        set { _ConnectionString = value; }
        get { return (_ConnectionString); }
    }
    static public bool CheckConnectivity
    {
        get
        {
            if (_objConn.State != ConnectionState.Closed || _objConn.State != ConnectionState.Broken)
                return (true);
            else
                return (false);
        }
    }
    #endregion

    #region Data Access Functions
    /// <summary>
    /// Open connection with connection string property value.
    /// </summary>
    /// <returns>returns empty string on success, else returns error message.</returns>
    static public string OpenConnection()
    {
        if (_objConn != null)
            if (_objConn.State == ConnectionState.Open)
                return "";
        string strRetVal = _OpenConnection(_ConnectionString);
        return (strRetVal);
    }
    /// <summary>
    /// Close sql connection.
    /// </summary>
    /// <returns>returns empty string on success, else returns error message.</returns>
    static public string CloseConnection()
    {
        try
        {
            if (_objConn.State == ConnectionState.Open)
                _objConn.Close();
            else if (_objConn.State == ConnectionState.Broken)
                return ("Connection has been broken!");
            else if (_objConn.State == ConnectionState.Closed)
                return ("Connection has been already closed!");
            else if (_objConn.State == ConnectionState.Connecting)
                return ("Connection in progress to connect!");
            else if (_objConn.State == ConnectionState.Executing)
                return ("Connection is executing!");
            else if (_objConn.State == ConnectionState.Fetching)
                return ("Connection is fetching records!");
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
        return ("");
    }
    /// <summary>
    /// Execute SQL Query.
    /// </summary>
    /// <returns>returns empty string on success, else returns error message.</returns>
    static public string ExecuteNonQuery()
    {
        bool bManuallyOpened = true;
        try
        {
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bManuallyOpened = false;
            }
            _objCmd.Connection = _objConn;
            int val = _objCmd.ExecuteNonQuery();
            if (_objConn.State == ConnectionState.Open && bManuallyOpened == false)
            {
                CloseConnection();
            }
            if (val > 0)
                return "";
            else
                return "Error";
        }
        catch (Exception Ex)
        {
            return (Ex.Message);
        }
        finally
        {

        }
    }

    static public string ExecuteNonQueryForDelete()
    {
        bool bManuallyOpened = true;
        try
        {
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bManuallyOpened = false;
            }
            _objCmd.Connection = _objConn;
            int val = _objCmd.ExecuteNonQuery();
            if (_objConn.State == ConnectionState.Open && bManuallyOpened == false)
            {
                CloseConnection();
            }
            if (val > 0)
                return "";
            else if (val == 0)
                return "No Records Available";
            else
                return "Error";
        }
        catch (Exception Ex)
        {
            return (Ex.Message);
        }
        finally
        {

        }
    }
    /// <summary>
    /// Execute Scalar Method Overloaded.
    /// </summary>
    /// <returns>returns field value as object</returns>
    public static object ExecuteScalarPassQuery(string strSQLStatement)
    {
        bool bManuallyOpened = true;
        try
        {
            if (string.IsNullOrEmpty(strSQLStatement))
                return (null);
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bManuallyOpened = false;
            }
            if (_objCmd == null)
            {
                _objCmd = new SqlCommand();
            }
            _objCmd.CommandType = CommandType.Text;
            _objCmd.CommandText = strSQLStatement;
            _objCmd.Connection = _objConn;
            object retval = _objCmd.ExecuteScalar();
            if (_objConn.State == ConnectionState.Open && bManuallyOpened == false)
            {
                CloseConnection();
            }

            return retval;
        }
        catch (Exception Ex)
        {
            return (Ex.Message);
        }
        finally
        {
        }
    }


    /// <summary>
    /// Returns data table by sql query supplied.
    /// </summary>
    /// <param name="strSQLStatement">SQL Query</param>
    /// <returns>DataTable Object</returns>
    static public DataTable FetchDataTable(string strSQLStatement)
    {
        bool bConnOpened = true;
        try
        {
            if (string.IsNullOrEmpty(strSQLStatement))
                return (null);
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bConnOpened = false;
            }
            _objDT = new DataTable();
            if (_objCmd == null)
            {
                _objCmd = new SqlCommand();
                _objCmd.Connection = _objConn;
            }
            _objCmd.CommandType = CommandType.Text;
            _objCmd.CommandText = strSQLStatement;
            _objCmd.Connection = _objConn;
            _objDA = new SqlDataAdapter(_objCmd);
            _objDT.Clear();
            _objDA.Fill(_objDT);
            if (_objConn.State == ConnectionState.Open && bConnOpened == false)
                CloseConnection();
            return (_objDT);
        }
        catch (Exception ae)
        {
            WriteErrorLogs(ae.Message);
        }
        finally
        {
            _objDA.Dispose();
        }
        return (null);
    }
    /// <summary>
    /// Returns data table by sql query supplied.
    /// </summary>
    /// <param name="strSQLStatement">SQL Query</param>
    /// <returns>DataTable Object</returns>
    static public DataTable FetchDataTableBySP(string storeProcName, string ParamName, object ParamValue)
    {
        bool bConnOpened = true;
        try
        {
            if (string.IsNullOrEmpty(storeProcName))
                return (null);
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bConnOpened = false;
            }
            _objDT = new DataTable();
            if (_objCmd == null)
            {
                _objCmd = new SqlCommand();
                _objCmd.Connection = _objConn;
            }
            _objCmd.Parameters.Clear();
            if (ParamName.Length > 0 && ParamValue != null)
                _objCmd.Parameters.AddWithValue(ParamName, ParamValue);
            _objCmd.CommandType = CommandType.StoredProcedure;
            _objCmd.CommandText = storeProcName;
            _objDA = new SqlDataAdapter(_objCmd);
            _objDT.Clear();
            _objDA.Fill(_objDT);
            if (_objConn.State == ConnectionState.Open && bConnOpened == false)
                CloseConnection();
            return (_objDT);
        }
        catch (Exception)
        {

        }
        finally
        {
            _objDA.Dispose();
        }
        return (null);
    }

    static public DataTable GetTableBySPWithParam(string storeProcName, string paramString)
    {
        bool bConnOpened = true;
        try
        {
            if (string.IsNullOrEmpty(storeProcName))
                return (null);
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bConnOpened = false;
            }
            _objDT = new DataTable();
            if (_objCmd == null)
            {
                _objCmd = new SqlCommand();
                _objCmd.Connection = _objConn;
                _objCmd.CommandTimeout = 600;
            }
            _objCmd.Parameters.Clear();
            _objCmd.CommandType = CommandType.Text;
            _objCmd.CommandTimeout = 600;
            _objCmd.CommandText = "exec " + storeProcName + " " + paramString;
            _objDA = new SqlDataAdapter(_objCmd);
            _objDT.Clear();
            _objDA.Fill(_objDT);
            if (_objConn.State == ConnectionState.Open && bConnOpened == false)
                CloseConnection();
            return (_objDT);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            _objDA.Dispose();
        }
        return (null);
    }

    static public DataSet GetTablesBySPWithParam(string storeProcName, string paramString)
    {
        bool bConnOpened = true;
        try
        {
            if (string.IsNullOrEmpty(storeProcName))
                return (null);
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bConnOpened = false;
            }
            _objDS = new DataSet();
            if (_objCmd == null)
            {
                _objCmd = new SqlCommand();
                _objCmd.Connection = _objConn;
                _objCmd.CommandTimeout = 600;
            }
            _objCmd.Parameters.Clear();
            _objCmd.CommandType = CommandType.Text;
            _objCmd.CommandTimeout = 600;
            _objCmd.CommandText = "exec " + storeProcName + " " + paramString;
            _objDA = new SqlDataAdapter(_objCmd);
            _objDS.Clear();
            _objDA.Fill(_objDS);
            if (_objConn.State == ConnectionState.Open && bConnOpened == false)
                CloseConnection();
            return (_objDS);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            _objDA.Dispose();
        }
        return (null);
    }
    /// <summary>
    /// Returns DataSet by provided sql query.
    /// </summary>
    /// <param name="strSQLStatement">SQL Query</param>
    /// <returns>DataSet Object</returns>
    static public DataSet FetchDataSet(string strSQLStatement)
    {
        bool bConnOpened = true;
        try
        {
            if (string.IsNullOrEmpty(strSQLStatement))
                return (null);
            if (_objConn == null)
                _objConn = new SqlConnection();
            if (_objConn.State == ConnectionState.Closed)
            {
                OpenConnection();
                bConnOpened = false;
            }
            _objDA = new SqlDataAdapter(strSQLStatement, _objConn);
            _objDS = new DataSet();
            _objDA.Fill(_objDS);
            return (_objDS);
        }
        catch (Exception)
        {

        }
        finally
        {
            if (_objConn.State == ConnectionState.Open && bConnOpened == false)
                CloseConnection();
            _objDA.Dispose();
        }
        return (null);
    }
    #endregion

    #region Generic Data Access Layer Implementation
    /// <summary>
    /// Opens Connection With Provided ConnectionString
    /// </summary>
    /// <param name="strConnectionString">Database Connection String</param>
    /// <returns></returns>
    static private string _OpenConnection(string strConnectionString)
    {
        try
        {
            //cnstr = ConfigurationManager.ConnectionStrings["DataConnectionString2"].ToString();
            if (String.IsNullOrEmpty(strConnectionString))
            {
                if (String.IsNullOrEmpty(_ConnectionString))
                {
                    strConnectionString = cnstr;
                    //strConnectionString = @"Data Source=DESKTOP-JQ88TS0\SQLEXPRESS;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@123;MultipleActiveResultSets=True";
                    //strConnectionString = @"Data Source=DESKTOP-8AAD1VO\SQLEXPRESS;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@123";
                    //strConnectionString = "Data Source=DESKTOP-67VM5ML;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@12345";
                    //strConnectionString = @"Data Source=DESKTOP-G11RM2O\SQLEXPRESS;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@123";
                    //strConnectionString = @"Data Source=DESKTOP-OMBFLQC\SQLEXPRESS;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@123";
                    //strConnectionString = @"Data Source=DHAVAL\SQLEXPRESS;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@123;TrustServerCertificate=True";
                    //strConnectionString = @"Data Source=DESKTOP-TN7I561\SQLEXPRESS;Initial Catalog=NilkanthApplicationDB;Persist Security Info=True;User ID=sa;Password=sa@123;TrustServerCertificate=True";
                }
                else
                    strConnectionString = _ConnectionString;
            }
            if (String.IsNullOrEmpty(strConnectionString))
            {
                return ("Invalid ConnectionString!");
            }
            if (_objConn == null)
                _objConn = new SqlConnection(strConnectionString);
            else
                _objConn.ConnectionString = strConnectionString;

            //to check error if connection is open then dont open it again.
            //specially in case of transaction.
            //if (_objConn.State == ConnectionState.Open)
            //CloseConnection();

            if (_objConn.State != ConnectionState.Open)
                _objConn.Open();

            return ("");
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }
    }

    #endregion

}

using System;
using System.Data;
using System.Net;
using System.Net.Sockets;

public class Queries : SQLHelper
{
    static private int UID;
    static private string UName;
    static private string accessLevel;
    static private string WBName;
    static private DataTable dt;

    static public int UserID
    {
        get { return (UID); }
        set { UID = value; }
    }
    static public string UserName
    {
        get { return (UName); }
        set { UName = value; }
    }
    static public string WeighBridgeName
    {
        get { return (WBName); }
        set { WBName = value; }
    }
    static public string AccessLevel
    {
        get { return (accessLevel); }
        set { accessLevel = value; }
    }

    //static public DataTable AccessDT
    //{
    //    get { return (AccessDT); }
    //    set { AccessDT = value; }
    //}
    static public DataTable AccessDT
    {
        get { return (dt); }
        set { dt = value; }
    }

    public Queries()
    {

    }
    static public string InsertBySP(string spname)
    {
        try
        {
            _objCmd.CommandType = CommandType.StoredProcedure;
            _objCmd.CommandText = spname;
            string retVal = SQLHelper.ExecuteNonQuery();
            if (retVal == "")
            {
                return "";
            }
            else
            {
                return retVal;
            }
        }
        catch (Exception Ex)
        {
            return (Ex.Message);
        }
    }

    static public string UpdateBySP(string spname)
    {
        try
        {
            _objCmd.CommandType = CommandType.StoredProcedure;
            _objCmd.CommandText = spname;
            string retVal = SQLHelper.ExecuteNonQuery();
            if (retVal == "")
            {
                return "";
            }
            else
            {
                return retVal;
            }
        }
        catch (Exception Ex)
        {
            return (Ex.Message);
        }
    }

    static public string DeleteBySP(string spname)
    {
        try
        {
            _objCmd.CommandType = CommandType.StoredProcedure;
            _objCmd.CommandText = spname;
            string retVal = SQLHelper.ExecuteNonQueryForDelete();
            if (retVal == "")
            {
                return "";
            }
            else
            {
                return retVal;
            }
        }
        catch (Exception Ex)
        {
            return (Ex.Message);
        }
    }
}


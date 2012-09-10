using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for DB_Connect
/// </summary>
public class DB_Connect
{
    public DB_Connect()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public static OdbcDataAdapter ExecuteQuery(String sql)
    {

        OdbcConnection con = new OdbcConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["nsis"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        //  SqlDataAdapter adp = new SqlDataAdapter("select DISTINCT CLASS_CODE * from student_class", con);
        OdbcDataAdapter adp = new OdbcDataAdapter(sql, con);

        return adp;
    }

    public static bool InsertQuery(String sql) {
        OdbcConnection con = new OdbcConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["nsis"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

        OdbcCommand cmd = con.CreateCommand();

        cmd.CommandText = sql;

        int result = cmd.ExecuteNonQuery();

        if (result == 1)
            return true;
        else
            return false;

    
    }

}

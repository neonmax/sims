<%@ WebHandler Language="C#" Class="stdImg" %>

using System;
using System.Web;

public class stdImg : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {


        System.Data.Odbc.OdbcConnection con = new System.Data.Odbc.OdbcConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["nsis"].ConnectionString;

        con.Open();
        System.Data.Odbc.OdbcCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT PHOTOGRAPH FROM PHOTOGRAPH_ALBUM WHERE ADMISSION_NO='" + context.Request["id"] + "' AND PID='" + context.Request["pid"] + "'";
    
        byte[] buf = (byte[])cmd.ExecuteScalar();

        context.Response.Clear();
        // context.Response.OutputStream.Write(buf, 0, buf.Length);
        context.Response.ContentType = "image/jpeg";
        context.Response.BinaryWrite(buf);
        context.Response.Flush();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
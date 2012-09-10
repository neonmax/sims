using System;
using System.Data;
using System.Configuration;
using System.Data.Odbc;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for DBConnect
/// </summary>
public class DBConnect
{
    string path = "Dsn=nsis;uid=root;pwd=123";
    static OdbcConnection connection;

    public DBConnect()
    {
        OdbcConnection con = new OdbcConnection(path);
        connection = con;
    }

    public OdbcConnection getconnection()
    {
        return connection;
    }
    public void close()
    {
        connection.Close();

    }
}

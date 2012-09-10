using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Odbc;

/// <summary>
/// Summary description for DBConnect
/// </summary>
public class DBConnect
{
    string path = "Dsn=Heshan_ODBC;uid=root;pwd=HESHAN";
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

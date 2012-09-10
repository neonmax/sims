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
        /// Utility is the place which hold implimentation of
        /// all functions
/// </summary>
public class Utility
{
	public Utility()
	{
	}

    public string checkLoggin(string userName, string passWord)
    {
        //assigning username to variable
        string username = userName;

        string UserLevel="";

        //assigning encripted password form text box & Encript
        Encriptor enc = new Encriptor();
        string password = enc.encript(passWord);
        
        // encripted one


        OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT USER_USERNAME, ROLE_CODE FROM users_mast WHERE USER_USERNAME ='" + username + "' AND USER_PASSWORD = '" + password + "'");

        adpNameList.SelectCommand.CommandType = CommandType.Text;
        DataSet userList = new DataSet();
        adpNameList.Fill(userList);

        if (userList.Tables[0].Rows.Count == 1)
        {
            
            
            
            Console.Beep();
            for (int i = 0; i < userList.Tables[0].Rows.Count; i++)
            {
               

                //get the user level from DB according to user name
                UserLevel = userList.Tables[0].Rows[i][1].ToString();
                
                
            }

        }
        else
        {
            UserLevel = "error";
        }

        return UserLevel;
    }

    
}

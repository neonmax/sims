using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //checking for empty session field
        if (Session["user"] == null)
        {
            Response.Redirect("../Common_Home.aspx");//go to common home page
        }
        else
        {
          //  txtUsername.Text = Session["user"].ToString();//assign session variable value to text field
        }
    
    }
}

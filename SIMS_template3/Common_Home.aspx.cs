using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //clear session variables
        Session["user"] = "";
        Session["userLevel"] = "";

    }
    protected void btnSignin_Click(object sender, ImageClickEventArgs e)
    {
        ////assign session value
        //Session["user"] = txtUser.Text;

        ////fill variable
        //string user = Session["user"].ToString();

        //if (txtUser.Text == "admin" || txtUser.Text == "school" || txtUser.Text == "parent")
        //{            
        //    Response.Redirect("~/Logged_Pages/Home.aspx");
        //}


        //-------------------------------------------------------
        //create object Utility class
        Utility utl = new Utility();

        //get user level after compair passwords
        string userLevel=utl.checkLoggin(txtUser.Text, txtPass.Text);
        

        if (userLevel != "error")
         {
            //assign user level to the session
             Session["userLevel"] = userLevel;
            
             //assign session value
             Session["user"] = txtUser.Text;

            //go to Logged home page
             Response.Redirect("~/Logged_Pages/Home.aspx");
         }
       
    }
}

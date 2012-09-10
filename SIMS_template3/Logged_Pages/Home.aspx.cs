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
        //checking for empty session field
        if (Session["user"] == null)
        //go to common home page
            Response.Redirect("../Common_Home.aspx");

        //assign session variable value to text field
            txtUser.Text = Session["user"].ToString();

        string user = Session["user"].ToString();
        //select the home page regarding to the user level
        switch (user)
        {
        //call adminFront user controller to current page panel
            case "admin":
                UserCategoryFunctions.Controls.Add(LoadControl("~/AdminFront.ascx"));
                break;
        //call SchoolAdmin user controller to current page panel
            case "school":
                UserCategoryFunctions.Controls.Add(LoadControl("~/SchoolAdmin.ascx"));
                break;
        //call Parent_Student user controller to current page panel
            default:
                UserCategoryFunctions.Controls.Add(LoadControl("~/Parent_Student.ascx"));
                break;
        }




    }



}

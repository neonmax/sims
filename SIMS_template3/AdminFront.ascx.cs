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

public partial class AdminFront : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnStd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("StudentHome.aspx");
    }
    protected void btnPrnt_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Parents_Home.aspx");
    }
    protected void btnAck_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Academic_Home.aspx");
    }
    protected void btnNonAck_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Non_Academic_Home.aspx");
    }
    protected void btnPro_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Profile.aspx");
    }
}

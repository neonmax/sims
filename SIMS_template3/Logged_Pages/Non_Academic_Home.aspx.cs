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

public partial class Academic_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Text = Session["user"].ToString();

        string user = Session["user"].ToString();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("./ANon_Academic_Reports/Charts/Charts.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./ANon_Academic_Reports/Charts/Charts.aspx");
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./ANon_Academic_Reports/Activity_Log/ActivityLog.aspx");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./ANon_Academic_Reports/character/Character.aspx");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./ANon_Academic_Reports/EventManagement/EventMng.aspx");
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./ANon_Academic_Reports/StudentWarning/StdWarning.aspx");
    }
}

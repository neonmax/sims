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

public partial class Parents_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Text = Session["user"].ToString();

        string user = Session["user"].ToString();
    }
    protected void imbParntDetails_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AParents_Reports/ParentDetails.aspx");
    }
    protected void imbParentCat_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AParents_Reports/parentCategory.aspx");
    }
}

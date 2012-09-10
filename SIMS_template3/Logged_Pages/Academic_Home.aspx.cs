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

    }

    protected void imbProgressReports_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/ProgressReports.aspx");
    }
    protected void imbPrizeWinners_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void btnBestPerformance_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/BestPerformance.aspx");
    }

    protected void imbExamResultSheets_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/GovExamRstSheet.aspx");
    }
    protected void imbEvent_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/PhotoGallery.aspx");
    }
    protected void imbExamResultAnalysis_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/GenExamRstSheet.aspx");
    }
    protected void imbGovExamProgress_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void imbGenAcaProgress_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/GeneralPerformance.aspx");
    }

    protected void imbAddMedical_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/AddMedicalDetails.aspx");
    }
    protected void imbViewMedical_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Academic_Reports/ViewMedicalDetails.aspx");
    }
}

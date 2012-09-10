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
using System.Data.Odbc;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //txtUser.Text = Session["user"].ToString();

        //Create report document
        ReportDocument crystalReport = new ReportDocument();

        //Load crystal report made in design view
        crystalReport.Load(Server.MapPath("Reports/ParentCategory.rpt"));

        //Set DataBase Login Info
        crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

        crvReportViewer.ReportSource = crystalReport;
    }
  
}

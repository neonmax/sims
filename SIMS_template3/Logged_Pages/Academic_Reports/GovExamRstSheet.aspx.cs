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
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExamination.SelectedIndex < 1)   //if invalid index is selected
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select a Valid Examination";    //error message
        }
        else if (ddlYear.SelectedIndex < 1) //if invalid index is selected
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select a Valid Year";   //error message
        }
        else
        {
            lblError.Text = ""; //Remove the error
            GenerateALReport();
        }

    }


    public void GenerateALReport()
    {    //method to generate the report

        String ReportFile = "";

        if (ddlExamination.SelectedIndex == 1)  //select the appropciate report file
            ReportFile = "Reports/ALResultSheet.rpt";
        else if (ddlExamination.SelectedIndex == 2)
            ReportFile = "Reports/OLResultSheet.rpt";

        //Create report document
        ReportDocument crystalReport = new ReportDocument();

        //Load crystal report made in design view
        crystalReport.Load(Server.MapPath(ReportFile));

        //Set DataBase Login Info
        crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

        //Provide parameter values
        crystalReport.SetParameterValue("year", int.Parse(ddlYear.SelectedValue.ToString()));

        //Set Report in to Report Viewer
        crvReportViewer.ReportSource = crystalReport;
    }
}
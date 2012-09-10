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
        if (ddlExamination.SelectedIndex < 1)   //If no Examination selected 
        {
            lblError.ForeColor = Color.Red; //Change the label color
            lblError.Text = "Please Select a Valid Examination";    //error message
        }
        else if (ddlYear.SelectedIndex < 1) //If no Year selected 
        {
            lblError.ForeColor = Color.Red; //Change the label color
            lblError.Text = "Please Select a Valid Year";   //error message
        }
        else
        {
            lblError.Text = "";     //When error is corrected remove the error
            GenerateALReport();
        }

    }


    public void GenerateALReport()  //methid to generate the report
    {

        if (ddlExamination.SelectedIndex == 1)  //If AL is selected
        {
            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/GenALResults.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            ////Provide parameter values
            crystalReport.SetParameterValue("year", ddlYear.SelectedValue.ToString());

            //Set Report in to Report Viewer
            crvReportViewer.ReportSource = crystalReport;
        }
        else if (ddlExamination.SelectedIndex == 2) //if ol is selected
        {
            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/GenOLResults.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            ////Provide parameter values
            crystalReport.SetParameterValue("year", ddlYear.SelectedValue.ToString());

            //Set Report in to Report Viewer
            crvReportViewer.ReportSource = crystalReport;
        }

    }
}
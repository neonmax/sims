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
        GenerateReport();
    }

    protected void GenerateReport()
    {
        //If Required Fields is not Selected Display Error
        if (ddlExamination.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;   //Change Label Color
            lblError.Text = "Please Select a Valid Examination";  //Set Error
        }
        else if (ddlYear.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select a Valid Year";
        }
        else
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            if (ddlExamination.SelectedIndex != -1)
            {
                //Create report document
                ReportDocument crystalReport = new ReportDocument();

                if (ddlExamination.SelectedIndex == 1)
                {
                    //Load crystal report made in design view
                    crystalReport.Load(Server.MapPath("Reports/ViewMedicalAL.rpt"));
                }
                else if (ddlExamination.SelectedIndex == 2)
                {
                    crystalReport.Load(Server.MapPath("Reports/ViewMedicalOL.rpt"));
                }
                //Set DataBase Login Info
                crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                //Provide parameter values
                crystalReport.SetParameterValue("year", int.Parse(ddlYear.SelectedValue.ToString()));

                //Set Report in to Report Viewer
                crvReportViewer.ReportSource = crystalReport;
            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please Provide Valid Details";
            }
        }
    }
}

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
using CrystalDecisions.Shared;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //If Required Fields is not Selected Display Error
        if (ddlCategory.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;   //Change Label Color
            lblError.Text = "Please Select a Valid Category";  //Set Error
        }
        else if (ddlYear.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select a Valid Year";
        }
        else
        {
            lblError.Text = "";  //After Fixing error hide the Error Message


            if (ddlCategory.SelectedIndex == 1)
            {              

                //Create report document
                ReportDocument crystalReport = new ReportDocument();

                //Load crystal report made in design view
                crystalReport.Load(Server.MapPath("Reports/StudentAdmissionReport.rpt"));

                //Set DataBase Login Info
                crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                //Provide parameter values
                crystalReport.SetParameterValue("year", int.Parse(ddlYear.SelectedValue.ToString()));

                //Set Report in to Report Viewer
                crvReportViewer.ReportSource = crystalReport;
            }

            else if (ddlCategory.SelectedIndex == 2)
            {
                //Create report document
                ReportDocument crystalReport = new ReportDocument();

                //Load crystal report made in design view
                crystalReport.Load(Server.MapPath("Reports/StudentLeavingReport.rpt"));

                //Set DataBase Login Info
                crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                //Provide parameter values
                crystalReport.SetParameterValue("year", int.Parse(ddlYear.SelectedValue.ToString()));
                crvReportViewer.ReportSource = crystalReport;
            }

            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please Provide Valid Details";
            }
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;   //Change Label Color
            lblError.Text = "Please Select a Valid Category";  //Set Error
        }
        else {
            lblError.Text = "";
        }
    }
    protected void crvReportViewer_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
    {
        ParameterDiscreteValue objDiscreteValue;
        ParameterField objParameterField;

        objDiscreteValue = new ParameterDiscreteValue();
        objDiscreteValue.Value = int.Parse(ddlYear.SelectedValue.ToString());
        objParameterField = crvReportViewer.ParameterFieldInfo["year"];
        objParameterField.CurrentValues.Add(objDiscreteValue);
        crvReportViewer.ParameterFieldInfo.Add(objParameterField);
    }
}
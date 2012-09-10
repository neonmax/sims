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
using System.Data.Odbc;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblClass.Visible = true;
        ddlClass.Visible = true;

        //If no Grade is Selected.
        if (ddlGrade.SelectedIndex != -1)
        {
            ddlClass.Items.Clear();     //Clear the excisting Items
            ddlClass.Items.Add(new ListItem("Select Class", "Empty"));      //Add Empty Item
            //Execute Query and 
            OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT DISTINCT CLASS_CODE FROM student_class WHERE SC_GRADE='" + ddlGrade.SelectedValue + "'");
            adpClassList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsClassList = new DataSet();
            adpClassList.Fill(dsClassList);
            if (dsClassList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstClassList = new ListItem();
                    lstClassList.Value = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    lstClassList.Text = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    ddlClass.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();

        }
    }

    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        if (ddlClass.SelectedIndex != -1)
        {
            lblCategory.Visible = true;
            ddlCategory.Visible = true;
        }
        else
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please select a class!";
        }

    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex != -1)
        {
        
            GenerateReport();
        }
        else 
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please select a Category!";
        }
    }

    protected void GenerateReport()
    {
        if (ddlCategory.SelectedIndex == 1)
        {

            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/ReligionwiseReport.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            // Provide parameter values
            crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
            crystalReport.SetParameterValue("class", ddlClass.SelectedValue.ToString());

            //Set Report in to Report Viewer
            crvReportViewer.ReportSource = crystalReport;

        }
        else if (ddlCategory.SelectedIndex == 2)
        {
            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/Method_of_Travel_Report.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            // Provide parameter values
            crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
            crystalReport.SetParameterValue("class", ddlClass.SelectedValue.ToString());

            //Set Report in to Report Viewer
            crvReportViewer.ReportSource = crystalReport;

        }
        else if (ddlCategory.SelectedIndex == 3)
        {
            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/Nationality_Report.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            // Provide parameter values
            crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
            crystalReport.SetParameterValue("class", ddlClass.SelectedValue.ToString());

            //Set Report in to Report Viewer
            crvReportViewer.ReportSource = crystalReport;
        }
        else if (ddlCategory.SelectedIndex == 4)
        {
            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/Gender_Report.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            // Provide parameter values
            crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
            crystalReport.SetParameterValue("class", ddlClass.SelectedValue.ToString());

            //Set Report in to Report Viewer
            crvReportViewer.ReportSource = crystalReport;
        }

    }

}
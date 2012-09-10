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
using CrystalDecisions.Shared;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void GenerateReport()
    {

        if (ddlCategoryList.SelectedIndex == 1)
        {
            if (ddlGrade.SelectedIndex > 0)
            {
                lblError.Text = "";

                //  Create report document
                ReportDocument crystalReport = new ReportDocument();

                //Load crystal report made in design view
                crystalReport.Load(Server.MapPath("Reports/Gradewise_Report.rpt"));

                //Set DataBase Login Info
                crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                //Provide parameter values
                crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
                crvReportViewer.ReportSource = crystalReport;

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "select a Grade";
            }

        }
        if (ddlCategoryList.SelectedIndex == 2)
        {

            if (ddlGrade.SelectedIndex > 0)
            {
                lblError.Text = "";

                if (ddlCategory.SelectedIndex > 0)
                {
                    lblError.Text = "";

                    //Create report document
                    ReportDocument crystalReport = new ReportDocument();

                    //Load crystal report made in design view
                    crystalReport.Load(Server.MapPath("Reports/Classwise_Report.rpt"));

                    // Set DataBase Login Info
                    crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                    // Provide parameter values
                    crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
                    crystalReport.SetParameterValue("class", ddlCategory.SelectedValue.ToString());

                    //Set Report in to Report Viewer
                    crvReportViewer.ReportSource = crystalReport;

                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "select a Class";
                }

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "select a Grade";
            }
        }

        if (ddlCategoryList.SelectedIndex == 3)
        {

            if (ddlGrade.SelectedIndex > 0)
            {
                lblError.Text = "";

                if (ddlCategory.SelectedIndex > 0)
                {
                    lblError.Text = "";

                    //Create report document
                    ReportDocument crystalReport = new ReportDocument();

                    //Load crystal report made in design view
                    crystalReport.Load(Server.MapPath("Reports/Subjectwise_Report.rpt"));

                    // Set DataBase Login Info
                    crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                    // Provide parameter values
                    crystalReport.SetParameterValue("grade", int.Parse(ddlGrade.SelectedValue.ToString()));
                    crystalReport.SetParameterValue("subject", ddlCategory.SelectedValue.ToString());

                    //Set Report in to Report Viewer
                    crvReportViewer.ReportSource = crystalReport;

                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "select a Subject";
                }

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "select a Grade";
            }

        }


    }

    protected void ddlCategoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //If Required Fields is not Selected Display Error
        if (ddlCategoryList.SelectedIndex < 1)
        {

            lblError.ForeColor = Color.Red;   //Change Label Color
            lblError.Text = "Please Select a Valid Category";  //Set Error

        }


        else if (ddlCategoryList.SelectedIndex == 1)
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            lblGrade.Visible = true;
            lblGrade.Text = "Grade";

            ddlGrade.Visible = true;
            ddlGrade.Items.Add(new ListItem("Select Grade", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlGrade.Items.Add(GradeList);
            }

        }

        else if (ddlCategoryList.SelectedIndex == 2)
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            lblGrade.Visible = true;
            lblGrade.Text = "Grade";

            ddlGrade.Visible = true;
            ddlGrade.Items.Clear();     //Clear the excisting Items
            ddlGrade.Items.Add(new ListItem("Select Grade", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlGrade.Items.Add(GradeList);
            }


        }
        else if (ddlCategoryList.SelectedIndex == 3)
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            lblGrade.Visible = true;
            lblGrade.Text = "Grade";

            ddlGrade.Visible = true;
            ddlGrade.Items.Clear();     //Clear the excisting Items
            ddlGrade.Items.Add(new ListItem("Select Grade", "Empty"));
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlGrade.Items.Add(GradeList);
            }

        }

        else
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            if (ddlGrade.SelectedIndex == 1) { }
        }

    }

    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategoryList.SelectedIndex == 1)
        {
            GenerateReport();
        }

        if (ddlCategoryList.SelectedIndex == 2)
        {
            lblCategory.Visible = true;
            lblCategory.Text = "Class";
            ddlCategory.Visible = true;


            ddlCategory.Items.Clear();     //Clear the excisting Items
            ddlCategory.Items.Add(new ListItem("Select Class", "Empty"));      //Add Empty Item
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
                    ddlCategory.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();
        }


        if (ddlCategoryList.SelectedIndex == 3)
        {
            lblCategory.Visible = true;
            lblCategory.Text = "Subject";
            ddlCategory.Visible = true;


            ddlCategory.Items.Clear();     //Clear the excisting Items
            ddlCategory.Items.Add(new ListItem("Select Subject", "Empty"));      //Add Empty Item
            //Execute Query and 
            OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT SUBJECT FROM subjects_mast WHERE GRADE_" + ddlGrade.SelectedIndex + " = 1");
            adpClassList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsClassList = new DataSet();
            adpClassList.Fill(dsClassList);
            if (dsClassList.Tables[0].Rows.Count > 0)
            {
                Console.Beep();
                for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstClassList = new ListItem();
                    lstClassList.Value = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    lstClassList.Text = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    ddlCategory.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();
        }

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        GenerateReport();

    }
    protected void crvReportViewer_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {
        if (ddlCategoryList.SelectedIndex == 1)
        {
            if (ddlGrade.SelectedIndex > 0)
            {
                ParameterDiscreteValue objDiscreteValue;
                ParameterField objParameterField;

                objDiscreteValue = new ParameterDiscreteValue();
                objDiscreteValue.Value = int.Parse(ddlGrade.SelectedValue.ToString());
                objParameterField = crvReportViewer.ParameterFieldInfo["grade"];
                objParameterField.CurrentValues.Add(objDiscreteValue);
                crvReportViewer.ParameterFieldInfo.Add(objParameterField);


            }


        }
        if (ddlCategoryList.SelectedIndex == 2)
        {
            if (ddlGrade.SelectedIndex > 0)
            {
                if (ddlCategory.SelectedIndex > 0)
                {
                    ParameterDiscreteValue objDiscreteValue, objDiscreteValue2;
                    ParameterField objParameterField, objParameterField2;

                    objDiscreteValue = new ParameterDiscreteValue();
                    objDiscreteValue.Value = int.Parse(ddlGrade.SelectedValue.ToString());
                    objParameterField = crvReportViewer.ParameterFieldInfo["grade"];
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    crvReportViewer.ParameterFieldInfo.Add(objParameterField);

                    objDiscreteValue2 = new ParameterDiscreteValue();
                    objDiscreteValue2.Value = ddlCategory.SelectedValue.ToString();
                    objParameterField2 = crvReportViewer.ParameterFieldInfo["class"];
                    objParameterField2.CurrentValues.Add(objDiscreteValue2);
                    crvReportViewer.ParameterFieldInfo.Add(objParameterField2);

                }

            }


        }
    }
}
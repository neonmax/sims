﻿using System;
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
    static String adNo;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        //If No Items Selected
        if (ddlGrade.SelectedIndex != -1)
        {
            ddlClass.Items.Add(new ListItem("Select Class", "Empty"));
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
            ddlStudentName.Items.Clear();
            ddlStudentName.Items.Add(new ListItem("Select Student", "empty"));
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT `NAME_INITIALS` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + ddlGrade.SelectedIndex + "' AND SC.CLASS_CODE = '" + ddlClass.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstNameList = new ListItem();
                    lstNameList.Value = dsNameList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    lstNameList.Text = dsNameList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset                   
                    ddlStudentName.Items.Add(lstNameList);
                }
            }
            dsNameList.Dispose();
        }

    }
    protected void ddlStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStudentName.SelectedIndex != -1)
        {
            OdbcDataAdapter adpAdNoList = DB_Connect.ExecuteQuery("SELECT S.`ADMISSION_NO` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + ddlGrade.SelectedIndex + "' AND S.NAME_INITIALS='" + ddlStudentName.SelectedValue + "'AND SC.CLASS_CODE = '" + ddlClass.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpAdNoList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsAdNoList = new DataSet();
            adpAdNoList.Fill(dsAdNoList);
            adNo = dsAdNoList.Tables[0].Rows[0][0].ToString();
            dsAdNoList.Dispose();
        }
    }

    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select Grade";
        }
        else if (ddlClass.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select Class";
        }
        else if (ddlStudentName.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select Student";
        }
        else if (ddlTerm.SelectedIndex == 0)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = "Please Select Term";
        }
        else
        {
            lblError.Text = "";  //if error Fixed remove error Messege

            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/StudentAcaPerf.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            //Provide parameter values
            crystalReport.SetParameterValue("adno", adNo);
            crystalReport.SetParameterValue("grade", ddlGrade.SelectedIndex);
            crystalReport.SetParameterValue("term", ddlTerm.SelectedIndex);
            crvReportViewer.ReportSource = crystalReport;
        }

    }
}

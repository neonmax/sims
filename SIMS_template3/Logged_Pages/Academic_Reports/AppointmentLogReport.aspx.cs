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
using DeepASP.JQueryPromptuTest;


public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void MedDateCal_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtSelectedDate = MedDateCal.SelectedDate;
        txtDate.Text = String.Format("{0:M/dd/yyyy}", dtSelectedDate);
    }


    protected void MedDateCal1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtSelectedDate = MedDateCal1.SelectedDate;
        txtDate1.Text = String.Format("{0:M/dd/yyyy}", dtSelectedDate);

        GenerateReport();
    }

  

    private void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();

            ClearInputs(ctrl.Controls);
        }
    }

    protected void txtDate1_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void GenerateReport()
    {
        System.Console.Beep();
          
           
                //Create report document
                ReportDocument crystalReport = new ReportDocument();

                if (txtDate.Text != "" && txtDate1.Text != "" )
                {
                    //Load crystal report made in design view
                    crystalReport.Load(Server.MapPath("Reports/Appointment.rpt"));
                
                
                //Set DataBase Login Info
                crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

                //Provide parameter values
                crystalReport.SetParameterValue("start", txtDate.Text.ToString());
                crystalReport.SetParameterValue("end", txtDate1.Text.ToString());


                //Set Report in to Report Viewer
                crvReportViewer.ReportSource = crystalReport;
            }
            else
            {
               // lblError.ForeColor = Color.Red;
               // lblError.Text = "Please Provide Valid Details";
            }
        }
    }

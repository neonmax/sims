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
using CrystalDecisions.Shared;


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
            ddlClass.Items.Clear();
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

            ParameterDiscreteValue crtparamDiscValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            crtparamDiscValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();

            crtparamDiscValue.Value = adNo;
            crtParamField.ParameterFieldName = "adno";
            crtParamField.CurrentValues.Add(crtparamDiscValue);
            crtParamFields.Add(crtParamField);


            crtparamDiscValue.Value = ddlGrade.SelectedIndex;
            crtParamField.ParameterFieldName = "grade";
            crtParamField.CurrentValues.Add(crtparamDiscValue);
            crtParamFields.Add(crtParamField);

            crtparamDiscValue.Value = ddlTerm.SelectedIndex;
            crtParamField.ParameterFieldName = "term";
            crtParamField.CurrentValues.Add(crtparamDiscValue);
            crtParamFields.Add(crtParamField);


            crtparamDiscValue.Value = ddlClass.SelectedValue;
            crtParamField.ParameterFieldName = "class";
            crtParamField.CurrentValues.Add(crtparamDiscValue);
            crtParamFields.Add(crtParamField);



            crvReportViewer.ParameterFieldInfo = crtParamFields;

            //Create report document
            ReportDocument crystalReport = new ReportDocument();

            //Load crystal report made in design view
            crystalReport.Load(Server.MapPath("Reports/NewStudentAcaPerf.rpt"));

            //Set DataBase Login Info
            crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

            //Provide parameter values
            crystalReport.SetParameterValue("adno", adNo);
            crystalReport.SetParameterValue("grade", ddlGrade.SelectedIndex);
            crystalReport.SetParameterValue("term", ddlTerm.SelectedIndex);
            crystalReport.SetParameterValue("class", ddlClass.SelectedIndex);
            crystalReport.SetParameterValue("padno", adNo);
            crystalReport.SetParameterValue("pgrade", ddlGrade.SelectedIndex);
            crystalReport.SetParameterValue("pterm", ddlTerm.SelectedIndex);
            crystalReport.SetParameterValue("pclass", ddlClass.SelectedValue);
            crystalReport.SetParameterValue("mgrade", ddlGrade.SelectedIndex);
            crystalReport.SetParameterValue("mterm", ddlTerm.SelectedIndex);
            crystalReport.SetParameterValue("mclass", ddlClass.SelectedValue);

          

            //Guid.NewGuid().ToString()
            string filename = System.IO.Path.GetTempPath() + adNo + ".pdf";
            crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, filename);
           
            crvReportViewer.ReportSource = crystalReport;
        }

    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {

    }
}

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

    static String adNo;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
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
        //If no Grade is Selected.
        if (ddlClass.SelectedIndex != -1)
        {
            ddlStudent.Items.Clear();
            ddlStudent.Items.Add(new ListItem("Select Student", "empty"));
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
                    ddlStudent.Items.Add(lstNameList);
                }
            }
            dsNameList.Dispose();
        }

    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStudent.SelectedIndex != -1)
        {
            OdbcDataAdapter adpAdNoList = DB_Connect.ExecuteQuery("SELECT S.`ADMISSION_NO` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + ddlGrade.SelectedIndex + "' AND S.NAME_INITIALS='" + ddlStudent.SelectedValue + "'AND SC.CLASS_CODE = '" + ddlClass.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpAdNoList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsAdNoList = new DataSet();
            adpAdNoList.Fill(dsAdNoList);
            adNo = dsAdNoList.Tables[0].Rows[0][0].ToString();
            txtAdNo.Text = adNo;
            dsAdNoList.Dispose();


        }
    }


    protected void ddlExamination_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExamination.SelectedIndex != -1)
        {

            String Exam = "";

            if (ddlExamination.SelectedIndex == 1)
                Exam = "A_LEVEL";
            else if (ddlExamination.SelectedIndex == 2)
                Exam = "O_LEVEL";

            ddlSubject.Items.Clear();
            ddlSubject.Items.Add(new ListItem("Select Subject", "empty"));
            OdbcDataAdapter adpSubjectList = DB_Connect.ExecuteQuery("SELECT SUBJECT,SUBJECT_CODE FROM subjects_mast WHERE " + Exam + "=1");
            adpSubjectList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsSubjectList = new DataSet();
            adpSubjectList.Fill(dsSubjectList);
            if (dsSubjectList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSubjectList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstSubjectList = new ListItem();
                    lstSubjectList.Value = dsSubjectList.Tables[0].Rows[i][1].ToString(); // or your index which is correct in your dataset
                    lstSubjectList.Text = dsSubjectList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset                   
                    ddlSubject.Items.Add(lstSubjectList);
                }
            }
            dsSubjectList.Dispose();
        }
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubject.SelectedIndex > 0)
            txtSubCode.Text = ddlSubject.SelectedValue.ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        lblError.ForeColor = Color.Red;
        lblError.Text = "";

        if (txtAdNo.Text == null || txtAdNo.Text.ToString().Length <= 0)
        {

            lblError.Text = "Please fill Admission Number.";
            CustomException ex = new CustomException("Success !!!", "Record Inserted Successfully.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
        else if (ddlExamination.SelectedIndex <= 0 || ddlYear.SelectedIndex <= 0)
        {
            lblError.Text = "Please select an Examination and Year.";
        }
        else if (txtSubCode.Text == null || txtSubCode.Text.ToString().Length <= 0)
        {
            lblError.Text = "Please fill Subject Code.";
        }
        else if (MedDateCal.SelectedDate == null || MedDateCal.SelectedDate.ToString().Length <= 0)
        {
            lblError.Text = "Please select the Medical Date.";
        }
        else if (ddlDuration.SelectedIndex <= 0)
        {
            lblError.Text = "Please select the Medical Duration.";
        }
        else
        {
            lblError.Text = "";
            addMedical();
        }

    }

    private void addMedical()
    {
        bool result = false;
        DateTime dtSelectedDate = MedDateCal.SelectedDate;
        String selectedDate = String.Format("{0:yyyy-MM-dd}", dtSelectedDate);
        if (ddlExamination.SelectedIndex == 1)
        {

            result = DB_Connect.InsertQuery("INSERT INTO `al_medical` (`ADMISSION_NO`, `AL_YEAR`, `AL_SUBJECT`, `MEDICAL_DATE`, `MEDICAL_DURATION`, `ISSUED_BY`, `REASON`, `NOTE`) VALUES('" + txtAdNo.Text.ToString() + "', " + ddlYear.SelectedValue.ToString() + ", '" + txtSubCode.Text.ToString() + "', '" + selectedDate + "', " + ddlDuration.SelectedValue + ", '" + txtIssuedBy.Text.ToString() + "', '" + txtReason.Text.ToString() + "', '" + txtNote.Text.ToString() + "');");
        }

        if (ddlExamination.SelectedIndex == 2)
        {
            result = DB_Connect.InsertQuery("INSERT INTO `ol_medical` (`ADMISSION_NO`, `OL_YEAR`, `OL_SUBJECT`, `MEDICAL_DATE`, `MEDICAL_DURATION`, `ISSUED_BY`, `REASON`, `NOTE`) VALUES('" + txtAdNo.Text.ToString() + "', " + ddlYear.SelectedValue.ToString() + ", '" + txtSubCode.Text.ToString() + "', '" + selectedDate + "', " + ddlDuration.SelectedValue + ", '" + txtIssuedBy.Text.ToString() + "', '" + txtReason.Text.ToString() + "', '" + txtNote.Text.ToString() + "');");

        }

        if (result)
        {
            
            CustomException ex = new CustomException("Success !!!", "Record Inserted Successfully.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

            ClearInputs(Page.Controls);

        }


    }
    protected void MedDateCal_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtSelectedDate = MedDateCal.SelectedDate;
        txtDate.Text = String.Format("{0:yyyy-MM-dd}", dtSelectedDate);
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
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }
}

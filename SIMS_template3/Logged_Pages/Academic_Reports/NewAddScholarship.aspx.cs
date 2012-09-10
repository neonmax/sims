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

    private void fillYears()
    {
        ddlYear.Items.Clear();
        ddlYear.Items.Add(new ListItem("Select Year", "Empty"));      //Add Empty Item
        for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 10; i--)
        {
            ListItem YearList = new ListItem();
            YearList.Value = i.ToString();
            YearList.Text = i.ToString();
            ddlYear.Items.Add(YearList);
        }
    }

    private void loadSchols()
    {
        ddlSchol.Items.Clear();
        ddlSchol.Items.Add(new ListItem("Select Scholarship", "empty"));
        OdbcDataAdapter adpSubjectList = DB_Connect.ExecuteQuery("SELECT SCHOLARSHIP,SCHOLARSHIP_CODE FROM scholarship_mast");
        adpSubjectList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsScholList = new DataSet();
        adpSubjectList.Fill(dsScholList);
        if (dsScholList.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsScholList.Tables[0].Rows.Count; i++)
            {
                ListItem lstScholList = new ListItem();
                lstScholList.Value = dsScholList.Tables[0].Rows[i][1].ToString(); // or your index which is correct in your dataset
                lstScholList.Text = dsScholList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset                   
                ddlSchol.Items.Add(lstScholList);
            }
        }
        dsScholList.Dispose();
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

        loadSchols();
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
            txtAdNo.Enabled = false;

            dsAdNoList.Dispose();


        }
       
    }


    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchol.SelectedIndex > 0)
            txtScholCode.Text = ddlSchol.SelectedValue.ToString();

        fillYears();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        lblError.ForeColor = Color.Red;
        lblError.Text = "";

        if (ddlYear.SelectedIndex > 0)
            addMedical();
        else
            lblError.Text = "Please Select Awarded Year";

    }

    private void addMedical()
    {
      

        bool result = false;
        result = DB_Connect.InsertQuery("INSERT INTO `scholarship` (`ADMISSION_NO`, `SCHOLARSHIP_CODE`, `SCHOLARSHIP_YEAR`, `SCHOLARSHIP_AMOUNT`, `SS_NOTE`) VALUES('" + txtAdNo.Text.ToString() + "', '" + txtScholCode.Text.ToString() + "', '" + ddlYear.SelectedItem.Text + "', " + txtAmount.Text + ",'" + txtNote.Text.ToString() + "');");


        if (result)
        {

            CustomException ex = new CustomException("Success !!!", "Scholarship Details Saved.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

            ClearInputs(Page.Controls);

        }


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

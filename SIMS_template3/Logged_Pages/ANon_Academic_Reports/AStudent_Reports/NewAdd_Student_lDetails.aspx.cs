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
using System.IO;
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    static String adNo, district, nationality, religion;
    static String Nationality_code, Religion_code, gender;
    int admissionNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        OdbcDataAdapter adpAdNoList = DB_Connect.ExecuteQuery("SELECT S.`ADMISSION_NO` FROM `student_mast` S ORDER BY ADMISSION_NO DESC  ");
        adpAdNoList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsAdNoList = new DataSet();
        adpAdNoList.Fill(dsAdNoList);
        adNo = dsAdNoList.Tables[0].Rows[0][0].ToString();
        admissionNo = Convert.ToInt32(adNo) + 1;
        txtAdNo.Text = admissionNo.ToString();
        dsAdNoList.Dispose();


    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        lblError.ForeColor = Color.Red;

        if (ddlGrade.SelectedIndex <= 0)
        {
            lblError.Text = "Please select a Grade.";
        }
        else if (ddlClass.SelectedIndex <= 0)
        {
            lblError.Text = "Please select a Class.";
        }
        else if (ddlDistrict.SelectedIndex <= 0 || ddlClass.SelectedIndex <= 0)
        {
            lblError.Text = "Please select a District.";
        }
        else
        {


            if (fuStudentImage.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuStudentImage.FileName);
                    fuStudentImage.SaveAs(Server.MapPath("~/Student_Images/") + filename);
                    // lblError.Text = "Upload status " + filename + " Uploaded. ";
                }
                catch (Exception ex)
                {
                    lblError.Text = "";
                }

            }
            addStudent();
        }


    }

    private void addStudent()
    {

        bool result = false;

        DateTime dtBirthDate = calDob.SelectedDate;
        String birthDate = String.Format("{0:yyyy-MM-dd}", dtBirthDate);

        DateTime dtAdmissionDate = calDoa.SelectedDate;
        String admissionDate = String.Format("{0:yyyy-MM-dd}", dtAdmissionDate);

        OdbcDataAdapter adpNationalityList = DB_Connect.ExecuteQuery("SELECT `NATIONAL_CODE` FROM `nationality_mast` WHERE NATIONALITY = '" + rblNationality.SelectedValue + "'");
        adpNationalityList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsNationalityList = new DataSet();
        adpNationalityList.Fill(dsNationalityList);
        nationality = dsNationalityList.Tables[0].Rows[0][0].ToString();
        dsNationalityList.Dispose();


        OdbcDataAdapter adpReligionList = DB_Connect.ExecuteQuery("SELECT `RELIGION_CODE` FROM `religion_mast` WHERE RELIGION = '" + rblReligion.SelectedValue + "'");
        adpReligionList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsReligionList = new DataSet();
        adpReligionList.Fill(dsReligionList);
        religion = dsReligionList.Tables[0].Rows[0][0].ToString();
        dsReligionList.Dispose();

        OdbcDataAdapter adpDistrictList = DB_Connect.ExecuteQuery("SELECT `DISTRICT_CODE` FROM `district_mast` WHERE DISTRICT = '" + ddlDistrict.SelectedItem.Text + "'");
        adpDistrictList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsDistrictList = new DataSet();
        adpDistrictList.Fill(dsDistrictList);
        district = dsDistrictList.Tables[0].Rows[0][0].ToString();
        dsDistrictList.Dispose();


        if (rblGender.SelectedIndex == 0)
        {
            gender = "M";

        }
        else if (rblGender.SelectedIndex == 1)
        {
            gender = "F";

        }


        //txtAddressL4.Text = "INSERT INTO `student_mast` (`ADMISSION_NO`, `NAME_FULL`, `NAME_INITIALS`, `DOB`, `BIRTHCERTIFICATE_NO`, `NATIONAL_CODE`,`S_SEX`, `RELIGION_CODE`, `ADMISSION_DATE`, `ADMISSION_GRADE`, `ADMISSION_CLASS`, `PREVIOUSE_SCHOOL`, `SADDRESS_1`, `SADDRESS_2`, `SADDRESS_3`, `SADDRESS_4`,`DISTRICT_CODE`, `STELEPHONE_NO`) VALUES('" + txtAdNo.Text.ToString() + "', '" + txtFullName.Text.ToString() + "','" + txtNameInitials.Text.ToString() + "','" + birthDate + "','" + txtBirthCno.Text.ToString() + "','" + nationality + "','" + gender + "','" + religion + "','" + admissionDate + "'," + ddlGrade.SelectedIndex + ",'" + ddlClass.SelectedValue.ToString() + "', '" + txtPrevSchl.Text.ToString() + "', '" + txtAddressL1.Text.ToString() + "', '" + txtAddressL2.Text.ToString() + "', '" + txtAddressL3.Text.ToString() + "','" + txtAddressL4.Text.ToString() + "','" + district + "', '" + txtTelNo.Text + "')";

        result = DB_Connect.InsertQuery("INSERT INTO `student_mast` (`ADMISSION_NO`, `NAME_FULL`, `NAME_INITIALS`, `DOB`, `BIRTHCERTIFICATE_NO`, `NATIONAL_CODE`,`S_SEX`, `RELIGION_CODE`, `ADMISSION_DATE`, `ADMISSION_GRADE`, `ADMISSION_CLASS`, `PREVIOUSE_SCHOOL`, `SADDRESS_1`, `SADDRESS_2`, `SADDRESS_3`, `SADDRESS_4`,`DISTRICT_CODE`, `STELEPHONE_NO`) VALUES('" + txtAdNo.Text.ToString() + "', '" + txtFullName.Text.ToString() + "','" + txtNameInitials.Text.ToString() + "','" + birthDate + "','" + txtBirthCno.Text.ToString() + "','" + nationality + "','" + gender + "','" + religion + "','" + admissionDate + "'," + ddlGrade.SelectedIndex + ",'" + ddlClass.SelectedValue.ToString() + "', '" + txtPrevSchl.Text.ToString() + "', '" + txtAddressL1.Text.ToString() + "', '" + txtAddressL2.Text.ToString() + "', '" + txtAddressL3.Text.ToString() + "','" + txtAddressL4.Text.ToString() + "','" + district + "', '" + txtTelNo.Text + "')");

        if (result)
        {
            //lblError.ForeColor = Color.Blue;
            //lblError.Text = "Success";

            CustomException ex = new CustomException("Success !!!", "Student record inserted Successfully.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

            ClearInputs(Page.Controls);

        }



    }

    protected void calDob_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtBirthDate = calDob.SelectedDate;
        String birthDate = String.Format("{0:yyyy-MM-dd}", dtBirthDate);
        txtDate.Text = birthDate;


    }
    protected void calDoa_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtAdmissionDate = calDoa.SelectedDate;
        String admissionDate = String.Format("{0:yyyy-MM-dd}", dtAdmissionDate);
        txtDateAd.Text = admissionDate;


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

            txtAdNo.Text = admissionNo.ToString();

        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        ClearInputs(Page.Controls);
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

using System;
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
using System.Net.Mail;
using System.Net;


public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    //define the comman oject for database access
    Warning swbc = new Warning();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //invoke the fill grade methode
                fill_ddl_grade();
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Page Can not be loaded')", true);
        }
    }
    //fill the grade dropdown list with grades
    public void fill_ddl_grade()
    {
        try
        {
            DataTable dt_grade = swbc.get_all_grades();
            if (dt_grade.Rows.Count == 0)
            {
                lbl_grade_check.Text = "No selected Grades";

            }
            else
            {
                clear_all_labels();
                ddl_grade.DataSource = swbc.get_all_grades();
                ddl_grade.DataMember = "SC_GRADE";
                ddl_grade.DataValueField = "SC_GRADE";
                ddl_grade.DataBind();
                ddl_grade.Items.Insert(0, "Select Grade");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Grade details can not be retrived')", true);
        }
    }
    //fill the drop down list with classes relevant to grade
    public void fill_ddl_class(decimal grade)
    {
        try
        {
            DataTable dt_class = swbc.get_class_relevaent_grade(grade);
            if (dt_class.Rows.Count == 0)
            {
                lbl_grade_check.Text = "No selected class for the grade";

            }
            else
            {
                clear_all_labels();
                ddl_class.DataSource = dt_class;
                ddl_class.DataMember = "CLASS_CODE";
                ddl_class.DataValueField = "CLASS_CODE";
                ddl_class.DataBind();
                ddl_class.Items.Insert(0, "Select Class");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! There are no any classes for the selected grade')", true);
        }
    }
    //fill the dropdown list with students of the class
    public void fill_ddl_students_off_class(string classs, decimal grade)
    {
        try
        {
            DataTable dt_student = swbc.get_all_students_of_class(Convert.ToChar(classs), grade);
            if (dt_student.Rows.Count == 0)
            {
                lbl_student_check.Text = "No selected students for the class";
            }
            else
            {
                //invoke the getstudent methide accrding to selected class and grade
                clear_all_labels();
                ddl_student.DataSource = dt_student;
                ddl_student.DataMember = "NAME_INITIALS";
                ddl_student.DataValueField = "NAME_INITIALS";
                ddl_student.DataBind();
                ddl_student.Items.Insert(0, "Select Student");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Student details can not be retrived')", true);
        }
    }
    //fill the drop down list with warn codes
    public void fill_ddl_warn_code()
    {
        try
        {
            DataTable dt_warncode = swbc.getall_warn_codes();
            if (dt_warncode.Rows.Count == 0)
            {
                lbl_wtype_check.Text = "No selected warn types for the class";

            }
            else
            {
                //invoke the getstudent methide accrding to selected class and grade
                clear_all_labels();
                ddl_type.DataSource = dt_warncode;
                ddl_type.DataMember = "WARNING_CODE";
                ddl_type.DataValueField = "WARNING_CODE";
                ddl_type.DataBind();
                ddl_type.Items.Insert(0, "Select Warn code");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Warn code details can not be retrived')", true);
        }
    }
    //fill the drop down list with warning levels
    public void fill_ddl_levels()
    {
        try
        {
            DataTable dt_level = swbc.get_all_level_codes();
            if (dt_level.Rows.Count == 0)
            {
                lbl_wtype_check.Text = "No selected warn types for the class";

            }
            else
            {
                //invoke the getstudent methide accrding to selected class and grade
                //invoke get all level code methode
                clear_all_labels();
                ddl_level.DataSource = swbc.get_all_level_codes();
                ddl_level.DataMember = "LEVEL_CODE";
                ddl_level.DataValueField = "LEVEL_CODE";
                ddl_level.DataBind();
                ddl_level.Items.Insert(0, "Select Warn Level");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Warn level details can not be retrived')", true);
        }
    }

    //clear all text fields
    public void clear()
    {
        ddl_class.Items.Clear();
        ddl_student.Items.Clear();
        ddl_type.Items.Clear();
        ddl_level.Items.Clear();
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
        lbl_wtype_check.Text = string.Empty;
        lbl_level_check.Text = string.Empty;
        txt_description.Text = string.Empty;
        txt_date.Text = string.Empty;
        fill_ddl_grade();
    }


    protected void btn_insert_Click(object sender, EventArgs e)
    {
        try
        {
            string student_id = swbc.Get_student_name(ddl_student.Text).Rows[0][0].ToString();
            decimal inform = define_warning_level(ddl_level.Text);
            string des = define_description(txt_description.Text);
            if (checkdate(txt_date.Text) == 1)
            {
                if (swbc.insert_student_warning(student_id, txt_date.Text, ddl_type.Text, ddl_level.Text, txt_description.Text, inform))
                {
                    if (inform == 1)
                    {
                        Label1.Text = "Sending...";
                        SendMail(student_id);
                        Label1.Text = string.Empty;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Success !! Warning Details Enterd Successfully')", true);
                        clear();
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Success !! Warning Details Enterd Successfully')", true);
                    clear();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Warning!! Input Data Is Incorrect')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Manually Enterd Date Is In Incorrect Format')", true);
            }
        }
        catch (Exception s)
        {
            string ss = s.Message;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error !! Warning Details Operation Faild')", true);

        }       

    }

    public decimal define_warning_level(string level)
    {
        decimal value;
        if (level == "Level 03")
        {
            value = 1;
        }
        else
        {
            value = 0;
        }
        return value;
    }

    public string define_description(string des)
    {
        string value;
        if (des == string.Empty || des == null)
        {
            value = "null";
        }
        else
        {
            value = des;
        }
        return des;
    }
    protected bool SendMail(string id)
    {
        bool sta = false;
        try
        {
            var toAddress = string.Empty;
            string fmail, mmail, gmail = null;
            DataTable mails = swbc.get_email(id);
            fmail = mails.Rows[0]["FATHER_EMAIL"].ToString();
            mmail = mails.Rows[0]["MOTHER_EMAIL"].ToString();
            gmail = mails.Rows[0]["GUARDIAN_EMAIL"].ToString();
            // Gmail Address from where you send the mail
            var fromAddress = "defenceinova@gmail.com";
            // any address where the email will be sending
            if (fmail != null)
            {
                toAddress = fmail.ToString(); ;
            }
            else if (mmail != null)
            {
                toAddress = mmail.ToString(); ;
            }
            else
            {
                toAddress = gmail.ToString();
            }
            //Password of your gmail address
            const string fromPassword = "defenceinova";
            // Passing the values and make a email formate to display
            string subject = "Student Behaviour";
            string body = txt_description.Text;
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
                sta = true;


            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
            return sta;
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Network Failure Occured')", true);
            return sta;
        }
    }

    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl_class_check.Text = "fhfhfhfhfhf";
    }

    protected void ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_class.Items.Clear();
            ddl_student.Items.Clear();
            ddl_type.Items.Clear();
            ddl_level.Items.Clear();
            lbl_grade_check.Text = string.Empty;
            lbl_class_check.Text = string.Empty;
            lbl_student_check.Text = string.Empty;
            lbl_wtype_check.Text = string.Empty;
            lbl_level_check.Text = string.Empty;
            txt_description.Text = string.Empty;
            txt_date.Text = string.Empty;
            if (ddl_grade.Text == "Select Grade")
            {
                lbl_grade_check.Text = "Invalid Grade";
            }
            else
            {

                fill_ddl_class(Convert.ToDecimal(ddl_grade.Text));

            }
        }
        catch
        {
            lbl_grade_check.Text = "Invalid Grade";
        }

    }
    protected void ddl_wtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_level.Items.Clear();
            lbl_class_check.Text = string.Empty;
            lbl_student_check.Text = string.Empty;
            lbl_wtype_check.Text = string.Empty;
            lbl_level_check.Text = string.Empty;
            txt_description.Text = string.Empty;
            txt_date.Text = string.Empty;
            if (ddl_type.Text == "Select Warn code")
            {
                lbl_wtype_check.Text = "Invalid Warn code";


            }
            else
            {
                fill_ddl_levels();
            }
        }
        catch
        {
            lbl_grade_check.Text = "Invalid Warn code";
        }

    }
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_student.Items.Clear();
            ddl_type.Items.Clear();
            ddl_level.Items.Clear();
            lbl_class_check.Text = string.Empty;
            lbl_student_check.Text = string.Empty;
            lbl_wtype_check.Text = string.Empty;
            lbl_level_check.Text = string.Empty;
            txt_description.Text = string.Empty;
            txt_date.Text = string.Empty;
            if (ddl_class.Text == "Select Class")
            {
                lbl_class_check.Text = "Invalid Class";
            }
            else
            {
                string dd = ddl_class.SelectedValue;
                fill_ddl_students_off_class(ddl_class.Text, Convert.ToDecimal(ddl_grade.Text));
            }
        }
        catch (Exception s)
        {
            string d = s.Message;
            lbl_class_check.Text = "Invalid Class";
        }

    }
    protected void ddl_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_type.Items.Clear();
            ddl_level.Items.Clear();
            lbl_class_check.Text = string.Empty;
            lbl_student_check.Text = string.Empty;
            lbl_wtype_check.Text = string.Empty;
            lbl_level_check.Text = string.Empty;
            txt_description.Text = string.Empty;
            txt_date.Text = string.Empty;
            if (ddl_student.Text == "Select Student")
            {
                lbl_student_check.Text = "Invalid Student";


            }
            else
            {
                fill_ddl_warn_code();
            }
        }
        catch
        {
            lbl_class_check.Text = "Invalid Student";
        }

    }
    //validate the input date
    public int checkdate(string date)
    {
        int a = 0;
        try
        {
            int year = Convert.ToInt16(date.Substring(6, 2));
            if (date.Length > 10 || date.Length < 8)
            {
                a = 0;
            }
            else if (!date.Contains('/'))
            {
                a = 0;
            }
            else if (Convert.ToInt16(date.Substring(0, 1)) > 12)
            {
                a = 0;
            }
            else if (year > 99)
            {
                a = 0;
            }

            else
            {
                a = 1;
            }
            return a;
        }
        catch
        {
            return a;
        }
    }

    protected void ddl_level_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
        lbl_wtype_check.Text = string.Empty;
        lbl_level_check.Text = string.Empty;
        if (ddl_level.Text == "Select Warn Level")
        {
            lbl_level_check.Text = "Invalid Level";
        }
    }
    public void clear_all_labels()
    {
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
        lbl_wtype_check.Text = string.Empty;
        lbl_level_check.Text = string.Empty;
    }
}

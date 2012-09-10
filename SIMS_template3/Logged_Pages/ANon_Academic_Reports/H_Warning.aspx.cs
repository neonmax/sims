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
using DeepASP.JQueryPromptuTest;


public partial class _Default : System.Web.UI.Page 
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
            //Response.Write("<script>alert('grade details can not be loaded')</script>"); 
            CustomException ex = new CustomException("Error !!!", "grade details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }

    }
    //fill the grade dropdown list with grades
    public void fill_ddl_grade()
    {
        try
        {
            //invoke the fill grade methode
            ddl_grade.DataSource = swbc.get_all_grades();
            ddl_grade.DataMember = "SC_GRADE";
            ddl_grade.DataValueField = "SC_GRADE";
            ddl_grade.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('grade details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "grade details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //fill the drop down list with classes relevant to grade
    public void fill_ddl_class(decimal grade)
    {
        try
        {
            //invoke the get class methode according to input grade
            ddl_class.DataSource = swbc.get_class_relevaent_grade(grade);
            ddl_class.DataMember = "CLASS_CODE";
            ddl_class.DataValueField = "CLASS_CODE";
            ddl_class.DataBind();
        }
        catch
        {
           // Response.Write("<script>alert('class details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "class details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //fill the dropdown list with students of the class
    public void fill_ddl_students_off_class(char classs, decimal grade)
    {
        try
        {
            //invoke the getstudent methide accrding to selected class and grade
            ddl_student.DataSource = swbc.get_all_students_of_class(classs, grade);
            ddl_student.DataMember = "NAME_FULL";
            ddl_student.DataValueField = "NAME_FULL";
            ddl_student.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('student details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "selected class student details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //fill the drop down list with warn codes
    public void fill_ddl_warn_code()
    {
        try
        {
            //invoke the get all warn code methode
            ddl_type.DataSource = swbc.getall_warn_codes();
            ddl_type.DataMember = "WARNING_CODE";
            ddl_type.DataValueField = "WARNING_CODE";
            ddl_type.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('warning code details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "warning code details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //fill the drop down list with warning levels
    public void fill_ddl_levels()
    {
        try
        {
            //invoke get all level code methode
            ddl_level.DataSource = swbc.get_all_level_codes();
            ddl_level.DataMember = "LEVEL_CODE";
            ddl_level.DataValueField = "LEVEL_CODE";
            ddl_level.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('warning level details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "warning leve details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }

    }
    //fill dropdownlist with parent inform values
    public void fill_ddl_parentinform()
    {       
            ddl_inform.Items.Insert(0, "Inform");
            ddl_inform.Items.Insert(1, "Not Inform");
    }


    //#######################################################################
    //##############################setup_ others########################

    //decide the decimal value accrding to the user input
    public decimal get_parentinform()
    {
        decimal value = 0 ;
        if (ddl_inform.Text == "Inform")
        {
            value = 0;
        }
        else 
        {
            value = 1;
        }
        return value;


    }

    //clear all text fields
    public void clear()
    {
        txt_date.Text = string.Empty;
        txt_description.Text = string.Empty;
        fill_ddl_grade();

    }
    // invoke the level fill methode
    protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_levels();
        }
        catch
        {
            //Response.Write("<script>alert('warning level details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "warning leve details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //invoke parent inform decimal value decision methode
    protected void ddl_level_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_parentinform();
        }
        catch
        {
            //Response.Write("<script>alert('Parent Inform details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "Parent inform details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //invoke the class selecting methode accrding to the user input
    protected void ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_class(Convert.ToDecimal(ddl_grade.Text));
        }
        catch
        {
            //Response.Write("<script>alert('class details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "class details  according to selected grade can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }

    }
    //invoke the get students according to the selected class and grade
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_students_off_class(Convert.ToChar(ddl_class.Text), Convert.ToDecimal(ddl_grade.Text));
        }
        catch
        {
           // Response.Write("<script>alert('student details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "student details  according to selected class can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //invoke the warn code filling methode
    protected void ddl_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_warn_code();
            //get the selected student name
            lbl_admissionno_result.Text = swbc.search_results(ddl_student.Text).Rows[0]["ADMISSION_NO"].ToString();

        }
        catch
        {
            Response.Write("<script>alert('Warning catagories can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "warning catagories can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }

    }
    //validate the input date
    public bool validate_date(string date)
    {
        int selected_date = 0;
        try
        {

            //select the current date,month and select date and month
            string format = date.Substring(3, 1);
            int this_month = Convert.ToInt32(DateTime.Today.Month.ToString());
            int today = Convert.ToInt32(DateTime.Today.Day.ToString());
            int selected_month = Convert.ToInt32(date.Substring(0, 1));
            if (format == "/")
            {
                selected_date = Convert.ToInt32(date.Substring(2, 1));
            }
            else
            {
                selected_date = Convert.ToInt32(date.Substring(2, 2));
            }
            //check selected date is correct
            if (selected_date <= today && this_month <= selected_month)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            CustomException ex = new CustomException("Error !!!", "Selected date is in incorrect format");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
           // Response.Write("<script>alert('Selected date is in incorrect format')</script>");
            return true;

        }
    }

    protected void btn_insert_Click(object sender, EventArgs e)
    {
        //validate the grade
        if (ddl_grade.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese select a grade')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a grade");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate class
        else if (ddl_class.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese select a class')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a class");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate student
        else if (ddl_student.Text == string.Empty || lbl_admissionno_result.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese select a student')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a student");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate warnig type
        else if (ddl_type.Text == string.Empty)
        {
           // Response.Write("<script>alert('Plaese select a warning type')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a warnning type");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate the warning level
        else if (ddl_level.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese select a warning level')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a warning level");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate parent inform
        else if (ddl_inform.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese select a inform option')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a inform option");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate date
        else if (txt_date.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese select a date')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese select a date");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate dexription
        else if (txt_description.Text == string.Empty)
        {
            //Response.Write("<script>alert('Plaese insert a warning description')</script>");
            CustomException ex = new CustomException("Warning !!!", "Plaese insert warning descripion");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate date
        else if (validate_date(txt_date.Text))
        {
            //Response.Write("<script>alert('Selected date is beyond the current date')</script>");
            CustomException ex = new CustomException("Warning !!!", "selected date is beyond the current date");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
        else
        {
            try
            {
                //invoke the insert methode
                if (swbc.insert_student_warning(lbl_admissionno_result.Text, txt_date.Text, ddl_type.Text, ddl_level.Text, txt_description.Text.Trim(), get_parentinform()))
                {
                    //Response.Write("<script>alert('Record Inserted Successfully')</script>");
                    CustomException ex = new CustomException("Success !!!", "Record Inserted Successfully");
                    MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messages.Show(this);
                    //clear the text fields if th e methode invokation is success
                    if (ddl_inform.Text == "Inform")
                    {
                        if (SendMail(lbl_admissionno_result.Text))
                        {
                            CustomException exx = new CustomException("Success !!!", "Email send to selected student's parents");
                            MessageBox message = new MessageBox(exx, MessageBoxDefaultButtonEnum.OK);
                            message.Show(this);
                            //Response.Write("<script>alert('Email send to selected student's parents')</script>");
                        }
                        else
                        {
                            CustomException exx = new CustomException("Error !!!", "Email can not be send");
                            MessageBox message = new MessageBox(exx, MessageBoxDefaultButtonEnum.OK);
                            message.Show(this);
                            //Response.Write("<script>alert('Network error, mail can not be send')</script>");
                        }
                    }
                    clear();
                }
            }
            catch
            {
                //Response.Write("<script>alert('Record can not be Inserted')</script>");
                CustomException exx = new CustomException("Error !!!", "Record can not be Inserted");
                MessageBox message = new MessageBox(exx, MessageBoxDefaultButtonEnum.OK);
                message.Show(this);

            }
        }
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        //invoke the methode to clear the user input fields
        clear();
    }
    protected bool SendMail(string id)
    {
        bool sta = false;
        var toAddress=string.Empty;
        string fmail,mmail,gmail = null;
        DataTable mails=swbc.get_email(id);
        fmail=mails.Rows[0]["FATHER_EMAIL"].ToString();
        mmail=mails.Rows[0]["MOTHER_EMAIL"].ToString();
        gmail=mails.Rows[0]["GUARDIAN_EMAIL"].ToString();
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
            toAddress = gmail.ToString() ;
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
}

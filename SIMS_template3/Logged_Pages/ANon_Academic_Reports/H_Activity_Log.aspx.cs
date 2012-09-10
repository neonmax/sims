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
using DeepASP.JQueryPromptuTest;


public partial class _Default : System.Web.UI.Page 
{
    //common variable for database access
    Log ialdc = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
      
       
            if (!IsPostBack)
            {
                try
                {
                    //invoke the dropdowwn list filling methdodes
                    fill_ddl_grade();
                    fill_ddl_activtycode();
                }
                catch
                {
                    //popout custom message if any error happans
                    CustomException ex = new CustomException("Error !!!", "page can not be loadded");
                    MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messageBox.Show(this);
                }
            }
        
    }

    //fill the drop down list with classes relevant to grade
    public void fill_ddl_class(decimal grade)
    {
        try
        {
            DataTable dt_class = ialdc.get_class_relevaent_grade(grade);
            //get all classess methode
            if (dt_class.Rows.Count == 0)
            {
               // Response.Write("<script>alert('There are no class values in the tabel')</script>");
                ////popout custom message if any error happans
                CustomException ex = new CustomException("Warning !!!", "There are no class values in the tabel");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
            }
            else
            {
                ddl_class.DataSource = dt_class;
                ddl_class.DataMember = "CLASS_CODE";
                ddl_class.DataValueField = "CLASS_CODE";
                ddl_class.DataBind();
            }
        }
        catch
        {
            //Response.Write("<script>alert('class details can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "class details can not be loaaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
    }
    //fill the dropdown list with students of the class
    public void fill_ddl_students_off_class(char classs, decimal grade)
    {
        try
        {
            //invoke get all student methode
            DataTable dt_student = ialdc.get_all_students_of_class(classs, grade);
            if (dt_student.Rows.Count == 0)
            {
                //Response.Write("<script>alert('There are no student in the selected class')</script>");
                ////popout custom message if any error happans
                CustomException ex = new CustomException("Warning !!!", "There are no students  in the selected class");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
            }
            else
            {
                ddl_student.DataSource = dt_student;
                ddl_student.DataMember = "NAME_FULL";
                ddl_student.DataValueField = "NAME_FULL";
                ddl_student.DataBind();
            }
        }
        catch
        {
           // Response.Write("<script>alert('student details can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "student details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
    //fill the drop down list with activty codes
    public void fill_ddl_activtycode()
    {
        try
        {
            //invoke get all activityes methode
            ddl_type.DataSource = ialdc.getall_activity_type();
            ddl_type.DataMember = "ACTIVITY_CODE";
            ddl_type.DataValueField = "ACTIVITY_CODE";
            ddl_type.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('activty code details can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "activty code details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
    //fill the drop down list with activities
    public void fill_ddl_activities(string type)
    {
        try
        {
            //invoke get all activities methode
            ddl_activity.DataSource = ialdc.get_all_activity(type);
            ddl_activity.DataMember = "ACTIVITYSUB_CODE";
            ddl_activity.DataValueField = "ACTIVITYSUB_CODE";
            ddl_activity.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('_activity details can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "activty details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //###################################################################################################
    }
    //invoke the grade data filling methode
    protected void ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //invoke the class filling methode
            fill_ddl_class(Convert.ToDecimal(ddl_grade.Text));
        }
        catch
        {
            //Response.Write("<script>alert('Selected grade classes can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "class details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
 
        }
    }
    //invoke the class filling methidde
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_students_off_class(Convert.ToChar(ddl_class.Text),Convert.ToDecimal(ddl_grade.Text));

        }
        catch 
        {
           // Response.Write("<script>alert('Selected class students can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "student details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
    }
    //invoke the student filling methdode
    protected void ddl_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable ss=ialdc.search_results(ddl_student.Text);
            //print the selecteed student admission no
            lbl_admissionno_result.Text = ss.Rows[0]["ADMISSION_NO"].ToString();

        }
        catch
        {
           // Response.Write("<script>alert('selected student records can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "selected student records  can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
 
        }

    }
    //invoke the acitivity filling methide
    protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_activities(ddl_type.Text);
        }
        catch
        {
            //Response.Write("<script>alert('activity data can not be loaded')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "activty details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
 
        }
    }
    //clear all text fieldds

    //refer the input date d and check whether the date is according to the correct requirement
    public bool validate_date(string date)
    {
        int selected_date = 0;
        try
        {
            //filter the current date and month and input date and month
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
            //Response.Write("<script>alert('Selected date is in incorrect format')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "selected date is incorrect");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
            return true;

        }
    }
    //clear fields
    public void clear()
    {
        txt_activityyear.Text = string.Empty;
        txt_membershipno.Text = string.Empty;
        txt_registerdate.Text = string.Empty;
        txt_description.Text = string.Empty;
    }
    //clear all the field
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_activityyear.Text = string.Empty;
        txt_membershipno.Text = string.Empty;
        txt_registerdate.Text = string.Empty;
        txt_description.Text = string.Empty;
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        //check the grade input
        if (ddl_grade.Text == string.Empty)
        {
            //Response.Write("<script>alert('please select a grade')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please select a grade");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the class input
        else if (ddl_class.Text == string.Empty)
        {
            //Response.Write("<script>alert('please select a class')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please select a class");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the studentname  input
        else if (ddl_student.Text == string.Empty)
        {
           // Response.Write("<script>alert('please select a student')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please select a student");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the activitytype input
        else if (ddl_type.Text == string.Empty)
        {
           // Response.Write("<script>alert('please select a activity type')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please select a actvity type");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the activity input
        else if (ddl_activity.Text == string.Empty)
        {
            //Response.Write("<script>alert('please select a activity')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please select a activity");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the activity name input
        else if (txt_activityyear.Text == string.Empty)
        {
           // Response.Write("<script>alert('please insert activity year')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please insert activity year");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the membership no input
        else if (txt_membershipno.Text == string.Empty)
        {
           // Response.Write("<script>alert('please insert membership number')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please insert memeber number");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the register date input
        else if (txt_registerdate.Text == string.Empty)
        {
           // Response.Write("<script>alert('please select a date')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please selected date");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the description input
        else if (txt_description.Text == string.Empty)
        {
           // Response.Write("<script>alert('please insert a activity description')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "please insert description");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        //check the date validation
        else if (validate_date(txt_registerdate.Text))
        {
          // Response.Write("<script>alert('selected date is beyond than current date')</script>");
            //popout custom message if any error happans
            CustomException ex = new CustomException("Warning!!!", "selected date is beyond than current date");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        else
        {
            try
            {
                //invoke the data insert methode
                if (ialdc.insert_student_activity(lbl_admissionno_result.Text, ddl_type.Text, ddl_activity.Text, Convert.ToDecimal(txt_activityyear.Text), txt_description.Text.Trim(), txt_membershipno.Text.Trim(), txt_registerdate.Text.Trim()))
                {
                   // Response.Write("<script>alert('Record inserted successfully')</script>");
                    //popout custom message if any error happans
                    CustomException ex = new CustomException("Success!!!", "Record inserted successfully");
                    MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messageBox.Show(this);
                    clear();
                }
            }
            catch
            {
                //Response.Write("<script>alert('Record can not be inserted')</script>");
                //popout custom message if any error happans
                CustomException ex = new CustomException("Error!!!", "REcord can not be inserted");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
                
            }
        }


    }
    //fill the grade dropdown list
    public void fill_ddl_grade()
    {
        try
        {
            //invoe get all grade methode
            DataTable dt_grade = ialdc.get_all_grades();
            if (dt_grade.Rows.Count == 0)
            {
               //Response.Write("<script>alert('There are No grade records in the table')</script>");
                ////popout custom message if any error happans
                CustomException ex = new CustomException("Warning!!!", "There are No grade records in the table");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
            }
            else
            {
                ddl_grade.DataSource = dt_grade;
                ddl_grade.DataMember = "SC_GRADE";
                ddl_grade.DataValueField = "SC_GRADE";
                ddl_grade.DataBind();
            }

        }
        catch
        {
            //Response.Write("<script>alert('grade details can not be loaded, try again')</script>");
            ////popout custom message if any error happans
            CustomException ex = new CustomException("Error!!!", "There are No grade records in the table");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
}

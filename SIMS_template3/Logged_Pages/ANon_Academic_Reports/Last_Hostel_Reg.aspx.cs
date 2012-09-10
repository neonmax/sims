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

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    //common variable for database access
    Hostel_DB hos = new Hostel_DB();

    /// <summary>
    /// this function selected all the years which stated as student
    /// leave years.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                set_grade();

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Page Can not be loaded')", true);
            }
        }
    }




    protected void btn_register_Click(object sender, EventArgs e)
    {
        if (ddl_grade.SelectedIndex == 0)
        {
            lbl_grade_check.Text = "Select Grade Properly";
        }
        else if (ddl_class.SelectedIndex == 0)
        {
            lbl_class_check.Text = "Select Class properly";
        }
        else if (ddl_student.SelectedIndex == 0)
        {
            lbl_student_check.Text = "Select Student Properly";
            lbl_admission_result.Text = "[Admission no]";
            lbl_admission_result.ForeColor = Color.Gray;
        }
        else if (txt_from.Text == string.Empty || checkdate(txt_from.Text) == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Warning!! Please Select a Proper Date')", true);
        }
        else
        {
            try
            {
                string tdate = "0";
                decimal pp = 0;
                decimal dhp = 0;
                decimal hp = 0;

                if (hos.register_student(lbl_admission_result.Text, set_regnum(lbl_admission_result.Text), txt_from.Text, tdate, pp, dhp, hp))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Success')", true);
                    ////Response.Write("<script>alert('Student Registration is Successful')</script>");
                    //CustomException ex = new CustomException("Success !!!", "Student Registration is Successful");
                    //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    //messageBox.Show(this);
                    clear();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Warning!! Registration can not be Completed')", true);
                    clear();

                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Registration can not be Completed')", true);
                clear();
            }

        }
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        clear();
    }
    public void clear()
    {
        set_grade();
        ddl_class.Items.Clear();
        ddl_student.Items.Clear();
        txt_from.Text = string.Empty;
        lbl_admission_result.Text = "[Admission no]";
        lbl_admission_result.ForeColor = Color.Gray;
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
        lbl_grade_check.Text = string.Empty;

    }

    protected void ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            ddl_class.Items.Clear();
            ddl_student.Items.Clear();
            lbl_admission_result.Text = "[Admission no]";
            lbl_admission_result.ForeColor = Color.Gray;
            txt_from.Text = string.Empty;
            lbl_student_check.Text = string.Empty;
            lbl_class_check.Text = string.Empty;
            if (ddl_grade.Text == "Select Grade")
            {
                lbl_grade_check.Text = "Invalid Grade";


            }
            else
            {
                fill_class(Convert.ToDecimal(ddl_grade.Text));
                //
            }
        }
        catch
        {
            // Response.Write("<script>alert('Please select the grade properly')</script>");
            lbl_grade_check.Text = "Invalid Grade";
        }
    }
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_admission_result.Text = "[Admission no]";
        lbl_admission_result.ForeColor = Color.Gray;
        txt_from.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
        lbl_class_check.Text = string.Empty;

        if (ddl_class.Text == "Select  Class")
        {
            lbl_class_check.Text = "Invalid Class";
            ddl_student.Items.Clear();
        }
        else
        {
            try
            {
                ddl_student.Items.Clear();
                fill_student(Convert.ToDecimal(ddl_grade.Text), Convert.ToChar(ddl_class.Text));
            }
            catch
            {

                Response.Write("<script>alert('Student List can not be Loaded')</script>");
            }

        }
    }
    protected void ddl_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_from.Text = string.Empty;

        try
        {
            if (ddl_student.Text == "Select  Student")
            {
                // Response.Write("<script>alert('Please select the student  properly')</script>");
                lbl_student_check.Text = "Invalid Student";
                lbl_admission_result.Text = "[Admission no]";
                lbl_admission_result.ForeColor = Color.Gray;
            }
            else
            {
                lbl_admission_result.Text = hos.get_student_id(ddl_student.Text);
                lbl_admission_result.ForeColor = Color.Black;
                lbl_student_check.Text = string.Empty;

            }
        }
        catch
        {
            lbl_student_check.Text = "selected student name can not be retrived";
            lbl_student_check.Text = string.Empty;
            //Response.Write("<script>alert('Error ! selected student name can not be retrived')</script>");
        }
    }

    //prepare the grade data table
    public void set_grade()
    {
        try
        {
            DataTable dt_grade = hos.get_grade();
            if (dt_grade.Rows.Count == 0)
            {
                lbl_grade_check.Text = "No selected grades in the database";
                clear();
                lbl_class_check.Text = string.Empty;
            }
            else
            {
                lbl_admission_result.Text = "[Admission no]";
                lbl_admission_result.ForeColor = Color.Gray;
                ddl_grade.DataSource = dt_grade;
                ddl_grade.DataMember = "SC_GRADE";
                ddl_grade.DataValueField = "SC_GRADE";
                ddl_grade.DataBind();
                ddl_grade.Items.Insert(0, "Select  Grade");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! There are no records in the database')", true);
        }
    }

    public void fill_class(decimal grade)
    {
        try
        {
            DataTable dt_class = hos.get_class(grade);
            if (dt_class.Rows.Count == 0)
            {
                lbl_grade_check.Text = "No selected class for the grade";
                ddl_class.Items.Clear();
                ddl_student.Items.Clear();
                lbl_student_check.Text = string.Empty;

            }
            else
            {
                lbl_admission_result.Text = "[Admission no]";
                lbl_admission_result.ForeColor = Color.Gray;
                lbl_grade_check.Text = string.Empty;
                lbl_class_check.Text = string.Empty;
                lbl_student_check.Text = string.Empty;
                ddl_class.DataSource = dt_class;
                ddl_class.DataMember = "CLASS_CODE";
                ddl_class.DataValueField = "CLASS_CODE";
                ddl_class.DataBind();
                ddl_class.Items.Insert(0, "Select  Class");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! There are no any classes for the selected grade')", true);
        }
    }

    public void fill_student(decimal grade, char classs)
    {
        try
        {
            DataTable dt_student = hos.get_student(grade, classs);
            if (dt_student.Rows.Count == 0)
            {
                lbl_class_check.Text = "No  students to be register";
                ddl_student.Items.Clear();
                lbl_student_check.Text = string.Empty;
            }
            else
            {
                lbl_class_check.Text = string.Empty;
                lbl_student_check.Text = string.Empty;
                ddl_student.DataSource = dt_student;
                ddl_student.DataMember = "NAME_FULL";
                ddl_student.DataValueField = "NAME_FULL";
                ddl_student.DataBind();
                ddl_student.Items.Insert(0, "Select  Student");
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! There are no students in the selected class')", true);
        }
    }
    //define the student regstration number for student
    public string set_regnum(string id)
    {
        string first = id.Substring(6, 4);
        string year = DateTime.Today.Year.ToString();
        string pre = "HO";
        return pre.Insert(2, year).Insert(6, first);
    }
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

}

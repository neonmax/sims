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
    //create comman object for databse access
    Leave lv = new Leave();
    ReportDocument rd = new ReportDocument(); 
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
                set_year();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Page Can Not Be Loaded.')", true);
            }
        }
    }
    /// <summary>
    /// select the releavnt leave year and from there validations also has
    /// been fullfilled.
    /// If user selected any invalid value 
    /// message will be appear as select leave year properly.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_year_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddl_grade.Items.Clear();
        ddl_class.Items.Clear();
        ddl_student.Items.Clear();
        lbl_year_check.Text = string.Empty;
        lbl_grade_check.Text = string.Empty;
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;

        if (ddl_year.Text == "Select  Year")
        {
            lbl_year_check.Text = "Invalid Year";
            ddl_grade.Items.Clear();
            ddl_class.Items.Clear();
            ddl_student.Items.Clear();
        }
        else
        {

            set_grade(Convert.ToDecimal(ddl_year.Text));           
        }

    }
    /// <summary>
    /// this event retrive the relevant classess  according to the selected grade
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_class.Items.Clear();
            ddl_student.Items.Clear();
            lbl_year_check.Text = string.Empty;
            lbl_grade_check.Text = string.Empty;
            lbl_class_check.Text = string.Empty;
            lbl_student_check.Text = string.Empty;
            if (ddl_grade.Text == "Select  Grade")
            {
                lbl_grade_check.Text = "Invalid Grade";
                ddl_class.Items.Clear();
                ddl_student.Items.Clear();
            }
            else
            {
                fill_class(Convert.ToDecimal(ddl_grade.Text), Convert.ToDecimal(ddl_year.Text));
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! operation can not be fulfill')", true);
         
            
        }
    }
    /// <summary>
    /// this event retrive the classess and students of those selected classess
    /// according to the selected class and the grade
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddl_student.Items.Clear();
        lbl_year_check.Text = string.Empty;
        lbl_grade_check.Text = string.Empty;
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
        if (ddl_class.Text == "Select  Class")
        {
            lbl_class_check.Text = "Invalid Class";
            ddl_student.Items.Clear();       
        }
        else
        {
            try
            {
               
                fill_student(Convert.ToDecimal(ddl_grade.Text), Convert.ToChar(ddl_class.Text), Convert.ToDecimal(ddl_year.Text));
            }
            catch(Exception d)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! operation can not be fulfill')", true);
                //Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
            }

        }
    }
    /// <summary>
    /// this event retrive the generated report accrding to the selected student
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_student_SelectedIndexChanged(object sender, EventArgs e)
    {
       //vaidate the student name is empty or not
        lbl_student_check.Text = string.Empty;
        if (ddl_student.Text == "Select  Student")
        {
            lbl_student_check.Text ="Invalid Student";
        }
        else
        {
            try
            {
                lbl_student_check.Text = string.Empty;

                //load the repoprt from location
                rd.Load("C:\\Users\\Neon\\Desktop\\Ready for 5th iteration\\4th Iteration Final\\SIMS_template3\\cr_leavingcertificate.rpt");
                //retrive all the information about the selcted student
                DataTable resource = lv.get_basic(ddl_student.Text);

                //set the student initial name
                TextObject name_initial = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name_initial"];
                name_initial.Text = getsex(resource.Rows[0]["S_SEX"].ToString()).Substring(0, 2) + " " + resource.Rows[0]["NAME_INITIALS"].ToString();
            //invoke the message to manage to student according to length
                setname(rd, resource.Rows[0]["NAME_FULL"].ToString());
                //set the student admit year to school
                TextObject id = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_adminid"];
                id.Text = resource.Rows[0]["ADMISSION_NO"].ToString();
                //set student sex 
                TextObject sex = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_sex"];
                sex.Text = resource.Rows[0]["S_SEX"].ToString();
                //set student nation
                DataTable dt = lv.get_nation(resource.Rows[0]["NATIONAL_CODE"].ToString());
                TextObject nation = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_nation"];
                nation.Text = dt.Rows[0]["NATIONALITY"].ToString();
                //set student date of birth
                TextObject dob = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_dob"];
                int dateindex = resource.Rows[0]["DOB"].ToString().LastIndexOf("/");
                dob.Text = resource.Rows[0]["DOB"].ToString().Substring(0, dateindex+5);
                //set student admin date
                TextObject addate = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_admindate"];
                int index = resource.Rows[0]["ADMISSION_DATE"].ToString().LastIndexOf("/");
                addate.Text = resource.Rows[0]["ADMISSION_DATE"].ToString().Substring(0, index+5);
                //set student leave year if student has leave the school other wise
                //prompt an alert
                TextObject leaveyear = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_leaveyear"];
                int last = resource.Rows[0]["DOL"].ToString().LastIndexOf("/");
                leaveyear.Text = resource.Rows[0]["DOL"].ToString().Substring(last+1, 4);
                //set the student leave grade
                TextObject leavegrade = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_leavegrade"];
                leavegrade.Text = "Grade " + lv.get_garde(resource.Rows[0]["ADMISSION_NO"].ToString()).Rows[0]["MAX(SC_GRADE)"].ToString();
                TextObject re_01 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_remarksex"];
                re_01.Text = getsex(resource.Rows[0]["S_SEX"].ToString()).Substring(2, 3);

                TextObject re_02 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_finalsex"];
                re_02.Text = get_finalsex(resource.Rows[0]["S_SEX"].ToString()) + ".";
                //set the report viwer to be print
                crvReportViewer.ReportSource = rd;
                crvReportViewer.RefreshReport();
            }
            catch (Exception ss)
            {
                string s = ss.Message;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Warning!! Selected student has not leave the school yet.')", true);
               // Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
            }
 
        }
    }
   

    /// <summary>
    /// identify the student initial preferance 
    /// according to the sex
    /// </summary>
    /// <param name="sex"></param>
    /// <returns></returns>
    public string getsex(string sex)
    {
        string prefix = null;
        if (sex == "M")
        {
            prefix = "MrHis";
        }
        else
        {
            prefix = "MsHer";
        }
        return prefix;
    }
    /// <summary>
    /// identify the student initial preferance 
    /// according to the sex
    /// </summary>
    /// <param name="sex"></param>
    /// <returns></returns>
    public string get_finalsex(string sex)
    {
        string prefix = null;
        if (sex == "M")
        {
            prefix = "him";
        }
        else
        {
            prefix = "her";
        }
        return prefix;

    }
    /// <summary>
    /// measuer how much lines there should be hold the student name
    /// </summary>
    /// <param name="rd"></param>
    /// <param name="fullname"></param>

    public void setname(ReportDocument rd, string fullname)
    {
        try
        {

            //if the total fulll name lenght s less than 48 character print it 
            if (fullname.Length <= 48)
            {
                TextObject name = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name01"];
                name.Text = fullname;
            }
            else
            {
                //if length is greater tha 48 and less than 96 print here
                int lenght = fullname.Length;
                if (lenght <= 96)
                {
                    string one = fullname.Substring(0, 48);
                    string two = fullname.Substring(48, lenght - 48);
                    TextObject name01 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name01"];
                    name01.Text = one;
                    TextObject name02 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name02"];
                    name02.Text = two;

                }
                    //if lenght greater than 96 and less than 144 print here
                else if (lenght <= 144)
                {
                    string one = fullname.Substring(0, 48);
                    string two = fullname.Substring(48, 48);
                    string three = fullname.Substring(96, lenght - 96);
                    TextObject name01 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name01"];
                    name01.Text = one;
                    TextObject name02 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name02"];
                    name02.Text = two;
                    TextObject name03 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name03"];
                    name03.Text = three;

                }
                else
                {
                    //other than if th nameis lenght than 144 characters do as defined here
                    string one = fullname.Substring(0, 48);
                    string two = fullname.Substring(48, 48);
                    string three = fullname.Substring(96, 48);
                    string four = fullname.Substring(144, fullname.Length - 144);
                    TextObject name01 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name01"];
                    name01.Text = one;
                    TextObject name02 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name02"];
                    name02.Text = two;
                    TextObject name03 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name03"];
                    name03.Text = three;
                    TextObject name04 = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["txt_name04"];
                    name04.Text = four;
                }
            }

        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! There Is Some Problem With Student Name. Try To Modify Name First ')", true);
           // Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
        }

    }
    /// <summary>
    /// clear all the drop down lists
    /// </summary>
    public void clear()
    {
        ddl_grade.Items.Clear();
        ddl_class.Items.Clear();
        ddl_student.Items.Clear();
    }
    /// <summary>
    /// clear the all text marks
    /// </summary>
    public void clearlabel_01()
    {
        lbl_grade_check.Text = string.Empty;
        lbl_class_check.Text = string.Empty;
        lbl_student_check.Text = string.Empty;
    }
    /// <summary>
    /// invoke the mehtode to select all the years
    /// </summary>
    public void set_year()
        
    {
        try
        {
            DataTable dt_grade = lv.get_all_years();
            ddl_year.DataSource = dt_grade;
            ddl_year.DataMember = "SC_YEAR";
            ddl_year.DataValueField = "SC_YEAR";
            ddl_year.DataBind();
            ddl_year.Items.Insert(0, "Select  Year");

            
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!!  Leave Year Values Can Not Be Loaded.')", true);
           // Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
        }
 
    }

    /// <summary>
    /// invoke the methode to select all the grade according to year
    /// </summary>
    /// <param name="year"></param>
    public void set_grade(decimal year)
    {
        try
        {
            DataTable dt_grade = lv.get_grades(year); 
            ddl_grade.DataSource = dt_grade;
            ddl_grade.DataMember = "SC_GRADE";
            ddl_grade.DataValueField = "SC_GRADE";
            ddl_grade.DataBind();
            ddl_grade.Items.Insert(0, "Select  Grade");
          
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Student Grade Values Can Not Be Loaded For The Selected Grade')", true);
           // Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
        }
    }

    /// <summary>
    /// invoke the methide to select all the class which according to the selected year
    /// and the grade
    /// </summary>
    /// <param name="grade"></param>
    /// <param name="year"></param>
    public void fill_class(decimal grade,decimal year)
    {
        try
        {
            DataTable dt_class = lv.get_class(grade,year);
            ddl_class.DataSource = dt_class;
            ddl_class.DataMember = "CLASS_CODE";
            ddl_class.DataValueField = "CLASS_CODE";
            ddl_class.DataBind();
            ddl_class.Items.Insert(0, "Select  Class");
            
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!!  Students In The Selected Class Can Not Be Loaded.')", true);
           // Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
        }
    }
    /// <summary>
    /// selecte all the students who are in the selected class according
    /// t selected class grade abd year
    /// </summary>
    /// <param name="grade"></param>
    /// <param name="classs"></param>
    /// <param name="year"></param>
    public void fill_student(decimal grade, char classs,decimal year)
    {
        try
        {
            DataTable dt_student = lv.get_student(grade, classs, year);
            ddl_student.DataSource = dt_student;
            ddl_student.DataMember = "NAME_FULL";
            ddl_student.DataValueField = "NAME_FULL";
            ddl_student.DataBind();
            ddl_student.Items.Insert(0, "Select  Student");
            
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Selected Student Name Can Not Be Loaded.')", true);
           // Response.Redirect("http://localhost:49178/SIMS_template3/Logged_Pages/ANon_Academic_Reports/LeavingCertificate.aspx");
        }
    }
}

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{

    //declare the connection string to the data base
    string Path = "Dsn=nsis;uid=root;pwd=123";
    //declare static variable to hold values relevant to specific student
    ReportDocument doc = new ReportDocument();
    static string _student_id = null;
    static string _student_name = null;
    static string _student_sex = null;
    static string _selected_id_sex = null;
    static DataTable dt_extracurricular;
    static DataTable dt_student_prefect_details;
    static DataTable dt_special_awards;
    static DataTable dt_studentwarnings;
    static DataTable dt_student_basic;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void gv_extracurricular_log_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ibtn_search_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //invoke gell all serach values methode to fill search values
            DataTable dt1 = get_all_serach_results(txt_SC_searchkey.Text);
            ddl_searchResult.DataSource = dt1;
            ddl_searchResult.DataTextField = "ADMISSION_NO";
            ddl_searchResult.DataValueField = "ADMISSION_NO";
            ddl_searchResult.DataBind();
        }
        catch (Exception ss)
        {
            //catch if any exception occurs and handle it
            string v = ss.Message;
            lblError.Text = v;
            Response.Write("<script>alert('Error in processing, Please try again')</script>");
        } 
    }

    //implement get aal values which satisfy srting key value
    public DataTable get_all_serach_results(string key)
    {
        DataTable dt;
        //create new connection with the databse
        OdbcConnection conn = new OdbcConnection(Path);
        //open the created connection
        conn.Open();
        //declare dataadpter variable and hold the values 
        OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO from student_mast where ADMISSION_NO like '%" + txt_SC_searchkey.Text + "%'", conn);
        //create new data tbale object
        dt = new DataTable();
        //fill the data table object through data adapter
        adapter.Fill(dt);
        //close the open clonnection
        conn.Close();
        //return the filled data table object
        return dt;

    }
    //get student name according to the student id
    public DataTable get_student_basic(string id)
    {
        dt_student_basic = new DataTable();
        OdbcConnection conn = new OdbcConnection(Path);
        conn.Open();
        OdbcCommand cmd = new OdbcCommand("select NAME_FULL,S_SEX,ADMISSION_DATE from student_mast where ADMISSION_NO='" + id + "'", conn);
        OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
        adapter.Fill(dt_student_basic);
        return dt_student_basic;

    }

    //this view the report
    protected void ibtn_SC_viewreport_Click(object sender, ImageClickEventArgs e)
    {
        
        _student_id = ddl_searchResult.Text;
        //load the report from the location
      
        doc.Load(Server.MapPath("CrystalReport_Student Character.rpt"));
        //invoke the set basic details of the selected student
     
        set_basics_inreport(ddl_searchResult.Text);
    
        //invoke the set extra curricular activites of the selected student
        set_Extra_curriculars(_student_id);
     
      
 
       
        //invoke the set prefect detils get methode of the student
        //set_prefect_deatils(_student_id);
        
        //invoke the set special awards methode of the selected student
        set_special_awards(_student_id);
     
      
        //////invoke the set warning mehtode of the selected student
        set_student_warnings(_student_id);
       

        //create text object and print student name
        TextObject txt_name = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text4"];
        txt_name.Text = _student_name;
     
        //print student id
        TextObject txt_id = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text6"];
        txt_id.Text = ddl_searchResult.Text;
    
        //set the report data source 
        crv_SC_characterreport.ReportSource = doc;
        lblError.Text = _student_id.ToString();
        //////refersh the report
        //crv_SC_characterreport.RefreshReport();
    }

    //build report through all the relevant information of the student
    public void set_basics_inreport(string st_id)
    {
        try
        {
            string admission_date = null;
            string prefix_sex = null;
            string leave_year = null;
            string al_year = null;
            string ol_year = null;
            //get student basuc information
            DataTable dt = get_student_basic(st_id);
            //get student al year
            al_year = get_student_AL_year(st_id);
            //get student leave year
            leave_year = get_student_leave_year(st_id);
            //get values from the retrived data table
            _student_name = (string)dt.Rows[0]["NAME_FULL"];
            _student_sex = (string)dt.Rows[0]["S_SEX"];
            admission_date = (string)dt.Rows[0]["ADMISSION_DATE"].ToString().Substring(5, 4);
            //detect the student sex
            if (_student_sex == "M")
            {
                _selected_id_sex = "He";
                prefix_sex = "Mr ";
            }
            else
            {
                _selected_id_sex = "She";
                prefix_sex = "Ms ";

            }
            //set the student name and sex in report
            TextObject txt_one = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text7"];
            txt_one.Text = "Here certify that" + "  " + prefix_sex + "  " + _student_name + "   " + "has been beneficed  student of Defense Services";

            //set the duration of school life time
            TextObject txt_two = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text8"];
            txt_two.Text = "School during the period" + " " + admission_date + " " + "to" + " " + leave_year + " " + ".";
            //set the student Advanced or Ordinary exam years
            TextObject txt_three = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text9"];
            //check al
            if (al_year != null)
            {
                txt_three.Text = _selected_id_sex + " " + "has been completed" + " " + "Advanced Level in year" + " " + al_year;
            }
            else if (al_year == null)
            {//if student has not done AL then go to OL years
                ol_year = get_student_OL_year(st_id);
                if (ol_year != null)
                {//print the student exam years
                    txt_three.Text = " " + _selected_id_sex + " " + "has been completed" + " " + "Ordinary Level in year" + " " + ol_year;

                }
                else
                {
                    txt_three.Text = " " + _selected_id_sex + " " + "has been completed" + " " + "Grade" + " " + "                 " + ".";

                }
            }

            TextObject txt_four = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text11"];
            txt_four.Text = "In addition to that" + " " + _selected_id_sex + " " + "has been achived following during the school life time";
        }
        catch (Exception cc)
        {
            string bb = cc.Message;
            Response.Write("<script>alert('Error in processing, Please try again')</script>");


        }

    }
    // specify the student extra curricular activities
    public void set_Extra_curriculars(string stid)
    {
        string sport = null;
        string startyear = null;
        string performance = null;
        DataTable dt = get_extra_curricular(_student_id);
        TextObject txt_extra_one = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text13"];
        if (dt.Rows.Count == 0)
        {//if student has not invole any extra activity mention that
            txt_extra_one.Text = _selected_id_sex + " has not participated in any extra curricular actiities";
        }
        else
        {//if there any extra activity mention that
            sport = dt.Rows[0]["ACTIVITYSUB_CODE"].ToString();
            startyear = dt.Rows[0]["ACTIVITY_YEAR"].ToString();
            performance = dt.Rows[0]["ACTIVITY_DESCRIPTION"].ToString();
            txt_extra_one.Text = _selected_id_sex + " " + "has been member of" + " " + sport + " " + "team," + " " + "since" + " " + startyear + " " + "showing" + " " + performance + " " + "performance.";
        }
    }
    //specify the student prefect details
    public void set_prefect_deatils(string stid)
    {
        //invoke student prefect detail method
        DataTable dt = get_prefect_details(_student_id);
        TextObject txt_extra_prefect = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text14"];
        if (dt.Rows.Count == 0)
        {
            txt_extra_prefect.Text = _selected_id_sex + " has not any experiance relevant to prefect activities";
        }
        else
        {

            //get all the student prefects detaiils
            string changing_text = null;
            int head_prefect = Convert.ToInt32(dt.Rows[0]["SENIORHPREFECT_YEAR"]);
            int dupty_head = Convert.ToInt32(dt.Rows[0]["SENIORDHPREFECT_YEAR"].ToString());
            int senior = Convert.ToInt32(dt.Rows[0]["SENIORPREFECT_YEAR"].ToString());
            int junior_head = Convert.ToInt32(dt.Rows[0]["JUNIORHPREFECT_YEAR"].ToString());
            int junior_deputy = Convert.ToInt32(dt.Rows[0]["JUNIORDHPREFECT_YEAR"].ToString());
            int junior = Convert.ToInt32(dt.Rows[0]["JUNIORPREFECT_YEAR"].ToString());

            //step by step go through all the prefect information a
            if (head_prefect != 0)
            {
                changing_text = "has been worked as the Head Prefect of the school" + " " + "in year" + " " + head_prefect.ToString();

            }
            else if (head_prefect == 0 && dupty_head != 0)
            {
                changing_text = "has been worked as a Deputy Head Prefect of the school" + " " + "in year" + " " + dupty_head.ToString();

            }
            else if (head_prefect == 0 && dupty_head == 0 && senior != 0)
            {
                changing_text = "has been worked as a Senior Prefect of the school" + " " + "in year" + " " + senior.ToString();
            }
            else if (head_prefect == 0 && dupty_head == 0 && senior == 0 && junior_head != 0)
            {
                changing_text = "has been worked as the Junior Head Prefect of the school" + " " + "in year" + " " + junior_head.ToString();

            }

            else if (head_prefect == 0 && dupty_head == 0 && senior == 0 && junior_head == 0 && junior_deputy != 0)
            {
                changing_text = "has been worked as a Junior Deputy Head Prefect of the school" + " " + "in year" + " " + junior_deputy;
            }
            else if (head_prefect == 0 && dupty_head == 0 && senior == 0 && junior_head == 0 && junior_deputy == 0 && junior == 0)
            {
                changing_text = "has been worked as a Junior  Prefect of the school" + " " + "in year" + " " + junior.ToString();
            }
            else
            {
                txt_extra_prefect.Text = null;

            }

            txt_extra_prefect.Text = "And also" + " " + _selected_id_sex + " " + changing_text + "" + ".";
        }


    }
    //specify the student prefect detils
    public void set_special_awards(string stid)
    {
        DataTable dt = get_student_specialawards(_student_id);
        TextObject txt_awards_one = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text17"];

        if (dt.Rows.Count == 0)
        {//if not any special awards metion that
            txt_awards_one.Text = _selected_id_sex + " has not been awarded for any special awards.";
        }
        else
        {//if any special awards , mention that
            string note = dt.Rows[0]["NOTE"].ToString();
            string year = dt.Rows[0]["AWARDED_YEAR"].ToString();
            txt_awards_one.Text = _selected_id_sex + " " + "has been won " + " " + note + " " + "in year" + " " + year + "" + ".";
        }

    }
    //specify the student warning
    public void set_student_warnings(string stid)
    {
        DataTable dt = get_warning(stid);
        TextObject txt_warns_one = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text19"];
        TextObject txt_warns_two = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text20"];
        TextObject txt_warns_heading = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text18"];
        TextObject txt_prdiciton_one = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text21"];
        TextObject txt_prdiciton_two = (TextObject)doc.ReportDefinition.Sections["Section2"].ReportObjects["Text22"];
        if (dt.Rows.Count < 1)
        {//predict the studen t behaviour accordig to the number of recors in warnings
            txt_warns_one.Text = "The general conduct during the school period is Satisfactory. So that " + _selected_id_sex + " was a moral ";
            txt_warns_two.Text = "character during the school life time.";
            txt_warns_heading.Text = null;
        }
        else if (dt.Rows.Count < 2)
        {
            string warn_note = dt.Rows[0]["NOTE"].ToString();
            string year = dt.Rows[0]["WARN_DATE"].ToString().Substring(5, 4);
            txt_warns_one.Text = _selected_id_sex + " " + "has been warned due to " + warn_note + " in year " + year + " .";
            txt_warns_two.Text = null;
            txt_prdiciton_one.Text = "The general conduct during the school period is Normal.";
            txt_prdiciton_two.Text = null;
        }
        else if (dt.Rows.Count == 2 || dt.Rows.Count > 2)
        {
            txt_warns_one.Text = "The general conduct during the school period is Non Satisfactory.";
            txt_warns_two.Text = null;
            txt_prdiciton_one.Text = null;
            txt_prdiciton_two.Text = null;


        }

    }
    //implement method to get student warnings
    public DataTable get_warning(string id)
    {
        dt_studentwarnings = new DataTable();
        OdbcConnection con = new OdbcConnection(Path);
        con.Open();
        OdbcDataAdapter dap = new OdbcDataAdapter("select * from student_warning where ADMISSION_NO='" + id + "'and LEVEL_CODE='Critical'", con);
        dap.Fill(dt_studentwarnings);
        con.Close();
        return dt_studentwarnings;


    }
    //implement method to get student special awards
    public DataTable get_student_specialawards(string id)
    {
        dt_special_awards = new DataTable();
        OdbcConnection con = new OdbcConnection(Path);
        con.Open();
        OdbcDataAdapter dap = new OdbcDataAdapter("select * from special_awards where ADMISSION_NO='" + id + "'", con);
        dap.Fill(dt_special_awards);
        con.Close();
        return dt_special_awards;
    }
    //implement methode to get prefect details
    public DataTable get_prefect_details(string id)
    {
        dt_student_prefect_details = new DataTable();
        OdbcConnection con = new OdbcConnection(Path);
        con.Open();
        OdbcDataAdapter ada = new OdbcDataAdapter("select * from prefects where ADMISSION_NO='" + id + "'", con);
        ada.Fill(dt_student_prefect_details);
        con.Close();
        return dt_student_prefect_details;
    }
    //implement methid to get extar curruclar activiies
    public DataTable get_extra_curricular(string id)
    {

        dt_extracurricular = new DataTable();
        OdbcConnection con = new OdbcConnection(Path);
        con.Open();
        OdbcDataAdapter apd = new OdbcDataAdapter("select * from extra_activity where ADMISSION_NO='" + id + "'", con);
        apd.Fill(dt_extracurricular);
        con.Close();
        return dt_extracurricular;

    }

    //get student leave year
    public string get_student_leave_year(string id)
    {
        try
        {

            string leave_date = null;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcCommand cmd = new OdbcCommand("select SL_YEAR from student_leave where ADMISSION_NO='" + id + "'", con);
            OdbcDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                leave_date = red.GetValue(0).ToString();
            }
            con.Close();
            return leave_date;
        }
        catch (Exception cc)
        {
            //rfv_txt_searchKey.Text = cc.ToString();

        }
        return null;
    }
    //get student al year
    public string get_student_AL_year(string id)
    {
        try
        {
            string year = null;
            OdbcConnection conn = new OdbcConnection(Path);
            conn.Open();
            OdbcCommand cmd = new OdbcCommand("select AL_YEAR from al_results where ADMISSION_NO='" + id + "'", conn);
            OdbcDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                year = read.GetValue(0).ToString();
            }
            conn.Close();
            return year;
        }
        catch (Exception ss)
        {
            //rfv_txt_searchKey.Text = ss.ToString();

        }
        return null;
    }
    //get studnt ol year
    public string get_student_OL_year(string id)
    {
        try
        {
            string year = null;
            OdbcConnection conn = new OdbcConnection(Path);
            conn.Open();
            OdbcCommand cmd = new OdbcCommand("select OL_YEAR from ol_results where ADMISSION_NO='" + id + "'", conn);
            OdbcDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                year = read.GetValue(0).ToString();
            }
            conn.Close();
            return year;
        }
        catch (Exception ss)
        {
            

        }
        return null;
    }
}

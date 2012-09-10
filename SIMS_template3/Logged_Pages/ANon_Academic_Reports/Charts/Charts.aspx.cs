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
    //define the path to datase
    string Path = "Dsn=nsis;uid=root;pwd=123";
    //define comman variables to hold function positions
    static int _position = 0;
    static string _student_id = null;
    static string _student_name = null;
    static ReportDocument rd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }


    protected void gv_extracurricular_log_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void btn_SA_individual_Click(object sender, EventArgs e)
    //{
    //    //clear all other drop down lists
    //    ddl_studentBase.Items.Clear();
    //    ddl_over_base.Items.Clear();
    //    ddl_overSubbase.Items.Clear();
    //    ddl_overSubbase02.Items.Clear();
    //    // clear drop down litsts relevant to chart generation
    //    clear_graph();

    //    _position = 1;
    //    try
    //    {
    //        //fill ddl_studentbase drop down list
    //        ddl_allstudentId.DataSource = get_all_studentid();
    //        ddl_allstudentId.DataValueField = "ADMISSION_NO";
    //        ddl_allstudentId.DataMember = "ADMISSION_NO";
    //        ddl_allstudentId.DataBind();
    //    }
    //    catch
    //    {
    //        //catch if any exception occurs
    //        Response.Write("<script>alert('Error in Processing, Try again')");
    //    }  
    //}
    //generate relevant report
    protected void ibtn_viewReport_Click(object sender, ImageClickEventArgs e)
    {
        //try
        //{//position specify the current selected report type
        //    if (_position == 1)
        //    {
        //        //hold student name selected from the drop down list
        //        _student_id = ddl_allstudentId.Text;
        //        //get student name from the get_studentname method
        //        _student_name = get_studentName(_student_id);
        //        if (ddl_studentBase.SelectedIndex == 5)
        //        {
        //            //create new report document
        //            rd = new ReportDocument();
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Individual//CrystalReport_individual_overoll.rpt"));
        //            //print student basic details 
        //            generate_individual_Basics(rd, _student_id);
        //        }
        //        else
        //        {
        //            if (ddl_studentBase.SelectedIndex == 1)
        //            {
        //                rd = new ReportDocument();
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_sport.rpt"));
        //                //print student basic details 
        //                generate_individual_Basics(rd, _student_id);
        //                //print each students individual sport details
        //                print_individual_sports(rd);
        //            }
        //            else if (ddl_studentBase.SelectedIndex == 2)
        //            {
        //                rd = new ReportDocument();
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_specislawards.rpt"));
        //                //print student basic details 
        //                generate_individual_Basics(rd, _student_id);
        //                //print each students individual special awards
        //                print_individual_special_awards(rd);
        //            }
        //            else if (ddl_studentBase.SelectedIndex == 3)
        //            {
        //                rd = new ReportDocument();
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_extraactivity.rpt"));
        //                //print student basic details 
        //                generate_individual_Basics(rd, _student_id);
        //                //print each students extra curricualr activites
        //                print_individual_extra_curricularactivites(rd);
        //            }
        //            else if (ddl_studentBase.SelectedIndex == 4)
        //            {
        //                rd = new ReportDocument();
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_Prefect.rpt"));
        //                //print student basic details 
        //                generate_individual_Basics(rd, _student_id);
        //                //print each sutudents prefect details
        //                print_individual_prefet_details(rd);
        //            }

        //        }
        //    }
        //    else if (_position == 2)
        //    {
        //        if (ddl_over_base.SelectedIndex == 1)
        //        {

        //            rd = new ReportDocument();
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
        //            //set overoll report with parametrs providing at run time involned with sports activities
        //            set_report_withfilter(rd, ddl_overSubbase.Text, ddl_overSubbase02.Text);



        //        }
        //        else if (ddl_over_base.SelectedIndex == 2)
        //        {
        //            rd = new ReportDocument();
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Specialawards.rpt"));
        //            //set overoll report with parametrs providing at run time involned with special award details
        //            Set_report_specialawards_withyear(rd, ddl_overSubbase02.Text);
        //        }
        //        else if (ddl_over_base.SelectedIndex == 3)
        //        {
        //            rd = new ReportDocument();
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
        //            //set overoll report with parametrs providing at run time involned with extra activities
        //            set_report_withfilter(rd, ddl_overSubbase.Text, ddl_overSubbase02.Text);
        //        }

        //        else if (ddl_over_base.SelectedIndex == 4)
        //        {
        //            rd = new ReportDocument();
        //            if (ddl_overSubbase02.SelectedIndex == 1)
        //            {
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
        //                //define report conatin all the sports in the school
        //                Set_report_allsports(rd);
        //            }
        //            else if (ddl_overSubbase02.SelectedIndex == 2)
        //            {
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
        //                //define report conatin all the Extra_activitesin the school
        //                Set_report_allExtra_activites(rd);
        //            }
        //            else if (ddl_overSubbase02.SelectedIndex == 3)
        //            {
        //                //load the report from the selected location
        //                rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Prefects.rpt"));
        //                //define all the pr
        //                set_report_Prefects(rd);
        //            }

        //        }


        //    }
        //    else if (_position == 3)
        //    {
        //        rd = new ReportDocument();
        //        if (ddl_chart_Basetype.SelectedIndex == 1)
        //        {
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_full.rpt"));
        //            get_chart_extra(rd);
        //        }
        //        else if (ddl_chart_Basetype.SelectedIndex == 2)
        //        {
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_spotvise.rpt"));
        //            get_report_extravise(rd, ddl_chartsSubbase.Text);
        //        }
        //        else if (ddl_chart_Basetype.SelectedIndex == 3)
        //        {
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Charts//CrystalReport_sport_with_year.rpt"));
        //            get_chart_with_year(rd, ddl_chartsSubbase.Text);

        //        }
        //    }
        //    else if (_position == 4)
        //    {

        //        rd = new ReportDocument();
        //        if (ddl_chart_Basetype.SelectedIndex == 1)
        //        {
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_full.rpt"));
        //            getreport(rd);
        //        }
        //        else if (ddl_chart_Basetype.SelectedIndex == 2)
        //        {
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_spotvise.rpt"));
        //            get_report_sportvise(rd, ddl_chartsSubbase.Text);
        //        }
        //        else if (ddl_chart_Basetype.SelectedIndex == 3)
        //        {
        //            //load the report from the selected location
        //            rd.Load(Server.MapPath("Reports//Charts//CrystalReport_sport_with_year.rpt"));
        //            get_chart_extra_with_year(rd, ddl_chartsSubbase.Text);
        //        }
        //    }
        //    //set the report sorce to the report

        //    crv_studentParticipation.ReportSource = rd;
        //    //refresh the report content
        //    crv_studentParticipation.RefreshReport();
        //}
        //catch
        //{
        //    //prompt an error message if any exception occurs
        //    Response.Write("<script>alert('Error in Processing, Try again')");

        //}
    }

    ////-------------------related to individual getters-----------------------------------------------------------------------

    //---------------------individual Reports----------------------------------------------------------------------------------
    //generate the basic student details like name and student id
    public void generate_individual_Basics(ReportDocument rd, string id)
    {
        try
        {
            //define text object to send to report
            TextObject txt_id = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text6"];
            txt_id.Text = _student_id;
            //define text object to send to report
            TextObject txt_name = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text5"];
            txt_name.Text = _student_name;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please Try Again')");
        }
    }
    public void print_individual_sports(ReportDocument rd)
    {
        try
        {
            DataTable dt = get_individual_sport_details(_student_id);
            //define text object to send data to report at run time 
            TextObject ee = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
            if (dt.Rows.Count == 0)
            {
                //display the text  if there are no any data relevant to the selection
                ee.Text = "The selected student has not been participated for any sport activity";
            }
            else
            {
                //display the text  if there are data relevant to the selection
                ee.Text = "The selected student has been involved with following sports";
            }
            //set the generetd data table as the datasource of the report
            rd.SetDataSource(dt);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");

        }
    }
    public void print_individual_special_awards(ReportDocument rd)
    {
        try
        {
            DataTable dt = get_individual_specialawards_details(_student_id);
            //define variable to hold the send data to report at run time
            TextObject ee = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
            if (dt.Rows.Count == 0)
            {
                //display the text  if there are no any data relevant to the selection
                ee.Text = "The selected student has not been awarded for any activity";
            }
            else
            {
                //display the text  if there are data relevant to the selection
                ee.Text = "The selected student has been awarded for followings";
            }
            //set the generetd data table as the datasource of the report
            rd.SetDataSource(dt);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    public void print_individual_extra_curricularactivites(ReportDocument rd)
    {
        try
        {
            DataTable dt = get_individual_extra_curricularactivities(_student_id);
            //define variable to hold the send data to report at run time
            TextObject ee = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
            if (dt.Rows.Count == 0)
            {
                //display the text  if there are no any data relevant to the selection
                ee.Text = "The selected student has not been participated for any extra curricular activity";
            }
            else
            {
                //display the text  if there are data relevant to the selection
                ee.Text = "The selected student has been involved in following acitivities";
            }
            //set the generetd data table as the datasource of the report
            rd.SetDataSource(dt);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");

        }
    }
    public void print_individual_prefet_details(ReportDocument rd)
    {
        try
        {
            DataTable dt = get_prefect_details(_student_id);
            //define variable to hold the send data to report at run time
            TextObject ee = (TextObject)rd.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
            if (dt.Rows.Count == 0)
            {
                //display the text  if there are no any data relevant to the selection
                ee.Text = "The selected student has not been work as prefect";
            }
            else
            {
                //display the text  if there are data relevant to the selection
                ee.Text = "The selected student has been worked as prefect as followings";
            }
            //set the generetd data table as the datasource of the report

            rd.SetDataSource(dt);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");

        }
    }
    //---------------------end of individual Reports---------------------------
    //get all the student ids
    public DataTable get_all_studentid()
    {
        try
        {
            DataTable dt_alllstudent;
            //define new connection with the database
            OdbcConnection con = new OdbcConnection(Path);
            //open the connection
            con.Open();
            //define dataadapter object to retrive the data
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ADMISSION_NO from extra_activity", con);
            dt_alllstudent = new DataTable();
            //fill the datatable with selected values
            adapter.Fill(dt_alllstudent);
            //colse the connection after filling data
            con.Close();
            //return the filled datatable object
            return dt_alllstudent;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('incorrect input')</script>");
            ddl_allstudentId.Items.Clear();
        }
        return null;
    }

    public void fill_ddl_studentBase()
    {
        //fill the ddl_studentBase drop down list
        ddl_studentBase.Items.Insert(0, "");
        ddl_studentBase.Items.Insert(1, "In Sports");
        ddl_studentBase.Items.Insert(2, "In Special Awards");
        ddl_studentBase.Items.Insert(3, "In Extra Activities");
        ddl_studentBase.Items.Insert(4, "Prefect Details");
        ddl_studentBase.Items.Insert(5, "OverRoll Report");
    }
    //get all sport name s from the databse
    public DataTable get_all_sports()
    {
        try
        {
            DataTable dt_allsports;
            OdbcConnection con = new OdbcConnection(Path);
            con.Close();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ACTIVITYSUB_CODE from extra_activity where ACTIVITY_CODE='Sports'", con);
            dt_allsports = new DataTable();
            adapter.Fill(dt_allsports);
            con.Close();
            return dt_allsports;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Invalid Operation')</script>");

        }
        return null;
    }
    //get all awarded years from the databse
    public DataTable get_all_years()
    {
        try
        {
            DataTable dt_allyears;
            OdbcConnection con = new OdbcConnection(Path);
            con.Close();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct AWARDED_YEAR from special_awards", con);
            dt_allyears = new DataTable();
            adapter.Fill(dt_allyears);
            con.Close();
            return dt_allyears;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Invalid Operation')</script>");

        }
        return null;
    }
    //get all years from the databse where type is extra
    public DataTable get_all_extraactivities()
    {
        try
        {
            DataTable dt_extraactivity;
            OdbcConnection con = new OdbcConnection(Path);
            con.Close();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ACTIVITYSUB_CODE from extra_activity where ACTIVITY_CODE='Extra'", con);
            dt_extraactivity = new DataTable();
            adapter.Fill(dt_extraactivity);
            con.Close();
            return dt_extraactivity;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Invalid Operation')</script>");

        }
        return null;
    }
    //get  the specif student  names from the data base 
    public string get_studentName(string id)
    {
        try
        {
            string st_name = null;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcCommand cmd = new OdbcCommand("select NAME_FULL from student_mast where ADMISSION_NO='" + id + "'", con);
            //declare a datareader object and execute the selection quary 
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //while data readng select the relevant student name
                st_name = reader[0].ToString();

            }
            con.Close();
            return st_name;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert(' Error In Processing, Try again')</script>");
        }
        return null;
    }
    //retrive all individuals sport activity information
    public DataTable get_individual_sport_details(string stid)
    {
        try
        {
            DataTable dt_in_sport;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity where ADMISSION_NO='" + stid + "' and ACTIVITY_CODE='Sport'", con);
            dt_in_sport = new DataTable();
            adapter.Fill(dt_in_sport);
            con.Close();
            return dt_in_sport;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please Try Again')");
        }
        return null;
    }
    //retrive all the individual special awards from the databse
    public DataTable get_individual_specialawards_details(string stid)
    {
        try
        {
            DataTable dt_in_specialwards;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from special_awards where ADMISSION_NO='" + stid + "'", con);
            dt_in_specialwards = new DataTable();
            adapter.Fill(dt_in_specialwards);
            con.Close();
            return dt_in_specialwards;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please Try Again')");
        }
        return null;
    }
    //retrive all the individual extra_curricularactivities from the databse
    public DataTable get_individual_extra_curricularactivities(string stid)
    {
        try
        {
            DataTable dt_in_extra_activity;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity where ADMISSION_NO='" + stid + "' and ACTIVITY_CODE='Extra'", con);
            dt_in_extra_activity = new DataTable();
            adapter.Fill(dt_in_extra_activity);
            con.Close();
            return dt_in_extra_activity;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please Try Again')");
        }
        return null;
    }
    //retrive all the individual prefect_details from the databse
    public DataTable get_prefect_details(string stid)
    {
        try
        {
            DataTable dt_prefects;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from prefects where ADMISSION_NO='" + stid + "'", con);
            dt_prefects = new DataTable();
            adapter.Fill(dt_prefects);
            con.Close();
            return dt_prefects;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please Try Again')");
        }
        return null;
    }
    //----------------------------------------------------------------------------------------
    // fill the ssl_student drop down list with alll student ids
    //protected void ddl_allstudentId_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //refresh the ddl_studentBase drop down list and refill it
    //    ddl_studentBase.Items.Clear();
    //    fill_ddl_studentBase();
    //}
    protected void btn_SA_overoll_Click(object sender, EventArgs e)
    {
        ////refresh all other not relevant drop down lists 
        //_position = 2;
        //ddl_allstudentId.Items.Clear();
        //ddl_studentBase.Items.Clear();
        //ddl_overSubbase.Items.Clear();
        //ddl_overSubbase02.Items.Clear();
        //clear_graph();
        ////fill the ddl_overbase drop down list
        //fill_ddl_overbase();
    }
    //protected void btn_charts_extra_Click(object sender, EventArgs e)
    //{
    //    //refresh all other not relevant drop down lists 
    //    _position = 3;
    //    ddl_chart_Basetype.Items.Clear();
    //    ddl_chartsSubbase.Items.Clear();
    //    //fill the ddl_chart_base_extraActivity drop down list
    //    fill_ddl_chart_base_extraActivity();
    //    clear_non_graph();
    //}

    //----------------------overroll_settings-----------------
    public void fill_ddl_overbase()
    {
        //insert items to the  ddl_over_base database
        ddl_over_base.Items.Clear();
        ddl_over_base.Items.Insert(0, "");
        ddl_over_base.Items.Insert(1, "Sports");
        ddl_over_base.Items.Insert(2, "Special Awards");
        ddl_over_base.Items.Insert(3, "Extra Activities");
        ddl_over_base.Items.Insert(4, "Full Reports");

    }
    //get all sport involved years
    public DataTable getall_sport_years()
    {
        try
        {
            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ACTIVITY_YEAR from extra_activity where ACTIVITY_CODE='Sports'", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please try again')</script>");
        }
        return null;
    }
    //get all extra activity involved years
    public DataTable getall_extra_years()
    {
        try
        {
            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ACTIVITY_YEAR from extra_activity where ACTIVITY_CODE='Extra'", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Please try again')</script>");
        }
        return null;
    }
    //fill ddl_oversubbase drop down list
    public void fill_overoll_sub_02_sports()
    {
        try
        {
            ddl_overSubbase02.DataSource = getall_sport_years();
            ddl_overSubbase02.DataTextField = "ACTIVITY_YEAR";
            ddl_overSubbase02.DataMember = "ACTIVITY_YEAR";
            ddl_overSubbase02.DataBind();
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }

    }
    //fill ddl_oversubbase02 drop down list
    public void fill_overoll_sub_02_Extra()
    {
        try
        {
            ddl_overSubbase02.DataSource = getall_extra_years();
            ddl_overSubbase02.DataTextField = "ACTIVITY_YEAR";
            ddl_overSubbase02.DataMember = "ACTIVITY_YEAR";
            ddl_overSubbase02.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('Error in Processing, Try again')");
        }

    }
    //fill ddl_oversubbase02 drop down list with awarded years
    public void fill_overoll_sub_02_Awarede()
    {
        try
        {
            ddl_overSubbase02.DataSource = get_all_years();
            ddl_overSubbase02.DataTextField = "AWARDED_YEAR";
            ddl_overSubbase02.DataMember = "AWARDED_YEAR";
            ddl_overSubbase02.DataBind();
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }

    }

    //detect relevant items that must be filled with the ddl_over_base drop down list
    //protected void ddl_over_base_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        if (ddl_over_base.SelectedIndex == 1)
    //        {

    //            ddl_overSubbase02.Items.Clear();
    //            ddl_overSubbase.DataSource = get_all_sports();
    //            ddl_overSubbase.DataValueField = "ACTIVITYSUB_CODE";
    //            ddl_overSubbase.DataMember = "ACTIVITYSUB_CODE";
    //            ddl_overSubbase.DataBind();
    //            fill_overoll_sub_02_sports();

    //        }
    //        else if (ddl_over_base.SelectedIndex == 2)
    //        {
    //            ddl_overSubbase.Items.Clear();
    //            ddl_overSubbase02.Items.Clear();
    //            fill_overoll_sub_02_Awarede();
    //        }
    //        else if (ddl_over_base.SelectedIndex == 3)
    //        {
    //            ddl_overSubbase.Items.Clear();
    //            ddl_overSubbase02.Items.Clear();
    //            ddl_overSubbase.DataSource = get_all_extraactivities();
    //            ddl_overSubbase.DataValueField = "ACTIVITYSUB_CODE";
    //            ddl_overSubbase.DataMember = "ACTIVITYSUB_CODE";
    //            ddl_overSubbase.DataBind();
    //            fill_overoll_sub_02_Extra();
    //        }

    //        else if (ddl_over_base.SelectedIndex == 4)
    //        {
    //            ddl_overSubbase.Items.Clear();
    //            ddl_overSubbase02.Items.Clear();
    //            ddl_overSubbase02.Items.Insert(0, "Select type");
    //            ddl_overSubbase02.Items.Insert(1, "Sports");
    //            ddl_overSubbase02.Items.Insert(2, "Extra Activity");
    //            ddl_overSubbase02.Items.Insert(3, "Prefects");
    //        }
    //    }
    //    catch
    //    {
    //        //prompt an error message if any exception occurs
    //        Response.Write("<script>alert('Error in Processing, Try again')");
    //    }
    //}
    //protected void ddl_overSubbase_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fill_overoll_sub_02_sports();
    //}

    public void set_report_withfilter(ReportDocument rd, string activity, string year)
    {
        try
        {

            DataTable get_data = get_activity_with_filter(activity, year);
            //define text object to send to report
            TextObject txt_topic = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text2"];
            if (get_data.Rows.Count != 0)
            {
                //ensure that the retrived data table is not empty
                txt_topic.Text = "OverRoll " + activity + " Progress in Year  " + year;
            }
            else
            {
                //if retrived data table is empty set the text object, mentioning it is empty
                txt_topic.Text = "No Data in selected field";

            }
            //set the data source of the report object
            rd.SetDataSource(get_data);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //set the report with prefect details
    public void set_report_Prefects(ReportDocument rd)
    {
        try
        {

            DataTable get_data = get_all_prefects();
            //define text object to send to report
            TextObject txt_topic = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text2"];
            if (get_data.Rows.Count != 0)
            {
                //ensure that the retrived data table is not empty
                txt_topic.Text = "OverRoll Prefetcs Details";
            }
            else
            {
                //if retrived data table is empty set the text object, mentioning it is empty
                txt_topic.Text = "No Data in selected field";

            }
            //set the data source of the report object
            rd.SetDataSource(get_data);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    public void Set_report_specialawards_withyear(ReportDocument rd, string Year)
    {
        try
        {

            DataTable get_data = get_specialawards_with_year(Year);
            //define text object to send to report
            TextObject txt_topic = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text2"];
            if (get_data.Rows.Count != 0)
            {
                //ensure that the retrived data table is not empty
                txt_topic.Text = "OverRoll  Special Award's  in Year  " + Year + "";
            }
            else
            {
                //if retrived data table is empty set the text object, mentioning it is empty
                txt_topic.Text = "No data in selected field";

            }
            //set the data source of the report object
            rd.SetDataSource(get_data);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");

        }
    }
    public void Set_report_allsports(ReportDocument rd)
    {
        try
        {

            DataTable get_data = get_overoll_allsports();
            //define text object to send to report
            TextObject txt_topic = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text2"];
            if (get_data.Rows.Count != 0)
            {
                //ensure that the retrived data table is not empty
                txt_topic.Text = "OverRoll  Sports Activity Details";
            }
            else
            {
                //if retrived data table is empty set the text object, mentioning it is empty
                txt_topic.Text = "No data in selected field";

            }
            //set the data source of the report object
            rd.SetDataSource(get_data);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    public void Set_report_allExtra_activites(ReportDocument rd)
    {
        try
        {

            DataTable get_data = get_overoll_allextra();
            //define text object to send to report
            TextObject txt_topic = (TextObject)rd.ReportDefinition.Sections["Section1"].ReportObjects["Text2"];
            if (get_data.Rows.Count != 0)
            {
                //ensure that the retrived data table is not empty
                txt_topic.Text = "OverRoll  Extra Curricular Activity Details";
            }
            else
            {
                //if retrived data table is empty set the text object, mentioning it is empty
                txt_topic.Text = "No data in selected field";

            }
            //set the data source of the report object
            rd.SetDataSource(get_data);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //retrive data table object that has records relevant toextra activity
    public DataTable get_overoll_allextra()
    {
        try
        {

            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity where ACTIVITY_CODE='Extra'", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in processing, Please try again')</script>");

        }
        return null;

    }
    //retrive data table object that has records relevant to sport activity
    public DataTable get_overoll_allsports()
    {
        try
        {

            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity where ACTIVITY_CODE='Sports'", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in processing, Please try again')</script>");

        }
        return null;

    }
    //retrive data table object that has records relevant to special awardes activity
    public DataTable get_specialawards_with_year(string year)
    {
        try
        {

            decimal years = Convert.ToDecimal(year);
            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from special_awards where AWARDED_YEAR='" + years + "'", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in processing, Please try again')</script>");

        }
        return null;
    }
    //retrive data table object that has records relevant toextra activity with user providede filterings
    public DataTable get_activity_with_filter(string activity, string year)
    {
        try
        {

            int years = Convert.ToInt32(year);
            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity where ACTIVITYSUB_CODE='" + activity + "' and ACTIVITY_YEAR=" + years + "", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in processing, Please try again')</script>");

        }
        return null;

    }
    //retrive data table object that has records relevant toe xtra activity with user providede filterings
    public DataTable get_activity_with_out_filter(string activity)
    {
        try
        {
            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity where ACTIVITYSUB_CODE='" + activity + "'", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in processing, Please try again')</script>");

        }
        return null;
    }
    //retrive data table object that has records relevant to prefcts details
    public DataTable get_all_prefects()
    {
        try
        {
            DataTable dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from prefects ", con);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in processing, Please try again')</script>");

        }
        return null;

    }
    //---------------------end--------------------------------
    //------------chart generation--------------------------------------
    //clear all drop down lists relevant chart generation
    //protected void btn_chart_sports_Click(object sender, EventArgs e)
    //{
    //    _position = 4;
    //    ddl_chart_Basetype.Items.Clear();
    //    ddl_chartsSubbase.Items.Clear();
    //    clear_non_graph();
    //    fill_ddl_chart_base_sports();
    //}


    //protected void ddl_chart_Basetype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddl_chart_Basetype.SelectedIndex == 1)
    //    {
    //        ddl_chartsSubbase.Items.Clear();

    //    }
    //    else if (ddl_chart_Basetype.SelectedIndex == 2)
    //    {
    //        try
    //        {
    //            if (_position == 4)
    //            {
    //                ddl_chartsSubbase.DataSource = get_all_sports();
    //                ddl_chartsSubbase.DataValueField = "ACTIVITYSUB_CODE";
    //                ddl_chartsSubbase.DataMember = "ACTIVITYSUB_CODE";
    //                ddl_chartsSubbase.DataBind();

    //            }
    //            else if (_position == 3)
    //            {
    //                ddl_chartsSubbase.DataSource = get_all_extraactivities();
    //                ddl_chartsSubbase.DataValueField = "ACTIVITYSUB_CODE";
    //                ddl_chartsSubbase.DataMember = "ACTIVITYSUB_CODE";
    //                ddl_chartsSubbase.DataBind();

    //            }
    //        }
    //        catch
    //        {
    //            Response.Write("<script>alert('Error in Processing, Try again')");
    //        }

    //    }
    //    else if (ddl_chart_Basetype.SelectedIndex == 3)
    //    {
    //        try
    //        {
    //            if (_position == 4)
    //            {
    //                ddl_chartsSubbase.DataSource = getall_sport_years();
    //                ddl_chartsSubbase.DataValueField = "ACTIVITY_YEAR";
    //                ddl_chartsSubbase.DataMember = "ACTIVITY_YEAR";
    //                ddl_chartsSubbase.DataBind();

    //            }
    //            else if (_position == 3)
    //            {
    //                ddl_chartsSubbase.DataSource = getall_extra_years();
    //                ddl_chartsSubbase.DataValueField = "ACTIVITY_YEAR";
    //                ddl_chartsSubbase.DataMember = "ACTIVITY_YEAR";
    //                ddl_chartsSubbase.DataBind();

    //            }
    //        }
    //        catch
    //        {
    //            //prompt an error message if any exception occurs
    //            Response.Write("<script>alert('Error in Processing, Try again')");
    //        }
    //    }
    //}

    public void fill_ddl_chart_base_extraActivity()
    {
        ddl_chart_Basetype.Items.Insert(0, "");
        ddl_chart_Basetype.Items.Insert(1, "Full Report");
        ddl_chart_Basetype.Items.Insert(2, "Acitivity wise");
        ddl_chart_Basetype.Items.Insert(3, "Year wise");
    }
    //fill ddl_chart_Basetype.Items.Insert drop down list
    public void fill_ddl_chart_base_sports()
    {
        ddl_chart_Basetype.Items.Insert(0, "");
        ddl_chart_Basetype.Items.Insert(1, "Full Report");
        ddl_chart_Basetype.Items.Insert(2, "Sport wise");
        ddl_chart_Basetype.Items.Insert(3, "Year wise");
    }
    //fill ddl_chart_Basetype.Items.Insert drop down list
    public void fill_ddl_chats_subbase_sports_year()
    {
        ddl_chartsSubbase.DataSource = getall_sport_years();
        ddl_chartsSubbase.DataTextField = "ACTIVITY_YEAR";
        ddl_chartsSubbase.DataMember = "ACTIVITY_YEAR";
        ddl_chartsSubbase.DataBind();
    }
    //fill ddl_chart_Basetype.Items.Insert drop down list
    public void fill_ddl_chats_subbase_extra_year()
    {
        ddl_chartsSubbase.DataSource = getall_extra_years();
        ddl_chartsSubbase.DataTextField = "ACTIVITY_YEAR";
        ddl_chartsSubbase.DataMember = "ACTIVITY_YEAR";
        ddl_chartsSubbase.DataBind();
    }

    //-------------end fill chart drop down lists-----------
    //------------drow reports-----------------------------
    //select the relevant dataset to drow the report
    public void getreport(ReportDocument rd)
    {
        try
        {
            DataSet ss = getsport();
            rd.SetDataSource(ss);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //draw the report with relevant filterings
    public void get_report_sportvise(ReportDocument rd, string sport)
    {
        try
        {
            DataSet ss = getsport_with_sportname(sport);
            rd.SetDataSource(ss);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //draw the report with relevant filterings
    public void get_report_extravise(ReportDocument rd, string extra)
    {
        try
        {
            DataSet ss = getextra_with_activityname(extra);
            rd.SetDataSource(ss);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //draw the report with relevant filterings
    public void get_chart_with_year(ReportDocument rd, string year)
    {
        try
        {
            DataSet ss = getsport_with_year(year);
            rd.SetDataSource(ss);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //draw the report with relevant filterings
    public void get_chart_extra_with_year(ReportDocument rd, string year)
    {
        try
        {
            DataSet ss = getextra_with_year(year);
            rd.SetDataSource(ss);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //draw the report with relevant filterings
    public void get_chart_extra(ReportDocument rd)
    {
        try
        {
            DataSet extra_set = getextra();
            rd.SetDataSource(extra_set);
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
    }
    //------------end drow reports-----------------------------
    //------------select data to drow reports---------------
    //build dataset with relevant information
    public DataSet getsport()
    {
        try
        {
            DataSet dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,ACTIVITYSUB_CODE,ACTIVITY_YEAR FROM EXTRA_ACTIVITY where ACTIVITY_CODE='Sports'", con);
            dt = new DataSet();
            adapter.Fill(dt, "extra_activity");
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
        return null;
    }
    //build dataset with relevant information accrding to sports
    public DataSet getsport_with_sportname(string sport)
    {
        try
        {
            DataSet dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,ACTIVITYSUB_CODE,ACTIVITY_YEAR FROM EXTRA_ACTIVITY where ACTIVITY_CODE='Sports' and ACTIVITYSUB_CODE='" + sport + "'", con);
            dt = new DataSet();
            adapter.Fill(dt, "extra_activity");
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
        return null;
    }
    //build dataset with relevant information accrding to extra activites
    public DataSet getextra_with_activityname(string extra)
    {
        try
        {
            DataSet dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,ACTIVITYSUB_CODE,ACTIVITY_YEAR FROM EXTRA_ACTIVITY where ACTIVITY_CODE='Extra' and ACTIVITYSUB_CODE='" + extra + "'", con);
            dt = new DataSet();
            adapter.Fill(dt, "extra_activity");
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
        return null;
    }
    //build dataset with relevant information accrding to sports and according to year
    public DataSet getsport_with_year(string year)
    {
        try
        {
            DataSet dt;
            int yr = Convert.ToInt32(year);
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,ACTIVITYSUB_CODE,ACTIVITY_YEAR FROM EXTRA_ACTIVITY where ACTIVITY_CODE='Sports' and ACTIVITY_YEAR=" + yr + "", con);
            dt = new DataSet();
            adapter.Fill(dt, "extra_activity");
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
        return null;
    }
    //build dataset with relevant information accrding to extra activites
    public DataSet getextra()
    {
        try
        {
            DataSet dt;
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,ACTIVITYSUB_CODE,ACTIVITY_YEAR FROM EXTRA_ACTIVITY where ACTIVITY_CODE='Extra'", con);
            dt = new DataSet();
            adapter.Fill(dt, "extra_activity");
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
        return null;
    }
    //build dataset with relevant information accrding to extra activites  with years filtering
    public DataSet getextra_with_year(string year)
    {
        try
        {
            DataSet dt;
            int yr = Convert.ToInt32(year);
            OdbcConnection con = new OdbcConnection(Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,ACTIVITYSUB_CODE,ACTIVITY_YEAR FROM EXTRA_ACTIVITY where ACTIVITY_CODE='Extra' where ACTIVITY_YEAR='" + yr + "'", con);
            dt = new DataSet();
            adapter.Fill(dt, "extra_activity");
            con.Close();
            return dt;
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }
        return null;
    }
    //---------------end select data to drow reports------

    //---------------------end of chart generation-------------------------------------------
    //------------------------clear_non_graph()------------------------------------------------------
    //clear report base drop down lists implementation
    public void clear_non_graph()
    {
        ddl_allstudentId.Items.Clear();
        ddl_over_base.Items.Clear();

    }
    //clear report base drop down lists implementation
    public void clear_graph()
    {
        ddl_chart_Basetype.Items.Clear();
        ddl_chartsSubbase.Items.Clear();

    }
    protected void btn_SA_individual_Click1(object sender, EventArgs e)
    {
        //clear all other drop down lists
        ddl_studentBase.Items.Clear();
        ddl_over_base.Items.Clear();
        ddl_overSubbase.Items.Clear();
        ddl_overSubbase02.Items.Clear();
        // clear drop down litsts relevant to chart generation
        clear_graph();

        _position = 1;
        try
        {
            //fill ddl_studentbase drop down list
            ddl_allstudentId.DataSource = get_all_studentid();
            ddl_allstudentId.DataValueField = "ADMISSION_NO";
            ddl_allstudentId.DataMember = "ADMISSION_NO";
            ddl_allstudentId.DataBind();
        }
        catch
        {
            //catch if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        } 

    }
    protected void ddl_allstudentId_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddl_studentBase.Items.Clear();
        fill_ddl_studentBase();
    }
    protected void ibtn_viewReport_Click1(object sender, ImageClickEventArgs e)
    {
        try
        {//position specify the current selected report type
            if (_position == 1)
            {
                //hold student name selected from the drop down list
                _student_id = ddl_allstudentId.Text;
                //get student name from the get_studentname method
                _student_name = get_studentName(_student_id);
                if (ddl_studentBase.SelectedIndex == 5)
                {
                    //create new report document
                    rd = new ReportDocument();
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Individual//CrystalReport_individual_overoll.rpt"));
                    //print student basic details 
                    generate_individual_Basics(rd, _student_id);
                }
                else
                {
                    if (ddl_studentBase.SelectedIndex == 1)
                    {
                        rd = new ReportDocument();
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_sport.rpt"));
                        //print student basic details 
                        generate_individual_Basics(rd, _student_id);
                        //print each students individual sport details
                        print_individual_sports(rd);
                    }
                    else if (ddl_studentBase.SelectedIndex == 2)
                    {
                        rd = new ReportDocument();
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_specislawards.rpt"));
                        //print student basic details 
                        generate_individual_Basics(rd, _student_id);
                        //print each students individual special awards
                        print_individual_special_awards(rd);
                    }
                    else if (ddl_studentBase.SelectedIndex == 3)
                    {
                        rd = new ReportDocument();
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_extraactivity.rpt"));
                        //print student basic details 
                        generate_individual_Basics(rd, _student_id);
                        //print each students extra curricualr activites
                        print_individual_extra_curricularactivites(rd);
                    }
                    else if (ddl_studentBase.SelectedIndex == 4)
                    {
                        rd = new ReportDocument();
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Individual//CrystalReport_Individual_Report_Prefect.rpt"));
                        //print student basic details 
                        generate_individual_Basics(rd, _student_id);
                        //print each sutudents prefect details
                        print_individual_prefet_details(rd);
                    }

                }
            }
            else if (_position == 2)
            {
                if (ddl_over_base.SelectedIndex == 1)
                {

                    rd = new ReportDocument();
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
                    //set overoll report with parametrs providing at run time involned with sports activities
                    set_report_withfilter(rd, ddl_overSubbase.Text, ddl_overSubbase02.Text);



                }
                else if (ddl_over_base.SelectedIndex == 2)
                {
                    rd = new ReportDocument();
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Specialawards.rpt"));
                    //set overoll report with parametrs providing at run time involned with special award details
                    Set_report_specialawards_withyear(rd, ddl_overSubbase02.Text);
                }
                else if (ddl_over_base.SelectedIndex == 3)
                {
                    rd = new ReportDocument();
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
                    //set overoll report with parametrs providing at run time involned with extra activities
                    set_report_withfilter(rd, ddl_overSubbase.Text, ddl_overSubbase02.Text);
                }

                else if (ddl_over_base.SelectedIndex == 4)
                {
                    rd = new ReportDocument();
                    if (ddl_overSubbase02.SelectedIndex == 1)
                    {
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
                        //define report conatin all the sports in the school
                        Set_report_allsports(rd);
                    }
                    else if (ddl_overSubbase02.SelectedIndex == 2)
                    {
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Sports.rpt"));
                        //define report conatin all the Extra_activitesin the school
                        Set_report_allExtra_activites(rd);
                    }
                    else if (ddl_overSubbase02.SelectedIndex == 3)
                    {
                        //load the report from the selected location
                        rd.Load(Server.MapPath("Reports//Overoll//CrystalReport_Overoll_Prefects.rpt"));
                        //define all the pr
                        set_report_Prefects(rd);
                    }

                }


            }
            else if (_position == 3)
            {
                rd = new ReportDocument();
                if (ddl_chart_Basetype.SelectedIndex == 1)
                {
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_full.rpt"));
                    get_chart_extra(rd);
                }
                else if (ddl_chart_Basetype.SelectedIndex == 2)
                {
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_spotvise.rpt"));
                    get_report_extravise(rd, ddl_chartsSubbase.Text);
                }
                else if (ddl_chart_Basetype.SelectedIndex == 3)
                {
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Charts//CrystalReport_sport_with_year.rpt"));
                    get_chart_with_year(rd, ddl_chartsSubbase.Text);

                }
            }
            else if (_position == 4)
            {

                rd = new ReportDocument();
                if (ddl_chart_Basetype.SelectedIndex == 1)
                {
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_full.rpt"));
                    getreport(rd);
                }
                else if (ddl_chart_Basetype.SelectedIndex == 2)
                {
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Charts//CrystalReport_chart_spotvise.rpt"));
                    get_report_sportvise(rd, ddl_chartsSubbase.Text);
                }
                else if (ddl_chart_Basetype.SelectedIndex == 3)
                {
                    //load the report from the selected location
                    rd.Load(Server.MapPath("Reports//Charts//CrystalReport_sport_with_year.rpt"));
                    get_chart_extra_with_year(rd, ddl_chartsSubbase.Text);
                }
            }
            //set the report sorce to the report

            crv_studentParticipation.ReportSource = rd;
            //refresh the report content
            crv_studentParticipation.RefreshReport();
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");

        }
    }
    protected void btn_SA_overoll_Click1(object sender, EventArgs e)
    {
        //refresh all other not relevant drop down lists 
        _position = 2;
        ddl_allstudentId.Items.Clear();
        ddl_studentBase.Items.Clear();
        ddl_overSubbase.Items.Clear();
        ddl_overSubbase02.Items.Clear();
        clear_graph();
        //fill the ddl_overbase drop down list
        fill_ddl_overbase();
    }
    protected void ddl_over_base_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {

            if (ddl_over_base.SelectedIndex == 1)
            {

                ddl_overSubbase02.Items.Clear();
                ddl_overSubbase.DataSource = get_all_sports();
                ddl_overSubbase.DataValueField = "ACTIVITYSUB_CODE";
                ddl_overSubbase.DataMember = "ACTIVITYSUB_CODE";
                ddl_overSubbase.DataBind();
                fill_overoll_sub_02_sports();

            }
            else if (ddl_over_base.SelectedIndex == 2)
            {
                ddl_overSubbase.Items.Clear();
                ddl_overSubbase02.Items.Clear();
                fill_overoll_sub_02_Awarede();
            }
            else if (ddl_over_base.SelectedIndex == 3)
            {
                ddl_overSubbase.Items.Clear();
                ddl_overSubbase02.Items.Clear();
                ddl_overSubbase.DataSource = get_all_extraactivities();
                ddl_overSubbase.DataValueField = "ACTIVITYSUB_CODE";
                ddl_overSubbase.DataMember = "ACTIVITYSUB_CODE";
                ddl_overSubbase.DataBind();
                fill_overoll_sub_02_Extra();
            }

            else if (ddl_over_base.SelectedIndex == 4)
            {
                ddl_overSubbase.Items.Clear();
                ddl_overSubbase02.Items.Clear();
                ddl_overSubbase02.Items.Insert(0, "Select type");
                ddl_overSubbase02.Items.Insert(1, "Sports");
                ddl_overSubbase02.Items.Insert(2, "Extra Activity");
                ddl_overSubbase02.Items.Insert(3, "Prefects");
            }
        }
        catch
        {
            //prompt an error message if any exception occurs
            Response.Write("<script>alert('Error in Processing, Try again')");
        }

    }
    protected void ddl_overSubbase_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_overoll_sub_02_sports();
    }
    protected void btn_chart_sports_Click1(object sender, EventArgs e)
    {
        _position = 4;
        ddl_chart_Basetype.Items.Clear();
        ddl_chartsSubbase.Items.Clear();
        clear_non_graph();
        fill_ddl_chart_base_sports();
    }
    protected void btn_charts_extra_Click1(object sender, EventArgs e)
    {
        //refresh all other not relevant drop down lists 
        _position = 3;
        ddl_chart_Basetype.Items.Clear();
        ddl_chartsSubbase.Items.Clear();
        //fill the ddl_chart_base_extraActivity drop down list
        fill_ddl_chart_base_extraActivity();
        clear_non_graph();
    }
    protected void ddl_chart_Basetype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddl_chart_Basetype.SelectedIndex == 1)
        {
            ddl_chartsSubbase.Items.Clear();

        }
        else if (ddl_chart_Basetype.SelectedIndex == 2)
        {
            try
            {
                if (_position == 4)
                {
                    ddl_chartsSubbase.DataSource = get_all_sports();
                    ddl_chartsSubbase.DataValueField = "ACTIVITYSUB_CODE";
                    ddl_chartsSubbase.DataMember = "ACTIVITYSUB_CODE";
                    ddl_chartsSubbase.DataBind();

                }
                else if (_position == 3)
                {
                    ddl_chartsSubbase.DataSource = get_all_extraactivities();
                    ddl_chartsSubbase.DataValueField = "ACTIVITYSUB_CODE";
                    ddl_chartsSubbase.DataMember = "ACTIVITYSUB_CODE";
                    ddl_chartsSubbase.DataBind();

                }
            }
            catch
            {
                Response.Write("<script>alert('Error in Processing, Try again')");
            }

        }
        else if (ddl_chart_Basetype.SelectedIndex == 3)
        {
            try
            {
                if (_position == 4)
                {
                    ddl_chartsSubbase.DataSource = getall_sport_years();
                    ddl_chartsSubbase.DataValueField = "ACTIVITY_YEAR";
                    ddl_chartsSubbase.DataMember = "ACTIVITY_YEAR";
                    ddl_chartsSubbase.DataBind();

                }
                else if (_position == 3)
                {
                    ddl_chartsSubbase.DataSource = getall_extra_years();
                    ddl_chartsSubbase.DataValueField = "ACTIVITY_YEAR";
                    ddl_chartsSubbase.DataMember = "ACTIVITY_YEAR";
                    ddl_chartsSubbase.DataBind();

                }
            }
            catch
            {
                //prompt an error message if any exception occurs
                Response.Write("<script>alert('Error in Processing, Try again')");
            }
        }
    }
    protected void ddl_chartsSubbase_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

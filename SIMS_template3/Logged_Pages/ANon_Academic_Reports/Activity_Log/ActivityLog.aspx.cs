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
    //declare connection string to the databse
    string _Path = "Dsn=nsis;uid=root;pwd=123";
    //declare comman variable to hold the selected row index number
    static int _index;

    protected void Page_Load(object sender, EventArgs e)
    {
       // if(IsPostBack)
       // {
        lbl_selected_further.Text = string.Empty;
        btn_delete.Enabled = false;
        btn_edit.Enabled = false;
        //}

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void GenerateReport()
    {
        
    }
    protected void gv_extracurricular_log_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_selectestudents_Click(object sender, EventArgs e)
    {
       

    }
    //fill current data in to the data grid view, make other buttons are not to be visible
    protected void btn_selectestudents_Click1(object sender, EventArgs e)
    {
        try
        {
            get_master_student_id();
            fill_ddl_activitytype();
            fill_grid("select * from extra_activity");
            ddl_view_delete_update.Items.Clear();
            lbl_selected_further.Text = string.Empty;
            lbl_selected_student.Text = string.Empty;
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            btn_edit.Enabled = false;
            btn_insert.Enabled = true;
            txt_insertactivityname.Text = string.Empty;
            txt_insertdescription.Text = string.Empty;
        }
        catch
        {
            Response.Write("<script>alert('Error !! ')</script>");
 
        }
    }

    //-------------------Getdata from database-------------------------------------------------

    //--------create comman methode to retrive datatables--------------------
    public DataTable quaryExecuter_datatable_retrive(string key)
    {
        try
        {
            DataTable dt_comman;
            OdbcConnection con = new OdbcConnection(_Path);
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter(key, con);
            dt_comman = new DataTable();
            adapter.Fill(dt_comman);
            con.Close();
            return dt_comman;

        }
        catch
        {
            //if any error occrs display  a messgae
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
        }
        return null;
    }
    //---------------------------create comman methde to execute non quaries
    public bool quaryexecuter_send(string quary)
    {
        bool stat = false;
        try
        {

            OdbcConnection con = new OdbcConnection(_Path);
            con.Open();
            OdbcCommand cmd = new OdbcCommand(quary, con);
            cmd.ExecuteNonQuery();
            con.Close();
            stat = true;
        }
        catch (Exception cc)
        {
            string ccc = cc.ToString();

            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");

        }
        return stat;
    }
    //-----------------create comman methode to retrive datsets-------------
    public DataSet quaryExecuter_dataset_retrive(string quary)
    {

        try
        {
            DataSet table_content;
            OdbcConnection con = new OdbcConnection(_Path);
            con.Open();
            OdbcCommand cmd = new OdbcCommand(quary, con);
            table_content = new DataSet();
            OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
            adapter.Fill(table_content, "extra_activity");
            con.Close();
            return table_content;
        }
        catch
        {
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
        }
        return null;

    }


    //--------------get all registed student's methods 
    public void get_master_student_id()
    {
        try
        {
            DataTable dt_name;
            string quary_name = "select ADMISSION_NO from student_mast";
            //get all names from student_mast table and set it as the datasource of the ddl_select_insert dropdown list
            dt_name = quaryExecuter_datatable_retrive(quary_name);
            ddl_select_insert.DataSource = dt_name;
            ddl_select_insert.DataValueField = "ADMISSION_NO";
            ddl_select_insert.DataMember = "ADMISSION_NO";
            ddl_select_insert.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
        }
    }
    //-------------------end Getdata from database---------------------------------------------

    //------------------------fill   drop down  lists------------------------------------------
    public void fill_ddl_activitytype()
    {
        //insert some main activity types in to ddl_selectactivitytype dropdownlist
        ddl_selectactivitytype.Items.Clear();
        ddl_selectactivitytype.Items.Insert(0, "Sports");
        ddl_selectactivitytype.Items.Insert(1, "Extra");
    }
    //-------------------------get all admission numbers from the extra activity table and fill in to   ddl_view_delete_update dropdown list
    public void fill_search()
    {
        try
        {
            string quary = "select distinct ADMISSION_NO from extra_activity";
            //------execute the qaury using comman quaryexecute method
            ddl_view_delete_update.DataSource = quaryExecuter_datatable_retrive(quary);
            ddl_view_delete_update.DataValueField = "ADMISSION_NO";
            ddl_view_delete_update.DataMember = "ADMISSION_NO";
            ddl_view_delete_update.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");

        }
    }
    //------------------------end fill drop down lists-----------------------------------------

    //------------------------InsertFormatiing--------------------------------------------------
    //get current year when operation executes
    public int get_year()
    {

        int year = Convert.ToInt32(DateTime.Today.Year);
        return year;
    }
    //get the registering date when opeartion executes
    public string get_register_date()
    {
        return DateTime.Today.Date.ToString("dd-MM-yyyy");
    }
    //-------------------insert new record in to database
    public void insert_new_record()
    {
        try
        {
            //select the relevant student id from drop down list
            string student_id = ddl_select_insert.Text.Trim();
            //select the activity type
            string type = ddl_selectactivitytype.Text.Trim();
            //get relevant activity name
            string activity = txt_insertactivityname.Text.Trim();
            //get current year
            int years = get_year();
            //get the relavant achivement of releant student
            string descrip = txt_insertdescription.Text;
            //build new membership number according to the user inputs
            string member_id = make_membershipid();
            ////get registering date
            string register_date = get_register_date();
            string quary = "insert into extra_activity values('" + student_id + "','" + type + "','" + activity + "'," + years + ",'" + descrip + "','" + member_id + "','" + register_date + "')";
            if (quaryexecuter_send(quary))
            {
                //if quary execution is success , display a message
                Response.Write("<script>alert('Record  inserted successfully')</script>");
            }
            else
            {
                //else display error message
                Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
            }
            //clear grid view, relevant drop down lists and text fields
            clear();

        }
        catch
        {
            //if any exception occurs  catch that and dipaly using script
            Response.Write("<script>alert('Operation Cancelled')</script>");
        }
    }
    //--------update the selected  students extra acitivity information------
    public void update_selected_Student()
    {
        try
        {
            //----select the detected row number
            GridViewRow row = gv_extracurricular_log.Rows[_index];
            Control ctr = row.Controls[0];
            //diplay the selected student number in  lbl_selected_student
            lbl_selected_student.Text = ((System.Web.UI.WebControls.LinkButton)(ctr.Controls[0])).Text.ToString();
            string _updating_student_id = lbl_selected_student.Text;
            //select the new activty type
            string _updating_activity_type = ddl_selectactivitytype.Text;
            //hold the new activity name
            string _updating_activity = txt_insertactivityname.Text;
            //select current year
            int _updating_year = get_year();
            //select new achivement of the student
            string _updating_description = txt_insertdescription.Text;
            //build new membership number accrding to the input values
            string _updating_membersipnumber = make_updateing_membershipid(_updating_student_id);
            //hold new registerd date
            string _updating_regdate = get_register_date();
            string _update_quary = "update extra_activity set ACTIVITY_CODE='" + _updating_activity_type + "', ACTIVITYSUB_CODE='" + _updating_activity + "', ACTIVITY_YEAR=" + _updating_year + ", ACTIVITY_DESCRIPTION='" + _updating_description + "', MEMBERSHIP_NO='" + _updating_membersipnumber + "',DATE_OF_REGISTRATION='" + _updating_regdate + "' where ADMISSION_NO='" + _updating_student_id + "' ";
            if (quaryexecuter_send(_update_quary))
            {
                //if updating process is success dipaly a message
                Response.Write("<script>alert('Record  Updated successfully')</script>");
            }
            else
            {
                //if update process is unsceefull dispaly an error message
                Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
            }
        }
        catch
        {
            //catch the exceptions
            Response.Write("<script>alert('Operation Cancelled')</script>");

        }


    }
    //-build new membership number accrding to the user inputs
    public string make_membershipid()
    {
        try
        {
            //extract 1 st 2 characters of the student id
            string id_first_part = ddl_select_insert.Text.Substring(0, 2);
            //extract register years st 2 characters of the student id
            string id_last_part = ddl_select_insert.Text.Substring(2, 4);
            //select some parts of activity name
            string activity_part = txt_insertactivityname.Text.Substring(0, 2);
            //get the student sregisted year
            string reg_date = DateTime.Today.ToString("dd-MM-yyyy");
            string reg_pat = reg_date.Substring(0, 2);
            //bind the selected parts 
            string mem_one = id_first_part.Insert(2, id_last_part);
            string mem_two = mem_one.Insert(6, activity_part);
            string final_mem = mem_two.Insert(8, reg_pat);
            return final_mem;
        }
        catch
        {
            //catch the exception
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");

        }
        return null;

    }


    //------------------------End of insert formatting------------------------------------------

    //--------------------retrive quaryresults--------------------------------------------------

    //fill the grid view using extra activity table
    public void fill_grid(string quary)
    {
        DataSet new_ds = quaryExecuter_dataset_retrive(quary);
        //get the filled dataset from execution and set it as the data source of the grid view
        gv_extracurricular_log.DataSource = new_ds;
        gv_extracurricular_log.DataBind();

    }

    //---------------------end of retrive quary results-----------------------------------------

    //----------------------clear---------------------------------------------------------------
    public void clear()
    {
        //refresh the ddl_student_mast drop down list
        get_master_student_id();
        //clear all text fields
        txt_insertactivityname.Text = string.Empty;
        txt_insertdescription.Text = string.Empty;
        //fill the grid again
        fill_grid("select * from extra_activity");
    }
    //----------------------end clear------------------------------------------------------------
    protected void btn_insert_Click(object sender, EventArgs e)
    {
       // if (IsPostBack)
        //{
            // execute the record insertion method
            if (txt_insertactivityname.Text == string.Empty || txt_insertdescription.Text == string.Empty)
            {
                Response.Write("<script>alert('Please Fill all the Fielsds')</script>");

            }
            else
            {
                insert_new_record();
                fill_grid("select * from extra_activity");
                ddl_select_insert.Items.Clear();
                Response.Write("<script>alert('Insertion is successfull')</script>");

            }
        //}
    }
    protected void gv_extracurricular_log_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //catch the row index when user select
            _index = Convert.ToInt32(e.CommandArgument);
            //detect the all values of the selected row
            show_selected_record(_index);
            //make other values unvisible
            btn_insert.Enabled = false;
            btn_edit.Enabled = true;
            btn_delete.Enabled = true;
            ddl_select_insert.Items.Clear();
        }
        catch
        {
            //catch exception
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");

        }
    }

    //-----------------------------show for update and delete-------------------------------------------------
    //hold the values of the selected row
    public void show_selected_record(int index)
    {
        try
        {
            //hold the selected index of the row
            GridViewRow row = gv_extracurricular_log.Rows[index];
            Control ctr = row.Controls[0];
            //hold the selected row;s student id
            lbl_selected_student.Text = ((System.Web.UI.WebControls.LinkButton)(ctr.Controls[0])).Text.ToString();
            //refresh the activty type selection drop down list
            fill_ddl_activitytype();
            //hold the activity name and the description
            txt_insertactivityname.Text = gv_extracurricular_log.Rows[index].Cells[2].Text.ToString();
            txt_insertdescription.Text = gv_extracurricular_log.Rows[index].Cells[4].Text.ToString();
            lbl_selected_further.Text = "Selected Student";

        }
        catch
        {
            //catch errore
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
        }
    }
    public string make_updateing_membershipid(string _updateingid)
    {

        // nortify user if the user try to update the student values without selecting specific index

        if (_updateingid == null)
        {
            Response.Write("<script>alert('Please Select Record')</script>");

        }
        else
        {
            try
            {
                //hold the all new values which must be updated and make new membership id
                string id_first_part = _updateingid.Substring(0, 2); ;
                string id_last_part = _updateingid.Substring(2, 4);
                string activity_part = txt_insertactivityname.Text.Substring(0, 2);
                string reg_date = DateTime.Today.ToString("dd-MM-yyyy");
                string reg_pat = reg_date.Substring(0, 2);
                string mem_one = id_first_part.Insert(2, id_last_part);
                string mem_two = mem_one.Insert(6, activity_part);
                string final_mem = mem_two.Insert(8, reg_pat);
                return final_mem;
            }
            catch
            {
                //catch errors
                Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");

            }

        }
        return null;


    }

    //-----------------------------------------end show for update and delete---------------------------------------------------------------





    protected void btn_edit_Click(object sender, EventArgs e)
    {
        //// nortify user if the user try to update the student values without selecting specific index
        if (txt_insertactivityname.Text == string.Empty || txt_insertdescription.Text == string.Empty)
        {
            Response.Write("<script>alert('Please Insert Required Values')</script>");
        }
        else if (_index < 0)
        {
            Response.Write("<script>alert('Please select a Record')</script>");
        }
        //else if (txt_insertactivityname.Text == null || txt_insertdescription.Text == null)
        //{
        //    Response.Write("<script>alert('Please complete all the fields')</script>");

        //}
        else
        {
            //execute update quary
            update_selected_Student();
            Response.Write("<script>alert('Record is successfully updated')</script>");
            fill_grid("select * from extra_activity");
            //after execution make insert button visible
            btn_insert.Enabled = true;
            //clear all text filedsy;
        }
        clear();
        lbl_selected_further.Text = string.Empty;
        lbl_selected_student.Text = string.Empty;
    }


    protected void btn_selectstudent_Click(object sender, EventArgs e)
    {
        //refresh the serach drop down lists
        fill_search();
        //make insert button unvisible
        btn_insert.Enabled = false;
        btn_edit.Enabled = true;
        btn_delete.Enabled = true;   
    }


    protected void ddl_view_delete_update_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //show the updated record in the data grid view
            string _selectedstudent = ddl_view_delete_update.Text;
            string quary = "select * from extra_activity where ADMISSION_NO='" + _selectedstudent + "'";
            DataSet new_ds = quaryExecuter_dataset_retrive(quary);
            //get the search details from the  databse and the diaply in the grid view
            gv_extracurricular_log.DataSource = new_ds;
            gv_extracurricular_log.DataBind();
        }
        catch
        {
            Response.Write("<script>alert('Error In Proccesing, Plaese Try Again')</script>");
        }
    }


    protected void btn_delete_Click(object sender, EventArgs e)
    {
        //nortfy user if user try to do any mordification without selecting studnt id
        ddl_select_insert.Items.Clear();
        if (_index < 0)
        {
            Response.Write("<script>alert('Please select Record First')</script>");
        }
        else
        {
            try
            {
                //detect the student record which need to be deleted
                GridViewRow row = gv_extracurricular_log.Rows[_index];
                Control ctr = row.Controls[0];
                lbl_selected_student.Text = ((System.Web.UI.WebControls.LinkButton)(ctr.Controls[0])).Text.ToString();
                string quary = "delete from extra_activity where ADMISSION_NO='" + lbl_selected_student.Text + "'";
                if (quaryexecuter_send(quary))
                {
                    //if deletion is completed dispaly a message
                    Response.Write("<script>alert('Record  deleted successfully')</script>");
                    fill_grid("select * from extra_activity");
                }
                else
                {
                    //if opeartion is not success diaplay an error message
                    Response.Write("<script>alert('Record Can not be deleted')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('Operation Cancelled ')</script>");

            }

        }
        //refrsh all other drop down lists and text fieldds
        clear();
        fill_ddl_activitytype();
        btn_insert.Enabled = true;
        lbl_selected_student.Text = string.Empty;
        lbl_selected_further.Text = string.Empty;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alert('Operation Cancelled ')</script>");
    }
}

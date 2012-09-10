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
    static string _selectedrecord = null;
    //define the global variable to hold the database connection
    DBConnect connect = new DBConnect();
    //define global crystal report referance
    ReportDocument report;

    //this methode load all students in student_mast table in to a datatable
    public DataTable getallstudents_StudentMast()
    {
        try
        {
            //define new datatable reference
            DataTable dt_student;
            //get the data using data adapter from databse
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO from student_mast", connect.getconnection());
            //create new data table object
            dt_student = new DataTable();
            //fill the datatable object using data adpter
            adapter.Fill(dt_student);
            //return the filled data table object
            return dt_student;
        }
        catch
        {
            //display a javascript alert if any error occurs
            Response.Write("<script>alert('Error while processing, Please try again')</script>");
        }
        finally
        {
            //close the connection
            connect.close();
        }
        //if any error occurs return null
        return null;
    }

    //this methode load all distint student ids in student_warning table in to data table object
    public DataTable getallstudents_Student_Warning()
    {
        try
        {
            //define new datatable reference
            DataTable dt_student;
            //get the data using data adapter from databse
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ADMISSION_NO from student_warning", connect.getconnection());
            //create new data table object
            dt_student = new DataTable();
            //fill the datatable object using data adpter
            adapter.Fill(dt_student);
            //return the filled data table object
            return dt_student;
        }
        catch
        {
            //display a javascript alert if any error occurs
            Response.Write("<script>alert('Error while processing, Please try again')</script>");
        }
        finally
        {
            //close the connection
            connect.close();
        }
        //if any error occurs return null
        return null;
    }

    //this method fires according to the selection of ddl_STW_studentid drop down list and fill the it
    public void fill_ddl_STW_studentid()
    {
        //set the relevant data table as the data source of drop down list
        ddl_STW_studentid.DataSource = getallstudents_StudentMast();
        //set the field of data table as the value
        ddl_STW_studentid.DataValueField = "ADMISSION_NO";
        ddl_STW_studentid.DataMember = "ADMISSION_NO";
        //bind the data to the drop down list
        ddl_STW_studentid.DataBind();
    }

    //this method fires according to the selection of ddl_STW_Serach drop down list and fill the it
    public void fill_ddl_STW_Search()
    {
        //set the relevant data table as the data source of drop down list
        ddl_STW_Serach.DataSource = getallstudents_Student_Warning();
        //set the field of data table as the value
        ddl_STW_Serach.DataValueField = "ADMISSION_NO";
        ddl_STW_Serach.DataMember = "ADMISSION_NO";
        //bind the data to the drop down list
        ddl_STW_Serach.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtn_delete.Visible = false;
        if (!IsPostBack)
        {
            //call the fill_ddl_STW_studentid() function
            fill_ddl_STW_studentid();
            //call the fill_ddl_STW_Search()function
            fill_ddl_STW_Search();
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

 
    protected void gv_extracurricular_log_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ibtn_STW_Insert_Click(object sender, ImageClickEventArgs e)
    {
        //if the data insertion is successfull only then it shows in the gridview
        if (insert_newrecord(ddl_STW_studentid.SelectedItem.Text))
        {
            Response.Write("<script>alert('New record inserted successfully')</script>");
            //retirve the inserted record
            gv_STW_Searchresult.DataSource = getinserted_record(ddl_STW_studentid.SelectedItem.Text);
            gv_STW_Searchresult.DataBind();
        }
        else
        {
            //if operation is failed display a message
            Response.Write("<script>alert('Operation con not be completed')</script>");
        }
        refresh();
    }
    //this method get the all details of selected student from search drop down list
    public DataSet get_selected_student_details(string student_id)
    {
        try
        {
            //define new dataset refernce
            DataSet ds;
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from student_warning where ADMISSION_NO='" + student_id + "'", connect.getconnection());
            //create new dataset object
            ds = new DataSet();
            adapter.Fill(ds);
            //return the dataset
            return ds;
        }
        catch
        {
            Response.Write("<script>alert('Error while processing, Please try again')</script>");
        }
        finally
        {
            //close the connection
            connect.close();
        }
        return null;

    }

    //this fill the grid view from ds object
    public void fill_grid(string student_id)
    {
        DataSet ds = get_selected_student_details(student_id);
        gv_STW_Searchresult.DataSource = ds;
        gv_STW_Searchresult.DataBind();
    }
    //protected void ddl_STW_Serach_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    fill_grid(ddl_STW_Serach.SelectedItem.Text);
    //}

    //this function insert new record to database
    public bool insert_newrecord(string student_id)
    {

        
        bool stat = false;
        
        try
        {
        //   //hold the data from the controllers in to local variables       
                string warncode = ddl_STW_Warningcode.SelectedItem.Text;
                 
                string levelcode = ddl_STW_Levelcode.SelectedItem.Text;
               
        
       
                string warndate = System.DateTime.Today.ToString("d");

                string note = txt_STW_note.Text;
               
        

                decimal informparent = ddl_STW_Informparents.SelectedIndex;
               
           
        //      //get the connection
                 OdbcConnection con = connect.getconnection();
        //       //open the created connection
                 con.Open();
                 
        //      //create new sql command
                OdbcCommand cmd = new OdbcCommand("insert into student_warning values('" + student_id + "','" + warncode + "','" + warndate + "','" + levelcode + "','" + note + "'," + informparent + ")", con);
        //      //execute the quary
               cmd.ExecuteNonQuery();
              
          
        //      //if quary excecution is success the  change stat as true
             stat = true;
        }
        catch
        {
            Response.Write("<script>alert('Error while processing, Please try again')</script>");
        }
        finally
        {
            connect.close();
        }
     
        return stat;

    }

    //this function retrives the enterd new record
    public DataSet getinserted_record(string student_id)
    {
        try
        {
            //define new datatable reference
            DataSet dt_student;
            //get the data using data adapter from databse
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from student_warning where ADMISSION_NO='" + student_id + "'", connect.getconnection());
            //create new data table object
            dt_student = new DataSet();
            //fill the datatable object using data adpter
            adapter.Fill(dt_student);
            //return the filled data table object
            return dt_student;
        }
        catch
        {
            //display a javascript alert if any error occurs
            Response.Write("<script>alert('Error while processing, Please try again')</script>");
        }
        finally
        {
            //close the connection
            connect.close();
        }
        //if any error occurs return null
        return null;
    }

    //this function deletes the selected  record
    public bool delete_record(string student_id)
    {
        bool stat = false;
        try
        {
            //get the connection
            OdbcConnection con = connect.getconnection();
            //open the created connection
            con.Open();
            //create new sql command
            OdbcCommand cmd = new OdbcCommand("delete from  student_warning where ADMISSION_NO='" + student_id + "'", con);
            //execute the quary
            cmd.ExecuteNonQuery();
            //if quary excecution is success the  change stat as true
            stat = true;
        }
        catch (Exception ss)
        {
            string dd = ss.ToString();
            Response.Write("<script>alert('Error while processing, Please try again')</script>");
        }
        finally
        {
            connect.close();
        }
        return stat;
    }
    //protected void gv_STW_Searchresult_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //hold the selected index of the row
    //    GridViewRow row = gv_STW_Searchresult.Rows[Convert.ToInt32(e.CommandArgument)];
    //    //select the specified controller
    //    Control ctr = row.Controls[0];
    //    //hold the selected rows student id
    //    _selectedrecord = ((System.Web.UI.WebControls.LinkButton)(ctr.Controls[0])).Text.ToString();
    //    //make the delete button visible
    //    ibtn_delete.Visible = true;
    //}
    //this refresh all the controllers
    public void refresh()
    {
        ibtn_delete.Visible = false;
        //call the fill_ddl_STW_studentid() function
        fill_ddl_STW_studentid();
        //call the fill_ddl_STW_Search()function
        fill_ddl_STW_Search();
        //clear the textbox
        txt_STW_note.Text = string.Empty;
    }
    protected void ibtn_delete_Click(object sender, ImageClickEventArgs e)
    {
        //pass the selected student id
        string id = _selectedrecord;
        //check weather the delete operation is success or not
        if (delete_record(id))
        {
            Response.Write("<script>alert('Record successfully deleted')</script>");
        }
        else
        {
            Response.Write("<script>alert('Operation con not be completed')</script>");

        }
        //call the refresh methode
        refresh();
    }
    public DataTable get_report_data()
    {
        try
        {
            DataTable dt;
            OdbcDataAdapter adpater = new OdbcDataAdapter("select * from student_warning", connect.getconnection());
            dt = new DataTable();
            adpater.Fill(dt);
            return dt;
        }
        catch
        {
            Response.Write("<script>alert('Operation con not be completed')</script>");
        }
        finally
        {
            connect.close();
        }
        return null;
    }
    protected void ddl_STW_chartselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //create new report document
            report = new ReportDocument();
            //according to the selected index geerate the report
            if (ddl_STW_chartselect.SelectedIndex == 0)
            {
                //load the report from the location
                report.Load(Server.MapPath("cr_studentwarning_level.rpt"));
            }
            else if (ddl_STW_chartselect.SelectedIndex == 1)
            {
                report.Load(Server.MapPath("cr_studentwarning_years.rpt"));
            }
            else if (ddl_STW_chartselect.SelectedIndex == 2)
            {
                report.Load(Server.MapPath("cr_studentwarning_activity.rpt"));
            }
            //set the retriveing data table as the report data source
            report.SetDataSource(get_report_data());
            //set the report object as the report source of the report viewer
            crv_STW_charts.ReportSource = report;
            //refresh the report
            crv_STW_charts.RefreshReport();
        }
        catch (Exception ss)
        {
            string name = ss.ToString();
            Response.Write("<script>alert('Report generation failed, try again')</script>");
        }
    }


    protected void ddl_STW_chartselect_SelectedIndexChanged1(object sender, EventArgs e)
    {

        try
        {
            //create new report document
            report = new ReportDocument();
            //according to the selected index geerate the report
            if (ddl_STW_chartselect.SelectedIndex == 0)
            {
                //load the report from the location
                report.Load(Server.MapPath("repo//cr_studentwarning_level.rpt"));
            }
            else if (ddl_STW_chartselect.SelectedIndex == 1)
            {
                report.Load(Server.MapPath("repo//cr_studentwarning_years.rpt"));
            }
            else if (ddl_STW_chartselect.SelectedIndex == 2)
            {
                report.Load(Server.MapPath("repo//cr_studentwarning_activity.rpt"));
            }
            //set the retriveing data table as the report data source
            report.SetDataSource(get_report_data());
            //set the report object as the report source of the report viewer
            crv_STW_charts.ReportSource = report;
            //refresh the report
            crv_STW_charts.RefreshReport();
        }
        catch (Exception ss)
        {
            string name = ss.ToString();
            Response.Write("<script>alert('Report generation failed, try again')</script>");
        }

    }
    protected void ibtn_STW_Insert_Click1(object sender, ImageClickEventArgs e)
    {
        //if the data insertion is successfull only then it shows in the gridview
       
        if (insert_newrecord(ddl_STW_studentid.SelectedItem.Text))
        {
            
       

         //retirve the inserted record
            
            gv_STW_Searchresult.DataSource = getinserted_record(ddl_STW_studentid.SelectedItem.Text);
            gv_STW_Searchresult.DataBind();
        }
        else
        {
       
        //if operation is failed display a message
         Response.Write("<script>alert('Operation con not be completed')</script>");
        }
        refresh();
    }
    protected void ddl_STW_studentid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_STW_Serach_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fill_grid(ddl_STW_Serach.SelectedItem.Text);
    }
    protected void gv_STW_Searchresult_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        //hold the selected index of the row
        GridViewRow row = gv_STW_Searchresult.Rows[Convert.ToInt32(e.CommandArgument)];
        //select the specified controller
        Control ctr = row.Controls[0];
        //hold the selected rows student id
        _selectedrecord = ((System.Web.UI.WebControls.LinkButton)(ctr.Controls[0])).Text.ToString();
        //make the delete button visible
        ibtn_delete.Visible = true;
    }
    protected void ibtn_delete_Click1(object sender, ImageClickEventArgs e)
    {
        ////pass the selected student id
        //string id = _selectedrecord;
        ////check weather the delete operation is success or not
        //if (delete_record(id))
        //{
        //    Response.Write("<script>alert('Record successfully deleted')</script>");
        //}
        //else
        //{
        //    Response.Write("<script>alert('Operation con not be completed')</script>");

        //}
        ////call the refresh methode
        //refresh();
    }
}

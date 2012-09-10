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
    DBConnect connect = new DBConnect();
    static string selected_id = null;
    //load the items in to dropdown list
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddl_SEM_selecttype.Items.Insert(0, "Sport");
            ddl_SEM_selecttype.Items.Insert(1, "Religious");
            ddl_SEM_selecttype.Items.Insert(2, "Cultural");
            ddl_SEM_selecttype.Items.Insert(3, "Entertainment");

            ddl_SEM_search.Items.Insert(0, "Sport");
            ddl_SEM_search.Items.Insert(1, "Religious");
            ddl_SEM_search.Items.Insert(2, "Cultural");
            ddl_SEM_search.Items.Insert(3, "Entertainment");
            ddl_SEM_search.Items.Insert(4, "All Records");
        }
        ibtn_SW_deleterecords.Visible = false;
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void gv_extracurricular_log_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ibtn_SEM_insert_Click(object sender, ImageClickEventArgs e)
    {
       
        if (txt_SEM_catagory == null || txt_SEM_description == null || txt_SEM_eventname == null || txt_SEM_issues == null)
        {
            Response.Write("<script>alert('Fill all the fields ')</script>");
            


        }
        else
        {
            string type = ddl_SEM_selecttype.SelectedItem.Text;
            string catagoty = txt_SEM_catagory.Text;
            string name = txt_SEM_eventname.Text;
            string date = System.DateTime.Today.ToString("d");
            string des = txt_SEM_description.Text;
            string organizer = ddl_SEM_organizar.SelectedItem.Text;
            string issue = txt_SEM_issues.Text;
            string eventid = create_name(type);
            if (insert_record(eventid, type, catagoty, name, date, des, organizer, issue))
            {
                fill_by_insertedrecord(eventid);
            }
            clear_text();

        }
    }

    //create event id accrodignto inputs
    public string create_name(string type)
    {
        string type_part = type.Substring(0, 3);
        string time = System.DateTime.Today.ToString("d").Substring(0, 6);
        string id = type_part.Insert(3, time);
        return id;
    }
    //insert new event record to the database
    public bool insert_record(string id, string type, string catagory, string name, string date, string des, string organizer, string issue)
    {
        bool stat = false;
        try
        {
            OdbcConnection con = connect.getconnection();
            con.Open();
            OdbcCommand cmd = new OdbcCommand("insert into school_events values('" + id + "','" + type + "','" + catagory + "','" + name + "','" + date + "','" + des + "','" + organizer + "','" + issue + "')", con);
            cmd.ExecuteNonQuery();
            stat = true;
        }
        catch (Exception ss)
        {
            string sss = ss.ToString();
            Response.Write("<script>alert('Error is Processing, Please Try Again')</script>");
        }
        finally
        {
            connect.close();
        }
        return stat;
    }

    public void fill_by_insertedrecord(string id)
    {
        gv_SEM_data.DataSource = get_inserted_record(id);
        gv_SEM_data.DataBind();
    }

    public DataSet get_inserted_record(string id)
    {
        DataSet ds;
        try
        {
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from school_events where EVENT_ID='" + id + "'", connect.getconnection());
            ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        catch
        {
            Response.Write("<script>alert('Error is Processing, Please Try Again')</script>");
        }
        finally
        {
            connect.close();
        }
        return null;
    }

    //this clear all the text boxes
    public void clear_text()
    {
        txt_SEM_catagory.Text = string.Empty;
        txt_SEM_description.Text = string.Empty;
        txt_SEM_eventname.Text = string.Empty;
        txt_SEM_issues.Text = string.Empty;
    }
    protected void ddl_SEM_search_SelectedIndexChanged(object sender, EventArgs e)
    {
        string quary = null;
        if (ddl_SEM_search.SelectedItem.Text == "Sport")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Sport'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "Religious")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Religious'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "Cultural")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Cultural'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "Entertainment")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Entertainment'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "All Records")
        {
            quary = "select * from school_events";

        }
        gv_SEM_data.DataSource = view_data(quary);
        gv_SEM_data.DataBind();
    }

    public DataSet view_data(string key)
    {
        DataSet ds;
        try
        {
            OdbcDataAdapter adapter = new OdbcDataAdapter(key, connect.getconnection());
            ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        catch
        {
            Response.Write("<script>alert('Error is Processing, Please Try Again')</script>");
        }
        finally
        {
            connect.close();
        }
        return null;
    }
    protected void gv_SEM_data_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //hold the selected index of the row
        GridViewRow row = gv_SEM_data.Rows[Convert.ToInt32(e.CommandArgument)];
        //select the specified controller
        Control ctr = row.Controls[0];
        //hold the selected rows student id
        selected_id = ((System.Web.UI.WebControls.LinkButton)(ctr.Controls[0])).Text.ToString();
        //make the delete button visible
        ibtn_SW_deleterecords.Visible = true;
    }

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
            OdbcCommand cmd = new OdbcCommand("delete from  school_events where EVENT_ID='" + student_id + "'", con);
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

    public void delete(string ids)
    {
        string id = selected_id;
        //check weather the delete operation is success or not
        if (delete_record(id))
        {
            Response.Write("<script>alert('Record successfully deleted')</script>");
        }
        else
        {
            Response.Write("<script>alert('Operation con not be completed')</script>");

        }

    }



    protected void ibtn_SW_deleterecords_Click(object sender, ImageClickEventArgs e)
    {
        delete(selected_id);
        ibtn_SW_deleterecords.Visible = false;
    }
    protected void ddl_SEM_search_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string quary = null;
        if (ddl_SEM_search.SelectedItem.Text == "Sport")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Sport'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "Religious")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Religious'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "Cultural")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Cultural'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "Entertainment")
        {
            quary = "select * from school_events where EVENT_TYPE_MAST='Entertainment'";

        }
        else if (ddl_SEM_search.SelectedItem.Text == "All Records")
        {
            quary = "select * from school_events";

        }
        gv_SEM_data.DataSource = view_data(quary);
        gv_SEM_data.DataBind();
    }
}

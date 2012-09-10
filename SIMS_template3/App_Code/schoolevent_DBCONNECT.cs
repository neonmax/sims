using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for schoolevent_DBCONNECT
/// </summary>
public class schoolevent_DBCONNECT
{
    //define static connection string
    static string path = "Dsn=heshan_odbc;uid=root;pwd=123";
    static OdbcConnection con;
    public schoolevent_DBCONNECT()
    {
        //
        // TODO: Add constructor logic here
        //
        con = new OdbcConnection(path);
    }
    public OdbcConnection getconnection()
    {
        //return the created connection
        return con;
    }

    //get all master events
    public DataTable get_event_master()
    {
        try
        {
            DataTable dt_master;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct EVENT_TYPE_MAST from event_mast ", conn);
            //create new data tbale object
            dt_master = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_master);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_master;
        }
        catch
        {
            return null;
        }
    }
    //get all sub events
    public DataTable get_subevents()
    {
        try
        {
            DataTable dt_sub;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct EVENT_TYPE_SUB from event_mast", conn);
            //create new data tbale object
            dt_sub = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_sub);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_sub;

        }
        catch
        {
            return null;
        }
    }

    //insert record 
    public bool insert_record(string id, string type, string catagory, string name, string date, string des, string organizer, string issue)
    {
        bool stat = false;
        try
        {
            //create new connection with the databse
            OdbcConnection con = getconnection();
            //open the conection
            con.Open();
            //set command text
            OdbcCommand cmd = new OdbcCommand("insert into school_events values('" + id + "','" + type + "','" + catagory + "','" + name + "','" + date + "','" + des + "','" + organizer + "','" + issue + "')", con);
            //execute quary
            cmd.ExecuteNonQuery();
            //set statuss as true
            stat = true;
            //close the connection
            con.Close();
        }
        catch (Exception ss)
        {
            string sss = ss.ToString();

        }
        return stat;
    }
    //delete record
    public bool delete_record(string id)
    {
        bool stat = false;
        try
        {
            //get the connection
            OdbcConnection con = getconnection();
            //open the created connection
            con.Open();
            //create new sql command
            OdbcCommand cmd = new OdbcCommand("delete from  school_events where EVENT_ID='" + id + "' ", con);
            //execute the quary
            cmd.ExecuteNonQuery();
            //if quary excecution is success the  change stat as true
            stat = true;
            //close the connection
            con.Close();
        }
        catch (Exception ss)
        {
            string dd = ss.ToString();
        }

        return stat;
    }

    //update record
    public bool update_record(string eid,string ntype, string nsub, string nmae, string ndate, string ndes, string norganizer, string nissue)
    {
        bool stat = false;
        try
        {
            //create new connection with the databse
            OdbcConnection con = getconnection();
            //open the conection
            con.Open();
            //set command text
            OdbcCommand cmd = new OdbcCommand("update school_events set EVENT_TYPE_MAST='" + ntype + "',EVENT_TYPE_SUB='" + nsub + "',EVENT_NAME='" + nmae + "',HELD_DATE='" + ndate + "',DESCRIPTION='" + ndes + "',ORGANIZER='" + norganizer + "',FACED_ISSUES='" + nissue + "' where EVENT_ID='" + eid + "' ", con);
            //execute quary
            cmd.ExecuteNonQuery();
            //set statuss as true
            stat = true;
            //close the connection
            con.Close();
        }
        catch (Exception ss)
        {
            string sss = ss.ToString();

        }
        return stat;
    }
    //get all records
    public DataTable getall()
    {
        try
        {
            DataTable dt_all;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from school_events ", conn);
            //create new data tbale object
            dt_all = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_all);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_all;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;
        }
    }
    //get the search result
    public DataTable search(string key)
    {
        try
        {
            DataTable dt_search;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from school_events where EVENT_NAME like '%" + key + "%'", conn);
            //create new data tbale object
            dt_search = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_search);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_search;
        }
        catch
        {
            return null;
        }

    }
    //get the selected record
    public DataTable get_selected_record(string id, string master, string sub, string name)
    {
        try
        {
            DataTable dt_selected;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from school_events where EVENT_ID='" + id + "' and EVENT_TYPE_MAST='" + master + "'and EVENT_TYPE_SUB='" + sub + "' and EVENT_NAME='" + name + "'", conn);
            //create new data tbale object
            dt_selected = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_selected);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_selected;
        }
        catch
        {
            return null;
        }

    }




}

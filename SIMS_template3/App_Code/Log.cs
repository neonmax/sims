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
/// Summary description for Log
/// </summary>
public class Log
{
    //define static connection string
    static string path = "Dsn=heshan_odbc;uid=root;pwd=123";
    static OdbcConnection con;
	public Log()
	{
        con = new OdbcConnection(path);
	
	}
    public OdbcConnection getconnection()
    {
        //return the created connection
        return con;
    }
    //##########################fill drop down lists###################################
    //retrive all the grades from the database
    public DataTable get_all_grades()
    {
        try
        {

            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct SC_GRADE from student_class ", conn);
            //create new data tbale object
            dt_serachresult = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_serachresult);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_serachresult;
        }
        catch
        {
            return null;
        }
    }

    public DataTable get_class_relevaent_grade(decimal grade)
    {
        try
        {
            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct CLASS_CODE from student_class where SC_GRADE=" + grade + "", conn);
            //create new data tbale object
            dt_serachresult = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_serachresult);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_serachresult;
        }
        catch
        {
            return null;
        }
    }

    public DataTable get_all_students_of_class(char classs, decimal grade)
    {
        try
        {
            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select  NAME_FULL from student_class c,student_mast m where CLASS_CODE='" + classs + "' and SC_GRADE=" + grade + " and m.ADMISSION_NO=c.ADMISSION_NO", conn);
            //create new data tbale object
            dt_serachresult = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_serachresult);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_serachresult;
        }
        catch
        {
            return null;
        }

    }
    public DataTable getall_activity_type()
    {
        try
        {
            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select  distinct ACTIVITY_CODE from extra_activity", conn);
            //create new data tbale object
            dt_serachresult = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_serachresult);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_serachresult;
        }
        catch
        {
            return null;
        }
    }
    public DataTable get_all_activity(string type)
    {
        try
        {
            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct ACTIVITYSUB_CODE from extra_activity where ACTIVITY_CODE='" + type + "'", conn);
            //create new data tbale object
            dt_serachresult = new DataTable();
            //fill the data table object through data adapter
            adapter.Fill(dt_serachresult);
            //close the open clonnection
            conn.Close();
            //return the filled data table object
            return dt_serachresult;
        }
        catch
        {
            return null;
        }

    }


    public bool insert_student_activity(string id, string type, string activity, decimal year, string note, string member, string date)
    {
        //define boolean variable to identify status
        bool stat = false;
        try
        {
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //set command
            OdbcCommand cmd = new OdbcCommand("insert into extra_activity (ADMISSION_NO,ACTIVITY_CODE,ACTIVITYSUB_CODE,ACTIVITY_YEAR,ACTIVITY_DESCRIPTION,MEMBERSHIP_NO,DATE_OF_REGISTRATION) values('" + id + "','" + type + "','" + activity + "'," + year + ",'" + note + "','" + member + "','" + date + "')", con);
            //execute the command
            cmd.ExecuteNonQuery();
            //set status as true
            stat = true;
            //close the connection
            con.Close();
        }
        catch (Exception ss)
        {
            string sss = ss.Message;
            stat = false;

        }
        return stat;
    }

    //update the record
    public bool update_record(string eid, string etype, string eactivity, decimal eyear, string ntype, string nactivity, decimal nyear, string note, string member, string date)
    {
        bool stat = false;
        try
        {
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //set command
            OdbcCommand cmd = new OdbcCommand("update extra_activity set ACTIVITY_CODE='" + nactivity + "', ACTIVITYSUB_CODE='" + ntype + "',ACTIVITY_YEAR=" + nyear + ", ACTIVITY_DESCRIPTION='" + note + "',MEMBERSHIP_NO='" + member + "',DATE_OF_REGISTRATION=" + date + " where ADMISSION_NO='" + eid + "' and ACTIVITY_CODE='" + etype + "' and ACTIVITYSUB_CODE='" + eactivity + "' and  ACTIVITY_YEAR=" + eyear + " ", con);
            //execute the command
            cmd.ExecuteNonQuery();
            //set status as true
            stat = true;
            //close the connection
            con.Close();
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            stat = false;

        }
        return stat;

    }
    //delete the record
    public bool delete_record(string id, string type, string activity, decimal year)
    {
        bool stat = false;
        try
        {
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //set command
            OdbcCommand cmd = new OdbcCommand("delete  from extra_activity where ADMISSION_NO='" + id + "' and ACTIVITY_CODE='" + type + "' and ACTIVITYSUB_CODE='" + activity + "' and ACTIVITY_YEAR='" + year + "'", con);
            //execute the command
            cmd.ExecuteNonQuery();
            //set status as true
            stat = true;
            //close the connection
            con.Close();
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            stat = false;

        }
        return stat;
    }

    //select record
    public DataTable select_record(string id, string type, string activity, decimal year)
    {

        try
        {
            //create data table object
            DataTable dt_select_record;
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //cretae datapter
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from  view_individual_student  where ADMISSION_NO='" + id + "' and ACTIVITY_CODE='" + type + "' and ACTIVITYSUB_CODE='" + activity + "' and ACTIVITY_YEAR=" + year + "", con);
            //execute the command
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;

        }
    }
    //get one student all records
    public DataTable get_one_student_all_records(string id)
    {
        try
        {
            //create data table object
            DataTable dt_select_record;
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //cretae datapter
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from  view_individual_student  where ADMISSION_NO='" + id + "' ", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;

        }
    }

    //select all the recorsd that satisfy id
    public DataTable search_results(string searchkey)
    {
        try
        {
            DataTable dt_select_record;
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //cretae datapter
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO from student_mast  where NAME_FULL ='"+searchkey+"'", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;


        }

    }

    //get all the records of the table
    public DataTable get_all()
    {
        try
        {
            //create data table object
            DataTable dt_select_record;
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //cretae datapter
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from extra_activity", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;

        }
    }
}

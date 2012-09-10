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
/// Summary description for Student_Warning_DBCONNECT
/// </summary>
public class Student_Warning_DBCONNECT
{
    //define static connection string
    static string path = "Dsn=heshan_odbc;uid=root;pwd=123";
    static OdbcConnection con;
    public Student_Warning_DBCONNECT()
    {
        //
        // TODO: Add constructor logic here
        //
        //create new connection
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select  ADMISSION_NO from student_class where CLASS_CODE='" + classs + "' and SC_GRADE=" + grade + "", conn);
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

    public DataTable getall_warn_codes()
    {
        try
        {
            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select  WARNING_CODE from warning_mast", conn);
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
    public DataTable get_all_level_codes()
    {
        try
        {
            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select  LEVEL_CODE from warning_level_mast", conn);
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

    //#################################################################################

    //##########################Data insert/Update/Delete and Select###################
    //insert data in to data base
    public bool insert_student_warning(string id, string date, string warn_code, string level, string note, decimal inform)
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
            OdbcCommand cmd = new OdbcCommand("insert into student_warning(WARN_DATE,ADMISSION_NO,WARNING_CODE,LEVEL_CODE,NOTE,INFORM_PARENTS) values('" + date + "','" + id + "','" + warn_code + "','" + level + "','" + note + "'," + inform + ")", con);
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
    public bool update_record(string id, string new_date, string new_warn_code, string new_level, string new_note, decimal new_inform, string exit_date, string _exitwarnocde, string exit_level)
    {
        bool stat = false;
        try
        {
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //set command
            OdbcCommand cmd = new OdbcCommand("update student_warning set WARN_DATE='" + new_date + "',WARNING_CODE='" + new_warn_code + "',LEVEL_CODE='" + new_level + "', NOTE='" + new_note + "',INFORM_PARENTS=" + new_inform + " where ADMISSION_NO='" + id + "' and WARNING_CODE='" + _exitwarnocde + "' and LEVEL_CODE='" + exit_level + "' and  WARN_DATE='" + exit_date + "' ", con);
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
    public bool delete_record(string id, string date, string warn_code, string level)
    {
        bool stat = false;
        try
        {
            //set up new connection
            OdbcConnection con = getconnection();
            //open the setup coneection
            con.Open();
            //set command
            OdbcCommand cmd = new OdbcCommand("delete  from student_warning  where ADMISSION_NO='" + id + "' and WARN_DATE='" + date + "' and WARNING_CODE='" + warn_code + "' and LEVEL_CODE='" + level + "'", con);
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
    public DataTable select_record(string id, string date, string warncode, string levelcode)
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from student_warning where ADMISSION_NO='" + id + "' and WARN_DATE='" + date + "' and WARNING_CODE='" + warncode + "' and LEVEL_CODE='" + levelcode + "'", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch
        {
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from  student_warning  where ADMISSION_NO='" + id + "' ", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch
        {
            return null;

        }
    }

    //select all the recorsd that satisfy id
    public DataTable search_results(string searchkey)
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select *  from student_warning where ADMISSION_NO='"+searchkey+"'", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch
        {
            return null;

        }

    }
    //get all the records of the table
    public DataTable databind()
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from student_warning ", con);
            dt_select_record = new DataTable();
            //fill the datatable
            adapter.Fill(dt_select_record);
            //close the connection
            con.Close();
            return dt_select_record;
        }
        catch
        {
            return null;

        }
    }

    public DataTable get_email(string id)
    {
        try
        {

            DataTable dt_serachresult;
            //create new connection with the databse
            OdbcConnection conn = getconnection();
            //open the created connection
            conn.Open();
            //declare dataadpter variable and hold the values 
            OdbcDataAdapter adapter = new OdbcDataAdapter("select FATHER_EMAIL,MOTHER_EMAIL,GUARDIAN_EMAIL from student_mast where ADMISSION_NO='" + id + "'", conn);
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
}

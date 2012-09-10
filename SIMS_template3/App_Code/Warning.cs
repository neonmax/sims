using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Odbc;

/// <summary>
/// Summary description for Warning
/// </summary>
public class Warning
{
    //define static connection string
    static string path = "Dsn=nsis;uid=root;pwd=123";
    static OdbcConnection con;
    public Warning()
    {
        con = new OdbcConnection(path);
    }
    public OdbcConnection getconnection()
    {
        //return the created connection
        return con;
    }
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select  m.NAME_INITIALS from student_class c , student_mast m where c.ADMISSION_NO=m.ADMISSION_NO and c.CLASS_CODE='" + classs + "' and c.SC_GRADE=" + grade + "", conn);
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select distinct WARNING_CODE from warning_mast", conn);
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
    //select all the recorsd that satisfy id
    public DataTable Get_student_name(string searchkey)
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
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO  from student_mast  where NAME_INITIALS ='" + searchkey + "'", con);
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

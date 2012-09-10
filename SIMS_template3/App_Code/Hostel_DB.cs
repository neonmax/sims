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
/// Summary description for Hostel_DB
/// </summary>
public class Hostel_DB
{
    //static variable to hold the connection string and connection object
    static string path = "Dsn=nsis;uid=root;pwd=123";
    static OdbcConnection con;

    public Hostel_DB()
    {
        con = new OdbcConnection(path);
    }

    //get the connection
    public OdbcConnection getconnection()
    {
        return con;
    }

    //get the class detaisl
    public DataTable get_grade()
    {
        try
        {
            DataTable dt_grade;
            con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select distinct SC_GRADE from student_class", con);
            dt_grade = new DataTable();
            adpter.Fill(dt_grade);
            con.Close();
            return dt_grade;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;
        }
    }
    //get class details
    public DataTable get_class(decimal grade)
    {
        try
        {
            DataTable dt_class;
            con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select distinct CLASS_CODE from student_class where SC_GRADE=" + grade + " ", con);
            dt_class = new DataTable();
            adpter.Fill(dt_class);
            con.Close();
            return dt_class;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;
        }

    }
    //get student details
    public DataTable get_student(decimal grade, char classs)
    {
        try
        {
            DataTable dt_student;
            con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select NAME_FULL from student_mast m,student_class s  where s.SC_GRADE=" + grade + " and s.CLASS_CODE='" + classs + "' and m.ADMISSION_NO=s.ADMISSION_NO  and s.ADMISSION_NO not  in (select h.ADMISSION_NO from hostel h)", con);
            dt_student = new DataTable();
            adpter.Fill(dt_student);
            con.Close();
            return dt_student;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;
        }
    }
    //get the selected student admission no
    public string get_student_id(string name)
    {
        try
        {
            string sname = null;
            con = getconnection();
            con.Open();
            OdbcCommand cmd = new OdbcCommand("select ADMISSION_NO from student_mast where NAME_FULL='" + name + "'", con);
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sname = reader["ADMISSION_NO"].ToString();
            }
            con.Close();
            return sname;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;
        }
    }

    //register particular student
    public bool register_student(string id, string regn, string from, string to, decimal p, decimal dh, decimal h)
    {
        bool status = false;
        try
        {
            con = getconnection();
            con.Open();
            OdbcCommand cmd = new OdbcCommand("insert into hostel (ADMISSION_NO, REGISTRATION_NO, DATE_FROM,DATE_TO,HOSTEL_PREFECT_YEAR,HOSTEL_DHPREFECT_YEAR,HOSTEL_HPREFECT_YEAR) values('" + id + "','" + regn + "','" + from + "','"+to+"',"+p+","+dh+","+h+" )", con);
            cmd.ExecuteNonQuery();
            status = true;
            con.Close();
            return status;
        }
        catch (Exception ss)
        {
            string sss = ss.Message;
            return status;
        }
    }




}

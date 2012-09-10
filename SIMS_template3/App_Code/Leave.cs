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
/// Summary description for Leave
/// </summary>
public class Leave
{
    static string path = "Dsn=nsis;uid=root;pwd=123";
    static OdbcConnection con;
    public Leave()
    {
        //
        // TODO: Add constructor logic here
        //
        con = new OdbcConnection(path);
    }
    public OdbcConnection getconnection()
    {
        return con;
    }

    public DataTable get_grades(decimal year)
    {
        try
        {
            DataTable dt_grade;
            con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select distinct SC_GRADE from student_class where SC_YEAR="+year+"", con);
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
    public DataTable get_class(decimal grade,decimal year)
    {
        try
        {
            DataTable dt_class;
            con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select distinct CLASS_CODE from student_class where SC_GRADE=" + grade + "  and SC_YEAR="+year+"", con);
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
    public DataTable get_student(decimal grade, char classs,decimal year)
    {
        try
        {
            DataTable dt_student;
            con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select NAME_FULL from student_mast m,student_class s  where s.SC_GRADE=" + grade + " and s.CLASS_CODE='" + classs + "' and s.SC_YEAR="+year+" and m.ADMISSION_NO=s.ADMISSION_NO", con);
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
    public DataTable getstudent(string id)
    {
        try
        {
            OdbcConnection conn = getconnection();
            conn.Open();
            DataTable dt_student;
            OdbcDataAdapter adpter = new OdbcDataAdapter("select ADMISSION_NO,NAME_INITIALS,ADMISSION_DATE,DOL from student_mast where NAME_FULL like '%" + id + "%'", conn);
            dt_student = new DataTable();
            adpter.Fill(dt_student);
            conn.Close();
            return dt_student;
        }
        catch (Exception s)
        {
            string me = s.Message;
            return null;
        }

    }
    public DataTable get_all_years()
    {
        try
        {
            OdbcConnection conn = getconnection();
            conn.Open();
            DataTable dt_years;
            OdbcDataAdapter adpter = new OdbcDataAdapter("select distinct SC_YEAR from student_class", conn);
            dt_years = new DataTable();
            adpter.Fill(dt_years);
            conn.Close();
            return dt_years;
        }
        catch (Exception s)
        {
            string me = s.Message;
            return null;
        }
    }
    public DataTable get_null()
    {
        try
        {
            OdbcConnection conn = getconnection();
            conn.Open();
            DataTable dt_null;
            OdbcDataAdapter adapter = new OdbcDataAdapter("select ADMISSION_NO,NAME_INITIALS,ADMISSION_DATE,DOL from student_mast where NAME_FULL like '% ZYX %'", conn);
            dt_null = new DataTable();
            adapter.Fill(dt_null);
            conn.Close();
            return dt_null;
        }
        catch
        {
            return null;
        }
    }
    public DataTable get_student_details(string id)
    {
        try
        {
            OdbcConnection conn = getconnection();
            conn.Open();
            DataTable dt_student;
            OdbcDataAdapter adpter = new OdbcDataAdapter("select m.ADMISSION_NO,m.NAME_FULL,m.NAME_INITIALS,n.NATIONALITY,m.ADMISSION_DATE,m.DOB,m.DOL,m.S_SEX from student_mast m, nationality_mast n where m.ADMISSION_NO='" + id + "' and m.NATIONAL_CODE=n.NATIONAL_CODE", conn);
            dt_student = new DataTable();
            adpter.Fill(dt_student);
            conn.Close();
            return dt_student;
        }
        catch
        {
            return null;
        }
    }
    public DataTable get_garde(string id)
    {

        try
        {
            DataTable dt_grade;
            OdbcConnection conn = getconnection();
            conn.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select MAX(SC_GRADE) from student_class where ADMISSION_NO='" + id + "' ", conn);
            dt_grade = new DataTable();
            adpter.Fill(dt_grade);
            conn.Close();
            return dt_grade;
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            return null;
        }

    }

    public DataTable get_basic(string id)
    {
      
   
        try
        {
            OdbcConnection conn = getconnection();
            conn.Open();
            DataTable dt_student;
            OdbcDataAdapter adpter = new OdbcDataAdapter("select * from student_mast where NAME_FULL='"+id+"'", conn);
            dt_student = new DataTable();
            adpter.Fill(dt_student);
            conn.Close();
            return dt_student;
        }
        catch
        {
            return null;
        }
    }

    public DataTable get_nation(string key)
    {
        try
        {
            OdbcConnection conn = getconnection();
            conn.Open();
            DataTable dt_nation;
            OdbcDataAdapter adpter = new OdbcDataAdapter("select NATIONALITY from nationality_mast where NATIONAL_CODE='"+key+"'", conn);
            dt_nation = new DataTable();
            adpter.Fill(dt_nation); 
            conn.Close();
            return dt_nation;
        }
        catch
        {
            return null;
        }
    }

}

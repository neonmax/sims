using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Author - E.A Heshan Sandeepa IT 10 1598 04
/// 2012-08-17
/// Summary description for Hostel_Edit
/// </summary>
public class Hostel_Edit
{
    static string path = "Dsn=heshan_odbc;uid=root;pwd=123";
    static OdbcConnection cc;
    public Hostel_Edit()
    {

        cc = new OdbcConnection(path);
    }
    /// <summary>
    /// return the create object
    /// </summary>
    /// <returns></returns>
    public OdbcConnection getconnection()
    {
        return cc;
    }
    /// <summary>
    /// this returns the all the records from table
    /// </summary>
    /// <returns></returns>
    public DataTable get_all_records()
    {
        try
        {
            DataTable dt_all;
            OdbcConnection con = getconnection();
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from hostel", con);
            dt_all = new DataTable();
            adapter.Fill(dt_all);
            con.Close();
            return dt_all;
        }
        catch (Exception s)
        {
            string ss = s.Message;
            return null;
        }
    }
    /// <summary>
    /// this function excute the quary to update the hostel records . 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="to"></param>
    /// <param name="prefect"></param>
    /// <param name="dh"></param>
    /// <param name="head"></param>
    /// <returns></returns>
    public bool update_hostel(string id, string to, decimal prefect, decimal dh, decimal head)
    {
        bool status = false;
        try
        {
            OdbcConnection con = getconnection();
            con.Open();
            OdbcCommand cmd = new OdbcCommand("update hostel set DATE_TO='" + to + "' , HOSTEL_PREFECT_YEAR=" + prefect + " , HOSTEL_DHPREFECT_YEAR=" + dh + " , HOSTEL_HPREFECT_YEAR=" + head + " where ADMISSION_NO='" + id + "'", con);
            cmd.ExecuteNonQuery();
            status = true;
            con.Close();
            return status;

        }
        catch
        {
            return status;
        }
    }
    /// <summary>
    /// thiss function excute the quary to delete record
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool delete_hostel(string id)
    {
        bool status = false;
        try
        {
            OdbcConnection con = getconnection();
            con.Open();
            OdbcCommand cmd = new OdbcCommand("delete from hostel where ADMISSION_NO='" + id + "'", con);
            cmd.ExecuteNonQuery();
            status = true;
            con.Close();
            return status;
        }
        catch
        {
            return status;
        }
    }
    /// <summary>
    /// this function returns null data table to clear the gridview in some unhadled casuses
    /// </summary>
    /// <returns></returns>
    public DataTable fill_null()
    {
        try
        {
            DataTable dt_all;
            OdbcConnection con = getconnection();
            con.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from hostel where ADMISSION_NO='xyz')", con);
            dt_all = new DataTable();
            adapter.Fill(dt_all);
            con.Close();
            return dt_all;
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// this function execute the qaury to search hostel records accrding to the
    /// search key, The search key would be any digit of  student hostel registerd 
    /// date.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public DataTable search_hostal(string name)
    {
        try
        {
            DataTable hostel_search;
            OdbcConnection con = getconnection();
            con.Open();
            OdbcDataAdapter adpter = new OdbcDataAdapter("select * from hostel where DATE_FROM like '%" + name + "%'", con);
            hostel_search = new DataTable();
            adpter.Fill(hostel_search);
            con.Close();
            return hostel_search;

        }
        catch
        {
            return null;
        }
    }





}

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

public partial class Common_AboutUs : System.Web.UI.Page
{
    DBConnect connect = new DBConnect();
    protected void Page_Load(object sender, EventArgs e)
    {
        PnlFunction.Visible = false;
        lblhide.Visible = false;
        ImgBtnHide.Visible = false;

        DataTable set_users = get_user_logs();
        lblUserNo.Text = set_users.Rows[0][0].ToString();
        lblUserName.Text = set_users.Rows[0][2].ToString();
        lblUserRole.Text = set_users.Rows[0][1].ToString();



        DataTable management = get_user_log_management();
        lblUserPrelogtime.Text = management.Rows[0][2].ToString();
        lblUserPrelogDate.Text = management.Rows[0][1].ToString();




    }
    protected void ImgBtnShow_Click(object sender, ImageClickEventArgs e)
    {
        PnlFunction.Visible = true;
        lblhide.Visible = true;
        ImgBtnHide.Visible = true;
        ImgBtnShow.Visible = false;
        lblShowmore.Visible = false;
    }
    protected void ImgBtnHide_Click(object sender, ImageClickEventArgs e)
    {
        PnlFunction.Visible = false;
        lblhide.Visible = false;
        ImgBtnHide.Visible = false;
        ImgBtnShow.Visible = true;
        lblShowmore.Visible = true;

    }

    public DataTable get_user_logs()
    {
        try
        {
            DataTable user_details = new DataTable();
            OdbcConnection conn = connect.getconnection();
            conn.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from users_mast ", conn);
            adapter.Fill(user_details);
            return user_details;
        }
        finally
        {
            connect.close();
        }
    }

    public DataTable get_user_log_management()
    {
        try
        {
            DataTable user_detail_management = new DataTable();
            OdbcConnection conn = connect.getconnection();
            conn.Open();
            OdbcDataAdapter adapter = new OdbcDataAdapter("select * from users_log_managment ", conn);
            adapter.Fill(user_detail_management);
            return user_detail_management;
        }
        finally
        {
            connect.close();
        }
    }
    protected void txtCurPas_TextChanged(object sender, EventArgs e)
    {



    }

    public string get_current_user_password(string username)
    {
        try
        {
            string pass = null;

            OdbcConnection con = connect.getconnection();
            con.Open();

            OdbcCommand cmd = new OdbcCommand("select USER_PASSWORD from user_mast  where USER_USERNAME='" + username + "'", con);

            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pass = reader[0].ToString();
            }

            return pass;
        }
        finally
        {
            connect.close();
        }




    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        Utility utl = new Utility();

        //get user level after compair passwords
        string userLevel = utl.checkLoggin(Session["user"].ToString(), txtCurPas.Text);

        if (userLevel != "error")
        {



            if (txtNewPass.Text == txtConfPass.Text)
            {

                //assigning encripted password form text box & Encript
                Encriptor enc = new Encriptor();
                string password = enc.encript(txtConfPass.Text.ToString());

                //DB_Connect.InsertQuery("UPDATE users_mast SET USER_PASSWORD='" + password + "' WHERE USER_USERNAME='test'");
                DB_Connect.InsertQuery("UPDATE users_mast SET USER_PASSWORD='" + password + "' WHERE USER_USERNAME='" + Session["user"].ToString() + "'");


                lblstatus.Text = "Password Changed.";
            }
            else
            {
                lblstatus.Text = "Passwords Doesnt Match";
            }

        }
        else
        {
            lblstatus.Text = "Current Password Invalid";
        }

    }
    protected void lblChange_Click(object sender, EventArgs e)
    {
        if (txtCurPas.Text == get_current_user_password("admin"))
        {
            txtNewPass.Text = "match";
        }
        else
        {
            txtNewPass.Text = "not match";
        }


    }
}

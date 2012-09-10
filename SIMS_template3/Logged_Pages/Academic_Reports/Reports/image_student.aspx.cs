using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Odbc;

public partial class Logged_Pages_Academic_Reports_Reports_image_student : System.Web.UI.Page
{

    static int turn;

    protected void Page_Load(object sender, EventArgs e)
    {
        //changeImage();
        if (Session["turn"] != null )
            turn = int.Parse(Session["turn"].ToString());
        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        turn = int.Parse(Session["turn"].ToString());
        turn++;
        Session["turn"] = ""+turn;
        changeImage();
    }


    private void changeImage()
    {

        OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT ADMISSION_NO, PID FROM photograph_album WHERE ADMISSION_NO='098'");
        adpClassList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsClassList = new DataSet();
        adpClassList.Fill(dsClassList);
        if (dsClassList.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
            {
                Console.Beep();
                if (i == turn)
                {
                    Image1.ImageUrl = "~/Logged_Pages/Academic_Reports/Reports/stdImg.ashx?id=" + dsClassList.Tables[0].Rows[i][0].ToString() + "&pid=" + dsClassList.Tables[0].Rows[i][1].ToString();
                    Label1.Text = "trn=" + turn + " ~/Logged_Pages/Academic_Reports/Reports/stdImg.ashx?id=" + dsClassList.Tables[0].Rows[i][0].ToString() + "&pid=" + dsClassList.Tables[0].Rows[i][1].ToString();
                }
            }
        }
        dsClassList.Dispose();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["turn"] = "0";
    }
}

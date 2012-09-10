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

public partial class StudentHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUser.Text = Session["user"].ToString();

        string user = Session["user"].ToString();
    }
    protected void imbTotalStudents_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./AStudent_Reports/Total_Students_Categorywise.aspx");
    }
    protected void imbEnrolled_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./AStudent_Reports/Students_Enrolled_Leaved.aspx");
    }

    protected void imbStudentDetails_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./AStudent_Reports/Student_Details.aspx");
    }
    protected void imbClassdetails_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./AStudent_Reports/Class_Details_Report.aspx");
    }
}

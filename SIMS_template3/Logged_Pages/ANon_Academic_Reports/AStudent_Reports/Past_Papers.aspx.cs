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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using CrystalDecisions.Shared;
using System.Net.Mail;
using System.Text.RegularExpressions;
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlType.SelectedIndex = 0;

        if (ddlDateRange.SelectedItem.Value == "all")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal";
            GridViewPastPapers.DataBind();
        }

        if (ddlDateRange.SelectedItem.Value == "nweek")
        {
            SqlDataSourcePastPapers.SelectCommand = "select * from appointment_principal where date_format(str_to_date(ADATE, '%m/%d/%Y'), '%Y/%m/%d') between now() AND date_add(now(),INTERVAL 1 WEEK);";
            GridViewPastPapers.DataBind();
        }

        if (ddlDateRange.SelectedItem.Value == "tmonth")
        {
            SqlDataSourcePastPapers.SelectCommand = "select * from appointment_principal where MONTH(date_format(str_to_date(ADATE, '%m/%d/%Y'), '%Y/%m/%d'))=MONTH(curdate());";
            GridViewPastPapers.DataBind();
        }

        if (ddlDateRange.SelectedItem.Value == "nmonth")
        {
            SqlDataSourcePastPapers.SelectCommand = "select * from appointment_principal where MONTH(date_format(str_to_date(ADATE, '%m/%d/%Y'), '%Y/%m/%d'))=MONTH(date_add(now(),INTERVAL 1 MONTH));";
            GridViewPastPapers.DataBind();
        }


    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDateRange.SelectedIndex = 0;

        if (ddlType.SelectedItem.Value == "all")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "parent")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE type='parent'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "student")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE type='student'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "guest")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE type='guest'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "other")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE type='other'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Pending")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Pending'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Confirmed")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Confirmed'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Rescheduled")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Rescheduled'";
            GridViewPastPapers.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Cancelled")
        {
            SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Cancelled'";
            GridViewPastPapers.DataBind();
        }



    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }





    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow &&
                  e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow &&
                  e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dwn")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewPastPapers.Rows[index];
            string fName = row.Cells[4].Text;
            lblError.Text = fName;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fName);
            Response.TransmitFile(Server.MapPath("~/Past_Papers/" + fName));
            Response.End();
        }

    }
    protected void DaySelector_OnRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = !e.Day.IsWeekend;
    }

    protected void DateCal_SelectionChanged(object sender, EventArgs e)
    {
        ddlDateRange.SelectedIndex = 0;
        ddlType.SelectedIndex = 0;

        DateTime dtSelectedDate = DaySelector.SelectedDate;
        txtDate.Text = String.Format("{0:yyyy-MM-dd}", dtSelectedDate);

        SqlDataSourcePastPapers.SelectCommand = "SELECT * FROM appointment_principal WHERE ADATE='" + DaySelector.SelectedDate.ToShortDateString() + "'";
        GridViewPastPapers.DataBind();

    }

    private void sendMail(String mailto, String subject, String messege)
    {

        string pwd = "sepwd2sims"; //(ConfigurationManager.AppSettings["password"]);
        string from = "sep.wd2.sims@gmail.com"; //Replace this with your own correct Gmail Address
        string to = mailto; //Replace this with the Email Address to whom you want to send the mail
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from);
        mail.Subject = subject;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = messege;

        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(from, pwd);
        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer

        try
        {
            client.Send(mail);
            //Response.Write("Message Sent...");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

        CustomException exec = new CustomException("Success", "Mail is Successfully Sent.");
        MessageBox messageBox = new MessageBox(exec, MessageBoxDefaultButtonEnum.OK);
        messageBox.Show(this);

    }


}

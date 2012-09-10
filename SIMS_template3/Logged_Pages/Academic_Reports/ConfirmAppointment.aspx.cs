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
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal";
            GridViewAppointments.DataBind();
        }

        if (ddlDateRange.SelectedItem.Value == "nweek")
        {
            SqlDataSourceAppointments.SelectCommand = "select * from appointment_principal where date_format(str_to_date(ADATE, '%m/%d/%Y'), '%Y/%m/%d') between now() AND date_add(now(),INTERVAL 1 WEEK);";
            GridViewAppointments.DataBind();
        }

        if (ddlDateRange.SelectedItem.Value == "tmonth")
        {
            SqlDataSourceAppointments.SelectCommand = "select * from appointment_principal where MONTH(date_format(str_to_date(ADATE, '%m/%d/%Y'), '%Y/%m/%d'))=MONTH(curdate());";
            GridViewAppointments.DataBind();
        }

        if (ddlDateRange.SelectedItem.Value == "nmonth")
        {
            SqlDataSourceAppointments.SelectCommand = "select * from appointment_principal where MONTH(date_format(str_to_date(ADATE, '%m/%d/%Y'), '%Y/%m/%d'))=MONTH(date_add(now(),INTERVAL 1 MONTH));";
            GridViewAppointments.DataBind();
        }


    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDateRange.SelectedIndex = 0;

        if (ddlType.SelectedItem.Value == "all")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "parent")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE type='parent'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "student")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE type='student'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "guest")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE type='guest'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "other")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE type='other'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Pending")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Pending'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Confirmed")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Confirmed'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Rescheduled")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Rescheduled'";
            GridViewAppointments.DataBind();
        }

        else if (ddlType.SelectedItem.Value == "Cancelled")
        {
            SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE STATUS='Cancelled'";
            GridViewAppointments.DataBind();
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
        GridViewRow row;
        //identify the selcted row
        row = GridViewAppointments.Rows[Convert.ToInt32(e.CommandArgument)];
        if (e.CommandName == "confirm")
        {
            //identfy the control
            Control ctr = row.Controls[0];

            String aDate = Server.HtmlDecode(row.Cells[0].Text);
            String aTime = Server.HtmlDecode(row.Cells[1].Text);
            String nameTo = Server.HtmlDecode(row.Cells[2].Text);
            String mailTo = Server.HtmlDecode(row.Cells[4].Text);

            String messege = "Dr. S. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n" +
                System.DateTime.Today.Date.ToShortDateString() + "\n\n" +
                "Dear " + nameTo + ",\n\n" +
                "Appointment Confirmation on " + aDate + " at " + aTime + "\n\n" +
                "\t\t" + "I would hereby like to confirm our appointment made over the online appointment system. You can expect me on " + aDate + ", at " + aTime + ", at ABC National College Principal's Office.\n\n" +
                "If I do not hear from you further, I will assume that the meeting will go ahead.\n\n" +
                "I look forward to our meeting.\n\n" +
                "With kind regards,\n\n" +
                "Dr. S. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n\n" + "If there are any issues regarding the appointment contact us : \nPhone : +94112243436\nEmail : abccollege@edu.lk"; ;


            try
            {
                this.sendMail(mailTo, "Your Appointment to Meet Principal of ABC College is Confirmed.", messege);
            }
            catch (Exception exce)
            {
            }


            DB_Connect.InsertQuery("UPDATE `appointment_principal` SET `STATUS`='Confirmed' WHERE  `ADATE`='" + aDate + "' AND `ATIME_SLOT`='" + aTime + "' LIMIT 1;");
            GridViewAppointments.DataBind();


        }

        else if (e.CommandName == "reschedule")
        {


            //identfy the control
            Control ctr = row.Controls[0];
            String aDate = Server.HtmlDecode(row.Cells[0].Text);
            String aTime = Server.HtmlDecode(row.Cells[1].Text);
            String nameTo = Server.HtmlDecode(row.Cells[2].Text);
            String mailTo = Server.HtmlDecode(row.Cells[5].Text);

            String messege = "Dr. S. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n" +
                System.DateTime.Today.Date.ToShortDateString() + "\n\n" +
                "Dear " + nameTo + ",\n\n" +
                "Appointment Cancelleation on " + aDate + " at " + aTime + "\n\n" +
                "\t\t" + "I regret to inform you that I will be cancelling the appointment that you have scheduled with me on " + aDate + ", at " + aTime + ". I am still willing to continue our appointment at another date that is also convenient with you in the future. Please respond soon so that I may reserve another date for your appointment.\n\n" +
                "I hope this does not disturb your schedule. Sorry for inconvenience.\n\n" +
                "With kind regards,\n\n" +
                "Dr. S. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n\n" + "If there are any issues regarding the appointment contact us : \nPhone : +94112243436\nEmail : abccollege@edu.lk"; ;

            try
            {
                this.sendMail(mailTo, "Your Appointment to Meet Principal of ABC College is Rescheduled.", messege);
            }
            catch (Exception exce)
            {

            }


            DB_Connect.InsertQuery("UPDATE `appointment_principal` SET `STATUS`='Rescheduled' WHERE  `ADATE`='" + aDate + "' AND `ATIME_SLOT`='" + aTime + "' LIMIT 1;");
            GridViewAppointments.DataBind();



        }

        else if (e.CommandName == "cancel")
        {
            //identfy the control
            Control ctr = row.Controls[0];

            String aDate = Server.HtmlDecode(row.Cells[0].Text);
            String aTime = Server.HtmlDecode(row.Cells[1].Text);
            String nameTo = Server.HtmlDecode(row.Cells[2].Text);
            String mailTo = Server.HtmlDecode(row.Cells[5].Text);

            String messege = "Dr. S. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n" +
                System.DateTime.Today.Date.ToShortDateString() + "\n\n" +
                "Dear " + nameTo + ",\n\n" +
                "Appointment Cancelleation on " + aDate + " at " + aTime + "\n\n" +
                "\t\t" + "I regret to inform you that I will be cancelling the appointment that you have scheduled with me on " + aDate + ", at " + aTime + ".\n\n" +
                "I hope this does not disturb your schedule. Sorry for inconvenience.\n\n" +
                "With kind regards,\n\n" +
                "Dr. S. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n\n" + "If there are any issues regarding the appointment contact us : \nPhone : +94112243436\nEmail : abccollege@edu.lk"; ;



            try
            {
                this.sendMail(mailTo, "Your Appointment to Meet Principal of ABC College is Cancelled.", messege);
            }
            catch (Exception exce)
            {

            }


            DB_Connect.InsertQuery("UPDATE `appointment_principal` SET `STATUS`='Cancelled' WHERE  `ADATE`='" + aDate + "' AND `ATIME_SLOT`='" + aTime + "' LIMIT 1;");
            GridViewAppointments.DataBind();



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

        SqlDataSourceAppointments.SelectCommand = "SELECT * FROM appointment_principal WHERE ADATE='" + DaySelector.SelectedDate.ToShortDateString() + "'";
        GridViewAppointments.DataBind();

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

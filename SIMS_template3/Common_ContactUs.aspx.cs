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
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Common_AboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //clear session variables
        Session["user"] = "";
        Session["userLevel"] = "";
    }
    protected void btnSignin_Click(object sender, ImageClickEventArgs e)
    {
        ////assign session value
        //Session["user"] = txtUser.Text;

        ////fill variable
        //string user = Session["user"].ToString();

        //if (txtUser.Text == "admin" || txtUser.Text == "school" || txtUser.Text == "parent")
        //{            
        //    Response.Redirect("~/Logged_Pages/Home.aspx");
        //}


        //-------------------------------------------------------
        //create object Utility class
        Utility utl = new Utility();

        //get user level after compair passwords
        string userLevel = utl.checkLoggin(txtUser.Text, txtPass.Text);


        if (userLevel != "error")
        {
            //assign user level to the session
            Session["userLevel"] = userLevel;

            //assign session value
            Session["user"] = txtUser.Text;

            //go to Logged home page
            Response.Redirect("~/Logged_Pages/Home.aspx");
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Length <= 0 || txtMail.Text.Length <= 0)
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please fill Name and From fields.";
        }
        else if (!(isEmail(txtMail.Text)))
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            lblError.Text = "Please enter a valid E-mail Address.";
        }
        else
        {
            lblError.Text = "";
            this.sendMail(txtName.Text, txtMail.Text, txtSubject.Text, txtMessage.Text);
            lblError.ForeColor = System.Drawing.Color.Blue;
            lblError.Text = "Messege Sent.";
        }
    }

    private void sendMail(String name, String fromEmail, String subject, String messege)
    {

        string pwd = "idohavpwd"; //(ConfigurationManager.AppSettings["password"]);
        string from = "neonmax1990@gmail.com"; //Replace this with your own correct Gmail Address
        string to = "neonmax1990@gmail.com"; //Replace this with the Email Address to whom you want to send the mail
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.From = new MailAddress(from);
        mail.Subject = subject;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = messege + " \n From : " + name + " \n From Email : " + fromEmail;

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
            Response.Write("Message Sent...");
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
    }

    public static bool isEmail(string inputEmail)
    {
        // inputEmail = NulltoString(inputEmail);
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
              @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }
}


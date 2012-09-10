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
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Odbc;
using CrystalDecisions.Shared;
using System.Net.Mail;
using System.Drawing;
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void funcSendMail(String subject, String messege, String query)
    {
        string pwd = "sepwd2sims"; //(ConfigurationManager.AppSettings["password"]);
        string from = "sep.wd2.sims@gmail.com"; //Replace this with your own correct Gmail Address
        string to = "sep.wd2.sims@gmail.com"; //Replace this with the Email Address to whom you want to send the mail
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        OdbcDataAdapter adpMailList_1 = DB_Connect.ExecuteQuery(query);

        adpMailList_1.SelectCommand.CommandType = CommandType.Text;

        DataSet dsMailList_1 = new DataSet();
        adpMailList_1.Fill(dsMailList_1);
        if (dsMailList_1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsMailList_1.Tables[0].Rows.Count; i++)
            {
                System.Console.Beep();

              
                mail.To.Add(dsMailList_1.Tables[0].Rows[i][0].ToString());
                mail.To.Add(dsMailList_1.Tables[0].Rows[i][1].ToString());

            }

        }


        mail.From = new MailAddress(from);
        mail.Subject = txtSubject.Text;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = txtMessage.Text;

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

            CustomException ex = new CustomException("Success !!!", "Notification sent Successfully.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

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




    }


    protected void ddlCategoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //If Required Fields is not Selected Display Error
        if (ddlCategoryList.SelectedIndex < 1)
        {

            lblError.ForeColor = Color.Red;   //Change Label Color
            lblError.Text = "Please Select a Valid Category";  //Set Error

        }


        else if (ddlCategoryList.SelectedIndex == 1)
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            lblGrade.Visible = true;
            lblGrade.Text = "Grade";

            ddlGrade.Visible = true;
            ddlGrade.Items.Clear();
            ddlGrade.Items.Add(new ListItem("Select Grade", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlGrade.Items.Add(GradeList);
            }

        }

        else if (ddlCategoryList.SelectedIndex == 2)
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            lblGrade.Visible = true;
            lblGrade.Text = "Grade";

            ddlGrade.Visible = true;
            ddlGrade.Items.Clear();     //Clear the existing Items
            ddlGrade.Items.Add(new ListItem("Select Grade", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlGrade.Items.Add(GradeList);
            }


        }
        else if (ddlCategoryList.SelectedIndex == 3)
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            lblGrade.Visible = true;
            lblGrade.Text = "Grade";

            ddlGrade.Visible = true;
            ddlGrade.Items.Clear();     //Clear the excisting Items
            ddlGrade.Items.Add(new ListItem("Select Grade", "Empty"));
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlGrade.Items.Add(GradeList);
            }

        }

        else
        {
            lblError.Text = "";  //After Fixing error hide the Error Message
            if (ddlGrade.SelectedIndex == 1) { }
        }

    }

    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategoryList.SelectedIndex == 1) 
        {
            fillToField();
        }
        else if (ddlCategoryList.SelectedIndex == 2 | ddlCategoryList.SelectedIndex == 3)
        {
            lblCategory.Visible = true;
            lblCategory.Text = "Class";
            ddlCategory.Visible = true;


            ddlCategory.Items.Clear();     //Clear the excisting Items
            ddlCategory.Items.Add(new ListItem("Select Class", "Empty"));      //Add Empty Item
            //Execute Query and 
            OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT DISTINCT CLASS_CODE FROM student_class WHERE SC_GRADE='" + ddlGrade.SelectedValue + "'");
            adpClassList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsClassList = new DataSet();
            adpClassList.Fill(dsClassList);
            if (dsClassList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstClassList = new ListItem();
                    lstClassList.Value = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    lstClassList.Text = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    ddlCategory.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();

            

        }


    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategoryList.SelectedIndex == 2)
        {
            fillToField();
        }

        else if (ddlCategoryList.SelectedIndex == 3)
        {


            lblStudent.Visible = true;
            lblStudent.Text = "Student";
            ddlStudent.Visible = true;


            ddlStudent.Items.Clear();
            ddlStudent.Items.Add(new ListItem("Select Student", "empty"));
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT `NAME_INITIALS` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + ddlGrade.SelectedIndex + "' AND SC.CLASS_CODE = '" + ddlCategory.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");

            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstNameList = new ListItem();
                    lstNameList.Value = dsNameList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    lstNameList.Text = dsNameList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset                   
                    ddlStudent.Items.Add(lstNameList);
                }
            }
            dsNameList.Dispose();
            
        }
    }


    protected void fillToField()
    {
        if (ddlCategoryList.SelectedIndex == 1 && ddlGrade.SelectedIndex > 0)
        {
            System.Console.Beep();
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT DISTINCT S.FATHER_EMAIL, S.MOTHER_EMAIL FROM `student_mast` S, `student_class` SC WHERE SC.SC_GRADE='" + ddlGrade.SelectedValue + "' AND S.FATHER_EMAIL IS NOT NULL AND S.MOTHER_EMAIL IS NOT NULL");

            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {


                    if (i == 0)
                        txtTo.Text = dsNameList.Tables[0].Rows[i][0].ToString();
                    else
                        txtTo.Text = txtTo.Text + "," + dsNameList.Tables[0].Rows[i][0].ToString();

                    txtTo.Text = txtTo.Text + "," + dsNameList.Tables[0].Rows[i][1].ToString();
                }
            }
            dsNameList.Dispose();
        }
        else if (ddlCategoryList.SelectedIndex == 2 && ddlGrade.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0)
        {
            System.Console.Beep();
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT DISTINCT S.FATHER_EMAIL, S.MOTHER_EMAIL FROM `student_mast` S, `student_class` SC WHERE SC.SC_GRADE='" + ddlGrade.SelectedValue + "'AND SC.CLASS_CODE='" + ddlCategory.SelectedValue + "'  AND S.FATHER_EMAIL IS NOT NULL AND S.MOTHER_EMAIL IS NOT NULL");

            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {


                    if (i == 0)
                        txtTo.Text = dsNameList.Tables[0].Rows[i][0].ToString();
                    else
                        txtTo.Text = txtTo.Text + "," + dsNameList.Tables[0].Rows[i][0].ToString();

                    txtTo.Text = txtTo.Text + "," + dsNameList.Tables[0].Rows[i][1].ToString();
                }
            }
            dsNameList.Dispose();

        }

        else if (ddlCategoryList.SelectedIndex == 3 && ddlGrade.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0 && ddlStudent.SelectedIndex > 0)
        {
            System.Console.Beep();
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT DISTINCT S.FATHER_EMAIL, S.MOTHER_EMAIL FROM `student_mast` S, `student_class` SC WHERE SC.SC_GRADE='" + ddlGrade.SelectedValue + "' AND SC.CLASS_CODE='" + ddlCategory.SelectedValue + "'AND S.NAME_INITIALS='" + ddlStudent.SelectedValue + "'AND S.FATHER_EMAIL IS NOT NULL AND S.MOTHER_EMAIL IS NOT NULL");

            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {


                    if (i == 0)
                        txtTo.Text = dsNameList.Tables[0].Rows[i][0].ToString();
                    else
                        txtTo.Text = txtTo.Text + "," + dsNameList.Tables[0].Rows[i][0].ToString();

                    txtTo.Text = txtTo.Text + "," + dsNameList.Tables[0].Rows[i][1].ToString();
                }
            }
            dsNameList.Dispose();

        }

    }




    protected void btnSend_Click(object sender, EventArgs e)
    {

        if (ddlCategoryList.SelectedIndex == 1)
        {
            if (ddlGrade.SelectedIndex > 0)
            {


                //.....send mail
                funcSendMail(txtSubject.Text, txtMessage.Text, "SELECT DISTINCT S.FATHER_EMAIL, S.MOTHER_EMAIL FROM `student_mast` S, `student_class` SC WHERE SC.SC_GRADE='" + ddlGrade.SelectedValue + "' AND S.FATHER_EMAIL IS NOT NULL AND S.MOTHER_EMAIL IS NOT NULL");

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please select a Grade";
            }

        }
        if (ddlCategoryList.SelectedIndex == 2)
        {

            if (ddlGrade.SelectedIndex > 0)
            {
                lblError.Text = "";

                if (ddlCategory.SelectedIndex > 0)
                {
                    
                    //..send mail
                    funcSendMail(txtSubject.Text, txtMessage.Text, "SELECT DISTINCT S.FATHER_EMAIL, S.MOTHER_EMAIL FROM `student_mast` S, `student_class` SC WHERE SC.SC_GRADE='" + ddlGrade.SelectedValue + "'AND SC.CLASS_CODE='" + ddlCategory.SelectedValue + "'  AND S.FATHER_EMAIL IS NOT NULL AND S.MOTHER_EMAIL IS NOT NULL");

                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Please select a Class";
                }

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please select a Grade";
            }
        }

        if (ddlCategoryList.SelectedIndex == 3)
        {


            if (ddlGrade.SelectedIndex > 0)
            {
                lblError.Text = "";

                if (ddlCategory.SelectedIndex > 0)
                {
                    lblError.Text = "";

                    if (ddlStudent.SelectedIndex > 0)
                    {
                        
                        //..send mail
                        funcSendMail(txtSubject.Text, txtMessage.Text, "SELECT DISTINCT S.FATHER_EMAIL, S.MOTHER_EMAIL FROM `student_mast` S, `student_class` SC WHERE SC.SC_GRADE='" + ddlGrade.SelectedValue + "' AND SC.CLASS_CODE='" + ddlCategory.SelectedValue + "'AND S.NAME_INITIALS='" + ddlStudent.SelectedValue + "'AND S.FATHER_EMAIL IS NOT NULL AND S.MOTHER_EMAIL IS NOT NULL");
                    }
                    else
                    {
                        lblError.Text = "Please select a Student Name";
                    }

                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "Please select a Class";
                }

            }
            else
            {
                lblError.ForeColor = Color.Red;
                lblError.Text = "Please select a Grade";
            }

        }


    }

    private void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();
                      
            ClearInputs(ctrl.Controls);
            
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillToField();
    }
}

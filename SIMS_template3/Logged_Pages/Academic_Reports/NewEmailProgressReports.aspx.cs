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


    private string generateReport(String sterm, String sgrade, String sclass, String sadno)
    {

        ParameterDiscreteValue crtparamDiscValue;
        ParameterField crtParamField;
        ParameterFields crtParamFields;

        crtparamDiscValue = new ParameterDiscreteValue();
        crtParamField = new ParameterField();
        crtParamFields = new ParameterFields();

        crtparamDiscValue.Value = sadno;
        crtParamField.ParameterFieldName = "adno";
        crtParamField.CurrentValues.Add(crtparamDiscValue);
        crtParamFields.Add(crtParamField);


        crtparamDiscValue.Value = sgrade;
        crtParamField.ParameterFieldName = "grade";
        crtParamField.CurrentValues.Add(crtparamDiscValue);
        crtParamFields.Add(crtParamField);

        crtparamDiscValue.Value = sterm;
        crtParamField.ParameterFieldName = "term";
        crtParamField.CurrentValues.Add(crtparamDiscValue);
        crtParamFields.Add(crtParamField);


        crtparamDiscValue.Value = sclass;
        crtParamField.ParameterFieldName = "class";
        crtParamField.CurrentValues.Add(crtparamDiscValue);
        crtParamFields.Add(crtParamField);

        crvReportViewer.ParameterFieldInfo = crtParamFields;

        //Create report document
        ReportDocument crystalReport = new ReportDocument();

        //Load crystal report made in design view
        crystalReport.Load(Server.MapPath("Reports/NewStudentAcaPerf.rpt"));

        //Set DataBase Login Info
        crystalReport.SetDatabaseLogon("root", "123", @"localhost", "nsis");

        //Provide parameter values
        crystalReport.SetParameterValue("adno", sadno);
        crystalReport.SetParameterValue("grade", sgrade);
        crystalReport.SetParameterValue("term", sterm);
        crystalReport.SetParameterValue("class", sclass);
        crystalReport.SetParameterValue("padno", sadno);
        crystalReport.SetParameterValue("pgrade", sgrade);
        crystalReport.SetParameterValue("pterm", sterm);
        crystalReport.SetParameterValue("pclass", sclass);
        crystalReport.SetParameterValue("mgrade", sgrade);
        crystalReport.SetParameterValue("mterm", sterm);
        crystalReport.SetParameterValue("mclass", sclass);

        Random random = new Random();
        int randomNumber = random.Next(0, 100);

        string filename = System.IO.Path.GetTempPath() + randomNumber + "-ProgressReport.pdf";
        crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, filename);
        crvReportViewer.ReportSource = crystalReport;
        return filename;

    }

    private void funcSendReport(String subject, String messege, String sterm, String sgrade, String sclass, String sadno)
    {

        DateTime dt = DateTime.Now;
        int year = dt.Year;
        if (ddlYear.SelectedIndex == 0)
            year = dt.Year;
        else if (ddlYear.SelectedIndex == 1)
            year = dt.Year - 1;

        if (sterm != null && sgrade != null && sclass == null && sadno == null)
        {
            OdbcDataAdapter adpStudentList = DB_Connect.ExecuteQuery("SELECT DISTINCT TM.TERM, TM.SC_GRADE, TM.CLASS_CODE, TM.ADMISSION_NO, SM.FATHER_EMAIL, SM.MOTHER_EMAIL, SM.FATHER_NAME, SM.NAME_INITIALS FROM term_marks TM, student_mast SM WHERE TM.TERM=" + sterm + " AND TM.SC_GRADE=" + sgrade + " AND TM.ADMISSION_NO = SM.ADMISSION_NO");

            adpStudentList.SelectCommand.CommandType = CommandType.Text;

            DataSet dsStudentList = new DataSet();
            adpStudentList.Fill(dsStudentList);
            if (dsStudentList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsStudentList.Tables[0].Rows.Count; i++)
                {
                    string path = this.generateReport(dsStudentList.Tables[0].Rows[i][0].ToString(), dsStudentList.Tables[0].Rows[i][1].ToString(), dsStudentList.Tables[0].Rows[i][2].ToString(), dsStudentList.Tables[0].Rows[i][3].ToString());

                    String messegetext = "Dr. W. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n" +
                    System.DateTime.Today.Date.ToShortDateString() + "\n\n" +
                    "Dear Mr. / Mrs." + dsStudentList.Tables[0].Rows[i][6].ToString() + ",\n\n" +
                    "Progress Report of your child " + dsStudentList.Tables[0].Rows[i][7].ToString() + "\n\n" +
                    "\t\t" + "Herewith attached the progress report of your child " + dsStudentList.Tables[0].Rows[i][7].ToString() + " for the term " + sterm + " of " + year + " academic year.\n\n" +
                    "Please take the nessasary actions to improve the academic performance of your child in the future.\n\n" +
                    "With kind regards,\n\n" +
                    "Dr. W. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n\n" + "If there are any issues regarding the acedemic performance of your child contact us : \nPhone : +94112243436\nEmail : abccollege@edu.lk"; ;




                    if (dsStudentList.Tables[0].Rows[i][4] != null && dsStudentList.Tables[0].Rows[i][5] != null)
                    {
                        funcSendMail("Progress Reports", messegetext, dsStudentList.Tables[0].Rows[i][4].ToString(), dsStudentList.Tables[0].Rows[i][5].ToString(), path);
                    }
                    else if (dsStudentList.Tables[0].Rows[i][4] != null && dsStudentList.Tables[0].Rows[i][5] == null)
                    {
                        funcSendMail("Progress Reports", messegetext, dsStudentList.Tables[0].Rows[i][4].ToString(), null, path);
                    }
                    else if (dsStudentList.Tables[0].Rows[i][4] == null && dsStudentList.Tables[0].Rows[i][5] != null)
                    {
                        funcSendMail("Progress Reports", messegetext, null, dsStudentList.Tables[0].Rows[i][5].ToString(), path);
                    }
                }
            }
        }




        else if (sterm != null && sgrade != null && sclass != null && sadno == null)
        {
            OdbcDataAdapter adpStudentList = DB_Connect.ExecuteQuery("SELECT DISTINCT TM.TERM, TM.SC_GRADE, TM.CLASS_CODE, TM.ADMISSION_NO, SM.FATHER_EMAIL, SM.MOTHER_EMAIL, SM.FATHER_NAME, SM.NAME_INITIALS FROM term_marks TM, student_mast SM WHERE TM.TERM=" + sterm + " AND TM.SC_GRADE=" + sgrade + " AND TM.CLASS_CODE='" + sclass + "' AND TM.ADMISSION_NO = SM.ADMISSION_NO");

            adpStudentList.SelectCommand.CommandType = CommandType.Text;

            DataSet dsStudentList = new DataSet();
            adpStudentList.Fill(dsStudentList);
            if (dsStudentList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsStudentList.Tables[0].Rows.Count; i++)
                {
                    string path = this.generateReport(dsStudentList.Tables[0].Rows[i][0].ToString(), dsStudentList.Tables[0].Rows[i][1].ToString(), dsStudentList.Tables[0].Rows[i][2].ToString(), dsStudentList.Tables[0].Rows[i][3].ToString());

                    String messegetext = "Dr. W. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n" +
               System.DateTime.Today.Date.ToShortDateString() + "\n\n" +
               "Dear Mr. / Mrs." + dsStudentList.Tables[0].Rows[i][6].ToString() + ",\n\n" +
               "Progress Report of your child " + dsStudentList.Tables[0].Rows[i][7].ToString() + "\n\n" +
               "\t\t" + "Herewith attached the progress report of your child " + dsStudentList.Tables[0].Rows[i][7].ToString() + " for the term " + sterm + " of " + year + " academic year.\n\n" +
               "Please take the nessasary actions to improve the academic performance of your child in the future.\n\n" +
               "With kind regards,\n\n" +
               "Dr. W. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n\n" + "If there are any issues regarding the acedemic performance of your child contact us : \nPhone : +94112243436\nEmail : abccollege@edu.lk"; ;


                    if (dsStudentList.Tables[0].Rows[i][4] != null && dsStudentList.Tables[0].Rows[i][5] != null)
                    {
                        funcSendMail("Progress Reports", messegetext, dsStudentList.Tables[0].Rows[i][4].ToString(), dsStudentList.Tables[0].Rows[i][5].ToString(), path);
                    }
                    else if (dsStudentList.Tables[0].Rows[i][4] != null && dsStudentList.Tables[0].Rows[i][5] == null)
                    {
                        funcSendMail("Progress Reports", messegetext, dsStudentList.Tables[0].Rows[i][4].ToString(), null, path);
                    }
                    else if (dsStudentList.Tables[0].Rows[i][4] == null && dsStudentList.Tables[0].Rows[i][5] != null)
                    {
                        funcSendMail("Progress Reports", messegetext, null, dsStudentList.Tables[0].Rows[i][5].ToString(), path);
                    }
                }
            }
        }


        else if (sterm != null && sgrade != null && sclass != null && sadno != null)
        {

            OdbcDataAdapter adpStudentList = DB_Connect.ExecuteQuery("SELECT DISTINCT TM.TERM, TM.SC_GRADE, TM.CLASS_CODE, TM.ADMISSION_NO, SM.FATHER_EMAIL, SM.MOTHER_EMAIL, SM.FATHER_NAME, SM.NAME_INITIALS FROM term_marks TM, student_mast SM WHERE TM.TERM=" + sterm + " AND TM.SC_GRADE=" + sgrade + " AND TM.CLASS_CODE='" + sclass + "' AND TM.ADMISSION_NO='" + sadno + "' AND TM.ADMISSION_NO = SM.ADMISSION_NO");

            adpStudentList.SelectCommand.CommandType = CommandType.Text;

            DataSet dsStudentList = new DataSet();
            adpStudentList.Fill(dsStudentList);
            if (dsStudentList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsStudentList.Tables[0].Rows.Count; i++)
                {


                    string path = this.generateReport(dsStudentList.Tables[0].Rows[i][0].ToString(), dsStudentList.Tables[0].Rows[i][1].ToString(), dsStudentList.Tables[0].Rows[i][2].ToString(), dsStudentList.Tables[0].Rows[i][3].ToString());

                    String messegetext = "Dr. W. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n" +
               System.DateTime.Today.Date.ToShortDateString() + "\n\n" +
               "Dear Mr. / Mrs." + dsStudentList.Tables[0].Rows[i][6].ToString() + ",\n\n" +
               "Progress Report of your child " + dsStudentList.Tables[0].Rows[i][7].ToString() + "\n\n" +
               "\t\t" + "Herewith attached the progress report of your child " + dsStudentList.Tables[0].Rows[i][7].ToString() + " for the term " + sterm + " of " + year + " academic year.\n\n" +
               "Please take the nessasary actions to improve the academic performance of your child in the future.\n\n" +
               "With kind regards,\n\n" +
               "Dr. W. Rajakaruna,\nPrincipal,\nABC National College,\nColombo 7.\n\n\n" + "If there are any issues regarding the acedemic performance of your child contact us : \nPhone : +94112243436\nEmail : abccollege@edu.lk"; ;


                    if (dsStudentList.Tables[0].Rows[i][4] != null && dsStudentList.Tables[0].Rows[i][5] != null)
                    {
                        funcSendMail("Progress Reports", messegetext, dsStudentList.Tables[0].Rows[i][4].ToString(), dsStudentList.Tables[0].Rows[i][5].ToString(), path);
                    }
                    else if (dsStudentList.Tables[0].Rows[i][4] != null && dsStudentList.Tables[0].Rows[i][5] == null)
                    {
                        funcSendMail("Progress Reports", messegetext, dsStudentList.Tables[0].Rows[i][4].ToString(), null, path);
                    }
                    else if (dsStudentList.Tables[0].Rows[i][4] == null && dsStudentList.Tables[0].Rows[i][5] != null)
                    {
                        funcSendMail("Progress Reports", messegetext, null, dsStudentList.Tables[0].Rows[i][5].ToString(), path);
                    }
                }
            }
        }



    }


    private void funcSendMail(String subject, String messege, String fatheraddress, string motheraddress, String path)
    {

        string pwd = "sepwd2sims"; //(ConfigurationManager.AppSettings["password"]);
        string from = "sep.wd2.sims@gmail.com"; //Replace this with your own correct Gmail Address
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        mail.To.Add(fatheraddress);
        mail.To.Add(motheraddress);
        mail.From = new MailAddress(from);

        if (txtSubject.Text.ToString().Length > 0)
            mail.Subject = txtSubject.Text;
        else
            mail.Subject = subject;

        mail.SubjectEncoding = System.Text.Encoding.UTF8;

        if (txtMessage.Text.ToString().Length > 0)
            mail.Body = messege + "\n\n Note : " + txtMessage.Text;
        else
            mail.Body = messege;

        //string attachmentFile = @"" + path;
        //System.Net.Mail.Attachment mailAttachment = new System.Net.Mail.Attachment(attachmentFile);
        //mail.Attachments.Add(mailAttachment);

        // Create  the file attachment for this e-mail message.
        Attachment attach = new Attachment(path);
        // Add the file attachment to this e-mail message.
        mail.Attachments.Add(attach);


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


            CustomException ex = new CustomException("Success !!!", "Progres Reports sent Successfully.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

            ClearInputs(Page.Controls);

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
            ddlCategory.Visible = false;
            ddlCategory.Items.Clear();     //Clear the existing Items
            lblCategory.Visible = false;
            ddlStudent.Visible = false;
            ddlStudent.Items.Clear();     //Clear the existing Items
            lblStudent.Visible = false;
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
            ddlStudent.Visible = false;
            ddlStudent.Items.Clear();     //Clear the existing Items
            lblStudent.Visible = false;
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

        if (ddlCategoryList.SelectedIndex == 2 || ddlCategoryList.SelectedIndex == 3)
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

        if (ddlCategoryList.SelectedIndex == 3)
        {


            lblStudent.Visible = true;
            lblStudent.Text = "Student";
            ddlStudent.Visible = true;


            ddlStudent.Items.Clear();
            ddlStudent.Items.Add(new ListItem("Select Student", "empty"));
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT S.NAME_INITIALS,S.ADMISSION_NO FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + ddlGrade.SelectedIndex + "' AND SC.CLASS_CODE = '" + ddlCategory.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");

            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstNameList = new ListItem();
                    lstNameList.Value = dsNameList.Tables[0].Rows[i][1].ToString(); // or your index which is correct in your dataset
                    lstNameList.Text = dsNameList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset                   
                    ddlStudent.Items.Add(lstNameList);
                }
            }
            dsNameList.Dispose();

        }
    }




    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (ddlCategoryList.SelectedIndex == 0)
            lblError.Text = "Please Select a Category";

        if (ddlCategoryList.SelectedIndex == 1)
        {
            if (ddlGrade.SelectedIndex > 0)
            {

                funcSendReport(txtSubject.Text, txtMessage.Text, ddlTerm.SelectedIndex.ToString(), ddlGrade.SelectedIndex.ToString(), null, null);

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

                    funcSendReport(txtSubject.Text, txtMessage.Text, ddlTerm.SelectedIndex.ToString(), ddlGrade.SelectedIndex.ToString(), ddlCategory.SelectedValue.ToString(), null);

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

                        if (ddlTerm.SelectedIndex != 0)
                        {

                            lblError.Text = "";

                            // create a delegate of MethodInvoker poiting to
                            // our Foo function.
                            MethodInvoker simpleDelegate = new MethodInvoker(Foo);

                            // Calling Foo Async
                            simpleDelegate.BeginInvoke(null, null);


                            CustomException ex = new CustomException("Success !!!", "Progres Reports are Added to mailing queue Successfully.");
                            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                            messageBox.Show(this);

                            //ClearInputs(Page.Controls);
                            lblGrade.Visible = false;
                            ddlGrade.Visible = false;
                            lblCategory.Visible = false;
                            ddlCategory.Visible = false;
                            lblStudent.Visible = false;
                            ddlStudent.Visible = false;
                        }
                        else
                        {
                            lblError.Text = "Please Select a Term.";
                        }




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


    public delegate void MethodInvoker();

    private void Foo()
    {
        funcSendReport(txtSubject.Text, txtMessage.Text, ddlTerm.SelectedIndex.ToString(), ddlGrade.SelectedIndex.ToString(), ddlCategory.SelectedValue.ToString(), ddlStudent.SelectedValue.ToString());
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

    }

}

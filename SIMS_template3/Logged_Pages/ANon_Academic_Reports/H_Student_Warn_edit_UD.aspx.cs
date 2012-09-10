using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DeepASP.JQueryPromptuTest;
using System.Net.Mail;
using System.Net;




public partial class Student_Warn_edit : System.Web.UI.Page
{
    //define comman object for database access
    Student_Warning_DBCONNECT swdb = new Student_Warning_DBCONNECT();
    //define comman variables for hold the selected row data
    static string id = null;
    static string date = null;
    static string type = null;
    static string level = null;
    static string message = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //invoke the grdi filling methode
                fill();
                //invoke the ddl_grade filling  methode
                fillgrade();

            }
        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "Page can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }

    }

    //fill the ddl_garde with grade details
    public void fillgrade()
    {
        try
        {
            //invoke the methode to get all grades
            ddl_grade.DataSource = swdb.get_all_grades();
            ddl_grade.DataMember = "SC_GRADE";
            ddl_grade.DataValueField = "SC_GRADE";
            ddl_grade.DataBind();

        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "grade details can not retrived");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
    }
    //fill the ddl_class with selected grade
    public void fillclass(decimal grade)
    {
        try
        {
            //invoke the methode to retrive the class details according to the selected grade
            ddl_class.DataSource = swdb.get_class_relevaent_grade(grade);
            ddl_class.DataMember = "CLASS_CODE";
            ddl_class.DataValueField = "CLASS_CODE";
            ddl_class.DataBind();

        }
        catch (Exception ss)
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "class detals can not retrived");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);


        }
    }
    //fill the ddl student with the studendetails
    public void fillstudeent(char classs, decimal grade)
    {
        try
        {
            ///invoke the methode to retrive the student details accoriding to the selected class and grade
            ddl_student.DataSource = swdb.get_all_students_of_class(classs, grade);
            ddl_student.DataMember = "ADMISSION_NO";
            ddl_student.DataValueField = "ADMISSION_NO";
            ddl_student.DataBind();

        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "students of the selected class can not be retrived");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
    }

    //fill the drivview with table data
    public void fill()
    {
        try
        {
            //invoke the methode to retrive the record from the table
            gv_warning.DataSource = swdb.databind();
            gv_warning.DataBind();
        }
        catch (Exception dd)
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "warning details can not be retrived");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }

    protected void ddl_grade_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //invoke the methode to fill classess accrding to selected class
            fillclass(Convert.ToDecimal(ddl_grade.Text));
        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "class details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
 
        }
    }
    //validate the selected date
    public bool validate_date(string date)
    {
        int selected_date = 0;
        try
        {
            //hold the cureent date and month
            string format = date.Substring(3, 1);
            int this_month = Convert.ToInt32(DateTime.Today.Month.ToString());
            int today = Convert.ToInt32(DateTime.Today.Day.ToString());
            //hold the selected date and month
            int selected_month = Convert.ToInt32(date.Substring(0, 1));
            if (format == "/")
            {
                selected_date = Convert.ToInt32(date.Substring(2, 1));
            }
            else
            {
                selected_date = Convert.ToInt32(date.Substring(2, 2));
            }
            //return false if data is not valide
            if (selected_date <= today && this_month <= selected_month)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "There is a problem with selected date");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
            return true;
        }
    }
    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //invoke the methode to fill student according to selected class and grade
            fillstudeent(Convert.ToChar(ddl_class.Text), Convert.ToDecimal(ddl_grade.Text));
        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "student details can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }

    }
    protected void ddl_student_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //fill the grid view with record according to selected  student
            gv_warning.DataSource=swdb.search_results(ddl_student.Text);
            gv_warning.DataBind();
        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "selected students warning records can not be loaded");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }

    protected void gv_warning_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //move the selected record in to data modify state
        gv_warning.EditIndex = e.NewEditIndex;
        fill();


        //hold the selected  row values
        GridViewRow row = gv_warning.Rows[Convert.ToInt32(e.NewEditIndex)];

        id = gv_warning.DataKeys[e.NewEditIndex].Value.ToString();

        DropDownList wtype =
          (DropDownList)row.FindControl("ddl_warningcode");
        type = wtype.Text;

        DropDownList wlevel =
                  (DropDownList)row.FindControl("ddl_level");
        level = wlevel.Text;

        TextBox wdate = (TextBox)row.FindControl("txt_date");
        date = wdate.Text;
    }
    protected void gv_warning_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //bound the data in to selected rocrd drop down  lists
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //check if is in edit mode
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddl_warn =
                          (DropDownList)e.Row.FindControl("ddl_warningcode");
                //Bind subcategories data to dropdownlist
                ddl_warn.DataTextField = "WARNING_CODE";
                ddl_warn.DataValueField = "WARNING_CODE";
                ddl_warn.DataSource = swdb.getall_warn_codes();
                ddl_warn.DataBind();
                DataRowView dr = e.Row.DataItem as DataRowView;
                ddl_warn.SelectedValue =
                             dr["WARNING_CODE"].ToString();

                DropDownList ddl_levels =
                            (DropDownList)e.Row.FindControl("ddl_level");
                //Bind subcategories data to dropdownlist
                ddl_levels.DataTextField = "LEVEL_CODE";
                ddl_levels.DataValueField = "LEVEL_CODE";
                ddl_levels.DataSource = swdb.get_all_level_codes();
                ddl_levels.DataBind();
                DataRowView dr2 = e.Row.DataItem as DataRowView;
                ddl_levels.SelectedValue =
                             dr["LEVEL_CODE"].ToString();
            }
        }
    }
    protected void gv_warning_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //hold the newly enterd value that is to be updated
        GridViewRow row = gv_warning.Rows[Convert.ToInt32(e.RowIndex)];

        string nid = gv_warning.DataKeys[e.RowIndex].Value.ToString();

        DropDownList wtype =
          (DropDownList)row.FindControl("ddl_warningcode");
        string ntype = wtype.Text;

        DropDownList wlevel =
                  (DropDownList)row.FindControl("ddl_level");
        string nlevel = wlevel.Text;

        TextBox wdate = (TextBox)row.FindControl("txt_date");
        string ndate = wdate.Text;
        TextBox wnote = (TextBox)row.FindControl("txt_note");
        string nnote = wnote.Text;
        message = wnote.Text;

        CheckBox par = (CheckBox)row.FindControl("chkStatus");
        decimal inform = 0;
        //check the parent infom status and then define the decimal value
        if (par.Checked)
        {
            inform = 1;
        }
        else
        {
            inform = 0;
        }
        //check whether the all the field are filled accordinly
        if (id == string.Empty || ntype == string.Empty || nlevel == string.Empty || ndate == string.Empty || nnote == string.Empty)
        {
            CustomException ex = new CustomException("Error !!!", "Fill all the fields");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate the insertd date
        else if (validate_date(ndate))
        {
            CustomException ex = new CustomException("Error !!!", "Selected date is beyond the current date");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
        else
        {
            try
            {
                //invoke the update methode
                if (swdb.update_record(id, ndate, ntype, nlevel, nnote, inform, date, type, level))
                {
                    //popout custom message is success
                    CustomException ex = new CustomException("Success !!!", "Record updated successfully");
                    MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messageBox.Show(this);

                    if (inform == 1)
                    {
                        if (SendMail(id))
                        {
                            CustomException ex_m = new CustomException("Success !!!", "Mail send");
                            MessageBox Box = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                            Box.Show(this);

                        }
                        else
                        {
                            CustomException x = new CustomException("Error !!!", "Mail can not send");
                            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                            messages.Show(this);
 
                        }
                    }
                    
                }
            }
            catch
            {
                //popout custom message if any error happans
                CustomException ex = new CustomException("Error !!!", "selected  record can not be updated");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
            }
        }

        //move the record from edit state
        gv_warning.EditIndex = -1;
        fill();
    }
    protected void gv_warning_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            //move the selected record from edit sate
            gv_warning.EditIndex = -1;
            fill();
        }
        catch
        {
            //popout custom message if any error happans
            CustomException ex = new CustomException("Error !!!", "Error with data");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
    protected void gv_warning_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //acces the row and get a cell values
        gv_warning.EditIndex = e.RowIndex;
        fill();
        try
        {
            GridViewRow row = gv_warning.Rows[Convert.ToInt32(e.RowIndex)];

            string nid = gv_warning.DataKeys[e.RowIndex].Value.ToString();

            TextBox wdate = (TextBox)row.FindControl("txt_date");
            string ndate = wdate.Text;
            DropDownList wtype =
              (DropDownList)row.FindControl("ddl_warningcode");
            string ntype = wtype.Text;

            DropDownList wlevel =
                      (DropDownList)row.FindControl("ddl_level");
            string nlevel = wlevel.Text;
            try
            {
                //invoke the delete record methode
                if (swdb.delete_record(nid, ndate, ntype, nlevel))
                {
                    //popout custom message if success
                    CustomException ex = new CustomException("Success !!!", "Record deleted successfully");
                    MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messageBox.Show(this);

                }
            }
            catch
            {
                //popout custom message if any error happans
                CustomException ex = new CustomException("Error !!!", "Selected record can not be deleted");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
            }

        }
        catch (Exception d)
        {
            string s = d.Message;

        }
        //move the selected record from the edi state
        gv_warning.EditIndex = -1;
        fill();
    }
    protected void gv_warning_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //define new set a record to be displyed
        gv_warning.PageIndex = e.NewPageIndex;
        fill();
    }
    protected bool SendMail(string id)
    {
        bool sta = false;
        var toAddress = string.Empty;
        string fmail, mmail, gmail = null;
        DataTable mails = swdb.get_email(id);
        fmail = mails.Rows[0]["FATHER_EMAIL"].ToString();
        mmail = mails.Rows[0]["MOTHER_EMAIL"].ToString();
        gmail = mails.Rows[0]["GUARDIAN_EMAIL"].ToString();
        // Gmail Address from where you send the mail
        var fromAddress = "defenceinova@gmail.com";
        // any address where the email will be sending
        if (fmail != null)
        {
            toAddress = fmail.ToString(); ;
        }
        else if (mmail != null)
        {
            toAddress = mmail.ToString(); ;
        }
        else
        {
            toAddress = gmail.ToString();
        }
        //Password of your gmail address
        const string fromPassword = "defenceinova";
        // Passing the values and make a email formate to display
        string subject = "Student Behaviour";
        string body = message.ToString();
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
            sta = true;


        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);
        return sta;
    }
}

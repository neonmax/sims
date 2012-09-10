using System;
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
using DeepASP.JQueryPromptuTest;

public partial class _Default : System.Web.UI.Page 
{
    //creare comman object for database connection
    Event sedc = new Event();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //invoke the event master drop down  filling methode
                fill_ddl_eventmaster();
            }
        }
        catch
        {
            //Response.Write("<script>alert('event master details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "event details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }

    }

    //fill the dropdown list with all master catagory
    public void fill_ddl_eventmaster()
    {
        try
        {
            //invoe get all grade methode
           ddl_main.DataSource = sedc.get_event_master();
           ddl_main.DataMember = "EVENT_TYPE_MAST";
           ddl_main.DataValueField = "EVENT_TYPE_MAST";
           ddl_main.DataBind();
        }
        catch
        {
           // Response.Write("<script>alert('event master details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "Event master details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //fill the dropdown list with all sub events
    public void fill_ddl_subevents(string master)
    {
        try
        {
            //invoe get all grade methode
            ddl_sub.DataSource = sedc.get_subevents(master);
            ddl_sub.DataMember = "EVENT_TYPE_SUB";
            ddl_sub.DataValueField = "EVENT_TYPE_SUB";
            ddl_sub.DataBind();
        }
        catch
        {
            //Response.Write("<script>alert('sub event details can not be loaded')</script>");
            CustomException ex = new CustomException("Error !!!", "event sub details can not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //check the input date is according to the gi
    public bool validate_date(string date)
    {
        int selected_date = 0;
        try
        {
            //detect the input date and month and current date and month
            string format = date.Substring(3, 1);
            int this_month = Convert.ToInt32(DateTime.Today.Month.ToString());
            int today = Convert.ToInt32(DateTime.Today.Day.ToString());
            int selected_month = Convert.ToInt32(date.Substring(0, 1));
            if (format == "/")
            {
                selected_date = Convert.ToInt32(date.Substring(2, 1));
            }
            else
            {
                selected_date = Convert.ToInt32(date.Substring(2, 2));
            }



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
            CustomException ex = new CustomException("Error !!!", "selected date is incorrect");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
           // Response.Write("<script>alert('Selected date is in incorrect format')</script>");
            return true;

        }
    }
    //clear the data text fields
    public void clear()
    {
        txt_date.Text = string.Empty;
        txt_des.Text = string.Empty;
        txt_id.Text = string.Empty;
        txt_issue.Text = string.Empty;
        txt_name.Text = string.Empty;
        txt_org.Text = string.Empty;
    }
    //invoke the sub event data filling methodes
    protected void ddl_main_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fill_ddl_subevents(ddl_main.Text);
        }
        catch
        {
           // Response.Write("<script>('Sub catagory details can not be load')</script>");
            CustomException ex = new CustomException("Error !!!", "event sub catagoty details ca not be loaded");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
    }
    //invoke the clear methode
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        clear();
    }
    //invoke the insert methode and validate the fields
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        //validate event id
        if (txt_id.Text == string.Empty)
        {
           // Response.Write("<script>alert('Please insert the event id')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please insert the event id");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
        //validate the catagory main type
        else if (ddl_main.Text == string.Empty)
        {
           // Response.Write("<script>alert('Please select main event type')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please select  the event main type");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
        //validate the sub event type
        else if (ddl_sub.Text == string.Empty)
        {
           // Response.Write("<script>alert('Please select sub event type')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please select  the event sub type");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate the event date
        else if (txt_date.Text == string.Empty)
        {
            //Response.Write("<script>alert('Please select a date')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please select  the date");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate the description
        else if (txt_des.Text == string.Empty)
        {
            //Response.Write("<script>alert('Please insert event description')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please insert the event description");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate the event name
        else if (txt_name.Text == string.Empty)
        {
           // Response.Write("<script>alert('Please insert  event name')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please insert the event name");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //validate the organizer
        else if (txt_org.Text == string.Empty)
        {
            //Response.Write("<script>alert('Please insert event organizer ')</script>");
            CustomException ex = new CustomException("Warning  !!!", "Please insert the event organizer");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
            //invoke the date validation methode
        else if (validate_date(txt_date.Text))
        {
           // Response.Write("<script>alert('selected date is beyond the current date')</script>");
            CustomException ex = new CustomException("Warning  !!!", "selected date is beyond the current date");
            MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messages.Show(this);
        }
        else
        {
            try
            {
                //invoke the input methode
                if (sedc.insert_record(txt_id.Text, ddl_main.Text, ddl_sub.Text, txt_name.Text.Trim(), txt_date.Text.Trim(), txt_des.Text.Trim(), txt_org.Text.Trim(), txt_issue.Text.Trim()))
                {
                   // Response.Write("<script>alert('Record inserted successfully')</script>");
                    CustomException ex = new CustomException("Successs  !!!", "Record inserted successfully");
                    MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messages.Show(this);
                    //clear the text fields if the insert is successfull
                    clear();
                }


            }
            catch
            {
                //Response.Write("<script>alert('Error, Record can not be inserted)</script>");
                CustomException ex = new CustomException("Error !!!", "Record can not be inserted");
                MessageBox messages = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messages.Show(this);

            }
        }
    }
}

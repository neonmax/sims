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
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_STD_Activity_Log : System.Web.UI.Page
{
    //define comman object for database access
    schoolevent_DBCONNECT sedb = new schoolevent_DBCONNECT();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //fill all the records
                fill();
            }
        }
        catch
        {
            //promt error meesage is any exception happens
            CustomException ex = new CustomException("Error !!!", "Error in Page loading");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }


    }

    //invoke the methode to get all table records
    public void fill()
    {
        try
        {
            //invoke the get all methde
            gv_events.DataSource = sedb.getall();
            gv_events.DataBind();

        }
        catch
        {
            //promt error meesage is any exception happens
            CustomException ex = new CustomException("Error !!!", "Data can not be loaded to page");
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

            //hold the current date  and month
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
            //check whether the selected date is beyond the current date
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
            //promt error meesage is any exception happens
            CustomException ex = new CustomException("Error !!!", "Selected Date is in incorrect format");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

            return true;

        }
    }

    protected void gv_events_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            //move the selected record in to modify mode
            gv_events.EditIndex = e.NewEditIndex;
            //invoke the fill method
            fill();
        }
        catch
        {
            //promt error meesage is any exception happens
            CustomException ex = new CustomException("Error !!!", "Selected Record can not be move to modify");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
    protected void gv_events_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //check if is in edit mode
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList main =
                              (DropDownList)e.Row.FindControl("ddl_master");
                    //Bind subcategories data to dropdownlist
                    main.DataMember = "EVENT_TYPE_MAST";
                    main.DataValueField = "EVENT_TYPE_MAST";
                    main.DataSource = sedb.get_event_master();
                    main.DataBind();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    main.SelectedValue =
                                 dr["EVENT_TYPE_MAST"].ToString();

                    DropDownList sub =
                    (DropDownList)e.Row.FindControl("ddl_sub");
                    //Bind subcategories data to dropdownlist
                    sub.DataTextField = "EVENT_TYPE_SUB";
                    sub.DataValueField = "EVENT_TYPE_SUB";
                    sub.DataSource = sedb.get_subevents();
                    sub.DataBind();
                    DataRowView dr2 = e.Row.DataItem as DataRowView;
                    main.SelectedValue =
                                 dr["EVENT_TYPE_SUB"].ToString();

                }
            }
        }
        catch
        {
            //promt error meesage is any exception happens
            CustomException ex = new CustomException("Error !!!", "Selected row's values are not available");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        //check whether the search search word is empty
        if (txt_search.Text == string.Empty)
        {
            Response.Write("<script>alert('Plaese insert search key')</script>");
            //CustomException ex = new CustomException("Warning !!!", "Please insert a key for search");
            //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            //messageBox.Show(this);
        }
        else
        {
            try
            {
                //invoke the methode to get search result
                gv_events.DataSource = sedb.search(txt_search.Text);
                gv_events.DataBind();
            }
            catch
            {
                //promt error meesage is any exception happens
                CustomException ex = new CustomException("Error !!!", "Search results are not avalible");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);

            }
        }
    }
    protected void gv_events_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //hold the cell data in to variables
        GridViewRow row = gv_events.Rows[Convert.ToInt32(e.RowIndex)];
        string id = gv_events.DataKeys[e.RowIndex].Value.ToString();
        DropDownList ddlt =
          (DropDownList)row.FindControl("ddl_master");
        string nmain = ddlt.Text;
        DropDownList ddltype =
                  (DropDownList)row.FindControl("ddl_sub");
        string nsub = ddltype.Text;
        TextBox tname = (TextBox)row.FindControl("txt_eventname");
        string nname = tname.Text;
        TextBox tdate = (TextBox)row.FindControl("txt_helddate");
        string ndate = tdate.Text;
        TextBox tdes = (TextBox)row.FindControl("txt_description");
        string ndes = tdes.Text;
        TextBox torg = (TextBox)row.FindControl("txt_organizer");
        string norga = torg.Text;
        TextBox tissue = (TextBox)row.FindControl("txt_facedissues");
        string nissue = tissue.Text;

        //check whether the ll the fields are fille
        if (id == string.Empty || nmain == string.Empty || nsub == string.Empty || ndate == string.Empty || ndes == string.Empty || norga == string.Empty || nissue == string.Empty)
        {
            Response.Write("<script>alert('Plaese insert all the fields')</script>");
            //promt error meesage is any exception happens
            //CustomException ex = new CustomException("Warning!!!", "Please fill all the fields");
            //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            //messageBox.Show(this);

        }
            //check the date is validated
        else if (validate_date(ndate))
        {
            Response.Write("<script>alert('selected date is incorrect')</script>");
            //promt error meesage is any exception happens
            //CustomException ex = new CustomException("Warning!!!", "Selected Date is greater than current date");
            //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            //messageBox.Show(this);

        }
        else
        {
            try
            {
                //invoke the updated methide
                if (sedb.update_record(id, nmain, nsub, nname, ndate, ndes, norga, nissue))
                {
                    Response.Write("<script>alert('Record updated successfully')</script>");
                    ////prompt a succcess message if the updated is success
                    //CustomException ex = new CustomException("Success !!!", "Record is updated successfully");
                    //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    //messageBox.Show(this);

                }
            }
            catch
            {
                Response.Write("<script>alert('Record can not be updated')</script>");
                ////promt error meesage is any exception happens
                //CustomException ex = new CustomException("Error !!!", "Selected record can not be updated");
                //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                //messageBox.Show(this);
            }
        }
        //move the record from updated methode
        gv_events.EditIndex = -1;
        fill();
    }
    protected void gv_events_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //move the record from updated methode
        gv_events.EditIndex = -1;
        fill();
    }
    protected void gv_events_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //hold the id of the record which is going to be delete
        GridViewRow row = gv_events.Rows[Convert.ToInt32(e.RowIndex)];
        string id = gv_events.DataKeys[e.RowIndex].Value.ToString();
        try
        {
            //invoke the delete methode
            if (sedb.delete_record(id))
            {
                Response.Write("<script>alert('Record deleted successfully')</script>");
                ////promt an message if the delete is success
                //CustomException ex = new CustomException("Success!!!", "Selected record is successfully deleted");
                //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                //messageBox.Show(this);

            }
        }
        catch
        {
            Response.Write("<script>alert('Record can not be deleted')</script>");
            ////move the record from updated methode
            //CustomException ex = new CustomException("Error !!!", "Selected record can not be deleted");
            //MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            //messageBox.Show(this);

        }
        //move the record from edit mode
        gv_events.EditIndex = -1;
        fill();
    }
    protected void gv_events_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //select the next blok of record
        gv_events.PageIndex = e.NewPageIndex;
        fill();
    }
}

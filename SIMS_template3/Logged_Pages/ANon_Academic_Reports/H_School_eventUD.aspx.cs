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

public partial class School_event : System.Web.UI.Page
{
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
            CustomException ex = new CustomException("Error !!!", "Error in Page loading");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
       

    }

    public void fill()
    {
        try
        {
            gv_events.DataSource=sedb.getall();
            gv_events.DataBind();

        }
        catch
        {
            CustomException ex = new CustomException("Error !!!", "Data can not be loaded to page");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
 
        }
    }


    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    try
    //    {
    //        gv_events.EditIndex = e.NewEditIndex;
    //        fill();
    //    }
    //    catch
    //    {
    //        CustomException ex = new CustomException("Error !!!", "Selected Record can not be move to modify");
    //        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //        messageBox.Show(this);
    //    }

    //}

    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            //check if is in edit mode
    //            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
    //            {
    //                DropDownList main =
    //                          (DropDownList)e.Row.FindControl("ddl_master");
    //                //Bind subcategories data to dropdownlist
    //                main.DataMember = "EVENT_TYPE_MAST";
    //                main.DataValueField = "EVENT_TYPE_MAST";
    //                main.DataSource = sedb.get_event_master();
    //                main.DataBind();
    //                DataRowView dr = e.Row.DataItem as DataRowView;
    //                main.SelectedValue =
    //                             dr["EVENT_TYPE_MAST"].ToString();

    //                DropDownList sub =
    //                (DropDownList)e.Row.FindControl("ddl_sub");
    //                //Bind subcategories data to dropdownlist
    //                sub.DataTextField = "EVENT_TYPE_SUB";
    //                sub.DataValueField = "EVENT_TYPE_SUB";
    //                sub.DataSource = sedb.get_subevents(main.SelectedValue);
    //                sub.DataBind();
    //                DataRowView dr2 = e.Row.DataItem as DataRowView;
    //                main.SelectedValue =
    //                             dr["EVENT_TYPE_SUB"].ToString();

    //            }
    //        }
    //    }
    //    catch
    //    {
    //        CustomException ex = new CustomException("Error !!!", "Selected row's values are not available");
    //        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //        messageBox.Show(this);
    //    }
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //    if (txt_search.Text == string.Empty)
    //    {
    //        CustomException ex = new CustomException("Warning !!!", "Please insert a key for search");
    //        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //        messageBox.Show(this);
    //    }
    //    else
    //    {
    //        try
    //        {
    //            gv_events.DataSource = sedb.search(txt_search.Text);
    //            gv_events.DataBind();
    //        }
    //        catch
    //        {
    //            CustomException ex = new CustomException("Error !!!", "Search results are not avalible");
    //            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //            messageBox.Show(this);

    //        }
    //    }
    //}
    //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    GridViewRow row = gv_events.Rows[Convert.ToInt32(e.RowIndex)];
    //    string id = gv_events.DataKeys[e.RowIndex].Value.ToString();
    //    DropDownList ddlt =
    //      (DropDownList)row.FindControl("ddl_master");
    //    string nmain = ddlt.Text;
    //    DropDownList ddltype =
    //              (DropDownList)row.FindControl("ddl_sub");
    //    string nsub = ddltype.Text;
    //    TextBox tname = (TextBox)row.FindControl("txt_eventname");
    //    string nname = tname.Text;
    //    TextBox tdate = (TextBox)row.FindControl("txt_helddate");
    //    string ndate = tdate.Text;
    //    TextBox tdes = (TextBox)row.FindControl("txt_description");
    //    string ndes = tdes.Text;
    //    TextBox torg = (TextBox)row.FindControl("txt_organizer");
    //    string norga = torg.Text;
    //    TextBox tissue = (TextBox)row.FindControl("txt_facedissues");
    //    string nissue = tissue.Text;

    //    if (id == string.Empty || nmain == string.Empty || nsub == string.Empty || ndate == string.Empty || ndes == string.Empty || norga == string.Empty || nissue == string.Empty)
    //    {
    //        CustomException ex = new CustomException("Warning!!!", "Please fill all the fields");
    //        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //        messageBox.Show(this);
 
    //    }
    //    else if(validate_date(ndate))
    //    {
    //        CustomException ex = new CustomException("Warning!!!", "Selected Date is greater than current date");
    //        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //        messageBox.Show(this);

    //    }
    //    else
    //    {
    //        try
    //        {
    //            if (sedb.update_record(id, nmain, nsub, nname, ndate, ndes, norga, nissue))
    //            {
    //                CustomException ex = new CustomException("Success !!!", "Record is updated successfully");
    //                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //                messageBox.Show(this);

    //            }
    //        }
    //        catch
    //        {
    //            CustomException ex = new CustomException("Error !!!", "Selected record can not be updated");
    //            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //            messageBox.Show(this);
    //        }
    //    }
    //    gv_events.EditIndex = -1;
    //    fill();
    //}
    //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gv_events.EditIndex = -1;
    //    fill();

    //}
    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    GridViewRow row = gv_events.Rows[Convert.ToInt32(e.RowIndex)];
    //    string id = gv_events.DataKeys[e.RowIndex].Value.ToString();
    //    try
    //    {
    //        if (sedb.delete_record(id))
    //        {
    //            CustomException ex = new CustomException("Success!!!", "Selected record is successfully deleted");
    //            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //            messageBox.Show(this);

    //        }
    //    }
    //    catch
    //    {
    //        CustomException ex = new CustomException("Error !!!", "Selected record can not be deleted");
    //        MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
    //        messageBox.Show(this);
 
    //    }
    //    gv_events.EditIndex = -1;
    //    fill();


    //}
    public bool validate_date(string date)
    {
        int selected_date = 0;
        try
        {

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
            gv_events.EditIndex = e.NewEditIndex;
            fill();
        }
        catch
        {
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
            CustomException ex = new CustomException("Error !!!", "Selected row's values are not available");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (txt_search.Text == string.Empty)
        {
            CustomException ex = new CustomException("Warning !!!", "Please insert a key for search");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);
        }
        else
        {
            try
            {
                gv_events.DataSource = sedb.search(txt_search.Text);
                gv_events.DataBind();
            }
            catch
            {
                CustomException ex = new CustomException("Error !!!", "Search results are not avalible");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);

            }
        }
    }
    protected void gv_events_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
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

        if (id == string.Empty || nmain == string.Empty || nsub == string.Empty || ndate == string.Empty || ndes == string.Empty || norga == string.Empty || nissue == string.Empty)
        {
            CustomException ex = new CustomException("Warning!!!", "Please fill all the fields");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
        else if (validate_date(ndate))
        {
            CustomException ex = new CustomException("Warning!!!", "Selected Date is greater than current date");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
        else
        {
            try
            {
                if (sedb.update_record(id, nmain, nsub, nname, ndate, ndes, norga, nissue))
                {
                    CustomException ex = new CustomException("Success !!!", "Record is updated successfully");
                    MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messageBox.Show(this);

                }
            }
            catch
            {
                CustomException ex = new CustomException("Error !!!", "Selected record can not be updated");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
            }
        }
        gv_events.EditIndex = -1;
        fill();
    }
    protected void gv_events_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_events.EditIndex = -1;
        fill();
    }
    protected void gv_events_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = gv_events.Rows[Convert.ToInt32(e.RowIndex)];
        string id = gv_events.DataKeys[e.RowIndex].Value.ToString();
        try
        {
            if (sedb.delete_record(id))
            {
                CustomException ex = new CustomException("Success!!!", "Selected record is successfully deleted");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);

            }
        }
        catch
        {
            CustomException ex = new CustomException("Error !!!", "Selected record can not be deleted");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

        }
        gv_events.EditIndex = -1;
        fill();
    }
    protected void gv_events_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_events.PageIndex = e.NewPageIndex;
        fill();
    }
}

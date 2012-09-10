using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Odbc;
using System.Collections;
using System.Collections.Generic;
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_STD_Activity_Log : System.Web.UI.Page
{
    /// <summary>
    /// Author - E.A Heshan Sandeepa IT 10 1598 04
    /// 2012-08-16
    /// this is the comman variable to access the database
    /// </summary>
    Hostel_Edit hd = new Hostel_Edit();
    /// <summary>
    /// when page loading all the records in the table would be there
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                lbl_status.Text = string.Empty;
                fill();
               
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Page can not be loaded.')", true);
        }
    }
    /// <summary>
    /// when search button is clicked it will check weather the txt_search is empty, then display a message
    /// other wise execute the search quary  and returns the data tablewith the database and fill the gridview.
    /// other wise display an message if any exceprion.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_search_Click1(object sender, EventArgs e)
    {
        try
        {
            if (txt_search.Text == string.Empty || txt_search.Text == null)
            {
                lbl_status.Text = "Insert Key";
            }
            else
            {
                gv_UD_hostel.DataSource = hd.search_hostal(txt_search.Text.Trim());
                gv_UD_hostel.DataBind();
                lbl_status.Text = string.Empty;
                txt_search.Text = string.Empty;
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Search Operation Can Not Be Completed.')", true);
            txt_search.Text = string.Empty;
        }

    }
    /// <summary>
    /// move the record in to edit mode, text boxex will be appear. all the labels will
    /// be clear. and then again invoke the methode to fill the gidview.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_UD_hostel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //txt_search.Text = "dddddd";
        try
        {
            lbl_status.Text = string.Empty;
            txt_search.Text = string.Empty;
            gv_UD_hostel.EditIndex = e.NewEditIndex;
            fill();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Selected Row Can Not Be Move To Edit Mode')", true);
        }
    }
    /// <summary>
    /// when update link clicked the record will be updated. first it read the values from the 
    /// edited grid view.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_UD_hostel_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            //create data table to hold the list values after validation
            DataTable dt = new DataTable();
            //add  cloumn 
            dt.Columns.Add("values");
            //clear all the fields
            lbl_status.Text = string.Empty;
            txt_search.Text = string.Empty;
            //identfy the selected record
            GridViewRow row = gv_UD_hostel.Rows[Convert.ToInt32(e.RowIndex)];
            //select the student id
            string id = gv_UD_hostel.DataKeys[e.RowIndex].Value.ToString();
            //select the students regsiterd date
            string nfrom = gv_UD_hostel.Rows[Convert.ToInt32(e.RowIndex)].Cells[2].Text;
            //select the to date
            TextBox todate = (TextBox)row.FindControl("txtto");
            string ntodate = todate.Text;
            //select the prefect date
            TextBox prefect = (TextBox)row.FindControl("txt_prefect");
            string nprefect = prefect.Text;
            //select the deputy head prefect year
            TextBox dhprefect = (TextBox)row.FindControl("txt_dh");
            string ndhprefect = dhprefect.Text;
            //select the head prefect year
            TextBox hprefect = (TextBox)row.FindControl("txt_hp");
            string nhprefect = hprefect.Text;
            //select the registerd year
            int year_sep = nfrom.LastIndexOf('/');
            int from_date = Convert.ToInt16(nfrom.Substring(year_sep + 1, 4));
            //invoke date checking validation methodes
            if ((checkdate(ntodate) == 1) && (verify_years(from_date, nprefect, ndhprefect, nhprefect) == 1))
            {
                //create the generic list to hold values
                List<string> list = new List<string>();
                //add records in to list
                list.Add(ntodate); list.Add(nprefect); list.Add(ndhprefect); list.Add(nhprefect);
                //access the each list value and check whether they are null or not 
                //if null then set the value as 0;
                foreach (string s in list)
                {
                    if (s == string.Empty || s == null)
                    {
                        dt.Rows.Add("0");
                    }
                    else
                    {
                        dt.Rows.Add(s);
                    }
                }
                //invoke the methide to update methode
                if (hd.update_hostel(id, dt.Rows[0]["values"].ToString(), Convert.ToDecimal(dt.Rows[1]["values"].ToString()), Convert.ToDecimal(dt.Rows[2]["values"].ToString()), Convert.ToDecimal(dt.Rows[3]["values"].ToString())))
                {
                    //display the  suucess message if the operation is succussfull
                    CustomException ex = new CustomException("Success", "Record Successfully Updated");
                    MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                    messageBox.Show(this);
                    gv_UD_hostel.EditIndex = -1;
                    fill();

                    //lbl_status.Text = "record updated successfully";
                    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Record Successfully Updated')", true);
                }
            }
            else
            {
                //create alert if any exception happens
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Please Insert Proper Values As Inputs Or Keep The Default Value As It Is.')", true);
            }
        }
        catch (Exception ss)
        {
            string s = ss.Message;
            //lbl_status.Text = "Can not update the record";    
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Record Can not be Updated')", true);
        }
    }


    protected void gv_UD_hostel_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    /// <summary>
    /// this invoke th fill methode to fill the gridview
    /// </summary>
    public void fill()
    {
        try
        {
            gv_UD_hostel.DataSource = hd.get_all_records();
            gv_UD_hostel.DataBind();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Data Can Not Be Loaded.')", true);
        }
    }
    /// <summary>
    /// take of the record which is in the edit mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_UD_hostel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        txt_search.Text = string.Empty;
        lbl_status.Text = string.Empty;
        gv_UD_hostel.EditIndex = -1;
        fill();
    }
    /// <summary>
    /// this methode validate method of the inserted date
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public int checkdate(string date)
    {
        //check the whether the date is empty
        int a = 0;
        if (date == "0")
        {
            return 1;
        }
        else
        {
            try
            {
               
                int year = Convert.ToInt16(date.Substring(6, 2));
                //check the ate lengh
                if (date.Length > 10 || date.Length < 8)
                {
                    a = 0;
                }
                //check if there  any mis characters
                else if (!date.Contains("/"))
                {
                    a = 0;
                }
                //check the month value is larger than 12
                else if (Convert.ToInt16(date.Substring(0, 1)) > 12)
                {
                    a = 0;
                }
                //check the year is greater than 99
                else if (year > 99)
                {
                    a = 0;
                }
                //check the date
                else if (Convert.ToInt16(date.Substring(0, 1)) == 0)
                {
                    return 1;
                }
                else
                {
                    a = 1;
                }
                return a;
            }
            catch
            {
                return a;
            }
        }
    }
    /// <summary>
    /// invoke the delete quary. inpu will be the student id
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_UD_hostel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txt_search.Text = string.Empty;
        lbl_status.Text = string.Empty;
        GridViewRow row = gv_UD_hostel.Rows[Convert.ToInt32(e.RowIndex)];
        string id = gv_UD_hostel.DataKeys[e.RowIndex].Value.ToString();
        try
        {
            //invoke delete quary, if deletion is succcess prompts a message
            if (hd.delete_hostel(id))
            {
                //lbl_status.Text = "Record Successfully deleted";
                CustomException ex = new CustomException("Success", "Record Successfully Deleted");
                MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
                messageBox.Show(this);
                gv_UD_hostel.EditIndex = -1;
                fill();
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('record deleted')", true);
            }
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!!  Selected Record Can not be Deleted.')", true);
        }
        gv_UD_hostel.EditIndex = -1;
        fill();
    }
    /// <summary>
    /// this validate the prefects years values
    /// </summary>
    /// <param name="from"></param>
    /// <param name="prefect"></param>
    /// <param name="deputy"></param>
    /// <param name="head"></param>
    /// <returns></returns>
    public int verify_years(int from, string pprefect, string pdeputy, string phead)
    {
        try
        {
            int prefect = Convert.ToInt16(pprefect);
            int deputy = Convert.ToInt16(pdeputy);
            int head = Convert.ToInt16(phead);

            int stat = 1;
            int current_year = Convert.ToInt16(DateTime.Today.Year);
            List<int> years = new List<int>();
            years.Add(prefect);
            years.Add(deputy);
            years.Add(head);
            foreach (int y in years)
            {
                if (y == 0 || (y >= from) && (y <= current_year))
                {
                    stat = 1;
                }
                else
                {
                    //return 0;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Prefect Year Values Must Be Within  Accomodation Period Or Less Than Or Equal To Current Year.')", true);
                    return 0;
                }
            }
            return stat;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// this event select recrords 10 by 10
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_UD_hostel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            txt_search.Text = string.Empty;
            lbl_status.Text = string.Empty;
            gv_UD_hostel.PageIndex = e.NewPageIndex;
            fill();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error!! Can Not Move To Next Page')", true);
        }
    }
}

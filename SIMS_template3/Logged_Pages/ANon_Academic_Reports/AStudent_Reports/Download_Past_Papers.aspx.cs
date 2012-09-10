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
            string fName = e.CommandArgument.ToString();

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fName);
            Response.TransmitFile(Server.MapPath("~/Past_Papers/" + fName));
            Response.End();
        }

    }


    protected void ddlCat_List_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlCat_List.SelectedIndex == 1)
        {
            lblCat1.Visible = true;
            ddlCat1.Visible = true;
            lblCat1.Text = "Year :";

            ddlCat1.Items.Clear();
            ddlCat1.Items.Add(new ListItem("Select Year", "Empty"));      //Add Empty Item
            for (int i = 2000; i <= 2012; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = i.ToString();
                ddlCat1.Items.Add(GradeList);
            }

        }

        else if (ddlCat_List.SelectedIndex == 2)
        {
            lblCat1.Visible = true;
            lblCat1.Text = "Grade :";
            ddlCat1.Visible = true;

            ddlCat1.Items.Clear();
            ddlCat1.Items.Add(new ListItem("Select Grade", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlCat1.Items.Add(GradeList);
            }

        }
        else if (ddlCat_List.SelectedIndex == 3)
        {
            lblCat1.Visible = true;
            lblCat1.Text = "Subject :";
            ddlCat1.Visible = true;


            ddlCat1.Items.Clear();     //Clear the excisting Items
            ddlCat1.Items.Add(new ListItem("Select Subject", "Empty"));      //Add Empty Item
            //Execute Query and 
            OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT DISTINCT S.SUBJECT_CODE, S.SUBJECT FROM subjects_mast S");
            adpClassList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsClassList = new DataSet();
            adpClassList.Fill(dsClassList);
            if (dsClassList.Tables[0].Rows.Count > 0)
            {
                Console.Beep();
                for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstClassList = new ListItem();
                    lstClassList.Value = dsClassList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset
                    lstClassList.Text = dsClassList.Tables[0].Rows[i][1].ToString(); // or your index which is correct in your dataset
                    ddlCat1.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();
        }

        else if (ddlCat_List.SelectedIndex == 4)
        {
            lblCat1.Visible = true;
            lblCat1.Text = "Grade :";
            ddlCat1.Visible = true;

            lblCat2.Visible = true;
            lblCat2.Text = "Term :";
            ddlCat2.Visible = true;

            ddlCat1.Items.Clear();
            ddlCat1.Items.Add(new ListItem("Select Grade", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 13; i++)
            {
                ListItem GradeList = new ListItem();
                GradeList.Value = i.ToString();
                GradeList.Text = "Grade " + i;
                ddlCat1.Items.Add(GradeList);
            }

            ddlCat2.Items.Clear();
            ddlCat2.Items.Add(new ListItem("Select Term", "Empty"));      //Add Empty Item
            for (int i = 1; i <= 3; i++)
            {
                ListItem TermList = new ListItem();
                TermList.Value = i.ToString();
                TermList.Text = "Term " + i;
                ddlCat2.Items.Add(TermList);
            }



        }

        else
        {

        }
    }


    protected void ddlCat2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCat_List.SelectedIndex == 4)
        {
            if (ddlCat1.SelectedIndex > 0 && ddlCat2.SelectedIndex > 0)
            {
                SqlDataSourcePastPapers.SelectCommand = "SELECT  P.PPRID, P.YEAR, P.GRADE, P.TERM, P.FILENAME, P.SIZE, S.SUBJECT FROM subjects_mast S, past_papers P WHERE P.SUB_CODE = S.SUBJECT_CODE AND P.GRADE=" + ddlCat1.SelectedValue + " AND P.TERM=" + ddlCat2.SelectedValue + " ORDER BY P.YEAR DESC ,P.GRADE ASC,P.TERM ASC";

                GridViewPastPapers.DataBind();
            }
            else if (ddlCat2.SelectedIndex <= 0)
            {
                lblError.Text = "invalid  term";
            }
        }

    }
    protected void ddlCat_3_SelectedIndexChanged(object sender, EventArgs e)
    {
        
      
    }
    protected void ddlCat_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCat_List.SelectedIndex == 1)
        {
            if (ddlCat1.SelectedIndex > 0)
            {
                SqlDataSourcePastPapers.SelectCommand = "SELECT  P.PPRID, P.YEAR, P.GRADE, P.TERM, P.FILENAME, P.SIZE, S.SUBJECT FROM subjects_mast S, past_papers P WHERE P.SUB_CODE = S.SUBJECT_CODE AND P.YEAR=" + ddlCat1.SelectedValue+" ORDER BY P.YEAR DESC ,P.GRADE ASC,P.TERM ASC";
                GridViewPastPapers.DataBind();
            }
            else
            {
                lblError.Text = "invalid year";
            }
        }



        else if (ddlCat_List.SelectedIndex == 2)
        {
            if (ddlCat1.SelectedIndex > 0)
            {

                SqlDataSourcePastPapers.SelectCommand = "SELECT  P.PPRID, P.YEAR, P.GRADE, P.TERM, P.FILENAME, P.SIZE, S.SUBJECT FROM subjects_mast S, past_papers P WHERE P.SUB_CODE = S.SUBJECT_CODE AND P.GRADE=" + ddlCat1.SelectedValue + " ORDER BY P.YEAR DESC ,P.GRADE ASC,P.TERM ASC";

                GridViewPastPapers.DataBind();
            }
            else
            {
                lblError.Text = "invalid  grade";
            }
        }


        else if (ddlCat_List.SelectedIndex == 3)
        {
            if (ddlCat1.SelectedIndex > 0)
            {

                SqlDataSourcePastPapers.SelectCommand = "SELECT  P.PPRID, P.YEAR, P.GRADE, P.TERM, P.FILENAME, P.SIZE, S.SUBJECT FROM subjects_mast S, past_papers P WHERE P.SUB_CODE = S.SUBJECT_CODE AND P.SUB_CODE=" + ddlCat1.SelectedValue + " ORDER BY P.YEAR DESC ,P.GRADE ASC,P.TERM ASC";

                GridViewPastPapers.DataBind();
            }
            else
            {
                lblError.Text = "invalid  subject";
            }
        }


        else if (ddlCat_List.SelectedIndex == 4)
        {
            if (ddlCat1.SelectedIndex <= 0)
            {
                lblError.Text = "Invalid Grade";
            }
        }

    }
    protected void GridViewPastPapers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }


    protected void PostBackBind_DataBinding(object sender, EventArgs e)
    {

        LinkButton lb = (LinkButton)sender;
        ScriptManager.GetCurrent(this).RegisterPostBackControl(lb);
        

    }


}

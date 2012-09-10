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
using System.IO;
using DeepASP.JQueryPromptuTest;

public partial class Logged_Pages_AParents_Reports_Parent_Info : System.Web.UI.Page
{
    static String adNo;
    string filename;
    int filesize;

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
            ddlSubject.Items.Clear();
            ddlSubject.Items.Add(new ListItem("Select Subject", "empty"));
            OdbcDataAdapter adpSubjectList = DB_Connect.ExecuteQuery("SELECT SUBJECT,SUBJECT_CODE FROM subjects_mast WHERE Grade_" + ddlGrade.SelectedItem.Value );
            adpSubjectList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsSubjectList = new DataSet();
            adpSubjectList.Fill(dsSubjectList);
            if (dsSubjectList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSubjectList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstSubjectList = new ListItem();
                    lstSubjectList.Value = dsSubjectList.Tables[0].Rows[i][1].ToString(); // or your index which is correct in your dataset
                    lstSubjectList.Text = dsSubjectList.Tables[0].Rows[i][0].ToString(); // or your index which is correct in your dataset                   
                    ddlSubject.Items.Add(lstSubjectList);
                }
            }
            dsSubjectList.Dispose();

        }
    
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        
            if (fuStudentImage.HasFile)
            {
                try
                {
                    filename = Path.GetFileName(fuStudentImage.FileName);
                    filesize = fuStudentImage.PostedFile.ContentLength/1024;
                    fuStudentImage.SaveAs(Server.MapPath("~/Past_Papers/") + filename);                   
                }
                catch (Exception ex)
                {
                    lblError.Text = "";
                }
            addFile();
            }else
            {
                lblError.Text = "Please select a file to Upload.";
            
            }
           
        


    }

    private void addFile()
    {

        bool result = false;


        result = DB_Connect.InsertQuery("INSERT INTO `past_papers` (`YEAR`, `GRADE`, `TERM`, `SUB_CODE` , FILENAME, SIZE) VALUES('" + ddlYear.SelectedItem.Value + "', '" + ddlGrade.SelectedItem.Value + "', '" + ddlterm.SelectedItem.Value + "', '" + ddlSubject.SelectedItem.Value + "', '" + filename + "', '" + filesize + "KB')");

        if (result)
        {
            

            CustomException ex = new CustomException("Success !!!", "File Saved Successfully.");
            MessageBox messageBox = new MessageBox(ex, MessageBoxDefaultButtonEnum.OK);
            messageBox.Show(this);

            ClearInputs(Page.Controls);

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
        lblError.Text = "";
        ClearInputs(Page.Controls);
    }

  
}

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

public partial class Logged_Pages_AParents_Reports_SendSMS : System.Web.UI.Page
{
    //dsAdNoList.Tables[0].Rows.Count();  to get count
    //then proceed with iterative sms sending
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }   
    protected void btnSendGrp_Click(object sender, EventArgs e)
    {
        BtnRstGrp.Text = "Cancel";
        //Preceeding notifiation image shows
        ImgProcessGrp.Visible = true;
        //Show status 
        lblStstusGrp.Visible = true;
        //Create variables
        string GrpStdNo;
        string GrpSender;
        string GrpMsg;
        //Get student no from dropdown list
        GrpStdNo = DrpdwnStdList.SelectedItem.ToString();
        //Get sender details from text field
        GrpSender = txtSenderGrp.Text;
        //Get meeesage from text field
        GrpMsg = txtMsgGroup.Text.Trim();
        //save mobile # in to session
        Session["mobileNo"] = GrpStdNo;
        //string number = "94716233138";//Request.QueryString[""];
        //string message = "Gayan.. cheeers...!!! working properly";//Request.QueryString["message"];  
      
        //Create object from RoutoSMSTelecom 
        RoutoSMSTelecom routo = new RoutoSMSTelecom();
        //Set user name
        routo.SetUser("1175036");
        //Set password
        routo.SetPass("td389jvf");
        //Set receiver's mobile no 
        routo.SetNumber(GrpStdNo);
        //Set sender's details
        routo.SetOwnNumber(GrpSender);
        //Set message type
        routo.SetType("SMS");
        //Set the message
        routo.SetMessage(GrpMsg);
       
        //Send message
         string header = routo.Send();
        //Check the header
         if (header == "error")
         {
             //change label attributes
             lblStstusGrp.ForeColor = System.Drawing.Color.Red;
             lblStstusGrp.Text = "Connectiing.... Internet Failure !";
             btnSendGrp.Text = "Retry";
         }
         else
         {
             //HIde notification inage
             ImgProcessGrp.Visible = false;
             //Show message sent notification
             lblStstusGrp.Text = "Message sent to +" + Session["mobileNo"];
             //clear data fields after sending the messages
             DrpdwnStdList.ClearSelection();
             txtSenderGrp.Text = "";
             txtMsgGroup.Text = "";
            
         }                            
        
    }
    protected void btnIndSend_Click(object sender, EventArgs e)
    {
        btnIndRst.Text = "Cancel";

        //Preceeding notifiation image shows
        ImgInd.Visible = true;
        //Show status 
        lblIndStatus.Visible = true;
        //Create variables
        string IndStdNo;
        string IndSender;
        string IndMsg;
        //Get student no from dropdown list
        IndStdNo = txtStdPrntNo.Text;
        //Get sender details from text field
        IndSender = txt_Ind_Sender.Text;
        //Get meeesage from text field
        IndMsg = txt_Ind_Msg.Text.Trim();
        //save mobile # in to session
        Session["mobileNo"] = IndStdNo;
        //string number = "94716233138";//Request.QueryString[""];
        //string message = "Gayan.. cheeers...!!! working properly";//Request.QueryString["message"];  

        //Create object from RoutoSMSTelecom 
        RoutoSMSTelecom routo = new RoutoSMSTelecom();
        //Set user name
        routo.SetUser("1175036");
        //Set password
        routo.SetPass("td389jvf");
        //Set receiver's mobile no 
        routo.SetNumber(IndStdNo);
        //Set sender's details
        routo.SetOwnNumber(IndSender);
        //Set message type
        routo.SetType("SMS");
        //Set the message
        routo.SetMessage(IndMsg);

        //Send message
        string header = routo.Send();
        //Check the header
        if (header == "error")
        {
            //change label attributes
            lblIndStatus.ForeColor = System.Drawing.Color.Red;
            lblIndStatus.Text = "Connectiing.... Internet Failure !";
            btnIndSend.Text = "Retry";
        }
        else
        {
            //HIde notification inage
            ImgInd.Visible = false;
            //Show message sent notification
            lblIndStatus.Text = "Message sent to +" + Session["mobileNo"];
            //clear data fields after sending the messages
            txtStdPrntNo.Text="";
            txt_Ind_Sender.Text = "";
            txt_Ind_Msg.Text = "";
            btnIndSend.Text = "Send";

        } 
    }
    
    protected void btnSendGrade_Click(object sender, EventArgs e)
    {
        btnGardeRst.Text = "Cancel";

        //Preceeding notifiation image shows
        ImgGrade.Visible = true;
        //Show status 
        lblGradeStatus.Visible = true;
        //Create variables
        string GradeStdNo;
        string GradeSender;
        string GradeMsg;
        //Get student no from dropdown list
        GradeStdNo = txtStdCount_grade.Text;
        //Get sender details from text field
        GradeSender = txt_Grade_sender.Text;
        //Get meeesage from text field
        GradeMsg = txt_Grade_Msg.Text.Trim();
        //save mobile # in to session
        Session["mobileNo"] = GradeStdNo;
        //string number = "94716233138";//Request.QueryString[""];
        //string message = "Gayan.. cheeers...!!! working properly";//Request.QueryString["message"];  

        //Create object from RoutoSMSTelecom 
        RoutoSMSTelecom routo = new RoutoSMSTelecom();
        //Set user name
        routo.SetUser("1175036");
        //Set password
        routo.SetPass("td389jvf");
        //Set receiver's mobile no 
        routo.SetNumber(GradeStdNo);
        //Set sender's details
        routo.SetOwnNumber(GradeSender);
        //Set message type
        routo.SetType("SMS");
        //Set the message
        routo.SetMessage(GradeMsg);

        //Send message
        string header = routo.Send();
        //Check the header
        if (header == "error")
        {
            //change label attributes
            lblGradeStatus.ForeColor = System.Drawing.Color.Red;
            lblGradeStatus.Text = "Connectiing.... Internet Failure !";
            btnSendGrade.Text = "Retry";
        }
        else
        {
            //HIde notification inage
            ImgGrade.Visible = false;
            //Show message sent notification
            lblGradeStatus.Text = "Message sent to +" + Session["mobileNo"];
            //clear data fields after sending the messages
            txtStdCount_grade.Text = "";
            txt_Grade_sender.Text = "";
            txt_Grade_Msg.Text = "";

        }
    }
    protected void btnClassSend_Click(object sender, EventArgs e)
    {
        btnClassRst.Text = "Cancel";

        //Preceeding notifiation image shows
        ImgClass.Visible = true;
        //Show status 
        lblClassStatus.Visible = true;
        //Create variables
        string ClassStdNo;
        string ClassSender;
        string ClassMsg;
        //Get student no from dropdown list
        ClassStdNo = txtStdCount_grade.Text;
        //Get sender details from text field
        ClassSender = txt_Grade_sender.Text;
        //Get meeesage from text field
        ClassMsg = txt_Grade_Msg.Text.Trim();
        //save mobile # in to session
        Session["mobileNo"] = ClassStdNo;
        //string number = "94716233138";//Request.QueryString[""];
        //string message = "Gayan.. cheeers...!!! working properly";//Request.QueryString["message"];  

        //Create object from RoutoSMSTelecom 
        RoutoSMSTelecom routo = new RoutoSMSTelecom();
        //Set user name
        routo.SetUser("1175036");
        //Set password
        routo.SetPass("td389jvf");
        //Set receiver's mobile no 
        routo.SetNumber(ClassStdNo);
        //Set sender's details
        routo.SetOwnNumber(ClassSender);
        //Set message type
        routo.SetType("SMS");
        //Set the message
        routo.SetMessage(ClassMsg);

        //Send message
        string header = routo.Send();
        //Check the header
        if (header == "error")
        {
            //change label attributes
            lblClassStatus.ForeColor = System.Drawing.Color.Red;
            lblClassStatus.Text = "Connectiing.... Internet Failure !";
            btnClassSend.Text = "Retry";
        }
        else
        {
            //HIde notification inage
            ImgClass.Visible = false;
            //Show message sent notification
            lblClassStatus.Text = "Message sent to +" + Session["mobileNo"];
            //clear data fields after sending the messages
            txtCnt_Class.Text = "";
            txt_Class_sender.Text = "";
            txt_Class_Msg.Text = "";

        }
    }
    protected void BtnRstGrp_Click(object sender, EventArgs e)
    {
        //clear data fields 
        DrpdwnStdList.ClearSelection();
        txtSenderGrp.Text = "";
        txtMsgGroup.Text = "";
        ImgProcessGrp.Visible = false;
        lblStstusGrp.Visible = false;
        lblGrpStd.Visible = false;
        DrpDwnGroupStd.Visible = false;
        lblGrpClas.Visible = false;
        DrpDwnGroupCla.Visible = false;
        btnSendGrp.Text = "Send";
        BtnRstGrp.Text = "Reset";
    }
    
    protected void DrpDwnIndStd_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtStdPrntNo.Text = DrpDwnIndStd.SelectedItem.ToString();

        if (DrpDwnIndStd.SelectedIndex != -1)
        {
            OdbcDataAdapter adpAdNoList = DB_Connect.ExecuteQuery("SELECT S.`FMOBILE_NO` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + DrpDwnIndGrade.SelectedIndex + "' AND S.NAME_INITIALS='" + DrpDwnIndStd.SelectedValue + "'AND SC.CLASS_CODE = '" + DrpDwnIndClass.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpAdNoList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsAdNoList = new DataSet();
            adpAdNoList.Fill(dsAdNoList);
            txtStdPrntNo.Text = dsAdNoList.Tables[0].Rows[0][0].ToString();
            dsAdNoList.Dispose();
        }
    }
    
    protected void btnIndRst_Click(object sender, EventArgs e)
    {
        btnIndRst.Text = "Reset";
        btnIndSend.Text = "Send";
        txtStdPrntNo.Text = "";
        txt_Ind_Sender.Text = "";
        txt_Ind_Msg.Text = "";
        ImgInd.Visible = false;
        lblIndStatus.Visible = false;
        DrpDwnIndStd.Visible = false;
        lblIndstdID.Visible = false;
        DrpDwnIndClass.Visible = false;
        lblIndClass.Visible = false;
    }
    protected void DrpDwnIndGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        //If no Grade is Selected.
        if (DrpDwnIndGrade.SelectedIndex != -1)
        {
            DrpDwnIndStd.Visible = false;
            lblIndstdID.Visible = false;
            DrpDwnIndClass.Visible = true;
            lblIndClass.Visible = true;

            //Clear the excisting Items
            DrpDwnIndClass.Items.Clear();
            //Clear the excisting Items
            DrpDwnIndClass.Items.Add(new ListItem("Select Class", "Empty"));
            //Execute Query and 
            OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT DISTINCT CLASS_CODE FROM student_class WHERE SC_GRADE='" + DrpDwnIndGrade.SelectedValue + "'");
            adpClassList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsClassList = new DataSet();
            adpClassList.Fill(dsClassList);
            if (dsClassList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstClassList = new ListItem();
                    // or your index which is correct in your dataset
                    lstClassList.Value = dsClassList.Tables[0].Rows[i][0].ToString();
                    // or your index which is correct in your dataset
                    lstClassList.Text = dsClassList.Tables[0].Rows[i][0].ToString();
                    DrpDwnIndClass.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();

        }


        
    }
    protected void DrpDwnIndClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        //If no Grade is Selected.
        if (DrpDwnIndClass.SelectedIndex != -1)
        {
            DrpDwnIndStd.Visible = true;
            lblIndstdID.Visible = true;

            DrpDwnIndStd.Items.Clear();
            DrpDwnIndStd.Items.Add(new ListItem("Select Student", "empty"));
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT `NAME_INITIALS` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + DrpDwnIndGrade.SelectedIndex + "' AND SC.CLASS_CODE = '" + DrpDwnIndClass.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstNameList = new ListItem();
                    // or your index which is correct in your dataset
                    lstNameList.Value = dsNameList.Tables[0].Rows[i][0].ToString();
                    // or your index which is correct in your dataset               
                    lstNameList.Text = dsNameList.Tables[0].Rows[i][0].ToString();
                    DrpDwnIndStd.Items.Add(lstNameList);
                }
            }
            dsNameList.Dispose();
        }
    }
    
    protected void btnGardeRst_Click(object sender, EventArgs e)
    {
        txtStdCount_grade.Text = "";
        txt_Grade_sender.Text = "";
        txt_Grade_Msg.Text = "";
        btnGardeRst.Text = "Reset";
        btnSendGrade.Text = "Send";
        lblGradeStatus.Visible = false;
        ImgGrade.Visible = false;
    }

   
    protected void DrpDwnGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtStdCount_grade.Text = DrpDwnGrade.SelectedItem.ToString();
    }
   
    protected void DrpDwnGroupGrade_SelectedIndexChanged1(object sender, EventArgs e)
    {
        

        //If no Grade is Selected.
        if (DrpDwnGroupGrade.SelectedIndex != -1)
        {
            lblGrpStd.Visible = false;
            DrpDwnGroupStd.Visible = false;
            lblGrpClas.Visible = true;
            DrpDwnGroupCla.Visible = true;

            //Clear the excisting Items
            DrpDwnGroupCla.Items.Clear();
            //Clear the excisting Items
            DrpDwnGroupCla.Items.Add(new ListItem("Select Class", "Empty"));
            //Execute Query and 
            OdbcDataAdapter adpClassList = DB_Connect.ExecuteQuery("SELECT DISTINCT CLASS_CODE FROM student_class WHERE SC_GRADE='" + DrpDwnGroupGrade.SelectedValue + "'");
            adpClassList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsClassList = new DataSet();
            adpClassList.Fill(dsClassList);
            if (dsClassList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsClassList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstClassList = new ListItem();
                    // or your index which is correct in your dataset
                    lstClassList.Value = dsClassList.Tables[0].Rows[i][0].ToString();
                    // or your index which is correct in your dataset
                    lstClassList.Text = dsClassList.Tables[0].Rows[i][0].ToString();
                    DrpDwnGroupCla.Items.Add(lstClassList);
                }
            }
            dsClassList.Dispose();

        }
    }
    protected void DrpDwnGroupClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        //If no Grade is Selected.
        if (DrpDwnClassClass.SelectedIndex != -1)
        {
            lblGrpStd.Visible = true;
            DrpDwnGroupStd.Visible = true;

            DrpDwnGroupStd.Items.Clear();
            DrpDwnGroupStd.Items.Add(new ListItem("Select Student", "empty"));
            OdbcDataAdapter adpNameList = DB_Connect.ExecuteQuery("SELECT `NAME_INITIALS` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + DrpDwnGroupGrade.SelectedIndex + "' AND SC.CLASS_CODE = '" + DrpDwnClassClass.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpNameList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsNameList = new DataSet();
            adpNameList.Fill(dsNameList);
            if (dsNameList.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsNameList.Tables[0].Rows.Count; i++)
                {
                    ListItem lstNameList = new ListItem();
                    // or your index which is correct in your dataset
                    lstNameList.Value = dsNameList.Tables[0].Rows[i][0].ToString();
                    // or your index which is correct in your dataset               
                    lstNameList.Text = dsNameList.Tables[0].Rows[i][0].ToString();
                    DrpDwnGroupStd.Items.Add(lstNameList);
                }
            }
            dsNameList.Dispose();
        }
    }
    protected void DrpDwnClassGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblClassClass.Visible = true;
        DrpDwnClassClass.Visible = true;
    }
    protected void btnClassRst_Click(object sender, EventArgs e)
    {
        lblClassClass.Visible = false;
        DrpDwnClassClass.Visible = false;
        txtCnt_Class.Text = "";
        txt_Class_sender.Text = "";
        txt_Class_Msg.Text = "";
        ImgClass.Visible = false;
        lblClassStatus.Visible = false;
        btnClassRst.Text = "Reset";
        btnClassSend.Text = "Send";
    }

    protected void btnSendAllRst_Click(object sender, EventArgs e)
    {
        txt_All_Sender.Text = "";
        txt_all_Msg.Text = "";
        txtSchlCount.Text = "";
        ImgAll.Visible = false;
        lblAllStatu.Visible = false;
        btnAllSend.Text = "Send";
        btnSendAllRst.Text = "Reset";
    }
    protected void btnAllSend_Click(object sender, EventArgs e)
    {
        btnSendAllRst.Text = "Cancel";

        //Preceeding notifiation image shows
        ImgAll.Visible = true;
        //Show status 
        lblAllStatu.Visible = true;
        //Create varndStatusiables
        string ALLStdNo = "94716233138";
        string ALLSender;
        string ALLMsg;
        //Get student no from dropdown list
        ALLStdNo = txtStdPrntNo.Text;
        //Get sender details from text field
        ALLSender = txt_Ind_Sender.Text;
        //Get meeesage from text field
        ALLMsg = txt_Ind_Msg.Text.Trim();
        //save mobile # in to session
        Session["mobileNo"] = ALLStdNo;
        //string number = "94716233138";//Request.QueryString[""];
        //string message = "Gayan.. cheeers...!!! working properly";//Request.QueryString["message"];  

        //Create object from RoutoSMSTelecom 
        RoutoSMSTelecom routo = new RoutoSMSTelecom();
        //Set user name
        routo.SetUser("1175036");
        //Set password
        routo.SetPass("td389jvf");
        //Set receiver's mobile no 
        routo.SetNumber(ALLStdNo);
        //Set sender's details
        routo.SetOwnNumber(ALLSender);
        //Set message type
        routo.SetType("SMS");
        //Set the message
        routo.SetMessage(ALLMsg);

        //Send message
        string header = routo.Send();
        //Check the header
        if (header == "error")
        {
            //change label attributes
            lblAllStatu.ForeColor = System.Drawing.Color.Red;
            lblAllStatu.Text = "Connectiing.... Internet Failure !";
            btnAllSend.Text = "Retry";
        }
        else
        {
            //HIde notification inage
            ImgInd.Visible = false;
            //Show message sent notification
            lblAllStatu.Text = "Message sent to +" + Session["mobileNo"];
            //clear data fields after sending the messages
            txtSchlCount.Text = "";
            txt_All_Sender.Text = "";
            txt_all_Msg.Text = "";

        }
    }
    protected void BtnAddGrp_Click(object sender, EventArgs e)
    {
        if (DrpDwnGroupStd.SelectedIndex != -1)
        {
            OdbcDataAdapter adpAdNoList = DB_Connect.ExecuteQuery("SELECT S.`FMOBILE_NO` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + DrpDwnGroupGrade.SelectedIndex + "' AND S.NAME_INITIALS='" + DrpDwnGroupStd.SelectedValue + "'AND SC.CLASS_CODE = '" + DrpDwnGroupCla.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
            adpAdNoList.SelectCommand.CommandType = CommandType.Text;
            DataSet dsAdNoList = new DataSet();
            adpAdNoList.Fill(dsAdNoList);
            string MobNo = dsAdNoList.Tables[0].Rows[0][0].ToString();
            lblMobNo.Text = MobNo.ToString();
            DrpdwnStdList.Items.Add(new ListItem(MobNo, MobNo));
            Label28.Text = MobNo+" is added.";
            dsAdNoList.Dispose();
        }
    }
    protected void DrpDwnGroupStd_SelectedIndexChanged(object sender, EventArgs e)
    {
        OdbcDataAdapter adpAdNoList = DB_Connect.ExecuteQuery("SELECT S.`FMOBILE_NO` FROM `student_mast` S, `student_class` SC WHERE SC.SC_YEAR = YEAR(CURDATE()) AND SC.SC_GRADE='" + DrpDwnGroupGrade.SelectedIndex + "' AND S.NAME_INITIALS='" + DrpDwnGroupStd.SelectedValue + "'AND SC.CLASS_CODE = '" + DrpDwnGroupCla.SelectedValue + "' AND SC.ADMISSION_NO = S.ADMISSION_NO");
        adpAdNoList.SelectCommand.CommandType = CommandType.Text;
        DataSet dsAdNoList = new DataSet();
        adpAdNoList.Fill(dsAdNoList);
        string MobNo = dsAdNoList.Tables[0].Rows[0][0].ToString();
        lblMobNo.Text = "No : "+MobNo.ToString();
        dsAdNoList.Dispose();
    }
}

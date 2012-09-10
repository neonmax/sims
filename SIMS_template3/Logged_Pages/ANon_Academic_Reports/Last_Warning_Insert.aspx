<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Last_Warning_Insert.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Add to Photo Gallery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../styles.css" rel="stylesheet" type="text/css" />
    <link href="../fronts.css" rel="stylesheet" type="text/css" />
    <link href="../../Notifications/CSS/Style.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../../lib/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <script src="../../lib/DeepASPImpromptuCalling.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="wrap">
        <div id="header">
            <div id="logo2">
                <br />
                <br />
                <br />
                <asp:Label ID="Text1" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
                    Font-Size="Small" ForeColor="White"></asp:Label>
            </div>
            <div id="menu">
                <ul>
                    <li><a href="../Home.aspx">Home</a></li>
                    <li><a href="../AboutUs.aspx" class="active">About Us</a></li>
                    <li><a href="../ContactUs.aspx">Contact Us</a></li>
                </ul>
            </div>
        </div>

                <div class="ReportBody">
                    <div class="ReportHeader">
                        Student Warning
                    </div>
                    <div class="ReportDesc">
                        Add New Student Warning Record
                        
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <div class="FormBackgroundAddAppointment">
                
                    <div class="paraSpace">
                    </div>
                      <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" class="RLable" Text="Grade :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_grade" class="Rtxt" runat="server" CssClass="FormTxtBox"
                                onselectedindexchanged="ddl_grade_SelectedIndexChanged" Height="20px" Width="185px"
                                AutoPostBack="True" >
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label2" runat="server" class="RLable" Text="Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddl_class" 
                                runat="server" Height="20px" Width="185px"
                                AutoPostBack="true" 
                                onselectedindexchanged="ddl_class_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label14" runat="server" class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                           <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddl_student" 
                                runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" 
                                onselectedindexchanged="ddl_student_SelectedIndexChanged">
                                </asp:DropDownList>
                                
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    
                                        <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            
                        </div>
                        <div class="fieldsElementCell">
<asp:Label ID="lbl_grade_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">
 <asp:Label ID="lbl_class_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">
<asp:Label ID="lbl_student_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                
                        </div>
                    </div>
                    
                                                <div class="paraSpace">
                    </div>
                            <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label5" runat="server" class="RLable" Text="Warn Type :
                            "></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddl_type" 
                                runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" onselectedindexchanged="ddl_wtype_SelectedIndexChanged" 
                              >
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label6" runat="server" class="RLable" Text="Warn Level :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddl_level" 
                                runat="server" Height="20px" Width="185px"
                               
                                AutoPostBack="true" 
                                onselectedindexchanged="ddl_level_SelectedIndexChanged">
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label7" runat="server" class="RLable" Text="Warn Date :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">

                          <asp:TextBox ID="txt_date" runat="server" Class="FormTxtBox " Font-Names="Arial" Width="160px"></asp:TextBox>  
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" PopupButtonID="ibtn_warning">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="ibtn_warning" runat="server" Height="16px" ImageUrl="~/images/Calendar_scheduleHS.png"
                                Width="16px" />    
                        </div>
                    </div>

                    <div class="paraSpace">
                    </div>
                    
                                                            <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            
                        </div>
                        <div class="fieldsElementCell">
<asp:Label ID="lbl_wtype_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">
<asp:Label ID="lbl_level_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">
<asp:Label ID="Label9"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                
                        </div>
                    </div>

                    <div class="paraSpace">
                    </div>
 

                       <div class="field_3_Row162auto">
                        <div class="fieldsCaptionCell162auto">
                            <asp:Label runat="server" class="RLable" Text="Note :" ID="txt_des"></asp:Label>
                        </div>
                      
                            <asp:TextBox ID="txt_description" runat="server" Height="97px" TextMode="MultiLine"  
                            CssClass="FormTxtBox " Width="669px"></asp:TextBox>
                        
                           &nbsp;&nbsp;
                        <br />
                    </div>
                     <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btn_insert" runat="server"  Text="Insert"
                                Width="142px" Height="30px" CssClass="buttonText" 
                                onclick="btn_insert_Click" ValidationGroup="submit" 
                                />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btn_Reset" runat="server" 
                                Text="Reset" Width="143px" CssClass="buttonText" 
                                Height="30px"  onclick="btn_Reset_Click"  />
                        </div>
                    </div>
                </div>
        </ContentTemplate>
            <Triggers>
           
                <asp:AsyncPostBackTrigger ControlID="btn_insert" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ddl_grade" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddl_class" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddl_student" 
                    EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
                
                
               

                    
                                     
                <div class="FormFooter">
                </div>

    </div>
 
</asp:Content>


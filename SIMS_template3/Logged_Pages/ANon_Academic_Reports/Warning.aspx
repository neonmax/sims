<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Warning.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="Student Warning" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
                                                <asp:ToolkitScriptManager ID="tsm_events" runat="server">
                            </asp:ToolkitScriptManager>
    <div id="wrap">
    
    
        <div id="header">
            <div id="logo2">
                <br />
                <br />
                <br />
                <asp:Label ID="SessionTxt" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
                    Font-Size="Medium" ForeColor="White"></asp:Label>
                <br />
                <asp:LinkButton ID="LnkLogout" runat="server" ForeColor="Yellow">Logout</asp:LinkButton>
            </div>
            <div id="menu">
                <ul>
                    <li><a href="../Home.aspx">Home</a></li>
                    <li><a href="../AboutUs.aspx" class="active">About Us</a></li>
                    <li><a href="../ContactUs.aspx">Contact Us</a></li>
                </ul>
            </div>
             
              <div class="ReportHeader">
                        Student Warnings
                    </div>
                    <div class="ReportDesc">
                        Add new student Warning
                    </div>
        </div>
        <div class="body">
            <div class="form">
                
                <div class="ParaMiddleH">
                    <div class="paraSpace">
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                      
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label2" runat="server" class="RLable" Text="Grade :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_grade" runat="server" class="RTxt" 
                                AutoPostBack="True" Width="180px"
                                OnSelectedIndexChanged="ddl_grade_SelectedIndexChanged" 
                                CssClass="FormTxtBox" Height="20px">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label3" runat="server" class="RLable" Text="Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_class" class="RTxt" runat="server" 
                                AutoPostBack="True" Width="180px"
                                OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" 
                                CssClass="FormTxtBox" Height="20px">
                                <asp:ListItem>Select Class</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label4" runat="server" class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_student" class="RTxt" runat="server" 
                                AutoPostBack="True" Width="180px"
                                OnSelectedIndexChanged="ddl_student_SelectedIndexChanged" 
                                CssClass="FormTxtBox" Height="20px">
                                <asp:ListItem>Select Student</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                         <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" class="RLable" Text="Admission No :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Label ID="lbl_admissionno_result" class="RLable" runat="server" Width="180px"></asp:Label>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                         <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label5" runat="server" class="RLable" Text="Warning Type :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_type" class="RTxt" runat="server" Width="180px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" 
                                CssClass="FormTxtBox" Height="20px">
                                <asp:ListItem>Select Warning Type</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label6" runat="server" class="RLable" Text="Warn Level :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_level"  class="RTxt" runat="server" 
                                AutoPostBack="True" Width="180px"
                                OnSelectedIndexChanged="ddl_level_SelectedIndexChanged" 
                                CssClass="FormTxtBox" Height="20px">
                                <asp:ListItem>Select Warning Level</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label7" runat="server" class="RLable" Text="Inform Parent:"></asp:Label>
                        </div>
                        <asp:DropDownList ID="ddl_inform"  class="RTxt" runat="server" 
                            AutoPostBack="True" Width="180px" CssClass="FormTxtBox" Height="20px" 
                            onselectedindexchanged="ddl_inform_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="paraSpace">
                    </div>
                         <div class="paraSpace">
                    </div>
                    <div class="field_3_Row162">
                        <div class="fieldsCaptionCell162">
                            <asp:Label ID="Label8" runat="server" class="RLable" Text="Warned  Date :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell162">
                            <asp:TextBox ID="txt_date" runat="server" Class="FormTxtBox " Font-Names="Arial" Width="160px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_date" runat="server" TargetControlID="txt_date"
                                WatermarkText="Select Date">
                            </asp:TextBoxWatermarkExtender>
                            <asp:CalendarExtender ID="ce_warning" runat="server" TargetControlID="txt_date" PopupButtonID="ibtn_warning">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="ibtn_warning" runat="server" Height="16px" ImageUrl="~/images/Calendar_scheduleHS.png"
                                Width="16px" />
                            <asp:RequiredFieldValidator ID="RFV_date" runat="server" 
                                ControlToValidate="txt_date" ErrorMessage="Select a Date" Font-Names="Arial" 
                                Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell162">
                            <asp:Label ID="Label12" runat="server" class="RLable" Text="Description :" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="fieldsElementCell162">
                            <asp:TextBox ID="txt_description" runat="server" Class="FormTxtBox " Height="160px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="wme_des" runat="server" TargetControlID="txt_description" WatermarkText="Add warning Details Here">
                    </asp:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RFV_description" runat="server" 
                                ControlToValidate="txt_description" ErrorMessage="Insert Warning Description" 
                                Font-Names="Arial" Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell162">
                        </div>
                    </div>
                    

                    
                    <div class="paraSpace">
                    </div>
                                        <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
  
                                                        <asp:Button ID="btn_insert" runat="server" 
                        Height="30px" Text="Insert" Width="142px" onclick="btn_insert_Click" 
                                CssClass="buttonText" />
                        </div>
                        <div class="fieldsCaptionCell">
                                              <asp:Button ID="btn_clear" runat="server" 
                        Height="30px" Text="Clear" Width="142px" onclick="btn_clear_Click" 
                                CssClass="buttonText" />

                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                    </div>
                    
                    </ContentTemplate>
                    
                    
                    </asp:UpdatePanel>
                    
                  
                    
                    

                    <div class="paraSpace">
                    </div>
                </div>
                <div class="ParaBottomH">
                </div>
                <br />
            </div>
        </div>
        <div class="con_bot">
        </div>
        <div id="footer">
            <p>
                All rights reserved                 <!-- Please DO NOT remove the following notice -->
                <p>
                    Design by SLIIT SEWD 02</p>
                <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

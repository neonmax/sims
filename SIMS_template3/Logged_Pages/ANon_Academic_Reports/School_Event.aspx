<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="School_Event.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="School Event" %>

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
        </div>
        <div class="body">
            <div class="form">
                <div id="menu">
                    <ul>
                        <li><a href="../Home.aspx">Home</a></li>
                        <li><a href="../AboutUs.aspx" class="active">About Us</a></li>
                        <li><a href="../ContactUs.aspx">Contact Us</a></li>
                    </ul>
                </div>
                <div class="ReportHeader">
                    School Event's Details
                </div>
                <div class="ReportDesc">
                    School Event Details
                </div>
                <div class="ParaMiddleH">
                    <div class="paraSpace">
                    </div>
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                     <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label2" runat="server" class="RLable" Text="Event ID"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txt_id" runat="server" Class="FormTxtBox" Width="180px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_id" runat="server" TargetControlID="txt_id"
                                WatermarkText="Add ID Here">
                            </asp:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RVF_id" runat="server" 
                                ControlToValidate="txt_id" ErrorMessage="Insert Event ID" Font-Names="Arial" 
                                Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label3" runat="server" class="RLable" Text="Main Category"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_main" runat="server" Width="180px" class="RTxt" AutoPostBack="True"
                                OnSelectedIndexChanged="ddl_main_SelectedIndexChanged" 
                                CssClass="FormTxtBox" Height="20px">
                                <asp:ListItem>Select Main Catagory</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label4" runat="server" class="RLable" Text="Sub Category"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_sub" runat="server" class="RTxt" Width="180px" 
                                AutoPostBack="True" CssClass="FormTxtBox" Height="20px">
                                <asp:ListItem>Select Sub Catagory</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label5" runat="server" class="RLable" Text="Event Name"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txt_name" runat="server" Class="FormTxtBox" Width="180px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_name" runat="server" TargetControlID="txt_name"
                                WatermarkText="Add name Here">
                            </asp:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RFV_date" runat="server" 
                                ControlToValidate="txt_name" ErrorMessage="Insert Event Name" 
                                Font-Names="Arial" Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label6" runat="server" class="RLable" Text="Organizer"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txt_org" runat="server" Class="FormTxtBox" Width="180px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_organizer" runat="server" TargetControlID="txt_org"
                                WatermarkText="Add organizer Here">
                            </asp:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RFV_organizer" runat="server" 
                                ControlToValidate="txt_org" ErrorMessage="Insert Organizer" Font-Names="Arial" 
                                Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label8" runat="server" class="RLable" Text="Held Date"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txt_date" runat="server" Class="FormTxtBox" Width="160px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_date" runat="server" TargetControlID="txt_date"
                                WatermarkText="Select date Here">
                            </asp:TextBoxWatermarkExtender>
                            <asp:CalendarExtender ID="ce_events" runat="server" TargetControlID="txt_date" PopupButtonID="ibtn_events"
                                Animated="False">
                            </asp:CalendarExtender>
                            <asp:ImageButton ID="ibtn_events" runat="server" Height="16px" Width="16px" ImageUrl="../../images/Calendar_scheduleHS.png" />
                            <asp:RequiredFieldValidator ID="RFV_helddate" runat="server" 
                                ControlToValidate="txt_date" ErrorMessage="Select Date" Font-Names="Arial" 
                                Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row162">
                        <div class="fieldsCaptionCell162">
                            <asp:Label ID="Label12" runat="server" class="RLable" Text="Description"></asp:Label>
                        </div>
                        <div class="fieldsElementCell162event">
                            <asp:TextBox ID="txt_des" runat="server" Class="FormTxtBox" Height="160px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_des" runat="server" TargetControlID="txt_des"
                                WatermarkText="Add event description Here">
                            </asp:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RFV_descritin" runat="server" 
                                ControlToValidate="txt_des" ErrorMessage="Insert Description" 
                                Font-Names="Arial" Font-Size="Small"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell162"><asp:Label ID="Label13" runat="server" Text="Faced Issues"></asp:Label>
                        </div>
                        <div class="fieldsElementCell162">
                            
                            <asp:TextBox ID="txt_issue" runat="server" Class="FormTxtBox" Height="160px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_isse" runat="server" TargetControlID="txt_issue"
                                WatermarkText="Add event issues Here">
                            </asp:TextBoxWatermarkExtender>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    
     
                    
                    
                    
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">

                        </div>
                        <div class="fieldsElementCell">
                                                                                        <asp:Button ID="btn_insert" runat="server" Font-Names="Arial" Font-Size="Medium"
                                Height="30px" Text="Insert" Width="142px" OnClick="btn_insert_Click" 
                                CssClass="buttonText" />  

                        </div>
                        <div class="fieldsCaptionCell">
                                                    <asp:Button ID="btn_clear" runat="server" Font-Names="Arial" Font-Size="Medium" Height="30px"
                                Text="Clear" Width="142px" OnClick="btn_clear_Click" 
                                CssClass="buttonText" />
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>

                    </div>
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
                All rights reserved          <!-- Please DO NOT remove the following notice -->
                <p>
                    Design by SLIIT SEWD 02</p>
                <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

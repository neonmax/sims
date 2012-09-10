<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="NewNotifications.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Send Notifications" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Notifications/CSS/Style.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../../lib/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <script src="../../lib/DeepASPImpromptuCalling.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
        <asp:ScriptManager ID="HmScptMng" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="HmUpPnl" runat="server">
            <ContentTemplate>
                <div class="ReportBody">
                    <div class="ReportHeader">
                        Notifications
                    </div>
                    <div class="ReportDesc">
                        Send Notifications to Parents
                    </div>
                    <div id="prev">
                        <asp:Image ID="Image1" runat="server" Height="381px" ImageUrl="~/images/direct-mail.jpg"
                            Width="99%" />
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" class="RLable" Text="Category :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" ID="ddlCategoryList" runat="server" Height="20px"
                                CssClass="FormTxtBox " Width="185px" OnSelectedIndexChanged="ddlCategoryList_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="empty">Select Category</asp:ListItem>
                                <asp:ListItem Value="grade">By Grade </asp:ListItem>
                                <asp:ListItem Value="class">By Class </asp:ListItem>
                                <asp:ListItem Value="student">By Student </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label class="RLable" ID="lblGrade" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" ID="ddlGrade" runat="server" Height="20px" Width="185px"
                                CssClass="FormTxtBox " AutoPostBack="true" Visible="False" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label class="RLable" ID="lblCategory" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" ID="ddlCategory" runat="server" Height="20px" Width="185px"
                                CssClass="FormTxtBox " AutoPostBack="true" Visible="False" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label class="RLable" ID="lblStudent" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" ID="ddlStudent" runat="server" Height="20px" Width="185px"
                                CssClass="FormTxtBox " AutoPostBack="true" Visible="False" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row162auto">
                        <div class="fieldsCaptionCell162auto">
                            <asp:Label runat="server" class="RLable" Text="To :" ID="Label3"></asp:Label>
                        </div>
                      
                            <asp:TextBox ID="txtTo" runat="server" Height="80px" TextMode="MultiLine"  
                            CssClass="FormTxtBox " Width="669px"></asp:TextBox>
                        
                        &nbsp;&nbsp;
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtTo" ErrorMessage="Please specify at least one recipient." 
                            ValidationGroup="send"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label18" runat="server" class="RLable" Text="Subject :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtSubject" runat="server"  Width="669px" 
                                CssClass="FormTxtBox "></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row162app">
                        <div class="fieldsCaptionCell162app">
                            <asp:Label ID="Label15" runat="server" class="RLable" Text="Message :"></asp:Label>
                        </div>
                       
                            <asp:TextBox ID="txtMessage" Class="FormTxtBox " runat="server" Height="160px" 
                                TextMode="MultiLine" Width="669px"></asp:TextBox>
                        
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnSend" runat="server" ValidationGroup="send" OnClick="btnSend_Click"
                                Text="Send" AutoPostBack="true" Width="143px" CssClass="buttonText" Height="30px" />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnReset" runat="server" CauseValidation="False" OnClick="btnReset_Click"
                                Text="Reset" AutoPostBack="true" Width="143px" CssClass="buttonText" Height="30px" />
                        </div>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

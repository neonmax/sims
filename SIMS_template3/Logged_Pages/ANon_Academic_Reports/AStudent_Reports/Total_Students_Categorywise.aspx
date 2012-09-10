<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true"
    CodeFile="Total_Students_Categorywise.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Categorized Total Number of Student" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="ReportBody">
                    <div class="ReportHeader">
                        Report Generator
                    </div>
                    <div class="ReportDesc">
                        Student Best Performance Report
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <div class="RepOptions">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Category :" ID="lblCategoryList"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddlCategoryList" runat="server" Height="20px"
                                    Width="185px" OnSelectedIndexChanged="ddlCategoryList_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="empty">Select Category</asp:ListItem>
                                    <asp:ListItem Value="grade">By Grade </asp:ListItem>
                                    <asp:ListItem Value="class">By Class </asp:ListItem>
                                    <asp:ListItem Value="subject">By Subject </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" ID="lblGrade" runat="server" Visible="False"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddlGrade" runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" Visible="False" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" ID="lblCategory" runat="server" Visible="False"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddlCategory" runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" Visible="False" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="RepPanel">
                        <CR:CrystalReportViewer class="RepPanel" ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                            BackColor="White" ReuseParameterValuesOnRefresh="True" BestFitPage="True" 
                            onnavigate="crvReportViewer_Navigate" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="footer">
            <p>
                All rights reserved
            </p>
            <!-- Please DO NOT remove the following notice -->
            <p>
                Design by SLIIT SEWD 02</p>
            <!-- end of copyright notice-->
        </div>
         </div>
</asp:Content>
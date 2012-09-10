<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true"
    CodeFile="GovExamRstSheet.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Government Examination Result Sheet" %>

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
                <br />
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
                        Report Generator
                    </div>
                    <div class="ReportDesc">
                        Student Best Performance Report
                    </div>
                    <div class="RepOptionsFixed40">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Examination :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddlExamination" runat="server" Height="30px" Width="185px"
                                    OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="empty">Select Examination</asp:ListItem>
                                    <asp:ListItem Value="al">G.C.E. A/L Examination</asp:ListItem>
                                    <asp:ListItem Value="ol">G.C.E. O/L Examination</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Year :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddlYear" runat="server" Height="30px" Width="185px"
                                    OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0">Select Year</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="2001">2001</asp:ListItem>
                                    <asp:ListItem Value="2002">2002</asp:ListItem>
                                    <asp:ListItem Value="2003">2003</asp:ListItem>
                                    <asp:ListItem Value="2004">2004</asp:ListItem>
                                    <asp:ListItem Value="2005">2005</asp:ListItem>
                                    <asp:ListItem Value="2006">2006</asp:ListItem>
                                    <asp:ListItem Value="2007">2007</asp:ListItem>
                                    <asp:ListItem Value="2008">2008</asp:ListItem>
                                    <asp:ListItem Value="2009">2009</asp:ListItem>
                                    <asp:ListItem Value="2010">2010</asp:ListItem>
                                    <asp:ListItem Value="2011">2011</asp:ListItem>
                                    <asp:ListItem Value="2012">2012</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <br />
                    <div class="RepPanel">
                        <CR:CrystalReportViewer class="RepPanel" ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                            BackColor="White" />
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

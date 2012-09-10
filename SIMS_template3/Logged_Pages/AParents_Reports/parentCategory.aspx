﻿<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true"
    CodeFile="parentCategory.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="General Academic" %>

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
                <asp:Label ID="txtUser" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
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
                        Report Generator
                    </div>
                    <div class="ReportDesc">
                        Parents Category Report (According to job</div>
                    <div class="RepOptions">
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
        <%--
        
        
        
        
        <div class="body">
            <div class="headline_holder">
                <asp:Label class="headline" runat="server" Text="Label">Report Generator  </asp:Label>
            </div>
            <div class="report_type">
                General Academic Performance Report
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <div class="form">
                <br />
                <div class="form_fields">
                    <asp:Label class="form_label" runat="server" Text="Grade :"></asp:Label>
                    <asp:DropDownList ID="ddlGrade" runat="server" Height="20px" Width="190px" 
                        AutoPostBack="true" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Grade</asp:ListItem>
                        <asp:ListItem Value="1">Grade 1</asp:ListItem>
                        <asp:ListItem Value="2">Grade 2</asp:ListItem>
                        <asp:ListItem Value="3">Grade 3</asp:ListItem>
                        <asp:ListItem Value="4">Grade 4</asp:ListItem>
                        <asp:ListItem Value="5">Grade 5</asp:ListItem>
                        <asp:ListItem Value="6">Grade 6</asp:ListItem>
                        <asp:ListItem Value="7">Grade 7</asp:ListItem>
                        <asp:ListItem Value="8">Grade 8</asp:ListItem>
                        <asp:ListItem Value="9">Grade 9</asp:ListItem>
                        <asp:ListItem Value="10">Grade 10</asp:ListItem>
                        <asp:ListItem Value="11">Grade 11</asp:ListItem>
                        <asp:ListItem Value="12">Grade 12</asp:ListItem>
                        <asp:ListItem Value="13">Grade 13</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form_fields">
                    <asp:Label class="form_label" runat="server" Text="Class :"></asp:Label>
                    <asp:DropDownList ID="ddlClass" runat="server" Height="20px" Width="190px" 
                        AutoPostBack="true" onselectedindexchanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form_fields">
                    <asp:Label class="form_label" runat="server" Text="Student :"></asp:Label>
                    <asp:DropDownList ID="ddlStudentName" runat="server" Height="20px" Width="190px"
                        AutoPostBack="true" 
                        onselectedindexchanged="ddlStudentName_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form_fields">
                    <asp:Label class="form_label" runat="server" Text="Term :"></asp:Label>
                     <asp:DropDownList ID="ddlTerm" runat="server" Height="20px" Width="190px" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="0">Select Term</asp:ListItem>
                                <asp:ListItem Value="1">Term 1</asp:ListItem>
                                <asp:ListItem Value="2">Term 2</asp:ListItem>
                                <asp:ListItem Value="3">Term 3</asp:ListItem>
                            </asp:DropDownList>
                </div>
                <br />
                <div class="GenBtnHalder">
                </div>
                <br />
                <div class="report">
                    <!--space for report -->
                    <br />
                    <CR:CrystalReportViewer ID="crvReportViewer" runat="server" AutoDataBind="true" DisplayGroupTree="False"
                        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                </div>
            </div>
        </div>
        <div class="con_bot">
        </div>--%>
        <div id="footer">
            <p>
                All rights reserved             </p>
            <!-- Please DO NOT remove the following notice -->
            <p>
                Design by SLIIT SEWD 02</p>
            <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

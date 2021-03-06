﻿<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true"
    CodeFile="BestPerformance.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Best Performance" %>

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
        <asp:ScriptManager ID="HmScptMng" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="HmUpPnl" runat="server">
            <ContentTemplate>
                <div class="ReportBody">
                    <div class="ReportHeader" id="lblError">
                        Report Generator
                    </div>
                    <div class="ReportDesc">
                        Examination Best Performance Report
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <div class="RepOptionsFixed40">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Examination :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddlExamination" runat="server" Height="20px" Width="185px">
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
                                <asp:DropDownList class="RTxt" ID="ddlYear" runat="server" Height="20px" Width="185px"
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
                        <asp:Button ID="btnPrint" runat="server" onclick="btnPrint_Click" 
                            Text="Print" />
                    </div>
                    <br />
                    <div class="RepPanel">
                        <CR:CrystalReportViewer class="RepPanel" ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                            EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
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
                
                    Best performance of the students<asp:Label ID="lblError" class="form_label" runat="server" ></asp:Label>
                       
                        </div>
                <div class="form">
                    <br />
                   <div class="form_fields">
                       <asp:Label class="form_label" runat="server" Text="Examination :"></asp:Label>
                       <asp:DropDownList ID="ddlExamination" runat="server" Height="20px" Width="190px">
                                <asp:ListItem Value="empty">Select Examination</asp:ListItem>
                                <asp:ListItem Value="al">G.C.E. A/L Examination</asp:ListItem>
                                <asp:ListItem Value="ol">G.C.E. O/L Examination</asp:ListItem>
                            </asp:DropDownList>
                   </div>
                   
                   <div class="form_fields">
                       <asp:Label ID="Label1" class="form_label" runat="server" Text="Year :"></asp:Label>
                      <asp:DropDownList ID="ddlYear" runat="server" Height="20px" Width="190px" 
                           onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
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
                   
                    <br />
                    <div>
                   
                    </div>
                    <br />
                    <div class="report"><!--space for report -->
                    
                        <br />
                        <CR:CrystalReportViewer ID="crvReportViewer" runat="server" 
                            AutoDataBind="true" DisplayGroupTree="False" 
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

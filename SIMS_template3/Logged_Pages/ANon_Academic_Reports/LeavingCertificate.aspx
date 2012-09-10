<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true"
    CodeFile="LeavingCertificate.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
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
                <asp:Label ID="Text12" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
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
                        Student&#39;s School Leaving Certificate
                    </div>
                    <div class="RepOptionsFixed40">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Leave Year :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddl_year" runat="server" Height="20px" Width="180px"
                                    AutoPostBack="true" 
                                    onselectedindexchanged="ddl_year_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Grade :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddl_grade" runat="server" Height="20px" Width="180px"
                                     AutoPostBack="true" 
                                    onselectedindexchanged="ddl_grade_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label class="RLable" runat="server" Text="Class :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddl_class" runat="server" Height="20px" Width="180px"
                                    AutoPostBack="true" 
                                    onselectedindexchanged="ddl_class_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    
                                        <div class="RepOptionsFixed40">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                
                            </div>
                            <div class="RepTxt">
                                                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_year_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                
                            </div>
                                      <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_grade_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                        </div>
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                
                            </div>
                            <div class="RepTxt">
                                                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_class_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                        <div class="RepOptionsFixed40">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                <asp:Label ID="Label1" class="RLable" runat="server" Text="Student :"></asp:Label>
                            </div>
                            <div class="RepTxt">
                                <asp:DropDownList class="RTxt" ID="ddl_student" runat="server" Height="20px" Width="180px"
                                    AutoPostBack="true" 
                                    onselectedindexchanged="ddl_student_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                        </div>


                    </div>
                       <div class="RepOptionsFixed40">
                        <div class="RepOptInstance">
                            <div class="RepLbl">
                                
                            </div>
                            <div class="RepTxt">
                                    <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_student_check" ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>


                    </div>
                    <br />
                    <div class="RepPanel">
                        <CR:CrystalReportViewer class="RepPanel" ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                            Height="400px" DisplayToolbar="False" ToolbarStyle-BackColor="#0066FF" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_class" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddl_grade" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddl_student" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddl_year" 
                    EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <div id="footer">
            <p>
                All rights reserved
            
            <!-- Please DO NOT remove the following notice -->
            <p>
                Design by SLIIT SEWD 02</p>
            <!-- end of copyright notice-->
        </div>
</asp:Content>

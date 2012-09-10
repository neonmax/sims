<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Last_Leaving_Certificate.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Add to Photo Gallery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
    <link href="../styles.css" rel="stylesheet" type="text/css" />

 
    
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

                <div class="ReportBody">
                    <div class="ReportHeader">
                        School Leaving Cerititicate
                    </div>
                    <div class="ReportDesc">
                        Generate Student&#39;s School Leaving Ceritificate
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">

                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel_leave" runat="server">
                    <ContentTemplate>
                                          <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" class="RLable" Text="Year :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddl_year" 
                                runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" 
                                onselectedindexchanged="ddl_year_SelectedIndexChanged" >           
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label2" runat="server" class="RLable" Text="Grade :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddl_grade" 
                                runat="server" Height="20px" Width="185px"
                     
                                AutoPostBack="true" 
                                onselectedindexchanged="ddl_Grade_SelectedIndexChanged">

                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label14" runat="server" class="RLable" Text="Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                           <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddl_class" 
                                runat="server" Height="20px" Width="185px"
                                   AutoPostBack="true" 
                                onselectedindexchanged="ddl_class_SelectedIndexChanged">
                              
                                </asp:DropDownList>
                                
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                                          <div class="FormRow">
                        <div class="fieldsCaptionCell">
                          
                        </div>
                        <div class="fieldsElementCell">
<asp:Label ID="lbl_year_check" runat="server" class="RLable" ForeColor="Red"></asp:Label>
                        </div>
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
                    </div>
                    <div class="paraSpace">
                    </div>

                      <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label3" runat="server" class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddl_student" 
                                runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" 
                                onselectedindexchanged="ddl_student_SelectedIndexChanged" >           
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">

                        </div>
                        <div class="fieldsCaptionCell">
                            
                        </div>
                        <div class="fieldsElementCell">

                                
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                                          <div class="FormRow">
                        <div class="fieldsCaptionCell">
                          
                        </div>
                        <div class="fieldsElementCell">
 <asp:Label ID="lbl_student_check" ForeColor="Red" class="RLable" runat="server"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">

                        </div>
                        <div class="fieldsCaptionCell">
                            
                        </div>
                        <div class="fieldsElementCell">

                                
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                          <div class="RepPanelauto">
                        <CR:CrystalReportViewer  ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                                  EnableParameterPrompt="False" DisplayToolbar="False" />
                    </div>
                     <div class="paraSpace">
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>



                </div>
                <div class="FormFooter">
                </div>

    </div>
</asp:Content>

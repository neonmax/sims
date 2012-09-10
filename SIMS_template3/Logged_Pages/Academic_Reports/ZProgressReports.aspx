<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="ZProgressReports.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="General Academic" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of Calender Toggle By Neon--%>

    <script type="text/javascript" language="javascript">
    function popupCalender() {
        var ExpandableFormRow = document.getElementById('ExpandableFormRow');
       if (dateField.style.display == 'none')
       dateField.style.display= 'block';
       else
       dateField.style.display='none';
    }
    
 
    </script>

    <%--End of Calender Toggle By Neon--%>
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
                        Student Progress Reports
                    </div>
                    <div class="ReportDesc">
                        Generate Student Progress Reports                       
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" class="RLable" Text="Grade :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddlGrade" runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
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
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label4" runat="server" class="RLable" Text="Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlClass" runat="server" Height="20px" Width="185px"
                                    OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label5" runat="server" class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                           <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddlStudentName" 
                                runat="server" Height="20px" Width="185px"
                                    OnSelectedIndexChanged="ddlStudentName_SelectedIndexChanged" 
                                AutoPostBack="true">
                                </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Term :" ID="Label2"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="true" 
                                class="RTxt" CssClass="FormTxtBox " Height="20px" 
                                OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" Width="185px">
                                <asp:ListItem Value="0">Select Term</asp:ListItem>
                                    <asp:ListItem Value="1">Term 1</asp:ListItem>
                                    <asp:ListItem Value="2">Term 2</asp:ListItem>
                                    <asp:ListItem Value="3">Term 3</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                   
                          <div class="RepPanelauto">
                        <CR:CrystalReportViewer  ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                    </div>
                     <div class="paraSpace">
                    </div>
                   
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                          
                        </div>
                        <div class="fieldsElementCell">
                           
                        
                        <asp:Button ID="btnEmail" runat="server" CssClass="buttonText" Height="30px" 
                            OnClick="btnEmail_Click" Text="Submit" ValidationGroup="submit" 
                            Width="142px" />
                            </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="AddMedical.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
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
                        Add Medical Details
                    </div>
                    <div class="ReportDesc">
                        Add Medical Details for Examinations                        
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" class="RLable" Text="Grade"></asp:Label>
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
                           <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddlStudent" runat="server" Height="20px" Width="185px"
                                    OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Admission No :" ID="Label2"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAdNo" runat="server" CssClass="FormTxtBox "  Width="185px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtAdNo" ErrorMessage="Please Enter Admission Number." 
                            ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Examination :" ID="Label3"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlExamination" runat="server" AutoPostBack="true" class="RTxt" CssClass="FormTxtBox "
                                    Height="20px" OnSelectedIndexChanged="ddlExamination_SelectedIndexChanged" Width="185px">
                                    <asp:ListItem Value="empty">Select Examination</asp:ListItem>
                                    <asp:ListItem Value="al">G.C.E. A/L Examination</asp:ListItem>
                                    <asp:ListItem Value="ol">G.C.E. O/L Examination</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                         <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Year :" ID="Label6"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" class="RTxt" Height="20px" CssClass="FormTxtBox "
                                    Width="185px">
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
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label18" runat="server" class="RLable" Text="Subject :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" class="RTxt" CssClass="FormTxtBox "
                                    Height="20px" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" Width="185px">
                                    <asp:ListItem Value="empty">Select Subject</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label19" runat="server" class="RLable" Text="Subject Code :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtSubCode" runat="server" Width="185px" CssClass="FormTxtBox "></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtSubCode" ErrorMessage="Please Enter Subject Code." 
                            ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Medical Date :" ID="Label10"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtDate" runat="server" Width="165px" CssClass="FormTxtBox "></asp:TextBox>
                            <img src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender()">
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label11" runat="server" class="RLable" Text="Duration :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlDuration" runat="server" class="RTxt" CssClass="FormTxtBox " Height="20px" Width="185px">
                                                <asp:ListItem Value="empty">Select Duration</asp:ListItem>
                                                <asp:ListItem Value="1">1 Day</asp:ListItem>
                                                <asp:ListItem Value="2">2 Days</asp:ListItem>
                                                <asp:ListItem Value="3">3 Days</asp:ListItem>
                                                <asp:ListItem Value="4">4 Days</asp:ListItem>
                                                <asp:ListItem Value="5">5 Days</asp:ListItem>
                                                <asp:ListItem Value="6">6 Days</asp:ListItem>
                                                <asp:ListItem Value="7">7 Days</asp:ListItem>
                                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label7" runat="server" class="RLable" Text="Issued By :" ></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                           <asp:TextBox ID="txtIssuedBy" runat="server" Width="185px" CssClass="FormTxtBox "></asp:TextBox>
                        </div>
                    </div>
                    <div id="dateField" style="display: none; padding-left: 100px">
                         <asp:Calendar ID="MedDateCal" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                                            OnSelectionChanged="MedDateCal_SelectionChanged">
                                            <SelectedDayStyle ForeColor="#0000CC" />
                                            <WeekendDayStyle ForeColor="Red" />
                                            <OtherMonthDayStyle ForeColor="#999966" />
                                        </asp:Calendar>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                          <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Reason :" ID="Label8"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtReason" runat="server" Width="180px" CssClass="FormTxtBox "></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                          <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Note :" ID="Label9"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtNote" runat="server" Width="180px" CssClass="FormTxtBox "></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" 
                                Text="Submit" ValidationGroup="submit" Width="142px" CssClass="buttonText" Height="30px" />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnCancel" runat="server" CauseValidation="False" Text="Reset" Width="142px" 
                                onclick="btnCancel_Click1" CssClass="buttonText" Height="30px" />
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

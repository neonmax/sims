<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="AppointmentSystem.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
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
                        Meet Principal
                    </div>
                    <div class="ReportDesc">
                        Add Appointment to Meet Principal
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" Text="Name :" ID="Label1"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtName" runat="server" CssClass="FormTxtBox" Width="294px"></asp:TextBox>
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Name is Required." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Contact Email" ID="Label2"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtEmail" runat="server" Class="FormTxtBox " Width="294px"></asp:TextBox>
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Email Address is Required." ValidationGroup="submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Valid Email Address is Required." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="submit"></asp:RegularExpressionValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Phone Number " ID="Label3"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtNumber" runat="server" Class="FormTxtBox " Width="180px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumber"
                            ErrorMessage="Phone Number is Required." ValidationGroup="submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNumber"
                            ErrorMessage="Phone Number should be in International Format having 13 numbers Ex:0094712345678"
                            ValidationExpression="\d{13}" ValidationGroup="submit"></asp:RegularExpressionValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label18" runat="server" class="RLable" Text="Appointment Type :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlAppointmentType" runat="server" AutoPostBack="true" class="RTxt"
                                CssClass="FormTxtBox " Height="20px" Width="185px">
                                <asp:ListItem>Select Type</asp:ListItem>
                                <asp:ListItem Value="parent">Parent Meeting</asp:ListItem>
                                <asp:ListItem Value="student">Student Meeting</asp:ListItem>
                                <asp:ListItem Value="guest">Guest Meeting</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label19" runat="server" class="RLable" Text="Reason :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtReason" runat="server" Class="FormTxtBox " Width="180px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAppointmentType"
                            ErrorMessage="Type is Required." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Appointment Date" ID="Label10"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtDate" runat="server" Width="160px" Class="FormTxtBox "></asp:TextBox>
                            <img src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender()">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate"
                                ErrorMessage="Appoint Date is Required." ValidationGroup="submit"></asp:RequiredFieldValidator>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label11" runat="server" class="RLable" Text="Appointment Time"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlTimeslot" runat="server" AutoPostBack="true" Class="FormTxtBox "
                                Width="185px">
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTimeslot"
                            ErrorMessage="Appointment Time is Required." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div id="dateField" style="display: none; padding-left: 101px">
                        <asp:Calendar ID="DaySelector" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                            OnSelectionChanged="DateCal_SelectionChanged" OnDayRender="DaySelector_OnRender">
                            <SelectedDayStyle ForeColor="#0000CC" />
                            <WeekendDayStyle ForeColor="Red" />
                            <OtherMonthDayStyle ForeColor="#999966" />
                        </asp:Calendar>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row162app">
                        <div class="fieldsCaptionCell162app">
                            <asp:Label ID="Label15" runat="server" class="RLable" Text="Note :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell162app">
                            <asp:TextBox ID="txtNotes" Class="FormTxtBox " runat="server" Height="160px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnAddAppointment" runat="server" Text="Add Appointment" OnClick="btnAddAppointment_Click"
                                Width="142px" ValidationGroup="submit" CssClass="buttonText" Height="30px" />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnCancel" runat="server" CauseValidation="False" Text="Reset" Width="142px"
                                OnClick="btnCancel_Click" CssClass="buttonText" Height="30px" />
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

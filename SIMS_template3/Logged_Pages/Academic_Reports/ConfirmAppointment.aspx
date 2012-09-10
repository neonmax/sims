<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="ConfirmAppointment.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
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
                        Review Appointments
                    </div>
                    <div class="ReportDesc">
                        Review Appointment to Meet Principal
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell3">
                            <asp:Label runat="server" class="RLable" Text="Date Range" ID="Label10"></asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList Class="FormTxtBox" ID="ddlDateRange" runat="server" Height="20px"
                                Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                <asp:ListItem Value="all">All Appointments</asp:ListItem>
                                <asp:ListItem Value="tmonth">This Month</asp:ListItem>
                                <asp:ListItem Value="nweek">Next Week</asp:ListItem>
                                <asp:ListItem Value="nmonth">Next Month</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell3">
                            <asp:Label ID="Label11" runat="server" class="RLable" Text="Select Type"></asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList Class="FormTxtBox " ID="ddlType" runat="server" Height="20px" Width="180px"
                                OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="all">All Types</asp:ListItem>
                                <asp:ListItem Value="parent">Parent Meeting</asp:ListItem>
                                <asp:ListItem Value="student">Student Meeting</asp:ListItem>
                                <asp:ListItem Value="guest">Guest Meeting</asp:ListItem>
                                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                <asp:ListItem Value="Conformed">Conformed</asp:ListItem>
                                <asp:ListItem Value="Rescheduled">Rescheduled</asp:ListItem>
                                <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell3">
                            <asp:Label runat="server" class="RLable" Text="Custom Date" ID="Label1"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtDate" runat="server" Width="160px" Class="FormTxtBox "></asp:TextBox>
                        <img src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender()">
                    </div>
                    <div id="dateField" style="display: none; padding-left: 671px">
                        <asp:Calendar ID="DaySelector" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                            OnSelectionChanged="DateCal_SelectionChanged" OnDayRender="DaySelector_OnRender">
                            <SelectedDayStyle ForeColor="#0000CC" />
                            <WeekendDayStyle ForeColor="Red" />
                            <OtherMonthDayStyle ForeColor="#999966" />
                        </asp:Calendar>
                    </div>
                    <div class="paraSpace">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <br />
                </div>
                <div class="FormBackgroundAddAppointment">
                    <asp:GridView ID="GridViewAppointments" runat="server" AutoGenerateColumns="False"
                        BorderColor="White" BorderStyle="Ridge" CellSpacing="1" DataKeyNames="USER_NO,ADATE,ATIME_SLOT"
                        DataSourceID="SqlDataSourceAppointments" OnRowCommand="GridView1_RowCommand"
                        OnRowCreated="GridView1_RowCreated" Width="97%" AllowPaging="True" CssClass="grid-view">
                        <Columns>
                            <asp:BoundField DataField="ADATE" HeaderText="DATE" ReadOnly="True" SortExpression="ADATE" />
                            <asp:BoundField DataField="ATIME_SLOT" HeaderText="TIMESLOT" ReadOnly="True" SortExpression="ATIME_SLOT" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                            <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />                            
                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-Height="20" ControlStyle-CssClass="buttonText"
                                HeaderText="CONFIRM" Text="Confirm" CommandName="confirm" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-Height="20" ControlStyle-CssClass="OrangebuttonText"
                                HeaderText="RESCHEDULE" Text="Reschedule" CommandName="reschedule" />
                            <asp:ButtonField ButtonType="Button" ControlStyle-Height="20" ControlStyle-CssClass="RedbuttonText"
                                HeaderText="CANCEL" Text="Cancel" CommandName="cancel" />
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSourceAppointments" runat="server" ConnectionString="<%$ ConnectionStrings:nsis %>"
                    ProviderName="<%$ ConnectionStrings:nsis.ProviderName %>" SelectCommand="SELECT * FROM appointment_principal;">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Download_Past_Papers.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Past Papers Archive" %>

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
                        Past Paper Archive
                    </div>
                    <div class="ReportDesc">
                        Download Examination Pastpapers
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell3">
                            <asp:Label runat="server" class="RLable" Text="Category :" ID="Label10"></asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList Class="FormTxtBox" ID="ddlCat_List" runat="server" Height="20px"
                                Width="180px" AutoPostBack="true" OnSelectedIndexChanged="ddlCat_List_SelectedIndexChanged">
                                <asp:ListItem Value="select">Select Category</asp:ListItem>
                                <asp:ListItem Value="year">By Year</asp:ListItem>
                                <asp:ListItem Value="grade">By Grade</asp:ListItem>
                                <asp:ListItem Value="subject">By Subject</asp:ListItem>
                                <asp:ListItem Value="gradeandterm">By Grade &amp; Term</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell3">
                            <asp:Label ID="lblCat1" runat="server" class="RLable"></asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList Class="FormTxtBox " ID="ddlCat1" runat="server" Height="20px" Width="180px"
                                OnSelectedIndexChanged="ddlCat_1_SelectedIndexChanged" AutoPostBack="true" Visible="False">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell3">
                            <asp:Label runat="server" class="RLable" ID="lblCat2"></asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList Class="FormTxtBox " ID="ddlCat2" runat="server" Height="20px" Width="180px"
                                OnSelectedIndexChanged="ddlCat2_SelectedIndexChanged" AutoPostBack="true" Visible="False">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell3">
                            <asp:Label ID="lblTerm" runat="server" class="RLable" Visible="False">Term :</asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="true" Class="FormTxtBox"
                                Height="20px" Width="180px" Visible="False">
                                <asp:ListItem Value="all">Select Category</asp:ListItem>
                                <asp:ListItem Value="tmonth">By Grade</asp:ListItem>
                                <asp:ListItem Value="nweek">By Subject</asp:ListItem>
                                <asp:ListItem Value="nmonth">By Year</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell3">
                            <asp:Label ID="lblSubject" runat="server" class="RLable" Visible="False">Subject 
                            :</asp:Label>
                        </div>
                        <div class="fieldsElementCell3">
                            <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" Class="FormTxtBox "
                                Height="20px" Visible="False" Width="180px">
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
                        </div>
                        <div class="fieldsElementCell3">
                        </div>
                    </div>
                    <div class="paraSpace">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="FormBackgroundAddAppointment">
                    <asp:GridView ID="GridViewPastPapers" runat="server" AutoGenerateColumns="False"
                        BorderColor="White" BorderStyle="Ridge" CellSpacing="1" DataKeyNames="PPRID"
                        DataSourceID="SqlDataSourcePastPapers" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated"
                        Width="97%" AllowPaging="True" CssClass="grid-view" AllowSorting="True" ChildrenAsTriggers="true">
                        <Columns>
                            <asp:BoundField DataField="YEAR" HeaderText="YEAR" ReadOnly="True" SortExpression="YEAR" />
                            <asp:BoundField DataField="GRADE" HeaderText="GRADE" ReadOnly="True" SortExpression="GRADE" />
                            <asp:BoundField DataField="TERM" HeaderText="TERM" SortExpression="TERM" />
                            <asp:BoundField DataField="SUBJECT" HeaderText="SUBJECT" SortExpression="SUBJECT" />
                            <asp:BoundField DataField="FILENAME" HeaderText="FILE NAME" SortExpression="FILENAME" />
                            <asp:BoundField DataField="SIZE" HeaderText="FILE SIZE" SortExpression="SIZE" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:LinkButton ID="MarkAsCompleteButton" runat="server" Text="Download" ControlStyle-ForeColor="Blue"
                                        CommandName="Dwn" OnDataBinding="PostBackBind_DataBinding" CommandArgument='<%# bind("FILENAME") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSourcePastPapers" runat="server" ConnectionString="<%$ ConnectionStrings:nsis %>"
                    ProviderName="<%$ ConnectionStrings:nsis.ProviderName %>" SelectCommand="SELECT  P.PPRID, P.YEAR, P.GRADE, P.TERM, P.FILENAME, P.SIZE, S.SUBJECT FROM subjects_mast S, past_papers P WHERE P.SUB_CODE = S.SUBJECT_CODE ORDER BY P.YEAR DESC ,P.GRADE ASC,P.TERM ASC">
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

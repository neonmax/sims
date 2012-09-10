<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="NewAddScholarship.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Add Scholarship Details" %>

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
                        Scholarship Details
                    </div>
                    <div class="ReportDesc">
                        Add Scholarship Details
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
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlGrade" runat="server"
                                Height="20px" Width="185px" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
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
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlClass" runat="server"
                                Height="20px" Width="185px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                                AutoPostBack="true">
                                  <asp:ListItem Value="empty">Select Class</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label5" runat="server" class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlStudent" runat="server"
                                Height="20px" Width="185px" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"
                                AutoPostBack="true">
                                  <asp:ListItem Value="empty">Select Student</asp:ListItem>
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
                            <asp:TextBox ID="txtAdNo" runat="server" CssClass="FormTxtBox " Width="185px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdNo"
                            ErrorMessage="Please Enter Admission Number." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label18" runat="server" class="RLable" Text="Scholarship :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlSchol" runat="server" AutoPostBack="true" class="RTxt" CssClass="FormTxtBox "
                                Height="20px" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" Width="185px">
                                <asp:ListItem Value="empty">Select Scholarship</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label19" runat="server" class="RLable" Text="Schol. Code :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtScholCode" runat="server" Width="185px" CssClass="FormTxtBox "></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtScholCode"
                            ErrorMessage="Please Enter Subject Code." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label11" runat="server" class="RLable" Text="Awarded Year :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlYear" runat="server" class="RTxt" CssClass="FormTxtBox "
                                Height="20px" Width="185px">
                                <asp:ListItem Value="empty">Select Year</asp:ListItem>
                                <asp:ListItem>2012</asp:ListItem>
                                <asp:ListItem>2011</asp:ListItem>
                                <asp:ListItem>2010</asp:ListItem>
                                <asp:ListItem>2009</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Amount :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="FormTxtBox " Width="185px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmount"
                            ErrorMessage="Please Enter Amount." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row162auto">
                        <div class="fieldsCaptionCell162auto">
                            <asp:Label runat="server" class="RLable" Text="Note :" ID="Label3"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtNote" runat="server" Height="97px" TextMode="MultiLine" CssClass="FormTxtBox "
                            Width="669px"></asp:TextBox>
                        &nbsp;&nbsp;
                        <br />
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                ValidationGroup="submit" Width="142px" CssClass="buttonText" Height="30px" />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnCancel" runat="server" CauseValidation="False" Text="Reset" Width="142px"
                                OnClick="btnCancel_Click1" CssClass="buttonText" Height="30px" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

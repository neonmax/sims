<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Activity_Log.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="Student Activity" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ToolkitScriptManager ID="tscm_activity" runat="server">
    </asp:ToolkitScriptManager>
    <div id="wrap">
        <div id="header">
            <div id="logo2">
                <br />
                <br />
                <br />
                <asp:Label ID="SessionTxt" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
                    Font-Size="Medium" ForeColor="White"></asp:Label>
                <br />
                <asp:LinkButton ID="LnkLogout" runat="server" ForeColor="Yellow">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="ReportBody">
            <div class="form">
                <div id="menu">
                    <ul>
                        <li><a href="../Home.aspx">Home</a></li>
                        <li><a href="../AboutUs.aspx" class="active">About Us</a></li>
                        <li><a href="../ContactUs.aspx">Contact Us</a></li>
                    </ul>
                </div>
                <div class="ReportHeader">
                    Extra Curricular Activity
                </div>
                <div class="ParaMiddleH">
                    <div class="paraSpace">
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="lbl_gra" class="RLable" runat="server" Text="Grade :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:DropDownList ID="ddl_grade" OnSelectedIndexChanged="ddl_grade_SelectedIndexChanged"
                                        runat="server" Width="180px" class="RTxt" AutoPostBack="True" CssClass="FormTxtBox"
                                        Height="20px">
                                    </asp:DropDownList>
                                </div>
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label3" runat="server" class="RLable" Text="Class :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:DropDownList ID="ddl_class" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged"
                                        runat="server" Width="180px" class="RTxt" AutoPostBack="True" CssClass="FormTxtBox"
                                        Height="20px">
                                    </asp:DropDownList>
                                </div>
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label4" runat="server" class="RLable" Text="Student :"></asp:Label>
                                </div>
                                <asp:DropDownList ID="ddl_student" OnSelectedIndexChanged="ddl_student_SelectedIndexChanged"
                                    runat="server" Width="180px" class="RTxt" AutoPostBack="True" CssClass="FormTxtBox"
                                    Height="20px">
                                </asp:DropDownList>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label1" runat="server" class="RLable" Text="Adm No :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_admissionno_result" class="RLable" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label5" runat="server" class="RLable" Text="Activity Type :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:DropDownList ID="ddl_type" class="RTxt" OnSelectedIndexChanged="ddl_type_SelectedIndexChanged"
                                        runat="server" Width="180px" AutoPostBack="True" CssClass="FormTxtBox" Height="20px">
                                    </asp:DropDownList>
                                </div>
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label6" runat="server" class="RLable" Text="Activity :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:DropDownList ID="ddl_activity" runat="server" class="RTxt" Width="180px" AutoPostBack="True"
                                        CssClass="FormTxtBox" Height="20px">
                                        <asp:ListItem>Select Activity</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label7" runat="server" class="RLable" Text="Activity Year :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:TextBox ID="txt_activityyear" Class="FormTxtBox " runat="server" Width="180px"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="wme_activityyear" runat="server" TargetControlID="txt_activityyear"
                                        WatermarkText="Add Activity Year">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="RFV_year" runat="server" ErrorMessage="Insert Year"
                                        ControlToValidate="txt_activityyear" Font-Names="Arial" Font-Size="Small" 
                                        ValidationGroup="submit"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="lbl_admissionno" runat="server" class="RLable" Text="Member No :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:TextBox ID="txt_membershipno" runat="server" Class="FormTxtBox " Width="180px"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="wme_memebershipno" runat="server" TargetControlID="txt_membershipno"
                                        WatermarkText=" Add Membership No">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="rfv_memeber" runat="server" ErrorMessage="Insert Memeber Id"
                                        ControlToValidate="txt_membershipno" Font-Names="Arial" Font-Size="Small" 
                                        ValidationGroup="submit"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="field_3_Row162">
                                <div class="fieldsCaptionCell162">
                                    <asp:Label ID="Label8" runat="server" class="RLable" Text="Reg. Date: "></asp:Label>
                                    <asp:RequiredFieldValidator ID="RFV_date" runat="server" ErrorMessage="Select Date"
                                        ControlToValidate="txt_registerdate" Font-Names="Arial" Font-Size="Small" 
                                        ValidationGroup="submit"></asp:RequiredFieldValidator>
                                </div>
                                <div class="fieldsElementCell162">
                                    <asp:TextBox ID="txt_registerdate" runat="server" Class="FormTxtBox " Height="20px"
                                        Width="160px"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="wme_date" runat="server" TargetControlID="txt_registerdate"
                                        WatermarkText="Date">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:CalendarExtender ID="ce_activity" runat="server" TargetControlID="txt_registerdate"
                                        PopupButtonID="ibtn_calander">
                                    </asp:CalendarExtender>
                                    <asp:ImageButton ID="ibtn_calander" runat="server" Height="16px" ImageUrl="../../images/Calendar_scheduleHS.png"
                                        Width="16px" />
                                </div>
                                <div class="fieldsCaptionCell162">
                                    <asp:Label ID="Label12" runat="server" class="RLable" Text="Description :" Font-Size="Medium"></asp:Label>
                                </div>
                                <div class="fieldsElementCell162">
                                    <asp:TextBox ID="txt_description" runat="server" Class="FormTxtBox " Height="160px"
                                        Width="330px" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="fieldsCaptionCell162">
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btn_insert" runat="server" Text="Insert" Height="30px" Width="142px"
                                OnClick="btn_insert_Click" CssClass="buttonText" ValidationGroup="submit" />
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Button ID="btn_clear" runat="server" Height="30px" Width="142px" Text="Clear"
                                OnClick="btn_clear_Click" CssClass="buttonText" />
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                    </div>
                </div>
                <div class="ParaBottomH">
                </div>
                <br />
            </div>
        </div>
        <div class="con_bot">
        </div>
        <div id="footer">
            <p>
                All rights reserved !-- Please DO NOT remove the following notice --&gt; ng notice
                --&gt;
                <p>
                    Design by SLIIT SEWD 02</p>
                <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

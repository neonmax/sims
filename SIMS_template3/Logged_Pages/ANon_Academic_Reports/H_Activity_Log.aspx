<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H_Activity_Log.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Style.css" rel="stylesheet" type="text/css" />

    <script src="DeepASPImpromptuCalling.js" type="text/javascript"></script>

    <script src="jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="jquery-1.5.1.js" type="text/javascript"></script>

    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            height: 602px;
            width: 1077px;
        }
        .style2
        {
            height: 13px;
        }
        .style3
        {
            height: 17px;
        }
        .style5
        {
            height: 18px;
        }
        .style29
        {
            width: 130px;
        }
        .style38
        {
            height: 13px;
            width: 228px;
        }
        .style40
        {
            height: 17px;
            width: 228px;
        }
        .style41
        {
            height: 18px;
            width: 228px;
        }
        .style42
        {
        }
        .style52
        {
            height: 13px;
            width: 137px;
        }
        .style53
        {
            height: 58px;
            width: 137px;
        }
        .style54
        {
            height: 17px;
            width: 137px;
        }
        .style55
        {
            height: 18px;
            width: 137px;
        }
        .style57
        {
            width: 137px;
        }
        .style71
        {
        }
        .style78
        {
        }
        .style80
        {
            height: 13px;
            width: 126px;
        }
        .style82
        {
            height: 17px;
            width: 126px;
        }
        .style83
        {
            height: 18px;
            width: 126px;
        }
        .style86
        {
            height: 13px;
            width: 122px;
        }
        .style88
        {
            height: 17px;
            width: 122px;
        }
        .style89
        {
            height: 18px;
            width: 122px;
        }
        .style94
        {
            height: 13px;
            width: 130px;
        }
        .style96
        {
            height: 17px;
            width: 130px;
        }
        .style97
        {
            height: 18px;
            width: 130px;
        }
        .style101
        {
            height: 58px;
        }
        .style102
        {
            height: 58px;
            width: 126px;
        }
        .style103
        {
            height: 58px;
            width: 228px;
        }
        .style104
        {
            height: 58px;
            width: 122px;
        }
        .style106
        {
            height: 49px;
            width: 130px;
        }
        .style107
        {
            height: 49px;
        }
        .style108
        {
            height: 49px;
            width: 126px;
        }
        .style109
        {
            height: 49px;
            width: 228px;
        }
        .style110
        {
            height: 49px;
            width: 122px;
        }
        .style111
        {
            height: 58px;
            width: 130px;
        }
        .style112
        {
            height: 37px;
        }
        .style113
        {
            height: 37px;
            width: 130px;
        }
        .style114
        {
            height: 37px;
            width: 126px;
        }
        .style115
        {
            height: 37px;
            width: 228px;
        }
        .style116
        {
            height: 37px;
            width: 122px;
        }
        .style117
        {
            height: 59px;
        }
        .style118
        {
            height: 59px;
            width: 126px;
        }
        .style119
        {
            height: 59px;
            width: 228px;
        }
        .style120
        {
            height: 59px;
            width: 122px;
        }
        .style121
        {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 100%; height: 602px;">
        <tr>
            <td class="style117" align="left" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_activityheading" runat="server" Font-Bold="True" Font-Names="Arial"
                    Font-Size="Large" Text="Student Extra Activity Details"></asp:Label>
            </td>
            <td class="style118" align="right">
            </td>
            <td class="style119">
            </td>
            <td class="style120" align="right">
            </td>
            <td class="style117">
            </td>
        </tr>
        <tr>
            <td class="style107" align="right">
                <asp:Label ID="lbl_grade" runat="server" Text="Grade :" Font-Names="Arial" Width="130px"></asp:Label>
            </td>
            <td class="style106">
                <asp:DropDownList ID="ddl_grade" runat="server" Height="25px" Width="191px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddl_grade_SelectedIndexChanged" Font-Names="Arial" Font-Size="Medium">
                </asp:DropDownList>
            </td>
            <td class="style108" align="right">
                <asp:Label ID="lbl_class" runat="server" Text="Class :" Font-Names="Arial" Width="130px"></asp:Label>
            </td>
            <td class="style109">
                <asp:DropDownList ID="ddl_class" runat="server" Height="25px" Width="190px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddl_class_SelectedIndexChanged" Font-Names="Arial" Font-Size="Medium">
                    <asp:ListItem>Select Class</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style110" align="right">
                <asp:Label ID="lbl_student" runat="server" Text="Student :" Font-Names="Arial" Width="130px"></asp:Label>
            </td>
            <td class="style107">
                &nbsp;<asp:DropDownList ID="ddl_student" runat="server" Height="25px" Width="190px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddl_student_SelectedIndexChanged"
                    Font-Names="Arial" Font-Size="Medium">
                    <asp:ListItem>Select Student</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style52">
            </td>
            <td class="style94">
            </td>
            <td class="style80">
            </td>
            <td class="style38">
            </td>
            <td class="style86">
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style53" align="right">
                <asp:Label ID="lbl_admissionno" runat="server" Text="Admission No       :" Font-Names="Arial"
                    Width="115px" Height="17px"></asp:Label>
            </td>
            <td class="style111">
                <asp:Label ID="lbl_admissionno_result" runat="server" Text="Label" Font-Names="Arial"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td class="style102">
            </td>
            <td class="style103">
            </td>
            <td class="style104">
            </td>
            <td class="style101">
            </td>
        </tr>
        <tr>
            <td class="style54">
            </td>
            <td class="style96">
            </td>
            <td class="style82">
            </td>
            <td class="style40">
            </td>
            <td class="style88">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style112" align="right">
                <asp:Label ID="lbl_activitytype" runat="server" Text="Activity Type       :" Font-Names="Arial"
                    Width="130px"></asp:Label>
            </td>
            <td class="style113">
                <asp:DropDownList ID="ddl_type" runat="server" Height="25px" Width="190px" AutoPostBack="True"
                    OnSelectedIndexChanged="ddl_type_SelectedIndexChanged" Font-Names="Arial" Font-Size="Medium">
                </asp:DropDownList>
            </td>
            <td class="style114" align="right">
                <asp:Label ID="lbl_activity" runat="server" Text="Activity            :" Font-Names="Arial"
                    Width="130px"></asp:Label>
            </td>
            <td class="style115">
                <asp:DropDownList ID="ddl_activity" runat="server" Height="25px" Width="190px" AutoPostBack="True"
                    Font-Names="Arial" Font-Size="Medium">
                    <asp:ListItem>Select Activity</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style116" align="right" valign="middle">
                <br />
                <asp:Label ID="lbl_activityyear" runat="server" Font-Names="Arial" Font-Size="Medium"
                    Text="Activity  Year :"></asp:Label>
                <br />
                &nbsp;
            </td>
            <td class="style112">
                &nbsp;<asp:TextBox ID="txt_activityyear" runat="server" Height="25px" Width="190px"
                    Font-Names="Arial" Font-Size="Medium" Style="margin-bottom: 0px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender
                        ID="wme_activityyear" runat="server" TargetControlID="txt_activityyear" WatermarkText="Add Activity Year">
                    </asp:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td class="style55">
            </td>
            <td class="style97">
            </td>
            <td class="style83">
            </td>
            <td class="style41">
            </td>
            <td class="style89">
            </td>
            <td class="style5">
            </td>
        </tr>
        <tr>
            <td class="style101" align="right">
                <asp:Label ID="lbl_membershipno" runat="server" Text="Membership No :" Font-Names="Arial"
                    Width="130px"></asp:Label>
            </td>
            <td class="style111">
                <asp:TextBox ID="txt_membershipno" runat="server" Height="25px" Width="187px" Font-Names="Arial"
                    Font-Size="Medium"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="wme_memebershipno" runat="server" TargetControlID="txt_membershipno"
                    WatermarkText=" Add Membership No">
                </asp:TextBoxWatermarkExtender>
            </td>
            <td class="style102" align="right">
                <asp:Label ID="lbl_description" runat="server" Text="Description :" Font-Names="Arial"
                    Width="130px"></asp:Label>
            </td>
            <td class="style42" colspan="2" rowspan="4">
                <asp:TextBox ID="txt_description" runat="server" Height="151px" TextMode="MultiLine"
                    Width="340px" Font-Names="Arial" Font-Size="Medium"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="wme_description" runat="server" TargetControlID="txt_description"
                    WatermarkText="Add Description Here">
                </asp:TextBoxWatermarkExtender>
            </td>
            <td class="style101">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style52">
            </td>
            <td class="style94">
            </td>
            <td class="style80">
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style101" align="right">
                <asp:Label ID="lbl_registerdate" runat="server" Text="Register Date :" Font-Names="Arial"></asp:Label>
            </td>
            <td class="style111">
                <asp:TextBox ID="txt_registerdate" runat="server" Height="30px" Width="100px" Font-Names="Arial"
                    Font-Size="Medium"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="wme_date" runat="server" TargetControlID="txt_registerdate"
                    WatermarkText="Date">
                </asp:TextBoxWatermarkExtender>
                <asp:CalendarExtender ID="ce_activity" runat="server" TargetControlID="txt_registerdate"
                    PopupButtonID="ibtn_calander">
                </asp:CalendarExtender>
                <asp:ImageButton ID="ibtn_calander" runat="server" Height="16px" ImageUrl="../../images/Calendar_scheduleHS.png"
                    Width="16px" />
            </td>
            <td class="style101">
            </td>
            <td class="style101">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style121" colspan="2">
                <asp:ToolkitScriptManager ID="tscm_activity" runat="server">
                </asp:ToolkitScriptManager>
            </td>
            <td class="style121">
            </td>
            <td class="style121">
            </td>
        </tr>
        <tr>
            <td class="style57">
                &nbsp;
            </td>
            <td class="style29">
                &nbsp;
            </td>
            <td class="style78" colspan="2">
                &nbsp;
            </td>
            <td class="style71" colspan="2">
                <asp:Button ID="btn_clear" runat="server" Font-Names="Arial" Font-Size="Medium" Height="31px"
                    Text="Clear" Width="111px" OnClick="btn_clear_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_insert" runat="server" Text="Insert" Font-Names="Arial" Font-Size="Medium"
                    Height="30px" Width="190px" OnClick="btn_insert_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

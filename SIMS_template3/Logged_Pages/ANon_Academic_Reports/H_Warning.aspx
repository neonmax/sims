<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="H_Warning.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />

    <script src="DeepASPImpromptuCalling.js" type="text/javascript"></script>
    

    <script src="jquery-1.5.1.js" type="text/javascript"></script>

    <script src="Jquery-Impromptu.3.3.js" type="text/javascript"></script>
    
    
    <style type="text/css">
        .style1
        {
            width: 121px;
        }
        .style2
        {
        }
        .style3
        {
            width: 120px;
        }
        .style4
        {
            width: 121px;
            height: 150px;
        }
        .style5
        {
            width: 120px;
            height: 150px;
        }
        .style6
        {
            height: 150px;
        }
        .style7
        {
            width: 121px;
            height: 49px;
        }
        .style8
        {
            height: 49px;
        }
        .style9
        {
            width: 120px;
            height: 49px;
        }
        .style10
        {
            height: 41px;
        }
        .style11
        {
            height: 41px;
        }
        .style12
        {
            width: 120px;
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 600px; width: 1053px">
    
        <table style="width: 100%; height: 600px;">
            <tr>
                <td class="style10" align="left" colspan="2">
                    <asp:Label ID="lbl_warningheading" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="Large" Text="Student Warning Details"></asp:Label>
                </td>
                <td class="style10" align="right">
                </td>
                <td class="style11">
                </td>
                <td class="style12" align="right">
                </td>
                <td class="style11">
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_grade" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Grade :"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddl_grade" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="Medium" Height="25px" Width="200px" 
                        onselectedindexchanged="ddl_grade_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_class" runat="server" Font-Names="Arial" Text="Class :"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddl_class" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="Medium" Height="25px" Width="200px" 
                        onselectedindexchanged="ddl_class_SelectedIndexChanged">
                        <asp:ListItem>Select Class</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3" align="right">
                    <asp:Label ID="lbl_student" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Student :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_student" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="Medium" Height="25px" Width="200px" 
                        onselectedindexchanged="ddl_student_SelectedIndexChanged">
                        <asp:ListItem>Select Student</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7" align="right">
                    <asp:Label ID="lbl_admissionno" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Admission No :"></asp:Label>
                </td>
                <td class="style8">
                    <asp:Label ID="lbl_admissionno_result" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Label"></asp:Label>
                </td>
                <td class="style7">
                    </td>
                <td class="style8">
                    </td>
                <td class="style9">
                    </td>
                <td class="style8">
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_warningtype" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Warning Type :"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddl_type" runat="server" Height="25px" Width="200px" 
                        AutoPostBack="True" Font-Names="Arial" Font-Size="Medium" 
                        onselectedindexchanged="ddl_type_SelectedIndexChanged">
                        <asp:ListItem>Select Warning Type</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_warniglevel" runat="server" Font-Names="Arial" 
                        Text="Warning Level :"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddl_level" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="Medium" Height="25px" Width="200px" 
                        onselectedindexchanged="ddl_level_SelectedIndexChanged">
                        <asp:ListItem>Select Warning Level</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3" align="right">
                    <asp:Label ID="lbl_warneddate" runat="server" Font-Names="Arial" 
                        Text="Warned Date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_date" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="25px" Width="175px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="wme_date" runat="server" TargetControlID="txt_date" WatermarkText="Select Date">
                    </asp:TextBoxWatermarkExtender>
                    <asp:CalendarExtender ID="ce_warning" runat="server" TargetControlID="txt_date" PopupButtonID="ibtn_warning" >
                    </asp:CalendarExtender>
                    <asp:ImageButton ID="ibtn_warning" runat="server" Height="25px" 
                        ImageUrl="~/NewFolder1/blue_calander.jpg" Width="25px" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_description" runat="server" Font-Names="Arial" 
                        Text="Description :"></asp:Label>
                </td>
                <td class="style2" colspan="3" rowspan="2">
                    <asp:TextBox ID="txt_description" runat="server" Font-Names="Arial" 
                        Font-Size="Medium" Height="225px" TextMode="MultiLine" Width="340px"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="wme_des" runat="server" TargetControlID="txt_description" WatermarkText="Add warning Details Here">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td class="style3" align="right">
                    <asp:Label ID="lbl_inform" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Inform Parents :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_inform" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="Medium" Height="25px" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style4">
                </td>
                <td class="style5">
                </td>
                <td class="style6">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2" colspan="2" rowspan="2">
                    <asp:ToolkitScriptManager ID="tsm_warning" runat="server">
                    </asp:ToolkitScriptManager>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Button ID="btn_clear" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="30px" Text="Clear" Width="110px" onclick="btn_clear_Click" />
                </td>
                <td>
                    <asp:Button ID="btn_insert" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="30px" Text="Insert" Width="199px" onclick="btn_insert_Click" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

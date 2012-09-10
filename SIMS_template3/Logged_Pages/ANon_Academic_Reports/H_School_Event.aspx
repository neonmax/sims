<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="H_School_Event.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Style.css" rel="stylesheet" type="text/css" />

    <script src="DeepASPImpromptuCalling.js" type="text/javascript"></script>

    <script src="jquery-1.5.1.js" type="text/javascript"></script>


    <script src="Jquery-Impromptu.3.3.js" type="text/javascript"></script>
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 120px;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            width: 121px;
        }
        .style5
        {
            height: 39px;
        }
        .style6
        {
            height: 39px;
        }
        .style7
        {
            width: 121px;
            height: 39px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 601px; width: 1048px">
    
        <table style="width: 100%; height: 599px;">
            <tr>
                <td class="style5" align="left" colspan="2">
                    <asp:Label ID="lbl_event_heading" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="Large" Text="School Event Details"></asp:Label>
                </td>
                <td class="style7" align="right">
                </td>
                <td class="style6">
                </td>
                <td width="120" align="right" class="style6">
                </td>
                <td class="style6">
                </td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_eventid" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Text="Event ID :"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txt_id" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="25px" Width="212px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="wme_id" runat="server" TargetControlID="txt_id" WatermarkText="Add ID Here">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td class="style4" align="right">
                    <asp:Label ID="lbl_maincatagoty" runat="server" Font-Names="Arial" 
                        Text="Main Catagoty :"></asp:Label>
                </td>
                <td class="style3">
                    <asp:DropDownList ID="ddl_main" runat="server" Font-Names="Arial" 
                        Font-Size="Medium" Height="25px" Width="212px" AutoPostBack="True" 
                        onselectedindexchanged="ddl_main_SelectedIndexChanged">
                        <asp:ListItem>Select Main Catagory</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td width="120" align="right">
                    <asp:Label ID="lbl_subcatagory" runat="server" Font-Names="Arial" 
                        Text="Sub Catagoty :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_sub" runat="server" Font-Names="Arial" 
                        Font-Size="Medium" Height="25px" Width="212px" AutoPostBack="True">
                        <asp:ListItem>Select Sub Catagory</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_eventname" runat="server" Font-Names="Arial" 
                        Text="Event Name      :"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txt_name" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="25px" Width="212px"></asp:TextBox>
                   <asp:TextBoxWatermarkExtender ID="wme_name" runat="server" TargetControlID="txt_name" WatermarkText="Add name Here">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td class="style4" align="right">
                    <asp:Label ID="lbl_organizer" runat="server" Font-Names="Arial" 
                        Text="Organizer :"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txt_org" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="25px" Width="212px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="wme_organizer" runat="server" TargetControlID="txt_org" WatermarkText="Add organizer Here">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td align="right">
                    <asp:Label ID="lbl_heldadate" runat="server" Font-Names="Arial" 
                        Text="Held Date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_date" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="25px" Width="186px"></asp:TextBox>
                        
                  <asp:TextBoxWatermarkExtender ID="wme_date" runat="server" TargetControlID="txt_date" WatermarkText="Select date Here">
                    </asp:TextBoxWatermarkExtender>
                    <asp:CalendarExtender ID="ce_events" runat="server" TargetControlID="txt_date" 
                        PopupButtonID="ibtn_events" Animated="False">
                    </asp:CalendarExtender>
                        
                    <asp:ImageButton ID="ibtn_events" runat="server" Height="25px" Width="25px" 
                        ImageUrl="~/Images/blue_calander.jpg" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" align="right">
                    <asp:Label ID="lbl_description" runat="server" Font-Names="Arial" 
                        Text="Description :"></asp:Label>
                    <br />
                </td>
                <td class="style2" colspan="2">
                    <asp:TextBox ID="txt_des" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="225px" TextMode="MultiLine" Width="340px"></asp:TextBox>
                   <asp:TextBoxWatermarkExtender ID="wme_des" runat="server" TargetControlID="txt_des" WatermarkText="Add event description Here">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td class="style3" align="right">
                    <asp:Label ID="lbl_facedissues" runat="server" Font-Names="Arial" 
                        Text="Faced Issues :"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_issue" runat="server" Font-Names="Arial" 
                        Font-Size="Medium" Height="225px" TextMode="MultiLine" Width="340px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="wme_isse" runat="server" TargetControlID="txt_issue" WatermarkText="Add event issues Here">
                    </asp:TextBoxWatermarkExtender>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3" colspan="2" rowspan="3">
                    <asp:ToolkitScriptManager ID="tsm_events" runat="server">
                    </asp:ToolkitScriptManager>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_clear" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="30px" Text="Clear" Width="109px" onclick="btn_clear_Click"  />
                </td>
                <td>
                    <asp:Button ID="btn_insert" runat="server" Font-Names="Arial" Font-Size="Medium" 
                        Height="30px" Text="Insert" Width="210px" onclick="btn_insert_Click"  />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H_School_eventUD.aspx.cs" Inherits="School_event" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<link href="Nortifications/CSS/Confirmation.css" rel="stylesheet" type="text/css" />
<link href="Style.css" rel="stylesheet" type="text/css" />
<script src="DeepASPImpromptuCalling.js" type="text/javascript"></script>
<script src="jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="jquery-1.5.1.js" type="text/javascript"></script>
<script src="Jquery-Impromptu.3.3.js" type="text/javascript"></script>
<script src="jquery.tools.js" type="text/javascript"></script>
<script src="pirobox.js" type="text/javascript"></script>
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 854px;
        }
        .style2
        {
            width: 628px;
        }
        .style3
        {
            width: 215px;
        }
        .style4
        {
            width: 257px;
        }
        .style5
        {
            width: 214px;
        }
        .style6
        {
            width: 197px;
        }
        .style7
        {
            width: 197px;
            height: 10px;
        }
        .style8
        {
            width: 214px;
            height: 10px;
        }
        .style9
        {
            width: 257px;
            height: 10px;
        }
        .style10
        {
            width: 215px;
            height: 10px;
        }
        .style11
        {
            width: 628px;
            height: 10px;
        }
        .style12
        {
            width: 854px;
            height: 10px;
        }
        .style13
        {
            height: 10px;
        }
        .style14
        {
            width: 874px;
            height: 10px;
        }
        .style15
        {
            width: 874px;
        }
        .style16
        {
            height: 406px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 500px; width: 1001px">
    
        <table style="width: 100%; height: 500px;">
            <tr>
                <td class="style7">
                    </td>
                <td class="style8">
                </td>
                <td class="style9">
                </td>
                <td class="style10">
                    </td>
                <td class="style11">
                </td>
                <td class="style14">
                    </td>
                <td class="style12" align="center">
                    <asp:TextBox ID="txt_search" runat="server" Height="25px" Width="225px" 
                        Font-Names="Arial" Font-Size="Medium" ></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="wme_txt_search" runat="server" 
                        TargetControlID="txt_search" WatermarkText="- - -Insert Event Name Here- - -">
                    </asp:TextBoxWatermarkExtender>
                        
                </td>
                <td class="style13">
                    <asp:Button ID="btn_search" runat="server" Height="26px" Text="Search" 
                        Width="100px" onclick="btn_search_Click"  />
                </td>
            </tr>
            <tr>
                <td class="style16" colspan="8">
                    <asp:GridView ID="gv_events" runat="server" Height="401px" Width="1000px"
                    autogeneratecolumns="False"
                    BorderColor="White" BorderStyle="Ridge"
                    CellSpacing="1" CellPadding="3" GridLines="Horizontal"
                    BackColor="White" BorderWidth="2px"
                    emptydatatext="No data available." DataKeyNames="EVENT_ID" Font-Names="Arial" 
                        Font-Size="Small" onrowdatabound="gv_events_RowDataBound" 
                        onrowediting="gv_events_RowEditing" AllowPaging="True" 
                        onpageindexchanging="gv_events_PageIndexChanging" 
                        onrowcancelingedit="gv_events_RowCancelingEdit" 
                        onrowdeleting="gv_events_RowDeleting" onrowupdating="gv_events_RowUpdating" 
                        PageSize="8">
                    
                        <PagerSettings PageButtonCount="5" />
                    
                    <Columns>
                    <asp:BoundField DataField="EVENT_ID" HeaderText="Event ID" 
                    ReadOnly="true">
                        <ControlStyle Width="50px" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" 
                            Height="30px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField headertext="Main Type">
                        <ControlStyle Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    <ItemTemplate> <%#Eval("EVENT_TYPE_MAST")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:DropDownList ID="ddl_master" runat="server" AutoPostBack="true" >               
                    </asp:DropDownList>                               
                    </EditItemTemplate>                   
                    </asp:TemplateField> 
                    
                    <asp:TemplateField headertext="Sub Type">
                        <ControlStyle Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    <ItemTemplate> <%#Eval("EVENT_TYPE_SUB")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:DropDownList ID="ddl_sub" runat="server" >               
                    </asp:DropDownList>                               
                    </EditItemTemplate>                   
                    </asp:TemplateField> 
                    
                    
                    <asp:TemplateField headertext="Event Name">
                        <ControlStyle Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("EVENT_NAME")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_eventname" text='<%#Eval("EVENT_NAME")%>'
                    runat="server"/>                                            
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    
                    <asp:TemplateField headertext="Held Date">
                        <ControlStyle Width="75px" />
                    <HeaderStyle HorizontalAlign="Center" Width="75px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" Width="75px" VerticalAlign="Middle" 
                            Height="30px"/>
                    <ItemTemplate> <%#Eval("HELD_DATE")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_helddate" text='<%#Eval("HELD_DATE")%>'
                    runat="server"/>    
                        <asp:CalendarExtender ID="ce_events" runat="server" TargetControlID="txt_helddate" PopupButtonID="txt_helddate">
                        </asp:CalendarExtender>
                                                            
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField headertext="Description">
                        <ControlStyle  Width="150px" />
                    <HeaderStyle HorizontalAlign="Center" Width="150px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("DESCRIPTION")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_description" text='<%#Eval("DESCRIPTION")%>'
                    runat="server"/>                                            
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    
                    <asp:TemplateField headertext="Organizer">
                        <ControlStyle Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("ORGANIZER")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_organizer" text='<%#Eval("ORGANIZER")%>'
                    runat="server"/>                                            
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField headertext="Faced Issues">
                        <ControlStyle  Width="150px" />
                    <HeaderStyle HorizontalAlign="Center" Width="150px" VerticalAlign="Middle" 
                            Height="30px" />
                    <ItemStyle HorizontalAlign="Center" Width="150px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("FACED_ISSUES")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_facedissues" text='<%#Eval("FACED_ISSUES")%>'
                    runat="server"/>                                            
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                    <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit"
                    Text="Edit"/>       
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:LinkButton ID="btnupdate" runat="server"
                    CommandName="Update" Text="Update" />
                    <asp:LinkButton ID="btncancel" runat="server"
                    CommandName="Cancel" Text="Cancel"/>       
                    </EditItemTemplate>             
                        <ControlStyle Width="50px" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" 
                            Height="30px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                    </asp:TemplateField>
                    
                    
                        <asp:TemplateField HeaderText="Delete" ControlStyle-Width="100px">
                        <ItemTemplate>
                        <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete"/> 
                       <asp:ModalPopupExtender ID="mpe_events" runat="server"
    TargetControlID="btndelete"
    PopupControlID="DivDeleteConfirmation"
    cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay"
    popupdraghandlecontrolid="PopupHeader" drag="true"
    backgroundcssclass="ModalPopupBG">  
    </asp:ModalPopupExtender>   
    
    <asp:ConfirmButtonExtender ID="cbe_events" runat="server"
    targetcontrolid="btndelete" enabled="True" 
	displaymodalpopupid="mpe_events"> 
    </asp:ConfirmButtonExtender>          
                        </ItemTemplate>
                        <ControlStyle Width="50px"/>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" 
                                Height="30px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                        </asp:TemplateField>
                        

                            
                    </Columns>
                    
                    </asp:GridView>
                    
                    
                    
                    
                    
                    
                    
                    
                    
                </td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:ToolkitScriptManager ID="tsm_events" runat="server">
                    </asp:ToolkitScriptManager>
                    
                    &nbsp;</td>
                <td class="style15">
                    &nbsp;</td>
                <td class="style1">
                
                    <asp:Panel ID="DivDeleteConfirmation" class="popupConfirmation"   runat="server"
                    style="display: none">
                    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                Confirmation !!! </div>
            <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
            </div>
        </div>
        <div class="popup_Body">
            <p>
                Are you sure that  you want to delete this Record?
            </p>
        </div>
        <div class="popup_Buttons">
            <input id="ButtonDeleleOkay" type="button" value="Okay" />
            <input id="ButtonDeleteCancel" type="button" value="Cancel" />
        </div>
    </div>
                    </asp:Panel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

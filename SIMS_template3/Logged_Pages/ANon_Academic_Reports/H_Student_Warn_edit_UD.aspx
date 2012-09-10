<%@ Page Language="C#" AutoEventWireup="true" CodeFile="H_Student_Warn_edit_UD.aspx.cs" Inherits="Student_Warn_edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<link href="Nortifications/CSS/Confirmation.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="DeepASPImpromptuCalling.js" type="text/javascript"></script>

    <script src="pirobox.js" type="text/javascript"></script>

    <script src="jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="jquery-1.5.1.js" type="text/javascript"></script>

    <script src="Jquery-Impromptu.3.3.js" type="text/javascript"></script>
    <script src="jquery.tools.js" type="text/javascript"></script>

    <link href="Style.css" rel="stylesheet" type="text/css" />

    <title>Untitled Page</title>
    <style type="text/css">
        

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 525px; width: 900px">
    
        <table style="width: 100%; height: 525px;">
            <tr>
                <td class="style1">
                    <asp:Label ID="lbl_grade" runat="server" Text="Grade :" Font-Names="Arial" 
                        Font-Size="Medium"></asp:Label>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="ddl_grade" runat="server" Height="25px" Width="190px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddl_grade_SelectedIndexChanged" Font-Names="Arial" 
                        Font-Size="Medium">
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <asp:Label ID="lbl_class" runat="server" Text="Class :" Font-Names="Arial" 
                        Font-Size="Medium" Font-Strikeout="False"></asp:Label>
                </td>
                <td class="style1">
                    <asp:DropDownList ID="ddl_class" runat="server" Height="25px" Width="190px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddl_class_SelectedIndexChanged" Font-Names="Arial" 
                        Font-Size="Medium">
                    </asp:DropDownList>
                </td>
                <td class="style1">
                    <asp:Label ID="lbl_student" runat="server" Text="Student :" Font-Names="Arial" 
                        Font-Size="Medium"></asp:Label>
                </td>
                <td class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddl_student" runat="server" Height="25px" Width="190px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddl_student_SelectedIndexChanged" Font-Names="Arial" 
                        Font-Size="Medium">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="6">
                    <asp:GridView ID="gv_warning" runat="server" Height="415px" Width="900px"
                    autogeneratecolumns="False"
BorderColor="White" BorderStyle="Ridge"
CellSpacing="1" CellPadding="3" GridLines="None"
BackColor="White" BorderWidth="2px"
emptydatatext="No data available." DataKeyNames="ADMISSION_NO" 
Font-Names="Arial" Font-Size="Small" AllowPaging="True" 
                        onpageindexchanging="gv_warning_PageIndexChanging" 
                        onrowcancelingedit="gv_warning_RowCancelingEdit" 
                        onrowdatabound="gv_warning_RowDataBound" onrowdeleting="gv_warning_RowDeleting" 
                        onrowediting="gv_warning_RowEditing" onrowupdating="gv_warning_RowUpdating" 
                        PageSize="8" >

                        <PagerSettings PageButtonCount="5" />

<Columns>
<asp:BoundField DataField="ADMISSION_NO" HeaderText="Admission No"
                  ReadOnly="true">
    <ControlStyle Width="100px" />
    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="30px" 
        Width="100px" />
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
</asp:BoundField>

<asp:TemplateField headertext="Warning Type">
    <ControlStyle Width="100px" />
    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
    <ItemTemplate> <%#Eval("WARNING_CODE")%></ItemTemplate>
    <EditItemTemplate>
     <asp:DropDownList ID="ddl_warningcode" runat="server" >               
        </asp:DropDownList>                               
    </EditItemTemplate>                   
</asp:TemplateField>

<asp:TemplateField headertext=" Warning Level">
    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    <ItemTemplate> <%#Eval("LEVEL_CODE")%></ItemTemplate>
    <EditItemTemplate>
     <asp:DropDownList ID="ddl_level" runat="server" >               
        </asp:DropDownList>                               
    </EditItemTemplate>                   
</asp:TemplateField>

<asp:TemplateField headertext="Warned Date">
    <ControlStyle Width="100px" />
    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
        Height="30px"/>
    <ItemTemplate> <%#Eval("WARN_DATE")%></ItemTemplate>
    <EditItemTemplate>
      <asp:TextBox id="txt_date" text='<%#Eval("WARN_DATE")%>'
        runat="server"/>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date" PopupButtonID="txt_date">
        </asp:CalendarExtender>
                                                    
    </EditItemTemplate>                   
</asp:TemplateField>

<asp:TemplateField headertext="Description">
    <ControlStyle Width="350px" />
    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
    <ItemStyle HorizontalAlign="Center" Width="350px" VerticalAlign="Middle"/>
    <ItemTemplate> <%#Eval("NOTE")%></ItemTemplate>
    <EditItemTemplate>
      <asp:TextBox id="txt_note" text='<%#Eval("NOTE")%>'
        runat="server"/>                                            
    </EditItemTemplate>                   
</asp:TemplateField>

<asp:TemplateField HeaderText="Inform Parents" ControlStyle-Width="50px">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkStatus" runat="server"
                            Checked='<%# Convert.ToBoolean(Eval("INFORM_PARENTS")) %>' />
                    </ItemTemplate>                   
                    <ControlStyle Width="25px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="30px" 
                        Width="25px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
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
                    <ControlStyle Width="75px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
</asp:TemplateField>

                                                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="100px">
                        <ItemTemplate>
                        <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete"/> 
                          <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="btndelete"
    PopupControlID="DivDeleteConfirmation"
    cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay"
    popupdraghandlecontrolid="PopupHeader" drag="true"
    backgroundcssclass="ModalPopupBG">  
    </asp:ModalPopupExtender>   
    
    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
    targetcontrolid="btndelete" enabled="True" 
	displaymodalpopupid="ModalPopupExtender1"> 
    </asp:ConfirmButtonExtender> 
                        
                                
                        </ItemTemplate>
                        <ControlStyle Width="75px"/>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="30px" 
                                                        Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        </asp:TemplateField>

</Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    
                    <asp:ToolkitScriptManager ID="tsm_warning" runat="server">
                    </asp:ToolkitScriptManager>
                    
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
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
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

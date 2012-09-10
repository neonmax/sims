<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="School_Event_UD.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="School Event" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Confirmation.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/DeepASPImpromptuCalling.js" type="text/javascript"></script>

    <script src="../../lib/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../../lib/jquery-1.3.2.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
               <div id="menu">
                <ul>
                    <li><a href="../Home.aspx">Home</a></li>
                    <li><a href="../AboutUs.aspx" class="active">About Us</a></li>
                    <li><a href="../ContactUs.aspx">Contact Us</a></li>
                </ul>
            </div>
                   <div class="ReportBody">
                    <div class="ReportHeader">
                        Student Wrning Details
                    </div>
                    <div class="ReportDesc">
                        Edit/Delete Student Warning Records
                    </div>
                </div>
        </div>
        <div class="body">
            <div class="form">            
             
                <div class="ParaMiddleH">
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:ToolkitScriptManager ID="tsm_events" runat="server">
                            </asp:ToolkitScriptManager>
                        </div>
                          <div class="fieldsCaptionCell">
                          </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        
                            <asp:TextBox ID="txt_search" runat="server" Class="FormTxtBox " Width="195px"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_txt_search" runat="server" TargetControlID="txt_search"
                                WatermarkText="Event Name Here">
                            </asp:TextBoxWatermarkExtender>
                            <asp:Button ID="btn_search" runat="server" Height="26px" Text="Search" Width="100px"
                                OnClick="btn_search_Click" CssClass="buttonText"/>
                    </div>
                    <div class="paraSpace">
                    </div>

                    <asp:GridView ID="gv_events" runat="server" Height="401px" Width="100%" AutoGenerateColumns="False"
                        BorderColor="White" BorderStyle="Ridge" CellSpacing="1" CellPadding="3" GridLines="Horizontal"
                        BackColor="White" BorderWidth="2px" EmptyDataText="No data available." DataKeyNames="EVENT_ID"
                        Font-Names="Arial" Font-Size="Small" OnRowDataBound="gv_events_RowDataBound"
                        OnRowEditing="gv_events_RowEditing" AllowPaging="True" OnPageIndexChanging="gv_events_PageIndexChanging"
                        OnRowCancelingEdit="gv_events_RowCancelingEdit" OnRowDeleting="gv_events_RowDeleting"
                        OnRowUpdating="gv_events_RowUpdating" PageSize="8">
                        <PagerSettings PageButtonCount="5" />
                        <Columns>
                            <asp:BoundField DataField="EVENT_ID" HeaderText="Event ID" ReadOnly="true">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Main Type">
                                <ControlStyle Width="75px" />
                                <HeaderStyle HorizontalAlign="Center" Width="75px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                                <ItemTemplate>
                                    <%#Eval("EVENT_TYPE_MAST")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_master" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Type">
                                <ControlStyle Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                <ItemTemplate>
                                    <%#Eval("EVENT_TYPE_SUB")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddl_sub" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event Name">
                                <ControlStyle Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <%#Eval("EVENT_NAME")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_eventname" Text='<%#Eval("EVENT_NAME")%>' runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Held Date">
                                <ControlStyle Width="50px" />
                                <HeaderStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" VerticalAlign="Middle" Height="30px" />
                                <ItemTemplate>
                                    <%#Eval("HELD_DATE")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_helddate" Text='<%#Eval("HELD_DATE")%>' runat="server" />
                                    <asp:CalendarExtender ID="ce_events" runat="server" TargetControlID="txt_helddate"
                                        PopupButtonID="txt_helddate">
                                    </asp:CalendarExtender>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ControlStyle Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <%#Eval("DESCRIPTION")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_description" Text='<%#Eval("DESCRIPTION")%>' runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Organizer">
                                <ControlStyle Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <%#Eval("ORGANIZER")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_organizer" Text='<%#Eval("ORGANIZER")%>' runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Faced Issues">
                                <ControlStyle Width="120px" />
                                <HeaderStyle HorizontalAlign="Center" Width="120px" VerticalAlign="Middle" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" Width="120px" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <%#Eval("FACED_ISSUES")%></ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_facedissues" Text='<%#Eval("FACED_ISSUES")%>' runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" />
                                    <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <ControlStyle Width="50px" ForeColor="#0066FF" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete" />
                                    <asp:ModalPopupExtender ID="mpe_events" runat="server" TargetControlID="btndelete"
                                        PopupControlID="DivDeleteConfirmation" CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay"
                                        PopupDragHandleControlID="PopupHeader" Drag="true" BackgroundCssClass="ModalPopupBG">
                                    </asp:ModalPopupExtender>
                                    <asp:ConfirmButtonExtender ID="cbe_events" runat="server" TargetControlID="btndelete"
                                        Enabled="True" DisplayModalPopupID="mpe_events">
                                    </asp:ConfirmButtonExtender>
                                </ItemTemplate>
                                <ControlStyle Width="50px" ForeColor="#0066FF" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" Height="30px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle ForeColor="#0066FF" />
                        <HeaderStyle BackColor="#333399" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCFFF7" />
                    </asp:GridView>


                    
                    <asp:Panel ID="DivDeleteConfirmation" class="popupConfirmation" runat="server" Style="display: none">
                        <div class="popup_Container">
                            <div class="popup_Titlebar" id="PopupHeader">
                                <div class="TitlebarLeft">
                                    Confirmation !!!
                                </div>
                                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                </div>
                            </div>
                            <div class="popup_Body">
                                <p>
                                    Are you sure that you want to delete this Record?
                                </p>
                            </div>
                            <div class="popup_Buttons">
                                <input id="ButtonDeleleOkay" type="button" value="Ok" />
                                <input id="ButtonDeleteCancel" type="button" value="Cancel" />
                            </div>
                        </div>
                    </asp:Panel>
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
                All rights reserved                 <!-- Please DO NOT remove the following notice -->
                <p>
                    Design by SLIIT SEWD 02</p>
                <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

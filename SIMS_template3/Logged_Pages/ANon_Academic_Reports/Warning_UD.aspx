<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Warning_UD.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="Student Warning" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Confirmation.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="wrap">
        
            <asp:ToolkitScriptManager ID="tsm_warnings" runat="server">
            </asp:ToolkitScriptManager>
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
        <div class="ReportBody">
                    <div class="ReportHeader">
                        Student Wrning Details
                    </div>
                    <div class="ReportDesc">
                        Edit/Delete Student Warning Records
                    </div>
                </div>
        
        <div class="body">
            <div class="form">
                <div class="ParaMiddleH">
                    <div class="paraSpace">
                    </div>
                    

                    <div class="field_3_Row">

               <div class="fieldsCaptionCell">
                            <asp:Label ID="Label2" class="RLable" runat="server" Text="Grade :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_grade" runat="server" Width="180px" class="RTxt" AutoPostBack="True"
                                OnSelectedIndexChanged="ddl_grade_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label3" class="RLable"  runat="server" Text="Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddl_class" runat="server" class="RTxt" Width="180px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddl_class_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>                     
                        
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label4" runat="server"  class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <asp:DropDownList ID="ddl_student" class="RTxt" runat="server" Width="180px" AutoPostBack="True"
                            OnSelectedIndexChanged="ddl_student_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    
                    
                    
                    <div class="paraSpace">
                    </div>
                   
                        <asp:GridView ID="gv_warning" runat="server" Height="415px" Width="100%" AutoGenerateColumns="False"
                            BorderColor="White" BorderStyle="Ridge" CellSpacing="1" 
                        CellPadding="3" GridLines="None"
                            BackColor="White" BorderWidth="2px" EmptyDataText="No data available." DataKeyNames="ADMISSION_NO"
                            Font-Names="Arial" Font-Size="Small" AllowPaging="True" OnPageIndexChanging="gv_warning_PageIndexChanging"
                            OnRowCancelingEdit="gv_warning_RowCancelingEdit" OnRowDataBound="gv_warning_RowDataBound"
                            OnRowDeleting="gv_warning_RowDeleting" 
                        OnRowEditing="gv_warning_RowEditing" 
                        OnRowUpdating="gv_warning_RowUpdating" PageSize="8">
                            <PagerSettings PageButtonCount="5" />
                            <Columns>
                                <asp:BoundField DataField="ADMISSION_NO" HeaderText="Admission No" ReadOnly="true">
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="30px" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Warning Type">
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                    <ItemTemplate>
                                        <%#Eval("WARNING_CODE")%></ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_warningcode" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Warning Level">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <%#Eval("LEVEL_CODE")%></ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_level" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Warned Date">
                                    <ControlStyle Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" Height="30px" />
                                    <ItemTemplate>
                                        <%#Eval("WARN_DATE")%></ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_date" Text='<%#Eval("WARN_DATE")%>' runat="server" />
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_date"
                                            PopupButtonID="txt_date">
                                        </asp:CalendarExtender>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ControlStyle Width="350px" />
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" Width="350px" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <%#Eval("NOTE")%></ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt_note" Text='<%#Eval("NOTE")%>' runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inform Parents" ControlStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStatus" runat="server" Checked='<%# Convert.ToBoolean(Eval("INFORM_PARENTS")) %>' />
                                    </ItemTemplate>
                                    <ControlStyle Width="25px" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="30px" Width="25px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" />
                                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel" />
                                    </EditItemTemplate>
                                    <ControlStyle Width="75px" ForeColor="#0066FF" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="75px" 
                                        ForeColor="Black" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ControlStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="Delete" Text="Delete" />
                                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btndelete"
                                            PopupControlID="DivDeleteConfirmation" CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay"
                                            PopupDragHandleControlID="PopupHeader" Drag="true" BackgroundCssClass="ModalPopupBG">
                                        </asp:ModalPopupExtender>
                                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btndelete"
                                            Enabled="True" DisplayModalPopupID="ModalPopupExtender1">
                                        </asp:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ControlStyle Width="75px" ForeColor="#0066FF" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="30px" Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle ForeColor="#0066FF" />
                            <HeaderStyle BackColor="#333399" ForeColor="White" />
                            <AlternatingRowStyle BackColor="#CCFFF7" />
                        </asp:GridView>
                  
                </div>
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

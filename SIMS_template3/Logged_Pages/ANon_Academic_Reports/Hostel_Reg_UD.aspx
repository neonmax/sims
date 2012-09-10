<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Hostel_Reg_UD.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="School Event" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Confirmation.css" rel="stylesheet" type="text/css" />
    <link href="Heshan_Nortification/Style.css" rel="stylesheet" type="text/css" />
    <script src="Heshan_Nortification/DeepASPImpromptuCalling.js" type="text/javascript"></script>
    <script src="Heshan_Nortification/jquery-1.5.1.js" type="text/javascript"></script>
    <script src="Heshan_Nortification/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <title>Calendar Extender</title>
    <script type="text/javascript">
    function checkDate(sender,args)
{
 if (sender._selectedDate > new Date())
            {
                alert("You cannot select a day greater than today!");
                sender._selectedDate = new Date(); 
                // set the date back to the current date
sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
}
    </script>
    
    <script type="text/javascript">

    var message = "Function Disabled!";
    function clickIE4() {
        if (event.button == 2) {
            alert(message);
            return false;
        }
    }
    function clickNS4(e) {
        if (document.layers || document.getElementById && !document.all) {
            if (e.which == 2 || e.which == 3) {
                alert(message);
                return false;
            }
        }
    }
    if (document.layers) {
        document.captureEvents(Event.MOUSEDOWN);
        document.onmousedown = clickNS4;
    }
    else if (document.all && !document.getElementById) {
        document.onmousedown = clickIE4;
    }
    document.oncontextmenu = new Function("alert(message);return false")
</script>
    
    
    

   
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
                        Student Hostel Accomodation Details
                    </div>
                    <div class="ReportDesc">
                        Edit / Delete Student Hostel Accomodation
                    </div>
                </div>
        </div>
        

         <div class="body">
         
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                         <div class="form">            
             
                <div class="ParaMiddleH">
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:ToolkitScriptManager ID="tsm_hostel_edit" runat="server">
                            </asp:ToolkitScriptManager>
                        </div>
                          <div class="fieldsCaptionCell">
                          </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        
                            <asp:TextBox ID="txt_search" runat="server" Class="FormTxtBox " 
                            Width="195px" MaxLength="10"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="wme_txt_search" runat="server" TargetControlID="txt_search" 
                                WatermarkText="Search By  Registed Year">
                            </asp:TextBoxWatermarkExtender>
                            
                            <asp:Button ID="btn_search" runat="server" Height="26px" Text="Search" Width="100px"
                                 CssClass="buttonText" onclick="btn_search_Click1" Font-Bold="True"/>
                    </div>

                                                <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label1" runat="server" class="RLable" Text="
                                    "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_grade_check"  ForeColor="Red" class="RLable" runat="server" Text=" "></asp:Label>
                                </div>
                                
                                    <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label2" runat="server" class="RLable" Text=" "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_class_check"  ForeColor="Red" class="RLable" runat="server" Text=" "></asp:Label>
                                </div>
                                
                                             <div class="fieldsCaptionCell">
                                    <asp:Label ID="lbl_status"  ForeColor="Red" class="RLable" runat="server" Font-Bold="True" 
                                                     Font-Names="Arial"></asp:Label>
                                </div>
                                
                            </div>


                    <asp:GridView ID="gv_UD_hostel" runat="server" Height="401px" Width="100%" AutoGenerateColumns="False"
                        BorderColor="White" BorderStyle="Ridge" CellSpacing="1" CellPadding="3" GridLines="Horizontal"
                        BackColor="White" BorderWidth="2px" 
                        EmptyDataText="No Matching Records Found" DataKeyNames="ADMISSION_NO"
                        Font-Names="Arial" Font-Size="Small" AllowPaging="True" PageSize="12" 
                        onpageindexchanging="gv_UD_hostel_PageIndexChanging" 
                        onrowcancelingedit="gv_UD_hostel_RowCancelingEdit" 
                        onrowdeleting="gv_UD_hostel_RowDeleting" onrowediting="gv_UD_hostel_RowEditing" 
                        onrowupdating="gv_UD_hostel_RowUpdating" 
                        ShowFooter="True"  
                       >
                        <PagerSettings PageButtonCount="3" />
                        <EmptyDataRowStyle Font-Names="Arial" Font-Size="Large" ForeColor="Red" />
                        <Columns>
                    <asp:BoundField DataField="ADMISSION_NO" HeaderText="Admission No" 
                    ReadOnly="true">
                    <ControlStyle Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"  />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                                        <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Regristration No" 
                    ReadOnly="true">
                    <ControlStyle Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"  />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                    
                                        <asp:BoundField DataField="DATE_FROM" HeaderText="From Date" 
                    ReadOnly="true">
                    <ControlStyle Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"  />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                    </asp:BoundField>
                          
                            
                                        <asp:TemplateField headertext=" Date To">
                    <ControlStyle  Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                             />
                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("DATE_TO")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txtto" text='<%#Eval("DATE_TO")%>' MaxLength="10"
                    runat="server"/>                     
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtto" OnClientDateSelectionChanged="checkDate" >
                    </asp:CalendarExtender>                                                                                                           
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    

                    <asp:TemplateField headertext="Prefect Year">
                    <ControlStyle  Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                            />
                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("HOSTEL_PREFECT_YEAR")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_prefect" text='<%#Eval("HOSTEL_PREFECT_YEAR")%>'
                    runat="server"/>  
                                                                                     
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    
                    <asp:TemplateField headertext="D_Head Prefect Year">
                    <ControlStyle  Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                             />
                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("HOSTEL_DHPREFECT_YEAR")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_dh" text='<%#Eval("HOSTEL_DHPREFECT_YEAR")%>'
                    runat="server"/>  
                                                                                                                   
                    </EditItemTemplate>                   
                    </asp:TemplateField>
                    <asp:TemplateField headertext="Head Prefect Year">
                    <ControlStyle  Width="90px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle" 
                            />
                    <ItemStyle HorizontalAlign="Center" Width="100px" VerticalAlign="Middle"/>
                    <ItemTemplate> <%#Eval("HOSTEL_HPREFECT_YEAR")%></ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox id="txt_hp" text='<%#Eval("HOSTEL_HPREFECT_YEAR")%>'
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
                        <ControlStyle Width="80px" ForeColor="#0033CC" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" 
                            Height="30px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" 
                            ForeColor="Blue" />
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
                        <ControlStyle Width="50px" ForeColor="#0033CC"/>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" 
                                Height="30px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" 
                             ForeColor="#0033CC" />
                        </asp:TemplateField>
                        </Columns>
                        <FooterStyle ForeColor="#0066FF" />
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
                                <input id="ButtonDeleleOkay" type="button" value="Delete" />
                                <input id="ButtonDeleteCancel" type="button" value="Cancel" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="ParaBottomH">
                </div>
                <br />
            </div>
             
             </ContentTemplate>
                 <Triggers>
                     <asp:AsyncPostBackTrigger ControlID="gv_UD_hostel" EventName="RowEditing" />
                     <asp:AsyncPostBackTrigger ControlID="gv_UD_hostel" 
                         EventName="RowCancelingEdit" />
                     <asp:AsyncPostBackTrigger ControlID="gv_UD_hostel" EventName="RowUpdating" />
                     <asp:AsyncPostBackTrigger ControlID="gv_UD_hostel" EventName="RowDeleting" />
                     <asp:AsyncPostBackTrigger ControlID="gv_UD_hostel" 
                         EventName="PageIndexChanging" />
                     <asp:AsyncPostBackTrigger ControlID="btn_search" EventName="Click" />
                 </Triggers>
             </asp:UpdatePanel>
         
         

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

<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Hostel_Reg.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log" Title="Student Activity" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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
                    Student Registration 
                </div>
                <div class="ReportDesc">
                       Register Student For Hostel Accomodation                      
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
                                    <asp:DropDownList ID="ddl_grade" 
                                        runat="server" Width="180px" class="RTxt" AutoPostBack="True" CssClass="FormTxtBox"
                                        Height="20px" onselectedindexchanged="ddl_grade_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label3" runat="server" class="RLable" Text="Class :"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:DropDownList ID="ddl_class" 
                                        runat="server" Width="180px" class="RTxt" AutoPostBack="True" CssClass="FormTxtBox"
                                        Height="20px" onselectedindexchanged="ddl_class_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label4" runat="server" class="RLable" Text="Student :"></asp:Label>
                                </div>
                                <asp:DropDownList ID="ddl_student" 
                                    runat="server" Width="180px" class="RTxt" AutoPostBack="True" CssClass="FormTxtBox"
                                    Height="20px" onselectedindexchanged="ddl_student_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label1" runat="server" class="RLable" Text="
                                    "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_grade_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                                
                                    <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label2" runat="server" class="RLable" Text=" "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_class_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                                
                                                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label10" runat="server" class="RLable" Text=" "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_student_check"  ForeColor="Red" class="RLable" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label5" runat="server" class="RLable" Text="ADM NO:"></asp:Label>
                                </div>
                                    <div class="fieldsCaptionCell">
                                    <asp:Label ID="lbl_admission_result" runat="server" class="RLable" Text="[ADMISSION_NO]" ForeColor="Silver"></asp:Label>
                                </div>
                                <div class="fieldsCaptionCell">
                                    
                                </div>
                                                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label8" runat="server" class="RLable" Text="From Date:"></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:TextBox ID="txt_from" runat="server" Class="RTxt" Height="20px"
                                     Width="160px" MaxLength="10"></asp:TextBox>
                                     <asp:ImageButton ID="ibtn_calander" runat="server" Height="16px" ImageUrl="../../images/Calendar_scheduleHS.png"
                                     Width="16px" />
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_from" OnClientDateSelectionChanged="checkDate"
                                     PopupButtonID="ibtn_calander" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    
                                    
                                </div>

                                <div class="fieldsCaptionCell">
                                    
                                </div>
                                <div class="fieldsElementCell">



                                </div>
                            </div>
                            <div class="paraSpace">
                            </div>
                            <div class="paraSpace">
                            </div>
                                                        <div class="field_3_Row">
                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label6" runat="server" class="RLable" Text="
                                    "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    
                                </div>
                                
                                    <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label13" runat="server" class="RLable" Text=" "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    <asp:Label ID="lbl_date_check" runat="server" ForeColor="Red" class="RLable" ></asp:Label>
                                </div>
                                
                                                                <div class="fieldsCaptionCell">
                                    <asp:Label ID="Label15" runat="server" class="RLable" Text=" "></asp:Label>
                                </div>
                                <div class="fieldsElementCell">
                                    
                                </div>
                            </div>

                            <div class="field_3_Row162">
                                <div class="fieldsCaptionCell162">

                                </div>
                                <div class="fieldsElementCell162">

                                </div>
                                <div class="fieldsCaptionCell162">
                                   
                                </div>
                                <div class="fieldsElementCell162">

                                </div>
                                <div class="fieldsCaptionCell162">
                                </div>
                            </div>

                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btn_register" runat="server" Text="Register Student" Height="30px" Width="142px"
                                CssClass="buttonText" ValidationGroup="submit" 
                                onclick="btn_register_Click" />
                                
                                
                                
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Button ID="btn_clear" runat="server" Height="30px" Width="142px" Text="Clear"
                                 CssClass="buttonText" onclick="btn_clear_Click" />
                        </div>
                        </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    

                            
                                               
                    
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

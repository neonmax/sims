<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="NewLogReport.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="General Academic" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of Calender Toggle By Neon--%>

    <script type="text/javascript" language="javascript">
    function popupCalender() {
       var datefield = document.getElementById('dateField');
       if (dateField.style.display == 'none')
       dateField.style.display= 'block';
       else
       dateField.style.display='none';
      
    }
    
   function popupCalender1() {
        var datefield1 = document.getElementById('dateField1');
       if (dateField1.style.display == 'none')
       dateField1.style.display= 'block';
       else
       dateField1.style.display='none';
    }
    
 
    </script>

    <%--End of Calender Toggle By Neon--%>
    <link href="../../Notifications/CSS/Style.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../../lib/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <script src="../../lib/DeepASPImpromptuCalling.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="wrap">
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
        <asp:ScriptManager ID="HmScptMng" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="HmUpPnl" runat="server">
            <ContentTemplate>
                <div class="ReportBody">
                    <div class="ReportHeader">
                        Appoinments Log Report
                    </div>
                    <div class="ReportDesc">
                        Log Report of Appoinments to Principal                     
                        </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                    
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Start Date :" ID="Label10"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtDate" runat="server" Width="165px" CssClass="FormTxtBox "></asp:TextBox>
                            <img id="img1" src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender()">
                        </div>
                         <div class="fieldsCaptionCell">
                             
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label11" runat="server" class="RLable" Text="End Date :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                           <asp:TextBox ID="txtDate1" runat="server" Width="165px" CssClass="FormTxtBox " 
                                ontextchanged="txtDate1_TextChanged"></asp:TextBox>
                            <img id="img2" src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender1()">
                        </div>
                        
                 
                        
                    </div>
                    
                    
                      <div class="FormRow">
                       <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">
                           <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        
                         <div class="fieldsCaptionCell">
                           
                        </div>  <div class="fieldsCaptionCell">
                           
                        </div>
                        <div class="fieldsElementCell">
                               <asp:Label ID="lblError2" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                      </div>
                    
                    
                    <div class="field_3_Row162appauto">
                  
                    
                    <div id="dateField" style="display: none;  padding-left: 100px";>
                         <asp:Calendar ID="MedDateCal" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                                            OnSelectionChanged="MedDateCal_SelectionChanged">
                                            <SelectedDayStyle ForeColor="#0000CC" />
                                            <WeekendDayStyle ForeColor="Red" />
                                            <OtherMonthDayStyle ForeColor="#999966" />
                                        </asp:Calendar>
                    </div>
                    
                  
                    
                    
                    
                    <div id="dateField1" style="display: none;  padding-left: 500px;">
                         <asp:Calendar ID="MedDateCal1" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                                            OnSelectionChanged="MedDateCal1_SelectionChanged">
                                            <SelectedDayStyle ForeColor="#0000CC" />
                                            <WeekendDayStyle ForeColor="Red" />
                                            <OtherMonthDayStyle ForeColor="#999966" />
                                        </asp:Calendar>

                    </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    
                    <div class="RepPanelauto">
                        <CR:CrystalReportViewer  ID="crvReportViewer" runat="server" AutoDataBind="true"
                            DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                    </div>
               
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

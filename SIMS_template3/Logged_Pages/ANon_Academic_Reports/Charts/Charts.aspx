<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true" CodeFile="Charts.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info" Title="Extra Curricular" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .style3
    {
        width: 143px;
    }
    .style1
    {
        width: 145px;
    }
    .style2
    {
        width: 143px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="wrap">
            <div id="header">
                
                    <div id="logo2">
                     <br />
                        <br />
                        <br />
                        <asp:Label ID="Text1" runat="server" Text="Session Name" Font-Bold="False" 
                            Font-Names="Arial" Font-Size="Small" ForeColor="White"></asp:Label>   
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
                    <div class="ReportHeader" ID="lblError">
                        Report Generator
                    </div>
                    <div class="ReportDesc">
                        Student Participation for Extra Curricular Activities Report&nbsp;
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <div class="RepOptions">
                        <table class="style3" width="150px">
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="lbl_heading01" runat="server" Text="Student Achivements"></asp:Label>
                                </td>
                                <td class="style2">
                                    &nbsp;</td>
                                <td rowspan="22">
                                    <CR:CrystalReportViewer ID="crv_studentParticipation" runat="server" 
                                        AutoDataBind="true" BestFitPage="False" Height="500px" Width="650px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="btn_SA_individual" runat="server" 
                                         Text="Individual Progress" Width="140px" 
                                        onclick="btn_SA_individual_Click1" />
                                </td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddl_studentBase" runat="server" AutoPostBack="true" 
                                        Height="20px" 
                                        Width="140px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:DropDownList ID="ddl_allstudentId" runat="server" AutoPostBack="true" 
                                        Height="20px"  
                                        Width="140px" 
                                        onselectedindexchanged="ddl_allstudentId_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="btn_SA_overoll" runat="server" 
                                        Text="OverRoll Progress" Width="140px" onclick="btn_SA_overoll_Click1" />
                                </td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddl_over_base" runat="server" AutoPostBack="true" 
                                        Height="22px" 
                                        Width="140px" onselectedindexchanged="ddl_over_base_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddl_overSubbase" runat="server" AutoPostBack="true" 
                                        Height="22px"  
                                        Width="140px" 
                                        onselectedindexchanged="ddl_overSubbase_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="btn_view" runat="server" 
                                        Text="Button" Visible="False" />
                                </td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddl_overSubbase02" runat="server" Height="22px" 
                                        Width="140px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:ImageButton ID="ibtn_viewReport" runat="server" Height="48px" 
                                        ImageUrl="~/Logged_Pages/ANon_Academic_Reports/Charts/icons/Clip.jpg" 
                                         Width="140px" onclick="ibtn_viewReport_Click1" />
                                </td>
                                <td class="style2">
                                    <asp:ImageButton ID="ibtn_downloadReport" runat="server" Height="48px" 
                                        ImageUrl="~/icons/download.jpg"  
                                        Width="140px" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="lbl_heading02" runat="server" Text="Generate Charts"></asp:Label>
                                </td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="btn_chart_sports" runat="server" 
                                         Text="Sports" Width="140px" onclick="btn_chart_sports_Click1" />
                                </td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddl_chart_Basetype" runat="server" AutoPostBack="true" 
                                        Height="24px" 
                                        Width="140px" 
                                        onselectedindexchanged="ddl_chart_Basetype_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <asp:Button ID="btn_charts_extra" runat="server" 
                                        Text="ExtraCurricular Activity" Width="140px" 
                                        onclick="btn_charts_extra_Click1" />
                                </td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddl_chartsSubbase" runat="server" AutoPostBack="true" 
                                        Height="17px" Width="140px" 
                                        onselectedindexchanged="ddl_chartsSubbase_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <br />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            <%--
            <div class="body">
                <div class="headline_holder">
                    <asp:Label class="headline" runat="server" Text="Label">Report Generator  </asp:Label>
                </div>
                <div class="report_type">
                
                    Best performance of the students<asp:Label ID="lblError" class="form_label" runat="server" ></asp:Label>
                       
                        </div>
                <div class="form">
                    <br />
                   <div class="form_fields">
                       <asp:Label class="form_label" runat="server" Text="Examination :"></asp:Label>
                       <asp:DropDownList ID="ddlExamination" runat="server" Height="20px" Width="190px">
                                <asp:ListItem Value="empty">Select Examination</asp:ListItem>
                                <asp:ListItem Value="al">G.C.E. A/L Examination</asp:ListItem>
                                <asp:ListItem Value="ol">G.C.E. O/L Examination</asp:ListItem>
                            </asp:DropDownList>
                   </div>
                   
                   <div class="form_fields">
                       <asp:Label ID="Label1" class="form_label" runat="server" Text="Year :"></asp:Label>
                      <asp:DropDownList ID="ddlYear" runat="server" Height="20px" Width="190px" 
                           onselectedindexchanged="ddlYear_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">Select Year</asp:ListItem>
                                <asp:ListItem Value="2000">2000</asp:ListItem>
                                <asp:ListItem Value="2001">2001</asp:ListItem>
                                <asp:ListItem Value="2002">2002</asp:ListItem>
                                <asp:ListItem Value="2003">2003</asp:ListItem>
                                <asp:ListItem Value="2004">2004</asp:ListItem>
                                <asp:ListItem Value="2005">2005</asp:ListItem>
                                <asp:ListItem Value="2006">2006</asp:ListItem>
                                <asp:ListItem Value="2007">2007</asp:ListItem>
                                <asp:ListItem Value="2008">2008</asp:ListItem>
                                <asp:ListItem Value="2009">2009</asp:ListItem>
                                <asp:ListItem Value="2010">2010</asp:ListItem>
                                <asp:ListItem Value="2011">2011</asp:ListItem>
                                <asp:ListItem Value="2012">2012</asp:ListItem>
                            </asp:DropDownList>
                   </div>
                   
                    <br />
                    <div>
                   
                    </div>
                    <br />
                    <div class="report"><!--space for report -->
                    
                        <br />
                        <CR:CrystalReportViewer ID="crvReportViewer" runat="server" 
                            AutoDataBind="true" DisplayGroupTree="False" 
                            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
                    
                    </div>
                    
                    
                    
                </div>
                
            
            </div>
            <div class="con_bot">
            
            
            
            </div>--%>
            <div id="footer">
                 <p>All rights reserved </p>
                    <!-- Please DO NOT remove the following notice --><p>Design by SLIIT SEWD 02</p><!-- end of copyright notice-->
            </div>
        </div>
        


</asp:Content>



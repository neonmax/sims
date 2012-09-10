<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true" CodeFile="ActivityLog.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info" Title="Activity Log" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
    {
        width: 99%;
        height: 497px;
    }
    .style2
    {
        height: 30px;
    }
    .style11
    {
        height: 37px;
        width: 95px;
    }
    .style12
    {
        height: 37px;
        width: 151px;
    }
    .style13
    {
        height: 18px;
        width: 95px;
    }
    .style14
    {
        height: 18px;
        width: 151px;
    }
    .style15
    {
        width: 95px;
        height: 29px;
    }
    .style16
    {
        width: 151px;
        height: 29px;
    }
    .style17
    {
        height: 35px;
        width: 95px;
    }
    .style18
    {
        height: 35px;
        width: 151px;
    }
    .style26
    {
        height: 35px;
    }
    .style19
    {
        width: 95px;
        height: 68px;
    }
    .style20
    {
        width: 151px;
        height: 68px;
    }
    .style21
    {
        height: 31px;
        }
    .style23
    {
        height: 33px;
        width: 95px;
    }
    .style24
    {
        height: 33px;
        width: 151px;
    }
    .style25
    {
        height: 33px;
    }
    .style8
    {
            width: 95px;
        }
    .style10
    {
        width: 151px;
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
                        Student&#39;s Extra Activity Log
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    <div class="RepOptions">
                        <table class="style1">
                            <tr>
                                <td class="style2" colspan="2">
                                    <asp:Label ID="lbl_insertnewrecord" runat="server" Font-Bold="True" 
                                        Text="Insert New Acttivity"></asp:Label>
                                </td>
                                <td class="style2">
                                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
                                        Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style11">
                                    <asp:Button ID="btn_selectestudents" runat="server" Font-Bold="True" 
                                         Text="Select Student" Width="112px" 
                                        onclick="btn_selectestudents_Click1" />
                                </td>
                                <td class="style12">
                                    <asp:DropDownList ID="ddl_select_insert" runat="server" AutoPostBack="true" 
                                        Height="25px"  
                                        Width="140px">
                                    </asp:DropDownList>
                                </td>
                                <td rowspan="12">
                                    <asp:GridView ID="gv_extracurricular_log" runat="server" 
                                        AutoGenerateColumns="False" BorderStyle="Solid" Height="446px" 
                                         
                                         
                                        Width="691px" onrowcommand="gv_extracurricular_log_RowCommand">
                                        <Columns>
                                            <asp:ButtonField DataTextField="ADMISSION_NO" HeaderText="Admission Number" 
                                                ShowHeader="True" />
                                            <asp:BoundField DataField="ACTIVITY_CODE" HeaderText="Activity Type">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACTIVITYSUB_CODE" HeaderText="Activity">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACTIVITY_YEAR" HeaderText="Year">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ACTIVITY_DESCRIPTION" HeaderText="Description">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MEMBERSHIP_NO" HeaderText="Membership Number">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DATE_OF_REGISTRATION" HeaderText="Registerd Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Admission No
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="style13">
                                    <asp:Label ID="lbl_selected_further" runat="server" Text="Selected Student"></asp:Label>
                                </td>
                                <td class="style14">
                                    <asp:Label ID="lbl_selected_student" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style15">
                                    <asp:Label ID="lbl_selectactivitytype" runat="server" Font-Bold="True" 
                                        Text="Select Activity Type"></asp:Label>
                                </td>
                                <td class="style16">
                                    <asp:DropDownList ID="ddl_selectactivitytype" runat="server" 
                                        AutoPostBack="true" Height="25px" Width="137px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    <asp:Label ID="lbl_activtyname" runat="server" Font-Bold="True" 
                                        Text="Activity Name"></asp:Label>
                                </td>
                                <td class="style18">
                                    <asp:TextBox ID="txt_insertactivityname" runat="server" Height="25px" 
                                        Width="140px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style26" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style19">
                                    <asp:Label ID="lbl_description" runat="server" Font-Bold="True" 
                                        Text="Description"></asp:Label>
                                </td>
                                <td class="style20">
                                    <asp:TextBox ID="txt_insertdescription" runat="server" Height="57px" 
                                        Width="139px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style21" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style23">
                                    <asp:Button ID="btn_insert" runat="server" Font-Bold="True" 
                                         Text="Insert Record" Width="101px" onclick="btn_insert_Click" />
                                </td>
                                <td class="style24">
                                    <asp:Button ID="btn_edit" runat="server" Font-Bold="True" 
                                         Text="Edit Record" Width="130px" onclick="btn_edit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style25" colspan="2">
                                    <asp:Label ID="lbl_viewactivityrecord" runat="server" Font-Bold="True" 
                                        Text="Search Activity Records"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    <asp:Button ID="btn_selectstudent" runat="server" Font-Bold="True" 
                                         Text="Select Student" Width="104px" onclick="btn_selectstudent_Click" />
                                </td>
                                <td class="style10">
                                    <asp:DropDownList ID="ddl_view_delete_update" runat="server" 
                                        AutoPostBack="true" Height="25px" 
                                         
                                        Width="140px" 
                                        onselectedindexchanged="ddl_view_delete_update_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style10">
                                    <asp:Button ID="btn_delete" runat="server" Font-Bold="True" 
                                       Text="Delete Record" Width="140px" onclick="btn_delete_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style10">
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



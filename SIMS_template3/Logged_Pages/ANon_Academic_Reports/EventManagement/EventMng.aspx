<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true" CodeFile="EventMng.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info" Title="Character Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                        Event Manager
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    
                    <div class="RepOptions">
                    
                        <div class="EMcontainer">
                        
                            <div class="EMcommon">
                                <div class="EMcomRowLow">
                                
                                    <asp:Label ID="lbl_SEM_selecttype" runat="server" Font-Bold="False" 
                                        Text="Select Type :"></asp:Label>
                                    <asp:DropDownList ID="ddl_SEM_selecttype" runat="server" Height="25px" 
                                        Width="199px" AutoPostBack="True">
                                    </asp:DropDownList>
                                
                                </div>
                                <div class="EMcomRowLow">
                                
                                    <asp:Label ID="lbl_SEM_selectcatagory" runat="server" Font-Bold="False" 
                                        Text="Catagory :"></asp:Label>
                                    <asp:TextBox ID="txt_SEM_catagory" runat="server" Width="217px" Height="25px"></asp:TextBox>
                                
                                </div>
                                <div class="EMcomRowLow">
                                
                                    <asp:Label ID="lbl_SEM_eventname" runat="server" Font-Bold="False" 
                                        Text="Event Name :"></asp:Label>
                                    <asp:TextBox ID="txt_SEM_eventname" runat="server" Width="195px" Height="25px"></asp:TextBox>
                                
                                </div>
                                <div class="EMcomRowHi">
                                
                                    <asp:Label ID="lbl_SEM_description" runat="server" Font-Bold="False" 
                                        Text="Description :"></asp:Label>
                                    <asp:TextBox ID="txt_SEM_description" runat="server" Height="139px" 
                                        Width="199px"></asp:TextBox>
                                
                                </div>
                                <div class="EMcomRowLow">
                                
                                    <asp:Label ID="lbl_SEM_organizer" runat="server" Font-Bold="False" 
                                        Text="Organizer :"></asp:Label>
                                    <asp:DropDownList ID="ddl_SEM_organizar" runat="server" Height="21px" 
                                        Width="212px" AutoPostBack="True">
                                        <asp:ListItem>School Management</asp:ListItem>
                                        <asp:ListItem>Parents</asp:ListItem>
                                        <asp:ListItem>OB Association</asp:ListItem>
                                    </asp:DropDownList>
                                
                                </div>
                                 <div class="EMcomRowHi">
                                
                                     <asp:Label ID="lbl_SEM_issues" runat="server" Font-Bold="False" 
                                         Text="Faced Issues :"></asp:Label>
                                     <asp:TextBox ID="txt_SEM_issues" runat="server" Height="139px" Width="186px"></asp:TextBox>
                                
                                </div>
                                <div class="EMcomRowLow">
                                
                                    <asp:ImageButton ID="ibtn_SEM_insert" runat="server" Height="32px" 
                                        Width="182px" ImageUrl="~/button imagess/save.png" 
                                        onclick="ibtn_SEM_insert_Click" />
                                
                                </div>
                            
                            </div>
                            <div class="EMAdvance">
                            
                                <div class="EMAdvSearch">
                                     <div class="EMcomRowLow">                                
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                                        Text="Search Event _"></asp:Label>                                                                    
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                                                    
                                         <asp:ImageButton ID="ibtn_SW_deleterecords" runat="server" Height="22px" 
                                             Width="130px" ImageUrl="~/button imagess/delete.jpg" />
                                    </div>
                                    <div class="EMcomRowLow">                                
                                        <asp:Label ID="lbl_SEM_search_selectcatagory" runat="server" Font-Bold="False" 
                                        Text="Select Catagory :"></asp:Label>
                                        <asp:DropDownList ID="ddl_SEM_search" runat="server" Height="20px" Width="212px" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddl_SEM_search_SelectedIndexChanged1">
                                        </asp:DropDownList>                                                      
                                    </div>
                                </div>
                                
                                <div class="EMAdvGrid">
                                
                                    <asp:GridView ID="gv_SEM_data" runat="server" Height="445px" Width="618px" 
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:ButtonField DataTextField="EVENT_ID" HeaderText="Event Number" 
                                                Text="Button" />
                                            <asp:BoundField DataField="EVENT_TYPE_MAST" HeaderText="Main Type" />
                                            <asp:BoundField DataField="EVENT_TYPE_SUB" HeaderText="Sub Type" />
                                            <asp:BoundField DataField="EVENT_NAME" HeaderText="Event Name" />
                                            <asp:BoundField DataField="HELD_DATE" HeaderText="Date" />
                                            <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" />
                                            <asp:BoundField DataField="ORGANIZER" HeaderText="Organizer" />
                                            <asp:BoundField DataField="FACED_ISSUES" HeaderText="Faces Issues" />
                                        </Columns>
                                    </asp:GridView>
                                
                                </div>
                            
                            
                            </div>
                            
                        
                        </div>
                    
                    
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



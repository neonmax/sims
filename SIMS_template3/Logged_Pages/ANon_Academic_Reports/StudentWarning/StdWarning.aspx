<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true" CodeFile="~/Logged_Pages/ANon_Academic_Reports/StudentWarning/StdWarning.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info" Title="Student Warning" %>

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
                        Student Warning
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </div>
                    
                        <div class="RepOptions">
                            <div class="EMcontainer">
                                <div class="EMcommon">
                                    <div class="EMcomRowLow">
                                        <asp:Label ID="lbl_STW_studentid" runat="server" Font-Bold="False" 
                                            Text="Student ID :"></asp:Label>
                                        <asp:DropDownList ID="ddl_STW_studentid" runat="server" Height="25px" 
                                            Width="214px" 
                                            onselectedindexchanged="ddl_STW_studentid_SelectedIndexChanged" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="EMcomRowLow">
                                        <asp:Label ID="lbl_STW_Warningcode" runat="server" Font-Bold="False" 
                                            Text="Warning Code :"></asp:Label>
                                        <asp:DropDownList ID="ddl_STW_Warningcode" runat="server" AutoPostBack="True" 
                                            Height="25px" Width="185px">
                                            <asp:ListItem>C</asp:ListItem>
                                            <asp:ListItem>NC</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="EMcomRowLow">
                                        <asp:Label ID="lbl_STW_Levelcode" runat="server" Font-Bold="False" 
                                            Text="Level Code :"></asp:Label>
                                        <asp:DropDownList ID="ddl_STW_Levelcode" runat="server" AutoPostBack="True" 
                                            Height="16px" Width="204px">
                                            <asp:ListItem>Critical </asp:ListItem>
                                            <asp:ListItem>NonCritical</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="EMcomRowHi">
                                        <asp:Label ID="lbl_STW_Note" runat="server" Font-Bold="False" Text="Notes :"></asp:Label>
                                        <asp:TextBox ID="txt_STW_note" runat="server" Height="139px" Width="244px"></asp:TextBox>
                                    </div>
                                    <div class="EMcomRowLow">
                                        <asp:Label ID="lbl_STW_Informparents" runat="server" Font-Bold="False" 
                                            Text="Inform Parents :"></asp:Label>
                                        <asp:DropDownList ID="ddl_STW_Informparents" runat="server" Height="20px" 
                                            Width="181px">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="EMcomRowLow">
                                        <asp:ImageButton ID="ibtn_STW_Insert" runat="server" Height="27px" 
                                            Width="182px" ImageUrl="~/button imagess/save.png" 
                                            onclick="ibtn_STW_Insert_Click1" />
                                    </div>
                                </div>
                                <div class="EMAdvance">
                                    <div class="EMAdvSearch">
                                        <div class="EMcomRowLow">
                                            <asp:Label ID="lbl_STW_searchstudent" runat="server" Font-Bold="False" 
                                                Text="Search Student :"></asp:Label>
                                            <asp:DropDownList ID="ddl_STW_Serach" runat="server" Height="16px" 
                                                Width="180px" AutoPostBack="True" 
                                                onselectedindexchanged="ddl_STW_Serach_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="ibtn_delete" runat="server" Height="22px" 
                                                ImageUrl="~/button imagess/delete.jpg" onclick="ibtn_delete_Click1" 
                                                Width="130px" Visible="False" />
                                        </div>
                                    </div>
                                    <div class="EMAdvGrid">
                                        <asp:GridView ID="gv_STW_Searchresult" runat="server" Height="174px" 
                                            Width="616px" AutoGenerateColumns="False" 
                                            onrowcommand="gv_STW_Searchresult_RowCommand1" BackColor="White">
                                            <Columns>
                                                <asp:ButtonField DataTextField="ADMISSION_NO" HeaderText="Admission Number" />
                                                <asp:BoundField DataField="WARNING_CODE" HeaderText="Warning Code" />
                                                <asp:BoundField DataField="WARN_DATE" HeaderText="Warn Date" />
                                                <asp:BoundField DataField="LEVEL_CODE" HeaderText="Level" />
                                                <asp:BoundField DataField="NOTE" HeaderText="Description" />
                                                <asp:BoundField DataField="INFORM_PARENTS" HeaderText="Parent Informed" />
                                            </Columns>
                                        </asp:GridView>
                                        
                                        <div class="EMcomRowLow" style="vertical-align: middle">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="False" 
                                            Text="Generate Chart     _"></asp:Label>
                                            <asp:DropDownList ID="ddl_STW_chartselect" runat="server" Height="20px" 
                                                Width="239px" AutoPostBack="True" 
                                                onselectedindexchanged="ddl_STW_chartselect_SelectedIndexChanged1">
                                                <asp:ListItem Value="0">Based On Activity</asp:ListItem>
                                                <asp:ListItem Value="1">Based On Type</asp:ListItem>
                                                <asp:ListItem Value="2">Based On Year</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div>
                                    
                                    
                                        <CR:CrystalReportViewer ID="crv_STW_charts" runat="server" Width="600px" Height="420px"
                                            AutoDataBind="True" BestFitPage="False" />
                                    
                                    
                                    </div>
                                        
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



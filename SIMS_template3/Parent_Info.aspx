<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true" CodeFile="Parent_Info.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info" Title="Parents Report" %>

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
                        <li><a href="#" class="active">Home</a></li>
                        <li><a href="#">About Us</a></li>
                        <li><a href="#">Contact Us</a></li>
                    </ul>
                </div>
            </div>
            <div id="prev">
                 
				 <div class="scrollable">
				<div class="items">
					<div class="item">
						<div class="headerReport "></div>                                    
					</div> <!-- item -->
					<div class="item">
					    <div class="header2"></div>						
					</div> <!-- item -->
					<div class="item">
					    <div class="header3"></div>						
					</div> <!-- item -->
					<div class="item">
					    <div class="header4"></div>
					</div> <!-- item -->				
					
				</div> <!-- items -->
			</div> <!-- scrollable -->
			<div class="navi"></div> <!-- create automatically the point dor the navigation depending on the numbers of items -->		   
			  
                <div style="clear: both"></div>
            </div>
            <div class="body">
                <div class="headline_holder">
                    <asp:Label class="headline" runat="server" Text="Label">Report Generator  </asp:Label>
                </div>
                <div class="form">
                    <div class="form_fields">                    
                        <asp:Label class="form_label" runat="server" Text="Critaria 1"></asp:Label>
                                              
                        <asp:TextBox class="form_text" runat="server"></asp:TextBox>
                                              
                    </div>
                    <br />
                    <div class="form_fields">                    
                        <asp:Label ID="Label1" class="form_label" runat="server" Text="Critaria 2"></asp:Label>
                                              
                        <asp:TextBox class="form_text" runat="server"></asp:TextBox>
                                              
                    </div>
                    <br />
                    <div class="form_fields">                    
                        <asp:Label ID="Label2" class="form_label" runat="server" Text="Critaria 3"></asp:Label>
                                              
                        <asp:TextBox class="form_text" runat="server"></asp:TextBox>
                                              
                    </div>
                    <br />
                    <br />
                    
                    
                    
                </div>
                
            
            </div>
            
               
                    
                           
                </div>
                
            
            
            
            <div class="con_bot">
            
            
            
            </div>
            
            
            
            
            <div id="footer">
                 <p>All rights reserved </p>
                    <!-- Please DO NOT remove the following notice --><p>Design by SLIIT SEWD 02</p><!-- end of copyright notice-->
            </div>
        
        


</asp:Content>



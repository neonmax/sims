<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/MainMaster.master" AutoEventWireup="true" CodeFile="Non_Academic_Home.aspx.cs" Inherits="Academic_Home" Title="Non Academic Home Page" %>

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
                        <asp:Label ID="txtUser" runat="server" Text="Session Name" Font-Bold="False" 
                            Font-Names="Arial" Font-Size="Small" ForeColor="White"></asp:Label>
                            
                            <br />
                    
                    </div>
                          
                
                
                <div id="menu">
                    <ul>
                        <li><a href="index.html" class="active">Home</a></li>
                        <li><a href="aboutus.html">About Us</a></li>
                        <li><a href="contact.html">Contact Us</a></li>
                        <li><a href="../Common_Home.aspx" style="color: #FF0000">Logout</a></li>
                    </ul>
                </div>
            </div>
            <div id="prev">
                 
				 <div class="scrollable">
				<div class="items">
					<div class="item">
						<div class="header1"></div>                                    
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

            
            
            <!--///////////////////////////// new frame work implimentation /////////////////////////         -->
                       
                                        <div id="MHedding">
                                            Non-Academic Home Page
                        </div>
                        
                        <div class="MHeaderDisc">
                            You can generate following reports.
                        </div>
                        


                        <div class="MCtrlPanel">


                        
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel1" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="ImageButton2_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Individual Achivements
                                    </div>
                                    <div class="MDesctxt">        
                                        Achivements of individual students at extracurricular activities
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel2" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton3" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="ImageButton3_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Student Participation
                                    </div>
                                    <div class="MDesctxt">        
                                        Charts for number of students participation in sports, music, societys, etc...
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel3" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton4" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="ImageButton4_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Activity Log
                                    </div>
                                    <div class="MDesctxt">        
                                        Extracurricular activity log for each student
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel4" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton5" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="ImageButton5_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Character Reports
                                    </div>
                                    <div class="MDesctxt">        
                                        Generate student character reports automaticaly
                                    </div>    
                                </div>
                        </asp:Panel> 
                         
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel5" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton6" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        School Fee
                                    </div>
                                    <div class="MDesctxt">        
                                        School fee handling
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel6" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton7" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="ImageButton7_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        School Events &amp; Tips
                                    </div>
                                    <div class="MDesctxt">        
                                        School education Tips &amp; Event management
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel7" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton8" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="ImageButton8_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Warnings
                                    </div>
                                    <div class="MDesctxt">        
                                        Warnings for Students / Punishments
                                    </div>    
                                </div>
                        </asp:Panel> 
                        

                        </div>       
                                                
            <!--///////////////////////////// new frame work implimentation /////////////////////////         -->
            
            
            <div class="con_bot"></div>
            <div id="foot_col">
                <div class="foot_col1">
                    <h2>Recent posts</h2>
                    <div class="foot_pad">
                        <p><a href="#">New events </a><br />
                            Event Information
                        </p>
                    </div>
                </div>
                <div class="foot_col2">
                    <h2>Share with Others</h2>
                    <div class="foot_pad">
                        <div class="link1"><a href="#">Subscribe to Blog</a></div>
                        <div class="link2"><a href="#">Be a fan on Facebook</a></div>
                        <div class="link3"><a href="#">RSS Feed</a></div>
                        <div class="link4"><a href="#">Follow us on Twitter</a></div>
                    </div>
                </div>

                <div class="foot_col3">
                    <h2>Useful Resources</h2>
                    <div class="foot_pad">
                        <ul class="ls">
                            
                                   <li><a href="#">Examination Department</a></li>
                                    <li><a href="#">University G C</a></li>
                        </ul>
                    </div>
                </div>
                <div class="footer_border_bot"></div>
            </div>
            <div id="footer">
                <div class="red_hr"></div>
                 <p>All rights reserved</p>
                    <!-- Please DO NOT remove the following notice --><p>Design by SLIIT SEWD 02</p><!-- end of copyright notice-->
            </div>
        </div>
        </div>
        
</asp:Content>



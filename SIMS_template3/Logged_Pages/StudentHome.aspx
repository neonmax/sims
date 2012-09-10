<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/MainMaster.master" AutoEventWireup="true" CodeFile="StudentHome.aspx.cs" Inherits="StudentHome" Title="Students Home Page" %>

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
                                            Student Home Page
                        </div>
                        
                        <div class="MHeaderDisc">
                            You can generate following reports.
                        </div>
                        


                        <div class="MCtrlPanel">


                        
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel1" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="imbTotalStudents" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="imbTotalStudents_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Total Students</div>
                                    <div class="MDesctxt">        
                                        Number of Students Categorywise</div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel2" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="imbStudentDetails" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="imbStudentDetails_Click"   />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        View Student Details
                                    </div>
                                    <div class="MDesctxt">        
                                        Enter student details and view student details&nbsp;
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel3" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="imbClassdetails" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="imbClassdetails_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Class Details Report
                                    </div>
                                    <div class="MDesctxt">        
                                        Report of students in class according to different criterias.
                                    </div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel4" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="imbEnrolled" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                                            onclick="imbEnrolled_Click"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Student Intake Counter
                                    </div>
                                    <div class="MDesctxt">        
                                        Report for total number of students registered per year
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
                                        Student Leaving Details
                                    </div>
                                    <div class="MDesctxt">        
                                        Report for total number of students left the school per year</div>    
                                </div>
                        </asp:Panel> 
                        <asp:Panel class="Boundrypannel" runat="server" ID="Panel6" Width="282px" 
                                CssClass="Boundrypannel">
                                <div class="Mlinker">
                                    <div class="Mimg">
                                    <asp:ImageButton ID="ImageButton7" runat="server" 
                                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg"  />
                                        &nbsp;</div>
                                    <div class="Mtxt">
                                        Eligible for Prefects
                                    </div>
                                    <div class="MDesctxt">        
                                        Provide details for the selection of school prefects</div>    
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



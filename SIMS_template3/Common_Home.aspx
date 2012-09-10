<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Common_Home.aspx.cs" Inherits="Home" Title="Home Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        <div id="wrap">
            <div id="header">
                
                    <div id="logo">
                        <asp:ScriptManager ID="HmScptMng" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="HmUpPnl" runat="server">
                            <ContentTemplate>
                                <br />
                                <asp:TextBox ID="txtUser" runat="server" BorderStyle="None"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtPass" runat="server" BorderStyle="None" TextMode="Password"></asp:TextBox>
                                <br />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSignin" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:ImageButton ID="btnSignin" runat="server" ImageAlign="Middle" ImageUrl="~/images/sign in.png"
                            OnClick="btnSignin_Click" />
                        
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Error..!" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                    </div>
                          
                
                
                <div id="menu">
                    <ul>
                        <li><a href="Common_Home.aspx" class="active">Home</a></li>
                        <li><a href="Common_AboutUs.aspx">About Us</a></li>
                        <li><a href="Common_ContactUs.aspx">Contact Us</a></li>
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

            <div id="content">
                <div id="column_box">
                    <div class="column1">
                        <div class="column_title">
                            <h1>School News</h1>
                        </div>
                        <div class="col_text">
                            <p><a href="#">School news </a><br />
                                School news.</p><br />
                           
                        </div>
                    </div>
                    <div class="column2">
                        <div class="column_title">
                            <h1>Time Tables</h1>
                        </div>
                        <div class="col_text">
                            <p><a href="#">Time Tables</a><br />
                                Time Tables </p><br />
                           
                        </div>
                    </div>
                    <div class="column3">
                        <div class="column_title">
                            <h1>Notice Board</h1>
                        </div>
                        <div class="col_text">
                            <p><a href="#">Notice board</a><br />
                                Notice board </p><br />
                           
                        </div>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>
            <div class="con_bot"></div>
            <div id="foot_col">
                <div class="foot_col1">
                    <h2>Recent posts</h2>
                    <div class="foot_pad">
                        <p><a href="#">New events </a><br />
                            Event Information
                        </p>
                        <br />
                        
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
        
</asp:Content>



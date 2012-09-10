<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/MainMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Common_AboutUs" Title="Profile Page" %>

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
                            <br />
                    
                
                </div>
                <div id="menu">
                    <ul>
                        <li><a href="Home.aspx">Home</a></li>
                        <li><a href="AboutUs.aspx">About Us</a></li>
                        <li><a href="ContactUs.aspx" class="active">Contact Us</a></li>
                        <li><a href="../Common_Home.aspx" style="color: #FF0000">Logout</a></li>
                    </ul>
                </div>
            </div>
            <div id="prevX">
                <asp:Image ID="Image1" runat="server" Height="212px" 
                    ImageUrl="~/Logged_Pages/images/profile-banner.jpg" Width="950px" />
            </div>

            <div id="content">
                
            </div>
            <div class="con_bot"></div>
            
            <div class="gapSet"></div> <div class="con_top"></div> 
            <div class="proSubtitle">Personal Details
                <div class="proRow">
                    <div class="RowcolLft">User No</div>                    
                    <div class="RowcolRte">:<asp:Label ID="lblUserNo" runat="server" Text="lblUserNo"></asp:Label>
                            </div>
                   
                </div>
                <div class="proRow">
                    <div class="RowcolLft">User Name</div>
                    <div class="RowcolRte">:<asp:Label ID="lblUserName" runat="server" 
                            Text="lblUserName"></asp:Label>
                    </div>
                </div>
                <div class="proRow">
                    <div class="RowcolLft">Role</div>
                    <div class="RowcolRte">:<asp:Label ID="lblUserRole" runat="server" 
                            Text="lblUserRole"></asp:Label>
                            </div>
                </div>
                <div class="proRow">
                    <div class="RowcolLft">Loged time</div>
                     <div class="RowcolRte">:<asp:Label ID="lblUserLogtime" runat="server" 
                             Text="lblUserLogtime"></asp:Label>
                    </div>
                </div>
                
                <div class="gapSet"></div>
                <asp:Label ID="Label1" runat="server" Text="Previous login details :"></asp:Label>
                <div class="proRow">
                    <div class="RowcolLft">Loged time</div>
                     <div class="RowcolRte">:<asp:Label ID="lblUserPrelogtime" runat="server" 
                             Text="lblUserPrelogtime"></asp:Label>
                            </div>
                </div> 
                <div class="proRow">
                    <div class="RowcolLft">Loged date</div>
                     <div class="RowcolRte">:<asp:Label ID="lblUserPrelogDate" runat="server" 
                             Text="lblUserPrelogDate"></asp:Label>
                            </div>
                </div> 
            
            </div>
            <div class="con_bot"></div>
            
            <div class="gapSet"></div> <div class="con_top"></div> 
            <div class="proSubtitle"> User Description
            <div class="TextDiv"> Summary description about the user. This one is generated 
                according to the user role.</div>
          
            </div>
                  <div class="con_bot"></div>
            
            <div class="gapSet"></div> <div class="con_top"></div> 
            
            
                    <div class="proSubtitle"> Security
                <div class="TextDiv"> User can have their own password And Server allow to users to 
                    change thair passwords frequently , for best security.</div>
                    <div class="proRow">
                        <div class="RowcolLft">Current Password</div>
                         <div class="RowcolRte">:<asp:TextBox ID="txtCurPas" runat="server" 
                                 BorderStyle="None" Height="20px" TextMode="Password" Width="208px" 
                                 ontextchanged="txtCurPas_TextChanged"></asp:TextBox>
                                </div>
                    </div>
                    <div class="proRow">
                        <div class="RowcolLft">New Password</div>
                         <div class="RowcolRte">:<asp:TextBox ID="txtNewPass" runat="server" 
                                 BorderStyle="None" Height="20px" Width="208px" TextMode="Password" 
                                 CssClass="FormTxtBox"></asp:TextBox>
                                </div>
                    </div>
                    <div class="proRow">
                        <div class="RowcolLft">Conform Password</div>
                         <div class="RowcolRte">:<asp:TextBox ID="txtConfPass" runat="server" 
                                 BorderStyle="None" Height="20px" TextMode="Password" Width="208px" 
                                 CssClass="FormTxtBox"></asp:TextBox>
                             <asp:Button ID="btnChange" runat="server" Height="20px" Text="Change Password" 
                                 Width="139px" onclick="btnChange_Click" />
                                <asp:Label ID="lblstatus" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                    </div>
                </div>   
                
                
                
                
                                                  
                    
                <div class="con_bot"></div>
                
                <div class="gapSet"></div> <div class="con_top"></div> 
                <div class="proSubtitle"> Functions</div>
                
                <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                
                
                <div class="TextDiv"> According to the User role, access for functions is limited. 
                    Here you can see what are the functions you can handle using this web server.<br />
                    <br />
                    <asp:Label ID="lblShowmore" runat="server" Text="See more"></asp:Label>
                    <asp:ImageButton ID="ImgBtnShow" runat="server" Height="24px" 
                        ImageUrl="~/Logged_Pages/images/next.png" onclick="ImgBtnShow_Click" 
                        Width="24px" />
                    &nbsp;<div>
                        <asp:Panel ID="PnlFunction" runat="server" 
                            BackImageUrl="~/Logged_Pages/images/HighAdminFun.jpg" Visible="False">
                        <asp:Image ID="ImgFun" runat="server" Height="366px" 
                                ImageUrl="~/Logged_Pages/images/HighAdminFun.jpg" Width="905px" />
                        
                        
                        </asp:Panel>
                    </div>
                    <div>
                        <asp:Label ID="lblhide" runat="server" Text="Hide view"></asp:Label>
                        <asp:ImageButton ID="ImgBtnHide" runat="server" Height="24px" 
                            ImageUrl="~/Logged_Pages/images/hide.png" onclick="ImgBtnHide_Click" 
                            Width="26px" />
                    </div>
                
                </div>
                
                </ContentTemplate>
            
            
            
            </asp:UpdatePanel>
            
            
                    
                    
                    
                        
            <div class="con_bot"></div>
            
            <div id="foot_col">
                <div class="foot_col1">
                    <h2>Recent posts<a href="#">New events </a><br />
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



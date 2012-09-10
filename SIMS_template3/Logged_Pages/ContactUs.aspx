<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/MainMaster.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="Common_AboutUs" Title="Contact Us Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        <div id="prev">
            <asp:Image ID="Image1" runat="server" Height="297px" ImageUrl="~/images/contactus.jpg"
                Width="950px" />
        </div>
        <div id="content">
            <div>
                <div class="proSubtitle">
                    Contact Form
                    <div class="TextDiv">
                        </br> Contact us for your future preferences.</div>
                    </br>
                    <div class="proRow">
                        <div class="RowcolLft">
                            Your Name</div>
                        <div class="RowcolRte">
                            :<asp:TextBox ID="txtName" runat="server" BorderStyle="None" Height="20px" Width="580px"></asp:TextBox>
                        </div>
                    </div>
                    </br>
                    <div class="proRow">
                        <div class="RowcolLft">
                            E-mail Address</div>
                        <div class="RowcolRte">
                            :<asp:TextBox ID="txtMail" runat="server" BorderStyle="None" Height="20px" Width="580px"></asp:TextBox>
                        </div>
                    </div>
                    </br>
                    <div class="proRow">
                        <div class="RowcolLft">
                            Subject</div>
                        <div class="RowcolRte">
                            :<asp:TextBox ID="txtSubject" runat="server" BorderStyle="None" Height="20px" Width="580px"></asp:TextBox>
                        </div>
                    </div>
                    </br>
                    <div class="proRow">
                        <div class="RowcolLft">
                            Message</div>
                        <div class="RowcolRte">
                            :
                            <asp:TextBox ID="txtMessage" runat="server" BorderStyle="None" Height="20px" Width="580px"></asp:TextBox>
                        </div>
                    </div>
                    </br>
                    <div class="proRow">
                        <div class="RowcolLft">
                            <asp:Button ID="btnSubmit" runat="server" Height="20px" Text="Submit" Width="139px"
                                OnClick="btnSubmit_Click" />
                        </div>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    </br>
                </div>
            </div>
            <div class="contact_content_bg">
                <div style="clear: both">
                </div>
            </div>
        </div>
        <div class="con_bot">
        </div>
        <div id="foot_col">
            <div class="foot_col1">
                <h2>
                    Recent posts</h2>
                <div class="foot_pad">
                    <p>
                        <a href="#">New events </a>
                        <br />
                        Event Information
                    </p>
                </div>
            </div>
            <div class="foot_col2">
                <h2>
                    Share with Others</h2>
                <div class="foot_pad">
                    <div class="link1">
                        <a href="#">Subscribe to Blog</a></div>
                    <div class="link2">
                        <a href="#">Be a fan on Facebook</a></div>
                    <div class="link3">
                        <a href="#">RSS Feed</a></div>
                    <div class="link4">
                        <a href="#">Follow us on Twitter</a></div>
                </div>
            </div>
            <div class="foot_col3">
                <h2>
                    Useful Resources</h2>
                <div class="foot_pad">
                    <ul class="ls">
                        <li><a href="#">Examination Department</a></li>
                        <li><a href="#">University G C</a></li>
                    </ul>
                </div>
            </div>
            <div class="footer_border_bot">
            </div>
        </div>
        <div id="footer">
            <div class="red_hr">
            </div>
            <p>
                All rights reserved</p>
            <!-- Please DO NOT remove the following notice -->
            <p>
                Design by SLIIT SEWD 02</p>
            <!-- end of copyright notice-->
        </div>
    </div>
    </div>
</asp:Content>

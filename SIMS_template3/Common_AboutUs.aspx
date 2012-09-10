<%@ Page Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Common_AboutUs.aspx.cs" Inherits="Common_AboutUs" Title="About us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        <div id="wrap">
            <div id="header">
                <div id="logo">
                <br />
                    <asp:ScriptManager ID="AtbUsScrMng" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="AbtusUpPnl" runat="server">
                        <ContentTemplate>
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
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Error..!"
                        ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                        
                        
                </div>
                <div id="menu">
                    <ul>
                        <li><a href="Common_Home.aspx">Home</a></li>
                        <li><a href="Common_AboutUs.aspx" class="active">About Us</a></li>
                        <li><a href="Common_ContactUs.aspx">Contact Us</a></li>
                    </ul>
                </div>
            </div>
            <div id="prevX">
               
                <asp:Image ID="Image1" runat="server" Height="294px" 
                    ImageUrl="~/images/about_us_image.jpg" Width="950px" />
               
            </div>

            <div id="content">
                <div class="about">
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="#0099CC" Text="History"></asp:Label>
                </div>
                <div id="aboutusTxt" style="clear: both"><br />ABC College was established in 1956 in the aspiration of 
                    endowing well educated citizens to the nation. Today, ABC is a national school 
                    recognized by the Ministry of Education and an independent, non-profit, 
                    educational institute which offers education from grade 1 to grade 13. There are 
                    more than 3,500 students studying in the school at the present.<br /><br /> The school 
                    includes three distinct divisions: Primary School (grade one through grade 
                    five), Middle School (grades six through eleven), and High School (grades twelve 
                    through thirteen). The professional staff is around 300 with nearly 60% holding 
                    Bsc. degrees or above.<br /><br /> ABC College provides a safe and pleasant learning 
                    environment in one of the finest school facilities in the country. ABC students 
                    consistently rank higher on academic and non academic achievements. Class sizes 
                    emphasize educationally sound student-teacher ratios. Student/teacher ratios 
                    across all of the divisions reflect the ABC Colleges commitment to ensuring a 
                    quality education and a high level of pastoral care for all of our students.<br /></div>
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



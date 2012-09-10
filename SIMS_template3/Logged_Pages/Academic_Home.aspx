<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/MainMaster.master" AutoEventWireup="true"
    CodeFile="Academic_Home.aspx.cs" Inherits="Academic_Home" Title="Academic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="wrap">
        <div id="header">
            <div id="logo2">
                <br />
                <br />
                <br />
                <asp:Label ID="txtUser" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
                    Font-Size="Small" ForeColor="White"></asp:Label>
                <br />
            </div>
            <div id="menu">
                <ul>
                    <li><a href="Home.aspx" class="active">Home</a></li>
                    <li><a href="AboutUs.aspx">About Us</a></li>
                    <li><a href="ContactUs.aspx">Contact Us</a></li>
                    <li><a href="../Common_Home.aspx" style="color: #FF0000">Logout</a></li>
                </ul>
            </div>
        </div>
        <div id="prev">
            <div class="scrollable">
                <div class="items">
                    <div class="item">
                        <div class="header1">
                        </div>
                    </div>
                    <!-- item -->
                    <div class="item">
                        <div class="header2">
                        </div>
                    </div>
                    <!-- item -->
                    <div class="item">
                        <div class="header3">
                        </div>
                    </div>
                    <!-- item -->
                    <div class="item">
                        <div class="header4">
                        </div>
                    </div>
                    <!-- item -->
                </div>
                <!-- items -->
            </div>
            <!-- scrollable -->
            <div class="navi">
            </div>
            <!-- create automatically the point dor the navigation depending on the numbers of items -->
            <div style="clear: both">
            </div>
        </div>
        <!--///////////////////////////// new frame work implimentation /////////////////////////         -->
        <div id="MHedding">
            Academic Home Page
        </div>
        <div class="MHeaderDisc">
            You can generate following reports.
        </div>
        <div class="MCtrlPanel">
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel1" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbProgressReports" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                            onclick="imbProgressReports_Click" />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Progress Reports
                    </div>
                    <div class="MDesctxt">
                        Individual progress report for students
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel2" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbPrizeWinners" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                            onclick="imbPrizeWinners_Click" />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Prize Winners
                    </div>
                    <div class="MDesctxt">
                        School prize giving by performance of term test marks
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel3" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbBestPerformance" runat="server" ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg"
                            OnClick="btnBestPerformance_Click" />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Best Performance
                    </div>
                    <div class="MDesctxt">
                        The best performance in government examinations.
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel4" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbGenAcaProgress" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" onclick="imbGenAcaProgress_Click" 
                           />
                        &nbsp;</div>
                    <div class="Mtxt">
                        General Examination Progress
                    </div>
                    <div class="MDesctxt">
                        Generate Examination Progressreports automaticaly
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel5" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbExamResultSheets" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                            onclick="imbExamResultSheets_Click" />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Exammination Result Details</div>
                    <div class="MDesctxt">
                        Scholarship, Ordinary level &amp; Advanced level result details
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel6" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbEvent" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                            onclick="imbEvent_Click" />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Student's Photo Gallery
                    </div>
                    <div class="MDesctxt">
                        Watch the School Student's Photo Gallery with the photoes shot at school events.
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel7" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbExamResultAnalysis" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" 
                            onclick="imbExamResultAnalysis_Click" />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Examination Result Analysis
                    </div>
                    <div class="MDesctxt">
                        Scholarship, Ordinary level &amp; Advanced level result for entire school year wise
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel class="Boundrypannel" runat="server" ID="Panel8" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbAddMedical" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" onclick="imbAddMedical_Click"  
                             />
                        &nbsp;</div>
                    <div class="Mtxt">
                        Add Medical Details
                    </div>
                    <div class="MDesctxt">
                        Add Government Examination Medical Details for the Students.
                    </div>
                </div>
            </asp:Panel>
             <asp:Panel class="Boundrypannel" runat="server" ID="Panel9" Width="282px" CssClass="Boundrypannel">
                <div class="Mlinker">
                    <div class="Mimg">
                        <asp:ImageButton ID="imbViewMedical" runat="server" 
                            ImageUrl="~/Logged_Pages/userImages/Untitled-2.jpg" onclick="imbViewMedical_Click"   
                             />
                        &nbsp;</div>
                    <div class="Mtxt">
                        View Medical Details
                    </div>
                    <div class="MDesctxt">
                        View Government Examination Medical Details of the Students.
                    </div>
                </div>
            </asp:Panel>
        </div>
        <!--///////////////////////////// new frame work implimentation /////////////////////////         -->
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

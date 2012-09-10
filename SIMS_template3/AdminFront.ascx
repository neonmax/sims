<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminFront.ascx.cs" Inherits="AdminFront" %>
<link href="Logged_Pages/fronts.css" rel="stylesheet" type="text/css" />

<div id="Hedding">
    HIGHER
ADMINISTRATOR
</div>
<div class="HeaderDisc">
You are allowed to use following areas
</div>

<div id="CtrlPanel">
    <div class="linker">
        <div class="img">
        <asp:ImageButton ID="btnPro" runat="server" 
                ImageUrl="~/Logged_Pages/userImages/profile.jpg" onclick="btnPro_Click" />
        </div>
        <div class="txt">
        &nbsp;&nbsp;&nbsp;&nbsp;
        Your Profile
            </div>
    
    </div>
    <div class="linker">
        <div class="img">
        <asp:ImageButton ID="btnStd" runat="server" 
                ImageUrl="~/Logged_Pages/userImages/student.jpg" onclick="btnStd_Click" />
        </div>
        <div class="txt">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Students
            </div>
    
    </div>
    <div class="linker">
        <div class="img">
        <asp:ImageButton ID="btnPrnt" runat="server" 
                ImageUrl="~/Logged_Pages/userImages/parent.jpg" onclick="btnPrnt_Click" />
        </div>
        <div class="txt">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Parents
            </div>
    
    </div>
    <div class="linker">
        <div class="img">
        <asp:ImageButton ID="btnAck" runat="server" 
                ImageUrl="~/Logged_Pages/userImages/academic.jpg" onclick="btnAck_Click" />
        </div>
        <div class="txt">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Academic
            </div>
    
    </div>
    <div class="linker">
        <div class="img">
        <asp:ImageButton ID="btnNonAck" runat="server" 
                ImageUrl="~/Logged_Pages/userImages/nonAck.jpg" onclick="btnNonAck_Click" />
        </div>
        <div class="txt">
        &nbsp;&nbsp;
        Non Academic</div>
    
    </div>
    


</div>


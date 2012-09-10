<%@ Page Language="C#" AutoEventWireup="true" CodeFile="image_student.aspx.cs" Inherits="Logged_Pages_Academic_Reports_Reports_image_student" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <asp:ScriptManager ID="HmScptMng" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="HmUpPnl" runat="server">
        <ContentTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Logged_Pages/Academic_Reports/Reports/stdImg.ashx" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LinkButton</asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>    
    </form>
</body>
</html>

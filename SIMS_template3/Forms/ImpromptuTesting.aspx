<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpromptuTesting.aspx.cs"
    Inherits="DeepASP.JQueryPromptuTest.ImpromptuTesting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CSS/Style.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../Scripts/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <%--<script src="../Scripts/jquery.Impromptu.3.3.js" type="text/javascript"></script>--%>

    <script src="../Scripts/DeepASPImpromptuCalling.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="header">
            <h2>
                Message Box using Jquery Impromptu</h2>
        </div>
        <asp:Button ID="btnShowImpromptu" CssClass="label" runat="server" 
            Text="Show Alert" onclick="btnShowImpromptu_Click" />
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="WUC_StudentWarning.ascx" tagname="WUC_StudentWarning" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            height: 104px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <uc1:WUC_StudentWarning ID="WUC_StudentWarning1" runat="server" />
    </form>
</body>
</html>

<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="NewPhotoGallery.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Photo Gallery" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of Calender Toggle By Neon--%>

    <script type="text/javascript" language="javascript">
    function popupCalender() {
        var ExpandableFormRow = document.getElementById('ExpandableFormRow');
       if (dateField.style.display == 'none')
       dateField.style.display= 'block';
       else
       dateField.style.display='none';
    }
    
 
    </script>

    <%--End of Calender Toggle By Neon--%>
    
    
    <link href="../../Notifications/CSS/Style.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../../lib/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <script src="../../lib/DeepASPImpromptuCalling.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../../lib/lightbox/lightbox.css" type="text/css" media="screen" />

    <script type="text/javascript" src="../../lib/lightbox/prototype.js"></script>

    <script type="text/javascript" src="../../lib/lightbox/scriptaculous.js?load=effects"></script>

    <script type="text/javascript" src="../../lib/lightbox/lightbox.js"></script>


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
            </div>
            <div id="menu">
                <ul>
                    <li><a href="../Home.aspx">Home</a></li>
                    <li><a href="../AboutUs.aspx" class="active">About Us</a></li>
                    <li><a href="../ContactUs.aspx">Contact Us</a></li>
                </ul>
            </div>
        </div>

        <div class="ReportBody">
            <div class="ReportHeader">
                Photo Gallery
            </div>
            <div class="ReportDesc">
               Student's Photo Gallery
            </div>
        </div>
        <div class="FormHeadder">
        </div>
        <div class="FormBackgroundAddAppointment">
            <div class="paraSpace">
            </div>
                   <asp:ScriptManager ID="HmScptMng" runat="server">
        </asp:ScriptManager>
        <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        function EndRequest(sender, args) {
            Lightbox.initialize()
        }
</script>

        <asp:UpdatePanel ID="HmUpPnl" runat="server">
            <ContentTemplate>
            <div class="FormRow">
                <div class="fieldsCaptionCell">
                    <asp:Label ID="Label1" runat="server" class="RLable" Text="Grade"></asp:Label>
                </div>
                <div class="fieldsElementCell">
                    <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlGrade" runat="server"
                        Height="20px" Width="185px" AutoPostBack="true" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Grade</asp:ListItem>
                        <asp:ListItem Value="1">Grade 1</asp:ListItem>
                        <asp:ListItem Value="2">Grade 2</asp:ListItem>
                        <asp:ListItem Value="3">Grade 3</asp:ListItem>
                        <asp:ListItem Value="4">Grade 4</asp:ListItem>
                        <asp:ListItem Value="5">Grade 5</asp:ListItem>
                        <asp:ListItem Value="6">Grade 6</asp:ListItem>
                        <asp:ListItem Value="7">Grade 7</asp:ListItem>
                        <asp:ListItem Value="8">Grade 8</asp:ListItem>
                        <asp:ListItem Value="9">Grade 9</asp:ListItem>
                        <asp:ListItem Value="10">Grade 10</asp:ListItem>
                        <asp:ListItem Value="11">Grade 11</asp:ListItem>
                        <asp:ListItem Value="12">Grade 12</asp:ListItem>
                        <asp:ListItem Value="13">Grade 13</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="fieldsCaptionCell">
                    <asp:Label ID="Label4" runat="server" class="RLable" Text="Class :"></asp:Label>
                </div>
                <div class="fieldsElementCell">
                    <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlClass" runat="server"
                        Height="20px" Width="185px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                        AutoPostBack="true">
                         <asp:ListItem Value="0">Select Class</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="fieldsCaptionCell">
                    <asp:Label ID="Label5" runat="server" class="RLable" Text="Student :"></asp:Label>
                </div>
                <div class="fieldsElementCell">
                    <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlStudent" runat="server"
                        Height="20px" Width="185px" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"
                        AutoPostBack="true">
                         <asp:ListItem Value="0">Select Student</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

           
            <div class="paraSpace">
            </div>
            <div class="paraSpace">
            </div>
            <div class="RepPanelgallery">
                <center>
                    <asp:DataList ID="dlImages" runat="server" RepeatColumns="7"  BackColor="White"
                        GridLines="None">
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <ItemTemplate>
                            <a id="imageLink" href='<%# Eval("FILENAME","~/SlideImages/{0}") %>' title='<%#Eval("NOTE") %>'
                                rel="lightbox[Brussels]" runat="server">
                                <asp:Image ID="Image1" ImageUrl='<%# Bind("FILENAME", "~/SlideImages/{0}") %>' runat="server"
                                    Width="112" Height="84" />
                            </a>
                        </ItemTemplate>
                        <AlternatingItemStyle BackColor="#DCDCDC" />
                        <ItemStyle BorderColor="#0280EC" BorderStyle="Outset" BorderWidth="3px" HorizontalAlign="Center"
                            VerticalAlign="Bottom" />
                        <SelectedItemStyle BackColor="#0280EC" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                    <asp:Label ID="lblNoImages" runat="server" Font-Bold="False" Font-Size="Large" 
                        ForeColor="Red" Text="No Images Found for the Student."></asp:Label>
                </center>
            </div>
            <div class="paraSpace">
            </div>
            <div class="paraSpace">
            </div>
        </div>
   </ContentTemplate>
        </asp:UpdatePanel>
        <div class="FormFooter">
        </div>
    </div>
</asp:Content>

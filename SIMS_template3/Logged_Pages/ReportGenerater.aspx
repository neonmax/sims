<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate.master" AutoEventWireup="true"
    CodeFile="ReportGenerater.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Best Performance" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="wrap">
        
        <div class="body">
        <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              
            <asp:Panel ID="RepPnl" runat="server">
            </asp:Panel>
            
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div class="con_bot">
        </div>
        <div id="footer">
            <p>
                All rights reserved
            </p>
            <!-- Please DO NOT remove the following notice -->
            <p>
                Design by SLIIT SEWD 02</p>
            <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

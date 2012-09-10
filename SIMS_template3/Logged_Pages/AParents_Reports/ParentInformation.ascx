<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParentInformation.ascx.cs"
    Inherits="Logged_Pages_Academic_Reports_BestPerformance" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<link href="../styles.css" rel="stylesheet" type="text/css" />
<div class="ReportBody">
    <div class="ReportHeader">
        Report Generator
    </div>
    <div class="ReportDesc">
        Student Best Performance Report
    </div>
    <div class="RepOptions">
        <div class="RepOptInstance">
            <div class="RepLbl">
                <asp:Label class="RLable" ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="RepTxt">
                <asp:DropDownList class="RTxt" ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="RepOptInstance">
            <div class="RepLbl">
                <asp:Label class="RLable" ID="Label2" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="RepTxt">
                <asp:DropDownList class="RTxt" ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="RepOptInstance">
            <div class="RepLbl">
                <asp:Label class="RLable" ID="Label3" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="RepTxt">
                <asp:DropDownList class="RTxt" ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <br />
    <div class="RepPanel">
        <CR:CrystalReportViewer class="RepPanel" ID="ParentDetCrView" runat="server"
            AutoDataBind="true" />
    </div>
</div>

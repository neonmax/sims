<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="Activity_LogUD.aspx.cs" Inherits="Logged_Pages_STD_Activity_Log"
    Title="Student Activity" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="wrap">
        <div id="header">
            <div id="logo2">
                <br />
                <br />
                <br />
                <asp:Label ID="SessionTxt" runat="server" Text="Session Name" Font-Bold="False" Font-Names="Arial"
                    Font-Size="Medium" ForeColor="White"></asp:Label>
                <br />
                <asp:LinkButton ID="LnkLogout" runat="server" ForeColor="Yellow">Logout</asp:LinkButton>
            </div>
        </div>
        <div class="body">
            <div class="form">
                <div class="repBanner">
                    <div class="BannerSpace">
                    </div>
                    <div class="BannerText">
                        Student Activity Log Report
                    </div>
                </div>
                <div class="Reportdescription">
                    You have to give a description about this report. It&#39;ll helps to understand the 
                    outcome of this report.</div>
                <div class="ParaHead">
                </div>
                <div class="ParaMiddle">
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label1" runat="server" Text="Search key"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="TextBox1" runat="server" Width="179px"></asp:TextBox>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Button ID="Button1" runat="server" Text="Search" Width="89px" />
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label2" runat="server" Text="Grade"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="180px" SkinID=" ">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label3" runat="server" Text="Class"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="DropDownList3" runat="server" Width="180px">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label4" runat="server" Text="Admin No"></asp:Label>
                        </div>
                        <asp:DropDownList ID="DropDownList4" runat="server" Width="180px">
                        </asp:DropDownList>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label5" runat="server" Text="Activity Type"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="180px">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label6" runat="server" Text="Activity"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="DropDownList5" runat="server" Width="180px">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label7" runat="server" Text="Activity Year"></asp:Label>
                        </div>
                        <asp:DropDownList ID="DropDownList6" runat="server" Width="180px">
                        </asp:DropDownList>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label8" runat="server" Text="Registered _"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Label ID="Label11" runat="server" Text="Date" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Label ID="Label12" runat="server" Text="Description" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                    </div>
                    <div class="field_3_Row162">
                        <div class="fieldsCaptionCell162">
                        </div>
                        <div class="fieldsElementCell162">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" Font-Size="Small"></asp:Calendar>
                        </div>
                        <div class="fieldsCaptionCell162">
                        </div>
                        <div class="fieldsElementCell162">
                            <asp:TextBox ID="TextBox2" runat="server" Height="160px" TextMode="MultiLine" Width="199px"></asp:TextBox>
                        </div>
                        <div class="fieldsCaptionCell162">
                        </div>
                    </div>
                    <div class="field_3_Row">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                        <asp:Button ID="Button2" runat="server" Text="Generate" Width="106px" />
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="commonChartHolder">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            Height="331px"  Width="814px">
                            <Columns>
                                <asp:ButtonField DataTextField="ADMISSION_NO" HeaderText="Admission Number">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="ACTIVITY_CODE" HeaderText="Activity type">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ACTIVITYSUB_CODE" HeaderText="Activity">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ACTIVITY_YEAR" HeaderText="Activty Year">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ACTIVITY_DESCRIPTION" HeaderText="Description">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MEMBERSHIP_NO" HeaderText="Member No">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DATE_OF_REGISTRATION" HeaderText="Registartion">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="Button" Text="Update">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="ParaBottom">
                </div>
                <br />
            </div>
        </div>
        <div class="con_bot">
        </div>
        <div id="footer">
            <p>
                All rights reserved
                !-- Please DO NOT remove the following notice -->
                <p>
                    Design by SLIIT SEWD 02</p>
                <!-- end of copyright notice-->
        </div>
    </div>
</asp:Content>

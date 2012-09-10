<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_StudentWarning.ascx.cs" Inherits="WUC_StudentWarning" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<div style="height: 553px; width: 950px">
    <div style="z-index: 1; left: 10px; top: 5px; position: absolute; height: 553px; width: 304px">
        <asp:DropDownList ID="ddl_STW_studentid" runat="server" 
            
            
            style="z-index: 1; left: 127px; top: 16px; position: relative; height: 25px; width: 165px" 
            onselectedindexchanged="ddl_STW_studentid_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_studentid" runat="server" Text="Student ID" 
            Font-Bold="True"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_Warningcode" runat="server" Font-Bold="True" 
            Text="Warning Code"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_Levelcode" runat="server" Font-Bold="True" 
            Text="Level Code"></asp:Label>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_Note" runat="server" Font-Bold="True" Text="Notes"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl_STW_Warningcode" runat="server" 
            
            
            style="z-index: 1; left: 128px; top: 75px; position: absolute; height: 25px; width: 165px" 
            AutoPostBack="True">
            <asp:ListItem>N</asp:ListItem>
            <asp:ListItem>NC</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>EC</asp:ListItem>
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl_STW_Levelcode" runat="server" 
            
            
            style="z-index: 1; left: 126px; top: 134px; position: absolute; height: 25px; width: 165px" 
            AutoPostBack="True">
            <asp:ListItem>Normal</asp:ListItem>
            <asp:ListItem>NCritical</asp:ListItem>
            <asp:ListItem>Critical</asp:ListItem>
            <asp:ListItem>ExCritical</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txt_STW_note" runat="server" 
            
            
            style="z-index: 1; left: 66px; top: 195px; position: absolute; width: 229px; height: 148px"></asp:TextBox>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_Informparents" runat="server" Font-Bold="True" 
            Text="Inform Parents"></asp:Label>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl_STW_Informparents" runat="server" 
            
            
            style="z-index: 1; left: 131px; top: 381px; position: absolute; height: 25px; width: 165px" 
            AutoPostBack="True">
            <asp:ListItem Value="1">Yes</asp:ListItem>
            <asp:ListItem Value="0">No</asp:ListItem>
        </asp:DropDownList>
        <asp:ImageButton ID="ibtn_STW_Insert" runat="server" 
            
            
            style="z-index: 1; left: 85px; top: 429px; position: absolute; width: 136px; height: 44px" 
            ImageUrl="~/images/images.jpg" onclick="ibtn_STW_Insert_Click" />
    </div>
    <div style="z-index: 1; left: 317px; top: 17px; position: absolute; height: 225px; width: 643px">
        <asp:GridView ID="gv_STW_Searchresult" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" HorizontalAlign="Center" 
            style="z-index: 1; left: 2px; top: 58px; position: absolute; height: 170px; width: 638px" 
            Width="638px" ShowFooter="True" 
            onrowcommand="gv_STW_Searchresult_RowCommand">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:ButtonField DataTextField="ADMISSION_NO" HeaderText="Admission No" />
                <asp:BoundField DataField="WARNING_CODE" HeaderText="Warning Code" />
                <asp:BoundField DataField="WARN_DATE" HeaderText="Warning Date" />
                <asp:BoundField DataField="LEVEL_CODE" HeaderText="Level" />
                <asp:BoundField DataField="NOTE" HeaderText="Description" />
                <asp:BoundField DataField="INFORM_PARENTS" HeaderText="Parent Informed" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        &nbsp;<br />
&nbsp;<asp:Label ID="lbl_STW_searchstudent" runat="server" Font-Bold="True" 
            Text="Search Student"></asp:Label><asp:DropDownList ID="ddl_STW_Serach" 
            runat="server" AutoPostBack="True"
            
            style="z-index: 1; left: 186px; top: 19px; position: absolute; height: 25px; width: 165px; right: 292px;" 
            onselectedindexchanged="ddl_STW_Serach_SelectedIndexChanged" 
         
            >
        </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ibtn_delete" runat="server" ImageUrl="~/images/delete.jpg" 
            onclick="ibtn_delete_Click" 
            style="position: absolute; z-index: 1; left: 492px; top: 12px; height: 31px; width: 118px" />
    </div>
    <div style="z-index: 1; left: 319px; top: 244px; position: absolute; height: 322px; width: 640px; right: 3px">
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_Heading" runat="server" BackColor="#3399FF" 
            Font-Bold="True" Font-Underline="True" Text="Generate Charts"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_STW_selectchartcatagory" runat="server" Font-Bold="True" 
            Text="Select Chart Type"></asp:Label>
        <asp:DropDownList ID="ddl_STW_chartselect" runat="server" AutoPostBack="True" 
            
            style="z-index: 1; left: 178px; top: 55px; position: absolute; height: 25px; width: 165px; right: 297px" 
            onselectedindexchanged="ddl_STW_chartselect_SelectedIndexChanged" 
            onprerender="ddl_STW_chartselect_PreRender">
            <asp:ListItem Value="0">Based On Level</asp:ListItem>
            <asp:ListItem Value="1">Based On Year</asp:ListItem>
            <asp:ListItem Value="2">Based On Activity</asp:ListItem>
        </asp:DropDownList>
        <br />
        <CR:CrystalReportViewer ID="crv_STW_charts" runat="server" AutoDataBind="true" 
            BestFitPage="False" Height="240px" Width="640px" />
        <br />
    </div>
</div>

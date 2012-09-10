<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_EventManagement.ascx.cs" Inherits="WUC_EventManagement" %>
<p>
    &nbsp;</p>
<div style="z-index: 1; left: 9px; top: 15px; position: absolute; height: 550px; width: 950px">
    <div style="z-index: 1; left: 0px; top: 0px; position: absolute; height: 550px; width: 311px">
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_selecttype" runat="server" Text="Select Type" 
            Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="ddl_SEM_selecttype" runat="server" AutoPostBack="True" 
            
            style="z-index: 1; left: 129px; top: 19px; position: absolute; height: 25px; width: 166px; bottom: 500px;" 
            onselectedindexchanged="ddl_SEM_selecttype_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_selectcatagory" runat="server" Text="Catagory" 
            Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_SEM_catagory" runat="server" Height="25px" Width="158px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_eventname" runat="server" Text="Event Name" 
            Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txt_SEM_eventname" runat="server" AutoPostBack="True" 
            
            
            style="z-index: 1; left: 130px; position: absolute; width: 158px; height: 25px; top: 99px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_description" runat="server" Text="Description" 
            Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txt_SEM_description" runat="server" 
            
            
            style="z-index: 1; left: 95px; top: 138px; position: absolute; width: 192px; height: 137px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_organizer" runat="server" Text="Organizer" 
            Font-Bold="True"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddl_SEM_organizar" runat="server" AutoPostBack="True" 
            
            
            style="z-index: 1; left: 128px; top: 293px; position: absolute; height: 25px; width: 166px">
            <asp:ListItem>School Management</asp:ListItem>
            <asp:ListItem>Student Commities</asp:ListItem>
            <asp:ListItem>OS Association</asp:ListItem>
            <asp:ListItem>Parents</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_issues" runat="server" Text="Faced Issues" 
            Font-Bold="True"></asp:Label>
        <asp:ImageButton ID="ibtn_SEM_insert" runat="server" 
            ImageUrl="~/images/images.jpg" 
            
            
            style="z-index: 1; left: 87px; top: 480px; position: absolute; width: 147px; height: 30px" 
            onclick="ibtn_SEM_insert_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_SEM_issues" runat="server" Height="93px" Width="158px"></asp:TextBox>
    </div>
    <div style="z-index: 1; left: 315px; top: 3px; position: absolute; height: 85px; width: 631px">
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_search" runat="server" Text="Search Event" 
            Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="ddl_SEM_search" runat="server" AutoPostBack="True" 
            
            style="z-index: 1; top: 54px; position: absolute; height: 25px; width: 150px; left: 146px; right: 335px" 
            onselectedindexchanged="ddl_SEM_search_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_SEM_search_selectcatagory" runat="server" 
            Text="Select Catagory" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ibtn_SW_deleterecords" runat="server" Height="22px" 
            ImageUrl="~/images/delete.jpg" onclick="ibtn_SW_deleterecords_Click" 
            Width="86px" />
        </div>
    <div style="z-index: 1; left: 315px; top: 93px; position: absolute; height: 454px; width: 632px">
        <asp:GridView ID="gv_SEM_data" runat="server" 
            
            style="z-index: 1; left: 7px; top: 8px; position: absolute; height: 442px; width: 622px" 
            AutoGenerateColumns="False" onrowcommand="gv_SEM_data_RowCommand">
            <Columns>
                <asp:ButtonField DataTextField="EVENT_ID" HeaderText="Event Number" >
                    <ControlStyle Font-Bold="True" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:ButtonField>
                <asp:BoundField DataField="EVENT_TYPE_MAST" HeaderText="Main Type" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="EVENT_TYPE_SUB" HeaderText="Sub Type" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="EVENT_NAME" HeaderText="Event Name" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="HELD_DATE" HeaderText="Date" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="DESCRIPTION" HeaderText="Description" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ORGANIZER" HeaderText="Organizer" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="FACED_ISSUES" HeaderText="Faced Issues" />
            </Columns>
        </asp:GridView>
    </div>
</div>

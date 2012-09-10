<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="NewAddtoPhotoGallery.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Add to Photo Gallery" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--Start of Calender Toggle By Neon--%>

    <script type="text/javascript" language="javascript">
    function popupCalender() {
        var datefield = document.getElementById('dateField');
       if (dateField.style.display == 'none')
       dateField.style.display= 'block';
       else
       dateField.style.display='none';
    }
    
    
     function popupCalender1() {
        var datefield1 = document.getElementById('dateField1');
       if (dateField1.style.display == 'none')
       dateField1.style.display= 'block';
       else
       dateField1.style.display='none';
    }
    </script>

    <%--End of Calender Toggle By Neon--%>
    
    <link href="../../Notifications/CSS/Style.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/jquery-1.5.1.js" type="text/javascript"></script>

    <script src="../../lib/Jquery-Impromptu.3.3.js" type="text/javascript"></script>

    <script src="../../lib/DeepASPImpromptuCalling.js" type="text/javascript"></script>
    
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
                        Add New Photographs to Photo Gallery
                    </div>
                </div>
                <div class="FormHeadder">
                </div>
                <div class="FormBackgroundAddAppointment">
                
                        <asp:ScriptManager ID="HmScptMng" runat="server">
        </asp:ScriptManager>
   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>

                
                    <div class="paraSpace">
                    </div>
                      <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Grade"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddlGrade" 
                                runat="server" Height="20px" Width="185px"
                                    AutoPostBack="true" 
                                OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
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
                            <asp:Label runat="server" class="RLable" Text="Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList class="RTxt" CssClass="FormTxtBox " ID="ddlClass" 
                                runat="server" Height="20px" Width="185px"
                                    OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" 
                                AutoPostBack="true">
                                <asp:ListItem Value="0">Select Class</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label14" runat="server" class="RLable" Text="Student :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                           <asp:DropDownList class="RTxt" CssClass="FormTxtBox "  ID="ddlStudent" runat="server" Height="20px" Width="185px"
                                    OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0">Select Student</asp:ListItem>
                                </asp:DropDownList>
                                
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Admission No :" ID="Label18"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAdNo" runat="server" CssClass="FormTxtBox "  Width="185px" 
                                ValidationGroup="submit"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtAdNo" ErrorMessage="Please Enter Admission Number" 
                            ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                   
                    
                     </ContentTemplate>
        </asp:UpdatePanel>
                    
                    
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label7" runat="server" class="RLable" Text="Photograph :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:FileUpload ID="fuStudentImage" runat="server" CssClass="FormTxtBox" Font-Size="12px"
                                Width="234px" />
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="fuStudentImage" 
                            ErrorMessage="Please Select a Photo to upload." ValidationGroup="submit"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblError" ForeColor="Red" runat="server" Font-Size="Small"></asp:Label>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                       <div class="field_3_Row162auto">
                        <div class="fieldsCaptionCell162auto">
                            <asp:Label runat="server" class="RLable" Text="Note :" ID="Label3"></asp:Label>
                        </div>
                      
                            <asp:TextBox ID="txtNote" runat="server" Height="97px" TextMode="MultiLine"  
                            CssClass="FormTxtBox " Width="669px"></asp:TextBox>
                        
                           &nbsp;&nbsp;
                        <br />
                    </div>
                     <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Upload"
                                Width="142px" Height="30px" CssClass="buttonText" 
                                ValidationGroup="submit" />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnReset" runat="server" CauseValidation="False" OnClick="btnReset_Click"
                                Text="Reset" AutoPostBack="true" Width="143px" CssClass="buttonText" 
                                Height="30px" ValidationGroup="reset" />
                        </div>
                    </div>
                </div>
                <div class="FormFooter">
                </div>

    </div>
</asp:Content>

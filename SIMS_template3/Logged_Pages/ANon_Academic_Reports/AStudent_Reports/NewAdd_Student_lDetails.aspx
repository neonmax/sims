<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="NewAdd_Student_lDetails.aspx.cs" Inherits="Logged_Pages_AParents_Reports_Parent_Info"
    Title="Add Student Details" %>

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
     <%-- --%>
                <div class="ReportBody">
                    <div class="ReportHeader">
                        Student Details
                    </div>
                    <div class="ReportDesc">
                        Add Student Personal Details
                        <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
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
                            <asp:Label runat="server" Text="Admission No :" ID="Label1"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAdNo" runat="server" CssClass="FormTextBox " Width="180px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter Admission Number"
                            ControlToValidate="txtAdNo" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Name in Full :" ID="Label2"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtFullName" runat="server" Class="FormTxtBox " Width="550px"></asp:TextBox>
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Full Name."
                            ControlToValidate="txtFullName" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Name with initials :" ID="Label3"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtNameInitials" runat="server" Class="FormTxtBox " Width="550px"></asp:TextBox>
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <div class="fieldsElementCell">
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNameInitials"
                            ErrorMessage="Please enter Name with Initials." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Birth Certificate No" ID="Label20"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtBirthCno" runat="server" Width="180px" CssClass="FormTxtBox"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBirthCno"
                            ErrorMessage="Please enter a Birth Certificate Number." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="fieldsCaptionCell">
                        <asp:Label ID="Label5" runat="server" class="RLable" Text="Gender :"></asp:Label>
                    </div>
                    <div class="elementBox">
                        <asp:RadioButtonList ID="rblGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rblGender"
                            ErrorMessage="Please select the gender." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label runat="server" class="RLable" Text="Date of Birth :" ID="Label4"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtDate" runat="server" Width="165px" CssClass="FormTxtBox"></asp:TextBox>
                            <img src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender()" />
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label6" runat="server" class="RLable" Text="Date of Admission"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtDateAd" runat="server" Width="165px" CssClass="FormTxtBox"></asp:TextBox>
                            <img src="../../images/Calendar_scheduleHS.png" alt="Picture" border="0" onclick="popupCalender1()" />
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDateAd"
                            ErrorMessage="Please select the Admission Date." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div id="dateField" style="display: none; padding-left: 100px">
                        <asp:Calendar ID="calDob" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                            OnSelectionChanged="calDob_SelectionChanged">
                            <SelectedDayStyle ForeColor="#0000CC" />
                            <WeekendDayStyle ForeColor="Red" />
                            <OtherMonthDayStyle ForeColor="#999966" />
                        </asp:Calendar>
                    </div>
                    <div id="dateField1" style="display: none; padding-left: 400px">
                        <asp:Calendar ID="calDoa" runat="server" AutoPostBack="true" FirstDayOfWeek="Monday"
                            OnSelectionChanged="calDoa_SelectionChanged">
                            <SelectedDayStyle ForeColor="#0000CC" />
                            <WeekendDayStyle ForeColor="Red" />
                            <OtherMonthDayStyle ForeColor="#999966" />
                        </asp:Calendar>
                    </div>
                    <div class="paraSpace">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDate"
                            ErrorMessage="Please select the Date of Birth." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="fieldsCaptionCell">
                        <div class="elementBoxBig">
                            <asp:Label ID="Label21" runat="server" class="RLable" Text="Nationality :"></asp:Label>
                        </div>
                    </div>
                    <div class="fieldsElementCell">
                        <asp:RadioButtonList ID="rblNationality" runat="server">
                            <asp:ListItem>Sinhalese</asp:ListItem>
                            <asp:ListItem>Muslim</asp:ListItem>
                            <asp:ListItem>Tamil</asp:ListItem>
                            <asp:ListItem>Burgher</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="fieldsCaptionCell">
                        <asp:Label ID="Label22" runat="server" class="RLable" Text="Religion :"></asp:Label>
                    </div>
                    <div class="fieldsElementCell">
                        <asp:RadioButtonList ID="rblReligion" runat="server" Height="34px" Width="198px">
                            <asp:ListItem>Buddhism</asp:ListItem>
                            <asp:ListItem>Christian</asp:ListItem>
                            <asp:ListItem>Muslim</asp:ListItem>
                            <asp:ListItem>Hindu</asp:ListItem>
                            <asp:ListItem>Roman Catholic</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rblNationality"
                            ErrorMessage="Please select the Nationality." ValidationGroup="submit"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rblReligion"
                            ErrorMessage="Please select the Religion." ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label12" runat="server" class="RLable" Text="Admission Grade :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="true" class="RTxt" Height="20px"
                                Width="180px" CssClass="FormTxtBox">
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
                            <asp:Label ID="Label13" runat="server" class="RLable" Text="Admission Class :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="true" class="RTxt" Height="20px"
                                Width="180px" CssClass="FormTxtBox">
                                <asp:ListItem Value="0">Select Class</asp:ListItem>
                                <asp:ListItem Value="A">A</asp:ListItem>
                                <asp:ListItem Value="B">B</asp:ListItem>
                                <asp:ListItem Value="C">C</asp:ListItem>
                                <asp:ListItem Value="D">D</asp:ListItem>
                                <asp:ListItem Value="E">E</asp:ListItem>
                                <asp:ListItem Value="F">F</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label15" runat="server" class="RLable" Text="Previous School :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtPrevSchl" runat="server" CssClass="FormTxtBox " Width="550px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label16" runat="server" class="RLable" Text="Address :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAddressL1" runat="server" CssClass="FormTxtBox " Width="180px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label8" runat="server" class="RLable" Text="District :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" class="RTxt"
                                CssClass="FormTxtBox" Height="20px" Width="180px" 
                                onselectedindexchanged="ddlDistrict_SelectedIndexChanged" >
                                <asp:ListItem Value="0">Select District</asp:ListItem>
                                <asp:ListItem Value="1">Ampara</asp:ListItem>
                                <asp:ListItem Value="2">Anuradhapura</asp:ListItem>
                                <asp:ListItem Value="3">Badulla</asp:ListItem>
                                <asp:ListItem Value="4">Batticaloa</asp:ListItem>
                                <asp:ListItem Value="5">Colombo</asp:ListItem>
                                <asp:ListItem Value="6">Galle</asp:ListItem>
                                <asp:ListItem Value="7">Gampaha</asp:ListItem>
                                <asp:ListItem Value="8">Hambantota</asp:ListItem>
                                <asp:ListItem Value="9">Jaffna</asp:ListItem>
                                <asp:ListItem Value="10">Kalutara</asp:ListItem>
                                <asp:ListItem Value="11">Kandy</asp:ListItem>
                                <asp:ListItem Value="12">Kegalle</asp:ListItem>
                                <asp:ListItem Value="13">Kilinochchi</asp:ListItem>
                                <asp:ListItem Value="14">Kurunegala</asp:ListItem>
                                <asp:ListItem Value="15">Mannar</asp:ListItem>
                                <asp:ListItem Value="16">Matale</asp:ListItem>
                                <asp:ListItem Value="17">Matara</asp:ListItem>
                                <asp:ListItem Value="18">Moneragala</asp:ListItem>
                                <asp:ListItem Value="19">Mullaitivu</asp:ListItem>
                                <asp:ListItem Value="20">Nuwara Eliya</asp:ListItem>
                                <asp:ListItem Value="21">Polonnaruwa</asp:ListItem>
                                <asp:ListItem Value="22">Puttalam</asp:ListItem>
                                <asp:ListItem Value="23">Ratnapura</asp:ListItem>
                                <asp:ListItem Value="24">Trincomalee</asp:ListItem>
                                <asp:ListItem Value="25">Vavuniya</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label9" runat="server" class="RLable" Text="Address :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAddressL2" runat="server" CssClass="FormTxtBox " Width="550px"></asp:TextBox>
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please enter the Address."
                            ControlToValidate="txtAddressL2" ValidationGroup="submit"></asp:RequiredFieldValidator>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label10" runat="server" class="RLable" Text="Address :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAddressL3" runat="server" CssClass="FormTxtBox " Width="550px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label11" runat="server" class="RLable" Text="Address :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtAddressL4" runat="server" CssClass="FormTxtBox " Width="550px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                            <asp:Label ID="Label17" runat="server" class="RLable" Text="Telephone No :"></asp:Label>
                        </div>
                        <div class="fieldsElementCell">
                            <asp:TextBox ID="txtTelNo" runat="server" CssClass="FormTxtBox" Width="180px"></asp:TextBox>
                        </div>
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
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsCaptionCell">
                        </div>
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="paraSpace">
                    </div>
                    <div class="FormRow">
                        <div class="fieldsCaptionCell">
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                Width="142px" Height="30px" CssClass="buttonText" ValidationGroup="submit" />
                        </div>
                        <div class="fieldsElementCell">
                            <asp:Button ID="btnReset" runat="server" CauseValidation="False" OnClick="btnReset_Click"
                                Text="Reset" AutoPostBack="true" Width="143px" CssClass="buttonText" Height="30px" />
                        </div>
                    </div>
                </div>
                <div class="FormFooter">
                </div>
     <%-- --%>
    </div>
</asp:Content>

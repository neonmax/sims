<%@ Page Language="C#" MasterPageFile="~/Logged_Pages/ReportTemplate_n.master" AutoEventWireup="true"
    CodeFile="SendSMS1.aspx.cs" Inherits="Logged_Pages_AParents_Reports_SendSMS" Title="SMS_Center" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        <div class="con_top">
        </div>
        <div class="body">
            <div class="form">
                <div class="SmsBanner">
                    <div class="BannerSpace">
                    </div>
                    <div class="BannerText">
                    </div>
                </div>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <div class="Reportdescription" style="color: #FF0000">
                    Notice : The all messages will be sent to parents's mobile numbers.</div>
                <div class="SMS_Holder">
                    <div class="SMS_top">
                    </div>
                    <div class="SMS_Middle">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="SMSFiledRow">
                                    <asp:TabContainer ID="TabCon1" runat="server" ActiveTabIndex="4" Width="927px" 
                                        ForeColor="#000066">
                                        <asp:TabPanel runat="server" HeaderText="Send to  all Parents" ID="TabPanel1">
                                            <HeaderTemplate>
                                                <span class="SMStab">Send to all Parents</span>
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <asp:Label ID="LblCoution" runat="server" ForeColor="#990000" Text="CAUTION : This function sends Short Messages(SMS) to all students in selected school."></asp:Label><br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsElementCell">
                                                        <asp:Label ID="Label1" runat="server" Text="Student Count :"></asp:Label>
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                        <asp:TextBox ID="txtSchlCount" runat="server" Height="20px" Width="190px" ValidationGroup="sendSMSAll"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSchlCount"
                                                        ErrorMessage="*Student list is Empty   " ValidationGroup="sendSMSAll"></asp:RequiredFieldValidator>
                                                    <br>
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsElementCell">
                                                                <asp:Label ID="Label2" runat="server" Text="Sender description :"></asp:Label>
                                                            </div>
                                                            <div class="fieldsElementCell">
                                                                <asp:TextBox ID="txt_All_Sender" runat="server" Height="20px" ValidationGroup="sendSMSAll"
                                                                    Width="193px"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_All_Sender"
                                                                ErrorMessage="*Empty sender details not allowed   " ValidationGroup="sendSMSAll"></asp:RequiredFieldValidator>
                                                            <br />
                                                            <br />
                                                            <div class="sms_Row_field">
                                                                <div class="fieldsElementCell">
                                                                    <asp:Label ID="Label3" runat="server" Text="Message :"></asp:Label>
                                                                </div>
                                                                <asp:TextBox ID="txt_all_Msg" runat="server" Height="60px" TextMode="MultiLine" ValidationGroup="sendSMSAll"
                                                                    Width="450px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_all_Msg"
                                                                    ErrorMessage="*Empty message not allowed   " ValidationGroup="sendSMSAll"></asp:RequiredFieldValidator>
                                                                <asp:ResizableControlExtender ID="ResizableControlExtender5" runat="server" Enabled="True"
                                                                    HandleCssClass="resizer" MaximumHeight="60" MaximumWidth="450" MinimumHeight="50"
                                                                    MinimumWidth="440" ResizableCssClass="resizer" TargetControlID="txt_all_Msg">
                                                                </asp:ResizableControlExtender>
                                                                <br />
                                                                <br />
                                                            </div>
                                                            <br />
                                                            <br />
                                                            <div class="sms_Row_field">
                                                                <div class="fieldsCaptionCell">
                                                                </div>
                                                                <div class="fieldsCaptionCell">
                                                                </div>
                                                                <div class="fieldsCaptionCell">
                                                                </div>
                                                                <div class="fieldsCaptionCell">
                                                                </div>
                                                                <div class="fieldsCaptionCell">
                                                                    <asp:Button ID="btnSendAllRst" runat="server" CssClass="buttonText" Height="21px"
                                                                        Text="Reset" ToolTip="To clear the Fields" ValidationGroup=" " Width="90px" OnClick="btnSendAllRst_Click" />
                                                                </div>
                                                                <div class="fieldsCaptionCell">
                                                                    <asp:Button ID="btnAllSend" runat="server" CssClass="buttonText" Height="21px" Text="Send"
                                                                        ToolTip="Click to send SMS" ValidationGroup="sendSMSAll" Width="90px" OnClick="btnAllSend_Click" />
                                                                </div>
                                                                <asp:ImageButton ID="ImgAll" runat="server" Height="24px" ImageUrl="~/Logged_Pages/images/ajax-loader.gif"
                                                                    Visible="False" Width="24px" />
                                                                <asp:Label ID="lblAllStatu" runat="server" Font-Size="12px" ForeColor="#00CC00"
                                                                    Text="Sending..." Visible="False"></asp:Label>
                                                            </div>
                                                        </div>
                                                    
                                                    </br>
                                                </div>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Notify Parents of a Grade">
                                            <HeaderTemplate>
                                                <span class="SMStab">Notify Parents of a Grade</span>
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                Please complete the given fields_
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsCaptionCell">
                                                        <asp:Label ID="Label6" runat="server" Text="Grade"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnGrade" runat="server" Width="180px" ToolTip="Choose a Grade"
                                                            AutoPostBack="True">
                                                            <asp:ListItem>Grade 10</asp:ListItem>
                                                            <asp:ListItem>Grade 11</asp:ListItem>
                                                            <asp:ListItem>Grade 12</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                    </div>
                                                    <br>
                                                        <div class="sms_Row_field">
                                                            <asp:Label ID="Label19" runat="server" ForeColor="#0099CC" Text="( Before send the message, you have to SELECT a GRADE from the dropdown list )"></asp:Label>
                                                        </div>
                                                        <hr />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsElementCell">
                                                                <asp:Label ID="Label20" runat="server" Text="Student Count :"></asp:Label>
                                                            </div>
                                                            <div class="fieldsElementCell">
                                                                <asp:TextBox ID="txtStdCount_grade" runat="server" Height="20px" ValidationGroup="sendSMSGrade"
                                                                    Width="190px"></asp:TextBox>
                                                            </div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtStdCount_grade"
                                                                ErrorMessage="*Student list is Empty   " ValidationGroup="sendSMSGrade"></asp:RequiredFieldValidator>
                                                            <br />
                                                            <br />
                                                            <div class="sms_Row_field">
                                                                <div class="fieldsElementCell">
                                                                    <asp:Label ID="Label21" runat="server" Text="Sender description :"></asp:Label>
                                                                </div>
                                                                <div class="fieldsElementCell">
                                                                    <asp:TextBox ID="txt_Grade_sender" runat="server" ValidationGroup="sendSMSGrade"
                                                                        Width="193px"></asp:TextBox>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_Grade_sender"
                                                                    ErrorMessage="*Empty sender details not allowed   " ValidationGroup="sendSMSGrade"></asp:RequiredFieldValidator>
                                                                <br />
                                                                <br />
                                                                <div class="sms_Row_field">
                                                                    <div class="fieldsElementCell">
                                                                        <asp:Label ID="Label22" runat="server" Text="Message :"></asp:Label>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_Grade_Msg" runat="server" Height="60px" TextMode="MultiLine"
                                                                        ValidationGroup="sendSMSGrade" Width="450px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_Grade_Msg"
                                                                        ErrorMessage="*Empty message not allowed   " ValidationGroup="sendSMSGrade"></asp:RequiredFieldValidator>
                                                                    <asp:ResizableControlExtender ID="ResizableControlExtender4" runat="server" Enabled="True"
                                                                        HandleCssClass="resizer" MaximumHeight="60" MaximumWidth="450" MinimumHeight="50"
                                                                        MinimumWidth="440" ResizableCssClass="resizer" TargetControlID="txt_Grade_Msg">
                                                                    </asp:ResizableControlExtender>
                                                                    <br />
                                                                </div>
                                                                <br />
                                                                <div class="sms_Row_field">
                                                                    <div class="fieldsCaptionCell">
                                                                    </div>
                                                                    <div class="fieldsCaptionCell">
                                                                    </div>
                                                                    <div class="fieldsCaptionCell">
                                                                    </div>
                                                                    <div class="fieldsCaptionCell">
                                                                    </div>
                                                                    <div class="fieldsCaptionCell">
                                                                        <asp:Button ID="btnGardeRst" runat="server" CssClass="buttonText" Height="21px" OnClick="btnGardeRst_Click"
                                                                            Text="Reset" ToolTip="To clear the Fields" ValidationGroup="sendSMSGrade" Width="90px" />
                                                                    </div>
                                                                    <div class="fieldsCaptionCell">
                                                                        <asp:Button ID="btnSendGrade" runat="server" CssClass="buttonText" Height="21px"
                                                                            OnClick="btnSendGrade_Click" Text="Send" ToolTip="Click to Send SMS" ValidationGroup="sendSMSGrade"
                                                                            Width="90px" />
                                                                    </div>
                                                                    <asp:ImageButton ID="ImgGrade" runat="server" Height="24px" ImageUrl="~/Logged_Pages/images/ajax-loader.gif"
                                                                        Visible="False" Width="24px" />
                                                                    <asp:Label ID="lblGradeStatus" runat="server" Font-Size="12px" ForeColor="#00CC00"
                                                                        Text="Sending..." Visible="False"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </br>
                                                </div>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Notify Parents of a Class">
                                            <HeaderTemplate>
                                                <span class="SMStab">Notify Parents of a Class</span>
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                Please complete the given fields_
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsCaptionCell">
                                                        <asp:Label ID="Label4" runat="server" Text="Grade"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnClassGrade" runat="server" Width="180px" ToolTip="Choose a Grade"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDwnClassGrade_SelectedIndexChanged">
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
                                                        <asp:Label ID="lblClassClass" runat="server" Text="Class" Visible="False"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnClassClass" runat="server" Width="180px" ToolTip="Choose a Class"
                                                            AutoPostBack="True" Visible="False">
                                                            <asp:ListItem>A</asp:ListItem>
                                                            <asp:ListItem>B</asp:ListItem>
                                                            <asp:ListItem>C</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                    </div>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </div>
                                                <br />
                                                <div class="sms_Row_field">
                                                    <asp:Label ID="Label24" runat="server" Text="( Before send the message, you have to SELECT a CLASS from the dropdown list )"></asp:Label>
                                                </div>
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsElementCell">
                                                        <asp:Label ID="Label25" runat="server" Text="Student Count :"></asp:Label>
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                        <asp:TextBox ID="txtCnt_Class" runat="server" Width="187px" ValidationGroup="sendSMSClass"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCnt_Class"
                                                        ErrorMessage="*Empty student name not allowed   " ValidationGroup="sendSMSClass"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <br />
                                                    <div class="sms_Row_field">
                                                        <div class="fieldsElementCell">
                                                            <asp:Label ID="Label26" runat="server" Text="Sender description :"></asp:Label>
                                                        </div>
                                                        <div class="fieldsElementCell">
                                                            <asp:TextBox ID="txt_Class_sender" runat="server" Width="193px" ValidationGroup="sendSMSClass"></asp:TextBox>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_Class_sender"
                                                            ErrorMessage="*Empty sender details not allowed   " ValidationGroup="sendSMSClass"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsElementCell">
                                                                <asp:Label ID="Label27" runat="server" Text="Message :"></asp:Label>
                                                            </div>
                                                            <asp:TextBox ID="txt_Class_Msg" runat="server" ValidationGroup="sendSMSClass" Width="450px"
                                                                Height="60px" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_Class_Msg"
                                                                ErrorMessage="*Empty message not allowed   " ValidationGroup="sendSMSClass"></asp:RequiredFieldValidator>
                                                            <asp:ResizableControlExtender ID="ResizableControlExtender3" runat="server" MinimumHeight="50"
                                                                MinimumWidth="440" MaximumHeight="60" MaximumWidth="450" Enabled="True" TargetControlID="txt_Class_Msg"
                                                                HandleCssClass="resizer" ResizableCssClass="resizer">
                                                            </asp:ResizableControlExtender>
                                                            <br />
                                                            <br />
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                                <asp:Button ID="btnClassRst" runat="server" CssClass="buttonText" Text="Reset" Width="69px"
                                                                    Height="21px" ValidationGroup=" " ToolTip="To clear the Fields" OnClick="btnClassRst_Click" />
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                                <asp:Button ID="btnClassSend" runat="server" CssClass="buttonText" Text="Send" ValidationGroup="sendSMSClass"
                                                                    Width="90px" Height="21px" OnClick="btnClassSend_Click" ToolTip="Click to send SMS" />
                                                            </div>
                                                            <asp:ImageButton ID="ImgClass" runat="server" Height="24px" ImageUrl="~/Logged_Pages/images/ajax-loader.gif"
                                                                Visible="False" Width="24px" />
                                                            <asp:Label ID="lblClassStatus" runat="server" Font-Size="12px" ForeColor="#00CC00"
                                                                Text="Sending..." Visible="False"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Notify Parents individualy">
                                            <HeaderTemplate>
                                                <span class="SMStab">Notify Parents individualy</span>
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                Please complete the given fields_
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsCaptionCell">
                                                        <asp:Label ID="Label11" runat="server" Text="Grade"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnIndGrade" runat="server" Width="180px" ToolTip="Choose a Grade"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDwnIndGrade_SelectedIndexChanged">
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
                                                        <asp:Label ID="lblIndClass" runat="server" Text="Class" Visible="False"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnIndClass" runat="server" Width="180px" ToolTip="Choose a Class"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDwnIndClass_SelectedIndexChanged"
                                                            Visible="False">
                                                            <asp:ListItem>A</asp:ListItem>
                                                            <asp:ListItem>B</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="fieldsCaptionCell">
                                                        <asp:Label ID="lblIndstdID" runat="server" Text="Student ID" Visible="False"></asp:Label></div>
                                                    <asp:DropDownList ID="DrpDwnIndStd" runat="server" Width="180px" ToolTip="Choose a Student name"
                                                        AutoPostBack="True" Height="20px" OnSelectedIndexChanged="DrpDwnIndStd_SelectedIndexChanged"
                                                        Visible="False">
                                                        <asp:ListItem>Shyamike</asp:ListItem>
                                                        <asp:ListItem>946233138</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br>
                                                </div>
                                                <br />
                                                <div class="sms_Row_field">
                                                    <asp:Label ID="Label14" runat="server" Text="( Before send the message, you have to choose GRADE, CLASS, STUDENT from dropdown lists )"
                                                        ForeColor="#0099CC"></asp:Label>
                                                </div>
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsElementCell">
                                                        <asp:Label ID="Label15" runat="server" Text="Parent's Mobile No :"></asp:Label>
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                        <asp:TextBox ID="txtStdPrntNo" runat="server" Width="187px" ValidationGroup="sendSMSInd"
                                                            ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStdPrntNo"
                                                        ErrorMessage="*Empty student name not allowed   " ValidationGroup="sendSMSInd"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <br />
                                                    <div class="sms_Row_field">
                                                        <div class="fieldsElementCell">
                                                            <asp:Label ID="Label16" runat="server" Text="Sender description :"></asp:Label>
                                                        </div>
                                                        <div class="fieldsElementCell">
                                                            <asp:TextBox ID="txt_Ind_Sender" runat="server" Width="193px" ValidationGroup="sendSMSInd"></asp:TextBox>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Ind_Sender"
                                                            ErrorMessage="*Empty sender details not allowed   " ValidationGroup="sendSMSInd"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsElementCell">
                                                                <asp:Label ID="Label17" runat="server" Text="Message :"></asp:Label>
                                                            </div>
                                                            <asp:TextBox ID="txt_Ind_Msg" runat="server" ValidationGroup="sendSMSInd" Width="450px"
                                                                Height="60px" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_Ind_Msg"
                                                                ErrorMessage="*Empty message not allowed   " ValidationGroup="sendSMSInd"></asp:RequiredFieldValidator>
                                                            <asp:ResizableControlExtender ID="ResizableControlExtender2" runat="server" MinimumHeight="50"
                                                                MinimumWidth="440" MaximumHeight="60" MaximumWidth="450" Enabled="True" TargetControlID="txt_Ind_Msg"
                                                                HandleCssClass="resizer" ResizableCssClass="resizer">
                                                            </asp:ResizableControlExtender>
                                                            <br />
                                                            <br />
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                                <asp:Button ID="btnIndRst" runat="server" CssClass="buttonText" Text="Reset" Width="90px"
                                                                    Height="21px" ValidationGroup=" " ToolTip="To clear the Fields" OnClick="btnIndRst_Click" />
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                                <asp:Button ID="btnIndSend" runat="server" CssClass="buttonText" Text="Send" ValidationGroup="sendSMSInd"
                                                                    Width="90px" Height="21px" OnClick="btnIndSend_Click" ToolTip="Click to send SMS" />
                                                            </div>
                                                            <asp:ImageButton ID="ImgInd" runat="server" Height="24px" ImageUrl="~/Logged_Pages/images/ajax-loader.gif"
                                                                Visible="False" Width="24px" />
                                                            <asp:Label ID="lblIndStatus" runat="server" Font-Size="12px" ForeColor="#00CC00"
                                                                Text="Sending..." Visible="False"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Notify selected Parent Group">
                                            <HeaderTemplate>
                                                <span class="SMStab">Notify selected Parent Group </span>
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                Please complete the given fields_
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsCaptionCell">
                                                        <asp:Label ID="Label7" runat="server" Text="Grade"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnGroupGrade" runat="server" Width="180px" ToolTip="Choose a Grade"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDwnGroupGrade_SelectedIndexChanged1">
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
                                                        <asp:Label ID="lblGrpClas" runat="server" Text="Class" Visible="False"></asp:Label></div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpDwnGroupCla" runat="server" Width="180px" ToolTip="Choose a Class"
                                                            AutoPostBack="True" OnSelectedIndexChanged="DrpDwnGroupClass_SelectedIndexChanged"
                                                            Visible="False">
                                                            <asp:ListItem>A</asp:ListItem>
                                                            <asp:ListItem>B</asp:ListItem>
                                                            <asp:ListItem>C</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="fieldsCaptionCell">
                                                        <asp:Label ID="lblGrpStd" runat="server" Text="Student ID" Visible="False"></asp:Label></div>
                                                    <asp:DropDownList ID="DrpDwnGroupStd" runat="server" Width="180px" ToolTip="Choose a Student name"
                                                        Visible="False" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="DrpDwnGroupStd_SelectedIndexChanged">
                                                        <asp:ListItem>Shyamike</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br>
                                                </div>
                                                <br />
                                                <div class="sms_Row_field">
                                                    <asp:Label ID="lblGrpDesc" runat="server" Text="( Before send the message, you have to add students   from the dropdown list, then press ADD )     "
                                                        ForeColor="#0099CC"></asp:Label>
                                                    <asp:Button ID="BtnAddGrp" runat="server" Height="21px" Text="Add " Width="90px"
                                                        CssClass="buttonText" ToolTip="Click to ADD the student" 
                                                        onclick="BtnAddGrp_Click" />
                                                    <asp:Label ID="lblMobNo" runat="server" Text="Label"></asp:Label>
                                                </div>
                                                <br />
                                                <hr />
                                                <br />
                                                <div class="sms_Row_field">
                                                    <div class="fieldsElementCell">
                                                        <asp:Label ID="Label10" runat="server" Text="Student Group :"></asp:Label>
                                                    </div>
                                                    <div class="fieldsElementCell">
                                                        <asp:DropDownList ID="DrpdwnStdList" runat="server" Width="180px" ValidationGroup="sendSMSGroup"
                                                            ToolTip="Expand to view the student list" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DrpdwnStdList"
                                                        ErrorMessage="*Empty group not allowed   " ValidationGroup="sendSMSGroup"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="Label28" runat="server" ForeColor="#FF9900"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <div class="sms_Row_field">
                                                        <div class="fieldsElementCell">
                                                            <asp:Label ID="lblSender" runat="server" Text="Sender description :"></asp:Label>
                                                        </div>
                                                        <div class="fieldsElementCell">
                                                            <asp:TextBox ID="txtSenderGrp" runat="server" Width="193px" ValidationGroup="sendSMSGroup"></asp:TextBox>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSenderGrp"
                                                            ErrorMessage="*Empty sender details not allowed   " ValidationGroup="sendSMSGroup"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsElementCell">
                                                                <asp:Label ID="lblMsg" runat="server" Text="Message :"></asp:Label>
                                                            </div>
                                                            <asp:TextBox ID="txtMsgGroup" runat="server" ValidationGroup="sendSMSGroup" Width="450px"
                                                                Height="60px" MaxLength="120" SkinID="Your Text Message Here" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMsgGroup"
                                                                ErrorMessage="*Empty message not allowed   " ValidationGroup="sendSMSGroup"></asp:RequiredFieldValidator>
                                                            <asp:ResizableControlExtender ID="ResizableControlExtender1" runat="server" MinimumHeight="50"
                                                                MinimumWidth="440" MaximumHeight="60" MaximumWidth="450" Enabled="True" TargetControlID="txtMsgGroup"
                                                                HandleCssClass="resizer" ResizableCssClass="resizer">
                                                            </asp:ResizableControlExtender>
                                                            <br />
                                                            <br />
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div class="sms_Row_field">
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                                <asp:Button ID="BtnRstGrp" runat="server" CssClass="buttonText" Text="Reset" Width="90px"
                                                                    Height="21px" ValidationGroup=" " ToolTip="To clear the Fields" OnClick="BtnRstGrp_Click" />
                                                            </div>
                                                            <div class="fieldsCaptionCell">
                                                                <asp:Button ID="btnSendGrp" runat="server" CssClass="buttonText" Text="Send" ValidationGroup="sendSMSGroup"
                                                                    Width="90px" Height="21px" OnClick="btnSendGrp_Click" ToolTip="Click to send SMS" />
                                                            </div>
                                                            <asp:ImageButton ID="ImgProcessGrp" runat="server" Height="24px" ImageUrl="~/Logged_Pages/images/ajax-loader.gif"
                                                                Visible="False" Width="24px" />
                                                            <asp:Label ID="lblStstusGrp" runat="server" Font-Size="12px" ForeColor="#00CC00"
                                                                Text="Sending..." Visible="False"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="SMS_Bottom">
                    </div>
                </div>
                <br />
            </div>
        </div>
        <div class="con_bot">
        </div>
        <div id="footer">
            <p>
                All rights reserved             </p>
        </div>
    </div>
</asp:Content>

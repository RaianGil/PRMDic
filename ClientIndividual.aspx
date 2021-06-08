<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
        <%@ Page language="c#" Inherits="EPolicy.ClientIndividual" CodeFile="ClientIndividual.aspx.cs" %>
            <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
            <HTML>

            <HEAD>
                <title>ePMS | electronic Policy Manager Solution</title>
                <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
                <meta content="C#" name="CODE_LANGUAGE">
                <meta content="JavaScript" name="vs_defaultClientScript">
                <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
                <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

                <script>
                    $(function() {
                        $('#<%= txtBirthdate.ClientID %>').datepicker({
                            changeMonth: true,
                            changeYear: true
                        });
                    });

                    function ShowDateTimePicker() {
                        $('#<%= txtBirthdate.ClientID %>').datepicker('show');
                    }

                    function getAge() {
                        pdt = new Date(document.form1.txtBirthdate.value);
                        today = new Date("<%=today%>");

                        age = (today.getFullYear() - pdt.getFullYear());
                        day = pdt.getDay();
                        month = pdt.getMonth();

                        if (month == today.getMonth()) {
                            if (day > today.getDay()) {
                                age = age - 1;
                            }
                        } else {
                            if (month > today.getMonth()) {
                                age = age - 1;
                            }
                        }


                        if (age >= 0) {
                            document.form1.TxtAge.value = age;
                        }
                    }
                </script>
                <script>
                    $(function() {
                        $('#<%= txtlicexpdate.ClientID %>').datepicker({
                            changeMonth: true,
                            changeYear: true
                        });
                    });

                    function ShowDateTimePicker1() {
                        $('#<%= txtlicexpdate.ClientID %>').datepicker('show');
                    }

                    function getAge() {
                        pdt = new Date(document.form1.txtlicexpdate.value);
                        today = new Date("<%=today%>");

                        age = (today.getFullYear() - pdt.getFullYear());
                        day = pdt.getDay();
                        month = pdt.getMonth();

                        if (month == today.getMonth()) {
                            if (day > today.getDay()) {
                                age = age - 1;
                            }
                        } else {
                            if (month > today.getMonth()) {
                                age = age - 1;
                            }
                        }


                        if (age >= 0) {
                            document.form1.TxtAge.value = age;
                        }
                    }
                </script>
                <script>
                    function onButtonClick() {
                        document.getElementById('txtPass').className = "show";
                        document.getElementById('btnValidate').className = "show";



                    }
                </script>
                <style>
                    .hide {
                        display: none;
                    }
                    
                    .show {
                        display: block;
                    }
                </style>
                <style type="text/css">
                    .headfield1 {
                        font-family: Tahoma;
                        margin-bottom: 0px;
                    }
                    
                    .headForm1 {
                        margin-right: 3px;
                        margin-left: 0px;
                    }
                    
                    .style1 {
                        height: 2px;
                    }
                    
                    .style2 {
                        height: 26px;
                        width: 240px;
                    }
                    
                    .style3 {
                        height: 15px;
                        width: 240px;
                    }
                    
                    .style4 {
                        height: 12px;
                        width: 240px;
                    }
                    
                    .style5 {
                        height: 11px;
                        width: 240px;
                    }
                    
                    .style6 {
                        height: 23px;
                        width: 240px;
                    }
                    
                    .style7 {
                        height: 20px;
                        width: 240px;
                    }
                </style>
            </HEAD>

            <body>
                <form id="form1" method="post" runat="server">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                    <TABLE id="Table8" style="Z-INDEX: 139; LEFT: 4px; WIDTH: 100%; POSITION: static; TOP: 4px; HEIGHT: 76px" cellSpacing="0" cellPadding="0" align="center" bgColor="white" dataPageSize="25" border="0">
                        <TR>
                            <TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
                                <P>
                                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                                </P>
                            </TD>
                        </TR>
                        <TR>
                            <TD style="FONT-SIZE: 0pt; WIDTH: 100%; HEIGHT: 184px;" align="center">
                                <TABLE style="WIDTH: 80%; HEIGHT: 506px;" class="tableMain">
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
                                        <TD style="FONT-SIZE: 0pt; HEIGHT: 3px" align="right" colSpan="3"></TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 100%; HEIGHT: 7px" align="left">
                                            <TABLE id="Table10" style="WIDTH: 100%; HEIGHT: 4px" class="tableMain" cellSpacing="0" cellPadding="0" width="808" border="0">
                                                <TR>
                                                    <TD align="left" class="style1">
                                                    </TD>
                                                    <TD align="right" class="style1" style="margin-bottom:1px;">
                                                        <div class="col-md">
                                                            <asp:Button id="btnQuotes" runat="server" onclick="btnQuotes_Click" Text="Quote" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button ID="btnAuditTrail" runat="server" OnClick="Button1_Click" Text="History" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button id="BtnViewTask" runat="server" onclick="BtnViewTask_Click" Text="Policies" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button id="btnProfile" runat="server" onclick="btnProfile_Click" Text="Profile" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                        </div>
                                                    </TD>
                                                </TR>
                                                <tr>
                                                    <td style="height:4px;">
                                                    </td>
                                                </tr>
                                                <TR>
                                                    <TD align="left" style="HEIGHT: 12px;">
                                                        <asp:Label id="Label21" runat="server" Font-Names="Tahoma" Width="137px" Font-Bold="True" ForeColor="Black" CssClass="headForm1 " Height="16px" Font-Size="11pt">Individual Client:</asp:Label>
                                                        <asp:label id="lblCustNumber" ForeColor="Black" Width="101px" Font-Names="Tahoma" RUNAT="server" Font-Bold="True" Font-Size="9pt" style="margin-left: 0px"></asp:label>
                                                        <asp:label id="LblProspectID" RUNAT="server" Width="105px" ForeColor="Black" Font-Names="Tahoma" Font-Bold="True" Font-Size="9pt" style="margin-left: 10px"></asp:label>
                                                    </TD>
                                                    <TD align="right" style="HEIGHT: 12px">
                                                        <div class="col-md">
                                                            <asp:Button id="btnNew" runat="server" onclick="btnNew_Click" Text="Add" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button id="btnEdit" runat="server" onclick="btnEdit_Click" Text="Edit" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button id="BtnSave" runat="server" onclick="BtnSave_Click" Text="Save" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button ID="btnDelete" runat="server" onclientclick="return confirm('Are you sure you want delete this customer?');" OnClick="btnDelete_Click" Text="Delete" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button id="btnCancel" runat="server" onclick="btnCancel_Click" Text="Cancel" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                            <asp:Button id="BtnExit" runat="server" Text="Exit" class="btn-h-30 btn-bg-theme2 m-1 btn-r-4" />
                                                        </div>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; HEIGHT: 4px; text-align: left;">
                                            <TABLE id="Table11" style="WIDTH: 100%" borderColor="#4b0082" height="1" cellSpacing="0" borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082" border="0">
                                                <TR>
                                                    <TD background="Images2/Barra3.jpg" style="text-align: left"></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 2pt; WIDTH: 100%; HEIGHT: 46px" vAlign="middle" align="center">
                                            <TABLE id="Table6" style="WIDTH: 100%; HEIGHT: 154px" cellSpacing="0" cellPadding="0" width="811" border="0">
                                                <TR>
                                                    <TD style="FONT-SIZE: 1pt; HEIGHT: 100px" align="center">
                                                        <TABLE id="Table1" style="WIDTH: 100%; HEIGHT: 196px" cellSpacing="0" cellPadding="0" width="803" border="0">
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 26px"></TD>
                                                                <TD style="WIDTH: 106px; HEIGHT: 26px"></TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 26px" align="left">
                                                                    <asp:checkbox id="ChkNoticeOfCancellation" tabIndex="29" ForeColor="Black" Width="156px" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headform3" AUTOPOSTBACK="True" TEXT="Notice of Cancellation" Font-Size="9pt"></asp:checkbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 26px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 26px">
                                                                    <asp:label id="lblHomePhone0" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="76px" ENABLEVIEWSTATE="False" Font-Size="9pt">New Quote:</asp:label>
                                                                </TD>
                                                                <TD class="style2">
                                                                    <asp:dropdownlist id="ddlQuote" tabIndex="13" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" Font-Size="9pt">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="0">Quote</asp:ListItem>
                                                                        <asp:ListItem Value="1">Corporate</asp:ListItem>
                                                                        <asp:ListItem Value="2">Laboratory</asp:ListItem>
                                                                        <asp:ListItem Value="3">Cyber</asp:ListItem>
                                                                        <asp:ListItem Value="4">Aspen</asp:ListItem>
                                                                        <asp:ListItem Value="5">First Dollar</asp:ListItem>
                                                                        <asp:ListItem Value="6">Allied</asp:ListItem>
                                                                        <asp:ListItem Value="7">Allied Corporate</asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 26px"></TD>
                                                                <TD style="HEIGHT: 26px" align="left" colspan="2">
                                                                    <asp:TextBox ID="txtControlNo" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" Height="25px" MaxLength="15" OnTextChanged="TxtFirstName_TextChanged" TabIndex="1" Width="94px"></asp:TextBox>
                                                                    <asp:Button ID="btnAssignCustNo" runat="server" OnClick="btnAssignCustNo_Click" Text="Assign Cust No. To Quote" Width="130px" Font-Size="7pt" />
                                                                </TD>
                                                            </TR>
                                                            <TR rowspan="2">
                                                                <TD style="WIDTH: 8px; HEIGHT: 26px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="Label2" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="72px" ENABLEVIEWSTATE="False" Font-Size="9pt">First Name</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 26px" align="left">
                                                                    <asp:textbox id="TxtFirstName" tabIndex="1" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="175px" MAXLENGTH="15" Font-Size="9pt" ontextchanged="TxtFirstName_TextChanged"></asp:textbox>
                                                                    &nbsp;
                                                                    <asp:label id="Label1" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="14px" WIDTH="12px" ENABLEVIEWSTATE="False" Font-Size="9pt">Init.</asp:label>
                                                                    <asp:textbox id="TxtInitial" tabIndex="2" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="21px" MAXLENGTH="1" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 26px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 26px" align="left">
                                                                    <asp:label id="lblHomePhone" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="76px" ENABLEVIEWSTATE="False" Font-Size="9pt">Home Phone</asp:label>
                                                                </TD>
                                                                <TD class="style2">
                                                                    <asp:textbox id="txtHomePhone" tabIndex="13" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" HEIGHT="25px" WIDTH="139px" MAXLENGTH="20" ISDATE="False" Font-Size="9pt"></asp:textbox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="(999)-999-9999" MaskType="Number" TargetControlID="txtHomePhone" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>


                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 26px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="Label10" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="68px" ENABLEVIEWSTATE="False" Font-Size="9pt">Social Security</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 26px">
                                                                    <%--																<maskedinput:maskedtextbox id="txtSocialSecurity" tabIndex="17" 
                                                                    Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server"
																	HEIGHT="12px" WIDTH="180px" MAXLENGTH="11" MASK="999-99-9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox>--%>
                                                                        <asp:RadioButtonList ID="chkssnselect" runat="server" Font-Size="Small" RepeatDirection="Horizontal" Width="150px">
                                                                            <asp:ListItem Value="Patronal">Patronal</asp:ListItem>
                                                                            <asp:ListItem Value="Personal">Personal</asp:ListItem>
                                                                        </asp:RadioButtonList>




                                                                </TD>

                                                                <TD>
                                                                    <asp:Button id="BtnActivateDeleteSoSec" runat="server" Text="Delete" Font-Names="Tahoma" Width="42px" Height="23px" BorderColor="#400000" BorderWidth="0px" Font-Size="9pt" onclick="BtnActivateDeleteSoSec_Click" Visible="False"></asp:Button>
                                                                </TD>

                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblLastName1" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="76px" ENABLEVIEWSTATE="False" Font-Size="9pt">Last Name 1</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 15px" align="left">
                                                                    <asp:textbox id="txtLastname1" tabIndex="3" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142" MAXLENGTH="25" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="lblWorkPhone" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Work Phone</asp:label>
                                                                </TD>
                                                                <TD class="style3">
                                                                    <asp:textbox id="txtWorkPhone" tabIndex="13" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" HEIGHT="25px" WIDTH="139px" MAXLENGTH="20" ISDATE="False" Font-Size="9pt"></asp:textbox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="(999)-999-9999" MaskType="Number" TargetControlID="txtWorkPhone" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>

                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblSocialSecurity" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="89px" ENABLEVIEWSTATE="False" Font-Size="9pt" Visible="true">Social Security</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 15px">
                                                                    <asp:textbox id="txtSocialSecurity" tabIndex="17" HEIGHT="25px" WIDTH="180px" RUNAT="server" Visible="True" CssClass="form-control"></asp:textbox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtenderSS" runat="server" Mask="999-99-9999" MaskType="Number" TargetControlID="txtSocialSecurity" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>
                                                                </TD>
                                                                <td>
                                                                    <input type="button" runat="server" name="answer" value="Show" Font-Names="Tahoma" Width="42px" Height="23px" ForeColor="White" BorderWidth="0px" BorderColor="#400000" BackColor="#400000" Font-Size="9pt" style="margin-right: 1px" onclick="onButtonClick()"
                                                                        id="btnShow" />

                                                                    <asp:textbox id="txtPass" runat="server" tabIndex="3" Font-Names="Tahoma" CSSCLASS="hide" RUNAT="server" autocomplete="Disabled" HEIGHT="25px" WIDTH="142" Font-Size="9pt" ontextchanged="txtPass_TextChanged"></asp:textbox>
                                                                    <asp:Button id="btnValidate" runat="server" Font-Names="Tahoma" Width="50px" Text="Validate" Height="23px" ForeColor="White" BorderWidth="0px" CSSCLASS="hide" BorderColor="#400000" BackColor="#400000" Font-Size="9pt" style="margin-right: 1px" onclick="btnValidate_Click"></asp:Button>


                                                                </td>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblLastName2" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="76px" ENABLEVIEWSTATE="False" Font-Size="9pt">Last Name 2</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 15px" align="left">
                                                                    <asp:textbox id="txtLastname2" tabIndex="4" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142px" MAXLENGTH="25" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label8" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Cellular</asp:label>
                                                                </TD>
                                                                <TD class="style3">
                                                                    <asp:textbox id="TxtCellular" tabIndex="14" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" HEIGHT="25px" WIDTH="139px" MAXLENGTH="20" ISDATE="False" Font-Size="9pt"></asp:textbox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="(999)-999-9999" MaskType="Number" TargetControlID="TxtCellular" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>

                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblEmployerSecSOc" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="172px" ENABLEVIEWSTATE="False" Font-Size="9pt" Visible="true"> Employer Social Security</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 15px">
                                                                    <asp:textbox id="txtEmployerSocSec" tabIndex="20" HEIGHT="25px" WIDTH="180px" RUNAT="server" Visible="True" CssClass="form-control"></asp:textbox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtenderSS2" runat="server" Mask="999-99-9999" MaskType="Number" TargetControlID="txtEmployerSocSec" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 12px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblGender" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Gender</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 12px" align="left">
                                                                    <asp:dropdownlist id="ddlGender" tabIndex="5" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142px" Font-Size="9pt"></asp:dropdownlist>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 12px" align="right"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label24" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Fax</asp:label>
                                                                </TD>
                                                                <TD class="style4">
                                                                    <asp:textbox id="txtfax" tabIndex="14" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" HEIGHT="25px" WIDTH="139px" MAXLENGTH="20" ISDATE="False" Font-Size="9pt"></asp:textbox>
                                                                    <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="(999)-999-9999" MaskType="Number" TargetControlID="txtfax" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>

                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 12px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="Label6" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="17px" WIDTH="172px" Font-Size="9pt">Originated At</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 12px">
                                                                    <%--<maskedinput:maskedtextbox id="txtEmployerSocSec" tabIndex="17" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server"
																	HEIGHT="12px" WIDTH="180px" MAXLENGTH="11" MASK="999-99-9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox>--%>
                                                                        <asp:dropdownlist id="ddlOriginatedAt" tabIndex="19" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="182px" Font-Size="9pt"></asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 11px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblBirthdate" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="64px" ENABLEVIEWSTATE="False" Font-Size="9pt">Birthdate</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 11px" align="left">
                                                                    <asp:textbox id="txtBirthdate" tabIndex="6" onclick="ShowDateTimePicker()" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="114px" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 11px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="lblCorpName" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="17px" WIDTH="73px" Font-Size="9pt">Corporation Name</asp:label>
                                                                </TD>
                                                                <TD class="style5">
                                                                    <asp:textbox id="txtCorpName" tabIndex="15" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="100" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 11px"></TD>
                                                                <TD style="WIDTH: 220px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblOccupation" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt" Width="172px">Occupation</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 11px">
                                                                    <asp:dropdownlist id="ddlOccupation" tabIndex="21" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="182px" AUTOPOSTBACK="True" Font-Size="9pt" onselectedindexchanged="ddlOccupation_SelectedIndexChanged"></asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="Label4" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="36px" ENABLEVIEWSTATE="False" Font-Size="9pt">Age</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px" align="left">
                                                                    <asp:textbox id="TxtAge" tabIndex="8" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142px" MAXLENGTH="3" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="lblJobName" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Work Name</asp:label>
                                                                </TD>
                                                                <TD class="style6">
                                                                    <asp:textbox id="txtWorkName" tabIndex="15" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblOccupation0" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt" Width="172px">Referred By</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">
                                                                    <asp:dropdownlist id="ddlreferredby" tabIndex="21" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="182px" AUTOPOSTBACK="True" Font-Size="9pt" onselectedindexchanged="ddlOccupation_SelectedIndexChanged">
                                                                        <asp:ListItem>CONTACT CENTERS</asp:ListItem>
                                                                        <asp:ListItem>DEALER</asp:ListItem>
                                                                        <asp:ListItem>INSURANCE AGENT</asp:ListItem>
                                                                        <asp:ListItem>INSURANCE COMPANY</asp:ListItem>
                                                                        <asp:ListItem>INTERNET</asp:ListItem>
                                                                        <asp:ListItem>NEWSPAPER</asp:ListItem>
                                                                        <asp:ListItem>OTHER</asp:ListItem>
                                                                        <asp:ListItem>RADIO</asp:ListItem>
                                                                        <asp:ListItem>TELEVISION</asp:ListItem>
                                                                        <asp:ListItem>YELLOW PAGE</asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblMaritalStatus" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="80px" ENABLEVIEWSTATE="False" Font-Size="9pt">Marital Status</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 20px" align="left">
                                                                    <asp:dropdownlist id="ddlMaritalStatus" tabIndex="9" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142px" Font-Size="9pt"></asp:dropdownlist>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label5" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Work City</asp:label>
                                                                </TD>
                                                                <TD class="style7">
                                                                    <asp:textbox id="TxtWorkCity" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblOccupation1" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Status</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 20px">
                                                                    <asp:dropdownlist id="ddlstatus" tabIndex="21" Font-Names="Tahoma" HEIGHT="25px" WIDTH="182" CSSCLASS="form-control" RUNAT="server" AUTOPOSTBACK="True" Font-Size="9pt">
                                                                        <asp:ListItem>Closed</asp:ListItem>
                                                                        <asp:ListItem>Declined</asp:ListItem>
                                                                        <asp:ListItem>Issued</asp:ListItem>
                                                                        <asp:ListItem>Orientation</asp:ListItem>
                                                                        <asp:ListItem>Pending</asp:ListItem>
                                                                        <asp:ListItem>Quoted</asp:ListItem>
                                                                        <asp:ListItem>Quoted/NI</asp:ListItem>
                                                                        <asp:ListItem>Submitted to UND</asp:ListItem>
                                                                        <asp:ListItem>Waiting for payment</asp:ListItem>
                                                                        <asp:ListItem>Payment received and referred to accounting</asp:ListItem>
                                                                        <asp:ListItem>Waiting for policy to insurance</asp:ListItem>
                                                                        <asp:ListItem>Requisites not met</asp:ListItem>
                                                                        <asp:ListItem>Operations outside of PR</asp:ListItem>
                                                                        <asp:ListItem>Higher Limits</asp:ListItem>
                                                                        <asp:ListItem>High Loss Ratio</asp:ListItem>
                                                                        <asp:ListItem>Telemedicine exposures</asp:ListItem>
                                                                        <asp:ListItem>Not available product</asp:ListItem>
                                                                        <asp:ListItem>Moral Hazard</asp:ListItem>
                                                                        <asp:ListItem>Risk Management Recommendation</asp:ListItem>
                                                                        <asp:ListItem>Student</asp:ListItem>
                                                                        <asp:ListItem>Other</asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblCustPreferedCommID" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="28px" WIDTH="80px" ENABLEVIEWSTATE="False" Font-Size="9pt">Prefered Communication</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 20px" align="left">
                                                                    <asp:textbox id="txtCustPreferedCommID" tabIndex="10" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="40" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label16" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="17px" WIDTH="73px" Font-Size="9pt">License</asp:label>
                                                                </TD>
                                                                <TD class="style7">
                                                                    <asp:textbox id="TxtLicence" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" HEIGHT="25px" WIDTH="139px" MAXLENGTH="15" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblOccupation2" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt" Width="172px">Prospect Status</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 18px" vAlign="middle">
                                                                    <asp:dropdownlist id="ddlprostatus" tabIndex="21" Font-Names="Tahoma" HEIGHT="25px" WIDTH="182" CSSCLASS="form-control" RUNAT="server" AUTOPOSTBACK="True" Font-Size="9pt">
                                                                        <asp:ListItem>Prospect</asp:ListItem>
                                                                        <asp:ListItem>Customer</asp:ListItem>
                                                                        <asp:ListItem>Inactive</asp:ListItem>

                                                                    </asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="Label26" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="16px" ENABLEVIEWSTATE="False" Font-Size="9pt">Quoted</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 20px" align="left">
                                                                    <%--<asp:textbox id="txtInsuredtype" tabIndex="10" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server"
																	HEIGHT="12px" WIDTH="139px" MAXLENGTH="40" Font-Size="9pt"></asp:textbox>--%>

                                                                        <asp:textbox id="txtquoted" tabIndex="10" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>

                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label25" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="17px" WIDTH="73px" Font-Size="9pt">License Exp. Date</asp:label>
                                                                </TD>
                                                                <TD class="style7">
                                                                    <asp:textbox id="txtlicexpdate" tabIndex="16" Font-Names="Tahoma" onclick="ShowDateTimePicker1()" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="40" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblInsuredtype" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="172px" ENABLEVIEWSTATE="False" Font-Size="9pt">Insured Type</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 18px" vAlign="middle">

                                                                    <asp:dropdownlist id="txtInsuredtype" tabIndex="22" Font-Names="Tahoma" HEIGHT="25px" WIDTH="182" CSSCLASS="form-control" RUNAT="server" Font-Size="9pt">
                                                                        <asp:ListItem>Physicians: Surgeon</asp:ListItem>
                                                                        <asp:ListItem>Physicians: NS</asp:ListItem>
                                                                        <asp:ListItem>Physicians: MS</asp:ListItem>
                                                                        <asp:ListItem>Physicians: Teaching</asp:ListItem>
                                                                        <asp:ListItem>Physicians: Dentist</asp:ListItem>
                                                                        <asp:ListItem>Physicians: Podiatrist</asp:ListItem>
                                                                        <asp:ListItem>Corporation: Allied</asp:ListItem>
                                                                        <asp:ListItem>Corporation: Cyber</asp:ListItem>
                                                                        <asp:ListItem>Corporation: Lab</asp:ListItem>
                                                                        <asp:ListItem>Corporation: MedMal</asp:ListItem>
                                                                        <asp:ListItem>Allied: Technician</asp:ListItem>
                                                                        <asp:ListItem>Allied: Assistant</asp:ListItem>
                                                                        <asp:ListItem>Allied: Pathologist</asp:ListItem>
                                                                        <asp:ListItem>Allied: Nurse</asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="NPI" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="80px" ENABLEVIEWSTATE="False" Font-Size="9pt">NPI</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 20px" align="left">
                                                                    <asp:textbox id="txtNPI" tabIndex="11" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="40" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="lblAmscaOrDEA2" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="80px" ENABLEVIEWSTATE="False" Font-Size="9pt">AMSCA</asp:label>
                                                                </TD>
                                                                <TD class="style7">
                                                                    <asp:textbox id="ddlAmscaOrDEA2" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                    <%--<asp:dropdownlist id="ddlAmscaOrDEA2" tabIndex="16" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server"
																	HEIGHT="19px" WIDTH="142px" Font-Size="9pt">
                                                                    <asp:ListItem>Amsca</asp:ListItem>
                                                                    <asp:ListItem>Dea</asp:ListItem>
                                                                </asp:dropdownlist>--%>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    &nbsp;</TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 18px; text-align: right;" vAlign="middle">
                                                                    &nbsp;</TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblwebsite" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="17px" WIDTH="73px" Font-Size="9pt">Website</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px" align="left">
                                                                    <asp:textbox id="txtWebsite2" tabIndex="12" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="40" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="lblAmscaOrDEA3" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="80px" ENABLEVIEWSTATE="False" Font-Size="9pt">DEA</asp:label>
                                                                </TD>
                                                                <TD class="style6">

                                                                    <asp:TextBox ID="ddlAmscaOrDEA3" RUNAT="server" CSSCLASS="form-control" Font-Names="Tahoma" Font-Size="9pt" HEIGHT="25px" MAXLENGTH="50" tabIndex="16" WIDTH="139px"></asp:TextBox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="lblAddress2" style="Z-INDEX: 101; LEFT: 981px; POSITION: absolute; TOP: 440px" Font-Names="Tahoma" WIDTH="51px" HEIGHT="10px" RUNAT="server" Visible="False" Font-Size="9pt">Urbanization</asp:label>
                                                                    <asp:checkbox id="ChkDisableAutomaticCustNo" tabIndex="36" ForeColor="Black" Width="190px" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headForm1 " AUTOPOSTBACK="True" TEXT="Disable Automatic Cust. No." Font-Size="9pt" Height="16px"></asp:checkbox>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">
                                                                    <asp:textbox id="txtAddress2" class="form-control" style="Z-INDEX: 102; LEFT: 997px; POSITION: absolute; TOP: 461px" tabIndex="25" Font-Names="Tahoma" MAXLENGTH="30" WIDTH="163px" HEIGHT="25px" RUNAT="server" Visible="False"></asp:textbox>
                                                                    <asp:Button id="BtnUpdate" runat="server" onclientclick="return confirm('Updating ALL cases, Continue?');" onclick="BtnUpdate_Click" Text="Update Cases" class="btn-bg-theme1 btn-w-95   btn-r-4" />
                                                                </TD>

                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblEmail" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">E-mail</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px" align="left">
                                                                    <asp:textbox id="txtEmail" tabIndex="12" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="100" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label11" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Lead ID</asp:label>
                                                                </TD>
                                                                <TD class="style6">
                                                                    <asp:textbox id="txtleadid" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="Label13" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" Visible="False" HEIGHT="17px" WIDTH="73px" Font-Size="9pt">Related To</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">
                                                                    <asp:dropdownlist id="ddlRelatedTo" tabIndex="23" Font-Names="Tahoma" WIDTH="182px" HEIGHT="25px" RUNAT="server" CSSCLASS="form-control" Visible="False" Font-Size="9pt">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                                                    </asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="Label12" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="25px" WIDTH="68px" ENABLEVIEWSTATE="False" Font-Size="9pt">E-mail 2</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px" align="left">
                                                                    <asp:textbox id="txtemail2" tabIndex="12" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142px" MAXLENGTH="100" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label17" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Agent ID</asp:label>
                                                                </TD>
                                                                <TD class="style6">
                                                                    <asp:textbox id="txtagentid" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:label id="Label7" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" Visible="False" HEIGHT="17px" WIDTH="88px" Font-Size="9pt">Master Client</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">
                                                                    <asp:dropdownlist id="ddlMasterCustomer" tabIndex="24" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" Visible="False" HEIGHT="25px" WIDTH="182px" Font-Size="9pt"></asp:dropdownlist>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="Label3" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="68px" ENABLEVIEWSTATE="False" Font-Size="9pt">Convert to Client</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px" align="left">
                                                                    <asp:textbox id="txtcontoclient" tabIndex="12" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="142px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label9" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Interested IN</asp:label>
                                                                </TD>
                                                                <TD class="style6">
                                                                    <asp:textbox id="txtinterestedin" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    <asp:Label ID="Label22" runat="server" CssClass="headfield1" Font-Size="9pt" VISIBLE="false" Height="14px" Text="Customer No"></asp:Label>
                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">
                                                                    <maskedinput:maskedtextbox id="TxtCustomerNo" tabIndex="25" Font-Names="Tahoma" VISIBLE="false" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="20" MASK="999999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox>
                                                                </TD>

                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 23px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    <asp:label id="lblHouseIncome" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="17px" WIDTH="172px" Font-Size="9pt">Household Income</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px" align="left">
                                                                    <asp:dropdownlist id="ddlHouseIncome" tabIndex="18" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="182px" Font-Size="9pt"></asp:dropdownlist>
                                                                </TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    &nbsp;</TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 23px">
                                                                    <asp:label Visible="false" id="Label18" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Social Security PIN</asp:label>
                                                                </TD>
                                                                <TD class="style6">
                                                                    <asp:textbox Visible="false" id="txtssnpin" tabIndex="16" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">

                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">

                                                                    <asp:Label ID="Label23" runat="server" CssClass="headfield1" Font-Size="9pt" Height="16px" Text="Prospect ID" Visible="False"></asp:Label>

                                                                </TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 23px" align="left">
                                                                    <maskedinput:maskedtextbox id="TxtProspectID" tabIndex="26" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="25px" WIDTH="139px" MAXLENGTH="20" MASK="999999" ISDATE="False" Font-Size="9pt" Visible="False"></maskedinput:maskedtextbox>
                                                                </TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left">
                                                                    &nbsp;</TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 20px" align="left">
                                                                    &nbsp;</TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 20px"></TD>
                                                                <TD style="WIDTH: 100px; HEIGHT: 16px" align="left">
                                                                    &nbsp;</TD>
                                                                <TD class="style7">
                                                                    &nbsp;</TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 20px">&nbsp;</TD>

                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 8px; HEIGHT: 18px" rowspan="3"></TD>
                                                                <TD style="WIDTH: 110px; HEIGHT: 18px" align="left" rowspan="3">
                                                                    <asp:label id="lblComments" Font-Names="Tahoma" CSSCLASS="headfield1" RUNAT="server" HEIGHT="18px" WIDTH="68px" ENABLEVIEWSTATE="False" Font-Size="9pt">Comments</asp:label>
                                                                </TD>
                                                                <TD style="HEIGHT: 18px" vAlign="middle" align="left" colSpan="4" rowspan="3">
                                                                    <asp:textbox id="txtComments" tabIndex="22" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="35px" WIDTH="373px" MAXLENGTH="200" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 7px; HEIGHT: 18px" rowspan="3"></TD>
                                                                <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                    &nbsp;</TD>
                                                                <TR>
                                                                    <TD style="WIDTH: 7px; HEIGHT: 20px">&nbsp;</TD>
                                                                    <TD style="WIDTH: 180px; HEIGHT: 15px" align="left">
                                                                </TR>
                                                            </TR>
                                                            <TD style="WIDTH: 214px; HEIGHT: 18px" vAlign="middle">
                                                                <asp:textbox id="txtOtherOccupation" tabIndex="22" Font-Names="Tahoma" CSSCLASS="form-control" RUNAT="server" HEIGHT="12px" WIDTH="180px" MAXLENGTH="15" VISIBLE="False" Font-Size="9pt"></asp:textbox>
                                                            </TD>


                                                        </TABLE>
                                                        </TD>
                                                </TR>
                                            </TABLE>
                                            </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 17px" align="left" colSpan="1">
                                            <TABLE id="Table2" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0" borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082" border="0">
                                                <TR>
                                                    <TD background="Images2/Barra3.jpg"></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 25px">
                                            <TABLE id="Table3" style="WIDTH: 808px; HEIGHT: 74px" cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD style="FONT-SIZE: 1pt; width: 806px;" align="center">
                                                        <TABLE id="Table4" style="WIDTH: 794px; HEIGHT: 149px" cellSpacing="0" cellPadding="0" width="794" border="0">
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 16px"></TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="lblTypeAddress1" Font-Names="Tahoma" ForeColor="Black" WIDTH="95px" RUNAT="server" CSSCLASS="headform3" Font-Bold="True" Font-Size="9pt">Postal Address</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 16px"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 16px">
                                                                    <asp:label id="LblTypeAddress2" Font-Names="Tahoma" ForeColor="Black" WIDTH="102px" RUNAT="server" CSSCLASS="headform3" Font-Bold="True" Font-Size="9pt">Physical Address</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 16px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 16px"></TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 16px"></TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 16px" align="left">
                                                                    <asp:label id="Label14" Font-Names="Tahoma" Width="302px" RUNAT="server" CSSCLASS="HeadField1" FONT-SIZE="XX-Small">*Address1 (Urb.,Cond.Bo.,Res.,Secc.Coop.,QBDA,Parcelas,Sector)</asp:label>
                                                                    <asp:label id="Label15" Font-Names="Tahoma" Width="278px" RUNAT="server" CSSCLASS="HeadField1" FONT-SIZE="XX-Small">**Address2(PoBox,Street,HC,Ave.,BLVD.,Camino,RR,Parque)</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 16px"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 16px">
                                                                    <asp:checkbox id="chkSameAddr" tabIndex="30" Width="116px" RUNAT="server" CSSCLASS="headfield1" TEXT="Same as postal" AUTOPOSTBACK="True" Enabled="False" Font-Size="9pt" Font-Names="Tahoma" oncheckedchanged="chkSameAddr_CheckedChanged"></asp:checkbox>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 16px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 16px"></TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 15px">
                                                                    <asp:label id="lblHomeUrb" Font-Names="Tahoma" WIDTH="51px" HEIGHT="10px" RUNAT="server" CSSCLASS="headfield1" Font-Size="9pt">*Address1</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 15px" align="left">
                                                                    <asp:textbox id="txtHomeUrb1" tabIndex="24" class="form-control" Font-Names="Tahoma" MAXLENGTH="30" WIDTH="163" HEIGHT="25px" RUNAT="server" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 15px">
                                                                    <asp:textbox id="txtAddress1Phys" tabIndex="31" Font-Names="Tahoma" MAXLENGTH="30" WIDTH="163px" HEIGHT="25px" RUNAT="server" Font-Size="9pt" class="form-control"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 15px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 15px"></TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 24px">
                                                                    <asp:label id="lblAddress1" Font-Names="Tahoma" WIDTH="51px" HEIGHT="10px" RUNAT="server" CSSCLASS="headfield1" Font-Size="9pt">**Address2</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 24px" align="left">
                                                                    <asp:textbox id="txtAddress1" tabIndex="25" class="form-control" Font-Names="Tahoma" MAXLENGTH="30" WIDTH="163px" HEIGHT="25px" RUNAT="server" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 24px"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 24px">
                                                                    <asp:textbox id="txtAddress2Phys" tabIndex="32" class="form-control" Font-Names="Tahoma" MAXLENGTH="30" WIDTH="163px" HEIGHT="25px" RUNAT="server" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 24px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 22px"></TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 12px">
                                                                    <asp:label id="lblCity" Font-Names="Tahoma" WIDTH="51px" HEIGHT="10px" RUNAT="server" CSSCLASS="headfield1" Font-Size="9pt">City</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 12px" align="left">
                                                                    <asp:textbox id="txtCity" tabIndex="26" Font-Names="Tahoma" class="form-control" MAXLENGTH="14" WIDTH="163px" HEIGHT="25" RUNAT="server" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 12px" align="right"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 12px">
                                                                    <asp:textbox id="txtCityPhys" tabIndex="33" Font-Names="Tahoma" class="form-control" MAXLENGTH="14" WIDTH="163px" HEIGHT="25px" RUNAT="server" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 12px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 12px"></TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 11px">
                                                                    <asp:label id="lblState" Font-Names="Tahoma" WIDTH="51px" HEIGHT="10px" RUNAT="server" CSSCLASS="headfield1" Font-Size="9pt">State</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 11px" align="left">
                                                                    <asp:textbox id="txtState" tabIndex="27" Font-Names="Tahoma" MAXLENGTH="2" WIDTH="163px" HEIGHT="25px" RUNAT="server" class="form-control" Font-Size="9pt">PR</asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 11px"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 11px">
                                                                    <asp:textbox id="txtStatePhys" tabIndex="34" Font-Names="Tahoma" MAXLENGTH="2" WIDTH="163px" HEIGHT="25px" class="form-control" RUNAT="server" Font-Size="9pt"></asp:textbox>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 11px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 11px"></TD>
                                                            </TR>
                                                            <tr>
                                                                <td style="height:4px;">
                                                                </td>
                                                            </tr>
                                                            <TR>
                                                                <TD style="WIDTH: 106px; HEIGHT: 22px">
                                                                    <asp:label id="lblZipCode" Font-Names="Tahoma" WIDTH="51" HEIGHT="10px" RUNAT="server" CSSCLASS="headfield1" Font-Size="9pt">Zip Code</asp:label>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 22px" align="left">
                                                                    <maskedinput:maskedtextbox id="txtZipCode" tabIndex="28" Font-Names="Tahoma" MAXLENGTH="10" WIDTH="163px" HEIGHT="25px" RUNAT="server" class="form-control" ISDATE="False" MASK="99999Z9999" Font-Size="9pt"></maskedinput:maskedtextbox>
                                                                </TD>
                                                                <TD style="WIDTH: 2px; HEIGHT: 22px"></TD>
                                                                <TD style="WIDTH: 181px; HEIGHT: 22px">
                                                                    <maskedinput:maskedtextbox id="txtZipCodePhys" tabIndex="35" Font-Names="Tahoma" MAXLENGTH="10" WIDTH="163px" HEIGHT="25px" class="form-control" RUNAT="server" ISDATE="False" MASK="99999Z9999" Font-Size="9pt"></maskedinput:maskedtextbox>
                                                                </TD>
                                                                <TD style="WIDTH: 162px; HEIGHT: 22px"></TD>
                                                                <TD style="WIDTH: 214px; HEIGHT: 22px" align="left"></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <tr>
                                        <td align="left" style="font-size: 0pt; height: 25px">
                                            <asp:Label ID="LblTotalCases" runat="server" CssClass="headForm1 " Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Height="9px" Width="188px">Total Cases:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="font-size: 0pt; height: 25px; text-align: left;">
                                            <asp:Label ID="LblError" runat="server" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Red" Visible="False" Width="780px">Label</asp:Label>
                                            <asp:DataGrid ID="searchIndividual" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="0" Font-Names="Arial" Font-Size="10pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="1px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                                OnItemCommand="searchIndividual_ItemCommand" PageSize="20" Width="805px">
                                                <FooterStyle BackColor="Navy" Font-Names="tahoma" ForeColor="#003399" />
                                                <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                                <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                                <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                                        <ItemStyle Font-Names="tahoma" />
                                                    </asp:ButtonColumn>
                                                    <asp:BoundColumn DataField="TaskControlID" HeaderText="Control No">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv."></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EffectiveDate" DataFormatString="{0:d}" HeaderText="Eff. Date">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EntryDate" DataFormatString="{0:d}" HeaderText="Entry Date">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TaskControlTypeID" HeaderText="TaskControlTypeID" Visible="False">
                                                    </asp:BoundColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="Maroon" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                        </TR>
                    </TABLE>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>

                    <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                    <asp:checkbox id="ChkOptOut" style="Z-INDEX: 103; LEFT: 12px; POSITION: absolute; TOP: 132px" tabIndex="36" Font-Names="Tahoma" Width="71px" RUNAT="server" CSSCLASS=" headForm1 " TEXT="Opt-Out" AUTOPOSTBACK="True" Visible="False"></asp:checkbox>



                    <asp:Panel ID="PanelSocSec" runat="server" CssClass="" Width="400px" Height="200px" BackColor="#EEEAEA">
                        <div class="" style="padding: 0px; background-color: #400000; color: #FFFFFF; font-family: tahoma;
					font-size: 14px; font-weight: normal; font-style: normal; background-repeat: no-repeat;
					text-align: left; vertical-align: bottom;">
                            &nbsp;&nbsp;
                            <asp:Label ID="LabelSocSecPanel" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans" Font-Size="14pt" Text="" ForeColor="#FFFFFF" />
                        </div>
                        <div class="">

                            <br />

                            <div style="text-align: center;">

                                <asp:Label ID="LabelSoSecQuestion" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans" Text="Which Social Security will you Delete?" />

                            </div>
                            <br />
                            <div style="text-align: center;">
                                <br />
                                <asp:Button ID="btnDeleteSoSec" runat="server" Text="Personal" onclick="btnDeleteSoSec_Click" TabIndex="99" Width="100px" onclientclick="return confirm('Are you sure you want delete this Personal Social Security Number?');" /> &nbsp;&nbsp;&nbsp;

                                <asp:Button ID="btnDeleteEmployerSoSec" runat="server" Text="Employer" onclick="btnDeleteEmployerSoSec_Click" TabIndex="99" Width="100px" onclientclick="return confirm('Are you sure you want delete this Employer Social Security Number?');" />
                            </div>
                        </div>
                        <br />
                        <div class="" align="center">
                            <asp:Button ID="btnAceptarSocSec" runat="server" Text="Exit" Width="100px" visible="true" />
                        </div>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="mpeSocSec" runat="server" DropShadow="True" PopupControlID="PanelSocSec" TargetControlID="ButtonSocSec">
                    </asp:ModalPopupExtender>
                    <asp:Button ID="ButtonSocSec" runat="server" Visible="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" BorderColor="Transparent" />
                    <asp:RoundedCornersExtender ID="RoundedCornersExtenderSocSec" runat="server" TargetControlID="PanelSocSec" Radius="10" Corners="All" />
                </form>
            </body>

            </HTML>
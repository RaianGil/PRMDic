<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinancialCancellations.aspx.cs" Inherits="FinancialCancellations" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<%@ Register assembly="MaskedInput" namespace="MaskedInput" tagprefix="maskedinput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<link rel="stylesheet" href="StyleSheet.css" type="text/css"/>
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
    <script src="js/load.js" type="text/javascript"></script>
    <title></title>
       <style type="text/css">
        .toggler { height: 1px;
           margin-left: 0px;
       }
        #button { padding: .5em 2em; text-decoration: none; }
        #btnCloseEffect {text-decoration: none; }
        #effect { width: 315px; height: 228px; padding: 0.4em; position: relative;}
        #effect h3 { margin: 0; padding: 0.4em; text-align: center; }
        .ui-effects-transfer { border: 2px dotted gray; } 
    </style>   
    <style type="text/css">

	    .headfield1
        {
            text-align: left;
            font-weight: 700;
            font-size: small;
        }

	    .headForm1
        {}
        .style1
        {
            height: 19px;
            text-align: left;
        }
        .style3
        {
            width: 168px;
            height: 19px;
        }

	    .style7
        {
            height: 20px;
        }

	    .style8
        {
            height: 21px;
        }
        .style10
        {
            height: 21px;
        }

	    .headForm2 { font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-weight: normal; color: #ffffff; text-decoration: none }
.headForm3 { font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-weight: normal; color: #004f7f; text-decoration: none }
.numbers { font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-weight: bold; color: #ffffff; text-decoration: none }

	    .style11
        {
            text-align: left;
        }

	    .style15
        {
            height: 1px;
            width: 237px;
        }
        .style16
        {
            height: 10px;
            width: 237px;
        }
        .style18
        {
            width: 237px;
            height: 19px;
        }

	    .style19
        {
            height: 21px;
            width: 212px;
        }
        .style20
        {
            text-align: left;
            height: 1px;
            width: 165px;
        }
        .style21
        {
            text-align: left;
            height: 10px;
            width: 165px;
        }
        .style22
        {
            height: 21px;
            text-align: left;
        }
        .style24
        {
            height: 1px;
            width: 152px;
        }
        .style25
        {
            height: 10px;
            width: 152px;
        }
        .style26
        {
            width: 152px;
            height: 19px;
        }
        .style27
        {
            height: 21px;
            width: 152px;
        }

	    .style28
        {
            height: 21px;
            text-align: left;
            }
        .style31
        {
            text-align: left;
            height: 2px;
        }
        .style32
        {
            height: 21px;
            text-align: left;
        }
        .style34
        {
            height: 15px;
            text-align: left;
        }

	    .style35
        {
            height: 19px;
            text-align: left;
            width: 269px;
        }
        .style36
        {
            height: 1px;
            width: 269px;
        }
        .style37
        {
            height: 1px;
            width: 324px;
        }
        .style38
        {
            width: 324px;
            height: 19px;
        }
        .style39
        {
            height: 1px;
            width: 173px;
        }
        .style40
        {
            width: 173px;
            height: 19px;
        }
        .style41
        {
            height: 20px;
            text-align: left;
            width: 269px;
        }
        .style42
        {
            width: 173px;
            height: 20px;
        }
        .style43
        {
            width: 324px;
            height: 20px;
        }
        .style44
        {
            width: 168px;
            height: 20px;
        }

	    .style45
        {
            width: 237px;
            height: 11px;
        }
        .style46
        {
            width: 152px;
            height: 11px;
        }
        .style48
        {
            text-align: left;
            height: 11px;
        }
        .modalBackground
        {	
            background-color:Silver;
            filter: alpha(opacity=70);
            opacity: 0.7px;    
            -moz-opacity: 0.7;
            -webkit-opacity: 70;
            -khtml-opacity: 70;
         }
         .CajaDialogoDiv
        {
            margin: 0px;
            text-align: center;
        }
        .CajaDialogo
        {
            background-color: white;
            border-width: 1px;
            border-style: outset;
            border-color: Navy;
            padding: 0px;
            width: 300px;
            font-weight: bold;
            font-style: italic;
        }
	    </style>
</head>
<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $("#effect").hide();
            $(function() {
                $('#<%= txtDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function ShowDateTimePicker() {
                $('#<%= txtDate.ClientID %>').datepicker('show');
            }

            $(function() {
                //run the currently selected effect
                function runEffect() {
                    //get effect type from 
                    //var selectedEffect = $('#effectTypes').val();
                    var selectedEffect = "blind";
                    //most effect types need no options passed by default
                    var options = {};
                    //run the effect
                    $("#effect").show(selectedEffect, options, 500, callback);
                };

                //callback function to bring a hidden box back
                function callback() {
                    //			setTimeout(function()
                    //			    {
                    //				    $("#effect:visible").removeAttr('style').hide().fadeOut();
                    //			    }, 
                    //			1000);
                };

                function CloseEffect() {
                    setTimeout(function() {
                        $("#effect:visible").removeAttr('style').hide().fadeOut();
                    },
			    10);
                }

                //set effect from select menu value

                $("#effect").hide();

                if (typeof (Sys.Browser.WebKit) == "undefined") {
                    Sys.Browser.WebKit = {};
                }
                if (navigator.userAgent.indexOf("WebKit/") > -1) {
                    Sys.Browser.agent = Sys.Browser.WebKit;
                    Sys.Browser.version = parseFloat(navigator.userAgent.match(/WebKit\/(\d+(\.\d+)?)/)[1]);
                    Sys.Browser.name = "WebKit";
                }
            });
</script>
<body background="Images2/SQUARE.GIF" bottommargin="0" leftmargin="0" 
    rightmargin="0" topmargin="19">
		<form method="post" runat="server">
		            <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
                AsyncPostBackTimeout="0">
            </Toolkit:ToolkitScriptManager>
			<TABLE id="Table8" style="Z-INDEX: 126; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 281px"
				cellSpacing="0" cellPadding="0" width="911" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="2">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 5px; POSITION: static; HEIGHT: 395px" vAlign="top"
						align="right" colSpan="1" rowSpan="5">
						<P align="center">
							<asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder></P>
					</TD>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center" 
                        valign="top">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 99px" cellSpacing="0" cellPadding="0" width="809"
								bgColor="white" border="0">
								<TR valign="top">
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">
										<TABLE id="Table1" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0" width="808"
											border="0">
											<TR>
												<TD style="WIDTH: 272px" align="left">     
													<asp:Label id="Label21" runat="server" Width="190px" Height="16px" 
                                                        Font-Size="11pt" Font-Bold="True"
														Font-Names="Tahoma" CssClass="headForm1 " ForeColor="Black">Financial Cancellations</asp:Label>
													</TD>
												<TD align="right">
													<asp:Button id="btnPrintAll" runat="server" BackColor="#400000" Width="110px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Print Email Notice" onclick="btnPrintAll_Click" 
                                                        TabIndex="15" style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnAvisoCanc" runat="server" BackColor="#400000" Width="100px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Email Notice" onclick="btnAvisoCanc_Click" 
                                                        TabIndex="15" style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnModify" runat="server" BackColor="#400000" Width="115px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Modify Contract" onclick="btnModify_Click" 
                                                        TabIndex="15" style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnNew" runat="server" BackColor="#400000" Width="50px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="New" onclick="btnNew_Click" 
                                                        TabIndex="15" style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnReinst" runat="server" BackColor="#400000" Width="50px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Reinst." onclick="btnReinst_Click" 
                                                        TabIndex="15" style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnSave" runat="server" BackColor="#400000" Width="50px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Save" onclick="btnSave_Click" 
                                                        TabIndex="15" style="margin-right: 1px" Visible="False"></asp:Button>
													<asp:Button id="btnPrint" runat="server" BackColor="#400000" Width="55px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Print" onclick="btnPrint_Click" 
                                                        TabIndex="15" style="margin-right: 1px"></asp:Button>
													<asp:Button id="BtnCancel" runat="server" BackColor="#400000" Width="55px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Cancel" onclick="BtnCancel_Click" 
                                                        TabIndex="15" Visible="False" style="margin-right: 1px"></asp:Button>
													<asp:Button id="BtnExit" runat="server" BackColor="#400000" Width="60px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Exit" onclick="BtnExit_Click" 
                                                        TabIndex="15"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; " class="style7" background="Images2/Barra3.jpg">
										
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 192px" vAlign="middle" align="center"> <TABLE id="Table6" style="WIDTH: 802px; HEIGHT: 84px" cellSpacing="0" cellPadding="0" width="802"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table4" style="WIDTH: 784px; HEIGHT: 10px" cellSpacing="0" cellPadding="0" width="784"
														border="0">
														<TR>
															<TD class="style28" colspan="4">
                                                                <asp:Label 
                                            ID="lblB0" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" 
                                                                        Font-Size="12pt" ForeColor="Black" 
                                            HEIGHT="19px" Width="270px">Contract Information</asp:Label>
                                                                    <asp:DropDownList ID="ddlFinancial0" RUNAT="server" AutoPostBack="True" 
                                                                        CSSCLASS="style11" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="20px" 
                                                                        onselectedindexchanged="ddlFinancial_SelectedIndexChanged" 
                                                                    WIDTH="206px" Visible="False">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblSelectedID" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Visible="False">0</asp:Label>
										                    </TD>
														</TR>
														<TR>
															<TD class="style28" colspan="4">
                                                                
                                                                <asp:Panel ID="pnlContract" runat="server" Height="200px">
                                                                <TABLE id="Table4" style="WIDTH: 800px; HEIGHT: 145px" cellSpacing="0" 
                                                                        cellPadding="0"
                                                                <TD class="style20">
																    </TD>
														</TR __designer:mapid="47">
														<TR>
															<TD class="style15" align="left">
																 </TD>
															<TD align="left" class="style24">
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																 </TD>
															<tr>
                                                                <td class="style21">
                                                                    <asp:Label ID="lblB" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" 
                                                                        Font-Size="9pt" ForeColor="Black" HEIGHT="19px" Width="105px">Financial 
                                                                    Name:</asp:Label>
                                                                </td>
                                                                <td align="left" class="style16">
                                                                    <asp:DropDownList ID="ddlFinancial" RUNAT="server" AutoPostBack="True" 
                                                                        CSSCLASS="style11" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="20px" 
                                                                        onselectedindexchanged="ddlFinancial_SelectedIndexChanged" WIDTH="206px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="left" class="style25">
                                                                    <asp:Label ID="lblState" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Customer Name:</asp:Label>
                                                                </td>
                                                                <td class="style11" style="WIDTH: 168px; " rowspan="2">
                                                                    <asp:TextBox ID="txtCustomerName" runat="server" Height="30px" 
                                                                        MaxLength="1000" TabIndex="8" Width="245px" ReadOnly="True" 
                                                                        TextMode="MultiLine" Enabled="False"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style21">
                                                                    <asp:Label ID="lblAddress1" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Width="139px">Financial Phone No.:</asp:Label>
                                                                </td>
                                                                <td align="left" class="style16">
                                                                    <maskedinput:MaskedTextBox ID="txtFinancialPhoneNo" runat="server" Columns="34" 
                                                                        CssClass="style11" Font-Names="Tahoma" Font-Size="9pt" Height="19px" 
                                                                        Mask="(999) 999-9999" tabIndex="1" Width="145px"></maskedinput:MaskedTextBox>
                                                                </td>
                                                                <td align="left" class="style25">
                                                                     </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style20">
                                                                    <asp:Label ID="lblAddress2" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Contract No.:</asp:Label>
                                                                </td>
                                                                <td align="left" class="style15">
                                                                    <asp:TextBox ID="txtContractNo" runat="server" Height="19px" MaxLength="20" 
                                                                        TabIndex="2" Width="145px"></asp:TextBox>
                                                                </td>
                                                                <td align="left" class="style24">
                                                                    <asp:CheckBox ID="chkEnable" runat="server" AutoPostBack="True" Font-Size="9pt" 
                                                                        oncheckedchanged="chkEnable_CheckedChanged" />
                                                                    <asp:Label ID="lblZipCode" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Policy No. :</asp:Label>
                                                                </td>
                                                                <td class="style11" style="WIDTH: 168px; " rowspan="2">
                                                                    <asp:TextBox ID="txtPolicyNo" runat="server" Height="30px" MaxLength="1000" 
                                                                        TabIndex="9" Width="245px" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style48">
                                                                    <asp:Label ID="lblPhone" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Effective Date:</asp:Label>
                                                                </td>
                                                                <td align="left" class="style45">
                                                                    <maskedinput:MaskedTextBox ID="txtEffDate" RUNAT="server" CSSCLASS="style11" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" HEIGHT="19px" ISDATE="True" 
                                                                        tabIndex="10" WIDTH="144px"></maskedinput:MaskedTextBox>
                                                                </td>
                                                                <td align="left" class="style46">
                                                                     
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style1">
                                                                    <asp:Label ID="lblEntryDate2" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Installments:</asp:Label>
                                                                </td>
                                                                <td align="left" class="style18">
                                                                    <asp:TextBox ID="txtInstallmentNum" runat="server" Height="19px" MaxLength="20" 
                                                                        TabIndex="2" Width="145px"></asp:TextBox>
                                                                </td>
                                                                <td align="left" class="style26">
                                                                    <asp:Label ID="lblSocialSecurity" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Agency:</asp:Label>
                                                                </td>
                                                                <td class="style3">
                                                                    <asp:DropDownList ID="ddlAgency" RUNAT="server" CSSCLASS="style11" 
                                                                        Enabled="False" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="20px" tabIndex="12" 
                                                                        WIDTH="206px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
														    <tr>
                                                                <td class="style1">
                                                                    <asp:Label ID="lblEntryDate0" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Down Payment:</asp:Label>
                                                                </td>
                                                                <td align="left" class="style18">
                                                                    <maskedinput:MaskedTextBox ID="txtPayment" runat="server" Columns="34" 
                                                                        CssClass="style11" Font-Names="Tahoma" Font-Size="9pt" Height="19px" 
                                                                        IsCurrency="True" tabIndex="3" Width="145px" AutoPostBack="True" 
                                                                        ontextchanged="txtPayment_TextChanged"></maskedinput:MaskedTextBox>
                                                                </td>
                                                                <td align="left" class="style26">
                                                                    <asp:Label ID="lblLicenseNum" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Agent:</asp:Label>
                                                                </td>
                                                                <td class="style3">
                                                                    <asp:DropDownList ID="ddlAgent" RUNAT="server" CSSCLASS="style11" 
                                                                        Enabled="False" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="20px" tabIndex="10" 
                                                                        WIDTH="206px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
														</TR>
                                                                    <tr>
                                                                        <td class="style1">
                                                                            <asp:Label ID="lblEntryDate3" RUNAT="server" CSSCLASS="headfield1" 
                                                                                Font-Names="Tahoma" Font-Size="9pt">Total to Pay:</asp:Label>
                                                                        </td>
                                                                        <td align="left" class="style18">
                                                                            <maskedinput:MaskedTextBox ID="txtTotalToPay" runat="server" 
                                                                                AutoPostBack="True" Columns="34" CssClass="style11" Font-Names="Tahoma" 
                                                                                Font-Size="9pt" Height="19px" IsCurrency="True" 
                                                                                ontextchanged="txtPayment_TextChanged" tabIndex="3" Width="145px"></maskedinput:MaskedTextBox>
                                                                        </td>
                                                                        <td align="left" class="style26">
                                                                            <asp:Label ID="lblLicenseNum1" RUNAT="server" CSSCLASS="headfield1" 
                                                                                Font-Names="Tahoma" Font-Size="9pt">Current Status:</asp:Label>
                                                                        </td>
                                                                        <td class="style3">
                                                                            <asp:DropDownList ID="ddlStatus" RUNAT="server" CSSCLASS="style11" 
                                                                                Enabled="False" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="20px" tabIndex="10" 
                                                                                WIDTH="206px">
                                                                                <asp:ListItem>
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Value="C">Pending Cancellation</asp:ListItem>
                                                                                <asp:ListItem Value="R">Reinstated</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style1">
                                                                            <asp:Label ID="lblEntryDate1" RUNAT="server" CSSCLASS="headfield1" 
                                                                                Font-Names="Tahoma" Font-Size="9pt">Remaining Balance:</asp:Label>
                                                                        </td>
                                                                        <td align="left" class="style18">
                                                                            <maskedinput:MaskedTextBox ID="txtRemainingBalance" runat="server" Columns="34" 
                                                                                CssClass="style11" Enabled="False" Font-Names="Tahoma" Font-Size="9pt" 
                                                                                Height="19px" IsCurrency="True" tabIndex="3" Width="145px"></maskedinput:MaskedTextBox>
                                                                        </td>
                                                                        <td align="left" class="style26">
                                                                             </td>
                                                                        <td class="style3">
                                                                             </td>
                                                                    </tr>
                                                            </TABLE>
                                                                </asp:Panel>
                                                                
                                                            </TD>
														</TR>
														<tr>
															<TD class="style31" colspan="4"  background="Images2/Barra3.jpg"></TD>
														</tr>
														<TR>
															<TD class="style34" colspan="4"></TD>
														</TR>
														<TR>
															<TD class="style34" colspan="4">
                                                                
                                                                <asp:Panel ID="pnlCancellations" runat="server" Height="165px" Visible="False">
                                                                <TABLE id="Table10" style="WIDTH: 800px; HEIGHT: 145px" cellSpacing="0" 
                                                                        cellPadding="0"
                                                                <TD class="style20">
																    </TD>
														</TR __designer:mapid="47">
														<TR>
															<TD class="style36" align="left">
																 </TD>
															<TD align="left" class="style39">
																 </TD>
															<TD class="style37">
																 </TD>
                                                            <tr>
                                                                <td class="style41">
                                                                </td>
                                                                <td align="left" class="style42">
                                                                    <asp:Label ID="lblPhone0" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Date</asp:Label>
                                                                </td>
                                                                <td align="left" class="style43">
                                                                    <asp:TextBox ID="txtDate" runat="server" Columns="30" CssClass="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="19px" IsDate="True" 
                                                                        onclick="ShowDateTimePicker();" TabIndex="44" Width="144px"></asp:TextBox>
                                                                </td>
                                                                <td class="style44">
                                                                </td>
                                                            </tr>
														    <tr>
                                                                <td class="style35">
                                                                     </td>
                                                                <td align="left" class="style40">
                                                                    <asp:Label ID="lblPhone1" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt">Installment</asp:Label>
                                                                </td>
                                                                <td align="left" class="style38">
                                                                    <asp:TextBox ID="txtInstallment" runat="server" Height="19px" MaxLength="20" 
                                                                        TabIndex="2" Width="145px"></asp:TextBox>
                                                                </td>
                                                                <td class="style3">
                                                                    <asp:Label ID="lblSelectedType" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Visible="False">C</asp:Label>
                                                                </td>
                                                            </tr>
														</TR>
                                                                    <tr>
                                                                        <td class="style35">
                                                                             </td>
                                                                        <td align="left" class="style40">
                                                                            <asp:CheckBox ID="chkExpTerms" runat="server" AutoPostBack="True" 
                                                                                Font-Size="9pt" oncheckedchanged="chkExpTerms_CheckedChanged" />
                                                                            <asp:Label ID="lblEntryDate" RUNAT="server" CSSCLASS="headfield1" 
                                                                                Font-Names="Tahoma" Font-Size="9pt">Balance</asp:Label>
                                                                        </td>
                                                                        <td align="left" class="style38">
                                                                            <asp:TextBox id="txtBalance" tabIndex="3" runat="server" 
                                                                    Width="145px" Height="19px" Font-Size="9pt"
																	Font-Names="Tahoma" CssClass="style11" IsCurrency="True"></asp:TextBox>
                                                                        </td>
                                                                        <td class="style3">
                                                                             </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="style35">
                                                                             </td>
                                                                        <td align="left" class="style40">
                                                                            <asp:Label ID="lblLicenseNum0" RUNAT="server" CSSCLASS="headfield1" 
                                                                                Font-Names="Tahoma" Font-Size="9pt">Comments</asp:Label>
                                                                        </td>
                                                                        <td align="left" class="style38">
                                                                            <asp:TextBox ID="txtComments" runat="server" Height="75px" TabIndex="4" 
                                                                                TextMode="MultiLine" Width="325px"></asp:TextBox>
                                                                        </td>
                                                                        <td class="style3">
                                                                             </td>
                                                                    </tr>
                                                            </TABLE>
                                                                </asp:Panel>
                                                                
                                                            </TD>
														</TR>
														<TR>
															<TD class="style22" colspan="4"> </TD>
														</TR>
														<TR>
															<TD class="style22"> 
																	<asp:label id="lblPendingItems" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Pending Items:</asp:label>
															</TD>
															<TD align="left" class="style19" valign="top"> 
																	</TD>
															<TD align="left" class="style27">
                                                                </TD>
															<TD align="left" class="style8">
                                                                </TD>
														</TR>
														<TR>
															<TD class="style32" colspan="4"> 
														<asp:datagrid id="grdPendingItems" RUNAT="server" WIDTH="802px" Height="100px" ITEMSTYLE-HORIZONTALALIGN="center"
															HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True"
															FONT-SIZE="9pt" FONT-NAMES="Tahoma" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
															ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
															ITEMSTYLE-CSSCLASS="HeadForm3" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" OnItemCommand = "grdAuditItems_ItemCommand"
                                                             >
															<FooterStyle Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
															<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
															<EditItemStyle HorizontalAlign="Center" BackColor="White" Height="30px"></EditItemStyle>
															<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
															<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White" 
                                                                Height="30px"></ItemStyle>
															<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
															<Columns>
																<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
																	<HeaderStyle HorizontalAlign="Center" Width="10px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:ButtonColumn>
																<asp:BoundColumn DataField="FinancialCancellationsID" 
                                                                    HeaderText="Transaction ID" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="85px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="FinancialCancellationsTypeDesc" HeaderText="Type">
                                                                </asp:BoundColumn>
																<asp:BoundColumn DataField="FinancialCancellationsDate" HeaderText="Date">
																	<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
															    <asp:BoundColumn DataField="FinancialCancellationsInstallment" 
                                                                    HeaderText="Installment"></asp:BoundColumn>
																<asp:BoundColumn DataField="FinancialCancellationsBalance" HeaderText="Balance">
																	<HeaderStyle HorizontalAlign="Center" Width="125px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="FinancialCancellationsComments" 
                                                                    HeaderText="Comments">
																	<HeaderStyle Width="150px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="TaskControlID" HeaderText="Key ID" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="UserDesc" HeaderText="User">
																	<HeaderStyle HorizontalAlign="Center" Width="165px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
                                                                <asp:BoundColumn DataField="UserID" HeaderText="UserID" 
                                                                    Visible="False"></asp:BoundColumn>
															    <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" 
                                                                    HeaderText="Delete"></asp:ButtonColumn>
															</Columns>
															<PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" 
                                                                BackColor="White" PageButtonCount="20"
																CssClass="Numbers" Mode="NumericPages" Height="15px"></PagerStyle>
														</asp:datagrid>
															</TD>
														</TR>
														<TR>
															<TD class="style11" colspan="4" background="Images2/Barra3.jpg"> 
																	</TD>
														</TR>
														<TR>
															<TD class="style22" colspan="4"> 
																	</TD>
														</TR>
														<TR>
															<TD class="style32"> 
																	<asp:label id="lblHistory" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1" Visible="False">History:</asp:label>
															</TD>
															<TD align="left" class="style19" valign="top"> 
																	 </TD>
															<TD align="left" class="style27">
                                                                 </TD>
															<TD align="left" class="style10">
                                                                 </TD>
														</TR>
														<TR>
															<TD class="style8" colspan="4">
														<asp:datagrid id="grdAuditItems" RUNAT="server" WIDTH="802px" Height="261px" ITEMSTYLE-HORIZONTALALIGN="center"
															HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True"
															FONT-SIZE="9pt" FONT-NAMES="Tahoma" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
															ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
															ITEMSTYLE-CSSCLASS="HeadForm3" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" 
                                                            Visible="False" OnItemCommand = "grdAuditItems_ItemCommand"
                                                             >
															<FooterStyle Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
															<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
															<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
															<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
															<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
															<Columns>
																<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
																	<HeaderStyle HorizontalAlign="Center" Width="10px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:ButtonColumn>
																<asp:BoundColumn DataField="FinancialCancellationID" 
                                                                    HeaderText="Transaction ID" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="85px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="EntryDate" HeaderText="Date &amp; Time">
																	<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="UserDesc" HeaderText="User">
																	<HeaderStyle HorizontalAlign="Center" Width="165px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="FinancialDesc" HeaderText="Financial">
																	<HeaderStyle HorizontalAlign="Center" Width="75px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="FinancialBalance" HeaderText="Balance">
																	<HeaderStyle HorizontalAlign="Center" Width="125px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="Comments" HeaderText="Comments">
																	<HeaderStyle Width="150px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="KeyID" HeaderText="Key ID">
																	<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
															    <asp:BoundColumn DataField="FinancialContractNo" HeaderText="Contract No" 
                                                                    Visible="False"></asp:BoundColumn>
                                                                <asp:BoundColumn DataField="FinancialPhoneNo" HeaderText="Phone No." 
                                                                    Visible="False"></asp:BoundColumn>
															    <asp:BoundColumn DataField="UserID" HeaderText="UserID" Visible="False">
                                                                </asp:BoundColumn>
															    <asp:BoundColumn DataField="ExpTerm" HeaderText="chkExpTerm" Visible="False">
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="PolicyNo" HeaderText="PolicyNo" Visible="False">
                                                                </asp:BoundColumn>
															</Columns>
															<PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																CssClass="Numbers" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></TD>
														</TR>
														<TR>
															<TD class="style32"> 
																	<asp:label id="Label1" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1" Visible="false">Cancellation Notice History:</asp:label>
															</TD>
															<TD align="left" class="style19" valign="top"> 
																	 </TD>
															<TD align="left" class="style27">
                                                                 </TD>
															<TD align="left" class="style10">
                                                                 </TD>
														</TR>
														<tr align="left" >
														<td>
														<asp:datagrid id="grdCancNotice" RUNAT="server" WIDTH="500px" Height="261px" ITEMSTYLE-HORIZONTALALIGN="center"
															HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True"
															FONT-SIZE="9pt" FONT-NAMES="Tahoma" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
															ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
															ITEMSTYLE-CSSCLASS="HeadForm3" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" 
                                                            Visible="False" onitemcommand="grdCancNotice_ItemCommand" 
                                                             >
															<FooterStyle Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
															<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
															<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
															<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
															<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
															<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
															<Columns>
																
																<asp:BoundColumn DataField="CertificateHistoryID" 
                                                                    HeaderText="Cert ID" Visible="False">
																	<HeaderStyle HorizontalAlign="Center" Width="85px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CertificateLocationDesc" HeaderText="Certificate Location">
																	<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Sent" HeaderText="Sent">
																	<HeaderStyle HorizontalAlign="Center" Width="165px"></HeaderStyle>
																	<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																   <asp:ButtonColumn ButtonType="PushButton" CommandName="SendAgain" 
                                                                    HeaderText="Send Again" Visible="true"></asp:ButtonColumn>
															</Columns>
															<PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																CssClass="Numbers" Mode="NumericPages"></PagerStyle>
														</asp:datagrid>
														</td>
														</tr>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													 </TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 5px" align="left"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px"></TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			 <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" Width="400px" BackColor="#F4F4F4"
                        Style="display: none;">
                        <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
                            font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
                            background-repeat: no-repeat; text-align: left; vertical-align: bottom;">
                            <asp:Label ID="Label55" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans"
                                Font-Size="14pt" Text="Message.." ForeColor="#000066" />
                        </div>
                        <div class="CajaDialogoDiv" style="color: #FFFFFF">
                            <table style="background-position: center; width: 400px; height: 175px;">
                                <tr>
                                    <td align="left" valign="middle">
                                        <asp:TextBox ID="lblRecHeader" runat="server" Font-Bold="False" Font-Italic="False"
                                            Font-Size="10pt" Font-Underline="False" ForeColor="Maroon" Text="Message" Width="390px"
                                            Font-Names="Arial" CssClass="" TextMode="MultiLine" Height="170px" BorderColor="Transparent"
                                            BorderStyle="None" BorderWidth="0px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="CajaDialogoDiv" align="center">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                        </div>
                    </asp:Panel>
			<Toolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground"
                        CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript=""
                        OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                    </Toolkit:ModalPopupExtender>
                    <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent"
                        BorderStyle="None" BorderWidth="0" Visible="true" />
                </ContentTemplate>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
			<asp:imagebutton id="btnAddNew1" style="Z-INDEX: 117; LEFT: 859px; POSITION: absolute; TOP: 9px"
				tabIndex="10" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="btnEdit1" style="Z-INDEX: 118; LEFT: 883px; POSITION: absolute; TOP: 9px" tabIndex="11"
				runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="BtnSave1" style="Z-INDEX: 119; LEFT: 915px; POSITION: absolute; TOP: 9px" tabIndex="12"
				RUNAT="server" Visible="False" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif"></asp:imagebutton>
			<asp:imagebutton id="btnSearch1" style="Z-INDEX: 120; LEFT: 947px; POSITION: absolute; TOP: 9px"
				tabIndex="13" runat="server" Visible="False" ImageUrl="Images/search_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="cmdCancel1" style="Z-INDEX: 121; LEFT: 979px; POSITION: absolute; TOP: 9px"
				tabIndex="14" runat="server" Visible="False" ImageUrl="Images/cancel_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="btnPrint1" style="Z-INDEX: 122; LEFT: 1099px; POSITION: absolute; TOP: 9px"
				tabIndex="15" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
			<asp:ImageButton id="btnAuditTrail1" style="Z-INDEX: 123; LEFT: 1011px; POSITION: absolute; TOP: 9px"
				runat="server" Width="48px" Height="19px" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
			<asp:imagebutton id="BtnExit1" style="Z-INDEX: 124; LEFT: 1067px; POSITION: absolute; TOP: 9px" tabIndex="17"
				RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
		</form>
	</body>
</html>

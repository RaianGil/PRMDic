<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.Agency" CodeFile="Agency.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
				<LINK href="baldrich.css" type="text/css" rel="stylesheet">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
	    <style type="text/css">
            .HeadField1
            {
                margin-left: 0px;
            }
            .style1
            {
                height: 1px;
                width: 203px;
            }
            .style2
            {
                height: 5px;
                width: 203px;
            }
            .style3
            {
                height: 10px;
                width: 203px;
            }
        </style>
        	<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
     $("#effect").hide();
     $(function() {
     $('#<%= txtlicexp.ClientID %>').datepicker({
             changeMonth: true,
             changeYear: true
         });
     });

     function ShowDateTimePicker() {
         $('#<%= txtlicexp.ClientID %>').datepicker('show');
     }
     // });
</script>
	<script type='text/javascript'>

	    jQuery(function($) {

	    $("#txtoffice1").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtoffice2").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtPhone").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtphone2").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtfax").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    

	    });

    </script>
	</HEAD>
	<body background="Images2/SQUARE.GIF" bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form method="post" runat="server">
			<P>
				<TABLE id="Table8" style="Z-INDEX: 127; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 281px"
					cellSpacing="0" cellPadding="0" width="911" align="center" bgColor="white" dataPageSize="25"
					border="0">
					<TR>
						<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
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
						<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
							<P align="center">
								<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 99px" cellSpacing="0" cellPadding="0" width="809"
									bgColor="white" border="0">
									<TR>
										<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
									</TR>
									<TR>
										<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
											<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
												width="808" border="0">
												<TR>
													<TD style="WIDTH: 272px" align="left">     
														<asp:Label id="Label1" runat="server" Font-Names="tahoma,11pt" Font-Size="11pt" CssClass="headForm1 "
															ForeColor="Black" Font-Bold="True">Agency ID:</asp:Label>
														<asp:label id="lblAgencyID" runat="server" Font-Names="Tahoma" Font-Size="Smaller" Width="91px"></asp:label></TD>
													<TD align="right">
														<asp:button id="btnAuditTrail" tabIndex="44" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="59px" BackColor="#400000" Text="AuditTrail" BorderWidth="0px" BorderColor="#400000"
															Height="23px" Font-Size="9pt" onclick="btnAuditTrail_Click"></asp:button>
														<asp:button id="btnCommission" tabIndex="45" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="86px" BackColor="#400000" Text="Commission" BorderWidth="0px" BorderColor="#400000"
															Height="23px" onclick="btnCommission_Click"></asp:button>
														<asp:button id="btnPrint" tabIndex="40" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Print" BorderWidth="0px" BorderColor="#400000"
															Height="23px" Font-Size="9pt" onclick="btnPrint_Click"></asp:button>
														<asp:button id="btnSearch" tabIndex="45" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Search" BorderWidth="0px" BorderColor="#400000"
															Height="23px" onclick="btnSearch_Click"></asp:button>
														<asp:button id="btnAddNew" tabIndex="45" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Add" BorderWidth="0px" BorderColor="#400000"
															Height="23px" onclick="btnAddNew_Click"></asp:button>
														<asp:button id="btnEdit" tabIndex="41" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Edit" BorderWidth="0px" BorderColor="#400000"
															Height="23px" Font-Size="9pt" onclick="btnEdit_Click"></asp:button>
														<asp:button id="BtnSave" tabIndex="43" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Save" BorderWidth="0px" BorderColor="#400000"
															Height="23px" Font-Size="9pt" onclick="BtnSave_Click"></asp:button>
														<asp:button id="cmdCancel" tabIndex="42" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Cancel" BorderWidth="0px" BorderColor="#400000"
															Height="23px" Font-Size="9pt" onclick="cmdCancel_Click"></asp:button>
														<asp:button id="Button2" tabIndex="45" runat="server" Font-Names="Tahoma" ForeColor="White"
															Width="52px" BackColor="#400000" Text="Exit" BorderWidth="0px" BorderColor="#400000"
															Height="23px" onclick="Button2_Click"></asp:button> 
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD style="FONT-SIZE: 1pt; HEIGHT: 1px">
											<TABLE id="Table11" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
												borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
												border="0">
												<TR>
													<TD background="Images2/Barra3.jpg"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 192px" vAlign="middle" align="center">                                                                                                                                          
											<TABLE id="Table6" style="WIDTH: 802px; HEIGHT: 84px" cellSpacing="0" cellPadding="0" width="802"
												border="0">
												<TR>
													<TD style="FONT-SIZE: 1pt" align="center">
														<TABLE id="Table4" style="WIDTH: 784px; HEIGHT: 10px" cellSpacing="0" cellPadding="0" width="784"
															border="0">
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
																<TD class="style1"><asp:label id="lblB" RUNAT="server" CSSCLASS="HeadField1" HEIGHT="16px" ForeColor="Black" Font-Names="Tahoma"
																		Font-Size="9pt">Agency Description</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 1px">
																	<asp:textbox id="txtAgencyDescription" tabIndex="1" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		MAXLENGTH="40" CSSCLASS="headfield1" WIDTH="249px" HEIGHT="22px"></asp:textbox></TD>
																<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P3" runat="server">
																		<asp:label id="Label3" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Agency Name </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																		
																		<asp:textbox id="txtname" tabIndex="2" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		MAXLENGTH="30" CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		
																		
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P4" runat="server">
																		<asp:label id="Label4" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Agency LastName 1 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																	
																		<asp:textbox id="txtlast1" tabIndex="3" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		MAXLENGTH="30" CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P5" runat="server">
																		<asp:label id="Label5" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Agency LastName 2 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																		
																		<asp:textbox id="txtlast2" tabIndex="4" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		MAXLENGTH="30" CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 10px"></TD>
																<TD class="style3">
																	<asp:label id="lblAddress1" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="HeadField1"
																		Height="16" Width="99px"> Address 1</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 10px">
																																			
																		<asp:textbox id="txtAddress1" tabIndex="5" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		MAXLENGTH="30" CSSCLASS="headfield1" WIDTH="250px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 10px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
																<TD class="style1">
																	<asp:label id="lblAddress2" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="HeadField1"
																		Height="16"> Address 2</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 1px">
																																			
																		<asp:textbox id="txtAddress2" tabIndex="6" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		MAXLENGTH="30" CSSCLASS="headfield1" WIDTH="250px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<asp:label id="lblCity" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="HeadField1"
																		Height="16">City</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																	<asp:textbox id="txtCity" tabIndex="7" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<asp:label id="lblState" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="HeadField1"
																		Height="16">State</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																	<asp:textbox id="txtSt" tabIndex="8" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="2"
																		CSSCLASS="headfield1" WIDTH="47px" HEIGHT="22px"></asp:textbox></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<asp:label id="lblZipCode" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="HeadField1"
																		Height="16">Zip Code</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtZipCode" tabIndex="9" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:textbox></TD>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P17" runat="server">
																		<asp:label id="Label17" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Additional Adress </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																		<asp:DropDownList ID="txtpostal" runat="server" Width="249px">
                                                                    <asp:ListItem>Fisica</asp:ListItem>
                                                                    <asp:ListItem>Postal</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>																	
																		
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P20" runat="server">
																		<asp:label id="Label28" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Second Adress 1 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtaddresssec1" tabIndex="10" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="100"
																		CSSCLASS="headfield1" WIDTH="250px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P21" runat="server">
																		<asp:label id="Label29" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Second Adress 2 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtaddresssec2" tabIndex="10" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="100"
																		CSSCLASS="headfield1" WIDTH="250px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P22" runat="server">
																		<asp:label id="Label30" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Second City </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtcity2" tabIndex="10" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P23" runat="server">
																		<asp:label id="Label31" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Second State </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtstate2" tabIndex="10" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="2"
																		CSSCLASS="headfield1" WIDTH="47px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P24" runat="server">
																		<asp:label id="Label32" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Second Zip Code </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtzip2" tabIndex="10" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P13" runat="server">
																		<asp:label id="Label13" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Office Phone 1 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtoffice1" tabIndex="11" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px" ></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P14" runat="server">
																		<asp:label id="Label14" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Office Phone 2 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtoffice2" tabIndex="12" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<asp:label id="lblPhone" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="HeadField1"
																		Height="16">Home Phone 1</asp:label></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																    
																    <asp:textbox id="txtPhone" tabIndex="13" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		
																	</TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P15" runat="server">
																		<asp:label id="Label15" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Home Phone 2 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtphone2" tabIndex="13" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P16" runat="server">
																		<asp:label id="Label16" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Office Fax </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtfax" tabIndex="14" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="20"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P1" runat="server">
																		<asp:label id="lblEntryDate" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Entry Date</asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																	<maskedinput:maskedtextbox id="txtEntryDate" tabIndex="15" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px" ISDATE="True" Enabled="False"></maskedinput:maskedtextbox></TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P2" runat="server">
																		<asp:label id="Label2" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Sale Contact </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtsale" tabIndex="16" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P6" runat="server">
																		<asp:label id="Label6" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Accounting Contact </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																																			
																		<asp:textbox id="txtacco" tabIndex="17" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P7" runat="server">
																		<asp:label id="Label7" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Contact Email 1 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																
																<asp:textbox id="txtemail1" tabIndex="18" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P8" runat="server">
																		<asp:label id="Label8" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Contact Email 2 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																
																	<asp:textbox id="txtemail2" tabIndex="19" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																		</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P9" runat="server">
																		<asp:label id="Label9" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Contact Email 3 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail3" tabIndex="19" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P10" runat="server">
																		<asp:label id="Label10" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Contact Email 4 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail4" tabIndex="20" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P11" runat="server">
																		<asp:label id="Label11" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Contact Email 5 </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail5" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P25" runat="server">
																		<asp:label id="Label33" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Website </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtwebsite" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P26" runat="server">
																		<asp:label id="Label34" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Facebook </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtfacebook" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P27" runat="server">
																		<asp:label id="Label35" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Instagram </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtinstagram" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P28" runat="server">
																		<asp:label id="Label36" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Twitter </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txttwitter" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P29" runat="server">
																		<asp:label id="Label37" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">LinkedIn </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtlinkedin" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P30" runat="server">
																		<asp:label id="Label38" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Other Social Media </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtothersm" tabIndex="21" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P12" runat="server">
																		<asp:label id="Label12" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">Social Security </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtssn" tabIndex="22" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="11"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P18" runat="server">
																		<asp:label id="Label18" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">License Exp. Date </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:TextBox ID="txtlicexp" runat="server" Columns="30" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" onIsDate="True" TabIndex="23"
                                                                    Width="79px"></asp:TextBox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
															<TR>
																<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
																<TD class="style2">
																	<P id="P19" runat="server">
																		<asp:label id="Label19" RUNAT="server" CSSCLASS="HeadField1" Font-Names="Tahoma" Font-Size="9pt"
																			Height="16">License Number </asp:label></P>
																</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtlicnum" tabIndex="24" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" MAXLENGTH="15"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																		CSSCLASS="headfield1" WIDTH="144px" HEIGHT="22px"></asp:textbox>
																	</TD>
																<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
															</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label20" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Type of License </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddltypelic" runat="server" Width="249px">
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label21" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Application </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlappl" runat="server" Width="249px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label22" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">OCS Appointment </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlocsa" runat="server" Width="249px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    <asp:ListItem>N/A</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label23" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="178px">Commission Agreement </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlcomm" runat="server" Width="249px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Standard Commission Agreement</asp:ListItem>
                                                                    <asp:ListItem>Special Commission Agreement</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label24" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Tax Waiver Certificate </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddltaxwai" runat="server" Width="249px">
                                                                    <asp:ListItem>Partial</asp:ListItem>
                                                                    <asp:ListItem>Total</asp:ListItem>
                                                                    <asp:ListItem>None</asp:ListItem>
                                                                    <asp:ListItem>Expired</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label25" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">E & O Policy </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddleopolicy" runat="server" Width="249px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    <asp:ListItem>Expired</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label26" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="198px">Merchant Registration (Suri) </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlmerchregis" runat="server" Width="249px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    <asp:ListItem>Expired</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label27" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Payment Method </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlpaymet" runat="server" Width="249px">
                                                                    <asp:ListItem>Wired</asp:ListItem>
                                                                    <asp:ListItem>Check</asp:ListItem>
                                                                    <asp:ListItem>Direct Deposit</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														</TABLE>
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
				<maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
				<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal></P>
			 
			<P> </P>
			<P> </P>
			<P> </P>
			<P> </P>
		</form>
	</body>
</HTML>

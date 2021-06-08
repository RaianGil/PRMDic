<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.Agent" CodeFile="CertificateLocation.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="baldrich.css" type="text/css" rel="stylesheet">
		<LINK href="baldrich.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                width: 468px;
            }
            .style2
            {
                height: 1px;
                width: 123px;
            }
            .style3
            {
                height: 10px;
                width: 123px;
            }
            .style4
            {
                height: 5px;
                width: 123px;
            }
        </style>
	</HEAD>
	<body background="Images2/SQUARE.GIF" bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 126; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 281px"
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
										<TABLE id="Table1" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0" width="808"
											border="0">
											<TR>
												<TD align="left" class="style1">     
													<asp:Label id="Label21" runat="server" Width="160px" Height="16px" 
                                                        Font-Size="11pt" Font-Bold="True"
														Font-Names="Tahoma" CssClass="headForm1 " ForeColor="Black">Certificate Location:</asp:Label>
													<asp:Label id="lblCertificateID" runat="server" Width="134px" Font-Size="10pt" 
                                                        Font-Names="Tahoma"></asp:Label></TD>
												<TD align="right">
													<asp:Button id="btnPrint" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Print" onclick="btnPrint_Click" 
                                                        Visible="False"></asp:Button>
													<asp:Button id="btnSearch" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Search" onclick="btnSearch_Click"></asp:Button>
													<asp:Button id="BtnSave" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Save" onclick="BtnSave_Click"></asp:Button>
													<asp:Button id="btnEdit" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Edit" onclick="btnEdit_Click"></asp:Button>
													<asp:Button id="btnAddNew" runat="server" BackColor="#400000" Width="59px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
													<asp:Button id="cmdCancel" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
													<asp:Button id="BtnExit" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Exit" onclick="BtnExit_Click"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px">
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
															<TD class="style2">
																<asp:label id="lblB" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="119px">Location  Description</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtCertificateLocationDesc" tabIndex="1" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="21" CSSCLASS="headfield1" WIDTH="249px" MAXLENGTH="150"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 10px"></TD>
															<TD class="style3">
																<asp:label id="lblAddress1" Width="99px" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma"
																	Font-Size="9pt"> Address 1</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px">
																<asp:textbox id="txtAddress1" tabIndex="2" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="21" CSSCLASS="headfield1" WIDTH="249" MAXLENGTH="150"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD class="style2">
																<asp:label id="lblAddress2" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt"> Address 2</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtAddress2" tabIndex="3" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="21" CSSCLASS="headfield1" WIDTH="249" MAXLENGTH="150"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD class="style4">
																<asp:label id="lblCity" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">City</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtCity" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="21"
																	CSSCLASS="headfield1" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD class="style4">
																<asp:label id="lblState" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">State</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtSt" tabIndex="5" RUNAT="server" CSSCLASS="headfield1" WIDTH="37px" HEIGHT="21px"
																	MAXLENGTH="2" Font-Names="Tahoma" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD class="style4">
																<asp:label id="lblZipCode" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1">Zip Code</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtZipCode" tabIndex="6" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="19px" CSSCLASS="headfield1" ISDATE="False" WIDTH="144px" MASK="99999Z9999" MAXLENGTH="10"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD class="style4">
																<asp:label id="lblPhone" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1">Phone </asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:MaskedTextBox id="txtPhone" tabIndex="7" runat="server" Width="144" Height="19px" Font-Size="9pt"
																	Font-Names="Tahoma" CssClass="headfield1" Mask="(999) 999-9999" Columns="34"></maskedinput:MaskedTextBox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD class="style4">
																<P id="P1" runat="server">
																<asp:label id="lblEmail" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" 
                                                                         CSSCLASS="headfield1">Email 1</asp:label>
																	 </P>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtEmail" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="21"
																	CSSCLASS="headfield1" WIDTH="144px" MAXLENGTH="50"></asp:textbox>
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD class="style4">
																<asp:label id="lblEmail2" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" 
                                                                         CSSCLASS="headfield1">Email 2</asp:label>
																	 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtEmail2" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="21"
																	CSSCLASS="headfield1" WIDTH="144px" MAXLENGTH="50"></asp:textbox>
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD class="style4">
																<asp:label id="lblEmail3" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" 
                                                                         CSSCLASS="headfield1">Email 3</asp:label>
																	 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtEmail3" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="21"
																	CSSCLASS="headfield1" WIDTH="144px" MAXLENGTH="50"></asp:textbox>
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD class="style4">
																	 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
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
</HTML>

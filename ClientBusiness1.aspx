<%@ Page language="c#" Inherits="EPolicy.ClientBusiness" CodeFile="ClientBusiness.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="epolicy.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF"
		topMargin="19" rightMargin="0">
		<form id="ClientIndividual" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 153; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 399px"
				cellSpacing="0" cellPadding="0" width="911" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 5px; POSITION: static; HEIGHT: 395px" align="right"
						colSpan="1" rowSpan="5" vAlign="top">
						<P align="center">
							<asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder></P>
					</TD>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 175px" cellSpacing="0" cellPadding="0"
								width="809" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left"> 
													<asp:Label id="Label17" runat="server" Font-Names="Tahoma" Width="137px" Font-Bold="True" ForeColor="Black"
														Height="16px" CssClass="headForm1 " Font-Size="11pt">Business Client:</asp:Label>
													<asp:label id="lblCustNumber" Font-Names="Tahoma" Width="103px" ForeColor="Black" RUNAT="server"
														CSSCLASS="headform3" Height="15px" Font-Size="9pt"></asp:label>
													<asp:label id="LblProspectID" Font-Names="Tahoma" Width="138px" ForeColor="Black" RUNAT="server"
														CSSCLASS="headform3" Font-Size="9pt"></asp:label></TD>
												<TD></TD>
												<TD align="right">
													<asp:Button id="btnNew" runat="server" Height="23px" ForeColor="White" Width="70px" Font-Names="Tahoma"
														BorderWidth="0px" BorderColor="#400000" BackColor="#400000" Text="Add" onclick="btnNew_Click"></asp:Button>
													<asp:Button id="BtnViewTask" runat="server" Font-Names="Tahoma" Text="Events" Width="53px" ForeColor="White"
														Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnViewTask_Click"></asp:Button>
													<asp:Button id="btnProfile" runat="server" Font-Names="Tahoma" Text="Profile" Width="52px" ForeColor="White"
														Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnProfile_Click"></asp:Button>
													<asp:Button id="BtnSave" runat="server" Font-Names="Tahoma" Text="Save" Width="41px" ForeColor="White"
														Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnSave_Click"></asp:Button>
													<asp:Button id="btnCancel" runat="server" Font-Names="Tahoma" Text="Cancel" Width="60px" ForeColor="White"
														Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnCancel_Click"></asp:Button>
													<asp:Button id="btnEdit" runat="server" Font-Names="Tahoma" Text="Edit" Width="49px" ForeColor="White"
														Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnEdit_Click"></asp:Button>
													<asp:Button id="btnAuditTrail" runat="server" Font-Names="Tahoma" Text="History" Width="60px"
														ForeColor="White" Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnAuditTrail_Click"></asp:Button>
													<asp:Button id="BtnExit" runat="server" Font-Names="Tahoma" Text="Exit" Width="43px" ForeColor="White"
														Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="Button1_Click"></asp:Button> 
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
									<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 128px" vAlign="middle" align="center">                                                                                                                                          
										<TABLE id="Table6" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table1" style="WIDTH: 789px; HEIGHT: 124px" cellSpacing="0" cellPadding="0"
														width="789" border="0">
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 111px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 364px; HEIGHT: 27px" align="left">
																<asp:checkbox id="ChkNoticeOfCancellation" tabIndex="29" Font-Names="Tahoma" Width="156px" ForeColor="Black"
																	RUNAT="server" CSSCLASS="headform3" TEXT="Notice of Cancellation" AUTOPOSTBACK="True" Font-Size="9pt"></asp:checkbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 22px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 252px; HEIGHT: 27px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 27px">
																<asp:label id="lblRequiredFirstName" RUNAT="server" CSSCLASS="headfield1" HEIGHT="4px" WIDTH="6px"
																	FORECOLOR="Red">*</asp:label></TD>
															<TD style="WIDTH: 111px; HEIGHT: 27px">
																<asp:label id="Label1" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" ENABLEVIEWSTATE="False"
																	HEIGHT="18px" Font-Size="9pt">Business Name</asp:label></TD>
															<TD style="WIDTH: 364px; HEIGHT: 27px" align="left">
																<asp:textbox id="TxtBusinessName" tabIndex="1" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" MAXLENGTH="100" WIDTH="323px" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 27px">
																<asp:label id="lblRequiredHomePhone" RUNAT="server" CSSCLASS="headfield1" HEIGHT="7px" WIDTH="3px"
																	FORECOLOR="Red">*</asp:label></TD>
															<TD style="WIDTH: 22px; HEIGHT: 27px">
																<asp:label id="Label6" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" HEIGHT="17px"
																	WIDTH="77px" Font-Size="9pt">Originated At</asp:label></TD>
															<TD style="WIDTH: 252px; HEIGHT: 27px">
																<asp:dropdownlist id="ddlOriginatedAt" tabIndex="6" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="23px" WIDTH="233px" Font-Size="9pt"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 111px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 364px; HEIGHT: 27px" align="left">
																<asp:textbox id="TxtBusinessName1" tabIndex="1" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" MAXLENGTH="15" WIDTH="107px" Font-Size="9pt"></asp:textbox>
																<asp:textbox id="TxtBusinessName2" tabIndex="1" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" MAXLENGTH="15" WIDTH="107px" Font-Size="9pt"></asp:textbox>
																<asp:textbox id="TxtBusinessName3" tabIndex="1" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" MAXLENGTH="15" WIDTH="107px" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 22px; HEIGHT: 27px"></TD>
															<TD style="WIDTH: 252px; HEIGHT: 27px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 25px"></TD>
															<TD style="WIDTH: 111px; HEIGHT: 25px">
																<asp:label id="Label4" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" ENABLEVIEWSTATE="False"
																	HEIGHT="18px" Font-Size="9pt">Business Type</asp:label></TD>
															<TD style="WIDTH: 364px; HEIGHT: 25px" align="left">
																<asp:dropdownlist id="ddlBusinessType" tabIndex="2" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="23px" WIDTH="262px" Font-Size="9pt">
																	<asp:ListItem></asp:ListItem>
																	<asp:ListItem Value="M">Male</asp:ListItem>
																	<asp:ListItem Value="F">Female</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="WIDTH: 2px; HEIGHT: 25px"></TD>
															<TD style="WIDTH: 22px; HEIGHT: 25px">
																<asp:label id="Label7" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" HEIGHT="17px"
																	WIDTH="73px" Visible="False" Font-Size="9pt">Master Client</asp:label></TD>
															<TD style="WIDTH: 252px; HEIGHT: 25px">
																<asp:dropdownlist id="ddlMasterCustomer" tabIndex="7" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" WIDTH="234px" Visible="False" Font-Size="9pt"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 14px"></TD>
															<TD style="WIDTH: 111px; HEIGHT: 14px">
																<asp:label id="Label8" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" ENABLEVIEWSTATE="False"
																	HEIGHT="18px" Font-Size="9pt">Description</asp:label></TD>
															<TD style="WIDTH: 364px; HEIGHT: 14px" align="left">
																<asp:textbox id="TxtDescription" tabIndex="3" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" MAXLENGTH="100" WIDTH="260px" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 14px" align="right"></TD>
															<TD style="WIDTH: 22px; HEIGHT: 14px">
																<asp:label id="Label2" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" HEIGHT="17px"
																	WIDTH="73px" Visible="False" Font-Size="9pt">Related To</asp:label></TD>
															<TD style="WIDTH: 252px; HEIGHT: 14px">
																<asp:dropdownlist id="ddlRelatedTo" tabIndex="8" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" WIDTH="234px" Visible="False" Font-Size="9pt">
																	<asp:ListItem></asp:ListItem>
																	<asp:ListItem Value="E">Entry Date</asp:ListItem>
																	<asp:ListItem Value="C">Close Date</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 21px"></TD>
															<TD style="WIDTH: 111px; HEIGHT: 21px">
																<asp:label id="lblSocialSecurity" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	ENABLEVIEWSTATE="False" HEIGHT="18px" WIDTH="107px" Font-Size="9pt">Employer Soc. Sec.</asp:label></TD>
															<TD style="WIDTH: 364px; HEIGHT: 21px">
																<maskedinput:maskedtextbox id="txtSocialSecurity" tabIndex="4" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" MAXLENGTH="11" WIDTH="261px" ISDATE="False" MASK="999-99-9999" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 21px"></TD>
															<TD style="WIDTH: 22px; HEIGHT: 21px"></TD>
															<TD style="WIDTH: 252px; HEIGHT: 21px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 44px"></TD>
															<TD style="WIDTH: 111px; HEIGHT: 44px">
																<asp:label id="lblComments" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" ENABLEVIEWSTATE="False"
																	HEIGHT="18px" WIDTH="92px" Font-Size="9pt">Comments</asp:label></TD>
															<TD style="WIDTH: 302px; HEIGHT: 44px" vAlign="bottom" align="left" colSpan="4">
																<asp:textbox id="txtComments" tabIndex="5" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="41px" MAXLENGTH="200" WIDTH="341px" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 3px; HEIGHT: 44px"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 13px" align="left" colSpan="1">                     
										<TABLE id="Table2" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD background="Images2/Barra3.jpg"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px">
										<TABLE id="Table4" style="WIDTH: 806px; HEIGHT: 188px" cellSpacing="0" cellPadding="0"
											width="806" border="0">
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 27px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 27px"></TD>
												<TD style="WIDTH: 364px; HEIGHT: 27px" align="left">
													<asp:label id="lblTypeAddress1" Font-Names="Tahoma" ForeColor="Black" WIDTH="91px" RUNAT="server"
														CSSCLASS="headform3" Font-Size="9pt">Postal Address</asp:label></TD>
												<TD style="WIDTH: 37px; HEIGHT: 27px">
													<asp:label id="LblTypeAddress2" Font-Names="Tahoma" ForeColor="Black" WIDTH="101px" RUNAT="server"
														CSSCLASS="headform3" Font-Size="9pt">Physical Address</asp:label></TD>
												<TD style="WIDTH: 22px; HEIGHT: 27px"></TD>
												<TD style="WIDTH: 252px; HEIGHT: 27px">
													<asp:label id="Label9" Font-Names="Tahoma" ForeColor="Black" WIDTH="120px" RUNAT="server" CSSCLASS="headform3"
														Font-Size="9pt">Contact Information</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 27px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 27px"></TD>
												<TD style="WIDTH: 364px; HEIGHT: 27px" align="left">
													<asp:label id="Label15" Font-Names="Tahoma" RUNAT="server" CSSCLASS="HeadField1" FONT-SIZE="XX-Small"
														Width="287px">**Address2(PoBox,Street,HC,Ave.,BLVD.,Camino,RR,Parque)</asp:label>
													<asp:label id="Label14" Font-Names="Tahoma" RUNAT="server" CSSCLASS="HeadField1" FONT-SIZE="XX-Small"
														Width="303px">*Address1 (Urb.,Cond.Bo.,Res.,Secc.Coop.,QBDA,Parcelas,Sector)</asp:label></TD>
												<TD style="WIDTH: 37px; HEIGHT: 27px">
													<asp:checkbox id="chkSameAddr" tabIndex="15" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1"
														Width="120px" AUTOPOSTBACK="True" TEXT="Same as postal" Font-Size="9pt" oncheckedchanged="chkSameAddr_CheckedChanged"></asp:checkbox></TD>
												<TD style="WIDTH: 22px; HEIGHT: 27px">
													<asp:label id="lblOccupation" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" Width="68px"
														HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">First Name</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 27px">
													<asp:textbox id="TxtFirstName" tabIndex="21" Font-Names="Tahoma" WIDTH="169px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 27px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 27px">
													<asp:label id="lblAddress1" Font-Names="Tahoma" WIDTH="51px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="10px" Font-Size="9pt">*Address1</asp:label></TD>
												<TD style="WIDTH: 364px; HEIGHT: 27px" align="left">
													<asp:textbox id="txtHomeUrb1" tabIndex="9" Font-Names="Tahoma" WIDTH="163" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="19px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 37px; HEIGHT: 27px">
													<asp:textbox id="txtAddress1Phys" tabIndex="16" Font-Names="Tahoma" WIDTH="163px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="30" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 22px; HEIGHT: 27px">
													<asp:label id="Label5" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" Width="74px"
														HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Last Name 1</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 27px">
													<asp:textbox id="TxtLastName1" tabIndex="22" Font-Names="Tahoma" WIDTH="169px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="50" DESIGNTIMEDRAGDROP="230" Font-Size="9pt"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 23px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 23px">
													<asp:label id="lblAddress2" Font-Names="Tahoma" WIDTH="51px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="10px" Font-Size="9pt">**Address2</asp:label></TD>
												<TD style="WIDTH: 364px; HEIGHT: 23px" align="left">
													<asp:textbox id="txtAddress1" tabIndex="10" Font-Names="Tahoma" WIDTH="163px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="30" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 37px; HEIGHT: 23px">
													<asp:textbox id="txtAddress2Phys" tabIndex="17" Font-Names="Tahoma" WIDTH="163px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="30" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 22px; HEIGHT: 23px">
													<asp:label id="Label11" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" Width="73px"
														HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Last Name 2</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 23px">
													<asp:textbox id="TxtLastName2" tabIndex="23" Font-Names="Tahoma" WIDTH="169px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 14px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 14px">
													<asp:label id="lblCity" Font-Names="Tahoma" WIDTH="51px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="10px" Font-Size="9pt">City</asp:label></TD>
												<TD style="WIDTH: 364px; HEIGHT: 14px" align="left">
													<asp:textbox id="txtCity" tabIndex="11" Font-Names="Tahoma" WIDTH="163px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="19px" MAXLENGTH="14" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 37px; HEIGHT: 14px" align="right">
													<asp:textbox id="txtCityPhys" tabIndex="18" Font-Names="Tahoma" WIDTH="163px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="14" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 22px; HEIGHT: 14px">
													<asp:label id="lblJobName" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" HEIGHT="18px"
														ENABLEVIEWSTATE="False" Font-Size="9pt">Position</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 14px">
													<asp:textbox id="TxtPosition" tabIndex="24" Font-Names="Tahoma" WIDTH="169px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 20px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 20px">
													<asp:label id="lblState" Font-Names="Tahoma" WIDTH="51px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="10px" Font-Size="9pt">State</asp:label></TD>
												<TD style="WIDTH: 364px; HEIGHT: 20px">
													<asp:textbox id="txtState" tabIndex="12" Font-Names="Tahoma" WIDTH="163px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="19px" MAXLENGTH="2" Font-Size="9pt">PR</asp:textbox></TD>
												<TD style="WIDTH: 37px; HEIGHT: 20px">
													<asp:textbox id="txtStatePhys" tabIndex="19" Font-Names="Tahoma" WIDTH="163px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="2" Font-Size="9pt"></asp:textbox></TD>
												<TD style="WIDTH: 22px; HEIGHT: 20px">
													<asp:label id="lblHomePhone" Font-Names="Tahoma" WIDTH="38px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Cellular</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 20px">
													<maskedinput:maskedtextbox id="txtCellular" tabIndex="25" Font-Names="Tahoma" WIDTH="169px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 20px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 20px">
													<asp:label id="lblZipCode" Font-Names="Tahoma" WIDTH="51" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="10px" Font-Size="9pt">Zip Code</asp:label></TD>
												<TD style="WIDTH: 364px; HEIGHT: 20px">
													<maskedinput:maskedtextbox id="txtZipCode" tabIndex="13" Font-Names="Tahoma" WIDTH="163px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="19px" MAXLENGTH="10" MASK="99999Z9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
												<TD style="WIDTH: 37px; HEIGHT: 20px">
													<maskedinput:maskedtextbox id="txtZipCodePhys" tabIndex="20" Font-Names="Tahoma" WIDTH="163px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="10" MASK="99999Z9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
												<TD style="WIDTH: 22px; HEIGHT: 20px">
													<asp:label id="lblWorkPhone" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" Width="70px"
														HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">Work Phone</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 20px">
													<maskedinput:maskedtextbox id="TxtWorkPhone" tabIndex="26" Font-Names="Tahoma" WIDTH="169px" RUNAT="server"
														CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 5px; HEIGHT: 20px"></TD>
												<TD style="WIDTH: 111px; HEIGHT: 20px"></TD>
												<TD style="WIDTH: 364px; HEIGHT: 20px"></TD>
												<TD style="WIDTH: 37px; HEIGHT: 20px"></TD>
												<TD style="WIDTH: 22px; HEIGHT: 20px">
													<asp:label id="lblEmail" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" Width="74px"
														HEIGHT="18px" ENABLEVIEWSTATE="False" Font-Size="9pt">E-mail</asp:label></TD>
												<TD style="WIDTH: 252px; HEIGHT: 20px">
													<asp:textbox id="txtEmail" tabIndex="27" Font-Names="Tahoma" WIDTH="169px" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="19px" MAXLENGTH="100" Font-Size="9pt"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:textbox id="txtAddress2" style="Z-INDEX: 102; LEFT: -28px; POSITION: absolute; TOP: 540px"
				tabIndex="11" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" MAXLENGTH="30" WIDTH="163px"
				Visible="False"></asp:textbox>
			<asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
			<asp:checkbox id="ChkOptOut" style="Z-INDEX: 103; LEFT: 924px; POSITION: absolute; TOP: -4px"
				tabIndex="28" Width="71px" CSSCLASS="headform3" RUNAT="server" TEXT="Opt-Out" AUTOPOSTBACK="True"
				Visible="False" ForeColor="Black" Font-Names="Tahoma"></asp:checkbox></form>
	</body>
</HTML>

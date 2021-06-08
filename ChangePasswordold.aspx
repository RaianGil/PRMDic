<%@ Page language="c#" Inherits="EPolicy.ChangePassword" CodeFile="ChangePassword.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="epolicy.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF"
		topMargin="19" rightMargin="0">
		<form method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 106; LEFT: 8px; WIDTH: 914px; POSITION: static; TOP: 8px; HEIGHT: 405px"
				cellSpacing="0" cellPadding="0" width="914" align="center" bgColor="white" dataPageSize="25"
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
							<TABLE id="Table9" style="WIDTH: 945px; HEIGHT: 609px" cellSpacing="0" cellPadding="0"
								width="945" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 3px" align="right" colSpan="3"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left"> 
													<asp:Label id="Label9" runat="server" Width="137px" Height="16px" Font-Names="Tahoma" Font-Bold="True"
														ForeColor="Black" CssClass="headForm1 " Font-Size="11pt">Search Prospect: </asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:Button id="BtnSave" runat="server" Text="Save" Width="71px" Height="23px" BorderWidth="0px"
														BorderColor="#400000" ForeColor="White" BackColor="#400000" onclick="BtnSave_Click"></asp:Button> 
													<asp:Button id="BtnExit" runat="server" Text="Exit" Width="63px" Height="23px" BorderWidth="0px"
														BorderColor="#400000" ForeColor="White" BackColor="#400000" onclick="BtnExit_Click"></asp:Button>
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
									<TD style="WIDTH: 112px; HEIGHT: 49px" vAlign="middle" align="center">                                                                                                                                          
										<TABLE id="Table6" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table2" style="WIDTH: 346px; HEIGHT: 79px" cellSpacing="0" cellPadding="0" width="346"
														border="0">
														<TR>
															<TD style="WIDTH: 11px; HEIGHT: 15px">
																<asp:label id="lblRequiredLastName1" FORECOLOR="Red" RUNAT="server" CSSCLASS="headfield1" WIDTH="2px"
																	HEIGHT="7px">*</asp:label></TD>
															<TD style="WIDTH: 106px; HEIGHT: 15px">
																<asp:label id="Label2" RUNAT="server" CSSCLASS="headfield1" WIDTH="80px" HEIGHT="18px" ENABLEVIEWSTATE="False"
																	Font-Names="Tahoma" Font-Size="9pt">User Name</asp:label></TD>
															<TD style="WIDTH: 448px; HEIGHT: 15px" align="left">
																<asp:textbox id="TxtUserName" tabIndex="1" runat="server" MaxLength="50" Width="144px" Height="21px"
																	Font-Size="9pt" Font-Names="Tahoma"></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 11px; HEIGHT: 15px">
																<asp:label id="Label6" FORECOLOR="Red" RUNAT="server" CSSCLASS="headfield1" WIDTH="2px" HEIGHT="7px">*</asp:label></TD>
															<TD style="WIDTH: 106px; HEIGHT: 15px">
																<asp:label id="Label1" RUNAT="server" CSSCLASS="headfield1" WIDTH="80px" HEIGHT="18px" ENABLEVIEWSTATE="False"
																	Font-Names="Tahoma" Font-Size="9pt">Old Password</asp:label></TD>
															<TD style="WIDTH: 448px; HEIGHT: 15px" align="left">
																<asp:textbox id="TxtPassword" tabIndex="2" runat="server" MaxLength="10" Width="144px" Height="21px"
																	TextMode="Password" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 11px; HEIGHT: 15px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 15px">
																<asp:Label id="Label5" runat="server" Width="64px"></asp:Label></TD>
															<TD style="WIDTH: 448px; HEIGHT: 15px" align="left"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 11px; HEIGHT: 2px">
																<asp:label id="Label7" FORECOLOR="Red" RUNAT="server" CSSCLASS="headfield1" WIDTH="2px" HEIGHT="7px">*</asp:label></TD>
															<TD style="WIDTH: 106px; HEIGHT: 2px">
																<asp:label id="Label3" RUNAT="server" CSSCLASS="headfield1" WIDTH="94px" HEIGHT="18px" ENABLEVIEWSTATE="False"
																	Font-Names="Tahoma" Font-Size="9pt">New Password</asp:label></TD>
															<TD style="WIDTH: 448px; HEIGHT: 2px" align="left">
																<asp:textbox id="TxtNewPassword" tabIndex="3" RUNAT="server" CSSCLASS="headfield1" WIDTH="142px"
																	HEIGHT="19px" TextMode="Password" MAXLENGTH="10" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 11px; HEIGHT: 2px">
																<asp:label id="Label8" FORECOLOR="Red" RUNAT="server" CSSCLASS="headfield1" WIDTH="2px" HEIGHT="7px">*</asp:label></TD>
															<TD style="WIDTH: 106px; HEIGHT: 2px">
																<asp:label id="Label4" RUNAT="server" CSSCLASS="headfield1" WIDTH="111px" HEIGHT="18px" ENABLEVIEWSTATE="False"
																	Font-Names="Tahoma" Font-Size="9pt">Confirm Password</asp:label></TD>
															<TD style="WIDTH: 448px; HEIGHT: 2px" align="left">
																<asp:textbox id="TxtConfirmPassword" tabIndex="4" RUNAT="server" CSSCLASS="headfield1" WIDTH="142px"
																	HEIGHT="19px" TextMode="Password" MAXLENGTH="10" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 3px" align="left" colSpan="1">
										<asp:label id="LblTotalCases" RUNAT="server" WIDTH="223px" Height="9px" Font-Names="Tahoma"
											ForeColor="Black" Font-Size="9pt">Total Cases:</asp:label>                     </TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 3px">
										<TABLE id="Table1" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD background="Images2/Barra3.jpg"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 3px" align="center">
										<asp:Label id="LblError" runat="server" Width="795px" Visible="False" Font-Names="Tahoma" ForeColor="Red"
											Font-Size="11pt">Label</asp:Label></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 25px" align="center">
										<P align="center">
											<asp:datagrid id="searchIndividual" RUNAT="server" WIDTH="802px" Height="104px" Visible="False"
												BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" ITEMSTYLE-HORIZONTALALIGN="center"
												HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True"
												FONT-SIZE="Smaller" FONT-NAMES="Arial" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
												ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
												ITEMSTYLE-CSSCLASS="HeadForm3">
												<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
												<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
												<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
												<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" CssClass="HeadForm2"
													BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
												<FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
												<Columns>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
														<ItemStyle Font-Names="Tahoma"></ItemStyle>
													</asp:ButtonColumn>
													<asp:BoundColumn DataField="prospectID" HeaderText="Prospect ID">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="firstName" HeaderText="First Name">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="lastName1" HeaderText="Last Name1">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="lastName2" HeaderText="Last Name2">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="homePhone" HeaderText="Home Phone">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="workPhone" HeaderText="Work Phone">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="cellular" HeaderText="Cellular">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="email" HeaderText="E-mail">
														<ItemStyle Font-Names="Tahoma"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
													CssClass="Numbers" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px">
										<P> </P>
										<P align="center"> </P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
			<asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
		</form>
	</body>
</HTML>

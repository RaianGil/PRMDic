<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.IncentiveReport" CodeFile="IncentiveReport.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body background="Images2/SQUARE.GIF" bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 101; LEFT: 4px; WIDTH: 914px; POSITION: static; TOP: 4px; HEIGHT: 13px"
				cellSpacing="0" cellPadding="0" width="914" align="center" bgColor="white" dataPageSize="25"
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
							<TABLE id="Table9" style="WIDTH: 811px; HEIGHT: 8px" cellSpacing="0" cellPadding="0"
								width="811" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 3px" align="right" colSpan="3"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 1px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left"> 
													<asp:Label id="Label8" runat="server" Width="198px" CssClass="headForm1 " Height="16px" Font-Names="Tahoma"
														Font-Size="11pt" ForeColor="Black" Font-Bold="True">Incentive Reports</asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:button id="Button2" tabIndex="44" runat="server" Width="64px" Height="23px" Font-Names="Tahoma"
														Font-Size="9pt" ForeColor="White" BorderColor="#400000" BorderWidth="0px" BackColor="#400000"
														Text="Print" onclick="Button2_Click"></asp:button>
													<asp:button id="BtnExit" tabIndex="45" runat="server" Width="61px" Height="23px" Font-Names="Tahoma"
														ForeColor="White" BorderColor="#400000" BorderWidth="0px" BackColor="#400000"
														Text="Exit"></asp:button> 
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
									<TD style="WIDTH: 112px; HEIGHT: 138px" vAlign="middle" align="center">                                                                                                                                          
										<TABLE id="Table1" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<asp:radiobuttonlist id="rblProspectsReports" style="Design_Time_Lock: False" tabIndex="1" runat="server"
														Width="267px" CssClass="HeadField1" Font-Names="Tahoma" Font-Size="9pt" AutoPostBack="True" Design_Time_Lock="False">
														<asp:ListItem Value="0" Selected="True">Incentive Report</asp:ListItem>
													</asp:radiobuttonlist>
													<P> </P>
													<P> </P>
													<P> </P>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 3px" align="left" colSpan="1">                     
										<asp:label id="LblTotalCases" RUNAT="server" Height="9px" Font-Names="Tahoma" Font-Size="9pt"
											CSSCLASS="headform3" WIDTH="141px">Report Filter</asp:label></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 3px">
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
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px" align="right">
										<TABLE id="Table4" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table3" style="WIDTH: 385px; HEIGHT: 101px" cellSpacing="0" cellPadding="0"
														width="385" border="0">
														<TR>
															<TD style="WIDTH: 87px; HEIGHT: 24px">
																<asp:label id="LblBank" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt" CSSCLASS="headfield1"
																	WIDTH="91px" ENABLEVIEWSTATE="False" HEIGHT="17px">Supplier</asp:label></TD>
															<TD style="HEIGHT: 24px"> 
																<asp:dropdownlist id="ddlSupplier" tabIndex="7" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt"
																	CSSCLASS="headfield1" WIDTH="230px" HEIGHT="19px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px; HEIGHT: 26px">
																<asp:label id="LblLineOfBusiness" runat="server" Width="94px" CssClass="HeadField1" Font-Names="Tahoma"
																	Font-Size="9pt"> Line of Business</asp:label></TD>
															<TD style="HEIGHT: 26px"> 
																<asp:dropdownlist id="ddlPolicyClass" tabIndex="2" runat="server" Width="232px" CssClass="HeadField1"
																	Height="19px" Font-Names="Tahoma" Font-Size="9pt"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px; HEIGHT: 25px">
																<asp:label id="Label1" runat="server" Width="58px" CssClass="HeadField1" Font-Names="Tahoma"
																	Font-Size="9pt">Date From</asp:label></TD>
															<TD style="HEIGHT: 25px"> 
																<maskedinput:maskedtextbox id="txtBegDate" tabIndex="3" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt"
																	CSSCLASS="headfield1" WIDTH="89px" HEIGHT="19px" ISDATE="True"></maskedinput:maskedtextbox> <INPUT id="btnCalendar2" style="WIDTH: 21px; HEIGHT: 21px" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Form1.txtBegDate','calendar_window','width=250,height=250');calendar_window.focus()"
																	tabIndex="4" type="button" value="..." name="btnCalendar" RUNAT="server"> 
																<asp:label id="Label2" runat="server" CssClass="HeadField1" Font-Names="Tahoma" Font-Size="9pt">To</asp:label> 
																<maskedinput:maskedtextbox id="TxtEndDate" tabIndex="5" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt"
																	CSSCLASS="headfield1" WIDTH="89px" HEIGHT="19px" ISDATE="True"></maskedinput:maskedtextbox> <INPUT id="btnCalendar" style="WIDTH: 21px; HEIGHT: 21px" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Form1.TxtEndDate','calendar_window','width=250,height=250');calendar_window.focus()"
																	tabIndex="2" type="button" value="..." name="btnCalendar" RUNAT="server"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px">
																<asp:label id="LblDataType" RUNAT="server" Font-Names="Tahoma" Font-Size="Smaller" CSSCLASS="headfield1"
																	WIDTH="76px" HEIGHT="17px">Date Type:</asp:label></TD>
															<TD> 
																<asp:dropdownlist id="ddlDateType" tabIndex="5" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt"
																	CSSCLASS="headfield1" WIDTH="112px" HEIGHT="23px">
																	<asp:ListItem Value="F" Selected="True">Effective Date</asp:ListItem>
																	<asp:ListItem Value="E">Entry Date</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 12px" align="center">
										<P align="center"> </P>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 5px">
										<P> </P>
									</TD>
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
					</TD>
				</TR>
			</TABLE>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
		</form>
	</body>
</HTML>

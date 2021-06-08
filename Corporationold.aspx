<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Corporation.aspx.cs" Inherits="EPolicy.Corporation" %>
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
            .headForm1
            {
                margin-right: 10px;
            }
            #Form1
            {
                height: 746px;
            }
        </style>
	</HEAD>
	<body background="Images2/SQUARE.GIF" bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 126; LEFT: 4px; WIDTH: 1000px; POSITION: static; TOP: 4px; HEIGHT: 516px"
				cellSpacing="0" cellPadding="0" align="center" bgColor="white" dataPageSize="25"
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
										<TABLE id="Table6" style="WIDTH: 802px; HEIGHT: 231px" 
                            cellSpacing="0" cellPadding="0" width="802"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table4" style="WIDTH: 784px; HEIGHT: 10px" cellSpacing="0" cellPadding="0" width="784"
														border="0">
														<TR>
															<TD style="HEIGHT: 1px" colspan="4">
										<TABLE id="Table1" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0" width="808"
											border="0">
											<TR>
												<TD style="WIDTH: 272px" align="left">     
													<asp:Label id="Label21" runat="server" Width="47px" Height="16px" Font-Size="11pt" Font-Bold="True"
														Font-Names="Tahoma" CssClass="headForm1 " ForeColor="Black">Corporation:</asp:Label>
													<asp:Label id="lblCorporationID" runat="server" Width="134px" Font-Size="10pt" 
                                                        Font-Names="Tahoma"></asp:Label></TD>
												<TD align="right">
													<asp:Button id="btnAuditTrail" runat="server" BackColor="#400000" Width="70px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="AuditTrail" 
                                                        onclick="btnAuditTrail_Click" style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnSearch" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Search" 
                                                        onclick="btnSearch_Click" style="margin-right: 1px"></asp:Button>
													<asp:Button id="BtnSave" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Save" onclick="BtnSave_Click" 
                                                        style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnEdit" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Edit" onclick="btnEdit_Click" 
                                                        style="margin-right: 1px"></asp:Button>
													<asp:Button id="btnAddNew" runat="server" BackColor="#400000" Width="59px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="AddNew" 
                                                        onclick="btnAddNew_Click" style="margin-right: 1px"></asp:Button>
													<asp:Button id="cmdCancel" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Cancel" 
                                                        onclick="cmdCancel_Click" style="margin-right: 1px"></asp:Button>
													<asp:Button id="BtnExit" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Exit" onclick="BtnExit_Click" 
                                                        style="margin-left: 0px"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									                        </TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 1px" colspan="4">
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
															<TD style="WIDTH: 186px; HEIGHT: 1px"> </TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px">
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px">
																<asp:label id="lblB" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="131px">Corporation Description</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtCorporationDescription" tabIndex="1" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="21" CSSCLASS="headfield1" WIDTH="249px" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 10px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 10px">
																<asp:label id="lblPolicyType" Width="99px" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma"
																	Font-Size="9pt">Policy Type</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px">
																<asp:textbox id="txtPolicyType" tabIndex="2" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="21px" CSSCLASS="headfield1" WIDTH="120px" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px">
																<asp:label id="lblIsGroup" RUNAT="server" CSSCLASS="headfield1" 
                                                                    Font-Names="Tahoma" Font-Size="9pt">Is Group?</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:CheckBox ID="chkIsGroup" runat="server" Font-Bold="False" Text="Yes" 
                                                                    TabIndex="4" />
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblCity" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Primary Discount</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtPrimaryDiscount" tabIndex="5" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="19px" CSSCLASS="headfield1" ISDATE="False" WIDTH="55px" MASK="99" MAXLENGTH="10"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblState" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Excess Discount</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtExcessDiscount" tabIndex="6" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="19px" CSSCLASS="headfield1" ISDATE="False" WIDTH="55px" MASK="99" MAXLENGTH="10"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																 </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px" align="justify"></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 5px" colspan="4"> </TD>
														</TR>
														</TABLE>
												</TD>
											</TR>
										</TABLE>
						<P style="height: 325px; width: 807px"> </P>
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

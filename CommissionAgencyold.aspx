<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.CommissionAgency" buffer="True" CodeFile="CommissionAgency.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
	</HEAD>
	<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript">
    $(function() 
    {
        $('#<%= txtEffectiveDate.ClientID %>').datepicker({
            changeMonth: true,            
            changeYear: true});
    });


    function ShowDateTimePicker()
    {
        $('#<%= txtEffectiveDate.ClientID %>').datepicker('show');
    }  
</script>
	<body background="Images2/SQUARE.GIF" bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="commAgency" method="post" runat="server">
			 <table id="Table8" align="center" bgcolor="white" border="0" cellpadding="0" cellspacing="0"
            datapagesize="25" style="z-index: 139; left: 4px; width: 921px; position: static;
            top: 4px; height: 1px" width="921">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3" valign="top">
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
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 1px" cellSpacing="0" cellPadding="0" width="809"
								bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 809px; HEIGHT: 3px" align="center"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 809px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table1" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0" width="808"
											border="0">
											<TR>
												<TD style="WIDTH: 272px" align="left">   
													<asp:Label id="Label2" runat="server" CssClass="headForm1 " ForeColor="Black" Font-Names="tahoma,11pt"
														Font-Bold="True" Font-Size="11pt">Agency ID:</asp:Label>
													<asp:label id="lblAgencyID" runat="server" Width="153px" Font-Names="Tahoma" Font-Size="Smaller"></asp:label></TD>
												<TD align="right">
													<asp:button id="btnAuditTrail" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="64px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Audit Trail"
														BorderWidth="0px" onclick="btnAuditTrail_Click"></asp:button>
													<asp:button id="btnPrint" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="52px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Print" BorderWidth="0px" onclick="btnPrint_Click"></asp:button>
													<asp:button id="BtnSave" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="52px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Save" BorderWidth="0px" onclick="BtnSave_Click"></asp:button>
													<asp:button id="btnAddNew" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="52px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Add" BorderWidth="0px"
														DESIGNTIMEDRAGDROP="30" onclick="btnAddNew_Click"></asp:button>
													<asp:button id="btnEdit" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="52px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Edit" BorderWidth="0px"
														DESIGNTIMEDRAGDROP="31" onclick="btnEdit_Click"></asp:button>
													<asp:button id="cmdCancel" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="52px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Cancel" BorderWidth="0px"
														DESIGNTIMEDRAGDROP="33" onclick="cmdCancel_Click"></asp:button>
													<asp:button id="BtnExit" tabIndex="45" runat="server" Font-Names="Tahoma" BackColor="#400000"
														Width="52px" BorderColor="#400000" Height="23px" ForeColor="White" Text="Exit" BorderWidth="0px"
														DESIGNTIMEDRAGDROP="36" onclick="BtnExit_Click"></asp:button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 4px; width: 809px;" background="Images2/Barra3.jpg">
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
									<TD style="FONT-SIZE: 5pt; WIDTH: 809px; HEIGHT: 62px" vAlign="top" align="center">                                                                                                                                          
										<TABLE id="Table6" style="WIDTH: 802px; HEIGHT: 15px" cellSpacing="0" cellPadding="0" width="802"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center" valign="top">
													<TABLE id="Table4" style="WIDTH: 796px; HEIGHT: 4px" cellSpacing="0" cellPadding="0" width="796"
														border="0">
														<TR>
															<TD style="WIDTH: 147px; HEIGHT: 1px" align="left">
																<asp:label id="lblPolicyID" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1" HEIGHT="17"
																	WIDTH="99px" RUNAT="server">Line of Business:</asp:label></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px" align="left">
																<asp:dropdownlist id="ddlPolicyID" tabIndex="1" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="22px" WIDTH="202px" RUNAT="server">
																	<asp:ListItem></asp:ListItem>
																	<asp:ListItem Value="E">Entry Date</asp:ListItem>
																	<asp:ListItem Value="C">Close Date</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="WIDTH: 85px; HEIGHT: 1px" align="left">
																<asp:label id="lblCommissionRate" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="17px" WIDTH="60px" RUNAT="server">Rate:</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px" align="left">
																<asp:textbox id="txtRate" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="12px" WIDTH="93px" RUNAT="server" MAXLENGTH="3"></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 147px; HEIGHT: 21px" align="left">
																<P>
																	<asp:label id="PolicyType" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1" HEIGHT="17"
																		WIDTH="72px" RUNAT="server">Policy Type:</asp:label></P>
															</TD>
															<TD style="WIDTH: 162px; HEIGHT: 21px" align="left">
																<asp:textbox id="txtPolicyType" tabIndex="2" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="12px" WIDTH="63px" RUNAT="server" MAXLENGTH="3"></asp:textbox></TD>
															<TD style="WIDTH: 85px; HEIGHT: 21px" align="left">
																<asp:label id="Label1" Font-Size="9pt" Font-Names="Tahoma" Width="82px" CSSCLASS="headfield1"
																	RUNAT="server">Effective Date</asp:label></TD>
															<TD style="FONT-SIZE: 2pt; WIDTH: 168px; HEIGHT: 21px" align="left">
																<asp:textbox id="txtEffectiveDate" tabIndex="5" onclick="ShowDateTimePicker()" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="12px" WIDTH="91" RUNAT="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 147px; HEIGHT: 1px" align="left">
																<asp:label id="lblInsurance" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1" HEIGHT="17"
																	WIDTH="91px" RUNAT="server">Insurance Co.:</asp:label></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px" align="left">
																<asp:dropdownlist id="ddlInsuranceCompany" tabIndex="3" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="22px" WIDTH="202px" RUNAT="server">
																	<asp:ListItem></asp:ListItem>
																	<asp:ListItem Value="E">Entry Date</asp:ListItem>
																	<asp:ListItem Value="C">Close Date</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="WIDTH: 85px; HEIGHT: 1px" align="left">
																<asp:label id="lblEntryDate" Font-Size="9pt" Font-Names="Tahoma" Width="72px" CSSCLASS="headfield1"
																	RUNAT="server">Entry Date</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px" align="left">
																<maskedinput:maskedtextbox id="txtEntryDate" tabIndex="7" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="12px" WIDTH="91px" RUNAT="server" Enabled="False" ISDATE="True"></maskedinput:maskedtextbox></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 147px; HEIGHT: 5px" align="left">
																<asp:label id="lblDealerID" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1" HEIGHT="17px"
																	WIDTH="76px" RUNAT="server" Visible="False">Dealer ID:</asp:label></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px" align="left">
																<asp:dropdownlist id="ddlDealerID" tabIndex="5" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="22px" WIDTH="203px" RUNAT="server" Visible="False">
																	<asp:ListItem></asp:ListItem>
																	<asp:ListItem Value="E">Entry Date</asp:ListItem>
																	<asp:ListItem Value="C">Close Date</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="WIDTH: 85px; HEIGHT: 5px" align="left">
																<asp:label id="lblBankID" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1" HEIGHT="17px"
																	WIDTH="58px" RUNAT="server" Visible="False">Bank ID:</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px" align="left">
																<asp:dropdownlist id="ddlBankID" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" CSSCLASS="headfield1"
																	HEIGHT="22px" WIDTH="192px" RUNAT="server" Visible="False">
																	<asp:ListItem></asp:ListItem>
																	<asp:ListItem Value="E">Entry Date</asp:ListItem>
																	<asp:ListItem Value="C">Close Date</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 147px; HEIGHT: 19px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 19px"></TD>
															<TD style="WIDTH: 85px; HEIGHT: 19px"></TD>
															<TD style="WIDTH: 168px; HEIGHT: 19px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 147px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<P id="P1" runat="server"> </P>
															</TD>
															<TD style="WIDTH: 85px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 809px; HEIGHT: 4px" align="left"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 809px; HEIGHT: 27px">
										<asp:datagrid id="searchCommission" Height="151px" WIDTH="798px" RUNAT="server" BORDERSTYLE="Solid"
											BORDERWIDTH="1px" BORDERCOLOR="MidnightBlue" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center"
											BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True" FONT-SIZE="9pt" FONT-NAMES="Tahoma"
											CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="Navy"
											HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="Navy" ITEMSTYLE-CSSCLASS="HeadForm3"
											PageSize="8">
											<FooterStyle ForeColor="AliceBlue" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></FooterStyle>
											<AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
											<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
											<Columns>
												<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn Visible="False" DataField="CommissionAgencyID" HeaderText="CommissionAgencyID"></asp:BoundColumn>
												<asp:BoundColumn DataField="PolicyClassID" HeaderText="Line fo Business"></asp:BoundColumn>
												<asp:BoundColumn DataField="AgencyID" HeaderText="Agency ID"></asp:BoundColumn>
												<asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
												<asp:BoundColumn DataField="InsuranceCompanyID" HeaderText="Insurance Co."></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="BankID" HeaderText="Bank"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CompanyDealerID" HeaderText="Dealer"></asp:BoundColumn>
												<asp:BoundColumn DataField="CommissionRate" HeaderText="Commission Rate"></asp:BoundColumn>
												<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date"></asp:BoundColumn>
												<asp:BoundColumn DataField="CommissionEntryDate" HeaderText="Entry Date"></asp:BoundColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Left" ForeColor="White" BackColor="#400000" PageButtonCount="20"
												CssClass="Numbers" Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></PagerStyle>
										</asp:datagrid></TD>
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
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
			<P></P>
			<P> </P>
			<P>
				<asp:imagebutton id="btnAddNew1" style="Z-INDEX: 120; LEFT: 658px; POSITION: absolute; TOP: 586px"
					tabIndex="8" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
				<asp:imagebutton id="btnEdit1" style="Z-INDEX: 121; LEFT: 690px; POSITION: absolute; TOP: 586px"
					tabIndex="9" runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
				<asp:imagebutton id="BtnSave1" tabIndex="10" RUNAT="server" IMAGEURL="Images/save_btn.gif" TOOLTIP="Save Person Information"
					CAUSESVALIDATION="False" style="Z-INDEX: 122; LEFT: 722px; POSITION: absolute; TOP: 586px" Visible="False"></asp:imagebutton><asp:imagebutton id="cmdCancel1" tabIndex="11" runat="server" CausesValidation="False" ImageUrl="Images/cancel_btn.gif"
					style="Z-INDEX: 123; LEFT: 754px; POSITION: absolute; TOP: 586px" Visible="False"></asp:imagebutton>
				<asp:imagebutton id="btnPrint1" tabIndex="12" runat="server" ImageUrl="Images/printreport_btn.gif"
					AlternateText="Print Report" style="Z-INDEX: 124; LEFT: 882px; POSITION: absolute; TOP: 578px"
					Visible="False"></asp:imagebutton>
				<asp:ImageButton id="btnAuditTrail1" runat="server" Width="48px" Height="19px" ImageUrl="Images/History_btn.bmp"
					style="Z-INDEX: 126; LEFT: 826px; POSITION: absolute; TOP: 586px" Visible="False"></asp:ImageButton><asp:imagebutton id="BtnExit1" tabIndex="14" RUNAT="server" IMAGEURL="Images/exit_btn.gif" CAUSESVALIDATION="False"
					style="Z-INDEX: 127; LEFT: 786px; POSITION: absolute; TOP: 586px" Visible="False"></asp:imagebutton></P>
		</form>
	</body>
</HTML>

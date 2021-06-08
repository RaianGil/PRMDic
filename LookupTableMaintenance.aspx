<%@ Page language="c#" Inherits="EPolicy.LookupTableMaintenance" CodeFile="LookupTableMaintenance.aspx.cs" %>
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
		<form method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 105; LEFT: 170px; WIDTH: 914px; POSITION: static; TOP: 201px; HEIGHT: 492px"
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
							<TABLE id="Table9" style="WIDTH: 811px; HEIGHT: 493px" cellSpacing="0" cellPadding="0"
								width="811" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 3px" align="right" colSpan="3"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD style="WIDTH: 507px; HEIGHT: 18px" align="left"> 
													<asp:Label id="lblProspectNo" runat="server" Font-Names="Tahoma" Font-Bold="True" ForeColor="Black"
														CssClass="headForm1 " Height="16px" Width="179px" Font-Size="11pt">Total Number of Tables:</asp:Label>
													<asp:Label id="lblTotalTables" runat="server" CssClass="headfield1" Font-Names="Tahoma" Width="146px"
														Font-Size="9pt"></asp:Label></TD>
												<TD style="WIDTH: 1px; HEIGHT: 18px"></TD>
												<TD style="HEIGHT: 18px" align="right">
													<P>
														<asp:Button id="btnLookupTableMetadata" runat="server" Font-Names="Tahoma" Text="Lookup Table"
															ForeColor="White" Height="23px" BackColor="#400000" BorderColor="#00000E" BorderWidth="0px" onclick="btnLookupTableMetadata_Click"></asp:Button> 
													</P>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 11px">
										<TABLE id="Table1" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD style="height: 19px" background="Images2/Barra3.jpg"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 2px" align="left" colSpan="1">
										<asp:label id="LblTotalCases" Font-Names="Tahoma" ForeColor="Black" CSSCLASS="headform3" WIDTH="223px"
											RUNAT="server" Height="9px" Font-Size="9pt">Total Cases:</asp:label>                     </TD>
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
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 3px" align="center">
										<asp:Label id="LblError" runat="server" Font-Names="Tahoma" ForeColor="Red" Width="795px" Visible="False"
											Font-Size="11pt">Label</asp:Label></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 25px" align="center">
										<P align="center">
											<asp:datagrid id="grdDisplayTables" Height="172px" RUNAT="server" WIDTH="802px" PageSize="12"
												ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
												ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0"
												FONT-NAMES="Tahoma" FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White"
												HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA"
												BORDERWIDTH="1px" BORDERSTYLE="Solid" HorizontalAlign="Center" 
                                                onselectedindexchanged="grdDisplayTables_SelectedIndexChanged">
												<FooterStyle Font-Size="9pt" Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
												<SelectedItemStyle HorizontalAlign="Center" ForeColor="White" BackColor="White"></SelectedItemStyle>
												<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
												<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
												<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="9pt" Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White"
													CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
												<Columns>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Edit" CommandName="Edit">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:BoundColumn DataField="TableName" HeaderText="Table Name">
														<HeaderStyle Width="80%"></HeaderStyle>
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Add" CommandName="Add">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:BoundColumn Visible="False" DataField="IsValuePair"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="LookupTableID"></asp:BoundColumn>
												</Columns>
												<PagerStyle Font-Size="9pt" Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White"
													PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 1px">
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
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<P> </P>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Inherits="EPolicy.SearchLookupTableDescriptions" CodeFile="SearchLookupTableDescriptions.aspx.cs" %>
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
	<body background="Images2/SQUARE.GIF">
		<!--DIV style="Z-INDEX: 101; LEFT: 8px; WIDTH: 10px; POSITION: absolute; TOP: 8px; HEIGHT: 10px" ms_positioning="text2D"-->
		<FORM id="SearchProspect" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 111; LEFT: 8px; WIDTH: 914px; POSITION: static; TOP: 8px; HEIGHT: 405px"
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
												<TD align="left"> 
													<asp:Label id="lblSearchX" runat="server" Font-Names="Tahoma" Width="377px" Height="16px" ForeColor="Black"
														Font-Bold="True" CssClass="headForm1 " Font-Size="11pt">Search lookup table:</asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:Button id="btnSearch" runat="server" Font-Names="Tahoma" Text="Search" Width="60px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnSearch_Click"></asp:Button>
													<asp:Button id="btnClear" runat="server" Font-Names="Tahoma" Text="Clear" Width="60px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnClear_Click"></asp:Button>
													<asp:Button id="btnAddNew" runat="server" Font-Names="Tahoma" Text="Add" Width="60px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnAddNew_Click"></asp:Button>
													<asp:Button id="btnExit" runat="server" Font-Names="Tahoma" Text="Exit" Width="57px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnExit_Click"></asp:Button> 
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
													<TABLE class="HeadField1" id="tblPerson" style="WIDTH: 792px; HEIGHT: 55px" cellSpacing="0"
														cellPadding="0" RUNAT="server">
														<TR>
															<TD style="WIDTH: 198px; POSITION: static; TOP: 172px; HEIGHT: 7px">  
																  
																<asp:label id="lblSearchFieldA" Width="137px" RUNAT="server" CSSCLASS="HeadField1" Font-Size="9pt"
																	Font-Names="Tahoma"></asp:label></TD>
															<TD style="WIDTH: 72px; HEIGHT: 7px">
																<asp:textbox id="txtSearchFieldA" tabIndex="1" Font-Names="Tahoma" Width="214px" RUNAT="server"
																	CSSCLASS="HeadField1" MAXLENGTH="15" HEIGHT="21" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 31px; HEIGHT: 7px"></TD>
															<TD style="WIDTH: 119px; HEIGHT: 7px">Other Tables</TD>
															<TD style="WIDTH: 329px; HEIGHT: 7px">
																<asp:dropdownlist id="ddlLookupTables" tabIndex="3" runat="server" Font-Names="Tahoma" Width="235px"
																	AutoPostBack="True" Font-Size="9pt" onselectedindexchanged="ddlLookupTables_SelectedIndexChanged"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 198px; HEIGHT: 10px">    
																<asp:label id="lblSearchFieldB" Font-Names="Tahoma" Width="137px" RUNAT="server" CSSCLASS="HeadField1"
																	Font-Size="9pt"></asp:label></TD>
															<TD style="WIDTH: 72px; HEIGHT: 10px">
																<asp:textbox id="txtSearchFieldB" tabIndex="2" Font-Names="Tahoma" Width="214px" RUNAT="server"
																	CSSCLASS="HeadField1" MAXLENGTH="15" HEIGHT="21" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 31px; HEIGHT: 10px"></TD>
															<TD style="WIDTH: 119px; HEIGHT: 10px"></TD>
															<TD style="WIDTH: 329px; HEIGHT: 10px">
                                                                <asp:CheckBox ID="chkGroup" runat="server" style="font-family: Tahoma" 
                                                                    Text="Groups Only" Visible="False" />
                                                            </TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 9px" align="left"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 1px" align="left" colSpan="1">
										<asp:label id="lblTotalRecords" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headform3" Height="9px"
											WIDTH="223px" ForeColor="Black" Font-Size="9pt">Total Records:</asp:label></TD>
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
										<asp:Label id="LblError" runat="server" Font-Names="Tahoma" Width="795px" ForeColor="Red" Visible="False"
											Font-Size="11pt">Label</asp:Label></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 25px" align="center">
										<P align="center">
											<asp:datagrid id="grdRecords" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" 
                                                BORDERSTYLE="Solid" WIDTH="802px"
												RUNAT="server" Height="316px" PageSize="12" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE"
												HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
												CELLPADDING="0" FONT-NAMES="Arial" FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False"
												BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" 
                                                OnItemCommand = "grdRecords_ItemCommand" 
                                                >
                                                
												<FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
												<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
												<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
												<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
												<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
													BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="fieldA">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
														<FooterStyle Font-Names="Tahoma"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="fieldB">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Edit" CommandName="Select">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:BoundColumn Visible="False" DataField="recordID"></asp:BoundColumn>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Delete" CommandName="Delete">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:ButtonColumn>
												</Columns>
												<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
													CssClass="Numbers" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px">
											<asp:datagrid id="grdCharge" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" 
                                            BORDERSTYLE="Solid" WIDTH="802px"
												RUNAT="server" Height="316px" PageSize="12" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE"
												HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
												CELLPADDING="0" FONT-NAMES="Arial" FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False"
												BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" Visible="False"
												OnItemCommand = "grdRecords_ItemCommand">
												<FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
												<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
												<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
												<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
												<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
													BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="chargeID" HeaderText="ID">
														<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
														<FooterStyle Font-Names="Tahoma"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="effectiveDate" HeaderText="EffectiveDate"></asp:BoundColumn>
													<asp:BoundColumn DataField="chargePercent" HeaderText="Charge Percent">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="policyType" HeaderText="PolicyType">
                                                    </asp:BoundColumn>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Edit" CommandName="Select">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:ButtonColumn>
													<asp:ButtonColumn ButtonType="PushButton" HeaderText="Delete" CommandName="Delete">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:ButtonColumn>
												</Columns>
												<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
													CssClass="Numbers" Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										<P align="center"> </P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE> <!--/DIV-->
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal></FORM>
	</body>
</HTML>
<!--onselectedindexchanged="grdRecords_SelectedIndexChanged"-->

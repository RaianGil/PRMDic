<%@ Page language="c#" Inherits="EPolicy.RenewPolicies" CodeFile="RenewPolicies.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<head>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="epolicy.css" type="text/css" rel="stylesheet"/>
	</head>
	
	<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript">
    $(function() 
    {
        $('#<%= txtFrom.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
            
        $('#<%= txtTo.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
     
    });
    
    function ShowDateTimePicker()
    {
        $('#<%= txtFrom.ClientID %>').datepicker('show');
    }   
     
      function ShowDateTimePicker2()
    {
        $('#<%= txtTo.ClientID %>').datepicker('show');
    }   
    </script>
	<Triggers>
                <asp:PostBackTrigger ControlID="BtnUpload" />
   </Triggers>
	<body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF"
		topMargin="19" rightMargin="0">
		<form method="post" runat="server">
		
		
			<TABLE id="Table8" style="Z-INDEX: 153; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 501px"
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
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 374px" cellSpacing="0" cellPadding="0"
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
													<asp:Label id="LblUpload" runat="server" Font-Names="Tahoma" Width="212px" Height="16px"
														Font-Bold="True" ForeColor="Black" Font-Size="11pt" CssClass="headForm1 ">Upload</asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:Button id="BtnExit" runat="server" Text="Exit" Font-Names="Tahoma" Width="45px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnExit_Click"></asp:Button> 
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
									<TD align="center">
                                            &nbsp;
									</TD>
								</TR>
								<TR>
									<TD align="center">
                                            <asp:Label id="Label1" runat="server" Font-Names="Tahoma" Width="212px" Height="16px"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 ">Renew Policies as of:</asp:Label></TD>
									</TD>
								</TR>
                                <TR>
									<TD align="center">
									<asp:Label id="Label2" runat="server" Font-Names="Tahoma" Width="65px" Height="16px" Visible ="True"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 ">From:</asp:Label>
									<asp:TextBox ID="txtFrom" runat="server"  Visible ="True" autocompletetype="Disabled"  autocomplete="Off"
                                                                                Font-Bold="True" Font-Italic="False" Font-Names="Tahoma" Font-Size="9pt" 
                                                                                Height="18px" MaxLength="100" TabIndex="3" Width="150px"
                                                                                onclick="ShowDateTimePicker();"></asp:TextBox>
                                                                           
                                                                           &nbsp;
                                                                           
                                    <asp:Label id="Label3" runat="server" Font-Names="Tahoma" Width="65px" Height="16px" Visible ="True"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 ">To:</asp:Label>
                                    <asp:TextBox ID="txtTo" runat="server"  Visible ="True" autocompletetype="Disabled"  autocomplete="Off"
                                                                                Font-Bold="True" Font-Italic="False" Font-Names="Tahoma" Font-Size="9pt" 
                                                                                Height="18px" MaxLength="100" TabIndex="4" Width="150px" 
                                                                                onclick="ShowDateTimePicker2();"></asp:TextBox>
									</TD>
									
									
									
								</TR>
								
								<TR>
									<TD align="center">
									
									<asp:Button id="BtnGetPoliciesToRenew" runat="server" Text="Get Data" Font-Names="Tahoma" Width="70px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnGetPoliciesToRenew_Click"></asp:Button> 

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
												&nbsp;&nbsp;&nbsp;		
																		

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
									<asp:Button id="BtnRenewPolicies" runat="server" Text="Renew Policies" Font-Names="Tahoma" Width="100px" Height="23px" Visible = "False"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnRenewPolicies_Click"
														onclientclick="return confirm('Are you certain you want to renew the policies?');"></asp:Button> 

									</TD>
								</TR>
								
								<TR>
									<TD align="center">
									
												&nbsp;&nbsp;&nbsp;		
																		

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
									   <asp:Label id="Label4" runat="server" Font-Names="Tahoma" Width="212px" Height="16px"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 "
														visible="false">Policies To Renew:</asp:Label>
														
									 </TD>
								</TR>
								

								<TR>
									<TD style="FONT-SIZE: 2pt; WIDTH: 112px; HEIGHT: 407px" vAlign="middle" align="center">                                                                                                                                          
										<TABLE id="Table6" style="WIDTH: 807px; HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="807"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table1" style="WIDTH: 789px; HEIGHT: 124px" cellSpacing="0" cellPadding="0"
														width="789" border="0">
																						<TR>
									<TD align="right">
                                            <asp:Button id="BtnExportToRenew" runat="server" Text="Export" Font-Names="Tahoma" Width="70px" Height="23px" Visible = "False"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnExportToRenew_Click"></asp:Button> 
									</TD>
								</TR>
														<TR>
															<TD style="WIDTH: 252px; HEIGHT: 20px">
																<asp:datagrid id="ToRenew" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE"
																	HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
																	CELLPADDING="0" FONT-NAMES="Tahoma" FONT-SIZE="Smaller" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False"
																	BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center"
																	BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" PageSize="16" WIDTH="802px" Height="20px">
																	<FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
																	<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
																	<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
																	<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
																	<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
																	<HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																		BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																	<Columns>

																		<asp:BoundColumn DataField="TaskcontrolID" HeaderText="Control Number">
																			<ItemStyle Font-Names="Tahoma"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="PolicyNumber" HeaderText="PolicyNo">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Anniversary" HeaderText="Anniversary">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ExpirationDate" HeaderText="Effective Date">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Customer" HeaderText="Customer">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="MedicalLimit" HeaderText="Limit">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ISOCode" HeaderText="IsoCode">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Specialty" HeaderText="Specialty">
																			<ItemStyle Font-Names="Specialty" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Premium" HeaderText="Premium">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Charge" HeaderText="Charge">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		
																	</Columns>
																	<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																		CssClass="Numbers" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></TD>
														</TR>
														<TR>
									<TD align="center">
									
									  &nbsp;
														
									 </TD>
								</TR>
								<TR>
									<TD align="center">
									
									   <asp:Label id="Label6" runat="server" Font-Names="Tahoma" Width="212px" Height="16px" Visible = "False"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 ">Preview:</asp:Label>
														
									 </TD>
								</TR>
														
														<TR>
									                        <TD align="right">
                                                                <asp:Button id="BtnExportPreview" runat="server" Text="Export" Font-Names="Tahoma" Width="70px" Height="23px" 
														        ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnExportPreview_Click"
														        visible="false"></asp:Button> 
									                        </TD>
								                        </TR>

														
														<TR>
															<TD style="WIDTH: 252px; HEIGHT: 20px">
																<asp:datagrid id="PreviewRenew" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE"
																	HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
																	CELLPADDING="0" FONT-NAMES="Tahoma" FONT-SIZE="Smaller" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False"
																	BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center"
																	BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" PageSize="16" WIDTH="802px" Height="20px">
																	<FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
																	<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
																	<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
																	<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
																	<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
																	<HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																		BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																	<Columns>

																		<asp:BoundColumn DataField="TaskcontrolID" HeaderText="Control Number">
																			<ItemStyle Font-Names="Tahoma"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="PolicyNumber" HeaderText="PolicyNo">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Anniversary" HeaderText="Anniversary">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="ExpirationDate" HeaderText="Effective Date">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Customer" HeaderText="Customer">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="MedicalLimit" HeaderText="Limit">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="IsoCode" HeaderText="IsoCode">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Specialty" HeaderText="Specialty">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Premium" HeaderText="Premium">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Charge" HeaderText="Charge">
																			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		
																	</Columns>
																	<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																		CssClass="Numbers" Mode="NumericPages"></PagerStyle>
																</asp:datagrid></TD>
														</TR>
														
														<TR>
									                        <TD align="center">
									                        
                                                                   &nbsp;</TD>
								                        </TR>
								                        
														<TR>
															<TD style="WIDTH: 252px; HEIGHT: 27px"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
										<P> </P>
										<P> </P>
									</TD>
								</TR
								<TR>
								<td >
																<asp:button id="cmdRemove" tabIndex="59" runat="server" Width="24px" Height="20px" Font-Size="9pt"
																	Font-Names="Tahoma" Text="<<" onclick="cmdRemove_Click" Visible="false"></asp:button>
																<asp:button id="cmdSelect" tabIndex="58" runat="server" Width="24px" Font-Names="Tahoma" Font-Size="9pt"
																	Height="20px" Text=">>" Visible="false" onclick="cmdSelect_Click"></asp:button>
                                                                 
                                                                
                                                                 <asp:listbox id="ddlSelectedAgent" tabIndex="60" runat="server" Width="170px" Font-Names="Arial" Visible="false"
																	Font-Size="7.5pt" Height="22px" onselectedindexchanged="ddlSelectedAgent_SelectedIndexChanged"></asp:listbox>
                                                                 
                                                                 
																<asp:dropdownlist id="ddlAvailableAgent" tabIndex="57" RUNAT="server" Font-Size="7.5pt" Font-Names="Arial"
																	HEIGHT="19px" CSSCLASS="headfield1" WIDTH="128px" Visible="false"></asp:dropdownlist>
																	
														        <asp:label id="LblSelectAgent" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																		HEIGHT="14px" CSSCLASS="headfield1" WIDTH="124px" Visible="False">Available 
                                                                    Agent - Level</asp:label>
								</td>
                                                                 
								
								
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

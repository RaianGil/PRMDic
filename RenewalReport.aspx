<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.RenewalReport" CodeFile="RenewalReport.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
				<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
		<script type="text/javascript">
		    $(function () {
		        $('#<%= txtBegDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        $('#<%= TxtEndDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });

		    });

		    function ShowDateTimePicker() {
		        $('#<%= txtBegDate.ClientID %>').datepicker('show');
		    }
		    function ShowDateTimePicker2() {
		        $('#<%= TxtEndDate.ClientID %>').datepicker('show');
		    }  
                       
		</script>	
	    <style type="text/css">
            .style1
            {
                width: 267px;
                height: 8px;
            }
            .style2
            {
                width: 27px;
                height: 8px;
            }
            .style3
            {
                width: 419px;
                height: 8px;
            }
            .style4
            {
                width: 232px;
                height: 8px;
            }
            .btn-w-70 {
                width: 70px;
                height: 25px;
                font-size: 9pt;
            }
            .btn-r-4 {
                border-radius: 4px;
                border: none;
            }
            .btn-bg-theme1 {
                background: #ba354e;
                color: #fff;
            }
            .txt-pv-5 {
                padding: 5px 2px;
            }
            .txt-r-4 {
                box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
                border-radius: 4px;
                background-color: #fff;
                border: 1px solid #ccc;
            }
            .txt-h-25 {
                height: 25px;
            }
        </style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Client" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 126; LEFT: 4px; WIDTH: 100%; POSITION: static; TOP: 4px; HEIGHT: 232px"
				cellSpacing="0" cellPadding="0" width="914" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center" valign="top">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 811px; HEIGHT: 1px" cellSpacing="0" cellPadding="0"
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
													<asp:Label id="Label14" runat="server" CssClass="headForm1 " Height="16px" Width="198px" Font-Names="Tahoma"
														Font-Size="11pt" ForeColor="Black" Font-Bold="True">Renewal Reports</asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:button id="BtnPrint" tabIndex="44" runat="server" onclick="BtnPrint_Click" 
                                                        class="btn-w-70 btn-bg-theme1 btn-r-4" Text="Print"></asp:button>
													<asp:button id="BtnExit" tabIndex="45" runat="server" onclick="BtnExit_Click" 
                                                        class="btn-w-70 btn-bg-theme1 btn-r-4" Text="Exit"></asp:button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px">
										<TABLE id="Table11" style="WIDTH: 808px" borderColor="#c00000" height="5px" cellSpacing="0"
											borderColorDark="#c00000" cellPadding="0" width="808" bgColor="#c00000" borderColorLight="#c00000"
											border="0">
											<TR>
												<TD style="height:1px;" background="Images2/GreyLine.png"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 112px; HEIGHT: 138px" vAlign="middle" align="center">                                                                                                                                          
										<TABLE id="Table1" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt; height: 7px;" align="center">
													<asp:radiobuttonlist id="rblReportList" style="Design_Time_Lock: False" runat="server" AutoPostBack="True"
														Design_Time_Lock="False" Width="191px" Font-Size="9pt" Font-Names="Tahoma" onselectedindexchanged="rblReportList_SelectedIndexChanged">
														<asp:ListItem Value="0" Selected="True">Pending Policy Renewals</asp:ListItem>
														<asp:ListItem Value="1">Renewed Policies To Print</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 3px" align="left" colSpan="1">                     
										<asp:label id="LblTotalCases" Height="9px" WIDTH="141px" CSSCLASS="headform3" RUNAT="server"
											Font-Names="Tahoma" Font-Size="9pt">Report Filter</asp:label></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 3px">
										<TABLE id="Table2" style="WIDTH: 808px" borderColor="#c00000" height="5px" cellSpacing="0"
											borderColorDark="#c00000" cellPadding="0" width="808" bgColor="#c00000" borderColorLight="#c00000"
											border="0">
											<TR>
												<TD style="height:1px;" background="Images2/GreyLine.png"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 32px" align="right">
										<TABLE id="Table3" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table5" style="WIDTH: 418px; HEIGHT: 28px" cellSpacing="0" cellPadding="0"
														width="418" border="0">
														<TR>
															<TD style="WIDTH: 87px" align="right">
																</TD>
															<TD align="left">
                                                                  
																</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 260px" align="left">
																<asp:label id="Label5" runat="server" CssClass="HeadField1" Font-Size="9pt" Font-Names="Tahoma">Effective Date From</asp:label></TD>
															<TD align="left" style="width: 340px">   <asp:textbox id="txtBegDate" tabIndex="3" RUNAT="server" WIDTH="89px"
																	onclick="ShowDateTimePicker()" class="headfield1 txt-r-4 txt-pv-5" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox>
                                                                  
																<asp:label id="Label2" runat="server" CssClass="HeadField1" Font-Size="9pt" Font-Names="Tahoma">To</asp:label>
																<asp:textbox id="TxtEndDate" class="headfield1 txt-r-4 txt-pv-5" tabIndex="5" RUNAT="server" WIDTH="89px" 
																	onclick="ShowDateTimePicker2()" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox>
																</TD>
														</TR>
														<TR>
															<TD class="style2">
																<asp:label id="lblStatus" CssClass="HeadField1" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    ForeColor="Black" Width="120px"
																	RUNAT="server" HEIGHT="12px" Visible="False">Status:</asp:label>
															</TD>
															<TD style="WIDTH: 460px; HEIGHT: 8px">
                                                                <asp:DropdownList runat="server" ID="ddlStatus" Width="111px" Visible="False">
                                                                    <asp:ListItem Value="1">Inforce</asp:ListItem>
                                                                    <asp:ListItem Value="2">Cancelled</asp:ListItem>
                                                                </asp:DropdownList>
                                                            </TD>
															<TD class="style4"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px; height: 7px;">
																</TD>
															<TD style="height: 7px">
                                                                       
                                                            </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px">
																</TD>
															<TD>
                                                                      
                                                            </TD>
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
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 84px">
										<P> </P>
										<P align="center"> </P>
										<P align="center"> </P>
										<P align="center"> </P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<maskedinput:maskedtextheader id="Maskedtextheader2" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader> 
		</form>
	</body>
	</HTML>
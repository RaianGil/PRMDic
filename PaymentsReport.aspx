<%@ Page language="c#" Inherits="EPolicy.PaymentsReport" CodeFile="PaymentsReport.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
	<style type="text/css">	
	    #jq-books{width:200px;float:right;margin-right:0}
	    #jq-books li{line-height:1.25em;margin:1em 0 1.8em;clear:left}
	    #home-content-wrapper #jq-books a.jq-bookImg{float:left;margin-right:10px;width:55px;height:70px}
	    #jq-books h3{margin:0 0 .2em 0}
	    #home-content-wrapper #jq-books h3 a{font-size:1em;color:black;}
	    #home-content-wrapper #jq-books a.jq-buyNow{font-size:1em;color:white;display:block;background:url(http://static.jquery.com/files/rocker/images/btn_blueSheen.gif) 50% repeat-x;text-decoration:none;color:#fff;font-weight:bold;padding:.2em .8em;float:left;margin-top:.2em;}
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
	<body bottomMargin="0" leftMargin="0"
		topMargin="9" rightMargin="0">
		<form id="Paym" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 124; LEFT: 4px; WIDTH: 100%; POSITION: static; TOP: 4px; HEIGHT: 409px"
				cellSpacing="0" cellPadding="0" width="914" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 811px; HEIGHT: 414px" cellSpacing="0" cellPadding="0"
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
														Font-Size="11pt" ForeColor="Black" Font-Bold="True">Payments Reports</asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:button id="Button2" tabIndex="44" runat="server" onclick="Button2_Click" 
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
												<TD style="FONT-SIZE: 1pt" align="center">
													<asp:radiobuttonlist id="rblProspectsReports" style="Design_Time_Lock: False" tabIndex="1" runat="server"
														Width="267px" CssClass="HeadField1" AutoPostBack="True" Design_Time_Lock="False" Font-Names="Tahoma"
														Font-Size="9pt" onselectedindexchanged="rblProspectsReports_SelectedIndexChanged">
														<asp:ListItem Value="0" Selected="True">Payments List</asp:ListItem>
														<asp:ListItem Value="1">Payments Applied</asp:ListItem>
														<asp:ListItem Value="2">Payments Unapplied</asp:ListItem>
														<asp:ListItem Value="3">Payments Deposited</asp:ListItem>
														<asp:ListItem Value="4">Payments By CheckNo</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 3px" align="left" colSpan="1">                     
										<asp:label id="LblTotalCases" CSSCLASS="headform3" WIDTH="141px" RUNAT="server" Height="9px"
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
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px" align="right">
										<TABLE id="Table4" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table3" style="WIDTH: 371px; HEIGHT: 99px" cellSpacing="0" cellPadding="0" width="371"
														border="0">
														<TR>
															<TD style="WIDTH: 87px">
																<asp:label id="LblLineOfBusiness" runat="server" Width="94px" CssClass="HeadField1" Font-Names="Tahoma"
																	Font-Size="9pt"> Line of Business</asp:label></TD>
															<TD> 
																<asp:dropdownlist id="ddlPolicyClass" tabIndex="2" runat="server" Width="244px" class="headfield1 txt-r-4 txt-pv-5"
                                                                Font-Names="Tahoma" Font-Size="9pt"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px">
																<asp:label id="LblBank" Visible="False" ENABLEVIEWSTATE="False" HEIGHT="18px" CSSCLASS="headfield1"
																	WIDTH="26px" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt">Bank</asp:label></TD>
															<TD> 
																<asp:dropdownlist id="ddlBank" tabIndex="7" Visible="False" HEIGHT="19px" class="headfield1 txt-r-4 txt-pv-5" WIDTH="244px"
																	RUNAT="server" Font-Names="Tahoma" Font-Size="9pt"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px; HEIGHT: 20px">
																<asp:label id="Label1" runat="server" Width="58px" CssClass="HeadField1" Font-Names="Tahoma"
																	Font-Size="9pt">Date From</asp:label></TD>
															<TD style="HEIGHT: 20px"> 
																<asp:TextBox id="txtBegDate" tabIndex="3" onclick="ShowDateTimePicker();" HEIGHT="19px" class="headfield1 txt-r-4 txt-pv-5" WIDTH="104px" RUNAT="server"
																	ISDATE="True" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>  
																<asp:label id="Label2" runat="server" CssClass="HeadField1" Font-Names="Tahoma" Font-Size="9pt">To</asp:label> 
																<asp:TextBox id="TxtEndDate" tabIndex="5" onclick="ShowDateTimePicker2();" HEIGHT="19px" class="headfield1 txt-r-4 txt-pv-5" WIDTH="104px" RUNAT="server"
																	ISDATE="True" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 87px">
																<asp:label id="LblCheckNo" runat="server" Visible="False" Width="57px" CssClass="HeadField1"
																	Font-Names="Tahoma" Font-Size="9pt">Check No.</asp:label></TD>
															<TD> 
																<asp:TextBox id="TxtCheckNo" runat="server" Visible="False" Width="115px" Height="21px" Font-Names="Tahoma"
																	Font-Size="9pt"></asp:TextBox></TD>
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
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader> 
		</form>
	</body>
</HTML>

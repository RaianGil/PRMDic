<%@ Page language="c#" Inherits="EPolicy.MainMenu" CodeFile="MainMenu.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>   
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="epolicy1.css" type="text/css" rel="stylesheet" />
        <link rel="icon" type="image/x-icon" href="images2/favicon.png" />
        <link href="js/bootstrap.min.css" rel="stylesheet" type="text/css" />
		<script src="js/load.js" type="text/javascript"></script>

	    <style type="text/css">
            .style1
            {
                width: 764px;
                height: 1px;
            }
            #Table1
            {
                width: 38px;
            }
            .btn-r-4 {
                border-radius: 4px;
                border: none;
            }
            .btn-bg-theme1 {
                background: #ba354e;
                color: #fff;
            }
            .btn-w-200 
            {
                padding:0px 10px;
                min-width: 90px;
                height: 35px;
            }
        </style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Main" method="post" runat="server">
			<TABLE id="Table1"
				cellSpacing="0" cellPadding="0" align="center" bgColor="white" dataPageSize="25"
				border="0" style="WIDTH: 100%;">
				<TR>
					<TD colSpan="2" class="style1">
						<P>
							<asp:placeholder id="phTopBanner" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD valign="top">
							 <asp:Panel id="Panel2" runat="server" BorderStyle="None" Width="100%" 
                            Height="215px" BackColor="White"
								BorderColor="#000040" BorderWidth="1px" Font-Size="5pt" 
                            style="text-align: center">
								<TABLE id="Table4" style="WIDTH: 100%; HEIGHT: 130px" cellSpacing="0" 
                                    cellPadding="1" border="0   " align="center">
									<TR>
										<TD align="center">
											<asp:Label id="Label4" runat="server" Font-Size="11pt" 
                                                BorderColor="Transparent" Width="110px"
												Font-Names="Tahoma" Font-Bold="True" ForeColor="Black">Main Menu</asp:Label>
											</TD>
									</TR>
									<TR>
										<TD align="center">
                                            <img src="Images2/LineMenu.JPG" style="height: 1px" width="158" /></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 2px" align="center">
											<asp:Button id="btnProspect" tabIndex="1" runat="server" onclick="Button5_Click" 
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Prospects"></asp:Button></TD>
										<TD style="HEIGHT: 10px; text-align: center;" align="center">
											<asp:Button id="btnCustomer" tabIndex="2" runat="server" onclick="BtnLogIn_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Customers"></asp:Button></TD>
										<TD style="HEIGHT: 5px" align="center">
											<asp:Button id="Button1" tabIndex="3" runat="server" onclick="Button1_Click1"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Quotes"></asp:Button></TD>
										<TD style="HEIGHT: 5px" align="center">
											<asp:Button id="ButtonFD" tabIndex="3" runat="server" onclick="btnFirstDollarQuote_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="First Dollar Quotes"/></TD>
										<TD style="HEIGHT: 5px" align="center">
											<asp:Button id="ButtonFDC" tabIndex="3" runat="server" onclick="btnFirstDollarCorporate_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="First Dollar Corporate Quotes"/></TD>
									</TR>
                                    <tr>
                                        <td align="center" style="height: 5px">
                                            <asp:Button ID="Button3" runat="server" Onclick="Button3_Click1"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="ASPEN Quotes"/>
                                        </td>
                                        <td align="center" style="height: 5px">
                                            <asp:Button ID="btnLabQuote" runat="server" OnClick="BtnLabPolicy_Click" 
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Laboratory Quotes"/>
                                        </td>
                                        <td align="center" style="height: 5px">
                                            <asp:Button ID="btnAspenLab" runat="server" onclick="btnAspenLab_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Aspen Laboratory Quotes"/>
                                        </td>
                                        <td align="center" style="height: 5px">
                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Corporate Policy Quotes"/>
                                        </td>
                                            <td align="center" style="height: 5px">
                                             <asp:Button ID="btnCyberQuote" runat="server" OnClick="btnCyberQuote_Click1"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Cyber Policy Quotes"/>
                                            </td>
                                    </tr>
                                    <tr>
                                            <td align="center" style="height: 5px">
                                             <asp:Button ID="btnAllied" runat="server" OnClick="btnAlliedHealth_Click" 
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="AHP Individual Quote"/>
                                            </td>
                                            <td align="center" style="height: 5px">
                                             <asp:Button ID="btnAlliedCorporate" runat="server" OnClick="btnAlliedHealthCorp_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="AHC Corporate Policy"/>
                                            </td>
                                        <td align="center" style="height: 5px">
                                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="ASPEN Corp. Policy Quotes"/>
                                        </td>
                                        <td align="center" style="height: 5px">
                                            <asp:Button ID="btnApplicationRequirements" runat="server" OnClick="btnApplicationRequirements_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Application Requirements"/>
                                        </td>
										<TD align="center">
											<asp:Button ID="btnExit" runat="server" onclick="Button2_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Exit" />
                                        </TD>
									</TR>
									<TR>
										<TD align="center">
                                            <asp:Button ID="btnSign" runat="server" OnClick="btnSign_Click"
                                                class="btn-r-4 btn-bg-theme1 btn-w-200" Text="Sign"/>
                                        </TD>
									</TR>
								    <tr>
                                        <td align="center" style="FONT-SIZE: 9pt">
                                        </td>
                                    </tr>
								</TABLE>
							</asp:Panel>
					</TD>
				</TR>
				</TABLE>
            <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
                style="z-index: 102; left: 407px; width: 35px; position: absolute; top: 562px;
                height: 22px" type="hidden" value="false" />
			 
		</form>
	</body>
</HTML>

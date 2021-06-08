<%@ Control Language="c#" Inherits="EPolicy.EPolicyWeb.Components.LeftReportMenu" CodeFile="LeftReportMenu.ascx.cs" %>
<TABLE id="Table1" style="WIDTH: 169px; HEIGHT: 523px" borderColor="#800000" height="523"
	cellSpacing="0" cellPadding="0" width="169" align="left" border="1" runat="server">
	<TR>
		<TD style="FONT-SIZE: 0pt; width: 167px;" vAlign="top" align="left" height="1">
			<TABLE id="Table3" style="WIDTH: 164px; HEIGHT: 295px" height="295" cellSpacing="1" cellPadding="1"
				width="164" bgColor="white" border="0">
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 25px">
						<P>
							<asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Height="12px" Width="113px"
								Font-Size="9pt" ForeColor="Black">REPORT MENU</asp:label>
							<asp:textbox id="Textbox3" runat="server" Height="1px" Width="158px" ForeColor="#000040" BorderColor="#000040"
								BorderStyle="Solid"></asp:textbox></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 11px" align="center">
						<P align="center">
							<asp:Button id="btnClientReport" runat="server" Font-Names="Tahoma" Height="19px" Width="147px"
								ForeColor="White" BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000"
								Text="Client Reports" onclick="Button10_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 2px" align="center">
						<P>
							<asp:Button id="btnQueriesGroupReport" runat="server" Font-Names="Tahoma" Height="19px" Width="147px"
								ForeColor="White" BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000"
								Text="Policies Reports" onclick="Button11_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 2px" align="center">
						<P align="center">
							<asp:Button id="btnRenewalReport" runat="server" ForeColor="White" Width="147px" Height="19px"
								Font-Names="Tahoma" BorderStyle="None" BorderColor="#C00000" Text="Renewal Report"
								BackColor="#C00000" BorderWidth="0px" onclick="btnRenewalReport_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 2px" align="center">
						<P>
							<asp:Button id="btnPaymentReports" runat="server" Font-Names="Tahoma" Height="19px" Width="147px"
								ForeColor="White" BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000"
								Text="Payment Reports" onclick="Button12_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 2px" align="center">
						<P align="center">
							<asp:Button id="btnCommissionReport" runat="server" ForeColor="White" Width="147px" Height="19px"
								Font-Names="Tahoma" BorderStyle="None" BorderColor="#C00000" Text="Commission Report"
								BackColor="#C00000" BorderWidth="0px" onclick="Button1_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px" align="center">
							<asp:Button id="btnMainMenu" runat="server" Font-Names="Tahoma" Height="19px" Width="147px"
								ForeColor="White" BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000"
								Text="Main Menu" onclick="Button3_Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px" align="center"></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 1px" align="center"></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 4px" align="center"></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 8px" align="center"></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px"></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px">
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px">
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px">
						<P align="center">&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px" align="center"></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 18px" align="center">
						<asp:textbox id="Textbox4" runat="server" Height="1px" Width="158px" ForeColor="#000040" BorderColor="#000040"
							BorderStyle="Solid"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>

<%@ Page language="c#" Inherits="EPolicy.ActiveXViewer" CodeFile="ActiveXViewer.aspx.cs" %>
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
		<form id="ActiveXExport" method="post" runat="server">
			<asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
			<TABLE id="Table4" style="Z-INDEX: 102; LEFT: 160px; WIDTH: 975px; POSITION: absolute; TOP: 0px; HEIGHT: 59px; BACKGROUND-COLOR: white"
				cellSpacing="1" cellPadding="1" width="975" border="0" RUNAT="server" bgColor="#ffffff">
				<TR>
					<TD class="Headform3" style="WIDTH: 163px" colSpan="3">
						<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="Headform3" style="WIDTH: 259px">   
						<asp:Label id="Label8" runat="server" CssClass="headForm1 " Width="198px" Height="16px" Font-Names="Tahoma"
							Font-Size="11pt" ForeColor="Black" Font-Bold="True">Report Viewer:</asp:Label></TD>
					<TD style="WIDTH: 254px" align="left"><asp:radiobuttonlist id="rblReports" style="Design_Time_Lock: False" runat="server" Width="240px" CssClass="headForm1 "
							Design_Time_Lock="False" RepeatDirection="Horizontal" Font-Names="Tahoma" Font-Size="9pt" onselectedindexchanged="rblReports_SelectedIndexChanged" ForeColor="Black">
							<asp:ListItem Value="PDF">Export To PDF</asp:ListItem>
							<asp:ListItem Value="XLS">Export To Excel</asp:ListItem>
							<asp:ListItem Value="CSV">Export To CSV</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD align="right">
						<asp:button id="btnEMail" tabIndex="45" runat="server" Width="83px" Height="23px" Font-Names="Tahoma"
							ForeColor="White" Text="Send E-Mail" BackColor="#400000" BorderColor="#400000"
							BorderWidth="0px" onclick="btnEMail_Click"></asp:button>
						<asp:button id="BtnDownLoad" tabIndex="45" runat="server" Width="83px" 
                            Height="23px" Font-Names="Tahoma"
							ForeColor="White" Text="Download" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" 
                            onclick="Button1_Click"></asp:button>
						<asp:button id="btnBack" tabIndex="45" runat="server" Width="72px" Height="23px" Font-Names="Tahoma"
							ForeColor="White" Text="Exit" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnExit_Click"></asp:button>   </TD>
				</TR>
				<TR>
					<TD class="Headform3" style="FONT-SIZE: 5pt; WIDTH: 163px; HEIGHT: 11px" colSpan="3">
						<TABLE id="Table11" style="WIDTH: 983px; HEIGHT: 19px" borderColor="#4b0082" height="19"
							cellSpacing="0" borderColorDark="#4b0082" cellPadding="0" width="983" bgColor="indigo"
							borderColorLight="#4b0082" border="0">
							<TR>
								<TD background="Images2/Barra3.jpg"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<!--div id="pagetop">
			<div id="pagetitlebanner">
				<h1><a href="default.aspx">ActiveReports for ASP.NET Sample</a></h1>
				<h2>ActiveX Viewer Control Samples</h2>
			</div>
		</div-->
		<div id="pagebody">
			<P>
				<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 159px; POSITION: absolute; TOP: 158px" runat="server"
					Height="297px" Width="432px">
					<OBJECT id="arv" style="WIDTH: 228.69%; HEIGHT: 400%" codeBase="arview2.cab"
						width="228.69%" classid="clsid:8569D715-FF88-44BA-8D1D-AD3E59543DDE" VIEWASTEXT>
						<PARAM NAME="_ExtentX" VALUE="26088">
						<PARAM NAME="_ExtentY" VALUE="11695">
					</OBJECT>
					<SCRIPT language="vbscript">
				<!--
				sub arv_ControlLoaded()
					arv.DataPath = "ActiveXViewer.aspx?ReturnReport=1"
				end sub
				-->
					</SCRIPT>
				</asp:Panel>
			</P>
			<!--p>
				ActiveReports for .NET includes an ActiveX Control for viewing and printing 
				reports from a browser. Provides an interactive viewing experience, and a high 
				quality printable output without requiring the .NET framework on the client 
				machine.
			</p--></div>
	</body>
</HTML>

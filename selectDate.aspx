<%@ Page language="c#" Inherits="EPolicy.selectDate" CodeFile="selectDate.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="epolicy.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<table>
				<tr>
					<td>
						<asp:Label id="lblMonths" runat="server" CssClass="HeadField1">Month</asp:Label></td>
					<td style="WIDTH: 70px">
						<asp:DropDownList id="cboMonths" runat="server" AutoPostBack="True" CssClass="HeadField1" tabIndex="1" onselectedindexchanged="cboMonths_SelectedIndexChanged">
							<asp:ListItem Value="1">January</asp:ListItem>
							<asp:ListItem Value="2">February</asp:ListItem>
							<asp:ListItem Value="3">March</asp:ListItem>
							<asp:ListItem Value="4">April</asp:ListItem>
							<asp:ListItem Value="5">May</asp:ListItem>
							<asp:ListItem Value="6">June</asp:ListItem>
							<asp:ListItem Value="7">July</asp:ListItem>
							<asp:ListItem Value="8">August</asp:ListItem>
							<asp:ListItem Value="9">September</asp:ListItem>
							<asp:ListItem Value="10">October</asp:ListItem>
							<asp:ListItem Value="11">November</asp:ListItem>
							<asp:ListItem Value="12">December</asp:ListItem>
						</asp:DropDownList></td>
					<td>
						<asp:Label id="lblYears" runat="server" CssClass="HeadField1">Year</asp:Label></td>
					<td>
						<asp:DropDownList id="cboYears" runat="server" AutoPostBack="True" CssClass="HeadField1" tabIndex="2" onselectedindexchanged="cboYears_SelectedIndexChanged"></asp:DropDownList></td>
				</tr>
				<tr>
					<td colspan="4" align="left"><!--<asp:Calendar id="Calendar1" Height="60" Width="220px" runat="server" ForeColor="#00000" BackColor="#ffffff" BorderColor="Transparent" OnSelectionChanged="calSelectDay_SelectionChanged" OnDayRender="calSelectDay_DayRender" showtitle="true" DayNameFormat="FirstTwoLetters" FirstDayOfWeek="Monday" NextPrevFormat="ShortMonth" SelectedDate="2003-01-14">
							<DayStyle ForeColor="#004F7F" BackColor="#FEFBF6"></DayStyle>
							<NextPrevStyle Font-Size="Smaller" ForeColor="White" BackColor="#72A2BB"></NextPrevStyle>
							<DayHeaderStyle ForeColor="Black" BackColor="#FEFBF6"></DayHeaderStyle>
							<SelectedDayStyle Font-Names="Arial" ForeColor="#818181" BackColor="#C3D3DA"></SelectedDayStyle>
							<TitleStyle ForeColor="White" BackColor="#78A2BB"></TitleStyle>
							<OtherMonthDayStyle ForeColor="#E2CA9A" BackColor="#FEFBF6"></OtherMonthDayStyle>
						</asp:Calendar>-->
						<asp:Calendar id="calSelectDay" runat="server" OnSelectionChanged="calSelectDay_SelectionChanged"
							OnDayRender="calSelectDay_DayRender" showtitle="true" DayNameFormat="FirstTwoLetters" BackColor="#ffffff"
							FirstDayOfWeek="Monday" BorderColor="Transparent" ForeColor="#00000" Height="60" Width="224px"
							NextPrevFormat="ShortMonth" CssClass="headfield1" tabIndex="3">
							<DayStyle ForeColor="SteelBlue" BackColor="#FEFBF6"></DayStyle>
							<NextPrevStyle Font-Size="Smaller" ForeColor="White" BackColor="SteelBlue"></NextPrevStyle>
							<DayHeaderStyle ForeColor="Black" BackColor="#FEFBF6"></DayHeaderStyle>
							<SelectedDayStyle Font-Names="Arial" ForeColor="#818181" BackColor="#C3D3DA"></SelectedDayStyle>
							<TitleStyle ForeColor="White" BackColor="SteelBlue"></TitleStyle>
							<OtherMonthDayStyle ForeColor="#E2CA9A" BackColor="#FEFBF6"></OtherMonthDayStyle>
						</asp:Calendar>
						<!--<NextPrevStyle ForeColor="White" BackColor="Navy"></NextPrevStyle>
							<TitleStyle ForeColor="White" BackColor="Navy"></TitleStyle>
							<OtherMonthDayStyle ForeColor="Silver"></OtherMonthDayStyle>
						</asp:Calendar>--></td>
				</tr>
			</table>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
	</body>
</HTML>

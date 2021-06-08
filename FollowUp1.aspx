<%@ Page language="c#" Inherits="EPolicy.FollowUp" CodeFile="FollowUp.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="baldrich.css" type="text/css" rel="stylesheet">
		<script>
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="TxtAttachment" style="Z-INDEX: 110; LEFT: 97px; POSITION: absolute; TOP: 131px"
				tabIndex="3" runat="server" BorderWidth="1px" BorderColor="SteelBlue" Width="279px" Font-Size="9pt"
				Font-Names="Tahoma"></asp:textbox>
			<asp:listbox id="FileList" style="Z-INDEX: 128; LEFT: 543px; POSITION: absolute; TOP: 201px"
				runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="196px" Height="77px" Visible="False"></asp:listbox>
			<asp:TextBox id="TextBox18" style="Z-INDEX: 113; LEFT: 11px; POSITION: absolute; TOP: 44px" runat="server"
				Width="710px" BorderColor="#400000" Height="1px" BorderStyle="Solid" ForeColor="Navy"></asp:TextBox>
			<asp:button id="btnEnviar" style="Z-INDEX: 112; LEFT: 523px; POSITION: absolute; TOP: 19px"
				tabIndex="8" runat="server" Width="75px" BorderColor="#400000" BorderWidth="1px" Height="23px"
				BorderStyle="Solid" BackColor="#400000" Font-Size="9pt" ForeColor="White" Text="Enviar"
				Font-Names="Tahoma" onclick="btnEnviar_Click"></asp:button>
			<asp:button id="btnSalir" style="Z-INDEX: 111; LEFT: 610px; POSITION: absolute; TOP: 19px" tabIndex="8"
				runat="server" Width="75px" BorderColor="#400000" BorderWidth="1px" Height="23px" BorderStyle="Solid"
				BackColor="#400000" Font-Size="9pt" ForeColor="White" Text="Salir" Font-Names="Tahoma" onclick="btnSalir_Click"></asp:button>
			<asp:label id="LblAttachment" style="Z-INDEX: 109; LEFT: 18px; POSITION: absolute; TOP: 134px"
				RUNAT="server" CSSCLASS="headfield1" ENABLEVIEWSTATE="False" WIDTH="20px" HEIGHT="18px"
				Font-Size="9pt" Font-Names="Tahoma">Attachments:</asp:label>
			<asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
			<asp:textbox id="TxtBody" style="Z-INDEX: 102; LEFT: 43px; POSITION: absolute; TOP: 158px" tabIndex="4"
				runat="server" Height="245px" Width="646px" BorderColor="SteelBlue" BorderWidth="1px" TextMode="MultiLine"
				Font-Size="9pt" Font-Names="Tahoma"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 108; LEFT: 45px; POSITION: absolute; TOP: 110px" RUNAT="server"
				HEIGHT="18px" WIDTH="20px" ENABLEVIEWSTATE="False" CSSCLASS="headfield1" Font-Size="9pt" Font-Names="Tahoma">Subject:</asp:label><asp:label id="Label1" style="Z-INDEX: 107; LEFT: 57px; POSITION: absolute; TOP: 86px" RUNAT="server"
				HEIGHT="18px" WIDTH="20px" ENABLEVIEWSTATE="False" CSSCLASS="headfield1" Font-Size="9pt" Font-Names="Tahoma">From:</asp:label><asp:label id="LblTo" style="Z-INDEX: 106; LEFT: 66px; POSITION: absolute; TOP: 62px" RUNAT="server"
				HEIGHT="18px" WIDTH="20px" ENABLEVIEWSTATE="False" CSSCLASS="headfield1" Font-Size="9pt" Font-Names="Tahoma">To...</asp:label><asp:textbox id="TxtMailTo" style="Z-INDEX: 105; LEFT: 97px; POSITION: absolute; TOP: 57px" tabIndex="1"
				runat="server" Width="590px" BorderColor="SteelBlue" BorderWidth="1px" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox><asp:textbox id="TxtMailFrom" style="Z-INDEX: 103; LEFT: 97px; POSITION: absolute; TOP: 81px"
				tabIndex="2" runat="server" Width="591px" BorderColor="SteelBlue" BorderWidth="1px" Font-Size="9pt" Font-Names="Tahoma">system@prmdic.net</asp:textbox><asp:textbox id="TxtMailSubject" style="Z-INDEX: 104; LEFT: 97px; POSITION: absolute; TOP: 105px"
				tabIndex="3" runat="server" Width="591px" BorderColor="SteelBlue" BorderWidth="1px" Font-Size="9pt" Font-Names="Tahoma"></asp:textbox><asp:panel id="Panel3" style="Z-INDEX: 100; LEFT: 3px; POSITION: absolute; TOP: 7px" RUNAT="server"
				HEIGHT="419px" WIDTH="727px" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#004F7F" DESIGNTIMEDRAGDROP="76"></asp:panel></form>
	</body>
</HTML>

<%@ Page language="c#" Inherits="EPolicy.NewTask" CodeFile="NewTrans.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
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
			<TABLE id="Table1" style="Z-INDEX: 104; LEFT: 413px; WIDTH: 913px; POSITION: static; TOP: 38px; HEIGHT: 541px"
				cellSpacing="0" cellPadding="0" width="913" align="center" bgColor="white" dataPageSize="25"
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
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 82px" align="center">
						<P>
							<TABLE id="Table4" style="WIDTH: 811px; HEIGHT: 18px" cellSpacing="0" cellPadding="1" width="811"
								border="0">
								<TR>
									<TD style="HEIGHT: 11px" align="center">
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left"> 
												</TD>
												<TD>
													<asp:Label id="Label4" runat="server" Font-Names="Tahoma" Width="130px" Font-Bold="True" ForeColor="Black"
														Font-Size="11pt" BorderColor="Transparent">New Transaction</asp:Label></TD>
												<TD align="right">
													<asp:Button id="btnEdit" runat="server" Font-Names="Tahoma" Width="85px" Text="Go" ForeColor="White"
														Height="23px" Font-Size="9pt" BackColor="#400000" BorderStyle="None" onclick="btnEdit_Click" BorderColor="#400000"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; HEIGHT: 17px" align="center"> 
										<TABLE id="Table11" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD style="height: 18px" background="Images2/Barra3.jpg"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 10px" align="center">
										<asp:label id="lblTelephone" Font-Names="Tahoma" CSSCLASS="HeadField1" RUNAT="server" Font-Size="9pt">Transaction Type:</asp:label> 
										<asp:dropdownlist id="ddlTaskControlType" tabIndex="18" Font-Names="Tahoma" HEIGHT="19px" CSSCLASS="headfield1"
											WIDTH="220px" RUNAT="server" Font-Size="9pt" onselectedindexchanged="ddlTaskControlType_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 6px" align="center"></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 5px" align="center"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"></TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
						<P> </P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 86px; HEIGHT: 66px" align="center">
						<P> </P>
						<P> </P>
						<P><BR>
							 </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
		</form>
	</body>
</HTML>

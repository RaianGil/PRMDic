<%@ Page language="c#" Inherits="EPolicy.ClientTasks" CodeFile="ClientTasks.aspx.cs" %>
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
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader><asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<TABLE id="Table9" style="Z-INDEX: 101; LEFT: 1008px; WIDTH: 589px; POSITION: static; TOP: 360px; HEIGHT: 1px"
				cellSpacing="0" cellPadding="0" bgColor="white" border="0">
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 1053px; HEIGHT: 1px" align="left" colSpan="4">
						<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></TD>
					<TD style="FONT-SIZE: 0pt; HEIGHT: 1px" align="right" colSpan="3"></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 299px; HEIGHT: 389px" align="center" rowSpan="8">
						<P>   
							<asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder>                        </P>
					</TD>
					<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">
						<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
							width="808" border="0">
							<TR>
								<TD align="left"> 
									<asp:Label id="Label4" runat="server" Font-Names="Tahoma" Width="137px" Font-Bold="True" ForeColor="Black"
										CssClass="headForm1 " Height="16px" Font-Size="11pt">Event List</asp:Label></TD>
								<TD></TD>
								<TD align="right">
									<asp:Button id="btnClose" runat="server" Font-Names="Tahoma" Width="62px" Text="Exit" ForeColor="White"
										Height="23px" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnClose_Click"></asp:Button> 
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 0pt;">
						<TABLE id="Table11" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
							borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
							border="0">
							<TR>
								<TD style="WIDTH: 829px" background="Images2/Barra3.jpg"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 1px" align="left">
						<asp:label id="LblTotalCases" Font-Size="9pt" Height="9px" ForeColor="Black" Font-Names="Tahoma"
							CSSCLASS="headForm1 " WIDTH="188px" RUNAT="server">Total Cases:</asp:label></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 0pt; WIDTH: 35px; height: 21px;">
						<TABLE id="Table2" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
							borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
							border="0">
							<TR>
								<TD style="height: 19px" background="Images2/Barra3.jpg"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 8px" align="center">
						<asp:Label id="LblError" runat="server" Font-Names="Tahoma" Width="780px" ForeColor="Red" Visible="False"
							Font-Size="11pt">Label</asp:Label>
					</TD>
				</TR>
                <tr>
                    <td align="center" style="font-size: 0pt; width: 35px; height: 7px" valign="top">
                        <asp:datagrid id="searchIndividual" Height="1px" WIDTH="805px" RUNAT="server" ITEMSTYLE-HORIZONTALALIGN="center"
								HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True"
								FONT-SIZE="Smaller" FONT-NAMES="Arial" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6"
								HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE" ITEMSTYLE-CSSCLASS="HeadForm3" PageSize="20"
								BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" OnItemCommand="searchIndividual_ItemCommand" OnSelectedIndexChanged="searchIndividual_SelectedIndexChanged">
								<FooterStyle Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
								<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
								<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
								<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" CssClass="HeadForm2"
									BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
										<ItemStyle Font-Names="tahoma"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="TaskControlID" HeaderText="Control No">
										<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
                                    <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
									<asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
										<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
                                    <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv."></asp:BoundColumn>
									<asp:BoundColumn DataField="EffectiveDate" HeaderText="Eff. Date" DataFormatString="{0:d}">
										<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EntryDate" HeaderText="Entry Date" DataFormatString="{0:d}">
										<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
                                    <asp:BoundColumn DataField="TaskControlTypeID" HeaderText="TaskControlTypeID" Visible="False">
                                    </asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
									CssClass="Numbers" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
                </tr>
				<TR>
					<TD style="FONT-SIZE: 0pt; WIDTH: 69px; height: 23px;">
						<P> </P>
						<P align="left">
                             </P>
					</TD>
				</TR>
			</TABLE>
			<P align="center"> </P>
			<P align="center"> </P>
		</form>
	</body>
</HTML>

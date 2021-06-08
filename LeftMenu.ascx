<%@ Control Language="c#" Inherits="EPolicy.EPolicyWeb.Components.MenuTaskControl" CodeFile="LeftMenu.ascx.cs" %>
<%@ Register assembly="MaskedInput" namespace="MaskedInput" tagprefix="maskedinput" %>
<style type="text/css">
    .style1
    {
        width: 162px;
        height: 18px;
    }
    .style4
    {
        width: 162px;
        height: 2px;
    }
    .style5
    {
        width: 162px;
        height: 1px;
    }
</style>
<TABLE id="Table1" style="WIDTH: 143px; HEIGHT: 479px" cellSpacing="0" cellPadding="0"
	width="143" border="1" runat="server" align="left" borderColor="maroon">
	<TR>
		<TD vAlign="top" align="left" style="FONT-SIZE: 0pt">
			<TABLE id="Table3" style="FONT-SIZE: 1pt; WIDTH: 164px; HEIGHT: 248px" 
                cellSpacing="1" cellPadding="1"
				width="164" border="0" bgColor="white">
				<TR>
					<TD   valign="bottom">
							<asp:label id="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Height="12px" Width="113px"
								Font-Size="9pt" ForeColor="Black">TRANSACTIONS</asp:label>
					</TD>
				</TR>
				<TR>
					<TD  >
						<img src="Images2/LineMenu.JPG"
                                    width="158" /></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 4px; width: 162px;" colSpan="1" rowSpan="1">
						<P align="center">
							<asp:Button id="Button8" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
								BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Main Menu" onclick="Button8_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 2px; width: 162px;" align="center">
						<P>
							<asp:Button id="Button12" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
								BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Reports" onclick="Button12_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD align="left" valign="bottom">
						 </TD>
				</TR>
				<TR>
					<TD   align="left" valign="bottom">
						<asp:label id="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Height="12px" Width="66px"
							Font-Size="9pt" ForeColor="Black">SEARCH</asp:label> </TD>
				</TR>
				<TR>
					<TD align="left">
						<img src="Images2/LineMenu.JPG"
                                width="158" style="height: 1px" /></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 1px; width: 162px;" align="center">
						<asp:Button id="Button9" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Search" onclick="Button9_Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 5px; width: 162px;" align="center">
						<asp:Button id="Button5" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Prospects" onclick="Button5_Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 3px; width: 162px;" align="center">
						<asp:Button id="Button6" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Customers" onclick="Button6_Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 9px; width: 162px;" align="center">
						<asp:Button id="Button7" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Policies" onclick="Button7_Click"></asp:Button></TD>
				</TR>
                <tr>
                    <td align="center" class="menuOptionsHead" style="width: 162px; height: 9px">
                        <asp:Button ID="btnDirectory" runat="server" BackColor="#C00000" BorderColor="#C00000"
                            BorderStyle="None" BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="19px"
                            OnClick="btnDirectory_Click" Text="Directory" Width="147px" /></td>
                </tr>
                <tr>
                    <td align="center" class="menuOptionsHead" style="width: 162px; height: 9px">
                        <asp:Button ID="btnGroup" runat="server" BackColor="#C00000" BorderColor="#C00000"
                            BorderStyle="None" BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="19px"
                            OnClick="btnGroup_Click" Text="Groups" Width="147px" /></td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                         </td>
                </tr>
                <tr>
                    <td align="left" class="style5">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt"
                            ForeColor="Black" Height="12px" Width="66px">CLAIM</asp:Label></td>
                </tr>
                <tr>
                    <td align="left"  >
                        <img src="Images2/LineMenu.JPG"
                                width="158" style="height: 1px" /></td>
                </tr>
				<TR>
					<TD class="" style="HEIGHT: 8px; width: 162px;" align="center"><asp:Button id="btnClaim" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="New Claim"/>
                    </TD>
				</TR>
                <tr>
                    <td align="center" class="menuOptionsHead" style="width: 162px; height: 8px">
                        <asp:Button ID="btnSearchClaim" runat="server" BackColor="#C00000" BorderColor="#C00000"
                            BorderStyle="None" BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="19px"
                            Text="Search Claim" Width="147px" /></td>
                </tr>
				<TR>
					<TD class="style4" style="height: 1px" valign="bottom">
						 </TD>
				</TR>
				<TR>
					<TD class="style4" style="height: 1px" valign="bottom">
						<asp:label id="Label5" runat="server" Font-Bold="True" Font-Names="Tahoma" Height="12px" Width="113px"
							Font-Size="9pt" ForeColor="Black">ADMINISTRATION</asp:label> </TD>
				</TR>
				<TR>
					<TD  >
						<img src="Images2/LineMenu.JPG"
                                width="158" style="height: 1px" /></TD>
				</TR>
                <tr>
                    <td align="center" class="menuOptionsHead" style="width: 162px; height: 11px">
                        <asp:Button ID="Button10" runat="server" BackColor="#C00000" BorderColor="#C00000"
                            BorderStyle="None" BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="19px"
                            OnClick="Button10_Click" Text="Payment Express" Width="147px" /></td>
                </tr>
                <tr>
                    <td align="center" class="menuOptionsHead" style="width: 162px; height: 11px">
                        <asp:Button ID="btnImportPayments" runat="server" BackColor="#C00000" BorderColor="#C00000"
                            BorderStyle="None" BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="19px"
                            OnClick="btnImportPayments_Click" Text="Import Payments" Width="147px" /></td>
                </tr>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 11px; width: 162px;">
						<P align="center">
							<asp:Button id="Button1" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
								BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Lookup Tables" onclick="Button1_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 1px; width: 162px;">
						<P align="center">
							<asp:Button id="Button4" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
								BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="Add User" onclick="Button4_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 1px; width: 162px;">
						<P align="center">
							<asp:Button id="Button2" runat="server" Font-Names="Tahoma" Height="19px" Width="147px" ForeColor="White"
								BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" Text="User Properties List" onclick="Button2_Click"></asp:Button></P>
					</TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 7px; width: 162px;" align="center">
						<asp:Button id="btnProcess" runat="server" Font-Names="Tahoma" Height="19px" 
                            Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" 
                            Text="Email Notifications" onclick="btnProcess_Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 7px; width: 162px;" align="center">
						<asp:Button id="BtnUploadSS" runat="server" Font-Names="Tahoma" Height="19px" 
                            Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" 
                            Text="Upload SS" onclick="BtnUploadSS_Click" Visible="False"></asp:Button></TD>
				</TR>
				<TR>
					<TD class="menuOptionsHead" style="HEIGHT: 7px; width: 162px;" align="center">
						<asp:Button id="Button3" runat="server" Font-Names="Tahoma" Height="19px" 
                            Width="147px" ForeColor="White"
							BorderColor="#C00000" BorderStyle="None" BorderWidth="0px" BackColor="#C00000" 
                            Text="Group &amp; Permissions" onclick="Button3_Click" Visible="False"></asp:Button></TD>
				</TR>
				
				
				<TR>
					<TD class="style1" align="center">
						 </TD>
				</TR>
                </TABLE>
		</TD>
	</TR>
</TABLE>
<p>
     </p>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
			<asp:imagebutton id="btnAddNew1" style="Z-INDEX: 117; LEFT: 859px; POSITION: absolute; TOP: 9px"
				tabIndex="10" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="btnEdit1" style="Z-INDEX: 118; LEFT: 883px; POSITION: absolute; TOP: 9px" tabIndex="11"
				runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="BtnSave1" style="Z-INDEX: 119; LEFT: 915px; POSITION: absolute; TOP: 9px" tabIndex="12"
				RUNAT="server" Visible="False" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif"></asp:imagebutton>
			<asp:imagebutton id="btnSearch1" style="Z-INDEX: 120; LEFT: 947px; POSITION: absolute; TOP: 9px"
				tabIndex="13" runat="server" Visible="False" ImageUrl="Images/search_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="cmdCancel1" style="Z-INDEX: 121; LEFT: 979px; POSITION: absolute; TOP: 9px"
				tabIndex="14" runat="server" Visible="False" ImageUrl="Images/cancel_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="btnPrint1" style="Z-INDEX: 122; LEFT: 1099px; POSITION: absolute; TOP: 9px"
				tabIndex="15" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
			<asp:ImageButton id="btnAuditTrail1" style="Z-INDEX: 123; LEFT: 1011px; POSITION: absolute; TOP: 9px"
				runat="server" Width="48px" Height="19px" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
			<asp:imagebutton id="BtnExit1" style="Z-INDEX: 124; LEFT: 1067px; POSITION: absolute; TOP: 9px" tabIndex="17"
				RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
		

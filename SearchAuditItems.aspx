<%@ Page language="c#" Inherits="EPolicy.SearchAuditItems" CodeFile="SearchAuditItems.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="epolicy.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
	    <form method="post" runat="server">
			
        <p>
            <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
        </p>
        <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
            <div class="col-md-12" style="text-align:right">
                <asp:Label id="lblHeading" runat="server"></asp:Label>
                
                <asp:Button id="btnBack" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Exit" onclick="btnBack_Click"></asp:Button>
            </div>
            <div class="col-md-12">
                <asp:datagrid id="grdAuditItems" RUNAT="server" WIDTH="802px" Height="261px" ITEMSTYLE-HORIZONTALALIGN="center"
                	HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True"
                	FONT-SIZE="9pt" FONT-NAMES="Tahoma" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
                	ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
                	ITEMSTYLE-CSSCLASS="HeadForm3" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" >
                	<FooterStyle Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
                	<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                	<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                	<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                	<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                	<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
                		BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                	<Columns>
                		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
                			<HeaderStyle HorizontalAlign="Center" Width="10px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:ButtonColumn>
                		<asp:BoundColumn DataField="HistoryID" HeaderText="Transaction ID">
                			<HeaderStyle HorizontalAlign="Center" Width="85px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:BoundColumn>
                		<asp:BoundColumn DataField="EntryDAte" HeaderText="Date &amp; Time">
                			<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:BoundColumn>
                		<asp:BoundColumn DataField="Users" HeaderText="User">
                			<HeaderStyle HorizontalAlign="Center" Width="165px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:BoundColumn>
                		<asp:BoundColumn DataField="Actions" HeaderText="Action">
                			<HeaderStyle HorizontalAlign="Center" Width="75px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:BoundColumn>
                		<asp:BoundColumn DataField="Subject" HeaderText="Subject">
                			<HeaderStyle HorizontalAlign="Center" Width="125px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:BoundColumn>
                		<asp:BoundColumn DataField="KeyID" HeaderText="Key ID">
                			<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                		</asp:BoundColumn>
                		<asp:BoundColumn Visible="False" DataField="Notes" HeaderText="Notes">
                			<HeaderStyle Width="150px"></HeaderStyle>
                			<ItemStyle Font-Names="tahoma"></ItemStyle>
                		</asp:BoundColumn>
                	</Columns>
                	<PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
                		CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                </asp:datagrid>
            </div>
            <div class="col-md-8">
               <div class="mb-3 row">
                   <asp:label id="Label2" RUNAT="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Notes:</asp:label>
                   <div class="col-md-12">
                        <asp:TextBox id="TxtNotes" runat="server" CssClass="form-control fs-txt-s" Width="100%" Height="157px" TextMode="MultiLine"></asp:TextBox>
                   </div>
               </div>
            </div>

            <div class="col-md-4"></div>
        
                                                                            
<%--            <asp:Label id="Label1" runat="server">Label</asp:Label>
--%>            </div>
		</form>
	</body>
</HTML>

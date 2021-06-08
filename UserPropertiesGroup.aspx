<%@ Page language="c#" Inherits="EPolicy.UserPropertiesGroup" CodeFile="UserPropertiesGroup.aspx.cs" %>
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
            <div class="d-none">
                <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
            </div>
            <asp:Button id="btnClose" style="Z-INDEX: 105; POSITION: absolute; TOP: 25px; left: 48rem;" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="btnClose_Click"></asp:Button>
            <asp:Label id="Label1" class="fs-14 fw-bold" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 29px" runat="server">Authenticated Group:</asp:Label>
            <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
            <asp:datagrid id="DtgAuthenticatedGroup" style="Z-INDEX: 103; LEFT: 25px; POSITION: absolute; TOP: 70px" WIDTH="796px" RUNAT="server" ForeColor="#333333" AlternatingRowStyle-BackColor="White" class="table table-bordered table-condensed table-hover" Height="424px"
                AUTOGENERATECOLUMNS="False" ALLOWPAGING="True" CELLPADDING="0" PageSize="16">
                <Columns>
                    <asp:ButtonColumn HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." ButtonType="PushButton" CommandName="Select">
                        <HeaderStyle Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn Visible="False" DataField="AuthenticatedGroupID" HeaderText="AuthenticatedGroupID">
                        <ItemStyle Font-Names="tahoma"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="AuthenticatedGroupDesc" HeaderText="Authenticated Group">
                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
                <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
            </asp:datagrid>
        </form>
    </body>

    </HTML>
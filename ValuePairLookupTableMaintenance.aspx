<%@ Page language="c#" Inherits="EPolicy.GeneralLookupTableMaintenance" CodeFile="ValuePairLookupTableMaintenance.aspx.cs" %>
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

    <body>
        <form method="post" runat="server">

            <p>
                <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
            </p>
            <div class="container-xl mb-4 p-18">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label id="Label1" runat="server">Description ID :</asp:Label>
                        <asp:label id="lblDescriptionID" runat="server"></asp:label>
                    </div>
                    <div class="col-md-6 f-right">
                        <asp:Button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Print List" onclick="btnPrint_Click"></asp:Button>
                        <asp:Button id="cmdExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="cmdExit_Click"></asp:Button>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr>
                </div>
                <div class="col-md-12 mt-4 mb-4 f-center">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:label id="LblTotalCases" class="fs-lbl-s" RUNAT="server">Table:</asp:label>
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList id="ddlLookupTables" class="fs-txt-s form-select" tabIndex="1" runat="server" AutoPostBack="True" onselectedindexchanged="ddlLookupTables_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr>
                </div>

                <asp:datagrid id="grdDisplayDescriptions" RUNAT="server" class="table table-bordered table-condensed table-hover " Width="100%" Height="261px" PageSize="12" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-BackColor="White" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False"
                    onselectedindexchanged="grdDisplayDescriptions_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonColumn ButtonType="PushButton" HeaderText="Edit" CommandName="Select">
                            <HeaderStyle Width="10%"></HeaderStyle>
                        </asp:ButtonColumn>
                        <asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID">
                            <HeaderStyle Width="10%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Desc" HeaderText="Description">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:ButtonColumn ButtonType="PushButton" HeaderText="Delete" CommandName="Delete">
                            <HeaderStyle Width="10%"></HeaderStyle>
                            <ItemStyle></ItemStyle>
                        </asp:ButtonColumn>
                    </Columns>
                    <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                    <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                </asp:datagrid>
                <div class="col-md-6 mb-1">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblInput" RUNAT="server" Visible="False">New:</asp:label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox id="txtInput" tabIndex="3" runat="server" Visible="False" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <asp:Button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                    <asp:Button id="cmdAdd" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Add" onclick="cmdAdd_Click"></asp:Button>
                    <asp:Button id="cmdSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Save" onclick="cmdSave_Click"></asp:Button>
                </div>
                <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
            </div>
        </form>
    </body>

    </HTML>
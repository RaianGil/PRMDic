<%@ Page language="c#" Inherits="EPolicy.GroupAndPermissions" CodeFile="GroupAndPermissions.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
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
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md">
                            <asp:Label id="Label17" class="fs-16" runat="server"> Group & Permissions:</asp:Label>
                        </div>
                        <div class="col-md f-right">
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="btnCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="btnCancel_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="LblTotalCases" class="fs-16" RUNAT="server">Permissions</asp:label>
                        </div>
                        <div class="col-md-6">
                            <asp:Label id="Label1" runat="server">Group:</asp:Label>
                            <asp:dropdownlist id="ddlAuthenticatedGroup" class="form-select" RUNAT="server" AutoPostBack="True" onselectedindexchanged="ddlAuthenticatedGroup_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="col-md">
                                <asp:Label id="Label3" runat="server">Available</asp:Label>
                                <asp:ListBox id="lbxAvailable" class="form-control" runat="server"></asp:ListBox>
                                <asp:Button id="cmdSelect" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text=">>" onclick="cmdSelect_Click"></asp:Button>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md">
                                <asp:Label id="Label2" runat="server">Selected</asp:Label>
                                <asp:ListBox id="lbxSelected" class="form-control" runat="server"></asp:ListBox>
                                <asp:Button id="cmdRemove" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="<<" onclick="cmdRemove_Click"></asp:Button>
                            </div>
                        </div>
                    </div>

                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
                    <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
                </div>
            </form>
        </body>

        </HTML>
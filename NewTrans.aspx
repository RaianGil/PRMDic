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

        <body>
            <form method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label4" runat="server">New Transaction</asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Go" onclick="btnEdit_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="f-center">
                        <asp:label id="lblTelephone" RUNAT="server">Transaction Type:</asp:label>
                        <div class="col-md-5">
                            <asp:dropdownlist id="ddlTaskControlType" RUNAT="server" class="form-select" onselectedindexchanged="ddlTaskControlType_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>

                    <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>

                </div>
            </form>
        </body>

        </HTML>
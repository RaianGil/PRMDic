<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RenewAuto.aspx.cs" Inherits="EPolicy.RenewAuto" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Untitled Page</title>
    </head>

    <body>
        <form id="form1" runat="server">
            <div class="container-xl mb-4 p-18">
                <div class="d-none">
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </div>
                <div class="mb-4"></div>
                <div class="row mb-2">
                    <div class="col-md-4">
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control fs-txt-s"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlAvailableAgent" runat="server" class="form-select fs-txt-s" TabIndex="57">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:ListBox ID="ddlSelectedAgent" class="form-control fs-txt-s h-6" runat="server" TabIndex="60"></asp:ListBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" OnClick="Button1_Click" Text="Renew" />
                </div>
            </div>
        </form>
    </body>

    </html>
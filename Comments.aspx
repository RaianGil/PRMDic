<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="Comments" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <html>

        <head>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <link href="Epolicy.css" type="text/css" rel="stylesheet">
            <style type="text/css">
                .style1 {
                    height: 39px;
                }
            </style>
        </head>

        <body>
            <form id="Form1" method="post" runat="server">

                <p>
                    <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="Label6" runat="server">View Comments:</asp:Label>
                            <asp:Label ID="LblTotalComments" runat="server">Total Comments:</asp:Label>
                            <asp:Label ID="LblCustomerName" runat="server">Policy No:</asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button ID="btnApplyComments" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Add Comments" OnClick="btnApply_Comments"></asp:Button>
                            <asp:Button ID="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="BtnExit_Click" Text="Exit" />
                        </div>
                    </div>
                    <div class="col-mb-12">
                        <hr>
                    </div>
                    <div class="col-md-12 mb-4">
                        <asp:Label ID="Label1" runat="server">Comments:</asp:Label>
                        <asp:TextBox ID="TxtComments" runat="server" class="form-control" ontextchanged="TxtComments_TextChanged" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <asp:Label ID="Label5" runat="server">Total Cases:</asp:Label>

                    <asp:Label ID="LblError" runat="server" Visible="False">Label</asp:Label>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <asp:DataGrid ID="searchComments" Height="260px" runat="server" ItemStyle-CssClass="HeadForm3" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" CellPadding="0"
                        Font-Names="Arial" Font-Size="9pt" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center" Width="795px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#400000"
                        onselectedindexchanged="searchComments_SelectedIndexChanged" onitemcommand="searchComments_ItemCommand" onitemcreated="searchComments_ItemCreated">
                        <FooterStyle BackColor="Navy"></FooterStyle>
                        <AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                        <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="Del.">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" onclientclick="return confirm('Are you certain you want to delete this comment?');" CommandName="Delete" />
                                </ItemTemplate>
                                <HeaderStyle Width="40px" />
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="CommentsID" HeaderText="Id"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UserName" HeaderText="User">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Comments" HeaderText="Comments">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EntryDate" HeaderText="Date">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:ButtonColumn Visible="False" HeaderImageUrl="Images/checkmark_image.gif" ButtonType="PushButton" CommandName="Select">
                                <ItemStyle Font-Names="tahoma"></ItemStyle>
                            </asp:ButtonColumn>
                            <asp:BoundColumn DataField="TaskControlID" HeaderText="Task Control" Visible="False">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="UserID" HeaderText="UserID" Visible="False">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>

                    <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>
                    <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                </div>
            </form>
        </body>

        </html>
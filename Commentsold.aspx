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
        .style1
        {
            height: 39px;
        }
    </style>
</head>
<body bottommargin="0" leftmargin="0" background="Images2/SQUARE.GIF" topmargin="19"
    rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="Table8" style="z-index: 113; left: 4px; width: 914px; position: static;
        top: 4px; height: 506px" cellspacing="0" cellpadding="0" width="914" align="center"
        bgcolor="white" datapagesize="25" border="0">
        <tr>
            <td style="width: 764px; height: 1px" colspan="3">
                <p>
                    <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                </p>
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; width: 5px; position: static; height: 395px" align="right"
                colspan="1" rowspan="5" valign="top">
                <p align="center">
                    <asp:PlaceHolder ID="phTopBanner1" runat="server"></asp:PlaceHolder>
                </p>
            </td>
            <td style="font-size: 0pt; width: 86px; height: 184px" align="center">
                <p align="center">
                    <table id="Table9" style="width: 811px; height: 490px" cellspacing="0" cellpadding="0"
                        width="811" bgcolor="white" border="0">
                        <tr>
                            <td style="font-size: 0pt; width: 809px; height: 3px" align="center">
                            </td>
                            <td style="font-size: 0pt; height: 3px" align="right" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 0pt; width: 809px; height: 3px" align="left">
                                <table id="Table10" style="width: 808px; height: 12px" cellspacing="0" cellpadding="0"
                                    width="808" border="0">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label6" runat="server" Font-Names="Tahoma" CssClass="headForm1 " Width="113px"
                                                Height="45px" Font-Bold="True" ForeColor="Black" Font-Size="11pt">View Comments:</asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="LblTotalComments" Font-Names="Tahoma" Height="16px" ForeColor="Black"
                                                CssClass="headform3" runat="server" Width="148px" Font-Size="9pt">Total 
                                            Comments:</asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="LblCustomerName" Font-Names="Tahoma" Height="16px" ForeColor="Black"
                                                CssClass="headform3" runat="server" Width="164px" Font-Size="9pt">Policy No:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnApplyComments" TabIndex="41" runat="server" Font-Names="Tahoma"
                                                Width="121px" Height="23px" Text="Add Comments" ForeColor="White" BackColor="#400000"
                                                BorderColor="#400000" BorderWidth="0px" Font-Size="9pt" OnClick="btnApply_Comments"
                                                Style="margin-right: 1px"></asp:Button>
                                            <asp:Button ID="BtnExit" runat="server" BackColor="#400000" BorderColor="#400000"
                                                BorderWidth="0px" Font-Names="Tahoma" Font-Size="9pt" ForeColor="White" Height="23px"
                                                OnClick="BtnExit_Click" TabIndex="41" Text="Exit" Width="44px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 0pt; height: 5px; width: 809px;">
                                <table id="Table11" style="width: 808px" bordercolor="#c00000" height="1" cellspacing="0"
                                    bordercolordark="#c00000" cellpadding="0" width="808" bgcolor="#c00000" bordercolorlight="#c00000"
                                    border="0">
                                    <tr>
                                        <td background="Images2/Barra3.jpg">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 809px; height: 49px" valign="middle" align="center">
                                <table id="Table6" style="width: 217px; height: 32px" cellspacing="0" cellpadding="0"
                                    border="0">
                                    <tr>
                                        <td style="font-size: 1pt" align="center">
                                            <table id="Table3" style="width: 211px; height: 104px" cellspacing="0" cellpadding="0"
                                                border="0">
                                                <tr>
                                                    <td class="style1" align="left">
                                                        <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" CssClass="headfield1" Width="97px"
                                                            Height="18px" Font-Size="9pt">Comments:</asp:Label>
                                                        <br />
                                                        <asp:TextBox ID="TxtComments" runat="server" Height="65px" Width="367px" 
                                                            ontextchanged="TxtComments_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td class="style1">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 10pt; width: 809px; height: 3px" align="left" colspan="1">
                                <asp:Label ID="Label5" Font-Names="Tahoma" Height="18px" ForeColor="Black" CssClass="headform3"
                                    runat="server" Width="223px" Font-Size="Smaller">Total Cases:</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 0pt; width: 809px; height: 3px">
                                <table id="Table2" style="width: 808px" bordercolor="#c00000" height="1" cellspacing="0"
                                    bordercolordark="#c00000" cellpadding="0" width="808" bgcolor="#c00000" bordercolorlight="#c00000"
                                    border="0">
                                    <tr>
                                        <td background="Images2/Barra3.jpg">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 0pt; width: 809px; height: 3px" align="center">
                                <asp:Label ID="LblError" runat="server" Font-Names="Tahoma" Width="795px" ForeColor="Red"
                                    Visible="False" Font-Size="11pt" Height="21px">Label</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 0pt; width: 809px; height: 25px" align="center">
                                <p align="center">
                                    <asp:DataGrid ID="searchComments" Height="260px" runat="server" ItemStyle-CssClass="HeadForm3"
                                        HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" AlternatingItemStyle-BackColor="#FEFBF6"
                                        AlternatingItemStyle-CssClass="HeadForm3" CellPadding="0" Font-Names="Arial"
                                        Font-Size="9pt" AllowPaging="True" AutoGenerateColumns="False" BackColor="White"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center" Width="795px"
                                        BorderStyle="Solid" BorderWidth="1px" BorderColor="#400000" 
                                        onselectedindexchanged="searchComments_SelectedIndexChanged" 
                                        onitemcommand="searchComments_ItemCommand" 
                                        onitemcreated="searchComments_ItemCreated">
                                        <FooterStyle BackColor="Navy"></FooterStyle>
                                        <AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                                        <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White"
                                            CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False"
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="Del.">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDelEndorsement" runat="server"
                                                                                    CommandArgument="Delete" 
                                                                                    
                                                                                    onclientclick="return confirm('Are you certain you want to delete this comment?');" 
                                                                                    CommandName="Delete" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="CommentsID" HeaderText="Id" ></asp:BoundColumn>
                                             <asp:BoundColumn DataField="UserName" HeaderText="User" >
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Comments" HeaderText="Comments">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="EntryDate" HeaderText="Date" >
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:ButtonColumn Visible="False" HeaderImageUrl="Images/checkmark_image.gif" ButtonType="PushButton"
                                                CommandName="Select">
                                                <ItemStyle Font-Names="tahoma"></ItemStyle>
                                            </asp:ButtonColumn>
                                            <asp:BoundColumn DataField="TaskControlID" HeaderText="Task Control" 
                                                Visible="False">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                             <asp:BoundColumn DataField="UserID" HeaderText="UserID" 
                                                 Visible="False">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" BackColor="White" PageButtonCount="20"
                                            CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid></p>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 0pt; width: 809px">
                                <p>
                                </p>
                                <p align="center">
                                </p>
                            </td>
                        </tr>
                    </table>
                </p>
                <p>
                </p>
            </td>
        </tr>
    </table>
    <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>
    <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
    </form>
</body>
</html>
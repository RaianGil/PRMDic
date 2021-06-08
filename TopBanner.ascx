<%@ Control Language="c#" Inherits="EPolicy.TopBanner2" CodeFile="TopBanner.ascx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript">
        javascript: window.history.forward(1);
</script>

<style>
    DIV.aFilter
    {
        filter: gray;
        width: 100%;
    }
</style>
<table id="Table1" style="width: 858px; position: static; height: 122px" cellpadding="0"
    width="858" align="center" border="0" bgcolor="white">
    <tr>
        <td style="font-size: 0pt; height: 40px">
            <table id="Table2" style="width: 979px; height: 1px" cellspacing="0" cellpadding="0"
                width="979" border="0">
                <tr>
                    <td style="width: 284px; height: 62px">
                        <p align="left">
                            <img src="Images2/PRMEDICALNEWLOGO.jpg" style="width: 201px; height: 86px">
                        </p>
                    </td>
                    <td style="width: 284px; height: 62px">
                        <p align="left">
                           <asp:Label ID="LabelTestEnv" runat="server" Font-Names="Arial" Font-Size="14pt" ForeColor="Red"
                                        Width="218px">TEST ENVIROMENT</asp:Label>
                        </p>
                    </td>
                    <td style="width: 868px; height: 62px">
                        <asp:Image ID="Img1" runat="server" ImageUrl="Images2/epmsLogo2.gif" Visible="False">
                        </asp:Image>
                    </td>
                </tr>
                <tr>
                    <td style="width: 732px; height: 17px" background="Images2/Barra3.jpg" colspan="2"
                        valign="bottom">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 972px">
                            <tr>
                                <td align="center" style="width: 385px; height: 7px">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White"
                                        Width="218px"></asp:Label>
                                </td>
                                <td style="height: 7px">
                                </td>
                                <td style="width: 57px; height: 7px">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="width: 385px; height: 7px">
                                    <asp:Label ID="lblUserName" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White"
                                        Width="218px"></asp:Label>
                                </td>
                                <td style="height: 7px">
                                    <asp:Label ID="LblDate" Height="11px" runat="server" Width="237px" Font-Names="arial"
                                        Font-Size="9pt" ForeColor="White"></asp:Label>
                                </td>
                                <td style="width: 57px; height: 7px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

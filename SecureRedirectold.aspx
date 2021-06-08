<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecureRedirect.aspx.cs" Inherits="SecureRedirect" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ePMS | electronic Policy Manager Solution</title>
    <meta http-equiv="refresh" content="1; URL=http://40.70.214.4/Default.aspx" />
    <meta name="keywords" content="automatic redirection" />
    <link rel="icon" href="images\favicon.ico" type="image/x-icon"/>
    <link rel="shortcut icon" href="images\favicon.ico" type="image/x-icon"/>
     <link rel="stylesheet" href="Stylesheet/Style.css" type="text/css" />
     <!--[if lt IE 7]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE7.js"></script> <![endif]-->
     <!--[if lt IE 8]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE8.js"></script> <![endif]-->
     <!--[if lt IE 9]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE9.js"></script> <![endif]-->
    <style type="text/css">
        .style2
        {
            height: 432px;
        }
    </style>
</head>
<body bottommargin="0" leftmargin="0" background="Images2/SQUARE.GIF" topmargin="19"
    rightmargin="0">
    <form id="form1" runat="server">
   
    <table cellspacing="0" cellpadding="0" align="center"
        style="border: 1px solid #999999; ">
        <tr>
            <td >
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td align="right" bgcolor="White">
                                        <br />
                                        <br />
                                                                                                              <br />
                                                                                              <asp:Image id="Img1" runat="server" ImageUrl="Images2/epmsLogo2.gif"></asp:Image></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images2/Barra3.jpg"
                                            Width="1011px" Height="33px" />
                                    </td>
                                      
                                </tr>
                            </table>
                            <table cellspacing="0" cellpadding="0" border="0" bgcolor="White"
                                style="width: 1009px">
                                                            <tr>
                                    <td align="center" class="style2">
                                        &nbsp;</td>
                                    <td align="center" class="style2" colspan="1">
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Font-Names="Lucida Sans" Font-Size="18pt"
                                            ForeColor="#3333FF"
                                            Text="Please wait, connecting to a secure link..."></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Font-Names="Lucida Sans" Font-Size="12pt"
                                            ForeColor="#990000" Text="Loading..."></asp:Label>
                                        <br />
                                            <img alt="" src="Images2/loader.gif" style="width: 80px; height: 16px" /></td>
                                    <td align="center" class="style2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <img alt="" src="Images/GreyLine.png" style="width: 1000px; height: 9px" /></td>
                                </tr>
                            </table>
                            <div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" style="height: 2px">
        <tr>
            <td align="center">
               
                <br />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
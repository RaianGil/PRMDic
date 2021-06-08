<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SecureRedirect.aspx.cs" Inherits="SecureRedirect" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head id="Head1" runat="server">
        <title>ePMS | electronic Policy Manager Solution</title>
        <meta http-equiv="refresh" content="1; URL=http://40.70.214.4/Default.aspx" />
        <meta name="keywords" content="automatic redirection" />
        <link rel="icon" href="images\favicon.ico" type="image/x-icon" />
        <link rel="shortcut icon" href="images\favicon.ico" type="image/x-icon" />
        <link rel="stylesheet" href="Stylesheet/Style.css" type="text/css" />
        <!--[if lt IE 7]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE7.js"></script> <![endif]-->
        <!--[if lt IE 8]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE8.js"></script> <![endif]-->
        <!--[if lt IE 9]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE9.js"></script> <![endif]-->
        <style type="text/css">
            .style2 {
                height: 432px;
            }
        </style>
    </head>

    <body>
        <form id="form1" runat="server">
            <p>
                <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
            </p>
            <div class="container-xl f-center h-10">
                <div class="spinner-border text-primary wh-10 position-relative progress-m" role="status">
                    <div class="visually-hidden">Loading...</div>
                </div>
            </div>
        </form>
    </body>

    </html>
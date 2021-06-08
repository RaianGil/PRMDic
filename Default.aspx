<%@ Page Language="c#" Async="false" Inherits="EPolicy.Default" CodeFile="Default.aspx.cs" %>

    <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>

        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <html xmlns="http://www.w3.org/1999/xhtml">

        <head>

            <title>eMedMal</title>
            <meta http-equiv="X-UA-Compatible" content="IE=edge" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" />
            <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.12.3.min.js"></script>
            <link rel="icon" type="image/x-icon" href="images2/favicon.png" />
            <link href="css/LoginForm.css" rel="stylesheet" />
            <script type="text/javascript">
                $(document).ready(function() {
                    $("#div1").delay(0).fadeIn(1200);
                });

                $(document).ready(function() {
                    $("#div2").delay(0).fadeIn(2000);
                });

                $(document).ready(function() {
                    $("#div3").delay(0).fadeIn(3000);
                });

                javascript: window.history.forward(1);
            </script>
            <style type="text/css">
                .modalBackground {
                    background-color: Gray;
                    filter: alpha(opacity=50);
                    opacity: 0.5;
                }
                
                .btn-bg-theme2 {
                    background: #495868;
                    color: #fff;
                }
            </style>
        </head>

        <body class="text-center">
            <form id="Form1" method="post" runat="server" class="form-signin">
                <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="900">
                </Toolkit:ToolkitScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
                    <ContentTemplate>
                        <div id="div1" align="center" style="display: none;">
                            <img alt="" src="Images2/LogoPRMD.png" style="width: 220px" class="" />
                        </div>
                        <%-- <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>--%>
                            <div id="div2" align="center" style="display: none; margin-top: 40px;">
                                <h1 class="h3 mb-3 font-weight-normal" style="color: #3B3B3B;">
                                    Please sign in</h1>
                                <asp:TextBox ID="TxtUserName" type="text" TabIndex="1" runat="server" autocomplete="off" CssClass="form-control" MaxLength="15" placeholder="User Name" required="" oninput="setCustomValidity('')" oninvalid="this.setCustomValidity('Please enter your username.')"></asp:TextBox>
                                <asp:TextBox ID="TxtPassword" type="password" TabIndex="2" runat="server" autocomplete="off" CssClass="form-control" MaxLength="10" TextMode="Password" placeholder="Password" required="" oninput="setCustomValidity('')" oninvalid="this.setCustomValidity('Please enter your password.')"></asp:TextBox>
                                <asp:Button ID="BtnSalir" runat="server" BackColor="#EB4110" Text="Logout" ForeColor="White" class="btn btn-lg btn-primary btn-block" Visible="False" OnClick="BtnSalir_Click">
                                </asp:Button>
                                <div class="checkbox mb-3">
                                </div>
                                <asp:Button ID="BtnLogIn" runat="server" class="btn btn-lg btn-block btn-bg-theme2" Text="Sign in" OnClick="BtnLogIn_Click"></asp:Button>
                                <br />
                                <br />
                            </div>
                            <div class="" style="display: none;">
                                <div id="div3" align="center" style="display: none;">
                                    <%--Font de eMedMal es AudioWide--%>
                                        <img alt="" src="Images2/eMedMal.png" style="width: 200px; height: 120px" class="" />
                                </div>
                            </div>
                            <br />
                            <br />
                            <p class="mt-5 mb-3 text-muted">
                                &copy; 2021</p>


                            <asp:Panel ID="pnlMessage" runat="server" CssClass="panel" Width="450px" BackColor="White" Height="300px">
                                <div class="panel-body" style="background-color: #ba354e; color: #FFFFFF; font-family: Calibri Light;
                        font-size: 14px; font-weight: normal; height: 75px; text-align: center; vertical-align: middle;">
                                    <asp:Label ID="Label5" runat="server" Font-Size="20pt" Text="Sign in" ForeColor="White" />
                                </div>
                                <div class="" style="padding: 0px; border-radius: 0px; background-color: White;">
                                    <table style="background-position: center; width: 450px; height: 150px;">
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Label ID="lblRecHeader" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="14pt" Font-Underline="False" ForeColor="#333333" Text="Message" Width="350px" CssClass="" Style="text-align: center;" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="" align="center" style="height: 75px; background-color: White; font-family: Tahoma;
                        font-size: 20px;">
                                    <asp:Button ID="btnAceptar" runat="server" Text="OK" Width="270px" CssClass="ButtonTextMenu-12 btn" />
                                </div>
                            </asp:Panel>
                            <Toolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="pnlMessage" TargetControlID="btnDummy2" OkControlID="btnAceptar">
                            </Toolkit:ModalPopupExtender>
                            <asp:Button ID="btnDummy2" runat="server" Visible="true" BackColor="Transparent" BorderStyle="None" BorderWidth="0" BorderColor="Transparent" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </body>

        </html>
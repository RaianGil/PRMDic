<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataBaseMenu.aspx.cs" Inherits="DataBaseMenu"%>
    <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
        <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
            <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
            <script runat="server">
            </script>
            <html xmlns="http://www.w3.org/1999/xhtml">

            <head id="Head1" runat="server">
                <title>ePMS | electronic Policy Manager Solution</title>
                <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
                <meta content="C#" name="CODE_LANGUAGE" />
                <meta content="JavaScript" name="vs_defaultClientScript" />
                <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
                <link href="epolicy.css" type="text/css" rel="stylesheet" />
                <link rel="stylesheet" href="Stylesheet/Style.css" type="text/css" />
                <meta name="viewport" content="width=device-width, initial-scale=1">
                <link href="epolicy.css" type="text/css" rel="stylesheet" />
                <link rel="icon" type="image/x-icon" href="images2/favicon.png" />
                <link href="css/bootstrap.min.css" rel="stylesheet">
                <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
                <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css">
                <script src="js/bootstrap.bundle.min.js"></script>
                <script src="js/jquery-1.7.1.min.js"></script>
                <script src="js/bootstrap-datepicker.js"></script>
                <!--[if lt IE 7]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE7.js"></script> <![endif]-->
                <!--[if lt IE 8]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE8.js"></script> <![endif]-->
                <!--[if lt IE 9]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE9.js"></script> <![endif]-->
                <script type="text/javascript">
                </script>
                <style type="text/css">
                    .style6 {
                        font-family: tahoma;
                        font-size: small;
                        color: #800000;
                    }
                    
                    #Table2 {
                        width: 808px;
                        height: 281px;
                    }
                    
                    .headfield1 {
                        margin-bottom: 0px;
                        margin-left: 0px;
                    }
                    
                    .f-right {
                        text-align: -webkit-right;
                    }
                    
                    .btn-r-4 {
                        border-radius: 4px;
                        border: none;
                    }
                    
                    .btn-h-30 {
                        width: auto;
                        padding: 5px 18px;
                        height: 30px;
                        font-size: 9pt;
                    }
                    
                    .btn-bg-theme2 {
                        background: #495868;
                        color: #fff;
                    }
                    
                    .fs-16 {
                        font-size: 16pt;
                    }
                </style>
            </head>

            <body>
                <div class="mb-4"></div>
                <form id="Opp" runat="server">
                    <div class="container-xl mb4 p18">
                        <ajaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnableScriptGlobalization="True">
                        </ajaxToolKit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label8" runat="server" class="fs-16">DataBaseMenu</asp:Label>
                                    </div>
                                    <div class="col-md-6 f-right">
                                        <asp:Button ID="BtnExecute" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="BtnExecute_Click" Text="Execute" />
                                        <asp:Button ID="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="BtnExit_Click" Text="Exit" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <hr>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label ID="Label35" runat="server" Text="Query"></asp:Label>
                                    <asp:TextBox ID="txtQuery" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <asp:Label ID="Label37" runat="server" Text="Result(s)"></asp:Label>

                                    <asp:ListBox ID="ListBox1" runat="server" class="form-select"></asp:ListBox>

                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="10">
                                        <progresstemplate>
                                            <span class="style6">
                    <img alt="" src="Images2/loader.gif" style="width: 80px; height: 16px" />
                    <br />
                    Please wait... </span>

                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                </div>
                                <div class="col-md-12">
                                    <hr>
                                </div>
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>

                                <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                                <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" RUNAT="server"></MaskedInput:MaskedTextHeader>
                                <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1" style="z-index: 102; left: 783px; width: 35px; position: absolute; top: 895px;
            height: 22px" type="hidden" value="false" />

                                <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" Width="400px" BackColor="#F4F4F4" Style="display: none;">
                                    <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
                        font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
                        background-repeat: no-repeat; text-align: left; vertical-align: bottom;">

                                        <asp:Label ID="Label34" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans" Font-Size="14pt" Text="Message..." ForeColor="#000066" />
                                    </div>
                                    <div class="CajaDialogoDiv" style="color: #FFFFFF">

                                        <asp:TextBox ID="lblRecHeader" runat="server" Font-Underline="False" Text="Message" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                    <div class="CajaDialogoDiv" align="center">
                                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                                    </div>
                                </asp:Panel>
                                <ajaxToolKit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground" CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript="" OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                                </ajaxToolKit:ModalPopupExtender>
                                <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" BorderWidth="0" Visible="true" />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </form>
            </body>

            </html>
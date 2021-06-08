<%@ Page language="c#" Inherits="EPolicy.FollowUp" CodeFile="FollowUp.aspx.cs" %>
    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
    <HTML>

    <HEAD>
        <title>ePMS | electronic Policy Manager Solution</title>
        <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
        <meta content="C#" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="baldrich.css" type="text/css" rel="stylesheet">
        <link href="epolicy1.css" type="text/css" rel="stylesheet" />
        <link rel="icon" type="image/x-icon" href="images2/favicon.png" />
        <link href="css/bootstrap.min.css" rel="stylesheet">
        <link href="css/datepicker.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css">
        <script src="js/bootstrap.bundle.min.js"></script>
        <script src="js/jquery-1.7.1.min.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>
        <script>
        </script>

        <style>
            .f-right {
                text-align: right;
            }
            
            .f-center {
                text-align: center;
            }
            
            .bs-1 {
                border: solid 1px black;
            }
            
            .hs-20 {
                height: 20rem;
            }
            
            .btn-r-4 {
                border-radius: 4px;
                border: none;
            }
            
            .btn-bg-theme2 {
                background: #495868;
                color: #fff;
            }
            
            .btn-bg-theme2:hover {
                background: #c0c9d3;
                color: #fff;
            }
            
            .btn-h-30 {
                width: auto;
                padding: 5px 18px;
                height: 30px;
                font-size: 9pt;
            }
        </style>
    </HEAD>

    <body>
        <form id="Form1" method="post" runat="server">
            <div class="mb-4"></div>
            <div class="container-xl mb-4 p-18">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="f-right">
                                <asp:button id="btnEnviar" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Enviar" onclick="btnEnviar_Click" />
                                <asp:button id="btnSalir" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Salir" onclick="btnSalir_Click" />
                            </div>
                        </div>
                        <div class="col-md-12 w-100">
                            <hr />
                        </div>
                        <div class="col-md-12">
                            <div class="input-group">
                                <asp:label id="LblTo" RUNAT="server" ENABLEVIEWSTATE="False" class="input-group-text">To</asp:label>
                                <asp:textbox id="TxtMailTo" runat="server" class="form-control" />
                            </div>

                            <div class="input-group">
                                <asp:label id="Label1" RUNAT="server" ENABLEVIEWSTATE="False" class="input-group-text">From:</asp:label>
                                <asp:textbox id="TxtMailFrom" runat="server" class="form-control">system@prmdic.net</asp:textbox>
                            </div>

                            <div class="input-group">
                                <asp:label id="Label2" RUNAT="server" ENABLEVIEWSTATE="False" class="input-group-text">Subject:</asp:label>
                                <asp:textbox id="TxtMailSubject" runat="server" class="form-control" />
                            </div>

                            <div class="input-group mb-2">
                                <asp:label id="LblAttachment" RUNAT="server" class="input-group-text">Attachments:</asp:label>
                                <asp:textbox id="TxtAttachment" runat="server" class="form-control" />
                            </div>

                            <asp:textbox id="TxtBody" runat="server" TextMode="MultiLine" class="form-control mb-3 hs-20" /></asp:textbox>
                            <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>

                            <asp:TextBox id="TextBox18" runat="server" class="form-control" Visible="False" />
                            <asp:listbox id="FileList" runat="server" Visible="False"></asp:listbox>
                        </div>

                    </div>
                </div>
            </div>
        </form>
    </body>

    </HTML>
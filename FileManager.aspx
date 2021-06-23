<%@ Page language="c#" Inherits="EPolicy.FileManager" CodeFile="FileManager.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <head runat="server">
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0" />
            <meta name="CODE_LANGUAGE" Content="C#" />
            <meta name="vs_defaultClientScript" content="JavaScript" />
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
            <link href="epolicy.css" type="text/css" rel="stylesheet" />
        </head>
        </script>

        <body>
            <form method="post" runat="server">
                <div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block" UpdateMode="Conditional">

                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtBackUp" EventName="Click" />
                        </Triggers>
                        <ContentTemplate>
                            <p>
                                <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                            </p>
                            <div class="container-xl">
                                <div class="row">
                                    <div class="col-md-4 fs-14 fw-bold">
                                        <asp:Label id="LblFileManager" runat="server">File Manager</asp:Label>
                                    </div>
                                    <div class="col-md-8 f-right">
                                        <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                                    </div>
                                    <div class="col-md-12 f-center">
                                        <hr>
                                        <div class="col-md-12 mb-1 fs-14 fw-bold">
                                            <asp:Label id="Label1" runat="server">Back Up Files from the Server</asp:Label>
                                        </div>
                                        <div class="col-md-12 mb-4">
                                            <asp:Button id="BtBackUp" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Transfer Files" onclick="BtBackUp_Click" onclientclick="return confirm('Are you certain you want to start the process?');"></asp:Button>
                                        </div>
                                        <div class="col-md-8 mb-1">
                                            <asp:Label id="Label2" runat="server">* Upon pressing the button all of the files will be moved to a back up folder and the working folder will be deleted. Please make sure that all other processes are stoped before starting the task.</asp:Label>
                                        </div>
                                        <hr>
                                    </div>
                                    <asp:Label id="LblTotalCases" runat="server" cssclass="fw-bold" Visible="false">Total Files: </asp:Label>

                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                                        <progresstemplate>
                                            <img alt="" src="Images2/loader.gif" style="width: 80px; height: 16px" />
                                            <br /> Please wait...
                                            <br />

                                        </progresstemplate>
                                    </asp:UpdateProgress>

                                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                                    <asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
                                    <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </form>
        </body>

        </HTML>
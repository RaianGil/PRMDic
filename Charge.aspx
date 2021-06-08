<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.Agent" CodeFile="Charge.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
            <style type="text/css">
                .style1 {
                    width: 468px;
                }
                
                .style2 {
                    height: 1px;
                    width: 89px;
                }
                
                .style3 {
                    height: 10px;
                    width: 89px;
                }
                
                .style4 {
                    height: 5px;
                    width: 89px;
                }
            </style>
        </HEAD>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js">
        </script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

        <body>
            <form id="Form1" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label21" class="fs-16" runat="server">Charge Definitions for: </asp:Label>
                            <asp:Label id="lblChargeDate" class="fs-16" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnSearch" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Search" onclick="btnSearch_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
                            <asp:Button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md f-center">
                        <div class="col-md-5">
                            <asp:label id="lblCity" RUNAT="server">Effective Date:</asp:label>

                            <asp:textbox id="txtEffectiveDate" RUNAT="server" class="form-control" MAXLENGTH="10"></asp:textbox>

                            <asp:label id="lblState" RUNAT="server">Charge Percent: </asp:label>

                            <maskedinput:maskedtextbox id="txtChargePercent" RUNAT="server" class="form-control" ISDATE="False" MASK="0.999999" MAXLENGTH="10"></maskedinput:maskedtextbox>

                            <asp:label id="lblState0" RUNAT="server">Policy Type: </asp:label>

                            <asp:DropDownList ID="ddlPolicyType" runat="server" class="form-select">
                                <asp:ListItem Value="1">PP</asp:ListItem>
                                <asp:ListItem Value="2">PE</asp:ListItem>
                                <asp:ListItem Value="3">CP</asp:ListItem>
                                <asp:ListItem Value="4">CE</asp:ListItem>
                            </asp:DropDownList>

                            <asp:label id="lblState1" RUNAT="server">Renewals Only? </asp:label>

                            <asp:CheckBox ID="chkRenewals" runat="server" class="d-block" Text="Yes" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>

                    <div class="col-md-12">
                        <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                        <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                        <asp:imagebutton id="btnAddNew1" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="btnEdit1" runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="BtnSave1" RUNAT="server" Visible="False" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif"></asp:imagebutton>
                        <asp:imagebutton id="btnSearch1" runat="server" Visible="False" ImageUrl="Images/search_btn.gif" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="cmdCancel1" runat="server" Visible="False" ImageUrl="Images/cancel_btn.gif" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="btnPrint1" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
                        <asp:ImageButton id="btnAuditTrail1" runat="server" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
                        <asp:imagebutton id="BtnExit1" RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
                    </div>
                </div>
            </form>
        </body>

        </HTML>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Corporation.aspx.cs" Inherits="EPolicy.Corporation" %>
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
                .headForm1 {
                    margin-right: 10px;
                }
                
                #Form1 {
                    height: 746px;
                }
            </style>
        </HEAD>

        <body>
            <form id="Form1" method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label21" class="fs-16" runat="server">Corporation:</asp:Label>
                            <asp:Label id="lblCorporationID" class="fs-16" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
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
                    <div class="f-center">
                        <div class="col-md-6">
                            <div class="col-md-12">
                                <asp:label id="lblB" RUNAT="server">Corporation Description</asp:label>
                                <asp:textbox id="txtCorporationDescription" RUNAT="server" class="form-control mb-1" MAXLENGTH="100"></asp:textbox>
                            </div>
                            <div class="col-md-12">

                                <asp:label id="lblPolicyType" RUNAT="server">Policy Type</asp:label>
                                <asp:textbox id="txtPolicyType" RUNAT="server" class="form-control mb-1" MAXLENGTH="100"></asp:textbox>
                            </div>
                            <div class="col-md-12">
                                <asp:label id="lblCity" RUNAT="server">Primary Discount</asp:label>
                                <maskedinput:maskedtextbox id="txtPrimaryDiscount" RUNAT="server" class="form-control mb-1" ISDATE="False" MASK="99" MAXLENGTH="10"></maskedinput:maskedtextbox>
                            </div>
                            <div class="col-md-12">
                                <asp:label id="lblState" RUNAT="server">Excess Discount</asp:label>
                                <maskedinput:maskedtextbox id="txtExcessDiscount" RUNAT="server" class="form-control mb-1" ISDATE="False" MASK="99" MAXLENGTH="10"></maskedinput:maskedtextbox>
                            </div>
                            <div class="col-md-12">
                                <asp:label id="lblIsGroup" RUNAT="server">Is Group?</asp:label>
                                <asp:CheckBox ID="chkIsGroup" runat="server" class="mb-1 d-block" Text="Yes" />
                            </div>
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
                        <asp:ImageButton id="btnAuditTrail1" runat="server" Width="48px" Height="19px" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
                        <asp:imagebutton id="BtnExit1" RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
                    </div>
                </div>
            </form>
        </body>

        </HTML>
<%@ Page language="c#" Inherits="EPolicy.Bank" CodeFile="Bank.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl">
                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:Label id="Label2" runat="server" class="fs-14 fw-bold">Bank ID:</asp:Label>
                            <asp:label id="lblBankID" runat="server" class="fs-14 fw-bold"></asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:button>
                            <asp:button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Print" onclick="btnPrint_Click"></asp:button>
                            <asp:button id="btnSearch" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Search" onclick="btnSearch_Click"></asp:button>
                            <asp:button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Add" onclick="btnAddNew_Click"></asp:button>
                            <asp:button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Edit" onclick="btnEdit_Click"></asp:button>
                            <asp:button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Save" onclick="BtnSave_Click"></asp:button>
                            <asp:button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Cancel" onclick="cmdCancel_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="BtnExit_Click"></asp:button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblB" RUNAT="server" class="fs-lbl-s">Bank Description</asp:label>
                        </div>
                        <div class="col-md-8">
                            <asp:textbox id="txtBankDescription" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblAddress1" RUNAT="server" class="fs-lbl-s"> Address 1</asp:label>
                        </div>
                        <div class="col-md-8">
                            <asp:textbox id="txtAddress1" RUNAT="server" MAXLENGTH="20" class="form-control fs-txt-s mb-1"></asp:textbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblAddress2" RUNAT="server" class="fs-lbl-s"> Address 2</asp:label>
                        </div>
                        <div class="col-md-8">
                            <asp:textbox id="txtAddress2" RUNAT="server" MAXLENGTH="20" class="form-control fs-txt-s mb-1"></asp:textbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblCity" RUNAT="server" class="fs-lbl-s">City</asp:label>
                        </div>
                        <div class="col-md-8">
                            <div class="input-group">
                                <asp:textbox id="txtCity" RUNAT="server" MAXLENGTH="10" class="form-control fs-txt-s mb-1 me-2"></asp:textbox>
                                <asp:CheckBox ID="chkNetCollection" runat="server" class="fs-lbl-s" Text="Is Net Collection Method" />
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblState" RUNAT="server" class="fs-lbl-s">State</asp:label>
                        </div>
                        <div class="col-md-8">
                            <asp:textbox id="txtSt" RUNAT="server" MAXLENGTH="2" class="form-control fs-txt-s mb-1"></asp:textbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblZipCode" RUNAT="server" class="fs-lbl-s">Zip Code</asp:label>
                        </div>
                        <div class="col-md-8">
                            <maskedinput:maskedtextbox id="txtZipCode" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="10" ISDATE="False" MASK="99999Z9999"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblPhone" RUNAT="server" class="fs-lbl-s">Phone </asp:label>
                        </div>
                        <div class="col-md-8">
                            <maskedinput:maskedtextbox id="txtPhone" runat="server" class="form-control fs-txt-s mb-1" Mask="(999) 999-9999" Columns="34"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="lblEntryDate" RUNAT="server" class="fs-lbl-s">Entry Date</asp:label>
                        </div>
                        <div class="col-md-8">
                            <maskedinput:maskedtextbox id="txtEntryDate" RUNAT="server" class="form-control fs-txt-s mb-1" ISDATE="True"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:label id="Label1" Width="97px" RUNAT="server" Visible="False" class="fs-lbl-s">Universal Code:</asp:label>
                        </div>
                        <div class="col-md-8">
                            <asp:textbox id="txtUniversal" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="3" Visible="False"></asp:textbox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label3" runat="server" class="fs-lbl-s">VSC Bank Fee:</asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtVSCBankFee" runat="server" class="form-control fs-txt-s mb-1" MaxLength="3"></asp:TextBox>
                        </div>
                    </div>

























                    <asp:checkbox id="chkLease" runat="server" AutoPostBack="True"></asp:checkbox>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                    <asp:imagebutton id="btnAddNew1" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
                    <asp:imagebutton id="btnEdit1" runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
                    <asp:imagebutton id="BtnSave1" RUNAT="server" Visible="False" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif"></asp:imagebutton>
                    <asp:imagebutton id="btnSearch1" runat="server" Visible="False" ImageUrl="Images/search_btn.gif" CausesValidation="False"></asp:imagebutton>
                    <asp:imagebutton id="cmdCancel1" runat="server" Visible="False" ImageUrl="Images/cancel_btn.gif" CausesValidation="False"></asp:imagebutton>
                    <asp:imagebutton id="btnPrint1" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
                    <asp:ImageButton id="btnAuditTrail1" runat="server" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
                    <asp:imagebutton id="BtnExit1" RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
                    <asp:button id="BtnEnd" runat="server" Text=">>" Visible="False" onclick="BtnEnd_Click"></asp:button>
                    <asp:button id="BtnNext" runat="server" Text=">" Visible="False" onclick="BtnNext_Click"></asp:button>
                    <asp:button id="BtnPrevious" runat="server" Text="<" Visible="False" onclick="BtnPrevious_Click"></asp:button>
                    <asp:button id="BtnBegin" runat="server" Text="<<" Visible="False" onclick="BtnBegin_Click"></asp:button>
                    <asp:Label id="lblRecordCount" runat="server" Visible="False">Label</asp:Label>
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                </div>
            </form>
        </body>

        </HTML>
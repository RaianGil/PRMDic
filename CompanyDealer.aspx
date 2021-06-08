<%@ Page language="c#" Inherits="EPolicy.CompanyDealer" CodeFile="CompanyDealer.aspx.cs" %>
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
            <style>
                .dd-none {
                    display: none;
                }
            </style>
        </HEAD>
        <bod>
            <form method="post" runat="server">
                <div class="dd-none">
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </div>
                <div class="mb-4"></div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label id="Label1" runat="server" class="fs-18">Company Dealer ID:</asp:Label>
                        <asp:label id="lblCompanyDealerID" runat="server"></asp:label>
                    </div>
                    <div class="col-md-6 f-right">
                        <asp:Button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
                        <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                        <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                        <asp:Button id="btnSearch" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Search" onclick="btnSearch_Click"></asp:Button>
                        <asp:Button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                        <asp:Button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print" onclick="btnPrint_Click"></asp:Button>
                        <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
                        <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr>
                </div>
                <div class="f-center mb-4">
                    <div class="col-md-5">
                        <asp:Label ID="Label8" runat="server">Dealer Code:</asp:Label>
                        <asp:textbox id="txtDealerCode" RUNAT="server" class="form-control" MAXLENGTH="30"></asp:textbox>

                        <asp:label id="lblB" RUNAT="server">Dealer Name:</asp:label>
                        <asp:TextBox ID="txtCompanyDealerDescription" runat="server" class="form-control" MaxLength="30"></asp:TextBox>

                        <asp:label id="lblCode" RUNAT="server">Universal Code:</asp:label>
                        <asp:textbox id="txtCode" RUNAT="server" class="form-control" MAXLENGTH="3"></asp:textbox>


                        <asp:label id="lblCoresu" RUNAT="server">Dealer Coresu:</asp:label>
                        <asp:textbox id="txtCoresu" RUNAT="server" class="form-control" MAXLENGTH="3"></asp:textbox>

                        <asp:label id="lblName" RUNAT="server">Dealer Resume Name:</asp:label>
                        <asp:textbox id="txtName" RUNAT="server" class="form-control" MAXLENGTH="30"></asp:textbox>

                        <asp:label id="lbladd1" RUNAT="server">Address 1</asp:label>
                        <asp:textbox id="txtAddress1" RUNAT="server" class="form-control" MAXLENGTH="20"></asp:textbox>

                        <asp:label id="lblAdd2" RUNAT="server">Address 2</asp:label>
                        <asp:textbox id="txtAddress2" RUNAT="server" class="form-control" MAXLENGTH="20"></asp:textbox>
                    </div>
                </div>
                <div class="f-center">
                    <div class="row col-md-10">
                        <div class="col-md-4">
                            <asp:label id="lblState" RUNAT="server">State</asp:label>
                            <asp:textbox id="txtSt" RUNAT="server" class="form-control" MAXLENGTH="2"></asp:textbox>
                            <asp:label id="lblCity" RUNAT="server">City</asp:label>
                            <asp:textbox id="txtCity" RUNAT="server" class="form-control" MAXLENGTH="14"></asp:textbox>
                            <asp:label id="lblZipCode" RUNAT="server">Zip Code</asp:label>
                            <maskedinput:maskedtextbox id="txtZipCode" class="form-control" RUNAT="server" MASK="99999Z9999" ISDATE="False" MAXLENGTH="10"></maskedinput:maskedtextbox>
                            <asp:label id="lblEntryDate" RUNAT="server">Entry Date</asp:label>
                            <maskedinput:maskedtextbox id="txtEntryDate" class="form-control" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                            <asp:Label ID="Label2" runat="server">VSC Client ID:</asp:Label>
                            <asp:TextBox ID="TXTVSCClientID" runat="server" class="form-control" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="Label4" runat="server">Profit Premier:</asp:Label>
                            <asp:TextBox ID="TxtProfit" runat="server" class="form-control"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server">Concurso:</asp:Label>
                            <asp:TextBox ID="TxtConcurso" runat="server" class="form-control"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server">ProfitDealer</asp:Label>
                            <asp:TextBox ID="TxtProfitDealer" runat="server" class="form-control"></asp:TextBox>
                            <asp:Label ID="Label6" runat="server">Master Gap:</asp:Label>
                            <asp:TextBox ID="TxtMasterGap" runat="server" MaxLength="10" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:label id="lblmbi" RUNAT="server" Visible="False">Mgrp mbi</asp:label>
                            <asp:textbox id="txtmbi" RUNAT="server" class="form-control" MAXLENGTH="2" Visible="False"></asp:textbox>
                            <asp:label id="lblAuto" RUNAT="server" Visible="False">Mgrp Auto</asp:label>
                            <asp:textbox id="txtAuto" RUNAT="server" class="form-control" MAXLENGTH="2" Visible="False"></asp:textbox>
                            <asp:checkbox id="chkTriangle" runat="server" class="d-block" AutoPostBack="True" Text="Triangle Dealers" Visible="False"></asp:checkbox>
                            <asp:checkbox id="chkEas" runat="server" class="d-block" Text="Special VSC Rate"></asp:checkbox>
                            <asp:checkbox id="chkBaldrich" runat="server" class="d-block" Text="Is Cabrera Group"></asp:checkbox>
                            <asp:checkbox id="ChkCars" runat="server" class="d-block" AutoPostBack="True" Text="Cars Plan" Visible="False"></asp:checkbox>
                            <asp:checkbox id="ChkRfloor" runat="server" class="d-block" Text="Reliable Floor Plan" AutoPostBack="True" Visible="False"></asp:checkbox>

                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <hr>
                </div>
                <div class="col-md-12">
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>

                    <asp:label id="Label3" RUNAT="server" ForeColor="OrangeRed">*</asp:label>

                    <asp:imagebutton id="btnAddNew1" runat="server" CausesValidation="False" ImageUrl="Images/addNew_btn.gif" ToolTip="Add New" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="btnEdit1" runat="server" CausesValidation="False" ImageUrl="Images/edit_btn.GIF" ToolTip="Edit" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="BtnSave1" RUNAT="server" IMAGEURL="Images/save_btn.gif" TOOLTIP="Save Person Information" CAUSESVALIDATION="False" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="btnSearch1" runat="server" CausesValidation="False" ImageUrl="Images/search_btn.gif" ToolTip="Search" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="cmdCancel1" runat="server" CausesValidation="False" ImageUrl="Images/cancel_btn.gif" ToolTip="Cancel" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="btnPrint1" runat="server" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report" ToolTip="Print Report" Visible="False"></asp:imagebutton>
                    <asp:ImageButton id="btnAuditTrail1" runat="server" ImageUrl="Images/History_btn.bmp" Visible="False"></asp:ImageButton>
                    <asp:imagebutton id="BtnExit1" RUNAT="server" IMAGEURL="Images/exit_btn.gif" CAUSESVALIDATION="False" ToolTip="Exit" Visible="False"></asp:imagebutton>
                    <asp:button id="BtnEnd" runat="server" Text=">>" Visible="False" onclick="BtnEnd_Click"></asp:button>
                    <asp:button id="BtnNext" runat="server" Text=">" Visible="False" onclick="BtnNext_Click"></asp:button>
                    <asp:label id="lblRecordCount" RUNAT="server" Visible="False">1 of 1</asp:label>
                    <asp:button id="BtnPrevious" runat="server" Text="<" Visible="False" onclick="BtnPrevious_Click"></asp:button>
                    <asp:button id="BtnBegin" runat="server" Text="<<" Visible="False" onclick="BtnBegin_Click"></asp:button>
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>


                    <asp:Label ID="lblUserName" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="White" Width="218px"></asp:Label>


                    <asp:Label ID="LblDate" runat="server" Font-Names="arial" Font-Size="9pt" ForeColor="White" Height="11px" Width="237px"></asp:Label>
                </div>
            </form>
            </body>

        </HTML>
<%@ Page language="c#" Inherits="EPolicy.ClientBusiness" CodeFile="ClientBusiness.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form id="ClientIndividual" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl">
                    <div class="row mb-2">
                        <div class="col-md-6">
                            <asp:Label id="Label17" runat="server" class="fs-14 fw-bold">Business Client:</asp:Label>
                            <asp:label id="lblCustNumber" RUNAT="server" class="fs-14 fw-bold"></asp:label>
                            <asp:label id="LblProspectID" RUNAT="server" class="fs-14 fw-bold"></asp:label>
                        </div>
                        <div class="col-md-6">
                            <asp:Button id="btnNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Add" onclick="btnNew_Click"></asp:Button>
                            <asp:Button id="BtnViewTask" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Events" onclick="BtnViewTask_Click"></asp:Button>
                            <asp:Button id="btnProfile" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Profile" onclick="btnProfile_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="btnCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Cancel" onclick="btnCancel_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="History" onclick="btnAuditTrail_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="Button1_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">

                                </div>
                                <div class="col-md-8">
                                    <asp:checkbox id="ChkNoticeOfCancellation" RUNAT="server" class="fs-lbl-s mb-1" TEXT="Notice of Cancellation" AUTOPOSTBACK="True"></asp:checkbox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblRequiredFirstName" RUNAT="server" class="fs-lbl-s">*</asp:label>
                                    <asp:label id="Label1" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Business Name</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtBusinessName" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="100"></asp:textbox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">

                                </div>
                                <div class="col-md-8">
                                    <div class="input-group mb-1">
                                        <asp:textbox id="TxtBusinessName1" RUNAT="server" class="form-control fs-txt-s" MAXLENGTH="15"></asp:textbox>
                                        <asp:textbox id="TxtBusinessName2" RUNAT="server" class="form-control fs-txt-s" MAXLENGTH="15"></asp:textbox>
                                        <asp:textbox id="TxtBusinessName3" RUNAT="server" class="form-control fs-txt-s" MAXLENGTH="15"></asp:textbox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label7" RUNAT="server" class="fs-lbl-s" Visible="False">Master Client</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlMasterCustomer" RUNAT="server" class="form-control fs-txt-s mb-1" Visible="False"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label8" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Description</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtDescription" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="100"></asp:textbox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblSocialSecurity" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Employer Soc. Sec.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtSocialSecurity" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="11" ISDATE="False" MASK="999-99-9999"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblRequiredHomePhone" RUNAT="server" class="fs-lbl-s">*</asp:label>
                                    <asp:label id="Label6" RUNAT="server" class="fs-lbl-s">Originated At</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlOriginatedAt" RUNAT="server" class="form-select fs-txt-s mb-1"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-4">
                                    <asp:label id="Label4" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Business Type</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlBusinessType" RUNAT="server" class="form-select fs-txt-s mb-1">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label2" RUNAT="server" class="fs-lbl-s" Visible="False">Related To</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlRelatedTo" RUNAT="server" class="form-select fs-txt-s mb-1" Visible="False">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:label id="lblComments" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Comments</asp:label>
                        </div>
                        <div class="col-md-10">
                            <asp:textbox id="txtComments" RUNAT="server" class="form-control fs-txt-s mb-1 h-6" MAXLENGTH="200"></asp:textbox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <asp:label id="lblTypeAddress1" RUNAT="server" class="fs-14 fw-bold">Postal Address</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:label id="LblTypeAddress2" RUNAT="server" class="fs-14 fw-bold">Physical Address</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:label id="Label9" RUNAT="server" class="fs-14 fw-bold">Contact Information</asp:label>
                        </div>
                    </div>
                    <div class="row mb-1">
                        <div class="col-md-4">
                            <p class="fs-lbl-s">
                                <asp:label id="Label15" RUNAT="server">**Address2(PoBox,Street,HC,Ave.,BLVD.,Camino,RR,Parque)</asp:label>
                                <asp:label id="Label14" RUNAT="server">*Address1 (Urb.,Cond.Bo.,Res.,Secc.Coop.,QBDA,Parcelas,Sector)</asp:label>
                            </p>
                        </div>
                        <div class="col-md-4">
                            <asp:checkbox id="chkSameAddr" RUNAT="server" class="fs-lbl-s" AUTOPOSTBACK="True" TEXT="Same as postal" oncheckedchanged="chkSameAddr_CheckedChanged"></asp:checkbox>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblOccupation" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">First Name</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtFirstName" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblAddress1" RUNAT="server" class="fs-lbl-s">*Address1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtHomeUrb1" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtAddress1Phys" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="30"></asp:textbox>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label5" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Last Name 1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtLastName1" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50" DESIGNTIMEDRAGDROP="230"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblAddress2" RUNAT="server" class="fs-lbl-s">**Address2</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtAddress1" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="30"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtAddress2Phys" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="30"></asp:textbox>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label11" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Last Name 2</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtLastName2" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblCity" RUNAT="server" class="fs-lbl-s">City</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtCity" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="14"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtCityPhys" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="14"></asp:textbox>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblJobName" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Position</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtPosition" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblState" RUNAT="server" class="fs-lbl-s">State</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtState" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="2">PR</asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtStatePhys" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="2"></asp:textbox>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblHomePhone" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Cellular</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtCellular" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblZipCode" RUNAT="server" class="fs-lbl-s">Zip Code</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtZipCode" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="10" MASK="99999Z9999" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <maskedinput:maskedtextbox id="txtZipCodePhys" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="10" MASK="99999Z9999" ISDATE="False"></maskedinput:maskedtextbox>
                        </div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblWorkPhone" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Work Phone</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="TxtWorkPhone" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblEmail" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">E-mail</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtEmail" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="100"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
































                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:textbox id="txtAddress2" RUNAT="server" Visible="False"></asp:textbox>
                    <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
                    <asp:checkbox id="ChkOptOut" RUNAT="server" TEXT="Opt-Out" AUTOPOSTBACK="True" Visible="False"></asp:checkbox>
                </div>
            </form>
        </body>

        </HTML>
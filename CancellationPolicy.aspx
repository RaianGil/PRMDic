<%@ Page language="c#" Inherits="EPolicy.CancellationPolicy" CodeFile="CancellationPolicy.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script type="text/javascript">
                function addCharges() {
                    a = parseFloat(document.CancPol.TxtReturnCharge.value);
                    if (!a)
                        a = 0;
                    b = parseFloat(document.CancPol.TxtReturnPremium.value);
                    if (!b)
                        b = 0;
                    //alert(a + ":" + b);
                    //alert(IsNaN(a) + ":" + IsNaN(b));
                    //if (a && b)
                    document.CancPol.TxtTotalReturnPremium.value = a + b;
                }
                $(function() {
                    $('#<%= txtCancellationDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });

                    $('#<%= txtRSCDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $('#<%= TxtCancellationEntryDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                });

                function ShowDateTimePicker() {
                    $('#<%= txtCancellationDate.ClientID %>').datepicker('show');
                }

                function ShowDateTimePicker2() {
                    $('#<%= txtRSCDate.ClientID %>').datepicker('show');
                }

                function ShowDateTimePicker3() {
                    $('#<%= TxtCancellationEntryDate.ClientID %>').datepicker('show');
                }
            </script>
            <style type="text/css">
                .headfield1 {}
                
                .style1 {
                    text-align: left;
                    height: 20px;
                    width: 150px;
                }
                
                .style4 {
                    text-align: left;
                    width: 150px;
                }
                
                .style5 {
                    width: 35px;
                    height: 25px;
                }
                
                .style7 {
                    height: 8px;
                }
                
                .style9 {
                    width: 35px;
                    height: 26px;
                }
                
                .style10 {
                    height: 21px;
                }
            </style>
        </HEAD>

        <body>
            <form id="CancPol" name="CanPol" method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                    <div class="row">
                        <div class="col-md-4" style="align-self: center;">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:label id="Label8" runat="server" CssClass="fs-14 fw-bold"> Cancellation Policy:</asp:label>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-8" style="text-align:right;">
                            <asp:button id="BtnCalculate" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Calculate" onclick="BtnCalculate_Click"></asp:button>
                            <asp:button id="btnPrint" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Print" onclick="btnPrint_Click" Visible="False"></asp:button>
                            <asp:button id="btnEdit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:button>
                            <asp:button id="BtnSave" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Save" onclick="BtnSave_Click" onclientclick="return confirm('Are you certain you want to apply this Cancellation?');"></asp:button>
                            <asp:button id="btnCancel" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Cancel" onclick="btnCancel_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:button>
                        </div>
                        <div class="col-md-12">
                            <hr />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label26" RUNAT="server" ENABLEVIEWSTATE="False" Font-Names="Tahoma" HEIGHT="19px" CSSCLASS="col-md-4 col-form-labe fs-lbl-s" Font-Size="9pt">Cancellation Date</asp:label>
                                        <div class="col-md-8">
                                            <asp:TextBox id="txtCancellationDate" onclick="ShowDateTimePicker();" CSSCLASS="form-control fs-txt-s fs-txt-s fechaFormat" RUNAT="server" ISDATE="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label1" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s">Cancellation Reason</asp:label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="ddlCancellationReason" RUNAT="server" AutoPostBack="True" CssClass="form-select fs-txt-s" onselectedindexchanged="ddlCancellationReason_SelectedIndexChanged"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label27" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s">Date</asp:label>
                                        <div class="col-md-8">
                                            <maskedinput:maskedtextbox id="txtRSCDate" onclick="ShowDateTimePicker2();" CSSCLASS="form-control fs-txt-s fechaFormat" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label2" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s">Cancellation Method</asp:label>
                                        <div class="col-md-8">
                                            <asp:dropdownlist id="ddlCancellationMethod" RUNAT="server" AutoPostBack="True" CSSCLASS="form-select fs-txt-s" onselectedindexchanged="ddlCancellationMethod_SelectedIndexChanged"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label28" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s">Comment</asp:label>
                                        <div class="col-md-8">
                                            <asp:textbox id="txtMOCDesc" RUNAT="server" MAXLENGTH="50" CssClass="form-control fs-txt-s" ontextchanged="txtMOCDesc_TextChanged"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label7" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s">Cancellation Entry Date</asp:label>
                                        <div class="col-md-8">
                                            <maskedinput:maskedtextbox id="TxtCancellationEntryDate" onclick="ShowDateTimePicker3();" CSSCLASS="form-control fs-txt-s fechaFormat" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="col-md-12">
                            <asp:label id="Label15" runat="server" CssClass="fs-11 fw-bold">Return Premium</asp:label>
                            <hr />
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label3" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s">Unearned Percent</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="TxtUnearnedPercent" RUNAT="server" MAXLENGTH="15" CssClass="form-control fs-txt-s"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label4" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s">Return Premium</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="TxtReturnPremium" RUNAT="server" MAXLENGTH="15" CSSCLASS="form-control fs-txt-s"></asp:textbox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label5" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s">Return Charge</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="TxtReturnCharge" RUNAT="server" MAXLENGTH="15" CssClass="form-control fs-txt-s"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label6" RUNAT="server" ENABLEVIEWSTATE="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s">Total Return Premium</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="TxtTotalReturnPremium" RUNAT="server" MAXLENGTH="15" EnableViewState="False" ReadOnly="True" CSSCLASS="form-control fs-txt-s"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <asp:label id="Label29" RUNAT="server" CssClass="fs-11 fw-bold">Comments</asp:label>
                            <hr />
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control fs-txt-s" Width="100%" Height="157px" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <INPUT id="ConfirmDialogBoxPopUp" style="Z-INDEX: 118; LEFT: 440px; WIDTH: 35px; POSITION: absolute; TOP: 14px; HEIGHT: 22px" type="hidden" size="1" value="false" name="ConfirmDialogBoxPopUp" runat="server">
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                </div>
            </form>
        </body>

        </HTML>
<%@ Page language="c#" Inherits="EPolicy.Payments" CodeFile="Payments.aspx.cs" %>
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
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script src="js/load.js" type="text/javascript"></script>
            <style type="text/css">

            </style>
        </HEAD>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $(function() {
                $('#<%= TxtEntryDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $('#<%= TxtCloseDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $('#<%= TxtPaymentDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $('#<%= txtDepositDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });
        </script>

        <body>
            <form id="Paym" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label21" runat="server">Payment Center:</asp:Label>
                            <asp:label id="lblTaskControlID" RUNAT="server"></asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="History" onclick="Button3_Click" Visible="False"></asp:Button>
                            <asp:Button id="btnDelete" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Delete" onclick="BtnDele_Click" Visible="False"></asp:Button>
                            <asp:Button id="btnReceipt" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Receipt" onclick="btnReceipt_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="Button6_Click"></asp:Button>
                            <asp:Button id="btnCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="Button5_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="Button4_Click"></asp:Button>
                            <asp:Button id="btnBack" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Back" onclick="Button5_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="Button2_Click"></asp:Button>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row mb-2">
                        <div class="col-md-4">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label2" RUNAT="server" ENABLEVIEWSTATE="False">Line of Business</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlPolicyClass" RUNAT="server" Class="form-select fs-txt-s" onselectedindexchanged="ddlPolicyClass_SelectedIndexChanged"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblGender" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Policy Type</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtPolicyType" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblLastName2" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Policy No.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtPolicyNo" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblBirthdate" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Certificate</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtCertificate" RUNAT="server" ontextchanged="txtCertificate_TextChanged" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label4" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Suffix</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtSuffix" RUNAT="server" ontextchanged="TxtSuffix_TextChanged" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblMaritalStatus" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Loan No.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtLoanNo" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblComments" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Comments</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtComments" RUNAT="server" TextMode="MultiLine" Class="form-control fs-txt-s w-266"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label1" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Customer No.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtCustomerNo" RUNAT="server" Class="form-control fs-txt-s" MAXLENGTH="10"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblSocialSecurity" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Name</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtName" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblHouseIncome" RUNAT="server" class="fs-lbl-s">Last Name 1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtLastName1" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label6" RUNAT="server" class="fs-lbl-s">Last Name 2</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtLastName2" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label7" RUNAT="server" class="fs-lbl-s">Social Security</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtSocialSecurity" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label8" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Status</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlTaskStatus" Class="form-control fs-txt-s" RUNAT="server"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label5" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Aging</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtAging" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label3" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Entry Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtEntryDate" RUNAT="server" Class="form-control fs-txt-s fechaFormat"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label9" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Close Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtCloseDate" RUNAT="server" Class="form-control fs-txt-s fechaFormat"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="LblBank" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Bank</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlBank" RUNAT="server" Class="form-control fs-txt-s"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label13" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Receipt No.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtReceiptNo" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label16" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Authorize By</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtAuthorizeBy" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="f-center">
                        <div class="row col-md-5">
                            <div class="col-md-4">
                                <asp:label id="lblLastName1" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False" Visible="False">Ins. Co. Policy No.</asp:label>
                            </div>
                            <div class="col-md-8">
                                <div class="input-group">
                                    <asp:textbox id="txtOriginalPolicyNo" RUNAT="server" Visible="False" Class="form-control fs-txt-s"></asp:textbox>
                                    <asp:Button id="BtnGo" runat="server" class="input-group-text" Text="Go" Visible="False" onclick="BtnGo_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>

                    <asp:Button id="BtnGo2" runat="server" Text="Go" Visible="False" onclick="BtnGo2_Click"></asp:Button>

                    <asp:TextBox ID="txtTCIDPolicy" runat="server" Visible="False" Width="73px"></asp:TextBox>

                    <div class="col-md-12">
                        <asp:label id="lblTypeAddress1" RUNAT="server" class="fs-lbl-s">Payment Information</asp:label>
                    </div>
                    <div class="row">
                        <div class="col-md-auto">
                            <asp:checkbox id="ChkMultiple" runat="server" class="fs-lbl-s" Text="Multiple Payments"></asp:checkbox>
                        </div>
                        <div class="col-md-auto">
                            <asp:Button id="BtnNewPayment" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="New Payment" onclick="BtnNewPayment_Click"></asp:Button>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="LblTotalCases" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Total Items:</asp:label>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label12" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Check No.</asp:label>
                            <asp:textbox id="TxtCheckNo" RUNAT="server" Class="form-control fs-txt-s"></asp:textbox>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label10" RUNAT="server" class="fs-lbl-s">Total Amount</asp:label>
                            <maskedinput:maskedtextbox id="TxtTotalAmount" runat="server" Class="form-control fs-txt-s" IsCurrency="True"></maskedinput:maskedtextbox>
                        </div>
                        <div class="col-md-auto"></div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row">
                        <div class="col-md-auto">
                            <asp:label id="Label11" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">SRO</asp:label>
                            <asp:checkbox id="ChkSRO" runat="server" Text=" " class="d-block" AutoPostBack="True" oncheckedchanged="ChkSRO_CheckedChanged"></asp:checkbox>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="LblPaymentDate" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Payment Date</asp:label>
                            <maskedinput:maskedtextbox id="TxtPaymentDate" RUNAT="server" ISDATE="True" CssClass="form-control fs-txt-s fechaFormat"></maskedinput:maskedtextbox>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label17" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Payment Check</asp:label>
                            <asp:Textbox id="TxtPaymentCheck" RUNAT="server" Class="form-control fs-txt-s"></asp:Textbox>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label18" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Payment Amount</asp:label>
                            <asp:TextBox id="TxtPaymentAmount" runat="server" Class="form-control fs-txt-s" IsCurrency="True"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label14" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Name</asp:label>
                            <asp:TextBox ID="TxtNamePayee" runat="server" Class="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label19" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Debit / Credit</asp:label>
                            <asp:dropdownlist id="ddlCreditDebit" Class="form-select fs-txt-s" RUNAT="server" AutoPostBack="True"></asp:dropdownlist>
                        </div>
                        <div class="col-md-auto">
                            <asp:label id="Label20" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False"> Deposit Date</asp:label>
                            <maskedinput:maskedtextbox id="txtDepositDate" RUNAT="server" ISDATE="True" CssClass="form-control fs-txt-s fechaFormat"></maskedinput:maskedtextbox>
                        </div>
                        <div class="col-md-auto"></div>
                    </div>






















                    <div class="row">
                        <div class="col-md-9" style="height:29.2px;">

                        </div>
                    </div>
                    <INPUT id="btnCalendar" style="WIDTH: 21px; HEIGHT: 21px; display:none;" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.TxtPaymentDate','calendar_window','width=250,height=250');calendar_window.focus()" tabIndex="23"
                        type="button" value="..." name="btnCalendar" RUNAT="server">









                    <INPUT id="Button1" style="WIDTH: 21px; HEIGHT: 21px; display:none;" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.txtDepositDate','calendar_window','width=250,height=250');calendar_window.focus()" tabIndex="29"
                        type="button" value="..." name="btnCalendar" RUNAT="server">
                    </TD>

                    <asp:checkbox id="ChkIsNEwTransaction" style="Z-INDEX: 101; LEFT: 408px; POSITION: absolute; TOP: 624px" tabIndex="21" runat="server" CssClass="headform1" Width="152px" Text="Is New Transaction" Visible="False"></asp:checkbox>

                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>

                    <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                </div>
            </form>
        </body>
        <script type="text/javascript">
            $('.datepicker-p1').datepicker();
        </script>

        </HTML>
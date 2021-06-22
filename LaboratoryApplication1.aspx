<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LaboratoryApplication1.aspx.cs"
    Inherits="EPolicy.LaboratoryApplication1" %>
    <%@ Register Assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.DynamicData" TagPrefix="cc1" %>
        <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
            <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

                <!DOCTYPE html PUBLIC"-//W3C//DTD XHTML 1.0 Transitional//EN""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
                <html xmlns="http://www.w3.org/1999/xhtml">

                <head>
                    <title>ePMS | electronic Policy Manager Solution</title>
                    <meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
                    <meta name="CODE_LANGUAGE" content="C#" />
                    <meta name="vs_defaultClientScript" content="JavaScript" />
                    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
                    <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />

                    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

                    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                    <script src="js/load.js" type="text/javascript"></script>

                    <script type="text/javascript">
                        function getExpDt() {
                            pdt = new Date(document.PolLab.txtEffDt.value);
                            trm = parseInt(document.PolLab.TxtTerm.value);
                            mnth = pdt.getMonth() + trm;
                            if (!isNaN(mnth)) {
                                pdt.setMonth(mnth % 12);
                                if (mnth > 11) {
                                    var t = pdt.getFullYear() + Math.floor(mnth / 12);
                                    pdt.setFullYear(t);
                                }
                                document.PolLab.txtExpDt.value = parse(pdt);
                            }
                        }

                        function parse(dt) {
                            ldt = new Date(dt);
                            if ((ldt.getMonth() + 1) < 10)
                                str = "0" + (ldt.getMonth() + 1);
                            else
                                str = (ldt.getMonth() + 1);
                            str += "/";
                            if (ldt.getDate() < 10)
                                str += "0" + ldt.getDate();
                            else
                                str += ldt.getDate();
                            str += "/";
                            str += dt.getFullYear();
                            return str;
                        }

                        function SetCiudad() {
                            for (i = 0; i <= document.PolCorp.ddlCiudad.options.length; i++) {
                                if (Number(document.PolCorp.ddlCiudad.options[i].value) == Number(document.PolCorp.TxtZip.value)) {
                                    document.PolCorp.ddlCiudad.selectedIndex = i;
                                    document.PolCorp.TxtZip.value = '00' + Number(document.PolCorp.TxtZip.value);
                                    return;
                                } else {
                                    document.PolCorp.ddlCiudad.selectedIndex = -1;
                                }
                            }
                        }

                        function SetZipCode() {
                            if (document.PolCorp.ddlCiudad.selectedIndex > 0) {
                                document.PolCorp.TxtZip.value = document.PolCorp.ddlCiudad.options[document.PolCorp.ddlCiudad.selectedIndex].value
                            } else {
                                document.PolCorp.TxtZip.value = ''
                            }
                        }
                    </script>

                    <style type="text/css">

                    </style>

                    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

                    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                    <script type="text/javascript" src="js/jquery.maskedinput-1.2.2.js"></script>

                    <script type="text/javascript">
                        $("#effect").hide();
                        $(function() {
                            $('#<%= txtEffDt.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });

                            $('#<%= TxtRetroactiveDate.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });

                            $('#<%= txtEndoEffDate.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });

                            $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtGapBegDate.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtGapEndDate.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtGapBegDate2.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtGapEndDate2.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtGapBegDate3.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtGapEndDate3.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtEntryDate.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtDatePrepared.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                            $('#<%= txtRetroEffDate.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                        });

                        function ShowDateTimePicker() {
                            $('#<%= txtEffDt.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker2() {
                            $('#<%= TxtRetroactiveDate.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker3() {
                            $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker5() {
                            $('#<%= txtEndoEffDate.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker6() {
                            $('#<%= txtGapBegDate.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker7() {
                            $('#<%= txtGapEndDate.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker8() {
                            $('#<%= txtGapBegDate2.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker9() {
                            $('#<%= txtGapEndDate2.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker10() {
                            $('#<%= txtGapBegDate3.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker11() {
                            $('#<%= txtGapEndDate3.ClientID %>').datepicker('show');
                        }
                        function ShowDateTimePicker12() {
                            $('#<%= txtEntryDate.ClientID %>').datepicker('show');
                        }
                        function ShowDateTimePicker13() {
                            $('#<%= txtDatePrepared.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePickerEndoRetroDate() {
                            $('#<%= txtRetroEffDate.ClientID %>').datepicker('show');
                        }

                        $(function() {
                            //run the currently selected effect
                            function runEffect() {
                                //get effect type from 
                                //var selectedEffect = $('#effectTypes').val();
                                var selectedEffect = "blind";
                                //most effect types need no options passed by default
                                var options = {};
                                //run the effect
                                $("#effect").show(selectedEffect, options, 500, callback);
                            };

                            //callback function to bring a hidden box back
                            function callback() {
                                //			setTimeout(function()
                                //			    {
                                //				    $("#effect:visible").removeAttr('style').hide().fadeOut();
                                //			    }, 
                                //			1000);
                            };

                            function CloseEffect() {
                                setTimeout(function() {
                                        $("#effect:visible").removeAttr('style').hide().fadeOut();
                                    },
                                    10);
                            }

                            //set effect from select menu value
                            $("#button").click(function() {
                                runEffect();
                                return false;
                            });

                            $("#btnRate").click(function() {
                                runEffect();
                                return false;
                            });

                            $("#btnCloseEffect").click(function() {
                                CloseEffect();
                                return false;
                            });

                            $("#effect").hide();
                        });
                    </script>

                    <script type="text/javascript">
                        jQuery(function ($) {
                            $(".telefoneFormat").mask("(999) 999-9999");
                            $(".fechaFormat").mask("99/99/9999");
                        });
                    </script>


                </head>

                <body>
                    <form id="PolLab" method="post" runat="server">
                        <asp:scriptmanager id="Script" runat="server" AsyncPostBackTimeout="0"></asp:scriptmanager>
                        <p>
                            <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                        </p>
                        <div class="container-xl">

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label21" runat="server" class="fs-14 fw-bold">Laboratory:</asp:label>
                                    <asp:label id="lblTCID" runat="server" class="fs-14 fw-bold"></asp:label>
                                </div>
                                <div class="col-md-8 f-right">
                                    <asp:button id="btnConvertPrimary" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnConvertPrimary_Click" tabindex="1" text="Convert Primary" />
                                    <asp:button id="btnConvertExcess" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnConvertExcess_Click" tabindex="1" text="Convert Excess" />
                                    <asp:button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Print" onclick="btnPrint_Click"></asp:button>
                                    <asp:button id="btnEnablePrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Enable Print" onclick="btnEnablePrint_Click" onclientclick="return confirm('Enabling Policy Printing, Continue?');"></asp:button>
                                    <asp:button id="btnRenew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnRenew_Click" text="Renew" />
                                    <asp:button id="btnReinstatement" tabindex="66" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Reinstatement" onclick="btnReinstatement_Click"></asp:button>
                                    <asp:button id="btnCancellation" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnCancellation_Click" text="Cancellation" />
                                    <asp:button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Modify" onclick="btnEdit_Click"></asp:button>
                                    <asp:button id="btnDelete" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnDelete_Click" text="Delete" onclientclick="return confirm('Are you certain you want to delete this Policy?');" />
                                    <asp:button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="New" onclick="btnAddNew_Click"></asp:button>
                                    <asp:button id="btnCalculatePremium" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Calculate" onclick="btnCalculatePremium_Click" />
                                    <asp:button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Cancel" onclick="cmdCancel_Click"></asp:button>
                                    <asp:button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Save" onclick="BtnSave_Click"></asp:button>
                                    <asp:button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Exit" onclick="BtnExit_Click"></asp:button>
                                    <asp:button id="btnComment" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnComment_Click" text="Comment" />
                                    <asp:button id="btnHistory" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnHistory_Click" text="History" />
                                    <asp:button id="btnEndor" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="New Endorsement" onclick="btnEndor_Click" style="font-family: Tahoma"></asp:button>
                                    <asp:button id="btnPayments" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" onclick="btnPayments_Click" text="Payments" />
                                    <asp:button id="btnComissions" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Commissions" onclick="btnComissions_Click"></asp:button>
                                    <asp:button id="btnFinancialCanc" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Financial Canc." onclick="btnFinancialCanc_Click"></asp:button>
                                    <asp:button id="btnTailQuote" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Tail Quote" onclick="btnTailQuote_Click"></asp:button>
                                    <asp:button id="btnPrintCertificate" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Print Certificate" onclick="btnPrintCertificate_Click"></asp:button>
                                    <asp:button id="btnPolicyCert" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" text="Policy Cert." onclick="btnPolicyCert_Click" visible="False" />
                                </div>
                            </div>
                            <div class="row mb-2 mt-2">
                                <div class="col-md-9">
                                    <asp:Label runat="server" Text="Laboratory Information" class="fs-14 fw-bold" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="LblStatus" runat="server" CssClass="headform2" class="fs-14 fw-bold">Inforce/</asp:Label>
                                    <asp:CheckBox ID="chkPaymentGA" runat="server" Text="Checked Payment by GA" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label45" runat="server" class="fs-lbl-s" EnableViewState="False">Name</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <div class="input-group">
                                        <asp:TextBox ID="TxtFirstName" runat="server" class="form-control fs-txt-s mb-1"></asp:TextBox>
                                        <asp:Label ID="Label52" runat="server" class="input-group-text" EnableViewState="False" Visible="False">Init.</asp:Label>
                                        <asp:TextBox ID="TxtInitial" runat="server" MaxLength="1" TabIndex="3" Visible="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label1" runat="server" class="fs-lbl-s" EnableViewState="False">Agency</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlAgency" runat="server" class="form-select fs-txt-s mb-1" TabIndex="52">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblEmail" runat="server" class="fs-lbl-s" EnableViewState="False">Corp No.</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtCustomerNo" runat="server" class="form-control fs-txt-s mb-1" MaxLength="10" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" class="fs-lbl-s" AutoPostBack="True" Text="" ToolTip="Auto Assign Policy" oncheckedchanged="ChkAutoAssignPolicy_CheckedChanged" />
                                    <asp:Label ID="lblPolicyNo" runat="server" class="fs-lbl-s">Policy No.</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtPolicyNo" runat="server" class="form-control fs-txt-s mb-1" MaxLength="15" TabIndex="40"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:label id="Label75" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Branch</asp:label>
                                </div>
                                <div class="col-md-3">
                                    <asp:dropdownlist id="ddlCity" tabIndex="52" RUNAT="server" class="form-select fs-txt-s mb-1"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label46" runat="server" class="fs-lbl-s" EnableViewState="False">Address 1</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtAddrs1" runat="server" class="form-control fs-txt-s mb-1" MaxLength="60" TabIndex="6"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblCertificate" runat="server" class="fs-lbl-s" visible="false">Certificate</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtCertificate" runat="server" class="form-control fs-txt-s mb-1" MaxLength="15" TabIndex="40" visible="false"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label61" runat="server" class="fs-lbl-s" EnableViewState="False">Agent</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlAgent" runat="server" class="form-select fs-txt-s mb-1" TabIndex="52">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label47" runat="server" class="fs-lbl-s" EnableViewState="False">Address 2</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtAddrs2" runat="server" class="form-control fs-txt-s mb-1" MaxLength="60" TabIndex="7"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblPolicyType" runat="server" class="fs-lbl-s">Policy Type</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group mb-1">
                                        <asp:TextBox ID="TxtPolicyType" runat="server" class="form-control fs-txt-s" MaxLength="4" TabIndex="41"></asp:TextBox>
                                        <asp:Label ID="lblSufijo" runat="server" class="fs-lbl-s input-group-text">Suffix</asp:Label>
                                        <asp:TextBox ID="TxtSufijo" runat="server" class="form-control fs-txt-s" MaxLength="2" TabIndex="42"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md 1">
                                    <asp:Label ID="lblOthAgent" runat="server" class="fs-lbl-s">Other Agent</asp:Label>
                                </div>
                                <div class="col-md-3">

                                    <asp:DropDownList ID="ddlAgent2" runat="server" class="form-select fs-txt-s mb-1" TabIndex="52">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label48" runat="server" class="fs-lbl-s" EnableViewState="False">City</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtCity" runat="server" class="form-control fs-txt-s mb-1" MaxLength="14" TabIndex="8"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblAnniversary" runat="server" class="fs-lbl-s" Text="Anniversary" />
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtAnniversary" runat="server" class="form-control fs-txt-s mb-1" MaxLength="2" TabIndex="42"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblOrigin" runat="server" class="fs-lbl-s" Text="Originated At" />
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlOriginatedAt" runat="server" class="form-select fs-txt-s mb-1" TabIndex="56">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label49" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Zip Code" />
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group mb-1">
                                        <asp:TextBox ID="TxtState" runat="server" class="form-control fs-txt-s" MaxLength="2" TabIndex="9"></asp:TextBox>
                                        <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" class="form-control fs-txt-s" IsDate="False" IsZipCode="true" Mask="CCCCCC" MaxLength="10" TabIndex="10"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblTerm" runat="server" class="fs-lbl-s">Term</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtTerm" runat="server" class="form-control fs-txt-s mb-1" MaxLength="3" TabIndex="43"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblInsComp" runat="server" class="fs-lbl-s">Ins. Company</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlInsuranceCompany" runat="server" class="form-select fs-txt-s mb-1" TabIndex="54" visible="false">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblHomePhone" runat="server" class="fs-lbl-s">Home Phone</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="txtHomePhone" runat="server" class="form-control fs-txt-s mb-1 telefoneFormat" IsDate="False" MaxLength="20" TabIndex="12"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblRetro" runat="server" class="fs-lbl-s" EnableViewState="False">Retro. Date</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="TxtRetroactiveDate" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" onclick="ShowDateTimePicker2();" TabIndex="44"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblGroup" runat="server" class="fs-lbl-s" visible="false">Group</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlGroup" runat="server" class="form-select fs-txt-s mb-1" TabIndex="55" visible="false">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblWorkPhone" runat="server" class="fs-lbl-s" EnableViewState="False">Work Phone</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="txtWorkPhone" runat="server" class="form-control fs-txt-s mb-1 telefoneFormat" IsDate="False" MaxLength="20" TabIndex="13"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblEffDate" runat="server" class="fs-lbl-s">Effective Date</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtEffDt" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" onclick="ShowDateTimePicker();" TabIndex="44"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblCorp" runat="server" class="fs-lbl-s">Corporation</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlCorparation" runat="server" class="form-control fs-txt-s mb-1" TabIndex="53">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label50" runat="server" class="fs-lbl-s" EnableViewState="False">Cellular</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" class="form-control fs-txt-s mb-1 telefoneFormat" IsDate="False" MaxLength="20" TabIndex="14"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblExpDate" runat="server" class="fs-lbl-s">Exp. Date</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtExpDt" runat="server" class="form-control fs-txt-s mb-1" ForeColor="DarkGray" TabIndex="46" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblMainSpecialty" runat="server" class="fs-lbl-s" EnableViewState="False">Main Spec.</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlMainSpecialty" runat="server" class="form-select fs-txt-s mb-1" TabIndex="53">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label41" runat="server" class="fs-lbl-s" EnableViewState="False">E-mail</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control fs-txt-s mb-1" MaxLength="100" TabIndex="15"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblEntryDate" runat="server" class="fs-lbl-s fechaFormat" onclick="ShowDateTimePicker12()">Entry Date</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtEntryDate" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" IsDate="True" TabIndex="47"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblFinancial" runat="server" class="fs-lbl-s">Financial</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlFinancial" runat="server" class="form-control fs-txt-s mb-1" TabIndex="53">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblClaimNo" runat="server" class="fs-lbl-s" Text="Claim No" />
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtClaimNumber" runat="server" class="form-control fs-txt-s mb-1" Columns="30" IsDate="True" TabIndex="47"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label51" runat="server" class="fs-lbl-s" visible="false">License:</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtLicense" runat="server" class="form-control fs-txt-s mb-1" MaxLength="25" TabIndex="15" visible="false"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label77" runat="server" class="fs-lbl-s">Has Claim?</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:RadioButtonList ID="rblClaim" runat="server" class="fs-lbl-s" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" Style="font-size: 9pt">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblCode" runat="server" class="fs-lbl-s" EnableViewState="False">Code</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtCode" runat="server" class="form-control fs-txt-s mb-1" MaxLength="4" TabIndex="41"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label78" runat="server" class="fs-lbl-s" EnableViewState="False">Est. Gross Receipts</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="txtEstGrossReceipt" runat="server" class="form-control fs-txt-s mb-1" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label43" runat="server" class="fs-lbl-s" EnableViewState="False">Limit:</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlPrMedicalLimits" runat="server" class="form-select fs-txt-s mb-1" AutoPostBack="false" TabIndex="56">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblOtherSpecialty" runat="server" class="fs-lbl-s" EnableViewState="False">Other Spec.</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlOtherSpecialtyB" runat="server" class="form-select fs-txt-s mb-1" TabIndex="53">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblCoverage" runat="server" class="fs-lbl-s" EnableViewState="False">Coverage</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtCoverage" runat="server" class="form-control fs-txt-s mb-1" MaxLength="4" TabIndex="41"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label60" runat="server" class="fs-lbl-s" EnableViewState="True">Charge</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="TxtCharge" runat="server" class="form-control fs-txt-s mb-1" IsDate="False" Mask="CCCCCC" MaxLength="14" TabIndex="48"></MaskedInput:MaskedTextBox>
                                    <asp:Button ID="btnCalcCharge" runat="server" BorderWidth="0px" onclick="btnCalcCharge_Click" Text="Calculate" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblPremum" runat="server" class="fs-lbl-s">Premium</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="TxtPremium" runat="server" class="form-control fs-txt-s mb-1" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49" OnTextChanged="TxtPremium_TextChanged"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblPremium0" runat="server" class="fs-lbl-s">Canc. Amount</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="TxtCancAmount" runat="server" class="form-control fs-txt-s mb-1" Enabled="False" IsCurrency="False" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblPriorAct" runat="server" class="fs-lbl-s" visible="false">Prior Act Type</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlPriorAct" runat="server" class="fs-lbl-s" TabIndex="53" visible="false">
                                        <asp:ListItem Value="0" Selected="True">Regular</asp:ListItem>
                                        <asp:ListItem Value="1">Limited</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="Label79" runat="server" class="fs-lbl-s" EnableViewState="False">Prospect Number</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" class="form-control fs-txt-s mb-1" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14" tabIndex="49"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblTotPremum" runat="server" class="fs-lbl-s">Tot. Premium</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <MaskedInput:MaskedTextBox ID="TxtTotalPremium" runat="server" class="form-control fs-txt-s mb-1" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49"></MaskedInput:MaskedTextBox>
                                </div>
                                <div class="col-md-1">

                                </div>
                                <div class="col-md-3">

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblLastName1" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="False">Last Name 1</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtLastname1" runat="server" class="form-control fs-txt-s mb-1" MaxLength="15" TabIndex="4" Visible="False"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblLastName2" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="False">Last Name 2</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtLastname2" runat="server" class="form-control fs-txt-s mb-1" MaxLength="15" TabIndex="5" Visible="False"></asp:TextBox>
                                </div>

                                <div class="col-md-1">
                                    <asp:Label ID="lblOtherSpecialty0" runat="server" class="fs-lbl-s" EnableViewState="False">Other Spec.</asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlOtherSpecialtyA" runat="server" class="form-select fs-txt-s" TabIndex="53">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblComments" runat="server" class="fs-lbl-s">Comments</asp:Label>
                                </div>
                                <div class="col-md-11">
                                    <asp:TextBox ID="TxtComments" runat="server" class="form-control fs-txt-s h-6 mb-1" TabIndex="50" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-1">
                                    <asp:Label ID="lblCoverage6" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Gap Dates:" />
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="lblCoverage0" runat="server" class="fs-lbl-s" EnableViewState="False">From:</asp:Label>
                                            <asp:TextBox ID="txtGapBegDate" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns=" 30" onclick="ShowDateTimePicker6();" TabIndex="44"></asp:TextBox>
                                            <asp:TextBox ID="txtGapBegDate2" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" onclick="ShowDateTimePicker8();" TabIndex="44"></asp:TextBox>
                                            <asp:TextBox ID="txtGapBegDate3" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns=" 30" onclick="ShowDateTimePicker10();" TabIndex="44"></asp:TextBox>

                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lblCoverage3" runat="server" class="fs-lbl-s" EnableViewState="False">To:</asp:Label>
                                            <asp:TextBox ID="txtGapEndDate" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" onclick="ShowDateTimePicker7();" TabIndex="44"></asp:TextBox>
                                            <asp:TextBox ID="txtGapEndDate2" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" onclick="ShowDateTimePicker9();" TabIndex="44"></asp:TextBox>
                                            <asp:TextBox ID="txtGapEndDate3" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" Columns="30" onclick="ShowDateTimePicker11();" TabIndex="44"></asp:TextBox>

                                        </div>
                                    </div>

                                </div>
                            </div>














                            <asp:DropDownList ID="ddlAvailableAgent" runat="server" Font-Names="Arial" Font-Size="7.5pt" TabIndex="57" Visible="False">
                            </asp:DropDownList>










                            <asp:CheckBox ID="chkUserMod" runat="server" oncheckedchanged="chkUserMod_CheckedChanged" Visible="False" />


                            <asp:ListBox ID="ddlSelectedAgent" runat="server" Font-Names="Arial" Font-Size="7.5pt" Height="22px" TabIndex="60"></asp:ListBox>






                            <asp:Label ID="lblLastName3" runat="server" EnableViewState="False" Visible="False">Number of Employees:
                            </asp:Label>


                            <asp:TextBox ID="txtNumberOfEmployees" runat="server" Columns="30" TabIndex="44" Visible="False"></asp:TextBox>








                            <asp:Label ID="lblCarrier" runat="server" EnableViewState="False">Excess Carrier Name
                            </asp:Label>


                            <asp:Label ID="Label65" runat="server" EnableViewState="False">Eff. Date
                            </asp:Label>


                            <asp:Label ID="Label66" runat="server" EnableViewState="False">Policy Limits
                            </asp:Label>


                            <asp:Label ID="Label67" runat="server" EnableViewState="False">Policy No. Other Company
                            </asp:Label>






                            <asp:TextBox ID="txtPriCarierName1" runat="server" MaxLength="75" TabIndex="24" Enabled="False"></asp:TextBox>
                            <asp:TextBox ID="txtPriPolEffecDate1" runat="server" CssClass="fechaFormat" onclick="ShowDateTimePicker3();" TabIndex="25" Enabled="False"></asp:TextBox>
                            <asp:TextBox ID="txtPriPolLimits1" runat="server" MaxLength="50" TabIndex="26" Enabled="False"></asp:TextBox>
                            <asp:TextBox ID="txtPriClaims1" runat="server" MaxLength="50" TabIndex="27" Enabled="False"></asp:TextBox>
                            <MaskedInput:MaskedTextBox ID="TxtUserPremium" runat="server" AutoPostBack="True" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" OnTextChanged="TxtPremium_TextChanged" TabIndex="49" Visible="False" Width="85px">
                            </MaskedInput:MaskedTextBox>

                            <asp:Panel ID="pnlEndorsement" runat="server" Width="955px">
                                <table style="width: 950px; height: 205px">

                                    <div class="col-md-12 mb-2 mt-2">
                                        <asp:Label ID="lblEndorsement" runat="server" class="fs-14 fw-bold" EnableViewState="False">Endorsements:</asp:Label>
                                    </div>
                                    <asp:CheckBox ID="chkUserModEndo" runat="server" Visible="False" oncheckedchanged="chkUserModEndo_CheckedChanged" />
                                    <asp:TextBox ID="txtEndorsementID" runat="server" class="form-control fs-txt-s mb-1" MaxLength="75" TabIndex="24" Visible="False"></asp:TextBox>
                                    <asp:Button ID="btnHideEndoPanel" runat="server" OnClick="btnHideEndoPanel_Click" TabIndex="72" Text="X" Visible="False" Width="25px" />

                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Label ID="lblEndorsementNo" runat="server" class="fs-lbl-s" EnableViewState="False">Endorsement No.:
                                            </asp:Label>
                                            <asp:TextBox ID="txtEndorsementNo" runat="server" class="form-control fs-txt-s mb-1" MaxLength="75" TabIndex="24"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblDatePrepared" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Date Prepared:" />
                                            <asp:TextBox ID="txtDatePrepared" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" onclick="ShowDateTimePicker13()" Columns="30" IsDate="True" TabIndex="44"></asp:TextBox>

                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblEndoEffDate" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Endo. Eff. Date:" />
                                            <asp:TextBox ID="txtEndoEffDate" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" onclick="ShowDateTimePicker5();"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblEndoRetroDate" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Endo. Retro. Date:" />
                                            <asp:TextBox ID="txtRetroEffDate" runat="server" class="form-control fs-txt-s mb-1 fechaFormat" onclick="ShowDateTimePickerEndoRetroDate();"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblEndoPremium" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Endo. Premium:" />
                                            <asp:TextBox ID="txtEndoPremium" runat="server" class="form-control fs-txt-s mb-1" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblEndoType" runat="server" class="fs-lbl-s" EnableViewState="False" Text="Endorsement Type:" />
                                            <asp:DropDownList ID="ddlEndoType" runat="server" class="form-select fs-txt-s mb-1" TabIndex="56">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:Label ID="lblEndoComments" runat="server" class="fs-lbl-s" EnableViewState="False">Comments:</asp:Label>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtEndoComments" runat="server" class="form-control fs-txt-s h-6 mb-1" MaxLength="2000" TabIndex="50" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                            </asp:Panel>

                            <div class="col-md-12">
                                <asp:Label ID="lblEndorsementHistory" runat="server" class="fs-14 fw-bold">Endorsements:</asp:Label>
                            </div>


                            <asp:DataGrid ID="dtEndorsement" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA
                                               " CellPadding="0" Font-Names="Arial" HeaderStyle-BackColor="#BB1509" HeaderStyle-ForeColor="white" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                OnItemCommand="dtEndorsement_ItemCommand
                                               " PageSize="8" TabIndex="9" Width="90%">
                                <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" CssClass="Numbers" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                        <ItemStyle />
                                        <HeaderStyle />
                                    </asp:ButtonColumn>
                                    <asp:BoundColumn DataField="EndorsementID" HeaderText="Task No." Visible="False">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EndorsementNo" HeaderText="Endorse No.">
                                        <HeaderStyle />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EntryDate" HeaderText="Date Prepared">
                                        <HeaderStyle Width="85px" />
                                        <ItemStyle />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EffectiveDate" HeaderText="Eff. Date">
                                        <HeaderStyle />
                                        <ItemStyle />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="RetroactiveDate" HeaderText="Retro. Date">
                                        <HeaderStyle />
                                        <ItemStyle />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EndorsementType" HeaderText="Type">
                                        <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EndorsementPremium" HeaderText="Premium">
                                        <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EndorsementComments" HeaderText="Comments">
                                        <HeaderStyle Width="250px" />
                                        <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EndorsementHistory" HeaderText="History" Visible="False">
                                        <HeaderStyle />
                                        <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">
                                        <HeaderStyle />
                                    </asp:ButtonColumn>
                                    <asp:TemplateColumn HeaderText="Del.">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete" OnClientClick="return confirm( 'Are you certain you want to delete this Endorsement?');" />
                                        </ItemTemplate>
                                        <HeaderStyle />
                                    </asp:TemplateColumn>
                                </Columns>
                                <HeaderStyle CssClass="HeadForm2" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="10px" HorizontalAlign="Center" />
                            </asp:DataGrid>
                            <div class="col-md-12">
                                <asp:Label ID="Label69" runat="server" class="fs-14 fw-bold" EnableViewState="False">History:</asp:Label>
                            </div>
                            <asp:Panel ID="pnlHistory" runat="server" style="text-align: center" Width="735px">

                                <asp:Button ID="btnRefresh" runat="server" BorderWidth="0px" onclick="btnRefresh_Click" style="font-family: Tahoma" tabIndex="66" Text="Refresh" Visible="False
                                               " Width="93px" />
                                <asp:DataGrid ID="DtSearchPayments" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White
                                               " BorderColor="#D6E3EA" CellPadding="0" Font-Names="Arial" HeaderStyle-BackColor="#BB1509" HeaderStyle-ForeColor="white" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="193px" ItemStyle-CssClass="HeadForm3"
                                    ItemStyle-HorizontalAlign="center" OnItemCommand="DtSearchPayments_ItemCommand1" PageSize="8" TabIndex="9" Width="90%">
                                    <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                    <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" CssClass="Numbers" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                    <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                    <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                            <ItemStyle />
                                            <HeaderStyle />
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No." Visible="False">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
                                            <HeaderStyle />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                            <HeaderStyle />
                                            <ItemStyle />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Certificate" HeaderText="Certificate" Visible="False">
                                            <HeaderStyle />
                                            <ItemStyle />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Sufijo" HeaderText="Suffix">
                                            <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv.">
                                            <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">
                                            <HeaderStyle />
                                            <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="LComments" HeaderText="Comments">
                                            <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="250px" />
                                            <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                    </Columns>
                                    <HeaderStyle CssClass="HeadForm2" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="10px" HorizontalAlign="Center" />
                                </asp:DataGrid>
                            </asp:Panel>
                            </asp:panel>

                            <asp:literal id="litPopUp" runat="server" visible="False"></asp:literal>
                            <input id="_Factor" runat="server" type="hidden" value="0" />
                            <input id="_TotalPremium1" runat="server" type="hidden" value="0" />
                            <input id="_TotalPremium2" runat="server" type="hidden" value="0" />
                            <input id="_TotalPremium3" runat="server" type="hidden" value="0" />
                            <input id="_TotalPremium4" runat="server" type="hidden" value="0" />
                        </div>
                    </form>

                </html>
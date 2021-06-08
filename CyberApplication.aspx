<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CyberApplication.aspx.cs"
    Inherits="EPolicy.CyberApplication" %>
    <%@ Register Assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.DynamicData" TagPrefix="cc1" %>
        <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
            <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>




                <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                        .style1 {
                            height: 14px;
                        }
                        
                        .style7 {
                            height: 20px;
                            text-align: left;
                        }
                        
                        .headfield1 {
                            text-align: left;
                            margin-left: 0px;
                            margin-right: 0px;
                            font-family: Tahoma;
                        }
                        
                        .style8 {
                            height: 20px;
                            width: 284px;
                            text-align: left;
                        }
                        
                        .style11 {
                            height: 19px;
                        }
                        
                        .style18 {
                            height: 23px;
                            text-align: right;
                        }
                        
                        .style19 {
                            font-family: Tahoma;
                            font-size: 9pt;
                            margin-right: 1px;
                        }
                        
                        .style22 {
                            height: 18px;
                            width: 270px;
                        }
                        
                        .style40 {
                            text-align: left;
                            margin-left: 0px;
                            margin-right: 0px;
                            font-size: 8pt;
                        }
                        
                        .style44 {
                            height: 39px;
                            text-align: right;
                        }
                        
                        .style53 {
                            width: 329px;
                            height: 27px;
                        }
                        
                        .style46 {
                            height: 22px;
                            text-align: left;
                        }
                        
                        .style35 {
                            height: 22px;
                        }
                        
                        .style45 {
                            height: 22px;
                            text-align: center;
                        }
                        
                        .style49 {
                            width: 186px;
                            height: 19px;
                            text-align: left;
                        }
                        
                        .style52 {
                            height: 107px;
                        }
                        
                        .style55 {
                            height: 18px;
                        }
                        
                        .headForm1 {}
                        
                        .style57 {
                            height: 22px;
                            text-align: left;
                            width: 173px;
                        }
                        
                        .style58 {
                            height: 22px;
                            text-align: center;
                            width: 173px;
                        }
                        
                        .style59 {
                            height: 22px;
                            width: 162px;
                        }
                        
                        .style60 {
                            height: 22px;
                            text-align: center;
                            width: 162px;
                        }
                        
                        .style61 {
                            height: 22px;
                            width: 12px;
                        }
                        
                        .style62 {
                            height: 22px;
                            text-align: center;
                            width: 12px;
                        }
                        
                        .style64 {
                            height: 22px;
                            width: 52px;
                        }
                        
                        .style66 {
                            text-align: left;
                            height: 13px;
                            width: 90px;
                        }
                        
                        .style68 {
                            width: 502px;
                            height: 9px;
                        }
                        
                        .style69 {
                            text-align: left;
                            height: 13px;
                            width: 502px;
                        }
                        
                        .style74 {
                            width: 90px;
                        }
                        
                        .style75 {
                            width: 502px;
                        }
                        
                        .style76 {
                            width: 768px;
                            height: 9px;
                        }
                        
                        .style77 {
                            text-align: left;
                            height: 13px;
                            width: 768px;
                        }
                        
                        .style78 {
                            width: 768px;
                        }
                        
                        .style79 {
                            height: 27px;
                        }
                        
                        .style80 {
                            width: 768px;
                            height: 26px;
                        }
                        
                        .style81 {
                            height: 26px;
                        }
                        
                        .style82 {
                            width: 768px;
                            height: 28px;
                        }
                        
                        .style83 {
                            height: 28px;
                        }
                    </style>

                    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

                    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

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

                            $('#<%= txtEffectiveDates.ClientID %>').datepicker({
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
                            $('#<%= txtEffectiveDates.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker7() {
                            $('#<%= txtGapBegDate.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker8() {
                            $('#<%= txtGapEndDate.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker9() {
                            $('#<%= txtGapBegDate2.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker10() {
                            $('#<%= txtGapEndDate2.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker11() {
                            $('#<%= txtGapBegDate3.ClientID %>').datepicker('show');
                        }

                        function ShowDateTimePicker12() {
                            $('#<%= txtGapEndDate3.ClientID %>').datepicker('show');
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

                </head>

                <body>

                    <form id="PolCyber" method="post" runat="server">
                        <asp:scriptmanager id="Script" runat="server" AsyncPostBackTimeout="0"></asp:scriptmanager>

                        <p>
                            <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                        </p>

                        <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                            <div class="row">
                                <div class="col-md-4" style="align-self:center;">
                                    <asp:label id="Label21" runat="server" CssClass="fs-14 fw-bold">Cyber:</asp:label>
                                    <asp:label id="lblTCID" runat="server" CssClass="fs-14 fw-bold"></asp:label>
                                </div>
                                <div class="col-md-8" style="text-align:right;">
                                    <asp:button id="btnConvertPrimary" runat="server" text="Convert Primary" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnConvertPrimary_Click1" />
                                    <asp:button id="btnConvert" runat="server" text="Convert Excess" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnConvert_Click" Visible="False" />
                                    <asp:button id="btnPrint" runat="server" text="Print" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnPrint_Click"></asp:button>
                                    <asp:button id="btnEnablePrint" runat="server" text="Enable Print" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" onclientclick="return confirm('Enabling Policy Printing, Continue?');" onclick="btnEnablePrint_Click"></asp:button>
                                    <asp:button id="btnRenew" runat="server" text="Renew" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnRenew_Click" />
                                    <asp:button id="btnReinstatement" runat="server" text="Reinstatement" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnReinstatement_Click"></asp:button>
                                    <asp:button id="btnCancellation" runat="server" text="Cancellation" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnCancellation_Click" />
                                    <asp:button id="btnEdit" runat="server" text="Modify" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnEdit_Click"></asp:button>
                                    <asp:button id="btnDelete" runat="server" text="Delete" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" onclientclick="return confirm('Are you certain you want to delete this Policy?');" onclick="btnDelete_Click" />
                                    <asp:button id="btnAddNew" runat="server" text="New" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnAddNew_Click"></asp:button>
                                    <asp:button id="btnCalculatePremium" runat="server" text="Calculate" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnCalculatePremium_Click" />
                                    <asp:button id="cmdCancel" runat="server" text="Cancel" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="cmdCancel_Click"></asp:button>
                                    <asp:button id="BtnSave" runat="server" text="Save" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="BtnSave_Click"></asp:button>
                                    <asp:button id="BtnExit" runat="server" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="BtnExit_Click" text="Exit"></asp:button>
                                    <asp:button id="btnComment" runat="server" text="Comment" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnComment_Click" />
                                    <asp:button id="btnHistory" runat="server" text="History" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnHistory_Click" />
                                    <asp:button id="btnEndor" runat="server" text="New Endorsement" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnEndor_Click"></asp:button>
                                    <asp:button id="btnPayments" runat="server" text="Payments" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnPayments_Click" />
                                    <asp:button id="btnComissions" runat="server" text="Commissions" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnComissions_Click"></asp:button>
                                    <asp:button id="btnFinancialCanc" runat="server" text="Financial Canc." style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnFinancialCanc_Click"></asp:button>
                                    <asp:button id="btnTailQuote" runat="server" text="Tail Quote" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnTailQuote_Click"></asp:button>
                                    <asp:button id="btnPrintCertificate" runat="server" text="Print Certificate" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnPrintCertificate_Click"></asp:button>
                                    <asp:button id="btnPolicyCert" runat="server" text="Policy Cert." style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" visible="False"></asp:button>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                    <div class="row">
                                        <asp:Label ID="Label42" runat="server" CssClass="fs-11 fw-bold">Applicant Information</asp:Label>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label45" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Individual / Enity:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtFirstName" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEmail" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Customer No.</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtCustomerNo" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="10"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label46" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Mailing Address:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtAddrs1" runat="server" MaxLength="60" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label47" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Office Address:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtAddrs2" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="60"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label48" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">City:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtCity" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label49" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Zip Code:</asp:Label>
                                                <div class="col-md-8" style="height:29.2px;">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="TxtState" runat="server" MaxLength="2" Width="30%" CSSCLASS="form-control fs-txt-s" style="float:left"></asp:TextBox>
                                                        <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" Width="70%" CSSCLASS="form-control fs-txt-s" IsDate="False" IsZipCode="true" Mask="CCCCCC" MaxLength="10"></MaskedInput:MaskedTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblMobilePhone" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Mobile Phone:</asp:Label>
                                                <div class="col-md-8">
                                                    <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" CSSCLASS="form-control fs-txt-s" IsDate="False" Mask="(999) 999-9999" MaxLength="20">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </MaskedInput:MaskedTextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblOfficePhone" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Office Phone:</asp:Label>
                                                <div class="col-md-8">
                                                    <MaskedInput:MaskedTextBox ID="txtWorkPhone" runat="server" CSSCLASS="form-control fs-txt-s" IsDate="False" Mask="(999) 999-9999" MaxLength="20"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </MaskedInput:MaskedTextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label41" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">E-mail:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEmail" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="100"></asp:TextBox>
                                                </div>
                                            </div>
                                            
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblComments" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Comments:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtComments" runat="server" MaxLength="200" TextMode="MultiLine" Visible="False" Width="265%"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <div class="col-md-4 label-vertical-align">
                                                    <asp:Label ID="lblPolicyNo" runat="server" CssClass="col-form-labe" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Policy No.</asp:Label>
                                                    <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" ForeColor="Black" Height="14px" Width="1px" AutoPostBack="True" Text=" " ToolTip="Auto Assign Policy" />
                                                </div>
                                                <div class="col-md-8" style="height:29.2px;">
                                                    <asp:TextBox ID="TxtPolicyNo" runat="server" CssClass="form-control fs-txt-s" MaxLength="15"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label2" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Individual / Enity:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TextBox1" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblPolicyType" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Policy Type</asp:Label>
                                                <div class="col-md-8" style="height:29.2px;">
                                                    <div class="input-group mb-3">
                                                        <asp:TextBox ID="TxtPolicyType" runat="server" CSSCLASS="form-control fs-txt-s" style="height:29.2px;" MaxLength="4"></asp:TextBox>
                                                        <asp:Label ID="lblSufijo" runat="server" class="input-group-text fs-lbl-s label-vertical-align" style="height:29.2px;">Suffix</asp:Label>
                                                        <asp:TextBox ID="TxtSufijo" runat="server" CSSCLASS="form-control fs-txt-s" style="height:29.2px;" MaxLength="2"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblAnniversary" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Anniversary</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtAnniversary" runat="server" MaxLength="2" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblTerm" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Term</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtTerm" runat="server" MaxLength="3" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblRetro" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Retro. Date</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="TxtRetroactiveDate" runat="server" Columns="30" onclick="ShowDateTimePicker2();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEffDate" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Effective Date</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEffDt" runat="server" Columns="30" onclick="ShowDateTimePicker();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblExpDate" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Exp. Date</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtExpDt" runat="server" CSSCLASS="form-control fs-txt-s" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEntryDate" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Entry Date</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEntryDate" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" IsDate="True"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>


                                        <div class="col-md-4">
                                            <div class="mb-3 row" style="margin-top: 3px; padding-bottom: 8.5px;">
                                                <asp:Label ID="LblStatus" runat="server" CssClass="headform2" EnableViewState="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Height="14px" Width="69px">Inforce/</asp:Label>
                                                <asp:CheckBox ID="chkPaymentGA" runat="server" Text="Checked Payment by GA" Font-Size="Small" Width="170px" style="font-size: 9pt; font-family: Tahoma" />
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label1" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Agency</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlAgency" runat="server" CSSCLASS="form-select fs-txt-s" onselectedindexchanged="ddlAgency_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:label id="Label75" RUNAT="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Branch</asp:label>
                                                <div class="col-md-8">
                                                    <asp:dropdownlist id="ddlCity" RUNAT="server" CSSCLASS="form-select fs-txt-s"></asp:dropdownlist>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label61" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Agent</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlAgent" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="mb-3 row">
                                                <asp:Label ID="lblOthAgent" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Other Agent</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlAgent2" runat="server" CSSCLASS="form-select fs-txt-s">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="mb-3 row">
                                                <asp:Label ID="lblOrigin" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Originated At</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlOriginatedAt" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="mb-3 row">
                                                <asp:Label ID="lblCorp" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Corporation</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlCorparation" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>
                                            
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblInsComp" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Ins. Company</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlInsuranceCompany" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>
                                            
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblGroup" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Group</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlGroup" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>
                                            
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblFinancial" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Financial</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlFinancial" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label43" runat="server" EnableViewState="False" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align">Limit:</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlCyberLimits" runat="server" CSSCLASS="form-select fs-txt-s" AutoPostBack="false"></asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <asp:Label ID="labelAlternateEmail" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Alternate Email:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtAlternateEmail" runat="server" CSSCLASS="form-select fs-txt-s" MaxLength="50" Visible="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblRetro7" runat="server" CSSCLASS="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Number Of Employees:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtNumberOfEmployees" runat="server" CSSCLASS="form-select fs-txt-s" Columns="30"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <hr />
                                    <div class="row">
                                        <asp:Label ID="lblRetro3" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">Gap Dates:</asp:Label>
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblRetro0" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">From:</asp:Label>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtGapBegDate" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker7();"></asp:TextBox>
                                                </div>
                                                <asp:Label ID="lblRetro4" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">To:</asp:Label>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtGapEndDate" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker8();"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblRetro1" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">From:</asp:Label>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtGapBegDate2" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker9();"></asp:TextBox>
                                                </div>

                                                <asp:Label ID="lblRetro5" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">To:</asp:Label>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtGapEndDate2" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker10();"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblRetro2" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">From:</asp:Label>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtGapBegDate3" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker11();"></asp:TextBox>
                                                </div>

                                                <asp:Label ID="lblRetro6" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">To:</asp:Label>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtGapEndDate3" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker12();"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEnity0" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Prospect Number</asp:Label>
                                                <div class="col-md-8">
                                                    <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" Enabled="False" CSSCLASS="form-control fs-txt-s" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14"></MaskedInput:MaskedTextBox>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEnity" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Enity:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlEnity" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblOther" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Other (please describe):</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtOtherEnity" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="50"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <div class="mb-3 row">
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label60" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Charge</asp:Label>
                                                        <div class="col-md-12">
                                                            <MaskedInput:MaskedTextBox ID="TxtCharge" runat="server" CSSCLASS="form-control fs-txt-s" IsDate="False" Mask="CCCCCC" MaxLength="14">
                                                            </MaskedInput:MaskedTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblPremum" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align">Premium</asp:Label>
                                                        <div class="col-md-12">
                                                            <MaskedInput:MaskedTextBox ID="TxtPremium" runat="server" CSSCLASS="form-control fs-txt-s" IsDate="False" OnTextChanged="TxtPremium_TextChanged" Mask="CCCCCCCCCC" MaxLength="14"></MaskedInput:MaskedTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblPremium0" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align">Canc. Amount</asp:Label>
                                                        <div class="col-md-12">
                                                            <MaskedInput:MaskedTextBox ID="TxtCancAmount" runat="server" CSSCLASS="form-select fs-txt-s" Enabled="False" IsCurrency="False" IsDate="False" Mask="CCCCCCCCCC">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </MaskedInput:MaskedTextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblPracticeHistory" runat="server" EnableViewState="False" CssClass="col-form-labe fs-lbl-s label-vertical-align">Practice history</asp:Label>
                                                        <div class="col-md-12">
                                                            <asp:DropDownList ID="ddlPracticeHistory" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblTotPremum" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align">Tot. Premium</asp:Label>
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="TxtTotalPremium" runat="server" CSSCLASS="form-control fs-txt-s" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&gt;
                                                            </asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblPatientNumber" runat="server" EnableViewState="False" CssClass="col-form-labe fs-lbl-s label-vertical-align">Number of Patients Files</asp:Label>
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtNumOfPatients" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="15" Visible="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblNumOfPhysicians" runat="server" EnableViewState="False" CssClass="col-form-labe fs-lbl-s label-vertical-align">Number of Physicians</asp:Label>
                                                        <div class="col-md-12">
                                                            <asp:DropDownList ID="ddlNumOfPhysicians" runat="server" CSSCLASS="form-select fs-txt-s" Visible="True"></asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="lblClaimNo" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align">Claim No</asp:Label>
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtClaimNumber" runat="server" CSSCLASS="form-select fs-txt-s" Columns="30" IsDate="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                    <hr />
                                    <div class="row">
                                        <asp:Label ID="lblPolicyInfo" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">Cyber Liability Policy Information:</asp:Label>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblInsuranceCarrier" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Insurance Carrier:</asp:Label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtInsuranceCarrier" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="75"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblPolicyEfDates" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Policy Effective Date:</asp:Label>

                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtEffectiveDates" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker6();"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblPolicyLimits" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Policy Limits:
                                                </asp:Label>

                                                <div class="col-md-12">
                                                    <asp:DropDownList ID="ddlLimitsPolicyInfo" runat="server" CSSCLASS="form-select fs-txt-s"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblPolicyNumberInfo" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Policy Number:
                                                </asp:Label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtPolicyNumberInfo" runat="server" AutoPostBack="True" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <hr />
                                    <div class="row">
                                        <asp:Label ID="lblGeneralInfo" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">General Information:</asp:Label>
                                        <div class="col-md-12">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblHippa" runat="server" CssClass="col-md-12 col-form-labe fs-11 label-vertical-align" EnableViewState="False">1. Are you in HIPPA compliance with the following?</asp:Label>
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblPrivacyOfficer" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" Text="  a. Have you designated a Privacy Oficer?"></asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblPrivacyOfficer" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label79" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+2/0</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblPrivacyPractice" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" Text="b. Have you adopted and implemented a written privacy practices policy?"></asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblPrivacyPractice" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label80" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+4/-4</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblAwerenessTrain" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" Text="c. Have your employeed undergone privacy risk and awerreness training?"></asp:Label>



                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblAwerenessTrain" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label81" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+1/-1</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblTechPerson" runat="server" CssClass="col-md-10 col-form-labe fs-11 label-vertical-align" EnableViewState="False">
                                                    2. Do you have an Information Technology person (or subcontractor) to implement and manage computer security for the Company&#39;s or individual&#39;s Network?
                                                </asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblTechPerson" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label82" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+2/-2</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblPrivacyBreach" runat="server" CssClass="col-md-10 col-form-labe fs-11 label-vertical-align" EnableViewState="False">
                                                    3. Have you experienced a computer security or privacy breach in the past 3 years?
                                                </asp:Label>


                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblPrivacyBreach" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label83" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+2/-3</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblGmail" runat="server" CssClass="col-md-10 col-form-labe fs-11 label-vertical-align" EnableViewState="False">
                                                    4. Do you use Gmail or other free web-based email for business?
                                                </asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblGmail" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label84" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+2/-4</asp:Label>
                                            </div>
                                            <div class="mb-3 row">

                                                <asp:Label ID="lblRegardRec" runat="server" CssClass="col-md-12 col-form-labe fs-11 label-vertical-align" EnableViewState="False">
                                                    5. Regarding your records:
                                                </asp:Label>
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblPaperRec" runat="server" CssClass="col-md-4 col-form-labe fs-10 label-vertical-align" EnableViewState="False">
                                                    a. Do you have paper-based records? ** If yes, please answer the following 3 questions:
                                                </asp:Label>
                                                <div class="col-md-2"></div>
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblLockedCab" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">
                                                    i. Do you store them in a locket cabineet or room?
                                                </asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblLockedCab" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label85" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+3/-2</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblPaperRet" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">ii. Do you have paper retention and disposal policy?</asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblPaperRet" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label86" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+1/-1</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblShredDoc" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">
                                                    iii. Do you shred or destroy all document when disposing of paper records?</asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblShredDoc" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label87" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+2/-2</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblElecRec" runat="server" CssClass="col-md-4 col-form-labe fs-10 label-vertical-align" EnableViewState="False">
                                                    b. Do you have electronic records? **If yes, plese answer the following 4 questions:
                                                </asp:Label>
                                                <div class="col-md-2"></div>
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblITEncrypted" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">
                                                    i. Is the Company IT Network encrypted?
                                                </asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblITEncrypted" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label88" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right">+4/-4</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblITNetwork" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">
                                                    ii. Is the Company IT Network accessible only by the user of frequently changed passwords?
                                                </asp:Label>
                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblITNetwork" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <asp:Label ID="Label89" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" style="text-align:right; align-self: end;">+2/-2</asp:Label>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblElecRecOnline" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">
                                                    iii. Are electronic records stored online in &quot;the Cloud&quot; with a secure internet provider?
                                                </asp:Label>



                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblElecRecOnline" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-6"></div>
                                                <asp:Label ID="lblElecRecWebBase" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">
                                                    iv. Are electronics records stored web-based or stand-alone?
                                                </asp:Label>



                                                <div class="col-md-1" style="text-align:-webkit-right;">
                                                    <asp:RadioButtonList ID="rblElecRecWebBase" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Yes</asp:ListItem>
                                                        <asp:ListItem>No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                            <div class="mb-3 row">
                                                <div class="col-md-10" style="text-align:-webkit-right;">
                                                    <asp:Label ID="lblCreditDebitPercent" runat="server" CssClass=" col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">%</asp:Label>
                                                </div>
                                                <div class="col-md-1">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtTotalDebit" runat="server" CssClass="form-control fs-txt-s" Width="50%" Columns="30" style="float:left"></asp:TextBox>
                                                        <asp:TextBox ID="txtTotalCredit" runat="server" CssClass="form-control fs-txt-s" Width="50%" Columns="30"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                            <div class="mb-3 row">

                                                <div class="col-md-10" style="text-align:-webkit-right;">
                                                    <asp:Label ID="lblCreditDebitTotal" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Total Percent: %</asp:Label>
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txtTotalCreditDebit" runat="server" CssClass="form-control fs-txt-s" Columns="30"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </div>
                                    </div>


                                    <hr />
                                    <div class="row">
                                        <asp:Label ID="lblEndorsement" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">Endorsements:</asp:Label>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEndorsementNo" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endorsement No.:</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEndorsementNo" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="75"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblDatePrepared" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Date Prepared:</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtDatePrepared" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" IsDate="True"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEndoEffDate" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endo. Eff. Date:</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEndoEffDate" runat="server" CSSCLASS="form-control fs-txt-s" onclick="ShowDateTimePicker5();"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEndoRetroDate" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endo. Retro. Date:</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtRetroEffDate" runat="server" CSSCLASS="form-control fs-txt-s" onclick="ShowDateTimePickerEndoRetroDate();"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEndoPremium" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endo. Premium:</asp:Label>

                                                <div class="col-md-8">
                                                    <asp:TextBox ID="txtEndoPremium" runat="server" CSSCLASS="form-control fs-txt-s" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEndoType" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endorsement Type:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlEndoType" CSSCLASS="form-select fs-txt-s" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-8">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblEndoComments" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Comments:</asp:Label>

                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtEndoComments" RUNAT="server" CSSCLASS="form-control fs-txt-s" Height="157px" MAXLENGTH="2000" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-12">
                                            <asp:Label ID="lblEndorsementHistory" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align fw-bold" runat="server">Endorsements:</asp:Label>

                                            <asp:DataGrid ID="dtEndorsement" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="0" Font-Names="Arial" Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="16px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                                PageSize="8" TabIndex="9" Width="90%" HeaderStyle-ForeColor="white" onitemcommand="dtEndorsement_ItemCommand">
                                                <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                                <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                                <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="Tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                                <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                                        <ItemStyle Font-Names="Tahoma" />
                                                        <HeaderStyle Width="40px" />
                                                    </asp:ButtonColumn>
                                                    <asp:BoundColumn DataField="EndorsementID" HeaderText="Task No." Visible="False">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EndorsementNo" HeaderText="Endorse No.">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EntryDate" HeaderText="Date Prepared">
                                                        <HeaderStyle Width="85px" />
                                                        <ItemStyle Font-Names="Tahoma" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EffectiveDate" HeaderText="Eff. Date">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Names="Tahoma" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="RetroactiveDate" HeaderText="Retro. Date">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Names="Tahoma" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EndorsementType" HeaderText="Type">
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EndorsementPremium" HeaderText="Premium">
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EndorsementComments" HeaderText="Comments">
                                                        <HeaderStyle Width="250px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EndorsementHistory" HeaderText="History" Visible="False">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                    </asp:BoundColumn>
                                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">
                                                        <HeaderStyle Width="40px" />
                                                    </asp:ButtonColumn>
                                                    <asp:TemplateColumn HeaderText="Del.">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete" OnClientClick="return confirm('Are you certain you want to delete this Endorsement?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="40px" />
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#BB1509" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                            </asp:DataGrid>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:Label ID="Label69" runat="server" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align fw-bold" EnableViewState="False">History:</asp:Label>

                                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Visible="False" />

                                            <asp:DataGrid ID="DtSearchPayments" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="0" Font-Names="Arial" Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="193px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                                PageSize="8" TabIndex="9" Width="90%" HeaderStyle-ForeColor="white" onitemcommand="DtSearchPayments_ItemCommand1">
                                                <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                                <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                                <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="Tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                                <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                <Columns>
                                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                                        <ItemStyle Font-Names="Tahoma" />
                                                        <HeaderStyle Width="40px" />
                                                    </asp:ButtonColumn>
                                                    <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No." Visible="False">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Names="Tahoma" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Certificate" HeaderText="Certificate" Visible="False">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Names="Tahoma" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Sufijo" HeaderText="Suffix">
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv.">
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">
                                                        <HeaderStyle Width="75px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="LComments" HeaderText="Comments">
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="250px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#BB1509" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                            </asp:DataGrid>
                                        </div>



                                    </div>


                                </div>




                                <%--<asp:Label ID="lblPrivacyOfficer0" runat="server" Text="  Yes / No"></asp:Label>--%>


































                                    <asp:Label ID="lblCertificate" runat="server" visible="false">Certificate</asp:Label>
                                    <asp:TextBox ID="TxtCertificate" runat="server" MaxLength="15" visible="false"></asp:TextBox>

                                    <asp:Label ID="lblHomePhone" runat="server" Visible="False">Home Phone</asp:Label>
                                    <MaskedInput:MaskedTextBox ID="txtHomePhone" runat="server" IsDate="False" Mask="(999) 999-9999" MaxLength="20" Visible="False"></MaskedInput:MaskedTextBox>

                                    <asp:Label ID="lblMainSpecialty" runat="server" CssClass="headfield1" EnableViewState="False" Visible="False">Main Spec.</asp:Label>
                                    <asp:DropDownList ID="ddlMainSpecialty" runat="server" Visible="False"></asp:DropDownList>

                                    <asp:Label ID="Label51" runat="server" visible="False">License</asp:Label>
                                    <asp:TextBox ID="txtLicense" runat="server" MaxLength="25" visible="false"></asp:TextBox>

                                    <asp:Label ID="lblCode" runat="server" EnableViewState="False" Visible="False">Code</asp:Label>
                                    <asp:TextBox ID="txtCode" runat="server" MaxLength="4" Visible="False"></asp:TextBox>

                                    <asp:Label ID="Label78" runat="server" EnableViewState="False" Visible="False">Est. Gross Receipts</asp:Label>
                                    <MaskedInput:MaskedTextBox ID="txtEstGrossReceipt" runat="server" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" Visible="False"></MaskedInput:MaskedTextBox>

                                    <asp:Label ID="lblCoverage" runat="server" EnableViewState="False" Visible="False">Coverage</asp:Label>
                                    <asp:TextBox ID="txtCoverage" runat="server" MaxLength="4" Visible="False"></asp:TextBox>

                                    <asp:Button ID="btnCalcCharge" runat="server" Text="Calculate" />

                                    <asp:Label ID="lblPriorAct" runat="server" visible="false">Prior Act Type</asp:Label>
                                    <asp:DropDownList ID="ddlPriorAct" runat="server" visible="false">
                                        <asp:ListItem Selected="True" Value="0">Regular</asp:ListItem>
                                        <asp:ListItem Value="1">Limited</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:Label ID="Label77" runat="server" Visible="False">Has Claim?</asp:Label>
                                    <asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" Visible="False">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>

                                    <asp:Label ID="lblOtherSpecialty" runat="server" EnableViewState="False" Visible="False">Other Spec.</asp:Label>
                                    <asp:DropDownList ID="ddlOtherSpecialtyB" runat="server" Visible="False">
                                    </asp:DropDownList>

                                    <asp:DropDownList ID="ddlAvailableAgent" runat="server" Visible="False">
                                    </asp:DropDownList>

                                    <MaskedInput:MaskedTextBox ID="TxtUserPremium" runat="server" AutoPostBack="True" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" Visible="False"></MaskedInput:MaskedTextBox>

                                    <asp:CheckBox ID="chkUserMod" runat="server" Visible="False" />

                                    <asp:ListBox ID="ddlSelectedAgent" runat="server" Visible="False"></asp:ListBox>

                                    <asp:Label ID="lblCarrier" runat="server" EnableViewState="False" Visible="False">Excess Carrier Name</asp:Label>

                                    <asp:Label ID="Label65" runat="server" EnableViewState="False" Visible="False">Eff. Date</asp:Label>

                                    <asp:Label ID="Label66" runat="server" EnableViewState="False" Visible="False">Policy Limits</asp:Label>

                                    <asp:Label ID="Label67" runat="server" EnableViewState="False" Visible="False">Policy No. Other Company</asp:Label>

                                    <asp:TextBox ID="txtPriCarierName1" runat="server" MaxLength="75" Enabled="False" Visible="False"></asp:TextBox>

                                    <asp:TextBox ID="txtPriPolEffecDate1" runat="server" onclick="ShowDateTimePicker3();" Enabled="False" Visible="False"></asp:TextBox>

                                    <asp:TextBox ID="txtPriPolLimits1" runat="server" MaxLength="50" Enabled="False" Visible="False"></asp:TextBox>

                                    <asp:TextBox ID="txtPriClaims1" runat="server" MaxLength="50" Enabled="False" Visible="False"></asp:TextBox>


                                    <asp:Panel ID="pnlPolicyInfo" runat="server">


                                        <asp:TextBox ID="txtLiabilityID" runat="server" Visible="False"></asp:TextBox>
                                        <asp:CheckBox ID="chkUserModEndo2" runat="server" Visible="False" />
                                        <asp:TextBox ID="txtTest" runat="server" MaxLength="75" Visible="False"></asp:TextBox>
                                        <asp:Button ID="btnAddPolicyInfo" runat="server" onclick="btnAddPolicyInfo_Click" Text="Update" Visible="False" />



                                        <asp:DataGrid ID="dtCyberPolicyInfo" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="0" Font-Names="Arial" Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="16px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                            TabIndex="9" Width="90%" HeaderStyle-ForeColor="white" onitemcommand="dtCyberPolicyInfo_ItemCommand">
                                            <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                            <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                            <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                            <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="Tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                            <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                            <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:ButtonColumn ButtonType="PushButton" CommandName="Modify" HeaderText="Modify">
                                                    <ItemStyle Font-Names="Tahoma" />
                                                    <HeaderStyle Width="40px" />
                                                </asp:ButtonColumn>
                                                <asp:BoundColumn DataField="LiabilityID" HeaderText="LiabilityID" Visible="False">
                                                    <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TaskControlID" HeaderText="TaskControlID" Visible="False">
                                                    <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="InsuranceCarrier" HeaderText="Insurance Carrier">
                                                    <HeaderStyle Width="125px" />
                                                    <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="EffectiveDate" HeaderText="Policy Effective Date">
                                                    <HeaderStyle Width="140px" HorizontalAlign="Center" />
                                                    <ItemStyle Font-Names="Tahoma" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="LimitDesc" HeaderText="Policy Limit">
                                                    <HeaderStyle Width="125px" />
                                                    <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy Number">
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Del.">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete" OnClientClick="return confirm('Are you certain you want to delete this Endorsement?');" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="40px" />
                                                </asp:TemplateColumn>
                                                <%-- <asp:BoundColumn DataField="EndorsementPremium" HeaderText="Premium">--%>
                                                    <%--<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                                Width="50px" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" 
                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                HorizontalAlign="Center" />
                                                        </asp:BoundColumn>--%>
                                                        <%--<asp:BoundColumn DataField="EndorsementComments" HeaderText="Comments">
                                                            <HeaderStyle Width="250px" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EndorsementHistory" HeaderText="History" 
                                                            Visible="False">
                                                            <HeaderStyle Width="75px" />
                                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                        </asp:BoundColumn>
                                                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">
                                                            <HeaderStyle Width="40px" />
                                                        </asp:ButtonColumn>--%>
                                                            <%-- <asp:TemplateColumn HeaderText="Del.">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" 
                                                                    CommandName="Delete" 
                                                                    OnClientClick="return confirm('Are you certain you want to delete this Endorsement?');" />
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="40px" />
                                                        </asp:TemplateColumn>--%>
                                            </Columns>
                                            <HeaderStyle BackColor="#BB1509" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                        </asp:DataGrid>

                                    </asp:Panel>


                                    <asp:Panel ID="pnlGeneralInfo" runat="server">




                                    </asp:Panel>


                                    <asp:Panel ID="pnlEndorsement" runat="server" Width="955px">
                                        <asp:CheckBox ID="chkUserModEndo" runat="server" Visible="False" />
                                        <asp:TextBox ID="txtEndorsementID" runat="server" MaxLength="75" Visible="False"></asp:TextBox>
                                        <asp:Button ID="btnHideEndoPanel" runat="server" Text="X" Visible="False" />





                                        <asp:Panel ID="pnlHistory" runat="server" style="text-align: center" Width="735px">


                                        </asp:Panel>

                                    </asp:Panel>

                                    <asp:literal id="litPopUp" runat="server" visible="False"></asp:literal>
                                    <input id="_Factor" runat="server" type="hidden" value="0" />
                                    <input id="_TotalPremium1" runat="server" type="hidden" value="0" />
                                    <input id="_TotalPremium2" runat="server" type="hidden" value="0" />
                                    <input id="_TotalPremium3" runat="server" type="hidden" value="0" />
                                    <input id="_TotalPremium4" runat="server" type="hidden" value="0" />
                            </div>
                        </div>
                    </form>
                </body>

                </html>
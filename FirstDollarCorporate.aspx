<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstDollarCorporate.aspx.cs"
    Inherits="EPolicy.FirstDollarCorporate" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <html xmlns="http://www.w3.org/1999/xhtml">

        <head>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta http-equiv="X-UA-Compatible" content="IE=EDGE" />
            <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />

            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script src="js/load.js" type="text/javascript"></script>
            <script>
                function getExpDt() {
                    pdt = new Date(document.PolCorp.txtEffDt.value);
                    trm = parseInt(document.PolCorp.TxtTerm.value);
                    mnth = pdt.getMonth() + trm;
                    if (!isNaN(mnth)) {
                        pdt.setMonth(mnth % 12);
                        if (mnth > 11) {
                            var t = pdt.getFullYear() + Math.floor(mnth / 12);
                            pdt.setFullYear(t);
                        }
                        document.PolCorp.txtExpDt.value = parse(pdt);
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
                        //alert(document.Pol.ddlCiudad.options[i].value +' - 'document.Pol.TxtZip.value)
                        if (Number(document.PolCorp.ddlCiudad.options[i].value) == Number(document.PolCorp.TxtZip.value)) {
                            //alert(document.PolCorp.ddlCiudad.options[i].text)
                            document.PolCorp.ddlCiudad.selectedIndex = i;
                            //document.PolCorp.TxtCity.value = document.PolCorp.ddlCiudad.options[i].text;
                            document.PolCorp.TxtZip.value = '00' + Number(document.PolCorp.TxtZip.value);
                            return;
                        } else {
                            //document.PolCorp.TxtCity.value = "";
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
                
                .style9 {
                    width: 186px;
                    height: 19px;
                }
                
                .style10 {
                    width: 162px;
                    height: 19px;
                }
                
                .style11 {
                    height: 19px;
                }
                
                .style16 {
                    height: 23px;
                }
                
                .style17 {
                    height: 20px;
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
                
                .style32 {
                    text-align: right;
                }
                
                .style37 {
                    width: 168px;
                    height: 24px;
                }
                
                .style38 {
                    width: 186px;
                    height: 24px;
                    text-align: left;
                }
                
                .style39 {
                    height: 4px;
                }
                
                .style40 {
                    text-align: left;
                    margin-left: 0px;
                    margin-right: 0px;
                    font-size: 8pt;
                }
                
                .style44 {
                    height: 25px;
                    text-align: right;
                }
                
                .style53 {
                    width: 329px;
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
                
                .style54 {
                    height: 24px;
                }
                
                .style55 {
                    height: 18px;
                }
                
                .style56 {
                    width: 152px;
                }
                
                .style57 {
                    height: 4px;
                    width: 152px;
                }
                
                .style58 {
                    height: 18px;
                    width: 152px;
                }
                
                .style59 {
                    height: 14px;
                    width: 152px;
                }
                
                .style61 {
                    height: 24px;
                    width: 152px;
                }
                
                .style62 {
                    height: 20px;
                    text-align: left;
                    width: 152px;
                }
                
                .style63 {
                    width: 152px;
                    height: 19px;
                }
                
                .style64 {
                    height: 19px;
                    width: 270px;
                }
            </style>

        </head>

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

                $('#<%= txtQuoteRetroDate.ClientID %>').datepicker({
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
                $('#<%= txtExpDt.ClientID %>').datepicker({
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

            function ShowDateTimePicker4() {
                $('#<%= txtQuoteRetroDate.ClientID %>').datepicker('show');
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
                $('#<%= txtExpDt.ClientID %>').datepicker('show');
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

        <body>
            <form id="PolCorp" method="post" runat="server">
                <p>
                    <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                </p>

                <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                    <div class="row">
                        <div class="col-md-4" style="align-self: center;">
                            <asp:Label ID="Label21" runat="server" CssClass="fs-14 fw-bold">Corporate:</asp:Label>
                            <asp:Label ID="lblTCID" runat="server" Width="70px" Font-Size="10pt" Font-Names="Tahoma"></asp:Label>
                        </div>
                        <div class="col-md-8" style="text-align:right;">
                            <asp:Button ID="btnConvertPrimary" runat="server" Font-Size="9pt" Font-Names="Tahoma" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" OnClick="btnConvertPrimary_Click" Text="Convert Primary" />
                            <asp:Button ID="btnPrint" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Print" OnClick="btnPrintWord_Click" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:button id="btnEnablePrint" runat="server" Font-Size="9pt" Text="Enable Print" onclick="btnEnablePrint_Click" Font-Names="Tahoma" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclientclick="return confirm('Enabling Policy Printing, Continue?');"
                            />
                            <asp:Button ID="btnRenew" runat="server" Font-Size="9pt" OnClick="btnRenew_Click" Text="Renew" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Font-Names="Tahoma" style="margin-bottom: 4px;" />
                            <asp:button id="btnReinstatement" runat="server" Font-Size="9pt" Text="Reinstatement" Font-Names="Tahoma" onclick="btnReinstatement_Click" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:Button ID="btnCancellation" runat="server" Font-Size="9pt" Font-Names="Tahoma" OnClick="btnCancellation_Click" Text="Cancellation" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                            <asp:Button ID="BtnSave" runat="server" Font-Size="9pt" Text="Save" Font-Names="Tahoma" OnClick="BtnSave_Click" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:Button ID="btnEdit" runat="server" Font-Size="9pt" Font-Names="Tahoma" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Modify" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" Font-Size="9pt" Font-Names="Tahoma" OnClick="btnDelete_Click" Text="Delete" onclientclick="return confirm('Are you certain you want to delete this Policy?');" style="margin-bottom: 4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4"
                            />
                            <asp:Button ID="btnAddNew" runat="server" Font-Size="9pt" Font-Names="Tahoma" style="margin-bottom: 4px;" Text="New" OnClick="btnAddNew_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:Button ID="cmdCancel" runat="server" Font-Size="9pt" Font-Names="Tahoma" style="margin-bottom: 4px;" Text="Cancel" OnClick="cmdCancel_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:Button ID="BtnExit" runat="server" Font-Size="9pt" Font-Names="Tahoma" style="margin-bottom: 4px;" Text="Exit" OnClick="BtnExit_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:button id="btnComment" runat="server" Font-Size="9pt" Font-Names="Tahoma" onclick="btnComment_Click" text="Comment" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                            <asp:Button ID="btnHistory" runat="server" Font-Size="9pt" Font-Names="Tahoma" OnClick="btnHistory_Click" Text="History" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                            <asp:button id="btnEndor" Font-Size="8pt" Font-Names="Tahoma" runat="server" Text="New Endorsement" onclick="btnEndor_Click" style="vertical-align: top; margin-bottom:4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:Button ID="btnPayments" runat="server" Font-Size="9pt" Font-Names="Tahoma" OnClick="btnPayments_Click" Text="Payments" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                            <asp:button id="btnComissions" runat="server" Font-Size="9pt" Font-Names="Tahoma" style="margin-bottom: 4px;" Text="Commissions" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" onclick="btnComissions_Click" />
                            <asp:button id="btnFinancialCanc" runat="server" Font-Size="8pt" Font-Names="Tahoma" Text="Financial Canc." onclick="btnFinancialCanc_Click" style="vertical-align: top; margin-bottom:4px;" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:button id="btnTailQuote" runat="server" Font-Size="9pt" Font-Names="Tahoma" Text="Tail Quote" onclick="btnTailQuote_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                            <asp:Button ID="btnPrintCertificate" runat="server" Font-Size="9pt" Font-Names="Tahoma" style="margin-bottom: 4px;" Text="Print Certificate" OnClick="btnPrintCertificate_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                            <asp:button id="btnPolicyCert" runat="server" Font-Size="9pt" Font-Names="Tahoma" Text="Policy Cert." onclick="btnPolicyCert_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Visible="False" style="margin-bottom: 4px;" />
                        </div>
                        <div class="col-md-12">
                            <hr />
                            <div class="row">
                                <h6>
                                    <asp:Label ID="Label42" runat="server" CssClass="fs-11 fw-bold">Corporate Information</asp:Label>
                                </h6>


                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label45" runat="server" CSSCLASS="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Name</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtFirstName" runat="server" CSSCLASS="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="200"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row" runat="server" visible="false">
                                        <asp:Label ID="lblLastName1" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" Visible="False">Last Name 1</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtLastname1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="15" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row" runat="server" visible="false">
                                        <asp:Label ID="lblLastName2" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px" Visible="False">Last Name 2</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtLastname2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="15" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row" runat="server" visible="false">
                                        <asp:Label ID="Label52" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="20px" Visible="False">Init.</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtInitial" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="1" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEmail" runat="server" CSSCLASS="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Corp No.</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtCustomerNo" runat="server" CSSCLASS="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblCertificate" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Certificate</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtCertificate" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="15" TabIndex="40"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label54" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Anniversary</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtAnniversary" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label55" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Term</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtTerm" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label48" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">City</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtCity" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblHomePhone" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Home Phone</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="txtHomePhone" onKeyDown="KeyDownHandler();" onkeyup="KeyDownHandler();" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="(999) 999-9999" MaxLength="20"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>

                                    <div class="mb-3 row">
                                        <asp:Label ID="lblWorkPhone" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Work Phone</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="txtWorkPhone" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="(999) 999-9999" MaxLength="20"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label50" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Cellular</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="(999) 999-9999" MaxLength="20"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label41" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">E-mail</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label51" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">License:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtLicense" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="25"></asp:TextBox>

                                            <MaskedInput:MaskedTextBox ID="TxtUserPremium" RUNAT="server" AutoPostBack="True" CSSCLASS="form-control" Font-Names="Tahoma" Font-Size="8pt" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14" ontextchanged="TxtPremium_TextChanged" tabIndex="49" Visible="False"></MaskedInput:MaskedTextBox>

                                            <asp:CheckBox ID="chkUserMod" runat="server" Font-Names="Tahoma" Font-Size="9pt" Visible="False" />
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label60" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">Charge</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtCharge" runat="server" CssClass="form-control" Width="63.7%" style="float:left" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="CCCCCC" MaxLength="14"></MaskedInput:MaskedTextBox>
                                            <asp:Button ID="btnCalcCharge" runat="server" CssClass="btn-bg-theme2 btn-w-100 btn-r-4" style="margin-left: 10px; height: 29px;" Font-Names="Tahoma" ForeColor="White" OnClick="CalculateCharge" Font-Size="9pt" Text="Calculate" />
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblPremum" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Premium</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtPremium" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" ontextchanged="TxtPremium_TextChanged"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <div class="col-md-3 label-vertical-align">
                                            <asp:Label ID="lblPolicyNo" runat="server" CssClass="col-form-labe" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Policy No.</asp:Label>
                                            <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" AutoPostBack="True" ForeColor="Black" Height="14px" Width="1px" OnCheckedChanged="ChkAutoAssignPolicy_CheckedChanged" Text=" " ToolTip="Auto Assign Policy" />
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtPolicyNo" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="15" ontextchanged="TxtPolicyNo_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnBack" runat="server" Height="23px" onclick="btnBack_Click" Text="&lt;" Width="19px" Visible="False" />
                                            <asp:Button ID="btnFoward" runat="server" Height="23px" onclick="btnFoward_Click" Text="&gt;" Width="19px" Visible="False" />
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label53" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Policy Type</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtPolicyType" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="4" Width="30%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label9" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Suffix</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtSufijo" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="2" Width="30%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label46" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Address 1</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtAddrs1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="60"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label47" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Address 2</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtAddrs2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="60"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label49" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Zip Code</asp:Label>
                                        <div class="col-md-9">
                                            <div class="input-group mb-3">
                                                <asp:TextBox ID="TxtState" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="2" Width="30%" style="float:left"></asp:TextBox>
                                                <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" IsZipCode="true" Mask="CCCCCC" MaxLength="10" Width="70%"></MaskedInput:MaskedTextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label56" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Retro. Date</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="TxtRetroactiveDate" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="mb-3 row">
                                        <asp:Label ID="Label57" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Effective Date</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtEffDt" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker();"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label58" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Exp. Date</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtExpDt" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="True" onclick="ShowDateTimePicker12();"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label59" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Entry Date</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtEntryDate" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row" style="height:29.2px">
                                        <asp:Label ID="lblUpdateForm" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Update Form</asp:Label>
                                        <div class="col-md-9 label-vertical-align">
                                            <asp:CheckBox ID="chkUpdateForm" runat="server" Font-Names="Tahoma" Font-Size="9pt" />
                                        </div>
                                    </div>
                                    <div class="mb-3 row" style="height:29.2px">
                                        <asp:Label ID="Label77" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Has Claim?</asp:Label>
                                        <div class="col-md-9 label-vertical-align">
                                            <asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" style="font-size: 9pt">
                                                <asp:ListItem Value="0">Yes</asp:ListItem>
                                                <asp:ListItem Value="1">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblClaimNo" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Claim No</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtClaimNumber" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-4">
                                    <div class="mb-3 row" style="margin-top: 3px; padding-bottom: 8.5px;">
                                        <asp:Label ID="LblStatus" runat="server" CssClass="headform2" EnableViewState="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Height="14px" Width="69px">Inforce/</asp:Label>
                                        <asp:CheckBox ID="chkPaymentGA" runat="server" Font-Size="Small" Width="170px" style="font-size: 9pt; font-family: Tahoma" Text="Checked Payment by GA" />
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label1" runat="server" CSSCLASS="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Agency</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlAgency" runat="server" CSSCLASS="form-select" Font-Names="Tahoma" Font-Size="8pt" onselectedindexchanged="ddlAgency_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblBranch" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Branch</asp:Label>
                                        <div class="col-md-9">
                                            <asp:dropdownlist id="ddlCity" Font-Names="Tahoma" Font-Size="8pt" RUNAT="server" CssClass="form-select"></asp:dropdownlist>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label61" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Agent</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlAgent" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label62" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Originated At</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlOriginatedAt" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label63" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Ins. Company</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlInsuranceCompany" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label71" RUNAT="server" CSSCLASS="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt" HEIGHT="14px">Group</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlGroup" RUNAT="server" CSSCLASS="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label64" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Corporation</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlCorparation" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblFinancial" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Financial</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlFinancial" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblMainSpecialty" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Main Spec.</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlMainSpecialty" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblOtherSpecialty" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Other Spec.</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlOtherSpecialtyA" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblOtherSpecialty0" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Other Spec.</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlOtherSpecialtyB" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label75" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Other Agent</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlAgent2" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>



                                <div class="col-md-8">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblComments" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Comments</asp:Label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="TxtComments" runat="server" CssClass="form-control" Width="100%" Height="157px" Font-Names="Tahoma" Font-Size="8pt" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="lblPremium0" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" HEIGHT="14px" CSSCLASS="col-md-3 col-form-labe label-vertical-align">Canc. Amount</asp:label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtCancAmount" RUNAT="server" CSSCLASS="form-control" Enabled="False" Font-Names="Tahoma" Font-Size="8pt" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblTotPremum" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Tot. Premium</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtTotalPremium" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblLastName3" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Prospect Number</asp:Label>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" CSSCLASS="form-control" Enabled="False" Font-Names="Tahoma" Font-Size="8pt" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label43" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Limit:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlPrMedicalLimits" runat="server" AutoPostBack="false" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" onselectedindexchanged="ddlPrMedicalLimits_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>





                            <hr />
                            <div class="row">
                                <h6>
                                    <asp:Label ID="lblGapEndDate5" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">Gap Dates:</asp:Label>
                                </h6>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblGapEndDate0" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">From:</asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtGapBegDate" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker6();"></asp:TextBox>
                                        </div>

                                        <asp:Label ID="lblGapEndDate" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">To:</asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtGapEndDate" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker7();"></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="mb-3 row">
                                        <asp:Label ID="lblGapEndDate1" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">From:</asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtGapBegDate2" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker8();"></asp:TextBox>
                                        </div>

                                        <asp:Label ID="lblGapEndDate3" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">To:</asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtGapEndDate2" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker9();"></asp:TextBox>
                                        </div>
                                    </div>



                                    <div class="mb-3 row">
                                        <asp:Label ID="lblGapEndDate2" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">From:</asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtGapBegDate3" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker10();"></asp:TextBox>
                                        </div>

                                        <asp:Label ID="lblGapEndDate4" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">To:</asp:Label>
                                        <div class="col-md-5">
                                            <asp:TextBox ID="txtGapEndDate3" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker11();"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <div class="col-md-12">
                                            <asp:ListBox ID="ddlSelectedAgent" runat="server" Font-Names="Arial" CssClass="form-control" Height="119.8px" Font-Size="8pt"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="mb-3 row">
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="lblCarrier" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="8pt">Excess Carrier Name</asp:Label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtPriCarierName1" runat="server" Font-Names="Tahoma" Font-Size="8pt" MaxLength="75" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label65" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="8pt">Eff. Date</asp:Label>
                                                <div class="col-md-12" style="height:29.2px;">
                                                    <div class="input-group mb-3 input-append date datepicker-p1" data-date-format="mm-dd-yyyy">
                                                        <%--<input size="10" type="text" class="form-control" value="12-02-2012">--%>
                                                            <maskedinput:maskedtextbox id="txtPriPolEffecDate1" Height="29.2px" Font-Size="8pt" Font-Names="Tahoma" RUNAT="server" ISDATE="True" CssClass="form-control"></maskedinput:maskedtextbox>
                                                            <span class="add-on input-group-text" style="height:29px;"><i class="bi bi-grid-3x3-gap-fill"></i></span>
                                                    </div>

                                                    <%--<maskedinput:maskedtextbox id="txtPriPolEffecDate1" Font-Size="8pt" Font-Names="Tahoma" style="float:left;"  
                                        RUNAT="server" ISDATE="True" CssClass="form-control" Width="80%"></maskedinput:maskedtextbox>
                                    <INPUT id="btnCalendar" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.txtPriPolEffecDate1','calendar_window','width=250,height=250');calendar_window.focus()"
                                        type="button" Width="20%" value="..." name="btnCalendar" RUNAT="server">--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label66" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="8pt">Policy Limits</asp:Label>
                                                <div class="col-md-12">
                                                    <asp:DropDownList ID="ddlPriPolLimits1" runat="server" CSSCLASS="form-select" Font-Names="Tahoma" Font-Size="8pt" AutoPostBack="True" OnSelectedIndexChanged="ddlPriPolLimits1_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="mb-3 row">
                                                <asp:Label ID="Label67" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="8pt">Policy No. Other Company</asp:Label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtPriClaims1" runat="server" Font-Names="Tahoma" Font-Size="8pt" MaxLength="50" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <hr />
                            <div class="row">
                                <h6>
                                    <asp:Label ID="lblEndorsement" runat="server" CssClass="headfield1" EnableViewState="False" Font-Bold="True" Font-Names="Tahoma">Endorsements:</asp:Label>
                                </h6>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndorsementNo" runat="server" CssClass="col-md-4 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Endorsement No.:</asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtEndorsementNo" runat="server" Font-Names="Tahoma" Font-Size="8pt" MaxLength="75" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblDatePrepared" runat="server" CssClass="col-md-4 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Date Prepared:</asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtDatePrepared" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndoEffDate" runat="server" CssClass="col-md-4 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Endo. Eff. Date:</asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtEndoEffDate" runat="server" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker5();" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndoRetroDate" runat="server" CssClass="col-md-4 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Endo. Retro. Date:</asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtRetroEffDate" runat="server" Font-Names="Tahoma" CssClass="form-control" Font-Size="8pt" onclick="ShowDateTimePickerEndoRetroDate();"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndoPremium" runat="server" CssClass="col-md-4 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Endo. Premium:</asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtEndoPremium" runat="server" AutoPostBack="True" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" ontextchanged="txtEndoPremium_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndoType" runat="server" CssClass="col-md-4 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt">Endorsement Type:</asp:Label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlEndoType" RUNAT="server" CSSCLASS="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-8">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndoComments" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px">Comments:</asp:Label>
                                        <div class="col-md-12">
                                            <asp:TextBox ID="txtEndoComments" RUNAT="server" CssClass="form-control" Width="100%" Height="157px" Font-Names="Tahoma" Font-Size="8pt" MAXLENGTH="2000" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4"></div>

                                <div class="col-md-12">
                                    <div class="mb-3 row">
                                        <asp:Label ID="lblEndorsementHistory" runat="server" CssClass="col-form-labe label-vertical-align" EnableViewState="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Endorsements:</asp:Label>
                                        <div class="col-md-12">
                                            <asp:DataGrid ID="dtEndorsement" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="0" Font-Names="Arial" Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="16px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                                OnItemCommand="dtEndorsement_ItemCommand" PageSize="8" TabIndex="9" Width="795px" onselectedindexchanged="dtEndorsement_SelectedIndexChanged">
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
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
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
                                                            <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete" onclientclick="return confirm('Are you certain you want to delete this Endorsement?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="40px" />
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                            </asp:DataGrid>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <hr />
                            <div class="row">
                                <h6>
                                    <asp:Label ID="Label69" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">History:</asp:Label>
                                </h6>
                                <div class="col-md-12">
                                    <div class="mb-3 row">
                                        <asp:Button ID="btnRefresh" runat="server" Font-Size="9pt" onclick="btnRefresh_Click" Font-Names="Tahoma" CssClass="btn-bg-theme2 btn-w-100 btn-r-4" Text="Refresh" Visible="False" />
                                        <div class="col-md-12">
                                            <asp:DataGrid ID="DtSearchPayments" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="0" Font-Names="Arial" Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="193px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                                OnItemCommand="DtSearchPayments_ItemCommand1" PageSize="8" TabIndex="9" Width="737px">
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
                                                    <asp:BoundColumn DataField="CComments" HeaderText="Comments">
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="250px" />
                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                    </asp:BoundColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                            </asp:DataGrid>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label8" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="8.29pt">Corporation:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="txtCorporation" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" MaxLength="300"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label70" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="8.29pt">Retroactive Date:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="txtQuoteRetroDate" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" onclick="ShowDateTimePicker4();"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label74" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" EnableViewState="False" Font-Names="Tahoma" Font-Size="8.29pt" Visible="true">Agent:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:DropDownList ID="ddlAgent0" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="mb-3 row">
                                                        <asp:label id="Label72" RUNAT="server" Font-Size="8.29pt" Font-Names="Tahoma" CssClass="col-md-3 col-form-labe label-vertical-align">Group:</asp:label>
                                                        <div class="col-md-9">
                                                            <asp:dropdownlist id="ddlGroup2" RUNAT="server" Font-Size="8pt" Font-Names="Tahoma" CSSCLASS="form-select"></asp:dropdownlist>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label18" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="8.29pt">Physician Name:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="txtCustomerName2" runat="server" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" MaxLength="75"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label3" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="8.29pt">Primary Rate:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:DropDownList ID="ddlPrimaryLimits1" runat="server" AutoPostBack="True" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlPrimaryLimits1_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>



                                                <div class="col-md-6">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label11" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Specialty:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:DropDownList ID="ddPrimarylPolicyClass" runat="server" AutoPostBack="True" CssClass="form-select" Font-Names="Tahoma" Font-Size="8pt" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label12" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Iso Code:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="txtIsoCode" runat="server" Font-Names="Tahoma" Font-Size="8pt" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label19" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Primary Mature Rate:</asp:Label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="txtPRate4" runat="server" Font-Names="Tahoma" CssClass="form-control" Font-Size="8pt"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mb-3 row">
                                                        <asp:Label ID="Label68" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Quantity:</asp:Label>
                                                        <div class="col-md-9">
                                                            <MaskedInput:MaskedTextBox ID="TxtAddQuantity" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="8pt" IsDate="False" Mask="CC" MaxLength="2">1</MaskedInput:MaskedTextBox>

                                                            <input id="txtPrateID" runat="server" name="txtPrateID" size="1" class="form-control" type="hidden" value="0" />
                                                            <input id="HIPrimeryRateID" runat="server" name="HIPrimeryRateID" size="1" class="form-control" type="hidden" value="0" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12" style="text-align: center;">
                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                                                </div>
                                                <div class="col-md-12">
                                                    <asp:DataGrid ID="DtGridCorpaoratePol" runat="server" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" CellPadding="0"
                                                        Font-Names="Arial" Font-Size="8pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="130px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                                                        OnItemCommand="DtGridCorpaoratePol_ItemCommand" PageSize="8" TabIndex="9" Width="803px" onselectedindexchanged="DtGridCorpaoratePol_SelectedIndexChanged">
                                                        <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                                        <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                                        <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="Tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                                        <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                        <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Modify">
                                                                <HeaderStyle Width="30px" />
                                                                <ItemStyle Font-Names="Tahoma" />
                                                            </asp:ButtonColumn>
                                                            <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No." Visible="False">
                                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="CustomerName" HeaderText="Physician Name">
                                                                <HeaderStyle Width="140px" />
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PrimaryRate" HeaderText="Primary Rate">
                                                                <HeaderStyle Width="75px" />
                                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Right" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                                            </asp:BoundColumn>
                                                            <%--<asp:BoundColumn DataField="ExcessRate" HeaderText="Excess Rate">
                                                <HeaderStyle Width="75px" />
                                                <ItemStyle Font-Names="Tahoma" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                            </asp:BoundColumn>--%>
                                                                <asp:BoundColumn DataField="Specialty" HeaderText="Specialty">
                                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="140px" />
                                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="IsoCode" HeaderText="Iso Code">
                                                                    <HeaderStyle Width="50px" />
                                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="TotalPrimaryPremium" HeaderText="Primary Prem.">
                                                                    <HeaderStyle Width="120px" />
                                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                                                </asp:BoundColumn>
                                                                <%-- <asp:BoundColumn DataField="TotalExcessPremium" HeaderText="Excess Prem.">
                                                <HeaderStyle Width="120px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" HorizontalAlign="Right" />
                                            </asp:BoundColumn>--%>
                                                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" HeaderText="Delete"></asp:ButtonColumn>
                                                                    <asp:BoundColumn DataField="CorporatePolicyDetailQuoteID" HeaderText="CorporatePolicyDetailQuoteID" Visible="False"></asp:BoundColumn>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                                    </asp:DataGrid>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <hr />
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label73" runat="server" Font-Size="10pt" Text="Quantity:" Width="20%" style="float:left;" CssClass="col-form-labe label-vertical-align"></asp:Label>
                                        <asp:Label ID="lblQuantity" runat="server" Text="0" Width="80%" CssClass="col-form-labe label-vertical-align"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label40" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Primary Rate %:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtDiscountP" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20">25%</asp:TextBox>

                                            <asp:TextBox ID="txtCorporatePolicyQuoteID" runat="server" Visible="False" CssClass="form-control"></asp:TextBox>
                                            <asp:TextBox ID="txtERate1M_3M" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" TabIndex="2" Width="87px" Visible="False"></asp:TextBox>

                                            <asp:TextBox ID="txtERate150_200" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>

                                            <asp:TextBox ID="txtERate250_500" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>

                                            <asp:TextBox ID="txtERate400_700" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>

                                            <asp:TextBox ID="txtERate500_1M" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>

                                            <asp:TextBox ID="txtPRate" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label17" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt">Primary Premium:</asp:Label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtTotalPrimaryPremium" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20"></asp:TextBox>

                                            <asp:TextBox ID="txtEmployee1M_3M" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>

                                            <asp:TextBox ID="txtEmployee250_500" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12" style="text-align:right;">
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Calculate" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" />
                                </div>
                            </div>


                            <hr />
                            <div class="row">
                                <h6>
                                    <asp:Label ID="Label7" runat="server" CssClass="fs-11 fw-bold">Primary - Technicians & Nurses</asp:Label>
                                </h6>
                                <div class="col-md-12">
                                    <div class="mb-3 row">
                                        <div class="col-md-3"></div>
                                        <asp:Label ID="Label2" runat="server" CssClass="col-md-2 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Primary</asp:Label>
                                        <asp:Label ID="Label4" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Rate %</asp:Label>
                                        <asp:Label ID="Label14" runat="server" CssClass="col-md-2 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Premium</asp:Label>
                                        <asp:Label ID="Label6" runat="server" CssClass="col-md-2 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Quantity</asp:Label>
                                        <asp:Label ID="Label5" runat="server" CssClass="col-md-2 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Premium</asp:Label>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label22" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Physicians Assistant</asp:Label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPrimaryTN1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtRateTN1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt">25%</asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPremiumTN1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtQuantityTN1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotPremTN1" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label23" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Nurse Midwife</asp:Label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPrimaryTN2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtRateTN2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt">50%</asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPremiumTN2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtQuantityTN2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotPremTN2" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label24" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Nurse Anesthetist</asp:Label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPrimaryTN3" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtRateTN3" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt">75%</asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPremiumTN3" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtQuantityTN3" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotPremTN3" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label25" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Nurse Practitioner</asp:Label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPrimaryTN4" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtRateTN4" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt">20%</asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPremiumTN4" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtQuantityTN4" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotPremTN4" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label26" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">All Other Personel</asp:Label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPrimaryTN5" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtRateTN5" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt">10%</asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtPremiumTN5" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtQuantityTN5" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotPremTN5" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label27" runat="server" CssClass="col-md-3 col-form-labe label-vertical-align" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt">Total:</asp:Label>
                                        <div class="col-md-2">

                                        </div>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtRateTN6" runat="server" Font-Names="Tahoma" Font-Size="9pt" CssClass="form-control">100%</asp:TextBox>
                                        </div>
                                        <div class="col-md-2">

                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtQuantityTN6" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotPremTN6" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="mb-3 row">
                                        <asp:Label ID="Label13" runat="server" CssClass="col-md-10 col-form-labe label-vertical-align" Font-Names="Tahoma" Font-Size="9pt" Font-Bold="True" style="text-align: end;">Total Primary Corporate Premium:</asp:Label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtTotalPrimaryCorporate" runat="server" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt" MaxLength="20"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>








                        <%--EJC200--%>
                            <%--<asp:Panel ID="pnlPrimary" runat="server">
         </asp:Panel>--%>


                                <%-- contenido que va en Endorsement --%>
                                    <%--INIT EJC200 --%>
                                        <asp:CheckBox ID="chkUserModEndo" runat="server" Font-Names="Tahoma" Font-Size="9pt" Visible="False" />

                                        <asp:TextBox ID="txtEndorsementID" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="18px" MaxLength="75" TabIndex="24" Visible="False" Width="70px"></asp:TextBox>

                                        <asp:Button ID="btnHideEndoPanel" runat="server" BackColor="#400000" BorderColor="#400000" BorderStyle="Solid" BorderWidth="1px" CssClass="style22" Font-Names="Tahoma" ForeColor="White" Height="23px" onclick="btnHideEndoPanel_Click" tabIndex="72" Text="X"
                                            Visible="False" Width="25px" />
                                        <%--END EJC200 --%>


                                            <%-- contenido que va en Gap Dates --%>
                                                <%--INIT EJC200 --%>
                                                    <asp:Label ID="lblGapEndDate6" runat="server" CssClass="headfield1" EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px" Width="130px" Visible="False">Number Of Employees:</asp:Label>

                                                    <asp:TextBox ID="txtNumberOfEmployees" runat="server" Columns="30" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Height="18px" TabIndex="44" Width="79px" Visible="False"></asp:TextBox>
                                                    <%--END EJC200 --%>


                                                        <%-- contenido sin lugar definido --%>
                                                            <%--INIT EJC200 --%>
                                                                <asp:DropDownList ID="ddlAvailableAgent" runat="server" CssClass="headfield1" Font-Names="Arial" Font-Size="7.5pt" Height="19px" TabIndex="57" Visible="False" Width="128px">
                                                                </asp:DropDownList>
                                                                <%--END EJC200 --%>


                    </div>
                    <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                    <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>
                </div>
            </form>
            <script type="text/javascript">
                $('.datepicker-p1').datepicker();
            </script>

        </body>

        </html>
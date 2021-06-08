<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AHCCorporatePolicies.aspx.cs"
    Inherits="EPolicy.CorporatePolicyQuote" %>
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

            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

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

        </head>

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
                <table>
                    <p>
                        <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                    </p>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label21" runat="server">Corporate:</asp:Label>
                            <asp:Label ID="lblTCID" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:Button ID="btnConvertPrimary" runat="server" OnClick="btnConvertPrimary_Click" Text="Convert Primary" />
                            <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="Convert Excess" />
                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"></asp:Button>
                            <asp:button id="btnEnablePrint" tabIndex="71" runat="server" Text="Enable Print" onclick="btnEnablePrint_Click" onclientclick="return confirm('Enabling Policy Printing, Continue?');" />
                            <asp:Button ID="btnRenew" runat="server" OnClick="btnRenew_Click" Text="Renew" />
                            <asp:button id="btnReinstatement" runat="server" Text="Reinstatement" onclick="btnReinstatement_Click" />
                            <asp:Button ID="btnCancellation" runat="server" OnClick="btnCancellation_Click" Text="Cancellation" />
                            <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
                            <asp:Button ID="btnEdit" runat="server" Text="Modify" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" onclientclick="return confirm('Are you certain you want to delete this Policy?');" />
                            <asp:Button ID="btnAddNew" runat="server" Text="New" OnClick="btnAddNew_Click" />
                            <asp:Button ID="cmdCancel" runat="server" Text="Cancel" OnClick="cmdCancel_Click" />
                            <asp:Button ID="BtnExit" runat="server" Text="Exit" OnClick="BtnExit_Click" />
                            <asp:button id="btnComment" runat="server" onclick="btnComment_Click" text="Comment" />
                            <asp:Button ID="btnHistory" runat="server" OnClick="btnHistory_Click" Text="History" />
                            <asp:button id="btnEndor" runat="server" Text="New Endorsement" onclick="btnEndor_Click" />
                            <asp:Button ID="btnPayments" runat="server" OnClick="btnPayments_Click" Text="Payments" />
                            <asp:button id="btnComissions" runat="server" Text="Commissions" onclick="btnComissions_Click" />
                            <asp:button id="btnFinancialCanc" runat="server" Text="Financial Canc." onclick="btnFinancialCanc_Click" />
                            <asp:button id="btnTailQuote" runat="server" Text="Tail Quote" onclick="btnTailQuote_Click" />
                            <asp:Button ID="btnPrintCertificate" runat="server" Text="Print Certificate" OnClick="btnPrintCertificate_Click" />
                            <asp:button id="btnPolicyCert" runat="server" Text="Policy Cert." onclick="btnPolicyCert_Click" Visible="False" />
                        </div>
                    </div>
                    <tr>
                        <td style="font-size: 5pt; width: 112px; height: 191px" valign="middle">

                            <table id="Table6" style="width: 802px; height: 84px" width="802">
                                <tr>
                                    <td style="font-size: 1pt">
                                        <tr>
                                            <td>
                                                <asp:Panel runat="server" ID="pnlPolicy">
                                                    <table style="width: 739px;">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label42" runat="server" Width="167px">Corporate Information</asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblStatus" runat="server"></asp:Label>Inforce/</asp:Label>
                                                                <asp:CheckBox ID="chkPaymentGA" runat="server" Font-Size="Small" style="font-size: 9pt; font-family: Tahoma" Text="Checked Payment by GA" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label45" runat="server" Width="72px">Name</asp:Label>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="TxtFirstName" runat="server" MaxLength="200"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server">Agency</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAgency" runat="server" onselectedindexchanged="ddlAgency_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEmail" runat="server" Width="58px">Corp No.</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtCustomerNo" runat="server" MaxLength="10" TabIndex="1" Width="106px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPolicyNo" runat="server" Width="56px">Policy No.</asp:Label>
                                                                <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" AutoPostBack="True" OnCheckedChanged="ChkAutoAssignPolicy_CheckedChanged" TabIndex="19" Text=" " ToolTip="Auto Assign Policy" Width="1px" />
                                                            </td>
                                                            <td style="margin-left: 40px">
                                                                <asp:TextBox ID="TxtPolicyNo" runat="server" MaxLength="15" ontextchanged="TxtPolicyNo_TextChanged" />
                                                                <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="&lt;" Visible="False" />
                                                                <asp:Button ID="btnFoward" runat="server" onclick="btnFoward_Click" Text="&gt;" Visible="False" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblBranch" runat="server">Branch</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:dropdownlist id="ddlCity" RUNAT="server"></asp:dropdownlist>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label46" runat="server">Address 1</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtAddrs1" runat="server" MaxLength="60"></asp:TextBox>
                                                            </td>
                                                            <td style="height: 4px">
                                                                <asp:Label ID="lblCertificate" runat="server">Certificate</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtCertificate" runat="server" MaxLength="15"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label61" runat="server">Agent</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAgent" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label47" runat="server">Address 2</asp:Label>
                                                            </td>
                                                            <td class="style57">
                                                                <asp:TextBox ID="TxtAddrs2" runat="server" MaxLength="60"></asp:TextBox>
                                                            </td>
                                                            <td style="height: 4px">
                                                                <asp:Label ID="Label53" runat="server">Policy Type</asp:Label>
                                                            </td>
                                                            <td style="font-size: 11px; font-family: Tahoma">
                                                                <asp:TextBox ID="TxtPolicyType" runat="server" MaxLength="4"></asp:TextBox>
                                                                Suffix
                                                                <asp:TextBox ID="TxtSufijo" runat="server" MaxLength="2"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label62" runat="server">Originated At</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlOriginatedAt" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label48" runat="server">City</asp:Label>
                                                            </td>
                                                            <td class="style57">
                                                                <asp:TextBox ID="TxtCity" runat="server" MaxLength="14" TabIndex="8"></asp:TextBox>
                                                            </td>
                                                            <td style="height: 4px">
                                                                <asp:Label ID="Label54" runat="server" Width="76px">Anniversary</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtAnniversary" runat="server" MaxLength="2" Width="34px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label63" runat="server" Width="75px">Ins. Company</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlInsuranceCompany" runat="server" TabIndex="54">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style64">
                                                                <asp:Label ID="Label49" runat="server" Width="75px">Zip Code</asp:Label>
                                                            </td>
                                                            <td class="style63">
                                                                <asp:TextBox ID="TxtState" runat="server" MaxLength="2" Width="31px"></asp:TextBox>
                                                                <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" IsDate="False" IsZipCode="true" Mask="CCCCCC" MaxLength="10" TabIndex="10"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style64">
                                                                <asp:Label ID="Label55" runat="server" Width="44px">Term</asp:Label>
                                                            </td>
                                                            <td class="style64">
                                                                <asp:TextBox ID="TxtTerm" runat="server" MaxLength="3" TabIndex="43" Width="34px"></asp:TextBox>
                                                            </td>
                                                            <td class="style64">
                                                                <asp:Label ID="Label71" RUNAT="server">Group</asp:Label>
                                                            </td>
                                                            <td class="style64">
                                                                <asp:DropDownList ID="ddlGroup" RUNAT="server" tabIndex="55">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label64" runat="server">Corporation</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCorparation" runat="server" TabIndex="53" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblHomePhone" runat="server" CssClass="style40">Home Phone</asp:Label>
                                                            </td>
                                                            <td>
                                                                <MaskedInput:MaskedTextBox ID="txtHomePhone" onKeyDown="KeyDownHandler();" onkeyup="KeyDownHandler();" runat="server" IsDate="False" Mask="(999) 999-9999" MaxLength="20" TabIndex="12"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label56" runat="server">Retro. Date</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TxtRetroactiveDate" runat="server" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFinancial" runat="server" Width="44px">Financial</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFinancial" runat="server" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" TabIndex="53">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                <asp:Label ID="lblWorkPhone" runat="server" CssClass="style40">Work Phone</asp:Label>
                                                            </td>
                                                            <td class="style59">
                                                                <MaskedInput:MaskedTextBox ID="txtWorkPhone" runat="server" IsDate="False" Mask="(999) 999-9999" MaxLength="20" TabIndex="13"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="Label57" runat="server" Width="78px">Effective Date</asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:TextBox ID="txtEffDt" runat="server" onclick="ShowDateTimePicker();"></asp:TextBox>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="lblMainSpecialty" runat="server" Width="72px">Main Spec.</asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:DropDownList ID="ddlMainSpecialty" runat="server" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" TabIndex="53">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style1">
                                                                <asp:Label ID="Label50" runat="server">Cellular</asp:Label>
                                                            </td>
                                                            <td class="style59">
                                                                <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" IsDate="False" Mask="(999) 999-9999" MaxLength="20" TabIndex="14"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="Label58" runat="server" Width="65px">Exp. Date</asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:TextBox ID="txtExpDt" runat="server" IsDate="True" onclick="ShowDateTimePicker12();"></asp:TextBox>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:Label ID="lblOtherSpecialty" runat="server" Width="75px">Other Spec.</asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:DropDownList ID="ddlOtherSpecialtyA" runat="server" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" TabIndex="53">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label41" runat="server">E-mail</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" TabIndex="15"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label59" runat="server" Width="65px">Entry Date</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEntryDate" runat="server" IsDate="True" TabIndex="47"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblOtherSpecialty0" runat="server" Width="75px">Other Spec.</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlOtherSpecialtyB" runat="server" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" TabIndex="53">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style11">
                                                                <asp:Label ID="Label51" runat="server">License:</asp:Label>
                                                            </td>
                                                            <td class="style63">
                                                                <asp:TextBox ID="txtLicense" runat="server" MaxLength="25" TabIndex="15"></asp:TextBox>
                                                            </td>
                                                            <td class="style11">
                                                                <MaskedInput:MaskedTextBox ID="TxtUserPremium" RUNAT="server" AutoPostBack="True" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14" ontextchanged="TxtPremium_TextChanged" tabIndex="49" Visible="False" WIDTH="85px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style11">
                                                                <asp:CheckBox ID="chkUserMod" runat="server" Visible="False" />
                                                            </td>
                                                            <td class="style11">
                                                                <asp:Label ID="Label75" runat="server" Width="75px">Other Agent</asp:Label>
                                                            </td>
                                                            <td class="style11">
                                                                <asp:DropDownList ID="ddlAgent2" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblUpdateForm" runat="server">Update Form</asp:Label>
                                                            </td>
                                                            <td class="style58">
                                                                <asp:CheckBox ID="chkUpdateForm" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label60" runat="server" Width="44px">Charge</asp:Label>
                                                            </td>
                                                            <td>
                                                                <MaskedInput:MaskedTextBox ID="TxtCharge" runat="server" IsDate="False" Mask="CCCCCC" MaxLength="14" TabIndex="48"></MaskedInput:MaskedTextBox>
                                                                <asp:Button ID="btnCalcCharge" runat="server" OnClick="CalculateCharge" Text="Calculate" Width="80px" style="background-color: #ba354e; margin-right: 1px" />
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label77" runat="server">Has Claim?</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" style="font-size: 9pt" Width="154px">
                                                                    <asp:ListItem Value="0">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="1">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style55">
                                                                <asp:Label ID="lblLastName1" runat="server" Visible="False" Width="72px">Last Name 1</asp:Label>
                                                            </td>
                                                            <td class="style58">
                                                                <asp:TextBox ID="txtLastname1" runat="server" MaxLength="15" TabIndex="4" Visible="False"></asp:TextBox>
                                                            </td>
                                                            <td class="style55">
                                                                <asp:Label ID="lblPremum" runat="server" Width="75px">Premium</asp:Label>
                                                            </td>
                                                            <td class="style55">
                                                                <MaskedInput:MaskedTextBox ID="TxtPremium" runat="server" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49" Width="85px" ontextchanged="TxtPremium_TextChanged"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style55">
                                                                <asp:Label ID="lblClaimNo" runat="server">Claim No</asp:Label>
                                                            </td>
                                                            <td class="style55">
                                                                <asp:TextBox ID="txtClaimNumber" runat="server" IsDate="True" tabIndex="47" Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblLastName2" runat="server" Visible="False" Width="72px">Last Name 2</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtLastname2" runat="server" MaxLength="15" TabIndex="5" Visible="False"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:label id="lblPremium0" RUNAT="server">Canc. Amount</asp:label>
                                                            </td>
                                                            <td class="style1">
                                                                <MaskedInput:MaskedTextBox ID="TxtCancAmount" RUNAT="server" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14" tabIndex="49" WIDTH="85px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblComments" runat="server" Width="44px">Comments</asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label52" runat="server" Height="20px" Visible="False" Width="16px">Init.</asp:Label>
                                                                <asp:TextBox ID="TxtInitial" runat="server" MaxLength="1" TabIndex="3" Visible="False" Width="21px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="lblTotPremum" runat="server" Width="75px">Tot. Premium</asp:Label>
                                                            </td>
                                                            <td class="style1">
                                                                <MaskedInput:MaskedTextBox ID="TxtTotalPremium" runat="server" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49" Width="85px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td rowspan="5">
                                                                <asp:TextBox ID="TxtComments" runat="server" MaxLength="200" TabIndex="50" TextMode="MultiLine" Width="285px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblLastName3" runat="server" Width="113px">Prospect Number</asp:Label>
                                                            </td>
                                                            <td>
                                                                <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14" tabIndex="49" WIDTH="85px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td class="style1">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                PrP</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:Label ID="Label43" runat="server">Limit:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPrMedicalLimits" runat="server" AutoPostBack="false" onselectedindexchanged="ddlPrMedicalLimits_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td class="style61">
                                                                <asp:Label ID="lblGapEndDate5" runat="server">Gap Dates:</asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAvailableAgent" runat="server" Visible="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGapEndDate0" runat="server">From:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGapBegDate" runat="server" onclick="ShowDateTimePicker6();"></asp:TextBox>
                                                                <asp:Label ID="lblGapEndDate" runat="server">To:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGapEndDate" runat="server" onclick="ShowDateTimePicker7();"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="ddlSelectedAgent" runat="server" TabIndex="60" Width="205px"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGapEndDate1" runat="server">From:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGapBegDate2" runat="server" onclick="ShowDateTimePicker8();"></asp:TextBox>
                                                                <asp:Label ID="lblGapEndDate3" runat="server">To:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGapEndDate2" runat="server" onclick="ShowDateTimePicker9();"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGapEndDate2" runat="server">From:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGapBegDate3" runat="server" onclick="ShowDateTimePicker10();"></asp:TextBox>
                                                                <asp:Label ID="lblGapEndDate4" runat="server">To:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtGapEndDate3" runat="server" onclick="ShowDateTimePicker11();"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblGapEndDate6" runat="server" Visible="False">Number Of Employees:</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNumberOfEmployees" runat="server" Visible="False"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCarrier" runat="server">Excess Carrier Name</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label65" runat="server">Eff. Date</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label66" runat="server" Width="80px">Policy Limits</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label67" runat="server" Width="164px">Policy No. Other Company</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPriCarierName1" runat="server" MaxLength="75" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td width="310px">
                                                                <maskedinput:maskedtextbox id="txtPriPolEffecDate1" tabIndex="22" RUNAT="server" WIDTH="82px" ISDATE="True"></maskedinput:maskedtextbox>
                                                                <INPUT id="btnCalendar" style="WIDTH: 16px; HEIGHT: 21px" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.txtPriPolEffecDate1','calendar_window','width=250,height=250');calendar_window.focus()" tabIndex="23" type="button"
                                                                    value="..." name="btnCalendar" RUNAT="server">
                                                                <%-- <asp:TextBox ID="txtPriPolEffecDate1" runat="server" 
                                                                                 onclick="ShowDateTimePicker3();" TabIndex="25" 
                                                                                 Enabled="False"></asp:TextBox>--%>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPriPolLimits1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPriPolLimits1_SelectedIndexChanged"></asp:DropDownList>
                                                                <%--<asp:TextBox ID="txtPriPolLimits1" runat="server" 
                                                                                  
                                                                                Enabled="False"></asp:TextBox>--%>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPriClaims1" runat="server" Enabled="False" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Panel ID="pnlEndorsement" runat="server" Width="805px">
                                                                    <table style="width: 800px; height: 205px">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblEndorsement" runat="server" />Endorsements:</asp:Label>
                                                                            </td>
                                                                            <td>

                                                                                <asp:CheckBox ID="chkUserModEndo" runat="server" Visible="False" />

                                                                                <asp:TextBox ID="txtEndorsementID" runat="server" MaxLength="75" Visible="False"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnHideEndoPanel" runat="server" onclick="btnHideEndoPanel_Click" tabIndex="72" Text="X" Visible="False" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style46">
                                                                                <asp:Label ID="lblEndorsementNo" runat="server" />Endorsement No.:</asp:Label>
                                                                            </td>
                                                                            <td class="style35">
                                                                                <asp:Label ID="lblDatePrepared" runat="server" />Date Prepared:</asp:Label>
                                                                            </td>
                                                                            <td class="style35">
                                                                                <asp:Label ID="lblEndoEffDate" runat="server" />Endo. Eff. Date:</asp:Label>
                                                                            </td>
                                                                            <td class="style35">
                                                                                <asp:Label ID="lblEndoPremium" runat="server" />Endo. Premium:</asp:Label>
                                                                            </td>
                                                                            <td class="style35">
                                                                                <asp:Label ID="lblEndoType" runat="server" />Endorsement Type:</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style45">
                                                                                <asp:TextBox ID="txtEndorsementNo" runat="server" />
                                                                            </td>
                                                                            <td class="style45">
                                                                                <asp:TextBox ID="txtDatePrepared" runat="server" IsDate="True"></asp:TextBox>
                                                                            </td>
                                                                            <td class="style45">
                                                                                <asp:TextBox ID="txtEndoEffDate" runat="server" onclick="ShowDateTimePicker5();" />
                                                                            </td>
                                                                            <td class="style45">
                                                                                <asp:TextBox ID="txtEndoPremium" runat="server" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged" Width="85px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="style45">
                                                                                <asp:DropDownList ID="ddlEndoType" RUNAT="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style49" colspan="7">
                                                                                <asp:Label ID="lblEndoComments" runat="server">Comments:</asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="style52" colspan="7" style="text-align: center">
                                                                                <asp:TextBox ID="txtEndoComments" RUNAT="server" Height="120px" MAXLENGTH="2000" tabIndex="50" TextMode="MultiLine" WIDTH="735px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:Label ID="lblEndorsementHistory" runat="server">Endorsements:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="text-align: center">
                                                                <asp:DataGrid ID="dtEndorsement" runat="server" OnItemCommand="dtEndorsement_ItemCommand" onselectedindexchanged="dtEndorsement_SelectedIndexChanged">






                                                                    <Columns>
                                                                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">


                                                                        </asp:ButtonColumn>
                                                                        <asp:BoundColumn DataField="EndorsementID" HeaderText="Task No." Visible="False">

                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementNo" HeaderText="Endorse No.">


                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EntryDate" HeaderText="Date Prepared">
                                                                            <HeaderStyle Width="85px" />

                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EffectiveDate" HeaderText="Eff. Date">


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

                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementHistory" HeaderText="History" Visible="False">


                                                                        </asp:BoundColumn>
                                                                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">

                                                                        </asp:ButtonColumn>
                                                                        <asp:TemplateColumn HeaderText="Del.">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete" onclientclick="return confirm('Are you certain you want to delete this Endorsement?');" />
                                                                            </ItemTemplate>

                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle />
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <TR>
                                                            <br />
                                                            <br />
                                                            <img src="Images2/GreyLine.png" alt="" width="100%" height="6px" />
                                                        </TR>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel runat="server" ID="pnlHistory" Width="735px" style="text-align: center">
                                                    <table style="width: 739px;">
                                                        <tr>
                                                            <td class="style17">
                                                                <asp:Label ID="Label69" runat="server">History:</asp:Label>
                                                            </td>
                                                            <td width="140" class="style17">
                                                            </td>
                                                            <td class="style17">
                                                            </td>
                                                            <td class="style17">
                                                            </td>
                                                            <td class="style17">
                                                                <asp:Button ID="btnRefresh" runat="server" BorderWidth="0px" onclick="btnRefresh_Click" style="font-family: Tahoma" tabIndex="66" Text="Refresh" Visible="False" Width="93px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style16">
                                                                <asp:DataGrid ID="DtSearchPayments" runat="server" OnItemCommand="DtSearchPayments_ItemCommand1">






                                                                    <Columns>
                                                                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">


                                                                        </asp:ButtonColumn>
                                                                        <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No." Visible="False">

                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">


                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">


                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Certificate" HeaderText="Certificate" Visible="False">


                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Sufijo" HeaderText="Suffix">
                                                                            <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv.">
                                                                            <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">


                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">


                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="CComments" HeaderText="Comments">
                                                                            <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="250px" />

                                                                        </asp:BoundColumn>
                                                                    </Columns>
                                                                    <HeaderStyle />
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                            </td>
                                            <TR>
                                                <br />
                                                <br />
                                                <td>
                                                    <img src="Images2/GreyLine.png" alt="" width="900px" height="6px" />
                                                </td>
                                            </TR>

                                            </table>
                                            </asp:Panel>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td class="style11">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Width="78px">Corporation:</asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCorporation" runat="server" MaxLength="300" Width="241px"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label70" runat="server" Width="108px">Retroactive Date:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuoteRetroDate" runat="server" onclick="ShowDateTimePicker4();"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label74" runat="server" Width="49px" Visible="False">Agent:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlAgent0" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style17">
                                        </td>
                                        <td class="style17">
                                            <asp:label id="Label72" RUNAT="server" WIDTH="49px">Group:</asp:label>
                                        </td>
                                        <td class="style17">
                                            <asp:dropdownlist id="ddlGroup2" RUNAT="server" WIDTH="185px"></asp:dropdownlist>
                                        </td>
                                        <td class="style17">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style39">
                                        </td>
                                        <td class="style39">
                                        </td>
                                        <td class="style39">
                                        </td>
                                        <td class="style39">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style38">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Width="99px">Physician Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerName2" runat="server" MaxLength="75" TabIndex="4" Width="241px"></asp:TextBox>
                                        </td>
                                        <td class="style37">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 22px">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server">Primary Rate:</asp:Label>
                                        </td>
                                        <td height="26">
                                            <asp:DropDownList ID="ddlPrimaryLimits1" runat="server" AutoPostBack="True" Font-Size="8.5pt" OnSelectedIndexChanged="ddlPrimaryLimits1_SelectedIndexChanged" TabIndex="1" Width="136px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 22px">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server">Excess Rate:</asp:Label>
                                        </td>
                                        <td height="26">
                                            <asp:DropDownList ID="ddlLimits" runat="server" AutoPostBack="True" Font-Size="8.5pt" OnSelectedIndexChanged="ddlLimits_SelectedIndexChanged" TabIndex="1" Width="136px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 22px">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Width="64px">Specialty:</asp:Label>
                                        </td>
                                        <td height="26">
                                            <asp:DropDownList ID="ddlPolicyClass" runat="server" AutoPostBack="True" Font-Size="8.5pt" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1" TabIndex="1" Width="280px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 22px">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server">Iso Code:</asp:Label>
                                        </td>
                                        <td height="26">
                                            <asp:TextBox ID="txtIsoCode" runat="server" ReadOnly="True" TabIndex="8"></asp:TextBox>
                                        </td>
                                        <td style="width: 155px;" height="26">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 22px">
                                        </td>
                                        <td>
                                            <asp:Label ID="Label19" runat="server">Primary Mature Rate:</asp:Label>
                                        </td>
                                        <td height="26">
                                            <asp:TextBox ID="txtPRate4" runat="server" TabIndex="8"></asp:TextBox>
                                        </td>
                                        <td style="width: 155px;" height="26">
                                            <asp:Label ID="Label68" runat="server" Width="53px">Quantity:</asp:Label>
                                            <MaskedInput:MaskedTextBox ID="TxtAddQuantity" runat="server" IsDate="False" Mask="CC" MaxLength="2" TabIndex="49" Width="45px">1</MaskedInput:MaskedTextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 22px">
                                            <input id="txtPrateID" runat="server" name="txtPrateID" size="1" style="z-index: 102;
                                                                left: 432px; width: 35px; position: absolute; top: 1432px; Height:27px" type="hidden" value="0" />
                                            <input id="HIPrimeryRateID" runat="server" name="HIPrimeryRateID" size="1" style="z-index: 102;
                                                                left: 740px; width: 35px; position: absolute; top: 1626px; height: 27px" type="hidden" value="0" />
                                        </td>
                                        <td style="width: 186px; height: 22px" class="style32">
                                            <asp:Label ID="Label20" runat="server">Excess Mature Rate:</asp:Label>
                                        </td>
                                        <td height="26">
                                            <asp:TextBox ID="txtRate4" runat="server" TabIndex="8"></asp:TextBox>
                                        </td>
                                        <td style="width: 155px; text-align: center;" height="26">
                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add" Width="80px" TabIndex="10" style="background-color: #ba354e; margin-right: 1px" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td background="Images2/GreyLine.png" style="width: 186px; height: 1px">
                                        </td>
                                        <td style="width: 186px; height: 1px" background="Images2/GreyLine.png" colspan="3">
                                        </td>
                                        <td background="Images2/GreyLine.png" style="width: 186px; height: 1px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 186px; height: 12px">
                                        </td>
                                        <td style="width: 186px; height: 12px">
                                        </td>
                                        <td style="width: 162px; height: 12px">
                                            <asp:DropDownList ID="ddPrimarylPolicyClass" runat="server" AutoPostBack="True" TabIndex="1" Visible="False" Width="64px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 155px; height: 12px">
                                        </td>
                                        <td style="width: 168px; height: 12px">
                                        </td>
                                    </tr>
                            </table>
                        </td>
                        </tr>
                </table>
                <asp:DataGrid ID="DtGridCorpaoratePol" runat="server" OnItemCommand="DtGridCorpaoratePol_ItemCommand" onselectedindexchanged="DtGridCorpaoratePol_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Modify">

                        </asp:ButtonColumn>
                        <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No." Visible="False">

                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CustomerName" HeaderText="Physician Name">


                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PrimaryRate" HeaderText="Primary Rate">


                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ExcessRate" HeaderText="Excess Rate">


                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Specialty" HeaderText="Specialty">


                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IsoCode" HeaderText="Iso Code">


                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TotalPrimaryPremium" HeaderText="Primary Prem.">


                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TotalExcessPremium" HeaderText="Excess Prem.">


                        </asp:BoundColumn>
                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" HeaderText="Delete"></asp:ButtonColumn>
                        <asp:BoundColumn DataField="CorporatePolicyDetailQuoteID" HeaderText="CorporatePolicyDetailQuoteID" Visible="False"></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle />
                </asp:DataGrid>
                </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="Table2" style="width: 784px; height: 10px">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label73" runat="server" style="font-size: 10pt; margin-right: 10px" Text="Quantity:"></asp:Label>
                                    <asp:Label ID="lblQuantity" runat="server" style="font-size: 10pt" Text="0"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label40" runat="server">Primary Rate %:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscountP" runat="server" MaxLength="20">25%</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCorporatePolicyQuoteID" runat="server" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtERate1M_3M" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtERate150_200" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtERate250_500" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server">Excess Rate %:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscount" runat="server" MaxLength="20">15%</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtERate400_700" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtERate500_1M" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPRate" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Width="97px">Primary Premium:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalPrimaryPremium" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmployee1M_3M" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployee250_500" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Width="91px">Excess Premium</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalExcessPremium" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                </td>
                                <td class="style9">
                                </td>
                                <td class="style10">
                                </td>
                                <td class="style11">
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Calculate" style="background-color: #ba354e; margin-right: 1px" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td background="Images2/GreyLine.png" style="height: 1px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label7" runat="server" Width="209px">Primary - Technicians & Nurses</asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="pnlPrimary" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server">Primary</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Width="47px">Rate %</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server">Premium</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server">Quantity</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server">Premium</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label22" runat="server">Physicians Assistant</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrimaryTN1" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRateTN1" runat="server">25%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPremiumTN1" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantityTN1" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotPremTN1" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server">Nurse Midwife</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrimaryTN2" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRateTN2" runat="server">50%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPremiumTN2" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantityTN2" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotPremTN2" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label24" runat="server">Nurse Anesthetist</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrimaryTN3" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRateTN3" runat="server">75%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPremiumTN3" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantityTN3" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotPremTN3" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label25" runat="server">Nurse Practitioner</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrimaryTN4" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRateTN4" runat="server">20%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPremiumTN4" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantityTN4" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotPremTN4" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label26" runat="server">All Other Personel</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPrimaryTN5" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRateTN5" runat="server">10%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPremiumTN5" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantityTN5" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotPremTN5" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label27" runat="server">Total:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRateTN6" runat="server">100%</asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuantityTN6" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotPremTN6" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td background="Images2/GreyLine.png" height="1">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label39" runat="server">Excess - Technicians & Nurses</asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="pnlExcess" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label28" runat="server">Excess</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label29" runat="server" Width="49px">Rate %</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label30" runat="server">Premium</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label31" runat="server">Quantity</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label32" runat="server">Premium</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label33" runat="server">Physicians Assistant</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExcessTN1" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtERateTN1" runat="server">15%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEPremiumTN1" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEQuantityTN1" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtETotPremTN1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label34" runat="server">Nurse Midwife</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExcessTN2" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtERateTN2" runat="server">50%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEPremiumTN2" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEQuantityTN2" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtETotPremTN2" runat="server" H></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label35" runat="server">Nurse Anesthetist</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExcessTN3" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtERateTN3" runat="server">50%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEPremiumTN3" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEQuantityTN3" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtETotPremTN3" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label36" runat="server">Nurse Practitioner</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExcessTN4" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtERateTN4" runat="server">10%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEPremiumTN4" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEQuantityTN4" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtETotPremTN4" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label37" runat="server">All Other Personel</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtExcessTN5" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtERateTN5" runat="server">2.5%</asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEPremiumTN5" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEQuantityTN5" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtETotPremTN5" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label38" runat="server">Total:</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtERateTN6" runat="server">100%</asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEQuantityTN6" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtETotPremTN6" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Calculate" />
                                </td>
                            </tr>
                            <tr>

                                <td background="Images2/GreyLine.png">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server">Total Primary Corporate Premium:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalPrimaryCorporate" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <asp:Label ID="Label9" runat="server">Total Excess Corporate Premium:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotalExcessCorporate" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                    </tr>
                </tr>
                </tr>
                </table>
                </td>
                </tr>
                <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>
            </form>
        </body>

        </html>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AHCCorporateQuotes.aspx.cs"
    Inherits="EPolicy.AHCCorporateQuotes" %>
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
            <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>


            <style type="text/css">
                .style1 {
                    height: 14px;
                }
                
                .style2 {}
                
                .style3 {
                    width: 198px;
                }
                
                .style4 {
                    width: 310px;
                }
                
                .style5 {
                    width: 196px;
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
                
                .style65 {
                    width: 186px;
                    height: 26px;
                }
                
                .style66 {
                    text-align: right;
                    width: 186px;
                    height: 26px;
                }
                
                .style67 {
                    width: 162px;
                    height: 26px;
                }
                
                .style68 {
                    width: 168px;
                    height: 26px;
                }
            </style>

        </head>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $("#effect").hide();
            $(function() {
                $('#<%= txtExpDt.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowExpDt() {
                $('#<%= txtExpDt.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= TxtRetroactiveDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowRetroactiveDate() {
                $('#<%= TxtRetroactiveDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtEffDt.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowEffDt() {
                $('#<%= txtEffDt.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtEntryDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowEntryDate() {
                $('#<%= txtEntryDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtGapBegDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowGapBegDate() {
                $('#<%= txtGapBegDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtGapBegDate2.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowGapBegDate2() {
                $('#<%= txtGapBegDate2.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtGapBegDate3.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowGapBegDate3() {
                $('#<%= txtGapBegDate3.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtGapEndDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowGapEndDate() {
                $('#<%= txtGapEndDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtGapEndDate2.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowGapEndDate2() {
                $('#<%= txtGapEndDate2.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtGapEndDate3.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowGapEndDate3() {
                $('#<%= txtGapEndDate3.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowPriPolEffecDate1() {
                $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtEndoEffDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowEndoEffDate() {
                $('#<%= txtEndoEffDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtRetroEffDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function dpShowRetroEffDate() {
                $('#<%= txtRetroEffDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtQuoteRetroDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });


            function dpShowQuoteRetroDate() {
                $('#<%= txtQuoteRetroDate.ClientID %>').datepicker('show');
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

                //	    
                //        $("#btnRate").click(function() {
                //            runEffect();
                //            return false;
                //        });

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
                            <asp:Label ID="lblTCID" runat="server" Font-Size="10pt"></asp:Label>
                        </div>
                        <div class="col-md-8" style="text-align:right;">
                            <asp:Button ID="btnConvertPrimary" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnConvertPrimary_Click" Text="Convert Primary" />
                            <asp:Button ID="btnConvert" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnConvert_Click" Text="Convert Excess" Visible="False" />
                            <asp:Button ID="btnRate" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Rate" Visible="false" />
                            <asp:Button ID="btnPrint" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Print" OnClick="btnPrint_Click" />
                            <asp:button id="btnEnablePrint" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Enable Print" onclick="btnEnablePrint_Click" onclientclick="return confirm('Enabling Policy Printing, Continue?');" />
                            <asp:Button ID="btnRenew" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnRenew_Click" Text="Renew" />
                            <asp:button id="btnReinstatement" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Reinstatement" onclick="btnReinstatement_Click" />
                            <asp:Button ID="btnCancellation" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnCancellation_Click" Text="Cancellation" />
                            <asp:Button ID="BtnSave" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Save" OnClick="BtnSave_Click" />
                            <asp:Button ID="btnEdit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Modify" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnDelete_Click" Text="Delete" onclientclick="return confirm('Are you certain you want to delete this Policy?');" />
                            <asp:Button ID="btnAddNew" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="New" OnClick="btnAddNew_Click" />
                            <asp:Button ID="cmdCancel" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Cancel" OnClick="cmdCancel_Click" />
                            <asp:Button ID="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Exit" OnClick="BtnExit_Click" />
                            <asp:button id="btnComment" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" onclick="btnComment_Click" text="Comment" />
                            <asp:Button ID="btnHistory" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnHistory_Click" Text="History" />
                            <asp:button id="btnEndor" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="New Endorsement" onclick="btnEndor_Click" />
                            <asp:Button ID="btnPayments" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="btnPayments_Click" TabIndex="64" Text="Payments" />
                            <asp:button id="btnComissions" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Commissions" onclick="btnComissions_Click" />
                            <asp:button id="btnFinancialCanc" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Financial Canc." onclick="btnFinancialCanc_Click" />
                            <asp:button id="btnTailQuote" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Tail Quote" onclick="btnTailQuote_Click" />
                            <asp:Button ID="btnPrintCertificate" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Print Certificate" OnClick="btnPrintCertificate_Click" />
                            <asp:button id="btnPolicyCert" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" Text="Policy Cert." onclick="btnPolicyCert_Click" Visible="False" />
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div id="effect" class="ui-widget-header ui-corner-all f-center" style="width: 316px; background:BB1509; display: none;">
                        <div class="col-md-12">
                            <asp:Label ID="Label76" class="fw-bold" runat="server" Text="Select Rate" />
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="Label78" class="fs-lbl-s mb-1" runat="server" Text="Specialty:" />
                            <asp:DropDownList ID="ddlRate" class=" form-select fs-txt-s mb-1" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="col-mc-12">
                            <asp:Label ID="Label79" class="fs-lbl-s mb-1" runat="server" Text="Iso Code:" />
                            <asp:TextBox ID="TextBox1" class=" form-control fs-txt-s mb-1" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="Label80" class="fs-lbl-s mb-1" runat="server" Text="Class:" />
                            <asp:TextBox ID="txtClass" class=" form-control fs-txt-s mb-1" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label81" class="fs-lbl-s mb-1" runat="server" Text="Rate 1" />
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label82" class="fs-lbl-s mb-1" runat="server" Text="Rate 2" />
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label83" class="fs-lbl-s mb-1" runat="server" Text="Rate 3" />
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label84" class="fs-lbl-s mb-1" runat="server" Text="MCM Rate" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate1" class=" form-control fs-txt-s mb-1" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate2" class=" form-control fs-txt-s mb-1" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate3" class=" form-control fs-txt-s mb-1" runat="server" />
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TextBox2" class=" form-control fs-txt-s mb-1" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnCloseEffect" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 m-1" runat="server" Text="Close" />
                        </div>
                    </div>

                    <div runat="server" ID="pnlPolicy">
                        <div class="row">
                            <div class="col-md-8">
                                <asp:Label ID="Label42" class="fs-lbl-s mb-1" runat="server">Corporate Information</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="LblStatus" class="fs-lbl-s mb-1" runat="server">Inforce/</asp:Label>
                                <asp:CheckBox ID="chkPaymentGA" runat="server" Text="Checked Payment by GA" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label45" class="fs-lbl-s mb-1" runat="server">Name</asp:Label>
                            </div>
                            <div class="col-md-7">
                                <asp:TextBox ID="TxtFirstName" class=" form-control fs-txt-s mb-1" runat="server" MaxLength="200"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label1" class="fs-lbl-s mb-1" runat="server">Agency</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAgency" runat="server" class=" form-select fs-txt-s mb-1" onselectedindexchanged="ddlAgency_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblEmail" class="fs-lbl-s mb-1" runat="server">Corp No.</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtCustomerNo" class=" form-control fs-txt-s mb-1" runat="server" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblPolicyNo" class="fs-lbl-s mb-1" runat="server">Policy No.</asp:Label>
                                <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" AutoPostBack="True" OnCheckedChanged="ChkAutoAssignPolicy_CheckedChanged" Text=" " ToolTip="Auto Assign Policy" />
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtPolicyNo" class=" form-control fs-txt-s mb-1" runat="server" ontextchanged="TxtPolicyNo_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblBranch" class="fs-lbl-s mb-1" runat="server">Branch</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlCity" class=" form-select fs-txt-s mb-1" tabIndex="52" RUNAT="server"></asp:dropdownlist>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label46" class="fs-lbl-s mb-1" runat="server">Address 1</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtAddrs1" class=" form-control fs-txt-s mb-1" runat="server" MaxLength="60"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblCertificate" class="fs-lbl-s mb-1" runat="server">Certificate</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtCertificate" class=" form-control fs-txt-s mb-1" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label61" class="fs-lbl-s mb-1" runat="server">Agent</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAgent" class=" form-select fs-txt-s mb-1" runat="server" TabIndex="52"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label47" runat="server" class="fs-lbl-s mb-1">Address 2</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtAddrs2" runat="server" class=" form-select fs-txt-s mb-1" MaxLength="60"></asp:TextBox>

                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label53" runat="server" class="fs-lbl-s mb-1">Policy Type</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:TextBox ID="TxtPolicyType" class="fs-txt-s form-control mb-1" runat="server" MaxLength="4"></asp:TextBox>
                                    <span class="input-group-text fs-txt-s mb-1">
                                        Suffix
                                    </span>
                                    <asp:TextBox ID="TxtSufijo" class="fs-txt-s form-control mb-1" runat="server" MaxLength="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label62" runat="server" class="fs-lbl-s mb-1">Originated At</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlOriginatedAt" class="fs-txt-s form-select mb-1" runat="server" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label48" runat="server" class="fs-lbl-s mb-1">City</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtCity" runat="server" class="fs-txt-s form-control mb-1" MaxLength="14"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label54" runat="server" class="fs-lbl-s mb-1">Anniversary</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtAnniversary" class="fs-txt-s form-control mb-1" runat="server" MaxLength="2"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label63" runat="server" class="fs-lbl-s mb-1">Ins. Company</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlInsuranceCompany" class="fs-txt-s form-select mb-1" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label49" runat="server" class="fs-lbl-s mb-1">Zip Code</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:TextBox ID="TxtState" runat="server" class="fs-txt-s form-control mb-1" MaxLength="2"></asp:TextBox>
                                    <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" class="fs-txt-s form-control mb-1" IsDate="False" IsZipCode="true" Mask="CCCCCC" MaxLength="10"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label55" runat="server" class="fs-lbl-s mb-1">Term</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtTerm" runat="server" class="fs-txt-s form-control mb-1" MaxLength="3"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label71" RUNAT="server" class="fs-lbl-s mb-1">Group</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlGroup" RUNAT="server" class="fs-txt-s form-select mb-1"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblHomePhone" runat="server" class="fs-lbl-s mb-1 telefoneFormat">Home Phone</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="txtHomePhone" class="fs-txt-s form-control mb-1" onKeyDown="KeyDownHandler();" onkeyup="KeyDownHandler();" runat="server" IsDate="False" Mask="(999) 999-9999" MaxLength="20" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label56" runat="server" class="fs-lbl-s mb-1 fechaFormat">Retro. Date</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtRetroactiveDate" runat="server" class="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowRetroactiveDate();"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label64" runat="server" class="fs-lbl-s mb-1">Corporation</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlCorparation" runat="server" class="fs-txt-s form-select mb-1" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblWorkPhone" runat="server" class="fs-lbl-s mb-1">Work Phone</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="txtWorkPhone" class="fs-txt-s form-control mb-1 telefoneFormat" runat="server" IsDate="False" Mask="(999) 999-9999" MaxLength="20" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label57" runat="server" class="fs-lbl-s mb-1">Effective Date</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtEffDt" runat="server" class="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowEffDt();" />
                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="lblFinancial" runat="server" class="fs-lbl-s mb-1">Financial</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlFinancial" runat="server" class="fs-txt-s form-select mb-1" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label50" runat="server" class="fs-lbl-s mb-1">Cellular</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" class="fs-txt-s form-control mb-1 telefoneFormat" IsDate="False" Mask="(999) 999-9999" MaxLength="20" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label58" runat="server" class="fs-lbl-s mb-1">Exp. Date</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtExpDt" runat="server" class="fs-txt-s form-control mb-1 fechaFormat" IsDate="True" onclick="dpShowExpDt();"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblMainSpecialty" runat="server" class="fs-lbl-s mb-1">Main Spec.</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlMainSpecialty" runat="server" class="fs-txt-s form-select mb-1" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label41" runat="server" class="fs-lbl-s mb-1">E-mail</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtEmail" runat="server" class="fs-txt-s form-control mb-1" MaxLength="100" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label59" runat="server" class="fs-lbl-s mb-1">Entry Date</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtEntryDate" runat="server" class="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowEntryDate();" IsDate="True"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblOtherSpecialty" runat="server" class="fs-lbl-s mb-1">Other Spec.</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlOtherSpecialtyA" runat="server" class="fs-txt-s form-select mb-1" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" TabIndex="53"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label51" runat="server" class="fs-lbl-s mb-1">License:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtLicense" runat="server" class="fs-txt-s form-control mb-1" MaxLength="25"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="TxtUserPremium" RUNAT="server" class="fs-txt-s form-control mb-1" AutoPostBack="True" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14" ontextchanged="TxtPremium_TextChanged" Visible="False"></MaskedInput:MaskedTextBox>
                                <asp:CheckBox ID="chkUserMod" runat="server" class="fs-txt-s" Visible="False" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblOtherSpecialty0" runat="server" class="fs-lbl-s mb-1">Other Spec.</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlOtherSpecialtyB" runat="server" class="fs-txt-s form-select mb-1" OnSelectedIndexChanged="ddlCorparation_SelectedIndexChanged" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblUpdateForm" runat="server" class="fs-lbl-s mb-1">Update Form</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox ID="chkUpdateForm" runat="server" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label60" runat="server" class="fs-lbl-s mb-1">Charge</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <div class="input-group">
                                    <MaskedInput:MaskedTextBox ID="TxtCharge" class=" form-control fs-txt-s mb-1" runat="server" IsDate="False" Mask="CCCCCC" MaxLength="14" />
                                    <asp:Button ID="btnCalcCharge" runat="server" class="input-group-text fs-txt-s mb-1" OnClick="CalculateCharge" Text="Calculate" />
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label75" runat="server" class="fs-lbl-s mb-1">Other Agent</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAgent2" runat="server" class="fs-txt-s form-select mb-1" TabIndex="52" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblLastName3" runat="server" class="fs-lbl-s mb-1">Prospect Number</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" cssclass="fs-txt-s form-control mb-1" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14"></MaskedInput:MaskedTextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblPremum" runat="server" class="fs-lbl-s mb-1">Premium</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="TxtPremium" runat="server" class="fs-txt-s form-control mb-1" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" ontextchanged="TxtPremium_TextChanged"></MaskedInput:MaskedTextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblIsoCode" runat="server" class="fs-lbl-s mb-1">IsoCode</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Dropdownlist id="ddlIsoCode" RUNAT="server" class="fs-txt-s form-select mb-1" AutoPostBack="True" onselectedindexchanged="ddlIsoCode_SelectedIndexChanged" />
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblClaimNo" runat="server" class="fs-lbl-s mb-1">Claim No</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtClaimNumber" runat="server" cssclass="fs-txt-s form-control mb-1" IsDate="True" tabIndex="47"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label77" runat="server" class="fs-lbl-s mb-1">Has Claim?</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:RadioButtonList ID="rblClaim" runat="server" class="fs-lbl-s mb-1" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" style="font-size: 9pt" Width="154px">
                                    <asp:ListItem Value="0">Yes</asp:ListItem>
                                    <asp:ListItem Value="1">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblSpecialty" runat="server" class="fs-lbl-s mb-1">Specialty</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Dropdownlist id="ddlSpecialty" RUNAT="server" cssclass="fs-txt-s form-control mb-1" AutoPostBack="True" onselectedindexchanged="ddlSpecialty_SelectedIndexChanged"></asp:Dropdownlist>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblLastName1" runat="server" class="fs-lbl-s mb-1" Visible="False">Last Name 1</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtLastname1" runat="server" cssclass="fs-txt-s form-control mb-1" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblLastName2" runat="server" class="fs-lbl-s mb-1" Visible="False">Last Name 2</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtLastname2" runat="server" cssclass="fs-txt-s form-control mb-1" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label52" runat="server" class="fs-lbl-s mb-1" Visible="False">Init.</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="TxtInitial" runat="server" cssclass="fs-txt-s form-control mb-1" MaxLength="1" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:label id="lblPremium0" RUNAT="server" class="fs-lbl-s mb-1">Canc. Amount</asp:label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="TxtCancAmount" cssclass="fs-txt-s form-control mb-1" RUNAT="server" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC"></MaskedInput:MaskedTextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblTotPremum" runat="server" class="fs-lbl-s mb-1">Tot. Premium</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <MaskedInput:MaskedTextBox ID="TxtTotalPremium" runat="server" cssclass="fs-txt-s form-control mb-1" IsDate="False" Mask="CCCCCCCCCC"></MaskedInput:MaskedTextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label43" runat="server" class="fs-lbl-s mb-1">Limit:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlPrMedicalLimits" runat="server" cssclass="fs-txt-s form-select mb-1" AutoPostBack="false" onselectedindexchanged="ddlPrMedicalLimits_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="lblComments" runat="server" class="fs-lbl-s mb-1">Comments</asp:Label>
                            </div>
                            <div class="col-md-11">
                                <asp:TextBox ID="TxtComments" runat="server" cssclass="fs-txt-s form-control mb-1" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>

                        <div class="col-md-12 mb-2">
                            <asp:Label ID="lblGapEndDate5" runat="server">Gap Dates:</asp:Label>
                        </div>
                        <div class="row">
                            <div class="row col-md-4">
                                <div class="col-md-1">
                                    <asp:Label ID="lblGapEndDate0" runat="server" class="fs-lbl-s mb-1">From:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtGapBegDate" runat="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowGapBegDate();"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblGapEndDate" runat="server" class="fs-lbl-s mb-1">To:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtGapEndDate" runat="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowGapEndDate();"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblGapEndDate1" runat="server" class="fs-lbl-s mb-1">From:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtGapBegDate2" runat="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowGapBegDate2();"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblGapEndDate3" runat="server" class="fs-lbl-s mb-1">To:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtGapEndDate2" runat="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowGapEndDate2();"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblGapEndDate2" runat="server" class="fs-lbl-s mb-1">From:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtGapBegDate3" runat="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowGapBegDate3();"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblGapEndDate4" runat="server" class="fs-lbl-s mb-1">To:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtGapEndDate3" runat="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowGapEndDate3();"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlAvailableAgent" runat="server" Visible="False">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnBack" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" onclick="btnBack_Click" Text="&lt;" Visible="False" />
                                <asp:Button ID="btnFoward" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" onclick="btnFoward_Click" Text="&gt;" Visible="False" />
                            </div>
                            <div class="col-md-3">
                                <asp:ListBox ID="ddlSelectedAgent" runat="server" cssclass="form-control fs-txt-s"></asp:ListBox>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="lblGapEndDate6" runat="server" class="fs-lbl-s mb-1" Visible="False">Number Of Employees:</asp:Label>
                                <asp:TextBox ID="txtNumberOfEmployees" runat="server" Visible="False"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblCarrier" runat="server" class="fs-lbl-s mb-1">Previous Carrier Name</asp:Label>
                                <asp:TextBox ID="txtPriCarierName1" runat="server" cssclass="fs-txt-s form-control mb-1" MaxLength="75" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label65" runat="server" class="fs-lbl-s mb-1">Eff. Date</asp:Label>
                                <maskedinput:maskedtextbox id="txtPriPolEffecDate1" RUNAT="server" cssclass="fs-txt-s form-control mb-1 fechaFormat" onclick="dpShowPriPolEffecDate1();" ISDATE="True"></maskedinput:maskedtextbox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label66" runat="server" class="fs-lbl-s mb-1">Policy Limits</asp:Label>
                                <asp:DropDownList ID="ddlPriPolLimits1" runat="server" cssclass="fs-txt-s form-control mb-1" AutoPostBack="True" OnSelectedIndexChanged="ddlPriPolLimits1_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label67" runat="server" class="fs-lbl-s mb-1">Policy No. Other Company</asp:Label>
                                <asp:TextBox ID="txtPriClaims1" runat="server" cssclass="fs-txt-s form-control mb-1" MaxLength="50" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>

                        <div ID="pnlEndorsement" runat="server">
                            <div class="col-md-12 row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblEndorsement" runat="server" class="mb-2">Endorsements:</asp:Label>
                                    <asp:TextBox ID="txtEndorsementID" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="75" Visible="False"></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    <asp:Label ID="lblEndorsementNo" runat="server" class="fs-lbl-s mb-1">Endorsement No.:</asp:Label>
                                    <asp:TextBox ID="txtEndorsementNo" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="75"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblDatePrepared" runat="server" class="fs-lbl-s mb-1">Date Prepared:</asp:Label>
                                    <asp:TextBox ID="txtDatePrepared" runat="server" cssclass="form-control fs-txt-s mb-1" IsDate="True"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblEndoEffDate" runat="server" class="fs-lbl-s mb-1">Endo. Eff. Date:</asp:Label>
                                    <asp:TextBox ID="txtEndoEffDate" runat="server" cssclass="form-control fs-txt-s mb-1 fechaFormat" onclick="dpShowEndoEffDate();"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblEndoRetroDate" runat="server" class="fs-lbl-s mb-1">Endo. Retro. Date:</asp:Label>
                                    <asp:TextBox ID="txtRetroEffDate" runat="server" cssclass="form-control fs-txt-s mb-1 fechaFormat" onclick="dpShowRetroEffDate();"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblEndoPremium" runat="server" class="fs-lbl-s mb-1">Endo. Premium:</asp:Label>
                                    <asp:TextBox ID="txtEndoPremium" runat="server" cssclass="form-control fs-txt-s mb-1" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="lblEndoType" runat="server" class="fs-lbl-s mb-1">Endorsement Type:</asp:Label>
                                    <asp:DropDownList ID="ddlEndoType" RUNAT="server" cssclass="form-select fs-txt-s mb-1" />
                                </div>
                                <div class="col-md-12">
                                    <asp:CheckBox ID="chkUserModEndo" runat="server" Visible="False" />
                                    <asp:Button ID="btnHideEndoPanel" runat="server" onclick="btnHideEndoPanel_Click" Text="X" Visible="False" />
                                </div>
                                <div class="col-md-12">
                                    <asp:Label ID="lblEndoComments" runat="server" cssclass="fs-lbl-s mb-1">Comments:</asp:Label>
                                    <asp:TextBox ID="txtEndoComments" RUNAT="server" cssclass="form-control fs-txt-s mb-1" MAXLENGTH="2000" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="lblEndorsementHistory" runat="server">Endorsements:</asp:Label>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <asp:DataGrid ID="dtEndorsement" runat="server" OnItemCommand="dtEndorsement_ItemCommand" onselectedindexchanged="dtEndorsement_SelectedIndexChanged" class="table table-bordered table-condensed table-hover" Width="100%" AutoGenerateColumns="False" Font-Size="10pt"
                            CellPadding="4" ForeColor="#333333" AlternatingRowStyle-BackColor="White" ALLOWPAGING="True" PageSize="9">
                            <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                            <Columns>
                                <asp:ButtonColumn HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonColumn>
                                <asp:BoundColumn DataField="EndorsementID" HeaderText="Task No." Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EndorsementNo" HeaderText="Endorse No.">
                                    <HeaderStyle />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EntryDate" HeaderText="Date Prepared">
                                    <HeaderStyle />
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
                                        <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete" onclientclick="return confirm('Are you certain you want to delete this Endorsement?');" />
                                    </ItemTemplate>
                                    <HeaderStyle />
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid>
                    </div>

                    <div runat="server" ID="pnlHistory">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label69" runat="server">History:</asp:Label>
                            </div>
                            <div class="col-md-6 f-right">
                                <asp:Button ID="btnRefresh" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" onclick="btnRefresh_Click" Text="Refresh" Visible="False" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:DataGrid ID="DtSearchPayments" runat="server" OnItemCommand="DtSearchPayments_ItemCommand1" class="table table-bordered table-condensed table-hover" Width="100%" AutoGenerateColumns="False" Font-Size="10pt" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-BackColor="White"
                                ALLOWPAGING="True" PageSize="9">
                                <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:ButtonColumn HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                        <HeaderStyle Width="10%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" />
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
                                    <asp:BoundColumn DataField="CComments" HeaderText="Comments">
                                        <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="250px" />
                                        <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                            </asp:DataGrid>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="Label8" runat="server" cssclass="fs-lbl-s mb-1">Corporation:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCorporation" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label70" runat="server" cssclass="fs-lbl-s mb-1" Width="108px">Retroactive Date:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtQuoteRetroDate" runat="server" cssclass="form-control fs-txt-s mb-1 fechaFormat" onclick="dpShowQuoteRetroDate();"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label74" runat="server" cssclass="fs-lbl-s mb-1">Agent:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlAgent0" runat="server" cssclass="form-select fs-txt-s mb-1" TabIndex="52" />
                        </div>

                        <div class="col-md-2">
                            <asp:label id="Label72" RUNAT="server" cssclass="fs-lbl-s mb-1">Group:</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:dropdownlist id="ddlGroup2" RUNAT="server" cssclass="form-select fs-txt-s mb-1"></asp:dropdownlist>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label18" runat="server" cssclass="fs-lbl-s mb-1">Name:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCustomerName2" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="75" TabIndex="4"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label3" runat="server" cssclass="fs-lbl-s mb-1">Rate:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPrimaryLimits1" runat="server" cssclass="form-select fs-txt-s mb-1" AutoPostBack="True" OnSelectedIndexChanged="ddlPrimaryLimits1_SelectedIndexChanged" />
                        </div>

                        <div class="col-md-2">
                            <asp:Label Visible="false" ID="Label10" runat="server" cssclass="fs-lbl-s mb-1">Excess Rate:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlLimits" runat="server" cssclass="form-select fs-txt-s mb-1" AutoPostBack="True" OnSelectedIndexChanged="ddlLimits_SelectedIndexChanged" Visible="False"></asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label44" runat="server" cssclass="fs-lbl-s mb-1">Specialty:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddPrimarylPolicyClass" runat="server" cssclass="form-select fs-txt-s mb-1" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1" />
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label11" runat="server" cssclass="fs-lbl-s mb-1">Specialty:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPolicyClass" runat="server" cssclass="form-select fs-txt-s mb-1" AutoPostBack="True" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1" />
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label12" runat="server" cssclass="fs-lbl-s mb-1">Iso Code:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtIsoCode" runat="server" cssclass="form-control fs-txt-s mb-1" ReadOnly="True"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label19" runat="server" cssclass="fs-lbl-s mb-1">Mature Rate:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPRate4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label68" runat="server" cssclass="fs-lbl-s mb-1">Quantity:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtAddQuantity" runat="server" cssclass="form-control fs-txt-s mb-1" IsDate="False" Mask="CC" MaxLength="4">1</asp:TextBox>
                                <asp:Button ID="Button2" runat="server" CssClass="input-group-text fs-txt-s mb-1" OnClick="Button2_Click" Text="Add" />
                            </div>
                        </div>

                        <div class="col-md-2">
                            <asp:Label Visible="false" ID="Label20" runat="server" cssclass="fs-lbl-s mb-1">Excess Mature Rate:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtRate4" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-12 f-center">
                        </div>
                    </div>

                    <input id="txtPrateID" runat="server" name="txtPrateID" size="1" style="z-index: 102;
                                                                left: 432px; width: 35px; position: absolute; top: 1432px; height: 22px" type="hidden" value="0" />
                    <input id="HIPrimeryRateID" runat="server" name="HIPrimeryRateID" size="1" style="z-index: 102;
                                                                left: 740px; width: 35px; position: absolute; top: 1626px; height: 22px" type="hidden" value="0" />

                    <asp:DataGrid ID="DtGridCorpaoratePol" runat="server" OnItemCommand="DtGridCorpaoratePol_ItemCommand" onselectedindexchanged="DtGridCorpaoratePol_SelectedIndexChanged" class="table table-bordered table-condensed table-hover" Width="100%" AutoGenerateColumns="False"
                        Font-Size="10pt" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-BackColor="White" ALLOWPAGING="True" PageSize="9">
                        <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Modify">
                                <HeaderStyle />
                                <ItemStyle />
                            </asp:ButtonColumn>
                            <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No." Visible="False">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CustomerName" HeaderText="Physician Name">
                                <HeaderStyle Width="140px" />
                                <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PrimaryRate" HeaderText="Primary Rate">
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Right" Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ExcessRate" HeaderText="Excess Rate" Visible="False">
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Specialty" HeaderText="Specialty">
                                <HeaderStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="140px" />
                                <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IsoCode" HeaderText="Iso Code">
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TotalPrimaryPremium" HeaderText="Primary Prem.">
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TotalExcessPremium" HeaderText="Excess Prem." Visible="False">
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" HeaderText="Delete"></asp:ButtonColumn>
                            <asp:BoundColumn DataField="CorporatePolicyDetailQuoteID" HeaderText="CorporatePolicyDetailQuoteID" Visible="False"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                        <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                    </asp:DataGrid>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row">
                        <div class="col-md-1">
                            <asp:Label ID="Label73" runat="server" cssclass="fs-lbl-s mb-1 fw-bold" Text="Quantity:"></asp:Label>
                            <asp:Label ID="lblQuantity" runat="server" cssclass="fs-lbl-s mb-1 fw-bold" Text="0"></asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label40" cssclass="fs-lbl-s mb-1" runat="server">Rate %:</asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtDiscountP" cssclass="form-control fs-txt-s mb-1" runat="server" MaxLength="20">25%</asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtERate1M_3M" cssclass="form-control fs-txt-s mb-1" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtERate150_200" cssclass="form-control fs-txt-s mb-1" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtERate250_500" cssclass="form-control fs-txt-s mb-1" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-1">
                            <asp:Label ID="Label16" runat="server" cssclass="fs-lbl-s mb-1" Visible="False">Excess Rate %:</asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtDiscount" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False">15%</asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtERate400_700" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtERate500_1M" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtPRate" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-1">
                            <asp:Label ID="Label17" runat="server" cssclass="fs-lbl-s mb-1" Width="97px">Premium:</asp:Label>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtTotalPrimaryPremium" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtEmployee1M_3M" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtEmployee250_500" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-md-auto"></div>

                    </div>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtCorporatePolicyQuoteID" runat="server" Visible="False"></asp:TextBox>
                    </div>
                    <asp:Label ID="Label15" runat="server" Width="91px" Visible="False">Excess Premium</asp:Label>
                    <asp:TextBox ID="txtTotalExcessPremium" runat="server" MaxLength="20" Visible="False"></asp:TextBox>
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-2">
                            <asp:Button ID="Button4" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="Button4_Click" Text="Calculate" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div runat="server" id="Section1">
                        <div class="col-md-12">
                            <asp:Label ID="Label7" cssclass="fs-lbl-s fw-bold" runat="server">Primary - Technicians & Nurses</asp:Label>
                        </div>
                        <asp:Panel ID="pnlPrimary" runat="server">
                            <div class="row">
                                <div class="col-md-3">

                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label2" cssclass="fs-lbl-s mb-1" runat="server">Primary</asp:Label>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label4" cssclass="fs-lbl-s mb-1" runat="server">Rate %</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label14" cssclass="fs-lbl-s mb-1" runat="server">Premium</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label6" cssclass="fs-lbl-s mb-1" runat="server">Quantity</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label5" cssclass="fs-lbl-s mb-1" runat="server">Premium</asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label22" cssclass="fs-lbl-s mb-1" runat="server">Physicians Assistant</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPrimaryTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRateTN1" runat="server" cssclass="form-control fs-txt-s mb-1">25%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPremiumTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtQuantityTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTotPremTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label23" cssclass="fs-lbl-s mb-1" runat="server">Nurse Midwife</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPrimaryTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRateTN2" runat="server" cssclass="form-control fs-txt-s mb-1">50%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPremiumTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtQuantityTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTotPremTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label24" cssclass="fs-lbl-s mb-1" runat="server">Nurse Anesthetist</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPrimaryTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRateTN3" runat="server" cssclass="form-control fs-txt-s mb-1">75%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPremiumTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtQuantityTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTotPremTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label25" cssclass="fs-lbl-s mb-1" runat="server">Nurse Practitioner</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPrimaryTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRateTN4" runat="server" cssclass="form-control fs-txt-s mb-1">20%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPremiumTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtQuantityTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTotPremTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label26" cssclass="fs-lbl-s mb-1" runat="server">All Other Personel</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPrimaryTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRateTN5" runat="server" cssclass="form-control fs-txt-s mb-1">10%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtPremiumTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtQuantityTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTotPremTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label27" runat="server" cssclass="fs-lbl-s mb-1">Total:</asp:Label>
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtRateTN6" runat="server" cssclass="form-control fs-txt-s mb-1">100%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtQuantityTN6" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtTotPremTN6" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="col-md-12">
                            <asp:Label ID="Label39" cssclass="fs-lbl-s fw-bold" runat="server">Excess - Technicians & Nurses</asp:Label>
                        </div>
                        <asp:Panel ID="pnlExcess" runat="server">
                            <div class="row mb-3">
                                <div class="col-md-3"></div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label28" cssclass="fs-lbl-s mb-1" runat="server">Excess</asp:Label>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="Label29" cssclass="fs-lbl-s mb-1" runat="server">Rate %</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label30" cssclass="fs-lbl-s mb-1" runat="server">Premium</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label31" cssclass="fs-lbl-s mb-1" runat="server">Quantity</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label32" cssclass="fs-lbl-s mb-1" runat="server">Premium</asp:Label>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label33" cssclass="fs-lbl-s mb-1" runat="server">Physicians Assistant</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtExcessTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtERateTN1" runat="server" cssclass="form-control fs-txt-s mb-1">15%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEPremiumTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEQuantityTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtETotPremTN1" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label34" cssclass="fs-lbl-s mb-1" runat="server">Nurse Midwife</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtExcessTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtERateTN2" runat="server" cssclass="form-control fs-txt-s mb-1">50%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEPremiumTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEQuantityTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtETotPremTN2" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label35" cssclass="fs-lbl-s mb-1" runat="server">Nurse Anesthetist</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtExcessTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtERateTN3" runat="server" cssclass="form-control fs-txt-s mb-1">50%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEPremiumTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEQuantityTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtETotPremTN3" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label36" cssclass="fs-lbl-s mb-1" runat="server">Nurse Practitioner</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtExcessTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtERateTN4" runat="server" cssclass="form-control fs-txt-s mb-1">10%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEPremiumTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEQuantityTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtETotPremTN4" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label37" cssclass="fs-lbl-s mb-1" runat="server">All Other Personel</asp:Label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtExcessTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtERateTN5" runat="server" cssclass="form-control fs-txt-s mb-1">2.5%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEPremiumTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEQuantityTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtETotPremTN5" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label38" cssclass="fs-lbl-s mb-1" runat="server">Total:</asp:Label>
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtERateTN6" runat="server" cssclass="form-control fs-txt-s mb-1">100%</asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtEQuantityTN6" cssclass="form-control fs-txt-s mb-1" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtETotPremTN6" runat="server" cssclass="form-control fs-txt-s mb-1"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="col-md-12 f-right">
                            <asp:Button ID="Button3" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-1" OnClick="Button3_Click" Text="Calculate" />
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <div class="row">
                            <div class="col-md-8"></div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label13" runat="server" cssclass="fs-lbl-s mb-1">Total Premium:</asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTotalPrimaryCorporate" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label9" runat="server" cssclass="fs-lbl-s mb-1" Visible="False">Total Excess Corporate Premium:</asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTotalExcessCorporate" runat="server" cssclass="form-control fs-txt-s mb-1" MaxLength="20" Visible="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                    </div>
                    <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>
            </form>
        </body>

        </html>
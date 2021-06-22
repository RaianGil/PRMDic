<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AHCPrimaryQuotes.aspx.cs" Inherits="AHCPrimaryQuotes" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>

        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <html>

        <head>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script src="js/load.js" type="text/javascript"></script>
            <style type="text/css">
                .toggler {
                    width: 276px;
                    height: 16px;
                }
                
                #button {
                    padding: .5em 2em;
                    text-decoration: none;
                }
                
                #btnCloseEffect {
                    text-decoration: none;
                }
                
                #effect h3 {
                    margin: 0;
                    padding: 0.4em;
                    text-align: center;
                }
                
                .ui-effects-transfer {
                    border: 2px dotted gray;
                }
            </style>
            <style type="text/css">
                #jq-books {
                    width: 200px;
                    float: right;
                    margin-right: 0
                }
                
                #jq-books li {
                    line-height: 1.25em;
                    margin: 1em 0 1.8em;
                    clear: left
                }
                
                #home-content-wrapper #jq-books a.jq-bookImg {
                    float: left;
                    margin-right: 10px;
                    width: 55px;
                    height: 70px
                }
                
                #jq-books h3 {
                    margin: 0 0 .2em 0
                }
                
                #home-content-wrapper #jq-books h3 a {
                    font-size: 1em;
                    color: black;
                }
                
                #home-content-wrapper #jq-books a.jq-buyNow {
                    font-size: 1em;
                    color: white;
                    display: block;
                    background: url(http://static.jquery.com/files/rocker/images/btn_blueSheen.gif) 50% repeat-x;
                    text-decoration: none;
                    color: #fff;
                    font-weight: bold;
                    padding: .2em .8em;
                    float: left;
                    margin-top: .2em;
                }
            </style>
            <script>
                function parseRate() {
                    var myString;
                    //for(i = 1;i <= document.form1.ddlPolicyClass.options.length ; i++)
                    //{
                    //myString = document.form1.ddlPolicyClass.options[1].value;
                    myString = document.form1.ddlPolicyClass.options[document.form1.ddlPolicyClass.selectedIndex].value;
                    var myRateList = myString.split("|");
                    //alert(myRateList[0]+"-"+myRateList[1])

                    document.form1.txtPrateID.value = myRateList[0];
                    document.form1.HIIsoCode.value = myRateList[1];
                    document.form1.HIClass.value = myRateList[2];
                    document.form1.HIRate1.value = myRateList[3];
                    document.form1.HIRate2.value = myRateList[4];
                    document.form1.HIRate3.value = myRateList[5];
                    document.form1.HIRate4.value = myRateList[6];

                    document.form1.txtIsoCode.value = myRateList[1];
                    document.form1.txtClass.value = myRateList[2];
                    document.form1.txtRate1.value = myRateList[3];
                    document.form1.txtRate2.value = myRateList[4];
                    document.form1.txtRate3.value = myRateList[5];
                    document.form1.txtRate4.value = myRateList[6];
                    //              for(a = 0;a < myRateList.lenght; a++)
                    //              {
                    //                var Rate1 = myRateList[a];
                    //                var startPos = Rate1.indexOf(',');
                    //                var myValue = Rate1.substring(startPos, Rate1.lenght -startPos);
                    //                //alert(myValue);
                    //                document.form1.txtIsoCode.value = myValue;
                    //              }
                    //}
                }
            </script>
        </head>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $(function() {
                $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtPriPolEffecDate2.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtPriPolEffecDate3.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtExcPolEffecDate1.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtExcPolEffecDate2.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtExcPolEffecDate3.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtDateBirth.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtPrimaryRetroDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
                $('#<%= txtExcessRetroDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function ShowDateTimePicker() {
                $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker2() {
                $('#<%= txtPriPolEffecDate2.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker3() {
                $('#<%= txtPriPolEffecDate3.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker4() {
                $('#<%= txtExcPolEffecDate1.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker5() {
                $('#<%= txtExcPolEffecDate2.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker6() {
                $('#<%= txtExcPolEffecDate3.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker7() {
                $('#<%= txtDateBirth.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker8() {
                $('#<%= txtPrimaryRetroDate.ClientID %>').datepicker('show');
            }


            //style="width: 316px; display:none"

            function pageLoad() {
                //sets initial state of the contactfinderdiv
                //alert(jQuery('#HIState').val());
                var state = jQuery('#HIState').val();
                if (state == '1') {
                    $('#effect').css('display', 'block');
                    //$('#HIState').val('');
                } else {
                    $('#effect').css('display', 'none');
                }

                $('.btnRate').click(function() {
                    $('.togglebox').show('slow');
                });

                $('.btnCloseEffect').click(function() {
                    $('.togglebox').hide('slow');
                });
            }
            $(function() {


                //run the currently selected effect
                function runEffect() {
                    //get effect type from 
                    //var selectedEffect = $('#effectTypes').val();
                    $('#HIState').val('1');
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
                            $('#HIState').val('0');
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

        <body onload="pageLoad()">
            <form id="form1" runat="server">

                <p>
                    <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="Label21" runat="server">Application:</asp:Label>
                            <asp:Label ID="lblTaskControlID" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button ID="btnConvert" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Convert Excess" OnClick="btnConvert_Click" Visible="True" />
                            <asp:Button ID="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Print Quote" OnClick="btnPrint_Click" Visible="True" />
                            <asp:Button ID="btnConvertPrimary" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Convert Policy" OnClick="btnConvertPrimary_Click" />
                            <asp:Button ID="btnRate" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Rate" />
                            <asp:Button ID="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" OnClick="BtnSave_Click" Text="Save" />
                            <asp:Button ID="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Modify" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Delete" OnClick="btnDelete_Click" />
                            <asp:Button ID="btnCancel" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Cancel" OnClick="btnCancel_Click" />
                            <asp:Button ID="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" Text="Exit" OnClick="BtnExit_Click" />
                        </div>
                    </div>
                    <div id="effect" class="col-md-4 ui-widget-header ui-corner-all f-center p-1" aling="right" style="background:BB1509;width: 375px; height:auto;">
                        <div class="col-md-4 mb-1">
                            <asp:Label ID="Label49" runat="server" class="fs-14 fw-bold" Text="Select Rate"></asp:Label>
                        </div>
                        <div class="col-md-12 mb-1">
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="Primary" AutoPostBack="True" />
                            <asp:RadioButton ID="RadioButton2" runat="server" Text="Excess" AutoPostBack="True" />
                        </div>
                        <div class="col-md-12 mb-1">
                            <asp:Label ID="Label51" runat="server" class="fs-lbl-s" Text="Primary Retro Date:"></asp:Label>
                        </div>
                        <div class="col-md-12 mb-1">
                            <MaskedInput:MaskedTextBox ID="txtPrimaryRetroDate" class="form-control fs-txt-s" runat="server" AutoPostBack="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="col-md-12 mb-1">
                            <asp:Label ID="Label56" runat="server" class="fs-lbl-s" Text="Excess Retro Date:"></asp:Label>
                        </div>
                        <div class="col-md-12 mb-1">
                            <MaskedInput:MaskedTextBox ID="txtExcessRetroDate" class="form-control fs-txt-s" runat="server" IsDate="True" AutoPostBack="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="row mb-1">
                            <div class="col-md-3">
                                <asp:Label ID="Label42" runat="server" class="fs-lbl-s" Text="Rate 1"></asp:Label>

                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label43" runat="server" class="fs-lbl-s" Text="Rate 2"></asp:Label>

                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label45" runat="server" class="fs-lbl-s" Text="Rate 3"></asp:Label>

                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label44" runat="server" class="fs-lbl-s" Text="MCM Rate "></asp:Label>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:Label ID="Label63" runat="server" class="fs-lbl-s" Text="Primary  Rate"></asp:Label>
                            </div>

                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlPrimaryLimits1" runat="server" class="form-select fs-txt-s" OnSelectedIndexChanged="ddlPrimaryLimits1_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtPRate1" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtPRate2" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtPRate3" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtPRate4" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:Label ID="Label64" runat="server" class="fs-lbl-s" Text="Excess Rate"></asp:Label>
                            </div>

                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlLimits" runat="server" class="form-select fs-txt-s" OnSelectedIndexChanged="ddlLimits_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate1" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate2" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate3" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate4" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:Label ID="Label62" runat="server" class="fs-lbl-s" Text="Others Excess Rates:"></asp:Label>
                            </div>

                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlLimits2" runat="server" class="form-select fs-txt-s" OnSelectedIndexChanged="ddlLimits_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate12" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate22" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate32" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate42" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlLimits3" runat="server" class="form-select fs-txt-s" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate13" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate23" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate33" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate43" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlLimits4" runat="server" class="form-select fs-txt-s" OnSelectedIndexChanged="ddlLimits4_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate14" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate24" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate34" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate44" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlLimits5" runat="server" class="form-select fs-txt-s" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate15" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate25" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate35" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate45" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>

                        <div class="row mb-1">
                            <div class="col-md-12 mb-1">
                                <asp:DropDownList ID="ddlLimits6" runat="server" class="form-select fs-txt-s" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate16" runat="server" placeholder="Rate 1" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate26" runat="server" placeholder="Rate 2" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate36" runat="server" placeholder="Rate 3" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtRate46" runat="server" placeholder="MCM Rate" class="form-control fs-txt-s" TabIndex="8"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="Label41" runat="server" class="fs-lbl-s" Text="Select Specialty:"></asp:Label>
                        </div>
                        <div class="col-md-12 mb-1">
                            <asp:DropDownList ID="ddlPolicyClass" runat="server" class="form-select fs-txt-s" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-12 mb-1">
                            <asp:DropDownList ID="ddPrimarylPolicyClass" runat="server" class="form-select fs-txt-s" AutoPostBack="True" OnSelectedIndexChanged="ddPrimarylPolicyClass_SelectedIndexChanged" Visible="False">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="Label46" runat="server" class="fs-lbl-s" Text="Iso Code:"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtIsoCode" runat="server" class="form-control fs-txt-s" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="Label47" runat="server" class="fs-lbl-s" Text="Class:"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox ID="txtClass" runat="server" class="form-control fs-txt-s" ReadOnly="True"></asp:TextBox>
                        </div>
                        <div class="col-md-12 f-center">
                            <asp:Button ID="btnCloseEffect" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 m-1" Text="Close" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    </asp:Panel>
                    <div class="col-md-12 mb-3">
                        <asp:Label ID="Label2" runat="server">I. PERSONAL INFORMATION</asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label54" class="fs-lbl-s" runat="server" EnableViewState="False">*</asp:Label>
                                    <asp:Label ID="lblGender" class="fs-lbl-s" runat="server" EnableViewState="False">Name:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtFirstName" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblLastName2" class="fs-lbl-s" runat="server" EnableViewState="False">Middle:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtInitial" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblBirthdate" class="fs-lbl-s" runat="server" EnableViewState="False">LastName:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLastname1" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label55" class="fs-lbl-s" runat="server" EnableViewState="False">*</asp:Label>
                                    <asp:Label ID="Label4" class="fs-lbl-s" runat="server" EnableViewState="False">LastName 2:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLastname2" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblMaritalStatus" class="fs-lbl-s" runat="server" EnableViewState="False">Date of Birth:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <MaskedInput:MaskedTextBox ID="txtDateBirth" runat="server" class="form-control mb-1 fs-txt-s fechaFormat" onclick="ShowDateTimePicker7();" IsDate="True"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblComments" class="fs-lbl-s" runat="server" EnableVi ewState="False">Place of Birth:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtBirthPlace" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblHouseIncome" class="fs-lbl-s" runat="server">Gender:</asp:Label>
                                </div>
                                <div class="col-md-8 mb-1">
                                    <asp:RadioButtonList ID="rdoGender" runat="server" class="fs-lbl-s" RepeatDirection="Horizontal">
                                        <asp:ListItem>Female</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label1" class="fs-lbl-s" runat="server" EnableViewState="False">Customer No.:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtCustomerNo" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label50" class="fs-lbl-s" runat="server" EnableViewState="False">Status:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlStatus" class="form-select mb-1 fs-txt-s" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label52" class="fs-lbl-s" runat="server" EnableViewState="False">Agency:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlAgency" runat="server" class="form-select mb-1 fs-txt-s">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label48" class="fs-lbl-s" runat="server">Comments:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" class="form-control mb-1 fs-txt-s w-260 h-6"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-6">

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label53" class="fs-lbl-s" runat="server" EnableViewState="False">Agent:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlAgent" runat="server" class="form-select mb-1 fs-txt-s">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label6" class="fs-lbl-s" runat="server">Office Address:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtAddrs1" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">

                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtAddrs2" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label7" class="fs-lbl-s" runat="server">City:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <div class="input-group mb-1">
                                        <asp:TextBox ID="TxtCity" runat="server" class="form-control fs-txt-s"></asp:TextBox>
                                        <asp:TextBox ID="TxtState" runat="server" class="form-control fs-txt-s"></asp:TextBox>
                                        <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" class="form-control fs-txt-s" IsDate="False" Mask="99999Z9999" MaxLength="10"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label59" runat="server" class="fs-lbl-s" EnableViewState="False">*</asp:Label>
                                    <asp:Label ID="Label3" runat="server" class="fs-lbl-s" EnableViewState="False">Office Phone:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <MaskedInput:MaskedTextBox ID="txtWorkPhone" class="form-control mb-1 fs-txt-s telefoneFormat" runat="server" IsCurrency="False" IsDate="False" IsZipCode="False" Mask="(999) 999-9999" MaxLength="14"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblLastName1" runat="server" class="fs-lbl-s" EnableViewState="False">Office Fax:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" class="form-control mb-1 fs-txt-s telefoneFormat" IsCurrency="False" IsDate="False" IsZipCode="False" Mask="(999) 999-9999" MaxLength="14"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label5" runat="server" class="fs-lbl-s" EnableViewState="False">E-mail:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label61" runat="server" class="fs-lbl-s" EnableViewState="False">*</asp:Label>
                                    <asp:Label ID="Label8" runat="server" class="fs-lbl-s" EnableViewState="False">Cell Phone:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <MaskedInput:MaskedTextBox ID="txtHomePhone" runat="server" class="form-control mb-1 fs-txt-s telefoneFormat" IsCurrency="False" IsDate="False" IsZipCode="False" Mask="(999) 999-9999" MaxLength="14"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="Label151" runat="server" class="fs-lbl-s">License:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLicense" runat="server" MaxLength="25" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>

                    <asp:Label ID="lblSocialSecurity" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="False">Social Security:</asp:Label>
                    <MaskedInput:MaskedTextBox ID="txtSocialSecurity" runat="server" class="form-control mb-1 fs-txt-s" IsCurrency="False" IsDate="False" IsZipCode="False" Mask="999-99-9999" Visible="false"></MaskedInput:MaskedTextBox>
                    <asp:Button ID="btnNextTop" runat="server" Text="Next >" OnClick="btnNextTop_Click" Visible="False" />

                    <div class="col-md-12 mb-3">
                        <asp:Label ID="lblTypeAddress1" runat="server">II. INSURANCE HISTORY</asp:Label>
                    </div>
                    <p>
                        <asp:Label ID="Label15" runat="server">2. Please provide the necessary information below with respect to your primary insurance coverage for</asp:Label>
                        <asp:Label ID="Label17" runat="server">the last three years, including the coverage in force as of the date of this application.</asp:Label>
                    </p>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label18" runat="server" class="fs-lbl-s" EnableViewState="False">Previous Carrier Name</asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label14" runat="server" class="fs-lbl-s" EnableViewState="False">Policy Effective Dates</asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label19" runat="server" class="fs-lbl-s" EnableViewState="False">Policy Limits</asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label20" runat="server" class="fs-lbl-s" EnableViewState="False">Policy No. Other Company</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriCarierName1" runat="server" MaxLength="75" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriPolEffecDate1" runat="server" onclick="ShowDateTimePicker();" class="form-control mb-1 fs-txt-s"></asp:TextBox>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriPolLimits1" runat="server" MaxLength="50" class="form-control mb-1 fs-txt-s"></asp:TextBox>

                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriClaims1" runat="server" MaxLength="50" class="form-control mb-1 fs-txt-s"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriCarierName2" runat="server" MaxLength="75" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <MaskedInput:MaskedTextBox ID="txtPriPolEffecDate2" runat="server" class="form-control mb-1 fs-txt-s" onclick="ShowDateTimePicker2();" IsDate="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriPolLimits2" runat="server" MaxLength="50" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriClaims2" runat="server" MaxLength="50" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriCarierName3" runat="server" MaxLength="75" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <MaskedInput:MaskedTextBox ID="txtPriPolEffecDate3" runat="server" class="form-control mb-1 fs-txt-s" onclick="ShowDateTimePicker3();" IsDate="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriPolLimits3" runat="server" MaxLength="50" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtPriClaims3" runat="server" MaxLength="50" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Label ID="Label28" runat="server" Visible="True">3. Please provide the necessary information below with respect to your excess professional liability</asp:Label>
                    <asp:Label ID="Label29" runat="server" Visible="True">insurance coverage for the last three years, including the coverage in force as of the date of this application.</asp:Label>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label31" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Excess Carrier Name</asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label32" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Policy Effective Dates</asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label33" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Policy Limits</asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="Label34" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Claims-Made Form or Occurrence Form</asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcCarierName1" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate1" runat="server" class="form-control mb-1 fs-txt-s" onclick="ShowDateTimePicker4();" Visible="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcPolLimits1" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcClaims1" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcCarierName2" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate2" runat="server" class="form-control mb-1 fs-txt-s" onclick="ShowDateTimePicker5();" IsDate="True" Visible="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcPolLimits2" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcClaims2" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcCarierName3" runat="server" isible="False" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate3" runat="server" class="form-control mb-1 fs-txt-s" onclick="ShowDateTimePicker6();" IsDate="True" Visible="True"></MaskedInput:MaskedTextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcPolLimits3" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtExcClaims3" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <p>
                            <asp:Label ID="Label16" runat="server" Visible="True">4. Has any insurance company (including Lloyd's of London) ever cancelled, declines to issued,</asp:Label>
                            <asp:Label ID="Label23" runat="server" Visible="True">refused to renew, surcharged your premium or issued coverage with any restrictions or exclusions?</asp:Label>
                            <asp:Label ID="Label24" runat="server" Visible="True">If Yes, please explain fully in the below Section.</asp:Label>
                        </p>
                        <asp:RadioButtonList ID="rdoMcaInsuranceCia" class="fs-lbl-s" runat="server" RepeatDirection="Horizontal" Visible="True">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="Label37" runat="server" EnableViewState="False"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtInsuranceCiaDesc" runat="server" TextMode="MultiLine" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md-12">
                        <asp:Label ID="Label9" runat="server" Visible="True">III. MEDICAL EDUCATION AND TRAINING</asp:Label>
                    </div>
                    <asp:Label ID="Label10" runat="server" Visible="True">3. Education</asp:Label>
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-2">
                            <asp:Label ID="Label13" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">School/Hospital</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label22" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">City/State/Country</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label26" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">From/To</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label25" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Degree/Type</asp:Label>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label12" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Medical School</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtMedSchool" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtMedCity" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtMedFrom" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtMedDegree" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label27" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Internship</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtIntSchool" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtIntCity" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtIntFrom" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtIntDegree" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label30" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Residency</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtResSchool" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtResCity" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtResFrom" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtResDegree" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label35" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Fellowship</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtFellSchool" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtFellCity" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtFellFrom" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtFellDegree" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label ID="Label36" runat="server" class="fs-lbl-s" EnableViewState="False" Visible="True">Other Training</asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtOSchool" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtOCity" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtOFrom" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtODegree" runat="server" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdfPrimaryLimit" runat="server" />
                    <asp:HiddenField ID="hdfLimit" runat="server" />
                    <p>
                        <asp:Label ID="Label11" runat="server" Visible="True">6. If you are a graduate of a non-U.S. medical school, are you certified by the Educational</asp:Label>
                        <asp:Label ID="Label38" runat="server" Visible="True">Commission for Foreign Medical School Graduates?</asp:Label>
                    </p>
                    <asp:RadioButtonList ID="rdoMcaCertified" runat="server" class="fs-lbl-s" RepeatDirection="Horizontal" Visible="True">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                    <p>
                        <asp:Label ID="Label39" runat="server" Visible="True">7. Did you complete residency training?</asp:Label>
                        <asp:Label ID="Label40" runat="server" Visible="True">If "No", please explain in Remarks Section.</asp:Label>
                    </p>
                    <asp:RadioButtonList ID="rdoMcaResTraining" runat="server" class="fs-lbl-s" RepeatDirection="Horizontal" Visible="True">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                    <div class="col-md-12">
                        <asp:TextBox ID="txtResidency" runat="server" TextMode="MultiLine" Visible="True" class="form-control mb-1 fs-txt-s"></asp:TextBox>
                        <asp:Button ID="btnNextBottom" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Next >" OnClick="btnNextBottom_Click" Visible="True" />
                    </div>



                    <p><input id="HIState" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 912px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" />
                    </p>


                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                    <asp:Literal ID="litPopUp" runat="server" Visible="True"></asp:Literal>
                    <input id="txtPrateID" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" /><input id="txtPrate2ID" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1468px;
                height: 22px" type="hidden" value="0" />
                    <input id="txtPrate3ID" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="txtPrate4ID" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="txtPrate5ID" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="txtPrate6ID" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" />
                    <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1" style="z-index: 102; left: 856px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="false" /><input id="HIIsoCode" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" /><input id="HIIsoCode2" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1468px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIIsoCode3" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIIsoCode4" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIIsoCode5" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIIsoCode6" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIClass" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 532px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIClass2" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 532px; width: 35px; position: absolute; top: 1468px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIClass3" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIClass4" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIClass5" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIClass6" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate1" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate12" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1468px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate13" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate14" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate15" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate16" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate2" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate22" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1468px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate23" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate24" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate25" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate26" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate3" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate32" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1468px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate33" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate34" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate35" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate36" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate4" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1432px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate42" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1464px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate43" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1500px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate44" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1528px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate45" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1560px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIRate46" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1592px;
                height: 22px" type="hidden" value="0" /><input id="HIPrimeryRateID" runat="server" name="HIPrimeryRateID" size="1" style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1626px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIrimeryRate4" runat="server" name="HIrimeryRate4" size="1" style="z-index: 102; left: 694px; width: 35px; position: absolute; top: 1626px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIrimeryRate3" runat="server" name="HIrimeryRate3" size="1" style="z-index: 102; left: 647px; width: 35px; position: absolute; top: 1626px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIrimeryRate2" runat="server" name="HIrimeryRate2" size="1" style="z-index: 102; left: 594px; width: 35px; position: absolute; top: 1626px;
                height: 22px" type="hidden" value="0" />
                    <input id="HIrimeryRate1" runat="server" name="HIrimeryRate1" size="1" style="z-index: 102; left: 544px; width: 35px; position: absolute; top: 1626px;
                height: 22px" type="hidden" value="0" />
                </div>
            </form>
        </body>


        </html>
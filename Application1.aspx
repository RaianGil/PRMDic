<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application1.aspx.cs" Inherits="Application1" %>
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
                
                #effect {
                    width: 455px;
                    height: auto;
                    padding: 0.4em;
                    position: relative;
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
                
                .style4 {
                    width: 147px;
                }
                
                .style5 {
                    height: 46px;
                    width: 147px;
                }
                
                .style6 {
                    height: 17px;
                    width: 147px;
                }
                
                .style7 {
                    height: 19px;
                    width: 147px;
                }
                
                .style8 {
                    width: 46px;
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
                <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                    <div class="row">
                        <div class="col-md-4" style="align-self:center;">
                            <asp:Label ID="Label21" runat="server" CssClass="fs-14 fw-bold">Application:</asp:Label>
                            <asp:Label ID="lblTaskControlID" runat="server" CssClass="fs-14 fw-bold"></asp:Label>
                        </div>
                        <div class="col-md-8" style="text-align:right;">
                            <%--Se movieron los botones Convert Primary y Convert Excess--%>
                                <asp:Button ID="btnConvert" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" Text="Convert Excess" OnClick="btnConvert_Click" />

                                <asp:Button ID="btnPrint" runat="server" Text="Print Quote" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" OnClick="btnPrint_Click" />


                                <asp:Button ID="btnConvertPrimary" runat="server" Text="Convert Primary" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" OnClick="btnConvertPrimary_Click" />

                                <asp:Button ID="btnRate" runat="server" Text="Rate" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                                <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" Text="Save" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                                <asp:Button ID="btnEdit" runat="server" Text="Modify" OnClick="btnEdit_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                                <asp:Button ID="BtnExit" runat="server" Text="Exit" OnClick="BtnExit_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" />
                        </div>
                        <div class="col-md-12">
                            <div id="effect" class="col-md-4 ui-widget-header ui-corner-all f-center" aling="right" style="background:BB1509;width: 375px; height:auto;">
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

                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                        <div class="row">
                            <asp:Label ID="Label2" runat="server" CssClass="fs-11 fw-bold">I. Personal Information</asp:Label>
                            <div class="col-md-4">
                                <div class="mb-3 row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblGender" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align">Name: Dr (a).:</asp:Label>
                                        <asp:Label ID="Label54" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align" ForeColor="Red">*</asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="TxtFirstName" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="lblLastName2" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Middle:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="TxtInitial" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-3">
                                        <asp:Label ID="lblBirthdate" runat="server" EnableViewState="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">LastName:</asp:Label>
                                        <asp:Label ID="Label55" runat="server" EnableViewState="False" ForeColor="Red" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">*</asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtLastname1" CSSCLASS="form-control fs-txt-s" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label4" runat="server" EnableViewState="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">LastName2:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtLastname2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="lblMaritalStatus" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Date of Birth:</asp:Label>
                                    <div class="col-md-9">
                                        <MaskedInput:MaskedTextBox ID="txtDateBirth" runat="server" onclick="ShowDateTimePicker7();" CSSCLASS="form-control fs-txt-s fechaFormat" IsDate="True"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="mb-3 row">
                                    <asp:Label ID="Label1" runat="server" EnableViewState="False" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Customer No.:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="TxtCustomerNo" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label50" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Status:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlStatus" runat="server" CSSCLASS="form-select fs-txt-s">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label52" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Agency:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlAgency" runat="server" CSSCLASS="form-select fs-txt-s">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label53" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Agent:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlAgent" runat="server" CSSCLASS="form-select fs-txt-s">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="mb-3 row">
                                    <asp:Label ID="lblComments" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Place of Birth:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtBirthPlace" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="col-md-4">

                                <div class="mb-3 row">
                                    <asp:Label ID="lblHouseIncome" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Gender:</asp:Label>

                                    <div class="col-md-9" style="height:29.2px; height: 29.2px; position: relative; top: 6px;">
                                        <asp:RadioButtonList ID="rdoGender" runat="server" CssClass="fs-lbl-s" RepeatDirection="Horizontal">
                                            <asp:ListItem>Female</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label6" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Office Address:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="TxtAddrs1" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label57" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Address 2:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="TxtAddrs2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="Label7" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">City:</asp:Label>

                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <asp:TextBox ID="TxtCity" runat="server" CSSCLASS="form-control fs-txt-s" Width="50%" style="float:left"></asp:TextBox>
                                            <asp:TextBox ID="TxtState" runat="server" CSSCLASS="form-control fs-txt-s" Width="20%" style="float:left"></asp:TextBox>
                                            <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" IsDate="False" Width="30%" CSSCLASS="form-control fs-txt-s" Mask="99999Z9999" MaxLength="10"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-3 ">
                                        <asp:Label ID="Label3" runat="server" EnableViewState="False" CssClass="col-form-labe fs-lbl-s label-vertical-align">Office Phone:</asp:Label>
                                        <asp:Label ID="Label59" runat="server" EnableViewState="False" CssClass="col-form-labe fs-lbl-s label-vertical-align" ForeColor="Red">*</asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <MaskedInput:MaskedTextBox ID="txtWorkPhone" runat="server" IsCurrency="False" IsDate="False" CSSCLASS="form-control fs-txt-s telefoneFormat" IsZipCode="False" Mask="(999) 999-9999" MaxLength="14"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <div class="mb-3 row">
                                    <asp:Label ID="Label48" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align">Comments:</asp:Label>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtComments" CssClass="form-control fs-txt-s" RUNAT="server" Width="100%" Height="157px" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="mb-3 row">
                                    <div class="col-md-3">
                                        <asp:Label ID="Label8" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align">Cell Phone:</asp:Label>
                                        <asp:Label ID="Label61" runat="server" EnableViewState="False" ForeColor="Red" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align telefoneFormat">*</asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <MaskedInput:MaskedTextBox ID="txtHomePhone" runat="server" IsCurrency="False" IsDate="False" CSSCLASS="form-control fs-txt-s telefoneFormat" IsZipCode="False" Mask="(999) 999-9999" MaxLength="14"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>

                                <div class="mb-3 row">
                                    <asp:Label ID="Label151" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">License:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtLicense" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="mb-3 row">
                                    <asp:Label ID="Label5" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">E-mail:</asp:Label>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtEmail" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <asp:Label ID="lblLastName1" runat="server" EnableViewState="False" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Office Fax:</asp:Label>
                                    <div class="col-md-9">
                                        <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server" IsCurrency="False" CSSCLASS="form-control fs-txt-s telefoneFormat" IsDate="False" IsZipCode="False" Mask="(999) 999-9999" MaxLength="14"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <hr />
                        <div class="row">
                            <asp:Label ID="lblTypeAddress1" runat="server" CssClass="fs-11 fw-bold">II. Insurance History</asp:Label>
                            <asp:Label ID="Label15" runat="server" CssClass="fs-11">2. Please provide the necessary information below with respect to your primary insurance coverage for the last three years, including the coverage in force as of the date of this application.</asp:Label>
                            <asp:Label ID="Label17" runat="server" CssClass="fs-11 fw-bold"></asp:Label>
                            <div class="col-md-3" style="margin-top:8px;">
                                <asp:Label ID="Label18" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align">Primary Carrier Name</asp:Label>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriCarierName1" runat="server" MaxLength="75" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriCarierName2" runat="server" MaxLength="75" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriCarierName3" runat="server" MaxLength="75" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3" style="margin-top:8px;">
                                <asp:Label ID="Label14" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align">Policy Effective Dates</asp:Label>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriPolEffecDate1" runat="server" onclick="ShowDateTimePicker();" CSSCLASS="form-control fs-txt-s fechaFormat"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <MaskedInput:MaskedTextBox ID="txtPriPolEffecDate2" runat="server" onclick="ShowDateTimePicker2();" IsDate="True" CSSCLASS="form-control fs-txt-s fechaFormat"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <MaskedInput:MaskedTextBox ID="txtPriPolEffecDate3" runat="server" onclick="ShowDateTimePicker3();" IsDate="True" CSSCLASS="form-control fs-txt-s fechaFormat"></MaskedInput:MaskedTextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3" style="margin-top:8px;">
                                <asp:Label ID="Label19" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align">Policy Limits</asp:Label>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriPolLimits1" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriPolLimits2" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriPolLimits3" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-3" style="margin-top:8px;">
                                <asp:Label ID="Label20" runat="server" EnableViewState="False" CSSCLASS="col-form-labe fs-lbl-s label-vertical-align">Policy No. Other Company</asp:Label>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriClaims1" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriClaims2" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3 row">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtPriClaims3" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>































                        <asp:Label ID="Label28" runat="server" CssClass="headform3" Visible="False">3. Please provide the necessary information below with respect to your excess professional liability</asp:Label>

                        <asp:Label ID="Label29" runat="server" Visible="False">insurance coverage for the last three years, including the coverage in force as of the date of this application.</asp:Label>

                        <asp:Label ID="Label31" runat="server" EnableViewState="False" Visible="False">Excess Carrier Name</asp:Label>

                        <asp:Label ID="Label32" runat="server" EnableViewState="False" Visible="False">Policy Effective Dates</asp:Label>

                        <asp:Label ID="Label33" runat="server" EnableViewState="False" Visible="False">Policy Limits</asp:Label>

                        <asp:Label ID="Label34" runat="server" EnableViewState="False" Visible="False">Claims-Made Form or Occurrence Form</asp:Label>

                        <asp:TextBox ID="txtExcCarierName1" runat="server" Visible="False"></asp:TextBox>


                        <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate1" runat="server" onclick="ShowDateTimePicker4();" IsDate="True" Visible="False"></MaskedInput:MaskedTextBox>

                        <asp:TextBox ID="txtExcPolLimits1" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtExcClaims1" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtExcCarierName2" runat="server" Visible="False"></asp:TextBox>

                        <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate2" runat="server" onclick="ShowDateTimePicker5();" IsDate="True" Visible="False"></MaskedInput:MaskedTextBox>

                        <asp:TextBox ID="txtExcPolLimits2" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtExcClaims2" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtExcCarierName3" runat="server" Visible="False"></asp:TextBox>

                        <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate3" runat="server" onclick="ShowDateTimePicker6();" IsDate="True" Visible="False"></MaskedInput:MaskedTextBox>

                        <asp:TextBox ID="txtExcPolLimits3" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtExcClaims3" runat="server" Visible="False"></asp:TextBox>



                        <asp:Label ID="lblSocialSecurity" runat="server" EnableViewState="False" Visible="False">Social Security:</asp:Label>

                        <MaskedInput:MaskedTextBox ID="txtSocialSecurity" runat="server" IsCurrency="False" IsDate="False" IsZipCode="False" Mask="999-99-9999" Visible="False"></MaskedInput:MaskedTextBox>





                        <asp:Button ID="btnNextTop" runat="server" Text="Next >" OnClick="btnNextTop_Click" Visible="False" />


                        <asp:Label ID="Label16" runat="server" Visible="False">4. Has any insurance company (including Lloyd's of London) ever cancelled, declines to issued,</asp:Label>
                        <asp:Label ID="Label23" runat="server" Visible="False">refused to renew, surcharged your premium or issued coverage with any restrictions or exclusions?</asp:Label>
                        <asp:Label ID="Label24" runat="server" Visible="False">If Yes, please explain fully in the below Section.</asp:Label>


                        <asp:RadioButtonList ID="rdoMcaInsuranceCia" runat="server" RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>

                        <asp:TextBox ID="txtInsuranceCiaDesc" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>

                        <asp:Label ID="Label37" runat="server" EnableViewState="False"></asp:Label>

                        <asp:Label ID="Label9" runat="server" Visible="False">III. MEDICAL EDUCATION AND TRAINING</asp:Label>

                        <asp:Label ID="Label10" runat="server" Visible="False">3. Education</asp:Label>

                        <asp:Label ID="Label13" runat="server" EnableViewState="False" Visible="False">School/Hospital</asp:Label>

                        <asp:Label ID="Label22" runat="server" EnableViewState="False" Visible="False">City/State/Country</asp:Label>

                        <asp:Label ID="Label26" runat="server" EnableViewState="False" Visible="False">From/To</asp:Label>

                        <asp:Label ID="Label25" runat="server" EnableViewState="False" Visible="False">Degree/Type</asp:Label>


                        <asp:Label ID="Label12" runat="server" EnableViewState="False" Visible="False">Medical School</asp:Label>

                        <asp:TextBox ID="txtMedSchool" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtMedCity" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtMedFrom" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtMedDegree" runat="server" Visible="False"></asp:TextBox>

                        <asp:Label ID="Label27" runat="server" EnableViewState="False" Visible="False">Internship</asp:Label>

                        <asp:TextBox ID="txtIntSchool" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtIntCity" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtIntFrom" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtIntDegree" runat="server" Visible="False"></asp:TextBox>


                        <asp:Label ID="Label30" runat="server" EnableViewState="False" Visible="False">Residency</asp:Label>

                        <asp:TextBox ID="txtResSchool" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtResCity" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtResFrom" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtResDegree" runat="server" Visible="False"></asp:TextBox>


                        <asp:Label ID="Label35" runat="server" EnableViewState="False" Visible="False">Fellowship</asp:Label>

                        <asp:TextBox ID="txtFellSchool" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtFellCity" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtFellFrom" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtFellDegree" runat="server" Visible="False"></asp:TextBox>


                        <asp:Label ID="Label36" runat="server" EnableViewState="False" Visible="False">Other Training</asp:Label>

                        <asp:TextBox ID="txtOSchool" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtOCity" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtOFrom" runat="server" Visible="False"></asp:TextBox>

                        <asp:TextBox ID="txtODegree" runat="server" Visible="False"></asp:TextBox>

                        <asp:Label ID="Label11" runat="server" Visible="False">6. If you are a graduate of a non-U.S. medical school, are you certified by the Educational</asp:Label>
                        <asp:Label ID="Label38" runat="server" Visible="False">Commission for Foreign Medical School Graduates?</asp:Label>

                        <asp:RadioButtonList ID="rdoMcaCertified" runat="server" RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>


                        <asp:Label ID="Label39" runat="server" Visible="False">7. Did you complete residency training?</asp:Label>
                        <asp:Label ID="Label40" runat="server" Visible="False">If "No", please explain in Remarks Section.</asp:Label>


                        <asp:RadioButtonList ID="rdoMcaResTraining" runat="server" RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>


                        <asp:TextBox ID="txtResidency" runat="server" TextMode="MultiLine" Visible="False"></asp:TextBox>


                        <asp:Button ID="btnNextBottom" runat="server" Text="Next >" OnClick="btnNextBottom_Click" Visible="False" />




                        <p><input id="HIState" runat="server" name="txtPrateID" size="1" style="z-index: 102; left: 912px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
                        </p>

                    </div>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                    <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
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
                </div>
                </div>
                </div>
            </form>

        </body>

        </html>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" AutoEventWireup="true" Inherits="EPolicy.FirstDollarPolicies" CodeFile="FirstDollarPolicies.aspx.cs" %>
        <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
            <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
            <html>

            <head>
                <title>ePMS | electronic Policy Manager Solution</title>
                <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0" />
                <meta name="CODE_LANGUAGE" Content="C#" />
                <meta name="vs_defaultClientScript" content="JavaScript" />
                <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
                <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                <script src="js/load.js" type="text/javascript"></script>
                <style type="text/css">
                    .toggler {
                        height: 1px;
                        margin-left: 0px;
                    }
                    
                    #button {
                        padding: .5em 2em;
                        text-decoration: none;
                    }
                    
                    #btnCloseEffect {
                        text-decoration: none;
                    }
                    
                    #effect {
                        width: 315px;
                        height: 228px;
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
                    
                    .headfield1 {
                        text-align: left;
                        margin-left: 0px;
                        margin-right: 0px;
                    }
                    
                    .style1 {
                        width: 8px;
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
                    
                    .style8 {
                        width: 8px;
                        height: 9px;
                    }
                    
                    .style9 {
                        width: 106px;
                        height: 9px;
                    }
                    
                    .style10 {
                        width: 198px;
                        height: 9px;
                    }
                    
                    .style11 {
                        width: 310px;
                        height: 9px;
                    }
                    
                    .style12 {
                        width: 196px;
                        height: 9px;
                    }
                    
                    .style13 {
                        width: 100px;
                        height: 9px;
                    }
                    
                    .style14 {
                        height: 9px;
                    }
                    
                    .style15 {
                        height: 18px;
                        width: 284px;
                    }
                    
                    .style16 {
                        height: 15px;
                        width: 284px;
                    }
                    
                    .style17 {
                        height: 21px;
                        width: 284px;
                    }
                    
                    .style18 {
                        height: 20px;
                        width: 284px;
                    }
                    
                    .style19 {
                        height: 17px;
                        width: 284px;
                    }
                    
                    .style20 {
                        height: 13px;
                        width: 284px;
                    }
                    
                    .style21 {
                        height: 3px;
                        width: 284px;
                    }
                    
                    .style22 {
                        font-size: 9pt;
                        margin-right: 1px;
                        margin-left: 0px;
                    }
                    
                    .style23 {
                        height: 3px;
                        width: 19px;
                    }
                    
                    .style24 {
                        width: 19px;
                    }
                    
                    .style25 {
                        height: 358px;
                        width: 19px;
                    }
                    
                    .style26 {
                        height: 13px;
                        width: 19px;
                    }
                    
                    .style27 {
                        height: 27px;
                        width: 19px;
                    }
                    
                    .style35 {
                        height: 22px;
                    }
                    
                    .style36 {
                        width: 97px;
                        height: 22px;
                    }
                    
                    .style38 {
                        height: 21px;
                    }
                    
                    .headForm1 {
                        margin-right: 2px;
                    }
                    
                    .style43 {
                        height: 19px;
                        width: 218px;
                    }
                    
                    #Table12 {
                        width: 608px;
                    }
                    
                    .style46 {
                        height: 22px;
                        text-align: left;
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
                    
                    .style53 {
                        text-align: right;
                    }
                </style>

                <script type="text/javascript">
                    function getExpDt() {
                        pdt = new Date(document.Pol.txtEffDt.value);
                        trm = parseInt(document.Pol.TxtTerm.value);
                        mnth = pdt.getMonth() + trm;
                        if (!isNaN(mnth)) {
                            pdt.setMonth(mnth % 12);
                            if (mnth > 11) {
                                var t = pdt.getFullYear() + Math.floor(mnth / 12);
                                pdt.setFullYear(t);
                            }
                            document.Pol.txtExpDt.value = parse(pdt);
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

                    function SetRadioButton() {

                        if (document.Pol.rdbLoan.checked = true) {
                            document.Pol.rdbLoan.checked = true;
                            document.Pol.rdbLeasing.checked = false;
                        }
                    }

                    function SetRadioButton2() {
                        if (document.Pol.rdbLoan.checked = true) {
                            document.Pol.rdbLoan.checked = false;
                            document.Pol.rdbLeasing.checked = true;
                        }
                    }

                    function SetFieldDate() {
                        document.Pol.TxtPurchaserDate.value = document.Pol.txtEffDt.value;
                        document.Pol.TxtEffDateCompany.value = document.Pol.txtEffDt.value;
                    }

                    //			function SetSupplier()
                    //			{
                    //			    if(document.Pol.ddlPolicyClass.options[document.Pol.ddlPolicyClass.selectedIndex].value == 1)
                    //			    {
                    //			   	    for(i = 0;i <= document.Pol.ddlSupplier.options.length ; i++)
                    //				    {
                    //				        //alert(document.Pol.ddlCiudad.options[i].value +' - 'document.Pol.TxtZip.value)
                    //				        if(document.Pol.ddlSupplier.options[i].value == document.Pol.ddlCompanyDealer.options[document.Pol.ddlCompanyDealer.selectedIndex].value)
                    //					    {					   
                    //					       document.Pol.ddlSupplier.disabled = false;
                    //					       document.Pol.ddlSupplier.selectedIndex = i;
                    //					       document.Pol.inputSupplierIndex.value = i;
                    //    					   //document.Pol.ddlSupplier.disabled = true;
                    //					       //document.Pol.TxtZip.value = '00'+Number(document.Pol.TxtZip.value);
                    //					       return;
                    //					    }
                    //					    else
                    //					    {
                    //					        //document.Pol.TxtCity.value = "";
                    //					        document.Pol.ddlSupplier.selectedIndex = -1;
                    //					        document.Pol.inputSupplierIndex.value = -1;
                    //					    }
                    //				    }	
                    //				}
                    //			}

                    function SetCiudad() {
                        for (i = 0; i <= document.Pol.ddlCiudad.options.length; i++) {
                            //alert(document.Pol.ddlCiudad.options[i].value +' - 'document.Pol.TxtZip.value)
                            if (Number(document.Pol.ddlCiudad.options[i].value) == Number(document.Pol.TxtZip.value)) {
                                //alert(document.Pol.ddlCiudad.options[i].text)
                                document.Pol.ddlCiudad.selectedIndex = i;
                                //document.Pol.TxtCity.value = document.Pol.ddlCiudad.options[i].text;
                                document.Pol.TxtZip.value = '00' + Number(document.Pol.TxtZip.value);
                                return;
                            } else {
                                //document.Pol.TxtCity.value = "";
                                document.Pol.ddlCiudad.selectedIndex = -1;
                            }
                        }
                    }

                    function SetZipCode() {
                        if (document.Pol.ddlCiudad.selectedIndex > 0) {
                            document.Pol.TxtZip.value = document.Pol.ddlCiudad.options[document.Pol.ddlCiudad.selectedIndex].value
                        } else {
                            document.Pol.TxtZip.value = ''
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

                    $('#<%= txtExpDt.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });

                    $('#<%= txtEndoEffDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });

                    $('#<%= TxtRetroactiveDate.ClientID %>').datepicker({
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
                    $('#<%= txtGapEndDate2.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $('#<%= txtGapBegDate2.ClientID %>').datepicker({
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
                    $('#<%= txtCyberRetroDate.ClientID %>').datepicker({
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
                    $('#<%= txtExpDt.ClientID %>').datepicker('show');
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

                function ShowDateTimePickerEndoRetroDate() {
                    $('#<%= txtRetroEffDate.ClientID %>').datepicker('show');
                }

                function ShowDateTimePickerCyberRetroDate() {
                    $('#<%= txtCyberRetroDate.ClientID %>').datepicker('show');
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
    <form id="Pol" method="post" runat="server">
        <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="0">
        </Toolkit:ToolkitScriptManager>

        <p><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></p>
        <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
          <div class="row">
             <div class="col-md-4" style="align-self:center;">
                <asp:label id="Label46" runat="server" CssClass="fs-14 fw-bold">Policies:</asp:label>
                <asp:label id="LblControlNo" runat="server" CssClass="fs-14 fw-bold"> No.:</asp:label>
             </div>
             <div class="col-md-8" style="text-align:right;">
                <asp:Button ID="btnComments" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Comments" style="margin-bottom: 4px;" onclick="btnComments_Click1" />
                <asp:Button ID="btnRate" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Rate" style="margin-bottom: 4px;" />
                <asp:button id="btnPrintPolicy" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Print" style="margin-bottom: 4px;" onclick="btnPrintPolicyWord_Click" />
                <asp:button id="btnEnablePrint" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Enable Print" style="margin-bottom: 4px;" 
                    onclick="btnEnablePrint_Click" onclientclick="return confirm('Enabling Policy Printing, Continue?');" Visible="False" />
                <asp:button id="btnCancellation" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Cancellation" style="margin-bottom: 4px;" onclick="btnCancellation_Click" />
                <asp:Button ID="btnRenew" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    OnClick="btnRenew_Click" style="margin-bottom: 4px;" Text="Renew" />
                <asp:button id="btnReinstatement" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Reinstatement" style="margin-bottom: 4px;" onclick="btnReinstatement_Click"></asp:button>
                <asp:button id="BtnSave" runat="server" Text="Save" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    onclick="BtnSave_Click" style="margin-bottom: 4px;"></asp:button>
                <asp:button id="btnAdd2" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Add" style="margin-bottom: 4px;" onclick="btnAdd2_Click" Visible="False"></asp:button>
                <asp:button id="btnDelete" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Delete" style="margin-bottom: 4px;"
                onclick="btnDelete_Click" onclientclick="return confirm('Are you certain you want to delete this Policy?');"></asp:button>
                <asp:button id="btnEdit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Modify" style="margin-bottom: 4px;" onclick="btnEdit_Click"></asp:button>
                <asp:button id="btnCancel" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Cancel" style="margin-bottom: 4px;" onclick="btnCancel_Click"></asp:button>
                <asp:button id="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Exit" style="margin-bottom: 4px;" onclick="BtnExit_Click"></asp:button>
                <asp:Button ID="btnHistory" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    OnClick="btnHistory_Click" style="margin-bottom: 4px;" Text="History" />
                <asp:button id="btnEndor" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="New Endorsement" style="margin-bottom: 4px;" onclick="btnEndor_Click"></asp:button>
                <asp:button id="btnComissions" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Commissions" style="margin-bottom: 4px;" onclick="btnComissions_Click"></asp:button>
                <asp:button id="btnPayments" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Payments" style="margin-bottom: 4px;" onclick="btnPayments_Click"></asp:button>
                <asp:button id="btnFinancialCanc" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Financial Canc." style="margin-bottom: 4px;" onclick="btnFinancialCanc_Click" Visible="False"></asp:button>
                <asp:button id="btnTailQuote" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Tail Quote" style="margin-bottom: 4px;" onclick="btnTailQuote_Click"></asp:button>
                <asp:button id="btnRegistry" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Registry" style="margin-bottom: 4px;" onclick="btnRegistry_Click"></asp:button>
                <asp:button id="btnPrintCertificate" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Print Certificate" style="margin-bottom: 4px;" onclick="btnPrintCertificate_Click"></asp:button>
                <asp:button id="btnPolicyCert" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" 
                    Text="Policy Cert." style="margin-bottom: 4px;" onclick="btnPolicyCert_Click" Visible="False"></asp:button>
             </div>
             <div class="col-md-12">
             <hr />
              <div class="row">
                  <asp:label id="Label3" RUNAT="server" CssClass="fs-11 fw-bold">Customer Information</asp:label>


                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:label id="lblEmail" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Customer No.</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="TxtCustomerNo" RUNAT="server" CSSCLASS="form-control fs-txt-s" MAXLENGTH="10"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label2" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">First Name</asp:label>
                        <div class="col-md-9" style="height:29.2px;">
                            <div class="input-group mb-3">
                              <asp:textbox id="TxtFirstName" RUNAT="server" CSSCLASS="form-control fs-txt-s" style="height:29.2px; width:auto" MAXLENGTH="25"></asp:textbox>
                              <asp:label id="Label1" RUNAT="server" class="input-group-text fs-lbl-s label-vertical-align" style="height:29.2px;" ENABLEVIEWSTATE="False">Init.</asp:label>
                              <asp:textbox id="TxtInitial" RUNAT="server" CSSCLASS="form-control fs-txt-s" style="height:29.2px;" MAXLENGTH="1"></asp:textbox>
                            </div>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblLastName1" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Last Name 1</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="txtLastname1" RUNAT="server" MAXLENGTH="15" CSSCLASS="form-control fs-txt-s" ontextchanged="txtLastname1_TextChanged"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblLastName2" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Last Name 2</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="txtLastname2" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="15"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblAdditionalName" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Add. Name:</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="txtAdditionalName" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="100"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label36" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Address 1</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="TxtAddrs1" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="60"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label37" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Address 2</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="TxtAddrs2" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="60"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label39" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">City</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="TxtCity" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="14"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label40" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Zip Code</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="TxtState" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="2" Width="30%" style="float:left"></asp:textbox>
                            <maskedinput:maskedtextbox id="TxtZip" CSSCLASS="form-control fs-txt-s" Width="70%" RUNAT="server" MAXLENGTH="10" MASK="CCCCCC" ISDATE="False" IsCurrency="False" IsZipCode="True"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblOtherSpecialty" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" Font-Italic="False">Other Spec.</asp:label>
                        <div class="col-md-9">
                        <asp:dropdownlist id="ddlOtherSpecialty" CSSCLASS="form-select fs-txt-s" RUNAT="server"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <div class="col-md-12" style="margin-top: 3px; padding-bottom: 8.5px;">
                           <asp:CheckBox ID="CHKCyberEndorsment" runat="server" CSSCLASS="fs-lbl-s label-vertical-align" Text="` eMED Defense Cyber Endorsement" AutoPostBack="True" oncheckedchanged="CHKCyberEndorsment_CheckedChanged" />
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblHomePhone" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Home Phone</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="txtHomePhone" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblWorkPhone" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Work Phone</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="txtWorkPhone" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label8" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Cellular</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="TxtCellular" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label26" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">E-mail</asp:label>
                        <div class="col-md-9">
                            <asp:textbox id="txtEmail" CSSCLASS="form-control fs-txt-s" RUNAT="server" MAXLENGTH="100"></asp:textbox>
                        </div>
                    </div>
                  </div>

                  <div class="col-md-4">

                    <div class="mb-3 row">
                        <div class="col-md-3 label-vertical-align">
                            <asp:Label ID="lblPolicyNo" runat="server" CssClass="col-form-labe" 
                                Font-Names="Tahoma" Font-Size="9pt" Height="14px">Policy No.</asp:Label>
                            <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" AutoPostBack="True" 
                                ForeColor="Black" Height="14px" Width="1px"
                                OnCheckedChanged="ChkAutoAssignPolicy_CheckedChanged" Text=" " 
                                ToolTip="Auto Assign Policy"/>                        
                        </div>
                        <div class="col-md-9" style="height:29.2px;">
                            <div class="input-group mb-3">
                              <asp:textbox id="TxtPolicyNo" RUNAT="server" CssClass="form-control fs-txt-s" MAXLENGTH="15" style="height:29.2px;"></asp:textbox>
                              <asp:Button id="btnNew" runat="server" Text="New" class="add-on btn-bg-theme2 input-group-text fs-lbl-s" style="height:29.2px; border: aliceblue;" ToolTip="Add New policy with the same information" onclick="btnNew_Click"></asp:Button>
                            </div>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <asp:label id="lblCertificate" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Certificate</asp:label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TxtCertificate" runat="server" MaxLength="15" CssClass="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label29" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Policy Type</asp:Label>
                        <div class="col-md-9" style="height:29.2px;">
                            <div class="input-group mb-3">
                              <asp:textbox id="TxtPolicyType" CSSCLASS="form-control fs-txt-s" style="height:29.2px;" RUNAT="server" MAXLENGTH="3"></asp:textbox>
                              <span class="input-group-text fs-lbl-s label-vertical-align" style="height:29.2px;">Suffix</span>
                              <asp:textbox id="TxtSufijo" CSSCLASS="form-control fs-txt-s" style="height:29.2px;" RUNAT="server" MAXLENGTH="2"></asp:textbox>
                            </div>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label16" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Anniversary</asp:label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TxtAnniversary" runat="server" CSSCLASS="form-control fs-txt-s" Width="30%" MaxLength="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label5" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Term</asp:Label>
                        <div class="col-md-9">
                            <asp:textbox id="TxtTerm" CSSCLASS="form-control fs-txt-s" Width="30%" RUNAT="server" MAXLENGTH="3"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label20" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Retro. Date</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox ID="TxtRetroactiveDate" runat="server" Columns="30" onclick="ShowDateTimePicker2();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label4" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Effective Date
                        </asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtEffDt" runat="server" Columns="30" IsDate="True" onclick="ShowDateTimePicker();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label11" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Exp. Date</asp:label>
                        <div class="col-md-9">
                        <asp:textbox id="txtExpDt" runat="server" Columns="30" IsDate="True" onclick="ShowDateTimePicker4();" CSSCLASS="form-control fs-txt-s"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label27" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Entry Date</asp:label>
                        <div class="col-md-9">
                        <asp:textbox id="txtEntryDate" CSSCLASS="form-control fs-txt-s" runat="server" IsDate="True" Columns="30"></asp:textbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label72" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Other Agent</asp:Label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlAgent2" CSSCLASS="form-select fs-txt-s" RUNAT="server">
                            </asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label41" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Charge</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="TxtCharge" CSSCLASS="form-control fs-txt-s" Width="60%" RUNAT="server" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCC" ISDATE="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblPremium" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" RUNAT="server">Premium</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="TxtPremium" CssClass="form-control fs-txt-s"  Width="60%" RUNAT="server" MAXLENGTH="14" MASK="CCCCCCCCCC" ISDATE="False" AutoPostBack="True" ontextchanged="TxtPremium_TextChanged"></maskedinput:maskedtextbox>
                            <asp:button id="btnChargeCalc" tabIndex="68" CssClass="btn-bg-theme2 btn-h-30 btn-r-4"  runat="server" BorderWidth="0px" BorderColor="#BB1509" BackColor="#BB1509" Text="Calculate" onclick="CalculateCharge" Visible="False"></asp:button>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblCyberPremium" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server" EnableViewState="False" Visible="false">Cyber Premium</asp:Label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="txtCyberPremium" tabIndex="49" CSSCLASS="form-control fs-txt-s" Width="60%" RUNAT="server" Visible="false" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCCCCCC" ISDATE="False" Enabled="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblPremium0" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" RUNAT="server">Canc. Amount</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="TxtCancAmount" RUNAT="server" CSSCLASS="form-control fs-txt-s" Width="60%" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCCCCCC" ISDATE="False" Enabled="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblTotPremum" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" RUNAT="server">Tot. Premium</asp:label>
                        <div class="col-md-9">
                            <maskedinput:maskedtextbox id="TxtTotalPremium" CSSCLASS="form-control fs-txt-s" Width="60%" RUNAT="server" MAXLENGTH="14" IsCurrency="True" MASK="CCCCCCCCCC" ISDATE="False" Enabled="False"></maskedinput:maskedtextbox>
                            <maskedinput:maskedtextbox id="TxtUserPremium" CSSCLASS="form-control fs-txt-s" Width="60%" RUNAT="server" MAXLENGTH="14" MASK="CCCCCCCCCC" ISDATE="False" AutoPostBack="True" ontextchanged="TxtPremium_TextChanged" Visible="False"></maskedinput:maskedtextbox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblDiscount" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server">Group Disc.</asp:Label>
                        <div class="col-md-9">
                            <MaskedInput:MaskedTextBox ID="txtInvoiceNumber" CSSCLASS="form-control fs-txt-s" Width="60%" runat="server" IsCurrency="False" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49"></MaskedInput:MaskedTextBox>
                        </div>
                    </div>
                  </div>


                  <div class="col-md-4">
                    <div class="mb-3 row" style="margin-top: 3px; padding-bottom: 8.5px;">
                        <asp:Label ID="LblStatus" runat="server" CssClass="headform2" EnableViewState="False"
                            Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Height="14px"
                            Width="69px">Inforce/</asp:Label>
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:CheckBox ID="chkPaymentGA" runat="server" Font-Size="Small" Width="170px"
                            style="font-size: 9pt; font-family: Tahoma" Text="Checked Payment by GA" />
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label18" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Agency</asp:label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlAgency" CssClass="form-select fs-txt-s" RUNAT="server" onselectedindexchanged="ddlAgency_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label75" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Branch</asp:label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlCity" CssClass="form-select fs-txt-s" RUNAT="server"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label21" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Agent</asp:Label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlAgent" CssClass="form-select fs-txt-s" RUNAT="server">
                            </asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label6" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" RUNAT="server">Originated At</asp:label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlOriginatedAt" CssClass="form-select fs-txt-s" RUNAT="server"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label9" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Ins. Company</asp:label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlInsuranceCompany" CssClass="form-select fs-txt-s" RUNAT="server" onselectedindexchanged="ddlInsuranceCompany_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <div class="col-md-3" >
                            <asp:label id="Label42" RUNAT="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" Visible="False">Group</asp:label>
                        </div>
                        <div class="col-md-9">
                        <asp:dropdownlist id="ddlGroup" CssClass="form-select fs-txt-s" RUNAT="server" AutoPostBack="True" onselectedindexchanged="ddlGroup_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="Label28" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Corporation</asp:label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlCorparation" CssClass="form-select fs-txt-s" RUNAT="server"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:label id="lblFinancial" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" RUNAT="server">Financial Inst.</asp:label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlFinancial" CssClass="form-select fs-txt-s" RUNAT="server"></asp:dropdownlist>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblIsoCode" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server" EnableViewState="False">IsoCode</asp:Label>
                        <div class="col-md-9">
                            <asp:Dropdownlist id="ddlIsoCode" CssClass="form-select fs-txt-s" RUNAT="server" AutoPostBack="True" onselectedindexchanged="ddlIsoCode_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblSpecialty" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server" EnableViewState="False">Specialty</asp:Label>
                        <div class="col-md-9">
                            <asp:dropdownlist id="ddlSpecialty" CssClass="form-select fs-txt-s" RUNAT="server" AutoPostBack="True" onselectedindexchanged="ddlSpecialty_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label74" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server" EnableViewState="False">Has Claim?</asp:Label>
                        <div class="col-md-9">
                            <asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow" style="font-size: 9pt" Width="154px">
                                <asp:ListItem Value="0">Yes</asp:ListItem>
                                <asp:ListItem Value="1">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblClaimNo" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Claim No</asp:Label>
                        <div class="col-md-12">
                            <asp:textbox id="txtClaimNumber" CssClass="form-control fs-txt-s" Width="100%" Height="113.7px" runat="server" IsDate="True" Columns="30" MaxLength="100" TextMode="MultiLine"></asp:textbox>
                        </div>
                    </div>
                 </div>


                 <div class="col-md-8">
                    <div class="mb-3 row">
                        <asp:label id="lblComments" RUNAT="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Comments</asp:label>
                        <div class="col-md-12">
                            <asp:textbox id="TxtComments" CssClass="form-control fs-txt-s" RUNAT="server" Width="100%" Height="157px" MAXLENGTH="2000" TextMode="MultiLine"></asp:textbox>
                        </div>
                    </div>
                 </div>

                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="Label51" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">License:</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtLicense" runat="server" MaxLength="25" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label17" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">ApplicationID</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtApplicationID" runat="server" MaxLength="10" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblGapDate2" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" 
                            runat="server" EnableViewState="False">Num. of Employees:</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtNumberOfEmployees" runat="server" Columns="30" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblUpdateForm" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server" EnableViewState="False">Update Form</asp:Label>
                        <div class="col-md-9">
                            <asp:CheckBox ID="chkUpdateForm" runat="server" />
                        </div>
                    </div>
                  </div>

              </div>





             <hr />
              <div class="row">
                  <asp:Label ID="lblGapEndDate5" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">Gap Dates:</asp:Label>
                  <div class="col-md-6">
                    <div class="mb-3 row">
                        <asp:Label ID="lblGapEndDate0" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" 
                            EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" >From:</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtGapBegDate" runat="server" Columns="30" onclick="ShowDateTimePicker6();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>

                        <asp:Label ID="lblGapEndDate" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" 
                            EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" >To:</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtGapEndDate" runat="server" Columns="30" onclick="ShowDateTimePicker7();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblGapEndDate1" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" 
                            EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">From:</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtGapBegDate2" runat="server" Columns="30" onclick="ShowDateTimePicker8();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>

                        <asp:Label ID="lblGapEndDate3" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" 
                            EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">To:</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtGapEndDate2" runat="server" Columns="30" onclick="ShowDateTimePicker9();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="lblGapEndDate2" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" 
                            EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">From:</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtGapBegDate3" runat="server" Columns="30" onclick="ShowDateTimePicker10();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>

                        <asp:Label ID="lblGapEndDate4" runat="server" CssClass="col-md-1 col-form-labe label-vertical-align" 
                            EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px">To:</asp:Label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtGapEndDate3" runat="server" Columns="30" onclick="ShowDateTimePicker11();" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <div class="mb-3 row">
                        <div class="col-md-12">
                            <asp:listbox id="ddlSelectedAgent" runat="server" CSSCLASS="form-control fs-txt-s" Height="89.7px" onselectedindexchanged="ddlSelectedAgent_SelectedIndexChanged"></asp:listbox>
                        </div>
                        <div style="text-align:end;">
                            <asp:button id="cmdRemove" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" runat="server" Text="<<" onclick="cmdRemove_Click"></asp:button>
                            <asp:button id="cmdSelect" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" runat="server" Text=">>" onclick="cmdSelect_Click"></asp:button>
                        </div>
                    </div>
                  </div>

                  <div class="col-md-12">
                    <div class="mb-3 row">
                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:Label ID="Label76" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Prospect Number</asp:Label>
                                <div class="col-md-12">
                                    <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" CSSCLASS="form-control fs-txt-s" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:Label ID="Label25" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Eff. Date</asp:Label>
                                <div class="col-md-12" style="height:29.2px;">
                                    <div>
                                      <maskedinput:maskedtextbox id="txtPriPolEffecDate1" Height="29.2px" Font-Size="8pt" Font-Names="Tahoma"
                                        RUNAT="server" ISDATE="True" CssClass="form-control"></maskedinput:maskedtextbox>
                                      <%--<span class="add-on input-group-text" style="height:29px;"><i class="bi bi-grid-3x3-gap-fill"></i></span>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:label id="Label10" RUNAT="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False">Limits</asp:label>
                                <div class="col-md-12">
                                    <asp:dropdownlist id="ddlAvailableAgent" RUNAT="server" CSSCLASS="form-select fs-txt-s"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:Label ID="Label12" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Liability A:</asp:Label>
                                <div class="col-md-12">
                                    <asp:dropdownlist id="ddlPrMedicalLimits" RUNAT="server" CSSCLASS="form-select fs-txt-s" AutoPostBack="True" OnSelectedIndexChanged="ddlPrMedicalLimits_SelectedIndexChanged">
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 label-vertical-align">
                            <div class="mb-3 row">
                                <div class="col-md-12">
                                    <asp:CheckBox ID="chkPending"  CssClass="col-form-labe fs-lbl-s" runat="server" Text="` Pending" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:Label ID="lblCarrier" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Excess Carrier Name</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtPriCarierName1" runat="server" MaxLength="75" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:Label ID="Label30" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Policy No. Other Company</asp:Label>
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtPriClaims1" runat="server" MaxLength="50" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="mb-3 row">
                                <asp:Label ID="Label24" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Policy Limits</asp:Label>
                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlPriPolLimits1" runat="server" CSSCLASS="form-select fs-txt-s" AutoPostBack="True" OnSelectedIndexChanged="ddlPriPolLimits1_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                    </div>
                  </div>
                  <div class="col-md-12">
                        <asp:label id="Label7" RUNAT="server" CssClass="fs-11 fw-bold" ENABLEVIEWSTATE="False">Covers:</asp:label>

                        <asp:DataGrid ID="DG_AdditialCoverages" runat="server" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" CellPadding="0" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-ForeColor="white"
                            HeaderStyle- HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center" OnItemCommand="dtEndorsement_ItemCommand" PageSize="8" TabIndex="9" Width="403px" Visible="false" onitemcreated="DG_AdditialCoverages_ItemCreated">
                            <%--<FooterStyle BackColor="Navy" ForeColor="#003399" />--%>
                                <%--<EditItemStyle BackColor="White" 
                                                                HorizontalAlign="Center" />
                                                            <SelectedItemStyle BackColor="White" 
                                                                HorizontalAlign="Center" />--%>
                                    <%--<PagerStyle BackColor="White" CssClass="Numbers" 
                                                                 ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" 
                                                                PageButtonCount="20" />--%>
                                        <%--<AlternatingItemStyle BackColor="White" 
                                                                CssClass="HeadForm3" HorizontalAlign="Center" />
                                                            <ItemStyle BackColor="White" CssClass="HeadForm3" 
                                                                HorizontalAlign="Center" />--%>
                            <Columns>
                            
                                <asp:BoundColumn DataField="Limit" HeaderText="Limit">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ISOCode" Visible="false" HeaderText="ISO Code">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Premium" HeaderText="Premium">
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle />
                                </asp:BoundColumn>
                            
                            </Columns>
                            <HeaderStyle BackColor="#BB1509" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="10px" HorizontalAlign="Center" />
                        </asp:DataGrid>
                  </div>
                  <div class="col-md-12">
                  <asp:button id="btnPrintCyberEndorsement" tabIndex="71" runat="server" Width="120px" Text="Print Cyber Endo." onclick="btnPrintCyberEndorsement_Click" Visible="False"></asp:button>

                        <asp:Label ID="lblAddCyberEndorsmentPremium" runat="server" Visible="False">Premium:</asp:Label>
                        <asp:textbox id="txtAddCyberEndorsmentPremium" tabIndex="9" RUNAT="server" Visible="False" AutoPostBack="True" ontextchanged="txtAddCyberEndorsmentPremium_TextChanged"></asp:textbox>

                        <asp:Label ID="lblCyberRetroDate" runat="server" Visible="False">RetroDate:</asp:Label>
                        <asp:textbox id="txtCyberRetroDate" tabIndex="9" RUNAT="server" Visible="False" AutoPostBack="True" onclick="ShowDateTimePickerCyberRetroDate();"></asp:textbox>
                  </div>
              </div>


             <hr />
              <div class="row">
                    <asp:Label ID="lblEndorsement" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False" >Endorsements:</asp:Label>
                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="lblEndorsementNo" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endorsement No.:
                        </asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtEndorsementNo" runat="server" CSSCLASS="form-control fs-txt-s" MaxLength="75"></asp:TextBox>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="lblDatePrepared" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Date Prepared:
                        </asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtDatePrepared" runat="server" CSSCLASS="form-control fs-txt-s" Columns="30" IsDate="True" TabIndex="44"></asp:TextBox>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="lblEndoEffDate" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endo. Eff. Date:
                        </asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtEndoEffDate" runat="server" CSSCLASS="form-control fs-txt-s" onclick="ShowDateTimePicker5();"></asp:TextBox>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="lblEndoRetroDate" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endo. Retro. Date:
                        </asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtRetroEffDate" runat="server" CSSCLASS="form-control fs-txt-s" onclick="ShowDateTimePickerEndoRetroDate();"></asp:TextBox>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="lblEndoPremium" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endo. Premium:
                        </asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtEndoPremium" runat="server" CSSCLASS="form-control fs-txt-s" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <div class="mb-3 row">
                        <asp:Label ID="lblEndoType" runat="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Endorsement Type:
                        </asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlEndoType" RUNAT="server" CSSCLASS="form-select fs-txt-s" autopostback="true" onselectedindexchanged="ddlEndoType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                  </div>

                  <div class="col-md-8">
                      <div class="mb-3 row">
                          <asp:Label ID="lblEndoComments" runat="server" CssClass="col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False">Comments:</asp:Label>
                          <div class="col-md-12">
                            <asp:TextBox ID="txtEndoComments" RUNAT="server" CSSCLASS="form-control fs-txt-s" Height="157px" MAXLENGTH="2000" TextMode="MultiLine"></asp:TextBox>
                          </div>
                      </div>
                  </div>
                  <div class="col-md-4">
                  </div>
                  <div class="col-md-12">
                     <asp:Label ID="lblEndorsementHistory" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">Endorsements:</asp:Label>
                     <asp:DataGrid ID="dtEndorsement" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" CellPadding="0" HeaderStyle-BackColor="#5C8BAE"
                         HeaderStyle- HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center" OnItemCommand="dtEndorsement_ItemCommand" PageSize="8" TabIndex="9" Width="90%" HeaderStyle-ForeColor="white">
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
                                 <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                             </asp:BoundColumn>
                             <asp:BoundColumn DataField="EndorsementPremium" HeaderText="Premium">
                                 <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                 <ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                             </asp:BoundColumn>
                             <asp:BoundColumn DataField="EndorsementComments" HeaderText="Comments">
                                 <HeaderStyle Width="250px" />
                                 <ItemStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                             </asp:BoundColumn>
                             <asp:BoundColumn DataField="EndorsementHistory" HeaderText="History" Visible="False">
                                 <HeaderStyle />
                                 <ItemStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                             </asp:BoundColumn>
                             <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">
                                 <HeaderStyle />
                             </asp:ButtonColumn>
                             <asp:TemplateColumn HeaderText="Del.">
                                 <ItemTemplate>
                                     <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" onclientclick="return confirm('Are you certain you want to delete this Endorsement?');" CommandName="Delete" />
                                 </ItemTemplate>
                                 <HeaderStyle />
                             </asp:TemplateColumn>
                             <asp:ButtonColumn ButtonType="PushButton" CommandName="Print" HeaderText="Print">
                                 <HeaderStyle />
                             </asp:ButtonColumn>
                         </Columns>
                         <HeaderStyle BackColor="#BB1509" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="10px" HorizontalAlign="Center" />
                     </asp:DataGrid>
                  </div>
                </div>




             <hr />
              <div class="row">
                  <asp:Label ID="Label22" runat="server" CssClass="fs-11 fw-bold" EnableViewState="False">History:</asp:Label>
                  <div class="col-md-12">
                      <div class="mb-3 row">
                        <asp:button id="btnRefresh" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Refresh" onclick="btnRefresh_Click" Visible="False"></asp:button>
                        <div class="col-md-12">
                            <asp:DataGrid ID="DtSearchPayments" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" CellPadding="0" HeaderStyle-BackColor="#5C8BAE"
                                HeaderStyle- HeaderStyle-HorizontalAlign="Center" Height="193px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center" OnItemCommand="DtSearchPayments_ItemCommand1" PageSize="8" TabIndex="9" Width="90%" HeaderStyle-ForeColor="white"
                                onitemcreated="DtSearchPayments_ItemCreated">
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
                                        <HeaderStyle HorizontalAlign="Center" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv.">
                                        <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">
                                        <HeaderStyle />
                                        <ItemStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">
                                        <HeaderStyle />
                                        <ItemStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Comments" HeaderText="Comments">
                                        <HeaderStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                        <ItemStyle Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                    </asp:BoundColumn>

                                </Columns>
                                <HeaderStyle BackColor="#BB1509" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="10px" HorizontalAlign="Center" />
                            </asp:DataGrid>
                        </div>
                      </div>
                 </div>
              </div>











             <hr />
              <div class="row">
                  <asp:Label ID="Label52" CssClass="fs-11 fw-bold" runat="server">Primary - Technicians & Nurses
                  </asp:Label>
                  <asp:textbox id="TxtID" CSSCLASS="form-control fs-txt-s" runat="server" Visible="False"></asp:textbox>
                  <div class="col-md-12">
                    <div class="mb-3 row">
                        <div class="col-md-3"></div>
                        <asp:Label ID="Label53" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align" runat="server">Primary</asp:Label>
                        <asp:Label ID="Label54" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align" runat="server">Rate %</asp:Label>
                        <asp:Label ID="Label55" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align" runat="server">Premium</asp:Label>
                        <asp:Label ID="Label56" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align" runat="server">Quantity</asp:Label>
                        <asp:Label ID="Label57" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align" runat="server">Premium</asp:Label>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label58" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server">Physicians Assistant</asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPrimaryTN1" runat="server" CssClass="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtRateTN1" runat="server" CssClass="form-control fs-txt-s">25%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPremiumTN1" runat="server" CssClass="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtQuantityTN1" runat="server" CssClass="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTotPremTN1" runat="server" CssClass="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label59" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server">Nurse Midwife</asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPrimaryTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtRateTN2" runat="server" CSSCLASS="form-control fs-txt-s">50%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPremiumTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtQuantityTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTotPremTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label60" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server">Nurse Anesthetist
                        </asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPrimaryTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtRateTN3" runat="server" CSSCLASS="form-control fs-txt-s">75%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPremiumTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtQuantityTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTotPremTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label61" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server">Nurse Practitioner
                        </asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPrimaryTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtRateTN4" runat="server" CSSCLASS="form-control fs-txt-s">20%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPremiumTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtQuantityTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTotPremTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label62" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" runat="server">All Other Personel
                        </asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPrimaryTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtRateTN5" runat="server" CSSCLASS="form-control fs-txt-s">10%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPremiumTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtQuantityTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTotPremTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label63" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Total:</asp:Label>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtRateTN6" runat="server" CSSCLASS="form-control fs-txt-s">100%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtQuantityTN6" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtTotPremTN6" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>

                  </div>
              </div>

             <hr />
              <div class="row">
                  <asp:Label ID="Label64" runat="server" CssClass="fs-11 fw-bold">Excess - Technicians & Nurses</asp:Label>
                  <div class="col-md-12">
                    <div class="mb-3 row">
                        <div class="col-md-3"></div>
                        <asp:Label ID="Label65" runat="server" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align">Excess</asp:Label>
                        <asp:Label ID="Label66" runat="server" CssClass="col-md-1 col-form-labe fs-lbl-s label-vertical-align">Rate %</asp:Label>
                        <asp:Label ID="Label67" runat="server" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align">Premium</asp:Label>
                        <asp:Label ID="Label31" runat="server" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align">Quantity</asp:Label>
                        <asp:Label ID="Label32" runat="server" CssClass="col-md-2 col-form-labe fs-lbl-s label-vertical-align">Premium</asp:Label>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label33" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Physicians Assistant</asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtExcessTN1" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtERateTN1" runat="server" CSSCLASS="form-control fs-txt-s">15%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEPremiumTN1" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEQuantityTN1" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtETotPremTN1" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label34" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Nurse Midwife</asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtExcessTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtERateTN2" runat="server" CSSCLASS="form-control fs-txt-s">50%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEPremiumTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEQuantityTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtETotPremTN2" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label35" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Nurse Anesthetist</asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtExcessTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtERateTN3" runat="server" CSSCLASS="form-control fs-txt-s">50%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEPremiumTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEQuantityTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtETotPremTN3" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label68" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Nurse Practitioner
                        </asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtExcessTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtERateTN4" runat="server" CSSCLASS="form-control fs-txt-s">10%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEPremiumTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEQuantityTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtETotPremTN4" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label69" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">All Other Personel
                        </asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtExcessTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtERateTN5" runat="server" CSSCLASS="form-control fs-txt-s">2.5%</asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEPremiumTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEQuantityTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtETotPremTN5" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mb-3 row">
                        <asp:Label ID="Label38" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Total:</asp:Label>

                        <div class="col-md-2">

                        </div>
                        <div class="col-md-1">
                            <asp:TextBox ID="txtERateTN6" runat="server" CSSCLASS="form-control fs-txt-s">100%</asp:TextBox>
                        </div>
                        <div class="col-md-2">

                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtEQuantityTN6" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtETotPremTN6" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                        </div>
                    </div>

                  </div>
                  <div class="col-md-12" style="text-align:right">
                    <asp:Button ID="Button3" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" OnClick="Button3_Click" Text="Calculate" />
                  </div>
              </div>


             <hr />
              <div class="row">
                  <div class="col-md-12">
                    <div class="mb-3 row">
                        <div class="col-md-8"></div>
                        <div class="col-md-4">
                            <div class="mb-3 row">
                                <asp:Label ID="Label70" runat="server" CssClass="col-md-5 col-form-labe fs-lbl-s label-vertical-align" >Total Primary Premium:</asp:Label>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtTotalPrimary" runat="server" MaxLength="20" CSSCLASS="form-control fs-txt-s" ></asp:TextBox>
                                </div>
                                
                                <asp:Label ID="Label71" runat="server" CssClass="col-md-5 col-form-labe fs-lbl-s label-vertical-align">Total Excess Premium:</asp:Label>

                                <div class="col-md-7">
                                    <asp:TextBox ID="txtTotalExcess" runat="server" MaxLength="20" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                   </div>
               </div>

             </div>
                        
                        
                        
            <div id="effect" class="ui-widget-header ui-corner-all" style="width: 316px; display:none">
                <asp:Label ID="Label49" runat="server" Font-Size="14pt" Font-Underline="True" Text="Select Rate"></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="Specialty:"></asp:Label>
                <asp:DropDownList ID="ddlRate" runat="server" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlRateExcess" runat="server" TabIndex="1" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged">
                </asp:DropDownList>
            
                <asp:Label ID="Label14" runat="server" Text="Iso Code:"></asp:Label>
                <asp:TextBox ID="txtIsoCode" runat="server" TabIndex="8"></asp:TextBox>
            
                <asp:Label ID="Label47" runat="server" Text="Class:"></asp:Label>
                <asp:TextBox ID="txtClass" runat="server" TabIndex="8"></asp:TextBox>
            
                <asp:Label ID="Label15" runat="server" Text="Rate 1"></asp:Label>
            
                <asp:Label ID="Label43" runat="server" Text="Rate 2"></asp:Label>
            
                <asp:Label ID="Label45" runat="server" Text="Rate 3"></asp:Label>
            
                <asp:Label ID="Label44" runat="server" Text="MCM Rate "></asp:Label>
            
                <asp:TextBox ID="txtRate1" runat="server" TabIndex="8"></asp:TextBox>
            
                <asp:TextBox ID="txtRate2" runat="server" TabIndex="8"></asp:TextBox>
            
                <asp:TextBox ID="txtRate3" runat="server" TabIndex="8"></asp:TextBox>
            
                <asp:TextBox ID="txtRate4" runat="server" TabIndex="8"></asp:TextBox>
            
                <asp:Button ID="btnCloseEffect" runat="server" BackColor="#BB1509" BorderColor="#BB1509" BorderWidth="0px" Text="Close" />
            </div>



                        <asp:label id="Label23" RUNAT="server" ENABLEVIEWSTATE="False" Visible="False">Line of Business</asp:label>
                        <asp:dropdownlist id="ddlPolicyClass" RUNAT="server" AutoPostBack="True" onselectedindexchanged="ddlPolicyClass_SelectedIndexChanged" Visible="False"></asp:dropdownlist>

                        <asp:label id="lblSocialSecurity" RUNAT="server" ENABLEVIEWSTATE="False" Visible="False">Social Security</asp:label>
                        <maskedinput:maskedtextbox id="txtSocialSecurity" tabIndex="11" RUNAT="server" MAXLENGTH="11" MASK="999-99-9999" ISDATE="False" Visible="False"></maskedinput:maskedtextbox>


                        <asp:label id="lblCharge" Width="48px" RUNAT="server" ENABLEVIEWSTATE="False" Visible="False">Percent</asp:label>
                        <asp:CheckBox ID="chkUserMod" runat="server" Visible="False" />

<%--                                <asp:Label ID="lblGapDate" runat="server" EnableViewState="False">Gap Dates:</asp:Label>
                                <asp:Label ID="lblGapDate0" runat="server" EnableViewState="False">From:</asp:Label>
                                <asp:Label ID="lblGapDate1" runat="server" EnableViewState="False">To:</asp:Label>
--%>

                        <asp:label id="Label19" RUNAT="server" CssClass="col-md-4 col-form-labe fs-lbl-s label-vertical-align" ENABLEVIEWSTATE="False" Visible="False">Supplier</asp:label>
                        <asp:dropdownlist id="ddlSupplier" RUNAT="server" Visible="False" CSSCLASS="form-select fs-txt-s" onselectedindexchanged="ddlSupplier_SelectedIndexChanged"></asp:dropdownlist>



                        
                        <asp:label id="LblSelectAgent" RUNAT="server" ENABLEVIEWSTATE="False" Visible="False">Available Agent - Level</asp:label>
                        
                        <asp:label id="lblSelectedAgent" RUNAT="server" ENABLEVIEWSTATE="False" Visible="False">Selected Agent
                        </asp:label>



                                <%--<maskedinput:maskedtextbox id="txtPriPolEffecDate1" tabIndex="22" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                                <INPUT id="btnCalendar" style="WIDTH: 21px; HEIGHT: 21px" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.txtPriPolEffecDate1','calendar_window','width=250,height=250');calendar_window.focus()" tabIndex="23" type="button"
                                    value="..." name="btnCalendar" RUNAT="server">--%>
                                <%--<asp:TextBox ID="txtPriPolEffecDate1" runat="server"  
                                                                     onclick="ShowDateTimePicker3();" ISDATE="true" TabIndex="25"></asp:TextBox>--%>


                                    <%--<asp:TextBox ID="txtPriPolLimits1" runat="server"  
                                                                     MaxLength="50" TabIndex="26"  
                                                                    ></asp:TextBox>--%>


                                        <asp:Panel ID="pnlEndorsement" runat="server">


                                            <asp:CheckBox ID="chkUserModEndo" runat="server" Visible="False" />


                                            <asp:TextBox ID="txtEndorsementID" runat="server" MaxLength="75" TabIndex="24" Visible="False"></asp:TextBox>


                                            <asp:Button ID="btnHideEndoPanel" runat="server" BackColor="#BB1509" BorderColor="#BB1509" onclick="btnHideEndoPanel_Click" tabIndex="72" Text="X" Visible="False" Width="25px" />


                                        </asp:Panel>


                                        <asp:Panel ID="pnlPrimary" runat="server">

                                        </asp:Panel>





                                        <asp:Panel ID="pnlExcess" runat="server">
                                        </asp:Panel>



                                        <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" BackColor="#F4F4F4" Style="display: none;">
                                            <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
                            font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
                            background-repeat: no-repeat; text-align: left; vertical-align: bottom;">
                                                <asp:Label ID="Label48" runat="server" Font-Italic="False" Font-Names="Lucida Sans" Font-Size="14pt" Text="Message.." ForeColor="#000066" />
                                            </div>
                                            <div class="CajaDialogoDiv">



                                                <asp:TextBox ID="lblRecHeader" runat="server" Font-Italic="False" Font-Underline="False" Text="Message" CssClass="" TextMode="MultiLine" Height="170px" BorderColor="Transparent" BorderStyle="None" BorderWidth="0px"></asp:TextBox>



                                            </div>
                                            <div class="CajaDialogoDiv" align="center">
                                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                                            </div>
                                        </asp:Panel>
                                        <Toolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground" CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript="" OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                                        </Toolkit:ModalPopupExtender>
                                        <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" BorderWidth="0" Visible="true" />
                                        <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                                        <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server" Visible="False"></maskedinput:maskedtextheader>
                                        <INPUT id="ConfirmDialogBoxPopUp" type="hidden" size="1" value="false" name="ConfirmDialogBoxPopUp" runat="server"><input id="inputSupplierIndex" runat="server" enableviewstate="true" name="ConfirmDialogBoxPopUp" type="hidden" value="-1" />
                    </div>
                    </div>
    </form>
    <script type="text/javascript">
        $('.datepicker-p1').datepicker();
    </script>
</body>

            </HTML>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" AutoEventWireup="true" Inherits="EPolicy.AHCPrimaryPolicies" CodeFile="AHCPrimaryPolicies.aspx.cs" %>
        <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
            <!DOCTYPE html PUBLIC"-//W3C//DTD XHTML 1.0 Transitional//EN""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        .toggler { height: 1px;
           margin-left: 0px;
       }
        #button { padding: .5em 2em; text-decoration: none; }
        #btnCloseEffect {text-decoration: none; }
        #effect { width: 315px; height: 228px; padding: 0.4em; position: relative;}
        #effect h3 { margin: 0; padding: 0.4em; text-align: center; }
        .ui-effects-transfer { border: 2px dotted gray; } 
    </style>   
	<style type="text/css">	
	    #jq-books{width:200px;float:right;margin-right:0}
	    #jq-books li{line-height:1.25em;margin:1em 0 1.8em;clear:left}
	    #home-content-wrapper #jq-books a.jq-bookImg{float:left;margin-right:10px;width:55px;height:70px}
	    #jq-books h3{margin:0 0 .2em 0}
	    #home-content-wrapper #jq-books h3 a{font-size:1em;color:black;}
	    #home-content-wrapper #jq-books a.jq-buyNow{font-size:1em;color:white;display:block;background:url(http://static.jquery.com/files/rocker/images/btn_blueSheen.gif) 50% repeat-x;text-decoration:none;color:#fff;font-weight:bold;padding:.2em .8em;float:left;margin-top:.2em;}
	    .headfield1
        {
            text-align: left;
            margin-left: 0px;
            margin-right: 0px;
            }
	    .style1
        {
            width: 8px;
        }
        .style2
        {
        }
        .style3
        {
            width: 198px;
        }
        .style4
        {
            width: 310px;
        }
        .style5
        {
            width: 196px;
        }
        .style8
        {
            width: 8px;
            height: 9px;
        }
        .style9
        {
            width: 106px;
            height: 9px;
        }
        .style10
        {
            width: 198px;
            height: 9px;
        }
        .style11
        {
            width: 310px;
            height: 9px;
        }
        .style12
        {
            width: 196px;
            height: 9px;
        }
        .style13
        {
            width: 100px;
            height: 9px;
        }
        .style14
        {
            height: 9px;
        }
	    .style15
        {
            height: 18px;
            width: 284px;
        }
        .style16
        {
            height: 15px;
            width: 284px;
        }
        .style17
        {
            height: 21px;
            width: 284px;
        }
        .style18
        {
            height: 20px;
            width: 284px;
        }
        .style19
        {
            height: 17px;
            width: 284px;
        }
        .style20
        {
            height: 13px;
            width: 284px;
        }
        .style21
        {
            height: 3px;
            width: 284px;
        }
	    .style22
        {
            font-size: 9pt;
            margin-right: 1px;
            margin-left: 0px;
        }
        .style23
        {
            height: 3px;
            width: 19px;
        }
        .style24
        {
            width: 19px;
        }
        .style25
        {
            height: 358px;
            width: 19px;
        }
        .style26
        {
            height: 13px;
            width: 19px;
        }
        .style27
        {
            height: 27px;
            width: 19px;
        }
	    .style35
        {
            height: 22px;
        }
        .style36
        {
            width: 97px;
            height: 22px;
        }
        .style38
        {
            height: 21px;
        }
        .headForm1
        {
            margin-right: 2px;
        }
        .style43
        {
            height: 19px;
            width: 218px;
        }
        #Table12
        {
            width: 608px;
        }
        .style46
        {
            height: 22px;
            text-align: left;
        }
        .style45
        {
            height: 22px;
            text-align: center;
        }
        .style49
        {
            width: 186px;
            height: 19px;
            text-align: left;
        }
        .style52
        {
            height: 107px;
        }
        .style53
        {
            text-align: right;
        }
        </style>
	
	<script type="text/javascript">
		function getExpDt()
			{
				pdt = new Date(document.Pol.txtEffDt.value);
				trm = parseInt(document.Pol.TxtTerm.value);
				mnth = pdt.getMonth() + trm;
				if (!isNaN(mnth))
				{
					pdt.setMonth(mnth%12);
					if (mnth > 11)
					{
						var t = pdt.getFullYear() + Math.floor(mnth/12);
						pdt.setFullYear(t);
					}
					document.Pol.txtExpDt.value= parse(pdt);
				}
			}
			
		function parse(dt)
			{
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
			
		function SetRadioButton()
			{
			
				if (document.Pol.rdbLoan.checked = true)
				{
					document.Pol.rdbLoan.checked = true;
					document.Pol.rdbLeasing.checked= false;
				}
			}
			
			function SetRadioButton2()
			{
				if (document.Pol.rdbLoan.checked = true)
				{
					document.Pol.rdbLoan.checked = false;
					document.Pol.rdbLeasing.checked = true;
				}
			}
			
			function SetFieldDate()
			{
			    document.Pol.TxtPurchaserDate.value = document.Pol.txtEffDt.value;
			    document.Pol.TxtEffDateCompany.value = document.Pol.txtEffDt.value;
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
                    //					        //document.Pol.TxtCity.value ="";
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
                                //document.Pol.TxtCity.value ="";
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
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl p-18 mb-4">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:label id="Label46" runat="server" class="fs-16">Policies:</asp:label>
                            <asp:label id="LblControlNo" runat="server" class="fs-16"> No.:</asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button ID="btnComments" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Comments" onclick="btnComments_Click1" />
                            <asp:Button ID="btnRate" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Rate" />
                            <asp:button id="btnPrintPolicy" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print" onclick="btnPrintPolicy_Click"></asp:button>
                            <asp:button id="btnEnablePrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Enable Print" onclick="btnEnablePrint_Click" onclientclick="return confirm('Enabling Policy Printing, Continue?');"></asp:button>
                            <asp:button id="btnCancellation" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancellation" onclick="btnCancellation_Click"></asp:button>
                            <asp:Button ID="btnRenew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnRenew_Click" Text="Renew" />
                            <asp:button id="btnReinstatement" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Reinstatement" onclick="btnReinstatement_Click"></asp:button>
                            <asp:button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:button>
                            <asp:button id="btnAdd2" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Add" onclick="btnAdd2_Click" Visible="False"></asp:button>
                            <asp:button id="btnDelete" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Delete" onclick="btnDelete_Click" onclientclick="return confirm('Are you certain you want to delete this Policy?');"></asp:button>
                            <asp:button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Modify" onclick="btnEdit_Click"></asp:button>
                            <asp:button id="btnCancel" runat="server" class="btn-bg-theme2 btn-h-30 btn-r-4" Text="Cancel" onclick="btnCancel_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:button>
                            <asp:Button ID="btnHistory" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnHistory_Click" Text="History" />
                            <asp:button id="btnEndor" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="New Endorsement" onclick="btnEndor_Click"></asp:button>
                            <asp:button id="btnComissions" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Commissions" onclick="btnComissions_Click"></asp:button>
                            <asp:button id="btnPayments" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Payments" onclick="btnPayments_Click"></asp:button>
                            <asp:button id="btnFinancialCanc" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Financial Canc." onclick="btnFinancialCanc_Click" Visible="False"></asp:button>
                            <asp:button id="btnTailQuote" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Tail Quote" onclick="btnTailQuote_Click"></asp:button>
                            <asp:button id="btnRegistry" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Registry" onclick="btnRegistry_Click"></asp:button>
                            <asp:button id="btnPrintCertificate" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print Certificate" onclick="btnPrintCertificate_Click"></asp:button>
                            <asp:button id="btnPolicyCert" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Policy Cert." onclick="btnPolicyCert_Click" Visible="False"></asp:button>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr />
                    </div>

                    <div id="effect" class="ui-widget-header ui-corner-all" style="width: 316px; display:none">
                        <asp:Panel ID="Panel1" runat="server" Height="244px">

                            <asp:Label ID="Label49" runat="server" Text="Select Rate"></asp:Label>

                            <asp:Label ID="Label13" runat="server" Text="Specialty:"></asp:Label>
                            <asp:DropDownList ID="ddlRate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:Label ID="Label14" runat="server" Text="Iso Code:"></asp:Label>
                            <asp:TextBox ID="txtIsoCode" runat="server"></asp:TextBox>

                            <asp:Label ID="Label47" runat="server" Text="Class:"></asp:Label>
                            <asp:TextBox ID="txtClass" runat="server"></asp:TextBox>

                            <asp:Label ID="Label15" runat="server" Text="Rate 1"></asp:Label>

                            <asp:Label ID="Label43" runat="server" Text="Rate 2"></asp:Label>

                            <asp:Label ID="Label45" runat="server" Text="Rate 3"></asp:Label>

                            <asp:Label ID="Label44" runat="server" Text="MCM Rate"></asp:Label>

                            <asp:TextBox ID="txtRate1" runat="server"></asp:TextBox>

                            <asp:TextBox ID="txtRate2" runat="server"></asp:TextBox>

                            <asp:TextBox ID="txtRate3" runat="server"></asp:TextBox>

                            <asp:TextBox ID="txtRate4" runat="server"></asp:TextBox>

                            <asp:Button ID="btnCloseEffect" runat="server" Text="Close" />

                        </asp:Panel>

                        <div class="col-md-12">
                            <hr />
                        </div>
                    </div>





                    <asp:label id="Label23" runat="server" ENABLEVIEWSTATE="False">Line of Business</asp:label>

                    <asp:dropdownlist id="ddlPolicyClass" runat="server" AutoPostBack="True" onselectedindexchanged="ddlPolicyClass_SelectedIndexChanged" Visible="False"></asp:dropdownlist>
                    <!-- #region Body part1 -->
                    <div class="row">
                        <!-- Columna 1-->
                        <div class="col-md-4">
                            <div class="col-md-12 mb-3">
                                <asp:label id="Label3" class="fs-16" runat="server">Customer Information</asp:label>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblEmail" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Customer No.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtCustomerNo" class="form-control fs-txt-s" runat="server" MAXLENGTH="10"></asp:textbox>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label2" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">First Name</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <div class="input-group">
                                        <asp:textbox id="TxtFirstName" class="form-control w-50 fs-txt-s" runat="server" MAXLENGTH="25"></asp:textbox>
                                        <asp:label id="Label1" class="input-group-text w-15 fs-txt-s" runat="server" ENABLEVIEWSTATE="False">Init.</asp:label>
                                        <asp:textbox id="TxtInitial" class="form-control w-25 fs-txt-s" runat="server" MAXLENGTH="1"></asp:textbox>
                                    </div>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblLastName1" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Last Name 1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtLastname1" class="form-control fs-txt-s" runat="server" MAXLENGTH="15" ontextchanged="txtLastname1_TextChanged"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblLastName2" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Last Name 2</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtLastname2" runat="server" class="form-control fs-txt-s" MAXLENGTH="15"></asp:textbox>

                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblAdditionalName" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Add. Name:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtAdditionalName" runat="server" class="form-control fs-txt-s" MAXLENGTH="100"></asp:textbox>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label36" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Address 1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtAddrs1" runat="server" class="form-control fs-txt-s" MAXLENGTH="60"></asp:textbox>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label37" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Address 2</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtAddrs2" runat="server" class="form-control fs-txt-s" MAXLENGTH="60"></asp:textbox>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label39" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">City</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtCity" runat="server" class="form-control fs-txt-s" MAXLENGTH="14"></asp:textbox>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label40" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Zip Code</asp:label>
                                </div>
                                <div class="col-md-8 d-inline-flex">
                                    <asp:textbox id="TxtState" runat="server" class="form-control w-25 fs-txt-s" MAXLENGTH="2"></asp:textbox>
                                    <maskedinput:maskedtextbox id="TxtZip" runat="server" class="form-control w-75 fs-txt-s" MAXLENGTH="10" MASK="CCCCCC" ISDATE="False" IsCurrency="False" IsZipCode="True"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                        <!-- Columna 2-->
                        <div class="col-md-4">
                            <div class="col-md-12 mb-3 f-right">
                                <asp:Button id="btnNew" class="btn-h-30 btn-bg-theme2 btn-r-4" runat="server" Text="New" ToolTip="Add New policy with the same information" onclick="btnNew_Click"></asp:Button>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <div class="">
                                        <asp:label id="lblPolicyNo" runat="server" class="fs-lbl-s">Policy No.</asp:label>
                                        <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" AutoPostBack="True" OnCheckedChanged="ChkAutoAssignPolicy_CheckedChanged" Text="" ToolTip="Auto Assign Policy" />
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtPolicyNo" runat="server" class="form-control fs-txt-s" MAXLENGTH="15"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblCertificate" runat="server" class="fs-lbl-s">Certificate</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtCertificate" runat="server" class="form-control fs-txt-s" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label29" runat="server" EnableViewState="False" class="fs-lbl-s">Policy Type</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <div class="input-group">
                                        <asp:textbox id="TxtPolicyType" runat="server" class="form-control w-50 fs-txt-s" MAXLENGTH="3"></asp:textbox>
                                        <asp:label class="input-group-text w-25 fs-txt-s" runat="server" ENABLEVIEWSTATE="False">Suffix</asp:label>
                                        <asp:textbox id="TxtSufijo" runat="server" class="form-control w-15 fs-txt-s" MAXLENGTH="2"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label16" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Anniversary</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtAnniversary" runat="server" MaxLength="2" class="form-control fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label5" runat="server" class="fs-lbl-s" EnableViewState="False">Term</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtTerm" runat="server" class="form-control fs-txt-s" MAXLENGTH="3"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label20" runat="server" class="fs-lbl-s" EnableViewState="False">Retro. Date</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtRetroactiveDate" runat="server" Columns="30" class="form-control fs-txt-s" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label4" runat="server" class="fs-lbl-s" EnableViewState="False">Effective Date</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtEffDt" runat="server" class="form-control fs-txt-s" Columns="30" IsDate="True" onclick="ShowDateTimePicker();"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label11" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Exp. Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtExpDt" runat="server" class="form-control fs-txt-s" Columns="30" IsDate="True" onclick="ShowDateTimePicker4();"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label27" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Entry Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtEntryDate" tabIndex="47" runat="server" class="form-control fs-txt-s" IsDate="True" Columns="30"></asp:textbox>

                                </div>
                            </div>
                        </div>
                        <!-- Columna 3-->
                        <div class="col-md-4">
                            <div class="col-md-12 mb-3">
                                <asp:label id="LblStatus" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Inforce/</asp:label>
                            </div>
                            <div class="col-md-12 mb-3-5">
                                <asp:CheckBox ID="chkPaymentGA" runat="server" Text="Checked Payment by GA" />
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label18" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Agency</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlAgency" runat="server" class="form-select fs-txt-s" onselectedindexchanged="ddlAgency_SelectedIndexChanged"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label75" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Branch</asp:label>

                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlCity" runat="server" class="form-select fs-txt-s"> </asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label21" runat="server" class="fs-lbl-s" EnableViewState="False">Agent</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownlist id="ddlAgent" runat="server" class="form-select fs-txt-s">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label6" runat="server" class="fs-lbl-s">Originated At</asp:label>
                                </div>
                                <div class="col-md-8">

                                    <asp:dropdownlist id="ddlOriginatedAt" runat="server" class="form-select fs-txt-s"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label9" runat="server" class="fs-lbl-s">Ins. Company</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlInsuranceCompany" runat="server" class="form-select fs-txt-s" onselectedindexchanged="ddlInsuranceCompany_SelectedIndexChanged">
                                    </asp:dropdownlist>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <!-- Label42 - Este estaba Visible: Faslse y por criterio propio lo quite-->
                                    <asp:label id="Label42" runat="server" class="fs-lbl-s">Group</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlGroup" runat="server" class="form-select fs-txt-s" AutoPostBack="True" onselectedindexchanged="ddlGroup_SelectedIndexChanged"></asp:dropdownlist>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label28" runat="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Corporation</asp:label>
                                </div>
                                <div class="col-md-8">

                                    <asp:dropdownlist id="ddlCorparation" runat="server" class="form-select fs-txt-s"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblFinancial" runat="server" class="fs-lbl-s">Financial Inst.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlFinancial" runat="server" class="form-select fs-txt-s"></asp:dropdownlist>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- #endregion -->
                    <!-- #region Body Part2-->
                    <div class="row">
                        <!-- Columna 1-->
                        <div class="col-md-4">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblHomePhone" runat="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Home Phone</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtHomePhone" runat="server" class="form-control fs-txt-s" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblWorkPhone" runat="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Work Phone</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtWorkPhone" runat="server" class="form-control fs-txt-s" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label8" runat="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Cellular</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="TxtCellular" runat="server" class="form-control fs-txt-s" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label26" runat="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">E-mail</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtEmail" runat="server" class="form-control fs-txt-s" AXLENGTH="100"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label51" runat="server" EnableViewState="False" class="fs-lbl-s">License:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtLicense" class="form-control fs-txt-s" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label17" runat="server" EnableViewState="False" class="fs-lbl-s">ApplicationID</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtApplicationID" runat="server" class="form-control fs-txt-s" MaxLength="10"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblComments" class="fs-lbl-s" runat="server" ENABLEVIEWSTATE="False">Comments</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="TxtComments" class="form-control w-266 h-6 fs-txt-s" runat="server" MAXLENGTH="2000" TextMode="MultiLine"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <!-- Columna 2-->
                        <div class="col-md-4">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label41" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Charge</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="TxtCharge" tabIndex="48" RUNAT="server" class="form-control fs-txt-s" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCC" ISDATE="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblPremium" runat="server" class="fs-lbl-s">Premium</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="TxtPremium" runat="server" class="form-control fs-txt-s" MAXLENGTH="14" MASK="CCCCCCCCCC" ISDATE="False" AutoPostBack="True" ontextchanged="TxtPremium_TextChanged"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblPremium0" runat="server" class="fs-lbl-s">Canc. Amount</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="TxtCancAmount" runat="server" class="form-control fs-txt-s" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCCCCCC" ISDATE="False" Enabled="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblTotPremum" runat="server" class="fs-lbl-s">Tot. Premium</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="TxtTotalPremium" runat="server" class="form-control fs-txt-s" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCCCCCC" ISDATE="False" Enabled="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="lblDiscount" runat="server" class="fs-lbl-s">Group Disc.</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <MaskedInput:MaskedTextBox ID="txtInvoiceNumber" runat="server" class="form-control fs-txt-s" IsCurrency="False" IsDate="False" Mask="CCCCCCCCCC" MaxLength="14"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label76" runat="server" EnableViewState="False" class="fs-lbl-s">Prospect Number</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <MaskedInput:MaskedTextBox ID="TxtProspectNo" class="form-control fs-txt-s" runat="server" Enabled="False" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" MAXLENGTH="14"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>

                        </div>
                        <!-- Columna 3-->
                        <div class="col-md-4">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblOtherSpecialty" runat="server" class="fs-lbl-s">Other Spec.</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlOtherSpecialty" runat="server" class="form-select fs-txt-s"></asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">

                                    <asp:Label ID="Label72" runat="server" EnableViewState="False" class="fs-lbl-s">Other Agent</asp:Label>
                                </div>
                                <div class="col-md-8">

                                    <asp:Dropdownlist id="ddlAgent2" class="form-select fs-txt-s" runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="lblIsoCode" runat="server" EnableViewState="False" class="fs-lbl-s">IsoCode</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList id="ddlIsoCode" runat="server" class="form-select fs-txt-s" onselectedindexchanged="ddlIsoCode_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="lblSpecialty" runat="server" EnableViewState="False" class="fs-lbl-s">Specialty</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlSpecialty" runat="server" class="form-select fs-txt-s" onselectedindexchanged="ddlSpecialty_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>

                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="Label74" runat="server" EnableViewState="False" class="fs-lbl-s">Has Claim?</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="True" onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                        <asp:ListItem Value="1">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="lblClaimNo" runat="server" EnableViewState="False" class="fs-lbl-s">Claim No</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtClaimNumber" runat="server" class="form-control fs-txt-s" Columns="30" TextMode="MultiLine"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:Label ID="lblGapDate" runat="server" EnableViewState="False" class="fs-lbl-s">Gap Dates:</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <asp:Label ID="lblGapDate0" runat="server" EnableViewState="False" class="fs-lbl-s">From:</asp:Label>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGapBegDate" runat="server" class="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker6();"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGapBegDate2" runat="server" class="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker8();"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGapBegDate3" runat="server" class="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker10();"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <asp:Label ID="lblGapDate1" runat="server" EnableViewState="False" class="fs-lbl-s">To:</asp:Label>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGapEndDate" runat="server" class="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker7();"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGapEndDate2" runat="server" class="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker9();"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtGapEndDate3" runat="server" class="form-control fs-txt-s" Columns="30" onclick="ShowDateTimePicker11();"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- #endregion -->
                    <div class="col-md-12">
                        <hr />
                    </div>



                    <div class="row mb-1">
                        <div class="col-md-4">

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 f-right">
                            <asp:label id="LblSelectAgent" runat="server" ENABLEVIEWSTATE="False" Visible="False">Available Agent - Level</asp:label>
                            <asp:dropdownlist id="ddlAvailableAgent" runat="server" class="form-select fs-txt-s mb-5"></asp:dropdownlist>
                            <asp:button id="cmdSelect" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text=">>" onclick="cmdSelect_Click"></asp:button>

                            <asp:Label ID="Label25" runat="server" EnableViewState="False" class="fs-lbl-s d-block">Eff. Date</asp:Label>
                            <maskedinput:maskedtextbox id="txtPriPolEffecDate1" runat="server" class="form-control fs-txt-s mb-1" ISDATE="True"></maskedinput:maskedtextbox>
                            <INPUT id="btnCalendar" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.txtPriPolEffecDate1','calendar_window','width=250,height=250');calendar_window.focus()" type="button" value="..." name="btnCalendar" runat="server">

                        </div>
                        <div class="col-md-4">
                            <asp:label id="lblSelectedAgent" runat="server" ENABLEVIEWSTATE="False" Visible="False">Selected Agent</asp:label>
                            <asp:listbox id="ddlSelectedAgent" runat="server" class="form-control fs-txt-s mb-1" onselectedindexchanged="ddlSelectedAgent_SelectedIndexChanged"></asp:listbox>
                            <asp:button id="cmdRemove" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="<<" onclick="cmdRemove_Click"></asp:button>

                            <asp:Label ID="Label24" runat="server" class="fs-lbl-s d-block" EnableViewState="False">Policy Limits</asp:Label>
                            <asp:DropDownList ID="ddlPriPolLimits1" runat="server" class="form-select fs-txt-s mb-1" AutoPostBack="True" OnSelectedIndexChanged="ddlPriPolLimits1_SelectedIndexChanged"></asp:DropDownList>


                            <asp:Label ID="Label30" runat="server" class="fs-lbl-s" EnableViewState="False">Policy No. Other Company</asp:Label>
                            <asp:TextBox ID="txtPriClaims1" runat="server" class="form-control fs-txt-s mb-1" MaxLength="50"></asp:TextBox>



                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblUpdateForm" runat="server" EnableViewState="False" class="fs-lbl-s">Update Form</asp:Label>
                            <asp:CheckBox ID="chkUpdateForm" runat="server" />

                            <asp:label id="lblSocialSecurity" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False" Visible="False">Social Security</asp:label>
                            <maskedinput:maskedtextbox id="txtSocialSecurity" runat="server" class="form-control fs-txt-s mb-1" MAXLENGTH="11" MASK="999-99-9999" ISDATE="False" Visible="False"></maskedinput:maskedtextbox>

                            <asp:Label ID="lblGapDate2" runat="server" class="fs-lbl-s d-block" EnableViewState="False">Num. of Employees:</asp:Label>
                            <asp:TextBox ID="txtNumberOfEmployees" runat="server" class="form-control fs-txt-s mb-1" Columns="30"></asp:TextBox>

                            <asp:Label ID="Label12" runat="server" class="fs-lbl-s" EnableViewState="False">Liability A:</asp:Label>
                            <asp:dropdownlist id="ddlPrMedicalLimits" runat="server" class="form-select fs-txt-s mb-1" AutoPostBack="True" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged2">
                            </asp:DropDownList>

                            <asp:label id="Label19" runat="server" class="fs-lbl-s" ENABLEVIEWSTATE="False" Visible="False">Supplier</asp:label>
                            <asp:dropdownlist id="ddlSupplier" runat="server" class="form-select fs-txt-s mb-1" Visible="False" onselectedindexchanged="ddlSupplier_SelectedIndexChanged"></asp:dropdownlist>

                            <asp:CheckBox ID="chkPending" runat="server" class="fs-lbl-s d-block" Text="Pending" />

                            <asp:Label ID="lblCarrier" runat="server" class="fs-lbl-s" EnableViewState="False">Previous Carrier Name</asp:Label>
                            <asp:TextBox ID="txtPriCarierName1" runat="server" class="form-control fs-txt-s mb-1" MaxLength="75"></asp:TextBox>
                        </div>
                    </div>


                    <asp:label id="lblCharge" runat="server" ENABLEVIEWSTATE="False" Visible="False">Percent</asp:label>
                    <asp:CheckBox ID="chkUserMod" runat="server" Visible="False" />
                    <asp:button id="btnChargeCalc" runat="server" Text="Calculate" onclick="CalculateCharge" Visible="False"></asp:button>
                    <maskedinput:maskedtextbox id="TxtUserPremium" runat="server" MAXLENGTH="14" MASK="CCCCCCCCCC" ISDATE="False" AutoPostBack="True" ontextchanged="TxtPremium_TextChanged" Visible="False"></maskedinput:maskedtextbox>














                    <asp:label id="Label7" runat="server" ENABLEVIEWSTATE="False">Covers:</asp:label>

                    <asp:label id="Label10" runat="server" ENABLEVIEWSTATE="False">Limits</asp:label>





















                    <asp:Panel ID="pnlEndorsement" runat="server">
                    </asp:Panel>
                    <asp:Label ID="lblEndorsement" runat="server" EnableViewState="False">Endorsements:</asp:Label>

                    <asp:CheckBox ID="chkUserModEndo" runat="server" Visible="False" />

                    <asp:TextBox ID="txtEndorsementID" runat="server" MaxLength="75" Visible="False"></asp:TextBox>

                    <asp:Button ID="btnHideEndoPanel" runat="server" onclick="btnHideEndoPanel_Click" Text="X" Visible="False" />
                    <div class="row">
                        <div class="col-md-auto">
                            <asp:Label ID="lblEndorsementNo" runat="server" class="fs-lbl-s" EnableViewState="False">Endorsement No.:</asp:Label>
                            <asp:TextBox ID="txtEndorsementNo" runat="server" class="form-control fs-txt-s" MaxLength="75"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:Label ID="lblDatePrepared" runat="server" class="fs-lbl-s" EnableViewState="False">Date Prepared:</asp:Label>
                            <asp:TextBox ID="txtDatePrepared" runat="server" class="form-control fs-txt-s" Columns="30" IsDate="True"></asp:TextBox>

                        </div>
                        <div class="col-md-auto">
                            <asp:Label ID="lblEndoEffDate" runat="server" class="fs-lbl-s" EnableViewState="False">Endo. Eff. Date:</asp:Label>
                            <asp:TextBox ID="txtEndoEffDate" runat="server" class="form-control fs-txt-s" onclick="ShowDateTimePicker5();"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:Label ID="lblEndoRetroDate" runat="server" class="fs-lbl-s" EnableViewState="False">Endo. Retro. Date:</asp:Label>
                            <asp:TextBox ID="txtRetroEffDate" runat="server" class="form-control fs-txt-s" onclick="ShowDateTimePickerEndoRetroDate();"></asp:TextBox>

                        </div>

                        <div class="col-md-auto">
                            <asp:Label ID="lblEndoPremium" runat="server" class="fs-lbl-s" EnableViewState="False">Endo. Premium:</asp:Label>
                            <asp:TextBox ID="txtEndoPremium" runat="server" class="form-control fs-txt-s" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged"></asp:TextBox>
                        </div>
                        <div class="col-md-auto">
                            <asp:Label ID="lblEndoType" runat="server" class="fs-lbl-s" EnableViewState="False">Endorsement Type:</asp:Label>
                            <asp:DropDownList ID="ddlEndoType" runat="server" class="form-select fs-txt-s">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <asp:Label ID="lblEndoComments" runat="server" class="fs-lbl-s" EnableViewState="False">Comments:</asp:Label>
                        <asp:TextBox ID="txtEndoComments" runat="server" class="form-control fs-txt-s h-6" MAXLENGTH="2000" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-md-12">
                        <asp:Label ID="lblEndorsementHistory" runat="server" class="fs-lbl-s fw-bold" EnableViewState="False">Endorsements:</asp:Label>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md-12">
                        <asp:Label ID="Label22" runat="server" EnableViewState="False" class="fs-lbl-s fw-bold">History:</asp:Label>
                    </div>








                    <asp:DataGrid ID="dtEndorsement" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="0" Font-Names="Arial" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="16px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center" OnItemCommand="dtEndorsement_ItemCommand"
                        PageSize="8" TabIndex="9" Width="90%" HeaderStyle-ForeColor="white" >
                        <FooterStyle BackColor="Navy" ForeColor="#003399" />
                        <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" CssClass="Numbers" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                        <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                        <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                <ItemStyle/>
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
                                <ItemStyle/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EffectiveDate" HeaderText="Eff. Date">
                                <HeaderStyle />
                                <ItemStyle/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="RetroactiveDate" HeaderText="Retro. Date">
                                <HeaderStyle />
                                <ItemStyle/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EndorsementType" HeaderText="Type">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EndorsementPremium" HeaderText="Premium">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="50px" />
                                <ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EndorsementComments" HeaderText="Comments">
                                <HeaderStyle />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EndorsementHistory" HeaderText="History" Visible="False">
                                <HeaderStyle />

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
                        </Columns>
                        <HeaderStyle BackColor="#BB1509" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                    </asp:DataGrid>



                    <asp:button id="btnRefresh" runat="server" Text="Refresh" onclick="btnRefresh_Click" Visible="False"></asp:button>

                    <asp:DataGrid ID="DtSearchPayments" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#BB1509" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="0" Font-Names="Arial" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="193px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center" OnItemCommand="DtSearchPayments_ItemCommand1"
                        PageSize="8" TabIndex="9" Width="90%" HeaderStyle-ForeColor="white">
                        <FooterStyle BackColor="Navy" ForeColor="#003399" />
                        <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" CssClass="Numbers" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                        <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                        <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                <ItemStyle/>
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
                                <ItemStyle/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Certificate" HeaderText="Certificate" Visible="False">
                                <HeaderStyle />
                                <ItemStyle/>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Sufijo" HeaderText="Suffix">
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv.">
                                <HeaderStyle Width="50px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">
                                <HeaderStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">
                                <HeaderStyle />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Comments" HeaderText="Comments">
                            </asp:BoundColumn>

                        </Columns>
                        <HeaderStyle BackColor="#BB1509" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                    </asp:DataGrid>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md-12">
                        <asp:Label ID="Label52" runat="server" class="fs-lbl-s">Primary - Technicians & Nurses</asp:Label>
                        <asp:textbox id="TxtID" Visible="False"></asp:textbox>
                    </div>

                    <asp:Panel ID="pnlPrimary" runat="server">
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label53" runat="server" class="fs-lbl-s mb-1">Primary</asp:Label>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label54" runat="server" class="fs-lbl-s mb-1">Rate %</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label55" runat="server" class="fs-lbl-s mb-1">Premium</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label56" runat="server" class="fs-lbl-s mb-1">Quantity</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label57" runat="server" class="fs-lbl-s mb-1">Premium</asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label58" runat="server" class="fs-lbl-s mb-1">Physicians Assistant</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPrimaryTN1" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtRateTN1" runat="server" class="fs-txt-s mb-1 form-control">25%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPremiumTN1" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtQuantityTN1" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTotPremTN1" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label59" runat="server" class="fs-lbl-s mb-1">Nurse Midwife</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPrimaryTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtRateTN2" runat="server" class="fs-txt-s mb-1 form-control">50%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPremiumTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtQuantityTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTotPremTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label60" runat="server" class="fs-lbl-s mb-1">Nurse Anesthetist</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPrimaryTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtRateTN3" runat="server" class="fs-txt-s mb-1 form-control">75%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPremiumTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtQuantityTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTotPremTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label61" runat="server" class="fs-lbl-s mb-1">Nurse Practitioner</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPrimaryTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtRateTN4" runat="server" class="fs-txt-s mb-1 form-control">20%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPremiumTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtQuantityTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTotPremTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label62" runat="server" class="fs-lbl-s mb-1">All Other Personel</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPrimaryTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtRateTN5" runat="server" class="fs-txt-s mb-1 form-control">10%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtPremiumTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtQuantityTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTotPremTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">

                            </div>
                            <div class="col-md-2 f-right">
                                <asp:Label ID="Label63" runat="server" class="fs-lbl-s mb-1">Total:</asp:Label>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtRateTN6" runat="server" class="fs-txt-s mb-1 form-control">100%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtQuantityTN6" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtTotPremTN6" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>







                    </asp:Panel>

                    <div runat="server" id="section1">
                    </div>

                    <asp:Label ID="Label64" runat="server">Excess - Technicians & Nurses</asp:Label>

                    <asp:Panel ID="pnlExcess" runat="server">
                        <div class="row">
                            <div class="col-md-2">

                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label65" runat="server" class="fs-lbl-s mb-1">Excess</asp:Label>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label66" runat="server" class="fs-lbl-s mb-1">Rate %</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label67" runat="server" class="fs-lbl-s mb-1">Premium</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label31" runat="server" class="fs-lbl-s  mb-1">Quantity</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label32" runat="server" class="fs-lbl-s mb-1">Premium</asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label33" runat="server" class="fs-lbl-s">Physicians Assistant</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtExcessTN1" runat="server" class="fs-txt-s form-control mb-1"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtERateTN1" runat="server" class="fs-txt-s form-control mb-1">15%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEPremiumTN1" runat="server" class="fs-txt-s form-control mb-1"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEQuantityTN1" runat="server" class="fs-txt-s form-control mb-1"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtETotPremTN1" runat="server" class="fs-txt-s form-control mb-1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label34" runat="server" class="fs-lbl-s mb-1">Nurse Midwife</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtExcessTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtERateTN2" runat="server" class="fs-txt-s mb-1 form-control">50%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEPremiumTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEQuantityTN2" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtETotPremTN2" runat="server" class="fs-txt-s form-control mb-1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label35" runat="server" class="fs-lbl-s mb-1">Nurse Anesthetist</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtExcessTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtERateTN3" runat="server" class="fs-txt-s mb-1 form-control">50%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEPremiumTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEQuantityTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtETotPremTN3" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label68" runat="server" class="fs-lbl-s mb-1">Nurse Practitioner</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtExcessTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtERateTN4" runat="server" class="fs-txt-s mb-1 form-control">10%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEPremiumTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEQuantityTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtETotPremTN4" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label69" runat="server" class="fs-lbl-s mb-1">All Other Personel</asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtExcessTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtERateTN5" runat="server" class="fs-txt-s mb-1 form-control">2.5%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEPremiumTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEQuantityTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtETotPremTN5" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2 f-right">
                                <asp:Label ID="Label38" runat="server" class="fs-lbl-s mb-1">Total:</asp:Label>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="txtERateTN6" runat="server" class="fs-txt-s mb-1 form-control">100%</asp:TextBox>
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtEQuantityTN6" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtETotPremTN6" runat="server" class="fs-txt-s mb-1 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button3" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" OnClick="Button3_Click" Text="Calculate" />
                        </div>

                        <div class="col-md-12">
                            <hr>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label70" runat="server" class="fs-lbl-s">Total Primary Premium:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtTotalPrimary" runat="server" MaxLength="20" class="fs-txt-s form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label71" runat="server" class="fs-lbl-s">Total Premium:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtTotalExcess" runat="server" class="fs-txt-s form-control"></asp:TextBox>
                            </div>
                        </div>











                    </asp:Panel>







                    <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" Width="400px" BackColor="#F4F4F4" Style="display: none;">
                        <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
            font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
            background-repeat: no-repeat; text-align: left; vertical-align: bottom;">
                            <asp:Label ID="Label48" runat="server" Text="Message.." />
                        </div>
                        <div class="CajaDialogoDiv" style="color: #FFFFFF">

                            <asp:TextBox ID="lblRecHeader" runat="server" Font-Underline="False" Text="Message" TextMode="MultiLine"></asp:TextBox>

                        </div>
                        <div class="CajaDialogoDiv" align="center">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                        </div>
                    </asp:Panel>
                    <Toolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground" CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript="" OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                    </Toolkit:ModalPopupExtender>
                    <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" BorderWidth="0" Visible="true" />
                    <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server" Visible="False"></maskedinput:maskedtextheader>
                    <INPUT id="ConfirmDialogBoxPopUp" style="Z-INDEX: 102; LEFT: 802px; WIDTH: 35px; POSITION: absolute; TOP: 1056px; HEIGHT: 22px" type="hidden" size="1" value="false" name="ConfirmDialogBoxPopUp" runat="server"><input id="inputSupplierIndex" runat="server" enableviewstate="true" name="ConfirmDialogBoxPopUp" size="1" style="z-index: 102; left: 879px; width: 35px; position: absolute; top: 1053px;
                height: 22px" type="hidden" value="-1" />
                </div>

                </form>
            </body>

            </HTML>
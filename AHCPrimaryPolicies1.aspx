<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" AutoEventWireup="true" Inherits="EPolicy.AHCPrimaryPolicies" CodeFile="AHCPrimaryPolicies.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<link rel="stylesheet" href="StyleSheet.css" type="text/css"/>
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
			
			function SetCiudad()
			{
			   	for(i = 0;i <= document.Pol.ddlCiudad.options.length ; i++)
				{
				    //alert(document.Pol.ddlCiudad.options[i].value +' - 'document.Pol.TxtZip.value)
				    if(Number(document.Pol.ddlCiudad.options[i].value) == Number(document.Pol.TxtZip.value))
					{
					   //alert(document.Pol.ddlCiudad.options[i].text)
					   document.Pol.ddlCiudad.selectedIndex = i;
					   //document.Pol.TxtCity.value = document.Pol.ddlCiudad.options[i].text;
					   document.Pol.TxtZip.value = '00'+Number(document.Pol.TxtZip.value);
					   return;
					}
					else
					{
					    //document.Pol.TxtCity.value = "";
					    document.Pol.ddlCiudad.selectedIndex = -1;
					}
				}	
			}
			
			function SetZipCode()
			{				   
			   if(document.Pol.ddlCiudad.selectedIndex > 0)
			   {
			      document.Pol.TxtZip.value =  document.Pol.ddlCiudad.options[document.Pol.ddlCiudad.selectedIndex].value
			   }
			   else
			   {
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
	<body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF" topMargin="19" rightMargin="0">
		<form id="Pol" method="post" runat="server">
              <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
                AsyncPostBackTimeout="0">
            </Toolkit:ToolkitScriptManager>
			<TABLE id="Table8" style="Z-INDEX: 101; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 507px"
				cellSpacing="0" cellPadding="0" width="900" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 5px; POSITION: static; HEIGHT: 395px" align="right"
						colspan="1" rowspan="5" valign="top">
						<P align="center"><asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder></P>
					</TD>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 355px" cellSpacing="0" cellPadding="0"
								width="809" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; " align="left" class="style23">
										<TABLE id="Table10" style="WIDTH: 815px; HEIGHT: 51px" cellSpacing="0" 
                                            cellPadding="0" border="0" align="right">
											<TR>
												<TD align="left" class="style38">
													<asp:label id="Label46" runat="server" Width="68px" ForeColor="Black" 
                                                        Font-Names="Tahoma" Font-Size="11pt"
														CssClass="headForm1 " Height="16px" Font-Bold="True">Policies:</asp:label>
													<asp:label id="LblControlNo" runat="server" Width="72px" Font-Names="Tahoma" Font-Size="9pt"
														CssClass="headfield1" Height="16px"> No.:</asp:label>    </TD>
											</TR>
											<TR>
												<TD align="right" style="FONT-SIZE: 2pt" bgcolor="#A00000" height="25" 
                                                    valign="middle">
                                                    <asp:Button ID="btnComments" runat="server" BackColor="#8A0E0C" BorderColor="White" 
                                                        Font-Names="Tahoma" ForeColor="White" Height="23px" 
                                                        Text="Comments" Width="80px" onclick="btnComments_Click1" BorderStyle="Solid" 
                                                        BorderWidth="1px" CssClass="style22" />
                                                    <asp:Button ID="btnRate" runat="server" BackColor="#A00000" BorderColor="White"
                                                        BorderWidth="1px" Font-Names="Tahoma" Font-Size="9pt" ForeColor="White" Height="23px"
                                                        Text="Rate" Width="50px" CssClass="style22" margin-left= "1px;" 
                                                        BorderStyle="Solid" />
                                                    <asp:button 
                                                        id="btnPrintPolicy" tabIndex="71" runat="server" Width="50px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Print" BackColor="#A00000" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnPrintPolicy_Click" style="font-family: Tahoma; margin-left: 0px;" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
														<asp:button 
                                                        id="btnEnablePrint" tabIndex="71" runat="server" Width="100px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Enable Print" BackColor="#A00000" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnEnablePrint_Click" style="font-family: Tahoma" 
                                                        CssClass="style22" 
                                                            onclientclick="return confirm('Enabling Policy Printing, Continue?');" 
                                                        BorderStyle="Solid"></asp:button>
                                                    <asp:button 
                                                        id="btnCancellation" tabIndex="65" runat="server" Width="85px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Cancellation" BackColor="#A00000" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnCancellation_Click" style="font-family: Tahoma" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    <asp:Button ID="btnRenew" runat="server" BackColor="#A00000" BorderColor="White"
                                                        BorderWidth="1px" Font-Size="9pt" ForeColor="White" Height="23px" OnClick="btnRenew_Click"
                                                        TabIndex="65" Text="Renew" Width="55px" style="font-family: Tahoma" 
                                                        CssClass="style22" BorderStyle="Solid" /> 
                                                    <asp:button 
                                                        id="btnReinstatement" tabIndex="66" runat="server" Width="100px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Reinstatement" BackColor="#A00000" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnReinstatement_Click" style="font-family: Tahoma; margin-left: 0px;" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    <asp:button id="BtnSave" tabIndex="70" runat="server" ForeColor="White" Font-Names="Tahoma"
														Height="23px" Text="Save" BackColor="#A00000" BorderColor="White" BorderWidth="1px" onclick="BtnSave_Click" 
                                                        CssClass="style22" Width="45px" BorderStyle="Solid"></asp:button> 
													<asp:button id="btnAdd2" tabIndex="68" runat="server" Width="40px" 
                                                        Height="23px" Font-Names="Tahoma"
														ForeColor="White" BorderWidth="1px" BorderColor="White" BackColor="#A00000"
														Text="Add" onclick="btnAdd2_Click" Visible="False" CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    <asp:button 
                                                        id="btnDelete" tabIndex="67" runat="server" ForeColor="White" Font-Names="Tahoma"
														Height="23px" Text="Delete" BackColor="#A00000" BorderColor="White" BorderWidth="1px" Width="50px" 
                                                        onclick="btnDelete_Click" CssClass="style22" 
                                                        
                                                        
                                                        onclientclick="return confirm('Are you certain you want to delete this Policy?');" 
                                                        BorderStyle="Solid"></asp:button>
                                                    <asp:button id="btnEdit" 
                                                        tabIndex="69" runat="server" Width="55px" ForeColor="White" Font-Names="Tahoma"
														Height="23px" Text="Modify" BackColor="#A00000" BorderColor="White" BorderWidth="1px" onclick="btnEdit_Click" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
														<asp:button id="btnCancel" tabIndex="72" runat="server" ForeColor="White" Font-Names="Tahoma"
														Height="23px" Text="Cancel" BackColor="#A00000" BorderColor="White" BorderWidth="1px" Width="50px" 
                                                        onclick="btnCancel_Click" CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    <asp:button id="BtnExit" tabIndex="73" runat="server" Width="40px" 
                                                        ForeColor="White" Font-Names="Tahoma"
														Height="23px" Text="Exit" BackColor="#A00000" BorderColor="White" BorderWidth="1px" onclick="BtnExit_Click" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    </TD>
											</TR>
											<TR>
												<TD align="right" style="FONT-SIZE: 2pt" bgcolor="#8A0E0C" height="25" 
                                                    valign="middle">
                                                    <asp:Button ID="btnHistory" runat="server" BackColor="#8A0E0C" BorderColor="White"
                                                        BorderWidth="1px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnHistory_Click"
                                                        TabIndex="61" Text="History" Width="55px" CssClass="style22" 
                                                        BorderStyle="Solid" />
                                                    <asp:button id="btnEndor" tabIndex="63" runat="server" Width="120px" 
                                                        ForeColor="White" Font-Size="9pt"
														Height="23px" Text="New Endorsement" BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnEndor_Click" style="font-family: Tahoma" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button> 
                                                    <asp:button id="btnComissions" tabIndex="63" runat="server" Width="90px" 
                                                        ForeColor="White" Font-Size="9pt"
														Height="23px" Text="Commissions" BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnComissions_Click" style="font-family: Tahoma" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button> 
                                                    <asp:button 
                                                        id="btnPayments" tabIndex="64" runat="server" Width="75px" 
                                                        ForeColor="White" Font-Size="9pt"
														Height="23px" Text="Payments" BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnPayments_Click" style="font-family: Tahoma" CssClass="style22" 
                                                        BorderStyle="Solid"></asp:button>  
                                                    <asp:button 
                                                        id="btnFinancialCanc" tabIndex="65" runat="server" Width="100px" ForeColor="White"
														Font-Size="8pt" Height="23px" Text="Financial Canc." BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnFinancialCanc_Click" style="font-family: Tahoma; margin-left: 0px; font-size: 9pt;" 
                                                        CssClass="style22" Visible="False" BorderStyle="Solid"></asp:button>
                                                    <asp:button 
                                                        id="btnTailQuote" tabIndex="71" runat="server" Width="75px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Tail Quote" BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnTailQuote_Click" style="font-family: Tahoma" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    <asp:button 
                                                        id="btnRegistry" tabIndex="65" runat="server" Width="80px" ForeColor="White"
														Font-Size="8pt" Height="23px" Text="Registry" BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnRegistry_Click" style="font-family: Tahoma; margin-left: 0px; font-size: 9pt;" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
														<asp:button 
                                                        id="btnPrintCertificate" tabIndex="71" runat="server" Width="100px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Print Certificate" BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnPrintCertificate_Click" style="font-family: Tahoma" 
                                                        CssClass="style22" BorderStyle="Solid"></asp:button>
                                                    <asp:button 
                                                        id="btnPolicyCert" tabIndex="65" runat="server" Width="80px" ForeColor="White"
														Font-Size="8pt" Height="23px" Text="Policy Cert." BackColor="#8A0E0C" BorderColor="White" BorderWidth="1px" 
                                                        onclick="btnPolicyCert_Click" style="font-family: Tahoma; margin-left: 0px; font-size: 9pt;" 
                                                        CssClass="style22" Visible="False" BorderStyle="Solid"></asp:button>
														</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; " class="style24">
										<TABLE id="Table3" style="WIDTH: 815px" borderColor="#c00000" height="1" cellSpacing="0"
											borderColorDark="#c00000" cellPadding="0" bgColor="#c00000" borderColorLight="#c00000"
											border="0">
											<TR>
												<TD style="HEIGHT: 1px" background="Images2/Barra3.jpg" align="left">
                                                    <div class="toggler">
                                                            <div id="effect" class="ui-widget-header ui-corner-all" style="width: 316px; display:none">
                                                                <!--h3 class="" style="font-size: 14pt; font-family: Tahoma; text-decoration: underline">
                                                                     </h3-->
                                                                <asp:Panel ID="Panel1" runat="server" Height="244px">
                                                                     
                                                                        <table border="1" bordercolor="#330000" bordercolordark="#000000" bordercolorlight="#990000"
                                                                            style="font-size: 9pt; width: 244px">
                                                                            <tr>
                                                                                <td align="center" colspan="4" height="16" style="width: 155px">
                                                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14pt"
                                                                        Font-Underline="True" Text="Select Rate" Width="116px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="16">
                                                                                    <asp:Label ID="Label13" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Specialty:"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td colspan="3" height="16" style="width: 155px">
                                                                                    <asp:DropDownList ID="ddlRate" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                                        Font-Size="9pt" Height="20px" TabIndex="1" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" height="14">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label14" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Iso Code:"
                                                                                        Width="64px"></asp:Label></td>
                                                                                <td colspan="3" height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtIsoCode" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="68px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label47" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Class:"
                                                                                        Width="64px"></asp:Label></td>
                                                                                <td colspan="3" height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtClass" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="68px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" height="14">
                                                                                     
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label15" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 1"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:Label ID="Label43" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 2"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label45" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 3"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label44" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="MCM Rate "
                                                                                        Width="68px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:TextBox ID="txtRate1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtRate2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14">
                                                                                    <asp:TextBox ID="txtRate3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3" style="height: 14px">
                                                                                     </td>
                                                                                <td align="center" style="width: 83px; height: 14px;">
                                                                                    <asp:Button ID="btnCloseEffect" runat="server" BackColor="#400000" BorderColor="#400000"
                                                                                        BorderWidth="0px" Font-Names="Tahoma" Font-Size="9pt" ForeColor="White" Height="23px"
                                                                                        Text="Close" Width="60px" /></td>
                                                                            </tr>
                                                                        </table>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 1pt; " vAlign="middle" align="center" class="style25">                                                                                                                                          
										<TABLE id="Table6" style="WIDTH: 808px; HEIGHT: 195px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table1" style="WIDTH: 807px; HEIGHT: 179px" cellSpacing="0" cellPadding="0"
														width="807" border="0">
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 294px; HEIGHT: 18px" colSpan="3"><asp:label id="Label3" Width="201px" ForeColor="Black" Font-Names="Tahoma" Font-Size="9pt"
																	Font-Bold="True" RUNAT="server">Customer Information</asp:label></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" align="left"><asp:label id="Label23" Width="88px" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" Visible="False">Line of Business</asp:label></TD>
															<TD style="FONT-SIZE: 3pt; WIDTH: 196px; HEIGHT: 18px" align="left"><asp:dropdownlist id="ddlPolicyClass" tabIndex="1" ForeColor="White" Font-Names="Tahoma" Font-Size="8pt"
																	BackColor="#004040" RUNAT="server" CSSCLASS="headfield1" HEIGHT="20" WIDTH="152px" AutoPostBack="True" onselectedindexchanged="ddlPolicyClass_SelectedIndexChanged" Visible="False"></asp:dropdownlist>
																<asp:Button id="btnNew" runat="server" Width="29px" Height="21px" Font-Size="8pt" Font-Names="Tahoma"
																	Text="New" ToolTip="Add New policy with the same information" onclick="btnNew_Click"></asp:Button></TD>
															<TD style="WIDTH: 100px; HEIGHT: 18px" align="left"></TD>
															<TD style="WIDTH: 214px; HEIGHT: 18px" align="left"><asp:label id="LblStatus" ForeColor="Black" Font-Names="Tahoma" Font-Size="9pt" Font-Bold="True"
																	RUNAT="server" CSSCLASS="headform2" HEIGHT="16px" ENABLEVIEWSTATE="False" WIDTH="172px">Inforce/</asp:label></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" align="left"><asp:label id="lblEmail" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False">Customer No.</asp:label></TD>
															<TD align="left" class="style15">
                                                                <asp:textbox id="TxtCustomerNo" 
                                                                    tabIndex="1" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="TextBoxStyle" HEIGHT="18px" WIDTH="106px" MAXLENGTH="10"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" align="left"><asp:label id="lblPolicyNo" Width="56px" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="14px">Policy No.</asp:label>
                                                                <asp:CheckBox ID="ChkAutoAssignPolicy" runat="server" AutoPostBack="True" CssClass="headForm1 "
                                                                    ForeColor="Black" Height="16px" OnCheckedChanged="ChkAutoAssignPolicy_CheckedChanged"
                                                                    TabIndex="19" Text=" " ToolTip="Auto Assign Policy" Width="1px" /></TD>
															<TD style="WIDTH: 196px; HEIGHT: 18px" align="left"><asp:textbox id="TxtPolicyNo" 
                                                                    tabIndex="40" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="131px" MAXLENGTH="15"></asp:textbox>
                                                                </TD>
															<TD style="WIDTH: 100px; HEIGHT: 18px" align="left"> </TD>
															<TD style="WIDTH: 214px; HEIGHT: 18px" align="left">
																<asp:CheckBox ID="chkPaymentGA" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Text="Checked Payment by GA"/></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 15px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 15px" align="left"><asp:label id="Label2" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="72px">First Name</asp:label></TD>
															<TD align="left" class="style16"><asp:textbox id="TxtFirstName" tabIndex="2" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="85px" MAXLENGTH="25"></asp:textbox> 
																<asp:label id="Label1" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="16px">Init.</asp:label>
                                                                <asp:textbox id="TxtInitial" tabIndex="3" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="TextBoxStyle" HEIGHT="18px" WIDTH="21px" MAXLENGTH="1"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 15px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 15px" align="left"><asp:label id="lblCertificate" Width="67px" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px">Certificate</asp:label></TD>
															<TD style="FONT-SIZE: 12px; WIDTH: 196px; FONT-FAMILY: Tahoma; HEIGHT: 15px" align="left">
                                                                <asp:TextBox ID="TxtCertificate" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" MaxLength="15" TabIndex="40" Width="131px"></asp:TextBox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 15px" align="left">
                                                                <asp:label id="Label18" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="40px">Agency</asp:label></TD>
															<TD style="WIDTH: 214px; HEIGHT: 15px" align="left">
                                                                <asp:dropdownlist id="ddlAgency" tabIndex="52" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px" onselectedindexchanged="ddlAgency_SelectedIndexChanged"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 21px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 21px" align="left"><asp:label id="lblLastName1" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="72px">Last Name 1</asp:label></TD>
															<TD align="left" class="style17">
                                                                <asp:textbox id="txtLastname1" tabIndex="4" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="138px" MAXLENGTH="15" ontextchanged="txtLastname1_TextChanged"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 21px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 21px" align="left">
                                                                <asp:Label ID="Label29" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="67px">Policy Type</asp:Label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 21px; font-size: 9pt; font-family: Tahoma;" align="left">
                                                                <asp:textbox id="TxtPolicyType" tabIndex="41" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="41px" MAXLENGTH="3"></asp:textbox>
                                                                  Suffix  <asp:textbox id="TxtSufijo" tabIndex="42" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="29px" MAXLENGTH="2"></asp:textbox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 21px" align="left">
                                                                <asp:label id="Label75" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="40px">Branch</asp:label></TD>
															<TD style="WIDTH: 214px; HEIGHT: 21px" align="left"><asp:dropdownlist id="ddlCity" tabIndex="52" Font-Names="Tahoma" Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 21px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 21px" align="left"><asp:label id="lblLastName2" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="72px">Last Name 2</asp:label></TD>
															<TD align="left" class="style17"><asp:textbox id="txtLastname2" tabIndex="5" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="138px" MAXLENGTH="15"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 21px" align="right"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 21px" align="left"><asp:label id="Label16" Width="80px" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False">Anniversary</asp:label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 21px" align="left">
                                                                 <asp:TextBox ID="TxtAnniversary" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" MaxLength="2" TabIndex="42" Width="34px"></asp:TextBox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 21px" align="left"><asp:Label ID="Label21" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="40px">Agent</asp:Label></TD>
															<TD style="WIDTH: 214px; HEIGHT: 21px" align="left">
                                                                <asp:dropdownlist id="ddlAgent" tabIndex="52" Font-Names="Tahoma" Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px">
                                                            </asp:DropDownList></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 20px" align="left">
																<asp:label id="lblAdditionalName" Font-Names="Tahoma" Font-Size="9pt" 
                                                                    RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="72px">Add. Name:</asp:label></TD>
															<TD align="left" class="style18">
																<asp:textbox id="txtAdditionalName" tabIndex="5" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="18px" WIDTH="138px" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 20px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 20px" align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="44px">Term</asp:Label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 20px" align="left">
                                                                 <asp:textbox id="TxtTerm" tabIndex="43" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="18px" WIDTH="34px" MAXLENGTH="3" ></asp:textbox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 20px" align="left">
																<asp:label id="Label6" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" WIDTH="74px">Originated At</asp:label></TD>
															<TD style="WIDTH: 214px; HEIGHT: 20px" align="left">
                                                                <asp:dropdownlist id="ddlOriginatedAt" tabIndex="56" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" align="left">
																<asp:label id="Label36" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" WIDTH="68px">Address 1</asp:label></TD>
															<TD align="left" class="style15">
																<asp:textbox id="TxtAddrs1" tabIndex="6" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="18px"
																	CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="60"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" align="left">
                                                                <asp:Label ID="Label20" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="68px">Retro. Date</asp:Label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 18px" align="left">
                                                                <asp:TextBox ID="TxtRetroactiveDate" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker2();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 18px" align="left">
																<asp:label id="Label9" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" WIDTH="76px">Ins. Company</asp:label></TD>
															<TD style="WIDTH: 214px; HEIGHT: 18px" align="left">
																<asp:dropdownlist id="ddlInsuranceCompany" tabIndex="54" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px" onselectedindexchanged="ddlInsuranceCompany_SelectedIndexChanged"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 20px" align="left">
																<asp:label id="Label37" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" WIDTH="68px">Address 2</asp:label></TD>
															<TD align="left" class="style18">
																<asp:textbox id="TxtAddrs2" tabIndex="7" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="18px"
																	CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="60"></asp:textbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 20px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 20px" align="left">
                                                                <asp:Label ID="Label4" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="79px">Effective 
                                                                Date</asp:Label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 20px" align="left">
                                                                <asp:TextBox ID="txtEffDt" runat="server" Columns="30" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" IsDate="True" 
                                                                    onclick="ShowDateTimePicker();" TabIndex="44"
                                                                    Width="79px"></asp:TextBox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 23px" align="left">
																<asp:label id="Label42" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" HEIGHT="14px" CSSCLASS="headfield1"
																	WIDTH="74px" Visible="False">Group</asp:label></TD>
															<TD style="WIDTH: 214px; HEIGHT: 20px" align="left">
																<asp:dropdownlist id="ddlGroup" tabIndex="55" RUNAT="server" Font-Size="8pt" Font-Names="Tahoma"
																	HEIGHT="19px" CSSCLASS="headfield1" WIDTH="206px" AutoPostBack="True" onselectedindexchanged="ddlGroup_SelectedIndexChanged"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" align="left">
																<asp:label id="Label39" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" WIDTH="41px">City</asp:label></TD>
															<TD style="WIDTH: 198px; HEIGHT: 18px" vAlign="bottom" align="left" colSpan="2">
																<asp:textbox id="TxtCity" tabIndex="8" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="18px"
																	CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="14"></asp:textbox>
															</TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" align="left">
																<asp:label id="Label11" Width="65px" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False">Exp. Date</asp:label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 18px" vAlign="middle" align="left">
																<asp:textbox id="txtExpDt" runat="server" Columns="30" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" IsDate="True" 
                                                                    onclick="ShowDateTimePicker4();" TabIndex="44"
                                                                    Width="79px"></asp:textbox></TD>
															<TD style="WIDTH: 100px; HEIGHT: 18px" vAlign="middle" align="left">
                                                                <asp:label id="Label28" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="61px">Corporation</asp:label></TD>
															<TD style="WIDTH: 140px; HEIGHT: 18px" vAlign="middle">
                                                                <asp:dropdownlist id="ddlCorparation" tabIndex="53" Font-Names="Tahoma" Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="style8"></TD>
															<TD align="left" class="style9">
																<asp:label id="Label40" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" WIDTH="80px">Zip Code</asp:label>
																 </TD>
															<TD vAlign="bottom" align="left" colSpan="2" class="style10">
																<asp:textbox id="TxtState" tabIndex="9" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="18px"
																	CSSCLASS="headfield1" WIDTH="31px" MAXLENGTH="2"></asp:textbox> 
																<maskedinput:maskedtextbox id="TxtZip" tabIndex="10" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma" HEIGHT="18px"
																	CSSCLASS="headfield1" WIDTH="90px" MAXLENGTH="10" MASK="CCCCCC" ISDATE="False" IsCurrency="False" IsZipCode="True"></maskedinput:maskedtextbox>
															     </TD>
															<TD align="left" class="style11">
																<asp:label id="Label27" Width="65px" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1">Entry Date</asp:label></TD>
															<TD vAlign="middle" align="left" class="style12">
																<P>
                                                                     <asp:textbox id="txtEntryDate" tabIndex="47" runat="server" Width="79px" Font-Names="Tahoma"
																	Font-Size="9pt" CssClass="headfield1" Height="18px" IsDate="True" Columns="30"></asp:textbox></P>
															</TD>
															<TD vAlign="middle" class="style13">
                                                                <asp:label id="lblFinancial" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" WIDTH="74px">Financial Inst.</asp:label></TD>
															<td class="style14">
                                                                <asp:dropdownlist id="ddlFinancial" tabIndex="56" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px"></asp:dropdownlist>
                                                            </td>
															<TD style="WIDTH: 140px; HEIGHT: 104px" vAlign="middle" rowSpan="6"> </TD>
														</TR>
														<TR>
															<TD class="style1"></TD>
															<TD align="left" class="style2" colspan="3">
																 </TD>
															<TD align="left" class="style4">
																 </TD>
															<TD vAlign="middle" align="left" class="style5">
															     </TD>
															<TD vAlign="middle" style="text-align: left">
																<asp:label id="lblOtherSpecialty" Font-Names="Tahoma" Font-Size="9pt" 
                                                                    RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" WIDTH="74px" Font-Italic="False">Other Spec.</asp:label></TD>
														    <td>
                                                                <asp:dropdownlist id="ddlOtherSpecialty" tabIndex="56" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px"></asp:dropdownlist>
                                                            </td>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"> </TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" align="left">
																<asp:label id="lblSocialSecurity" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="16px" CSSCLASS="headfield1" WIDTH="80px" Visible="False">Social 
                                                                Security</asp:label></TD>
															<TD style="WIDTH: 198px; HEIGHT: 18px" vAlign="bottom" align="left" colSpan="2">
																<maskedinput:maskedtextbox id="txtSocialSecurity" tabIndex="11" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="11" MASK="999-99-9999" ISDATE="False" Visible="False"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 196px; HEIGHT: 18px" vAlign="middle" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 100px; HEIGHT: 18px; text-align: left;" vAlign="middle">
																<asp:Label ID="Label72" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">Other Agent</asp:Label></TD>
														    <td>
                                                                <asp:dropdownlist id="ddlAgent2" tabIndex="52" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px">
                                                            </asp:DropDownList>
                                                            </td>
                                                               
														</TR>
													  <tr>  <%--IsoCode--%>
														    <td class="style1"></td>
															<td align="left" class="style2" colspan="3"></td>
															<td align="left" class="style4"></td>
															<td vAlign="middle" align="left" class="style5"></td>
															<td vAlign="middle" style="text-align: left">                                                   
																<asp:Label ID="lblIsoCode" runat="server" CssClass="headfield1" EnableViewState="False"
																Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">IsoCode</asp:Label>
															</td>
														    <td>
                                                                <asp:Dropdownlist id="ddlIsoCode" tabIndex="52" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px" onselectedindexchanged="ddlIsoCode_SelectedIndexChanged" 
                                                                    AutoPostBack="True"></asp:DropDownList>
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                           </td>
                                                        </tr>
                                                        
														<tr>  <%--Specialty--%>
														    <td class="style1"></td>
															<td align="left" class="style2" colspan="3"></td>
															<td align="left" class="style4">
																<asp:label id="Label41" Width="44px" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1">Charge</asp:label>
																<asp:label id="lblCharge" Width="48px" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" Visible="False">Percent</asp:label>
															</td>
															<td align="left" class="style4">
																<maskedinput:maskedtextbox id="TxtCharge" tabIndex="48" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="85px" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCC" ISDATE="False"></maskedinput:maskedtextbox>
																<asp:CheckBox ID="chkUserMod" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Visible="False" />
															</td>															
															<td vAlign="middle" style="text-align: left">                                                   
																<asp:Label ID="lblSpecialty" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">Specialty</asp:Label>
                                                             </td>
														    <td>
                                                                <asp:dropdownlist id="ddlSpecialty" tabIndex="52" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="206px" onselectedindexchanged="ddlSpecialty_SelectedIndexChanged"  AutoPostBack="True"></asp:DropDownList>
                                                            </td>
                                                        </tr>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"> </TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" align="left">
																<asp:label id="lblHomePhone" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" WIDTH="76px">Home Phone</asp:label></TD>
															<TD style="WIDTH: 198px; HEIGHT: 18px" vAlign="bottom" align="left" colSpan="2">
																<maskedinput:maskedtextbox id="txtHomePhone" tabIndex="13" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" align="left">
																<asp:label id="lblPremium" Width="76px" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="14px" CSSCLASS="headfield1">Premium</asp:label>
															</TD>
															<TD style="WIDTH: 196px; HEIGHT: 18px" vAlign="middle" align="left">
																<maskedinput:maskedtextbox id="TxtPremium" tabIndex="49" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="85px" MAXLENGTH="14" MASK="CCCCCCCCCC" ISDATE="False" AutoPostBack="True" 
                                                                    ontextchanged="TxtPremium_TextChanged"></maskedinput:maskedtextbox>
													<asp:button id="btnChargeCalc" tabIndex="68" runat="server" Width="65px" Height="21px" Font-Names="Tahoma"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" BackColor="#400000"
														Text="Calculate" onclick="CalculateCharge" Visible="False"></asp:button>
															</TD>
															<TD style="text-align: left">
																<asp:Label ID="Label74" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">Has Claim?</asp:Label></TD>
														    <td style="text-align: left">
																<asp:RadioButtonList ID="rblClaim" runat="server" AutoPostBack="True" 
                                                                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow" style="font-size: 9pt" 
                                                                    Width="154px">
                                                                    <asp:ListItem Value="0">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="1">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" align="left">
																<asp:label id="lblWorkPhone" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1">Work Phone</asp:label></TD>
															<TD align="left" class="style15">
																<maskedinput:maskedtextbox id="txtWorkPhone" tabIndex="13" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 18px" vAlign="middle"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" vAlign="middle" align="left">
																<asp:label id="lblPremium0" Width="94px" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="14px" CSSCLASS="headfield1">Canc. Amount</asp:label>
															</TD>
															<TD style="WIDTH: 196px; HEIGHT: 18px" vAlign="middle" align="left">
																<maskedinput:maskedtextbox id="TxtCancAmount" tabIndex="49" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="85px" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCCCCCC" ISDATE="False" 
                                                                    Enabled="False"></maskedinput:maskedtextbox>
																</TD>
															<TD style="WIDTH: 100px; HEIGHT: 18px" vAlign="middle" align="left"> 
																<asp:Label ID="lblClaimNo" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">Claim No</asp:Label>
																</TD>
														    <td>
                                                                    <br />
																<asp:textbox id="txtClaimNumber" tabIndex="47" runat="server" Width="205px" Font-Names="Tahoma"
																	Font-Size="9pt" CssClass="headfield1" Height="37px" IsDate="True" Columns="30" MaxLength="100" TextMode="MultiLine"></asp:textbox>
                                                            </td>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 18px" colSpan="1" align="left">
																<asp:label id="Label8" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1">Cellular</asp:label></TD>
															<TD align="left" class="style15">
																<maskedinput:maskedtextbox id="TxtCellular" tabIndex="14" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="20" MASK="(999) 999-9999" ISDATE="False"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 18px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 18px" vAlign="middle" align="left">
																<asp:label id="lblTotPremum" Width="76px" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" HEIGHT="14px" CSSCLASS="headfield1">Tot. 
                                                                Premium</asp:label></TD>
															<td style="text-align: left">
																<maskedinput:maskedtextbox id="TxtTotalPremium" tabIndex="49" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="85px" MAXLENGTH="14" IsCurrency="False" MASK="CCCCCCCCCC" ISDATE="False" 
                                                                    Enabled="False"></maskedinput:maskedtextbox>
																<maskedinput:maskedtextbox id="TxtUserPremium" tabIndex="49" RUNAT="server" 
                                                                    Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="18px" CSSCLASS="headfield1" WIDTH="85px" MAXLENGTH="14" MASK="CCCCCCCCCC" ISDATE="False" AutoPostBack="True" 
                                                                    ontextchanged="TxtPremium_TextChanged" Visible="False"></maskedinput:maskedtextbox>
                                                            </td>
															<TD style="WIDTH: 196px; HEIGHT: 18px; text-align: center;" vAlign="middle" 
                                                                align="left">
																<asp:Label ID="lblGapDate" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">Gap Dates:</asp:Label>
																</TD>
														    <td align="center">
                                                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:Label ID="lblGapDate0" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">From:</asp:Label>
																<asp:Label ID="lblGapDate1" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="70px">To:</asp:Label>
                                                                    </td>
														</TR>
														<TR>
															<TD class="style1"></TD>
															<TD align="left" class="style2">
																<asp:label id="Label26" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1">E-mail</asp:label></TD>
															<TD vAlign="bottom" align="left" colSpan="2" class="style3">
																<asp:textbox id="txtEmail" tabIndex="15" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" HEIGHT="18px"
																	CSSCLASS="headfield1" WIDTH="138px" MAXLENGTH="100"></asp:textbox></TD>
															<TD align="left" class="style4">
                                                                <asp:Label ID="lblDiscount" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="14px" Width="76px">Group Disc.</asp:Label></TD>
															<TD style="WIDTH: 285px; HEIGHT: 20px" colSpan="2" align="left">
                                                                <MaskedInput:MaskedTextBox ID="txtInvoiceNumber" runat="server" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsCurrency="False" IsDate="False"
                                                                    Mask="CCCCCCCCCC" MaxLength="14" TabIndex="49" Width="85px"></MaskedInput:MaskedTextBox>
                                                            </TD>
														    <td align="center">
                                                               
                                                                <asp:TextBox ID="txtGapBegDate" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker6();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox>
                                                                <asp:TextBox ID="txtGapEndDate" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker7();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox>
                                                                    </td>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 17px"></TD>
															<TD style="WIDTH: 106px; HEIGHT: 17px" align="left" colSpan="1">
                                                                <asp:Label ID="Label51" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="40px">License:</asp:Label></TD>
															<TD vAlign="bottom" align="left" class="style19">
                                                                <asp:TextBox ID="txtLicense" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" MaxLength="25" TabIndex="15" Width="138px"></asp:TextBox></TD>
															<TD style="WIDTH: 57px; HEIGHT: 17px" vAlign="bottom" align="right"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 17px; text-align: left;" vAlign="bottom" 
                                                                align="right">   
																<asp:label id="lblComments" Width="44px" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma"
																	ENABLEVIEWSTATE="False" HEIGHT="14px" CSSCLASS="headfield1">Comments</asp:label>   </TD>
															<TD style="WIDTH: 285px; " colSpan="2" rowSpan="3" align="left">
																<asp:textbox id="TxtComments" tabIndex="50" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma"
																	HEIGHT="37px" CSSCLASS="headfield1" WIDTH="260px" MAXLENGTH="2000" TextMode="MultiLine"></asp:textbox></TD>
														    <td align="center">
                                                                                                                                
                                                                <asp:TextBox ID="txtGapBegDate2" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker8();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox>
                                                                <asp:TextBox ID="txtGapEndDate2" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker9();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox>
																 </td>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 13px">&nbsp;</TD>
															<TD style="WIDTH: 289px; HEIGHT: 13px" vAlign="bottom" align="left">
                                                                <asp:Label ID="Label17" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px">ApplicationID</asp:Label></TD>
                                                            <td align="left" valign="bottom" class="style20">
                                                                <asp:TextBox ID="txtApplicationID" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" MaxLength="10" TabIndex="1" Width="106px"></asp:TextBox></td>
															<TD style="WIDTH: 57px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 310px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 206px; HEIGHT: 13px" vAlign="bottom" align="center">
                                                                <asp:TextBox ID="txtGapBegDate3" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker10();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox>
                                                                <asp:TextBox ID="txtGapEndDate3" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker11();"
                                                                    TabIndex="44" Width="79px"></asp:TextBox>
																 </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 13px">&nbsp;</TD>
															<TD style="WIDTH: 289px; HEIGHT: 13px" vAlign="bottom" align="left">
                                                                &nbsp;</TD>
                                                            <td align="left" valign="bottom" class="style20">
                                                                &nbsp;</td>
															<TD style="WIDTH: 57px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 310px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 206px; HEIGHT: 13px" vAlign="bottom" align="left">
																<asp:Label ID="lblGapDate2" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="65px">Num. of 
                                                                Employees:</asp:Label>
                                                                <asp:TextBox ID="txtNumberOfEmployees" runat="server" Columns="30" CssClass="headfield1"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" TabIndex="44" 
                                                                    Width="76px"></asp:TextBox>
																 </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 13px"></TD>
															<TD style="WIDTH: 289px; HEIGHT: 13px" vAlign="bottom" align="left">
                                                                             <asp:Label ID="lblUpdateForm" runat="server" CssClass="headfield1" 
                                                                                 EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                                 Width="40px">Update Form</asp:Label>
                                                                             </TD>
                                                            <td align="left" valign="bottom" class="style20">
                                                                             <asp:CheckBox ID="chkUpdateForm" runat="server" Font-Names="Tahoma" 
                                                                                 Font-Size="9pt"/>
                                                                             </td>
															<TD style="WIDTH: 57px; HEIGHT: 13px" vAlign="bottom" align="left"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 13px" vAlign="bottom" align="left">
																<asp:label id="Label7" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="60px" Font-Bold="True">Covers:</asp:label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 13px" vAlign="bottom" align="left"><asp:label id="Label10" Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
														HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="201px" Font-Bold="True">Limits</asp:label></TD>
															<TD style="WIDTH: 100px; HEIGHT: 13px" vAlign="bottom" align="left">
																</TD>
															<TD style="WIDTH: 206px; HEIGHT: 13px" vAlign="bottom" align="left">
																<asp:dropdownlist id="ddlAvailableAgent" tabIndex="57" RUNAT="server" Font-Size="7.5pt" Font-Names="Arial"
																	HEIGHT="19px" CSSCLASS="headfield1" WIDTH="128px"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 13px">&nbsp;</TD>
															<TD style="WIDTH: 289px; HEIGHT: 13px" vAlign="bottom" align="left">
                                                                             &nbsp;</TD>
                                                            <td align="left" valign="bottom" class="style20">
                                                                             &nbsp;</td>
															<TD style="WIDTH: 57px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 310px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 196px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 100px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 206px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 13px">&nbsp;</TD>
															<TD style="WIDTH: 289px; HEIGHT: 13px" vAlign="bottom" align="left">
                                                                <asp:Label ID="Label76" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px">Prospect Number</asp:Label>
                                                                             </TD>
                                                            <td align="left" valign="bottom" class="style20">
                                                                            <MaskedInput:MaskedTextBox ID="TxtProspectNo" RUNAT="server" 
                                                                                CSSCLASS="headfield1" Enabled="False" Font-Names="Tahoma" Font-Size="9pt" 
                                                                                HEIGHT="18px" IsCurrency="False" ISDATE="False" MASK="CCCCCCCCCC" 
                                                                                MAXLENGTH="14" tabIndex="49" WIDTH="85px"></MaskedInput:MaskedTextBox>
                                                                             </td>
															<TD style="WIDTH: 57px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 310px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 196px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 100px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 206px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 13px">&nbsp;</TD>
															<TD style="WIDTH: 289px; HEIGHT: 13px" vAlign="bottom" align="left">
                                                                             &nbsp;</TD>
                                                            <td align="left" valign="bottom" class="style20">
                                                                             &nbsp;</td>
															<TD style="WIDTH: 57px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 310px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 196px; HEIGHT: 13px" vAlign="bottom" align="left">&nbsp;</TD>
															<TD style="WIDTH: 100px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
															<TD style="WIDTH: 206px; HEIGHT: 13px" vAlign="bottom" align="left">
																&nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 20px"></TD>
															<TD style="WIDTH: 408px; HEIGHT: 20px" vAlign="bottom" align="left">
																<asp:label id="Label19" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="14px" ENABLEVIEWSTATE="False" WIDTH="40px" Visible="False">Supplier</asp:label>
																</TD>
															<TD style="WIDTH: 198px; HEIGHT: 20px" vAlign="bottom" align="left" colSpan="2">
                                                                <asp:dropdownlist id="ddlSupplier" tabIndex="51" Font-Names="Tahoma" 
                                                                    Font-Size="8pt" RUNAT="server" CSSCLASS="headfield1"
																	HEIGHT="19px" WIDTH="206px" Visible="False" onselectedindexchanged="ddlSupplier_SelectedIndexChanged"></asp:dropdownlist>
																 </TD>
															<TD style="WIDTH: 310px; HEIGHT: 20px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="68px">Liability A:</asp:Label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 20px" align="left"><asp:dropdownlist id="ddlPrMedicalLimits" tabIndex="56" Font-Names="Tahoma" Font-Size="8pt" RUNAT="server"
																	CSSCLASS="headfield1" HEIGHT="19px" WIDTH="192px" AutoPostBack="True" OnSelectedIndexChanged="ddlRate_SelectedIndexChanged2">
                                                            </asp:DropDownList></TD>
															<TD style="WIDTH: 100px; HEIGHT: 20px">
																</TD>
															<TD style="WIDTH: 206px; HEIGHT: 20px">
																	<asp:label id="LblSelectAgent" RUNAT="server" Font-Size="9pt" Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																		HEIGHT="14px" CSSCLASS="headfield1" WIDTH="124px" Visible="False">Available 
                                                                    Agent - Level</asp:label></TD>
														</TR>
                                                        <tr>
                                                            <td style="width: 8px; height: 15px">
                                                            </td>
                                                            <td align="left" style="width: 408px; height: 15px" valign="bottom">
																<asp:button id="cmdRemove" tabIndex="59" runat="server" Width="24px" Height="20px" Font-Size="9pt"
																	Font-Names="Tahoma" Text="<<" onclick="cmdRemove_Click"></asp:button>
																<asp:button id="cmdSelect" tabIndex="58" runat="server" Width="24px" Font-Names="Tahoma" Font-Size="9pt"
																	Height="20px" Text=">>" onclick="cmdSelect_Click"></asp:button>
                                                                 </td>
                                                            <td align="left" colspan="2" style="width: 198px; height: 15px" valign="bottom">
                                                            </td>
                                                            <td style="width: 310px; height: 15px">
                                                            </td>
                                                            <td style="width: 196px; height: 15px">
                                                            </td>
                                                            <td align="left" colspan="2" style="font-size: 1pt; width: 150px; height: 15px">
                            <asp:listbox id="ddlSelectedAgent" tabIndex="60" runat="server" Width="170px" Font-Names="Arial"
																	Font-Size="7.5pt" Height="22px" onselectedindexchanged="ddlSelectedAgent_SelectedIndexChanged"></asp:listbox>
                                                            </td>
                                                        </tr>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 15px"></TD>
															<TD style="WIDTH: 408px; HEIGHT: 15px" vAlign="bottom" align="left">
																<asp:label id="lblSelectedAgent" RUNAT="server" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" ENABLEVIEWSTATE="False"
																	HEIGHT="14px" CSSCLASS="headfield1" WIDTH="79px" Visible="False">Selected 
                                                                Agent</asp:label>
																</TD>
															<TD style="WIDTH: 198px; HEIGHT: 15px" vAlign="bottom" align="center" colSpan="2">
                                                                <asp:Label ID="lblCarrier" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="110px">Previous 
                                                                Carrier Name</asp:Label></TD>
															<TD style="WIDTH: 310px; HEIGHT: 15px">
                                                                <asp:Label ID="Label25" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="70px">Eff. Date</asp:Label></TD>
															<TD style="WIDTH: 196px; HEIGHT: 15px">
                                                                <asp:Label ID="Label24" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px">Policy Limits</asp:Label></TD>
															<TD style="FONT-SIZE: 1pt; WIDTH: 150px; HEIGHT: 15px" align="left" colSpan="2">
                                                                 
                                                                <asp:Label ID="Label30" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px">Policy No. 
                                                                Other Company</asp:Label></TD>
														</TR>
                                                        <tr>
                                                            <td style="width: 8px; height: 15px">
                                                            </td>
                                                            <td align="left" style="width: 408px; height: 15px" valign="bottom">
																<asp:CheckBox ID="chkPending" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Text="Pending" />
                                                            </td>
                                                            <td align="center" colspan="2" style="width: 198px; height: 15px" valign="bottom">
                                                                <asp:TextBox ID="txtPriCarierName1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px" MaxLength="75" TabIndex="24" Width="130px"></asp:TextBox></td>
                                                            <td style="width: 310px; height: 15px">
                                                                <maskedinput:maskedtextbox id="txtPriPolEffecDate1" tabIndex="22" Font-Size="9pt" Font-Names="Tahoma"  
																	RUNAT="server" HEIGHT="19px" WIDTH="82px" ISDATE="True"></maskedinput:maskedtextbox><INPUT id="btnCalendar" style="WIDTH: 21px; HEIGHT: 21px" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Paym.txtPriPolEffecDate1','calendar_window','width=250,height=250');calendar_window.focus()"
																	tabIndex="23" type="button" value="..." name="btnCalendar" RUNAT="server">
                                                                <%--<asp:TextBox ID="txtPriPolEffecDate1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px" onclick="ShowDateTimePicker3();" ISDATE="true" TabIndex="25" Width="70px"></asp:TextBox>--%></td>
                                                            <td style="width: 196px; height: 15px">
                                                                <asp:DropDownList ID="ddlPriPolLimits1" runat="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="19px" 
                                                                    tabIndex="56" WIDTH="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlPriPolLimits1_SelectedIndexChanged"></asp:DropDownList>
                                                                <%--<asp:TextBox ID="txtPriPolLimits1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px" MaxLength="50" TabIndex="26" Width="120px" 
                                                                    ></asp:TextBox>--%></td>
                                                            <td align="left" colspan="2" style="font-size: 1pt; width: 150px; height: 15px">
                                                                <asp:TextBox ID="txtPriClaims1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px" MaxLength="50" TabIndex="27" Width="196px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 8px; height: 15px">
                                                                 </td>
                                                            <td align="left" style="width: 408px; height: 15px" valign="bottom">
                                                                 </td>
                                                            <td align="center" colspan="2" style="width: 198px; height: 15px" valign="bottom">
                                                                 </td>
                                                            <td style="width: 310px; height: 15px">
                                                                 </td>
                                                            <td style="width: 196px; height: 15px">
                                                                 </td>
                                                            <td align="left" colspan="2" style="font-size: 1pt; width: 150px; height: 15px">
                                                                 </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 8px; height: 15px">
                                                                 </td>
                                                            <td align="left" style="height: 15px" valign="bottom" colspan="7">
                                                <asp:Panel ID="pnlEndorsement" runat="server" Width="955px">
                                                    <table style="width: 950px; height: 205px">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblEndorsement" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt" 
                                                                    Height="14px" Width="90px">Endorsements:</asp:Label>
                                                            </td>
                                                            <td class="style53">
                                                                 </td>
                                                            <td class="style53">
                                                                <asp:CheckBox ID="chkUserModEndo" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Visible="False" />
                                                            </td>
                                                            <td style="text-align: center">
                                                                <asp:TextBox ID="txtEndorsementID" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" MaxLength="75" TabIndex="24" Visible="False" 
                                                                    Width="70px"></asp:TextBox>
                                                            </td>
                                                            <td class="style53">
                                                                <asp:Button ID="btnHideEndoPanel" runat="server" BackColor="#400000" 
                                                                    BorderColor="#400000" BorderStyle="Solid" BorderWidth="1px" CssClass="style22" 
                                                                    Font-Names="Tahoma" ForeColor="White" Height="23px" 
                                                                    onclick="btnHideEndoPanel_Click" tabIndex="72" Text="X" Visible="False" 
                                                                    Width="25px" />
                                                            </td>
                                                            </tr><tr>
                                                            <td class="style46">
                                                                <asp:Label ID="lblEndorsementNo" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="126px">Endorsement No.:</asp:Label>
                                                            </td>
                                                            <td class="style35">
                                                                <asp:Label ID="lblDatePrepared" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="94px">Date Prepared:</asp:Label>
                                                            </td>
                                                            <td class="style35">
                                                                <asp:Label ID="lblEndoEffDate" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="100px">Endo. Eff. Date:</asp:Label>
                                                                    
                                                            <td class="style35">
                                                                <asp:Label ID="lblEndoRetroDate" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="100px">Endo. Retro. Date:</asp:Label>
                                                            </td>
                                                            </td>
                                                            <td class="style35">
                                                                <asp:Label ID="lblEndoPremium" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="100px">Endo. Premium:</asp:Label>
                                                            </td>
                                                            <td class="style35">
                                                                <asp:Label ID="lblEndoType" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="192px">Endorsement Type:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style45">
                                                                <asp:TextBox ID="txtEndorsementNo" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" MaxLength="75" TabIndex="24" Width="70px"></asp:TextBox>
                                                            </td>
                                                            <td class="style45">
                                                                <asp:TextBox ID="txtDatePrepared" runat="server" Columns="30" 
                                                                    CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Height="18px" 
                                                                    IsDate="True"  TabIndex="44" Width="79px"></asp:TextBox>
                                                            </td>
                                                            <td class="style45">
                                                                <asp:TextBox ID="txtEndoEffDate" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker5();"
                                                                    Width="70px"></asp:TextBox>
                                                            </td>
                                                            <td class="style45">
                                                                <asp:TextBox ID="txtRetroEffDate" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" onclick="ShowDateTimePickerEndoRetroDate();"
                                                                    Width="70px"></asp:TextBox>
                                                            </td>
                                                            <td class="style45">
                                                            <asp:TextBox ID="txtEndoPremium" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" AutoPostBack="True" ontextchanged="txtEndoPremium_TextChanged"
                                                                    Width="85px"></asp:TextBox>
                                                            </td>
                                                            <td class="style45">
                                                                <asp:DropDownList ID="ddlEndoType" RUNAT="server"
                                                                    CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="8pt" HEIGHT="19px" 
                                                                    tabIndex="56" WIDTH="192px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style49" colspan="5">
                                                                <asp:Label ID="lblEndoComments" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="14px" 
                                                                    Width="100px">Comments:</asp:Label>
                                                            </td></tr>
                                                        <tr>
                                                            <td class="style52" colspan="5" style="text-align: center">
                                                                <asp:TextBox ID="txtEndoComments" RUNAT="server" CSSCLASS="headfield1" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" HEIGHT="90px" MAXLENGTH="2000" 
                                                                    tabIndex="50" TextMode="MultiLine" WIDTH="735px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table></asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 8px; height: 15px">
                                                                 </td>
                                                            <td align="left" style="height: 15px; text-align: left;" valign="bottom" 
                                                                colspan="7">
                                                                <asp:Label ID="lblEndorsementHistory" runat="server" 
                                                                    CssClass="headfield1" EnableViewState="False" Font-Bold="True" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="90px">Endorsements:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 8px; height: 15px">
                                                                 </td>
                                                            <td align="left" style="height: 15px; text-align: center;" valign="bottom" 
                                                                colspan="7">
                                                                <asp:DataGrid ID="dtEndorsement" runat="server" 
                                                                    AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" 
                                                                    AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" 
                                                                    BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" 
                                                                    CellPadding="0" Font-Names="Arial" Font-Size="9pt" 
                                                                    HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" 
                                                                    HeaderStyle-HorizontalAlign="Center" Height="16px" 
                                                                    ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center" 
                                                                    OnItemCommand="dtEndorsement_ItemCommand" PageSize="8" TabIndex="9" 
                                                                    Width="795px">
                                                                    <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                                                    <EditItemStyle BackColor="White" 
                                                                        HorizontalAlign="Center" />
                                                                    <SelectedItemStyle BackColor="White" 
                                                                        HorizontalAlign="Center" />
                                                                    <PagerStyle BackColor="White" CssClass="Numbers" 
                                                                        Font-Names="Tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" 
                                                                        PageButtonCount="20" />
                                                                    <AlternatingItemStyle BackColor="White" 
                                                                        CssClass="HeadForm3" HorizontalAlign="Center" />
                                                                    <ItemStyle BackColor="White" CssClass="HeadForm3" 
                                                                        HorizontalAlign="Center" />
                                                                    <Columns>
                                                                        <asp:ButtonColumn ButtonType="PushButton" 
                                                                            CommandName="Select" HeaderText="Sel.">
                                                                            <ItemStyle Font-Names="Tahoma" />
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:ButtonColumn>
                                                                        <asp:BoundColumn DataField="EndorsementID" 
                                                                            HeaderText="Task No." Visible="False">
                                                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementNo" 
                                                                            HeaderText="Endorse No.">
                                                                            <HeaderStyle Width="75px" />
                                                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EntryDate" 
                                                                            HeaderText="Date Prepared">
                                                                            <HeaderStyle Width="85px" />
                                                                            <ItemStyle Font-Names="Tahoma" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EffectiveDate" 
                                                                            HeaderText="Eff. Date">
                                                                            <HeaderStyle Width="75px" />
                                                                            <ItemStyle Font-Names="Tahoma" />
                                                                        </asp:BoundColumn>
                                                                          <asp:BoundColumn DataField="RetroactiveDate" 
                                                                            HeaderText="Retro. Date">
                                                                            <HeaderStyle Width="75px" />
                                                                            <ItemStyle Font-Names="Tahoma" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementType" 
                                                                            HeaderText="Type">
                                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" 
                                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                HorizontalAlign="Center" Width="50px" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementPremium" HeaderText="Premium">
                                                                            <HeaderStyle Font-Bold="False" Font-Italic="False" 
                                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                HorizontalAlign="Center" Width="50px" />
                                                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" Font-Bold="False" 
                                                                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                                                                Font-Underline="False" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementComments" 
                                                                            HeaderText="Comments">
                                                                            <HeaderStyle Width="250px" />
                                                                            <ItemStyle Font-Bold="False" Font-Italic="False" 
                                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                HorizontalAlign="Left" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EndorsementHistory" 
                                                                            HeaderText="History" Visible="False">
                                                                            <HeaderStyle Width="75px" />
                                                                            <ItemStyle Font-Bold="False" Font-Italic="False" 
                                                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                HorizontalAlign="Right" />
                                                                        </asp:BoundColumn>
                                                                        <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Edit">
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:ButtonColumn>
                                                                        <asp:TemplateColumn HeaderText="Del.">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDelEndorsement" runat="server"
                                                                                    CommandArgument="Delete" 
                                                                                    
                                                                                    onclientclick="return confirm('Are you certain you want to delete this Endorsement?');" 
                                                                                    CommandName="Delete" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px" />
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#400000" CssClass="HeadForm2" 
                                                                        Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" 
                                                                        Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" 
                                                                        HorizontalAlign="Center" />
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 3px"></TD>
															<TD style="WIDTH: 408px; HEIGHT: 3px" vAlign="bottom" align="left">
																</TD>
															<TD vAlign="bottom" align="left" colSpan="1" class="style21">
																</TD>
															<TD style="WIDTH: 57px; HEIGHT: 3px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 3px">
																</TD>
															<TD style="WIDTH: 196px; HEIGHT: 3px">
                                                                 </TD>
															<TD style="WIDTH: 100px; HEIGHT: 3px">
																</TD>
															<TD style="WIDTH: 187px; HEIGHT: 3px">
																</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 8px; HEIGHT: 3px"></TD>
															<TD style="WIDTH: 408px; HEIGHT: 3px" vAlign="bottom" align="left"></TD>
															<TD vAlign="bottom" align="left" class="style21"></TD>
															<TD style="WIDTH: 57px; HEIGHT: 3px"></TD>
															<TD style="WIDTH: 310px; HEIGHT: 3px">
																</TD>
															<TD style="WIDTH: 196px; HEIGHT: 3px">
																</TD>
															<TD style="WIDTH: 100px; HEIGHT: 3px">
                                                                </TD>
															<TD style="WIDTH: 187px; HEIGHT: 3px">
                                                                </TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													&nbsp;</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 1pt; " align="left" colSpan="1" class="style26">                     
										<TABLE id="Table5" style="WIDTH: 808px" borderColor="#c00000" height="1" cellSpacing="0"
											borderColorDark="#c00000" cellPadding="0" width="808" bgColor="#c00000" borderColorLight="#c00000"
											border="0">
											<TR>
												<TD style="height: 19px" background="Images2/Barra3.jpg"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; " class="style27">
										<TABLE id="Table2" style="WIDTH: 802px; HEIGHT: 16px" cellSpacing="0" 
                                            cellPadding="0" width="802"
											border="0" align="center">
											<TR>
												<TD style="WIDTH: 141px; HEIGHT: 19px" align="left"> 
                                                    <asp:Label ID="Label22" runat="server" CssClass="headfield1" EnableViewState="False"
                                                        Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="60px">History:</asp:Label></TD>
												<TD style="WIDTH: 157px; HEIGHT: 19px"></TD>
												<TD class="style43"></TD>
												<TD style="WIDTH: 291px; HEIGHT: 19px">
													</TD>
												<TD style="WIDTH: 180px; HEIGHT: 19px"></TD>
                                                <td style="width: 180px; height: 19px; text-align: right;">
                                                    <asp:button 
                                                        id="btnRefresh" tabIndex="66" runat="server" Width="93px" ForeColor="White"
														Font-Size="9pt" Height="23px" Text="Refresh" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" 
                                                        onclick="btnRefresh_Click" style="font-family: Tahoma" Visible="False"></asp:button>
                                                </td>
											</TR>
											<TR>
												<TD style="WIDTH: 223px; HEIGHT: 17px" align="center" colSpan="6">
<asp:DataGrid ID="DtSearchPayments" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6"
                                                        AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" Font-Names="Arial"
                                                        Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2"
                                                        HeaderStyle-HorizontalAlign="Center" Height="193px" ItemStyle-CssClass="HeadForm3"
                                                        ItemStyle-HorizontalAlign="center" OnItemCommand="DtSearchPayments_ItemCommand1"
                                                        PageSize="8" TabIndex="9" Width="795px">
                                                        <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                                        <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                                        <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                                        <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="Tahoma" ForeColor="Blue"
                                                            HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
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
                                                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
                                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Right" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv.">
                                                                <HeaderStyle Width="50px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">
                                                                <HeaderStyle Width="75px" />
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Right" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">
                                                                <HeaderStyle Width="75px" />
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Right" />
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Comments" HeaderText="Comments">
                                                                <HeaderStyle Width="250px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" HorizontalAlign="Left" />
                                                            </asp:BoundColumn>
                                                            
                                                        </Columns>
                                                        <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False"
                                                            Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                                            ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                                    </asp:DataGrid></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 223px; HEIGHT: 17px" align="char" colSpan="6">
                                                     </TD></TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</P>
                                    <table id="Table11" style="width: 814px; height: 10px" 
                            cellspacing="0" cellpadding="0" border="0" align="center">
                                        <tr>
                                            <td background="Images2/Barra3.jpg" colspan="5" style="height: 1px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:Label ID="Label52" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="209px" Height="18px">Primary - Technicians & Nurses</asp:Label><asp:textbox id="TxtID" style="Z-INDEX: 101; LEFT: 865px; POSITION: absolute; right: 33px;" runat="server"
				Width="61px" Visible="False"></asp:textbox></td><td style="width: 168px; height: 22px">
                                                 </td></tr><tr>
                                            <td colspan="4">
                                                <asp:Panel ID="pnlPrimary" runat="server" Width="637px">
                                                    <table style="width: 633px; height: 144px">
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label53" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Primary</asp:Label></td><td>
                                                                <asp:Label ID="Label54" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="47px">Rate %</asp:Label></td><td>
                                                                <asp:Label ID="Label55" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Premium</asp:Label></td><td>
                                                                <asp:Label ID="Label56" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Quantity</asp:Label></td><td style="width: 97px">
                                                                <asp:Label ID="Label57" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Premium</asp:Label></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label58" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="127px">Physicians Assistant</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtPrimaryTN1" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtRateTN1" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">25%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtPremiumTN1" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtQuantityTN1" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 97px">
                                                                <asp:TextBox ID="txtTotPremTN1" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label59" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="109px">Nurse Midwife</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtPrimaryTN2" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtRateTN2" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">50%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtPremiumTN2" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtQuantityTN2" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 97px">
                                                                <asp:TextBox ID="txtTotPremTN2" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label60" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="119px">Nurse Anesthetist</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtPrimaryTN3" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtRateTN3" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">75%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtPremiumTN3" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtQuantityTN3" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 97px">
                                                                <asp:TextBox ID="txtTotPremTN3" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label61" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="111px">Nurse Practitioner</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtPrimaryTN4" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtRateTN4" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">20%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtPremiumTN4" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtQuantityTN4" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 97px">
                                                                <asp:TextBox ID="txtTotPremTN4" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td class="style35">
                                                                <asp:Label ID="Label62" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="117px">All Other Personel</asp:Label></td><td align="left" class="style35">
                                                                <asp:TextBox ID="txtPrimaryTN5" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td class="style35">
                                                                <asp:TextBox ID="txtRateTN5" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">10%</asp:TextBox></td><td class="style35">
                                                                <asp:TextBox ID="txtPremiumTN5" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td class="style35">
                                                                <asp:TextBox ID="txtQuantityTN5" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td class="style36">
                                                                <asp:TextBox ID="txtTotPremTN5" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="Label63" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="39px">Total:</asp:Label></td><td colspan="1">
                                                                <asp:TextBox ID="txtRateTN6" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="18px"
                                                                    Width="30px">100%</asp:TextBox></td><td align="right" colspan="1">
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtQuantityTN6" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 97px">
                                                                <asp:TextBox ID="txtTotPremTN6" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td></tr></table></asp:Panel></td></tr><tr>
                                            <td align="center" background="Images2/Barra3.jpg" colspan="5" height="1">
                                            </td>
                                        </tr>
                                        <div runat="server" id="section1">
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Label ID="Label64" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="9pt" Height="18px" Width="209px">Excess - Technicians & Nurses</asp:Label></td><td colspan="1" style="width: 168px; height: 22px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Panel ID="pnlExcess" runat="server" Width="637px">
                                                    <table style="width: 633px; height: 144px">
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label65" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Excess</asp:Label></td><td>
                                                                <asp:Label ID="Label66" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="49px">Rate %</asp:Label></td><td>
                                                                <asp:Label ID="Label67" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Premium</asp:Label></td><td>
                                                                <asp:Label ID="Label31" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Quantity</asp:Label></td><td style="width: 96px">
                                                                <asp:Label ID="Label32" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="41px">Premium</asp:Label></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label33" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="127px">Physicians Assistant</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtExcessTN1" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtERateTN1" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">15%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEPremiumTN1" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEQuantityTN1" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 96px">
                                                                <asp:TextBox ID="txtETotPremTN1" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label34" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="109px">Nurse Midwife</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtExcessTN2" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtERateTN2" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">50%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEPremiumTN2" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEQuantityTN2" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 96px">
                                                                <asp:TextBox ID="txtETotPremTN2" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label35" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="119px">Nurse Anesthetist</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtExcessTN3" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtERateTN3" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">50%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEPremiumTN3" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEQuantityTN3" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 96px">
                                                                <asp:TextBox ID="txtETotPremTN3" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label68" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="111px">Nurse Practitioner</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtExcessTN4" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtERateTN4" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">10%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEPremiumTN4" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEQuantityTN4" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 96px">
                                                                <asp:TextBox ID="txtETotPremTN4" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td>
                                                                <asp:Label ID="Label69" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="117px">All Other Personel</asp:Label></td><td align="left">
                                                                <asp:TextBox ID="txtExcessTN5" runat="server" Width="65px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtERateTN5" runat="server" Width="30px" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px">2.5%</asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEPremiumTN5" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td>
                                                                <asp:TextBox ID="txtEQuantityTN5" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 96px">
                                                                <asp:TextBox ID="txtETotPremTN5" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td></tr><tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="Label38" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="39px">Total:</asp:Label></td><td colspan="1">
                                                                <asp:TextBox ID="txtERateTN6" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="18px" Width="30px">100%</asp:TextBox></td><td align="right" colspan="1">
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEQuantityTN6" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td><td style="width: 96px">
                                                                <asp:TextBox ID="txtETotPremTN6" runat="server" Width="65px" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px"></asp:TextBox></td></tr></table></asp:Panel></td></tr><tr>
                                            <td colspan="3" align="right">
                                            </td>
                                            <td align="left" colspan="1" style="text-align: right">
                                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Calculate"
                                                    Width="106px" BackColor="#400000" BorderColor="#400000" 
                                                    ForeColor="White" /></td>
                                            <td colspan="1" style="width: 168px; height: 22px">
                                                 </td></tr><tr>
                                            <td align="right" background="Images2/Barra3.jpg" colspan="5" height="1px">
                                            </td>
                                        </tr>
                                        </div>
                                        <tr>
                                            <td style="width: 186px;">
                                            </td>
                                            <td style="width: 186px;">
                                            </td>
                                            <td colspan="2" align="right">
                                                <asp:Label ID="Label70" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="175px" Font-Bold="True" Height="16px">Total Primary Premium:</asp:Label> </td><td style="width: 168px;" align="left">
                                                <asp:TextBox ID="txtTotalPrimary" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="9pt" Height="18px" MaxLength="20" TabIndex="2" Width="87px"></asp:TextBox></td></tr><tr>
                                            <td style="width: 186px;">
                                            </td>
                                            <td style="width: 186px;">
                                            </td>
                                            <td colspan="2" align="right">
                                                <asp:Label ID="Label71" runat="server" CssClass="headfield1" 
                                                    Font-Names="Tahoma" Font-Size="9pt"
                                                    Width="175px" Font-Bold="True" Height="16px">Total Premium:</asp:Label> </td><td style="width: 168px; text-align: left;">
                                                <asp:TextBox ID="txtTotalExcess" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="9pt" Height="18px" MaxLength="20" TabIndex="2" Width="87px"></asp:TextBox>
                                                    </td>
                                                    </tr>
                                                    </table>
                                                    </TD>
                                                    </TR>
                                                    </TABLE>
                                                     <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" Width="400px" BackColor="#F4F4F4"
                        Style="display: none;">
                        <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
                            font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
                            background-repeat: no-repeat; text-align: left; vertical-align: bottom;">
                            <asp:Label ID="Label48" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans"
                                Font-Size="14pt" Text="Message.." ForeColor="#000066" />
                        </div>
                        <div class="CajaDialogoDiv" style="color: #FFFFFF">
                            <table style="background-position: center; width: 400px; height: 175px;">
                                <tr>
                                    <td align="left" valign="middle">
                                        <asp:TextBox ID="lblRecHeader" runat="server" Font-Bold="False" Font-Italic="False"
                                            Font-Size="10pt" Font-Underline="False" ForeColor="Maroon" Text="Message" Width="390px"
                                            Font-Names="Arial" CssClass="" TextMode="MultiLine" Height="170px" BorderColor="Transparent"
                                            BorderStyle="None" BorderWidth="0px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="CajaDialogoDiv" align="center">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                        </div>
                    </asp:Panel>
			<Toolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground"
                        CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript=""
                        OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                    </Toolkit:ModalPopupExtender>
                    <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent"
                        BorderStyle="None" BorderWidth="0" Visible="true" />
                                                    <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                                                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server" Visible="False"></maskedinput:maskedtextheader>
                <INPUT id="ConfirmDialogBoxPopUp" style="Z-INDEX: 102; LEFT: 802px; WIDTH: 35px; POSITION: absolute; TOP: 1056px; HEIGHT: 22px"
				type="hidden" size="1" value="false" name="ConfirmDialogBoxPopUp" runat="server"><input id="inputSupplierIndex" runat="server" enableviewstate="true" name="ConfirmDialogBoxPopUp"
                size="1" style="z-index: 102; left: 879px; width: 35px; position: absolute; top: 1053px;
                height: 22px" type="hidden" value="-1" />
                </form>
                </body>
                </HTML>
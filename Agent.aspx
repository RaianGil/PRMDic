<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.Agent" CodeFile="Agent.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="baldrich.css" type="text/css" rel="stylesheet">
		<LINK href="baldrich.css" type="text/css" rel="stylesheet">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
	    <style type="text/css">

	    .headfield1
        {
            text-align: left;
            margin-left: 0px;
            margin-right: 0px;
            }
	    </style>
	</HEAD>
	<script src="http://digitalbush.com/wp-content/uploads/2013/01/jquery.maskedinput-1.3.1.min_.js"></script>
	<script type='text/javascript'>
	    $(function () {
	        // Define your mask (using 9 to denote any digit)
	        $('#txtoff1').mask('(999) 999-9999');
	    });
  </script>
	<%--<script type='text/javascript'>

	    jQuery(function($) {

	    $("#txtoff1").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtoff2").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtphone").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    $("#txtphone2").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
	    
	    });

    </script>--%>
	<script>
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
	            }
	            else {
	                //document.Pol.TxtCity.value = "";
	                document.Pol.ddlCiudad.selectedIndex = -1;
	            }
	        }
	    }

	    function SetZipCode() {
	        if (document.Pol.ddlCiudad.selectedIndex > 0) {
	            document.Pol.TxtZip.value = document.Pol.ddlCiudad.options[document.Pol.ddlCiudad.selectedIndex].value
	        }
	        else {
	            document.Pol.TxtZip.value = ''
	        }
	    }

		</script>
	
	<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript">
        $("#effect").hide();
        $(function () {
            $('#<%= txtLicenseNumExpDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });
        });

        function ShowDateTimePicker() {
            $('#<%= txtLicenseNumExpDate.ClientID %>').datepicker('show');
        }
        // });
</script>
 <script type="text/javascript">
     $("#effect").hide();
     $(function () {
         $('#<%= txtlicexp.ClientID %>').datepicker({
             changeMonth: true,
             changeYear: true
         });
     });

     function ShowDateTimePicker() {
         $('#<%= txtlicexp.ClientID %>').datepicker('show');
     }
     // });
</script>

<%--<script type='text/javascript'>

    jQuery(function($) {

        $("#TxtTelefono").mask("(000) 000-0000", { placeholder: "(###) ###-####" });
        $("#TextBoxOther1").mask("(000) 000-0000", { placeholder: "(###) ###-####" });

    });

    </script>--%>
    
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 126; LEFT: 4px; WIDTH: 100%; POSITION: static; TOP: 4px; HEIGHT: 281px"
				cellSpacing="0" cellPadding="0" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 99px" cellSpacing="0" cellPadding="0" width="809"
								bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table1" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0" width="808"
											border="0">
											<TR>
												<TD style="WIDTH: 272px" align="left">     
													<asp:Label id="Label21" runat="server" Width="47px" Height="16px" Font-Size="11pt" Font-Bold="True"
														Font-Names="Tahoma" CssClass="headForm1 " ForeColor="Black">Agent:</asp:Label>
													<asp:Label id="lblAgentID" runat="server" Width="134px" Font-Size="10pt" Font-Names="Tahoma"></asp:Label></TD>
												<TD align="right">
													<asp:Button id="btnCommission" runat="server" Width="100px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px" 
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Commission" onclick="btnCommission_Click"></asp:Button>
													<asp:Button id="btnAuditTrail" runat="server" Width="90px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
													<asp:Button id="btnPrint" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Print" onclick="btnPrint_Click"></asp:Button>
													<asp:Button id="btnSearch" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Search" onclick="btnSearch_Click"></asp:Button>
													<asp:Button id="BtnSave" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Save" onclick="BtnSave_Click"></asp:Button>
													<asp:Button id="btnEdit" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Edit" onclick="btnEdit_Click"></asp:Button>
													<asp:Button id="btnAddNew" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
													<asp:Button id="cmdCancel" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
													<asp:Button id="BtnExit" runat="server" Width="60px" Height="30px" CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px"
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="Exit" onclick="BtnExit_Click"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px">
										<TABLE id="Table11" style="WIDTH: 100%" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
                                                <br />
                                    <br />
													<img src="Images2/GreyLine.png" alt="" width="100%" height="6px" />
												</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 192px" vAlign="middle" align="center">                                                                                                                                          
										<TABLE id="Table6" style="WIDTH: 802px; HEIGHT: 84px" cellSpacing="0" cellPadding="0" width="802"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE id="Table4" style="WIDTH: 784px; HEIGHT: 10px" cellSpacing="0" cellPadding="0" width="784"
														border="0">
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px">
																<asp:label id="lblB" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="129px">Agent Description</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtAgentDescription" tabIndex="1" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px"  CssClass="form-control" WIDTH="249px" MAXLENGTH="30"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label1" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Agent Inicial </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtinicial" tabIndex="2" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="20px" MAXLENGTH="1"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label2" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Agent Lastname 1 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtlast1" tabIndex="3" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="20"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label3" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Agent LastName 2 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtlast2" tabIndex="4" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="20"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 10px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 10px">
																<asp:label id="lblAddress1" Width="99px" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma"
																	Font-Size="9pt"> Address 1</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px">
																<asp:textbox id="txtAddress1" tabIndex="5" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px"  CssClass="form-control" WIDTH="249" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px">
																<asp:label id="lblAddress2" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt"> Address 2</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtAddress2" tabIndex="6" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px" CssClass="form-control" WIDTH="249" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblCity" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">City</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtCity" tabIndex="7" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" HEIGHT="27px"
                                                                CssClass="form-control" WIDTH="144px" MAXLENGTH="20"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblState" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">State</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtSt" tabIndex="8" RUNAT="server"  CssClass="form-control" WIDTH="37px" HEIGHT="27px"
																	MAXLENGTH="2" Font-Names="Tahoma" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblZipCode" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1">Zip Code</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtZipCode" tabIndex="9" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px" CssClass="form-control" ISDATE="False" WIDTH="144px" MASK="99999Z9999" MAXLENGTH="10"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 10px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 10px">
																<asp:label id="Label32" Width="99px" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma"
																	Font-Size="9pt">Second Address 1</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px">
																<asp:textbox id="txtaddresssec1" tabIndex="5" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px"  CssClass="form-control" WIDTH="249" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 1px">
																<asp:label id="Label33" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Second Address 2</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtaddresssec2" tabIndex="6" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px"  CssClass="form-control" WIDTH="249" MAXLENGTH="100"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label34" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Second City</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtcity2" tabIndex="7" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="20"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label35" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Second State</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtstate2" tabIndex="8" RUNAT="server" CssClass="form-control" WIDTH="37px" HEIGHT="27px"
																	MAXLENGTH="2" Font-Names="Tahoma" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label36" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1">Second Zip Code</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtzip2" tabIndex="9" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px" CssClass="form-control" ISDATE="False" WIDTH="144px" MASK="99999Z9999" MAXLENGTH="10"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label24" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Sent to: </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
                                                                <asp:RadioButtonList ID="rbsentto" runat="server" Font-Size="X-Small" 
                                                                    RepeatDirection="Horizontal" Width="272px">
                                                                    <asp:ListItem Value="0">Postal Address</asp:ListItem>
                                                                    <asp:ListItem Value="1">Physical Address</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label4" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Sales Contact </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtsales" tabIndex="10" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" ></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label5" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Accounting Contact </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtacco" tabIndex="11" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" ></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label6" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Contact Email 1 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail1" tabIndex="12" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="30"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label7" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Contact Email 2 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail2" tabIndex="13" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="30"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label8" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Contact Email 3 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail3" tabIndex="14" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="30" ></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label9" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Contact Email 4 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail4" tabIndex="15" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="30"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label10" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Contact Email 5 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtemail5" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="30"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label26" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Website</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtwebsite" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label27" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Facebook</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtfacebook" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label28" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Instagram</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtinstagram" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label29" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Twitter</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txttwitter" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label30" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">LinkedIn</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtlinkedin" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label31" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Other Social Media</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtothersm" tabIndex="16" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="50"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label11" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Office Phone 1 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtoff1" tabIndex="17" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15" ></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label12" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Office Phone 2 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtoff2" tabIndex="18" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblPhone" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1">Home Phone 1</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:MaskedTextBox id="txtPhone" tabIndex="19" runat="server" Width="144" Height="27px" Font-Size="9pt"
																	Font-Names="Tahoma" MAXLENGTH="15" CssClass="form-control" Mask="(999) 999-9999" Columns="34"   ></maskedinput:MaskedTextBox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label13" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Home Phone 2 </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
															    <maskedinput:MaskedTextBox id="txtphone2" tabIndex="20" runat="server" Width="144" Height="27px" Font-Size="9pt"
																	Font-Names="Tahoma" MAXLENGTH="15" CssClass="form-control" Mask="(999) 999-9999" Columns="34"   ></maskedinput:MaskedTextBox>
																<%--<asp:textbox id="txtphone2" tabIndex="20" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:textbox>--%></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label14" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Office Fax </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtfax" tabIndex="21" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<P id="P1" runat="server">
																	<asp:label id="lblEntryDate" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1">Entry Date</asp:label></P>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtEntryDate" tabIndex="22" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="27px"  CssClass="form-control" Enabled="False" ISDATE="True" WIDTH="144px" Mask="DD/DD/9999"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblEmail" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" 
                                                                    CSSCLASS="headfield1">E-mail</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:TextBox ID="txtEmail" runat="server" Height="27px" MaxLength="30" CssClass="form-control"
                                                                    Width="144px" TabIndex="23"></asp:TextBox>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblSocialSecurity" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Social Security</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<maskedinput:maskedtextbox id="txtSocialSecurity" tabIndex="24" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server" MAXLENGTH="12"
																	HEIGHT="27px"  CssClass="form-control" ISDATE="False" WIDTH="144px"  onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblLicenseNum" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server"  CSSCLASS="headfield1"> License Num.</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:TextBox ID="txtLicenseNum" runat="server" Height="27px" MaxLength="15" tabIndex="25" CssClass="form-control"
                                                                    Width="144px"></asp:TextBox>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="Label25" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server"  CSSCLASS="headfield1"> License Exp. Date </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
															<asp:TextBox ID="txtlicexp" runat="server" Columns="30" CssClass="form-control" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="27px" onIsDate="True" TabIndex="26"
                                                                    Width="79px"></asp:TextBox>
																<%--<asp:TextBox ID="txtlicexp" runat="server" Height="27px" MaxLength="10"  CssClass="form-control"
                                                                    Width="144px"></asp:TextBox>--%>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label15" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Type of License </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddltypelic" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label16" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Application </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlappl" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label17" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">OCS Appointment </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlocsa" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem Value="Pending"></asp:ListItem>
                                                                    <asp:ListItem>N/A</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label18" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="173px">Commission Agreement </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlcomm" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Standard Commission Agreement</asp:ListItem>
                                                                    <asp:ListItem Value="Special Commission Agreement">Special Commission Agreement</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label19" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Tax Waiver Certificate </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddltaxwai" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control" >
                                                                    <asp:ListItem>Partial</asp:ListItem>
                                                                    <asp:ListItem>Total</asp:ListItem>
                                                                    <asp:ListItem>None</asp:ListItem>
                                                                    <asp:ListItem>Expired</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label20" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">E & O Policy </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddleopolicy" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    <asp:ListItem>Expired</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label22" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="198px">Merchant Registration (Suri) </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlmerchregis" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    <asp:ListItem>Expired</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="Label23" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Payment Method </asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlpaymet" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                    <asp:ListItem>Wired</asp:ListItem>
                                                                    <asp:ListItem>Check</asp:ListItem>
                                                                    <asp:ListItem>Direct Deposit</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													
													        </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> </TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblLicenseNumExpDate" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Lic. Number Exp Date</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
                                                                <asp:TextBox ID="txtLicenseNumExpDate" runat="server" Columns="30"  CssClass="form-control" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="27px" onIsDate="True" TabIndex="27"
                                                                    Width="79px"></asp:TextBox>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> </TD>
														</TR>
														
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:CheckBox ID="chkAllComm" runat="server" Text="Add All Commissions"  
                                                                        Font-Size="9pt" Font-Names="Tahoma"  />
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
                                                                &nbsp;</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblDeposit" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Direct Deposit:</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
                                                                <asp:RadioButtonList ID="chkAccountType" runat="server" Font-Size="X-Small" 
                                                                    RepeatDirection="Horizontal" Width="252px">
                                                                    <asp:ListItem Value="0">Direct Deposit</asp:ListItem>
                                                                    <asp:ListItem Value="1">Chekings</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblBanco" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Banco:</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtBanco" tabIndex="28" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblRuta" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Num. Ruta:</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtNumRuta" tabIndex="29" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																	<asp:label id="lblCuenta" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" CSSCLASS="headfield1">Num. Cuenta:</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:textbox id="txtNumCuenta" tabIndex="30" Font-Size="9pt" Font-Names="Tahoma" 
                                                                    RUNAT="server" HEIGHT="27px"
																	 CssClass="form-control" WIDTH="144px" MAXLENGTH="15"></asp:textbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> &nbsp;</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"> &nbsp;</TD>
															<TD style="WIDTH: 162px; HEIGHT: 5px">
																<asp:label id="lblB0" RUNAT="server" CSSCLASS="headfield1" HEIGHT="19px" 
                                                                    ForeColor="Black" Font-Names="Tahoma"
																	Font-Size="9pt" Width="140px">Belongs to Agency:</asp:label>
															</TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:DropDownList ID="ddlAgency" runat="server" Width="249px" HEIGHT="29px" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"> 
													<asp:Button id="btnAddBelongsTo" runat="server" Width="80px" Height="30px" 
                                                    CssClass="ButtonTextMenu-12 btn" style = "background-color: #ba354e; margin-right: 1px" 
														BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
													        </TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 112px; HEIGHT: 5px" align="left"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px">
                                     <asp:DataGrid ID="GridAgency" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6"
                                    AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" Font-Names="Arial"
                                    Font-Size="9pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2"
                                    HeaderStyle-HorizontalAlign="Center" Height="16px" ItemStyle-CssClass="HeadForm3"
                                    ItemStyle-HorizontalAlign="center" 
                                    PageSize="8" TabIndex="9" Width="795px" onitemcommand="GridAgency_ItemCommand">
                                    <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                    <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="Tahoma" ForeColor="Blue"
                                        HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                                    <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                    <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundColumn DataField="AgencyBelongsToID" HeaderText="ID" Visible="True">
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AgencyDesc" HeaderText="Agency" Visible="True">
                                            <HeaderStyle Width="700px" />
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                        </asp:BoundColumn>

                                        <asp:TemplateColumn HeaderText="Del.">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelEndorsement" runat="server" CommandArgument="Delete" CommandName="Delete"
                                                    OnClientClick="return confirm('Are you certain you want to delete this Agency?');" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="40px" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False"
                                        Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                        ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                </asp:DataGrid>  
                                    </TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px">&nbsp;</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
			<asp:imagebutton id="btnAddNew1" style="Z-INDEX: 117; LEFT: 859px; POSITION: absolute; TOP: 9px"
				tabIndex="10" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="btnEdit1" style="Z-INDEX: 118; LEFT: 883px; POSITION: absolute; TOP: 9px" tabIndex="11"
				runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="BtnSave1" style="Z-INDEX: 119; LEFT: 915px; POSITION: absolute; TOP: 9px" tabIndex="12"
				RUNAT="server" Visible="False" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif"></asp:imagebutton>
			<asp:imagebutton id="btnSearch1" style="Z-INDEX: 120; LEFT: 947px; POSITION: absolute; TOP: 9px"
				tabIndex="13" runat="server" Visible="False" ImageUrl="Images/search_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="cmdCancel1" style="Z-INDEX: 121; LEFT: 979px; POSITION: absolute; TOP: 9px"
				tabIndex="14" runat="server" Visible="False" ImageUrl="Images/cancel_btn.gif" CausesValidation="False"></asp:imagebutton>
			<asp:imagebutton id="btnPrint1" style="Z-INDEX: 122; LEFT: 1099px; POSITION: absolute; TOP: 9px"
				tabIndex="15" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
			<asp:ImageButton id="btnAuditTrail1" style="Z-INDEX: 123; LEFT: 1011px; POSITION: absolute; TOP: 9px"
				runat="server" Width="48px" Height="19px" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
			<asp:imagebutton id="BtnExit1" style="Z-INDEX: 124; LEFT: 1067px; POSITION: absolute; TOP: 9px" tabIndex="17"
				RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
		</form>
	</body>
</HTML>

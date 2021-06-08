<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.ProspectIndividual" CodeFile="ProspectIndividual.aspx.cs" %>
        <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			    <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="epolicy.css" type="text/css" rel="stylesheet">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>				
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
		<script src="js/load.js" type="text/javascript"></script>
				
				
        <script type="text/javascript">
            $("#effect").hide();
            $(function() {
                $('#<%= txtlicexpdate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function ShowDateTimePicker() {
                $('#<%= txtlicexpdate.ClientID %>').datepicker('show');
            }
            // });
        </script>
	    <style type="text/css">
            .style1
            {
                height: 30px;
                width: 144px;
            }
            .style2
            {
                height: 10px;
                width: 144px;
            }
            .style3
            {
                height: 28px;
                width: 144px;
            }
            .style4
            {
                height: 31px;
                width: 144px;
            }
            .style5
            {
                width: 302px;
            }
			              
       
                    .modalBackground {
                        background-color: Gray;
                        filter: alpha(opacity=50);
                        opacity: 0.5;
                    }
        </style>
      
	</HEAD>
	<body>
	<div class="middleMain">
		<form method="post" runat="server">
		  <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="900">
                        </Toolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
							
			<TABLE id="Table8" style="Z-INDEX: 153; LEFT: 4px; WIDTH: 75%; cellSpacing="0" cellPadding="0" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD >
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                        </P>
					</TD>

				</TR>
				<TR>
					<TD style="WIDTH: 100%; align="center" >
							<TABLE id="Table9" style="WIDTH: 100%;" cellSpacing="0" cellPadding="0"
								width="317" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">
									    <TABLE id="Table10" style="WIDTH: 100%; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left" class="style5"> 
													<asp:Label id="Label17" runat="server" Font-Names="Tahoma" Width="77px" ForeColor="Black" Height="16px"
														CssClass="headForm1 " Font-Size="11pt" Font-Bold="True">Prospect: </asp:Label> 
													<asp:Label id="Label2" runat="server" Font-Names="Tahoma" Width="33px" ForeColor="Black" Height="1px"
														CssClass="headForm1 " Font-Size="9pt">Client: </asp:Label> 
													<asp:label id="lblParentCustomer" Font-Names="Tahoma" WIDTH="113px" CSSCLASS="headfield1" RUNAT="server"
														Font-Size="9pt"></asp:label>
													<asp:label id="lblProspectNo" Font-Names="Tahoma" WIDTH="111px" CSSCLASS="headfield1" RUNAT="server"
														Font-Size="9pt"></asp:label></TD>
												<TD align="right">
													<asp:Button id="cmdConvertToCustomer" runat="server" onclick="cmdConvertToCustomer_Click" 
                                                        Text="Convert" class="btn-h-30 btn-bg-theme2 btn-r-4"/>
													<asp:Button id="btnAuditTrail" runat="server" onclick="btnAuditTrail_Click" 
                                                        Text="History" class="btn-h-30 btn-bg-theme2 btn-r-4"></asp:Button>
													<asp:Button id="btnNew" runat="server" onclick="btnNew_Click" 
                                                        Text="Add" class="btn-h-30 btn-bg-theme2 btn-r-4"></asp:Button>
													<asp:Button id="btnDelete" runat="server" onclientclick="return confirm('Deleting current prospect, Continue?');" onclick="btnDelete_Click" 
                                                        Text="Delete" class="btn-h-30 btn-bg-theme2 btn-r-4"/>
													<asp:Button id="BtnSave" runat="server" onclick="BtnSave_Click"
                                                        Text="Save" class="btn-h-30 btn-bg-theme2 btn-r-4"/>
													<asp:Button id="btnEdit" runat="server" onclick="btnEdit_Click"
                                                        Text="Edit" class="btn-h-30 btn-bg-theme2 btn-r-4"/>
													<asp:Button id="cmdCancel" runat="server" onclick="cmdCancel_Click"
                                                        Text="Cancel" class="btn-h-30 btn-bg-theme2 btn-r-4"/>
													<asp:Button id="cmdExit" runat="server" onclick="cmdExit_Click"
                                                        Text="Exit" class="btn-h-30 btn-bg-theme2 btn-r-4"/>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 5px">
										<TABLE class="tableMain">
											<TR>
												 <div class="col-md-12">
													<hr />
												</div>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100%;  vAlign="middle" align="center">                                                                                                                                          
										<TABLE class="tableMain">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<TABLE class="tableMain">
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 30px" vAlign="middle"> <FONT color="#ff0066"> </FONT></TD>
															<TD style="WIDTH: 114px; HEIGHT: 30px">
																<asp:label id="lblFirstName" Font-Names="Tahoma" HEIGHT="18px" WIDTH="80px" CSSCLASS="headfield1"
																	RUNAT="server" ENABLEVIEWSTATE="False" Font-Size="9pt">First Name</asp:label>
                                                            </TD>
															<TD style="WIDTH: 156px; HEIGHT: 30px">
																<asp:textbox id="txtFirstname" tabIndex="1" Font-Names="Tahoma" HEIGHT="25px" WIDTH="140" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="30" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 30px"><FONT color="#ff0066"> </FONT></TD>
															<TD class="style1">
																<asp:label id="lbllicence" Font-Names="Tahoma" HEIGHT="17px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Licence</asp:label></TD>
															<TD style="WIDTH: 166px; HEIGHT: 30px">
																<asp:textbox id="txtlicence" tabIndex="10" Font-Names="Tahoma" HEIGHT="25px" WIDTH="140" CSSCLASS="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																	RUNAT="server" MAXLENGTH="15" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 30px"></TD>
															<TD style="WIDTH: 127px; HEIGHT: 30px">   
																<asp:label id="lblReferredBy" Font-Names="Tahoma" HEIGHT="15px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Width="98px" Font-Size="9pt">Referred By</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 30px">
																<asp:dropdownlist id="ddlReferredBy" tabIndex="19" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" AUTOPOSTBACK="True" Font-Size="8pt"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 30px" vAlign="middle"> <FONT color="#ff0066"> </FONT></TD>
															<TD style="WIDTH: 114px; HEIGHT: 30px">
																<asp:label id="lblinicial" Font-Names="Tahoma" HEIGHT="18px" WIDTH="75px" CSSCLASS="headfield1"
																	RUNAT="server" ENABLEVIEWSTATE="False" Font-Size="9pt">Inicial</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 30px">
																<asp:textbox id="txtinicial" tabIndex="2" Font-Names="Tahoma" HEIGHT="25px" WIDTH="140" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="1" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 30px"><FONT color="#ff0066"> </FONT></TD>
															<TD class="style1">
																<asp:label id="lbllicexpdate" Font-Names="Tahoma" HEIGHT="17px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Licence Exp Date</asp:label></TD>
															<TD style="WIDTH: 166px; HEIGHT: 30px">
																<asp:textbox id="txtlicexpdate" tabIndex="11" Font-Names="Tahoma"  HEIGHT="25px" WIDTH="140" CSSCLASS="form-control" 
																	RUNAT="server" MAXLENGTH="15" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 30px"></TD>
															<TD style="WIDTH: 127px; HEIGHT: 30px">   
																<asp:label id="lblstatus" Font-Names="Tahoma" HEIGHT="15px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Width="98px" Font-Size="9pt">Status</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 30px">
																<asp:dropdownlist id="ddlstatus" tabIndex="19" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" AUTOPOSTBACK="True" Font-Size="8pt">
                                                                    <asp:ListItem>Closed</asp:ListItem>
                                                                    <asp:ListItem>Declined</asp:ListItem>
                                                                    <asp:ListItem>Issued</asp:ListItem>
                                                                    <asp:ListItem>Orientation</asp:ListItem>
                                                                    <asp:ListItem>Pending</asp:ListItem>
                                                                    <asp:ListItem>Quoted</asp:ListItem>
                                                                    <asp:ListItem>Quoted/NI</asp:ListItem>
                                                                    <asp:ListItem>Submitted to UND</asp:ListItem>
                                                                    <asp:ListItem>Waiting for payment</asp:ListItem>
                                                                    <asp:ListItem>Payment received and referred to accounting</asp:ListItem>
                                                                    <asp:ListItem>Waiting for policy to insurance</asp:ListItem>
                                                                    <asp:ListItem>Requisites not met</asp:ListItem>
                                                                    <asp:ListItem>Operations outside of PR</asp:ListItem>
                                                                    <asp:ListItem>Higher Limits</asp:ListItem>
                                                                    <asp:ListItem>High Loss Ratio</asp:ListItem>
                                                                    <asp:ListItem>Telemedicine exposures</asp:ListItem>
                                                                    <asp:ListItem>Not available product</asp:ListItem>
                                                                    <asp:ListItem>Moral Hazard</asp:ListItem>
                                                                    <asp:ListItem>Risk Management Recommendation</asp:ListItem>
                                                                    <asp:ListItem>Student</asp:ListItem>
                                                                    <asp:ListItem>Other</asp:ListItem>
                                                                </asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 30px" vAlign="middle"> <FONT color="#ff0066"> </FONT></TD>
															<TD style="WIDTH: 114px; HEIGHT: 30px">
																<asp:label id="lblLastName1" Font-Names="Tahoma" HEIGHT="16px" WIDTH="75px" CSSCLASS="headfield1"
																	RUNAT="server" ENABLEVIEWSTATE="False" Font-Size="9pt">Last Name 1</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 30px">
																<asp:textbox id="txtLastname1" tabIndex="4" Font-Names="Tahoma" HEIGHT="25px" WIDTH="140" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="30" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 30px"><FONT color="#ff0066"> </FONT></TD>
															<TD class="style1">
																<asp:label id="Label12" Font-Names="Tahoma" HEIGHT="17px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Home Phone</asp:label></TD>
															<TD style="WIDTH: 166px; HEIGHT: 30px">
																<asp:textbox id="txtHomePhone" tabIndex="12" Font-Names="Tahoma" HEIGHT="25px" WIDTH="140" CSSCLASS="form-control"  
																	RUNAT="server" MAXLENGTH="13" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 30px"></TD>
															<TD style="WIDTH: 127px; HEIGHT: 30px">   
																<asp:label id="lblinsuredtype" Font-Names="Tahoma" HEIGHT="15px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Width="98px" Font-Size="9pt">Insured Type</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 30px">
																<asp:dropdownlist id="ddlinsuredtype" tabIndex="19" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" AUTOPOSTBACK="True" Font-Size="8pt">
                                                                    <asp:ListItem>Physicians: Surgeon</asp:ListItem>
                                                                    <asp:ListItem>Physicians: NS</asp:ListItem>
                                                                    <asp:ListItem>Physicians: MS</asp:ListItem>
                                                                    <asp:ListItem>Physicians: Teaching</asp:ListItem>
                                                                    <asp:ListItem>Physicians: Dentist</asp:ListItem>
                                                                    <asp:ListItem>Physicians: Podiatrist</asp:ListItem>
                                                                    <asp:ListItem>Corporation: Allied</asp:ListItem>
                                                                    <asp:ListItem>Corporation: Cyber</asp:ListItem>
                                                                    <asp:ListItem>Corporation: Lab</asp:ListItem>
                                                                    <asp:ListItem>Corporation: MedMal</asp:ListItem>
                                                                    <asp:ListItem>Allied: Technician</asp:ListItem>
                                                                    <asp:ListItem>Allied: Assistant</asp:ListItem>
                                                                    <asp:ListItem>Allied: Pathologist</asp:ListItem>
                                                                    <asp:ListItem>Allied: Nurse</asp:ListItem>
                                                                </asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 10px" Align="middle"> </TD>
															<TD style="WIDTH: 114px; HEIGHT: 10px">
																<asp:label id="lblLastName2" Font-Names="Tahoma" HEIGHT="25px" WIDTH="75px" CSSCLASS="headfield1"
																	RUNAT="server" ENABLEVIEWSTATE="False" Font-Size="9pt">Last Name 2</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 10px">
																<asp:textbox id="txtLastname2" tabIndex="5" Font-Names="Tahoma" HEIGHT="25px" WIDTH="140" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="30" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 10px"><FONT color="#ff0066"> </FONT></TD>
															<TD class="style2">
																<asp:label id="lblWorkPhone" Font-Names="Tahoma" HEIGHT="16px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Work Phone</asp:label></TD>
															<TD style="WIDTH: 166px; HEIGHT: 10px">
																<maskedinput:maskedtextbox id="txtWorkPhone" tabIndex="13" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																	RUNAT="server" MAXLENGTH="13" MASK="(999) 999-9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 10px"></TD>
															
															<TD style="WIDTH: 127px; HEIGHT: 28px">   
																<asp:label id="lblLocation" Font-Names="Tahoma" HEIGHT="15px" WIDTH="80px" CSSCLASS="headfield1"
																	RUNAT="server" ENABLEVIEWSTATE="False" Font-Size="9pt">Originated At</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 28px">
																<asp:dropdownlist id="ddlLocation" tabIndex="19" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" Font-Size="8pt"></asp:dropdownlist></TD>
															
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 28px"></TD>
															<TD style="WIDTH: 114px; HEIGHT: 28px">
																<asp:label id="lblEmail" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">E-mail</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 28px">
																<asp:textbox id="txtEmail" tabIndex="6" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 28px"><FONT color="#ff0066"> </FONT></TD>
															<TD class="style3">
																<asp:label id="lblCellular" Font-Names="Tahoma" WIDTH="83px" CSSCLASS="HeadField1" RUNAT="server"
																	Font-Size="9pt">Cellular Phone</asp:label></TD>
															<TD style="WIDTH: 166px; HEIGHT: 28px">
																<maskedinput:maskedtextbox id="txtCellular" tabIndex="14" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																	RUNAT="server" MAXLENGTH="13" MASK="(999) 999-9999" ISDATE="False" Font-Size="9pt"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 2px; HEIGHT: 28px"></TD>
															<TD style="WIDTH: 127px; HEIGHT: 28px">   
																<asp:label id="Label9" Font-Names="Tahoma" HEIGHT="15px" WIDTH="80px" CSSCLASS="headfield1"
																	RUNAT="server" ENABLEVIEWSTATE="False" Font-Size="9pt">Amsca Or DEA</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 28px">
																<asp:dropdownlist id="ddlAmscaOrDEA" tabIndex="19" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" Font-Size="8pt">
                                                                    <asp:ListItem>Amsca</asp:ListItem>
                                                                    <asp:ListItem>Dea</asp:ListItem>
                                                                </asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 31px"></TD>
															<TD style="WIDTH: 114px; HEIGHT: 31px">
																<asp:label id="Label1" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">E-mail 2</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtEmail2" tabIndex="7" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 31px"></TD>
															<TD class="style4">
															
																<asp:label id="Label3" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Fax</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtFax" tabIndex="15" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" 
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															
															
															<TD style="WIDTH: 2px; HEIGHT: 31px"></TD>
														
															<TD class="style4">
																<asp:label id="Label21" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Lead ID</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtLeadID" tabIndex="20" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 31px"></TD>
															<TD style="WIDTH: 114px; HEIGHT: 31px">
																<asp:label id="Label11" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Address 1</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtaddress1" tabIndex="8" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 31px"></TD>
															<TD class="style4">
																<asp:label id="Label4" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Convert To Client</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtConvToClientDate" tabIndex="16" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 99px; HEIGHT: 31px"></TD>
															<TD class="style4">
																<asp:label id="Label19" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Agent ID</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtAgentID" tabIndex="21" Font-Names="Tahoma"  WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															
																
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 31px"></TD>
															<TD style="WIDTH: 114px; HEIGHT: 31px">
																<asp:label id="Label14" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Address 2</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtaddress2" tabIndex="9" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 31px"></TD>
															<TD class="style4">
																<asp:label id="Label13" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Website </asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtWebsite" tabIndex="17" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 99px; HEIGHT: 31px"></TD>
															<TD class="style4">
																<asp:label id="Label20" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Interested IN</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtInterestedIN" tabIndex="22" Font-Names="Tahoma" WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															
															
																
														</TR>
														<TR>
															<TD style="WIDTH: 5px; HEIGHT: 31px"></TD>
															<TD style="WIDTH: 114px; HEIGHT: 31px">
																<asp:label id="Label15" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="headfield1" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt">Quoted</asp:label></TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																<asp:textbox id="txtQuoted" tabIndex="9" Font-Names="Tahoma" HEIGHT="25px" WIDTH="141" CSSCLASS="form-control"
																	RUNAT="server" MAXLENGTH="50" Font-Size="9pt"></asp:textbox></TD>
															<TD style="WIDTH: 86px; HEIGHT: 31px"></TD>
															<TD class="style4">
																&nbsp;</TD>
															<TD style="WIDTH: 156px; HEIGHT: 31px" vAlign="middle">
																&nbsp;</TD>
															<TD style="WIDTH: 1px; HEIGHT: 1px"></TD>
															<asp:label id="txtReferredByName" visible="false" Font-Names="Tahoma" HEIGHT="13px" CSSCLASS="form-control" RUNAT="server"
																	ENABLEVIEWSTATE="False" Font-Size="9pt"></asp:label>
															
															<TD style="WIDTH: 127px; HEIGHT: 31px"></TD>
															<TD style="WIDTH: 168px; HEIGHT: 28px">
																<asp:dropdownlist id="ddlHouseIncome" tabIndex="18" Font-Names="Tahoma"  WIDTH="152" CSSCLASS="form-control"
																	RUNAT="server" Font-Size="9pt" Visible="false"></asp:dropdownlist></TD>
															<TD style="WIDTH: 168px; HEIGHT: 31px"></TD>
																
														</TR>
												
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 8px" align="left">   
										<asp:label id="LblTotalCases" Font-Names="Tahoma" WIDTH="148px" CSSCLASS="headform3" RUNAT="server"
											ForeColor="Black" Height="9px" Font-Size="9pt">Total Cases:</asp:label>
									</TD>
								</TR>
								<tr>
									<td style="HEIGHT: 10px">
										<div class="col-md-12">
													<hr />
												</div>
									</td>
								</tr>
								<TR>
									<TD style="FONT-SIZE: 5pt; WIDTH: 100%; HEIGHT: 65px" align="left">
										<asp:Label id="LblError" runat="server" Width="100%" ForeColor="IndianRed" Visible="False"
											Font-Size="10pt" Font-Names="Tahoma">Label</asp:Label>
										<asp:datagrid id="searchIndividual" RUNAT="server" WIDTH="100%" Height="204px"  Font-Size="10pt"
                                            class="table table-bordered table-condensed table-hover " AUTOGENERATECOLUMNS="False" ALLOWPAGING="True" CELLPADDING="0"
											PageSize="7" OnItemCommand="searchIndividual_ItemCommand1" OnItemDataBound="searchIndividual_ItemDataBound1">
											<Columns>
												<asp:ButtonColumn HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." ButtonType="PushButton" CommandName="Select">
													<HeaderStyle Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"/>
												</asp:ButtonColumn>
												<asp:BoundColumn DataField="TaskControlID" HeaderText="Control No.">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TaskControlTypeDesc" HeaderText="Task Type">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="EntryDate" HeaderText="Entry Date" DataFormatString="{0:d}">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TaskStatusDesc" HeaderText="Status">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
                                                <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                                <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px"></TD>
								</TR>
							</TABLE>
					</TD>
				</TR>
			</TABLE>
			<asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
			  </ContentTemplate>
                        </asp:UpdatePanel>
			</form>
		</div>
	</body>
</HTML>

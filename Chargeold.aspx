<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.Agent" CodeFile="Charge.aspx.cs" %>
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
	    <style type="text/css">
            .style1
            {
                width: 468px;
            }
            .style2
            {
                height: 1px;
                width: 89px;
            }
            .style3
            {
                height: 10px;
                width: 89px;
            }
            .style4
            {
                height: 5px;
                width: 89px;
            }
        </style>
	</HEAD>
	 <script type="text/javascript">
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<%--    <script type="text/javascript">
        $("#effect").hide();
        $(function() 
        {
            $('#<%= txtEffectiveDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });

        function ShowDateTimePicker()
        {
            $('#<%= txtEffectiveDate.ClientID %>').datepicker('show');
        }    
        
    
	    $(function() { 
		//run the currently selected effect
		function runEffect()
		{
			//get effect type from 
			//var selectedEffect = $('#effectTypes').val();
			var selectedEffect ="blind";
			//most effect types need no options passed by default
			var options = {};			
			//run the effect
			$("#effect").show(selectedEffect,options,500,callback);
		};
    </script>  --%> 
	<body background="Images2/SQUARE.GIF" bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table8" style="Z-INDEX: 126; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 281px"
				cellSpacing="0" cellPadding="0" width="911" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 5px; POSITION: static; HEIGHT: 395px" vAlign="top"
						align="right" colSpan="1" rowSpan="5">
						<P align="center">
							<asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder></P>
					</TD>
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
												<TD align="left" class="style1">     
													<asp:Label id="Label21" runat="server" Width="189px" Height="16px" 
                                                        Font-Size="11pt" Font-Bold="True"
														Font-Names="Tahoma" CssClass="headForm1 " ForeColor="Black">Charge Definitions for: </asp:Label>
													<asp:Label id="lblChargeDate" runat="server" Width="188px" Font-Size="10pt" 
                                                        Font-Names="Tahoma"></asp:Label></TD>
												<TD align="right">
													<asp:Button id="btnSearch" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Search" onclick="btnSearch_Click"></asp:Button>
													<asp:Button id="BtnSave" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Save" onclick="BtnSave_Click"></asp:Button>
													<asp:Button id="btnEdit" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Edit" onclick="btnEdit_Click"></asp:Button>
													<asp:Button id="btnAddNew" runat="server" BackColor="#400000" Width="59px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
													<asp:Button id="cmdCancel" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
													<asp:Button id="BtnExit" runat="server" BackColor="#400000" Width="46px" Height="23px"
														BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" ForeColor="White" Text="Exit" onclick="BtnExit_Click"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px">
										<TABLE id="Table11" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD background="Images2/Barra3.jpg"></TD>
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
															<TD class="style2">
																<asp:label id="lblCity" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Effective Date:</asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:textbox id="txtEffectiveDate" tabIndex="4" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server" HEIGHT="21"
																	CSSCLASS="headfield1" WIDTH="144px" MAXLENGTH="10"
																	 ></asp:textbox></TD><%--onclick="ShowDateTimePicker();"--%>
															<TD style="WIDTH: 168px; HEIGHT: 1px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 10px"></TD>
															<TD class="style3">
																<asp:label id="lblState" RUNAT="server" CSSCLASS="headfield1" Font-Names="Tahoma" Font-Size="9pt">Charge Percent: </asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px">
																<maskedinput:maskedtextbox id="txtChargePercent" tabIndex="6" Font-Size="9pt" 
                                                                    Font-Names="Tahoma" RUNAT="server"
																	HEIGHT="19px" CSSCLASS="headfield1" ISDATE="False" WIDTH="109px" MASK="0.999999" MAXLENGTH="10"></maskedinput:maskedtextbox></TD>
															<TD style="WIDTH: 168px; HEIGHT: 10px"></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 1px"></TD>
															<TD class="style2">
																<asp:label id="lblState0" RUNAT="server" CSSCLASS="headfield1" 
                                                                    Font-Names="Tahoma" Font-Size="9pt">Policy Type: </asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px">
																<asp:DropDownList ID="ddlPolicyType" runat="server">
                                                                    <asp:ListItem Value="1">PP</asp:ListItem>
                                                                    <asp:ListItem Value="2">PE</asp:ListItem>
                                                                    <asp:ListItem Value="3">CP</asp:ListItem>
                                                                    <asp:ListItem Value="4">CE</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 1px"> </TD>
														</TR>
														<TR>
															<TD style="WIDTH: 186px; HEIGHT: 5px"></TD>
															<TD class="style4">
																<asp:label id="lblState1" RUNAT="server" CSSCLASS="headfield1" 
                                                                    Font-Names="Tahoma" Font-Size="9pt">Renewals Only? </asp:label></TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px">
																<asp:CheckBox ID="chkRenewals" runat="server" Text="Yes" />
                                                            </TD>
															<TD style="WIDTH: 168px; HEIGHT: 5px"></TD>
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
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px"></TD>
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

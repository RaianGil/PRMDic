<%@ Page language="c#" AutoEventWireup="true" Inherits="EPolicy.PolicyReport" CodeFile="PolicyReport.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/MS_Control/MultipleSelection.ascx" TagName="MultipleSelection" TagPrefix="uc1" %>
<!--DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>ePMS | electronic Policy Manager Solution</title>
		
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
				
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
		<style type="text/css">
            .style3
            {
                width: 112px;
                height: 66px;
            }
            .style5
            {
                text-align: right;
                height: 20px;
                width: 668px;
            }
            .style6
            {
                width: 668px;
                height: 17px;
            }
            .style7
            {
                height: 17px;
                width: 321px;
            }
            .headForm2 { font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-weight: normal; color: #ffffff; text-decoration: none }
.headForm3 { font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-weight: normal; color: #004f7f; text-decoration: none }
.numbers { font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-weight: bold; color: #ffffff; text-decoration: none }
            .style12
            {
                text-align: left;
                height: 20px;
                width: 321px;
            }
            .headfield1
            {                text-align: right;
            }
            .style13
            {
                text-align: right;
            }
            .style14
            {
                width: 668px;
                height: 20px;
            }
            .style15
            {
                height: 20px;
                width: 321px;
            }
            .style16
            {
                width: 668px;
                height: 22px;
                text-align: right;
            }
            .style17
            {
                height: 22px;
                text-align: left;
                width: 321px;
            }
            .style18
            {
                width: 35px;
                text-align: right;
            }
            .style19
            {
                width: 254px;
            }
            .style20
            {
                width: 35px;
            }
            .btn-w-70 {
                width: 70px;
                height: 25px;
                font-size: 9pt;
            }
            .btn-w-95 {
                width: 95px;
                height: 25px;
                font-size: 9pt;
            }
            .btn-r-4 
            {
                border-radius: 4px;
                border: none;
            }
            .btn-bg-theme1 {
                background: #ba354e;
                color: #fff;
            }
            .txt-pv-5 {
                padding: 5px 2px;
            }
            .txt-r-4 {
                box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
                border-radius: 4px;
                background-color: #fff;
                border: 1px solid #ccc;
            }
        </style>
	</HEAD>
	<script type="text/javascript">
	    $(function () {
	        $('#<%= txtSearchDate.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });

	    });

	    function ShowDateTimePicker() {
	        $('#<%= txtSearchDate.ClientID %>').datepicker('show');
	    }

</script>
	<body bottomMargin="0" leftMargin="0"
		topMargin="19" rightMargin="0">
		<form id="Form1" method="post" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="True">
        </ajaxToolkit:ToolkitScriptManager>
			<TABLE id="Table8" style="Z-INDEX: 122; LEFT: 4px; WIDTH: 100%; POSITION: static; TOP: 4px; HEIGHT: 340px"
				cellSpacing="0" cellPadding="0" width="914" align="center" bgColor="white" dataPageSize="25"
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
							<TABLE id="Table9" style="WIDTH: 811px; HEIGHT: 336px" cellSpacing="0" cellPadding="0"
								width="811" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 1px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left" class="style19"> 
													<asp:Label id="Label8" runat="server" Height="16px" Width="198px" CssClass="headForm1 " ForeColor="Black"
														Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True">Email Policy Notifications</asp:Label></TD>
												<TD class="style18">
													 </TD>
												<TD align="right">
													<asp:button id="btnCheck" tabIndex="44" runat="server" onclick="btnCheck_Click" 
                                                        class="btn-bg-theme1 btn-r-4 btn-w-95" Text="Check Pending" style="margin-right: 1px"></asp:button>
													<asp:button id="Button2" tabIndex="44" runat="server" onclick="Button2_Click"
                                                        class="btn-bg-theme1 btn-r-4 btn-w-70" Text="Search" style="margin-right: 1px"></asp:button>
													<asp:button id="BtnExit" tabIndex="45" runat="server" onclick="BtnExit_Click" 
                                                        class="btn-bg-theme1 btn-r-4 btn-w-70" Text="Exit"></asp:button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px; text-align: left;">
										<TABLE id="Table11" style="WIDTH: 808px" height="6px">
											<TR>
												<TD style=" height="5px" background="Images2/GreyLine.png"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center" class="style3">
										<TABLE id="Table1" style="WIDTH: 806px; HEIGHT: 66px" cellSpacing="0" 
                                            cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													<asp:radiobuttonlist id="rblPolicyNotifications" 
                                                        style="Design_Time_Lock: False; text-align: justify;" tabIndex="1" runat="server"
														RepeatLayout="Flow" AutoPostBack="True" Design_Time_Lock="False" Width="175px" Height="89px" Font-Names="Tahoma"
														Font-Size="9pt" onselectedindexchanged="rblPolicyReports_SelectedIndexChanged">
														<asp:ListItem Selected="True" Value="0">Payment Reminder</asp:ListItem>
														<asp:ListItem Value="1">Renewal Notice (30 Days)</asp:ListItem>
														<asp:ListItem Value="2">Renewal Notice (15 Days)</asp:ListItem>
														<asp:ListItem Value="3">Cancellation Notice</asp:ListItem>
													</asp:radiobuttonlist>
													<TABLE id="Table5" style="WIDTH: 481px; HEIGHT: 180px; margin-left: 0px;" 
                                                        cellSpacing="0" cellPadding="0"
														border="0">
														<TR>
															<TD class="style6"></TD>
															<TD class="style7">
																</TD>
														</TR>
														<TR>
															<TD class="style16" align="right">
																<asp:label id="LblDate" RUNAT="server" HEIGHT="16px" CSSCLASS="headfield1" WIDTH="101px"
																	Font-Names="Tahoma" Font-Size="9pt">Search as of:</asp:label></TD>
															<TD>
																<maskedinput:maskedtextbox id="txtSearchDate" tabIndex="1" RUNAT="server" 
                                                                    ISDATE="True" class="headfield1 txt-r-4 txt-pv-5"
																	WIDTH="205px" Font-Names="Tahoma" Font-Size="9pt" style="text-align: left"></maskedinput:maskedtextbox>   </TD>
														</TR>
														<TR>
															<TD class="style14">
																</TD>
															<TD class="style15">
																  </TD>
														</TR>
														<TR>
															<TD class="style5">
																<asp:label id="LblPolicyNo" RUNAT="server" HEIGHT="16px" 
                                                                    CSSCLASS="headfield1" WIDTH="100px"
																	Font-Names="Tahoma" Font-Size="9pt">Policy No.:</asp:label></TD>
															<TD class="style12">
																<asp:textbox id="TxtPolicyNo" tabIndex="2" Font-Names="Tahoma" Width="205px" RUNAT="server"
																	class="headfield1 txt-r-4 txt-pv-5" MAXLENGTH="11" Font-Size="9pt" style="text-align: left"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="style5">
																<asp:label id="lblPolicyType" RUNAT="server" HEIGHT="16px" 
                                                                    CSSCLASS="headfield1" WIDTH="100px"
																	Font-Names="Tahoma" Font-Size="9pt">Policy Type:</asp:label></TD>

															<TD class="style12">
																<asp:textbox id="TxtPolicyType" tabIndex="2" Font-Names="Tahoma" Width="205px" RUNAT="server"
																	class="headfield1 txt-r-4 txt-pv-5" MAXLENGTH="3" Font-Size="9pt" style="text-align: left"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="style5">
																 </TD>
															<TD class="style12">
													             </TD>
														</TR>
														<TR>
															<TD class="style5">
																<asp:label id="LblAgency" RUNAT="server" HEIGHT="16px" 
                                                                    CSSCLASS="headfield1" WIDTH="100px"
																	Font-Names="Tahoma" Font-Size="9pt">Agency:</asp:label></TD>
															<TD class="style12">
													            <uc1:MultipleSelection ID="MultipleSelection1" runat="server"/>
                                                            </TD>
														</TR>
														<TR>
															<TD class="style5">
																 </TD>
															<TD class="style12">
													             </TD>
														</TR>
														<TR>
															<TD class="style5">
																 </TD>
															<TD class="style12">
										<P class="style13" style="width: 301px; height: 20px;">
													<asp:button id="btnSendEmail" tabIndex="44" runat="server" Height="23px" 
                                                        Width="74px" Text="Send Emails"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px; margin-right: 1px;" onclick="btnSendEmail_Click"></asp:button>
													<asp:button id="btnPrint" tabIndex="44" runat="server" Height="23px" 
                                                        Width="74px" Text="Print"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px" onclick="btnPrint_Click"></asp:button>
													        </P>
													        </TD>
														</TR>
														</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 3px" align="left" colSpan="1">                    
										<asp:label id="LblEmailList" Height="16px" RUNAT="server" CSSCLASS="headform3" WIDTH="141px"
											Font-Names="Tahoma" Font-Size="9pt">Search Result:</asp:label></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; " class="style20">
										<TABLE id="Table2" style="WIDTH: 810px; height: 6px;">
											<TR>
												<TD style="height: 5px" background="Images2/GreyLine.png"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 27px" align="right">
																<asp:Label id="LblError" runat="server" 
                                            Font-Size="11pt" Width="791px" ForeColor="Red" Font-Names="Tahoma"
																	Visible="False" style="text-align: left">Label</asp:Label>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 12px" align="center">
										<P class="style13" style="width: 794px; height: 20px;">
														<asp:button id="btnSelectAll" tabIndex="44" runat="server" Height="23px" 
                                                            Width="74px" Text="Select All"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px; margin-right: 1px;" onclick="btnSelectAll_Click"></asp:button>
													<asp:button id="btnDeselect" tabIndex="44" runat="server" Height="23px" Width="74px" Text="Deselect All"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px" onclick="btnDeselect_Click"></asp:button>
													        </P>
																	<asp:datagrid id="DtEmailResults" tabIndex="9" Height="193px" 
                                                        RUNAT="server" WIDTH="795px" PageSize="8"
																		ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
																		ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0"
																		FONT-NAMES="Tahoma" FONT-SIZE="9pt" AUTOGENERATECOLUMNS="False" BACKCOLOR="White"
																		HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA"
																		BORDERWIDTH="1px" BORDERSTYLE="Solid" Font-Italic="False" style="text-align: center; font-size: 8pt;" 
                                                                        OnItemCommand="DtEmailResults_ItemCommand">
																		<FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
																		<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
																		<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
																		<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" 
                                                                            BackColor="White" Wrap="False"></AlternatingItemStyle>
																		<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
																		<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																			BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																		<Columns>
																			<asp:ButtonColumn ButtonType="PushButton" CommandName="Select" 
                                                                                HeaderText="Sel."></asp:ButtonColumn>
																			<asp:BoundColumn DataField="TaskControlID" HeaderText="TaskControlID" 
                                                                                Visible="False">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    HorizontalAlign="Left" Wrap="False" />
																			</asp:BoundColumn>
																			
																			<asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" Font-Bold="False" 
                                                                                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                                                                    Font-Underline="False" Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" Font-Bold="False" Font-Italic="False" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    HorizontalAlign="Center" Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="CustomerName" HeaderText="Customer Name">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" Font-Bold="False" Font-Italic="False" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    HorizontalAlign="Left" Wrap="False" Font-Size="7pt"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Email" HeaderText="Email">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" Font-Bold="False" 
                                                                                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                                                                    Font-Underline="False" Wrap="False" Font-Size="7pt"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    Wrap="False" Font-Size="8pt"></ItemStyle>
																			</asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="ExpirationDate" HeaderText="Expiration Date">
                                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                                                    Wrap="False" Font-Size="8pt" />
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="PaidAmount" HeaderText="Paid Amount">
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" 
                                                                                    Font-Size="8pt" />
                                                                            </asp:BoundColumn>
																		    <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Premium">
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" 
                                                                                    Font-Size="8pt" />
                                                                            </asp:BoundColumn>
                                                                            
																		    <asp:BoundColumn DataField="DateDifference" HeaderText="Date Difference">
                                                                            </asp:BoundColumn>
																		    <asp:TemplateColumn HeaderText="Check to Apply">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkSelect" runat="server"/>
                                                                                    
                                                                                </ItemTemplate>
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" />
                                                                            </asp:TemplateColumn>
																		    <asp:ButtonColumn ButtonType="PushButton" CommandName="Preview" 
                                                                                HeaderText="Preview"></asp:ButtonColumn>
																		</Columns>
																		<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																			CssClass="Numbers" Mode="NumericPages"></PagerStyle>
																	</asp:datagrid>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 36px">
																	<asp:datagrid id="DtCheckEmailResults" 
                                            tabIndex="9" Height="193px" 
                                                        RUNAT="server" WIDTH="795px" PageSize="8"
																		ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
																		ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0"
																		FONT-NAMES="Tahoma" FONT-SIZE="9pt" AUTOGENERATECOLUMNS="False" BACKCOLOR="White"
																		HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA"
																		BORDERWIDTH="1px" BORDERSTYLE="Solid" Font-Italic="False" style="text-align: center; font-size: 8pt;" 
                                                                        OnItemCommand="DtEmailResults_ItemCommand" 
                                            Visible="False">
																		<FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
																		<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
																		<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
																		<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" 
                                                                            BackColor="White" Wrap="False"></AlternatingItemStyle>
																		<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
																		<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																			BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																		<Columns>
																			<asp:ButtonColumn ButtonType="PushButton" CommandName="Select" 
                                                                                HeaderText="Sel."></asp:ButtonColumn>
																			<asp:BoundColumn DataField="TaskControlID" HeaderText="TaskControlID" 
                                                                                Visible="False">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    HorizontalAlign="Left" Wrap="False" />
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center" Font-Bold="False" 
                                                                                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                                                                    Font-Underline="False" Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" Font-Bold="False" Font-Italic="False" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    HorizontalAlign="Center" Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="CustomerName" HeaderText="Customer Name">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" Font-Bold="False" Font-Italic="False" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    HorizontalAlign="Left" Wrap="False" Font-Size="8pt"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="Email" HeaderText="Email">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" Font-Bold="False" 
                                                                                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                                                                    Font-Underline="False" Wrap="False" Font-Size="8pt"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date">
																				<HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
																				<ItemStyle HorizontalAlign="Center" Font-Bold="False" Font-Italic="False" 
                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                    Wrap="False" Font-Size="8pt"></ItemStyle>
																			</asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="ExpirationDate" HeaderText="Expiration Date">
                                                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" 
                                                                                    Wrap="False" Font-Size="8pt" />
                                                                            </asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="PaidAmount" HeaderText="Paid Amount">
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" 
                                                                                    Font-Size="8pt" />
                                                                            </asp:BoundColumn>
																		    <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Premium">
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" 
                                                                                    Font-Size="8pt" />
                                                                            </asp:BoundColumn>
																		    <asp:BoundColumn DataField="DateDifference" HeaderText="Date Difference">
                                                                            </asp:BoundColumn>
																		</Columns>
																		<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																			CssClass="Numbers" Mode="NumericPages"></PagerStyle>
																	</asp:datagrid>
										<P class="style13" style="width: 794px; height: 20px;">
													<asp:button id="btnSelectAll2" tabIndex="44" runat="server" Height="23px" 
                                                        Width="74px" Text="Select All"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px; margin-right: 1px;" onclick="btnSelectAll_Click"></asp:button>
													<asp:button id="btnDeselect2" tabIndex="44" runat="server" Height="23px" 
                                                        Width="74px" Text="Deselect All"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px" onclick="btnDeselect_Click"></asp:button>
													        </P>
										<P align="center"> </P>
										<P align="center"> </P>
										<P align="center"> </P>
										<P align="center"> </P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			   
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
		</form>
	</body>
</HTML>

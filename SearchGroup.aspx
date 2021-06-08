<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchGroup.aspx.cs" Inherits="SearchGroup" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/MS_Control/MultipleSelection.ascx" TagName="MultipleSelection" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
                 <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			    <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
                <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
                <meta name="CODE_LANGUAGE" content="C#">
                <meta name="vs_defaultClientScript" content="JavaScript">
                <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">


				 <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script src="js/load.js" type="text/javascript"></script>
				
				
              
                <style type="text/css">
                    .modalBackground {
                        background-color: Gray;
                        filter: alpha(opacity=50);
                        opacity: 0.5;
                    }
                </style>
            </head>

</head>
 <script type="text/javascript">
     $(function() {
         $('#<%= txtBegDate.ClientID %>').datepicker({
             changeMonth: true,
             changeYear: true
         });
         $('#<%= TxtEndDate.ClientID %>').datepicker({
             changeMonth: true,
             changeYear: true
         });
     });

     function ShowDateTimePicker() {
         $('#<%= txtBegDate.ClientID %>').datepicker('show');
     }
     function ShowDateTimePicker2() {
         $('#<%= TxtEndDate.ClientID %>').datepicker('show');
     }  
</script>
<body>
<div class="middleMain" style="width:100%;">
		<form id="Form1" method="post" runat="server">
		 <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="900">
                        </Toolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
							 <p>
                                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                                </p>
								
								
								 <div class="container-xl mb-4 p-18">
                                    <div class="col-md-12 f-center">
									<img alt="" src="Images2/search.png" class="searchImage" style="margin-bottom: 25px;" />
									</div>
                                    <div class="col-md-12 f-center">
                                        <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Bold="True" ForeColor="#3B3B3B" CssClass="headForm1 " Height="9px" Width="45px" Font-Size="18pt">Search</asp:Label>
                                    </div>
									 <div class="col-md-12 f-center">
									  <asp:Button id="btnSearch" runat="server" onclick="btnSearch_Click" Text="Search" class="btn-h-30 btn-bg-theme2 btn-r-4" style="margin-right: 1px"/>
									  <asp:Button id="btnClear" runat="server" onclick="btnClear_Click" Text="Refresh" class="btn-h-30 btn-bg-theme2 btn-r-4" style="margin-right: 1px"/> 
									  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="10">
                                            <ProgressTemplate>
                                                <img alt="" src="Images2/loader.gif" style="width: 35px; height: 35px;" />
                                                <span><span class=""></span><span style="font-family: Tahoma; font-size: 14pt; color: #BA354E">
                                <strong>Please wait...</strong></span></span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                     </div>
									 <div class="col-md-12 f-center">
                                        <hr />
                                    </div>
									
									 <div class="col-md-12 f-center">
									   <asp:radiobuttonlist id="rblFilter" tabIndex="1" runat="server" class="form-select"
													 Font-Size="10pt" Font-Names="Tahoma" CssClass="HeadField1" Design_Time_Lock="False" 
                                                     AutoPostBack="True" onselectedindexchanged="rblFilter_SelectedIndexChanged" 
                                                     RepeatDirection="Horizontal">
												    <asp:ListItem Value="0" Selected="True">Groups</asp:ListItem>
													<asp:ListItem Value="1">Corporations</asp:ListItem>
											    </asp:radiobuttonlist>
												
										<asp:label id="LblLineOfBusiness" Font-Names="Tahoma"  HEIGHT="14px" WIDTH="61px" runat="server" Font-Size="9pt">Group:</asp:label>

										 <uc1:MultipleSelection ID="MultipleSelection1" runat="server"/>
														    <asp:dropdownlist id="ddlGroup" tabIndex="6" Font-Names="Tahoma" class="form-select"
															    runat="server" onselectedindexchanged="ddlTaskControlType_SelectedIndexChanged"  style="border-radius:5px;width:300px;"
                                                                Visible="False"></asp:dropdownlist><asp:dropdownlist id="ddlCorporation" 
                                                                tabIndex="6" Font-Names="Tahoma" RUNAT="server" Font-Size="10pt" HEIGHT="34px" onselectedindexchanged="ddlTaskControlType_SelectedIndexChanged" 
                                                                Visible="False">
                                                        </asp:DropDownList>	

											<asp:label id="LblBegDate" Font-Names="Tahoma" HEIGHT="14px" WIDTH="61px" RUNAT="server" Font-Size="9pt">Beg. Date:</asp:label>	
											<asp:TextBox ID="txtBegDate" TabIndex="1" onclick="ShowDateTimePicker();" Font-Names="Tahoma"  runat="server" CssClass="form-control w-25"></asp:TextBox>	

											<asp:label id="LblLineOfBusiness0" Font-Names="Tahoma" HEIGHT="14px" WIDTH="61px" RUNAT="server" Font-Size="9pt">End Date:</asp:label>
											 <asp:TextBox ID="TxtEndDate" TabIndex="3" onclick="ShowDateTimePicker2();" Font-Names="Tahoma"  runat="server" CssClass="form-control w-25"></asp:TextBox>
											 
											 <asp:Button id="btnPrint" runat="server" Font-Names="Tahoma" ForeColor="White" Height="23px"
														Width="75px" Text="Print" BackColor="#400000" BorderWidth="0px" onclick="btnPrint_Click" BorderColor="#400000" 
                                                        style="margin-right: 1px" Visible="False"></asp:Button>
									</div>
									
									 <div class="col-md-12">
                                        <asp:label id="LblTotalCases" Font-Names="Tahoma" CSSCLASS="headForm1 " WIDTH="148px" RUNAT="server" ForeColor="Black"  Font-Size="10pt">Total Cases:</asp:label>
											<asp:Label ID="LblError" runat="server" Font-Names="Tahoma" Visible="False" ForeColor="Red" Width="694px" Font-Size="10pt">Label</asp:Label>
                                        <hr />
                                    </div>
									
									
			<div class="col-md-12"> 
			<TABLE id="Table1" style="width: 100%; height: 0px" cellspacing="0" cellpadding="0" bgcolor="white" border="0">				
				<TR>
					<TD align="center">
							<TABLE class="tableMain">	
							<TR>
									<TD style="WIDTH: 100%;">
										<asp:datagrid id="searchIndividual" WIDTH="100%" RUNAT="server" Height="118px" Font-Size="10pt"
											PageSize="12" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" OnItemCommand="searchIndividual_ItemCommand" 
                                            OnItemDataBound="searchIndividual_ItemDataBound">
												<Columns>
												<asp:ButtonColumn ButtonType="PushButton" HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." CommandName="Select">
                               					    <HeaderStyle Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"/>
												</asp:ButtonColumn>
												<asp:BoundColumn DataField="TaskControlID" HeaderText="Control No." 
                                                    Visible="False">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TaskControlTypeDesc" HeaderText="Control Type" 
                                                    DataFormatString="{0:d}" Visible="False">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PolicyNumber" HeaderText="Policy No.">
                                                </asp:BoundColumn>
												<asp:BoundColumn DataField="TaskStatusDesc" HeaderText="Status">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Aging" HeaderText="Aging">
													<ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Agent" HeaderText="Agent">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="InsuranceCompany" HeaderText="Ins. Co.">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Bank" HeaderText="Bank">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="EntryDate" HeaderText="Entry Dt." DataFormatString="{0:d}">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CloseDate" HeaderText="Close Dt." DataFormatString="{0:d}">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CustomerNo" HeaderText="Customer No.">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Name" HeaderText="Name">
													<ItemStyle Font-Names="tahoma"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" height="34px"/>
                                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
										</asp:datagrid></TD>
								</TR>
							</TABLE>

						<P align="center"> </P>
						<P align="center"> </P>
						<P align="center"> </P>
						<P align="center"> </P>
					</TD>
				</TR>
			</TABLE>
			</div>
			<asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
			  </ContentTemplate>
                        </asp:UpdatePanel>
		</form>
		</div>
	</body>
</html>

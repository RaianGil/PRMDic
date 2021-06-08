<%@ Page language="c#" Inherits="EPolicy.ViewPayment" CodeFile="ViewPayment.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Epolicy.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form method="post" runat="server">
            <p>
                <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
            </p>

            <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                <div class="row">
                    <div class="col-md-8" style="align-self: center;">
			           <asp:Label id="Label6" runat="server" CssClass="fs-14 fw-bold">View Payments:</asp:Label>

			           <asp:label id="LblCustomerName" CssClass="fs-11" RUNAT="server">Policy No:</asp:label>
                    </div>
                    <div class="col-md-4" style="text-align:right;">
                       <asp:button id="btnHistory" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="History" onclick="btnHistory_Click"></asp:button>
			           <asp:button id="btnApply" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Apply Payment" onclick="btnApply_Click"></asp:button>
                       <asp:Button ID="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" OnClick="BtnExit_Click" Text="Exit"/> 
                    </div>
                   <div class="col-md-12">
                   <hr />
                    <div class="row">
                    <div class="col-md-4">
                      <div class="mb-3 row">
			              <asp:Label id="Label1" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Total Premium</asp:Label>
                          <div class="col-md-9">
			                <asp:TextBox id="TxtTotalPremium" CSSCLASS="form-control fs-txt-s" runat="server"></asp:TextBox>
                          </div>
                      </div>
                    </div>
                    <div class="col-md-4">
                      <div class="mb-3 row">
                          <asp:Label id="Label2" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Total Paid</asp:Label>
                          <div class="col-md-9">
			                <asp:TextBox id="TxtTotalPaid" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                          </div>
                      </div>
                    </div>
                    <div class="col-md-4">
                      <div class="mb-3 row">
                          <asp:Label id="Label3" runat="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Balance</asp:Label>
                          <div class="col-md-9">
                            <asp:TextBox id="TxtBalance" runat="server" CSSCLASS="form-control fs-txt-s"></asp:TextBox>
                          </div>
                      </div>
                    </div>
                    </div>



                   <asp:label id="LblTotalCases" CssClass="fs-11" RUNAT="server">Total Cases:</asp:label>
                   <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label id="LblError" CSSCLASS="col-md-3 col-form-labe fs-lbl-s label-vertical-align" ForeColor="Red" runat="server" Visible="False">Label</asp:Label>

                            <asp:datagrid id="searchIndividual" Height="260px" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3"
                            	HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6"
                            	ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Arial" FONT-SIZE="9pt" 
                                AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center"
                            	ITEMSTYLE-HORIZONTALALIGN="center" Width="90%" HeaderStyle-ForeColor="white" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#BB1509" 
                                OnItemCommand="searchIndividual_ItemCommand1" 
                                onselectedindexchanged="searchIndividual_SelectedIndexChanged" 
                                PageSize="100">
                            	<FooterStyle BackColor="Navy"></FooterStyle>
                            	<AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                            	<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                            	<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
                            		BackColor="#BB1509" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                            	<Columns>
                            		<asp:ButtonColumn Visible="False" HeaderImageUrl="Images/checkmark_image.gif" ButtonType="PushButton"
                            			CommandName="Select">
                            			<ItemStyle Font-Names="tahoma"></ItemStyle>
                            		</asp:ButtonColumn>
                            		<asp:BoundColumn Visible="False" DataField="PartialPaymentID" HeaderText="PartialPaymentID">
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            		</asp:BoundColumn>
                            		<asp:BoundColumn DataField="CheckNumber" HeaderText="Check No.">
                            			<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            		</asp:BoundColumn>
                            		<asp:BoundColumn Visible="False" DataField="PaymentReference" HeaderText="Payment Reference">
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            		</asp:BoundColumn>
                            		<asp:BoundColumn DataField="TransactionDate" HeaderText="Entry Date">
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            		</asp:BoundColumn>
                            		<asp:BoundColumn DataField="PaymentDate" HeaderText="Payment Date">
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            		</asp:BoundColumn>
                            		<asp:BoundColumn DataField="CreditDebitDesc" HeaderText="Credit/Debit">
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            		</asp:BoundColumn>
                                    <asp:BoundColumn DataField="DepositDate" HeaderText="Deposit Date">
                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Name" HeaderText="Name">
                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                            		<asp:BoundColumn DataField="PremiumCancAMT" HeaderText="Transaction Amount" DataFormatString="{0:c}">
                            			<ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                            		</asp:BoundColumn>
                            		<asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Sel.">
                                    </asp:ButtonColumn>
                            		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
                            	</Columns>
                            	<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" BackColor="White" PageButtonCount="20"
                            		CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                            </asp:datagrid>
		                    </div>
                            <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			                <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                        </div>
                    </div>
                </div>
            </div>
		</form>
	</body>
</HTML>

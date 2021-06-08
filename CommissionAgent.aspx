<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.CommissionAgent" buffer="True" CodeFile="CommissionAgent.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<META content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="baldrich.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
		<FORM id="commAgt" method="post" runat="server" style="vertical-align: top">

            <p>
            	<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
            </p>

              <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                <div class="row">
                   <div class="col-md-6" style="align-self: center;">
                      <div class="row">
                        <div class="col-md-12">
                            <asp:Label id="Label3" runat="server" CssClass="fs-14 fw-bold" >Agent ID:</asp:Label>
                            <asp:label id="lblAgentID" runat="server" CssClass="fs-14 fw-bold" ></asp:label>
                        </div>
                        <div class="col-md-12">
                            <asp:Label ID="Label4" runat="server" Text="Contactar departamento de sistemas si va a añadir un PolicyType nuevo." 
                                ForeColor="Red" CssClass="fs-11 fw-bold"></asp:Label>
                        </div>
                      </div>
                   </div>
                   <div class="col-md-6" style="text-align:right; align-self:center">
                        <asp:Button id="btnAuditTrail" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
                        <asp:Button id="btnPrint" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Print" onclick="btnPrint_Click"></asp:Button>
                        <asp:Button id="BtnSave" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                        <asp:Button id="btnAddNew" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
                        <asp:Button id="btnEdit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                        <asp:Button id="cmdCancel" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                        <asp:Button id="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button> 
                   </div>
                   <div class="col-md-12">
                   <hr />
                        <div class="row">
                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:label id="lblPolicyID" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s">Line Of Business</asp:label>
                                    <div class="col-md-9">
                                        <asp:dropdownlist id="ddlPolicyID" CSSCLASS="form-select fs-txt-s" RUNAT="server">
                                        	<asp:ListItem></asp:ListItem>
                                        	<asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        	<asp:ListItem Value="C">Close Date</asp:ListItem>
                                        </asp:dropdownlist>
                                    </div>
                                </div>
                           </div>
                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:Label ID="Label1" runat="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align" EnableViewState="False" >Eff. Date</asp:Label>
                                    <div class="col-md-9" style="height:29.2px;">
                                        <div class="input-group mb-3 input-append date datepicker-p1" data-date-format="mm-dd-yyyy">
                                          <maskedinput:maskedtextbox id="txtEffectiveDate" RUNAT="server" ISDATE="True" CssClass="form-control fs-txt-s"></maskedinput:maskedtextbox>
                                          <span class="add-on input-group-text" style="height:29px;"><i class="bi bi-grid-3x3-gap-fill"></i></span>
                                        </div>
                                    </div>
                                </div>
                           </div>

                           <div class="col-md-6">
                                <div class="mb-3 row">
            	                    <asp:label id="PolicyType" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Policy Type:</asp:label>
                                    <div class="col-md-9">
                                        <asp:textbox id="txtPolicyType" RUNAT="server" MAXLENGTH="10" Width="30%" CssClass="form-control fs-txt-s"></asp:textbox>
                                    </div>
                                </div>
                           </div>
                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:label id="lblEntryDate" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Entry Date</asp:label>
                                    <div class="col-md-9">
                                        <maskedinput:maskedtextbox id="txtEntryDate" RUNAT="server" ISDATE="True" Enabled="False" CssClass="form-control fs-txt-s"></maskedinput:maskedtextbox>
                                    </div>
                                </div>
                           </div>

                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:label id="lblInsurance" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Insurance Co.:</asp:label>
                                    <div class="col-md-9">
                                        <asp:dropdownlist id="ddlInsuranceCompany" RUNAT="server" CssClass="form-select fs-txt-s">
                                        	<asp:ListItem></asp:ListItem>
                                        	<asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        	<asp:ListItem Value="C">Close Date</asp:ListItem>
                                        </asp:dropdownlist>
                                    </div>
                                </div>
                           </div>
                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:label id="lblAgentLevel" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Agent Level</asp:label>
                                    <div class="col-md-9">
                                        <asp:textbox id="txtAgentLevel" RUNAT="server" MAXLENGTH="3" Width="30%" CssClass="form-control fs-txt-s"></asp:textbox>
                                    </div>
                                </div>
                           </div>
                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:label id="Label2" RUNAT="server" CSSCLASS="col-md-3 col-form-labe fs-lbl-s">Selected  Type:</asp:label>
                                    <div class="col-md-9">
                                        <asp:radiobutton id="RdbRate" Text="%" runat="server" CSSCLASS="fs-txt-s fs-txt-s" AutoPostBack="True" GroupName="SelectedType" Checked="True" oncheckedchanged="RdbRate_CheckedChanged"></asp:radiobutton> 
                                        <asp:radiobutton id="RdbCommissionAmount" runat="server" CSSCLASS="fs-txt-s fs-txt-s" Text="Amt" AutoPostBack="True" GroupName="SelectedType" oncheckedchanged="RdbCommissionAmount_CheckedChanged"></asp:radiobutton>
                                    </div>
                                </div>
                           </div>
                           <div class="col-md-6">
                                <div class="mb-3 row">
                                    <asp:label id="lblCommissionAmount" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Comm. Amount:</asp:label>
                                    <asp:label id="lblCommissionRate" RUNAT="server" CssClass="col-md-3 col-form-labe fs-lbl-s label-vertical-align">Rate:</asp:label>
                                    <div class="col-md-9">
                                        <asp:textbox id="txtCommissionAmount" RUNAT="server" MAXLENGTH="5" CssClass="form-control fs-txt-s" Width="40%"></asp:textbox>
                                        <asp:textbox id="txtRate" RUNAT="server" MAXLENGTH="3" CssClass="form-control fs-txt-s" Width="40%"></asp:textbox>
                                    </div>
                                </div>
                           </div>

                           <div class="col-md-12">
                                <asp:datagrid id="searchCommission" Height="151px" WIDTH="805px" RUNAT="server" BORDERSTYLE="Solid"
                                	BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center"
                                	BACKCOLOR="White" AUTOGENERATECOLUMNS="False" ALLOWPAGING="True" FONT-SIZE="9pt" FONT-NAMES="Tahoma"
                                	CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6"
                                	HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE" ITEMSTYLE-CSSCLASS="HeadForm3"
                                	PageSize="6" onselectedindexchanged="searchCommission_SelectedIndexChanged" 
                                    onitemcommand="searchCommission_ItemCommand1">
                                	<FooterStyle ForeColor="MidnightBlue" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></FooterStyle>
                                	<AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                                	<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                                	<HeaderStyle HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                	<Columns>
                                		<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select"></asp:ButtonColumn>
                                		<asp:BoundColumn Visible="False" DataField="CommissionAgentID" HeaderText="CommissionAgentID"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="PolicyClassID" HeaderText="Line of Business"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="AgentID" HeaderText="Agent ID"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="InsuranceCompanyID" HeaderText="Insurance Co."></asp:BoundColumn>
                                		<asp:BoundColumn Visible="False" DataField="BankID" HeaderText="Bank"></asp:BoundColumn>
                                		<asp:BoundColumn Visible="False" DataField="CompanyDealerID" HeaderText="Dealer"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="CommissionRate" HeaderText="Comm. Rate"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="CommissionAmount" HeaderText="Comm.Amount"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="CommissionEntryDate" HeaderText="Entry Date"></asp:BoundColumn>
                                		<asp:BoundColumn DataField="AgentLevel" HeaderText="Agent Level"></asp:BoundColumn>
                                	    <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" 
                                            HeaderText="Del."></asp:ButtonColumn>
                                	</Columns>
                                	<PagerStyle HorizontalAlign="Left" ForeColor="White" BackColor="#400000" PageButtonCount="20"
                                		CssClass="Numbers" Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></PagerStyle>
                                </asp:datagrid>
                           </div>

                        </div>
                    </div>


			        <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
			        <asp:imagebutton id="BtnExit1" RUNAT="server" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif" Visible="False"></asp:imagebutton>
			        <asp:ImageButton id="btnAuditTrail1" runat="server" Width="48px" ImageUrl="Images/History_btn.bmp" Visible="False"></asp:ImageButton>
			        <asp:imagebutton id="btnPrint1" runat="server" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report" Visible="False"></asp:imagebutton>
			        <asp:imagebutton id="cmdCancel1" runat="server" ImageUrl="Images/cancel_btn.gif" CausesValidation="False" Visible="False"></asp:imagebutton>
			        <asp:imagebutton id="BtnSave1" RUNAT="server" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif" Visible="False"></asp:imagebutton>
			        <asp:imagebutton id="btnEdit1" runat="server" ImageUrl="Images/edit_btn.GIF" CausesValidation="False" Visible="False"></asp:imagebutton>
			        <asp:imagebutton id="btnAddNew1" runat="server" ImageUrl="Images/addNew_btn.gif" CausesValidation="False" Visible="False"></asp:imagebutton>
			        <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>

            </div>
            </div>
        </FORM>
        <script type="text/javascript">
            $('.datepicker-p1').datepicker();
        </script>
	</BODY>
</HTML>

<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.CommissionAgency" buffer="True" CodeFile="CommissionAgency.aspx.cs" %>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
        </HEAD>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $(function() {
                $('#<%= txtEffectiveDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });


            function ShowDateTimePicker() {
                $('#<%= txtEffectiveDate.ClientID %>').datepicker('show');
            }
        </script>

        <body>
            <form id="commAgency" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label2" runat="server">Agency ID:</asp:Label>
                            <asp:label id="lblAgencyID" runat="server"></asp:label>
                        </div>
                        <div class="col-md-6">
                            <asp:button id="btnAuditTrail" runat="server" Text="Audit Trail" onclick="btnAuditTrail_Click"></asp:button>
                            <asp:button id="btnPrint" runat="server" Text="Print" onclick="btnPrint_Click"></asp:button>
                            <asp:button id="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click"></asp:button>
                            <asp:button id="btnAddNew" runat="server" Text="Add" DESIGNTIMEDRAGDROP="30" onclick="btnAddNew_Click"></asp:button>
                            <asp:button id="btnEdit" runat="server" Text="Edit" DESIGNTIMEDRAGDROP="31" onclick="btnEdit_Click"></asp:button>
                            <asp:button id="cmdCancel" runat="server" Text="Cancel" DESIGNTIMEDRAGDROP="33" onclick="cmdCancel_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" Text="Exit" DESIGNTIMEDRAGDROP="36" onclick="BtnExit_Click"></asp:button>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblPolicyID" RUNAT="server">Line of Business:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlPolicyID" RUNAT="server">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblCommissionRate" RUNAT="server">Rate:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtRate" RUNAT="server" MAXLENGTH="3"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="PolicyType" RUNAT="server">Policy Type:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtPolicyType" RUNAT="server" MAXLENGTH="3"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="Label1" RUNAT="server">Effective Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtEffectiveDate" onclick="ShowDateTimePicker()" RUNAT="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblInsurance" RUNAT="server">Insurance Co.:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlInsuranceCompany" RUNAT="server">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblEntryDate" RUNAT="server">Entry Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtEntryDate" RUNAT="server" Enabled="False" ISDATE="True"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblDealerID" RUNAT="server" Visible="False">Dealer ID:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlDealerID" RUNAT="server" Visible="False">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:label id="lblBankID" RUNAT="server" Visible="False">Bank ID:</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:dropdownlist id="ddlBankID" RUNAT="server" Visible="False">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>



















                    <asp:datagrid id="searchCommission" Height="151px" WIDTH="798px" RUNAT="server" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="MidnightBlue" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False"
                        ALLOWPAGING="True" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="Navy" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="Navy" ITEMSTYLE-CSSCLASS="HeadForm3" PageSize="8">
                        <FooterStyle ForeColor="AliceBlue" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></FooterStyle>
                        <AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select"></asp:ButtonColumn>
                            <asp:BoundColumn Visible="False" DataField="CommissionAgencyID" HeaderText="CommissionAgencyID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PolicyClassID" HeaderText="Line fo Business"></asp:BoundColumn>
                            <asp:BoundColumn DataField="AgencyID" HeaderText="Agency ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
                            <asp:BoundColumn DataField="InsuranceCompanyID" HeaderText="Insurance Co."></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="BankID" HeaderText="Bank"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="CompanyDealerID" HeaderText="Dealer"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CommissionRate" HeaderText="Commission Rate"></asp:BoundColumn>
                            <asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CommissionEntryDate" HeaderText="Entry Date"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle HorizontalAlign="Left" ForeColor="White" BackColor="#400000" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></PagerStyle>
                    </asp:datagrid>

                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>

                    <asp:imagebutton id="btnAddNew1" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
                    <asp:imagebutton id="btnEdit1" runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
                    <asp:imagebutton id="BtnSave1" RUNAT="server" IMAGEURL="Images/save_btn.gif" TOOLTIP="Save Person Information" CAUSESVALIDATION="False" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="cmdCancel1" runat="server" CausesValidation="False" ImageUrl="Images/cancel_btn.gif" Visible="False"></asp:imagebutton>
                    <asp:imagebutton id="btnPrint1" runat="server" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report" Visible="False"></asp:imagebutton>
                    <asp:ImageButton id="btnAuditTrail1" runat="server" ImageUrl="Images/History_btn.bmp" Visible="False"></asp:ImageButton>
                    <asp:imagebutton id="BtnExit1" RUNAT="server" IMAGEURL="Images/exit_btn.gif" CAUSESVALIDATION="False" Visible="False"></asp:imagebutton>
                </div>
            </form>
        </body>

        </HTML>
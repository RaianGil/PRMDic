<%@ Page language="c#" Inherits="EPolicy.IncentiveSupplier" CodeFile="IncentiveSupplier.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form id="Supp" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl p-18 mb-4">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label3" class="fs-16" runat="server">Supplier ID:</asp:Label>
                            <asp:label id="lblSupplierID" class="fs-16" runat="server"></asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
                            <asp:Button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print" onclick="btnPrint_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                            <asp:Button id="Button2" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="Button2_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="lblPolicyID" RUNAT="server">Line Of Business</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <asp:dropdownlist id="ddlPolicyID" RUNAT="server" class="form-select">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="PolicyType" RUNAT="server">Policy Type:</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <asp:textbox id="txtPolicyType" RUNAT="server" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="lblInsurance" RUNAT="server">Insurance Co.:</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <asp:dropdownlist id="ddlInsuranceCompany" RUNAT="server" class="form-select">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="Label2" RUNAT="server">Selected Type:</asp:label>

                                </div>
                                <div class="col-md-9">
                                    <asp:radiobutton id="RdbRate" runat="server" AutoPostBack="True" GroupName="SelectedType" Text="%" Checked="True" oncheckedchanged="RdbRate_CheckedChanged"></asp:radiobutton>
                                    <asp:radiobutton id="RdbIncentiveAmount" runat="server" AutoPostBack="True" GroupName="SelectedType" Text="Amt" oncheckedchanged="RdbIncentiveAmount_CheckedChanged"></asp:radiobutton>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="lblIncentiveRate" RUNAT="server">Rate:</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <asp:textbox id="txtRate" RUNAT="server" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="lblIncentiveAmount" RUNAT="server">Incentive Amount:</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <asp:textbox id="txtIncentiveAmount" RUNAT="server" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="Label1" RUNAT="server">Effective Date</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <div class="d-inline-flex">
                                        <maskedinput:maskedtextbox id="txtEffectiveDate" RUNAT="server" ISDATE="True" class="form-control"></maskedinput:maskedtextbox>
                                        <INPUT id="Button1" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Supp.txtEffectiveDate','calendar_window','width=250,height=250');calendar_window.focus()" type="button" value="..." name="btnCalendar" class="input-group-text"
                                            RUNAT="server">
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-3">
                                    <asp:label id="lblEntryDate" RUNAT="server">Entry Date</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <maskedinput:maskedtextbox id="txtEntryDate" RUNAT="server" Enabled="False" ISDATE="True" class="form-control"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:label id="lblAgentLevel" RUNAT="server">Supplier Level</asp:label>
                                </div>
                                <div class="col-md-9">
                                    <asp:textbox id="txtSupplierLevel" RUNAT="server" class="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="col-md-12">
                        <asp:datagrid id="searchIncentive" Height="162px" WIDTH="801px" RUNAT="server" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False"
                            ALLOWPAGING="True" FONT-SIZE="9pt" FONT-NAMES="Tahoma" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE" ITEMSTYLE-CSSCLASS="HeadForm3"
                            PageSize="6">
                            <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
                            <AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                            <Columns>
                                <asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select"></asp:ButtonColumn>
                                <asp:BoundColumn Visible="False" DataField="IncentiveSupplierID" HeaderText="Incentive SupplierID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PolicyClassID" HeaderText="Line of Business"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SupplierID" HeaderText="Supplier ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
                                <asp:BoundColumn DataField="InsuranceCompanyID" HeaderText="Insurance Co."></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="BankID" HeaderText="Bank"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="CompanyDealerID" HeaderText="Dealer"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IncentiveRate" HeaderText="Incentive. Rate"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IncentiveAmount" HeaderText="IncentiveAmount"></asp:BoundColumn>
                                <asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IncentiveEntryDate" HeaderText="Entry Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SupplierLevel" HeaderText="Supplier Level"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Left" ForeColor="Navy" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                        </asp:datagrid>
                    </div>

                    <asp:literal id="litPopUp" VISIBLE="False" RUNAT="server"></asp:literal>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                </div>
            </form>
        </body>

        </HTML>
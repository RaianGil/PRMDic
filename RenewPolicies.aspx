<%@ Page language="c#" Inherits="EPolicy.RenewPolicies" CodeFile="RenewPolicies.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <head>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0" />
            <meta name="CODE_LANGUAGE" Content="C#" />
            <meta name="vs_defaultClientScript" content="JavaScript" />
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
            <link href="epolicy.css" type="text/css" rel="stylesheet" />
        </head>

        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $(function() {
                $('#<%= txtFrom.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $('#<%= txtTo.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

            });

            function ShowDateTimePicker() {
                $('#<%= txtFrom.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker2() {
                $('#<%= txtTo.ClientID %>').datepicker('show');
            }
        </script>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUpload" />
        </Triggers>

        <body>
            <form method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl">
                    <div class="row">
                        <div class="col-md-4 fs-14 fw-bold">
                            <asp:Label id="LblUpload" runat="server">Upload</asp:Label>
                        </div>
                        <div class="col-md-8 f-right">
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <div class="col-md-12 f-center fw-bold mb-1">
                            <asp:Label id="Label1" runat="server">Renew Policies as of:</asp:Label>
                        </div>
                        <div class="col-md-12 f-center mb-2">
                            <div class="row col-md-6">
                                <div class="col-md-1">
                                    <asp:Label id="Label2" runat="server" Visible="True">From:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtFrom" runat="server" Visible="True" class="form-control fs-txt-s fechaFormat" autocompletetype="Disabled" onclick="ShowDateTimePicker();"></asp:TextBox>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label id="Label3" runat="server" Visible="True">To:</asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtTo" runat="server" Visible="True" class="form-control fs-txt-s fechaFormat" autocompletetype="Disabled" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 f-center">
                            <asp:Button id="BtnGetPoliciesToRenew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Get Data" onclick="BtnGetPoliciesToRenew_Click"></asp:Button>
                            <asp:Button id="BtnRenewPolicies" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Renew Policies" Visible="False" onclick="BtnRenewPolicies_Click" onclientclick="return confirm('Are you certain you want to renew the policies?');"></asp:Button>
                        </div>
                        <div class="col-md-12">
                            <asp:Label id="Label4" runat="server" visible="false">Policies To Renew:</asp:Label>
                        </div>
                        <div class="col-md-12">
                            <asp:Button id="BtnExportToRenew" runat="server" Text="Export" Visible="False" onclick="BtnExportToRenew_Click"></asp:Button>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <asp:datagrid id="ToRenew" RUNAT="server" Width="100%" runat="server" Height="118px" CellPadding="0" class="table table-bordered mb-2" AutoGenerateColumns="False" PageSize="16">
                            <Columns>
                                <asp:BoundColumn DataField="TaskcontrolID" HeaderText="Control Number">
                                    <ItemStyle></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PolicyNumber" HeaderText="PolicyNo">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Anniversary" HeaderText="Anniversary">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ExpirationDate" HeaderText="Effective Date">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Customer" HeaderText="Customer">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MedicalLimit" HeaderText="Limit">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ISOCode" HeaderText="IsoCode">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Specialty" HeaderText="Specialty">
                                    <ItemStyle Font-Names="Specialty" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Premium" HeaderText="Premium">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Charge" HeaderText="Charge">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages" />
                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                        </asp:datagrid>

                        <div class="col-md-12 mb-1">
                            <asp:Label id="Label6" runat="server" Visible="False">Preview:</asp:Label>
                        </div>
                        <div class="col-md-12 mb-1">
                            <asp:Button id="BtnExportPreview" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Export" onclick="BtnExportPreview_Click" visible="false"></asp:Button>
                        </div>

                        <asp:datagrid id="PreviewRenew" RUNAT="server" Width="100%" runat="server" Height="118px" CellPadding="0" class="table table-bordered mb-2" AutoGenerateColumns="False" PageSize="16">
                            <Columns>
                                <asp:BoundColumn DataField="TaskcontrolID" HeaderText="Control Number">
                                    <ItemStyle></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PolicyNumber" HeaderText="PolicyNo">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Anniversary" HeaderText="Anniversary">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ExpirationDate" HeaderText="Effective Date">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Customer" HeaderText="Customer">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MedicalLimit" HeaderText="Limit">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IsoCode" HeaderText="IsoCode">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Specialty" HeaderText="Specialty">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Premium" HeaderText="Premium">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Charge" HeaderText="Charge">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages" />
                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                        </asp:datagrid>
                        <div class="col-md-12 mb-1">
                            <asp:label id="LblSelectAgent" RUNAT="server" ENABLEVIEWSTATE="False" Visible="False">Available Agent - Level</asp:label>
                        </div>
                        <div class="col-md-5 mb-1">
                            <asp:dropdownlist id="ddlAvailableAgent" class="form-select fs-txt-s" RUNAT="server" Visible="false"></asp:dropdownlist>
                        </div>
                        <div class="col-md-2 mb-1">
                            <asp:button id="cmdRemove" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="<<" onclick="cmdRemove_Click" Visible="false"></asp:button>
                            <asp:button id="cmdSelect" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text=">>" Visible="false" onclick="cmdSelect_Click"></asp:button>
                        </div>
                        <div class="col-md-5 mb-1">
                            <asp:listbox id="ddlSelectedAgent" runat="server" class="form-control fs-txt-s" Visible="false" onselectedindexchanged="ddlSelectedAgent_SelectedIndexChanged"></asp:listbox>
                        </div>

                        <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                        <asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
                        <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
                    </div>
                </div>
            </form>
        </body>

        </HTML>
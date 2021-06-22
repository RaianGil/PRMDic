<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.ViewIncentive" CodeFile="ViewIncentive.aspx.cs" %>
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
            <form method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </P>
                <div class="mb-4"></div>
                <div class="container-xl mb-4 p-18">
                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:Label id="Label1" class="fs-16" runat="server">View Incentives:</asp:Label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:label id="LblTotalCases" class="fs-16" RUNAT="server">Total Cases:</asp:label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:label id="LblCustomerName" class="fs-16" RUNAT="server">Policy No:</asp:label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:Button id="Button1" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="Button1_Click"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:label id="Label44" class="fs-16" RUNAT="server" ENABLEVIEWSTATE="False">Status:</asp:label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:label id="LblStatus" class="fs-16" RUNAT="server" ENABLEVIEWSTATE="False">Inforce/Paid</asp:label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:label id="Label3" class="fs-16" RUNAT="server">Total Cases:</asp:label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-4">
                                    <asp:label id="LblError" class="fs-16" runat="server" Visible="False">Label</asp:label>
                                </div>
                            </div>
                        </div>
                    </p>


                    <asp:datagrid id="searchIndividual" RUNAT="server" WIDTH="795px" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" Height="192px" PageSize="14" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6"
                        ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Arial" FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center">
                        <FooterStyle ForeColor="White" BackColor="Navy"></FooterStyle>
                        <AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                        <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="PolicyIncentiveID" HeaderText="PolicyIncentiveID">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IncentiveLevel" HeaderText="Level">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SupplierID" HeaderText="Supplier ID">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SupplierDesc" HeaderText="Supplier">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IncentiveDate" HeaderText="Incentive Date">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IncentiveSupplierPercent" HeaderText="Incentive Percent">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IncentiveAmount" HeaderText="Incentive Amount" DataFormatString="{0:c}">
                                <ItemStyle Font-Names="tahoma"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IncentiveSupplier" HeaderText="Incentive Supplier" DataFormatString="{0:c}">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ReturnIncentiveSupplier" HeaderText="Return Incentive." DataFormatString="{0:c}">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                    </asp:datagrid>

                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                </div>
            </form>
        </body>

        </HTML>
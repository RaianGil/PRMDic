<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.SearchPolicies" CodeFile="SearchPolicies.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			<link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
			
            <script src="js/load.js" type="text/javascript"></script>
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form id="Form1" method="post" runat="server">

                <P>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </P>

                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-12 f-center">
                            <img alt="" src="Images2/search.png" class="searchImage" style="margin-bottom: 25px;" />
                        </div>
                    </div>

                    <div class="col-md-12 f-center">
                        <asp:Label id="Label5" runat="server" class="fs-16">Search Policy:</asp:Label>
                    </div>

                    <div class="col-md-12 f-center">
                        <asp:Button id="Imagebutton1" runat="server" Text="Search" onclick="Imagebutton1_Click" class="btn-h-30 btn-bg-theme2 btn-r-4"></asp:Button>
                        <asp:Button id="Imagebutton2" runat="server" Text="Clear" onclick="Imagebutton2_Click" class="btn-h-30 btn-bg-theme2 btn-r-4"></asp:Button>
                    </div>

                    <hr>

                    <p>
                        <div class="row">
                            <div class="col-md-4 f-center">
                                <asp:label id="LblEventControlNo" RUNAT="server">Line Of Business</asp:label>
                                <asp:dropdownlist id="ddlPolicyClass" RUNAT="server" onselectedindexchanged="ddlPolicyClass_SelectedIndexChanged" class="form-select"></asp:dropdownlist>
                            </div>

                            <div class="col-md-4 f-center">
                                <asp:label id="lblCustID" RUNAT="server">Policy Type</asp:label>
                                <asp:textbox id="TxtPolicyType" RUNAT="server" class="form-control"></asp:textbox>
                            </div>

                            <div class="col-md-4 f-center">
                                <asp:label id="LblDataType" RUNAT="server">Policy No.</asp:label>
                                <asp:textbox id="TxtPolicyNo" RUNAT="server" class="form-control"></asp:textbox>
                            </div>
                        </div>
                    </p>


                    <p>

                        <div class="row">
                            <div class="col-md-3 f-center">
                                <asp:label id="lblFirstName" RUNAT="server">Certificate</asp:label>
                                <asp:textbox id="TxtCertificate" RUNAT="server" class="form-control"></asp:textbox>
                            </div>

                            <div class="col-md-3 f-center">
                                <asp:label id="lblLastName2" RUNAT="server">Suffix</asp:label>
                                <asp:textbox id="TxtSuffix" RUNAT="server" class="form-control"></asp:textbox>
                            </div>

                            <div class="col-md-3 f-center">
                                <asp:label id="Label1" RUNAT="server">Bank</asp:label>
                                <asp:textbox id="TxtBank" RUNAT="server" class="form-control"></asp:textbox>
                            </div>

                            <div class="col-md-3 f-center">
                                <asp:label id="Label2" RUNAT="server">Loan No.</asp:label>
                                <asp:textbox id="TxtLoanNo" RUNAT="server" class="form-control"></asp:textbox>
                            </div>

                        </div>
                    </p>




                    <asp:label id="lblVIN" RUNAT="server">VIN</asp:label>

                    <asp:textbox id="txtVIN" RUNAT="server" class="form-control"></asp:textbox>

                    <asp:label id="LblTotalCases" RUNAT="server">Total Cases:</asp:label>

                    <asp:Label id="LblError" runat="server" Visible="False">Label</asp:Label>

                    <hr>

                    <TR>
                        <TD style="HEIGHT: 3px">
                            <P align="center">
                                <asp:datagrid id="DtSearchPayments" Height="193px" RUNAT="server" WIDTH="100%" PageSize="8" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" 
								OnItemCommand="DtSearchPayments_ItemCommand1" class="table table-bordered" CellPadding="4" ForeColor="#333333"
                                    AlternatingRowStyle-BackColor="White" Visible="False" OnItemDataBound="DtSearchPayments_ItemDataBound" Font-Size="10pt">
                                    <Columns>
                                        <asp:ButtonColumn ButtonType="PushButton" HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." CommandName="Select">
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"/>
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No.">
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyClassDesc" HeaderText="Line Of Business" Visible="False">
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Certificate" HeaderText="Certificate" Visible="False">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Sufijo" HeaderText="Suffix">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv."></asp:BoundColumn>
                                        <asp:BoundColumn DataField="EffectiveDate" HeaderText="EffectiveDate">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="TotalPremium" HeaderText="Total Prem.">
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CustomerNo" HeaderText="Customer No.">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CustomerName" HeaderText="Customer Name">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Bank" HeaderText="Bank" Visible="False">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="LoanNo" HeaderText="Loan No." Visible="False">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                    <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                                </asp:datagrid>
                            </P>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="HEIGHT: 3px">
                            <P align="center">
                                <asp:datagrid id="DtSearchAll" tabIndex="9" Height="151px" RUNAT="server" WIDTH="90%" PageSize="8" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3"
                                    CELLPADDING="0" FONT-NAMES="Arial" FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px"
                                    BORDERSTYLE="Solid">
                                    <FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
                                    <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                                    <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                                    <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                                    <HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                    <Columns>
                                        <asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn DataField="TaskControlID" HeaderText="Task No.">
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyClassDesc" HeaderText="Line Of Business">
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Certificate" HeaderText="Certificate">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Sufijo" HeaderText="Suffix">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle Font-Names="Tahoma" HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CustomerNo" HeaderText="Customer No.">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CustomerName" HeaderText="Customer Name">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Bank" HeaderText="Bank">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="LoanNo" HeaderText="Loan No.">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="VIN" HeaderText="V.I.N.">
                                            <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                </asp:datagrid>
                            </P>
                        </TD>
                    </TR>


                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                </div>
            </form>
        </body>

        </HTML>
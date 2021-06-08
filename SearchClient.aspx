<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.SearchClient" CodeFile="SearchClient.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
                        <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			<link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form id="SearchClientIndividual" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>

                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-12 f-center">
                            <img alt="" src="Images2/search.png" class="searchImage" style="margin-bottom: 25px;" />
                        </div>
                    </div>

                    <div class="col-md-12 f-center">
                        <asp:Label id="Label1" runat="server" class="fs-16">Search Customer</asp:Label>
                    </div>

                    <div class="col-md-12 f-center">
                        <asp:Button id="btnSearch" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnSearch_Click" Text="Search" />
                        <asp:Button id="btnClear" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnClear_Click" Text="Clear" />
                    </div>

                    <hr>

                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-3">
                                    <asp:textbox id="TxtCustomerNo" class="form-control" placeholder="Client No" RUNAT="server" />
                                </div>
                            </div>
                        </div>
                    </p>

                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-3">
                                    <asp:textbox id="txtFirstName" class="form-control" placeholder="First Name" RUNAT="server" />
                                </div>
                            </div>
                        </div>
                    </p>

                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-3">
                                    <asp:textbox id="txtLastName1" class="form-control" placeholder="Last Name 1" RUNAT="server" />
                                </div>
                            </div>
                        </div>
                    </p>

                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-3">
                                    <asp:textbox id="txtLastName2" class="form-control" placeholder="Last Name 2" RUNAT="server" />
                                </div>
                            </div>
                        </div>
                    </p>

                    <p>
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-3">
                                    <maskedinput:maskedtextbox id="txtSocialSecurity" class="form-control" placeholder="Social Security" RUNAT="server" ENABLEVIEWSTATE="False" ISDATE="False" MASK="999-99-9999"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                        </div>
                    </p>

                    <div class="row">
                        <div class="col-md-12 f-center">
                            <div class="col-md-3">
                                <maskedinput:maskedtextbox id="TxtPhone" class="form-control" placeholder="Phone" RUNAT="server" ENABLEVIEWSTATE="False" ISDATE="False" MASK="(999) 999-9999"></maskedinput:maskedtextbox>
                            </div>
                        </div>

                        <p>
                            <div class="row">
                                <div class="col-md-12 f-center">
                                    <div class="col-md-3">
                                        <asp:RadioButton id="RdbIndividual" runat="server" Text="Individual" AutoPostBack="True" Checked="True" GroupName="ClientType" oncheckedchanged="RdbIndividual_CheckedChanged"></asp:RadioButton>
                                        <asp:RadioButton id="RdbBusiness" runat="server" Text="Business" AutoPostBack="True" GroupName="ClientType" oncheckedchanged="RdbBusiness_CheckedChanged"></asp:RadioButton>
                                    </div>
                                </div>
                            </div>
                        </p>

                        <div class="row">
                            <div class="col-md-12 f-center">
                                <div class="col-md-6">
                                    <asp:label id="LblTotalCases" runat="server">Total Cases:</asp:label>
                                    <asp:Label id="LblError" runat="server" Visible="False">Label</asp:Label>
                                </div>
                            </div>
                        </div>

                        <TR>
                            <TD style="FONT-SIZE: 0pt; align="center">
                                <P align="center">
                                    <asp:datagrid id="searchIndividual" RUNAT="server" ALLOWPAGING="True" CELLPADDING="0" class="table table-bordered table-condensed table-hover" Width="100%" 
									AutoGenerateColumns="False" PageSize="9" Font-Size="10pt">
                                        <Columns>
                                            <asp:ButtonColumn ButtonType="PushButton" HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." CommandName="Select">
                               					<HeaderStyle Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"/>
                                            </asp:ButtonColumn>
                                            <asp:BoundColumn DataField="CustomerNo" HeaderText="Client No">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Firstna" HeaderText="First Name">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Initial" HeaderText="Initial">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Lastna1" HeaderText="Last Name1">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Lastna2" HeaderText="Last Name2">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Homeph" HeaderText="Home Phone">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Jobph" HeaderText="Work Phone">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Cellular" HeaderText="Cellular">
                                                <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="SocSec" HeaderText="Social Security">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="LatestPolicy" HeaderText="Latest Policy">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                            <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                                    </asp:datagrid>
                                    <asp:datagrid id="searchBusiness" RUNAT="server" class="table table-bordered table-condensed table-hover" WIDTH="100%"
                                        ALLOWPAGING="True" CELLPADDING="0" Visible="False" PageSize="9" Font-Size="10pt">
                                        <Columns>
                                            <asp:ButtonColumn ButtonType="PushButton" HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." CommandName="Select">
                               					<HeaderStyle Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"/>
                                            </asp:ButtonColumn>
                                            <asp:BoundColumn DataField="CustomerNo" HeaderText="Client No">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="emplna" HeaderText="Business Name">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="EmployerSocialSecurity" HeaderText="Employer Social Security">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="FirstName" HeaderText="First Name">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="LastName" HeaderText="Last Name">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Phone" HeaderText="Work Phone">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Cellular" HeaderText="Cellular">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                            <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
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
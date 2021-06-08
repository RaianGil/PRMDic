<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.SearchProspect" CodeFile="SearchProspect.aspx.cs" %>
        <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
            <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
            <HTML>

            <HEAD>
                            <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			<link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
                <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
                <meta content="C#" name="CODE_LANGUAGE">
                <meta content="JavaScript" name="vs_defaultClientScript">
                <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
                <LINK href="epolicy.css" type="text/css" rel="stylesheet">
                <style type="text/css">
                    .style1 {
                        width: 191px;
                    }
                    
                    .style2 {
                        height: 10px;
                        width: 191px;
                    }
                    
                    .txt-w-215 {
                        width: 215px;
                    }
                    
                    .r-btn-center {
                        align-self: flex-end;
                        padding: 5px;
                    }
                    
                    .r-btn-better {
                        font-size: larger;
                        font-weight: 400;
                    }
                </style>
            </HEAD>

            <body>
                <form id="Form1" method="post" runat="server">

                    <p>
                        <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                    </p>

                    <div class="container-xl mb-4 p-18">
                        <div class="row">
                            <div class="col-md-12 f-center">
                                <img alt="" src="Images2/search.png" class="searchImage" style="margin-bottom: 25px;" />
                            </div>
                        </div>


                        <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="900">
                        </Toolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="col-md-12 f-center">
                                    <asp:Label ID="Label26" runat="server" class="fs-16">Search Prospect</asp:Label>
                                </div>

                                <div class="col-md-12 f-center">
                                    <asp:Button id="btnSearch" runat="server" Text="Search" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnSearch_Click" />
                                    <asp:Button id="btnClear" runat="server" Text="Clear" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnClear_Click" />
                                </div>


                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="10">
                                    <ProgressTemplate>
                                        <img alt="" src="Images2/loader.gif" style="width: 35px; height: 35px;" />
                                        <span><span class=""></span><span style="font-family: Tahoma; font-size: 14pt; color: #BA354E">
                                        <strong>Please wait...</strong></span></span>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>


                                <hr>

                                <p>
                                    <div class="row">
                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="TxtProspectID" RUNAT="server" class="form-control" placeholder="Prospect ID" />
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtFirstName" RUNAT="server" class="form-control" placeholder="First Name" />
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtinicial" RUNAT="server" class="form-control" placeholder="Initial" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtLastName1" RUNAT="server" class="form-control" placeholder="Last Name 1" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtLastName2" RUNAT="server" class="form-control" placeholder="Last Name 2" />
                                        </div>
                                    </div>
                                </p>

                                <p>
                                    <div class="row">
                                        <div class="col-md-2 f-center">
                                            <asp:DropDownList ID="ddlstatus" RUNAT="server" class="form-select"></asp:DropDownList>
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:DropDownList ID="ddlinsuredtype" RUNAT="server" class="form-select"></asp:DropDownList>
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtlicence" RUNAT="server" class="form-control" placeholder="Licence" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtlicexpdate" tabIndex="2" RUNAT="server" class="form-control" placeholder="Licence exp date" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtLeadID" RUNAT="server" class="form-control" placeholder="Lead ID" />
                                        </div>
                                    </div>
                                </p>

                                <p>
                                    <div class="row">
                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtAgentID" RUNAT="server" class="form-control" placeholder="Agent ID" />
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtInterestedIN" RUNAT="server" class="form-control" placeholder="Interested IN" />
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtConvToClientDate" RUNAT="server" class="form-control" placeholder="Convert To Client Date" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="TxtEmail" RUNAT="server" class="form-control" placeholder="E-Mail" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtEmail2" RUNAT="server" class="form-control" placeholder="E-Mail 2" />
                                        </div>
                                    </div>
                                </p>

                                <p>
                                    <div class="row">
                                        <div class="col-md-2 f-center">
                                            <maskedinput:maskedtextbox id="TxtPhone" RUNAT="server" class="form-control" placeholder="Phone" MASK="(999) 999-9999" ISDATE="False" ENABLEVIEWSTATE="False"></maskedinput:maskedtextbox>
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtFax" RUNAT="server" class="form-control" placeholder="Fax" />
                                        </div>

                                        <div class="col-md-2 f-center">
                                            <asp:textbox id="txtQuoted" RUNAT="server" class="form-control" placeholder="Quoted" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtaddress1" RUNAT="server" class="form-control" placeholder="Address" />
                                        </div>

                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtaddress2" RUNAT="server" class="form-control" placeholder="Address 2" />
                                        </div>
                                    </div>
                                </p>

                                <p>
                                    <p>
                                        <div class="row">
                                            <div class="col-md-4 f-center">
                                                <asp:textbox id="txtWebsite" RUNAT="server" class="form-control" placeholder="Website" />
                                            </div>

                                            <div class="col-md-5 f-center">
                                                <asp:DropDownList ID="ddlAmscaOrDEA" RUNAT="server" class="form-select"></asp:DropDownList>
                                            </div>

                                            <div class="col-md-3 f-center r-btn-center r-btn-better">
                                                <asp:radiobutton id="RdbIndividual" runat="server" Text="Individual" AutoPostBack="True" Checked="True" GroupName="ClientType" oncheckedchanged="RdbIndividual_CheckedChanged"></asp:radiobutton>
                                                <asp:radiobutton id="RdbBusiness" runat="server" Text="Business" AutoPostBack="True" GroupName="ClientType" oncheckedchanged="RdbBusiness_CheckedChanged"></asp:radiobutton>
                                            </div>
                                        </div>
                                    </p>
                                </p>

                                <p>
                                    <div class="col-md-6 f-left">
                                        <asp:Label ID="Label1" runat="server" class="fs-16">Customers</asp:Label>
                                    </div>
                                </p>

                                <p>
                                    <div class="row">
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtCustPreferedCommID" RUNAT="server" class="form-control" placeholder="Cust Prefered Comm ID" />
                                        </div>
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtWebsite2" RUNAT="server" class="form-control" placeholder="Website" />
                                        </div>
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtInsuredtype" RUNAT="server" class="form-control" placeholder="Insured Type" />
                                        </div>
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtCorpName" RUNAT="server" class="form-control" placeholder="Corporation Name in Policy" />
                                        </div>
                                    </div>
                                </p>

                                <p>
                                    <div class="row">
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtssn" RUNAT="server" class="form-control" placeholder="SSN Personal" />
                                        </div>
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtssn2" RUNAT="server" class="form-control" placeholder="SSN 2 Patronal" />
                                        </div>
                                        <div class="col-md-3 f-center">
                                            <asp:DropDownList ID="ddlAmscaOrDEA2" class="form-select" RUNAT="server"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 f-center">
                                            <asp:textbox id="txtNPI" RUNAT="server" class="form-control" placeholder="NPI" />
                                        </div>
                                    </div>
                                </p>

                                <p>
                                    <asp:Label ID="LblTotalCases" runat="server">Total Cases:</asp:Label>
                                </p>

                                <hr>

                                <asp:Label id="LblError" runat="server" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Red" Visible="False" Width="100%">Label</asp:Label>

                                <TR>
                                    <TD style="FONT-SIZE: 0pt; align="center">
                                        <P align="center">
                                            <asp:datagrid id="searchIndividual" Height="188px" RUNAT="server" 
                                            class="table table-bordered table-condensed table-hover " Width="100%" AutoGenerateColumns="False" Font-Size="10pt"
                                            CellPadding="4" ForeColor="#333333" AlternatingRowStyle-BackColor="White" Visible="False" ALLOWPAGING="True" PageSize="9">
                                                <Columns>
                                                    <asp:ButtonColumn HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." ButtonType="PushButton" CommandName="Select">
                                                        <HeaderStyle Width="10%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"/>
                                                    </asp:ButtonColumn>
                                                    <asp:BoundColumn DataField="prospectID" HeaderText="Prospect ID">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="firstName" HeaderText="First Name">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="lastName1" HeaderText="Last Name1">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="lastName2" HeaderText="Last Name2">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="homePhone" HeaderText="Home Phone">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="workPhone" HeaderText="Work Phone">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="cellular" HeaderText="Cellular">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="email" HeaderText="E-mail">
                                                        <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                                    </asp:BoundColumn>
                                                </Columns>
                                                <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                                <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                                            </asp:datagrid>
                                        </P>
                                        <P>
                                            <asp:datagrid id="searchBusiness" Height="93px" RUNAT="server" WIDTH="802px" Visible="False" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False"
                                                ALLOWPAGING="True" FONT-SIZE="9pt" FONT-NAMES="Arial" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
                                                ITEMSTYLE-CSSCLASS="HeadForm3" PageSize="9">
                                                <FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
                                                <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                                                <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                                                <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                                                <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                                <Columns>
                                                    <asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
                                                        <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                    </asp:ButtonColumn>
                                                    <asp:BoundColumn DataField="ProspectID" HeaderText="Prospect ID">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="BusinessName" HeaderText="Business Name">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="FirstName" HeaderText="First Name">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="lastName" HeaderText="Last Name">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="WorkPhone" HeaderText="Phone">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Email" HeaderText="E-mail">
                                                        <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                </Columns>
                                                <PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                            </asp:datagrid>
                                        </P>
                                    </TD>
                                </TR>



                                <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                                <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </form>
            </body>

            </HTML>
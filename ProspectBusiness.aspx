<%@ Page language="c#" Inherits="EPolicy.ProspectBusiness" CodeFile="ProspectBusiness.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
            <style type="text/css">
                .style1 {
                    height: 11px;
                    width: 223px;
                }
                
                .style2 {
                    height: 26px;
                    width: 223px;
                }
            </style>
        </HEAD>

        <body>
            <form method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </P>
                <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                    <div class="row">
                        <div class="col-md-4" style="align-self: center;">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label id="Label17" runat="server" ForeColor="Black" Height="16px" Width="77px" CssClass="headForm1 " Font-Bold="True" Font-Size="11pt">Prospect: </asp:Label>
                                    <asp:label id="lblProspectNo" RUNAT="server" CSSCLASS="headfield1" WIDTH="121px" Font-Size="9pt"></asp:label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label id="Label5" runat="server" ForeColor="Black" Height="10px" Width="33px" CssClass="headForm1 " Font-Size="9pt">Client: </asp:Label>
                                    <asp:label id="lblParentCustomer" RUNAT="server" CSSCLASS="headfield1" WIDTH="96px" Font-Size="9pt"></asp:label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8" style="text-align:right;">
                            <asp:Button id="btnNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Add" onclick="btnNew_Click"></asp:Button>
                            <asp:Button id="cmdConvertToCustomer" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="ChangeToCustomer" onclick="cmdConvertToCustomer_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="History" onclick="btnAuditTrail_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                        <div class="col-md-12">
                            <hr />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="lblBusinessName" for="txtBusinessName" HEIGHT="19px" RUNAT="server" CSSCLASS="col-md-3 col-form-labe" Font-Size="9pt">Business Name</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="txtBusinessName" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label1" for="Textbox1" HEIGHT="19px" RUNAT="server" CSSCLASS="col-md-3 col-form-labe" Font-Size="9pt">xxxxxxxxxxxx</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="Textbox1" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="lblReferredBy" for="ddlReferredBy" HEIGHT="34px" RUNAT="server" CSSCLASS="col-md-3 col-form-labe" Font-Size="9pt" ENABLEVIEWSTATE="False">Referred By</asp:label>
                                        <div class="col-md-9">
                                            <asp:dropdownlist id="ddlReferredBy" tabIndex="3" RUNAT="server" CSSCLASS="form-select" AUTOPOSTBACK="True" HEIGHT="34px" Font-Size="9pt"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="lblPhone" for="txtPhone" RUNAT="server" CSSCLASS="col-md-3 col-form-labe" ForeColor="Black" HEIGHT="34px" Font-Size="9pt">Phone</asp:label>
                                        <div class="col-md-9">
                                            <maskedinput:maskedtextbox id="txtPhone" tabIndex="2" RUNAT="server" CSSCLASS="form-control telefoneFormat" HEIGHT="34px" MAXLENGTH="20" MASK="(999) 999-9999" Font-Size="9pt"></maskedinput:maskedtextbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label3" for="txtReferredByName" HEIGHT="34px" RUNAT="server" CSSCLASS="col-md-3 col-form-labe" Font-Size="9pt">xxxxxxxxxxxx</asp:label>
                                        <div class="col-md-9">
                                            <asp:textbox id="txtReferredByName" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="mb-3 row">
                                        <asp:label id="Label10" for="ddlLocation" RUNAT="server" CSSCLASS="col-md-3 col-form-labe" HEIGHT="34" ENABLEVIEWSTATE="False" Font-Size="9pt">Originated At</asp:label>
                                        <div class="col-md-9">
                                            <asp:dropdownlist id="ddlLocation" tabIndex="5" RUNAT="server" CSSCLASS="form-select" AUTOPOSTBACK="True" HEIGHT="34px" Font-Size="9pt"></asp:dropdownlist>
                                        </div>
                                    </div>
                                </div>



                                <div class="col-md-12">
                                    <div class="mb-3 row">
                                        <b>	<asp:label id="Label9" RUNAT="server" ForeColor="Black" WIDTH="136px"
			    	                		Font-Size="9pt" >Contact Information</asp:label>
			    	                </b>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label4" RUNAT="server" CSSCLASS="col-md-2 col-form-labe" ForeColor="Black" HEIGHT="19px" Font-Size="9pt">First Name</asp:label>
                                        <div class="col-md-10">
                                            <asp:textbox id="txtFirstName" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label6" HEIGHT="19px" RUNAT="server" CSSCLASS="col-md-2 col-form-labe" Font-Size="9pt">E-mail</asp:label>

                                        <div class="col-md-10">
                                            <asp:textbox id="txtEmail" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>



                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label7" RUNAT="server" CSSCLASS="col-md-2 col-form-labe" ForeColor="Black" HEIGHT="19px" Font-Size="9pt">Last Name</asp:label>
                                        <div class="col-md-10">
                                            <asp:textbox id="txtLastName1" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3 row">
                                        <asp:label id="Label8" HEIGHT="19px" RUNAT="server" CSSCLASS="col-md-2 col-form-labe" Font-Size="9pt">xxxxxxxxxx</asp:label>
                                        <div class="col-md-10">
                                            <asp:textbox id="Textbox4" tabIndex="1" RUNAT="server" CSSCLASS="form-control" HEIGHT="34px" MAXLENGTH="20" Font-Size="9pt"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <hr />
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:label id="LblTotalCases" RUNAT="server" CSSCLASS="headform3" Height="9px" ForeColor="Black" WIDTH="131px" Font-Size="9pt">Total Cases:</asp:label>
                                    <hr />
                                </div>
                                <div class="col-md-12">
                                    <asp:Label id="LblError" runat="server" ForeColor="IndianRed" Width="765px" Font-Size="13pt" Visible="False">Label</asp:Label>
                                    </TD>
                                </div>
                                <div class="col-md-12">
                                    <asp:datagrid id="searchIndividual" RUNAT="server" Height="204px" WIDTH="795px" PageSize="7" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False"
                                        ALLOWPAGING="True" FONT-SIZE="Smaller" FONT-NAMES="Arial" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE"
                                        ITEMSTYLE-CSSCLASS="HeadForm3">
                                        <FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
                                        <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                                        <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                                        <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" Height="10px" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                        <Columns>
                                            <asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
                                                <HeaderStyle Width="1px"></HeaderStyle>
                                                <ItemStyle></ItemStyle>
                                            </asp:ButtonColumn>
                                            <asp:BoundColumn DataField="TaskControlID" HeaderText="Control No">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="TaskControlTypeDesc" HeaderText="Task Type">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="EntryDate" HeaderText="Entry Date" DataFormatString="{0:d}">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="TaskStatusDesc" HeaderText="Status">
                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                    </asp:datagrid>
                                </div>
                            </div>
                        </div>
                    </div>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                </div>
            </form>
        </body>

        </HTML>
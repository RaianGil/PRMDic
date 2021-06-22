<%@ Page language="c#" Inherits="EPolicy.Supplier" CodeFile="Supplier.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        </HEAD>

        <body>
            <form id="Supp" method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl">
                    <div class="row">
                        <div class="col-md-4">
                            <asp:Label id="Label21" cssclass="fs-14 fw-bold" runat="server">Supplier:</asp:Label>
                            <asp:Label id="lblSupplierID" cssclass="fs-14" runat="server"></asp:Label>
                        </div>
                        <div class="col-md-8 f-right">
                            <asp:Button id="btnAuditTrail" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
                            <asp:Button id="btnIncentive" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Incentive" onclick="btnIncentive_Click"></asp:Button>
                            <asp:Button id="btnPrint" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Print" onclick="btnPrint_Click"></asp:Button>
                            <asp:Button id="btnSearch" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Search" onclick="btnSearch_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="btnAddNew" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="cmdCancel" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblB" RUNAT="server" CssClass="fs-lbl-s mb-1">Supplier Description</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtSupplierDescription" RUNAT="server" CssClass="form-control fs-txt-s mb-1" MAXLENGTH="30"></asp:textbox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblAddress1" RUNAT="server" CssClass="fs-lbl-s mb-1"> Address 1</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtAddress1" RUNAT="server" CssClass="form-control fs-txt-s mb-1" MAXLENGTH="20"></asp:textbox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblAddress2" RUNAT="server" CssClass="fs-lbl-s mb-1"> Address 2</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtAddress2" RUNAT="server" CssClass="form-control fs-txt-s mb-1" MAXLENGTH="20"></asp:textbox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblCity" RUNAT="server" CssClass="fs-lbl-s mb-1">City</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtCity" RUNAT="server" CssClass="form-control fs-txt-s mb-1" MAXLENGTH="10"></asp:textbox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblState" RUNAT="server" CssClass="fs-lbl-s mb-1">State</asp:label>
                        </div>
                        <div class="col-md-4">
                            <asp:textbox id="txtSt" RUNAT="server" CssClass="form-control fs-txt-s mb-1" MAXLENGTH="2"></asp:textbox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblZipCode" RUNAT="server" CssClass="fs-lbl-s mb-1">Zip Code</asp:label>
                        </div>
                        <div class="col-md-4">
                            <maskedinput:maskedtextbox id="txtZipCode" RUNAT="server" CssClass="form-control fs-txt-s mb-1" ISDATE="False" MASK="99999Z9999" MAXLENGTH="10"></maskedinput:maskedtextbox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblPhone" RUNAT="server" CssClass="fs-lbl-s mb-1">Phone </asp:label>
                        </div>
                        <div class="col-md-4">
                            <maskedinput:MaskedTextBox id="txtPhone" runat="server" CssClass="form-control fs-txt-s mb-1 telefoneFormat" Mask="(999) 999-9999"></maskedinput:MaskedTextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:label id="lblEntryDate" RUNAT="server" CssClass="fs-lbl-s mb-1">Entry Date</asp:label>
                        </div>
                        <div class="col-md-4">
                            <maskedinput:maskedtextbox id="txtEntryDate" RUNAT="server" CssClass="form-control fs-txt-s mb-1 fechaFormat" Enabled="False" ISDATE="True"></maskedinput:maskedtextbox>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblAddSupplier" runat="server" CssClass="fs-lbl-s mb-1">Add Supplier:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlSupplier2" runat="server" CssClass="form-select fs-txt-s mb-1" />
                        </div>
                        <asp:Button ID="btnAdd2" runat="server" OnClick="btnAdd2_Click" Text="Add" />
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <asp:DataGrid ID="dgSupplier2" runat="server" Width="100%" runat="server" Height="118px" CellPadding="0" class="table table-bordered" AutoGenerateColumns="False" OnItemCommand="dgSupplier2_ItemCommand">
                            <Columns>
                                <asp:BoundColumn DataField="SupplierID" HeaderText="SupplierID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SupplierDesc" HeaderText="Supplier">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" HeaderImageUrl="Images2/x.bmp">
                                </asp:ButtonColumn>
                                <asp:BoundColumn DataField="GroupSupplierID" HeaderText="GroupSupplierID" Visible="False">
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages" />
                            <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid>

                        <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                        <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                        <asp:button id="BtnBegin" tabIndex="16" runat="server" Text="<<" style="Z-INDEX: 116; LEFT: 666px; POSITION: absolute; TOP: 598px" Visible="False" onclick="BtnBegin_Click"></asp:button>
                        <asp:button id="BtnPrevious" tabIndex="17" runat="server" Width="24px" Text="<" style="Z-INDEX: 117; LEFT: 686px; POSITION: absolute; TOP: 598px" Visible="False" onclick="BtnPrevious_Click"></asp:button>
                        <asp:button id="BtnNext" tabIndex="18" runat="server" Width="24px" Text=">" style="Z-INDEX: 118; LEFT: 706px; POSITION: absolute; TOP: 598px" Visible="False" onclick="BtnNext_Click"></asp:button>
                        <asp:button id="BtnEnd" tabIndex="19" runat="server" Text=">>" style="Z-INDEX: 119; LEFT: 726px; POSITION: absolute; TOP: 598px" Visible="False" onclick="BtnEnd_Click"></asp:button>
                        <asp:label id="lblRecordCount" RUNAT="server" CSSCLASS="headform2" WIDTH="129px" HEIGHT="17px" style="Z-INDEX: 120; LEFT: 746px; POSITION: absolute; TOP: 598px" Visible="False">1 of 1</asp:label>
                    </div>
                </div>
            </form>
        </body>

        </HTML>
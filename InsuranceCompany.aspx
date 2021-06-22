<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.InsuranceCompany" CodeFile="InsuranceCompany.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script src="js/load.js" type="text/javascript"></script>
        </HEAD>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            function dpShowEntryDate() {
                $('#<%= txtEntryDate.ClientID %>').datepicker('show');
            }

            $(function() {
                $('#<%= txtEntryDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

            });
        </script>

        <body>
            <form method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label2" class="fs-16" runat="server">Insurance Company ID:</asp:Label>
                            <asp:label id="lblInsuranceCompanyID" class="fs-16" runat="server"></asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:button id="btnAuditTrail" runat="server" Text="AuditTrail" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnAuditTrail_Click"></asp:button>
                            <asp:button id="btnPrint" runat="server" Text="Print" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnPrint_Click"></asp:button>
                            <asp:button id="btnSearch" runat="server" Text="Search" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnSearch_Click"></asp:button>
                            <asp:button id="btnAddNew" runat="server" Text="Add" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnAddNew_Click"></asp:button>
                            <asp:button id="btnEdit" runat="server" Text="Edit" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnEdit_Click"></asp:button>
                            <asp:button id="BtnSave" runat="server" Text="Save" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="BtnSave_Click"></asp:button>
                            <asp:button id="cmdCancel" runat="server" Text="Cancel" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="cmdCancel_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" Text="Exit" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="BtnExit_Click"></asp:button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="f-center">
                        <div class="row col-md-10">
                            <div class="col-md-6">
                                <div class="row mb-1">
                                    <div class="col-md-4">
                                        <asp:label id="lblB" RUNAT="server">Insurance Description</asp:label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:textbox id="txtInsuranceDescription" RUNAT="server" class="form-control"></asp:textbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-4">
                                        <asp:label id="lblInsuranceName" RUNAT="server">Insurance Name</asp:label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:textbox id="txtInsuranceName" RUNAT="server" class="form-control"></asp:textbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-4">
                                        <asp:label id="lblAddress1" RUNAT="server"> Address 1</asp:label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:textbox id="txtAddress1" RUNAT="server" class="form-control"></asp:textbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-4">
                                        <asp:label id="lblAddress2" RUNAT="server"> Address 2</asp:label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:textbox id="txtAddress2" RUNAT="server" MAXLENGTH="10" class="form-control"></asp:textbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-4">
                                        <asp:label id="lblCity" RUNAT="server">City</asp:label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:textbox id="txtCity" RUNAT="server" class="form-control"></asp:textbox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="row mb-1">
                                    <div class="col-md-3">
                                        <asp:label id="lblState" RUNAT="server">State</asp:label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:textbox id="txtSt" RUNAT="server" MAXLENGTH="2" class="form-control"></asp:textbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-3">
                                        <asp:label id="lblZipCode" RUNAT="server">Zip Code</asp:label>
                                    </div>
                                    <div class="col-md-9">
                                        <maskedinput:maskedtextbox id="txtZipCode" RUNAT="server" MAXLENGTH="10" ISDATE="False" MASK="99999Z9999" class="form-control"></maskedinput:maskedtextbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-3">
                                        <asp:label id="lblPhone" RUNAT="server">Phone </asp:label>
                                    </div>
                                    <div class="col-md-9">
                                        <maskedinput:maskedtextbox id="txtPhone" runat="server" Mask="(999) 999-9999" Columns="34" class="form-control telefoneFormat"></maskedinput:maskedtextbox>
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-3">
                                        <asp:label id="lblEntryDate" RUNAT="server">Entry Date</asp:label>
                                    </div>
                                    <div class="col-md-9">
                                        <maskedinput:maskedtextbox id="txtEntryDate" RUNAT="server" onclick="dpShowEntryDate();" ISDATE="True" class="form-control fechaFormat"></maskedinput:maskedtextbox>
                                        <INPUT id="btnCalendar" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=Agency.txtEntryDate','calendar_window','width=250,height=250');calendar_window.focus()" type="button" value="..." name="btnCalendar" RUNAT="server" class="input-group-text d-none">
                                    </div>
                                </div>
                                <div class="row mb-1">
                                    <div class="col-md-3">
                                        <asp:label id="lblSequence" RUNAT="server">Sequence</asp:label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:textbox id="txtSequence" RUNAT="server" MAXLENGTH="5" class="form-control"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="col-md">
                                    <asp:checkbox id="chkPrintPolicy" runat="server" Visible="False" Text="Print Policy" AutoPostBack="True"></asp:checkbox>
                                </div>
                                <div class="col-md">
                                    <asp:checkbox id="chkPrintCancel" runat="server" Visible="False" Text="Print Cancel" AutoPostBack="True"></asp:checkbox>
                                </div>
                                <div class="col-md">
                                    <asp:checkbox id="chkPrintLabels" runat="server" Visible="False" Text="Print Labels" AutoPostBack="True"></asp:checkbox>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="col-md">
                                    <asp:label id="lblApuntador" Visible="False" RUNAT="server">Apuntador</asp:label>
                                    <asp:textbox id="txtApuntador" Visible="False" RUNAT="server" class="form-control" MAXLENGTH="3"></asp:textbox>
                                </div>
                                <div class="col-md">
                                    <asp:label id="lblQuote" Visible="False" RUNAT="server">Quote</asp:label>
                                    <asp:textbox id="txtQuote" Visible="False" RUNAT="server" class="form-control" MAXLENGTH="3"></asp:textbox>
                                </div>
                                <div class="col-md">
                                    <asp:label id="lblApun_Trans" Visible="False" RUNAT="server">Apun_Trams</asp:label>
                                    <asp:textbox id="txtApun_Trams" Visible="False" RUNAT="server" class="form-control" MAXLENGTH="3"></asp:textbox>
                                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">

                        <asp:imagebutton id="btnAddNew1" runat="server" Visible="False" ImageUrl="Images/addNew_btn.gif" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="btnEdit1" runat="server" Visible="False" ImageUrl="Images/edit_btn.GIF" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="BtnSave1" Visible="False" RUNAT="server" CAUSESVALIDATION="False" TOOLTIP="Save Person Information" IMAGEURL="Images/save_btn.gif"></asp:imagebutton>
                        <asp:imagebutton id="btnSearch1" runat="server" Visible="False" ImageUrl="Images/search_btn.gif" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="cmdCancel1" runat="server" Visible="False" ImageUrl="Images/cancel_btn.gif" CausesValidation="False"></asp:imagebutton>
                        <asp:imagebutton id="btnPrint1" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
                        <asp:ImageButton id="btnAuditTrail1" runat="server" Visible="False" ImageUrl="Images/History_btn.bmp"></asp:ImageButton>
                        <asp:imagebutton id="BtnExit1" Visible="False" RUNAT="server" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
                        <asp:label id="lblRecordCount" Visible="False" RUNAT="server">1 of 1</asp:label>
                        <asp:button id="BtnBegin" runat="server" Visible="False" Text="<<" onclick="BtnBegin_Click"></asp:button>
                        <asp:button id="BtnPrevious" runat="server" Visible="False" Text="<" onclick="BtnPrevious_Click"></asp:button>
                        <asp:button id="BtnNext" runat="server" Visible="False" Text=">" onclick="BtnNext_Click"></asp:button>
                    </div>
                </div>

                <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                <p>
                    <asp:button id="BtnEnd" runat="server" Visible="False" Text=">>" onclick="BtnEnd_Click"></asp:button>
                </p>
                </div>
            </form>
        </body>

        </HTML>
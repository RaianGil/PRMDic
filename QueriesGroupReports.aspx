<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.QueriesGroupReports" CodeFile="QueriesGroupReports.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        </HEAD>

        <body>
            <form id="Form1" method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6 fs-14 fw-bold">
                            <asp:label id="Label8" runat="server">Policies Reports</asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Print" onclick="btnPrint_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="BtnExit_Click"></asp:button>
                        </div>
                    </div>


                    <asp:radiobuttonlist id="rblCertificatePaidOrder" style="Z-INDEX: 104; LEFT: 1074px; POSITION: absolute; TOP: 447px" runat="server" Width="168px" Height="34px" AutoPostBack="True" Visible="False">

                        <asp:ListItem Value="0" Selected="True">By Co. Dealer / Ins. Co.</asp:ListItem>
                        <asp:ListItem Value="1">By Company Dealer</asp:ListItem>
                        <asp:ListItem Value="2">Non Commission</asp:ListItem>
                    </asp:radiobuttonlist>

                    <asp:radiobuttonlist id="rblPremWrittenOrder" style="Z-INDEX: 103; LEFT: 1073px; POSITION: absolute; TOP: 524px" runat="server" Width="163px" Height="34px" AutoPostBack="True" Visible="False">

                        <asp:ListItem Value="0" Selected="True">By Company Dealer</asp:ListItem>
                        <asp:ListItem Value="1">By Bank</asp:ListItem>
                        <asp:ListItem Value="2">By Co. Dealer / Ins. Co.</asp:ListItem>
                    </asp:radiobuttonlist>

                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
                    <div class="col-md-12">
                        <hr>
                    </div>



                    <div class="col-md-12 mt-4 mb-4 f-center">
                        <asp:radiobuttonlist id="rblAutoGuardReports" style="Design_Time_Lock: False" tabIndex="1" runat="server" Design_Time_Lock="False" AutoPostBack="True">
                            <asp:ListItem Value="0" Selected="True">Policy Premium Written</asp:ListItem>
                        </asp:radiobuttonlist>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md-6">
                        <div class="row  mb-1">
                            <div class="col-md-4">
                                <asp:label id="LblTotalCases" RUNAT="server" class="fs-lbl-s">Report Filter:</asp:label>
                            </div>
                            <div class="col-md-8">
                                <asp:checkbox id="ChkSummary" runat="server" class="fs-lbl-s" Text="Summary"></asp:checkbox>
                            </div>
                        </div>

                        <div class="row  mb-1">
                            <div class="col-md-4">
                                <asp:label id="lblOutstanding" RUNAT="server" class="fs-lbl-s">Policy Outstanding as of:</asp:label>
                            </div>
                            <div class="col-md-8">
                                <div class="input-group input-append date" data-date-format="mm-dd-yyyy">
                                    <maskedinput:maskedtextbox id="txtOutstandingDate" class="form-control fs-txt-s" tabIndex="5" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                                    <span runat="server" id="btnCalendar31" class="add-on input-group-text datepicker-p1" style="height:29px;"><i class="bi bi-grid-3x3-gap-fill "></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="row  mb-1">
                            <div class="col-md-4">
                                <asp:label id="LblDataType" RUNAT="server" class="fs-lbl-s" Visible="False">Date Type:</asp:label>
                            </div>
                            <div class="col-md-8">
                                <asp:dropdownlist id="ddlDateType" RUNAT="server" class="form-select fs-txt-s" Visible="False">
                                    <asp:ListItem Value="F" Selected="True">Effective Date</asp:ListItem>
                                    <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="row mb-1">
                            <div class="col-md-4">
                                <asp:label id="Label1" runat="server" class="fs-lbl-s">Date From</asp:label>
                            </div>
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-5">
                                        <div class="input-group input-append date" data-date-format="mm-dd-yyyy">
                                            <maskedinput:maskedtextbox id="txtBegDate" RUNAT="server" class="form-control fs-txt-s" ISDATE="True"></maskedinput:maskedtextbox>
                                            <span runat="server" id="btnCalendar01" class="add-on input-group-text datepicker-p1" style="height:29px;"><i class="bi bi-grid-3x3-gap-fill "></i></span>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:label id="Label2" runat="server" class="fs-lbl-s">To</asp:label>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="input-group input-append date" data-date-format="mm-dd-yyyy">
                                            <maskedinput:maskedtextbox id="TxtEndDate" tabIndex="5" RUNAT="server" class="form-control fs-txt-s" ISDATE="True"></maskedinput:maskedtextbox>
                                            <span runat="server" id="btnCalendar21" class="add-on input-group-text datepicker-p1" style="height:29px;"><i class="bi bi-grid-3x3-gap-fill "></i></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:label id="lblPolicyClass" RUNAT="server" class="fs-lbl-s">Line Of Business:</asp:label>
                            </div>
                            <div class="col-md-8">
                                <asp:dropdownlist id="ddlPolicyClass" tabIndex="7" RUNAT="server" class="form-select fs-txt-s"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>

                </div>
            </form>
            <script type="text/javascript">
                $('.datepicker-p1').datepicker();
            </script>
        </body>

        </HTML>
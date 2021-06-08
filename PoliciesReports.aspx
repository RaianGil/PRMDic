<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.PoliciesReports" CodeFile="PoliciesReports.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script type="text/javascript">
                $(function() {
                    $('#<%= txtBegDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $('#<%= TxtEndDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                    $('#<%= txtOutstandingDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });

                });

                function ShowDateTimePicker() {
                    $('#<%= txtBegDate.ClientID %>').datepicker('show');
                }

                function ShowDateTimePicker2() {
                    $('#<%= TxtEndDate.ClientID %>').datepicker('show');
                }

                function ShowDateTimePicker3() {
                    $('#<%= txtOutstandingDate.ClientID %>').datepicker('show');
                }
            </script>
            <style type="text/css">
                .style1 {
                    width: 267px;
                    height: 8px;
                }
                
                .style2 {
                    width: 27px;
                    height: 8px;
                }
                
                .style3 {
                    width: 419px;
                    height: 8px;
                }
                
                .style4 {
                    width: 232px;
                    height: 8px;
                }
                
                .btn-w-70 {
                    width: 70px;
                    height: 25px;
                    font-size: 9pt;
                }
                
                .btn-r-4 {
                    border-radius: 4px;
                    border: none;
                }
                
                .btn-bg-theme1 {
                    background: #ba354e;
                    color: #fff;
                }
            </style>

        </HEAD>

        <body>
            <form id="Rep" method="post" runat="server">

                <P>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </P>

                <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-8">

                            <div class="row">
                                <div class="col-md-4" style="align-self: center;">
                                    <asp:label id="Label8" runat="server" CssClass="fs-14 fw-bold">Policies Reports</asp:label>
                                </div>
                                <div class="col-md-8" style="text-align:right;">
                                    <asp:button id="btnDownLoad" runat="server" Text="DownLoad" onclick="btnDownLoad_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;"></asp:button>
                                    <asp:Button ID="BtnPrint2" runat="server" OnClick="BtnPrint2_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" Text="Print" />
                                    <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" Text="Print" />
                                    <asp:button id="BtnExit" runat="server" onclick="BtnExit_Click" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" style="margin-bottom: 4px;" Text="Exit"></asp:button>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                    <div class="row">

                                        <div class="col-md-12" style="padding-left: 38%;">
                                            <div class="mb-3 row">
                                                <asp:radiobuttonlist id="rblAutoGuardReports" runat="server" Design_Time_Lock="False" AutoPostBack="True" onselectedindexchanged="rblAutoGuardReports_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Selected="True">Policy Premium Written</asp:ListItem>
                                                    <asp:ListItem Value="1">Policy Certificate Outstanding</asp:ListItem>
                                                    <asp:ListItem Value="2">Policy Certificate Paid</asp:ListItem>
                                                    <asp:ListItem Value="3">Renewal List</asp:ListItem>
                                                    <asp:ListItem Value="4">Policies Premium Earned</asp:ListItem>
                                                    <asp:ListItem Value="7">Quotes List</asp:ListItem>
                                                    <asp:ListItem Value="8">Endorsements Report</asp:ListItem>
                                                    <asp:ListItem Value="12">Financial Notice Agning</asp:ListItem>
                                                    <asp:ListItem Value="13">Cancellation Notice</asp:ListItem>
                                                </asp:radiobuttonlist>
                                            </div>
                                        </div>
                                    </div>

                                    <hr />
                                    <div class="row">
                                        <div class="col-md-3"></div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-4 mb-3">
                                                    <asp:label id="LblTotalCases" RUNAT="server" CssClass="fs-11 fw-bold">Report Filter:</asp:label>
                                                </div>
                                                <div class="col-md-8 mb-3">
                                                    <asp:checkbox id="ChkSummary" runat="server" Text="Summary"></asp:checkbox>
                                                    <asp:checkbox id="ChkActualPolicies" runat="server" Text="Actual"></asp:checkbox>
                                                    <asp:checkbox id="ChkEndorsement" runat="server" Text="Endorsement"></asp:checkbox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:label id="lblFilterBy" RUNAT="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3">Filter by:</asp:label>
                                                <div class="col-md-8">
                                                    <asp:RadioButtonList ID="rblFilterBy" runat="server" AutoPostBack="True" onselectedindexchanged="rblFilterBy_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="A" style="padding-right: 10px;">Agency</asp:ListItem>
                                                        <asp:ListItem Value="B" style="padding-right: 10px;">Agent</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <asp:label id="lblOutstanding" RUNAT="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3"> Policy Outstanding as of:</asp:label>
                                                <div class="col-md-8">
                                                    <asp:TextBox id="txtOutstandingDate" onclick="ShowDateTimePicker3();" class="form-control fs-txt-s" RUNAT="server" ISDATE="True" ontextchanged="txtOutstandingDate_TextChanged"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4"></div>
                                                <div class="col-md-8">
                                                    <asp:CheckBox ID="chkPartialPayments" runat="server" Text="Only Partial Payments" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:label id="lblOutstandingStatus" RUNAT="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3" Visible="False">Status:</asp:label>
                                                <div class="col-md-8">
                                                    <asp:RadioButtonList ID="rblOutstandingStatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Visible="False">
                                                        <asp:ListItem Selected="True" Value="0" style="padding-right: 10px;">All</asp:ListItem>
                                                        <asp:ListItem Value="1" style="padding-right: 10px;">Unpaid</asp:ListItem>
                                                        <asp:ListItem Value="2" style="padding-right: 10px;">Overpaid</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <asp:label id="lblPaidEntry" RUNAT="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3">Paid Entry:</asp:label>
                                                <div class="col-md-8">
                                                    <maskedinput:maskedtextbox id="txtFollowUpCancellation" RUNAT="server" class="form-control fs-txt-s" ISDATE="True"></maskedinput:maskedtextbox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <asp:label id="LblDataType" Visible="False" class="col-md-4 fs-lbl-s label-vertical-align mb-3" RUNAT="server">Date Type:</asp:label>
                                                <div class="col-md-8">
                                                    <asp:dropdownlist id="ddlDateType" Visible="False" class="form-select fs-txt-s" RUNAT="server">
                                                        <asp:ListItem Value="E" Selected="True">Entry Date</asp:ListItem>
                                                        <asp:ListItem Value="F">Effective Date</asp:ListItem>
                                                        <asp:ListItem Value="C">Cancellation Date</asp:ListItem>
                                                        <asp:ListItem Value="N">Cancellation Entry Date</asp:ListItem>
                                                    </asp:dropdownlist>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:label id="Label1" runat="server" CssClass="col-md-4 fs-lbl-s label-vertical-align mb-3">Date From</asp:label>
                                                <div class="col-md-8">
                                                    <div class="input-group">
                                                        <asp:TextBox id="txtBegDate" onclick="ShowDateTimePicker();" RUNAT="server" CSSCLASS="form-control fs-txt-s" style="height: 29.2px;"></asp:TextBox>
                                                        <asp:label id="Label2" runat="server" CssClass="col-form-labe input-group-text label-vertical-align" style="height: 29.2px;">To</asp:label>
                                                        <asp:TextBox ID="TxtEndDate" runat="server" onclick="ShowDateTimePicker2();" CSSCLASS="form-control fs-txt-s" style="height: 29.2px;"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="lblAgent" runat="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3">Agency:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:dropdownlist id="ddlAgent" RUNAT="server" class="form-select fs-txt-s">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="lblPolicyType" runat="server" class="col-md-4 fs-lbl-s label-vertical-align">Policy Type:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:dropdownlist id="ddlPolicyType" runat="server" class="form-select fs-txt-s" Visible="False">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Value="PE">Excess Policy</asp:ListItem>
                                                        <asp:ListItem Value="PP">Primary Policy</asp:ListItem>
                                                        <asp:ListItem Value="CP">Corporate Primary</asp:ListItem>
                                                        <asp:ListItem Value="CE">Corporate Excess</asp:ListItem>
                                                        <asp:ListItem Value="CLP">Laboratory</asp:ListItem>
                                                        <asp:ListItem Value="CLE">Laboratory Excess</asp:ListItem>
                                                        <asp:ListItem Value="EMD">Cyber Policy</asp:ListItem>
                                                    </asp:dropdownlist>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <asp:Label ID="lblGroup" runat="server" class="col-md-4 fs-lbl-s label-vertical-align">Group:</asp:Label>
                                                <div class="col-md-8">
                                                    <asp:DropDownList ID="ddlGroup" runat="server" class="form-select fs-txt-s" Visible="False">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3"></div>
                                    </div>
                                </div>














                                <asp:label id="lblPolicyClass" RUNAT="server">Line Of Business:</asp:label>

                                <asp:dropdownlist id="ddlPolicyClass" RUNAT="server"></asp:dropdownlist>

                                <asp:label id="lblCompanyDealer" RUNAT="server">Company Dealer:</asp:label>

                                <asp:dropdownlist id="ddlBank" RUNAT="server"></asp:dropdownlist>
                                <asp:dropdownlist id="ddlDealer" RUNAT="server"></asp:dropdownlist>

                                <asp:label id="lblInsuranceCompany" RUNAT="server">Insurance Company:</asp:label>

                                <asp:dropdownlist id="ddlInsuranceCompany" RUNAT="server"></asp:dropdownlist>

                                <asp:label id="lblMonth" Visible="False" RUNAT="server">Month:</asp:label>

                                <asp:dropdownlist id="ddlMonths" runat="server" Visible="False">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:dropdownlist>

                                <asp:label id="lblYear" Visible="False" RUNAT="server">Year:</asp:label>

                                <asp:dropdownlist id="ddlYears" runat="server" Visible="False"></asp:dropdownlist>


                                <asp:Label ID="lblAgent0" runat="server">Agent:</asp:Label>

                                <asp:dropdownlist id="ddlAgent0" RUNAT="server">
                                </asp:DropDownList>


                                <asp:Label ID="lblPending" runat="server">Pending or Active:</asp:Label>

                                <asp:dropdownlist id="ddlVSCPending" runat="server" Visible="False">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>Pending</asp:ListItem>
                                </asp:DropDownList>



                                <asp:radiobuttonlist id="rblPremWrittenOrder" runat="server" AutoPostBack="True" onselectedindexchanged="rblPremWrittenOrder_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">By Dealer</asp:ListItem>
                                    <asp:ListItem Value="1">By Bank</asp:ListItem>
                                </asp:radiobuttonlist>
                                <asp:radiobuttonlist id="rblCertificatePaidOrder" runat="server" AutoPostBack="True" Visible="False" onselectedindexchanged="rblCertificatePaidOrder_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">By Co. Dealer / Ins. Co.</asp:ListItem>
                                    <asp:ListItem Value="1">By Company Dealer</asp:ListItem>
                                    <asp:ListItem Value="2">Non Commission</asp:ListItem>
                                </asp:radiobuttonlist>

                                <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                                <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                                <asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
                                <asp:imagebutton id="BtnDownload1" runat="server" Visible="False" ImageUrl="Images/Download_btn.GIF"></asp:imagebutton>
                                <asp:imagebutton id="btnPrint1" runat="server" Visible="False" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report"></asp:imagebutton>
                            </div>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>

            </form>
        </body>

        </HTML>
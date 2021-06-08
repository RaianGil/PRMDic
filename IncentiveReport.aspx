<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.IncentiveReport" CodeFile="IncentiveReport.aspx.cs" %>
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
                <div class="container-xl">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label8" class="fs-16" runat="server">Incentive Reports</asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:button id="Button2" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print" onclick="Button2_Click"></asp:button>
                            <asp:button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit"></asp:button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="col-md-12 f-center py-50">
                        <asp:radiobuttonlist id="rblProspectsReports" runat="server" AutoPostBack="True" Design_Time_Lock="False">
                            <asp:ListItem Value="0" Selected="True">Incentive Report</asp:ListItem>
                        </asp:radiobuttonlist>
                    </div>

                    <div class="col-md-12">
                        <asp:label id="LblTotalCases" RUNAT="server">Report Filter</asp:label>
                        <hr />
                    </div>
                    <div class="row f-center">
                        <div class="">
                            <div class="col-md-5">
                                <asp:label id="LblBank" RUNAT="server" ENABLEVIEWSTATE="False">Supplier</asp:label>
                            </div>
                            <div class="col-md-4">
                                <asp:dropdownlist id="ddlSupplier" class="w-auto1 form-select" RUNAT="server"></asp:dropdownlist>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-md-5">
                                <asp:label id="LblLineOfBusiness" runat="server"> Line of Business</asp:label>
                            </div>
                            <div class="col-md-4">
                                <asp:dropdownlist class="form-select" id="ddlPolicyClass" runat="server"></asp:dropdownlist>
                            </div>
                        </div>
                        <div class="">
                            <div class="col-md-5">
                                <asp:label id="Label1" runat="server">Date From</asp:label>
                            </div>
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md">
                                        <div class="d-inline-flex">
                                            <maskedinput:maskedtextbox id="txtBegDate" class="form-control" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                                            <INPUT id="btnCalendar2" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Form1.txtBegDate','calendar_window','width=250,height=250');calendar_window.focus()" type="button" class="input-group-text" value="..." name="btnCalendar"
                                                RUNAT="server">
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:label id="Label2" runat="server">To</asp:label>
                                    </div>
                                    <div class="col-md">
                                        <div class="d-inline-flex">
                                            <maskedinput:maskedtextbox id="TxtEndDate" class="form-control" RUNAT="server" ISDATE="True"></maskedinput:maskedtextbox>
                                            <INPUT id="btnCalendar" onclick="javascript:calendar_window=window.open('selectDate.aspx?formname=document.Form1.TxtEndDate','calendar_window','width=250,height=250');calendar_window.focus()" type="button" class="input-group-text" value="..." name="btnCalendar"
                                                RUNAT="server">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <div class="col-md-5">
                                    <asp:label id="LblDataType" RUNAT="server">Date Type:</asp:label>
                                </div>
                                <div class="col-md-4">
                                    <asp:dropdownlist id="ddlDateType" class="form-select" RUNAT="server">
                                        <asp:ListItem Value="F" Selected="True">Effective Date</asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

















                <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
            </form>
        </body>

        </HTML>
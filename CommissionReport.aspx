<%@ Reference Page="~/CommissionAgent.aspx" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <%@ Page language="c#" Inherits="EPolicy.CommissionReport" CodeFile="CommissionReport.aspx.cs" %>
            <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
            <HTML>

            <HEAD>
                <title>ePMS | electronic Policy Manager Solution</title>
                <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
                <meta name="CODE_LANGUAGE" Content="C#">
                <meta name="vs_defaultClientScript" content="JavaScript">
                <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
                <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                <style type="text/css">
                    #jq-books {
                        width: 200px;
                        float: right;
                        margin-right: 0
                    }
                    
                    #jq-books li {
                        line-height: 1.25em;
                        margin: 1em 0 1.8em;
                        clear: left
                    }
                    
                    #home-content-wrapper #jq-books a.jq-bookImg {
                        float: left;
                        margin-right: 10px;
                        width: 55px;
                        height: 70px
                    }
                    
                    #jq-books h3 {
                        margin: 0 0 .2em 0
                    }
                    
                    #home-content-wrapper #jq-books h3 a {
                        font-size: 1em;
                        color: black;
                    }
                    
                    #home-content-wrapper #jq-books a.jq-buyNow {
                        font-size: 1em;
                        color: white;
                        display: block;
                        background: url(http://static.jquery.com/files/rocker/images/btn_blueSheen.gif) 50% repeat-x;
                        text-decoration: none;
                        color: #fff;
                        font-weight: bold;
                        padding: .2em .8em;
                        float: left;
                        margin-top: .2em;
                    }
                    
                    .headfield1 {
                        font-size: x-small;
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
                    
                    .txt-pv-5 {
                        padding: 5px 2px;
                    }
                    
                    .txt-r-4 {
                        box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
                        border-radius: 4px;
                        background-color: #fff;
                        border: 1px solid #ccc;
                    }
                    
                    .txt-h-25 {
                        height: 25px;
                    }
                </style>
            </HEAD>
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
                });

                function ShowDateTimePicker() {
                    $('#<%= txtBegDate.ClientID %>').datepicker('show');
                }

                function ShowDateTimePicker2() {
                    $('#<%= TxtEndDate.ClientID %>').datepicker('show');
                }
            </script>

            <body bottomMargin="0" leftMargin="0" topMargin="9" rightMargin="0">
                <form id="Form1" method="post" runat="server">


                    <P>
                        <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                    </P>

                    <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-8">

                                <div class="row">
                                    <div class="col-md-4" style="align-self: center;">
                                        <asp:Label id="Label8" runat="server" CssClass="fs-14 fw-bold">Commission Reports</asp:Label>
                                    </div>
                                    <div class="col-md-8" style="text-align:right;">
                                        <asp:button id="Button2" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-4" onclick="Button2_Click" Text="Print"></asp:button>
                                        <asp:button id="BtnExit" runat="server" CssClass="btn-bg-theme2 btn-h-30 btn-r-4 mb-4" OnClick="BtnExit_Click" Text="Exit"></asp:button>
                                    </div>
                                    <div class="col-md-12">
                                        <hr />
                                        <div class="row">

                                            <div class="col-md-12" style="padding-left: 38%;">
                                                <div class="mb-3 row">
                                                    <asp:radiobuttonlist id="rblProspectsReports" style="Design_Time_Lock: False" runat="server" AutoPostBack="True" Design_Time_Lock="False" OnSelectedIndexChanged="rblProspectsReports_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Selected="True">Comission Agency Report</asp:ListItem>
                                                        <asp:ListItem Value="1">Comission Agent Report</asp:ListItem>
                                                        <asp:ListItem Value="2">Comission Aging Report</asp:ListItem>
                                                    </asp:radiobuttonlist>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:label id="LblTotalCases" RUNAT="server" CssClass="fs-11 fw-bold">Report Filter</asp:label>
                                        <hr />
                                        <div class="row">
                                            <div class="col-md-3"></div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4 mb-3">
                                                        <asp:label id="LblAgency" RUNAT="server" ENABLEVIEWSTATE="False" class="col-md-4 fs-lbl-s label-vertical-align mb-3">Agency</asp:label>
                                                        <asp:label id="LblNumAgents" RUNAT="server" ENABLEVIEWSTATE="False" class="col-md-4 fs-lbl-s label-vertical-align mb-3" Visible="False">Num. of Agents</asp:label>
                                                    </div>
                                                    <div class="col-md-8 mb-3">
                                                        <asp:dropdownlist id="ddlAgency" RUNAT="server" class="form-select fs-txt-s"></asp:dropdownlist>
                                                        <asp:TextBox ID="txtNumAgents" runat="server" class="form-control fs-txt-s" Width="70%" style="float:left;" Visible="False">1</asp:TextBox>
                                                        <asp:button id="btnUpdate" runat="server" Text="Update" CssClass="btn-bg-theme2 btn-h-30 btn-r-4" Width="30%" onclick="btnUpdate_Click" Visible="False"></asp:button>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <asp:Label ID="lblAgent" runat="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3" EnableViewState="False" Visible="False">Agent</asp:Label>
                                                    <div class="col-md-8">
                                                        <asp:datagrid id="dtGridAgents" tabIndex="4" Height="145px" RUNAT="server" WIDTH="301px" PageSize="8" ITEMSTYLE- HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE- CELLPADDING="0"
                                                            AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" Font-Italic="False"
                                                            style="text-align: center; font-size: 8pt;" ShowHeader="False" Visible="False">
                                                            <FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
                                                            <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                                                            <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                                                            <AlternatingItemStyle HorizontalAlign="Center" BackColor="White" Wrap="False"></AlternatingItemStyle>
                                                            <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                            <HeaderStyle HorizontalAlign="Center" Height="10px" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="Agents">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlAgent" RUNAT="server" WIDTH="200px">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                            <PagerStyle HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                                        </asp:datagrid>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <asp:label id="lblDeposit" RUNAT="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3">Account Type:</asp:label>
                                                    <div class="col-md-8">
                                                        <asp:RadioButtonList ID="chkAccountType" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="0" style="padding-right: 10px;">Direct Deposit</asp:ListItem>
                                                            <asp:ListItem Value="1" style="padding-right: 10px;">Chekings</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>


                                                <div class="row">
                                                    <asp:label id="lblAgentLevel" runat="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3" Visible="False">Agent Level</asp:label>
                                                    <div class="col-md-8">
                                                        <asp:RadioButtonList ID="rblAgentLevel" runat="server" RepeatDirection="Horizontal" Visible="False">
                                                            <asp:ListItem Selected="True" Value="1" style="padding-right: 10px;">Primary</asp:ListItem>
                                                            <asp:ListItem Value="2" style="padding-right: 10px;">Secondary</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>


                                                <div class="row">
                                                    <asp:label id="Label1" runat="server" CssClass="col-md-4 fs-lbl-s label-vertical-align mb-3">Date From</asp:label>
                                                    <div class="col-md-8">
                                                        <div class="input-group">
                                                            <asp:TextBox id="txtBegDate" RUNAT="server" CSSCLASS="form-control fs-txt-s" style="height: 29.2px;" onclick="ShowDateTimePicker();"></asp:TextBox>
                                                            <asp:label id="Label2" runat="server" CssClass="col-form-labe input-group-text label-vertical-align" style="height: 29.2px;">To</asp:label>
                                                            <asp:TextBox id="TxtEndDate" RUNAT="server" onclick="ShowDateTimePicker2();" CSSCLASS="form-control fs-txt-s" style="height: 29.2px;"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <asp:label id="LblDataType" RUNAT="server" class="col-md-4 fs-lbl-s label-vertical-align mb-3">Date Type:</asp:label>
                                                    <div class="col-md-8">
                                                        <asp:dropdownlist id="ddlDateType" RUNAT="server" class="form-select fs-txt-s">
                                                            <asp:ListItem Value="F" Selected="True">Effective Date</asp:ListItem>
                                                            <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                                            <asp:ListItem Value="P">Paid Entry Date</asp:ListItem>
                                                        </asp:dropdownlist>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2"></div>














                            <br />









                            <asp:label id="LblLineOfBusiness" runat="server" Visible="False"> Line of Business</asp:label>

                            <asp:dropdownlist id="ddlPolicyClass" runat="server" Width="232px" Visible="False"></asp:dropdownlist>
















                            <asp:literal id="litPopUp" VISIBLE="False" RUNAT="server"></asp:literal>
                            <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                        </div>
                    </div>
                </form>
            </body>

            </HTML>
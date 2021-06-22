<%@ Page language="c#" Inherits="EPolicy.ViewCommission" CodeFile="ViewCommission.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
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
                
                #Table12 {
                    width: 608px;
                }
            </style>
        </HEAD>
        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $("#effect").hide();
            $(function() {
                $('#<%= txtPaymentDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $('#<%= txtDepositDate.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });
            });

            function ShowDateTimePicker() {
                $('#<%= txtPaymentDate.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker2() {
                $('#<%= txtDepositDate.ClientID %>').datepicker('show');
            }

            $(function() {
                //run the currently selected effect
                function runEffect() {
                    //get effect type from 
                    //var selectedEffect = $('#effectTypes').val();
                    var selectedEffect = "blind";
                    //most effect types need no options passed by default
                    var options = {};
                    //run the effect
                    $("#effect").show(selectedEffect, options, 500, callback);
                };

                //callback function to bring a hidden box back
                function callback() {
                    //			setTimeout(function()
                    //			    {
                    //				    $("#effect:visible").removeAttr('style').hide().fadeOut();
                    //			    }, 
                    //			1000);
                };

                function CloseEffect() {
                    setTimeout(function() {
                            $("#effect:visible").removeAttr('style').hide().fadeOut();
                        },
                        10);
                }

                //set effect from select menu value
                $("#button").click(function() {
                    runEffect();
                    return false;
                });

                $("#btnRate").click(function() {
                    runEffect();
                    return false;
                });

                $("#btnCloseEffect").click(function() {
                    CloseEffect();
                    return false;
                });

                $("#effect").hide();
            });
        </script>

        <body>
            <form method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">

                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label1" runat="server">View Commissions:</asp:Label>
                            <asp:label id="LblTotalCases" RUNAT="server" Visible="False">Total Cases:</asp:label>
                            <asp:label id="LblCustomerName" RUNAT="server">Policy No:</asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="New" onclick="btnNew_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click" Visible="False"></asp:Button>
                            <asp:Button id="btnUpdate" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Update" onclick="btnUpdate_Click" Visible="False"></asp:Button>
                            <asp:Button id="btnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="btnSave_Click" Visible="False"></asp:Button>
                            <asp:Button id="btnClose" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="btnClose_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md-12">
                        <div class="col-md">
                        </div>
                        <div class="row mb-2">
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="lblAgent" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False" Visible="True">Agent:</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:DropDownList ID="ddlAgent" runat="server" cssclass="form-select mb-1" AutoPostBack="True" onselectedindexchanged="ddlAgent_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="Label44" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Policy Status:</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:label id="LblStatus" ENABLEVIEWSTATE="False" RUNAT="server" class="fs-lbl-s">Inforce/Paid</asp:label>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:Label id="LblAgentPercent" runat="server" class="fs-lbl-s">Agent Com. Percent</asp:Label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox id="TxtCommPercent" runat="server" cssclass="form-select fs-txt-s" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:Label id="LblAgentComm" runat="server" class="fs-lbl-s">Agent Com. Amount</asp:Label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox id="TxtCommAmt" runat="server" cssclass="form-select fs-txt-s" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:Label id="LblCheckAmount" runat="server" class="fs-lbl-s">Comission Amount Paid</asp:Label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox id="txtCheckAmount" runat="server" cssclass="form-select fs-txt-s" Enabled="False" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:Label id="LblBalance" runat="server" class="fs-lbl-s">Balance</asp:Label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox id="txtBalance" runat="server" cssclass="form-select fs-txt-s" Enabled="False" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-12">
                            <asp:Label id="lblAddNewComission" runat="server" class="mb-1">Add New Comission Payment:</asp:Label>
                        </div>
                        <div class="row">
                            <div class="col-md d-none">
                                <div class="col-md">
                                    <asp:Label ID="lblSelectedComissionPaymentID" runat="server" Text="0" Visible="False"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="LblPaymentDate" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Payment Date</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox ID="txtPaymentDate" runat="server" Columns="30" cssclass="form-control fs-txt-s fechaFormat" IsDate="True" onclick="ShowDateTimePicker();"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="Label17" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Payment Check</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox ID="TxtPaymentCheck" RUNAT="server" cssclass="form-control fs-txt-s" MAXLENGTH="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="Label18" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Payment Amount</asp:label>
                                </div>
                                <div class="col-md">
                                    <MaskedInput:MaskedTextBox ID="TxtPaymentAmount" runat="server" cssclass="form-control fs-txt-s" IsCurrency="True"></MaskedInput:MaskedTextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="Label14" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Agent Name</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox ID="TxtNamePayee" runat="server" cssclass="form-control fs-txt-s"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="Label19" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False">Debit / Credit</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:DropDownList ID="ddlCreditDebit" cssclass="form-select fs-txt-s" RUNAT="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md">
                                <div class="col-md">
                                    <asp:label id="Label20" RUNAT="server" class="fs-lbl-s" ENABLEVIEWSTATE="False"> Deposit Date</asp:label>
                                </div>
                                <div class="col-md">
                                    <asp:TextBox ID="txtDepositDate" runat="server" Columns="30" cssclass="form-control fs-txt-s fechaFormat" IsDate="True" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md">
                            <asp:Panel ID="pnlComissionPayment" runat="server" Visible="True">

                            </asp:Panel>

                            <asp:label id="Label3" Height="9px" RUNAT="server" class="fs-lbl-s" Visible="False">Total Cases:</asp:label>
                            <asp:Label id="LblError" runat="server" ForeColor="Red" Visible="False">Label</asp:Label>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <asp:datagrid id="searchIndividual" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Arial"
                            ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" WIDTH="795px" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#400000" OnItemCommand="searchIndividual_ItemCommand">
                            <FooterStyle BackColor="Navy"></FooterStyle>
                            <AlternatingItemStyle BackColor="#FEFBF6"></AlternatingItemStyle>
                            <ItemStyle HorizontalAlign="Center" Height="50px"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" Height="10px" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ComissionPaymentID" HeaderText="ComissionPaymentID">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CheckNumber" HeaderText="Check No.">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TransactionDate" HeaderText="Entry Date">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PaymentDate" HeaderText="Payment Date">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CreditDebitDesc" HeaderText="Credit/Debit">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DepositDate" HeaderText="Deposit Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Name" HeaderText="Name"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TransactionAmount" HeaderText="Transaction Amount" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Sel.">
                                </asp:ButtonColumn>
                                <asp:TemplateColumn HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this payment?');" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Left" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages" Height="15px"></PagerStyle>
                        </asp:datagrid>

                        <asp:datagrid id="searchIndividualOld" Height="306px" WIDTH="795px" RUNAT="server" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" PageSize="12" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
                            ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="#400000" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center"
                            Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Visible="False">
                            <FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
                            <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                            <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                            <AlternatingItemStyle HorizontalAlign="Center" BackColor="White"></AlternatingItemStyle>
                            <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" Height="10px" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="PolicyCommissionID" HeaderText="PolicyCommissionID">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CommissionLevel" HeaderText="Level">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AgentID" HeaderText="Agent ID">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AgentDesc" HeaderText="Agent">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CommissionDate" HeaderText="Commission Date">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CommissionAgentPercent" HeaderText="Comm. Percent">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CommissionAmount" HeaderText="Comm. Amount" DataFormatString="{0:c}">
                                    <ItemStyle></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CommissionAgent" HeaderText="Comm. Agent" DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ReturnCommissionAgent" HeaderText="Return Comm." DataFormatString="{0:c}">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                        </asp:datagrid>
                        <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                        <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                    </div>
            </form>
        </body>

        </HTML>
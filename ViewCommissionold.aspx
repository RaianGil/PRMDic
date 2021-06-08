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
                
                .headfield1 {
                    text-align: left;
                    margin-left: 0px;
                    margin-right: 0px;
                }
                
                .style1 {
                    width: 8px;
                }
                
                .style2 {}
                
                .style3 {
                    width: 198px;
                }
                
                .headForm1 {
                    margin-right: 2px;
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

        <body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF" topMargin="19" rightMargin="0">
            <form method="post" runat="server">
                <TABLE id="Table8" style="Z-INDEX: 113; LEFT: 4px; WIDTH: 914px; POSITION: static; TOP: 4px; HEIGHT: 483px" cellSpacing="0" cellPadding="0" width="914" align="center" bgColor="white" dataPageSize="25" border="0">
                    <TR>
                        <TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
                            <P>
                                <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                            </P>
                        </TD>
                    </TR>
                    <TR>
                        <TD style="FONT-SIZE: 10pt; WIDTH: 5px; POSITION: static; HEIGHT: 395px" align="right" colSpan="1" rowSpan="5" vAlign="top">
                            <P align="center">
                                <asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder>
                            </P>
                        </TD>
                        <TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
                            <P align="center">
                                <TABLE id="Table9" style="WIDTH: 811px; HEIGHT: 515px" cellSpacing="0" cellPadding="0" width="811" bgColor="white" border="0">
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
                                        <TD style="FONT-SIZE: 0pt; HEIGHT: 3px" align="right"></TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">
                                            <TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD align="left">
                                                        <asp:Label id="Label1" runat="server" Font-Names="Tahoma" CssClass="headForm1 " Width="162px" Height="16px" Font-Bold="True" ForeColor="Black" Font-Size="11pt">View Commissions:</asp:Label>
                                                        <asp:label id="LblTotalCases" RUNAT="server" WIDTH="148px" CSSCLASS="headform1" Height="9px" ForeColor="Black" Font-Names="Tahoma" Font-Size="9pt" Visible="False">Total Cases:</asp:label>
                                                        <asp:label id="LblCustomerName" RUNAT="server" WIDTH="196px" CSSCLASS="headform1" Height="9px" ForeColor="Black" Font-Names="Tahoma" Font-Size="9pt">Policy No:</asp:label>
                                                    </TD>
                                                    <TD class="style1">
                                                    </TD>
                                                    <TD align="right">
                                                        <asp:Button id="btnNew" runat="server" Font-Names="Tahoma" Width="60px" Height="23px" ForeColor="White" Text="New" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnNew_Click" style="margin-left: 0px; margin-right: 1px;"></asp:Button>
                                                        <asp:Button id="btnEdit" runat="server" Font-Names="Tahoma" Width="60px" Height="23px" ForeColor="White" Text="Edit" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnEdit_Click" style="margin-left: 0px; margin-right: 1px;" Visible="False"></asp:Button>
                                                        <asp:Button id="btnUpdate" runat="server" Font-Names="Tahoma" Width="60px" Height="23px" ForeColor="White" Text="Update" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnUpdate_Click" style="margin-left: 0px; margin-right: 1px;"
                                                            Visible="False"></asp:Button>
                                                        <asp:Button id="btnSave" runat="server" Font-Names="Tahoma" Width="60px" Height="23px" ForeColor="White" Text="Save" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnSave_Click" style="margin-left: 0px; margin-right: 1px;" Visible="False"></asp:Button>
                                                        <asp:Button id="btnClose" runat="server" Font-Names="Tahoma" Width="55px" Height="23px" ForeColor="White" Text="Exit" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="btnClose_Click"></asp:Button>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; HEIGHT: 5px">
                                            <TABLE id="Table11" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0" borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082" border="0">
                                                <TR>
                                                    <TD background="Images2/Barra3.jpg"></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="WIDTH: 112px; HEIGHT: 49px" vAlign="middle" align="center">
                                            <TABLE id="Table6" style="WIDTH: 806px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" width="806" border="0">
                                                <TR>
                                                    <TD style="FONT-SIZE: 1pt" align="center">
                                                        <TABLE id="Table3" style="WIDTH: 343px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" width="343" border="0">
                                                            <TR>
                                                                <TD>
                                                                    <asp:label id="lblAgent" RUNAT="server" HEIGHT="16px" WIDTH="131px" CSSCLASS="headfield1" ENABLEVIEWSTATE="False" Font-Size="9pt" Font-Names="Tahoma" Visible="False">Agent:</asp:label>
                                                                </TD>
                                                                <TD>
                                                                    <asp:DropDownList ID="ddlAgent" runat="server" AutoPostBack="True" Height="16px" onselectedindexchanged="ddlAgent_SelectedIndexChanged" Width="240px">
                                                                    </asp:DropDownList>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <asp:label id="Label44" RUNAT="server" HEIGHT="16px" WIDTH="131px" CSSCLASS="headfield1" ENABLEVIEWSTATE="False" Font-Size="9pt" Font-Names="Tahoma">Policy Status:</asp:label>
                                                                </TD>
                                                                <TD>
                                                                    <asp:label id="LblStatus" Font-Names="Tahoma" ENABLEVIEWSTATE="False" CSSCLASS="headfield1" WIDTH="71px" HEIGHT="16px" RUNAT="server" Font-Size="9pt">Inforce/Paid</asp:label>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <asp:Label id="LblAgentPercent" runat="server" Height="18px" Width="133px" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt">Agent Com. Percent</asp:Label>
                                                                </TD>
                                                                <TD>
                                                                    <asp:TextBox id="TxtCommPercent" runat="server" Height="19px" Width="108px" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Enabled="False"></asp:TextBox>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <asp:Label id="LblAgentComm" runat="server" Height="18px" Width="133px" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt">Agent Com. Amount</asp:Label>
                                                                </TD>
                                                                <TD>
                                                                    <asp:TextBox id="TxtCommAmt" runat="server" Height="19px" Width="108px" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Enabled="False"></asp:TextBox>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="style3">
                                                                </TD>
                                                                <TD class="style3">
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <asp:Label id="LblCheckAmount" runat="server" Height="18px" Width="154px" Font-Names="Tahoma" Font-Size="9pt">Comission Amount Paid</asp:Label>
                                                                </TD>
                                                                <TD>
                                                                    <asp:TextBox id="txtCheckAmount" runat="server" Height="19px" Width="108px" Font-Names="Tahoma" Font-Size="9pt" Enabled="False" ReadOnly="True"></asp:TextBox>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <asp:Label id="LblBalance" runat="server" Height="18px" Width="154px" Font-Names="Tahoma" Font-Size="9pt" Font-Bold="True">Balance</asp:Label>
                                                                </TD>
                                                                <TD>
                                                                    <asp:TextBox id="txtBalance" runat="server" Height="19px" Width="108px" Font-Names="Tahoma" Font-Size="9pt" Enabled="False" ReadOnly="True" style="font-weight: 700"></asp:TextBox>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                </TD>
                                                                <TD>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="WIDTH: 112px; HEIGHT: 49px" vAlign="middle" align="center">

                                            <asp:Panel ID="pnlComissionPayment" runat="server" Height="70px" Width="805px" Visible="True">
                                                <TABLE id="Table12" style="WIDTH: 805px; HEIGHT: 19px" cellSpacing="0" cellPadding="0" border="0" align="right">
                                                    <TR>
                                                        <TD colspan="6">
                                                            <asp:Label id="lblAddNewComission" runat="server" Font-Names="Tahoma" CssClass="headForm1 " Width="597px" Height="16px" Font-Bold="True" ForeColor="Black" Font-Size="11pt">Add New Comission Payment:</asp:Label>
                                                        </TD>
                                                    </TR>
                                                    <TR>
                                                        <TD>
                                                        </TD>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblSelectedComissionPaymentID" runat="server" Text="0" Visible="False"></asp:Label>
                                                        </td>
                                                    </TR>
                                                    <TR>
                                                        <TD class="style2">
                                                            <asp:label id="LblPaymentDate" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" ENABLEVIEWSTATE="False" HEIGHT="18" WIDTH="107px">Payment Date</asp:label>
                                                        </TD>
                                                        <td class="style2">
                                                            <asp:label id="Label17" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" ENABLEVIEWSTATE="False" HEIGHT="18" WIDTH="94px">Payment Check</asp:label>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:label id="Label18" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" ENABLEVIEWSTATE="False" HEIGHT="18" WIDTH="101px">Payment Amount</asp:label>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:label id="Label14" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" ENABLEVIEWSTATE="False" HEIGHT="18px" WIDTH="144px">Agent Name</asp:label>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:label id="Label19" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" WIDTH="87px" HEIGHT="18" ENABLEVIEWSTATE="False">Debit / Credit</asp:label>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:label id="Label20" Font-Size="9pt" Font-Names="Tahoma" RUNAT="server" WIDTH="77px" HEIGHT="18" ENABLEVIEWSTATE="False"> Deposit Date</asp:label>
                                                        </td>
                                                    </TR>
                                                    <TR>
                                                        <TD class="style2">
                                                            <asp:TextBox ID="txtPaymentDate" runat="server" Columns="30" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" onclick="ShowDateTimePicker();" TabIndex="1" Width="79px"></asp:TextBox>
                                                        </TD>
                                                        <td class="style2">
                                                            <asp:TextBox ID="TxtPaymentCheck" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt" HEIGHT="19px" MAXLENGTH="50" tabIndex="2" WIDTH="111px"></asp:TextBox>
                                                        </td>
                                                        <td class="style2">
                                                            <MaskedInput:MaskedTextBox ID="TxtPaymentAmount" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="19px" IsCurrency="True" tabIndex="3" Width="94px"></MaskedInput:MaskedTextBox>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:TextBox ID="TxtNamePayee" runat="server" Height="19px" style="margin-left: 1px; margin-right: 1px" TabIndex="4" Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:DropDownList ID="ddlCreditDebit" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt" HEIGHT="21px" style="margin-left: 1px; margin-right: 1px" tabIndex="5" WIDTH="85px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="style2">
                                                            <asp:TextBox ID="txtDepositDate" runat="server" Columns="30" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" onclick="ShowDateTimePicker2();" TabIndex="5" Width="79px"></asp:TextBox>
                                                        </td>
                                                    </TR>
                                                    <TR>
                                                        <TD>
                                                        </TD>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </TR>
                                                </TABLE>
                                            </asp:Panel>

                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 10pt; WIDTH: 112px; HEIGHT: 3px" align="left" colSpan="1">
                                            <asp:label id="Label3" Font-Names="Tahoma" Height="9px" ForeColor="Black" CSSCLASS="headform3" WIDTH="223px" RUNAT="server" Visible="False">Total Cases:</asp:label>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 3px">
                                            <TABLE id="Table2" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0" borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082" border="0">
                                                <TR>
                                                    <TD background="Images2/Barra3.jpg"></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 18px" align="center">
                                            <asp:Label id="LblError" runat="server" Font-Names="Tahoma" Width="795px" ForeColor="Red" Font-Size="11pt" Visible="False">Label</asp:Label>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 18px" align="center">
                                            <asp:datagrid id="searchIndividual" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Arial"
                                                FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" WIDTH="795px" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#400000"
                                                OnItemCommand="searchIndividual_ItemCommand">
                                                <FooterStyle BackColor="Navy"></FooterStyle>
                                                <AlternatingItemStyle CssClass="HeadForm3" BackColor="#FEFBF6"></AlternatingItemStyle>
                                                <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" Height="50px"></ItemStyle>
                                                <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                                <Columns>
                                                    <asp:BoundColumn Visible="False" DataField="ComissionPaymentID" HeaderText="ComissionPaymentID">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CheckNumber" HeaderText="Check No.">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TransactionDate" HeaderText="Entry Date">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PaymentDate" HeaderText="Payment Date">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CreditDebitDesc" HeaderText="Credit/Debit">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="DepositDate" HeaderText="Deposit Date"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Name" HeaderText="Name"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TransactionAmount" HeaderText="Transaction Amount" DataFormatString="{0:c}">
                                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundColumn>
                                                    <asp:ButtonColumn ButtonType="PushButton" CommandName="Edit" HeaderText="Sel.">
                                                    </asp:ButtonColumn>
                                                    <asp:TemplateColumn HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete" runat="server" Text="" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this payment?');" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages" Height="15px"></PagerStyle>
                                            </asp:datagrid>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 25px" align="center">
                                            <P align="center">

                                                <asp:datagrid id="searchIndividualOld" Height="306px" WIDTH="795px" RUNAT="server" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" PageSize="12" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
                                                    ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Tahoma" FONT-SIZE="9pt" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="#400000" HEADERSTYLE-HORIZONTALALIGN="Center"
                                                    ITEMSTYLE-HORIZONTALALIGN="center" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Visible="False">
                                                    <FooterStyle Font-Names="tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
                                                    <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                                                    <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                                                    <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                                                    <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                                                    <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                                    <Columns>
                                                        <asp:BoundColumn Visible="False" DataField="PolicyCommissionID" HeaderText="PolicyCommissionID">
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CommissionLevel" HeaderText="Level">
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="AgentID" HeaderText="Agent ID">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="AgentDesc" HeaderText="Agent">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CommissionDate" HeaderText="Commission Date">
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CommissionAgentPercent" HeaderText="Comm. Percent">
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CommissionAmount" HeaderText="Comm. Amount" DataFormatString="{0:c}">
                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CommissionAgent" HeaderText="Comm. Agent" DataFormatString="{0:c}">
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ReturnCommissionAgent" HeaderText="Return Comm." DataFormatString="{0:c}">
                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundColumn>
                                                    </Columns>
                                                    <PagerStyle Font-Names="tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                                </asp:datagrid>
                                            </P>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD style="FONT-SIZE: 0pt; WIDTH: 35px">
                                            <P></P>
                                            <P align="center"></P>
                                        </TD>
                                    </TR>
                                </TABLE>
                            </P>
                            <P></P>
                        </TD>
                    </TR>
                </TABLE>
                <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
            </form>
        </body>

        </HTML>
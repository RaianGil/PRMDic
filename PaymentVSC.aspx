<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentVSC.aspx.cs" Inherits="PaymentVSC" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
            <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

            <html xmlns="http://www.w3.org/1999/xhtml">

            <head runat="server">
                <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
                <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
                <meta http-equiv="X-UA-Compatible" content="IE=edge" />
                <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" />
                <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
                <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                <script src="js/load.js" type="text/javascript"></script>
                <script type="text/javascript">
                    $(document).ready(function() {
                        $('#gdVscQuote').dataTable({
                            "lengthMenu": [
                                [10, 25, 50, -1],
                                [10, 25, 50, "All"]
                            ]
                        });
                    });
                </script>
                <style type="text/css">
                    .modalBackground {
                        background-color: Gray;
                        filter: alpha(opacity=50);
                        opacity: 0.5;
                    }
                    
                    body {
                        margin: 0;
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
                    
                    .btn-w-150 {
                        width: 150px;
                        height: 35px;
                    }
                </style>
            </head>
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script type="text/javascript">
                $(function() {
                    $('#<%= TxtPaymentDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });

                    $('#<%= txtDepositDate.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                });
            </script>

            <body>
                <form id="form1" method="post" runat="server">
                    <p>
                        <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                    </p>
                    <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">

                        <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="900">
                        </Toolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
                            <ContentTemplate>

                                <!-- Contenido copiado -->

                                <div class="ia-center">
                                    <img alt="" src="Images2/payment-icon.png" />
                                </div>
                                <div class="ia-center">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Bold="True" ForeColor="#3B3B3B" CssClass=" " Height="9px" Width="45px" Font-Size="18pt">Payment Express</asp:Label>
                                </div>
                                <div class="ia-center">
                                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn-bg-theme1 btn-w-150 btn" OnClick="btnClear_Click"></asp:Button>
                                    <asp:Button ID="BtnExit" runat="server" Text="Exit" class="btn-bg-theme1 btn-w-150 btn" OnClick="BtnExit_Click1" Style="margin-left: 10px"></asp:Button>
                                </div>
                                <div class="ia-center">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="10">
                                        <ProgressTemplate>
                                            <img alt="" src="Images2/loader.gif" style="width: 35px; height: 35px;" />
                                            <span><span class=""></span><span style="font-family: Tahoma; font-size: 14pt; color: #BA354E">
                                            <strong>Please wait...</strong></span></span>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>

                                <div class="col-md-12">
                                    <hr />
                                </div>

                                <!-- /Termina contenido copiado -->
                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblGender" runat="server" CssClass="txt-xl" EnableViewState="False">Policy Type</asp:Label>
                                        <asp:TextBox ID="TxtPolicyType" runat="server" CssClass="form-control txt-xl" MaxLength="3" TabIndex="1"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="Label4" runat="server" CssClass="txt-xl" EnableViewState="False">Suffix</asp:Label>
                                        <asp:TextBox ID="TxtSuffix" runat="server" CssClass="form-control txt-xl" MaxLength="3" TabIndex="2"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="LblPaymentDate" runat="server" CssClass="txt-xl" EnableViewState="False">Payment Date</asp:Label>
                                        <asp:TextBox ID="TxtPaymentDate" runat="server" CssClass="form-control txt-xl fechaFormat" IsDate="True" TabIndex="3"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="Label17" runat="server" CssClass="txt-xl" EnableViewState="False">Payment Check</asp:Label>
                                        <asp:TextBox ID="TxtPaymentCheck" runat="server" CssClass="form-control txt-xl" MaxLength="50" TabIndex="5"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="Label19" runat="server" CssClass="txt-xl" EnableViewState="False">Debit / Credit</asp:Label>
                                        <asp:DropDownList ID="ddlCreditDebit" runat="server" runat="server" CssClass="form-control txt-xl" TabIndex="6">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="Label20" runat="server" CssClass="txt-xl" EnableViewState="False"> Deposit Date</asp:Label>
                                        <asp:TextBox ID="txtDepositDate" runat="server" CssClass="form-control txt-xl fechaFormat" IsDate="True" TabIndex="7"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12 f-op-10">
                                    <hr />
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblLastName2" runat="server" CssClass="txt-xl" EnableViewState="False">Policy No.</asp:Label>
                                        <div class="input-group">
                                            <asp:TextBox ID="txtPolicyNo" runat="server" CssClass="form-control txt-xl" style="display: inline;" MaxLength="10" TabIndex="9"></asp:TextBox>
                                            <asp:Button ID="btnSearch" class="input-group-text" runat="server" Text="..." OnClick="btnSearch_Click" />
                                        </div>

                                    </div>
                                    <div class="col">
                                        <asp:Label ID="Label2" runat="server" CssClass="" EnableViewState="False">Name</asp:Label>
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control txt-xl" style="display: inline;" MaxLength="50" TabIndex="5"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="Label18" runat="server" CssClass="" EnableViewState="False">Payment Amount</asp:Label>
                                        <asp:TextBox ID="TxtPaymentAmount" runat="server" CssClass="form-control txt-xl" style="display: inline;" IsCurrency="True" TabIndex="10"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:Label runat="server" class="f-op-0" EnableViewState="False">______________</asp:Label>
                                        <asp:Button ID="BtnSave" runat="server" Font-Names="Tahoma" OnClick="Button6_Click" Text="Apply" TabIndex="11" class="btn-bg-theme1 btn btn-r-4 btn-w-150" />
                                    </div>
                                </div>


                                </td>
                                <td align="left" colspan="1" style="height: 10px;">
                                    <asp:TextBox ID="txtTCIDPolicy" runat="server" Font-Names="Tahoma" Font-Size="9pt" Visible="False" Width="73px"></asp:TextBox>
                                </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="6">
                                        <asp:Label ID="lblNotFound" runat="server" Font-Names="tahoma" Font-Size="9pt" ForeColor="Red" Text="Policy No. not found !" Visible="False" Width="136px"></asp:Label>
                                    </td>
                                </tr>

                                <div class="col-md-12">
                                    <hr />
                                </div>

                                <div class="ia-center">
                                    <asp:Label ID="Label5" runat="server" CssClass="txt-xl" EnableViewState="False" style="display: inline;">Total Payment:</asp:Label>
                                    <asp:TextBox ID="txtTotalPayment" runat="server" CssClass="form-control" Font-Names="Tahoma" Width="250px" style="display: inline;" Font-Size="11pt" IsCurrency="True" OnTextChanged="txtTotalPayment_TextChanged" TabIndex="10"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <hr />
                                </div>
                                <div class="col-md-6">
                                    <asp:Panel ID="pnlInfo" runat="server" Width="100%" Visible="false">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:Label ID="lblContractnNo" runat="server" CssClass="txt-s" Height="19px" Width="76px">Policy No.</asp:Label>
                                                <asp:TextBox ID="TxtContractNo" runat="server" CssClass="form-control txt-xl" MaxLength="15" ReadOnly="True" TabIndex="1" />
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button ID="btnClose" runat="server" class="btn-bg-theme1 btn btn-r-4" OnClick="btnClose_Click" TabIndex="6" Text="X" ToolTip="Close" />
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <asp:Label ID="lblCustomerName" runat="server" CssClass="txt-s">Customer</asp:Label>
                                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control txt-xl" MaxLength="15" ReadOnly="True" TabIndex="3"></asp:TextBox>
                                        </div>

                                        <div class="col-md-6">
                                            <asp:Label ID="lblTotalPrice" runat="server" CssClass="txt-s">Total Price</asp:Label>
                                            <asp:TextBox ID="TxtTotalPrice" runat="server" Font-Bold="True" CssClass="form-control txt-xl" MaxLength="15" ReadOnly="True" TabIndex="3"></asp:TextBox>
                                        </div>
                                </div>
                                </asp:Panel>
                                <div class="col-md-12 f-op-10">
                                    <hr />
                                </div>
                                <div class="col-md-12">
                                    <asp:DataGrid ID="gdVscQuote" style="padding-left:20px; padding-right:20px" class="table table-bordered table-condensed table-hover" RUNAT="server" PageSize="8" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False">
                                        <HeaderStyle HorizontalAlign="Center" Height="30px" ForeColor="White" CssClass="HeadForm2" BackColor="#0c63b0" />
                                        <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundColumn DataField="TaskControlID" HeaderText="Control ID">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="TotalPaid" HeaderText="Total Paid">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PaymentApplied" HeaderText="Applied?">
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Left" Height="30px" ForeColor="White" BackColor="#0c63b0" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid><br />
                                    </td>
                                    </tr>
                                </div>
                                <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>
                                <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </form>
            </body>

            </html>
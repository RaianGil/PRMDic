<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LPManager.aspx.cs" Inherits="LPManager" %>

    <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

        <html xmlns="http://www.w3.org/1999/xhtml">

        <head id="Head1" runat="server">
            <title>File Upload</title>
            <script>
                function validatePage() {
                    flagProcessing = true;
                }

                function disableBotonPagar() {
                    var boton = document.getElementById('btnPagar2');
                    if (boton != null) {
                        boton.style.visibility = 'hidden';
                        //document.TransactionPrepaid.TxtNumRef.value = ""; 
                    }
                }
            </script>
            <style type="text/css">

            </style>
        </head>


        <body>
            <form id="form1" runat="server" enctype="multipart/form-data">
                <asp:updatepanel id="UpdatePanel1" runat="server">
                    <contenttemplate>

                        <p>
                            <asp:PlaceHolder ID="phTopBanner" runat="server"></asp:PlaceHolder>
                        </p>
                        <div class="container-xl mb-4 p-18">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>

                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label46" runat="server">Payment File Import:</asp:Label>
                                </div>
                                <div class="col-md-6 f-right">
                                    <asp:button id="btnImportPayment" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Import Payments" onclick="btnImportPayment_Click" Visible="False"></asp:button>
                                    <asp:Button ID="Button2" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="Button2_Click1" Text="Select All" />
                                    <asp:Button ID="Button1" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="Button1_Click1" Text="Deselect All" />
                                    <asp:button id="btnReapply" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Re-Apply" onclick="btnReapply_Click" onclientclick="return confirm('Are you sure you want to re-apply the selected payments?')"></asp:button>
                                    <asp:Button ID="btnDelete" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnDelete_Click" onclientclick="return confirm('Areyou sure you want to delete the selected payments?')" Text="Delete" Visible="False" />
                                    <asp:Button ID="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnPrint_Click" Text="Print" Visible="False" />
                                    <asp:button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:button>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <hr>
                            </div>
                            <asp:Panel ID="pnlLPManager" runat="server" Visible="true">
                                <div class="col-md-12">
                                    <asp:Label ID="lblError" runat="server" Text="No data to delete." Visible="False"></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:DataGrid ID="dtLossPaymentManager" runat="server" class="table table-bordered table-condensed table-hover " Width="100%" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" AlternatingRowStyle-BackColor="White" Height="193px"
                                        OnItemCommand="dtLossPaymentManager_ItemCommand" PageSize="8" TabIndex="9">
                                        <Columns>
                                            <asp:ButtonColumn HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." ButtonType="PushButton" CommandName="Select">
                                                <HeaderStyle Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:ButtonColumn>
                                            <asp:BoundColumn DataField="PaymentDate" HeaderText="Payment Date">
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PaymentCheck" HeaderText="Payment Check">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PaymentAmount" DataFormatString="{0:c}" HeaderText="Payment Amount">
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle Font-Names="Tahoma" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Name" HeaderText="Name">
                                                <HeaderStyle Width="250px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="DepositDate" HeaderText="Deposit Date">
                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="75px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                                <HeaderStyle Width="100px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="EffectiveYear" HeaderText="Effec. Year">
                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="90px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="UserDesc" HeaderText="Entered by">
                                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" Width="125px" />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="EntryDate" HeaderText="Entry Date">
                                                <HeaderStyle />
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="PaymentImportID" HeaderText="PaymentImportID">
                                            </asp:BoundColumn>

                                        </Columns>
                                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                        <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                                    </asp:DataGrid>
                                </div>

                                <rsweb:ReportViewer ID="ReportViewer2" runat="server" AsyncRendering="False" Height="501px" Width="860px"> </rsweb:ReportViewer>

                                </caption>

                            </asp:Panel>
                            <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                    </contenttemplate>
                </asp:updatepanel>
                </div>
            </form>
        </body>

        </html>
<%@ Page language="c#" Inherits="EPolicy.UploadSS" CodeFile="UploadSS.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <head>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0" />
            <meta name="CODE_LANGUAGE" Content="C#" />
            <meta name="vs_defaultClientScript" content="JavaScript" />
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
            <link href="epolicy.css" type="text/css" rel="stylesheet" />
        </head>

        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script type="text/javascript">
            $(function() {
                $('#<%= txtFrom.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

                $('#<%= txtTo.ClientID %>').datepicker({
                    changeMonth: true,
                    changeYear: true
                });

            });

            function ShowDateTimePicker() {
                $('#<%= txtFrom.ClientID %>').datepicker('show');
            }

            function ShowDateTimePicker2() {
                $('#<%= txtTo.ClientID %>').datepicker('show');
            }
        </script>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUpload" />
        </Triggers>

        <body>
            <form method="post" runat="server">


                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">

                    <div class="col-md-12 f-center">
                        <img alt="" src="Images2/UploadFile.jpg" class="searchImage" style="margin-bottom: 25px;" />
                    </div>
                    <div class="col-md-12 fs-14 fw-bold mb-1 f-center">
                        <asp:Label id="LblUpload" runat="server">Upload</asp:Label>
                    </div>
                    <div class="col-md-12 f-center">
                        <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="col-md-12 f-center">
                        <div class="col-md-12">
                            <asp:Label id="Label1" class="fs-lbl-s mb-1" runat="server">Please input and verify the password:</asp:Label>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-1">
                                <asp:TextBox ID="txtPassWord" runat="server" class="form-control" Visible="true" autocompletetype="Disabled" autocomplete="Off"></asp:TextBox>
                                <asp:Button id="BtnCheckPassword" runat="server" class="input-group-text" Text="Verify" Visible="true" onclick="BtnCheckPassword_Click"></asp:Button>
                            </div>


                            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <fieldset>
                                                <legend>UpdatePanel</legend>
                                                <asp:Label ID="Label2" runat="server" Text="Initial page rendered."></asp:Label><br />
                                                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                                                </fieldset>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
                                            <ProgressTemplate>
                                                Processing...
                                             <img alt="" src="Images2/loader.gif" style="width: 80px; height: 16px" /></td>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>--%>

                                <div class="input-group mb-1">
                                    <asp:FileUpload ID="FileUpload1" cssclass="form-control" runat="server" Visible="true" Enabled="false" />

                                    <asp:Button id="BtnUpload" runat="server" cssclass="input-group-text" Text="Upload" onclick="BtnUpload_Click" Enabled="false"></asp:Button>
                                </div>

                                <asp:Button id="BtnDownloadCustomer840Info" runat="server" Text="Download Customer Info" Visible="true" cssclass="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Enabled="false" onclick="BtnDownloadCustomer840Info_Click"></asp:Button>


                                <asp:Button id="BtnDownloadCustomer840Info2020" runat="server" Text="Download 480 2020 Info" Visible="true" cssclass="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Enabled="false" onclick="BtnDownloadCustomer840Info2020_Click"></asp:Button>

                                <div class="col-md-12">
                                    <div class="input-group">
                                        <asp:Label id="Label2" runat="server" class="input-group-text" Visible="false">From:</asp:Label>
                                        <asp:TextBox ID="txtFrom" runat="server" class="form-control" Visible="false" autocompletetype="Disabled" autocomplete="Off" onclick="ShowDateTimePicker();"></asp:TextBox>

                                        <asp:Label id="Label3" runat="server" class="input-group-text" Visible="false">To:</asp:Label>
                                        <asp:TextBox ID="txtTo" runat="server" class="form-control" Visible="false" autocompletetype="Disabled" autocomplete="Off" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                    </div>
                                </div>
                        </div>
                    </div>
                    <div style="display:none;">


                        <asp:TextBox ID="txtInupt" runat="server" Visible="true"></asp:TextBox>


                        <asp:Button id="BtnEncrypt" runat="server" Text="Encrypt" Visible="true" onclick="BtnEncryptAndDecrypt_Click"></asp:Button>

                        <asp:Button id="BtnDecrypt" runat="server" Text="Decrypt" Visible="true" onclick="BtnEncryptAndDecrypt_Click"></asp:Button>


                        <asp:TextBox ID="txtResult" runat="server" Visible="true"></asp:TextBox>


                    </div>

                    <asp:Label id="LblTotalCases" runat="server" Visible="false">Total Cases: </asp:Label>


                    <asp:datagrid id="DGAnalisys" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Tahoma"
                        FONT-SIZE="Smaller" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" PageSize="16"
                        WIDTH="802px" Height="20px">
                        <Columns>
                            <asp:BoundColumn DataField="GrossTotal" HeaderText="Gross Total">
                                <ItemStyle Font-Names="Tahoma"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TrashInfo" HeaderText="Trash Info">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ActualTotal" HeaderText="Actual Total">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TotalUpdated" HeaderText="Total Updated">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PersonalSSUpdated" HeaderText="Personal SS Updated">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PatronSSUpdated" HeaderText="Patron SS Updated">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TotalNotUpdated" HeaderText="Total Not Updated">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="SSEmpty" HeaderText="SS Empty">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CustomerNotFound" HeaderText="Customer Not Found">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CustomerNotFoundAndSSEmpty" HeaderText="Customer Not Found And SS Empty">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                    </asp:datagrid>


                    <asp:datagrid id="DGErrorCases" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Tahoma"
                        FONT-SIZE="Smaller" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" PageSize="16"
                        WIDTH="802px" Height="20px">
                        <FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
                        <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                        <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                        <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                        <HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                        <Columns>

                            <asp:BoundColumn DataField="CUSTOMERNUMBER" HeaderText="Customer Number">
                                <ItemStyle Font-Names="Tahoma"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TYPE" HeaderText="Error Reason">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>

                        </Columns>
                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                    </asp:datagrid>


                    <asp:Button id="BtnExportResult" runat="server" Text="Export Errors" Visible="false" onclick="BtnExportResult_Click"></asp:Button>

                    <asp:Button id="BtnExportUpdatedResult" runat="server" Text="Export Updated Cases" Visible="false" onclick="BtnExportUpdatedResult_Click"></asp:Button>


                    <asp:datagrid id="DGSocSec" RUNAT="server" ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0" FONT-NAMES="Tahoma"
                        FONT-SIZE="Smaller" ALLOWPAGING="True" AUTOGENERATECOLUMNS="False" BACKCOLOR="White" HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA" BORDERWIDTH="1px" BORDERSTYLE="Solid" PageSize="16"
                        WIDTH="802px" Height="408px">
                        <FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
                        <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                        <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                        <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                        <HeaderStyle Font-Names="Tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                        <Columns>
                            <%--<asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select"></asp:ButtonColumn>--%>
                                <asp:BoundColumn DataField="SECCIONATIPODEID" HeaderText="SS Type">
                                    <HeaderStyle Width="150px"></HeaderStyle>
                                    <ItemStyle Font-Names="Tahoma"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CUSTOMERNUMBER" HeaderText="Customer Number">
                                    <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="NUMERODEIDENTIFICACIONPATRONALOSEGUROSOCIAL" HeaderText="SS">
                                    <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                    </asp:datagrid>


                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
                    <asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
                </div>
            </form>
        </body>

        </HTML>
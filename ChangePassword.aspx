<%@ Page language="c#" Inherits="EPolicy.ChangePassword" CodeFile="ChangePassword.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label9" runat="server">Search Prospect: </asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="f-center">
                        <div class="col-md-5">
                            <asp:label id="lblRequiredLastName1" FORECOLOR="Red" RUNAT="server">*</asp:label>

                            <asp:label id="Label2" RUNAT="server" ENABLEVIEWSTATE="False">User Name</asp:label>

                            <asp:textbox id="TxtUserName" runat="server" class="form-control" MaxLength="50"></asp:textbox>

                            <asp:label id="Label6" RUNAT="server" FORECOLOR="Red">*</asp:label>

                            <asp:label id="Label1" RUNAT="server" ENABLEVIEWSTATE="False">Old Password</asp:label>

                            <asp:textbox id="TxtPassword" runat="server" class="form-control" MaxLength="10" TextMode="Password"></asp:textbox>

                            <asp:Label id="Label5" runat="server"></asp:Label>

                            <asp:label id="Label7" RUNAT="server" FORECOLOR="Red">*</asp:label>

                            <asp:label id="Label3" RUNAT="server" ENABLEVIEWSTATE="False">New Password</asp:label>

                            <asp:textbox id="TxtNewPassword" RUNAT="server" class="form-control" TextMode="Password" MAXLENGTH="10"></asp:textbox>

                            <asp:label id="Label8" FORECOLOR="Red" RUNAT="server">*</asp:label>

                            <asp:label id="Label4" RUNAT="server" ENABLEVIEWSTATE="False">Confirm Password</asp:label>

                            <asp:textbox id="TxtConfirmPassword" RUNAT="server" class="form-control" TextMode="Password" MAXLENGTH="10"></asp:textbox>
                        </div>
                    </div>
                    <asp:label id="LblTotalCases" RUNAT="server">Total Cases:</asp:label>

                    <asp:Label id="LblError" runat="server" Visible="False">Label</asp:Label>
                    <div class="col-md-12">
                        <hr>
                    </div>




                    <asp:datagrid id="searchIndividual" RUNAT="server" WIDTH="802px" Height="104px" Visible="False" BORDERSTYLE="Solid" BORDERWIDTH="1px" BORDERCOLOR="#D6E3EA" ITEMSTYLE-HORIZONTALALIGN="center" HEADERSTYLE-HORIZONTALALIGN="Center" BACKCOLOR="White" AUTOGENERATECOLUMNS="False"
                        ALLOWPAGING="True" FONT-SIZE="Smaller" FONT-NAMES="Arial" CELLPADDING="0" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" HEADERSTYLE-CSSCLASS="HeadForm2" HEADERSTYLE-BACKCOLOR="#5C8BAE" ITEMSTYLE-CSSCLASS="HeadForm3">
                        <SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
                        <EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
                        <AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></AlternatingItemStyle>
                        <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
                        <HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" CssClass="HeadForm2" BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                        <FooterStyle Font-Names="Tahoma" ForeColor="#003399" BackColor="Navy"></FooterStyle>
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" HeaderText="Sel." CommandName="Select">
                                <ItemStyle Font-Names="Tahoma"></ItemStyle>
                            </asp:ButtonColumn>
                            <asp:BoundColumn DataField="prospectID" HeaderText="Prospect ID">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="firstName" HeaderText="First Name">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="lastName1" HeaderText="Last Name1">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="lastName2" HeaderText="Last Name2">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="homePhone" HeaderText="Home Phone">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="workPhone" HeaderText="Work Phone">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="cellular" HeaderText="Cellular">
                                <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="email" HeaderText="E-mail">
                                <ItemStyle Font-Names="Tahoma"></ItemStyle>
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
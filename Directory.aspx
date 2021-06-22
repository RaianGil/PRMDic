<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Directory.aspx.cs" Inherits="Directory" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

        <html xmlns="http://www.w3.org/1999/xhtml">

        <head runat="server">
            <title>ePMS | electronic Policy Manager Solution</title>
        </head>

        <body>
            <form id="form1" runat="server">


                <p>
                    <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="Label46" runat="server">Directory:</asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button ID="btnDelete" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnDelete_Click" Text="Delete" />
                            <asp:Button ID="btnAdd2" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnAdd2_Click" Text="Add" Visible="False" />
                            <asp:Button ID="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnEdit_Click" Text="Modify" />
                            <asp:Button ID="btnCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnCancel_Click" Text="Cancel" />
                            <asp:Button ID="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="BtnExit_Click" Text="Exit" />
                            <asp:Button ID="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" OnClick="BtnSave_Click" Text="Save" />
                            <asp:ListBox ID="ListBox1" runat="server" class="btn-h-30 form-select">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:ListBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>
                    <div class="f-center">
                        <div class="col-md-10">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label17" runat="server">Salutation:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtSalutation" runat="server" class="form-control" MaxLength="5"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label5" runat="server">First Name:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtFirstName" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="lblLastName1" runat="server">Last Name 1:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtLastname1" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label6" runat="server">Title:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtTitle" runat="server" class="form-control" MaxLength="20"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label12" runat="server">Specialty:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlSpecialty" runat="server" class="form-select">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label9" runat="server">Phone 1:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="TxtPhone1" runat="server" class="form-control telefoneFormat" IsDate="False" Mask="(999) 999-9999"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label14" runat="server">Ext:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtExt" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label10" runat="server">Phone 2:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <MaskedInput:MaskedTextBox ID="txtPhone2" runat="server" class="form-control telefoneFormat" IsDate="False" Mask="(999) 999-9999" MaxLength="20"></MaskedInput:MaskedTextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label11" runat="server">Email:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label1" runat="server">Location:</asp:Label>
                                        </div>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlLocation" runat="server" class="form-select"></asp:DropDownList>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row mb-1">
                                    <div class="col-md-1">
                                        <asp:Label ID="Label2" runat="server">Comments:</asp:Label>
                                    </div>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtComments" runat="server" class="form-control h-7" MaxLength="500"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label7" runat="server">Physical Address</asp:Label>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">Address 1</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtAdds1" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">Address 2</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtAdds2" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">City</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlCiudad" class="form-select" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">Zip Code</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtState" runat="server" class="form-control" MaxLength="2"></asp:TextBox>
                                            <asp:TextBox ID="txtZip" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12 mb-1">
                                        <asp:Label ID="Label8" runat="server">Postal Address</asp:Label>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">Address 1</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPostalAdds1" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">Address 2</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPostalAdds2" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">City</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlCiudad3" runat="server" class="form-select">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row mb-1">
                                        <div class="col-md-4">
                                            <asp:Label runat="server">Zip Code</asp:Label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtPostalState" runat="server" class="form-control" MaxLength="2"></asp:TextBox>
                                            <asp:TextBox ID="txtPostalZip" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <div class="col-md-5">
                            <div class="col-md-12">
                                <asp:Label ID="lblCity" runat="server" EnableViewState="False">City:</asp:Label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCiudad2" runat="server" class="form-select">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearch" runat="server" class="input-group-text" OnClick="btnSearch_Click" Text="Search" />
                                </div>
                                <asp:Label ID="lblLocation" runat="server" EnableViewState="False">Location:</asp:Label>
                                <asp:DropDownList ID="ddlLocation2" runat="server" class="form-select">
                                </asp:DropDownList>

                                <asp:Label ID="lblSpecialty" runat="server" EnableViewState="False">Specialty:</asp:Label>
                                <asp:DropDownList ID="ddlSpecialty2" runat="server" class="form-select">
                                </asp:DropDownList>

                                <asp:Label ID="lblFirstName" runat="server" EnableViewState="False">First Name:</asp:Label>
                                <asp:TextBox ID="TxtSearchFirstName" runat="server" class="form-control" MaxLength="50"></asp:TextBox>

                                <asp:Label ID="lblLastName" runat="server" EnableViewState="False">Last Name:</asp:Label>
                                <asp:TextBox ID="txtSearchLastName" runat="server" class="form-control mb-1" MaxLength="50"></asp:TextBox>

                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Check All" />
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Uncheck All" />
                                <asp:Button ID="btnMessages" runat="server" OnClick="btnMessages_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Message" />
                            </div>
                        </div>
                    </div>











                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-8"></div>
                    </div>


























                    <asp:Panel ID="pnlMessage" runat="server" Visible="False">

                        <asp:Label ID="Label3" runat="server" Text="Subject:"></asp:Label>
                        <asp:TextBox ID="TxtSubject" runat="server"></asp:TextBox>

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="X" ToolTip="Close" />

                        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>

                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Send Email" />

                    </asp:Panel>


                    <asp:Label ID="LblTotalCases" runat="server">Total Cases:</asp:Label>
                    <asp:Label ID="LblError" runat="server" Visible="False">Label</asp:Label>
                    <div class="col-md-12">
                        <hr>
                    </div>
                    <asp:DataGrid ID="searchDirectory" runat="server" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" CellPadding="0"
                        Font-Names="Arial" Font-Size="8pt" ForeColor="Black" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" HeaderStyle-HorizontalAlign="Center" Height="118px" ItemStyle-CssClass="HeadForm3" ItemStyle-HorizontalAlign="center"
                        OnItemCommand="searchDirectory_ItemCommand" PageSize="9" Width="808px">
                        <FooterStyle BackColor="Navy" Font-Names="tahoma" ForeColor="Black" />
                        <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                        <AlternatingItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                        <ItemStyle BackColor="White" CssClass="HeadForm3" HorizontalAlign="Center" />
                        <Columns>
                            <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                <ItemStyle Font-Names="tahoma" />
                            </asp:ButtonColumn>
                            <asp:BoundColumn DataField="DirectorioID" HeaderText="DirectorioyID" Visible="False">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FirstName" DataFormatString="{0:d}" HeaderText="Name">
                                <ItemStyle Font-Names="tahoma" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LastName" HeaderText="Last Name">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LocationMedDesc" HeaderText="Location">
                                <ItemStyle Font-Names="tahoma" HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Address" HeaderText="City">
                                <HeaderStyle Width="200px" />
                                <ItemStyle Font-Names="tahoma" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Phone1" HeaderText="Phone 1" Visible="False">
                                <ItemStyle Font-Names="tahoma" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Phone2" HeaderText="Phone 2" Visible="False">
                                <ItemStyle Font-Names="tahoma" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PRMEDICSpecialtyDesc" HeaderText="Specialty"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="email">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="email" HeaderText="emailText" Visible="False"></asp:BoundColumn>
                        </Columns>
                        <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" HorizontalAlign="Center" />
                    </asp:DataGrid>

                </div>
                <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1" style="z-index: 145; left: 620px; width: 35px; position: absolute; top: 8px;
            height: 22px" type="hidden" value="false" />
            </form>
        </body>

        </html>
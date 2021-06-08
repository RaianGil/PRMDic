<%@ Page Language="c#" Inherits="EPolicy.UsersProperties" CodeFile="UsersProperties.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
    <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
    <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

    <script src="js/load.js" type="text/javascript"></script>

    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.5;
        }
    </style>
</head>
<body>
    <div class="middleMain">
        <form id="Form1" method="post" runat="server">
        <p>
            <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
        </p>
        <table id="Table8" style="z-index: 153; width: 68%;" cellspacing="0" cellpadding="0"
            align="center" bgcolor="white" datapagesize="25" border="0">
            <tr>
                <td align="center">
                    <table id="Table9" style="width: 100%;" cellspacing="0" cellpadding="0" bgcolor="white"
                        border="0">
                        <tr>
                            <td align="center">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table id="Table10" style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label17" runat="server" Width="140px" Font-Names="Tahoma" Font-Size="11pt"
                                                ForeColor="Black" Font-Bold="True" CssClass="headForm1 ">User Properties:</asp:Label>
                                            <asp:Label ID="lblUserName" Font-Names="Tahoma" Font-Size="10pt" CssClass="HeadField"
                                                runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnEdit" TabIndex="10" runat="server" OnClick="btnEdit_Click" class="btn-h-30 btn-bg-theme2 btn-r-4"
                                                Text="Modificar" />
                                            <asp:Button ID="btnAdd" TabIndex="11" runat="server" OnClick="btnAdd_Click" class="btn-h-30 btn-bg-theme2 btn-r-4"
                                                Text="Añadir" />
                                            <asp:Button ID="BtnSave" TabIndex="12" runat="server" OnClick="BtnSave_Click" class="btn-h-30 btn-bg-theme2 btn-r-4"
                                                Text="Salvar" />
                                            <asp:Button ID="btnCancel" TabIndex="13" runat="server" OnClick="btnCancel_Click"
                                                class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancelar" />
                                            <asp:Button ID="BtnExit" TabIndex="14" runat="server" OnClick="BtnExit_Click" class="btn-h-30 btn-bg-theme2 btn-r-4"
                                                Text="Salir" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table id="Table11" cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tr>
                                        <div class="col-md-12">
                                            <hr />
                                        </div>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table id="Table1" cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                        <tr>
                            <td align="right">
                                <asp:CheckBox ID="ChkAccountDisable" TabIndex="1" Font-Size="10pt" Font-Names="Tahoma"
                                    runat="server" AutoPostBack="True" Text="Diasable Account"></asp:CheckBox>
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="ChkChangePassword" TabIndex="2" Font-Names="Tahoma" Font-Size="10pt"
                                    runat="server" Text="Change Password" AutoPostBack="True"></asp:CheckBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label6" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    runat="server" ForeColor="Black">Date:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtEntryDate" TabIndex="3" Font-Names="Tahoma" Font-Size="10pt"
                                    Width="250px" CssClass="form-control w-25" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    runat="server" EnableViewState="False">Username:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtUserName" runat="server" TabIndex="3" Font-Size="10pt" Font-Names="Tahoma"
                                    CssClass="form-control w-25" Width="250px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblB" Font-Names="Tahoma" Font-Size="10pt" class="headfield1" runat="server"
                                    ForeColor="Black">Office:</asp:Label>
                            </td>
                            <td align="left" colspan="1"">
                                <asp:DropDownList ID="ddlLocation" TabIndex="8" Font-Names="Tahoma" Font-Size="10pt"
                                    Width="250px" CssClass="form-control w-25" Height="34px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    runat="server" EnableViewState="False">Name:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtFirstName" TabIndex="4" Font-Size="10pt" Font-Names="Tahoma"
                                    runat="server" CssClass="form-control w-25" Width="250px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label7" ForeColor="Black" Font-Size="10pt" Font-Names="Tahoma" runat="server"
                                    CssClass="headfield1" Visible="False">Deafult Dealer:</asp:Label>
                            </td>
                            <td align="left" colspan="1">
                                <asp:DropDownList ID="ddlDealer" TabIndex="8" Font-Size="8pt" Font-Names="Tahoma"
                                    runat="server" CssClass="form-control w-25" Height="34px" Visible="False" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblLastName" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    Height="18px" runat="server" EnableViewState="False">Last Name:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLastname" TabIndex="5" Font-Size="10pt" Font-Names="Tahoma" runat="server"
                                    CssClass="form-control w-25" Width="250px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                    Font-Size="10pt" ForeColor="Black" Height="19px">Deafult Agent:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAgent" TabIndex="8" Font-Size="8pt" Font-Names="Tahoma"
                                    runat="server" CssClass="form-control w-25" Height="34px" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    Height="18px" runat="server" EnableViewState="False">New Password:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtPassword" TabIndex="6" Font-Size="10pt" Font-Names="Tahoma" runat="server"
                                    CssClass="form-control w-25" TextMode="Password" Width="250px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                    Font-Size="10pt" ForeColor="Black" Height="19px">Deafult Agency:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlAgency" TabIndex="8" Font-Size="8pt" Font-Names="Tahoma"
                                    runat="server" CssClass="form-control w-25" Height="34px" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label4" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    Height="18px" runat="server" EnableViewState="False">Confirm Password:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TxtConfirmPassword" TabIndex="7" Font-Size="10pt" Font-Names="Tahoma"
                                    runat="server" CssClass="form-control w-25" TextMode="Password" Width="250px"></asp:TextBox>
                            </td>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="chkDealer" runat="server" Font-Names="Tahoma" Font-Size="10pt"
                                    Text="Filter By Dealer" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" rowspan="1">
                            </td>
                            <td align="left">
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                                <asp:CheckBox ID="chkAgent" runat="server" Font-Names="Tahoma" Font-Size="10pt" Text="Filter By Agent" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    Height="18px" runat="server" EnableViewState="False">Hour From:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlTime1" runat="server" Font-Size="10pt" Font-Names="Tahoma"
                                    Width="250px" CssClass="form-control w-25">
                                    <asp:ListItem Value="6:00 AM" Selected="True">6:00 AM</asp:ListItem>
                                    <asp:ListItem Value="7:00 AM">7:00 AM</asp:ListItem>
                                    <asp:ListItem Value="8:00 AM">8:00 AM</asp:ListItem>
                                    <asp:ListItem Value="9:00 AM">9:00 AM</asp:ListItem>
                                    <asp:ListItem Value="10:00 AM">10:00 AM</asp:ListItem>
                                    <asp:ListItem Value="11:00 AM">11:00 AM</asp:ListItem>
                                    <asp:ListItem Value="12:00 PM">12:00 PM</asp:ListItem>
                                    <asp:ListItem Value="1:00 PM">1:00 PM</asp:ListItem>
                                    <asp:ListItem Value="2:00 PM">2:00 PM</asp:ListItem>
                                    <asp:ListItem Value="3:00 PM">3:00 PM</asp:ListItem>
                                    <asp:ListItem Value="4:00 PM">4:00 PM</asp:ListItem>
                                    <asp:ListItem Value="5:00 PM">5:00 PM</asp:ListItem>
                                    <asp:ListItem Value="6:00 PM">6:00 PM</asp:ListItem>
                                    <asp:ListItem Value="7:00 PM">7:00 PM</asp:ListItem>
                                    <asp:ListItem Value="8:00 PM">8:00 PM</asp:ListItem>
                                    <asp:ListItem Value="9:00 PM">9:00 PM</asp:ListItem>
                                    <asp:ListItem Value="10:00 PM">10:00 PM</asp:ListItem>
                                    <asp:ListItem Value="11:00 PM">11:00 PM</asp:ListItem>
                                    <asp:ListItem Value="12:00 AM">12:00 AM</asp:ListItem>
                                    <asp:ListItem Value="1:00 AM">1:00 AM</asp:ListItem>
                                    <asp:ListItem Value="2:00 AM">2:00 AM</asp:ListItem>
                                    <asp:ListItem Value="3:00 AM">3:00 AM</asp:ListItem>
                                    <asp:ListItem Value="4:00 AM">4:00 AM</asp:ListItem>
                                    <asp:ListItem Value="5:00 AM">5:00 AM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right"">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" Font-Size="10pt" Font-Names="Tahoma" runat="server" CssClass="headfield1"
                                    Height="18px" EnableViewState="False">Hour To:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlTime2" runat="server" Font-Size="10pt" Font-Names="Tahoma"
                                    Width="250px" CssClass="form-control w-25">
                                    <asp:ListItem Value="6:00 AM">6:00 AM</asp:ListItem>
                                    <asp:ListItem Value="7:00 AM">7:00 AM</asp:ListItem>
                                    <asp:ListItem Value="8:00 AM">8:00 AM</asp:ListItem>
                                    <asp:ListItem Value="9:00 AM">9:00 AM</asp:ListItem>
                                    <asp:ListItem Value="10:00 AM">10:00 AM</asp:ListItem>
                                    <asp:ListItem Value="11:00 AM">11:00 AM</asp:ListItem>
                                    <asp:ListItem Value="12:00 PM">12:00 PM</asp:ListItem>
                                    <asp:ListItem Value="1:00 PM">1:00 PM</asp:ListItem>
                                    <asp:ListItem Value="2:00 PM">2:00 PM</asp:ListItem>
                                    <asp:ListItem Value="3:00 PM">3:00 PM</asp:ListItem>
                                    <asp:ListItem Value="4:00 PM">4:00 PM</asp:ListItem>
                                    <asp:ListItem Value="5:00 PM">5:00 PM</asp:ListItem>
                                    <asp:ListItem Value="6:00 PM" Selected="True">6:00 PM</asp:ListItem>
                                    <asp:ListItem Value="7:00 PM">7:00 PM</asp:ListItem>
                                    <asp:ListItem Value="8:00 PM">8:00 PM</asp:ListItem>
                                    <asp:ListItem Value="9:00 PM">9:00 PM</asp:ListItem>
                                    <asp:ListItem Value="10:00 PM">10:00 PM</asp:ListItem>
                                    <asp:ListItem Value="11:00 PM">11:00 PM</asp:ListItem>
                                    <asp:ListItem Value="12:00 AM">12:00 AM</asp:ListItem>
                                    <asp:ListItem Value="1:00 AM">1:00 AM</asp:ListItem>
                                    <asp:ListItem Value="2:00 AM">2:00 AM</asp:ListItem>
                                    <asp:ListItem Value="3:00 AM">3:00 AM</asp:ListItem>
                                    <asp:ListItem Value="4:00 AM">4:00 AM</asp:ListItem>
                                    <asp:ListItem Value="5:00 AM">5:00 AM</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;
                            </td>
                            <td align="left" colspan="3">
                                <asp:CheckBox ID="ChkLunes" runat="server" Font-Size="10pt" Font-Names="Tahoma" Text="Monday">
                                </asp:CheckBox>
                                <asp:CheckBox ID="ChkMartes" runat="server" Text="Tuesday" Font-Names="Tahoma" Font-Size="10pt">
                                </asp:CheckBox>
                                <asp:CheckBox ID="ChkMiercoles" runat="server" Font-Size="10pt" Font-Names="Tahoma"
                                    Text="Wednesday"></asp:CheckBox>
                                <asp:CheckBox ID="ChkJueves" runat="server" Text="Thursday" Font-Names="Tahoma" Font-Size="10pt">
                                </asp:CheckBox>
                                <asp:CheckBox ID="ChkViernes" runat="server" Text="Friday" Font-Names="Tahoma" Font-Size="10pt">
                                </asp:CheckBox>
                                <asp:CheckBox ID="ChkSabado" runat="server" Text="Saturday" Font-Names="Tahoma" Font-Size="10pt">
                                </asp:CheckBox>
                                <asp:CheckBox ID="ChkDomingo" runat="server" Text="Sunday" Font-Names="Tahoma" Font-Size="10pt">
                                </asp:CheckBox>
                                <asp:CheckBox ID="ChkTodoDia" runat="server" Text="All Days" Font-Names="Tahoma"
                                    Font-Size="10pt" Font-Bold="True"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" Font-Names="Tahoma" Font-Size="10pt" CssClass="headfield1"
                                    Height="19" runat="server" ForeColor="Black">Comments:</asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="TxtComments" TabIndex="9" Font-Size="10pt" Font-Names="Tahoma" runat="server"
                                    CssClass="form-control w-25" MaxLength="200" Width="550px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LblTotalCases" Height="3px" Font-Names="Tahoma" Font-Size="10pt" CssClass="headform3"
                                    runat="server" Visible="False">Member of:</asp:Label>
                            </td>
                            <td s align="left">
                                <asp:Label ID="LblPermissionType" Font-Size="10pt" Font-Names="Tahoma" Height="3px"
                                    runat="server" CssClass="headform3" Visible="False"> Permission Types:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAddDealer" Font-Size="10pt" Font-Names="Tahoma" Height="3px" runat="server"
                                    CssClass="headform3" Visible="False">Add Dealer By User:</asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left" rowspan="3">
                                <asp:DataGrid ID="DataGridGroup" ForeColor="Black" Height="175px" runat="server"
                                    Width="194px" PageSize="6" BorderStyle="Solid" BorderWidth="1px" BorderColor="#400000"
                                    ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center" BackColor="White"
                                    AutoGenerateColumns="False" AllowPaging="True" Font-Size="10pt" Font-Names="Tahoma"
                                    CellPadding="0" AlternatingItemStyle-CssClass="HeadForm3" AlternatingItemStyle-BackColor="#FEFBF6"
                                    HeaderStyle-CssClass="HeadForm2" HeaderStyle-BackColor="#5C8BAE" ItemStyle-CssClass="HeadForm3"
                                    OnItemCommand="DataGridGroup_ItemCommand">
                                    <FooterStyle ForeColor="White" BackColor="#BB1509"></FooterStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" Height="40px" ForeColor="White" CssClass="HeadForm2"
                                        BackColor="#BB1509" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                    <Columns>
                                        <asp:ButtonColumn HeaderText="Sel" ButtonType="PushButton" CommandName="Select">
                                            <HeaderStyle Width="0.25in"></HeaderStyle>
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn Visible="False" DataField="AuthenticatedGroupID" HeaderText="Authenticated Group ID">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AuthenticatedGroupDesc" HeaderText="Member of:">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:ButtonColumn HeaderText="Add" ButtonType="PushButton" CommandName="Add"></asp:ButtonColumn>
                                        <asp:BoundColumn Visible="False" DataField="AuthenticatedGroupUserID" ReadOnly="True"
                                            HeaderText="AuthenticatedGroupUser"></asp:BoundColumn>
                                        <asp:ButtonColumn HeaderText="Del" ButtonType="PushButton" CommandName="Delete">
                                        </asp:ButtonColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Left" ForeColor="White" BackColor="#BB1509" PageButtonCount="20"
                                        CssClass="Numbers" Mode="NumericPages" Font-Bold="False" Font-Italic="False"
                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></PagerStyle>
                                </asp:DataGrid>
                            </td>
                            <td valign="top" align="left" colspan="" rowspan="3">
                                <asp:DataGrid ID="DataGridPermission" Height="131px" runat="server" Width="209px"
                                    PageSize="7" BorderStyle="Solid" BorderWidth="1px" BorderColor="#400000" ItemStyle-HorizontalAlign="center"
                                    HeaderStyle-HorizontalAlign="Center" BackColor="White" AutoGenerateColumns="False"
                                    AllowPaging="True" Font-Size="10pt" Font-Names="Tahoma" CellPadding="0" AlternatingItemStyle-CssClass="HeadForm3"
                                    AlternatingItemStyle-BackColor="#FEFBF6" HeaderStyle-CssClass="HeadForm2" HeaderStyle-BackColor="#5C8BAE"
                                    ItemStyle-CssClass="HeadForm3" OnItemCommand="DataGridPermission_ItemCommand">
                                    <FooterStyle ForeColor="White" BackColor="#BB1509"></FooterStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" Height="40px" ForeColor="White" CssClass="HeadForm2"
                                        BackColor="#BB1509" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="AuthenticatedPermissionID" HeaderText="Permission">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="AuthenticatedPermissionDesc" HeaderText="Permissions">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Left" ForeColor="White" BackColor="#BB1509" PageButtonCount="20"
                                        CssClass="Numbers" Mode="NumericPages" Font-Bold="False" Font-Italic="False"
                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></PagerStyle>
                                </asp:DataGrid>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDealer2" TabIndex="23" Font-Size="8pt" Font-Names="Tahoma"
                                    runat="server" CssClass="headfield1" Height="19px" Width="227px" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td colspan="1">
                                <p>
                                    <asp:Button ID="btnAdd2" TabIndex="47" runat="server" Font-Names="Tahoma" class="btn-h-30 btn-bg-theme2 btn-r-4"
                                        Text="Add" OnClick="btnAdd2_Click" Visible="False" Width="75px"></asp:Button></p>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top" colspan="3" rowspan="2">
                                <asp:DataGrid ID="dgDealer" ForeColor="Black" Height="170px" runat="server" Width="355px"
                                    PageSize="6" BorderStyle="Solid" BorderWidth="1px" BorderColor="#400000" ItemStyle-HorizontalAlign="center"
                                    HeaderStyle-HorizontalAlign="Center" BackColor="White" AutoGenerateColumns="False"
                                    AllowPaging="True" Font-Size="10pt" Font-Names="Tahoma" CellPadding="0" AlternatingItemStyle-CssClass="HeadForm3"
                                    AlternatingItemStyle-BackColor="#FEFBF6" HeaderStyle-CssClass="HeadForm2" HeaderStyle-BackColor="#5C8BAE"
                                    ItemStyle-CssClass="HeadForm3" OnItemCommand="dgDealer_ItemCommand">
                                    <FooterStyle ForeColor="White" BackColor="#BB1509"></FooterStyle>
                                    <ItemStyle HorizontalAlign="Center" CssClass="HeadForm3"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Center" Height="40px" ForeColor="White" CssClass="HeadForm2"
                                        BackColor="#BB1509" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
                                    <Columns>
                                        <asp:BoundColumn Visible="False" DataField="CompanyDealerID" HeaderText="CompanyDealerID">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CompanyDealerDesc" HeaderText="CompanyDealer">
                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:ButtonColumn HeaderText="Del" ButtonType="PushButton" CommandName="Delete">
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn Visible="False" DataField="GroupDealerID" HeaderText="GroupDealerID">
                                        </asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Left" ForeColor="White" BackColor="#BB1509" PageButtonCount="20"
                                        CssClass="Numbers" Mode="NumericPages" Font-Bold="False" Font-Italic="False"
                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></PagerStyle>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        </form>
    </div>
</body>
</html>

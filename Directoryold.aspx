<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Directory.aspx.cs" Inherits="Directory" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>ePMS | electronic Policy Manager Solution</title>
</head>
<body background="Images2/SQUARE.GIF" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="19">
    <form id="form1" runat="server">
    <div>
        <table id="Table8" align="center" bgcolor="white" border="0" cellpadding="0" cellspacing="0"
            datapagesize="25" style="z-index: 101; left: 4px; width: 911px; position: static;
            top: 4px; height: 507px" width="911">
            <tr>
                <td colspan="3" style="width: 764px; height: 1px">
                    <p>
                        <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                    </p>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="1" rowspan="5" style="font-size: 10pt; width: 5px; position: static;
                    height: 395px" valign="top">
                    <p align="center">
                        <asp:PlaceHolder ID="phTopBanner1" runat="server"></asp:PlaceHolder>
                    </p>
                </td>
                <td align="center" style="font-size: 0pt; width: 86px; height: 184px">
                    <p align="center">
                        <table id="Table9" bgcolor="white" border="0" cellpadding="0" cellspacing="0" style="width: 809px;
                            height: 168px" width="809">
                            <tr>
                                <td align="center" style="font-size: 0pt; width: 6px; height: 3px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: 0pt; width: 6px; height: 3px">
                                    <table id="Table10" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 12px" width="808">
                                        <tr>
                                            <td align="left" style="width: 157px">
                                                 
                                                <asp:Label ID="Label46" runat="server" CssClass="headForm1 " Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="11pt" ForeColor="Black" Height="16px" Width="53px">Directory:</asp:Label> 
                                                </td>
                                            <td align="left" style="font-size: 2pt">
                                                         <asp:Button ID="btnDelete" runat="server"
                                                            BackColor="#400000" BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma"
                                                            ForeColor="White" Height="23px" OnClick="btnDelete_Click" TabIndex="22" Text="Delete"
                                                            Width="43px" />
                                                <asp:Button ID="btnAdd2" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnAdd2_Click"
                                                    TabIndex="23" Text="Add" Visible="False" Width="36px" /> <asp:Button ID="btnEdit"
                                                        runat="server" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma"
                                                        ForeColor="White" Height="23px" OnClick="btnEdit_Click" TabIndex="24" Text="Modify"
                                                        Width="48px" /> 
                                                <asp:Button ID="btnCancel" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnCancel_Click"
                                                    TabIndex="25" Text="Cancel" Width="46px" /><asp:Button ID="BtnExit" runat="server"
                                                        BackColor="#400000" BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma"
                                                        ForeColor="White" Height="23px" OnClick="BtnExit_Click" TabIndex="26" Text="Exit"
                                                        Width="35px" /> <asp:Button ID="BtnSave" runat="server" BackColor="#400000"
                                                            BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma" ForeColor="White"
                                                            Height="23px" OnClick="BtnSave_Click" TabIndex="27" Text="Save" /> <asp:ListBox 
                                                    ID="ListBox1" runat="server" Height="25px" Width="38px">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                </asp:ListBox>
 <div class="toggler" align="right">
                                                     </div>
                                                 </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; height: 21px">
                                    <table id="Table3" bgcolor="#c00000" border="0" bordercolor="#c00000" bordercolordark="#c00000"
                                        bordercolorlight="#c00000" cellpadding="0" cellspacing="0" height="1" style="width: 808px"
                                        width="808">
                                        <tr>
                                            <td background="Images2/Barra3.jpg" style="height: 1px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="font-size: 1pt; width: 112px; height: 46px" valign="middle">
                                                           
                                                           
                                                           
                                                           
                                                           
                                                      
                                    <table id="Table6" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 195px" width="808">
                                        <tr>
                                            <td align="center" style="font-size: 1pt; height: 61px;">
                                                <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 807px;
                                                    height: 28px" width="807">
                                                    <tr>
                                                        <td style="width: 8px; height: 20px">
                                                        </td>
                                                        <td align="right" style="width: 308px; height: 20px">
                                                            <asp:Label ID="Label17" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px">Salutation:</asp:Label> </td>
                                                        <td align="left" style="width: 275px; height: 20px">
                                                            <asp:TextBox ID="txtSalutation" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="5" TabIndex="1" Width="138px"></asp:TextBox></td>
                                                        <td align="right" style="width: 164px; height: 20px">
                                                            <asp:Label ID="Label9" runat="server" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="14px">Phone 1:</asp:Label> </td>
                                                        <td align="left" colspan="3" style="font-size: 9pt; width: 196px; font-family: Tahoma;
                                                            height: 20px">
                                                            <MaskedInput:MaskedTextBox ID="TxtPhone1" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" IsDate="False" Mask="(999) 999-9999" MaxLength="20"
                                                                TabIndex="12" Width="104px"></MaskedInput:MaskedTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px">
                                                        </td>
                                                        <td align="right" style="width: 308px; height: 21px">
                                                            <asp:Label ID="Label5" runat="server" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="14px" Width="72px">First Name:</asp:Label> </td>
                                                        <td align="left" style="width: 275px; height: 21px">
                                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="2" Width="138px"></asp:TextBox></td>
                                                        <td align="right" style="width: 164px; height: 21px">
                                                            <asp:Label ID="Label14" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px">Ext:</asp:Label> </td>
                                                        <td align="left" colspan="3" style="font-size: 9pt; width: 196px; font-family: Tahoma;
                                                            height: 21px">
                                                            <asp:TextBox ID="txtExt" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="10" TabIndex="13" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px">
                                                        </td>
                                                        <td align="right" style="width: 308px; height: 21px">
                                                            <asp:Label ID="lblLastName1" runat="server" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="72px">Last Name 1:</asp:Label> </td>
                                                        <td align="left" style="width: 275px; height: 21px">
                                                            <asp:TextBox ID="txtLastname1" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="3" Width="138px"></asp:TextBox></td>
                                                        <td align="right" style="width: 164px; height: 21px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px">Phone 2:</asp:Label> </td>
                                                        <td align="left" style="font-size: 9pt; width: 196px; font-family: Tahoma; height: 21px" colspan="3">
                                                            <MaskedInput:MaskedTextBox ID="txtPhone2" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" IsDate="False" Mask="(999) 999-9999" MaxLength="20"
                                                                TabIndex="14" Width="104px"></MaskedInput:MaskedTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 20px">
                                                        </td>
                                                        <td align="right" colspan="1" style="width: 308px; height: 20px">
                                                            <asp:Label ID="Label6" runat="server" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px">Title:</asp:Label> </td>
                                                        <td align="left" style="width: 275px; height: 20px" valign="bottom">
                                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="20" TabIndex="4" Width="138px"></asp:TextBox></td>
                                                        <td align="right" style="width: 164px; height: 20px" valign="bottom">
                                                            <asp:Label ID="Label11" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px">Email:</asp:Label>
                                                              </td>
                                                        <td align="left" colspan="3" rowspan="1" style="width: 285px; height: 20px">
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="15" Width="216px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 13px">
                                                        </td>
                                                        <td align="right" colspan="1" style="width: 308px; height: 13px">
                                                            <asp:Label ID="Label12" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px" Width="36px">Specialty:</asp:Label> </td>
                                                        <td align="left" style="width: 275px; height: 13px" valign="bottom">
                                                            <asp:DropDownList ID="ddlSpecialty" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="8pt" Height="19px"
                                                                TabIndex="5" Width="240px">
                                                            </asp:DropDownList></td>
                                                        <td align="right" style="width: 164px; height: 13px" valign="bottom">
                                                            <asp:Label ID="Label2" runat="server" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="14px">Comments:</asp:Label> </td>
                                                        <td align="left" colspan="3" rowspan="3" style="width: 285px; height: 14px">
                                                            <asp:TextBox ID="txtComments" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="40px" MaxLength="500" TabIndex="16" Width="216px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 14px">
                                                        </td>
                                                        <td align="right" colspan="1" style="width: 308px; height: 14px">
                                                            <asp:Label ID="Label1" runat="server" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="14px" Width="36px">Location:</asp:Label> </td>
                                                        <td align="left" style="width: 275px; height: 14px" valign="bottom">
                                                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="8pt" Height="19px"
                                                    TabIndex="6" Width="240px">
                                                            </asp:DropDownList></td>
                                                        <td align="right" style="width: 164px; height: 14px" valign="bottom">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 14px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 308px; height: 14px">
                                                        </td>
                                                        <td align="left" style="width: 275px; height: 14px" valign="bottom">
                                                        </td>
                                                        <td align="right" style="width: 164px; height: 14px" valign="bottom">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td align="left" style="width: 308px; height: 11px" valign="bottom">
                                                            <asp:Label ID="Label7" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px" Width="112px">Physical Address</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 275px; height: 11px" valign="bottom">
                                                            </td>
                                                        <td style="width: 164px; height: 11px" align="left">
                                                            <asp:Label ID="Label8" runat="server" CssClass="headfield1" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="14px" Width="92px">Postal Address</asp:Label></td>
                                                        <td style="width: 196px; height: 11px" colspan="3">
                                                             </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 10px">
                                                        </td>
                                                        <td align="left" style="width: 308px; height: 10px" valign="bottom">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 275px; height: 10px" valign="bottom">
                                                            <asp:TextBox ID="txtAdds1" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="7" Width="220px"></asp:TextBox></td>
                                                        <td style="width: 164px; height: 10px">
                                                        </td>
                                                        <td colspan="3" style="width: 196px; height: 10px">
                                                            <asp:TextBox ID="txtPostalAdds1" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="17" Width="220px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 10px">
                                                        </td>
                                                        <td align="left" style="width: 308px; height: 10px" valign="bottom">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 275px; height: 10px" valign="bottom">
                                                            <asp:TextBox ID="txtAdds2" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="8" Width="220px"></asp:TextBox></td>
                                                        <td style="width: 164px; height: 10px">
                                                        </td>
                                                        <td colspan="3" style="width: 196px; height: 10px">
                                                            <asp:TextBox ID="txtPostalAdds2" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="18" Width="220px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 10px">
                                                        </td>
                                                        <td align="left" style="width: 308px; height: 10px" valign="bottom">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 275px; height: 10px" valign="bottom">
                                                            <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="8pt" Height="19px"
                                                                TabIndex="9" Width="144px">
                                                            </asp:DropDownList></td>
                                                        <td style="width: 164px; height: 10px">
                                                        </td>
                                                        <td align="left" colspan="3" style="width: 196px; height: 10px">
                                                            <asp:DropDownList ID="ddlCiudad3" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="8pt" Height="19px"
                                                                TabIndex="19" Width="144px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 1px">
                                                        </td>
                                                        <td align="left" style="width: 308px; height: 1px" valign="bottom">
                                                        </td>
                                                        <td align="left" style="width: 275px; height: 1px" valign="bottom">
                                                            <asp:TextBox ID="txtState" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="2" TabIndex="10" Width="28px"></asp:TextBox>
                                                                 <asp:TextBox ID="txtZip" runat="server" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="12px" MaxLength="10" TabIndex="11"
                                                                Width="138px"></asp:TextBox></td>
                                                        <td style="width: 164px; height: 1px">
                                                        </td>
                                                        <td style="width: 196px; height: 1px" align="left" colspan="3">
                                                            <asp:TextBox ID="txtPostalState" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="2" TabIndex="20" Width="28px"></asp:TextBox>
                                                               
                                                            <asp:TextBox ID="txtPostalZip" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="10" TabIndex="21" Width="138px"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="1" style="font-size: 1pt; width: 112px; height: 13px">
                                    <table id="Table5" bgcolor="#c00000" border="0" bordercolor="#c00000" bordercolordark="#c00000"
                                        bordercolorlight="#c00000" cellpadding="0" cellspacing="0" style="width: 808px; height: 1px;"
                                        width="808">
                                        <tr>
                                            <td background="Images2/Barra3.jpg" style="height: 19px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; width: 35px; height: 27px">
                                    <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 802px;
                                        height: 4px" width="802">
                                        <tr>
                                            <td colspan="2" style="width: 141px; height: 19px">
                                            </td>
                                            <td style="width: 355px; height: 19px">
                                            </td>
                                            <td style="width: 213px; height: 19px" align="right">
                                                <asp:Label ID="lblCity" runat="server" CssClass="headfield1" EnableViewState="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="32px">City:</asp:Label> </td>
                                            <td style="width: 291px; height: 19px" align="left">
                                                <asp:DropDownList ID="ddlCiudad2" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="8pt" Height="19px" TabIndex="28" Width="208px">
                                                </asp:DropDownList></td>
                                            <td style="width: 180px; height: 19px" align="left"><asp:Button ID="btnSearch" runat="server"
                                                            BackColor="#400000" BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma"
                                                            ForeColor="White" Height="23px" OnClick="btnSearch_Click" TabIndex="33" Text="Search"
                                                            Width="76px" /> 
                                            </td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 141px; height: 19px">
                                            </td>
                                            <td style="width: 355px; height: 19px">
                                            </td>
                                            <td align="right" style="width: 213px; height: 19px">
                                                <asp:Label ID="lblLocation" runat="server" CssClass="headfield1" EnableViewState="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="1px">Location:</asp:Label> </td>
                                            <td align="left" style="width: 291px; height: 19px">
                                                <asp:DropDownList ID="ddlLocation2" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="8pt" Height="19px"
                                                    TabIndex="29" Width="208px">
                                                </asp:DropDownList></td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 141px; height: 19px">
                                            </td>
                                            <td style="width: 355px; height: 19px">
                                            </td>
                                            <td align="right" style="width: 213px; height: 19px">
                                                <asp:Label ID="lblSpecialty" runat="server" CssClass="headfield1" EnableViewState="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="68px">Specialty:</asp:Label></td>
                                            <td align="left" style="width: 291px; height: 19px">
                                                <asp:DropDownList ID="ddlSpecialty2" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="8pt" Height="19px"
                                                    TabIndex="30" Width="208px">
                                                </asp:DropDownList></td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 141px; height: 19px">
                                            </td>
                                            <td style="width: 355px; height: 19px">
                                            </td>
                                            <td align="right" style="width: 213px; height: 19px">
                                                <asp:Label ID="lblFirstName" runat="server" CssClass="headfield1" EnableViewState="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px">First Name:</asp:Label> </td>
                                            <td align="left" style="width: 291px; height: 19px">
                                                <asp:TextBox ID="TxtSearchFirstName" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="31" Width="138px"></asp:TextBox></td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 141px; height: 19px">
                                                       
                                            </td>
                                            <td style="width: 355px; height: 19px">
                                            </td>
                                            <td style="width: 213px; height: 19px" align="right">
                                                <asp:Label ID="lblLastName" runat="server" CssClass="headfield1" EnableViewState="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Height="14px">Last Name:</asp:Label> </td>
                                            <td style="width: 291px; height: 19px" align="left">
                                                <asp:TextBox ID="txtSearchLastName" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                    Font-Size="9pt" Height="12px" MaxLength="50" TabIndex="32" Width="138px"></asp:TextBox></td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                            <td style="width: 180px; height: 19px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="7" style="width: 800px; height: 9px; font-size: 10pt;">
                                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" TabIndex="6" Text="Check All" Width="84px" />
                                                     
                                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"
                                                        TabIndex="7" Text="Uncheck All" Width="84px" />
                                                     
                                                <asp:Button ID="btnMessages" runat="server" OnClick="btnMessages_Click"
                                                        TabIndex="7" Text="Message" Width="84px" /></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="7" style="width: 800px; height: 9px; font-size: 10pt;">
                                                <asp:Panel ID="pnlMessage" runat="server" BackColor="#C00000" BorderColor="#C00000"
                                                    BorderStyle="Solid" ForeColor="#C00000" Height="300px" Visible="False" Width="700px">
                                                    <table cellpadding="0" cellspacing="0" style="width: 696px; height: 284px">
                                                        <tr>
                                                            <td align="center" colspan="3" rowspan="1" style="height: 30px">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
                                                                    ForeColor="White" Height="20px" Text="Subject:" Width="60px"></asp:Label>
                                                                <asp:TextBox ID="TxtSubject" runat="server" Width="580px"></asp:TextBox></td>
                                                            <td colspan="1" rowspan="1" style="width: 21px; height: 30px" valign="top">
                                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                                                        TabIndex="7" Text="X" Width="20px" BackColor="Silver" BorderColor="Silver" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt" Height="28px" ToolTip="Close" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" rowspan="1" style="height: 245px">
                                                                <asp:TextBox ID="txtMessage" runat="server" Font-Names="Tahoma" Font-Size="10pt"
                                                                    Height="236px" TextMode="MultiLine" Width="648px"></asp:TextBox></td>
                                                            <td colspan="1" rowspan="1" style="width: 21px; height: 245px" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 18px">
                                                            </td>
                                                            <td style="height: 18px">
                                                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click"
                                                        TabIndex="7" Text="Send Email" Width="84px" /></td>
                                                            <td style="height: 18px">
                                                            </td>
                                                            <td style="width: 21px; height: 18px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="7" style="width: 500px; height: 9px">
                                                <asp:Label ID="LblTotalCases" runat="server" CssClass="headForm1 " Font-Names="Tahoma"
                                                    Font-Size="9pt" ForeColor="Black" Height="9px" Width="148px">Total Cases:</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="7" style="width: 650px; height: 9px">
                                                <asp:Label ID="LblError" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Red"
                                                    Visible="False" Width="694px">Label</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="7" style="width: 223px; height: 9px">
                                                <asp:DataGrid ID="searchDirectory" runat="server" AlternatingItemStyle-BackColor="#FEFBF6"
                                                    AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" Font-Names="Arial"
                                                    Font-Size="8pt" ForeColor="Black" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2"
                                                    HeaderStyle-HorizontalAlign="Center" Height="118px" ItemStyle-CssClass="HeadForm3"
                                                    ItemStyle-HorizontalAlign="center" OnItemCommand="searchDirectory_ItemCommand"
                                                    PageSize="9" Width="808px">
                                                    <FooterStyle BackColor="Navy" Font-Names="tahoma" ForeColor="Black" />
                                                    <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                                                    <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="White" CssClass="Numbers" Font-Names="tahoma" ForeColor="Blue"
                                                        HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
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
                                                    <HeaderStyle BackColor="#400000" CssClass="HeadForm2" Font-Bold="False" Font-Italic="False"
                                                        Font-Names="tahoma" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
                                                        ForeColor="White" Height="10px" HorizontalAlign="Center" />
                                                </asp:DataGrid></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </p>
                    <p>
                         </p>
                </td>
            </tr>
        </table>
    
    </div>
        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
            style="z-index: 145; left: 620px; width: 35px; position: absolute; top: 8px;
            height: 22px" type="hidden" value="false" />
    </form>
</body>
</html>

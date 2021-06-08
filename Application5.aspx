<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application5.aspx.cs" Inherits="Application5" %>
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
            datapagesize="25" style="z-index: 139; left: 4px; width: 921px; position: static;
            top: 4px; height: 1px" width="921">
            <tr>
                <td colspan="3" style="width: 764px; height: 1px">
                    <p>
                        <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                    </p>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="1" rowspan="5" style="font-size: 10pt; width: 5px; position: static;
                    height: 396px" valign="top">
                    <p align="center">
                        <asp:PlaceHolder ID="phTopBanner1" runat="server"></asp:PlaceHolder>
                    </p>
                </td>
                <td align="center" style="font-size: 0pt; width: 86px; height: 396px">
                    <p align="center">
                        <table id="Table9" bgcolor="white" border="0" cellpadding="0" cellspacing="0" style="width: 819px;
                            height: 36px" width="819">
                            <tr>
                                <td align="center" style="font-size: 0pt; width: 815px; height: 3px">
                                </td>
                                <td align="right" colspan="3" style="font-size: 0pt; height: 3px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: 0pt; width: 815px; height: 7px">
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                                           
                                       
                                    <table id="Table10" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 12px" width="808">
                                        <tr>
                                            <td align="left">
                                                 
                                                <asp:Label ID="Label55" runat="server" CssClass="headForm1 " Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="11pt" ForeColor="Black" Height="16px" Width="92px">Application:</asp:Label>
                                                <asp:Label ID="lblTaskControlID" runat="server" CssClass="HeadField" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="124px"></asp:Label></td>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnPrevTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnPrevTop_Click"
                                                    TabIndex="1" Text="< Prev" Width="54px" /> 
                                                <asp:Button ID="btnNextTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnNextTop_Click"
                                                    TabIndex="2" Text="Next >" Width="54px" />
                                                         
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; width: 815px" valign="top">
                                    <table id="Table11" bgcolor="indigo" border="0" bordercolor="#4b0082" bordercolordark="#4b0082"
                                        bordercolorlight="#4b0082" cellpadding="0" cellspacing="0" height="1" style="width: 808px"
                                        width="808">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="1" style="font-size: 5pt; height: 17px"
                                    valign="top" width="850">
                                    <asp:Label ID="Label50" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                        Font-Size="9pt" Width="736px">40. Please check any of the following procedures that you perform and provide estimates of how many you perform each year:</asp:Label>
                                     
                                        
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; width: 815px; height: 18px">
                                    <table id="Table3" border="0" cellpadding="1" cellspacing="1" style="width: 814px;
                                        height: 1px" width="814">
                                        <tr>
                                            <td align="left" style="font-size: 1pt; height: 105px" valign="top">
                                                <table id="Table7" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 760px; height: 3px">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px;">
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Angioplasty" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px;">
                                                             <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px;">
                                                            <asp:CheckBox ID="CheckBox20" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Myelography" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px;">
                                                            <asp:Label ID="Label20" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox20" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px;">
                                                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Angioplasty (PTA)" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px">
                                                            <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                             <asp:TextBox ID="TextBox2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px;">
                                                            <asp:CheckBox ID="CheckBox21" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Pacemaker insertions, temporary" Width="220px" /> </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:Label ID="Label21" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox21" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Aortography" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 22px">
                                                            <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                             <asp:TextBox ID="TextBox3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox22" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Pacemaker insertions, permanent" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 22px">
                                                            <asp:Label ID="Label22" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox22" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Biopsy" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label>
                                                             
                                                            <asp:TextBox ID="TextBox4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox23" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Percutaneous Transhepatic" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label23" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox23" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox5" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Breast" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                             <asp:TextBox ID="TextBox5" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox24" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Percutaneous Gastrostomy" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label24" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox24" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox6" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Breast Implants" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label6" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                             <asp:TextBox ID="TextBox6" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox25" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Periocular tatooing" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label25" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox25" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox7" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Cardiac Catheterization" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label7" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox7" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox26" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Prostate" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label26" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox26" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox8" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Coronary Angiography" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label8" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox8" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox27" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Radiation Therapy (other than grenz ray)" Width="248px" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label27" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox27" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox9" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Cholangiography" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label9" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox9" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox28" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Silicone" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label28" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox28" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox10" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Contrast Media in CNS" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label10" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox10" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox29" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Saline" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label29" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox29" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox11" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Endoscopic Sclerotherapy" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label11" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox11" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox30" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Therapeutic use of radioactive materials" Width="256px" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label30" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox30" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox12" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Hexagonal Kertotomy" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label12" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox12" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox31" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Use of laetrile" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label31" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox31" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox13" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Intraocular Lens Implants" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label13" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox13" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                            <asp:CheckBox ID="CheckBox32" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Use of chelation therapy in treatment" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:Label ID="Label32" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox32" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox14" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Intragastric balloon placement" Width="192px" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 19px">
                                                            <asp:Label ID="Label14" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox14" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 350px; height: 20px">
                                                                               
                                                            <asp:Label ID="Label33" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                Width="152px">of cardiovascular disease</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 19px">
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox15" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="IVPs" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label15" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox15" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 350px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox16" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Kidney" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label16" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox16" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 350px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox17" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Liver" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label17" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox17" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 350px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox18" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Liposuction" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label18" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox18" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 350px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 275px; height: 19px">
                                                            <asp:CheckBox ID="CheckBox19" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Lungs" /></td>
                                                        <td align="left" bordercolor="silver" style="width: 191px; height: 20px">
                                                            <asp:Label ID="Label19" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="#"></asp:Label> 
                                                            <asp:TextBox ID="TextBox19" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="13" Width="36px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 350px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                             
                                                        </td>
                                                    </tr>
                                                </table>
                                                   
                                                <table id="Table18" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 606px;">
                                                            </td>
                                                        <td align="left" colspan="1" style="width: 429px;">
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table14" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px; height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 7px">
                                                                     </td>
                                            <td align="right" colspan="1" style="width: 429px; height: 7px">
                                                <asp:Button ID="btnPrevBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnPrevBottom_Click"
                                                    TabIndex="57" Text="< Prev" Width="54px" /> 
                                                <asp:Button ID="btnNextBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnNextBottom_Click"
                                                    TabIndex="58" Text="Next >" Width="54px" />
                                                           
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                height: 3px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </p>
                    <p>
                         </p>
                    <p>
                         </p>
                </td>
            </tr>
        </table>
    
    </div>
        <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader><asp:Literal
            ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
                style="z-index: 102; left: 440px; width: 35px; position: absolute; top: 1156px;
                height: 22px" type="hidden" value="false" />
    </form>
</body>
</html>

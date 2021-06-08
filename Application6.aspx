<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application6.aspx.cs" Inherits="Application6" %>

<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ePMS | electronic Policy Manager Solution</title>
</head>
<body background="Images2/SQUARE.GIF" bottommargin="0" leftmargin="0" rightmargin="0"
    topmargin="19">
    <form id="form1" runat="server">
        <div>
            <table id="Table8" align="center" bgcolor="white" border="0" cellpadding="0" cellspacing="0"
                datapagesize="25" style="z-index: 139; left: 4px; width: 921px; position: static;
                top: 4px; height: 20px" width="921">
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
                                height: 64px">
                                <tr>
                                    <td align="center" style="font-size: 0pt; width: 814px; height: 3px">
                                    </td>
                                    <td align="right" colspan="3" style="font-size: 0pt; height: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="font-size: 0pt; width: 814px; height: 7px">
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                           
                                        <table id="Table10" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                            height: 12px" width="808">
                                            <tr>
                                                <td align="left">
                                                     
                                                    <asp:Label ID="Label21" runat="server" CssClass="headForm1 " Font-Bold="True" Font-Names="Tahoma"
                                                        Font-Size="11pt" ForeColor="Black" Height="16px" Width="92px">Application:</asp:Label><asp:Label
                                                            ID="lblTaskControlID" runat="server" CssClass="HeadField" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="124px"></asp:Label></td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:Button ID="btnPrevTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                        BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" Text="< Prev"
                                                        Width="54px" TabIndex="1" OnClick="btnPrevTop_Click" /> 
                                                    <asp:Button ID="btnNextTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                        BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" Text="Next >"
                                                        Width="54px" TabIndex="2" OnClick="btnNextTop_Click" />
                                                             
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-size: 0pt; width: 814px" valign="top">
                                        <table id="Table11" bgcolor="indigo" border="0" bordercolor="#4b0082" bordercolordark="#4b0082"
                                            bordercolorlight="#4b0082" cellpadding="0" cellspacing="0" height="1">
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table id="Table3" border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td align="left" valign="top" style="height: 1146px">
                                                    <table>
                                                   <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="3" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="lblTypeAddress1" runat="server" CssClass="headform3" Font-Bold="True"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Width="792px">41. Please check which surgical procedures you perform and the percertange of your total practice each represents. Do not include assiting at surgery.</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="No. Performed Per Year"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="Percentage of Practice/Year"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaAbort" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Abortions" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAbortYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAbortPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaAnes" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Anesthesiologic" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAnesYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAnesPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaCardio" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Cardiovascular Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtCardioYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtCardioPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaChymo" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Chymopapapin injections" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtChymoYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtChymoPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaColon" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Colon and rectal surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtColonYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtColonPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaGen" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="General Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtGenYear" runat="server" Font-Names="Tahoma" Font-Size="9pt" TabIndex="39"
                                                                    Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtGenPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaGyne" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Gynecologic surgery (other than abortions)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtGyneYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtGynePercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaHand" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Hand surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtHandYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtHandPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaHead" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Head and Neck Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtHeadYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtHeadPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaLapa" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Laparoscopic Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtLapaYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtLapaPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaOther" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Other Laparoscopic Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOtherYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOtherPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaLipo" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Liposuction" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtLipoYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtLipoPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaNeuro" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Neurosurgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtNeuroYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtNeuroPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaObs" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="Obstetrics" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtObsYear" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtObsPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaOph" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="Ophthalmic Surgery (includes closed reductions)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOphYear" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOphPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaOrth" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Orthopedic Surgery (elective cosmetic)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOrthYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOrthPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaOrthoReplace" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Orthopedic Surgery (total Joint Replacement)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOrthoReplaceYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtOrthoReplacePercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaPlaSurElective" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Plastic Surgery (elective cosmetic)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtPlaSurElectiveYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtPlaSurElectivePercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaRefra" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Refractive Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtRefraYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtRefraPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaSpinLumbar" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Spinal Surgery (posterior lumbar fusion)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtSpinLumbarYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtSpinLumbarPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaSpinOther" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Spinal Surgery (other spinal surgery)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtSpinOtherYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtSpinOtherPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaThora" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    ForeColor="Black" Text="Thoracic suergery (other than cardiovascular)" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtThoraYear" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtThoraPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaUro" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="Urologic Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtUroYear" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtUroPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkMcaVas" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black"
                                                                    Text="Vascular Surgery" /></td>
                                                            <td>
                                                                <asp:TextBox ID="txtVasYear" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                            <td>
                                                                <asp:TextBox ID="txtVasPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="80px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 7px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">42. To be completed if you administer any anesthesia or supervise administration of any anesthesia:</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 8px; width: 641px;">
                                                                 <asp:Label ID="Label6" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(a) Do you perform pain management only?</asp:Label></td>
                                                            <td style="height: 8px">
                                                                <asp:RadioButtonList ID="rdoMca42a" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 2px; width: 641px;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(b) Do you administer anesthesia only as anesthesiologist?</asp:Label></td>
                                                            <td style="height: 2px">
                                                                <asp:RadioButtonList ID="rdoMca42b" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label7" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(c) Do you use flamable anesthesia?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42c" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(d) Do you perform acupunture anesthesia?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42d" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label9" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(e) Do you supervise an anesthesiology department?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42e" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(f) Have you signed a contract to supervised an anesthesiology department?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42f" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="width: 641px">
                                                                <asp:Label ID="Label11" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(g) What is the maximum number of nurse anesthetists you supervise at any one time?</asp:Label></td>
                                                            
                                                        </tr>
                                                        <tr>
                                                        <td colspan ="2">
                                                                
                                                                <asp:TextBox TextMode="MultiLine" Height="30px" ID="txtMca42g" runat="server" Font-Names="Tahoma" Font-Size="9pt" TabIndex="39"
                                                                    Width="300px"></asp:TextBox></td>
                                                        
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(h) Are you always present during intubation and initial dosing by nurse anesthethists?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42h" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label13" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(i) Are you ever off hospital premises while supervising nurse anesthetists?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42i" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(j) Are the nurse anesthetists you supervise hospital employees? If Yes, are they also supervised by a physician anesthesiologist</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42j" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(k) If you are a surgeon? If not hospital employees, who is the employer?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42k" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtMca42kDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="300px" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 641px">
                                                                <asp:Label ID="Label15" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="640px">(i) Do you administer any anesthesia as a surgeon? If yes explain:</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca42l" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtMca42lDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="300px" Height="30px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <!--comienzo-->
                                                    <table>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label17" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="17px" Width="640px">43. Do you perform chelation therapy? If so, for what reasons? </asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtapp643Desc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="300px" Height="30px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label19" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">44. Do you anticipate your surgical practice will change significantly in the coming year? If yes explain: </asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca44" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtapp644Desc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="300px" Height="30px" TextMode="MultiLine"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">45. Do you perform mayor surgery in a freestanding facility or in your own office? </asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca45" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">46. Are you entering practice for the first time since completing an intership, residency, fellowship, or military service?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca46" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label22" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">47 Do you have any teaching responsabilites? If yes, complete these questions.</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca47" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label24" Width="100px" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt">Institution Name:</asp:Label>
                                                                <asp:TextBox ID="txtapp647Inst" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label25" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="14px" Width="50px">Address:</asp:Label>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                        
                                                        <asp:TextBox ID="txtapp647Addr" TextMode="MultiLine" Height="30px" Width="300px"
                                                        runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39"></asp:TextBox>
                                                        
                                                        </td>
                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label23" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">Does the institution provide liability covegare for these responsabilities?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca47b" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label26" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">What percentage of you weekly time is devoted to clinical teaching?</asp:Label></td>
                                                           
                                                        </tr>
                                                        <tr>
                                                         <td colspan="2">
                                                                <asp:TextBox TextMode="multiLine" Height="30px" Width="300px" ID="txtapp647bPercent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">48 Do yo have any medical director responsabilities? If yes complete these questions.</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca48" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label28" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt">Institution Name:</asp:Label>
                                                                <asp:TextBox ID="txtapp648Ent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label29" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="14px" Width="108px">Address:</asp:Label>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan="2">
                                                        
                                                        <asp:TextBox ID="txtapp648Addr" runat="server" Font-Names="Tahoma" Font-Size="9pt" TextMode="MultiLine"
                                                                    Height="30px" Width="300px" TabIndex="39"></asp:TextBox>
                                                        
                                                        </td>
                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label30" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">Does the entity provide liability coverage for administrative acts?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca48b" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">Does the entity provide liability coverage  for patient care acts?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca48c" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                           <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label32" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">49 Has your practice specialty/procedures changed in the last 5 years?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca49" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label33" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">If yes, explain how the specialty/procedures changed and give dates of change:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtapp649Desc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="30px" TabIndex="39" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label34" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">50 Do you perform emergency medicine other than to maintain hospital privileges?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca50" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label35" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt">If yes, describe location, hours, worked, relationships, etc:</asp:Label>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtapp650Desc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="30px" TabIndex="39" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label36" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">51. Do you treat or review treatment of prison inmates? If yes, explain in remarks section</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca51" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label37" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">52. Do you perform medical legal evaluations?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca52" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label38" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt">If yes, with whom?</asp:Label>
                                                                </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtapp657DescB" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="30px" TabIndex="39" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label39" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">53. Do you practice obstetrics, including prenatal care?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca53" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label40" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">54. Do you deliver infants?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca54" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label41" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt">If yes,comnplete the fallowing:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label42" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">Vaginal deliveries #/year</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtapp654b" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                TabIndex="39" Width="60px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label43" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">VBAC #/year</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtapp654c" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                TabIndex="39" Width="60px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label44" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">C-Sections #/year</asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtapp654d" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                TabIndex="39" Width="60px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label45" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">55. Do you perform deliveries other than in a hospital?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca55" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label46" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">If Yes, specify facility?</asp:Label>
                                                            </td>                                                            
                                                        </tr>
                                                        <tr>
                                                        <td colspan="2">
                                                                <asp:TextBox Width="300px" TextMode="MultiLine" ID="txtapp655Desc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="30px" TabIndex="39"></asp:TextBox>
                                                            </td>
                                                        
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label47" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">Do you perform deliveries?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca55b" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label48" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">56. Do you perform abortions?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca56" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td style="height: 8px">
                                                                            <asp:Label ID="Label49" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">(a) If Yes,First Semester:</asp:Label></td>
                                                                        <td style="height: 8px">
                                                                            <asp:RadioButtonList ID="rdoMca56First" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                                RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label50" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt" Width="640px">Second Semester:</asp:Label></td>
                                                                        <td colspan="" rowspan="">
                                                                            <asp:RadioButtonList ID="Mca56Second" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                                RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label51" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt" Width="640px">Third Semester:</asp:Label></td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rdoMca56third" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                                RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                                <asp:ListItem>No</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label52" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">(b) If Yes, </asp:Label> 
                                                                            <asp:Label ID="Label53" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">Office #/year</asp:Label>
                                                                            <asp:TextBox ID="txtDesc56A" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                TabIndex="39" Width="60px"></asp:TextBox>
                                                                            <asp:Label ID="Label58" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">Hospital #/year</asp:Label>
                                                                            <asp:TextBox ID="txtDesc56B" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                TabIndex="39" Width="60px"></asp:TextBox>
                                                                            <asp:Label ID="Label59" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                                Font-Size="9pt">Other #/year</asp:Label>
                                                                            <asp:TextBox ID="txtDesc56C" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                TabIndex="39" Width="60px"></asp:TextBox></td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label56" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">57. Do you perform consultations utilizing telecomunications technology as the medium for rendering medical services (telemedicine)?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca57" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label57" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">If Yes, please indicate all states in which the patients being treated reside:</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 19px">
                                                                <asp:TextBox style="height: 30px" ID="txtapp657DescA" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="12px" TabIndex="39" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                                height: 4px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label54" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">58. If you are radiologist or pathologist, do you read, interpret or diagnose films, slides or specimens taken who reside outside Puerto Rico ?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca58" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label55" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">If yes, please indicate all states in which the patients being treated reside:</asp:Label></td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtapp658DescA" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="30px" TabIndex="39" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label60" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">59. Are you employed full time or part time by the federal, State, or local goverment?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca59" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label61" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">60. Do you perform sex-reassignment surgery?</asp:Label></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoMca60" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 17px">
                                                                <asp:Label ID="Label62" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                    Font-Size="9pt" Width="640px">61. Do you perform weight control surgery?</asp:Label></td>
                                                            <td style="height: 17px">
                                                                <asp:RadioButtonList ID="rdoMca61" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" TabIndex="51" Width="80px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" background="Images2/Barra3.jpg" colspan="2" style="height: 1px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Button ID="btnPrevBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" Text="< Prev"
                                                                    Width="54px" TabIndex="1" OnClick="btnPrevBottom_Click" /></td>
                                                            <td>
                                                                <asp:Button ID="btnNextBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" Text="Next >"
                                                                    Width="54px" TabIndex="2" OnClick="btnNextBottom_Click" /></td>
                                                        </tr>
                                                    </table>
                                                    <!--final-->
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                    </td>
                </tr>
            </table>
        </div>
        <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader><asp:Literal
            ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
            style="z-index: 102; left: 39px; width: 35px; position: absolute; top: 2127px;
            height: 22px" type="hidden" value="false" />
    </form>
</body>
</html>

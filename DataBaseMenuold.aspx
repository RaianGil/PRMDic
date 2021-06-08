<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataBaseMenu.aspx.cs" Inherits="DataBaseMenu"%>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="epolicy.css" type="text/css" rel="stylesheet"/>
		<link rel="stylesheet" href="Stylesheet/Style.css" type="text/css"/>
		<!--[if lt IE 7]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE7.js"></script> <![endif]-->
        <!--[if lt IE 8]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE8.js"></script> <![endif]-->
        <!--[if lt IE 9]> <script src="http://ie7-js.googlecode.com/svn/version/2.1(beta4)/IE9.js"></script> <![endif]-->
		<script type="text/javascript">
		
		</script>    
    <style type="text/css">
        .style6
        {
            font-family: tahoma;
            font-size: small;
            color: #800000;
        }
        #Table2
        {
            width: 808px;
            height: 281px;
        }
        .headfield1
        {
            margin-bottom: 0px;
            margin-left: 0px;
        }
        </style>
</head>
<body background="Images2/SQUARE.GIF" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="19">
    <form id="Opp" runat="server">
    <div>
<ajaxToolKit:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnableScriptGlobalization="True">
        </ajaxToolKit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block">
            <ContentTemplate>
    
        <table align="center" bgcolor="white" border="0" cellpadding="0" cellspacing="0"
            style="width: 774px; position: static; height: 252px">
            <tr>
                <td style="height: 1px">
                     </td>
            </tr>
            <tr>
                <td style="width: 828px; height: 329px" valign="top">
                    <table align="left" cellpadding="0" cellspacing="0" height="1">
                        <tr>
                            <td align="left" style="height: 1px" bgcolor="#F4F4F4">
                                 <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                                    Font-Names="tahoma" Font-Size="11pt"
                                    ForeColor="#004C97" Height="16px" Width="126px">DataBaseMenu</asp:Label></td>
                            <td align="left" bgcolor="#F4F4F4">
                                 </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" valign="top">
                                <table id="Table3" bgcolor="#99CC00" border="0" bordercolor="#99CC00" bordercolordark="#99CC00"
                                    bordercolorlight="#99CC00" cellpadding="0" cellspacing="0" height="1" style="width: 808px">
                                    <tr>
                                        <td style="height: 1px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="height: 140px" valign="top">
                                <table id="Table2" align="left" border="0" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td align="left" valign="bottom">
                                             
                                            <asp:Button ID="BtnExecute" runat="server" BackColor="#004C97" 
                                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Font-Names="tahoma" 
                                                Font-Size="9pt" ForeColor="White" Height="23px" OnClick="BtnExecute_Click" 
                                                Text="Execute" Width="95px" />
                                            <asp:Button ID="BtnExit" runat="server" BackColor="#004C97" BorderColor="White" 
                                                BorderStyle="Solid" BorderWidth="1px" Font-Names="tahoma" Font-Size="9pt" 
                                                ForeColor="White" Height="23px" OnClick="BtnExit_Click" Text="Exit" 
                                                Width="95px" />
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom">
                                            <asp:Label ID="Label35" runat="server" Font-Names="tahoma" Font-Size="10pt" 
                                                Text="Query"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom">
                                            <asp:TextBox ID="txtQuery" runat="server" Height="133px" TextMode="MultiLine" 
                                                Width="796px" Font-Names="tahoma" Font-Size="9pt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom">
                                            <asp:Label ID="Label37" runat="server" Font-Names="tahoma" Font-Size="10pt" 
                                                Text="Result(s)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="ListBox1" runat="server" Font-Names="tahoma" Font-Size="9pt" 
                                                Height="270px" Width="788px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                                AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="10">
                                                <progresstemplate>
                                                    <span class="style6">
                                                    <img alt="" src="Images2/loader.gif" style="width: 80px; height: 16px" />
                                                    <br />
                                                    Please wait... </span>
                                                    <br />
                                                     
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView1" runat="server" Font-Names="tahoma" Font-Size="8pt">
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             </td>
                                    </tr>
                                    <tr>
                                        <td>
                                             </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" RUNAT="server"></MaskedInput:MaskedTextHeader>
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
            style="z-index: 102; left: 783px; width: 35px; position: absolute; top: 895px;
            height: 22px" type="hidden" value="false" />
            
            <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" Width="400px" BackColor="#F4F4F4"
                    Style="display: none;">
                    <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
                        font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
                        background-repeat: no-repeat; text-align: left; vertical-align: bottom;">
                          
                        <asp:Label ID="Label34" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans"
                            Font-Size="14pt" Text="Message..." ForeColor="#000066" />
                    </div>
                    <div class="CajaDialogoDiv" style="color: #FFFFFF">
                        <table style="background-position: center; width: 400px; height: 175px;">
                            <tr>
                                <td align="left" valign="middle">
                                    <asp:TextBox ID="lblRecHeader" runat="server" Font-Bold="False" Font-Italic="False"
                                        Font-Size="10pt" Font-Underline="False" ForeColor="Maroon" Text="Message" Width="390px"
                                        Font-Names="Arial" CssClass="" TextMode="MultiLine" Height="170px" BorderColor="Transparent"
                                        BorderStyle="None" BorderWidth="0px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="CajaDialogoDiv" align="center">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                    </div>
                </asp:Panel>
                <ajaxToolKit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript=""
                    OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                </ajaxToolKit:ModalPopupExtender>
                <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent"
                    BorderStyle="None" BorderWidth="0" Visible="true" />
                    
                    
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CertificateFileUpload.aspx.cs" Inherits="CertificateFileUpload" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			    <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
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
        .style1
        {
            height: 88px;
        }
        .style7
        {
            height: 82px;
        }
        .style11
        {
            height: 30px;
        }
        .style12
        {
            height: 5px;
        }
        .style22
        {
            font-size: 9pt;
            margin-right: 1px;
            margin-left: 0px;
            margin-bottom: 0px;
        }
        .style23
        {
            height: 30px;
            width: 892px;
        }
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.5;
        }
        .btn-bg-theme1 {
            background: #ba354e;
            color: #fff;
        }
        .btn-w-150 {
            width: 150px;
            height: 35px;
        }
        .btn-w-243 
        {
            width: 243px;
            height: 35px;
        }
        </style>
</head>

    
<body>
    <div class="middleMain">
		<form id="form1" runat="server" enctype="multipart/form-data">
            <Toolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                AsyncPostBackTimeout="900">
            </Toolkit:ToolkitScriptManager>
            <asp:updatepanel id="UpdatePanel1" runat="server">
                <contenttemplate>
                    <table class="tableMain">
                        <tr>
                            <td>
                                <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                            </td>
                            <td align="center" contenteditable="true" rowspan="4" style="font-size: 9pt; display:none;" 
                                valign="top" class="style1">
                            <asp:PlaceHolder ID="phTopBanner1" runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                    </table>
                    <table class="tableMain">
                        <tr>
                            <td align="center">
                                <img alt="" src="Images2/UploadFile.jpg" class="searchImage" style="margin-bottom: 25px;" />
                            </td>
                        </tr>
                    </table>
                    <table class="tableMain">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Bold="True" ForeColor="#3B3B3B"
                                    CssClass=" " Height="9px" Width="45px" Font-Size="18pt">Import Payment</asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="tableMain">
                        <tr class="">
                            <td align="center">
                                <asp:Button ID="btnManageLossPayments" runat="server" onclick="btnManageLossPayments_Click"
                                    class="btn btn-bg-theme1 btn-w-150" Text="Loss Payments"/>
                                <asp:button id="BtnExit" tabIndex="73" runat="server" onclick="BtnExit_Click"
                                    class="btn btn-bg-theme1 btn-w-150" Text="Exit" Style="margin-left: 10px"/>
                             </td>
                        </tr>
                        <tr>
                            <td style="height: 35px">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                    DisplayAfter="10">
                                    <ProgressTemplate>
                                        <img alt="" src="Images2/loader.gif" style="width: 35px; height: 35px;" />
                                        <span><span class=""></span><span style="font-family: Tahoma; font-size: 14pt; color: #BA354E">
                                            <strong>Please wait...</strong></span></span>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                    <table id="Table3" class="tableMain">
                        <tr>
                            <td align="center">
                                <br />
                                <img src="Images2/GreyLine.png" alt="" width="90%" height="6px" />
                            </td>
                        </tr>
                    </table>
                    <table class="tableMain" align="center">
                        <tr>
                            <td align="center">
                                <asp:RadioButtonList ID="rblPaymentType" runat="server" RepeatDirection="Horizontal"
                                    Style="font-family: Tahoma; font-size: 14pt;">
                                    <asp:ListItem Value="0" Selected="True">Policy Payments</asp:ListItem>
                                    <asp:ListItem Value="1" Style="margin-left:15px;">Comission Payment</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style23" colspan="3" style="font-size: 12pt;" 
                                    valign="bottom">
                                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Italic="False" Style="display: inline;"
                                Font-Names="tahoma" Font-Size="11pt" Text="File (.csv): "></asp:Label>
                                <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="tahoma" Style="display: inline;"
                                Font-Size="11pt"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <br />
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                                    class="btn-w-243 btn-bg-theme1 btn" Text="Upload" Font-Size="11pt"/>
                            <br/> <br/>
                            </td>
                        </tr>
                    </table>

                        <table align="center" bgcolor="#ffffff" border="1" bordercolor="white" cellpadding="0"
                            cellspacing="0" style="width: 100%; position: static; height: 220px">
                            <td>
                                <table align="center" style="width: 802px;
                                    height: 601px" bgcolor="White">
                        <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                            <td align="center" style="font-size: 12pt; " valign="bottom" class="style23">
                                <asp:Panel ID="pnlImportPayment" runat="server">
                                <table align="center" style="width: 802px;
                            </td>
                            <td align="center" style="font-size: 12pt; " valign="bottom" class="style11">
                                    <caption>
                                         </td>
                                        </tr>
                                        <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                            <td align="right" class="style11" style="font-size: 12pt; ">
                                                 </td>
                                            <td align="center" class="style23" style="font-size: 12pt; " valign="bottom">
                                                 </td>
                                            <td align="center" class="style23" style="font-size: 12pt; " valign="bottom">
                                                 </td>
                                            <td align="center" class="style11" style="font-size: 12pt; " valign="bottom">
                                                 </td>
                                        </tr>
                                        <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                            <td align="right" class="style11" style="font-size: 12pt; ">
                                                   </td>
                                            <td align="center" class="style11" style="font-size: 12pt; " valign="bottom">
                                                 </td>
                                        </tr>
                                        <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                            <td align="left" class="style12" style="font-size: 12pt; ">
                                            </td>
                                            <td align="center" class="style12" colspan="4" style="font-size: 12pt; ">
                                            </td>
                                        </tr>
                                        <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                            <td align="right" class="style7">
                                                   </td>
                                            <td align="center" colspan="4" valign="top">
                                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" 
                                                    Height="501px" Width="860px">
                                                </rsweb:ReportViewer>
                                            </td>
                                        </tr>
                                    </caption>
                        </table>
                        </asp:Panel>
                            <td align="center" style="font-size: 12pt; " valign="bottom" class="style23">
                                 </table>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                                 </td>
                <td> </td>
            </tr>
            <tr>
                <td>
                     </td>
                <td> </td>
            </tr>
        </table>
        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        </contenttemplate>
    </asp:updatepanel>
    </form>
    </div>
</body>
</html>

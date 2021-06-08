<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application8.aspx.cs" Inherits="Application8" %>

<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
    <title>ePMS | electronic Policy Manager Solution</title>

    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript">
    $(function() 
    {
        $('#<%= txtDateOfIncident.ClientID %>').datepicker({
            changeMonth: true,            
            changeYear: true});
        $('#<%= txtDateReported.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
        $('#<%= txtapp88fDate.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});   
        $('#<%= txtDateSign.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});                       
            });
            
    function ShowDateTimePicker()
    {
        $('#<%= txtDateOfIncident.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker2()
    {
        $('#<%= txtDateReported.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker3()
    {
        $('#<%= txtapp88fDate.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker4()
    {
        $('#<%= txtDateSign.ClientID %>').datepicker('show');
    }  
            
    </script>

</head>
<body background="Images2/SQUARE.GIF" bottommargin="0" leftmargin="0" rightmargin="0"
    topmargin="19">
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
                                height: 64px" width="819">
                                <tr>
                                    <td align="center" style="font-size: 0pt; width: 815px; height: 3px">
                                    </td>
                                    <td align="right" colspan="3" style="font-size: 0pt; height: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="font-size: 0pt; width: 815px; height: 7px">
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                                               
                                           
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 46px">
                                        <table id="Table10" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                            height: 12px" width="808">
                                            <tr>
                                                <td align="left">
                                                     
                                                    <asp:Label ID="Label21" runat="server" CssClass="headForm1 " Font-Bold="True" Font-Names="Tahoma"
                                                        Font-Size="11pt" ForeColor="Black" Height="16px" Width="92px">Application:</asp:Label>
                                                    <asp:Label ID="lblTaskControlID" runat="server" CssClass="HeadField" Font-Names="Tahoma"
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
                                    <td align="center">
                                        <table>
                                            <tr>
                                                <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                    height: 3px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 17px">
                                                    <asp:Label ID="Label7" runat="server" CssClass="headform3" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px" Font-Bold="True">INCIDENT/CLAIMS INFORMATION FORM</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                    height: 3px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label8" runat="server" CssClass="headform3" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="563px" Height="15px" Font-Bold="True" Font-Italic="True">All incidents or claims to current or prior carriers must be reported. Use separate form for each claim. Attach additional information, if necessary.</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                    height: 3px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 340px">
                                                                           
                                                                           
                                                                           
                                                                           
                                                                           
                                                                           
                                                                           
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">1. Name of Patient:</asp:Label>
                                                </td>
                                                <td style="width: 409px">
                                                    <asp:TextBox ID="txtPatientName" TabIndex="39" runat="server" Font-Size="9pt" Font-Names="Tahoma"
                                                        Width="400px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label2" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">2. Date of Incident:</asp:Label>
                                                </td>
                                                <td align="left" style="width: 409px">
                                                    <asp:TextBox ID="txtDateOfIncident" TabIndex="39" runat="server" Font-Size="9pt"
                                                        Font-Names="Tahoma" Width="82px" onclick="ShowDateTimePicker();"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label3" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">3. Date reported to Insurance Carrier:</asp:Label>
                                                </td>
                                                <td align= "left" style="width: 409px">
                                                    <asp:TextBox ID="txtDateReported" TabIndex="39" runat="server" Font-Size="9pt" Font-Names="Tahoma"
                                                        Width="82px" onclick="ShowDateTimePicker2();"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label4" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">4. Name of Insurance Carrier:</asp:Label>
                                                </td>
                                                <td style="width: 409px">
                                                    <asp:TextBox ID="txtInsuranceNameCarrier" TabIndex="39" runat="server" Font-Size="9pt"
                                                        Font-Names="Tahoma" Width="400px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label5" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">5. Allegations:</asp:Label>
                                                </td>
                                                <td style="width: 409px">
                                                    <asp:TextBox ID="txtAllegation" TabIndex="39" runat="server" Font-Size="9pt" Font-Names="Tahoma"
                                                        Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label6" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">6. Present Condition of Patient:</asp:Label>
                                                </td>
                                                <td style="width: 409px">
                                                    <asp:TextBox ID="txtConditionPatient" TabIndex="39" runat="server" Font-Size="9pt"
                                                        Font-Names="Tahoma" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Width="603px" Height="15px">7. Did you in any way alter, change, delete, embellish and/or destroy any records, medical or otherwise, or were allegations made that you did so, pertaining to this claim?</asp:Label></td>
                                                            <td style="width: 100px">
                                                                <asp:RadioButtonList ID="rdoMca7" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" Width="85px" TabIndex="55">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label10" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Width="253px" Height="15px">8. Status of Claim (Check applicable answer):</asp:Label>
                                                </td>
                                                <td style="width: 409px">
                                                     </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table style="width: 606px">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8a" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Suit threatened, no action taken" />
                                                            </td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8g" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Suit filed but dropped by claimant" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8b" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Awaiting court action or mediation" /></td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8c" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Summary judgment in you favor" /></td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8h" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Jury verdict" />
                                                                <asp:CheckBox ID="chkMca8j" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Directed verdict" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8d" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Court outcome in you favor" /></td>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8i" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Jury verdict" /><asp:CheckBox
                                                                    ID="chkMca8k" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Directed verdict" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8e" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Court outcome in favor of plaintiff" /></td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">Amount of loss payment:$</asp:Label>
                                                                <asp:TextBox ID="txtapp88ePayment" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="82px"></asp:TextBox></td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:CheckBox ID="chkMca8f" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Suit settled out of court" /></td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label12" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">a. Date claim paid:</asp:Label>
                                                                <asp:TextBox ID="txtapp88fDate" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="82px" onclick="ShowDateTimePicker3();" ReadOnly="True"></asp:TextBox></td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label13" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">b. Amount paid:</asp:Label>
                                                                <asp:TextBox ID="txtapp88fPaid" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="82px"></asp:TextBox></td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label14" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">c. Did you want to settle this claim?</asp:Label></td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoMca8fc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" Width="85px" TabIndex="55" Height="26px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label22" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">Was teh corporation sued?</asp:Label></td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoMca8l" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" Width="85px" TabIndex="55" Height="26px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label17" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">Was payment made on its behalf?</asp:Label></td>
                                                            <td align="left">
                                                                <asp:RadioButtonList ID="rdoMca8m" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    RepeatDirection="Horizontal" Width="85px" TabIndex="55" Height="26px">
                                                                    <asp:ListItem>Yes</asp:ListItem>
                                                                    <asp:ListItem>No</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label16" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                                    Height="15px" Width="203px">If Yes, amont paid: $</asp:Label>
                                                                <asp:TextBox ID="txtMPayment" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                    TabIndex="39" Width="82px"></asp:TextBox></td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label15" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Height="15px" Width="350px">9. Name and address of the attorney assigned to your case:</asp:Label>
                                                </td>
                                                <td style="width: 409px">
                                                    <asp:TextBox ID="txtapp89Desc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                        TabIndex="39" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                    height: 3px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label18" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Height="15px" Width="624px" Font-Bold="True">I HERBY DECLARE THE ABOVE INFORMATION IS TRUE AND COMPLETE</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 340px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Height="15px" Width="84px">Signed:</asp:Label>
                                                    <asp:TextBox ID="txtSigned" runat="server" Font-Names="Tahoma" Font-Size="9pt" TabIndex="39"
                                                        Width="224px"></asp:TextBox></td>
                                                <td style="width: 409px" align="left">
                                                    <asp:Label ID="Label20" runat="server" CssClass="HeadField" Font-Names="Tahoma" Font-Size="9pt"
                                                        Height="15px" Width="110px">Date Signed:</asp:Label>
                                                    <asp:TextBox ID="txtDateSign" runat="server" onclick="ShowDateTimePicker4();" Font-Names="Tahoma" Font-Size="9pt" TabIndex="39"
                                                        Width="104px"></asp:TextBox></td>
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
                    </td>
                </tr>
            </table>
        </div>
        <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader><asp:Literal
            ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
            style="z-index: 102; left: 259px; width: 35px; position: absolute; top: 1669px;
            height: 22px" type="hidden" value="false" />
    </form>
</body>
</html>

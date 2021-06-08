<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application2.aspx.cs" Inherits="Application2" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ePMS | electronic Policy Manager Solution</title>
<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
</head>
<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript">
    $(function() 
    {
        $('#<%= txtBoardCertifiedDesc7.ClientID %>').datepicker({
            changeMonth: true,            
            changeYear: true});
        $('#<%= txtBoardCertifiedDesc8.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
        $('#<%= txtBoardCertifiedDesc9.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});                      
        $('#<%= txtEleExpDate.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});               
        $('#<%= txtWrittenWhen.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});             
        $('#<%= txtOralWhen.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});             
        $('#<%= txtBoardDate.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});                         
    });


    function ShowDateTimePicker()
    {
        $('#<%= txtBoardCertifiedDesc7.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker2()
    {
        $('#<%= txtBoardCertifiedDesc8.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker3()
    {
        $('#<%= txtBoardCertifiedDesc9.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker4()
    {
        $('#<%= txtEleExpDate.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker5()
    {
        $('#<%= txtWrittenWhen.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker6()
    {
        $('#<%= txtOralWhen.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker7()
    {
        $('#<%= txtBoardDate.ClientID %>').datepicker('show');
    }    
</script>
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
                            height: 64px" width="819">
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
                                                 
                                                <asp:Label ID="Label21" runat="server" CssClass="headForm1 " Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="11pt" ForeColor="Black" Height="16px" Width="92px">Application:</asp:Label>
                                                <asp:Label ID="lblTaskControlID" runat="server" CssClass="HeadField" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="124px"></asp:Label></td>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnPrevTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                                BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                                Text="< Prev" Width="54px" OnClick="btnPrevTop_Click" TabIndex="1" /> 
                                    <asp:Button ID="btnNextTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                                BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                                Text="Next >" Width="54px" OnClick="btnNextTop_Click" TabIndex="2" />
                                             
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
                                <td align="right" colspan="1" style="font-size: 5pt; width: 815px; height: 17px" valign="top">
                                         
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; width: 815px; height: 19px">
                                    <table id="Table3" border="0" cellpadding="1" cellspacing="1" style="width: 814px;
                                        height: 76px" width="814">
                                        <tr>
                                            <td align="left" style="font-size: 1pt; height: 258px" valign="top">
                                                <table id="Table4" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td colspan="2" style="width: 300px">
                                                            <asp:Label ID="lblTypeAddress1" runat="server" CssClass="headform3" Font-Bold="True"
                                                                Font-Names="Tahoma" Font-Size="9pt" Width="268px">IV.SPECIAL /BOARD CERTIFICATION</asp:Label></td>
                                                        <td style="width: 92px">
                                                        </td>
                                                        <td style="width: 321px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                   <asp:Label ID="Label18" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="112px">Primary Specialty</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:TextBox ID="txtPriSpecialty" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" MaxLength="75" Width="288px" TabIndex="3"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 92px">
                                                            <asp:Label ID="Label19" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px">% of Practice</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtPriPractice" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" MaxLength="50" Width="120px" TabIndex="4"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                   <asp:Label ID="Label1" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="112px">Secondary Specialty</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:TextBox ID="txtSecSpecialty" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" MaxLength="75" Width="288px" TabIndex="5"></asp:TextBox> </td>
                                                        <td align="left" bordercolor="silver" style="width: 92px">
                                                             <asp:Label ID="Label2" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px">% of Practice</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtSecPractice" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" MaxLength="50" Width="120px" TabIndex="6"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="2" style="width: 440px">
                                                            <asp:Label ID="Label3" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="424px">10. Do you limit your practice to either the Primary or Secondary specialty?</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 92px">
                                                            <asp:RadioButtonList ID="rdoMcaPracticeLimit" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="7">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="2" style="width: 158px">
                                                                                 
                                                            <asp:Label ID="Label4" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="128px">Please explain.</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 92px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="4" style="width: 158px">
                                                            <asp:TextBox ID="txtPracticeLimitDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="24px"
                                                                MaxLength="75" Width="664px" TextMode="MultiLine" TabIndex="8"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" bordercolor="silver" colspan="4"
                                                            style="width: 158px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="2" style="width: 325px">
                                                            <asp:Label ID="Label5" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="308px">11. Are you Board Certfied in one or more areas?</asp:Label></td>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 92px">
                                                            <asp:RadioButtonList ID="rdoMcaBoardCertified" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="9">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 158px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table7" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 760px;
                                                            height: 3px">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:Label ID="Label31" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Name of Board</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                            <asp:Label ID="Label32" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Year Originally Certified</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                            <asp:Label ID="Label33" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="120px">Certification Expires</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px">
                                                            <asp:Label ID="Label34" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px">Recertification Year</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="228px" TabIndex="10"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                                    <asp:TextBox ID="txtBoardCertifiedDesc4" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="11"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc7" runat="server" onclick="ShowDateTimePicker();" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="92px" TabIndex="12"></asp:TextBox> </td>
                                                        <td align="center" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc10" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="108px" TabIndex="13"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 22px">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="228px" TabIndex="14"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px">
                                                                   
                                                            <asp:TextBox ID="txtBoardCertifiedDesc5" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="15"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 22px">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc8" runat="server" onclick="ShowDateTimePicker2();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="92px" TabIndex="16"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 22px">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc11" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="108px" TabIndex="17"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 20px;">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="228px" TabIndex="18"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px;">
                                                                   
                                                            <asp:TextBox ID="txtBoardCertifiedDesc6" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="19"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 20px;">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc9" runat="server" onclick="ShowDateTimePicker3();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="92px" TabIndex="20"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 20px;">
                                                            <asp:TextBox ID="txtBoardCertifiedDesc12" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="108px" TabIndex="21"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                                 
                                                <table id="Table5" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px;
                                                            height: 3px" background="Images2/Barra3.jpg">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 375px; height: 11px">
                                                            <asp:Label ID="Label16" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="372px">12. If not Board Certified, what is the expiration date of eligibility?</asp:Label>
                                                                                  </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                            <asp:TextBox ID="txtEleExpDate" runat="server" onclick="ShowDateTimePicker4();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="92px" TabIndex="22"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 375px; height: 3px">
                                                                                
                                                            <asp:Label ID="Label6" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="100px">If expired, Why?</asp:Label>
                                                              
                                                            <asp:TextBox ID="txtExpiredWhy" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="612px" TabIndex="23"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 500px; height: 11px">
                                                            <asp:Label ID="Label7" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="432px">13. If not current certified, are you scheduled to take the board examination?</asp:Label>
                                                                                </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                            <asp:RadioButtonList ID="rdoMcaBoardExam" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="24">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 375px; height: 4px">
                                                                                
                                                            <asp:Label ID="Label8" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="100px">If expired, Why?</asp:Label>
                                                              
                                                            <asp:TextBox ID="txtBoardExamDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="612px" TabIndex="25"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px; height: 3px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table6" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 606px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 500px; height: 11px">
                                                            <asp:Label ID="Label14" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="276px">14. If elegible, have you taken the written exam?</asp:Label>
                                                                 
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 200px; height: 11px">
                                                            <asp:RadioButtonList ID="rdoMcaWrittenExam" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="26">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td align="left" colspan="1" style="width: 295px; height: 11px">
                                                                    <asp:Label ID="Label17" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="44px">When?</asp:Label> 
                                                            <asp:TextBox ID="txtWrittenWhen" runat="server" onclick="ShowDateTimePicker5();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="75px" TabIndex="27"></asp:TextBox></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                            <asp:Label ID="Label20" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="44px">Results</asp:Label>
                                                            <asp:TextBox ID="txtWrittenResult" runat="server"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    Width="72px" TabIndex="28"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 5px">
                                                                                
                                                            <asp:Label ID="Label15" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="236px">If elegible, have you taken the oral exam?</asp:Label>
                                                                                    
                                                                     
                                                        </td>
                                                        <td align="left" style="width: 200px; height: 5px">
                                                            <asp:RadioButtonList ID="rdoMcaOralExam" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="29">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td align="left" style="width: 295px; height: 5px">
                                                                    <asp:Label ID="Label23" runat="server" CssClass="headform3"
                                                                Font-Bold="False" Font-Names="Tahoma" Font-Size="9pt" Width="44px">When?</asp:Label>
                                                             <asp:TextBox
                                                                    ID="txtOralWhen" runat="server" onclick="ShowDateTimePicker6();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    Width="75px" TabIndex="30"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 5px">
                                                            <asp:Label ID="Label24" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="44px">Results</asp:Label>
                                                            <asp:TextBox ID="txtOralResult" runat="server"
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                    Width="72px" TabIndex="31"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="4" style="width: 121px; height: 4px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                 
                                                <table id="Table15" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 603px; height: 11px">
                                                            <asp:Label ID="Label28" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="264px">15. Have you ever failed to pass a Board Exam?</asp:Label>
                                                                 </td>
                                                        <td align="left" colspan="1" style="width: 362px; height: 11px">
                                                                        
                                                            <asp:RadioButtonList ID="rdoMcaFailedBoardExam" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="32">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                             </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 631px; height: 4px">
                                                                                
                                                            <asp:Label ID="Label42" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="236px">Name of Specialty Board Failed:</asp:Label>
                                                              
                                                            <asp:TextBox ID="txtBoardFailedSpecialty" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="268px" TabIndex="33"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label43" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="36px">Date:</asp:Label>
                                                                    <asp:TextBox ID="txtBoardDate" runat="server" onclick="ShowDateTimePicker7();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="116px" TabIndex="34"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="3" style="width: 121px; height: 4px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 804px;
                                                    height: 1px">
                                                    <tr>
                                                        <td colspan="4" style="width: 320px">
                                                            <asp:Label ID="Label9" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="112px">V. MILITARY</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 14px">
                                                            <asp:Label ID="Label10" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="280px">16. Are you current active in Military Servies?</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 572px; height: 14px">
                                                            <asp:RadioButtonList ID="rdoMcaMilitary" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="35">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 572px; height: 4px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 13px">
                                                                                 
                                                            <asp:Label ID="Label37" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="56px">     Branch</asp:Label> 
                                                            <asp:TextBox ID="txtMilitaryDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="164px" TabIndex="36"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" colspan="5" style="width: 572px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 14px">
                                                            <asp:Label ID="Label44" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="212px">17. Are you in the Military Reserves?</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 572px; height: 14px">
                                                            <asp:RadioButtonList ID="rdoMcaMilitaryReserve" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="37">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" colspan="6" style="width: 572px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 14px">
                                                            <asp:Label ID="Label45" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="200px">VI.LICENSES AND AFFILIATIONS</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 14px">
                                                            <asp:Label ID="Label46" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="388px">18. Specify state or countries where you are or have been licensed:</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 200px">
                                                            <asp:Label ID="Label25" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px">State/Country</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 194px">
                                                            <asp:Label ID="Label13" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Year</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:Label ID="Label22" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px">License #</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:Label ID="Label26" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px">Status</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 200px; height: 20px">
                                                              
                                                            <asp:TextBox ID="txtLicState1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="38"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 194px; height: 20px">
                                                            <asp:TextBox ID="txtLicYear1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="39"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px">
                                                             <asp:TextBox ID="txtLicNumber1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="40"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px">
                                                            <asp:TextBox ID="txtLicStatus1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="41"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 200px">
                                                              
                                                            <asp:TextBox ID="txtLicState2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="42"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 194px">
                                                            <asp:TextBox ID="txtLicYear2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="43"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:TextBox ID="txtLicNumber2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="44"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:TextBox ID="txtLicStatus2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="45"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 200px; height: 20px">
                                                              
                                                            <asp:TextBox ID="txtLicState3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="46"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 194px; height: 20px">
                                                            <asp:TextBox ID="txtLicYear3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" Width="120px" TabIndex="47"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px">
                                                            <asp:TextBox ID="txtLicNumber3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="48"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px">
                                                            <asp:TextBox ID="txtLicStatus3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="120px" TabIndex="49"></asp:TextBox></td>
                                                    </tr>
                                                </table><table id="Table17" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 3px" background="Images2/Barra3.jpg">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 606px; height: 4px">
                                                            <asp:Label ID="Label30" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="564px">19. If any of your licenses have been made inactive, suspended, restricted or revoked, please explain.</asp:Label>
                                                                                </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 4px"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 30px">
                                                <asp:TextBox ID="txtLicInactive" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                    Height="28px" TextMode="MultiLine" Width="572px" TabIndex="50"></asp:TextBox></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 30px">
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
                                    <table id="Table12" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px;
                                                height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 11px">
                                                <asp:Label ID="Label11" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="536px">20. Are you a member of any national (NOT specialty) medical societies?</asp:Label>
                                                             </td>
                                            <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                <asp:RadioButtonList ID="rdoMcaMedSocieties" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                    RepeatDirection="Horizontal" Width="80px" TabIndex="51">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 6px">
                                                <asp:Label ID="Label38" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="52px">If so, list:</asp:Label><asp:TextBox ID="txtMedSocietiesDesc"
                                                        runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" Width="468px" TabIndex="52"></asp:TextBox></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 6px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;">
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table16" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                        <tr>
                                            <td align="left" background="Images2/Barra3.jpg" colspan="2" style="width: 606px;
                                                height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 4px">
                                                 <asp:Label ID="Label12" runat="server" CssClass="headform3" Font-Bold="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Width="536px">21. Are you a member of any national specialty societies?</asp:Label>
                                                                   </td>
                                            <td align="left" colspan="1" style="width: 429px; height: 4px">
                                                <asp:RadioButtonList ID="rdoMcaNationalSocieties" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                    RepeatDirection="Horizontal" Width="80px" TabIndex="53">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 3px">
                                                <asp:Label ID="Label27" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="52px">If so, list:</asp:Label><asp:TextBox ID="txtNationalSocietiesDesc"
                                                        runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" Width="468px" TabIndex="54"></asp:TextBox></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                height: 3px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table13" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                <table id="Table18" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 606px; height: 34px">
                                                            <asp:Label ID="Label35" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="612px">22. Are you a member of any state medical society?</asp:Label>
                                                                                </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 34px">
                                                            <asp:RadioButtonList ID="rdoMcaStateMedSocieties" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                    RepeatDirection="Horizontal" Width="80px" TabIndex="55">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 34px">
                                                <asp:Label ID="Label39" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="612px">23. Are you a member of your local medical society?</asp:Label>
                                                                    </td>
                                            <td align="left" colspan="1" style="width: 429px; height: 34px">
                                                <asp:RadioButtonList ID="rdoMcaLocalMedSocieties" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                    RepeatDirection="Horizontal" Width="80px" TabIndex="56">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                height: 3px">
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
                                            <td align="right" colspan="1" style="width: 429px; height: 7px"><asp:Button ID="btnPrevBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                                BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                                Text="< Prev" Width="54px" OnClick="btnPrevBottom_Click" TabIndex="57" /> 
                                                <asp:Button ID="btnNextBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Next >" Width="54px" OnClick="btnNextBottom_Click" TabIndex="58" />
                                                    
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
                    <p>
                         </p>
                    <p>
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

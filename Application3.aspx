<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application3.aspx.cs" Inherits="Application3" %>
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
        $('#<%= txtEntDate1.ClientID %>').datepicker({
            changeMonth: true,            
            changeYear: true});
        $('#<%= txtEntDate2.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
        $('#<%= txtEntDate3.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});                      
        $('#<%= txtEntDate4.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});               
        $('#<%= txtEntDate5.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});                                  
    });


    function ShowDateTimePicker()
    {
        $('#<%= txtEntDate1.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker2()
    {
        $('#<%= txtEntDate2.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker3()
    {
        $('#<%= txtEntDate3.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker4()
    {
        $('#<%= txtEntDate4.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker5()
    {
        $('#<%= txtEntDate5.ClientID %>').datepicker('show');
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
                                                 
                                                <asp:Label ID="Label21" runat="server" CssClass="headForm1 " Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="11pt" ForeColor="Black" Height="16px" Width="92px">Application:</asp:Label>
                                                <asp:Label ID="lblTaskControlID" runat="server" CssClass="HeadField" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="124px"></asp:Label></td>
                                            <td>
                                            </td>
                                            <td align="right">
                                                <asp:Button ID="btnPrevTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" TabIndex="63"
                                                    Text="< Prev" Width="54px" OnClick="btnPrevTop_Click" /> 
                                                <asp:Button ID="btnNextTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" TabIndex="64"
                                                    Text="Next >" Width="54px" OnClick="btnNextTop_Click" />
                                                         
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
                                <td align="right" colspan="1" style="font-size: 5pt; width: 815px; height: 17px"
                                    valign="top">
                                         
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; width: 815px; height: 19px">
                                    <table id="Table3" border="0" cellpadding="1" cellspacing="1" style="width: 814px;
                                        height: 76px" width="814">
                                        <tr>
                                            <td align="left" style="font-size: 1pt; height: 258px" valign="top"><table id="Table7" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                <tr>
                                                    <td align="left" colspan="5" style="width: 760px; height: 3px">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                        <asp:Label ID="Label2" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="316px">VII. HOSPITAL AND FACILITY CENTER PRIVILEGES</asp:Label></td>
                                                    <td align="center" bordercolor="silver" style="width: 206px">
                                                    </td>
                                                    <td align="center" bordercolor="silver" style="width: 222px">
                                                    </td>
                                                    <td align="center" bordercolor="silver" style="width: 321px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" bordercolor="silver" colspan="4" style="width: 700px">
                                                                               
                                                        <asp:Label ID="Label1" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="620px">24. List all Hospitals and /or other surgical centers or facilities where you currently have privileges or applications</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" bordercolor="silver" colspan="4" style="width: 700px">
                                                                             
                                                        <asp:Label ID="Label3" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="616px">for privileges pending. Indicate the type of privileges and restrictions, if any.</asp:Label></td>
                                                </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 18px;">
                                                            <asp:Label ID="Label31" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Hospital/Facility</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 18px;">
                                                            <asp:Label ID="Label32" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">City</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 18px;">
                                                            <asp:Label ID="Label33" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="120px">Type of Privileges</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 18px;">
                                                            <asp:Label ID="Label34" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px">Restrictions</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:TextBox ID="txtHospital1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="1" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                                   
                                                            <asp:TextBox ID="txtCity1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="2" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                            <asp:TextBox ID="txtPrivileges1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="3" Width="92px"></asp:TextBox> </td>
                                                        <td align="center" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtRestrictions1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="4" Width="108px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 22px">
                                                            <asp:TextBox ID="txtHospital2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="5" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px">
                                                                   
                                                            <asp:TextBox ID="txtCity2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="6" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 22px">
                                                            <asp:TextBox ID="txtPrivileges2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="7" Width="92px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 22px">
                                                            <asp:TextBox ID="txtRestrictions2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="8" Width="108px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 20px">
                                                            <asp:TextBox ID="txtHospital3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="9" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px">
                                                                   
                                                            <asp:TextBox ID="txtCity3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="10" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 20px">
                                                            <asp:TextBox ID="txtPrivileges3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="11" Width="92px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:TextBox ID="txtRestrictions3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="12" Width="108px"></asp:TextBox></td>
                                                    </tr>
                                                <tr>
                                                    <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 20px">
                                                        <asp:TextBox ID="txtHospital4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            TabIndex="13" Width="228px"></asp:TextBox></td>
                                                    <td align="center" bordercolor="silver" style="width: 206px; height: 20px">
                                                               
                                                        <asp:TextBox ID="txtCity4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            TabIndex="14" Width="120px"></asp:TextBox></td>
                                                    <td align="center" bordercolor="silver" style="width: 222px; height: 20px">
                                                        <asp:TextBox ID="txtPrivileges4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            TabIndex="15" Width="92px"></asp:TextBox></td>
                                                    <td align="center" bordercolor="silver" style="width: 321px; height: 20px">
                                                        <asp:TextBox ID="txtRestrictions4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            TabIndex="16" Width="108px"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                                <table id="Table4" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 760px; height: 3px" background="Images2/Barra3.jpg">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:Label ID="Label5" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="264px">VIII. PRACTICE PROFILE</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                        </td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="3" style="width: 700px; height: 16px">
                                                                              
                                                            <asp:Label ID="Label16" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="212px">A. Current Practice Locations</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="3" style="width: 700px">
                                                                             
                                                            <asp:Label ID="Label18" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="432px">25. List all offices where you currently practice.</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:Label ID="Label19" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Address/Suite</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                            <asp:Label ID="Label29" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">City/State</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                            <asp:Label ID="Label36" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="120px">Country</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:TextBox ID="txtOficeAddr1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="17" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                                   
                                                            <asp:TextBox ID="txtOficeCity1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="18" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                             <asp:TextBox ID="txtOficeCountry1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="19" Width="92px"></asp:TextBox> </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 22px">
                                                            <asp:TextBox ID="txtOficeAddr2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="20" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px">
                                                                   
                                                            <asp:TextBox ID="txtOficeCity2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="21" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 22px">
                                                            <asp:TextBox ID="txtOficeCountry2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="22" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 20px">
                                                            <asp:TextBox ID="txtOficeAddr3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="23" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px">
                                                                   
                                                            <asp:TextBox ID="txtOficeCity3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="24" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 20px">
                                                            <asp:TextBox ID="txtOficeCountry3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="25" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                                 
                                                <table id="Table5" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" colspan="2" style="width: 606px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 375px; height: 3px">
                                                                                  
                                                                      
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="width: 121px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                                               <asp:Label ID="Label41"
                                                                runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma" Font-Size="9pt"
                                                                Width="212px">B. Practice History</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 750px; height: 4px">
                                                                                  
                                                                   <asp:Label ID="Label8" runat="server" CssClass="headform3"
                                                                Font-Bold="False" Font-Names="Tahoma" Font-Size="9pt" Width="624px">26. Where have you practiced your profession since completion of your formal training? (Include military or any</asp:Label>
                                                              
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 750px; height: 4px">
                                                                                
                                                            <asp:Label ID="Label4" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="572px">public service organization).  PLEASE ACCOUNT FOR ALL TIMES SINCE COMPLETION OF YOUR MEDICAL</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 750px; height: 4px">
                                                                                
                                                            <asp:Label ID="Label7" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="576px">SCHOOL, WITH THE EXCEPTION OF YOUR RESIDENCY OR FELLOWSHIP TRAINING. INCLUDE YOUR</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 750px; height: 4px">
                                                                                
                                                            <asp:Label ID="Label40" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="196px">SPECIALTY AT THAT TIME</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 375px; height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label6" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Entity Name:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntName1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="26" Width="324px"></asp:TextBox>
                                                                                   
                                                                                   
                                                                     
                                                        </td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label47" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Dates:</asp:Label> 
                                                             <asp:TextBox ID="txtEntDate1" runat="server" onclick="ShowDateTimePicker();" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="27" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label55" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Address:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntAddr1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                               TabIndex="28" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label54" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Specialty:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntSpecialty1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                               TabIndex="29" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label48" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Entity Name:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntName2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="30" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label49" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Dates:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntDate2" runat="server" onclick="ShowDateTimePicker2();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="31" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label51" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Address:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntAddr2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="32" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label50" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Specialty:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntSpecialty2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="33" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label52" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Entity Name:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntName3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="34" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label59" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Dates:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntDate3" runat="server" onclick="ShowDateTimePicker3();" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="35" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label53" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Address:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntAddr3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="36" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label60" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Specialty:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntSpecialty3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="37" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label56" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Entity Name:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntName4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="38" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label61" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Dates:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntDate4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                onclick="ShowDateTimePicker4();" TabIndex="39" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label57" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Address:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntAddr4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="40" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label62" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Specialty:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntSpecialty4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                              TabIndex="41" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label58" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Entity Name:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntName5" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="42" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label63" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Dates:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntDate5" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                onclick="ShowDateTimePicker5();" TabIndex="43" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                            <asp:Label ID="Label65" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Address:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntAddr5" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="44" Width="324px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label64" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">Specialty:</asp:Label>
                                                             
                                                            <asp:TextBox ID="txtEntSpecialty5" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="45" Width="92px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 4px">
                                                        </td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table6" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 606px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 474px; height: 11px">
                                                                                 
                                                            <asp:Label ID="Label14" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="248px">C. Type of Medical Practice/Structure</asp:Label>
                                                             
                                                                
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 295px; height: 11px">
                                                                        
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                             </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 500px; height: 5px" colspan="4">
                                                                                
                                                            <asp:Label ID="Label15" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="452px">27. Check the boxes that best describe the type of practice you currently have:</asp:Label>
                                                                                  
                                                                                   
                                                                
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="" style="width: 274px; height: 5px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                             <asp:CheckBox ID="chkMcaPhysician" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Solo Physician" TabIndex="46" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                            <asp:CheckBox ID="chkMcaPartnership" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Partnership" TabIndex="50" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="" style="width: 274px; height: 5px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                             <asp:CheckBox ID="chkMcaEmpPhysician" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Employed Physician" TabIndex="47" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                            <asp:CheckBox ID="chkMcaGroup" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Group Member" TabIndex="51" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="" style="width: 274px; height: 5px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                             <asp:CheckBox ID="chkMcaProfAss" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Professional Association" TabIndex="48" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                            <asp:CheckBox ID="chkMcaProfCorp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Professional Corporation" TabIndex="52" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="" style="width: 274px; height: 5px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                            <asp:CheckBox ID="chkMcaOther" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Other" TabIndex="49" /></td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 500px; height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="4" style="width: 121px;
                                                            height: 4px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                 
                                                <table id="Table15" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 603px; height: 11px">
                                                                              
                                                            <asp:Label ID="Label28" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="648px">28. If you checked any box other than "Solo Physician", list below the name of the entity(ies),</asp:Label>
                                                                 </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 603px; height: 11px">
                                                                              
                                                            <asp:Label ID="Label17" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="648px">your status, and names of associates, partners, shareholders.</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 631px; height: 4px">
                                                                                  
                                                                     
                                                            <asp:Label ID="Label42" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="236px">Name of Entity (if any)</asp:Label>
                                                              
                                                        </td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label43" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="288px">Status (partner, shareholder, employee, contractor)</asp:Label>
                                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 631px; height: 4px">
                                                                                  
                                                                 <asp:TextBox ID="txtPhyEntName" runat="server" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" TabIndex="53" Width="364px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                            <asp:TextBox ID="txtPhyStatus" runat="server" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" TabIndex="54"
                                                                Width="328px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 631px; height: 4px">
                                                                                  
                                                            <asp:Label ID="Label20" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="316px">Name of partners, shareholders, employers or associates</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 800px; height: 4px">
                                                                                   
                                                               
                                                            <asp:TextBox ID="txtPhyPartners" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="55" Width="656px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 631px; height: 4px">
                                                        </td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="3" style="width: 121px;
                                                            height: 4px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 804px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 750px; height: 14px">
                                                                                   
                                                                                   
                                                                 
                                                            <asp:Label ID="Label10" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="596px">If coverage is desired for entity listed above, you must provide evidence of current coverage for the entity.</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 650px; height: 14px">
                                                                             
                                                            <asp:Label ID="Label9" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="410px">29. Do you practice with other physicians not listed above in Question 28?</asp:Label>
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 350px; height: 14px">
                                                            <asp:RadioButtonList ID="rdoMcaOtherPhy" runat="server" Font-Names="Tahoma"
                                                                Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="56" Width="80px">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 4px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 800px; height: 13px">
                                                                                   
                                                                     
                                                            <asp:Label ID="Label23" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="764px">If yes, list the physicians(s) and indicate the nature of your association (e.g. common billing, share office, employees, common letterhead).</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px; height: 13px">
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="4" style="width: 572px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 572px; height: 14px">
                                                                                 <asp:Label
                                                                ID="Label37" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="160px">Name of Physician(s)</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 572px; height: 14px">
                                                            <asp:Label ID="Label24" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="160px">Nature of Association</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 572px; height: 14px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 572px; height: 14px">
                                                                                
                                                            <asp:TextBox ID="txtPhyName" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="57" Width="280px"></asp:TextBox></td>
                                                        <td align="left" colspan="1" style="width: 1px; height: 14px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 572px; height: 14px">
                                                            <asp:TextBox ID="txtPhyAssoc" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="58" Width="308px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 572px; height: 14px">
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 572px; height: 14px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" colspan="5" style="width: 572px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 200px;">
                                                              
                                                            </td>
                                                        <td align="center" bordercolor="silver" style="width: 1px;">
                                                            </td>
                                                        <td align="center" bordercolor="silver" style="width: 154px;">
                                                            </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table12" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px; height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 750px; height: 11px">
                                                               
                                                <asp:Label ID="Label11" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="612px">30. Do all members of your night, weekend, vacation or illness "on-call" referral group carry professional liability?</asp:Label>
                                                             </td>
                                            <td align="left" colspan="1" style="width: 350px; height: 11px">
                                                <asp:RadioButtonList ID="rdoMcaRefferral" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                    RepeatDirection="Horizontal" TabIndex="59" Width="76px">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 6px">
                                                               <asp:Label ID="Label38" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="256px">If no, list the names of those who do not:</asp:Label></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 6px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 6px">
                                                              
                                                <asp:TextBox ID="txtRefferralDesc"
                                                        runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="60"
                                                        Width="564px"></asp:TextBox></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 6px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px">
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
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" TabIndex="61"
                                                    Text="< Prev" Width="54px" OnClick="btnPrevBottom_Click" /> 
                                                <asp:Button ID="btnNextBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" TabIndex="62"
                                                    Text="Next >" Width="54px" OnClick="btnNextBottom_Click" />
                                                    
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
                style="z-index: 102; left: 424px; width: 35px; position: absolute; top: 1308px;
                height: 22px" type="hidden" value="false" />
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Application4.aspx.cs" Inherits="Application4" %>
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
                                            <td align="right" style="width: 286px">
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
                                <td align="right" colspan="1" style="font-size: 5pt; width: 815px; height: 17px"
                                    valign="top">
                                         
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; width: 815px; height: 19px">
                                    <table id="Table3" border="0" cellpadding="1" cellspacing="1" style="width: 814px;
                                        height: 76px" width="814">
                                        <tr>
                                            <td align="left" style="font-size: 1pt; height: 255px" valign="top">
                                                <table id="Table4" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td colspan="2" style="width: 300px">
                                                                                   
                                                              
                                                            <asp:Label ID="lblTypeAddress1" runat="server" CssClass="headform3" Font-Bold="True"
                                                                Font-Names="Tahoma" Font-Size="9pt" Width="240px">D. Non-Physician Heathcare Providers</asp:Label></td>
                                                        <td style="width: 92px">
                                                        </td>
                                                        <td style="width: 321px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="width: 700px">
                                                                                   
                                                                                 <asp:Label ID="Label29" runat="server" CssClass="headfield1"
                                                                EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="556px">31. Please indicate below and list the hours per week if you, your medical partnership or medical</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                        </td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:Label ID="Label1" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="140px">Total Hours Per Week</asp:Label></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:Label ID="Label2" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="124px">Number of Employees</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                   </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaLab" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Laboratory Technicians" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtLabHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="3" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtLabEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="4" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                   </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                             <asp:CheckBox ID="chkMcaPhy" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Physiotherapist" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtPhyHours" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="5" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtPhyEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="6" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaXray" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="X-ray Technicians" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtXrayHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="7" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtXrayEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="8" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaOther" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Others" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtOtherHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="9" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtOtherEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="10" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaNurseAnes" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Nurse Anesthetists" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtNurseAnesHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="11" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtNurseAnesEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="12" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaNurseMid" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Nurse Midwives" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                             <asp:TextBox ID="txtNurseMidHours" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="13" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtNurseMidEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="14" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaNursePerf" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Nurse Perfusionist" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtNursePerfHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="15" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtNursePerfEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="16" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaNursePrac" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Nurse Practitioner" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtNursePracHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="17" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtNursePracEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="18" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaOpto" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Optometrists/Opticians" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                             <asp:TextBox ID="txtOptoHours" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="19" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtOptoEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="20" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaPhyAss" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Physician's assistant" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtPhyAssHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="21" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtPhyAssEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="22" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px; height: 20px">
                                                            <asp:CheckBox ID="chkMcaPsych" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Psychologists" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px; height: 20px">
                                                             <asp:TextBox ID="txtPsychHours" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="23" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:TextBox ID="txtPsychEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="24" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaScrub" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Scrub Nurses" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtScrubHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="25" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtScrubEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="26" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px">
                                                            <asp:CheckBox ID="chkMcaSurgical" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Surgical Technicians" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px">
                                                            <asp:TextBox ID="txtSurgicalHours" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="27" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtSurgicalEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="28" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 125px; height: 20px">
                                                        </td>
                                                        <td align="left" bordercolor="silver" style="width: 214px; height: 20px">
                                                            <asp:CheckBox ID="chkOtherDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Text="Others (describe)" /></td>
                                                        <td align="center" bordercolor="silver" style="width: 92px; height: 20px">
                                                             <asp:TextBox ID="txtOtherDescHours" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="29" Width="60px"></asp:TextBox></td>
                                                        <td align="left" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:TextBox ID="txtOtherDescEmp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="30" Width="60px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" bordercolor="silver" colspan="4"
                                                            style="width: 158px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="4" style="width: 825px">
                                                            <asp:Label ID="Label5" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="608px">32. If you, your medical partnership or medical corporation employs any health care professionals listed above</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="4" style="width: 825px">
                                                                                
                                                            <asp:Label ID="Label3" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="516px">please indicate the individual's name, specialty, insurance carrier and limits of liability below.</asp:Label></td>
                                                    </tr>
                                                </table>
                                                <table id="Table7" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 760px; height: 7px">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px">
                                                            <asp:Label ID="Label31" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="72px">Name</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                            <asp:Label ID="Label32" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="68px">Specialty</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px">
                                                            <asp:Label ID="Label33" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="68px">Insured By</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px">
                                                            <asp:Label ID="Label34" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="108px">Limits of Liability</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 20px;">
                                                            <asp:TextBox ID="txtHCName1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="31" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px;">
                                                                   
                                                            <asp:TextBox ID="txtHCSpeciality1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="32" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 20px;">
                                                            <asp:TextBox ID="txtHCInsured1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px"  TabIndex="33" Width="92px"></asp:TextBox> </td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 20px;">
                                                            <asp:TextBox ID="txtHCLimits1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="34" Width="108px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 22px">
                                                            <asp:TextBox ID="txtHCName2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="35" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px">
                                                                   
                                                            <asp:TextBox ID="txtHCSpecialty2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="36" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 22px">
                                                            <asp:TextBox ID="txtHCInsured2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px"  TabIndex="37" Width="92px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 22px">
                                                            <asp:TextBox ID="txtHCLimits2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="38" Width="108px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 281px; height: 20px">
                                                            <asp:TextBox ID="txtHCName3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="39" Width="228px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px">
                                                                   
                                                            <asp:TextBox ID="txtHCSpecialty3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="40" Width="120px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 222px; height: 20px">
                                                            <asp:TextBox ID="txtHCInsured3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px"  TabIndex="41" Width="92px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:TextBox ID="txtHCLimits3" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" TabIndex="42" Width="108px"></asp:TextBox></td>
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
                                                        <td align="left" colspan="1" style="width: 375px; height: 11px">
                                                                                   
                                                            <asp:Label ID="Label4" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="148px">E. Facility Association</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 900px; height: 11px">
                                                            <asp:Label ID="Label16" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="632px">33. Indicate if you are employed or contracted to provide professional services with any of the following facilities:</asp:Label>
                                                                                  </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 375px; height: 3px">
                                                                                  
                                                                                   
                                                                                  <asp:CheckBox
                                                                ID="chkMcaNone" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Check here if none." TabIndex="43" />
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="width: 121px;
                                                            height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table6" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="3" style="width: 606px; height: 3px"><table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px; height: 20px;">
                                                                           </td>
                                                                <td align="left" bordercolor="silver" style="height: 20px;" width="320">
                                                                    <asp:CheckBox ID="chkMcaBlood" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Blood Bank" TabIndex="44" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px; height: 20px;">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px; height: 20px;">
                                                                    <asp:CheckBox ID="chkMcaPsy" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Hospital, psychiatric" Width="128px" TabIndex="53" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px; height: 22px;">
                                                                           </td>
                                                                <td align="left" bordercolor="silver" style="height: 22px;" width="320">
                                                                     <asp:CheckBox ID="chkMcaBirthing" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Birthing Center" TabIndex="45" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px; height: 22px;">
                                                                     </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px; height: 22px;">
                                                                    <asp:CheckBox ID="chkMcaInd" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Industrial Firm medical care facility" TabIndex="54" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" width="320">
                                                                    <asp:CheckBox ID="chkMcaCity" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="City, County, State or Federal Agency" Width="244px" TabIndex="46" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px">
                                                                    <asp:CheckBox ID="chkMcaLaboratory" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Laboratory" TabIndex="55" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" width="320">
                                                                    <asp:CheckBox ID="chkMcaClinic" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Clinic with bed and board facilities" TabIndex="47" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px">
                                                                    <asp:CheckBox ID="chkMcaNursing" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Nursing Home" Width="128px" TabIndex="56" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" width="320">
                                                                    <asp:CheckBox ID="chkMcaEmergency" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Emergency Treatment facility (freestanding)" Width="276px" TabIndex="48" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px">
                                                                    <asp:CheckBox ID="chkMcaSanitarium" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Sanitarium" Width="120px" TabIndex="57" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px; height: 20px;">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="height: 20px;" width="320">
                                                                    <asp:CheckBox ID="chkMcaEmerHospital" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Emergency Treatment facility (hospital)" Width="248px" TabIndex="49" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px; height: 20px;">
                                                                     </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px; height: 20px;"><asp:CheckBox ID="chkMcaUrgent" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Urgent Care Clinic" Width="120px" TabIndex="58" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px; height: 21px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="height: 21px" width="320">
                                                                    <asp:CheckBox ID="chkMcaFreeStanding" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Freestanding Surgical facility" TabIndex="50" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px; height: 21px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px; height: 21px"><asp:CheckBox ID="chkMcaXrayFacility" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="SanitariumX-Ray or Imaging Facility" Width="224px" TabIndex="59" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" width="320">
                                                                    <asp:CheckBox ID="chkMcaHospital" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Hospital (other than member of medical staff)" Width="276px" TabIndex="51" /></td>
                                                                <td align="left" bordercolor="silver" style="width: 9px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px"><asp:CheckBox ID="chkMcaOtherHC" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Other Health Care Facility" Width="188px" TabIndex="60" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="1" style="width: 125px">
                                                                </td>
                                                                <td align="left" bordercolor="silver" width="320">
                                                                    <asp:CheckBox ID="chkMcaConva" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                        Text="Hospital, Convalescent" TabIndex="52" /></td>
                                                                <td align="center" bordercolor="silver" style="width: 9px">
                                                                     </td>
                                                                <td align="left" bordercolor="silver" style="width: 321px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" bordercolor="silver" colspan="4"
                                                            style="width: 158px; height: 3px">
                                                                </td>
                                                            </tr>
                                                        </table>
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
                                                        <td align="left" colspan="4" style="width: 920px; height: 11px">
                                                            <asp:Label ID="Label6" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="720px">34. if you have a written contract with any of the facilities listed above, please attach any copy of the contract to this Application.</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 315px; height: 11px">
                                                            <asp:Label ID="Label28" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="100px">FACILITY #1:</asp:Label>
                                                                    </td>
                                                        <td align="left" colspan="1" style="width: 364px; height: 11px">
                                                                        
                                                        </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                             </td>
                                                        <td align="left" colspan="1" style="width: 603px; height: 11px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 315px; height: 4px">
                                                                
                                                            <asp:Label ID="Label42" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="40px">Name:</asp:Label>
                                                              
                                                        </td>
                                                        <td align="left" style="width: 364px; height: 4px">
                                                            <asp:Label ID="Label43" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="36px">Address:</asp:Label>
                                                                    </td>
                                                        <td align="left" colspan="2" style="width: 375px; height: 4px">
                                                            <asp:Label ID="Label7" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="112px">Type of Association:</asp:Label>
                                                              </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 315px; height: 4px">
                                                                                   
                                                             <asp:TextBox ID="txtFacilityName1" runat="server" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" TabIndex="61" Width="204px"></asp:TextBox></td>
                                                        <td align="left" style="width: 364px; height: 4px">
                                                            <asp:TextBox ID="txtFacilityAddr1" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px" onclick="ShowDateTimePicker7();" TabIndex="62" Width="320px"></asp:TextBox></td>
                                                        <td align="left" colspan="2" style="width: 375px; height: 4px">
                                                            <asp:TextBox ID="txtFacilityType1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                onclick="ShowDateTimePicker7();" TabIndex="63" Width="184px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 315px; height: 4px">
                                                               
                                                            <asp:Label ID="Label8" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="40px">Duties:</asp:Label>
                                                                              
                                                        </td>
                                                        <td align="left" style="width: 364px; height: 4px">
                                                            <asp:Label ID="Label9" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="340px">Numbers of Hours per Week Percentage of Weekly Practice</asp:Label></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                        </td>
                                                        <td align="left" style="width: 603px; height: 4px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 315px; height: 4px">
                                                                                    
                                                            <asp:TextBox ID="txtFacilityDuties1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="64" Width="204px"></asp:TextBox></td>
                                                        <td align="left" style="width: 364px; height: 4px">
                                                            <asp:TextBox ID="txtFacilityNumbers1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                onclick="ShowDateTimePicker7();" TabIndex="65" Width="320px"></asp:TextBox></td>
                                                        <td align="left" style="width: 375px; height: 4px">
                                                        </td>
                                                        <td align="left" style="width: 603px; height: 4px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="width: 121px;
                                                            height: 4px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="Table13" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px; height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 15px">
                                                <asp:Label ID="Label39" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="264px">Is the facility insured for professional liability?</asp:Label>
                                                                    </td>
                                            <td align="left" colspan="1" style="width: 429px; height: 15px">
                                                <asp:RadioButtonList ID="rdoMcaProfLiab1" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="66" Width="80px">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 21px">
                                                <asp:Label ID="Label10" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="264px">Does the facility extend coverage to you?</asp:Label></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 21px">
                                                <asp:RadioButtonList ID="rdoMcaExtendedCov1" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="67" Width="80px">
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
                                            <td align="left" colspan="2" style="width: 606px; height: 3px"><table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                <tr>
                                                    <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="1" style="width: 315px; height: 11px">
                                                        <asp:Label ID="Label12" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="100px">FACILITY #2:</asp:Label>
                                                             </td>
                                                    <td align="left" colspan="1" style="width: 364px; height: 11px">
                                                                    
                                                    </td>
                                                    <td align="left" colspan="1" style="width: 429px; height: 11px">
                                                         </td>
                                                    <td align="left" colspan="1" style="width: 603px; height: 11px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 315px; height: 4px">
                                                            
                                                        <asp:Label ID="Label13" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="40px">Name:</asp:Label>
                                                          
                                                    </td>
                                                    <td align="left" style="width: 364px; height: 4px">
                                                        <asp:Label ID="Label14" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="36px">Address:</asp:Label>
                                                                </td>
                                                    <td align="left" colspan="2" style="width: 375px; height: 4px">
                                                        <asp:Label ID="Label15" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="112px">Type of Association:</asp:Label>
                                                          </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 315px; height: 4px">
                                                                               
                                                         <asp:TextBox ID="txtFacilityName2" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                            Height="12px" TabIndex="68" Width="204px"></asp:TextBox></td>
                                                    <td align="left" style="width: 364px; height: 4px">
                                                        <asp:TextBox ID="txtFacilityAddr2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            onclick="ShowDateTimePicker7();" TabIndex="69" Width="320px"></asp:TextBox></td>
                                                    <td align="left" colspan="2" style="width: 375px; height: 4px">
                                                        <asp:TextBox ID="txtFacilityType2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            onclick="ShowDateTimePicker7();" TabIndex="70" Width="184px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 315px; height: 4px">
                                                           
                                                        <asp:Label ID="Label17" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="40px">Duties:</asp:Label>
                                                                          
                                                    </td>
                                                    <td align="left" style="width: 364px; height: 4px">
                                                        <asp:Label ID="Label18" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                            Font-Size="9pt" Width="340px">Numbers of Hours per Week Percentage of Weekly Practice</asp:Label></td>
                                                    <td align="left" style="width: 375px; height: 4px">
                                                    </td>
                                                    <td align="left" style="width: 603px; height: 4px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 315px; height: 4px">
                                                                                
                                                        <asp:TextBox ID="txtFacilityDuties2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            TabIndex="71" Width="204px"></asp:TextBox></td>
                                                    <td align="left" style="width: 364px; height: 4px">
                                                        <asp:TextBox ID="txtFacilityNumbers2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                            onclick="ShowDateTimePicker7();" TabIndex="72" Width="320px"></asp:TextBox></td>
                                                    <td align="left" style="width: 375px; height: 4px">
                                                    </td>
                                                    <td align="left" style="width: 603px; height: 4px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="width: 121px;
                                                            height: 4px">
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
                                                        <td align="left" colspan="1" style="width: 606px; height: 15px">
                                                            <asp:Label ID="Label11" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="264px">Is the facility insured for professional liability?</asp:Label>
                                                                                </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 15px">
                                                            <asp:RadioButtonList ID="rdoMcaProfLiab" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="73" Width="80px">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 606px; height: 21px">
                                                            <asp:Label ID="Label19" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="264px">Does the facility extend coverage to you?</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 21px">
                                                            <asp:RadioButtonList ID="rdoMcaExtendedCov" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="74" Width="80px">
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
                                                <table id="Table16" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                        height: 1px">
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 3px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 1033px; height: 15px">
                                                                           
                                                            <asp:Label ID="Label23" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="220px">F. Medical Practice Description</asp:Label>
                                                                </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 15px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 1033px; height: 12px">
                                                            <asp:Label ID="Label22" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="264px">35. Are you applying for full-time coverage?</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 125px; height: 12px">
                                                            <asp:RadioButtonList ID="rdoMcaFullTimeCov" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="75" Width="80px">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 1300px; height: 21px">
                                                            <asp:Label ID="Label20" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="572px">36. Are you applying for part-time coverage, not more than 20 hours per week, non-surgical practice?</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 125px; height: 21px">
                                                            <asp:RadioButtonList ID="rdoMcaPartTimeCov" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" RepeatDirection="Horizontal" TabIndex="76" Width="80px">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 1033px; height: 21px">
                                                            <asp:Label ID="Label24" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="232px">37. If yes, please complete the following:</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 21px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 1033px; height: 9px">
                                                                                   
                                                                                   
                                                                             
                                                            <asp:TextBox ID="txtDaysPWeek" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="77" Width="60px"></asp:TextBox>
                                                             
                                                            <asp:Label ID="Label25" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="88px">Days per week</asp:Label>
                                                                                  
                                                                       
                                                            <asp:TextBox ID="txtHoursPDayOffice" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="78" Width="60px"></asp:TextBox>
                                                             
                                                            <asp:Label ID="Label26" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="132px">Hours per day (office)</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 9px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 1033px; height: 7px">
                                                                                   
                                                                                   
                                                                             
                                                            <asp:TextBox ID="txtPatienPWeek" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="79" Width="60px"></asp:TextBox>
                                                             
                                                            <asp:Label ID="Label27" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="100px">Patients per week</asp:Label>
                                                                           
                                                            <asp:TextBox ID="txtHoursPDayHosp" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="80" Width="60px"></asp:TextBox>
                                                             
                                                            <asp:Label ID="Label30" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="144px">Hours per day (hospital)</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 820px; height: 7px">
                                                            <asp:Label ID="Label35" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="780px">38. Provide a general description of your activities for which other professional liability coverage is provided and will not be covered by PRMD:</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2" style="width: 606px; height: 7px">
                                                                       
                                                            <asp:TextBox ID="txtActDesc" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="28px"
                                                                TabIndex="81" TextMode="MultiLine" Width="732px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" background="Images2/Barra3.jpg" colspan="2" style="width: 121px;
                                                height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="Table17" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 760px; height: 7px">
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px;">
                                                            <asp:Label ID="Label36" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="372px">39. Indicate your weekly average practice activity</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px;">
                                                            <asp:Label ID="Label38" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="80px">Number/Week</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 100px;">
                                                            <asp:Label ID="Label40" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="84px">Hour/Week</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px">
                                                            <asp:Label ID="Label37" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="240px">Patients seen in the office (non-surgical)</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px">
                                                            <asp:TextBox ID="txtapp339Number1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                 TabIndex="82" Width="52px"></asp:TextBox> </td>
                                                        <td align="center" bordercolor="silver" style="width: 100px">
                                                            <asp:TextBox ID="txtapp339Hours1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="83" Width="44px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px;">
                                                            <asp:Label ID="Label41" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="244px">Patients seen in the hospital (non-surgical)</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px;">
                                                            <asp:TextBox ID="txtapp339Number2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                 TabIndex="84" Width="52px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 100px;">
                                                            <asp:TextBox ID="txtapp339Hours2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="85" Width="44px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px;">
                                                            <asp:Label ID="Label44" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="344px">Patients seen only by paramedical personnel that you employ</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px;">
                                                            <asp:TextBox ID="txtapp339Number3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="86" Width="52px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 100px;">
                                                            <asp:TextBox ID="txtapp339Hours3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="87" Width="44px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px;">
                                                            <asp:Label ID="Label47" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="220px">Number of surgical assists you perform</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px;">
                                                            <asp:TextBox ID="txtapp339Number4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="88" Width="52px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 100px;">
                                                            <asp:TextBox ID="txtapp339Hours4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                TabIndex="89" Width="44px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px;">
                                                            <asp:Label ID="Label45" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="376px">Anesthesiologists: Procedures for which you administer anesthesia</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px;">
                                                            <asp:TextBox ID="txtapp339Number5" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px"  TabIndex="90" Width="52px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 100px;">
                                                            <asp:TextBox ID="txtapp339Hours5" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="12px"  TabIndex="91" Width="44px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" style="width: 500px;">
                                                            <asp:Label ID="Label46" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="412px">Pathologists/radiologists: Procedures you perform without patient contact</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 107px;">
                                                            <asp:TextBox ID="txtapp339Number6" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                 TabIndex="92" Width="52px"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 100px;">
                                                            <asp:TextBox ID="txtapp339Hours6" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                 TabIndex="93" Width="44px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" background="Images2/Barra3.jpg" bordercolor="silver" colspan="5"
                                                            style="width: 630px; height: 3px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 7px">
                                                                     </td>
                                            <td align="right" colspan="1" style="width: 330px; height: 7px">
                                                <asp:Button ID="btnPrevBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnPrevBottom_Click"
                                                    TabIndex="95" Text="< Prev" Width="54px" /> 
                                                <asp:Button ID="btnNextBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="btnNextBottom_Click"
                                                    TabIndex="96" Text="Next >" Width="54px" />
                                                    
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
                </td>
            </tr>
        </table>
    
    </div>
        <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
            style="z-index: 102; left: 440px; width: 35px; position: absolute; top: 1520px;
            height: 22px" type="hidden" value="false" />
    </form>
</body>
</html>

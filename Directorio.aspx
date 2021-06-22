<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Directorio.aspx.cs" Inherits="Directorio" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
            <%@ Register Src="~/MS_Control/MultipleSelection.ascx" TagName="MultipleSelection" TagPrefix="uc1" %>
                <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
                    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

                    <html xmlns="http://www.w3.org/1999/xhtml">

                    <head id="Head1" runat="server">
                        <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0" />
                        <meta name="CODE_LANGUAGE" Content="C#" />
                        <meta name="vs_defaultClientScript" content="JavaScript" />
                        <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
                        <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                        <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
                        <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                        <script src="js/load.js" type="text/javascript"></script>
                        <title>ePMS | electronic Policy Manager Solution</title>
                        <style type="text/css">
                            .headfield1 {
                                text-align: left;
                                margin-bottom: 0px;
                                font-weight: 700;
                            }
                            
                            .style9 {
                                height: 19px;
                                width: 102px;
                            }
                            
                            .style10 {
                                height: 19px;
                                width: 335px;
                            }
                            
                            .headForm2 {
                                font-family: Arial, Helvetica, sans-serif;
                                font-size: 12px;
                                font-style: normal;
                                font-weight: normal;
                                color: #ffffff;
                                text-decoration: none
                            }
                            
                            .headForm3 {
                                font-family: Arial, Helvetica, sans-serif;
                                font-size: 12px;
                                font-style: normal;
                                font-weight: normal;
                                color: #004f7f;
                                text-decoration: none
                            }
                            
                            .numbers {
                                font-family: Arial, Helvetica, sans-serif;
                                font-size: 12px;
                                font-style: normal;
                                font-weight: bold;
                                color: #ffffff;
                                text-decoration: none
                            }
                            
                            .HeadField1 {
                                text-align: left;
                            }
                            
                            .style59 {
                                width: 141px;
                                height: 19px;
                            }
                            
                            .style60 {
                                width: 213px;
                                height: 19px;
                            }
                            
                            .style61 {
                                height: 19px;
                            }
                            
                            .style62 {
                                width: 180px;
                                height: 19px;
                            }
                            
                            .style63 {
                                width: 141px;
                            }
                        </style>
                    </head>
                    <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                    <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                    <script type="text/javascript">
                        function dpShowDateFrom() {
                            $('#<%= txtDateFrom.ClientID %>').datepicker('show');
                        }

                        function dpShowDateTo() {
                            $('#<%= txtDateTo.ClientID %>').datepicker('show');
                        }
                        $(function() {
                            $('#<%= txtDateFrom.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });

                            $('#<%= txtDateTo.ClientID %>').datepicker({
                                changeMonth: true,
                                changeYear: true
                            });
                        });
                    </script>

                    <body>
                        <form id="form1" runat="server">
                            <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="True">
                            </ajaxToolkit:ToolkitScriptManager>
                            <p>
                                <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                            </p>
                            <div class="container-xl mb-4 p-18">
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label46" runat="server" class="fs-16">Directory:</asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="float-end">
                                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="22" Text="Delete" />
                                            <asp:Button ID="btnAdd2" runat="server" OnClick="btnAdd2_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="23" Text="Add" Visible="False" />
                                            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="24" Text="Modify" Visible="False" />
                                            <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="27" Text="Save" Visible="False" />
                                            <asp:Button ID="BtnPrint" runat="server" OnClick="BtnExport_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="26" Text="Print" />
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="25" Text="Cancel" Visible="False" />
                                            <asp:Button ID="BtnExit" runat="server" OnClick="BtnExit_Click" class="btn-h-30 btn-bg-theme2 btn-r-4" TabIndex="26" Text="Exit" />
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <hr />
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="col">
                                                <asp:Label id="Label3" runat="server" class="mb1">Available Columns:</asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:ListBox id="lbxAvailable" class="form-control mb-1 lst-h-104" runat="server" Font-Size="9pt" onselectedindexchanged="lbxAvailable_SelectedIndexChanged">
                                                    <asp:ListItem Value="TaskControlID">Control No</asp:ListItem>
                                                    <asp:ListItem Value="CustomerNo">Customer Number</asp:ListItem>
                                                    <asp:ListItem Value="IndividualPrimList">Individual Primary</asp:ListItem>
                                                    <asp:ListItem Value="IndividualExcList">Individual Excess</asp:ListItem>
                                                    <asp:ListItem Value="CorporatePrimList">Corporate Primary</asp:ListItem>
                                                    <asp:ListItem Value="CorporateExcList">Corporate Excess</asp:ListItem>
                                                    <asp:ListItem Value="IndividualPrimTailList">Individual Primary Tail</asp:ListItem>
                                                    <asp:ListItem Value="IndividualExcTailList">Individual Excess Tail</asp:ListItem>
                                                    <asp:ListItem Value="CorporatePrimTailList">Corporate Primary Tail</asp:ListItem>
                                                    <asp:ListItem Value="CorporateExcTailList">Corporate Excess Tail</asp:ListItem>
                                                    <%--<asp:ListItem Value="PolicyList">Policies</asp:ListItem>--%>
                                                        <asp:ListItem Value="Firstna">Name</asp:ListItem>
                                                        <asp:ListItem Value="Initial">Initial</asp:ListItem>
                                                        <asp:ListItem Value="Lastna1">Last Name</asp:ListItem>
                                                        <asp:ListItem Value="Lastna2">Last Name 2</asp:ListItem>
                                                        <asp:ListItem Value="Specialty">Specialty</asp:ListItem>
                                                        <asp:ListItem Value="ISOCode">Code</asp:ListItem>
                                                        <%--<asp:ListItem Value="PriPolLimits1">Limits Individual</asp:ListItem>
                                                <asp:ListItem Value="CorpPriPolLimits1">Limits Corporate</asp:ListItem>--%>
                                                            <asp:ListItem Value="LimitsIndvPrimList">Limits Individual Primary</asp:ListItem>
                                                            <asp:ListItem Value="LimitsIndvExcList">Limits Individual Excess</asp:ListItem>
                                                            <asp:ListItem Value="LimitsCorpPrimList">Limits Corporate Primary</asp:ListItem>
                                                            <asp:ListItem Value="LimitsCorpExcList">Limits Corporate Excess</asp:ListItem>
                                                            <%--<asp:ListItem Value="RetroactiveDate">Retro Date</asp:ListItem>--%>
                                                                <asp:ListItem Value="RetroDtIndvPrimList">Retroactive Date Individual Primary</asp:ListItem>
                                                                <asp:ListItem Value="RetroDtIndvExcList">Retroactive Date Individual Excess</asp:ListItem>
                                                                <asp:ListItem Value="RetroDtCorpPrimList">Retroactive Date Corporate Primary</asp:ListItem>
                                                                <asp:ListItem Value="RetroDtCorpExcList">Retroactive Date Corporate Excess</asp:ListItem>
                                                                <asp:ListItem Value="StatusIndvPrimList">Status Individual Primary</asp:ListItem>
                                                                <asp:ListItem Value="StatusIndvExcList">Status Individual Excess</asp:ListItem>
                                                                <asp:ListItem Value="StatusCorpPrimList">Status Corporate Primary</asp:ListItem>
                                                                <asp:ListItem Value="StatusCorpExcList">Status Corporate Excess</asp:ListItem>
                                                                <asp:ListItem Value="CancDtIndvPrimList">Cancellation Date Individual Primary</asp:ListItem>
                                                                <asp:ListItem Value="CancDtIndvExcList">Cancellation Date Individual Excess</asp:ListItem>
                                                                <asp:ListItem Value="CancDtCorpPrimList">Cancellation Date Corporate Primary</asp:ListItem>
                                                                <asp:ListItem Value="CancDtCorpExcList">Cancellation Date Corporate Excess</asp:ListItem>
                                                                <asp:ListItem Value="CancRIndvPrimList">Cancellation Reason Individual Primary</asp:ListItem>
                                                                <asp:ListItem Value="CancRIndvExcList">Cancellation Reason Individual Excess</asp:ListItem>
                                                                <asp:ListItem Value="CancRCorpPrimList">Cancellation Reason Corporate Primary</asp:ListItem>
                                                                <asp:ListItem Value="CancRCorpExcList">Cancellation Reason Corporate Excess</asp:ListItem>
                                                                <asp:ListItem Value="PriCarierName1">Primary Carrier Name</asp:ListItem>
                                                                <asp:ListItem Value="Homeph">Home Phone</asp:ListItem>
                                                                <asp:ListItem Value="Cellular">Cell Phone</asp:ListItem>
                                                                <asp:ListItem Value="Jobph">Job Phone</asp:ListItem>
                                                                <asp:ListItem Value="Faxph">Fax Phone</asp:ListItem>
                                                                <asp:ListItem Value="Email">Email</asp:ListItem>
                                                                <asp:ListItem Value="PhysAdds1">Office Address</asp:ListItem>
                                                                <asp:ListItem Value="PhysAdds2">Office Address 2</asp:ListItem>
                                                                <asp:ListItem Value="PhysCity">Office City</asp:ListItem>
                                                                <asp:ListItem Value="PhysState">Office State</asp:ListItem>
                                                                <asp:ListItem Value="PhysZip">Office Zip</asp:ListItem>
                                                                <asp:ListItem Value="Adds1">Postal Address</asp:ListItem>
                                                                <asp:ListItem Value="Adds2">Postal Address 2</asp:ListItem>
                                                                <asp:ListItem Value="City">Postal City</asp:ListItem>
                                                                <asp:ListItem Value="State">Postal State</asp:ListItem>
                                                                <asp:ListItem Value="Zip">Postal Zip</asp:ListItem>
                                                                <asp:ListItem Value="Birthday">Date of Birth</asp:ListItem>
                                                                <asp:ListItem Value="MedicalSchool">Medical School</asp:ListItem>
                                                                <asp:ListItem Value="Internship">Internship</asp:ListItem>
                                                                <asp:ListItem Value="Residency">Residency</asp:ListItem>
                                                                <asp:ListItem Value="Fellowship">Fellowship</asp:ListItem>
                                                                <asp:ListItem Value="BoardCertified">Board Certification</asp:ListItem>
                                                                <asp:ListItem Value="MedicalPractice">Medical Practice Type</asp:ListItem>
                                                                <asp:ListItem Value="PrivilegeList">Privileges</asp:ListItem>
                                                                <asp:ListItem Value="Status">Status</asp:ListItem>
                                                                <asp:ListItem Value="AgencyIndvPrimList">Agency Individual Primary</asp:ListItem>
                                                                <asp:ListItem Value="AgencyIndvExcList">Agency Individual Excess</asp:ListItem>
                                                                <asp:ListItem Value="AgencyCorpPrimList">Agency Corporate Primary</asp:ListItem>
                                                                <asp:ListItem Value="AgencyCorpExcList">Agency Corporate Excess</asp:ListItem>
                                                                <asp:ListItem Value="AgentIndvPrimList">Agent Individual Primary</asp:ListItem>
                                                                <asp:ListItem Value="AgentIndvExcList">Agent Individual Excess</asp:ListItem>
                                                                <asp:ListItem Value="AgentCorpPrimList">Agent Corporate Primary</asp:ListItem>
                                                                <asp:ListItem Value="AgentCorpExcList">Agent Corporate Excess</asp:ListItem>
                                                                <asp:ListItem Value="ShareholderNo">Shareholder #</asp:ListItem>
                                                                <asp:ListItem Value="EntryDate">Entry Date</asp:ListItem>
                                                                <asp:ListItem Value="PolGroup">Group</asp:ListItem>
                                                                <%--<asp:ListItem Value="InvoiceNumber">Discount Percentage (%)</asp:ListItem>--%>
                                                                    <asp:ListItem Value="HasClaim">Has Claim?</asp:ListItem>
                                                                    <asp:ListItem Value="ClaimNo">Claim Number</asp:ListItem>

                                                                    <asp:ListItem Value="EffectiveDate">Effective Date</asp:ListItem>

                                                                    <asp:ListItem Value="SpecialityLabLimit">Laboratory Limits</asp:ListItem>

                                                                    <asp:ListItem Value="CorporateLabPrimTailList" Enabled="False"></asp:ListItem>
                                                                    <asp:ListItem Value="CyberTailList">Cyber Tail List</asp:ListItem>
                                                                    <asp:ListItem Value="CorporateLabPrimTailList">Corporate Lab Primary Tail List</asp:ListItem>
                                                                    <asp:ListItem Value="CorporateLabExcTailList">Corporate Lab Excess Tail List</asp:ListItem>
                                                                    <asp:ListItem Value="AspenLabExcTailList">Aspen Lab Excess Tail</asp:ListItem>

                                                                    <asp:ListItem Value="AspenPrimaryPolicyTailList">Aspen Primary Policy Tail</asp:ListItem>
                                                                    <asp:ListItem Value="AspenExcessPolicyTailList">Aspen Excess Policy Tail</asp:ListItem>
                                                                    <asp:ListItem Value="AspenAPolicyTailList">AAPT Policy Tail</asp:ListItem>
                                                                    <asp:ListItem Value="LimitCyberList">Limits Cyber</asp:ListItem>
                                                                    <asp:ListItem Value="LimitCorpLabPrimList">Limits Corporate Lab Primary</asp:ListItem>
                                                                    <asp:ListItem Value="LimitCorpLExcPrimList">Limits Corporate Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="AspenLabExcPrimList">Limits Aspen Lab Excess List</asp:ListItem>
                                                                    <asp:ListItem Value="AspenLabAPrimList">Limits Aspen Primary</asp:ListItem>
                                                                    <asp:ListItem Value="AspenLabAExcLimList">Limits Aspen Excess</asp:ListItem>
                                                                    <asp:ListItem Value="AspenLabAAPTLimList">Limts AAPT</asp:ListItem>
                                                                    <asp:ListItem Value="RetroDTCyberPrimList">Retroactive Date Cyber</asp:ListItem>
                                                                    <asp:ListItem Value="RetroDTCLPrimList">Retroactive Date Corp Lab Primary</asp:ListItem>

                                                                    <asp:ListItem Value="RetroDTCLExcList">Retroactive Date Corp Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="RetroDTALEList">Retroactive Date Aspen Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="RetroDTAAPList">Retroactive Date Aspen Primary</asp:ListItem>

                                                                    <asp:ListItem Value="RetroDTAAEList">Retroactive Date Aspen Excess</asp:ListItem>
                                                                    <asp:ListItem Value="RetroDTAAPTList">Retroactive Date AAPT</asp:ListItem>
                                                                    <asp:ListItem Value="StatusCyberList">Status Cyber</asp:ListItem>
                                                                    <asp:ListItem Value="StatusCLPList">Status Corporate Lab Primary</asp:ListItem>
                                                                    <asp:ListItem Value="StatusCLEList">Status Corporate Lab Excess
                                                                    </asp:ListItem>
                                                                    <asp:ListItem Value="StatusALEList">Status Aspen Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="StatusAAPList">Status Aspen Primary</asp:ListItem>
                                                                    <asp:ListItem Value="StatusAAEList">Status Aspen Excess</asp:ListItem>
                                                                    <asp:ListItem Value="StatusAAPTList">Status AAPT</asp:ListItem>
                                                                    <asp:ListItem Value="CancDtEMDList">Cancellation Date Cyber</asp:ListItem>
                                                                    <asp:ListItem Value="CancDtCLPList">Calcellation Date Corporate Lab Primary</asp:ListItem>

                                                                    <asp:ListItem Value="CancDtCLEList">Calcellation Date Corporate Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="CancDtALEList">Calcellation Date Aspen Lab Excess</asp:ListItem>

                                                                    <asp:ListItem Value="CancDtAApList">Calcellation Date Aspen Primary</asp:ListItem>
                                                                    <asp:ListItem Value="CancDtAAEList">Calcellation Date Aspen Excess</asp:ListItem>
                                                                    <asp:ListItem Value="CancDtAAPTList">Calcellation Date AAPT</asp:ListItem>
                                                                    <asp:ListItem Value="CancREMDList">Cancellation Reason Cyber</asp:ListItem>
                                                                    <asp:ListItem Value="CancRCLPList">Cancellation Reason Corporate Lab Primary</asp:ListItem>
                                                                    <asp:ListItem Value="CancRCLEList">Cancellation Reason Corporate Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="CancRALEList">Cancellation Reason Aspen Lab Excess</asp:ListItem>
                                                                    <asp:ListItem Value="CancRAAPList">Cancellation Reason Aspen Primary</asp:ListItem>

                                                                    <asp:ListItem Value="LicenciaDate">Medic Exp Date</asp:ListItem>

                                                </asp:ListBox>
                                            </div>
                                            <div class="d-grid gap-2">
                                                <asp:Button id="cmdSelectAll" tabIndex="2" class="btn-bg-theme2 btn-r-4 mb-1" runat="server" Text="Select All" onclick="cmdSelectAll_Click" />
                                                <asp:Button id="cmdSelect" runat="server" class="btn-bg-theme2 btn-r-4 mb-1" Text=">>" onclick="cmdSelect_Click" />
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="col">
                                                <asp:Label id="Label53" runat="server">Selected Columns:</asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:ListBox id="lbxSelected" class="w-auto1 form-control mb-1" runat="server"></asp:ListBox>
                                            </div>
                                            <div class="col">
                                                <asp:Button id="cmdRemove" tabIndex="3" class="btn-bg-theme2 btn-r-4 btn-w-100 mb-1" runat="server" Text="<<" onclick="cmdRemove_Click" />
                                            </div>
                                            <div class="col">
                                                <asp:Button id="cmdRemoveAll" tabIndex="3" class="btn-bg-theme2 btn-r-4 btn-w-100 mb-1" runat="server" Text="Remove All" onclick="cmdRemoveAll_Click" />
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="col">
                                                <asp:Label id="Label54" runat="server">Options:</asp:Label>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:label id="lblCustID" RUNAT="server">Client No:</asp:label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:textbox id="TxtCustomerNo" RUNAT="server" class="form-control mb-1 mb-1"></asp:textbox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblFirstName" runat="server" EnableViewState="False">First Name:</asp:Label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:TextBox ID="TxtSearchFirstName" runat="server" TabIndex="1" class="form-control mb-1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblLastName" runat="server" EnableViewState="False">Last Name:</asp:Label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:TextBox ID="txtSearchLastName" runat="server" class="form-control mb-1"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblPolicyType" runat="server" EnableViewState="False">Policy Type:</asp:Label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:DropDownList ID="ddlPolicyType" class="form-select mb-1" Font-Size="9pt" runat="server">
                                                        <asp:ListItem Value="PP">PP - Primary Policy</asp:ListItem>
                                                        <asp:ListItem Value="PE">PE - Excess Policy</asp:ListItem>
                                                        <asp:ListItem Value="AAP">AAP - Aspen Primary Policy</asp:ListItem>
                                                        <asp:ListItem Value="AAE">AAE - Aspen Excess Policy</asp:ListItem>
                                                        <asp:ListItem Value="CP">CP - Primary Corporate Policy</asp:ListItem>
                                                        <asp:ListItem Value="CE">CE - Excess Corporate Policy</asp:ListItem>
                                                        <asp:ListItem Value="APC">APC - Aspen Primary Corporate Policy</asp:ListItem>
                                                        <asp:ListItem Value="AEC">AEC - Aspen Excess Corporate Policy</asp:ListItem>
                                                        <asp:ListItem Value="CLP ">CLP - Corporate Policy Lab Primary</asp:ListItem>
                                                        <asp:ListItem Value="CLE">CLE - Corporate Policy Lab Excess</asp:ListItem>
                                                        <asp:ListItem Value="ALE ">ALE - Apsen Lab Excess</asp:ListItem>
                                                        <asp:ListItem Value="EMD">EMD - Cyber Policy</asp:ListItem>
                                                        <asp:ListItem Value="PAH">PAH - Allied Individial Policy</asp:ListItem>
                                                        <asp:ListItem Value="CPA">CPA - Allied Corporate Policy</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblCity" runat="server">City:</asp:Label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:DropDownList ID="ddlCiudad2" class="form-select mb-1" runat="server" Font-Size="9pt">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblSpecialty" class="w-auto" runat="server" EnableViewState="False">Specialty:</asp:Label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:DropDownList ID="ddlSpecialty2" class="form-select mb-1" Font-Size="9pt" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblAgent" runat="server" EnableViewState="False">Agent:</asp:Label>
                                                </div>
                                                <div class="col-8">
                                                    <asp:DropDownList ID="ddlAgent" class="form-select mb-1" Font-Size="9pt" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <asp:Label ID="lblAgency" runat="server" EnableViewState="False">Agency:</asp:Label>

                                                </div>
                                                <div class="col-8">
                                                    <asp:DropDownList ID="ddlAgency" class="form-select mb-1" Font-Size="9pt" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-5">
                                                    <asp:Label ID="lblInForce" runat="server" class="" EnableViewState="False">In Force:</asp:Label>
                                                </div>
                                                <div class="col-7">
                                                    <asp:RadioButtonList ID="rblInForce" runat="server" class="mb-1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="2">All</asp:ListItem>
                                                        <asp:ListItem Value="0">Yes</asp:ListItem>
                                                        <asp:ListItem Value="1">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-5">
                                                    <asp:Label ID="lblBoardCert" runat="server">Board Certified:</asp:Label>
                                                </div>
                                                <div class="col-7">
                                                    <asp:RadioButtonList ID="rblBoardCert" runat="server" class="mb-1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="2">All</asp:ListItem>
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <asp:Button ID="btnClear" runat="server" class="mb-1 w-auto1 btn-h-30 btn-bg-theme2 btn-r-4" OnClick="btnClear_Click" Text="Clear" />
                                                </div>
                                                <div class="col">
                                                    <asp:Button ID="btnSearch" runat="server" class="mb-1 w-auto1 btn-h-30 btn-bg-theme2 btn-r-4" Text="Search" Width="76px" Visible="False" />
                                                </div>
                                            </div>
                                            <div class="col">
                                                <asp:Label ID="lblDateType" runat="server" EnableViewState="False" class="mb-1" Visible="False">Date Type:</asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:DropDownList ID="ddlDateType" runat="server" AutoPostBack="True" class="form-select mb-1" onselectedindexchanged="ddlDateType_SelectedIndexChanged" Visible="true">
                                                    <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                                    <asp:ListItem Value="F">Effective Date</asp:ListItem>
                                                    <asp:ListItem Value="C">Cancellation Date</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col">
                                                <div class="input-group mb-1">
                                                    <asp:Label ID="lblDateFrom" runat="server" class="input-group-text" Visible="True">From:</asp:Label>
                                                    <asp:TextBox ID="txtDateFrom" runat="server" class="form-control fechaFormat" onclick="dpShowDateFrom();" MaxLength="50" Visible="True"></asp:TextBox>
                                                    <asp:Label ID="lblDateTo" runat="server" class="input-group-text" Visible="True">To:</asp:Label>
                                                    <asp:TextBox ID="txtDateTo" runat="server" class="form-control fechaFormat" onclick="dpShowDateTo();" Visible="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                            <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1" style="z-index: 145; left: 620px; width: 35px; position: absolute; top: 8px;
            height: 22px" type="hidden" value="false" />
                        </form>
                    </body>

                    </html>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
        <%@ Page language="c#" Inherits="EPolicy.ClientIndividual" CodeFile="ClientIndividual.aspx.cs" %>
            <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
            <HTML>

            <HEAD>
                <title>ePMS | electronic Policy Manager Solution</title>
                <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
                <meta content="C#" name="CODE_LANGUAGE">
                <meta content="JavaScript" name="vs_defaultClientScript">
                <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
                <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
                <script type="text/javascript" src="js/jquery.maskedinput-1.2.2.js"></script>

                <script>
                    $(function() {
                        $('#<%= txtBirthdate.ClientID %>').datepicker({
                            changeMonth: true,
                            changeYear: true
                        });
                    });

                    function ShowDateTimePicker() {
                        $('#<%= txtBirthdate.ClientID %>').datepicker('show');
                    }

                    function getAge() {
                        pdt = new Date(document.form1.txtBirthdate.value);
                        today = new Date("<%=today%>");

                        age = (today.getFullYear() - pdt.getFullYear());
                        day = pdt.getDay();
                        month = pdt.getMonth();

                        if (month == today.getMonth()) {
                            if (day > today.getDay()) {
                                age = age - 1;
                            }
                        } else {
                            if (month > today.getMonth()) {
                                age = age - 1;
                            }
                        }


                        if (age >= 0) {
                            document.form1.TxtAge.value = age;
                        }
                    }
                </script>
                <script>
                    $(function() {
                        $('#<%= txtlicexpdate.ClientID %>').datepicker({
                            changeMonth: true,
                            changeYear: true
                        });
                    });

                    function ShowDateTimePicker1() {
                        $('#<%= txtlicexpdate.ClientID %>').datepicker('show');
                    }

                    function getAge() {
                        pdt = new Date(document.form1.txtlicexpdate.value);
                        today = new Date("<%=today%>");

                        age = (today.getFullYear() - pdt.getFullYear());
                        day = pdt.getDay();
                        month = pdt.getMonth();

                        if (month == today.getMonth()) {
                            if (day > today.getDay()) {
                                age = age - 1;
                            }
                        } else {
                            if (month > today.getMonth()) {
                                age = age - 1;
                            }
                        }


                        if (age >= 0) {
                            document.form1.TxtAge.value = age;
                        }
                    }
                </script>
                <script>
                    function onButtonClick() {
                        document.getElementById('txtPass').className = "show";
                        document.getElementById('btnValidate').className = "show";



                    }
                </script>
                <script type="text/javascript">
                    jQuery(function($) {
                        $(".telefoneFormat").mask("(999) 999-9999");
                        $(".fechaFormat").mask("99/99/9999");
                        $(".socialFormat").mask("999-99-9999");
                    });
                </script>

                <style>
                    .hide {
                        display: none;
                    }
                    
                    .show {
                        display: block;
                    }
                </style>
                <style type="text/css">
                    .headfield1 {
                        font-family: Tahoma;
                        margin-bottom: 0px;
                    }
                    
                    .headForm1 {
                        margin-right: 3px;
                        margin-left: 0px;
                    }
                    
                    .style1 {
                        height: 2px;
                    }
                    
                    .style2 {
                        height: 26px;
                        width: 240px;
                    }
                    
                    .style3 {
                        height: 15px;
                        width: 240px;
                    }
                    
                    .style4 {
                        height: 12px;
                        width: 240px;
                    }
                    
                    .style5 {
                        height: 11px;
                        width: 240px;
                    }
                    
                    .style6 {
                        height: 23px;
                        width: 240px;
                    }
                    
                    .style7 {
                        height: 20px;
                        width: 240px;
                    }
                </style>
            </HEAD>

            <body>
                <form id="form1" method="post" runat="server">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                    <P>
                        <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                    </P>
                    <div class="container-xl mb-4">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label id="Label21" runat="server" class="fs-14 fw-bold mb-1">Individual Client:</asp:Label>
                                <asp:label id="lblCustNumber" RUNAT="server" class="fs-14 fw-bold"></asp:label>
                                <asp:label id="LblProspectID" RUNAT="server" class="fs-14 fw-bold"></asp:label>
                            </div>
                            <div class="col-md-6 f-right">
                                <asp:Button id="btnQuotes" runat="server" onclick="btnQuotes_Click" Text="Quote" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button ID="btnAuditTrail" runat="server" OnClick="Button1_Click" Text="History" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="BtnViewTask" runat="server" onclick="BtnViewTask_Click" Text="Policies" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="btnProfile" runat="server" onclick="btnProfile_Click" Text="Profile" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="btnNew" runat="server" onclick="btnNew_Click" Text="Add" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="btnEdit" runat="server" onclick="btnEdit_Click" Text="Edit" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="BtnSave" runat="server" onclick="BtnSave_Click" Text="Save" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button ID="btnDelete" runat="server" onclientclick="return confirm('Are you sure you want delete this customer?');" OnClick="btnDelete_Click" Text="Delete" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="btnCancel" runat="server" onclick="btnCancel_Click" Text="Cancel" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                                <asp:Button id="BtnExit" runat="server" Text="Exit" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <hr>
                        </div>
                        <div class="row">

                            <div class="col-md-1">

                            </div>
                            <div class="col-md-3">
                                <asp:checkbox id="ChkNoticeOfCancellation" tabIndex="29" RUNAT="server" class="fs-lbl-s mb-1" AUTOPOSTBACK="True" TEXT="Notice of Cancellation"></asp:checkbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblHomePhone0" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">New Quote:</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlQuote" class="form-select fs-txt-s mb-1" RUNAT="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="0">Quote</asp:ListItem>
                                    <asp:ListItem Value="1">Corporate</asp:ListItem>
                                    <asp:ListItem Value="2">Laboratory</asp:ListItem>
                                    <asp:ListItem Value="3">Cyber</asp:ListItem>
                                    <asp:ListItem Value="4">Aspen</asp:ListItem>
                                    <asp:ListItem Value="5">First Dollar</asp:ListItem>
                                    <asp:ListItem Value="6">Allied</asp:ListItem>
                                    <asp:ListItem Value="7">Allied Corporate</asp:ListItem>
                                </asp:dropdownlist>
                            </div>

                            <div class="col-md-2">
                                <asp:TextBox ID="txtControlNo" runat="server" MaxLength="15" class="form-control fs-txt-s mb-1" OnTextChanged="TxtFirstName_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnAssignCustNo" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" OnClick="btnAssignCustNo_Click" Text="Assign Cust No. To Quote" />
                            </div>


                            <div class="col-md-1">
                                <asp:label id="Label2" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">First Name</asp:label>
                            </div>
                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:textbox id="TxtFirstName" RUNAT="server" class="form-control w-50 fs-txt-s mb-1" MAXLENGTH="15" ontextchanged="TxtFirstName_TextChanged"></asp:textbox>
                                    <asp:label id="Label1" RUNAT="server" class="input-group-text fs-txt-s mb-1" ENABLEVIEWSTATE="False">Init.</asp:label>
                                    <asp:textbox id="TxtInitial" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="1"></asp:textbox>
                                </div>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblHomePhone" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Home Phone</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtHomePhone" RUNAT="server" class="form-control fs-txt-s telefoneFormat mb-1" MAXLENGTH="20" ISDATE="False"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label10" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Social Security</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:RadioButtonList ID="chkssnselect" runat="server" class="fs-lbl-s mb-1" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Patronal">Patronal</asp:ListItem>
                                    <asp:ListItem Value="Personal">Personal</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblLastName1" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Last Name 1</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtLastname1" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="25"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblWorkPhone" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Work Phone</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtWorkPhone" RUNAT="server" class="form-control fs-txt-s telefoneFormat mb-1" MAXLENGTH="20" ISDATE="False"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblSocialSecurity" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Social Security</asp:label>
                            </div>
                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:textbox id="txtSocialSecurity" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                                    <input type="button" runat="server" name="answer" class="input-group-text fs-txt-s mb-1" value="Show" onclick="onButtonClick()" id="btnShow" />
                                    <asp:Button id="BtnActivateDeleteSoSec" runat="server" class="input-group-text fs-txt-s mb-1" Text="Delete" onclick="BtnActivateDeleteSoSec_Click" Visible="False"></asp:Button>
                                </div>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblLastName2" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Last Name 2</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtLastname2" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="25"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label8" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Cellular</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="TxtCellular" RUNAT="server" class="form-control fs-txt-s telefoneFormat mb-1" MAXLENGTH="20" ISDATE="False"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblEmployerSecSOc" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1"> Employer Social Security</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtEmployerSocSec" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-12">
                                <asp:textbox id="txtPass" runat="server" CSSCLASS="hide" RUNAT="server" autocomplete="Disabled" ontextchanged="txtPass_TextChanged"></asp:textbox>
                                <asp:Button id="btnValidate" runat="server" Text="Validate" CSSCLASS="hide" onclick="btnValidate_Click"></asp:Button>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblGender" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Gender</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlGender" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:dropdownlist>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label24" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Fax</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtfax" RUNAT="server" class="form-control fs-txt-s telefoneFormat mb-1" MAXLENGTH="20" ISDATE="False"></asp:textbox>
                            </div>
                            <div class="col-md-1">
                                <asp:label id="Label6" RUNAT="server" class="fs-lbl-s mb-1">Originated At</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlOriginatedAt" CSSCLASS="form-select fs-txt-s mb-1" RUNAT="server"></asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblBirthdate" class="fs-lbl-s mb-1" RUNAT="server" ENABLEVIEWSTATE="False">Birthdate</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtBirthdate" class="form-control fs-txt-s fechaFormat mb-1" onclick="ShowDateTimePicker()" RUNAT="server"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblCorpName" RUNAT="server" class="fs-lbl-s mb-1">Corporation Name</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtCorpName" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="100"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblOccupation" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Occupation</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlOccupation" RUNAT="server" class="form-select fs-txt-s mb-1" AUTOPOSTBACK="True" onselectedindexchanged="ddlOccupation_SelectedIndexChanged"></asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="Label4" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Age</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="TxtAge" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="3"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblJobName" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Work Name</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtWorkName" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblOccupation0" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Referred By</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlreferredby" RUNAT="server" class="form-select fs-txt-s mb-1" AUTOPOSTBACK="True" onselectedindexchanged="ddlOccupation_SelectedIndexChanged">
                                    <asp:ListItem>CONTACT CENTERS</asp:ListItem>
                                    <asp:ListItem>DEALER</asp:ListItem>
                                    <asp:ListItem>INSURANCE AGENT</asp:ListItem>
                                    <asp:ListItem>INSURANCE COMPANY</asp:ListItem>
                                    <asp:ListItem>INTERNET</asp:ListItem>
                                    <asp:ListItem>NEWSPAPER</asp:ListItem>
                                    <asp:ListItem>OTHER</asp:ListItem>
                                    <asp:ListItem>RADIO</asp:ListItem>
                                    <asp:ListItem>TELEVISION</asp:ListItem>
                                    <asp:ListItem>YELLOW PAGE</asp:ListItem>
                                </asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblMaritalStatus" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Marital Status</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlMaritalStatus" RUNAT="server" class="form-select fs-txt-s mb-1"></asp:dropdownlist>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label5" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Work City</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="TxtWorkCity" RUNAT="server" MAXLENGTH="50" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblOccupation1" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Status</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlstatus" RUNAT="server" class="form-select fs-txt-s mb-1" AUTOPOSTBACK="True">
                                    <asp:ListItem>Closed</asp:ListItem>
                                    <asp:ListItem>Declined</asp:ListItem>
                                    <asp:ListItem>Issued</asp:ListItem>
                                    <asp:ListItem>Orientation</asp:ListItem>
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Quoted</asp:ListItem>
                                    <asp:ListItem>Quoted/NI</asp:ListItem>
                                    <asp:ListItem>Submitted to UND</asp:ListItem>
                                    <asp:ListItem>Waiting for payment</asp:ListItem>
                                    <asp:ListItem>Payment received and referred to accounting</asp:ListItem>
                                    <asp:ListItem>Waiting for policy to insurance</asp:ListItem>
                                    <asp:ListItem>Requisites not met</asp:ListItem>
                                    <asp:ListItem>Operations outside of PR</asp:ListItem>
                                    <asp:ListItem>Higher Limits</asp:ListItem>
                                    <asp:ListItem>High Loss Ratio</asp:ListItem>
                                    <asp:ListItem>Telemedicine exposures</asp:ListItem>
                                    <asp:ListItem>Not available product</asp:ListItem>
                                    <asp:ListItem>Moral Hazard</asp:ListItem>
                                    <asp:ListItem>Risk Management Recommendation</asp:ListItem>
                                    <asp:ListItem>Student</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblCustPreferedCommID" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Prefered Communication</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtCustPreferedCommID" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="40"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label16" RUNAT="server" class="fs-lbl-s mb-1">License</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="TxtLicence" RUNAT="server" class="form-control fs-txt-s mb-1" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" MAXLENGTH="15"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblOccupation2" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Prospect Status</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlprostatus" RUNAT="server" class="form-select fs-txt-s mb-1" AUTOPOSTBACK="True">
                                    <asp:ListItem>Prospect</asp:ListItem>
                                    <asp:ListItem>Customer</asp:ListItem>
                                    <asp:ListItem>Inactive</asp:ListItem>
                                </asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="Label26" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Quoted</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtquoted" RUNAT="server" MAXLENGTH="50" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label25" RUNAT="server" class="fs-lbl-s mb-1">License Exp. Date</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtlicexpdate" class="form-control fs-txt-s fechaFormat mb-1" onclick="ShowDateTimePicker1()" RUNAT="server" MAXLENGTH="40"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblInsuredtype" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Insured Type</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="txtInsuredtype" RUNAT="server" class="form-select fs-txt-s mb-1">
                                    <asp:ListItem>Physicians: Surgeon</asp:ListItem>
                                    <asp:ListItem>Physicians: NS</asp:ListItem>
                                    <asp:ListItem>Physicians: MS</asp:ListItem>
                                    <asp:ListItem>Physicians: Teaching</asp:ListItem>
                                    <asp:ListItem>Physicians: Dentist</asp:ListItem>
                                    <asp:ListItem>Physicians: Podiatrist</asp:ListItem>
                                    <asp:ListItem>Corporation: Allied</asp:ListItem>
                                    <asp:ListItem>Corporation: Cyber</asp:ListItem>
                                    <asp:ListItem>Corporation: Lab</asp:ListItem>
                                    <asp:ListItem>Corporation: MedMal</asp:ListItem>
                                    <asp:ListItem>Allied: Technician</asp:ListItem>
                                    <asp:ListItem>Allied: Assistant</asp:ListItem>
                                    <asp:ListItem>Allied: Pathologist</asp:ListItem>
                                    <asp:ListItem>Allied: Nurse</asp:ListItem>
                                </asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="NPI" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">NPI</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtNPI" tabIndex="11" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="40"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblAmscaOrDEA2" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">AMSCA</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="ddlAmscaOrDEA2" RUNAT="server" class="form-select fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                            </div>
                            <div class="col-md-3">
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblwebsite" RUNAT="server" class="fs-lbl-s mb-1">Website</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtWebsite2" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="40"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblAmscaOrDEA3" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">DEA</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="ddlAmscaOrDEA3" RUNAT="server" class="form-select fs-txt-s mb-1" MAXLENGTH="50"></asp:TextBox>
                            </div>
                            <div class="col-md-12">
                                <asp:label id="lblAddress2" RUNAT="server" Visible="False" class="fs-lbl-s mb-1">Urbanization</asp:label>
                                <asp:textbox id="txtAddress2" MAXLENGTH="30" RUNAT="server" class="form-control fs-txt-s mb-1" Visible="False"></asp:textbox>
                            </div>
                            <div class="col-md-2">
                                <asp:checkbox id="ChkDisableAutomaticCustNo" tabIndex="36" RUNAT="server" class="fs-lbl-s mb-1" AUTOPOSTBACK="True" TEXT="Disable Automatic Cust. No."></asp:checkbox>
                            </div>
                            <div class="col-md-2">
                                <asp:Button id="BtnUpdate" runat="server" class="btn-h-30 btn-bg-theme2 mb-1 btn-r-4" onclientclick="return confirm('Updating ALL cases, Continue?');" onclick="BtnUpdate_Click" Text="Update Cases" />
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblEmail" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">E-mail</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtEmail" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="100"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label11" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Lead ID</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtleadid" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label13" RUNAT="server" Visible="False" class="fs-lbl-s mb-1">Related To</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlRelatedTo" RUNAT="server" class="form-control fs-txt-s mb-1" Visible="False">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                    <asp:ListItem Value="C">Close Date</asp:ListItem>
                                </asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="Label12" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">E-mail 2</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtemail2" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="100"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label17" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Agent ID</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtagentid" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label7" RUNAT="server" Visible="False" class="fs-lbl-s mb-1">Master Client</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlMasterCustomer" RUNAT="server" class="form-select fs-txt-s mb-1" Visible="False"></asp:dropdownlist>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="Label3" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Convert to Client</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtcontoclient" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="Label9" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Interested IN</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:textbox id="txtinterestedin" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="50"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="Label22" runat="server" VISIBLE="false" Text="Customer No" class="fs-lbl-s mb-1"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <maskedinput:maskedtextbox id="TxtCustomerNo" VISIBLE="false" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="20" MASK="999999" ISDATE="False"></maskedinput:maskedtextbox>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblHouseIncome" RUNAT="server" class="fs-lbl-s mb-1">Household Income</asp:label>
                            </div>
                            <div class="col-md-3">
                                <asp:dropdownlist id="ddlHouseIncome" RUNAT="server" class="form-select fs-txt-s mb-1"></asp:dropdownlist>
                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="Label23" runat="server" class="fs-lbl-s mb-1" Text="Prospect ID" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <maskedinput:maskedtextbox id="TxtProspectID" RUNAT="server" class="form-control fs-txt-s mb-1" MAXLENGTH="20" MASK="999999" ISDATE="False" Visible="False"></maskedinput:maskedtextbox>
                            </div>

                            <div class="col-md-12">
                                <asp:label id="lblComments" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s mb-1">Comments</asp:label>
                                <asp:textbox id="txtComments" RUNAT="server" MAXLENGTH="200" TextMode="MultiLine" class="form-control fs-txt-s mb-1 h-10"></asp:textbox>
                            </div>
                            <div class="col-md-12">
                                <hr>
                            </div>

                            <asp:textbox Visible="false" id="txtssnpin" RUNAT="server" MAXLENGTH="50"></asp:textbox>
                            <asp:textbox id="txtOtherOccupation" RUNAT="server" MAXLENGTH="15" VISIBLE="False"></asp:textbox>
                            <div class="col-md-1">

                            </div>
                            <div class="col-md-5">
                                <asp:label id="lblTypeAddress1" RUNAT="server" class="fs-14 mb-1 fw-bold mb-2">Postal Address</asp:label>
                            </div>

                            <div class="col-md-1">

                            </div>
                            <div class="col-md-5">
                                <asp:label id="LblTypeAddress2" RUNAT="server" class="fs-14 mb-1 fw-bold mb-2">Physical Address</asp:label>
                            </div>


                            <div class="col-md-1">

                            </div>
                            <div class="col-md-5">
                                <asp:label id="Label14" RUNAT="server" class="fs-lbl-s mb-1">*Address1 (Urb.,Cond.Bo.,Res.,Secc.Coop.,QBDA,Parcelas,Sector)</asp:label>
                                <asp:label id="Label15" RUNAT="server" class="fs-lbl-s mb-1">**Address2(PoBox,Street,HC,Ave.,BLVD.,Camino,RR,Parque)</asp:label>
                            </div>
                            <div class="col-md-1">

                            </div>
                            <div class="col-md-5">
                                <asp:checkbox id="chkSameAddr" tabIndex="30" RUNAT="server" TEXT="Same as postal" AUTOPOSTBACK="True" Enabled="False" oncheckedchanged="chkSameAddr_CheckedChanged"></asp:checkbox>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblHomeUrb" RUNAT="server" class="fs-lbl-s mb-1">*Address1</asp:label>
                            </div>
                            <div class="col-md-5">
                                <asp:textbox id="txtHomeUrb1" MAXLENGTH="30" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-1">

                            </div>
                            <div class="col-md-5">
                                <asp:textbox id="txtAddress1Phys" MAXLENGTH="30" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>


                            <div class="col-md-1">
                                <asp:label id="lblAddress1" RUNAT="server" class="fs-lbl-s mb-1">**Address2</asp:label>
                            </div>
                            <div class="col-md-5">
                                <asp:textbox id="txtAddress1" MAXLENGTH="30" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <asp:textbox id="txtAddress2Phys" MAXLENGTH="30" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblCity" RUNAT="server" class="fs-lbl-s mb-1">City</asp:label>
                            </div>
                            <div class="col-md-5">
                                <asp:textbox id="txtCity" MAXLENGTH="14" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <asp:textbox id="txtCityPhys" MAXLENGTH="14" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblState" RUNAT="server" class="fs-lbl-s mb-1">State</asp:label>
                            </div>
                            <div class="col-md-5">
                                <asp:textbox id="txtState" MAXLENGTH="2" RUNAT="server" class="form-control fs-txt-s mb-1">PR</asp:textbox>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <asp:textbox id="txtStatePhys" MAXLENGTH="2" RUNAT="server" class="form-control fs-txt-s mb-1"></asp:textbox>
                            </div>

                            <div class="col-md-1">
                                <asp:label id="lblZipCode" RUNAT="server" class="fs-lbl-s mb-1">Zip Code</asp:label>
                            </div>
                            <div class="col-md-5">
                                <maskedinput:maskedtextbox id="txtZipCode" MAXLENGTH="10" RUNAT="server" class="form-control fs-txt-s mb-1" ISDATE="False" MASK="99999Z9999"></maskedinput:maskedtextbox>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <maskedinput:maskedtextbox id="txtZipCodePhys" MAXLENGTH="10" RUNAT="server" class="form-control fs-txt-s mb-1" ISDATE="False" MASK="99999Z9999"></maskedinput:maskedtextbox>
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="LblTotalCases" runat="server" class="fs-lbl-s mb-1">Total Cases:</asp:Label>
                                <asp:Label ID="LblError" runat="server" ForeColor="Red" Visible="False" class="fs-lbl-s mb-1">Label</asp:Label>
                            </div>
                        </div>

                        <asp:DataGrid ID="searchIndividual" runat="server" AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" AlternatingItemStyle- AutoGenerateColumns="False" BackColor="White" BorderColor="#D6E3EA" BorderStyle="Solid" BorderWidth="1px" CellPadding="0"
                            Font-Names="Arial" Font-Size="10pt" HeaderStyle-BackColor="#5C8BAE" HeaderStyle-HeaderStyle-HorizontalAlign="Center" Height="1px" ItemStyle- ItemStyle-HorizontalAlign="center" OnItemCommand="searchIndividual_ItemCommand" PageSize="20"
                            Width="805px">
                            <FooterStyle BackColor="Navy" />
                            <EditItemStyle BackColor="White" HorizontalAlign="Center" />
                            <SelectedItemStyle BackColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="White" CssClass="Numbers" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" PageButtonCount="20" />
                            <AlternatingItemStyle BackColor="White" HorizontalAlign="Center" />
                            <ItemStyle BackColor="White" HorizontalAlign="Center" />
                            <Columns>
                                <asp:ButtonColumn ButtonType="PushButton" CommandName="Select" HeaderText="Sel.">
                                    <ItemStyle />
                                </asp:ButtonColumn>
                                <asp:BoundColumn DataField="TaskControlID" HeaderText="Control No">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PolicyType" HeaderText="Policy Type"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PolicyNo" HeaderText="Policy No.">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Anniversary" HeaderText="Anniv."></asp:BoundColumn>
                                <asp:BoundColumn DataField="EffectiveDate" DataFormatString="{0:d}" HeaderText="Eff. Date">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EntryDate" DataFormatString="{0:d}" HeaderText="Entry Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TaskControlTypeID" HeaderText="TaskControlTypeID" Visible="False">
                                </asp:BoundColumn>
                            </Columns>
                            <HeaderStyle BackColor="Maroon" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        </asp:DataGrid>
                        <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                        <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
                        <asp:checkbox id="ChkOptOut" style="Z-INDEX: 103; LEFT: 12px; POSITION: absolute; TOP: 132px" tabIndex="36" Width="71px" RUNAT="server" CSSCLASS=" headForm1 " TEXT="Opt-Out" AUTOPOSTBACK="True" Visible="False"></asp:checkbox>
                        <asp:Panel ID="PanelSocSec" runat="server" CssClass="" Width="400px" Height="200px" BackColor="#EEEAEA">
                            <div class="" style="padding: 0px; background-color: #400000; color: #FFFFFF; font-family: tahoma;
					font-size: 14px; font-weight: normal; font-style: normal; background-repeat: no-repeat;
					text-align: left; vertical-align: bottom;">
                                <asp:Label ID="LabelSocSecPanel" runat="server" Text="" />
                                <asp:Label ID="LabelSoSecQuestion" runat="server" Text="Which Social Security will you Delete?" />
                                <asp:Button ID="btnDeleteSoSec" runat="server" Text="Personal" onclick="btnDeleteSoSec_Click" onclientclick="return confirm('Are you sure you want delete this Personal Social Security Number?');" />
                                <asp:Button ID="btnDeleteEmployerSoSec" runat="server" Text="Employer" onclick="btnDeleteEmployerSoSec_Click" onclientclick="return confirm('Are you sure you want delete this Employer Social Security Number?');" />
                                <asp:Button ID="btnAceptarSocSec" runat="server" Text="Exit" />
                            </div>
                        </asp:Panel>
                        <asp:ModalPopupExtender ID="mpeSocSec" runat="server" DropShadow="True" PopupControlID="PanelSocSec" TargetControlID="ButtonSocSec">
                        </asp:ModalPopupExtender>
                        <asp:Button ID="ButtonSocSec" runat="server" BackColor="Transparent" BorderStyle="None" BorderWidth="0" BorderColor="Transparent" />
                        <asp:RoundedCornersExtender ID="RoundedCornersExtenderSocSec" runat="server" TargetControlID="PanelSocSec" Radius="10" Corners="All" />
                    </div>
                </form>
            </body>

            </HTML>
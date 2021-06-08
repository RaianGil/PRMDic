<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.Agency" CodeFile="Agency.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
            <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
            <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
            <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
            <script type="text/javascript">
                $("#effect").hide();
                $(function() {
                    $('#<%= txtlicexp.ClientID %>').datepicker({
                        changeMonth: true,
                        changeYear: true
                    });
                });

                function ShowDateTimePicker() {
                    $('#<%= txtlicexp.ClientID %>').datepicker('show');
                }
                // });
            </script>
            <script type='text/javascript'>
                jQuery(function($) {

                    $("#txtoffice1").mask("(000) 000-0000", {
                        placeholder: "(###) ###-####"
                    });
                    $("#txtoffice2").mask("(000) 000-0000", {
                        placeholder: "(###) ###-####"
                    });
                    $("#txtPhone").mask("(000) 000-0000", {
                        placeholder: "(###) ###-####"
                    });
                    $("#txtphone2").mask("(000) 000-0000", {
                        placeholder: "(###) ###-####"
                    });
                    $("#txtfax").mask("(000) 000-0000", {
                        placeholder: "(###) ###-####"
                    });


                });
            </script>
        </HEAD>

        <body class="middleMain">
            <form id="Form1" method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label1" class="fs-16" runat="server">Agency ID:</asp:Label>
                            <asp:label id="lblAgencyID" class="fs-16" runat="server"></asp:label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:button>
                            <asp:button id="btnCommission" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Commission" onclick="btnCommission_Click"></asp:button>
                            <asp:button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print" onclick="btnPrint_Click"></asp:button>
                            <asp:button id="btnSearch" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Search" onclick="btnSearch_Click"></asp:button>
                            <asp:button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Add" onclick="btnAddNew_Click"></asp:button>
                            <asp:button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Edit" onclick="btnEdit_Click"></asp:button>
                            <asp:button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Save" onclick="BtnSave_Click"></asp:button>
                            <asp:button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Cancel" onclick="cmdCancel_Click"></asp:button>
                            <asp:button id="Button2" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="Button2_Click"></asp:button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblB" runat="server">Agency Description</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtAgencyDescription" runat="server" MAXLENGTH="40" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label3" runat="server">Agency Name </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtname" runat="server" MAXLENGTH="30" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label4" runat="server">Agency LastName 1 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtlast1" runat="server" MAXLENGTH="30" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label5" runat="server">Agency LastName 2 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtlast2" runat="server" MAXLENGTH="30" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblAddress1" runat="server"> Address 1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtAddress1" runat="server" MAXLENGTH="30" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblAddress2" runat="server"> Address 2</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtAddress2" runat="server" MAXLENGTH="30" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblCity" runat="server">City</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtCity" runat="server" MAXLENGTH="20" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblState" runat="server">State</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtSt" runat="server" MAXLENGTH="2" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblZipCode" runat="server">Zip Code</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtZipCode" runat="server" MAXLENGTH="20" class="form-control" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label17" runat="server">Additional Adress </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="txtpostal" class="form-select" runat="server">

                                        <asp:ListItem>Fisica</asp:ListItem>
                                        <asp:ListItem>Postal</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label28" runat="server">Second Adress 1 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtaddresssec1" runat="server" MAXLENGTH="100" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label29" runat="server">Second Adress 2 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtaddresssec2" runat="server" MAXLENGTH="100" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label30" runat="server">Second City </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtcity2" runat="server" MAXLENGTH="20" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label31" runat="server">Second State </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtstate2" runat="server" MAXLENGTH="2" class="form-control" />
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label32" runat="server">Second Zip Code </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtzip2" runat="server" MAXLENGTH="20" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label13" runat="server">Office Phone 1 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtoffice1" runat="server" MAXLENGTH="20" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label14" runat="server">Office Phone 2 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtoffice2" runat="server" MAXLENGTH="20" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblPhone" runat="server">Home Phone 1</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtPhone" runat="server" MAXLENGTH="20" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label15" runat="server">Home Phone 2 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtphone2" runat="server" MAXLENGTH="20" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label16" runat="server">Office Fax </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtfax" runat="server" MAXLENGTH="20" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="lblEntryDate" runat="server">Entry Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <maskedinput:maskedtextbox id="txtEntryDate" runat="server" class="form-control" ISDATE="True" Enabled="False"></maskedinput:maskedtextbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label2" runat="server">Sale Contact </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtsale" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label6" runat="server">Accounting Contact </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtacco" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label7" runat="server">Contact Email 1 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtemail1" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label8" runat="server">Contact Email 2 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtemail2" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label9" runat="server">Contact Email 3 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtemail3" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label10" runat="server">Contact Email 4 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtemail4" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label11" runat="server">Contact Email 5 </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtemail5" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label33" runat="server">Website </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtwebsite" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label34" runat="server">Facebook </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtfacebook" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label35" runat="server">Instagram </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtinstagram" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label36" runat="server">Twitter </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txttwitter" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label37" runat="server">LinkedIn </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtlinkedin" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label38" runat="server">Other Social Media</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtothersm" runat="server" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label12" runat="server">Social Security</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtssn" runat="server" MAXLENGTH="11" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label18" runat="server">License Exp. Date</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtlicexp" runat="server" Columns="30" class="form-control" onIsDate="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label19" runat="server">License Number</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:textbox id="txtlicnum" runat="server" MAXLENGTH="15" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);" class="form-control"></asp:textbox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label20" runat="server">Type of License
                                    </asp:label>
                                </div>
                                <div class="col-md-8">

                                    <asp:DropDownList ID="ddltypelic" class="form-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label21" runat="server">Application</asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlappl" class="form-select" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label22" runat="server">OCS Appointment
                                    </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlocsa" class="form-select" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>N/A</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label23" runat="server">Commission Agreement
                                    </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlcomm" class="form-select" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Standard Commission Agreement
                                        </asp:ListItem>
                                        <asp:ListItem>Special Commission Agreement
                                        </asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label24" runat="server">Tax Waiver Certificate
                                    </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddltaxwai" class="form-select" runat="server">
                                        <asp:ListItem>Partial</asp:ListItem>
                                        <asp:ListItem>Total</asp:ListItem>
                                        <asp:ListItem>None</asp:ListItem>
                                        <asp:ListItem>Expired</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label25" runat="server">E & O Policy
                                    </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddleopolicy" class="form-select" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Expired</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label26" runat="server">Merchant Registration (Suri)
                                    </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlmerchregis" class="form-select" runat="server">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                        <asp:ListItem>Pending</asp:ListItem>
                                        <asp:ListItem>Expired</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-md-4">
                                    <asp:label id="Label27" runat="server">Payment Method
                                    </asp:label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddlpaymet" class="form-select" runat="server">
                                        <asp:ListItem>Wired</asp:ListItem>
                                        <asp:ListItem>Check</asp:ListItem>
                                        <asp:ListItem>Direct Deposit
                                        </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
                    <asp:literal id="litPopUp" runat="server" VISIBLE="False"></asp:literal>
                </div>
            </form>
        </body>

        </HTML>
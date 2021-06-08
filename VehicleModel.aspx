<%@ Page language="c#" Inherits="EPolicy.VehicleModel" CodeFile="VehicleModel.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC"-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="baldrich.css" type="text/css" rel="stylesheet">
        </HEAD>

        <body>
            <form id="ProspectBusiness" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label id="Label3" class="fs-14 fw-bold" runat="server">Vehicle Model ID:</asp:Label>
                            <asp:label id="lblA" RUNAT="server" class="fs-lbl-s"> Vehicle Make</asp:label>
                            <asp:Label id="lblVehicleModelID" runat="server" class="fs-lbl-s"></asp:Label>
                        </div>
                        <div class="col-md-6 f-right">
                            <asp:Button id="btnAuditTrail" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="AuditTrail" onclick="btnAuditTrail_Click"></asp:Button>
                            <asp:Button id="btnPrint" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Print" onclick="btnPrint_Click"></asp:Button>
                            <asp:Button id="btnSearch" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Search" onclick="btnSearch_Click"></asp:Button>
                            <asp:Button id="btnAddNew" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="AddNew" onclick="btnAddNew_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Edit" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="BtnSave" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Save" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="cmdCancel" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Cancel" onclick="cmdCancel_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4 mb-1" Text="Exit" onclick="BtnExit_Click"></asp:Button>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>


                    <div class="row">
                        <div class="col-md-6">
                            <asp:label id="Label1" RUNAT="server" class="fs-lbl-s">Vehicle Make</asp:label>
                        </div>
                        <div class="col-md-6">
                            <asp:label id="lblB" RUNAT="server" class="fs-lbl-s">Vehicle Model Description</asp:label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:dropdownlist id="ddlVehicleMake" tabIndex="9" RUNAT="server" class="form-select fs-txt-s" AutoPostBack="True" onselectedindexchanged="ddlVehicleMake_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                        <div class="col-md-6">
                            <asp:textbox id="txtVehicleModelDescription" RUNAT="server" class="form-control fs-txt-s" MAXLENGTH="50"></asp:textbox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:label id="Label20" RUNAT="server" ENABLEVIEWSTATE="False" class="fs-lbl-s">Model</asp:label>
                        <asp:listbox id="ddlModel" runat="server" class="form-control fs-txt-s"></asp:listbox>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>

                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                    <div class="col-md-12">
                        <asp:imagebutton id="BtnExit1" style="Z-INDEX: 102; LEFT: 1073px; POSITION: absolute; TOP: 134px" tabIndex="8" RUNAT="server" Visible="False" CAUSESVALIDATION="False" IMAGEURL="Images/exit_btn.gif"></asp:imagebutton>
                        <asp:ImageButton id="btnAuditTrail1" runat="server" Height="19px" Width="48px" ImageUrl="Images/History_btn.bmp" style="Z-INDEX: 103; LEFT: 1113px; POSITION: absolute; TOP: 138px" Visible="False"></asp:ImageButton>
                        <asp:imagebutton id="btnPrint1" tabIndex="7" runat="server" ImageUrl="Images/printreport_btn.gif" AlternateText="Print Report" style="Z-INDEX: 104; LEFT: 1173px; POSITION: absolute; TOP: 134px" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="cmdCancel1" tabIndex="7" runat="server" ImageUrl="Images/cancel_btn.gif" CausesValidation="False" style="Z-INDEX: 105; LEFT: 1273px; POSITION: absolute; TOP: 138px" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="btnSearch1" tabIndex="6" runat="server" CausesValidation="False" ImageUrl="Images/search_btn.gif" style="Z-INDEX: 106; LEFT: 1305px; POSITION: absolute; TOP: 138px" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="BtnSave1" tabIndex="5" RUNAT="server" IMAGEURL="Images/save_btn.gif" TOOLTIP="Save Person Information" CAUSESVALIDATION="False" style="Z-INDEX: 107; LEFT: 1341px; POSITION: absolute; TOP: 142px" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="btnEdit1" tabIndex="4" runat="server" ImageUrl="Images/edit_btn.GIF" CausesValidation="False" style="Z-INDEX: 108; LEFT: 1377px; POSITION: absolute; TOP: 142px" Visible="False"></asp:imagebutton>
                        <asp:imagebutton id="btnAddNew1" tabIndex="3" runat="server" CausesValidation="False" ImageUrl="Images/addNew_btn.gif" style="Z-INDEX: 109; LEFT: 1413px; POSITION: absolute; TOP: 142px" Visible="False"></asp:imagebutton>
                        <asp:button id="BtnBegin" tabIndex="9" runat="server" Height="23px" Text="<<" style="Z-INDEX: 110; LEFT: 1077px; POSITION: absolute; TOP: 170px" Visible="False" onclick="BtnBegin_Click"></asp:button>
                        <asp:button id="BtnPrevious" tabIndex="10" runat="server" Height="23px" Width="24px" Text="<" style="Z-INDEX: 111; LEFT: 1105px; POSITION: absolute; TOP: 170px" Visible="False" onclick="BtnPrevious_Click"></asp:button>
                        <asp:label id="lblRecordCount" CSSCLASS="headform2" RUNAT="server" HEIGHT="17px" WIDTH="129px" style="Z-INDEX: 112; LEFT: 1145px; POSITION: absolute; TOP: 170px" Visible="False">1 of 1</asp:label>
                        <asp:button id="BtnNext" tabIndex="11" runat="server" Height="23px" Width="24px" Text=">" style="Z-INDEX: 113; LEFT: 1285px; POSITION: absolute; TOP: 170px" Visible="False" onclick="BtnNext_Click"></asp:button>
                        <asp:button id="BtnEnd" tabIndex="12" runat="server" Height="23px" Text=">>" style="Z-INDEX: 114; LEFT: 1317px; POSITION: absolute; TOP: 170px" Visible="False" onclick="BtnEnd_Click"></asp:button>
                        <asp:dropdownlist id="ddlModel2" style="Z-INDEX: 116; LEFT: 1075px; POSITION: absolute; TOP: 49px" tabIndex="30" RUNAT="server" WIDTH="162px" HEIGHT="19px" Visible="False"></asp:dropdownlist>
                        <asp:textbox id="txtVehicleMakeID" style="Z-INDEX: 117; LEFT: 1095px; POSITION: absolute; TOP: 69px" tabIndex="1" RUNAT="server" WIDTH="41px" MAXLENGTH="10" Visible="False"></asp:textbox>
                    </div>
                </div>
            </form>
        </body>

        </HTML>
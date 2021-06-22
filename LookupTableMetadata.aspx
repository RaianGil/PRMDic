<%@ Page language="c#" Inherits="EPolicy.LookupTableMetadata" CodeFile="LookupTableMetadata.aspx.cs" %>
    <%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
            <meta content="C#" name="CODE_LANGUAGE">
            <meta content="JavaScript" name="vs_defaultClientScript">
            <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
            <style>
                .btn-center {
                    align-self: flex-end;
                    padding-bottom: 4px;
                }
            </style>


        </HEAD>

        <body>
            <form id="ProspectBusiness" method="post" runat="server">

                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4 p-18">
                    <div class="row">
                        <div class="col-md">
                            <asp:Label id="Label7" runat="server" class="fs-16">Lookup Table ID:</asp:Label>
                            <asp:label id="lblLookupTableID" runat="server" class="fs-16"></asp:label>
                        </div>

                        <div class="col-md-2 f-right">
                            <asp:Button id="BtnSave" runat="server" Text="Save" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="BtnSave_Click"></asp:Button>
                            <asp:Button id="cmdCancel" runat="server" Text="Cancel" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="cmdCancel_Click"></asp:Button>
                            <asp:Button id="btnEdit" runat="server" Text="Edit" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnEdit_Click"></asp:Button>
                            <asp:Button id="BtnExit" runat="server" Text="Exit" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="cmdExit_Click"></asp:Button>
                            <asp:Button id="btnSearch" runat="server" Text="Search" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnSearch_Click"></asp:Button>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr>
                    </div>


                    <div class="row">
                        <div class="col-5 f-center">
                            <asp:Label id="Label6" runat="server">Add table to metadata store:</asp:Label>
                            <asp:DropDownList id="ddlTablesNotInMetadataStore" class="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-1 f-center btn-center">
                            <asp:Button id="btnAddTableToMetadataStore" runat="server" Text="Add" class="btn-h-30 btn-bg-theme2 btn-r-4" onclick="btnAddTableToMetadataStore_Click"></asp:Button>
                        </div>

                        <div class="col-4 f-center">
                            <asp:label id="lblA" RUNAT="server">Table Name</asp:label>
                            <asp:dropdownlist id="ddlTableNames" runat="server" AutoPostBack="True" class="form-select" onselectedindexchanged="ddlTableNames_SelectedIndexChanged"></asp:dropdownlist>
                        </div>
                        <div class="col-2 f-center btn-center">
                            <asp:checkbox id="chkIsValuePair" runat="server" Text="Is value pair?" Enabled="False" AutoPostBack="True" oncheckedchanged="chkIsValuePair_CheckedChanged"></asp:checkbox>
                        </div>
                    </div>

                    <p>
                        <div class="row">
                            <div class="col-6 f-center">
                                <asp:label id="Label1" runat="server">ID Field Name</asp:label>
                                <asp:dropdownlist id="ddlIdFieldNames" runat="server" cssclass="form-select" Enabled="False"></asp:dropdownlist>
                            </div>

                            <div class="col-6 f-center">
                                <asp:label id="Label2" runat="server">Description Field Name</asp:label>
                                <asp:dropdownlist id="ddlDescriptionFieldNames" runat="server" cssclass="form-select" Enabled="False"></asp:dropdownlist>
                            </div>
                        </div>
                    </p>

                    <p>
                        <div class="row">
                            <div class="col-4 f-center">
                                <asp:label id="Label3" runat="server">Default Search Field A</asp:label>
                                <asp:dropdownlist id="ddlDefaultSearchFieldsA" runat="server" cssclass="form-select" Enabled="False"></asp:dropdownlist>
                            </div>

                            <div class="col-4 f-center">
                                <asp:label id="Label4" runat="server">Default Search Field B</asp:label>
                                <asp:dropdownlist id="ddlDefaultSearchFieldsB" runat="server" cssclass="form-select" Enabled="False"></asp:dropdownlist>
                            </div>

                            <div class="col-4 f-center">
                                <asp:label id="Label5" runat="server">Maintenance Page Path</asp:label>
                                <asp:textbox id="txtMaintenancePagePath" runat="server" cssclass="form-control" Enabled="False"></asp:textbox>
                            </div>
                        </div>
                    </p>


                    <div class="col-md-12">
                        <hr>
                    </div>
                </div>

                <div class="col-md-12">
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                </div>

            </form>
        </body>

        </HTML>
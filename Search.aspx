<%@ Page Language="c#" Inherits="EPolicy.EventControl" CodeFile="Search.aspx.cs" %>

    <%--<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>--%>
        <%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
            <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
            <html>

            <head>
                 <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			    <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
                <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
                <meta name="CODE_LANGUAGE" content="C#">
                <meta name="vs_defaultClientScript" content="JavaScript">
                <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">


				 <link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css" />
                <link rel="stylesheet" href="StyleSheet.css" type="text/css" />
                <script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
                <script src="js/load.js" type="text/javascript"></script>
				
				
              
                <style type="text/css">
                    .modalBackground {
                        background-color: Gray;
                        filter: alpha(opacity=50);
                        opacity: 0.5;
                    }
                </style>
            </head>

            <body>
                <div class="middleMain">
                    <form id="Form1" method="post" runat="server">
                        <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" AsyncPostBackTimeout="900">
                        </Toolkit:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <p>
                                    <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                                </p>
                                <div class="container-xl mb-4 p-18">
                                    <div class="col-md-12 f-center">
                                        <img alt="" src="Images2/search.png" class="searchImage" style="margin-bottom: 25px;" />
                                    </div>
                                    <div class="col-md-12 f-center">
                                        <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Bold="True" ForeColor="#3B3B3B" CssClass="headForm1 " Height="9px" Width="45px" Font-Size="18pt">Search</asp:Label>
                                    </div>
                                    <div class="col-md-12 f-center">
                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" class="btn-bg-theme2 btn" />
                                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Refresh" class="btn-bg-theme2 btn" />

                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="10">
                                            <ProgressTemplate>
                                                <img alt="" src="Images2/loader.gif" style="width: 35px; height: 35px;" />
                                                <span><span class=""></span><span style="font-family: Tahoma; font-size: 14pt; color: #BA354E">
                                <strong>Please wait...</strong></span></span>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <div class="col-md-12">
                                        <hr />
                                    </div>
                                    <asp:TextBox ID="txtBegDate" TabIndex="1" onclick="ShowDateTimePicker();" Font-Names="Tahoma" Visible="False" Height="12px" Width="88px" runat="server" Font-Size="9pt"></asp:TextBox>
                                    <asp:DropDownList ID="ddlTaskControlType" TabIndex="6" Font-Names="Tahoma" Visible="False" Height="23px" Width="198px" runat="server" AutoPostBack="True" Font-Size="9pt" OnSelectedIndexChanged="ddlTaskControlType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="LblEndingDate" Font-Names="Tahoma" Visible="False" Height="14px" Width="71px" runat="server" Font-Size="9pt">Ending Date:</asp:Label>
                                    <asp:TextBox ID="TxtEndDate" TabIndex="3" onclick="ShowDateTimePicker2();" Font-Names="Tahoma" Visible="False" Height="12px" Width="88px" runat="server" Font-Size="9pt"></asp:TextBox>
                                    <asp:Label ID="LblAgent" Font-Names="Tahoma" Visible="False" Height="14px" Width="35px" runat="server" Font-Size="9pt">Agent:</asp:Label>
                                    <asp:DropDownList ID="ddlAgent" TabIndex="7" Visible="False" Height="23px" Width="199" runat="server" Font-Size="9pt" Font-Names="Tahoma">
                                    </asp:DropDownList>
                                    <asp:Label ID="LblDataType" Font-Names="Tahoma" Visible="False" Height="14px" Width="62px" runat="server" Font-Size="9pt">Date Type:</asp:Label>
                                    <asp:DropDownList ID="ddlDateType" TabIndex="5" Font-Names="Tahoma" Visible="False" Height="23px" Width="124px" runat="server" Font-Size="9pt">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="E">Entry Date</asp:ListItem>
                                        <asp:ListItem Value="C">Close Date</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="LblBank" Font-Names="Tahoma" Visible="False" Height="14px" Width="35px" runat="server" Font-Size="9pt">Bank:</asp:Label>
                                    <asp:DropDownList ID="ddlBank" TabIndex="8" Font-Names="Tahoma" Visible="False" Height="23px" Width="198px" runat="server" Font-Size="9pt">
                                    </asp:DropDownList>
                                    <asp:Label ID="LblEventControlStatus" Font-Names="Tahoma" Visible="False" Height="14px" Width="30px" runat="server" Font-Size="9pt"> Status:</asp:Label>
                                    <asp:DropDownList ID="ddlTaskStatus" TabIndex="9" Font-Names="Tahoma" Visible="False" Height="23px" Width="198px" runat="server" Font-Size="9pt">
                                    </asp:DropDownList>
                                    <div class="col-md-12  f-center">
                                        <asp:TextBox ID="TxtTaskControlID" runat="server" Font-Names="Tahoma" CssClass="form-control w-25" placeholder="Control No."></asp:TextBox>
                                    </div>

                                    <asp:Label ID="lblTypeAddress1" Font-Names="Tahoma" Width="61px" runat="server" Height="14px" ForeColor="Black" Font-Size="9pt" Visible="False">Search By:</asp:Label>
                                    <asp:RadioButton class="headform1 " ID="RdbTaskControlID" TabIndex="11" runat="server" Font-Names="Tahoma" Width="93px" Height="2px" ForeColor="Black" BackColor="Transparent" Text="Control No." AutoPostBack="True" GroupName="SearchBy" Checked="True" Font-Size="9pt"
                                        OnCheckedChanged="RdbBusiness_CheckedChanged" Visible="False"></asp:RadioButton>
                                    <asp:RadioButton class="headform1 " ID="RdbFilterGroup" TabIndex="10" runat="server" Font-Names="Tahoma" Width="53px" Height="5px" ForeColor="Black" BackColor="Transparent" Text="Filter" AutoPostBack="True" GroupName="SearchBy" Font-Size="9pt" OnCheckedChanged="RdbIndividual_CheckedChanged"
                                        Visible="False">
                                    </asp:RadioButton>

                                    <div class="col-md-12">
                                        <asp:Label ID="LblTotalCases" Font-Names="Tahoma" CssClass="headForm1" runat="server" ForeColor="Black" Height="12px" Font-Size="11pt">Total Cases:</asp:Label>
                                        <hr />
                                    </div>
                                    <div class="col-md-12">     
                                                <table id="Table31" style="width: 100%; height: 0px" cellspacing="0" cellpadding="0" bgcolor="white" border="0">
                                                    <table id="Table1" style="z-index: 119; left: 17px; width: 100%; position: static;
														top: 105px; height: 359px" cellspacing="0" cellpadding="0" width="914" align="center" bgcolor="white" datapagesize="25" border="0">
                                                        <tr>
                                                            <td style="width: 809px; height: 0px" valign="middle" align="center">

                                                                <table id="Table61" style="width: 806px; height: 0px" cellspacing="0" cellpadding="0" width="806" border="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <table id="Table71" style="width: 736px; height: 0px" cellspacing="0" cellpadding="0" border="0" align="left">                                                                            
                                                                                <tr>
                                                                                    <td style="width: 161px; height: 0px">
                                                                                    </td>
                                                                                    <td style="width: 240px; height: 0px" colspan="2" align="right">

                                                                                        <asp:Label ID="lblTypeAddress11" Font-Names="Tahoma" Width="61px" runat="server" Height="14px" ForeColor="Black" Font-Size="9pt" Visible="False">Search By:</asp:Label>
                                                                                        <asp:RadioButton class="headform1 " ID="RdbTaskControlID1" TabIndex="11" runat="server" Font-Names="Tahoma" Width="93px" Height="2px" ForeColor="Black" BackColor="Transparent" Text="Control No." AutoPostBack="True" GroupName="SearchBy" Checked="True"
                                                                                            Font-Size="9pt" OnCheckedChanged="RdbBusiness_CheckedChanged" Visible="False">
                                                                                        </asp:RadioButton>
                                                                                        <asp:RadioButton class="headform1 " ID="RdbFilterGroup1" TabIndex="10" runat="server" Font-Names="Tahoma" Width="53px" Height="5px" ForeColor="Black" BackColor="Transparent" Text="Filter" AutoPostBack="True" GroupName="SearchBy" Font-Size="9pt" OnCheckedChanged="RdbIndividual_CheckedChanged" Visible="False"></asp:RadioButton>
                                                                                    </td>
                                                                                    <td style="height: 10px" width="250">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>     
                                                        <tr>
                                                            <td style="width: 100%; height: 0px" align="center">
                                                                <asp:Label ID="LblError" runat="server" Font-Names="Tahoma" Visible="False" ForeColor="Red" Width="694px" Font-Size="10pt">Label</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="width: 100%;text-align:center;">
                                                            <td style="font-size: 10pt; width: 100%; height: 239px; text-align:center;">
                                                                <asp:DataGrid ID="searchIndividual" Width="100%" runat="server" Height="118px" CellPadding="0" 
																class="table table-bordered" AutoGenerateColumns="False"  Font-Size="10pt"
																OnItemCommand="searchIndividual_ItemCommand1" OnItemDataBound="searchIndividual_ItemDataBound1">
                                                                    <Columns>
                                                                        <asp:ButtonColumn ButtonType="PushButton" HeaderStyle-CssClass="bi bi-check2 f-center" Text="..." CommandName="Select">
                                                                            <HeaderStyle Width="10%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center"/>
                                                                        </asp:ButtonColumn>
                                                                        <asp:BoundColumn DataField="TaskControlID" HeaderText="Control No.">
                                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="TaskControlTypeDesc" HeaderText="Control Type" DataFormatString="{0:d}">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="TaskStatusDesc" HeaderText="Status">
                                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Aging" HeaderText="Aging">
                                                                            <ItemStyle Font-Names="tahoma" HorizontalAlign="Left"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Agent" HeaderText="Agent">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn Visible="False" DataField="InsuranceCompany" HeaderText="Ins. Co.">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Bank" HeaderText="Bank">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="EntryDate" HeaderText="Entry Dt." DataFormatString="{0:d}">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="CloseDate" HeaderText="Close Dt." DataFormatString="{0:d}">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="CustomerNo" HeaderText="Customer No.">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="Name" HeaderText="Name">
                                                                            <ItemStyle Font-Names="tahoma"></ItemStyle>
                                                                        </asp:BoundColumn>
                                                                    </Columns>
                                                                    <PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20" CssClass="Numbers" Mode="NumericPages"></PagerStyle>
                                                                    <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Left" />
                                                                </asp:DataGrid>

                                                            </td>
                                                        </tr>
                                                    </table>
                                            
                                            <p align="center">
                                            </p>                                           
                                            <p align="center">
                                            </p>
                                            <p align="center">
                                            </p>
                                      
                                    </div>
                                   <%-- <MaskedInput:MaskedTextHeader ID="MaskedTextHeader1" runat="server"></MaskedInput:MaskedTextHeader>--%>
                                    <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                </div>
                </form>
                </div>
            </body>

            </html>
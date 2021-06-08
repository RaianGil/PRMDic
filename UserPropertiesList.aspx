<%@ Page Language="c#" Inherits="EPolicy.UserPropertiesList" CodeFile="UserPropertiesList.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
			    <link rel="icon" type="image/x-icon" href="images2/favicon.ico" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no" />
    <link href="js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="js/Calendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <link rel="stylesheet" type="text/css" href="http://cdn.datatables.net/plug-ins/3cfcc339e89/integration/bootstrap/3/dataTables.bootstrap.css" />
    <script type="text/javascript" src="js/jquery.dataTables.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#searchIndividual').dataTable({
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
            });
        });
    </script>
    <style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.5;
        }
        
        .btn-bg-theme1 {
            background: #ba354e;
            color: #fff;
        }
        .btn-w-150 {
            width: 150px;
            height: 35px;
        }
        .btn-bg-theme1 {
            background: #ba354e;
            color: #fff;
            }
    </style>
</head>
<body>
    <div class="middleMain">
        <form id="Form1" method="post" runat="server">
        <Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
            AsyncPostBackTimeout="900">
        </Toolkit:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
            <ContentTemplate>
                <table class="tableMain">
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="Placeholder1" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
                <table class="tableMain">
                    <tr>
                        <td align="center">
                            <img alt="" src="Images2/login.png" class="searchImage" style="margin-bottom: 25px;" />
                        </td>
                </table>
                <table class="tableMain">
                    <tr>
                        <td align="center">
                            <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Bold="True" ForeColor="#3B3B3B"
                                CssClass=" " Height="9px" Width="45px" Font-Size="18pt">User Profile List</asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="tableMain">
                    <tr class="">
                        <td align="center">
                            <asp:Button ID="BtnExit" runat="server" Text="Exit" class="btn-bg-theme1 btn btn-w-150" Font-Size="10pt"
                                OnClick="BtnExit_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 35px">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                DisplayAfter="10">
                                <ProgressTemplate>
                                    <img alt="" src="Images2/loader.gif" style="width: 35px; height: 35px;" />
                                    <span><span class=""></span><span style="font-family: Tahoma; font-size: 14pt; color: #BA354E">
                                        <strong>Please wait...</strong></span></span>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                <table id="Table3" class="tableMain">
                    <tr>
                        <td align="center">
                            <div class="col-md-12">
                                        <hr />
                                    </div>
                        </td>
                    </tr>
                </table>
                <table class="tableMain" style="width:75%;">
                    <tr>
                        <td align="left" >
                            <asp:Label ID="LblTotalCases" runat="server" Font-Names="Tahoma" style="margin-left:120px;"
                                Font-Bold="False" ForeColor="Black" Font-Size="11pt" CssClass="">Total Users</asp:Label>
                        </td>
                    </tr>
                </table>
                <table class="tableMain" align="center" style="width: 75%;">
                    <tr>
                        <td align="center">
                            <asp:GridView ID="searchIndividual" runat="server" class="table table-bordered" Width="100%" font-size="10pt"
                                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                GridLines="None" DataKeyNames="UserID, UserName, FirstName, LastName, AccountDisable"
                                OnRowCommand="searchIndividual_RowCommand">                              
                                <Columns>
                                    <asp:ButtonField ButtonType="Button" HeaderText="Sel." CommandName="Select" />
                                    <asp:BoundField Visible="False" DataField="UserID" HeaderText="UserID" />
                                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="AccountDisable" HeaderText="Account Disable" />
                                </Columns>                                
                                <FooterStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#BB1509" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#BB1509" ForeColor="White" HorizontalAlign="Center" />
                                
                            </asp:GridView>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                </p>
                <p>
                </p>
                <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </div>
</body>
</html>

<%@ Control Language="c#" Inherits="EPolicy.TopBanner2" CodeFile="TopBanner1.ascx.cs" %>
<% %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<title>PRMD | PUERTO RICO INSURANCE COMPANY</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link href="epolicy.css?$$REVISION$$" type="text/css" rel="stylesheet" />
<link rel="icon" type="image/x-icon" href="images2/favicon.ico" />

<link href="css/bootstrap.min.css" rel="stylesheet">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css">
<script src="js/bootstrap.bundle.min.js"></script>

<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript" src="js/jquery.maskedinput-1.2.2.js"></script>

<style>
    .btn-bg-theme1 {
    background: #BB1509;
    color: #fff;
    }
    
    .btn-bg-theme1:hover {
    background: #9d7373;
    color: #fff;
    }

    #tagA1:hover, #tagA2:hover, #tagA3:hover, #tagA4:hover, #tagA5:hover {
    color: #ffff;
    }
    
    #tagA1, #tagA2, #tagA3, #tagA4, #tagA5, #Linkbutton6 {
    color: rgba(255,255,255,.85);
    }
    #lilogout> a {
     color: rgba(255,255,255,.85);
    }
    #lilogout> a:hover {
     color: #ffff;
    }
    .label-vertical-align
    {
        align-self:center;
     }
    .navbar-bg-theme1
    {
        background: #BB1509;
    }
    
    .btn-bg-theme2
    {
        background:#495868;
        color: #fff;
    }
    .btn-bg-theme2:hover 
    {
        background: #c0c9d3;
        color: #fff;
    }

    .btn-w-150 {
        width: 150px;
        height: 35px;
    }

    .btn-w-75 {
        width: 75px;
    }
    .btn-w-100 {
        width: 100px;
        height: 35px;
    }

    .btn-w-70 {
        width: 70px;
        height: 25px;
        font-size: 9pt;
    }
    .btn-h-30 {
        width: auto;
        padding: 5px 18px;
        height: 30px;
        font-size: 9pt;
    }
    .btn-r-4 {
        border-radius: 4px;
        border: none;
    }
    .txt-pv-5 {
        padding: 5px 2px;
    }
    .txt-r-4 {
        box-shadow: inset 0 1px 1px rgb(0 0 0 / 8%);
        border-radius: 4px;
        background-color: #fff;
        border: 1px solid #ccc;
    }
    .ia-center{
      text-align: center;
    }

  .bd-placeholder-img {
    font-size: 1.125rem;
    text-anchor: middle;
    -webkit-user-select: none;
    -moz-user-select: none;
    user-select: none;
  }

  @media (min-width: 768px) {
    .bd-placeholder-img-lg {
      font-size: 3.5rem;
    }
  }

  .w-80 {
    width:80%;
  }
  .p-18 {
    padding:0px 18px;
  }
  .p-40 {
    padding:0px 40px;
  }
  .f-op-0 {
    color: rgba(0,0,0,0);
    background: rgba(0,0,0,0);
  }
  .f-op-10 {
    color: rgba(0,0,0,0);
    background: rgba(0,0,0,0.1);
  }
  .txt-xl {
    size: 11pt;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  }
  .txt-s {
    size: 9pt;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  }
  .bg-op-10 {
    background: rgba(0,0,0,0.05);
  }
  .d-none {
    display:none;
  }
  .w-auto1 {
    width: -webkit-fill-available;
  }
  .lst-h-104 {
    height: 104px;
  }
  .fs-16 {
    font-size: 16pt;
  }
  .fs-14 {
    font-size: 14pt;
  }
  .bs-1{
    border: solid 1px black;
  }
  .f-right {
    text-align: -webkit-right;
  }
  .f-center {
    text-align: -webkit-center;
  }
  .py-50 {
    padding: 50px 0px;
  }
  .mb-3-5 {
    margin-bottom: 1.25rem!important;
  }
  .fs-11{
    font-size: 11pt;
  }
  .fs-10{
    font-size: 10pt;
  }
  .fs-8 {
    font-size: 8pt;
  }
  .fw-bold {
    font-weight: bold;
  }
  .h-7 {
    height: 7rem;
   }
   .wh-10 {
     width: 10rem;
     height: 10rem;
   }
   .h-10 {
     height: 10rem;
   }
   .progress-m {
      top: 100%;
   }
   .fs-lbl-s {
     font-size: 9pt;
   }
   .fs-txt-s {
     font-size: 8pt;
   }
   .w-266 {
      width: 266%;
   }
   .h-6 {
     height: 6rem;
   }
   .w-260 {
    width: 260%;
   }
   .fw-bold
  {
    font-weight:bold;
  }
  ppr-1 
  {
      padding-right: 4px;
  }
  
</style>
    <script type="text/javascript">
        jQuery(function ($) {
            $(".telefoneFormat").mask("(999) 999-9999");
            $(".fechaFormat").mask("99/99/9999");
        });
    </script>
<script type="text/javascript">
    javascript: window.history.forward(1);  
</script>

  <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
     <div class="row" style="position:relative; top:10px;">
        <div class="col-md-6">
            <asp:image id="Image3" runat="server" ImageUrl="Images2/LogoPRMD.png" Width="50%"></asp:image>
        </div>
        <div class="col-md-6" style="text-align:end;">
            <asp:Image ID="imgGuessWho" runat="server" width="12%" ImageUrl="~/Images2/login.png" Visible="False"/>
            <asp:Label ID="lblUserName" runat="server" Font-Size="9pt" Font-Names="Tahoma"></asp:Label>
        </div>
     </div>
  </div>
  <%--<nav class="navbar navbar-expand-lg navbar-dark navbar-bg-theme1" id="navBarMenu" runat="server">
    <div class="container-xl">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample07XL" aria-controls="navbarsExample07XL" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarsExample07XL">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <a class="nav-link" id="tagA1" href="/Search.aspx">Main Menu</a>
          </li>
          <li class="nav-item dropdown" id="liSearch" runat="server">
            <a class="nav-link dropdown-toggle"  id="tagA2" href="#" data-bs-toggle="dropdown" aria-expanded="false">Search</a>
            <ul class="dropdown-menu">
              <li><a class="dropdown-item" id="liSearchByControlID" runat="server" href="/Search.aspx">Search by ControlID</a></li>
              <li><a class="dropdown-item" id="liSearchByProspects" runat="server" href="/SearchProspect.aspx">Search by Prospects</a></li>
              <li><a class="dropdown-item" id="liSearchByCustomers" runat="server" href="/SearchClient.aspx">Search by Customers</a></li>
              <li><a class="dropdown-item" id="liSearchByPolicies" runat="server" href="/SearchPolicies.aspx">Search by Policies</a></li>
              <li><a class="dropdown-item" id="liSearchByDirectory" runat="server" href="/Directorio.aspx">Search by Directory</a></li>
              <li><a class="dropdown-item" id="liSearchByGroups" runat="server" href="/SearchGroup.aspx">Search by Groups</a></li>
            </ul>
          </li>
          <li class="nav-item dropdown" id="liNewTransaction" runat="server">
            <a class="nav-link dropdown-toggle" id="tagA3" href="#" data-bs-toggle="dropdown" aria-expanded="false">New Transaction</a>
            <ul class="dropdown-menu">
              <li id="liProspect" runat="server">
                <asp:LinkButton ID="btnProspect" class="dropdown-item" runat="server" OnClick="btnProspect_Click">Prospect</asp:LinkButton>
              </li>
              <li id="liCustomers" runat="server">
                <asp:LinkButton ID="btnCustomers" class="dropdown-item" runat="server" OnClick="btnCustomers_Click">Customers</asp:LinkButton>
              </li>
              <li id="liASPENQuotes" runat="server">
                <asp:LinkButton ID="btnASPENQuotes" class="dropdown-item" runat="server" OnClick="btnASPENQuotes_Click">ASPEN Quotes</asp:LinkButton>
              </li>
              <li id="liLaboratoriesQuotes" runat="server">
                <asp:LinkButton ID="btnLaboratoriesQuotes" class="dropdown-item" runat="server" OnClick="btnLaboratoriesQuotes_Click">Laboratories Quotes</asp:LinkButton>
              </li>
              <li id="liCorporatePolicyQuotes" runat="server">
                <asp:LinkButton ID="btnCorporatePolicyQuotes" class="dropdown-item" runat="server" OnClick="btnCorporatePolicyQuotes_Click">Corporate Policy Quotes</asp:LinkButton>
              </li>
              <li id="liCyberPolicyQuotes" runat="server">
                <asp:LinkButton ID="btnCyberPolicyQuotes" class="dropdown-item" runat="server" OnClick="btnCyberPolicyQuotes_Click">Cyber Policy Quotes</asp:LinkButton>
              </li>
              <li id="liASPENCorporatePolicyQuotes" runat="server">
                <asp:LinkButton ID="btnASPENCorporatePolicyQuotes" class="dropdown-item" runat="server" OnClick="btnASPENCorporatePolicyQuotes_Click">ASPEN Corporate Policy Quotes</asp:LinkButton>
              </li>
              <li id="liApplicationRequirements" runat="server">
                <asp:LinkButton ID="btnApplicationRequirements" class="dropdown-item" runat="server" OnClick="btnApplicationRequirements_Click">Application Requirements</asp:LinkButton>
              </li>
            </ul>
          </li>
          <li class="nav-item dropdown" id="liReports" runat="server">
            <a class="nav-link dropdown-toggle" id="tagA4" href="#" data-bs-toggle="dropdown" aria-expanded="false">Reports</a>
            <ul class="dropdown-menu">
              <li id="liClientReports" runat="server">
                <a class="dropdown-item" href="/ClientReport.aspx">Client Reports</a>
              </li>
              <li id="liPoliciesReports" runat="server">
                <a class="dropdown-item" href="/PoliciesReports.aspx">Policies Reports</a>
              </li>
              <li id="liRenewalReports" runat="server">
                <a class="dropdown-item" href="/RenewalReport.aspx">Renewal Reports</a>
              </li>
              <li id="liPaymentReports" runat="server">
                <a class="dropdown-item" href="/PaymentsReport.aspx">Payment Reports</a>
              </li>
              <li id="liCommissionReports" runat="server">
                <a class="dropdown-item" href="/CommissionReport.aspx">Commission Reports</a>
              </li>
            </ul>
          </li>
          <li class="nav-item dropdown" id="liAdministration" runat="server">
            <a class="nav-link dropdown-toggle" id="tagA5" href="#" data-bs-toggle="dropdown" aria-expanded="false">Administration</a>
            <ul class="dropdown-menu">
              <li id="liPaymentExpress" runat="server">
                <a class="dropdown-item" href="/PaymentVSC.aspx">Payment Express</a>
              </li>
              <li id="liImportPayment" runat="server">
                <a class="dropdown-item" href="/CertificateFileUpload.aspx">Import Payment</a>
              </li>
              <li id="liLookupTables" runat="server">
                <a class="dropdown-item" href="/LookupTableMaintenance.aspx">Lookup Tables</a>
              </li>
              <li id="liUserPropertiesList" runat="server">
                <a class="dropdown-item" href="/UserPropertiesList.aspx">User Properties List</a>
              </li>
              <li id="liAddUser" runat="server">
                <asp:LinkButton ID="btnAddUser" class="dropdown-item" runat="server" OnClick="btnAddUser_Click">Add User</asp:LinkButton>
              </li>
              <li id="liEmailNotification" runat="server">
                <a class="dropdown-item" href="/PolicyReport.aspx">Email Notification</a>
              </li>
            </ul>
          </li>
        </ul>
        <ul class="navbar-nav">
            <li class="nav-item" id="lilogout">
                <asp:LinkButton ID="Linkbutton6" class="nav-link" runat="server" OnClick="btnLogout_Click">Logout</asp:LinkButton>
            </li>
        </ul>
      </div>
    </div>
  </nav>--%>

 <div class="container-xl" style=" position: relative; z-index: 101;">
<table class="tableMain" style="width:100%;">
<%--    <tr style="height: 120px;">
        <td align="left">
            <img alt="" src="Images2/LogoPRMD.png" style="width: 166px; height: 100px; margin-left: 300px;"
                class="" />
        </td>
    </tr>--%>
    <tr style="background: #BB1509;" >
        <td style="background: #BB1509;">
           <div class="hideSkiplink">
                <div style="height:50px; width: 100%; background:#BB1509; ">
                    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="False"
                        IncludeStyleBlock="False" Orientation="Horizontal" Font-Names="Tahoma"
                        Font-Size="15pt" ForeColor="Blue" OnMenuItemClick="NavigationMenu_MenuItemClick">
                        <Items >
                            <asp:MenuItem Text="Main Menu" Value="Main Menu"></asp:MenuItem>
                            <asp:MenuItem Text="Search" Value="Search">
                                <asp:MenuItem Text="Search by ControlID" Value="Search by ControlID"></asp:MenuItem>
                                <asp:MenuItem Text="Search by Prospects" Value="Search by Prospects"></asp:MenuItem>
                                <asp:MenuItem Text="Search by Customers" Value="Search by Customers"></asp:MenuItem>
                                <asp:MenuItem Text="Search by Policies" Value="Search by Policies"></asp:MenuItem>
                                <asp:MenuItem Text="Search by Directory" Value="Search by Directory"></asp:MenuItem>
                                <asp:MenuItem Text="Search by Groups" Value="Search by Groups"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="New Transaction" Value="New Transaction">
                                <asp:MenuItem Text="Prospect" Value="Prospect"></asp:MenuItem>
                                <asp:MenuItem Text="Customers" Value="Customers"></asp:MenuItem>
								<asp:MenuItem Text="Quotes" Value="Quotes"></asp:MenuItem>								
								<asp:MenuItem Text="First Dollar Quotes" Value="First Dollar Quotes"></asp:MenuItem>
								<asp:MenuItem Text="First Dollar Corporate Quotes" Value="First Dollar Corporate Quotes"></asp:MenuItem>								
                                <asp:MenuItem Text="ASPEN Quotes" Value="ASPEN Quotes"></asp:MenuItem>
                                <asp:MenuItem Text="Laboratories Quotes" Value="Laboratories Quotes"></asp:MenuItem>
								<asp:MenuItem Text="Aspen Laboratories Quotes" Value="Aspen Laboratories Quotes"></asp:MenuItem>								
                                <asp:MenuItem Text="Corporate Policy Quotes" Value="Corporate Policy Quotes"></asp:MenuItem>								
                                <asp:MenuItem Text="Cyber Policy Quotes" Value="Cyber Policy Quotes"></asp:MenuItem>								
								<asp:MenuItem Text="AHP Individual Quotes" Value="AHP Individual Quotes"></asp:MenuItem>
								<asp:MenuItem Text="AHC Corporate Quotes" Value="AHC Corporate Quotes"></asp:MenuItem>								
                                <asp:MenuItem Text="ASPEN Corporate Policy Quotes" Value="ASPEN Corporate Policy Quotes">
                                </asp:MenuItem>
                                <asp:MenuItem Text="Application Requirements" Value="Application Requirements"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Reports" Value="Reports">
                                <asp:MenuItem Text="Client Reports" Value="Client Reports"></asp:MenuItem>
                                <asp:MenuItem Text="Policies Reports" Value="Policies Reports"></asp:MenuItem>
                                <asp:MenuItem Text="Renewal Reports" Value="Renewal Reports"></asp:MenuItem>
                                <asp:MenuItem Text="Payment Reports" Value="Payment Reports"></asp:MenuItem>
                                <asp:MenuItem Text="Commission Reports" Value="Commission Reports"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Administration" Value="Administration">
                                <asp:MenuItem Text="Payment Express" Value="Payment Express"></asp:MenuItem>
                                <asp:MenuItem Text="Import Payment" Value="Import Payment"></asp:MenuItem>
                                <asp:MenuItem Text="Lookup Tables" Value="Lookup Tables"></asp:MenuItem>
                                <asp:MenuItem Text="User Properties List" Value="User Properties List"></asp:MenuItem>
                                <asp:MenuItem Text="Add User" Value="Add User"></asp:MenuItem>
                                <asp:MenuItem Text="Email Notification" Value="Email Notification"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Logout" Value="Logout"></asp:MenuItem>

                        </Items>
                    </asp:Menu>
                </div>
            </div>
        </td>
    </tr>
</table>
 </div>
                            <%--<asp:MenuItem Text="Auto Nuevo" Value="Auto Nuevo"></asp:MenuItem>--%>

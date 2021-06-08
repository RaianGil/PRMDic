<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TailQuote.aspx.cs" Inherits="TailQuote" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Strict//EN">
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<link rel="stylesheet" href="StyleSheet.css" type="text/css"/>
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
   <style type="text/css">
        .toggler { width: 276px; height: 9px; }
        #button { padding: .5em 2em; text-decoration: none; }
        #btnCloseEffect {text-decoration: none; }
        #effect { width: 315px; height: 228px; padding: 0.4em; position: relative;}
        #effect h3 { margin: 0; padding: 0.4em; text-align: center; }
        .ui-effects-transfer { border: 2px dotted gray; } 
    </style>   
	<style type="text/css">	
	    #jq-books{width:200px;float:right;margin-right:0}
	    #jq-books li{line-height:1.25em;margin:1em 0 1.8em;clear:left}
	    #home-content-wrapper #jq-books a.jq-bookImg{float:left;margin-right:10px;width:55px;height:70px}
	    #jq-books h3{margin:0 0 .2em 0}
	    #home-content-wrapper #jq-books h3 a{font-size:1em;color:black;}
	    #home-content-wrapper #jq-books a.jq-buyNow{font-size:1em;color:white;display:block;background:url(http://static.jquery.com/files/rocker/images/btn_blueSheen.gif) 50% repeat-x;text-decoration:none;color:#fff;font-weight:bold;padding:.2em .8em;float:left;margin-top:.2em;}
	    .headfield1
        {
            text-align: left;
        }

	    #Form1
        {
            width: 437px;
            height: 393px;
        }

	</style>
</head>
<script language="javascript">
        setTimeout("self.close();", 120000) //60000

        $(function() {
            $('#<%= txtSearchDate.ClientID %>').datepicker({
                changeMonth: true,
                changeYear: true
            });

        });

        function ShowDateTimePicker() {
            $('#<%= txtSearchDate.ClientID %>').datepicker('show');
        }
</script> 
<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 450px; height: 303px">
            <div style="visibility:hidden;"><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></div>
             <div class="row" style="align-self:center;">
                <asp:Label id="Label8" runat="server" CssClass="fs-14 fw-bold">Tail Premium Quote</asp:Label>
             </div>
             <hr />
             <div class="row" style="align-self:center;">
                <div class="col-md-6">
                    <asp:Label id="lblPolicyNo" runat="server" CssClass="fs-11">Policy No:</asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:Label id="lblCustomerName" CssClass="fs-11" runat="server">Customer: </asp:Label>
                </div>
             </div>

             <hr />
            
            <div class="row">
                <div class="col-md-4">
                    <asp:label id="LblDate" CssClass="fs-lbl-s" RUNAT="server">Cancelation Date:</asp:label>
                </div>
                <div class="col-md-8">
                    <div class="input-group mb-3">
                      <asp:Textbox  id="txtSearchDate" class="form-control" RUNAT="server" ISDATE="True"></asp:Textbox>
                      <asp:button id="btnCalculate" runat="server" Text="Calculate" class="btn btn-outline-primary" onclick="btnCalculate_Click"></asp:button>
                    </div>
                </div>
            </div>
            
            
            
            <asp:Label ID="Label13" runat="server" Text="Cyber Premium:" Visible="False"></asp:Label>
            
            <asp:TextBox ID="txtCyberPercent" runat="server" Visible="False"></asp:TextBox>
            
            <asp:Label ID="Label9" runat="server" Text="MCM Rate:" Visible="False"></asp:Label>
            
            <asp:TextBox ID="txtMCMRate" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            
            <asp:Label ID="Label10" runat="server" Text="Tail Rate:" Visible="False"></asp:Label>
            
            <asp:TextBox ID="txtTailRate" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            
            <asp:Label ID="Label12" runat="server" Text="Years:" Visible="False"></asp:Label>
            
            <asp:RadioButtonList ID="RadioButtonListCyber" runat="server" RepeatDirection="Horizontal" Visible="False">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
            </asp:RadioButtonList>
            
            <asp:Label ID="Label11" runat="server" Text="TAIL PREMIUM:" Visible="False"></asp:Label>
            
            <asp:TextBox ID="txtTailPremium" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            
            <asp:button id="btnConvert" runat="server" Text="Convert" class="btn btn-outline-primary" onclick="btnConvert_Click" Visible="False"></asp:button>
            <asp:button id="btnPrint" runat="server" Text="Print" class="btn btn-outline-primary" onclick="btnPrint_Click" Visible="False"></asp:button>
            <asp:button id="BtnExit" runat="server" Text="Exit" class="btn btn-outline-danger" onclick="BtnExit_Click"></asp:button>
            <hr />

	        <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
	        <asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
	    	</p>
            <br />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstDollarQuotes.aspx.cs" Inherits="FirstDollarQuotes" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>ePMS | electronic Policy Manager Solution</title>
    	<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
        <script src="js/load.js" type="text/javascript"></script>
    <style type="text/css">
        .toggler { width: 276px; height: 16px; }
        #button { padding: .5em 2em; text-decoration: none; }
        #btnCloseEffect {text-decoration: none; }
        #effect { width: 455px; height: 480px; padding: 0.4em; position: relative; }
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
	    .style4
        {
            width: 147px;
        }
        .style5
        {
            height: 46px;
            width: 147px;
        }
        .style6
        {
            height: 17px;
            width: 147px;
        }
        .style7
        {
            height: 19px;
            width: 147px;
        }
	    .style8
        {
            width: 46px;
        }
	</style>	
	<script>
	function parseRate()
	{
        var myString;
        //for(i = 1;i <= document.form1.ddlPolicyClass.options.length ; i++)
		//{
              //myString = document.form1.ddlPolicyClass.options[1].value;
               myString = document.form1.ddlPolicyClass.options[document.form1.ddlPolicyClass.selectedIndex].value;
              var myRateList = myString.split("|");
            //alert(myRateList[0]+"-"+myRateList[1])
             
              document.form1.txtPrateID.value = myRateList[0];
              document.form1.HIIsoCode.value = myRateList[1];
              document.form1.HIClass.value = myRateList[2];
              document.form1.HIRate1.value = myRateList[3];
              document.form1.HIRate2.value = myRateList[4];
              document.form1.HIRate3.value = myRateList[5];
              document.form1.HIRate4.value = myRateList[6];
              
              document.form1.txtIsoCode.value = myRateList[1];
              document.form1.txtClass.value = myRateList[2];
              document.form1.txtRate1.value = myRateList[3];
              document.form1.txtRate2.value = myRateList[4];
              document.form1.txtRate3.value = myRateList[5];
              document.form1.txtRate4.value = myRateList[6];
//              for(a = 0;a < myRateList.lenght; a++)
//              {
//                var Rate1 = myRateList[a];
//                var startPos = Rate1.indexOf(',');
//                var myValue = Rate1.substring(startPos, Rate1.lenght -startPos);
//                //alert(myValue);
//                document.form1.txtIsoCode.value = myValue;
//              }
        //}
	}
	
</script>
</head>
<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript">
    $(function() 
    {
        $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
        $('#<%= txtPriPolEffecDate2.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});
        $('#<%= txtPriPolEffecDate3.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});            
        $('#<%= txtExcPolEffecDate1.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});   
        $('#<%= txtExcPolEffecDate2.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true}); 
        $('#<%= txtExcPolEffecDate3.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true}); 
        $('#<%= txtDateBirth.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});  
      $('#<%= txtPrimaryRetroDate.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});  
      $('#<%= txtExcessRetroDate.ClientID %>').datepicker({
            changeMonth: true,
            changeYear: true});    
    });

    function ShowDateTimePicker()
    {
        $('#<%= txtPriPolEffecDate1.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker2()
    {
        $('#<%= txtPriPolEffecDate2.ClientID %>').datepicker('show');
    }    
    function ShowDateTimePicker3()
    {
        $('#<%= txtPriPolEffecDate3.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker4()
    {
        $('#<%= txtExcPolEffecDate1.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker5()
    {
        $('#<%= txtExcPolEffecDate2.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker6()
    {
        $('#<%= txtExcPolEffecDate3.ClientID %>').datepicker('show');
    }
    function ShowDateTimePicker7()
    {
        $('#<%= txtDateBirth.ClientID %>').datepicker('show');
    } 
    function ShowDateTimePicker8()
    {
        $('#<%= txtPrimaryRetroDate.ClientID %>').datepicker('show');
    }     
   

    //style="width: 316px; display:none"

    function pageLoad()
        {
            //sets initial state of the contactfinderdiv
            //alert(jQuery('#HIState').val());
            var state = jQuery('#HIState').val();
            if (state == '1') {
                $('#effect').css('display', 'block');
                //$('#HIState').val('');
            } else {
                $('#effect').css('display', 'none');
            }

            $('.btnRate').click(function() {
                $('.togglebox').show('slow');       
            });

            $('.btnCloseEffect').click(function() {
                $('.togglebox').hide('slow');
            });
       }
    $(function() { 
    
        
		//run the currently selected effect
		function runEffect()
		{
			//get effect type from 
			//var selectedEffect = $('#effectTypes').val();
			$('#HIState').val('1');
			var selectedEffect ="blind";
			//most effect types need no options passed by default
			var options = {};			
			//run the effect
			$("#effect").show(selectedEffect,options,500,callback);
		};
		
		//callback function to bring a hidden box back
		function callback()
		{
//			setTimeout(function()
//			    {
//				    $("#effect:visible").removeAttr('style').hide().fadeOut();
//			    }, 
//			1000);
		};
				
        function CloseEffect()
	    {
		    setTimeout(function()
		      {
		         $('#HIState').val('0');
				 $("#effect:visible").removeAttr('style').hide().fadeOut();
			  }, 
			    10);
	    }
					
		//set effect from select menu value
		$("#button").click(function() {
			runEffect();
			return false;
		});		
		
		$("#btnRate").click(function() {
			runEffect();
			return false;
		});	
		
		$("#btnCloseEffect").click(function() {
			CloseEffect();
			return false;
		});
		
		$("#effect").hide();
	});
</script>
<body onload ="pageLoad()"  background="Images2/SQUARE.GIF">
    <form id="form1" runat="server">
    <div>
        <table id="Table8" align="center" bgcolor="white" border="0" cellpadding="0" cellspacing="0"
           style="z-index: 139; left: 4px; width: 921px; position: static;
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
                    <p align="left">
                        <asp:PlaceHolder ID="phTopBanner1" runat="server"></asp:PlaceHolder>
                    </p>
                </td>
                <td align="center" style="font-size: 0pt; width: 86px; height: 396px">                         
                        <table id="Table9" bgcolor="white" border="0" cellpadding="0" cellspacing="0" style="width: 819px;
                            height: 64px" width="819">
                            <tr>
                                <td style="font-size: 0pt; " valign="top" class="style4">
                                    <table id="Table11" border="0" 
                                       cellpadding="0" cellspacing="0" style="width: 808px"
                                        width="808">
                                        <tr>
                                            <td class="style8" rowspan="2" >
                                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                    Font-Size="11pt" ForeColor="Black" Height="16px" Width="92px">Application:</asp:Label>
                                                <asp:Label ID="lblTaskControlID" runat="server" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="124px"></asp:Label>
                                            </td>
                                       
                                          
                                            <td>  <%--Se movieron los botones Convert Primary y Convert Excess--%>                                                         
                                                         <asp:Button ID="btnConvert" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Convert Excess" Width="125px" OnClick="btnConvert_Click" 
                                                    TabIndex="1" style="margin-right: 1px" Visible="False" />  </td>
                                            <td align="right" >                                            
                                                                                                                                                                                                                                          
                                                <asp:Button ID="btnPrint" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Print Quote" Width="80px" OnClick="btnPrint_Click" TabIndex="2" 
                                                    style="margin-right: 1px; margin-bottom: 1px;" Visible="False" />                                                                                               
                                            </td>
                                        </tr>
                                        <tr>
                                        
                                        <%--Se movió de ésta área el botón Convert Excess al lado izquierdo del botón Convert Primary--%>
                                            <td >  
                                              <asp:Button ID="btnConvertPrimary" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Convert Policy" Width="125px" OnClick="btnConvertPrimary_Click" 
                                                    TabIndex="1" style="margin-right: 1px; margin-bottom: 1px;" />                                                 
                                            </td>
                                            
                                            <td align="right" >
                                                <asp:Button ID="btnRate" runat="server" Text="Rate" BackColor="#400000" 
                                                    BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma"
                                                    ForeColor="White" Height="23px" TabIndex="69" Width="65px" 
                                                   style="margin-right: 1px" />
                                                <asp:Button ID="BtnSave" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px" OnClick="BtnSave_Click"
                                                    TabIndex="70" Text="Save" Width="65px" style="margin-right: 1px" />
                                                <asp:Button ID="btnEdit" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Modify" Width="65px" OnClick="btnEdit_Click" TabIndex="4" 
                                                    style="margin-right: 1px" />
                                                <asp:Button ID="btnDelete" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Delete" Width="65px" OnClick="btnDelete_Click" TabIndex="1" 
                                                    style="margin-right: 1px" />
                                                <asp:Button ID="btnCancel" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Cancel" Width="65px" OnClick="btnCancel_Click" TabIndex="3" 
                                                    style="margin-right: 1px" />
                                                <asp:Button ID="BtnExit" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Exit" Width="65px" OnClick="BtnExit_Click" TabIndex="5" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                            <div class="toggler" align="center">
                                                            <div id="effect" class="ui-widget-header ui-corner-all" style="width: 453px; display:none">
                                                                                                                                                                       
                                                                        <asp:Panel ID="Panel1" runat="server">
                                                                        <table style="width: 244px; font-size: 9pt;" border="1">
                                                                            <tr>
                                                                                <td align="center" colspan="5" height="16">
                                                                    <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14pt"
                                                                        Font-Underline="True" Text="Select Rate" Width="116px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="5" height="16">
                                                                                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Rate" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                                                                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Excess" AutoPostBack="True" Visible="false" OnCheckedChanged="RadioButton2_CheckedChanged" /></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14" align="right">
                                                                                    <asp:Label ID="Label51" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Retro Date:"
                                                                                        Width="129px"></asp:Label></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <MaskedInput:MaskedTextBox ID="txtPrimaryRetroDate" runat="server"
                                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsDate="True" onclick="ShowDateTimePicker8();"
                                                                                        TabIndex="11" Width="66px" AutoPostBack="True" OnTextChanged="txtPrimaryRetroDate_TextChanged"></MaskedInput:MaskedTextBox></td>
                                                                                <td height="14" align="right" colspan="2">
                                                                                    <asp:Label ID="Label56" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Excess Retro Date:"
                                                                                        Width="119px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <MaskedInput:MaskedTextBox ID="txtExcessRetroDate" runat="server"
                                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsDate="True" onclick="ShowDateTimePicker9();"
                                                                                        TabIndex="11" Width="66px" AutoPostBack="True" OnTextChanged="txtExcessRetroDate_TextChanged"></MaskedInput:MaskedTextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" colspan="5" height="14">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label63" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
                                                                                        Text="Rate" Width="120px"></asp:Label></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:Label ID="Label65" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 1"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label66" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 2"
                                                                                        Width="48px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label67" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 3"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label68" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="MCM Rate "
                                                                                        Width="68px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlPrimaryLimits1" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" OnSelectedIndexChanged="ddlPrimaryLimits1_SelectedIndexChanged" ForeColor="Black">
                                                                                    </asp:DropDownList></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtPRate1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtPRate2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtPRate3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtPRate4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14" colspan="5">
                                                                                    </td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row1">
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label64" runat="server" Font-Names="Tahoma" Font-Size="10pt" Text="Excess Rate"
                                                                                        Width="107px" Font-Bold="True"></asp:Label></td>
                                                                                <td style="width: 155px" height="14">
                                                                                    <asp:Label ID="Label42" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 1"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label43" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 2"
                                                                                        Width="48px"></asp:Label></td>
                                                                                <td style="width: 83px" height="14">
                                                                                    <asp:Label ID="Label45" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Rate 3"
                                                                                        Width="44px"></asp:Label></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label44" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="MCM Rate "
                                                                                        Width="68px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row2">
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlLimits" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" OnSelectedIndexChanged="ddlLimits_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                                <td style="width: 155px" height="14">
                                                                                    <asp:TextBox ID="txtRate1" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 32px">
                                                                                    <asp:TextBox ID="txtRate2" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td style="width: 83px" height="14">
                                                                                    <asp:TextBox ID="txtRate3" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate4" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row3">
                                                                                <td colspan="5" height="14">
                                                                                    <asp:Label ID="Label62" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Others Excess Rates:"
                                                                                        Width="200px"></asp:Label></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row4">
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlLimits2" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" OnSelectedIndexChanged="ddlLimits_SelectedIndexChanged" ForeColor="Black">
                                                                                    </asp:DropDownList></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtRate12" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 32px">
                                                                                    <asp:TextBox ID="txtRate22" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate32" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate42" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row5">
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlLimits3" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" ForeColor="Black">
                                                                                    </asp:DropDownList></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtRate13" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 32px">
                                                                                    <asp:TextBox ID="txtRate23" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate33" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate43" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row6">
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlLimits4" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" ForeColor="Black" OnSelectedIndexChanged="ddlLimits4_SelectedIndexChanged">
                                                                                    </asp:DropDownList></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtRate14" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 32px">
                                                                                    <asp:TextBox ID="txtRate24" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate34" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate44" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row7" >
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlLimits5" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" ForeColor="Black">
                                                                                    </asp:DropDownList></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtRate15" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 32px">
                                                                                    <asp:TextBox ID="txtRate25" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate35" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate45" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr runat="server" id="Row8">
                                                                                <td height="14">
                                                                                    <asp:DropDownList ID="ddlLimits6" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="8.5pt" Height="20px"
                                                                                        TabIndex="1" Width="136px" AutoPostBack="True" ForeColor="Black">
                                                                                    </asp:DropDownList></td>
                                                                                <td height="14" style="width: 155px">
                                                                                    <asp:TextBox ID="txtRate16" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 32px">
                                                                                    <asp:TextBox ID="txtRate26" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate36" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                                <td height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtRate46" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                                        ReadOnly="True" TabIndex="8" Width="64px"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14" colspan="5">
                                                                                </td>
                                                                            </tr>
                                                                              <tr>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label57" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Select Specialty:"
                                                                                        Width="117px"></asp:Label></td>
                                                                                <td height="14" colspan="4"><asp:DropDownList ID="ddPrimarylPolicyClass" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="9pt" Height="20px"
                                                                                        TabIndex="1" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1" Visible="True">
                                                                                </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="14">
                                                                                    <asp:Label ID="Label41" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Select Specialty:"
                                                                                        Width="117px"></asp:Label></td>
                                                                                <td align="left" height="14" style="width: 83px" colspan="4"><asp:DropDownList ID="ddlPolicyClass" runat="server" Font-Names="Tahoma"
                                                                                        Font-Size="9pt" Height="20px"
                                                                                        TabIndex="1" Width="228px" OnSelectedIndexChanged="ddlPolicyClass_SelectedIndexChanged1" Visible="False" AutoPostBack="True">
                                                                                </asp:DropDownList></td>
                                                                            </tr>
                                                                          
                                                                            <tr>
                                                                                <td colspan="1" height="14">
                                                                                    <asp:Label ID="Label46" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Iso Code:"
                                                                                        Width="64px"></asp:Label></td>
                                                                                <td colspan="2" height="14">
                                                                                    <asp:TextBox ID="txtIsoCode" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                                        Height="12px" TabIndex="8" Width="68px" ReadOnly="True"></asp:TextBox></td>
                                                                                <td align="center" height="14" style="width: 83px">
                                                                                    <asp:Label ID="Label47" runat="server" Font-Names="Tahoma" Font-Size="9pt" Text="Class:"
                                                                                        Width="64px"></asp:Label></td>
                                                                                <td align="center" height="14" style="width: 83px">
                                                                                    <asp:TextBox ID="txtClass" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                                        Height="12px" TabIndex="8" Width="68px" ReadOnly="True"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" height="14">
                                                                                </td>
                                                                                <td align="center" height="14" style="width: 83px">
                                                                                    <asp:Button ID="btnCloseEffect" runat="server" Text="Close" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" Font-Names="Tahoma" Font-Size="9pt" ForeColor="White" Height="23px" Width="60px" /></td>
                                                                            </tr>
                                                                        </table>
                                                                        </asp:Panel>
                                                                      

                                                                   
                                            
                                                            </div>
                                                            </div>                                                            
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="font-size: 2pt; " valign="middle" class="style5">
                                                           
                                    <table id="Table6" border="0" cellpadding="0" cellspacing="0" style="width: 811px;
                                        height: 112px" width="811">
                                        <tr>
                                            <td align="center" style="font-size: 1pt; height: 169px;" valign="top">
                                                <table id="Table1" border="1" cellpadding="0" cellspacing="0" style="width: 100%;
                                                    height: 1px" width="806">
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td style="width: 200px; height: 11px" align="left" colspan="2">
                                                            <asp:Label ID="Label2" runat="server"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="6px" Width="176px" Font-Bold="True">I. PERSONAL INFORMATION</asp:Label></td>
                                                        <td style="width: 15%; height: 11px" align="left">
                                                            <asp:Label ID="Label1" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="80px">Customer No.:</asp:Label></td>
                                                        <td style="width: 330px; height: 11px" align="left">
                                                            <asp:TextBox ID="TxtCustomerNo" runat="server" Height="12px" Width="108px" Font-Names="Tahoma" Font-Size="9pt"></asp:TextBox>
                                                                                   
                                                                                   
                                                                                   
                                                                     
                                                            <asp:Button ID="btnNextTop" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Next >" Width="54px" OnClick="btnNextTop_Click" TabIndex="6" Visible="False" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td align="left" colspan="2" style="width: 280px; height: 11px">
                                                             
                                                        </td>
                                                        <td align="left" style="width: 15%; height: 11px">
                                                            <asp:Label ID="Label50" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="80px">Status:</asp:Label></td>
                                                        <td align="left" style="width: 330px; height: 11px">
                                                            <asp:DropDownList ID="ddlStatus" runat="server" Height="21px" Width="276px" 
                                                                Font-Names="Tahoma" Font-Size="9pt" TabIndex="52">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td align="left" colspan="2" style="width: 280px; height: 11px">
                                                        </td>
                                                        <td align="left" style="width: 15%; height: 11px">
                                                            <asp:Label ID="Label52" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="56px">Agency:</asp:Label></td>
                                                        <td align="left" style="width: 330px; height: 11px">
                                                            <asp:DropDownList ID="ddlAgency" runat="server" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="19px" TabIndex="52" Width="276px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td align="left" colspan="2" style="width: 280px; height: 11px">
                                                        </td>
                                                        <td align="left" style="width: 15%; height: 11px">
                                                            <asp:Label ID="Label53" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px" Width="40px">Agent:</asp:Label></td>
                                                        <td align="left" style="width: 330px; height: 11px">
                                                            <asp:DropDownList ID="ddlAgent" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="8pt" Height="19px" TabIndex="52" Width="276px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 10px">
                                                        </td>
                                                        <td style="width: 19%; height: 10px" align="left">
                                                             <asp:Label ID="Label54" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="10pt" ForeColor="Red" Height="2px" Width="1px">*</asp:Label><asp:Label ID="lblGender" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="2px">Name:</asp:Label></td>
                                                        <td align="left" style="width: 186px; height: 10px">
                                                            <asp:TextBox ID="TxtFirstName" runat="server" Height="12px" Width="164px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="7"></asp:TextBox></td>
                                                        <td style="width: 15%; height: 10px" align="left">
                                                            </td>
                                                        <td style="width: 331px; height: 10px" align="left">
                                                             </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 15px">
                                                        </td>
                                                        <td style="width: 19%; height: 11px" align="left">
                                                            <asp:Label ID="lblLastName2" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="2px" Width="36px">Middle:</asp:Label></td>
                                                        <td align="left" style="width: 186px; height: 11px">
                                                            <asp:TextBox ID="TxtInitial" runat="server" Height="12px" Width="24px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="8"></asp:TextBox></td>
                                                        <td style="width: 15%; height: 11px" align="left">
                                                             <asp:Label ID="Label6" runat="server" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="17px" Width="88px">Office Address:</asp:Label>  
                                                        </td>
                                                        <td style="width: 273px; height: 15px" colspan="1" align="left">
                                                            <asp:TextBox ID="TxtAddrs1" runat="server" Height="12px" Width="312px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="15"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 14px">
                                                        </td>
                                                        <td style="width: 19%; height: 14px" align="left">
                                                            <asp:Label ID="Label55" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="10pt" ForeColor="Red" Height="2px" Width="1px">*</asp:Label>
                                                            <asp:Label ID="lblBirthdate" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="52px">LastName:</asp:Label></td>
                                                        <td align="left" style="width: 186px; height: 11px">
                                                            <asp:TextBox ID="txtLastname1" runat="server" Height="12px" Width="164px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="9"></asp:TextBox></td>
                                                        <td style="width: 15%; height: 14px" align="left">
                                                            </td>
                                                        <td colspan="1" style="width: 240px; height: 14px" align="left">
                                                            <asp:TextBox ID="TxtAddrs2" runat="server" Height="12px" Width="312px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="16"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td style="width: 19%; height: 11px" align="left">
                                                            <asp:Label ID="Label4" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="60px">LastName2:</asp:Label></td>
                                                        <td style="width: 186px; height: 11px" align="left">
                                                            <asp:TextBox ID="txtLastname2" runat="server" Height="12px" Width="164px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="10"></asp:TextBox></td>
                                                        <td style="width: 15%; height: 11px" align="left">
                                                             <asp:Label ID="Label7" runat="server" CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="17px" Width="44px">City:</asp:Label></td>
                                                        <td style="width: 331px; height: 11px" align="left">
                                                            <asp:TextBox ID="TxtCity" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="180px" TabIndex="17"></asp:TextBox>
                                                              
                                                            <asp:TextBox ID="TxtState" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="12px"
                                                                Width="16px" TabIndex="18"></asp:TextBox>
                                                              
                                                            <MaskedInput:MaskedTextBox ID="TxtZip" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" IsDate="False" Mask="99999Z9999" MaxLength="10"
                                                                TabIndex="19" Width="96px"></MaskedInput:MaskedTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px">
                                                        </td>
                                                        <td style="width: 19%; height: 11px" align="left">
                                                             <asp:Label ID="lblMaritalStatus" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="1px" Width="76px">Date of Birth:</asp:Label></td>
                                                        <td align="left" style="width: 186px; height: 11px">
                                                            <MaskedInput:MaskedTextBox ID="txtDateBirth" runat="server" onclick="ShowDateTimePicker7();" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsDate="True" TabIndex="11"
                                                                Width="84px"></MaskedInput:MaskedTextBox></td>
                                                        <td align="left" style="width: 15%; height: 11px">
                                                            <asp:Label ID="Label59" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="10pt" ForeColor="Red" Height="2px" Width="1px">*</asp:Label>
                                                            <asp:Label ID="Label3" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="2px" Width="84px">Office Phone:</asp:Label></td>
                                                        <td align="left" style="width: 331px; height: 11px">
                                                            <MaskedInput:MaskedTextBox ID="txtWorkPhone" runat="server"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsCurrency="False" IsDate="False"
                                                                IsZipCode="False" Mask="(999) 999-9999" TabIndex="20" Width="100px" MaxLength="14"></MaskedInput:MaskedTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 10px">
                                                        </td>
                                                        <td style="width: 19%; height: 11px" align="left">
                                                            <asp:Label ID="lblComments" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="9px" Width="80px">Place of Birth:</asp:Label></td>
                                                        <td align="left" style="width: 186px; height: 11px">
                                                            <asp:TextBox ID="txtBirthPlace" runat="server" Height="12px" Width="164px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="12"></asp:TextBox></td>
                                                        <td style="width: 15%; height: 11px" align="left">
                                                            <asp:Label ID="lblLastName1" runat="server" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="2px" Width="60px">Office Fax:</asp:Label></td>
                                                        <td style="width: 331px; height: 10px" align="left">
                                                            <MaskedInput:MaskedTextBox ID="TxtCellular" runat="server"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsCurrency="False" IsDate="False"
                                                                IsZipCode="False" Mask="(999) 999-9999" TabIndex="21" Width="100px" MaxLength="14"></MaskedInput:MaskedTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px;">
                                                        </td>
                                                        <td style="width: 19%;" align="left">
                                                             <asp:Label ID="lblSocialSecurity" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="89px" 
                                                                Visible="False">Social Security:</asp:Label></td>
                                                        <td style="width: 186px;" align="left">
                                                             <MaskedInput:MaskedTextBox ID="txtSocialSecurity" runat="server" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsCurrency="False" IsDate="False"
                                                                IsZipCode="False" Mask="999-99-9999" TabIndex="13" Width="84px" 
                                                                Visible="False"></MaskedInput:MaskedTextBox></td>
                                                        <td style="width: 15%;" align="left">
                                                             <asp:Label ID="Label5" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="40px">E-mail:</asp:Label></td>
                                                        <td colspan="1" style="width: 331px;" align="left">
                                                            <asp:TextBox ID="txtEmail" runat="server" Height="12px" Width="312px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="22"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 16px">
                                                        </td>
                                                        <td align="left" style="width: 19%; height: 16px">
                                                            <asp:Label ID="lblHouseIncome" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="17px" Width="56px">Gender:</asp:Label></td>
                                                        <td align="left" style="width: 186px; height: 16px">
                                                            <asp:RadioButtonList ID="rdoGender" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                Height="1px" RepeatDirection="Horizontal" Width="80px" TabIndex="14">
                                                                <asp:ListItem>Female</asp:ListItem>
                                                                <asp:ListItem>Male</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                        <td align="left" style="width: 15%; height: 16px">
                                                            <asp:Label ID="Label61" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="10pt" ForeColor="Red" Height="2px" Width="1px">*</asp:Label>
                                                            <asp:Label ID="Label8" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="76px">Cell Phone:</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 331px; height: 16px">
                                                            <MaskedInput:MaskedTextBox ID="txtHomePhone" runat="server" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="12px" IsCurrency="False" IsDate="False"
                                                                IsZipCode="False" Mask="(999) 999-9999" TabIndex="23" Width="100px" MaxLength="14"></MaskedInput:MaskedTextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 16px">
                                                        </td>
                                                        <td align="left" style="width: 19%; height: 16px">
                                                        </td>
                                                        <td align="left" style="width: 186px; height: 16px">
                                                        </td>
                                                        <td align="left" style="width: 15%; height: 16px">
                                                            <asp:Label ID="Label151" runat="server" CssClass="headfield1" 
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="17px" Width="40px">License:</asp:Label></td>
                                                        <td align="left" colspan="1" style="width: 331px; height: 16px">
                                                            <asp:TextBox ID="txtLicense" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="12px" MaxLength="25" TabIndex="15" Width="138px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 16px">
                                                        </td>
                                                        <td align="left" style="width: 19%; height: 16px">
                                                            <asp:Label ID="Label48" runat="server" CssClass="headfield1" Font-Names="Tahoma"
                                                                Font-Size="9pt" Height="17px" Width="56px">Comments:</asp:Label></td>
                                                        <td align="left" colspan="3" style="width: 600px; height: 16px">
                                                            <asp:TextBox ID="txtComments" runat="server" Font-Names="Tahoma" Font-Size="9pt" Height="48px"
                                                                TabIndex="22" TextMode="MultiLine" Width="508px"></asp:TextBox></td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td background="Images2/Barra3.jpg" colspan="5" style="width: 8px; height: 4px">
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="1" style="font-size: 5pt; " valign="top" 
                                    class="style6">
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 0pt; " class="style7">
                                    <table id="Table3" border="0" cellpadding="1" cellspacing="1" style="width: 814px;
                                        height: 76px" width="814">
                                        <tr>
                                            <td align="left" style="font-size: 1pt; height: 258px;" valign="top">
                                                <table id="Table4" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td colspan="1" style="width: 211px">
                                                            <asp:Label ID="lblTypeAddress1" runat="server" CssClass="headform3" Font-Bold="True"
                                                                Font-Names="Tahoma" Font-Size="9pt" Width="155px">II. INSURANCE HISTORY</asp:Label></td><td style="width: 206px">
                                                                </td>
                                                        <td style="width: 154px">
                                                        </td>
                                                        <td style="width: 321px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 700px; height: 14px;">
                                                            <asp:Label ID="Label15" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="636px">2. Please provide the necessary information below with respect to your primary insurance coverage for</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 720px; height: 14px;">
                                                            <asp:Label ID="Label17" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="636px">the last three years, including the coverage in force as of the date of this application.</asp:Label>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7" style="font-size: 5pt; width: 400px; height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 211px" colspan="" bordercolor="silver">
                                                            <asp:Label ID="Label18" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Previous 
                                                            Carrier Name</asp:Label></td>
                                                        <td align="center" style="width: 206px" bordercolor="silver">
                                                            <asp:Label ID="Label14" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px">Policy Effective Dates</asp:Label></td>
                                                        <td align="center" style="width: 154px" bordercolor="silver">
                                                            <asp:Label ID="Label19" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px">Policy Limits</asp:Label></td>
                                                        <td align="center" style="width: 321px" bordercolor="silver">
                                                            <asp:Label ID="Label20" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px">Policy No. Other Company</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 211px" colspan="" bordercolor="silver">
                                                            <asp:TextBox ID="txtPriCarierName1" runat="server" Height="12px" Width="152px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="75" TabIndex="24"></asp:TextBox></td>
                                                        <td align="center" style="width: 206px" bordercolor="silver">
                                                            <asp:TextBox ID="txtPriPolEffecDate1" runat="server" onclick="ShowDateTimePicker();" Height="12px" Width="92px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="25"></asp:TextBox>
                                                            </td>
                                                        <td align="center" style="width: 154px" bordercolor="silver">
                                                             <asp:TextBox ID="txtPriPolLimits1" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="50" TabIndex="26"></asp:TextBox></td>
                                                        <td align="center" style="width: 321px" bordercolor="silver">
                                                            <asp:TextBox ID="txtPriClaims1" runat="server" Height="12px" Width="196px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="50" TabIndex="27"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 211px; height: 22px;">
                                                            <asp:TextBox ID="txtPriCarierName2" runat="server" Height="12px" Width="152px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="75" TabIndex="28"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px;">
                                                            <MaskedInput:MaskedTextBox ID="txtPriPolEffecDate2" runat="server" onclick="ShowDateTimePicker2();" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px" IsDate="True" TabIndex="29"
                                                                Width="92px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 22px;">
                                                            <asp:TextBox ID="txtPriPolLimits2" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="50" TabIndex="30"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 22px;">
                                                            <asp:TextBox ID="txtPriClaims2" runat="server" Height="12px" Width="196px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="50" TabIndex="31"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 211px; height: 22px">
                                                            <asp:TextBox ID="txtPriCarierName3" runat="server" Height="12px" Width="152px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="75" TabIndex="32"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px">
                                                            <MaskedInput:MaskedTextBox ID="txtPriPolEffecDate3" runat="server" onclick="ShowDateTimePicker3();" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px" IsDate="True" TabIndex="33"
                                                                Width="92px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 22px">
                                                            <asp:TextBox ID="txtPriPolLimits3" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="50" TabIndex="34"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 22px">
                                                            <asp:TextBox ID="txtPriClaims3" runat="server" Height="12px" Width="196px" Font-Names="Tahoma" Font-Size="9pt" MaxLength="50" TabIndex="35"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                                <table id="Table7" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 8px">
                                                    <tr>
                                                        <%--<td align="left" background="Images2/Barra3.jpg" colspan="5" style="width: 760px;
                                                            height: 3px">
                                                            <br />
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 760px">
                                                            <asp:Label ID="Label28" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="636px" Visible="False">3. Please provide the necessary information below with respect to your excess professional liability</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="5" style="width: 760px">
                                                             <asp:Label ID="Label29" runat="server" CssClass="headform3" Font-Bold="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Width="632px" Visible="False">insurance coverage for the last three years, including the coverage in force as of the date of this application.</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7" style="font-size: 5pt; width: 400px; height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 211px" colspan="1" bordercolor="silver">
                                                            <asp:Label ID="Label31" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px" Visible="False">Excess Carrier Name</asp:Label></td>
                                                        <td align="center" style="width: 206px" bordercolor="silver">
                                                            <asp:Label ID="Label32" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px" Visible="False">Policy Effective Dates</asp:Label></td>
                                                        <td align="center" style="width: 154px" bordercolor="silver">
                                                            <asp:Label ID="Label33" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px" Visible="False">Policy Limits</asp:Label></td>
                                                        <td align="center" style="width: 321px" bordercolor="silver">
                                                            <asp:Label ID="Label34" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px" Visible="False">Claims-Made Form or Occurrence Form</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 211px" colspan="1" bordercolor="silver">
                                                            <asp:TextBox ID="txtExcCarierName1" runat="server" Height="12px" Width="152px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="36" Visible="False"></asp:TextBox></td>
                                                        <td align="center" style="width: 206px" bordercolor="silver">
                                                                  
                                                            <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate1" runat="server" onclick = "ShowDateTimePicker4();" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px" IsDate="True" TabIndex="37"
                                                                Width="92px" Visible="False"></MaskedInput:MaskedTextBox></td>
                                                        <td align="center" style="width: 154px" bordercolor="silver">
                                                             <asp:TextBox ID="txtExcPolLimits1" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="38" Visible="False"></asp:TextBox></td>
                                                        <td align="center" style="width: 321px" bordercolor="silver">
                                                            <asp:TextBox ID="txtExcClaims1" runat="server" Height="12px" Width="196px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="39" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 211px; height: 22px">
                                                            <asp:TextBox ID="txtExcCarierName2" runat="server" Height="12px" Width="152px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="40" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 22px">
                                                                  <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate2" runat="server" onclick="ShowDateTimePicker5();"
                                                                CssClass="headfield1" Font-Names="Tahoma" Font-Size="9pt" Height="14px" IsDate="True"
                                                                TabIndex="41" Width="92px" Visible="False"></MaskedInput:MaskedTextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 22px">
                                                            <asp:TextBox ID="txtExcPolLimits2" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="42" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 22px">
                                                            <asp:TextBox ID="txtExcClaims2" runat="server" Height="12px" Width="196px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="43" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bordercolor="silver" colspan="1" style="width: 211px; height: 21px;">
                                                            <asp:TextBox ID="txtExcCarierName3" runat="server" Height="12px" Width="152px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="44" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 21px;">
                                                                 
                                                            <MaskedInput:MaskedTextBox ID="txtExcPolEffecDate3" runat="server" onclick="ShowDateTimePicker6();" CssClass="headfield1"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="14px" IsDate="True" TabIndex="45"
                                                                Width="92px" Visible="False"></MaskedInput:MaskedTextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 21px;">
                                                            <asp:TextBox ID="txtExcPolLimits3" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="46" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 21px;">
                                                            <asp:TextBox ID="txtExcClaims3" runat="server" Height="12px" Width="196px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="47" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                                 
                                                <table id="Table5" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <%--<td align="left" background="Images2/Barra3.jpg" colspan="2" style="width: 606px;
                                                            height: 3px">
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" style="width: 606px; height: 42px;" align="left">
                                                            <asp:Label ID="Label16" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="612px" Visible="False">4. Has any insurance company (including Lloyd's of London) ever cancelled, declines to issued,</asp:Label>
                                                                <asp:Label ID="Label23" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="612px" Visible="False">refused to renew, surcharged your premium or issued coverage with any restrictions or exclusions?</asp:Label>         
                                                            <asp:Label ID="Label24" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="368px" Visible="False">If Yes, please explain fully in the below  Section.</asp:Label>
                                                                </td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 42px;">
                                                            <asp:RadioButtonList ID="rdoMcaInsuranceCia" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="48" Visible="False">
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                                <asp:ListItem>No</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="1" style="width: 606px; height: 42px">
                                                            <asp:TextBox ID="txtInsuranceCiaDesc" runat="server" Height="28px" TextMode="MultiLine"
                                                                Width="532px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="49" Visible="False"></asp:TextBox></td>
                                                        <td align="left" colspan="1" style="width: 429px; height: 42px">
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="center" style="width: 121px; height: 3px;" colspan="2" background="Images2/Barra3.jpg">
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                                 
                                                <table id="Table2" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                                    <tr>
                                                        <td colspan="3" style="width: 211px; height: 18px;">
                                                             <asp:Label ID="Label37" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px"></asp:Label></td>
                                                        <td style="width: 154px; height: 18px;">
                                                        </td>
                                                        <td style="width: 321px; height: 18px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="width: 320px">
                                                            <asp:Label ID="Label9" runat="server" CssClass="headform3" Font-Bold="True" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="296px" Visible="False">III. MEDICAL EDUCATION AND TRAINING</asp:Label></td>
                                                        <td style="width: 154px">
                                                        </td>
                                                        <td style="width: 321px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="6" style="width: 700px; height: 14px;">
                                                            <asp:Label ID="Label10" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                                Font-Size="9pt" Width="636px" Visible="False">3. Education</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8" style="font-size: 5pt; width: 400px; height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width: 162px" colspan="" bordercolor="silver">
                                                        </td>
                                                        <td align="center" style="width: 206px" bordercolor="silver">
                                                            <asp:Label ID="Label13" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="144px" Visible="False">School/Hospital</asp:Label></td>
                                                        <td align="center" style="width: 154px" bordercolor="silver">
                                                            <asp:Label ID="Label22" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px" Visible="False">City/State/Country</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:Label ID="Label26" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="87px" Visible="False">From/To</asp:Label></td>
                                                        <td align="center" style="width: 321px" bordercolor="silver">
                                                            <asp:Label ID="Label25" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="164px" Visible="False">Degree/Type</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 162px; height: 20px;" colspan="" bordercolor="silver">
                                                              
                                                            <asp:Label ID="Label12" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="88px" Visible="False">Medical School</asp:Label></td>
                                                        <td align="center" style="width: 206px; height: 20px;" bordercolor="silver">
                                                            <asp:TextBox ID="txtMedSchool" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="50" Visible="False"></asp:TextBox></td>
                                                        <td align="center" style="width: 154px; height: 20px;" bordercolor="silver">
                                                             <asp:TextBox ID="txtMedCity" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="51" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px;">
                                                            <asp:TextBox ID="txtMedFrom" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="52" Visible="False"></asp:TextBox></td>
                                                        <td align="center" style="width: 321px; height: 20px;" bordercolor="silver">
                                                            <asp:TextBox ID="txtMedDegree" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="53" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 162px">
                                                              
                                                            <asp:Label ID="Label27" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="88px" Visible="False">Internship</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                            <asp:TextBox ID="txtIntSchool" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="54" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:TextBox ID="txtIntCity" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="55" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:TextBox ID="txtIntFrom" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="56" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtIntDegree" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="57" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 162px; height: 20px">
                                                              
                                                            <asp:Label ID="Label30" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="88px" Visible="False">Residency</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px">
                                                            <asp:TextBox ID="txtResSchool" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="58" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px">
                                                            <asp:TextBox ID="txtResCity" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="59" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px">
                                                            <asp:TextBox ID="txtResFrom" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="60" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 20px">
                                                            <asp:TextBox ID="txtResDegree" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="61" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 162px; height: 20px;">
                                                              
                                                            <asp:Label ID="Label35" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="88px" Visible="False">Fellowship</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px; height: 20px;">
                                                            <asp:TextBox ID="txtFellSchool" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="62" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px;">
                                                            <asp:TextBox ID="txtFellCity" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="63" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px; height: 20px;">
                                                            <asp:TextBox ID="txtFellFrom" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="64" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px; height: 20px;">
                                                            <asp:TextBox ID="txtFellDegree" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="65" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" bordercolor="silver" colspan="1" style="width: 162px">
                                                              
                                                            <asp:Label ID="Label36" runat="server" CssClass="headfield1" EnableViewState="False"
                                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" Width="88px" Visible="False">Other Training</asp:Label></td>
                                                        <td align="center" bordercolor="silver" style="width: 206px">
                                                            <asp:TextBox ID="txtOSchool" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="66" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:TextBox ID="txtOCity" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="67" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 154px">
                                                            <asp:TextBox ID="txtOFrom" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="68" Visible="False"></asp:TextBox></td>
                                                        <td align="center" bordercolor="silver" style="width: 321px">
                                                            <asp:TextBox ID="txtODegree" runat="server" Height="12px" Width="120px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="69" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                        <asp:HiddenField ID="hdfPrimaryLimit" runat="server" />
                                        <asp:HiddenField ID="hdfLimit" runat="server" />                                        
                                    </table><table id="Table12" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                        <tr>
                                            <%--<td align="left" background="Images2/Barra3.jpg" colspan="2" style="width: 606px;
                                                            height: 3px">
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="width: 606px; height: 42px;" align="left">
                                                <asp:Label ID="Label11" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="612px" Visible="False">6. If you are a graduate of a non-U.S. medical school, are you certified by the Educational</asp:Label>
                                                    <asp:Label ID="Label38" runat="server" CssClass="headform3" Font-Bold="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Width="612px" Visible="False">Commission for Foreign Medical School Graduates?</asp:Label>               </td>
                                            <td align="left" colspan="1" style="width: 429px; height: 42px;">
                                                <asp:RadioButtonList ID="rdoMcaCertified" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="70" Visible="False">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <%--<td align="center" style="width: 121px; height: 3px;" colspan="2" background="Images2/Barra3.jpg">
                                            </td>--%>
                                        </tr>
                                    </table>
                                    <table id="Table13" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px;
                                                            height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="width: 606px; height: 42px;" align="left">
                                                <asp:Label ID="Label39" runat="server" CssClass="headform3" Font-Bold="False" Font-Names="Tahoma"
                                                    Font-Size="9pt" Width="612px" Visible="False">7. Did you complete residency training?</asp:Label>
                                                    <asp:Label ID="Label40" runat="server" CssClass="headform3" Font-Bold="False"
                                                    Font-Names="Tahoma" Font-Size="9pt" Width="612px" Visible="False">If "No", please explain in Remarks Section.</asp:Label>               </td>
                                            <td align="left" colspan="1" style="width: 429px; height: 42px;">
                                                <asp:RadioButtonList ID="rdoMcaResTraining" runat="server" Font-Names="Tahoma" Font-Size="9pt"
                                                                RepeatDirection="Horizontal" Width="80px" TabIndex="71" Visible="False">
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="1" style="width: 606px; height: 42px">
                                                <asp:TextBox ID="txtResidency" runat="server" Height="28px" TextMode="MultiLine" Width="532px" Font-Names="Tahoma" Font-Size="9pt" TabIndex="72" Visible="False"></asp:TextBox></td>
                                            <td align="left" colspan="1" style="width: 429px; height: 42px">
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td align="center" style="width: 121px; height: 3px;" colspan="2" background="Images2/Barra3.jpg">
                                            </td>
                                        </tr>--%>
                                    </table>
                                    <table id="Table14" border="0" cellpadding="0" cellspacing="0" style="width: 808px;
                                                    height: 1px">
                                        <tr>
                                            <td align="left" colspan="2" style="width: 606px;
                                                            height: 3px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="width: 606px; height: 7px;" align="left">
                                                                     </td>
                                            <td align="right" colspan="1" style="width: 429px; height: 7px;">
                                                 
                                                <asp:Button ID="btnNextBottom" runat="server" BackColor="#400000" BorderColor="#400000"
                                                    BorderWidth="0px" Font-Names="Tahoma" ForeColor="White" Height="23px"
                                                    Text="Next >" Width="54px" OnClick="btnNextBottom_Click" TabIndex="73" Visible="False" />
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td align="center" style="width: 121px; height: 3px;" colspan="2" background="Images2/Barra3.jpg">
                                            </td>--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    
                    
               
                    <p><input id="HIState" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 912px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
                         </p>
                    <p>
                         </p>
                    <p>
                         </p>
                    <p>
                         </p>
                </td>
            </tr>
        </table>
        </div>
        <maskedinput:maskedtextheader id="MaskedTextHeader1" runat="server"></maskedinput:maskedtextheader>
        <asp:Literal ID="litPopUp" runat="server" Visible="False"></asp:Literal>
        <input id="txtPrateID" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" /><input id="txtPrate2ID" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1468px;
            height: 22px" type="hidden" value="0" />
        <input id="txtPrate3ID" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="txtPrate4ID" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="txtPrate5ID" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="txtPrate6ID" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 432px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" />
        <input id="ConfirmDialogBoxPopUp" runat="server" name="ConfirmDialogBoxPopUp" size="1"
            style="z-index: 102; left: 856px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="false" /><input id="HIIsoCode" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" /><input id="HIIsoCode2" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1468px;
            height: 22px" type="hidden" value="0" />
        <input id="HIIsoCode3" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="HIIsoCode4" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="HIIsoCode5" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="HIIsoCode6" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 476px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" />
        <input id="HIClass" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 532px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
        <input id="HIClass2" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 532px; width: 35px; position: absolute; top: 1468px;
            height: 22px" type="hidden" value="0" />
        <input id="HIClass3" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="HIClass4" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="HIClass5" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="HIClass6" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 528px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" />
         <input id="HIRate1" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate12" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1468px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate13" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate14" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate15" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate16" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 588px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate2" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate22" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1468px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate23" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate24" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate25" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate26" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 640px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate3" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate32" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1468px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate33" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate34" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate35" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate36" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 692px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate4" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1432px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate42" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1464px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate43" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1500px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate44" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1528px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate45" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1560px;
            height: 22px" type="hidden" value="0" />
        <input id="HIRate46" runat="server" name="txtPrateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1592px;
            height: 22px" type="hidden" value="0" /><input id="HIPrimeryRateID" runat="server" name="HIPrimeryRateID" size="1"
            style="z-index: 102; left: 740px; width: 35px; position: absolute; top: 1626px;
            height: 22px" type="hidden" value="0" />
        <input id="HIrimeryRate4" runat="server" name="HIrimeryRate4" size="1"
            style="z-index: 102; left: 694px; width: 35px; position: absolute; top: 1626px;
            height: 22px" type="hidden" value="0" />
        <input id="HIrimeryRate3" runat="server" name="HIrimeryRate3" size="1"
            style="z-index: 102; left: 647px; width: 35px; position: absolute; top: 1626px;
            height: 22px" type="hidden" value="0" />
        <input id="HIrimeryRate2" runat="server" name="HIrimeryRate2" size="1"
            style="z-index: 102; left: 594px; width: 35px; position: absolute; top: 1626px;
            height: 22px" type="hidden" value="0" />
        <input id="HIrimeryRate1" runat="server" name="HIrimeryRate1" size="1"
            style="z-index: 102; left: 544px; width: 35px; position: absolute; top: 1626px;
            height: 22px" type="hidden" value="0" />
    </form>
    </div>
</body>
</html>


<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Page language="c#" Inherits="EPolicy.AHCRegistry" CodeFile="AHCRegistry.aspx.cs" %>
<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>
		<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
		<script>
		    $(function() {
		        $('#<%= txtLicenseExoDptoDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });

		        $('#<%= txtGraduationCertificate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });

		        $('#<%= txtColCertificateDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });

		        $('#<%= txtGradeCopyDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });

		        $('#<%= txtTecLicenseDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });

		        $('#<%= txtLicenseExpDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		           $('#<%= txtDptoLicenseDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		          $('#<%= txtGradeCopyDate2.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		             $('#<%= txtAudioLicenseDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		              $('#<%= txtJuntaCertificateDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		           $('#<%= txtGradeCopyDate3.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
                  $('#<%= txtDegreeDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		         $('#<%= txtRegisterCertificateDate3.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		          
		         $('#<%= txtNutriLicenseDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		             $('#<%= txtGradeCopyDate4.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		           $('#<%= txtNutriCertificateDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		             $('#<%= txtCredentialsDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		          $('#<%= txtRegisterCertificateDate4.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		        
		        
		        $('#<%= txtPriPolEffecDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        $('#<%= txtMDSGradDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        $('#<%= txtInternGradDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        $('#<%= txtResidencyGradDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		         $('#<%= txtFelloshipGradDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
		        $('#<%= txtRegisterCertificateDate.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		         $('#<%= txtRegisterCertificateDate2.ClientID %>').datepicker({
		            changeMonth: true,
		            changeYear: true
		        });
		        
	             $('#<%= txtCertificateCopyDate.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });
	        
	        	   $('#<%= txtPsicoLicenseDate.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });
	                
	        
	        
	        	   $('#<%= txtPsicoLicenseDate.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });
		         $('#<%= txtOptoDate.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });
	        
	          $('#<%= txtPermanentDate.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });
	        
	        
	          $('#<%= txtCredentialsDate2.ClientID %>').datepicker({
	            changeMonth: true,
	            changeYear: true
	        });    
		  });

		    function ShowDateTimePicker() {
		        $('#<%= txtLicenseExoDptoDate.ClientID %>').datepicker('show');
		    }

		    function ShowDateTimePicker2() {
		        $('#<%= txtGraduationCertificate.ClientID %>').datepicker('show');
		    }

		    function ShowDateTimePicker3() {
		        $('#<%= txtColCertificateDate.ClientID %>').datepicker('show');
		    }

		    function ShowDateTimePicker4() {
		        $('#<%= txtGradeCopyDate.ClientID %>').datepicker('show');
		    }

		    function ShowDateTimePicker5() {
		        $('#<%= txtTecLicenseDate.ClientID %>').datepicker('show');
		    }

		    function ShowDateTimePicker6() {
		        $('#<%= txtLicenseExpDate.ClientID %>').datepicker('show');
            }
	        function ShowDateTimePicker7() {
	            $('#<%= txtPriPolEffecDate.ClientID %>').datepicker('show');
	        }
	        function ShowDateTimePicker8() {
		        $('#<%= txtInternGradDate.ClientID %>').datepicker('show');
		    }
		     function ShowDateTimePicker9() {
		        $('#<%= txtResidencyGradDate.ClientID %>').datepicker('show');
		    }
		    function ShowDateTimePicker10() {
		        $('#<%= txtColCertificateDate.ClientID %>').datepicker('show');
		    }

		    function ShowDateTimePicker11() {
		        $('#<%= txtMDSGradDate.ClientID %>').datepicker('show');
		    }
		    function ShowDateTimePicker12() {
		        $('#<%= txtFelloshipGradDate.ClientID %>').datepicker('show');
		    }
		    
		    function ShowDateTimePicker13() {
		        $('#<%= txtRegisterCertificateDate.ClientID %>').datepicker('show');
		    }
		     function ShowDateTimePicker14() {
		        $('#<%= txtRegisterCertificateDate2.ClientID %>').datepicker('show');
		    }
		    
		    function ShowDateTimePicker15() {
		        $('#<%= txtDptoLicenseDate.ClientID %>').datepicker('show');
		        }
       
            function ShowDateTimePicker16() {
                $('#<%= txtGradeCopyDate2.ClientID %>').datepicker('show'); 
                }
		        
            function ShowDateTimePicker17() {
                $('#<%= txtAudioLicenseDate.ClientID %>').datepicker('show'); 
		    }
		    
		    function ShowDateTimePicker18() {
                $('#<%= txtJuntaCertificateDate.ClientID %>').datepicker('show'); 
		    }
		    
            function ShowDateTimePicker19() {
               $('#<%= txtGradeCopyDate3.ClientID %>').datepicker('show'); 
               }
          
            function ShowDateTimePicker20() {
               $('#<%= txtDegreeDate.ClientID %>').datepicker('show'); 
               }
          
           function ShowDateTimePicker21() {
          $('#<%= txtRegisterCertificateDate3.ClientID %>').datepicker('show'); 
          }
          
        function ShowDateTimePicker22() {
          $('#<%= txtNutriLicenseDate.ClientID %>').datepicker('show');  
             }      
          
      function ShowDateTimePicker23() {
          $('#<%= txtGradeCopyDate4.ClientID %>').datepicker('show');
          }
          
       function ShowDateTimePicker24() {
      $('#<%= txtNutriCertificateDate.ClientID %>').datepicker('show'); 
      }
           
            function ShowDateTimePicker25() {
      $('#<%= txtCertificateCopyDate.ClientID %>').datepicker('show');   
      }
      
         function ShowDateTimePicker26() {
      $('#<%= txtRegisterCertificateDate4.ClientID %>').datepicker('show');   
      }
      
               function ShowDateTimePicker27() {
      $('#<%= txtPsicoLicenseDate.ClientID %>').datepicker('show'); 
      }  
      
                function ShowDateTimePicker28() {
      $('#<%= txtGradeCopyDate5.ClientID %>').datepicker('show');   
      }
      
      
                function ShowDateTimePicker29() {
      $('#<%= txtCredentialsDate.ClientID %>').datepicker('show'); 
      }
      
                    function ShowDateTimePicker30() {
      $('#<%= txtOptoDate.ClientID %>').datepicker('show');  
      }
      
            function ShowDateTimePicker31() {
      $('#<%= txtPermanentDate.ClientID %>').datepicker('show');
      }
      
        function ShowDateTimePicker32() {
      $('#<%= txtRegisterCertificateDate5.ClientID %>').datepicker('show');
      }
      
        function ShowDateTimePicker33() {
      $('#<%= txtCredentialsDate2.ClientID %>').datepicker('show');
      }
           
		     
		</script>
		
		<style>
		    hr { background-color: black; height: 1px; border: 0; }
		    
		    </style>
	    <style type="text/css">
            .headfield1
            {
                font-family: Tahoma;
                margin-bottom: 0px;
                text-align: left;
            }
            .headForm1
            {
                margin-left: 0px;
                font-size: small;
                margin-right: 15px;
                text-align: left;
            }
            .style3
            {
                height: 4px;
                width: 1485px;
            }
            .style22
        {
            }
	    .style6
        {
            width: 100px;
        }
        .style16
        {
              text-align: left;
            }
            .style23
            {
                width: 100px;
                height: 22px;
            }
            .style24
            {
                width: 593px;
                height: 22px;
            }
            .style32
            {
                width: 111px;
                height: 22px;
                font-size: small;
                text-align: left;
            }
            .style34
            {
                text-align: left;
            }
            .style37
            {
                text-align: left;
            }
            .style38
            {
                height: 11px;
                text-align: left;
            }
            .style39
            {
                font-weight: bold;
                text-align: left;
            }
            .style41
            {
                text-align: left;
                height: 11px;
                width: 161px;
            }
            .style43
            {
                text-align: left;
                width: 161px;
            }
            .style47
            {
                height: 22px;
                text-align: left;
            }
            .style53
            {
                text-align: left;
            }
            .style54
            {
                width: 89px;
                text-align: center;
            }
            .style55
            {
                width: 89px;
                text-align: left;
                height: 22px;
            }
            .style57
            {
                text-align: left;
                height: 11px;
                width: 89px;
            }
            .style59
            {
                text-align: left;
                width: 89px;
            }
            .style60
            {
                height: 22px;
                text-align: left;
            }
            .style68
            {
                height: 16px;
                text-align: left;
            }
            .style73
            {
                height: 11px;
                font-size: small;
                text-align: left;
                }
            .style74
            {
                width: 111px;
            }
            .style76
            {
                width: 111px;
                text-align: left;
                height: 16px;
            }
            .style77
            {
                text-align: left;
                }
            .style85
            {
                width: 89px;
                text-align: left;
                height: 2px;
            }
            .style86
            {
                width: 161px;
                text-align: left;
                height: 2px;
            }
            .style88
            {
                text-align: left;
                height: 2px;
            }
            .style92
            {
                font-size: small;
                text-align: left;
            }
            .style93
            {
                text-align: left;
                width: 89px;
                height: 16px;
            }
            .style94
            {
                text-align: left;
                width: 161px;
                height: 16px;
            }
            .style97
            {
                height: 216px;
            }
            .style98
            {
                height: 22px;
                font-size: small;
                text-align: left;
            }
            .style100
            {
                text-align: left;
                width: 161px;
                height: 22px;
            }
            .style102
            {
                width: 235px;
            }
            .style103
            {
                text-align: left;
                width: 235px;
            }
            .style104
            {
                width: 235px;
                text-align: left;
                height: 2px;
            }
            .style105
            {
                text-align: left;
                height: 11px;
                width: 235px;
            }
            .style106
            {
                width: 235px;
                text-align: left;
                height: 22px;
            }
            .style107
            {
                text-align: left;
                width: 235px;
                height: 16px;
            }
            .style108
            {
                width: 106px;
            }
            .style109
            {
                text-align: left;
                width: 106px;
            }
            .style110
            {
                text-align: left;
                height: 2px;
                width: 106px;
            }
            .style111
            {
                height: 11px;
                text-align: left;
                width: 106px;
            }
            .style112
            {
                height: 22px;
                text-align: left;
                width: 106px;
            }
            .style113
            {
                height: 16px;
                text-align: left;
                width: 106px;
            }
            .style114
            {
                text-align: left;
                width: 144px;
            }
            .style115
            {
                font-size: small;
                text-align: left;
                width: 144px;
            }
            .style116
            {
                height: 11px;
                font-size: small;
                text-align: left;
                width: 144px;
            }
            .style117
            {
                height: 22px;
                font-size: small;
                text-align: left;
                width: 144px;
            }
            .style118
            {
                width: 144px;
            }
            .style119
            {
                height: 16px;
                text-align: left;
                width: 144px;
            }
            .style120
            {
                width: 89px;
                text-align: left;
                height: 36px;
            }
            .style121
            {
                text-align: left;
                height: 36px;
            }
            .style122
            {
                text-align: left;
                width: 235px;
                height: 36px;
            }
            .style123
            {
                text-align: left;
                width: 106px;
                height: 36px;
            }
            .style124
            {
                text-align: left;
                width: 144px;
                height: 36px;
            }
            </style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF"
		topMargin="19" rightMargin="0">
		<form id="form1" runat="server">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 762px; HEIGHT: 369px" cellSpacing="0" 
                                cellPadding="0" bgColor="white" border="0" align="center">
								<TR>
									<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						            <P><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                                    </P>
					            </TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; text-align: left;" align="center" class="style22" 
                                        rowspan="6" valign="top">
						                <P align="center"><asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder></P>
									            </TD>
									<TD style="FONT-SIZE: 0pt; text-align: left;" align="center" class="style22">
													<asp:Label id="Label8" runat="server" Height="16px" Width="160px" 
                                                        CssClass="headForm1 " ForeColor="Black"
														Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True">Documents Registry</asp:Label>
																<asp:Label id="lblPolicyNo" runat="server" 
                                            Font-Size="11pt" Width="235px" ForeColor="Red" Font-Names="Tahoma" 
                                            style="text-align: left">Name:</asp:Label>
									            </TD>
									<TD style="FONT-SIZE: 0pt; text-align: right;" align="center" class="style22" 
                                        valign="bottom">
													<asp:button id="btnHistory" tabIndex="5" runat="server" Height="23px" 
                                                        Width="64px" Text="History"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" onclick="btnHistory_Click" style="margin-bottom: 0px; margin-right: 1px;"></asp:button>
													<asp:button id="btnPrint" tabIndex="5" runat="server" Height="23px" 
                                                        Width="50px" Text="Print"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" onclick="btnPrint_Click" style="margin-bottom: 0px; margin-right: 1px;" Visible="False"></asp:button>
													<asp:button id="btnEdit" tabIndex="5" runat="server" Height="23px" 
                                                        Width="64px" Text="Edit"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" onclick="btnEdit_Click" style="margin-bottom: 0px; margin-right: 1px;"></asp:button>
													<asp:button id="btnSave" tabIndex="5" runat="server" Height="23px" 
                                                        Width="64px" Text="Save"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" onclick="btnSave_Click" style="margin-bottom: 0px; margin-right: 1px;"></asp:button>
													<asp:button id="btnCancel" tabIndex="5" runat="server" Height="23px" 
                                                        Width="64px" Text="Cancel"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" onclick="btnCancel_Click" style="margin-bottom: 0px; margin-right: 1px;"></asp:button>
													<asp:button id="BtnExit" tabIndex="5" runat="server" Height="23px" 
                                                        Width="64px" Text="Exit"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" onclick="BtnExit_Click" style="margin-bottom: 0px; margin-right: 1px;"></asp:button>
									            </TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px; text-align: left;" colspan="2">
										<TABLE id="Table11" style="WIDTH: 807px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD background="Images2/Barra3.jpg" align="center" style="text-align: center"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD vAlign="left" align="left" class="style3" colspan="2">
									
									  <table>
									        <tr>
									            <td>
									            </td>
									        <td>
                                                    <asp:Label ID="LblDate23" RUNAT="server" CSSCLASS="style39" Font-Names="Tahoma" Font-Size="9pt" HEIGHT="22px" WIDTH="150px">Medical Practice Type:</asp:Label>									            
									        
									        <asp:CheckBoxList ID="chkMedicalPractice" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="chkMedicalPractice_SelectedIndexChanged" 
                                                style="font-size: 10pt; font-family: Tahoma" Width="288px">
                                                <asp:ListItem>Enfermeras Graduadas</asp:ListItem>
                                                <asp:ListItem>Tecnólogos Médicos</asp:ListItem>
                                                <asp:ListItem>Técnicos de Rayos X </asp:ListItem>
                                                <asp:ListItem>Audiológos y Patólogos del Habla</asp:ListItem>
                                                <asp:ListItem>Nutricionistas y Dietistas</asp:ListItem>
                                                <asp:ListItem>Psicólogos</asp:ListItem>
                                                <asp:ListItem>Optómetras</asp:ListItem>
                                            </asp:CheckBoxList>
				                    </td>
									        </tr>
									        
									        </table>
									<hr />
									<table>
									    <tr>
									        <td>
											    <table>
									            <tr>
									                <td></td>
									                <td>
                                                        <asp:Label ID="LblDate13" RUNAT="server" CSSCLASS="style39"  Font-Names="Tahoma" Font-Size="9pt" HEIGHT="22px" WIDTH="100px">Practice Info:</asp:Label>									            
									                </td>
									                <td>
													    <asp:Label ID="LblDate30" RUNAT="server" CssClass=" " Font-Names="Tahoma" Font-Size="9pt" HEIGHT="22px" style="font-weight: 700" WIDTH="111px">Grad. Date</asp:Label>									            
									                </td>								            									            
									        						            									            
									            </tr>
									            <tr>
									                <td>
                                                        <asp:CheckBox ID="chkMedicalSchool" runat="server" AutoPostBack="True" 
                                                                CssClass=" " oncheckedchanged="RevealControls" Text=" " />
                                                                    <asp:Label ID="LblDate9" RUNAT="server" CSSCLASS="headfield1" 
                                                                Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" WIDTH="90px">Medical 
                                                                    School:</asp:Label>									            
									                </td>
									                <td>
                                                                   <asp:TextBox ID="txtMedicalSchool" runat="server" Columns="30" 
                                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                TabIndex="44" Width="205px"></asp:TextBox>									            
									                </td>
									                <td>
                                                                    <asp:TextBox ID="txtMDSGradDate" runat="server" Columns="30" CssClass=" " 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                        onclick="ShowDateTimePicker11();" TabIndex="44" Width="79px"></asp:TextBox>									            
									                </td>	
    					            									            
									                <td>
                                                                    &nbsp;</td>	
    					            									            
									            </tr>
									            <tr>
									                <td>
									                <asp:CheckBox ID="chkInternship" runat="server" AutoPostBack="True" 
                                                    CssClass=" " oncheckedchanged="RevealControls" Text=" " />
                                                        <asp:Label ID="LblDate10" RUNAT="server" CSSCLASS="headfield1" 
                                                    Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" WIDTH="80px">Internship:</asp:Label>
    									            
									                </td>
									                <td>
									                 <asp:TextBox ID="txtInternship" runat="server" Columns="30" CssClass=" " 
                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" TabIndex="44" 
                                                        Width="205px"></asp:TextBox>
									                </td>
									                <td>
																    <asp:TextBox ID="txtInternGradDate" runat="server" Columns="30" CssClass=" " 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                        onclick="ShowDateTimePicker8();" TabIndex="44" Width="79px"></asp:TextBox>									            
									                </td>	
    									            								            									            
									                <td>
																    &nbsp;</td>	
    									            								            									            
									            </tr>
									          
									            <tr>
									                <td>
                                                                    <asp:CheckBox ID="chkResidency" runat="server" AutoPostBack="True" CssClass=" " 
                                                                        oncheckedchanged="RevealControls" Text=" " />
                                                                    <asp:Label ID="LblDate11" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" WIDTH="80px">Residency:</asp:Label>									            
									                </td>
									                <td>
                                                                    <asp:TextBox ID="txtResidency" runat="server" Columns="30" CssClass=" " 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" TabIndex="44" 
                                                                        Width="205px"></asp:TextBox>									            
									                </td>
									                <td>
                                                                    <asp:TextBox ID="txtResidencyGradDate" runat="server" Columns="30" CssClass=" " 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                        onclick="ShowDateTimePicker9();" TabIndex="44" Width="79px"></asp:TextBox>									            
									                </td>	
    									            								            									            
									                <td>
                                                                    &nbsp;</td>	
    									            								            									            
									            </tr>
									            <tr>
									                <td>
                                                                    <asp:CheckBox ID="chkFellowship" runat="server" AutoPostBack="True" 
                                                                        CssClass=" " oncheckedchanged="RevealControls" Text=" " />
                                                                    <asp:Label ID="LblDate12" RUNAT="server" CSSCLASS="headfield1" 
                                                                        Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" WIDTH="80px">Fellowship:</asp:Label>									            
									                </td>
									                <td>
                                                                    <asp:TextBox ID="txtFellowship" runat="server" Columns="30" 
                                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                TabIndex="44" Width="205px"></asp:TextBox>									            
									                </td>
									                <td>
                                                                    <asp:TextBox ID="txtFelloshipGradDate" runat="server" Columns="30" CssClass=" " 
                                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                        onclick="ShowDateTimePicker12();" TabIndex="44" Width="79px"></asp:TextBox>									            
									                </td>		
    									            							            									            
									                <td>
                                                                    &nbsp;</td>		
    									            							            									            
									            </tr>									        									        
									        </table>			        
									        </td>
									    </tr>
									    <tr>
									        <td>
									      
									        </td>
									    </tr>									    
									</table>
									<hr />
									<table>
									        <tr>
									            <td>
                                                                <asp:Label ID="LblDate" RUNAT="server" CSSCLASS="style39" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="22px" WIDTH="127px">Documents:</asp:Label>									            
									            </td>
									            <td>
																<asp:Label ID="LblDate8" RUNAT="server" CssClass=" " Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="22px" style="font-weight: 700" 
                                                            WIDTH="132px">Expiration 
                                                                Date:</asp:Label>									            
									            </td>
									        </tr>
									       <tr>
									            <td>
                                                                <asp:CheckBox ID="chkLicenseExoDptoDate" runat="server" CssClass=" " Text=" " 
                                                                    AutoPostBack="True" oncheckedchanged="RevealControls" />
                                                                <asp:Label ID="LblDate1" RUNAT="server" CSSCLASS=" " Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="16px" WIDTH="86px" style="text-align: center">Licencia expedida por el Depto. de Salud:</asp:Label>									            
									            </td>
									            <td>
                                                                <asp:TextBox ID="txtLicenseExoDptoDate" runat="server" Columns="30" 
                                                                    CssClass=" " Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" IsDate="True" 
                                                                    onclick="ShowDateTimePicker();" TabIndex="44"
                                                                    Width="79px"></asp:TextBox>									            
									            </td>
									       </tr>
									       
									       <tr>
									       <td>
									                            <asp:CheckBox ID="chkGraduationCertificate" runat="server" CssClass=" " Text=" " 
                                                                    AutoPostBack="True" oncheckedchanged="RevealControls" />
                                                                <asp:Label ID="LblDate5" RUNAT="server" CSSCLASS=" " Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="16px" WIDTH="114px" style="text-align: center">Copia del 
                                                                Certificado de Graduación, Bachillerato y/o Maestría como enfermera:</asp:Label>
									       </td>
									       <td>
									                                 <asp:TextBox ID="txtGraduationCertificate" runat="server" Columns="30" 
                                                                    CssClass=" " Font-Names="Tahoma"
                                                                    Font-Size="9pt" Height="18px" IsDate="True" 
                                                                    onclick="ShowDateTimePicker2();" TabIndex="44"
                                                                    Width="79px"></asp:TextBox>
									       </td>
									       </tr>
									       <tr>
									       <td>  <asp:CheckBox ID="chkRegisterCertificateDate" runat="server" AutoPostBack="True" 
                                                    CssClass=" " oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="LblDate31" RUNAT="server" CSSCLASS=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" HEIGHT="31px" WIDTH="105px" style="text-align: center">Certificado de Registro – Colegio de Tecnólogos Médicos de PR:</asp:Label>
                                            </td>
									       <td>
									       <asp:TextBox ID="txtRegisterCertificateDate" runat="server" Columns="30" CssClass=" " 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" 
                                                                    onclick="ShowDateTimePicker13{};" TabIndex="44" Width="79px"></asp:TextBox>
                                             </td>
									       </tr>
									       
									       <tr>
									       <td>
									                <asp:CheckBox ID="chkGradeCopyDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                        oncheckedchanged="RevealControls" Text=" " />
                                                    <asp:Label ID="LblDate7" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                        Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia de sus grados de estudio:</asp:Label>
									       </td>
									       <td>
                                                        <asp:TextBox ID="txtGradeCopyDate" runat="server" Columns="30" CssClass=" " 
                                                        Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                        onclick="ShowDateTimePicker4();" TabIndex="44" Width="79px"></asp:TextBox>									       
									       </td>
									       </tr>
									       <tr>
									       <td> <asp:CheckBox ID="chkTecLicenseDatte" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="LblDate27" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Licencia como Tecnólogo Médico por el Depto. de Salud de PR:</asp:Label></td>
									      
									       <td> <asp:TextBox ID="txtTecLicenseDate" runat="server" Columns="30" CssClass=" " 
                                                Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker5();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td><asp:CheckBox ID="chkColCertificateDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="LblJDL" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificación 
                                                y Colegiación del Colegio de Tecnólogos Médicos de PR :</asp:Label></td>
									       <td> <asp:TextBox ID="txtColCertificateDate" runat="server" Columns="30" CssClass=" " 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                    onclick="ShowDateTimePicker10();" TabIndex="44" Visible="true" 
                                                                    Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td><asp:CheckBox ID="chkRegisterCertificateDate2" runat="server" 
                                                AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="LblCannabis" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificado de Registro </asp:Label></td>
									       <td> 
									         <asp:TextBox ID="txtRegisterCertificateDate2" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker14();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       <tr>
									       <td><asp:CheckBox ID="chkDegreeDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label6" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia grado Bachillerato, Maestría y/o Doctorado en 
                                             patología del habla-lenguaje o en audiología:</asp:Label></td>
							       <td>        <asp:TextBox ID="txtDegreeDate" runat="server" Columns="30" 
                                                    CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                    onclick="ShowDateTimePicker20();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td>  <asp:CheckBox ID="chkDptoLicenseDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label1" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Licencia Depto. de Salud de PR:</asp:Label></td>
									       
									       <td> <asp:TextBox ID="txtDptoLicenseDate" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker15();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td>  <asp:CheckBox ID="chkGradeCopyDate2" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label2" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                 Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia de sus grados de estudio:</asp:Label></td>
                                                 
									       <td> <asp:TextBox ID="txtGradeCopyDate2" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker16();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td> <asp:CheckBox ID="chkAudioLicenseDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label3" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Licencia como Audiólogo Depto. de Salud de PR :</asp:Label></td>
                                                    
									       <td> <asp:TextBox ID="txtAudioLicenseDate" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker17();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td> <asp:CheckBox ID="chkJuntaCertificateDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label4" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificación por Junta Examinadora de Patólogos del Habla-Lenguaje, Audiólogos y Terapistas:</asp:Label></td>
									       <td>
                                                            <asp:TextBox ID="txtJuntaCertificateDate" runat="server" Columns="30" 
                                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                            onclick="ShowDateTimePicker18();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       <tr>
									       <td><asp:CheckBox ID="chkGradeCopyDate3" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label5" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia de sus grados de estudio:</asp:Label></td>
                                                
									       <td> <asp:TextBox ID="txtGradeCopyDate3" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker19();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td> <asp:CheckBox ID="chkRegisterCertificateDate3" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label7" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificado de Registro - Junta Examinadora de 
                                                 Dietistas de PR):</asp:Label></td>
									       
									       <td>
					                            <asp:TextBox ID="txtRegisterCertificateDate3" runat="server" Columns="30" 
                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                            onclick="ShowDateTimePicker21();" TabIndex="44" Width="79px"></asp:TextBox>					       
									       </td>
									       </tr>
									       <tr>
									       <td>
									         <asp:CheckBox ID="chkNutriLicenseDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label10" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Licencia como Nutricionista y/o Dietista por el Depto. de Salud de PR:</asp:Label>
									       </td>
									       
									       
									       <td>     <asp:TextBox ID="txtNutriLicenseDate" runat="server" Columns="30" 
                                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                            onclick="ShowDateTimePicker22();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       <tr>
									       <td><asp:CheckBox ID="chkGradeCopyDate4" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label11" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia de sus grados de estudio:</asp:Label></td>
									       
									       <td><asp:TextBox ID="txtGradeCopyDate4" runat="server" Columns="30" 
                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                            onclick="ShowDateTimePicker23();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td><asp:CheckBox ID="chkNutriCertificateDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label12" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificación y Colegiación del Colegio de Nutricionistas y Dietistas de PR:</asp:Label></td>
                                                
									       <td> <asp:TextBox ID="txtNutriCertificateDate" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker24();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td> <asp:CheckBox ID="chkCertificateCopyDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label13" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia de certificaciones en Diabetes, Control de Peso, Manejo de Condiciones Renales, Vegetarianismo, Cáncer (si aplica):</asp:Label></td>
									       
									       <td>   <asp:TextBox ID="txtCertificateCopyDate" runat="server" Columns="30" 
                                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                            onclick="ShowDateTimePicker25();" TabIndex="44" Width="79px"></asp:TextBox></td>
									       </tr>
									       
									       <tr>
									       <td>
									         <asp:CheckBox ID="chkRegisterCertificateDate4" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="lblRegisterCertificateDate3" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificado de Registro - Junta Examinadora de Psicólogos de PR:</asp:Label>
									       </td>
									       <td>
                                                  <asp:TextBox ID="txtRegisterCertificateDate4" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker26();" TabIndex="44" Width="79px"></asp:TextBox>									       
									       
									       </td>
									       </tr>
									       
									       <tr>									       
									       <td>
                                             <asp:CheckBox ID="chkPsicoLicenseDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label14" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Licencia como Psicólogo por el Depto. de Salud de PR:</asp:Label>							       
									       </td>
									       
									       <td>
						                          <asp:TextBox ID="txtPsicoLicenseDate" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker27();" TabIndex="44" Width="79px"></asp:TextBox>									       
									       </td>
									       </tr>
									       
									       <tr>
									       <td>
				                               <asp:CheckBox ID="chkGradeCopyDate5" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label15" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Copia de sus grados de estudio:</asp:Label>
									       </td>
									       
									       <td>
                                                <asp:TextBox ID="txtGradeCopyDate5" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker28();" TabIndex="44" Width="79px"></asp:TextBox>									       
									       </td>
									       									       
								       </tr>
								       
								      <tr>
								      <td>
                                            <asp:CheckBox ID="chkCredentialsDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label16" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Credenciales y/o certificaciones especiales:</asp:Label></td>
        	      
								      <td>
                                                <asp:TextBox ID="txtCredentialsDate" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                onclick="ShowDateTimePicker29();" TabIndex="44" Width="79px"></asp:TextBox>							      
								      </td>								      
								      </tr>
								      
								      <tr>
								      <td>
				                                <asp:CheckBox ID="chkOptoDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label17" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Diploma de Doctor en Optometría:</asp:Label>
								      </td>
								      
								      <td>
				                             <asp:TextBox ID="txtOptoDate" runat="server" Columns="30" 
                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                            onclick="ShowDateTimePicker30();" TabIndex="44" Width="79px"></asp:TextBox>
								      
								      </td>
								      </tr>
								      
								      <tr>
								      <td>
								           <asp:CheckBox ID="chkPermanentDate" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label18" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Licencia Permanente expedida por la Junta Examinadora de Optómetras:</asp:Label>
								     </td>
    								      
								      <td>
					                          <asp:TextBox ID="txtPermanentDate" runat="server" Columns="30" 
                                                CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="17px" IsDate="True" 
                                                onclick="ShowDateTimePicker31();" TabIndex="44" Width="79px"></asp:TextBox>
								      </td>
								      </tr>
								      
								      <tr>
								      <td>
				                            <asp:CheckBox ID="chkRegisterCertificateDate5" runat="server" AutoPostBack="True" CssClass=" " 
                                                    oncheckedchanged="RevealControls" Text=" " />
                                                <asp:Label ID="Label19" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                    Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificación 
                                            y Registro expedida por el Departamento de Salud:</asp:Label>
								      </td>
								      
								      <td>
				                             <asp:TextBox ID="txtRegisterCertificateDate5" runat="server" Columns="30" 
                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                            onclick="ShowDateTimePicker32();" TabIndex="44" Width="79px"></asp:TextBox>
	
								      </td>
								      </tr>
								      
								      <tr><td><asp:CheckBox ID="chkCole" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label20" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Certificado de Colegiación:</asp:Label>
                                                                 </td></tr>
								      
								      <tr>
								      <td>
								               <asp:CheckBox ID="chkCredentialsDate2" runat="server" AutoPostBack="True" CssClass=" " 
                                                oncheckedchanged="RevealControls" Text=" " />
                                            <asp:Label ID="Label21" runat="server" CssClass=" " Font-Names="Tahoma" 
                                                Font-Size="9pt" Height="16px" style="font-size: 9pt" Width="132px">Credenciales 
                                               y/o certificaciones especiales :</asp:Label>
								      </td>
								      
								      <td>
								      
				                            <asp:TextBox ID="txtCredentialsDate2" runat="server" Columns="30" 
                                            CssClass=" " Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                            onclick="ShowDateTimePicker33();" TabIndex="44" Width="79px"></asp:TextBox>
								      </td>
								      
								      </tr>
									</table>

										<TABLE id="Table1" style="WIDTH: 806px; HEIGHT: 66px" cellSpacing="0" 
                                            cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													
												    <asp:Panel ID="pnlIndividual" runat="server" style="text-align: center">
												    <TABLE id="Table5" style="WIDTH: 100%; HEIGHT: 85px; margin-left: 0px;" 
                                                        cellSpacing="0" cellPadding="0"
														border="0" align="center">
														
														
														<tr>
                                                            <td class="style55">
                                                                 &nbsp;</td>
                                                            <td class="style16">
                                                               
                                                            </td>
                                                            <td class="style103">
                                                                <br />
                                                              
                                                                <asp:Label ID="LblDate32" RUNAT="server" CSSCLASS=" " Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="22px" Visible="False" WIDTH="105px">LICENCIA:</asp:Label>
                                                              
                                                                </td>
                                                            <td class="style109">
                                                                <asp:TextBox ID="txtLicencia" runat="server" Columns="30" CssClass=" " 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" TabIndex="44" 
                                                                    Visible="False" Width="79px"></asp:TextBox>
                                                            </td>
                                                            <td class="style16">

                                                            </td>
                                                            <%--Este no--%>
                                                            <td class="style77" colspan="2">
                                                                 <asp:CheckBox ID="chkTribunal" runat="server" AutoPostBack="True" CssClass=" " 
                                                                     oncheckedchanged="RevealControls" Text=" " Visible="False" />
                                                                 <asp:Label ID="LblDate6" RUNAT="server" CSSCLASS=" " Font-Names="Tahoma" 
                                                                     Font-Size="9pt" HEIGHT="27px" Visible="False" WIDTH="105px">TRIBUNAL EXAMINADOR:</asp:Label> 
                                                            </td>
                                                        </tr>
                                        				
																
														
														
														
														
														
															
														
														<tr>
                                                            <td class="style55">
                                                                 </td>
                                                            <td class="style16">
                                                                 </td>
                                                            <td class="style103">
                                                                 </td>
                                                            <td class="style109">
                                                                &nbsp;</td>
                                                            <td class="style16">
                                                                &nbsp;</td>
                                                            <td class="style77" colspan="2">
                                                                &nbsp;</td>
                                                            <td class="style37" colspan="2">
                                                                <asp:TextBox ID="txtOther" runat="server" Columns="30" CssClass=" " 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" TabIndex="44" 
                                                                    Width="205px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style59">
                                                                </td>
                                                            <td class="style16">
                                                                <asp:CheckBox ID="chkShareHolder" runat="server" AutoPostBack="True" 
                                                                    CssClass=" " oncheckedchanged="chkShareHolder_CheckedChanged" Text=" " />
                                                                <asp:Label ID="LblDate29" RUNAT="server" CSSCLASS="headfield1" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" WIDTH="80px">Shareholder</asp:Label>
                                                                </td>
                                                            <td class="style103">
                                                                </td>
                                                            <td class="style109">
                                                                &nbsp;</td>
                                                            <td class="style16">
                                                                &nbsp;</td>
                                                            <td class="style92">
                                                                </td>
                                                            <td class="style115">
                                                                </td>
                                                            <td class="style34" colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style57">
                                                                 </td>
                                                            <td class="style41">
                                                                <asp:Label ID="LblShareholderNo" RUNAT="server" Font-Bold="True" 
                                                                    Font-Names="Tahoma" Font-Size="7pt" HEIGHT="16px" 
                                                                    style="font-size: 9pt; text-align: left;" WIDTH="126px">Certificate No.:</asp:Label>
                                                            </td>
                                                            <td class="style105">
                                                                <MaskedInput:MaskedTextBox ID="txtShareholderNo" RUNAT="server" CSSCLASS=" " 
                                                                    Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" ISDATE="False" 
                                                                    Mask="9999999999" MaxLength="10" style="font-size: small; margin-left: 0px;" 
                                                                    tabIndex="1" WIDTH="100px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style111">
                                                                &nbsp;</td>
                                                            <td class="style38">
                                                                &nbsp;</td>
                                                            <td class="style73">
                                                                <asp:Label ID="LblDate26" RUNAT="server" CSSCLASS="style39" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="16px" WIDTH="114px" Visible="False">License Exp. Date:</asp:Label>
                                                            </td>
                                                            <td class="style116">
                                                                <asp:TextBox ID="txtLicenseExpDate" runat="server" Columns="30" CssClass=" " 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" IsDate="True" 
                                                                    onclick="ShowDateTimePicker6();" TabIndex="44" Width="79px" 
                                                                    Visible="False"></asp:TextBox>
                                                            </td>
                                                            <td class="style38" colspan="2">
                                                                <asp:CheckBox ID="chkCV" runat="server" AutoPostBack="True" CssClass=" " 
                                                                    Text=" " />
                                                                <asp:Label ID="LblDate28" RUNAT="server" CSSCLASS="style39" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" HEIGHT="16px" WIDTH="105px">Curriculum Vitae</asp:Label>
                                                            </td>
                                                        </tr>
														<tr>
                                                            <td class="style55">
                                                                </td>
                                                            <td class="style100">
                                                                <asp:Label ID="Label9" runat="server" CssClass=" " Height="16px" 
                                                                    style="font-family: Tahoma; text-align: left; font-weight: 700; font-size: 9pt; margin-top: 0px;" 
                                                                    Text="Number of Shares:" Visible="False" Width="135px"></asp:Label>
                                                            </td>
                                                            <td class="style106">
                                                                <MaskedInput:MaskedTextBox ID="txtShareholder" RUNAT="server" CSSCLASS=" " 
                                                                    Enabled="False" Font-Names="Tahoma" Font-Size="9pt" HEIGHT="16px" 
                                                                    ISDATE="False" Mask="9999" MaxLength="4" 
                                                                    style="font-size: small; margin-left: 0px;" tabIndex="1" Visible="False" 
                                                                    WIDTH="60px"></MaskedInput:MaskedTextBox>
                                                            </td>
                                                            <td class="style112">
                                                                &nbsp;</td>
                                                            <td class="style47">
                                                                &nbsp;</td>
                                                            <td class="style98">
                                                                </td>
                                                            <td class="style117">
                                                                </td>
                                                            <td class="style47" colspan="2">
                                                            </td>
                                                        </tr>
														<TR>
															<TD class="style59">
																</TD>
															<td class="style43" rowspan="2">
                                                                <asp:Label ID="LblDate24" RUNAT="server" Font-Bold="True" Font-Names="Tahoma" 
                                                                    Font-Size="7pt" HEIGHT="16px" style="font-size: 9pt; text-align: left;" 
                                                                    WIDTH="126px">Previous claims?</asp:Label>
                                                            </td>
															<TD class="style103" rowspan="2">
                                                                <asp:RadioButtonList ID="rblPreviousClaims" runat="server" AutoPostBack="True" 
                                                                    Height="16px" RepeatDirection="Horizontal" style="font-size: 9pt; " 
                                                                    Width="51px" 
                                                                    onselectedindexchanged="rblPreviousClaims_SelectedIndexChanged">
                                                                    <asp:ListItem Value="NO" Selected="True">No</asp:ListItem>
                                                                    <asp:ListItem Value="YES">Yes</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </TD>
															<td class="style109" rowspan="2">
                                                                &#160;</td>
															<TD class="style16" rowspan="2">
                                                                &#160;</TD>
															<td align="center" rowspan="2" class="style74" style="text-align: left">
																<asp:Label ID="LblDate15" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt" 
                                                                    HEIGHT="16px" style="text-align: left; font-weight: 700" WIDTH="100px">Board 
                                                                Certified:</asp:Label>
                                                            </td>
                                                            <td align="center" rowspan="2" class="style118">
                                                                <asp:RadioButtonList ID="rblBoardCertified" runat="server" Font-Bold="False" 
                                                                    Height="16px" RepeatDirection="Horizontal" 
                                                                    style="font-size: 9pt; text-align: left;" Width="50px">
                                                                    <asp:ListItem Selected="True" Value="NO">No</asp:ListItem>
                                                                    <asp:ListItem Value="YES">Yes</asp:ListItem>
                                                                    <asp:ListItem>N/A</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
														</TR>
														<tr>
                                                            <td class="style57">
                                                                </td>
                                                            <td colspan="2">
                                                                 </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style59">
                                                                 </td>
                                                            <td class="style43">
                                                                <asp:Label ID="lblCarrier" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="18px" 
                                                                    Width="110px" Visible="False">Carrier Name:</asp:Label>
                                                            </td>
                                                            <td class="style53" colspan="4">
                                                                <asp:TextBox ID="txtPriCarierName" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" MaxLength="75" style="margin-right: 10px" 
                                                                    TabIndex="24" Width="190px"></asp:TextBox>
                                                            </td>
                                                            <td class="style47" colspan="2">
                                                                <asp:Label ID="Label25" runat="server" CssClass="headfield1" 
                                                                    EnableViewState="False" Font-Names="Tahoma" Font-Size="9pt" Height="16px" 
                                                                    Width="70px" Visible="False">Eff. Date:</asp:Label>
                                                            </td>
                                                            <td class="style47">
                                                                <asp:TextBox ID="txtPriPolEffecDate" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" onclick="ShowDateTimePicker7();" TabIndex="44" 
                                                                    Width="79px" Columns="30" CssClass=" " IsDate="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style59">
                                                                 </td>
                                                            <td class="style43">
                                                                <asp:Label ID="Label30" runat="server" EnableViewState="False" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" style="margin-right: 7px" 
                                                                    Width="79px" Visible="False">Policy No.:</asp:Label>
                                                            </td>
                                                            <td class="style103">
                                                                <asp:TextBox ID="txtPriClaims" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" MaxLength="50" TabIndex="27" Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td class="style109">
                                                                &nbsp;</td>
                                                            <td class="style16">
                                                                 &nbsp;</td>
                                                            <td class="style77">
                                                            </td>
                                                            <td class="style60" colspan="2">
                                                                <asp:Label ID="Label24" runat="server" EnableViewState="False" 
                                                                    Font-Names="Tahoma" Font-Size="9pt" Height="18px" style="text-align: left" 
                                                                    Visible="False" Width="87px">Policy Limits:</asp:Label>
                                                            </td>
                                                            <td class="style60">
                                                                <asp:TextBox ID="txtPriPolLimits" runat="server" Font-Names="Tahoma" 
                                                                    Font-Size="9pt" Height="18px" MaxLength="50" TabIndex="26" Width="145px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style93">
                                                                </td>
                                                            <td class="style94">
                                                                </td>
                                                            <td class="style107">
                                                                </td>
                                                            <td class="style113">
                                                                &nbsp;</td>
                                                            <td class="style68">
                                                                &nbsp;</td>
                                                            <td class="style76">
                                                                </td>
                                                            <td class="style119">
                                                                </td>
                                                            <td class="style68" colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style59">
                                                                 </td>
                                                            <td class="style43" valign="top">
                                                                <asp:Label ID="LblDate25" RUNAT="server" Font-Names="Tahoma" Font-Size="9pt" 
                                                                    HEIGHT="16px" style="text-align: left; font-weight: 700" WIDTH="105px">Comments:</asp:Label>
                                                            </td>
                                                            <td class="style34" colspan="5">
                                                                <asp:TextBox ID="txtComment" runat="server" Height="70px" TextMode="MultiLine" 
                                                                    Width="326px"></asp:TextBox>
                                                                  </td>
                                                            <td class="style37" colspan="2">
                                                                 </td>
                                                        </tr>
														<tr>
                                                            <td class="style59">
                                                                 </td>
                                                            <td class="style43">
                                                                 </td>
                                                            <td class="style34" colspan="5">
                                                                 </td>
                                                            <td colspan="2">
                                                                 </td>
                                                            <td class="style37">
                                                                <br />
                                                                <br />
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
														</TABLE>
                                                    </asp:Panel>
													
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 1px" colspan="2">
										<TABLE id="Table2" 
                                            style="WIDTH: 807px; height: 0px; margin-top: 0px; margin-bottom: 0px;" 
                                            borderColor="#4b0082" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD style="height: 1px; width: 100%" background="Images2/Barra3.jpg" 
                                                    align="center"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<tr>
									<TD vAlign="middle" align="center" class="style97" colspan="2">
										<TABLE id="Table12" style="WIDTH: 806px; HEIGHT: 66px" cellSpacing="0" 
                                            cellPadding="0" width="806"
											border="0">
											<TR>
												<TD style="FONT-SIZE: 1pt" align="center">
													
												    <asp:Panel ID="pnlPrivileges" runat="server">
												    <TABLE id="Table13" style="WIDTH: 302px; HEIGHT: 74px; margin-left: 0px;" 
                                                        cellSpacing="0" cellPadding="0"
														border="0">
														<TR>
															<TD class="style23">
																<asp:label id="LblDate0" RUNAT="server" HEIGHT="16px" WIDTH="120px"
																	Font-Names="Tahoma" Font-Size="9pt" style="font-weight: 700; text-align: left;">Privileges:</asp:label>\\</TD>
															<TD class="style24" align="right">
																<maskedinput:maskedtextbox id="txtGridCount" tabIndex="1" RUNAT="server" 
                                                                    ISDATE="False" HEIGHT="19px" CSSCLASS="TextBoxStyle"
																	WIDTH="50px" Font-Names="Tahoma" Font-Size="9pt" Mask="9999" MaxLength="4"></maskedinput:maskedtextbox></TD>
															<TD class="style23" align="right">
													<asp:button id="btnUpdate" tabIndex="6" runat="server" Height="23px" 
                                                        Width="74px" Text="Update"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														BackColor="#400000" style="margin-left: 0px" onclick="btnUpdate_Click"></asp:button>
													        </TD>
														</TR>
														<TR>
															<TD class="style6" colspan="3">
																	<asp:datagrid id="dtGridCertificateLocations" 
                                            tabIndex="4" Height="145px" 
                                                        RUNAT="server" WIDTH="338px" PageSize="8"
																		ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
																		ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0"
																		FONT-NAMES="Tahoma" FONT-SIZE="9pt" AUTOGENERATECOLUMNS="False" BACKCOLOR="White"
																		HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA"
																		BORDERWIDTH="1px" BORDERSTYLE="Solid" Font-Italic="False" style="text-align: center; font-size: 8pt;" 
                                                                        onitemcommand="dtGridCertificateLocations_ItemCommand" >
																		<FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
																		<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
																		<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
																		<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" 
                                                                            BackColor="White" Wrap="False"></AlternatingItemStyle>
																		<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
																		<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
																			BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
																		<Columns>
																			<asp:BoundColumn DataField="PrivilegeID" HeaderText="PrivilegeID">
                                                                            </asp:BoundColumn>
                                                                            <asp:TemplateColumn HeaderText="Hospital">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddlCertificateLocation" runat="server" 
                                                                                        DataSourceID="SqlDataSource1" DataTextField="HospitalDesc" 
                                                                                        DataValueField="HospitalID" Width="425px">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
																		    <asp:TemplateColumn HeaderText="Delete">
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnDeletePrivilege" runat="server" CausesValidation="false" 
                                                                                        CommandName="Delete"
                                                                                        onclientclick="return confirm('Are you certain you want to delete this Privilege?');" 
                                                                                        Text="" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
																		</Columns>
																		<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
																			CssClass="Numbers" Mode="NumericPages"></PagerStyle>
																	</asp:datagrid>
										                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                        ConnectionString="<%$ ConnectionStrings:PRMDICConnectionString %>" 
                                                                        SelectCommand="GetHospital" SelectCommandType="StoredProcedure">
                                                                    </asp:SqlDataSource>
										                    </TD>
														</TR>
														</TABLE>
                                                    </asp:Panel>
													
												</TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 35px; HEIGHT: 36px" colspan="2">
										<P align="center"> </P>
										<P align="center"> </P>
									</TD>
								</TR>
							</TABLE>
						</P>
						<P>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
		                </P>
					</form>
	</body>
</HTML>

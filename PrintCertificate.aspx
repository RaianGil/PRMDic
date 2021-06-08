<%@ Page language="c#" AutoEventWireup="true" Inherits="EPolicy.PrintCertificate" CodeFile="PrintCertificate.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<%@ Register Assembly="AjaxControlToolkit, Version=3.5.50508.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<!--DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<%--<link rel="stylesheet" href="css/jquery-ui-1.7.2.custom.css" type="text/css"/>--%>
		<%--<link rel="stylesheet" href="StyleSheet.css" type="text/css"/>--%>
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
	    .style3
        {
            width: 198px;
        }
        .style5
        {
            width: 196px;
        }
        .style6
        {
            width: 100px;
        }
        .style12
        {
            width: 196px;
            height: 9px;
        }
        .style14
        {
            height: 9px;
        }
	    .style15
        {
            width: 277px;
        }
        .style16
        {
            width: 272px;
        }
        .style17
        {
            width: 271px;
        }
        .style21
        {
            height: 3px;
        }
        .style22
        {
            height: 3px;
            width: 683px;
        }
	</style>	
	</HEAD>
    <%--<script language="javascript">
    setTimeout("self.close();",300000) //60000
    </script> --%>
	<body>
		<form id="Form1" method="post" runat="server">
			<p><asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></p>

              <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                <div class="row">
                   <div class="col-md-12">
					 <asp:Label id="Label8" runat="server" Height="16px" CssClass="headForm1 " ForeColor="Black"
					 	Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True">Print Certificate</asp:Label>
                   </div>
                   <div class="col-md-4" style="align-self: center;">
                      <div class="row">
                        <div class="col-md-6">
						    <asp:Label id="lblPolicyNo" runat="server" 
                                Font-Size="11pt" Width="349px" ForeColor="Red" Font-Names="Tahoma" 
                                style="text-align: left">Policy No:</asp:Label>
                        </div>                   
                      </div>
                   </div>
                   <div class="col-md-8" style="text-align:right;">                   
                        <asp:button id="btnPrint" tabIndex="5" runat="server"
                            Text="Print" CssClass="btn-bg-theme1 btn-w-100 btn-r-4"
					    	ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
					    	onclick="btnPrint_Click" style="margin-bottom: 0px"></asp:button>
						<asp:button id="BtnExit" tabIndex="6" runat="server" Text="Exit" CssClass="btn-bg-theme1 btn-w-100 btn-r-4"
							ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
                            onclick="BtnExit_Click"></asp:button>
                   </div>
                   <div class="col-md-12">
                   <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="mb-3 row" style="align-items: center; justify-content: center;">
								<asp:label id="LblDate" RUNAT="server" HEIGHT="16px" Width="150px" CSSCLASS="form-labe"
									Font-Names="Tahoma" Font-Size="9pt">Number of Certificates:</asp:label>
								<maskedinput:maskedtextbox id="txtGridCount" tabIndex="1" RUNAT="server" 
                                    ISDATE="False" HEIGHT="34px" Width="250px" CSSCLASS="TextBoxStyle form-control"
									Font-Names="Tahoma" Font-Size="9pt" Mask="9999" MaxLength="4"></maskedinput:maskedtextbox>
                            </div>
                            <div class="mb-3 row" style="align-items: center; justify-content: center; margin-right: 110px;">
								<asp:Label ID="Label9" runat="server" 
                                    style="font-size: 9pt; font-family: Tahoma; text-align: right" 
                                    Text="Same Address?" Width="123px" Height="16px"></asp:Label>
                                <asp:CheckBox ID="chkSameAddress" runat="server" Width="123px"
                                    style="text-align: left; font-size: 9pt; font-family: Tahoma" Text="Yes" 
                                    TabIndex="2" />
                            </div>
                            <div class="mb-3 row" style="align-items: center; justify-content: center; margin-right: 110px;">
								<asp:CheckBox ID="chkCancPrint" Width="123px" runat="server" Font-Size="X-Small" 
                                                                     Text="Cancellation Print" />
                                <asp:CheckBox ID="chkRegPrint" Width="123px" runat="server" Font-Size="X-Small" 
                                                                     Text="Regular Print" />
                            </div>
                            <div class="mb-3 row" style="align-items: center; justify-content: center;">
								<asp:button id="btnUpdate" tabIndex="6" runat="server" Height="23px" 
                                                        Width="74px" Text="Update" CssClass="btn-bg-theme1 btn-w-100 btn-r-4"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														onclick="btnUpdate_Click"></asp:button>
                            </div>
                        </div>
                    </div>
                   <hr />
                    <div class="row">
                        <div class="col-md-12">
						    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:PRMDICConnectionString %>" 
                                SelectCommand="GetCertificateLocation" SelectCommandType="StoredProcedure">
                            </asp:SqlDataSource>
						    <asp:datagrid id="dtGridCertificateLocations" 
                                tabIndex="4" Height="145px" 
                                RUNAT="server" WIDTH="338px" PageSize="8"
						    	ITEMSTYLE-CSSCLASS="HeadForm3" HEADERSTYLE-BACKCOLOR="#5C8BAE" HEADERSTYLE-CSSCLASS="HeadForm2"
						    	ALTERNATINGITEMSTYLE-BACKCOLOR="#FEFBF6" ALTERNATINGITEMSTYLE-CSSCLASS="HeadForm3" CELLPADDING="0"
						    	FONT-NAMES="Tahoma" FONT-SIZE="9pt" AUTOGENERATECOLUMNS="False" BACKCOLOR="White"
						    	HEADERSTYLE-HORIZONTALALIGN="Center" ITEMSTYLE-HORIZONTALALIGN="center" BORDERCOLOR="#D6E3EA"
						    	BORDERWIDTH="1px" BORDERSTYLE="Solid" Font-Italic="False" style="text-align: center; font-size: 8pt;">
						    	<FooterStyle ForeColor="#003399" BackColor="Navy"></FooterStyle>
						    	<SelectedItemStyle HorizontalAlign="Center" BackColor="White"></SelectedItemStyle>
						    	<EditItemStyle HorizontalAlign="Center" BackColor="White"></EditItemStyle>
						    	<AlternatingItemStyle HorizontalAlign="Center" CssClass="HeadForm3" 
                                    BackColor="White" Wrap="False"></AlternatingItemStyle>
						    	<ItemStyle HorizontalAlign="Center" CssClass="HeadForm3" BackColor="White"></ItemStyle>
						    	<HeaderStyle Font-Names="tahoma" HorizontalAlign="Center" Height="10px" ForeColor="White" CssClass="HeadForm2"
						    		BackColor="#400000" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></HeaderStyle>
						    	<Columns>
						    		<asp:TemplateColumn HeaderText="Certificate Location">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlCertificateLocation" runat="server" Width="200px" 
                                                DataSourceID="SqlDataSource1" DataTextField="CertificateLocationDesc" 
                                                DataValueField="CertificateLocationID">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
						    	</Columns>
						    	<PagerStyle Font-Names="Tahoma" HorizontalAlign="Left" ForeColor="Blue" BackColor="White" PageButtonCount="20"
						    		CssClass="Numbers" Mode="NumericPages"></PagerStyle>
						    </asp:datagrid>
                        </div>
                            <div class="mb-3 row" style="align-items: center; justify-content: center;">
                                <asp:button id="btnPrintAll" tabIndex="5" runat="server"
                                                        Width="150px" Text="Print All From Table" CssClass="btn-bg-theme1 btn-w-150 btn-r-4"
														ForeColor="White" BorderWidth="0px" BorderColor="#400000" Font-Names="Tahoma" Font-Size="9pt"
														onclick="btnPrintAll_Click"></asp:button>
                            </div>

                        <div class="col-md-12">
                            <asp:DataGrid ID="dtCertificateHistory" runat="server" 
                                AllowPaging="True" AlternatingItemStyle-BackColor="#FEFBF6" 
                                AlternatingItemStyle-CssClass="HeadForm3" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#D6E3EA" 
                                BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="0" Font-Names="Arial" Font-Size="9pt" 
                                HeaderStyle-BackColor="#5C8BAE" HeaderStyle-CssClass="HeadForm2" 
                                HeaderStyle-HorizontalAlign="Center" Height="16px" 
                                ItemStyle-CssClass="HeadForm3" 
                                ItemStyle-HorizontalAlign="center" PageSize="8" TabIndex="9" 
                                Width="600px" 
                                onitemcommand="dtCertificateHistory_ItemCommand">
                                <FooterStyle BackColor="Navy" ForeColor="#003399" />
                                <EditItemStyle BackColor="White" 
                                    HorizontalAlign="Center" />
                                <SelectedItemStyle BackColor="White" 
                                    HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" CssClass="Numbers" 
                                    Font-Names="Tahoma" ForeColor="Blue" HorizontalAlign="Left" Mode="NumericPages" 
                                    PageButtonCount="20" />
                                <AlternatingItemStyle BackColor="White" 
                                    CssClass="HeadForm3" HorizontalAlign="Center" />
                                <ItemStyle BackColor="White" CssClass="HeadForm3" 
                                    HorizontalAlign="Center" />
                                <Columns>
                                 <asp:BoundColumn DataField="CertificateHistoryID"  Visible="false"
                                        HeaderText="Certificate ID">
                                        <HeaderStyle Width="130px" />
                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CertificateLocationDesc" 
                                        HeaderText="Certificate Location">
                                        <HeaderStyle Width="130px" />
                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                     <asp:BoundColumn DataField="CertificateLocationID" Visible="false"
                                        HeaderText="Certificate Location ID">
                                        <HeaderStyle Width="130px" />
                                        <ItemStyle Font-Names="Tahoma" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CertificateDate" 
                                        HeaderText="Date Prepared">
                                        <HeaderStyle Width="85px" />
                                        <ItemStyle Font-Names="Tahoma" />
                                    </asp:BoundColumn>
                                    <asp:ButtonColumn HeaderImageUrl="Images2/x.bmp" ButtonType="PushButton" CommandName="Delete">
                                      <HeaderStyle Width="5px"  />
                                    </asp:ButtonColumn>
                                    <asp:ButtonColumn  ButtonType="PushButton"  HeaderText="Print" CommandName="Print">
                                      <HeaderStyle Width="5px"  />
                                    </asp:ButtonColumn>
                                </Columns>
                                <HeaderStyle BackColor="#400000" CssClass="HeadForm2" 
                                    Font-Bold="False" Font-Italic="False" Font-Names="tahoma" Font-Overline="False" 
                                    Font-Strikeout="False" Font-Underline="False" ForeColor="White" Height="10px" 
                                    HorizontalAlign="Center" />
                            </asp:DataGrid>
                        </div>
                    </div>
                   </div>



		<Toolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
                AsyncPostBackTimeout="0">
            </Toolkit:ToolkitScriptManager>
			    <asp:Panel ID="pnlMessage" runat="server" CssClass="CajaDialogo" Width="400px" BackColor="#F4F4F4"
                        Style="display: none;">
                        <div class="CajaDialogoDiv" style="padding: 0px; background-color: #FFFFFF; color: #C0C0C0;
                            font-family: tahoma; font-size: 14px; font-weight: normal; font-style: normal;
                            background-repeat: no-repeat; text-align: left; vertical-align: bottom;">
                            <asp:Label ID="Label55" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Lucida Sans"
                                Font-Size="14pt" Text="Message.." ForeColor="#000066" />
                        </div>
                        <div class="CajaDialogoDiv" style="color: #FFFFFF">
                            <table style="background-position: center; width: 400px; height: 175px;">
                                <tr>
                                    <td align="left" valign="middle">
                                        <asp:TextBox ID="lblRecHeader" runat="server" Font-Bold="False" Font-Italic="False"
                                            Font-Size="10pt" Font-Underline="False" ForeColor="Maroon" Text="Message" Width="390px"
                                            Font-Names="Arial" CssClass="" TextMode="MultiLine" Height="170px" BorderColor="Transparent"
                                            BorderStyle="None" BorderWidth="0px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="CajaDialogoDiv" align="center">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
                        </div>
                    </asp:Panel>
			<Toolkit:ModalPopupExtender ID="mpeSeleccion" runat="server" BackgroundCssClass="modalBackground"
                        CancelControlID="" DropShadow="True" OkControlID="btnAceptar" OnCancelScript=""
                        OnOkScript="" PopupControlID="pnlMessage" TargetControlID="btnDummy">
                    </Toolkit:ModalPopupExtender>
                    <asp:Button ID="btnDummy" runat="server" BackColor="Transparent" BorderColor="Transparent"
                        BorderStyle="None" BorderWidth="0" Visible="true" />
             </div>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:literal id="litPopUp" runat="server" Visible="False"></asp:literal>
            </div>
		</form>
	</body>
</HTML>

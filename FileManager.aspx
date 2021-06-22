<%@ Page language="c#" Inherits="EPolicy.FileManager" CodeFile="FileManager.aspx.cs" %>
<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<head runat="server">
		<title>ePMS | electronic Policy Manager Solution</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="epolicy.css" type="text/css" rel="stylesheet"/>
		
		<style type="text/css">
            .style1
            {
                height: 23px;
            }
    </style>
    
	</head>
	
<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="js/jquery-ui-1.7.2.custom.min.js"></script>
<script type="text/javascript">
    
</script>
	
	<body bottomMargin="0" leftMargin="0" background="Images2/SQUARE.GIF"
		topMargin="19" rightMargin="0">
		<form method="post" runat="server">
		
<%--		<asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>--%>
        
        <div>
<asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Block" UpdateMode="Conditional">
        
        <Triggers>
                <%--<asp:PostBackTrigger ControlID="BtBackUp" />--%>
                 <asp:AsyncPostBackTrigger ControlID="BtBackUp" 
                    EventName="Click" />
   </Triggers>
            <ContentTemplate>
		
		
			<TABLE id="Table8" style="Z-INDEX: 153; LEFT: 4px; WIDTH: 911px; POSITION: static; TOP: 4px; HEIGHT: 501px"
				cellSpacing="0" cellPadding="0" width="911" align="center" bgColor="white" dataPageSize="25"
				border="0">
				<TR>
					<TD style="WIDTH: 764px; HEIGHT: 1px" colSpan="3">
						<P>
							<asp:placeholder id="Placeholder1" runat="server"></asp:placeholder></P>
					</TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 10pt; WIDTH: 5px; POSITION: static; HEIGHT: 395px" align="right"
						colSpan="1" rowSpan="5" vAlign="top">
						<P align="center">
							<asp:placeholder id="phTopBanner1" runat="server"></asp:placeholder></P>
					</TD>
					<TD style="FONT-SIZE: 0pt; WIDTH: 86px; HEIGHT: 184px" align="center">
						<P align="center">
							<TABLE id="Table9" style="WIDTH: 809px; HEIGHT: 374px" cellSpacing="0" cellPadding="0"
								width="809" bgColor="white" border="0">
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="center"></TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; WIDTH: 6px; HEIGHT: 3px" align="left">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
										<TABLE id="Table10" style="WIDTH: 808px; HEIGHT: 12px" cellSpacing="0" cellPadding="0"
											width="808" border="0">
											<TR>
												<TD align="left"> 
													<asp:Label id="LblFileManager" runat="server" Font-Names="Tahoma" Width="212px" Height="16px"
														Font-Bold="True" ForeColor="Black" Font-Size="11pt" CssClass="headForm1 ">File Manager</asp:Label></TD>
												<TD></TD>
												<TD align="right">
													<asp:Button id="BtnExit" runat="server" Text="Exit" Font-Names="Tahoma" Width="45px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtnExit_Click"></asp:Button> 
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 0pt; HEIGHT: 5px">
										<TABLE id="Table11" style="WIDTH: 808px" borderColor="#4b0082" height="1" cellSpacing="0"
											borderColorDark="#4b0082" cellPadding="0" width="808" bgColor="indigo" borderColorLight="#4b0082"
											border="0">
											<TR>
												<TD background="Images2/Barra3.jpg"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center">
                                            &nbsp;
									</TD>
								</TR>
								<TR>
									<TD align="center">
                                            <asp:Label id="Label1" runat="server" Font-Names="Tahoma" Width="212px" Height="16px"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 ">Back Up Files from the Server</asp:Label></TD>
									</TD>
								</TR>
								<TR>
									<TD align="center">
									
												&nbsp;&nbsp;&nbsp;		
																		

									</TD>
								</TR>
                                <TR>
									<TD align="center">
	                                    &nbsp; 
	                                    </TD>
									
									
									
								</TR>
								
								<TR>
									<TD align="center" class="style1">
									
									<asp:Button id="BtBackUp" runat="server" Text="Transfer Files" Font-Names="Tahoma" Width="100px" Height="23px"
														ForeColor="White" BackColor="#400000" BorderColor="#400000" BorderWidth="0px" onclick="BtBackUp_Click"
														onclientclick="return confirm('Are you certain you want to start the process?');"></asp:Button> 

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
												&nbsp;&nbsp;&nbsp;		
																		

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
												<asp:Label id="Label2" runat="server" Font-Names="Tahoma" Width="212px" Height="16px"
														Font-Bold="True" ForeColor="Black" Font-Size="9pt" CssClass="headForm1 ">* Upon pressing the button all of the files will be moved to a back up folder and the working folder will be deleted.
														Please make sure that all other processes are stoped before starting the task.</asp:Label></TD>
																		

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
												&nbsp;&nbsp;&nbsp;		
																		

									</TD>
								</TR>
								<TR>
									<TD align="center">
									
									      <asp:Label id="LblTotalCases" runat="server" Font-Names="Tahoma" Width="212px" Height="16px" Visible="false"
														Font-Bold="True" ForeColor="Black" Font-Size="11pt" CssClass="headForm1 ">Total Files: </asp:Label>
									</TD>
								</TR>
								
								<TR>
									<TD align="center">
                                          
														
											   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                  Update in progress...
                                                </ProgressTemplate>
                                                </asp:UpdateProgress>--%>
                                                
                                                 <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                                                AssociatedUpdatePanelID="UpdatePanel2">
                                                <progresstemplate>
                                                   <%-- <span class="style6">--%>
                                                    <img alt="" src="Images2/loader.gif" style="width: 80px; height: 16px" />
                                                    <br />
                                                    Please wait... 
                                                    <%--</span>--%>
                                                    <br />
                                                     
                                                </progresstemplate>
                                            </asp:UpdateProgress>
                                            
									</TD>
									<TD align="right">
                                             
									</TD>
								</TR>
								<TR>
									<TD style="FONT-SIZE: 2pt; WIDTH: 112px; HEIGHT: 407px" vAlign="middle" align="center">                                                                                                                                          
									</TD>
								</TR>
							</TABLE>
						</P>
						<P> </P>
					</TD>
				</TR>
			</TABLE>
			<maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
			<asp:placeholder id="phTopBanner" runat="server"></asp:placeholder>
			<asp:Literal id="litPopUp" runat="server" Visible="False"></asp:Literal>
			
			            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
			
<%--			
			 </ContentTemplate>
            </asp:UpdatePanel>--%>
			
		</form>
	</body>
</HTML>

<%@ Register TagPrefix="MaskedInput" Namespace="MaskedInput" Assembly="MaskedInput" %>
    <%@ Page language="c#" Inherits="EPolicy.PrintPolicy" CodeFile="PrintPolicy.aspx.cs" %>
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
        <HTML>

        <HEAD>
            <title>ePMS | electronic Policy Manager Solution</title>
            <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
            <meta name="CODE_LANGUAGE" Content="C#">
            <meta name="vs_defaultClientScript" content="JavaScript">
            <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
            <LINK href="epolicy.css" type="text/css" rel="stylesheet">
            <SCRIPT LANGUAGE=Javascript>
                <!--

                function OnClear() {
                    SigPlus1.ClearTablet(); //Clears the signature, in case of error or mistake
                }

                function OnCancel() {
                    SigPlus1.TabletState = 0; //Turns tablet off
                }

                function OnSign() {
                    SigPlus1.TabletState = 1; //Turns tablet on
                }

                function OnSave() {
                    SigPlus1.TabletState = 0; //Turns tablet off
                    SigPlus1.SigCompressionMode = 1; //Compresses the signature at a 2.5 to 1 ratio, making it smaller...to display the signature again later, you WILL HAVE TO set the SigCompressionMode of the new SigPlus object = 1, also
                    document.PrintPolicy.hiddenSigString.value = SigPlus1.SigString;

                    alert("The signature you have taken is the following data: " + SigPlus1.SigString);

                    alert("Test: " + document.PrintPolicy.hiddenSigString.value);
                    //The signature is now taken, and you may access it using the SigString property of SigPlus. 
                    //This SigString is the actual signature, in ASCII format. 
                    //You may pass this string value like you would any other String. 
                    //To display the signature again, you simply pass this String back to the SigString property of SigPlus 
                    //(BE SURE TO SET SigCompressionMode=1 PRIOR TO REASSIGNING THE SigString)
                }

                //-->
            </SCRIPT>

        </HEAD>

        <body>
            <form name="PrintPolicy" method="post" runat="server">
                <p>
                    <asp:placeholder id="Placeholder1" runat="server"></asp:placeholder>
                </p>
                <div class="container-xl mb-4" style="padding-left:18px; padding-right:18px;">
                    <div class="row">
                        <div class="col-md-4" style="align-self: center;">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label id="Label17" runat="server" CssClass="headForm1 " Height="16px" Width="212px" Font-Names="Tahoma" Font-Size="11pt" ForeColor="Black" Font-Bold="True">Print Policy:</asp:Label>
                                    <input id="hiddenSigString" runat="server" enableviewstate="true" name="ConfirmDialogBoxPopUp" size="1" style="z-index: 102; left: 704px; width: 35px; position: absolute; top: 44px;
                                height: 22px" type="hidden" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Label id="Label5" runat="server" Font-Names="Tahoma" ForeColor="Black" Height="10px" Width="33px" CssClass="headForm1 " Font-Size="9pt">Client: </asp:Label>
                                    <asp:label id="lblParentCustomer" Font-Names="Tahoma" RUNAT="server" CSSCLASS="headfield1" WIDTH="96px" Font-Size="9pt"></asp:label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8" style="text-align:right;">
                            <asp:Button ID="btnSign" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Sign" />
                            <asp:Button id="PrintPolicies" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Print" onclick="PrintPolicies_Click"></asp:Button>
                            <asp:Button id="BtnBack" runat="server" class="btn-h-30 btn-bg-theme2 btn-r-4" Text="Exit" onclick="BtnBack_Click"></asp:Button>
                        </div>
                        <div class="col-md-12">
                            <hr />
                            <div class="row">
                                <div class="col-md-7">
                                    <asp:label id="Label4" runat="server" Width="127px" CssClass="headform1" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">Policy & Document List</asp:label>
                                    <p>
                                        <asp:CheckBoxList id="ChkPolicyList" runat="server" CssClass="form-control" RepeatLayout="Flow" BorderStyle="Solid" BorderWidth="1px" Height="353px" Font-Names="Tahoma" Font-Size="9pt"></asp:CheckBoxList>
                                    </p>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:label id="Label9" runat="server" Width="60px" CssClass="headform1" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">Copy List:</asp:label>
                                            <P>
                                                <asp:CheckBoxList id="ChkCopyList" runat="server" CssClass="form-control" RepeatLayout="Flow" BorderStyle="Solid" BorderWidth="1px" Height="161px" Font-Names="Tahoma" Font-Size="9pt"></asp:CheckBoxList>
                                            </P>
                                            <P>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:label id="Label1" runat="server" Width="60px" CssClass="headform1" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">Print Only One Copy of:</asp:label>
                                            <p>
                                                <asp:CheckBoxList id="ChkPrintJustOne" runat="server" Height="161px" BorderWidth="1px" BorderStyle="Solid" RepeatLayout="Flow" CssClass="form-control" Font-Names="Tahoma" Font-Size="9pt"></asp:CheckBoxList>
                                            </P>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <maskedinput:maskedtextheader id="MaskedTextHeader1" RUNAT="server"></maskedinput:maskedtextheader>
                    <asp:literal id="litPopUp" RUNAT="server" VISIBLE="False"></asp:literal>
                    <P> </P>
                </div>
            </form>
        </body>

        </HTML>
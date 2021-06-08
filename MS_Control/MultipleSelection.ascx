<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultipleSelection.ascx.cs" Inherits="EPolicy.MultipleSelection" %>
<%@ Register Assembly="CheckBoxListExCtrl" Namespace="CheckBoxListExCtrl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<div>
           <asp:DropDownList ID="MultiSelectDDL" 
                runat="server" Width="208px" Font-Names="Tahoma" Font-Size="10pt" 
                CssClass="regularText">
            </asp:DropDownList>
            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
               CssClass="regularText" Font-Names="Tahoma" Font-Size="11pt" style="border-radius:5px;"
               oncheckedchanged="CheckBox1_CheckedChanged" Text="Select All" />
            <cc2:HoverMenuExtender ID="HoverMenuExtender1"
                         runat="server" 
                         TargetControlID="MultiSelectDDL" 
                         PopupControlID="PanelPopUp" 
                         PopupPosition="bottom" 
                         OffsetX="6" 
                         PopDelay="25">
            </cc2:HoverMenuExtender>      
         
            <asp:Panel ID="PanelPopUp" CssClass="popupMenu" runat="server" Width="208px" 
                Height="280px">
             <cc1:CheckBoxListExCtrl ID="CheckBoxListExCtrl1" runat="server" Font-Names="Arial" 
                    Font-Size="8pt" Width="208px">
            </cc1:CheckBoxListExCtrl>
            </asp:Panel>
             <asp:HiddenField ID="hf_checkBoxValue" runat="server" />
            <asp:HiddenField ID="hf_checkBoxText" runat="server" />
            <asp:HiddenField ID="hf_checkBoxSelIndex" runat="server" />
        </div>   
<div id="ie6SelectTooltip" style="display:none;position:absolute;padding:1px;border:1px solid #333333;background-color:#fffedf;font-size:smaller;z-index: 99;"></div>

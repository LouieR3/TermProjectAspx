<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WalletBalance.ascx.cs" Inherits="TermProject_Template.CustomControls.WalletBalance" %>
<p>
    <asp:Label ID="lblAccountBalance" runat="server" style="z-index: 1; left: 26px; top: 20px; position: absolute; " Text="Account Balance:" ForeColor="Black"></asp:Label>
</p>
<asp:Label ID="lblBalance" runat="server" style="z-index: 1; left: 145px; top: 20px; position: absolute" ForeColor="Black"></asp:Label>
<asp:Button ID="btnAddFunds" runat="server" Text="Add Funds" OnClick="btnAddFunds_Click" style="z-index: 1; left: 262px; top: 16px; position: absolute; right: 383px; width: 92px;" />
<asp:TextBox ID="txtAddFunds" runat="server" style="z-index: 1; left: 371px; top: 19px; position: absolute" Visible="False"></asp:TextBox>
<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="z-index: 1; left: 511px; top: 16px; position: absolute; width: 36px;" Text="Add" Visible="False" />
<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" style="z-index: 1; left: 562px; top: 16px; position: absolute; width: 57px;" Text="Cancel" Visible="False" />

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WalletBalance.ascx.cs" Inherits="TermProject_Template.CustomControls.WalletBalance" %>
<div class="placeOrder">
    <p>
        <asp:Label ID="lblAccountBalance" runat="server" Text="Account Balance:" ForeColor="Black"></asp:Label>
    </p>
    <asp:Label ID="lblBalance" runat="server" ForeColor="Black"></asp:Label>
    <asp:Button ID="btnAddFunds" runat="server" Text="Add Funds" OnClick="btnAddFunds_Click" />
    <asp:TextBox ID="txtAddFunds" runat="server" Visible="False"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Visible="False" />
    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Visible="False" />
</div>
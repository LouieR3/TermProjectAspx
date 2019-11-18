<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditWallet.ascx.cs" Inherits="TermProject_Template.CustomControls.EditWallet" %>
<style type="text/css">
    .style1
    {
        width: 124px;
    }
    .style2
    {
        text-align: center;
    }
</style>
<table id="Table1" border="0" cellpadding="5" cellspacing="0"
       style="width: 542px">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblWalletSetting" runat="server" Text="Wallet Settings" ForeColor="Black"></asp:Label></td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblName" runat="server" Text="Account Name:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
            </td>
    </tr>
</table>
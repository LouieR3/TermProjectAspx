<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditWallet.ascx.cs" Inherits="TermProject_Template.CustomControls.EditWallet" %>
<style type="text/css">
    .style2 {
        text-align: center;
        margin-left: auto;
        margin-right: auto;
        width: 100%;
        padding-top: 20px;
    }
</style>
<table class="tblStyle" id="Table1" border="0" cellpadding="5" cellspacing="0">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblWalletSetting" runat="server" class="login100-form-title p-b-16" Text="Wallet Settings" ForeColor="Black"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblName" class="txt1 p-b-11" runat="server" Text="Account Name:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAddress" class="txt1 p-b-11" runat="server" Text="Account Address:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblBankName" class="txt1 p-b-11" runat="server" Text="Bank Name:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtBankName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCardType" class="txt1 p-b-11" runat="server" Text="Card Type:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCardType" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCardNumber" class="txt1 p-b-11" runat="server" Text="CardNumber:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCardNumber" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblEmail" class="txt1 p-b-11" runat="server" Text="Email:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnEdit" class="logButton1" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnUpdate" class="logButton1" runat="server" Text="Update" OnClick="btnUpdate_Click" Enabled="False" EnableTheming="True" />
        </td>
    </tr>
</table>


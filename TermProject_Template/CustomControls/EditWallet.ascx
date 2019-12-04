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
            <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblAddress" runat="server" Text="Account Address:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblBankName" runat="server" Text="Bank Name:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtBankName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblCardType" runat="server" Text="Card Type:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:DropDownList ID="ddlType" runat="server" Width="127px" Enabled="False">
                <asp:ListItem>Credit</asp:ListItem>
                <asp:ListItem>Debit</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblCardNumber" runat="server" Text="CardNumber:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtCardNumber" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblEmail" runat="server" Text="Email:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Enabled="False" />
            </td>
    </tr>
</table>
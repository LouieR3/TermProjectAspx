<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountSettings.ascx.cs" Inherits="TermProject_Template.CustomControls.AccountSettings" %>
<style type="text/css">
    .style2 {
        text-align: center;
        margin-left: auto;
        margin-right: auto;
        width: 100%;
    }
</style>
<table id="Table1" border="0" cellpadding="5" cellspacing="0">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblAccountSettings" class="login100-form-title p-b-16" runat="server" Text="Account Settings" ForeColor="Black"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblLoginID" class="txt1 p-b-11" runat="server" Text="Login ID:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLoginID" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td >
            <asp:Label ID="lblPassword" class="txt1 p-b-11" runat="server" Text="Account Password:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblUserFirstName" class="txt1 p-b-11" runat="server" Text="First Name:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtUserFirstName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblUserLastName" class="txt1 p-b-11" runat="server" Text="Last Name:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtUserLastName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblBillingAddress" class="txt1 p-b-11" runat="server" Text="Billing Address:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtBillingAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblDeliveryAddress" class="txt1 p-b-11" runat="server" Text="Delivery Address:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDeliveryAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblEmail" class="txt1 p-b-11" runat="server" Text="Account Email:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnEdit" class="logButton1" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnUpdate" class="logButton1" runat="server" Text="Update" OnClick="btnUpdate_Click" Enabled="False" />
      </td>
    </tr>
</table>

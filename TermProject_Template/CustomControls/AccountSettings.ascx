<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountSettings.ascx.cs" Inherits="TermProject_Template.CustomControls.AccountSettings" %>
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
            <asp:Label ID="lblAccountSettings" runat="server" Text="Account Settings" ForeColor="Black"></asp:Label></td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblLoginID" runat="server" Text="Login ID:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtLoginID" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblPassword" runat="server" Text="Account Password:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtPassword" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblUserFirstName" runat="server" Text="First Name:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtUserFirstName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblUserLastName" runat="server" Text="Last Name:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtUserLastName" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblBillingAddress" runat="server" Text="Billing Address:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtBillingAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td Class ="style1">
            <asp:Label ID="lblDeliveryAddress" runat="server" Text="Delivery Address:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtDeliveryAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td Class ="style1">
            <asp:Label ID="lblEmail" runat="server" Text="Account Email:" ForeColor="Black"></asp:Label>

        </td>
        <td style="width: 300px">
            <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </td>
    </tr>
</table>

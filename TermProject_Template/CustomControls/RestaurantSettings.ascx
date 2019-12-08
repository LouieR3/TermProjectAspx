<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestaurantSettings.ascx.cs" Inherits="TermProject_Template.CustomControls.RestaurantSettings" %>
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
            <asp:Label ID="lblRestaurantSettings" class="login100-form-title p-b-16" runat="server" Text="Restaurant Settings" ForeColor="Black"></asp:Label></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblRestName" class="txt1 p-b-11" runat="server" Text="Restaurant Name:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
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
        <td >
            <asp:Label ID="lblPassword" class="txt1 p-b-11" runat="server" Text="Password:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblAddress" class="txt1 p-b-11" runat="server" Text="Address:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblPhone" class="txt1 p-b-11" runat="server" Text="First Name:" ForeColor="Black"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="btnEdit" class="logButton1" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnUpdate" class="logButton1" runat="server" Text="Update" Enabled="False" OnClick="btnUpdate_Click" />
      </td>
    </tr>
</table>

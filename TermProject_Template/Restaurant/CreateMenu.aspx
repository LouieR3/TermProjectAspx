<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="CreateMenu.aspx.cs" Inherits="TermProject_Template.Restaurant.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <asp:Button ID="btnEdit" runat="server" style="z-index: 1; left: 491px; top: 71px; position: absolute; right: 252px;" Text="Edit" OnClick="Button1_Click" />
    <asp:GridView ID="gvMenu" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvEmails_PageIndexChanging" PageSize="5" style="z-index: 1; left: 190px; top: 111px; position: absolute; height: 217px; width: 842px" Visible="False">
        <Columns>
            <asp:TemplateField HeaderText="Select" Visible="False">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ImageField ControlStyle-CssClass="img" DataImageUrlField="Avatar" HeaderText="Item Photo">
                <ControlStyle CssClass="img" Height="30px" Width="30px" />
                <HeaderStyle Height="20px" />
                <ItemStyle Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
            </asp:ImageField>
            <asp:BoundField DataField="Email_Title" HeaderText="Item" />
            <asp:BoundField DataField="Email_Content" HeaderText="Item Price" />
            <asp:TemplateField HeaderText="Add On's">
                <ItemTemplate>
                    <asp:ListBox ID="lsbxAddOns" runat="server"></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="ItemID" Visible="False" />
        </Columns>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:Button ID="btnDelete" runat="server" style="z-index: 1; left: 541px; top: 71px; position: absolute" Text="Delete" Visible="False" OnClick="btnDelete_Click" />
    <asp:Button ID="btnChange" runat="server" style="z-index: 1; left: 615px; top: 71px; position: absolute" Text="Change" Visible="False" />
    <asp:Button ID="btnNewItem" runat="server" style="z-index: 1; left: 395px; top: 70px; position: absolute" Text="New Item" />
</asp:Content>

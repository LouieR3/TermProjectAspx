<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="ViewAllOrders.aspx.cs" Inherits="TermProject_Template.Restaurant.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <asp:Label ID="lblOrders" runat="server" Text="Order Information:" ForeColor="Black" style="z-index: 1; left: 7px; top: 55px; position: absolute"></asp:Label>
    <asp:Label ID="lblOrderName" runat="server" Text="Label" ForeColor="Black" style="z-index: 1; left: 204px; top: 101px; position: absolute"></asp:Label>
    <asp:Label ID="lblUserEmail" runat="server" Text="Label" ForeColor="Black" style="z-index: 1; left: 35px; top: 104px; position: absolute"></asp:Label>
    <asp:Label ID="lblRestaurantEmail" runat="server" Text="Label" ForeColor="Black" style="z-index: 1; left: 349px; top: 101px; position: absolute"></asp:Label>
    <asp:Label ID="lblOrderStatus" runat="server" Text="Label" style="z-index: 1; left: 510px; top: 100px; position: absolute" ForeColor="Black"></asp:Label>
    <asp:Label ID="lblOrderCost" runat="server" Text="Label" ForeColor="Black" style="z-index: 1; left: 669px; top: 100px; position: absolute"></asp:Label>
    <asp:Label ID="lblOrderDate" runat="server" Text="Label" ForeColor="Black" style="z-index: 1; left: 803px; top: 93px; position: absolute"></asp:Label>
    <div id ="ViewOrder" runat="server" style=" position:absolute;top: 140px; width:100%; color:black">
    </div>
</asp:Content>

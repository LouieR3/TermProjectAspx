<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="ViewAllOrders.aspx.cs" Inherits="TermProject_Template.Restaurant.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    View All Orders
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="../images/icons/fav.png" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../css/util.css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="container-login101">
        <div >
            <asp:Label ID="lblOrders" runat="server" Text="Order Information:" ForeColor="Black" Style="z-index: 1; left: 7px; top: 55px; position: absolute"></asp:Label>
            <asp:Label ID="lblOrderName" runat="server" Text="Label" ForeColor="Black" Style="z-index: 1; left: 204px; top: 101px; position: absolute"></asp:Label>
            <asp:Label ID="lblUserEmail" runat="server" Text="Label" ForeColor="Black" Style="z-index: 1; left: 35px; top: 104px; position: absolute"></asp:Label>
            <asp:Label ID="lblRestaurantEmail" runat="server" Text="Label" ForeColor="Black" Style="z-index: 1; left: 349px; top: 101px; position: absolute"></asp:Label>
            <asp:Label ID="lblOrderStatus" runat="server" Text="Label" Style="z-index: 1; left: 510px; top: 100px; position: absolute" ForeColor="Black"></asp:Label>
            <asp:Label ID="lblOrderCost" runat="server" Text="Label" ForeColor="Black" Style="z-index: 1; left: 669px; top: 100px; position: absolute"></asp:Label>
            <asp:Label ID="lblOrderDate" runat="server" Text="Label" ForeColor="Black" Style="z-index: 1; left: 803px; top: 93px; position: absolute"></asp:Label>
            <div id="ViewOrder" runat="server"  class="wrap-login104 p-l-85 p-r-85 p-t-35 p-b-45"></div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="TermProject_Template.Users.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Your Order
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="container-login101 m-t-20">
        <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-45">
            <span class="login100-form-title p-b-32">Order Informatin:</span>
            <asp:Label ID="lblOrderName" runat="server" class="txt10 p-b-11" Text="Label" ForeColor="Black"></asp:Label><br /><br />
            <asp:Label ID="lblUserEmail" runat="server" class="txt10 p-b-11" Text="Label" ForeColor="Black"></asp:Label><br /><br />
            <asp:Label ID="lblRestaurantEmail" runat="server" class="txt10 p-b-11" Text="Label" ForeColor="Black"></asp:Label><br /><br />
            <asp:Label ID="lblOrderStatus" runat="server" class="txt10 p-b-11" Text="Label" ForeColor="Black"></asp:Label><br /><br />
            <asp:Label ID="lblOrderCost" runat="server" class="txt10 p-b-11" Text="Label" ForeColor="Black"></asp:Label><br /><br />
            <asp:Label ID="lblOrderDate" runat="server" class="txt10 p-b-11" Text="Label" ForeColor="Black"></asp:Label><br /><br />
            <div id="ViewOrder" runat="server" class="wrap-login104 p-l-85 p-r-85 p-t-35"></div>
        </div>
    </div>

</asp:Content>


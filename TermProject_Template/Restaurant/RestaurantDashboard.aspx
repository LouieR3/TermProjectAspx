<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantDashboard.aspx.cs" Inherits="TermProject_Template.Restaurant.ResturantDashboard" %>

<%@ Register Src="../CustomControls/RestaurantSettings.ascx" TagPrefix="uc1" TagName="RestaurantSettings" %>
<%@ Register Src="~/CustomControls/EditWallet.ascx" TagPrefix="uc1" TagName="EditWallet" %>
<%@ Register Src="~/CustomControls/WalletBalance.ascx" TagPrefix="uc1" TagName="WalletBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Dashboard
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
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="wrap-login103 p-l-85 p-r-85 p-t-55 p-b-45">
        <uc1:WalletBalance runat="server" ID="WalletBalance" />
    </div>
    <div class="container-login101 m-t-20">
        <div class="wrap-login103 p-l-85 p-r-85 p-t-55 p-b-45">
            <table style="width: 752px">
                <tr>
                    <th>Image</th>
                    <th>Restaurant</th>
                    <th>Email</th>
                    <th>Address</th>
                    <th>Phone Number</th>
                </tr>
                <asp:Repeater ID="rptRest" runat="server" OnItemCommand="repeaterRest_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Image ID="lblRestImage" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "RestImage") %>'></asp:Image>
                            </td>
                            <td>
                                <asp:Label ID="lblRestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestEmail") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestAddress") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestPhone") %>'></asp:Label>
                            </td>
                            <br />
                        </tr>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr>
                    </SeparatorTemplate>
                </asp:Repeater>
            </table>
            <input id="txtHidden" style="width: 28px" type="hidden" value="0" runat="server" />
        </div>
        <div class="container-login101">
            <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-45">
                <uc1:EditWallet runat="server" ID="EditWallet" />
            </div>
            <div class="wrap-login100 contentAlign p-l-85 p-r-85 p-t-65 p-b-55">
                <uc1:RestaurantSettings runat="server" ID="RestaurantSettings" />
            </div>
        </div>
        <asp:PlaceHolder ID="MyPlaceHolder" runat="server" >

        </asp:PlaceHolder>
    </div>
</asp:Content>

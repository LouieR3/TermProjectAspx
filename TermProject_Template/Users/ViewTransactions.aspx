<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="TermProject_Template.Users.ViewTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    View Your Transactions
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
    <!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="container-login101">
        <div class="wrap-login10 p-l-85 p-r-85 p-t-55 p-b-45">
            <span class="login100-form-title p-b-32">Your Transactions</span>
            <asp:GridView class="gv1" ID="gvTransactions" runat="server" ForeColor="Black" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    <asp:BoundField DataField="Type" HeaderText="Type" />
                    <asp:BoundField DataField="CardNumber" HeaderText="Card Number" />
                    <asp:BoundField DataField="MerchantID" HeaderText="Merchant ID" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <asp:Button ID="btnDashboard" class="logButton back2Dash" runat="server" OnClick="btnDashboard_Click" Text="Back to Dashboard" />
        </div>
    </div>
</asp:Content>

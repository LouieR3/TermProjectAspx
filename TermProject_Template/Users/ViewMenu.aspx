<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ViewMenu.aspx.cs" Inherits="TermProject_Template.Users.WebForm2" %>

<%@ Register Src="~/CustomControls/WalletBalance.ascx" TagPrefix="uc1" TagName="WalletBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    View Menu
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
        <div class="wrap-login10 p-l-85 p-r-85 p-t-35 p-b-45">
            <div>
                <uc1:WalletBalance runat="server" ID="WalletBalance" />
            </div>
            <span class="login101-form-title p-t-32 p-b-30">Restaurant Menu</span>
            <asp:Label ID="Label1" class="txt1" runat="server" ForeColor="Black" Text="If you are selecting more than one add on, hold SHIFT or CTRL and select"></asp:Label>
            <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" class="gv" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ItemID" DataField="Menu_ID" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Title" DataField="Item_Name" ItemStyle-HorizontalAlign="Center">
                        <ControlStyle ForeColor="Black" />
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_Type" HeaderText="Category" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:ImageField HeaderText="Image" DataImageUrlField="Item_Photo" ControlStyle-Font-Size="XX-Small" ItemStyle-HorizontalAlign="Center">
                        <ControlStyle ForeColor="Black" />
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:ImageField>
                    <asp:BoundField HeaderText="Price" DataField="Item_Price" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Center">
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Add Ons" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ListBox ID="lbAddOns" runat="server" AutoPostBack="false" SelectionMode="Multiple" ViewStateMode="Enabled"></asp:ListBox>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="White" />
                        <ItemStyle ForeColor="Black" />
                    </asp:TemplateField>
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
            <asp:Button ID="btnPlaceOrder" runat="server" class="logButton placeOrder" Text="Place Order" OnClick="btnPlaceOrder_Click" />
        </div>
    </div>

</asp:Content>

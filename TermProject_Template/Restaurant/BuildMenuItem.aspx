<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="BuildMenuItem.aspx.cs" Inherits="TermProject_Template.Restaurant.BuildMenuItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Create Menu Item
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
        <div class="wrap-login100 p-l-85 p-r-85 p-t-35 p-b-45">
            <asp:Button ID="btnMenu" runat="server" OnClick="btnMenu_Click" class="logButton placeOrder3" Text="Back to Menu" />
            <br />
            <br />
            <asp:Label ID="lblItemName" class="txt1 p-b-11" runat="server" Text="Item Name:" ForeColor="Black"></asp:Label>
            <div class="wrap-input100 validate-input m-b-12">
                <asp:TextBox ID="txtItemName" class="input100" runat="server"></asp:TextBox>
            </div>

            <asp:Label ID="lblItemPrice" class="txt1 p-b-11" runat="server" Text="Item Price:" ForeColor="Black"></asp:Label>
            <div class="wrap-input100 validate-input m-b-12">
                <asp:TextBox ID="txtItemPrice" class="input100" runat="server"></asp:TextBox>
            </div>

            <asp:Label ID="lblItemImage" class="txt1 p-b-11" runat="server" Text="Upload Image:" ForeColor="Black"></asp:Label>
            <div class="wrap-input101 m-b-36">
                <asp:FileUpload ID="fleuplItemImage" runat="server" />
            </div>

            <asp:Label ID="Label1" class="txt1 p-b-11" runat="server" Text="Item Type:" ForeColor="Black"></asp:Label>
            <div class="wrap-input100 validate-input m-b-12">
                <asp:DropDownList ID="ddlType" runat="server" class="input100">
                    <asp:ListItem>Miscellaneous</asp:ListItem>
                    <asp:ListItem>Appetizer</asp:ListItem>
                    <asp:ListItem>Salad</asp:ListItem>
                    <asp:ListItem>Entree</asp:ListItem>
                    <asp:ListItem>Desert</asp:ListItem>
                    <asp:ListItem>Side</asp:ListItem>
                    <asp:ListItem>Drink</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Label ID="lblAddOns" runat="server" Text="Item Add On's:" ForeColor="Black" Visible="False"></asp:Label>

            <asp:Button ID="btnNewAddOn" runat="server" class="logButton" Text="New Add On" OnClick="btnNewAddOn_Click" Visible="False" />
            <div class="wrap-input100 validate-input m-b-12">
                <asp:TextBox ID="txtNewAddOn" runat="server" class="input100" Visible="False"></asp:TextBox>
            </div>

            <asp:Button ID="btnAdd" runat="server" class="logButton" Text="Add" OnClick="btnAdd_Click" Visible="False" />
            <div class="gv">
                <asp:GridView ID="gvAddOn" runat="server" AutoGenerateColumns="False" Visible="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Add_On_Name" HeaderText="Add On's" />
                        <asp:BoundField HeaderText="ItemID" DataField="Add_On_ID" />
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
            </div>
            
            <asp:Button ID="btnCreateItem" runat="server" class="logButton placeOrder3" Text="Create Item" OnClick="btnCreateItem_Click" />
            <asp:Button ID="btnDeleteAddOn" runat="server" class="logButton placeOrder3" Text="Delete Add On" OnClick="btnDeleteAddOn_Click" Visible="False" />
            <asp:Label ID="lblStatus" runat="server" class="txt1 p-b-11" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>

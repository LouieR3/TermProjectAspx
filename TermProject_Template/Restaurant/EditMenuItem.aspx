<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="EditMenuItem.aspx.cs" Inherits="TermProject_Template.Restaurant.EditMenuItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Edit Menu Item
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
    <div class="container-login100 m-t-20">
        <div class="wrap-login10 p-l-85 p-r-85 p-t-35 p-b-45">
            <div class="btnStyle">
                <asp:Button ID="btnMenu" runat="server" OnClick="btnMenu_Click" class="logButton btnStyle" Text="Back to Menu" />
            </div>
            <br />
            <br />

            <asp:Label ID="lblItemName" runat="server" Text="Item Name:" class="txt1 p-b-11" ForeColor="Black"></asp:Label>
            <div class="wrap-input101 validate-input m-b-12">
                <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
            </div>

            <asp:Label ID="lblItemPrice" runat="server" Text="Item Price:" class="txt1 p-b-11" ForeColor="Black"></asp:Label>
            <div class="wrap-input101 validate-input m-b-12">
                <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox>
            </div>

            <asp:Label ID="lblItemImage" runat="server" Text="Upload Image:" class="txt1 p-b-11" ForeColor="Black"></asp:Label>
            <div class="wrap-input101 validate-input m-b-12">
                <asp:FileUpload ID="fleuplItemImage" runat="server" />
            </div>

            <asp:Label ID="lblAddOns" runat="server" Text="Item Add On's:" class="txt1 p-b-11" ForeColor="Black"></asp:Label>

            <asp:Button ID="btnNewAddOn" runat="server" class="logButton" Text="New Add On" OnClick="btnNewAddOn_Click" Enabled="False" />
            <br />
            <br />
            <div class="wrap-input101 validate-input m-b-12">
                <asp:TextBox ID="txtNewAddOn" runat="server" Visible="False"></asp:TextBox>
            </div>

            <asp:Label ID="Label1" runat="server" class="txt1 p-b-11" Text="Item Type:" ForeColor="Black"></asp:Label>
            <div class="wrap-input101 validate-input m-b-12">
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem>Miscellaneous</asp:ListItem>
                    <asp:ListItem>Appetizer</asp:ListItem>
                    <asp:ListItem>Salad</asp:ListItem>
                    <asp:ListItem>Entree</asp:ListItem>
                    <asp:ListItem>Desert</asp:ListItem>
                    <asp:ListItem>Side</asp:ListItem>
                    <asp:ListItem>Drink</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnAdd" runat="server" class="logButton" Text="Add" OnClick="btnAdd_Click" Visible="False" />
            <br />
            <br />
            <div class="gv1">
                <asp:GridView ID="gvAddOn" runat="server" AutoGenerateColumns="False">
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
            <br />
            <br />
            <div class="btnStyle">
                <asp:Button ID="btnEdit" runat="server" class="logButton" Text="Edit" OnClick="btnEdit_Click" />
                <asp:Button ID="btnUpdate" runat="server" class="logButton" Text="Update" Enabled="False" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDeleteAddOn" runat="server" class="logButton" Text="Delete Add On" OnClick="btnDeleteAddOn_Click" Enabled="False" />
            </div>
        </div>
    </div>
</asp:Content>

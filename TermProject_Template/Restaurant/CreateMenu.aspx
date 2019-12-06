<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="CreateMenu.aspx.cs" Inherits="TermProject_Template.Restaurant.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
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
    <asp:Button ID="btnEdit" runat="server" style="z-index: 1; left: 491px; top: 53px; position: absolute; right: 472px;" Text="Edit" OnClick="Button1_Click" />
    <asp:Button ID="btnDelete" runat="server" style="z-index: 1; left: 543px; top: 52px; position: absolute" Text="Delete" Visible="False" OnClick="btnDelete_Click" />
    <asp:Button ID="btnChange" runat="server" style="z-index: 1; left: 615px; top: 52px; position: absolute" Text="Change" Visible="False" OnClick="btnChange_Click" />
    <asp:Button ID="btnNewItem" runat="server" style="z-index: 1; left: 395px; top: 54px; position: absolute" Text="New Item" OnClick="btnNewItem_Click" />
    <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" class="gv" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center" Visible="False">
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
</asp:Content>

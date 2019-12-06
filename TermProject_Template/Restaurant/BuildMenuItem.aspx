<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant/RestaurantAccountMaster.Master" AutoEventWireup="true" CodeBehind="BuildMenuItem.aspx.cs" Inherits="TermProject_Template.Restaurant.BuildMenuItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <asp:Label ID="lblItemPrice" runat="server" Text="Item Price:" style="z-index: 1; left: 96px; top: 166px; position: absolute" ForeColor="Black"></asp:Label>
    
    <asp:TextBox ID="txtItemName" runat="server" style="z-index: 1; left: 193px; top: 87px; position: absolute"></asp:TextBox>
    
    <asp:Label ID="lblItemName" runat="server" Text="Item Name:" style="z-index: 1; left: 103px; top: 86px; position: absolute" ForeColor="Black"></asp:Label>
    
    <asp:TextBox ID="txtItemPrice" runat="server" style="z-index: 1; left: 200px; top: 167px; position: absolute"></asp:TextBox>
    
    <asp:Label ID="lblItemImage" runat="server" Text="Upload Image:" style="z-index: 1; left: 94px; top: 209px; position: absolute" ForeColor="Black"></asp:Label>
    
    <asp:FileUpload ID="fleuplItemImage" runat="server" style="z-index: 1; left: 198px; top: 208px; position: absolute" />

    <asp:Label ID="lblAddOns" runat="server" Text="Item Add On's:" style="z-index: 1; left: 96px; top: 299px; position: absolute; right: 416px;" ForeColor="Black" Visible="False"></asp:Label>
    
    <asp:Button ID="btnNewAddOn" runat="server" style="z-index: 1; left: 294px; top: 307px; position: absolute" Text="New Add On" OnClick="btnNewAddOn_Click" Visible="False" />
    <asp:TextBox ID="txtNewAddOn" runat="server" style="z-index: 1; left: 452px; top: 314px; position: absolute; height: 33px;" Visible="False"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" style="z-index: 1; left: 488px; top: 361px; position: absolute; height: 26px;" Text="Add" OnClick="btnAdd_Click" Visible="False" />
    <asp:GridView ID="gvAddOn" runat="server" AutoGenerateColumns="False" style="z-index: 1; left: 92px; top: 336px; position: absolute; height: 217px; width: 157px" Visible="False">
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
    <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 100px; top: 123px; position: absolute" Text="Item Type:" ForeColor="Black"></asp:Label>
    <asp:DropDownList ID="ddlType" runat="server" style="z-index: 1; left: 192px; top: 123px; position: absolute">
        <asp:ListItem>Miscellaneous</asp:ListItem>
        <asp:ListItem>Appetizer</asp:ListItem>
        <asp:ListItem>Salad</asp:ListItem>
        <asp:ListItem>Entree</asp:ListItem>
        <asp:ListItem>Desert</asp:ListItem>
        <asp:ListItem>Side</asp:ListItem>
        <asp:ListItem>Drink</asp:ListItem>
    </asp:DropDownList>
    
    <asp:Button ID="btnEdit" runat="server" style="z-index: 1; left: 387px; top: 52px; position: absolute" Text="Edit" OnClick="btnEdit_Click" Visible="False" />
    <asp:Button ID="btnUpdate" runat="server" style="z-index: 1; left: 450px; top: 52px; position: absolute" Text="Update" Enabled="False" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnCreateItem" runat="server" style="z-index: 1; left: 96px; top: 250px; position: absolute" Text="Create Item" OnClick="btnCreateItem_Click" />
    <asp:Button ID="btnDeleteAddOn" runat="server" style="z-index: 1; left: 297px; top: 345px; position: absolute" Text="Delete Add On" OnClick="btnDeleteAddOn_Click" Visible="False" />
    <asp:Label ID="lblStatus" runat="server" style="z-index: 1; left: 394px; top: 123px; position: absolute" Text="Label"></asp:Label>
    <asp:Button ID="btnMenu" runat="server" OnClick="btnMenu_Click" style="z-index: 1; left: 16px; top: 60px; position: absolute" Text="Back to Menu" />
</asp:Content>

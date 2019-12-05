<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ViewMenu.aspx.cs" Inherits="TermProject_Template.Users.WebForm2" %>

<%@ Register Src="~/CustomControls/WalletBalance.ascx" TagPrefix="uc1" TagName="WalletBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div>
        <uc1:WalletBalance runat="server" ID="WalletBalance" />
    </div>
    <div>
     <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" style="z-index: 1;padding-bottom:10px; left: 50px; top: 107px; position: absolute; height: 194px; width: 829px; margin-top: 9px;" CellPadding="0" >
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black" />
                        <ItemStyle ForeColor="Black" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Item_Type" HeaderText="Category">
                    <HeaderStyle ForeColor="Black" />
                    <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:ImageField HeaderText="Image" DataImageUrlField="Item_Photo" ControlStyle-Font-Size="XX-Small">
                        <ControlStyle ForeColor="Black" />
                        <HeaderStyle ForeColor="Black" />
                        <ItemStyle ForeColor="Black" />
                    </asp:ImageField>
                    <asp:BoundField HeaderText="Title" DataField="Item_Name" >
                    <ControlStyle ForeColor="Black" />
                    <HeaderStyle ForeColor="Black" />
                    <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Price" DataField="Item_Price" DataFormatString="{0:c}" >
                    <HeaderStyle ForeColor="Black" />
                    <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ItemID" DataField="Menu_ID">
                    <HeaderStyle ForeColor="Black" />
                    <ItemStyle ForeColor="Black" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Add Ons">
                        <ItemTemplate>
                            <asp:ListBox ID="lbAddOns" runat="server" AutoPostBack="false" SelectionMode="Multiple" ViewStateMode="Enabled" ></asp:ListBox>
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black" />
                        <ItemStyle ForeColor="Black" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
     <asp:Button ID="btnPlaceOrder" runat="server" style="z-index: 1; left: 782px; top: 84px; position: absolute" Text="PlaceOrder" OnClick="btnPlaceOrder_Click" />
    <asp:Label ID="Label1" runat="server" ForeColor="Black" style="z-index: 1; left: 41px; top: 82px; position: absolute" Text="Label"></asp:Label>
</asp:Content>


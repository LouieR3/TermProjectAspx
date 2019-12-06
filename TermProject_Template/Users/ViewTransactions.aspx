<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMaster.Master" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="TermProject_Template.Users.ViewTransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <asp:GridView ID="gvTransactions" runat="server"
        style="z-index: 1; left: 120px; top: 153px; position: absolute;
            height: 133px; width: 187px" ForeColor="Black" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="CardNumber" HeaderText="Card Number" />
            <asp:BoundField DataField="MerchantID" HeaderText="Merchant ID" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnDashboard" runat="server" OnClick="btnDashboard_Click" style="z-index: 1; left: 492px; top: 116px; position: absolute" Text="Back to Dashboard" />
    </asp:Content>

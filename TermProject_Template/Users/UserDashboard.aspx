<%@ Page Title="" Language="C#" MasterPageFile="UsersMaster.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="TermProject_Template.Users.WebForm1" %>

<%@ Register src="../CustomControls/AccountSettings.ascx" TagPrefix="uc1" TagName="AccountSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Account Settings
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <uc1:AccountSettings runat="server" id="AccountSettings" />
</asp:Content>

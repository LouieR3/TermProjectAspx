<%@ Page Title="" Language="C#" MasterPageFile="UsersMaster.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="TermProject_Template.Users.WebForm1" %>

<%@ Register Src="../CustomControls/AccountSettings.ascx" TagPrefix="uc1" TagName="AccountSettings" %>
<%@ Register Src="~/CustomControls/EditWallet.ascx" TagPrefix="uc1" TagName="EditWallet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">

    <div class ="Settings">
        <div class="SubSetting" style="background-color:aliceblue">
            <uc1:EditWallet runat="server" ID="EditWallet" />
        </div>
        <div class="SubSetting" style ="background-color:darkgray">
            <uc1:AccountSettings runat="server" ID="AccountSettings" />
        </div>
    </div>
</asp:Content>

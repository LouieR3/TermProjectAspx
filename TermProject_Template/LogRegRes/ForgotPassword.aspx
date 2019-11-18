<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogReg.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TermProject_Template.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Forgot Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div id="forgotPage">
        <asp:Label runat="server" Text="Please Enter Email:" ID="lblEnterEmail" Font-Size="Large" ForeColor="Black"></asp:Label>
        <asp:TextBox runat="server" Class="forgotPasswordText" ID="txtEnterEmail"></asp:TextBox>
        <br />
        <br />
        <asp:Button runat="server" Class="resetButton" Text="Reset Password" ID="btnEnterEmail" OnClick="btnEnterEmail_Click" />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
</asp:Content>

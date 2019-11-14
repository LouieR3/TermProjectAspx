<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogReg.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TermProject_Template.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Forgot Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <asp:label runat="server" text="Please Enter Email:" style="z-index: 1; left: 434px; top: 267px; position: absolute" ID="lblEnterEmail" Font-Size="Large" ForeColor="Black"></asp:label>
    <asp:textbox runat="server" style="z-index: 1; left: 433px; top: 282px; position: absolute" ID="txtEnterEmail"></asp:textbox>
    <asp:button runat="server" text="Button" style="z-index: 1; left: 545px; top: 340px; position: absolute" ID="btnEnterEmail" OnClick="btnEnterEmail_Click"/>
</asp:Content>

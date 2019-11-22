<%@ Page Title="" Language="C#" MasterPageFile="UsersMaster.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="TermProject_Template.Users.WebForm1" %>

<%@ Register Src="../CustomControls/AccountSettings.ascx" TagPrefix="uc1" TagName="AccountSettings" %>
<%@ Register Src="~/CustomControls/EditWallet.ascx" TagPrefix="uc1" TagName="EditWallet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="Restaurants" style="top:70px;padding-bottom:10px;">
        <div>
            <table style="width: 752px">
                <tr style="color:cornsilk; padding-left: 15px;">
                    <th>Image</th>
                    <th>Restaurant</th>
                    <th>Email</th>
                    <th>Address</th>
                    <th>Phone Number</th>
                </tr>
                <asp:Repeater ID="rptRest" runat="server" OnItemCommand="repeaterRest_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblRestImage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestImage") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestEmail") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestAddress") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRestPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestPhone") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnSelect" Text="Select Restaurant" runat="server" />
                            </td>
                            <br />
                        </tr>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr>
                    </SeparatorTemplate>
                </asp:Repeater>
            </table>
        </div>
        <input id="txtHidden" style="width: 28px" type="hidden" value="0"
            runat="server" />
        <hr />
        <asp:LinkButton ID="lnkBtnPrev" runat="server" Font-Underline="False"
            Font-Bold="True" OnClick="lnkBtnPrev_Click"><< Prev </asp:LinkButton>

        <asp:LinkButton ID="lnkBtnNext" runat="server" Font-Underline="False"
            Font-Bold="True" OnClick="lnkBtnNext_Click">Next >></asp:LinkButton>
    </div>
    <div class="Settings" style="top: 280px">
        <div class="SubSetting" style="background-color: aliceblue">
            <uc1:EditWallet runat="server" ID="EditWallet" />
        </div>
        <div class="SubSetting" style="background-color: darkgray">
            <uc1:AccountSettings runat="server" ID="AccountSettings" />
        </div>
    </div>
    <div id ="Orders">

    </div>

</asp:Content>

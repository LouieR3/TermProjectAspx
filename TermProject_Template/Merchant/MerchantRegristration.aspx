<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegristration.aspx.cs" Inherits="TermProject_Template.MerchantRegristration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <link rel="stylesheet" type="text/css" href="CSS/main.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblContactEmail" runat="server" style="z-index: 1; left: 439px; top: 242px; position: absolute" Text="Contact Email" ForeColor="Black"></asp:Label>
        <p>
        <asp:TextBox ID="txtMerchantsName" runat="server" style="z-index: 1; left: 439px; top: 181px; position: absolute"></asp:TextBox>
        </p>
        <asp:Label ID="lblName" runat="server" ForeColor="Black" style="z-index: 1; left: 439px; top: 164px; position: absolute">Enter Merchants Name</asp:Label>
        <asp:Label ID="lblMerchantRegPage" runat="server" Font-Size="X-Large" ForeColor="Black" style="z-index: 1; left: 53px; top: 43px; position: absolute" Text="Merchant Regristration Page"></asp:Label>
        <p>
            &nbsp;</p>
        <asp:TextBox ID="txtContactEmail" runat="server" style="z-index: 1; left: 439px; top: 258px; position: absolute"></asp:TextBox>
        <asp:Button ID="btnEnterMerchant" runat="server" style="z-index: 1; left: 560px; top: 323px; position: absolute; height: 49px; width: 113px;" Text="Button" OnClick="btnEnterMerchant_Click" />
    </form>
</body>
</html>

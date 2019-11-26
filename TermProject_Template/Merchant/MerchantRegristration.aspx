<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantRegristration.aspx.cs" Inherits="TermProject_Template.MerchantRegristration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Merchant Registration</title>
    <meta charset="UTF-8" />
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
</head>
<body>
    <div>
        <ul>
            <li>
                <img class="imageT" src="../images/Temple-T.png" /><a></a></li>
            <li style="padding-left: 20px;"><a>QuickEats</a></li>
        </ul>
    </div>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-45">
                    <div class="login100-form validate-form flex-sb flex-w">
                        <span class="login100-form-title p-b-32">Merchant Registration
                        </span>

                        <span class="txt1 p-b-11">Merchant's Name
                        </span>
                        <div class="wrap-input100 validate-input m-b-36">
                            <asp:TextBox ID="txtMerchantsName" class="input100" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">Contact Email
                        </span>
                        <div class="wrap-input100 validate-input m-b-36">
                            <asp:TextBox ID="txtContactEmail" class="input100" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button ID="btnEnterMerchant" class="logButton" runat="server" Text="Register" OnClick="btnEnterMerchant_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--===============================================================================================-->
        <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
        <!--===============================================================================================-->
        <script src="vendor/animsition/js/animsition.min.js"></script>
        <!--===============================================================================================-->
        <script src="vendor/bootstrap/js/popper.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
        <!--===============================================================================================-->
        <script src="vendor/select2/select2.min.js"></script>
        <!--===============================================================================================-->
        <script src="vendor/daterangepicker/moment.min.js"></script>
        <script src="vendor/daterangepicker/daterangepicker.js"></script>
        <!--===============================================================================================-->
        <script src="vendor/countdowntime/countdowntime.js"></script>
        <!--===============================================================================================-->
        <script src="js/main.js"></script>
    </form>
    <div class="footer">
        <p>Pronto</p>
    </div>
</body>
</html>

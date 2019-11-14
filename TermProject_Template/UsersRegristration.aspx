<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogReg.Master" AutoEventWireup="true" CodeBehind="UsersRegristration.aspx.cs" Inherits="TermProject_Template.UsersRegristration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Register Account
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
    <link rel="stylesheet" type="text/css" href="css/util.css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-40">
                    <form class="login100-form validate-form flex-sb flex-w">
                        <span class="login100-form-title p-b-32">Account Creation
                        </span>

                        <span class="txt1 p-b-11">Name
                        </span>
                        <div class="wrap-input100 validate-input m-b-36" data-validate="Username is required">
                            <asp:TextBox ID="txtCreateName" class="input100" name="name" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">Address
                        </span>
                        <div class="wrap-input100 validate-input m-b-36" data-validate="Address is required">
                            <asp:TextBox ID="txtCreateAddress" class="input100" name="address" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">Phone Number
                        </span>
                        <div class="wrap-input100 validate-input m-b-36" data-validate="Phone Number is required">
                            <asp:TextBox ID="txtCreatePhone" class="input100" name="phone" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">Email used to Confirm
                        </span>
                        <div class="wrap-input100 validate-input m-b-36" data-validate="Email is required">
                            <asp:TextBox ID="txtCreateConfirm" class="input100" name="confirm" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">New Email Address
                        </span>
                        <div class="wrap-input100 validate-input m-b-36" data-validate="Email is required">
                            <asp:TextBox ID="txtCreateEmail" class="input100" name="email" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">Password
                        </span>
                        <div class="wrap-input100 validate-input m-b-12" data-validate="Password is required">
                            <span class="btn-show-pass">
                                <i class="fa fa-eye"></i>
                            </span>
                            <asp:TextBox ID="txtPassword" class="input100" type="password" name="pass" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <span class="txt1 p-b-11">Admin or User?
                        </span>
                        <div class="wrap-input100 validate-input m-b-36" data-validate="User Type is required">
                            <asp:TextBox ID="txtAdminOrUser" class="input100" name="userType" runat="server"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button ID="btnCreateNew" class="login100-form-btn" runat="server" Text="Create New Account" OnClick="btnCreateNew_Click" />
                        </div>

                    </form>
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
</asp:Content>

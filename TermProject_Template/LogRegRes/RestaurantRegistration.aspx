<%@ Page Title="" Language="C#" MasterPageFile="~/LogRegRes/MasterLogReg.Master" AutoEventWireup="true" CodeBehind="RestaurantRegistration.aspx.cs" Inherits="TermProject_Template.LogRegRes.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Register Restaurant
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="../images/icons/fav.png" />
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
    <!--===============================================================================================-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content1" runat="server">
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login101 p-l-85 p-r-85 p-t-55 p-b-45">
                <div class="login100-form validate-form flex-sb flex-w">
                    <span class="login100-form-title p-b-32">Register Restaurant
                    </span>

                    <span class="txt1 p-b-11">Restaurant Name
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtRName" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Contact Email
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtContactEmail" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Restaurant Address
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtRAddress" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Phone Number
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtRPhone" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Bank Name
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtBankName" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Card Type
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:DropDownList ID="ddlCardType" class="input100" runat="server">
                            <asp:ListItem Value="Credit"> Credit </asp:ListItem>
                            <asp:ListItem Value="Debit"> Debit </asp:ListItem>
                        </asp:DropDownList>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Card Number
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtCardNum" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Restaurant Image
                    </span>
                    <div class="wrap-input101 m-b-36">
                        <asp:FileUpload ID="fuImage" runat="server" />
                    </div>
                    
                    <span class="txt1 p-b-11">Password
                    </span>
                    <div class="wrap-input100 validate-input m-b-12">
                        <span class="btn-show-pass">
                            <i class="fa fa-eye"></i>
                        </span>
                        <asp:TextBox ID="txtRPass" class="input100" type="password" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="container-login102-form-btn">
                        <asp:Button ID="btnCreateRestuarant" class="logButton" runat="server" Text="Create Account" OnClick="btnCreateRestuarant_Click" />
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
</asp:Content>

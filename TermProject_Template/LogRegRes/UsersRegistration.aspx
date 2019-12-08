<%@ Page Title="" Language="C#" MasterPageFile="MasterLogReg.Master" AutoEventWireup="true" CodeBehind="UsersRegistration.aspx.cs" Inherits="TermProject_Template.UsersRegristration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Create Account
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
                    <span class="login100-form-title p-b-32">Account Creation
                    </span>

                    <span class="txt1 p-b-11">First Name
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtFirstName" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Last Name
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtLastName" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">LoginID (Optional)
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtLoginID" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Email
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtCreateEmail" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <!--
                    <span class="txt1 p-b-11">State
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:DropDownList ID="ddlState" class="input100" runat="server">
                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                            <asp:ListItem Value="CA">California</asp:ListItem>
                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                            <asp:ListItem Value="DE">Delaware</asp:ListItem>
                            <asp:ListItem Value="FL">Florida</asp:ListItem>
                            <asp:ListItem Value="GA">Georgia</asp:ListItem>
                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                            <asp:ListItem Value="IL">Illinois</asp:ListItem>
                            <asp:ListItem Value="IN">Indiana</asp:ListItem>
                            <asp:ListItem Value="IA">Iowa</asp:ListItem>
                            <asp:ListItem Value="KS">Kansas</asp:ListItem>
                            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                            <asp:ListItem Value="ME">Maine</asp:ListItem>
                            <asp:ListItem Value="MD">Maryland</asp:ListItem>
                            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                            <asp:ListItem Value="MI">Michigan</asp:ListItem>
                            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                            <asp:ListItem Value="MO">Missouri</asp:ListItem>
                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                            <asp:ListItem Value="NY">New York</asp:ListItem>
                            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                            <asp:ListItem Value="OH">Ohio</asp:ListItem>
                            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                            <asp:ListItem Value="TX">Texas</asp:ListItem>
                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                            <asp:ListItem Value="VT">Vermont</asp:ListItem>
                            <asp:ListItem Value="VA">Virginia</asp:ListItem>
                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                        <span class="focus-input100"></span>
                    </div>
                    -->

                    <span class="txt1 p-b-11">Billing Address
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtBilling" class="input100" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">Delivery Address
                    </span>
                    <div class="wrap-input100 validate-input m-b-36">
                        <asp:TextBox ID="txtDelivery" class="input100" runat="server"></asp:TextBox>
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

                    <span class="txt1 p-b-11">Password
                    </span>
                    <div class="wrap-input100 validate-input m-b-12">
                        <span class="btn-show-pass">
                            <i class="fa fa-eye"></i>
                        </span>
                        <asp:TextBox ID="txtCreatePW" class="input100" type="password" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="container-login102-form-btn">
                        <asp:Button ID="btnCreateAccount" class="logButton" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
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

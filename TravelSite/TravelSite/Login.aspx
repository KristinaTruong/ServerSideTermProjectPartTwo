<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravelSite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <style>
        @CHARSET "UTF-8";


        * {
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
            outline: none;
        }

        body {
            background-image: url("image/ZackRoifLandscapePhotography.jpg");
            background-repeat: no-repeat;
            background-size: cover;
        }

        .login-form {
            text-align: center;
            margin: 0 auto;
            margin-top: 40px;
            margin-bottom: 40px;
            max-width: 460px;
        }

            .login-form > section {
                padding: 35px 35px 25px 35px;
                border-radius: 5px;
            }

            .login-form a {
                color: white;
            }

            .login-form img {
                display: block;
                margin: 0 auto;
                margin-bottom: 55px;
            }

        form[role=login] {
            font: 14px/2.2em Lato, serif;
            color: white;
        }

            form[role=login] input,
            form[role=login] > button {
                font-size: 15px;
                padding: 10px 30px;
            }

            form[role=login] input {
                color: #777;
                background: rgba(255,255,255,255);
                border: none;
                height: 2.6em;
                padding: 10px 40px;
                border-radius: 3px;
                -webkit-box-shadow: inset 0 0 1px 1px rgba(150, 150, 150, .1);
                -moz-box-shadow: inset 0 0 1px 1px rgba(150, 150, 150, .1);
                box-shadow: inset 0 0 1px 1px rgba(150, 150, 150, .1);
            }

            form[role=login] > div {
                margin: 30px 0;
                position: relative;
            }

        #btnLogin {
            margin-top: 12px;
            margin-bottom: 12px;
            border: 1px solid #0c4584;
        }

        form[role=login] > button {
            margin-top: 12px;
            margin-bottom: 12px;
            background: #0c56a9;
            border: 1px solid #0c4584;
        }

        .form-control + .glyphicon {
            position: absolute;
            left: 0;
            top: 10%;
            padding: 8px 0 0 17px;
            font-size: 15px;
            color: black;
        }

        #log {
            background-color: darkgray;
            opacity: 0.85;
        }

        #hr {
            padding-bottom: -200px;
            padding-top: -200px;
            color: red;
        }

        #wrongPassword {
            display: none;
        }
    </style>
</head>
<body>

    <section class="container login-form">
        <section id="log">
            <form method="post"  runat="server">
                <img src="image/KJ LOGO smaller.png" alt="" class="img-responsive" />

                <div class="alert alert-danger" role="alert" runat="server" id="wrongPassword">
                    ERROR: The username or password is incorrect
                </div>
                <div class="form-group">
                    <span class="glyphicon glyphicon-user" style="display:inline; padding-right:20px;"></span><asp:TextBox style="display:inline;" ID="txtUserNm" runat="server" class="form-control" placeHolder="User Name" ValidationGroup="validLogin" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="validatorUsername" runat="server" ControlToValidate="txtUserNm" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validLogin"></asp:RequiredFieldValidator>
                    
                </div>

                <div class="form-group">
                    <span class="glyphicon glyphicon-lock" style="display:inline;padding-right:20px"></span><asp:TextBox style="display:inline;" ID="txtPassword" runat="server" class="form-control" placeHolder="Password" ValidationGroup="validLogin" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="validatorPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validLogin"></asp:RequiredFieldValidator>
                    
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-bloc" OnClick="btnLogin_Click" ValidationGroup="validLogin"></asp:Button>

                <input type="checkbox" checked="checked" name="remember" runat="server" id="rememberMe" class="btn btn-primary btn-bloc" />
                Remember me<br />
                <hr />


                <asp:LinkButton ID="lbtnCreateAccount" runat="server" ForeColor="Black" OnClick="lbtnCreateAccount_Click">Don't have an account?</asp:LinkButton>
                <br />

            </form>
        </section>
    </section>

</body>
</html>


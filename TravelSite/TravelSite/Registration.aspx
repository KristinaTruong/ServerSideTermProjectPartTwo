﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TravelSite.Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Teko">
    <title></title>
    
    <style>
        * {
            font-family: 'Teko', Arial;
            font-size: 19px;
        }

        body {
            background-image: url(image/ZackRoifLandscapePhotography.jpg);
            background-size: cover;
            background-attachment: fixed;
        }

        form {
            padding: 30px;
            font-family: 'Agency FB',Arial;
            font-size: 19px;
            background-color: white;
            opacity: 0.9;
            width: 80%;
            margin: auto;
            max-width: 100%;
            height: 100%;
            max-height: 100%;
            margin-top: 30px;
            margin-bottom: 30px;
        }

        #footer {
            width: auto;
            max-width: 100%;
            background-color: #343a40;
            color: white;
            text-align: left;
            padding: 20px;
            margin-top: 60px;
        }

        nav a {
            color: white;
            text-decoration: none;
            padding-left: 5px;
            padding-right: 5px;
        }

        #footer a {
            color: deepskyblue;
            text-decoration: none;
            padding-left: 5px;
            padding-right: 5px;
        }

        nav a:hover {
            color: deepskyblue;
            text-decoration: none;
            padding-left: 5px;
            padding-right: 5px;
        }

        #footer a:hover {
            color: black;
            text-decoration: none;
            padding-left: 5px;
            padding-right: 5px;
        }
    </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="font-size: 20px;">
        <a class="navbar-brand" href="#">
            <img src="image/KJ%20LOGO%20smaller%202.png" />
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
            </ul>
        </div>
    </nav>
    <div class="contentBody">
        <div class="row" style="margin: 0px;">
            <div class="col">
                <form id="travelForm" runat="server">
                    <div>
                        <br />
                        Full Name<br />
                        <asp:TextBox ID="txtCustomerName" runat="server" ValidationGroup="validRegister" Width="311px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorName" runat="server" ControlToValidate="txtCustomerName" ErrorMessage="*Required" ForeColor="Red" SetFocusOnError="True" ValidationGroup="validRegister">*Required</asp:RequiredFieldValidator>
                        <br />
                        Phone Number<br />
                        <asp:TextBox ID="txtCustomerPhone" runat="server" ValidationGroup="validRegister" Width="315px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorPhone" runat="server" ControlToValidate="txtCustomerPhone" ErrorMessage="*Required" ForeColor="Red" ValidationGroup="validRegister">*Required</asp:RequiredFieldValidator>
                        <br />
                        Email Address<br />
                        <asp:TextBox ID="txtCustomerEmail" runat="server" ValidationGroup="validRegister" Width="311px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorEmail" runat="server" ControlToValidate="txtCustomerEmail" ErrorMessage="*Required" ForeColor="Red" ValidationGroup="validRegister">*Required</asp:RequiredFieldValidator>
                        <br />
                        Payment Information<br />
                        <asp:TextBox ID="txtCustomerPayment" runat="server" ValidationGroup="validRegister" Width="311px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validatorPayment" runat="server" ControlToValidate="txtCustomerEmail" ErrorMessage="*Required" ForeColor="Red" ValidationGroup="validRegister">*Required</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Button ID="btnRegister" runat="server" BackColor="#343A40" BorderStyle="Solid" ForeColor="White" OnClick="btnRegister_Click" Text="Register" ValidationGroup="validRegister" Width="316px" />
                        <br />
                        <div id="testing" runat="server" style="max-width:600px;">

                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <div id="footer">
        <div class="container">
            <div class="row">
                <div class="col-1" style="vertical-align: middle;">
                    <img src="image/KJ%20LOGO%20smaller.png" /><br />
                    <br />
                </div>
                <div class="col-1">
                </div>
                <div class="col-2">
                    <a href="#">About Us</a><br />
                    <a href="#">Our Vision</a><br />
                    <a href="#">Blog</a>
                </div>
                <div class="col-2">
                    <a href="TOS.aspx">Terms Of Service</a><br />
                    <a href="#">Help Desk</a>
                </div>
                <div class="col-2" style="font-size: 15px;">
                    215-555-5555<br />
                    123 Maple Street<br />
                    Philadelphia, PA 19231
                </div>
                <div class="col-2">
                    <img src="image/nortonSmall.png" />
                </div>
                <div class="col-2">
                    Jinal Gadhiya<br />
                    Kristina Truong
                    <br />
                    ©2018
                </div>

            </div>
        </div>
    </div>
</body>

</html>

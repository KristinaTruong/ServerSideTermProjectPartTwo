﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="TravelSite.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #btnSave, #btnEdit {
            width: 40%;
        }
        .row{
            margin-top:10px;
            margin-bottom:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Account</h1>
    *NOTE: Your email is your login username, if it is changed, you must use that to login next time!
    <div id="successMessage" class="alert alert-success" role="alert" runat="server" visible="false">
  SUCCESS! Your account was updated
</div>
    <div class="row">
        <div class="col">
            <!-- name, address, phone -->
            <div class="row">
                <div class="col-2">Name:</div>
                <div class="col-10">
                    <asp:TextBox ID="txtName" style="width:60%;" runat="server" ValidationGroup="validationGroup" Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valName" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtName">*Required</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-2">Address:</div>
                <div class="col-10">
                    <asp:TextBox ID="txtAddress" style="width:60%;" runat="server" ValidationGroup="validationGroup" Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valAddress" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtAddress">*Required</asp:RequiredFieldValidator>
                </div>
                
            </div>
            <div class="row">
                <div class="col-2">Phone:</div>
                <div class="col-10">
                <asp:TextBox ID="txtPhone"  style="width:60%;" runat="server" ValidationGroup="validationGroup" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPhone" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtPhone">*Required</asp:RequiredFieldValidator>
            </div>
                </div>
        </div>
        <div class="col">
             <div class="row">
                <div class="col-2">Email:</div>
                <div class="col-10"><asp:TextBox ID="txtEmail" style="width:60%;" runat="server" SValidationGroup="validationGroup" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valEmail" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtEmail">*Required</asp:RequiredFieldValidator><br />
</div>
             </div>
            <div class="row">
                <div class="col-2">Payment:</div>
                <div class="col-10"><asp:TextBox ID="txtPayment" style="width:60%;" runat="server" SValidationGroup="validationGroup" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valPayment" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtEmail">*Required</asp:RequiredFieldValidator><br />
</div>
             </div>
            <div class="row">
                <div class="col-2">Password:</div>
                <div class="col-10"><asp:TextBox ID="txtPassword" style="width:60%;" runat="server"  ValidationGroup="validationGroup" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtPassword">*Required</asp:RequiredFieldValidator><br />
</div>
             </div>
           
                
            
        </div>

    </div>



    <div class="container container-fluid">
    <div class="row">
        <div class="col"><asp:Button ID="btnEdit" class="btn btn-dark"
                runat="server" Text="Edit" Style="width: 100%;" OnClick="btnEditClick" /></div>
        <div class="col">
            <asp:Button ID="btnSave" class="btn btn-dark" 
                runat="server" Text="Save Changes" style="width:100%;" Enabled="false" ValidationGroup="validationGroup" CausesValidation="true" OnClick="btnSave_Click"/></div>

    </div></div>
</asp:Content>

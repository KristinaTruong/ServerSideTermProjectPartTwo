<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Experience.aspx.cs" Inherits="TravelSite.Experience" %>

<%@ Register Src="~/PageTemplateASCX.ascx" TagPrefix="uc1" TagName="PageTemplateASCX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #btnSearch, #btnAdd {
            width: 40%;
        }
        .nav-link:hover{
            background-color:gray;
            color:black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PageTemplateASCX runat="server" ID="PageTemplateASCX" />
</asp:Content>

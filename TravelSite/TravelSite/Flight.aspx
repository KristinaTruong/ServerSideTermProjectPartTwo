<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Flight.aspx.cs" Inherits="TravelSite.Flight" %>

<%@ Register Src="~/PageTemplateASCX.ascx" TagPrefix="uc1" TagName="PageTemplateASCX" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    
    <uc1:PageTemplateASCX runat="server" ID="PageTemplateASCX" />
</asp:Content>

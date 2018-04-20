<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="PackagePageTemplate.aspx.cs" Inherits="TravelSite.PackagePageTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #btnSearch, #btnAdd {
            width: 40%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>[TITLE]</h1>
    <div id="searchSection" runat="server">
        <div class="row">
            <div class="col">
                COLUMN 1
            </div>
            <div class="col">
                COLUMN 2
               
            </div>
        </div>
    </div>
    <div class="container container-fluid">
    <div class="row">
        <div class="col"><asp:Button ID="btnSearch" class="btn btn-dark"
                runat="server" Text="Search" Style="width: 100%;" /></div>
        <div class="col">
            <asp:Button ID="btnAdd" class="btn btn-dark" 
                runat="server" Text="Add" style="width:100%;"/></div>

    </div></div>
    <asp:GridView ID="gvAvailable" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No results were found." ForeColor="Black" GridLines="Horizontal">
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>

</asp:Content>

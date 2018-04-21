<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="TravelSite.Car" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1>Car Rental</h1>
    <div id="searchSection" runat="server">
        <div class="row">
            <div class="col">
                COLUMN 1
                <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="validationGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="val1" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="TextBox2">*Required</asp:RequiredFieldValidator>
            </div>
            <div class="col">
                COLUMN 2
               
                <asp:TextBox ID="TextBox3" runat="server" ValidationGroup="validationGroup"></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="val2" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="TextBox3">*Required</asp:RequiredFieldValidator>
               
            </div>
        </div>
    </div><br />
    <br />
    <div class="container container-fluid">
    <div class="row">
        <div class="col"><asp:Button ID="btnSearch" class="btn btn-dark"
                runat="server" Text="Search" Style="width: 100%;" OnClick="btnSearch_Click" ValidationGroup="validationGroup" /></div>
        <div class="col">
            <asp:Button ID="btnAdd" class="btn btn-dark" 
                runat="server" Text="Add" style="width:100%;display:none;"/></div>
        <br />
    </div></div><br />
    <asp:GridView ID="gvAvailable" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No results were found." ForeColor="Black" GridLines="Horizontal" Width="100%" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CarID" Visible="False" />
            <asp:BoundField DataField="Make" HeaderText="Make" />
            <asp:BoundField DataField="Model" HeaderText="Model" />
            <asp:BoundField DataField="Year" HeaderText="Year" />
            <asp:BoundField DataField="Type" HeaderText="Type" />
            <asp:BoundField DataField="Color" HeaderText="Color" />
            <asp:BoundField DataField="PricePerDay" HeaderText="Rate" />
        </Columns>
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

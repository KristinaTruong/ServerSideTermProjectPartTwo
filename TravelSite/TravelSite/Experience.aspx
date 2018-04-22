<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Experience.aspx.cs" Inherits="TravelSite.Experience" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      #btnSearch, #btnAdd {
            width: 40%;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1>Experience</h1>
     <div id="successfulAdd" runat="server" style="display:none;" class="alert alert-success" role="alert">
  SUCCESS! Your items have  successfully added to your vacation package!
</div>
<div id="failedAdd" runat="server" style="display:none;" class="alert alert-danger" role="alert">
  ERROR! No items were selected. Please select at least one item to add
</div>
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
    </div>
    <br />
    <div class="container container-fluid">
        <div class="row">
            <div class="col">
                <asp:Button ID="btnSearch" class="btn btn-dark"
                    runat="server" Text="Search" Style="width: 100%;" OnClick="btnSearch_Click" ValidationGroup="validationGroup" />
            </div>
            <div class="col">
                <asp:Button ID="btnAdd" class="btn btn-dark"
                    runat="server" Text="Add" Style="width: 100%; display: none;" OnClick="btnAdd_Click"/>
            </div>
            <br />
        </div>
    </div>
    <br />
    <asp:GridView ID="gvAvailable" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No results were found." ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" TextAlign="Left" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Agency_Id" Visible="False" />
            <asp:BoundField DataField="Agency_Name" HeaderText="Name" />
            <asp:BoundField DataField="Agency_City" HeaderText="City" />
            <asp:BoundField DataField="Agency_State" HeaderText="State" />
            <asp:BoundField DataField="Agency_Zip" HeaderText="Zip" />
            <asp:BoundField DataField="Agency_Phone" HeaderText="Phone" />
            <asp:BoundField DataField="Agency_Email" HeaderText="Email" />
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

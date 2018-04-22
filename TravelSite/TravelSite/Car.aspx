<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="TravelSite.Car" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Car Rental</h1>
    <div id="successfulAdd" runat="server" style="display:none;" class="alert alert-success" role="alert">
  SUCCESS! Your items have  successfully added to your vacation package!
</div>
<div id="failedAdd" runat="server" style="display:none;" class="alert alert-danger" role="alert">
  ERROR! No items were selected. Please select at least one item to add
</div>
    <div id="searchSection" runat="server">
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col-2">City:</div>
                    <div class="col-10">
                        <asp:TextBox ID="txtCity" runat="server" ValidationGroup="validationGroup"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valCity" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtCity">*Required</asp:RequiredFieldValidator>
                    </div>
                    </div><div class="row">
                    <div class="col-2">State:</div>
                    <div class="col-10">
                        <asp:TextBox ID="txtState" runat="server" ValidationGroup="validationGroup"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valState" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtState">*Required</asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">Agency:</div>
                    <div class="col-10"> <asp:TextBox ID="txtAgency" runat="server" ValidationGroup="validationGroup"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valAgency" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtAgency">*Required</asp:RequiredFieldValidator>
                    </div></div>
            </div>
            <div class="col">
                <div class="row">

                    <div class="col-2">Requirement:</div>
                    <div class="col-10"><asp:TextBox ID="txtRequirement" runat="server" ValidationGroup="validationGroup"></asp:TextBox>

                <asp:RequiredFieldValidator ID="valRequirement" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtRequirement">*Required</asp:RequiredFieldValidator>
</div>
               </div>
                
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

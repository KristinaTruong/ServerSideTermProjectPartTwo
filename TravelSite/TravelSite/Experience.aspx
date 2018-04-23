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
    <div id="successfulAdd" runat="server" style="display: none;" class="alert alert-success" role="alert">
        SUCCESS! Your items have  successfully added to your vacation package!
    </div>
    <div id="failedAdd" runat="server" style="display: none;" class="alert alert-danger" role="alert">
        ERROR! No items were selected. Please select at least one item to add
    </div>
    <div id="searchSection" runat="server">
        <div class="row">
            <div class="col">
                 <!-- name, address, phone -->
            <div class="row">
                <div class="col-2">City:</div>
                <div class="col-10">
                    <asp:TextBox ID="txtCity" style="width:60%;" runat="server" ValidationGroup="validationGroup" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCity" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtCity">*Required</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-2">State:</div>
                <div class="col-10">
                    <asp:TextBox ID="txtState" style="width:60%;" runat="server" ValidationGroup="validationGroup" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valState" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtState">*Required</asp:RequiredFieldValidator>
                </div>
                
            </div>
            <div class="row">
                <div class="col-2">Agency:</div>
                <div class="col-10">
                <asp:TextBox ID="txtAgency"  style="width:60%;" runat="server" ValidationGroup="validationGroup" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="valAgency" runat="server" ErrorMessage="*Required" ForeColor="#CC0000" ValidationGroup="validationGroup" ControlToValidate="txtAgency">*Required</asp:RequiredFieldValidator>
            </div>
                </div>
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
                    runat="server" Text="Add" Style="width: 100%;" OnClick="btnAdd_Click" Enabled="False" />
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
            <asp:BoundField DataField="Agency_Id" HeaderText="Agency ID" Visible="true"/>
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

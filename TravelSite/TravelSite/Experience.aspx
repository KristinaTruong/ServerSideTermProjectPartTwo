<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Experience.aspx.cs" Inherits="TravelSite.Experience" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #btnSearch, #btnAdd {
            width: 40%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ERROR MESSAGES -------------------------------------------------------------------------------->
    <h1>Experience</h1>
    <!-- IF SUCESSFULLY ADDED -->
    <div id="successfulAdd" runat="server" style="display: none;" class="alert alert-success" role="alert">
        SUCCESS! Your items have  successfully added to your vacation package
    </div>
    <!-- IF ADD FAILED -->
    <div id="failedAdd" runat="server" style="display: none;" class="alert alert-danger" role="alert">
        ERROR! No items were selected. Please select at least one item to add
    </div>
    <!-- IF SEARCH CRITERIA IS INVALID -->
    <div id="failedSearch" runat="server" style="display: none;" class="alert alert-danger" role="alert">
        ERROR! Search criteria is invalid
    </div>
    <!--  -------------------------------------------------------------------------------------------------->
    <!--  -------------------------------------------------------------------------------------------------->

    <div id="searchSection" runat="server">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header" style="background-color: #343a40; color: white;">
                        REQUIRED
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                CITY<br />
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><div id="valCity" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- SECTION TEMPLATE --------------------------------------------------------------------------------------
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header" style="background-color: #343a40; color: white;">
                        [SECTION TITLE]
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                [FIELD]<br />
                                <asp:TextBox ID="item" runat="server"></asp:TextBox><div id="valItem" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!---------------------------------------------------------------------------------------------------------->

    </div>


    <br />
    <!----------- BUTTONS -------------------------------------------------------------------------------->
    <div class="container container-fluid">
        <div class="row">
            <div class="col">
                <asp:Button ID="btnSearch" class="btn btn-primary"
                    runat="server" Text="Search" Style="width: 100%;" OnClick="btnSearch_Click" ValidationGroup="validationGroup" />
            </div>
            <div class="col">
                <asp:Button ID="btnAdd" class="btn btn-primary"
                    runat="server" Text="Add" Style="width: 100%;" OnClick="btnAdd_Click" Enabled="False" />
            </div>
            <br />
        </div>
    </div>
    <!--------------------------------------------------------------------------------------------------->
    <!----- GRIDVIEW ----------------------------------------------------------------------------->
    <br />
    <asp:GridView ID="gvAvailable" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No results were found." ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" TextAlign="Left" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Agency_Id" HeaderText="Agency ID" Visible="true" />
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
    <!--------------------------------------------------------------------------------------------------->
</asp:Content>

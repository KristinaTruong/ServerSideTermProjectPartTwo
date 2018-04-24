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
    <!-- SEARCH MENU -->
    <ul class="nav nav-tabs">
  <li class="nav-item">
    <a class="nav-link active" id="navDefault" href="#" runat="server" onserverclick="displayDefault" >Default</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="navAgency" href="#" runat="server" onserverclick="displayAgency">By Agency</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="navActivity" href="#" runat="server" onserverclick="displayActivity">By Activity Type</a>
  </li>
        <li class="nav-item">
    <a class="nav-link" id="navAgencyAndActivity" href="#" runat="server" onserverclick="displayAgencyAndActivity">By Agency & Activity Type</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="navVenue" href="#" runat="server" onserverclick="displayVenue">By Venue</a>
  </li>
</ul>
    <!----------------------------------------------------------------------------------------------------->

    <div id="searchSection" runat="server">
        <!-- REQUIRED CRITERIA -->
            <div class="row" id="searchDefault" runat="server" > 
                <div class="col">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    CITY<br />
                                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><div id="valCity" style="display: none; color: red;" runat="server">*Required</div>
                                </div>
                                <div class="col">
                                    STATE<br />
                                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox><div id="valState" style="display: none; color: red;" runat="server">*Required</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <!-- SEARCH BY AGENCY -->
        <div class="row" id="searchAgency" runat="server" style="display:none;">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                Agency ID<br />
                                <asp:TextBox ID="txtAgencyID" runat="server"></asp:TextBox><div id="valAgencyID" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- SEARCH BY AGENCY -->
        <div class="row" id="searchActivity" runat="server" style="display:none;">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                Activity ID<br />
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><div id="Div2" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- SEARCH BY ACTIVITY AND AGENCY-->
        <div class="row" id="searchAgencyAndActivity" runat="server" style="display:none;">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                Agency ID<br />
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><div id="Div3" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                            <div class="col">
                                Activity ID<br />
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><div id="Div1" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- SEARCH BY VENUE-->
        <div class="row" id="searchVenue" runat="server" style="display:none;">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                Venue ID<br />
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><div id="Div4" style="display: none; color: red;" runat="server">*Required</div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- SECTION TEMPLATE --------------------------------------------------------------------------------------
        <div class="row" id="sectionName" runat="server" style="display:none;">
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
    <asp:GridView ID="gvAvailable" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        EmptyDataText="No results were found." ForeColor="Black" GridLines="Horizontal" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" TextAlign="Left" />
                </ItemTemplate>
            </asp:TemplateField>
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

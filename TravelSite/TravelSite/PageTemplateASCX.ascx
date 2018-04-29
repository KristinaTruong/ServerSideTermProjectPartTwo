<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageTemplateASCX.ascx.cs" Inherits="TravelSite.PageTempleASCX" %>

<!-- ERROR MESSAGES -------------------------------------------------------------------------------->
<h1 id="pagetitle" runat="server">Experience</h1>
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
<div id="noResults" runat="server" style="display: none;" class="alert alert-danger" role="alert">
    ERROR! No results were found
</div>
<!--  -------------------------------------------------------------------------------------------------->
<!--  -------------------------------------------------------------------------------------------------->
<!-- SEARCH MENU -->
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link active" id="navDefault" href="#" runat="server" onserverclick="displayDefault">Default</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" id="navAgency" href="#" runat="server" onserverclick="display2">By Agency</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" id="navActivity" href="#" runat="server" onserverclick="display3">By Activity Type</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" id="navAgencyAndActivity" href="#" runat="server" onserverclick="display4">By Agency & Activity Type</a>
    </li>
    <li class="nav-item">
        <a class="nav-link active" id="navSearch4" href="#" runat="server" onserverclick="display5">Search 5</a>
    </li>
</ul>
<!----------------------------------------------------------------------------------------------------->

<div id="searchSection" runat="server">
    <!-- Introduction -->
    <div class="row" id="introSection" runat="server">
        <div class="col">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">

                            <br />
                            <br />

                            To get started, please click a search filter above!
                                    <br />

                            <br />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- REQUIRED CRITERIA -->
    <div class="row" id="searchDefault" runat="server" style="display: none;">
        <div class="col">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <div id="cityCriteria" runat="server">CITY</div>
                            <br />
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><div id="valCity" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="stateCriteria" runat="server">STATE</div>
                            <br />
                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox><div id="valState" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="txtbox1Heading" runat="server">BOX 1</div>
                            <br />
                            <asp:TextBox ID="txtbox1" runat="server"></asp:TextBox><div id="valtxtbox1" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="txtbox2Heading" runat="server">BOX 2</div>
                            <br />
                            <asp:TextBox ID="txtbox2" runat="server"></asp:TextBox><div id="valtxtbox2" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- SEARCH BY AGENCY -->
    <div class="row" id="search2" runat="server" style="display: none;">
        <div class="col">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <div id="txtbox3Heading" runat="server">BOX 3</div>
                            <br />
                            <asp:TextBox ID="txtbox3" runat="server"></asp:TextBox><div id="valtxtbox3" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="txtbox4Heading" runat="server">BOX 4</div>
                            <br />
                            <asp:TextBox ID="txtbox4" runat="server"></asp:TextBox><div id="valtxtbox4" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="txtbox5Heading" runat="server">BOX 5</div>
                            <br />
                            <asp:TextBox ID="txtbox5" runat="server"></asp:TextBox><div id="valtxtbox5" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- SEARCH BY ACTIVITY -->
    <div class="row" id="search3" runat="server" style="display: none;">
        <div class="col">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                     
                            <div class="col">
                                <div id="txtbox6Heading" runat="server">BOX 6</div>
                                <br />
                                <asp:TextBox ID="txtbox6" runat="server"></asp:TextBox><div id="valtxtbox6" style="display: none; color: red;" runat="server">*Required</div>
                            </div>
                            <div class="col">
                                <div id="txtbox7Heading" runat="server">BOX 7</div>
                                <br />
                                <asp:TextBox ID="txtbox7" runat="server"></asp:TextBox><div id="valtxtbox7" style="display: none; color: red;" runat="server">*Required</div>
                            </div>
                            <div class="col">
                                <div id="txtbox8Heading" runat="server">BOX 8</div>
                                <br />
                                <asp:TextBox ID="txtbox8" runat="server"></asp:TextBox><div id="valtxtbox8" style="display: none; color: red;" runat="server">*Required</div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <!-- SEARCH BY ACTIVITY AND AGENCY-->
        <div class="row" id="search4" runat="server" style="display: none;">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div id="txtbox9Heading" runat="server">BOX 9</div>
                                <br />
                                <asp:TextBox ID="txtbox9" runat="server"></asp:TextBox><div id="valtxtbox9" style="display: none; color: red;" runat="server">*Required</div>
                            </div>
                            <div class="col">
                                <div id="txtbox10Heading" runat="server">BOX 10</div>
                                <br />
                                <asp:TextBox ID="txtbox10" runat="server"></asp:TextBox><div id="valtxtbox10" style="display: none; color: red;" runat="server">*Required</div>
                            </div>
                            <div class="col">
                                <div id="txtbox11Heading" runat="server">BOX 11</div>
                                <br />
                                <asp:TextBox ID="txtbox11" runat="server"></asp:TextBox><div id="valtxtbox11" style="display: none; color: red;" runat="server">*Required</div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    <!-- SEARCH 4 -->
    <div class="row" id="search5" runat="server" style="display: none;">
        <div class="col">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <div id="txtbox12Heading" runat="server">BOX 12</div>
                            <br />
                            <asp:TextBox ID="txtbox12" runat="server"></asp:TextBox><div id="valtxtbox12" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="txtbox13Heading" runat="server">BOX 13</div>
                            <br />
                            <asp:TextBox ID="txtbox13" runat="server"></asp:TextBox><div id="valtxtbox13" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                        <div class="col">
                            <div id="txtbox14Heading" runat="server">BOX 14</div>
                            <br />
                            <asp:TextBox ID="txtbox14" runat="server"></asp:TextBox><div id="valtxtbox14" style="display: none; color: red;" runat="server">*Required</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <!-- SEARCH BY VENUE-->
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
            <div class="container container-fluid" id="buttonSection" style="visibility: hidden;" runat="server">
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
                EmptyDataText="No results were found." ForeColor="Black" GridLines="Horizontal" Width="100%" ViewStateMode="Enabled">
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

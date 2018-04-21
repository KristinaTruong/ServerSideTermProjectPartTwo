<%@ Page Title="" Language="C#" MasterPageFile="~/TravelSite.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="TravelSite.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            display: inline;
        }

        .row {
            width: 100%;
            text-align: center;
        }

            .row img {
            }

        .card-img-top {
            overflow: hidden;
            max-width: 200px;
            width: 200px;
            max-height: 200px;
            height: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
        <div class="row"><div class="col"><h1>Welcome!</h1></div></div>
        <div class="row"><div class="col">To get started on your personalized vacation package, <br />please select from below to start adding items to your dream vacation!</div></div>
        <div class="row"><div class="col"><br /><hr /></div></div>
        <div class="row">

            <div class="col">
                <div class="card" style="width: 20%;">
                    <img class="card-img-top" src="image/air-airplane-blue-sky-cloud-Favim.com-3157133.jpg" alt="Card image cap" />
                    <div class="card-body">
                        <h3 class="card-title">Flight</h3>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="Flight.aspx" class="btn btn-primary">BOOK NOW</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 20%;">
                    <img class="card-img-top" src="image/iberostar-grand-hotel-bavaro-4256x2828-punta-kana-best-hotels-of-2017-3175.jpg" alt="Card image cap" />
                    <div class="card-body">
                        <h3 class="card-title">Hotel</h3>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="Hotel.aspx" class="btn btn-primary">BOOK NOW</a>
                    </div>
                </div>
            </div>
            <div class="col">

                <div class="card" style="width: 20%;">
                    <img class="card-img-top" src="image/272866-car-combi-748x495.jpg" alt="Card image cap" />
                    <div class="card-body">
                        <h3 class="card-title">Car Rental</h3>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="Car.aspx" class="btn btn-primary">BOOK NOW</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card" style="width: 20%;">
                    <img class="card-img-top" src="image/6-Places-to-Swim-with-Dolphins-1835cdaa19ee4566aa631ea6ecaa5a0d.jpg" alt="Card image cap" />
                    <div class="card-body">
                        <h3 class="card-title">Explore Activities</h3>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="Experience.aspx" class="btn btn-primary">BOOK NOW</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

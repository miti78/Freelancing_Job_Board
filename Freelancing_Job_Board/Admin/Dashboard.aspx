<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Freelancing_Job_Board.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.1/css/all.min.css" />
    <style>
        .card {
            background-color: #fff;
            border-radius: 15px;
            border: none;
            position: relative;
            box-shadow: 0.46075rem 2.1075rem rgba(90, 27, 105, 0.1), 0 0.9375rem 1.40625rem rgba(10, 97, 105, 0.1), 0 0.25rem 0.53125rem rgba(90, 97, 105, 0.12), 0 0.125rem 0.1875rem rgba(10, 97, 105, 0.1);
            margin-bottom: 20px;
        }

        .bg-cherry {
            background: linear-gradient(to right, #493240, #1109) !important;
            color: #fff;
        }

        .bg-blue-dark {
            background: linear-gradient(to right, #373644, #4285f4) !important;
            color: #fff;
        }

        .bg-green-dark {
            background: linear-gradient(to right, #504, #3817d) !important;
            color: #fff;
        }

        .bg-orange-dark {
            background: linear-gradient(to right, #ff7e00, #ffba56) !important;
            color: #fff;
        }

        .card.card-statistic-3 .card-icon-large.fas, .card.card-statistic-3 .card-icon-large.far, .card.card-statistic-3 .card-icon-large.fab, .card.card-statistic-3 .card-icon-large.fal {
            font-size: 110px;
        }

        .card .card-statistic-3 .card-icon {
            text-align: center;
            line-height: 50px;
            margin-left: 15px;
            color: #000;
            position: absolute;
            right: 5px;
            opacity: 0.11;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container pt-4" style="margin-right:100px ; gap:30px">
        <div class="col-12 pb-3">
            <h2 class="text-center">Dashboard</h2>
        </div>
        <div class="col-md-10 mx-auto">
            <!-- First Row -->
            <div class="row" >
                <div class="col-xl-6 col-lg-12">
                    <div class="card bg-cherry">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large">
                                <i class="fas fa-users pr-2"></i>
                            </div>
                            <div class="mb-4">
                                <h5 class="card-title mb-0">Total Users</h5>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <h2 class="d-flex align-items-center mb-0">
                                        <%: Session["Users"] %>
                                    </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-12">
                    <div class="card bg-blue-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large">
                                <i class="fas fa-briefcase pr-2"></i>
                            </div>
                            <div class="mb-4">
                                <h5 class="card-title mb-0">Total Jobs</h5>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <h2 class="d-flex align-items-center mb-0">
                                        <%: Session["Jobs"] %>
                                    </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Second Row -->
            <div class="row">
                <div class="col-xl-6 col-lg-12">
                    <div class="card bg-green-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large">
                                <i class="fas fa-check-square pr-2"></i>
                            </div>
                            <div class="mb-4">
                                <h5 class="card-title mb-0">Applied Jobs</h5>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <h2 class="d-flex align-items-center mb-0">
                                        <%: Session["AppliedJobs"] %>
                                    </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-6 col-lg-12">
                    <div class="card bg-orange-dark">
                        <div class="card-statistic-3 p-4">
                            <div class="card-icon card-icon-large">
                                <i class="fas fa-comments pr-2"></i>
                            </div>
                            <div class="mb-4">
                                <h5 class="card-title mb-0">Contacted Users</h5>
                            </div>
                            <div class="row align-items-center mb-2 d-flex">
                                <div class="col-8">
                                    <h2 class="d-flex align-items-center mb-0">
                                        <%: Session["Contact"] %>
                                    </h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

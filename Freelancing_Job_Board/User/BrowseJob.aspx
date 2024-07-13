<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BrowseJob.aspx.cs" Inherits="Freelancing_Job_Board.User.BrowseJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }
        .job-listing-area {
            padding: 50px 0;
        }
        .small-section-tittle2 {
            margin-bottom: 20px;
            font-weight: bold;
            color: #333;
        }
        .select-job-items2 {
            margin-bottom: 30px;
            background-color: #fff;
            padding: 15px;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            margin-bottom:10px;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            transition: border-color 0.3s;
        }
        .form-control:focus {
            border-color: #FF4357;
            outline: none;
        }
        .btn {
            display: block;
            width: 100%;
            padding: 10px;
            background-color: #FF4357;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
            text-align: center;
            margin-left: 10px;
        }
        .btn:hover {
            background-color: #e03e50;
        }
        .checkbox label, .radiobuttonlist label {
            font-size: 14px;
        }
        .checkbox {
            margin-bottom: 10px;
        }
        .radiobuttoncontainer {
            margin-top: 20px;
        }
        .single-job-items {
            padding: 20px; 
            margin-bottom: 30px; 
            background-color: #fff; 
            border-radius: 8px; 
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            width: 1000px; 
            max-width: 900px; 
            margin-left: auto; 
            margin-right: auto; 
            transition: transform 0.2s; 
        }
        .single-job-items:hover {
            transform: translateY(-5px); 
        }
        .job-items {
            display: flex; 
            align-items: center; 
        }
        .company-img img {
            border-radius: 50%; 
            border: 2px solid #FF4357; 
        }
        .job-title h5 {
            font-size: 1.2em; 
            color: #333; 
            margin: 0; 
        }
        .job-title ul {
            list-style-type: none; 
            padding: 0; 
            margin: 5px 0 0; 
            font-size: 0.9em; 
        }
        .job-title ul li {
            color: #666; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="bradcam_area bradcam_bg_1">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="bradcam_text" >
                            <asp:Label ID="lblJobCount" runat="server" Style="font-size: 40px;" CssClass="job-count-label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="job-listing-area pt-50 pb-120">
            <div class="container">
                <div class="row">
                    <div class="col-xl-2 col-lg-3 col-md-4">
                        <div class="row">
                            <div class="col-12">
                                <div class="small-section-tittle2 mb-45">
                                    <div class="ion">
                                        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="20px" height="12px">
                                            <path fill-rule="evenodd" fill="rgb(27, 207, 107)" d="M7.778,12.000 L12.222,12.000 L12.222,10.000 17.778,10.000 17.778,12.000 ZM-0.000,-0.000 L-0.000,2.000 L2" />
                                        </svg>
                                    </div>
                                    <h4>Filter Jobs</h4>
                                </div>
                            </div>
                        </div>
                        <div class="job-category-listing mb-50 pb-8">
                            <div class="single-listing">
                                <div class="small-section-tittle2">
                                    <h4>Job Location</h4>
                                </div>
                                <div class="select-job-items2">
                                    <asp:DropDownList ID="ddCountry" runat="server" CssClass="form-control w-100"
                                        AppendDataBoundItems="True" OnSelectedIndexChanged="ddCountry_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="0" Text="Country" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <div class="select-Categories pt-80 pb-50">
                                <div class="small-section-tittle2">
                                    <h4>Job Type</h4>
                                </div>
                                <div class="checkbox checkbox-primary">
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True"
                                        RepeatDirection="Vertical" RepeatLayout="Flow" CssClass="styled"
                                        TextAlign="Right" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                        <asp:ListItem>Full Time</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                        <asp:ListItem>Remote</asp:ListItem>
                                        <asp:ListItem>Freelance</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="select-Categories pt-80 pb-50">
                                <div class="small-section-tittle2">
                                    <h4>Posted Within</h4>
                                </div>
                                <div class="radiobuttoncontainer">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radiobuttonlist" AutoPostBack="true"
                                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatLayout="Flow">
                                        <asp:ListItem Value="8" Selected="True">Any</asp:ListItem>
                                        <asp:ListItem Value="1">Today</asp:ListItem>
                                        <asp:ListItem Value="2">Last 2 days</asp:ListItem>
                                        <asp:ListItem Value="3">Last 3 days</asp:ListItem>
                                        <asp:ListItem Value="4">Last 5 days</asp:ListItem>
                                        <asp:ListItem Value="5">Last 10 days</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="mb-1">
                                <asp:LinkButton ID="lbFilter" runat="server" CssClass="btn btn-sm" Width="100%"
                                    OnClick="lbFilter_Click">Filter</asp:LinkButton>
                            </div>
                            <div class="mb-4">
                                <asp:LinkButton ID="lbReset" runat="server" CssClass="btn btn-sm" Width="100%"
                                    OnClick="lbReset_Click">Reset</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-10 col-lg-9 col-md-8">
                        <section class="featured-job-area">
                            <div class="container">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="count-job mb-35">
                                            <asp:Label ID="lblJobCountDisplay" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <asp:DataList ID="DataList1" runat="server">
                                    <ItemTemplate>
                                        <div class="single-job-items" style="display: flex; justify-content: space-between; align-items: center; padding: 20px; border: 1px solid #e0e0e0; border-radius: 8px; margin-bottom: 15px; background-color: #fff;">
                                            <div class="job-items" style="display: flex; align-items: center;">
                                                <div class="company-img">
                                                    <a href="Job_Details.aspx?id=<%# Eval("JobId") %>">
                                                        <img width="80" src="<%# GetImageUrl(Eval("CompanyImage")) %>" alt="<%# Eval("CompanyName") %> Logo">
                                                    </a>
                                                </div>
                                                <div class="job-title" style="margin-left: 15px;">
                                                    <a href="Job_Details.aspx?id=<%# Eval("JobId") %>">
                                                        <h5><%# Eval("Title") %></h5>
                                                    </a>
                                                    <ul>
                                                        <li><strong>Company:</strong> <%# Eval("CompanyName") %></li>
                                                        <li><i class="fas fa-map-marker-alt"></i> <%# Eval("State") %>, <%# Eval("Country") %></li>
                                                        <li><strong>Salary:</strong> <%# Eval("Salary") %></li>
                                                        <li><strong>Job Type:</strong> <%# Eval("JobType") %></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="items-link" style="display: flex; align-items: center; justify-content: flex-start;">
                                                <a href="Job_Details.aspx?id=<%# Eval("JobId") %>" class="btn btn-sm" style="margin-right: 100px;">Apply</a>

                                                <span class="text-secondary">
                                                    <i class="fas fa-clock pr-1"></i>
                                                    <%# RelativeDate(Convert.ToDateTime(Eval("CreateDate"))) %>
                                                </span>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

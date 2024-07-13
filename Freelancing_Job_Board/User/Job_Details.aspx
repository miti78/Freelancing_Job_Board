<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Job_Details.aspx.cs" Inherits="Freelancing_Job_Board.User.Job_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .job_summary {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            margin-left: 20px;
        }
        .job_content ul {
            list-style-type: none;
            padding: 0;
        }
        .job_content li {
            margin-bottom: 10px;
        }
        .job_summary h3 {
            font-size: 24px;
            color: #343a40;
        }
        .share_wrap {
            margin-top: 20px;
            text-align: center;
        }
        .share_wrap ul {
            padding: 0;
            display: inline-block;
        }
        .share_wrap li {
            display: inline;
            margin: 0 10px;
        }
        .job_location_wrap {
            margin-top: 20px;
        }
        .apply-btn2 {
            margin-top: 20px;
            text-align: center;
        }
        .apply-btn2 .btn {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            text-decoration: none;
            font-weight: bold;
            transition: background-color 0.3s, transform 0.3s;
        }
        .apply-btn2 .btn:hover {
            background-color: #0056b3;
            transform: scale(1.05);
        }
        .apply-btn2 .btn:active {
            background-color: #004080;
        }
        .apply-btn2 .btn:focus {
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }
        .apply-btn2 .btn[disabled] {
            background-color: #6c757d;
            cursor: not-allowed;
        }
        /*.job_details_area h1, 
.job_details_area h4, 
.job_details_area p {
    color: #007bff;*/ /* Change to your desired color */
/*}*/



    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
         <asp:Label ID="lblMsg" runat="server" Visible="true"></asp:Label>
       <%-- <div class="bradcam_area bradcam_bg_1">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="bradcam_text">
                            <h3><%# jobTitle %></h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>

        <div class="job_details_area">
            <div class="container">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="job_details_header">
                            <div class="single_jobs white-bg d-flex justify-content-between">
                                <div class="jobs_left d-flex align-items-center">
                                   <asp:DataList ID="JobDetailsDataListSummary" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                                       <ItemTemplate>
                                           <div class="jobs_left d-flex align-items-center">
                                               
                                               <div class="thumb">
                                                   <img src="../img/svg_icon/th.jpg" style="width:100px; height:100px;" alt="">
                                               </div>
                                               <div class="jobs_conetent" style="margin-left:15px">
                                                   <a href="#"><h4><%# Eval("Title") %></h4></a>
                                                   <div class="links_locat d-flex align-items-center">
                                                       <div class="location">
                                                           <p><i class="fa fa-map-marker"></i> <%# Eval("State") %>, <%# Eval("Country") %></p>
                                                       </div>
                                                       <div class="location">
                                                           <p><i class="fa fa-clock-o"></i> <%# Eval("JobType") %></p>
                                                       </div>
                                                   </div>
                                               </div>
                                           </div>
                                       </ItemTemplate>
                                   </asp:DataList>
                                </div>
                                <div class="jobs_right">
                                    <div class="apply_now">
                                        <a class="heart_mark" href="#"><i class="ti-heart"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="descript_wrap white-bg">
<%--                            <asp:Label ID="lblMsg" runat="server" Visible="true"></asp:Label>--%>
                            <asp:DataList ID="JobDetailsDataList" runat="server" OnItemCommand="DataList1_ItemCommand">
                                <ItemTemplate>
                                    <h1><b>Company Name: <span><%# Eval("CompanyName") %></span></b></h1>
                                    <%--<h1 style="color:#007bff;"><%# Eval("CompanyName") %></h1>--%>
                                    <h4><b>Description Of Job</b></h4>
                                    <p>Description: <span><%# Eval("Description") %></span></p>
                                    <h4><b>Required knowledge and skill</b></h4>
                                    <p>Specialization: <span><%# Eval("Specialization") %></span></p>
                                    <p>Qualification: <span><%# Eval("Qualification") %></span></p>
                                    <p>Experience: <span><%# Eval("Experience") %></span></p>
                                    <h4><b>Other Information</b></h4>
                                    <p>Posted Date: <span><%# Eval("CreateDate", "{0:dd MMMM yyyy}") %></span></p>
                                    <p>Application Date: <span><%# Eval("LastDateToApply", "{0:dd MMMM yyyy}") %></span></p>
                                    <h4><b>Website and Email</b></h4>
                                    <p>Web: <span><%# Eval("Website") %></span></p>
                                    <p>Email: <span><%# Eval("Email") %></span></p>

                                     <div class="apply-btn2">                        
<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" Text="Apply Now" CommandName="ApplyJob" CommandArgument='<%# Eval("JobId") %>'></asp:LinkButton>

     </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                           

                            <div class="post-details4 mb-50">
                                <div class="small-section-tittle">
                                    <h4>Company Information</h4>
                                </div>
                                <span><%# Eval("CompanyName") %></span>
                                <p><b>Address:</b> <%# Eval("Address") %></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="job_summary">
                            <div class="summery_header">
                                <h3>Job Summary</h3>
                            </div>
                            <div class="job_content">
                                <asp:DataList ID="JobSummaryDataList" runat="server">
                                    <ItemTemplate>
                                        <ul>
                                            <li>Published on: <span><%# Eval("CreateDate", "{0:dd MMMM yyyy}") %></span></li>
                                            <li>Vacancy: <span><%# Eval("NoOfPost") %></span></li>
                                            <li>Salary: <span><%# Eval("Salary") %></span></li>
                                            <li>Location: <span><%# Eval("State") %>, <%# Eval("Country") %></span></li>
                                            <li>Job Nature: <span><%# Eval("JobType") %></span></li>
                                        </ul>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                            <div class="apply-btn2">
                           <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn" Text="Apply Now" CommandName="ApplyJob" CommandArgument='<%# Eval("JobId") %>'></asp:LinkButton>
                            </div>
                        </div>
                        <div class="share_wrap d-flex">
                            <span>Share at:</span>
                            <ul>
                                <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                <li><a href="#"><i class="fa fa-envelope"></i></a></li>
                            </ul>
                        </div>
                        <div class="job_location_wrap">
                            <div class="job_lok_inner">
                                <div id="map" style="height: 200px;"></div>
                                <script>
                                    function initMap() {
                                        var uluru = { lat: -25.363, lng: 131.044 };
                                        var grayStyles = [
                                            {
                                                featureType: "all",
                                                stylers: [
                                                    { saturation: -90 },
                                                    { lightness: 50 }
                                                ]
                                            },
                                            { elementType: 'labels.text.fill', stylers: [{ color: '#ccdee9' }] }
                                        ];
                                        var map = new google.maps.Map(document.getElementById('map'), {
                                            center: { lat: -31.197, lng: 150.744 },
                                            zoom: 9,
                                            styles: grayStyles,
                                            scrollwheel: false
                                        });
                                    }
                                </script>
                                <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap"></script>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

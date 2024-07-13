<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="Freelancing_Job_Board.Admin.NewJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Add Job</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5 pt-4 pb-4" style="margin-left: 300px;">
            <asp:Label ID="lblMsg" runat="server" CssClass="alert" Visible="false"></asp:Label>
            <h2 class="text-center mb-4">Add Job</h2>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtJobTitle">Job Title</label>
                    <asp:TextBox ID="txtJobTitle" CssClass="form-control" placeholder="Enter job title" runat="server" Required="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtNumPost">Number of Posts</label>
                    <asp:TextBox ID="txtNumPost" CssClass="form-control" placeholder="Enter number of posts" TextMode="Number" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-12">
                    <label for="txtDescription">Description</label>
                    <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Enter job description" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtQualification">Qualification/Education Required</label>
                    <asp:TextBox ID="txtQualification" CssClass="form-control" placeholder="Ex: MCA, BTech" runat="server" Required="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtExperience">Experience Required</label>
                    <asp:TextBox ID="txtExperience" CssClass="form-control" placeholder="Ex: 2 years, 5 years" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtSpecialization">Specialization Required</label>
                    <asp:TextBox ID="txtSpecialization" CssClass="form-control" placeholder="Enter specialization" runat="server" Required="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtLastDate">Last Date to Apply</label>
                    <asp:TextBox ID="txtLastDate" CssClass="form-control" TextMode="Date" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtSalary">Salary</label>
                    <asp:TextBox ID="txtSalary" CssClass="form-control" placeholder="Ex: 25000/Month or 7L/Year" runat="server" Required="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="ddlJobType">Job Type</label>
                    <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select Job Type</asp:ListItem>
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Remote</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Job Type is Required" ForeColor="Red"
                        ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtCompanyName">Company/Organization Name</label>
                    <asp:TextBox ID="txtCompanyName" CssClass="form-control" placeholder="Enter company name" runat="server" Required="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="fuCompanyLogo">Company/Organization Logo</label>
                    <asp:FileUpload ID="fuCompanyLogo" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtWebsite">Website</label>
                    <asp:TextBox ID="txtWebsite" CssClass="form-control" placeholder="Enter company website" TextMode="Url" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtEmail">Enter Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter contact email" TextMode="Email" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-12">
                    <label for="txtAddress">Enter Address</label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Enter working location" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label>Country</label>
                    <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" DataSourceID="SqlDataSource1" AppendDataBoundItems="true"
                        DataTextField="CountryName" DataValueField="CountryName">
                        <asp:ListItem Value="0">Select Country</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country Is Required" ForeColor="Red"
                        Display="Dynamic" SetFocusOnError="true" InitialValue="0" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Freelancing_Job_BoardConnectionString %>"
                        SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                </div>
                <div class="col-md-6">
                    <label for="txtState">State</label>
                    <asp:TextBox ID="txtState" CssClass="form-control" placeholder="Enter state" runat="server" Required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-3">
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" Text="Add Job" runat="server" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewResumeDetails.aspx.cs" Inherits="Freelancing_Job_Board.Admin.ViewResumeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>View Resume Details</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5 pt-4 pb-4"style="margin-left: 300px;">
            <asp:Label ID="lblMsg" runat="server" CssClass="alert" Visible="false"></asp:Label>
            <h2 class="text-center mb-4">Resume Details</h2>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:Panel ID="pnlResume" runat="server" CssClass="border p-3">
                        <!-- Content for displaying the resume -->
                        <asp:Literal ID="litResume" runat="server"></asp:Literal>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

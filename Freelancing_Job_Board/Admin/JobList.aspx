<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="Freelancing_Job_Board.Admin.JobList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Job List</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5 pt-4 pb-4" style="margin-left: 300px;">
            <div>
                <asp:Label ID="lblMsg" runat="server" CssClass="alert" Visible="false"></asp:Label>
            </div>
            <h2 class="text-center" style="margin-right: 300px; margin-bottom: 40px;">Job List</h2>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered"
    EmptyDataText="No Record to display.." AllowPaging="true" PageSize="5"
    OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobId"
    OnRowCommand="GridView1_RowCommand">

    <Columns>
        <asp:BoundField DataField="SrNo" HeaderText="Sr.No">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Title" HeaderText="Job Title">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
                            <asp:BoundField DataField="NoOfPost" HeaderText="No. Of Posts">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qualification" HeaderText="Qualification">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Experience" HeaderText="Experience">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LastDateToApply" HeaderText="Valid Till" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompanyName" HeaderText="Company">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Country" HeaderText="Country">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="State" HeaderText="State">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreateDate" HeaderText="Posted Date" DataFormatString="{0:yyyy-MM-dd}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                         <%-- Edit --%>
        <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
                <asp:LinkButton ID="btnEditJob" runat="server" CommandName="EditJob" CommandArgument='<%# Container.DataItemIndex %>'>
                    <asp:Image ID="ImgEdit" runat="server" ImageUrl="../assets/img/update.jpg" Height="25px" />
                </asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>

        <%-- Delete --%>
        <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
                <asp:LinkButton ID="btnDeleteJob" runat="server" CommandName="DeleteJob" CommandArgument='<%# Container.DisplayIndex %>'
                    CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this job?');">
                    Delete
                </asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
                        <HeaderStyle BackColor="#7200cf" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

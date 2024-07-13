<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewResume.aspx.cs" Inherits="Freelancing_Job_Board.Admin.ViewResume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>View Resumes</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5 pt-4 pb-4"style="margin-left: 300px;">
            <div>
                <asp:Label ID="lblMsg" runat="server" CssClass="alert" Visible="false"></asp:Label>
            </div>
            <h2 class="text-center mb-4">Resume List</h2>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered"
                        EmptyDataText="No Resumes to display.." AllowPaging="true" PageSize="5"
                        OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="UserId"
                        OnRowCommand="GridView1_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Username" HeaderText="Username">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="View Resume">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnViewResume" runat="server" CommandName="ViewResume" CommandArgument='<%# Container.DataItemIndex %>'
                                        CssClass="btn btn-primary btn-sm">
                                        View
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDeleteResume" runat="server" CommandName="DeleteResume" CommandArgument='<%# Container.DataItemIndex %>'
                                        CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this resume?');">
                                        Delete
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#7200cf" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

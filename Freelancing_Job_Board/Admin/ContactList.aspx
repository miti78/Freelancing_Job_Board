<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="Freelancing_Job_Board.Admin.ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container mt-5 pt-4 pb-4" style="margin-left: 300px;">
            <div>
                <asp:Label ID="lblMsg" runat="server" CssClass="alert" Visible="false"></asp:Label>
            </div>
            <h2 class="text-center" style="margin-right: 300px; margin-bottom: 40px;">Contact List</h2>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered"
                        EmptyDataText="No Record to display." AllowPaging="true" PageSize="5"
                        OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="ContactId" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Username">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Subject" HeaderText="Subject">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Message" HeaderText="Message">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDeleteJob" runat="server" CommandName="Delete" CommandArgument='<%# Container.DisplayIndex %>'
                                        CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this contact?');">
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

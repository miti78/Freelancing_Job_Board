<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Freelancing_Job_Board.Admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.12.1/css/all.min.css" />
    <style>
        .user-list-container {
            background-image: url('../Images/bg.jpg');
            width: 100%;
            height: 720px;
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
        }

        .user-list-header {
            padding-top: 4rem;
            padding-bottom: 4rem;
        }

        .user-list-header h3 {
            color: #fff;
        }

        .alert {
            padding: 10px;
            margin-top: 10px;
        }
        
        .alert-success {
            background-color: #d4edda;
            color: #155724;
        }

        .alert-danger {
            background-color: #f8d7da;
            color: #721c24;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="user-list-container">
        <div class="container-fluid pt-4 pb-4" >
            <form id="form1" runat="server">
                <div>
                    <asp:Label ID="lblMsg" runat="server" CssClass="alert"></asp:Label>
                </div>
                <h3 class="text-center">User List/Details</h3>
                <div class="row mb-3 pt-sm-3">
                    <div class="col-md-12">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display..!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="UserId" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="User Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Country" HeaderText="Country">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                                    DeleteImageUrl="../assets/img/icon/trashIcon.png" ButtonType="Image">
                                    <ControlStyle Height="25px" Width="25px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Freelancing_Job_Board.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
                <div class="bradcam_area bradcam_bg_1">
    <div class="container">
        <div class="row">
            <div class="col-xl-12">
                <div class="bradcam_text">
                    <%--<h3 class="text-center">Sign Up</h3>--%>
                </div>
            </div>
        </div>
    </div>
</div>
        <section>
            <div class="container pt-50 pb-40">
                <div class="row">
                    <div class="col-12 pb-20">
                        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h2 class="contact-title text-center">Login</h2>
                    </div>
                    <div class="col-lg-6 mx-auto">
                        <div class="form-contact contact_form">
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter your username" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password" required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="form-group">
                                        <label>User Type</label> <br />
                                        <asp:DropDownList runat="server" ID="ddlLoginType" CssClass="form-control">
                                            <asp:ListItem Value="0">Select Type</asp:ListItem>
                                            <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                            <asp:ListItem Value="User">User</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group mt-3">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button button-contactForm btn_4 boxed-btn" OnClick="btnLogin_Click" />
                                <span class="ClickLink ml-5"> <a href="../User/Register.aspx">  New user? Click Here....</a>></span>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</asp:Content>

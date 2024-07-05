<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Freelancing_Job_Board.User.Registration" %>
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
        <section >
    <div class="container pt-50 pb-40">
        <div class="row ">
            <div class="col-12 pb-20">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="col-12 ">
                <h2 class="contact-title text-center">Sign Up</h2>
            </div>
            <div class="col-lg-6 mx-auto">
                <div class="form-contact contact_form">
                    <div class="row">
                        <div class="col-12"><h3>Login Information</h3></div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Username</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter your username" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Confirm Password</label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm your password" required></asp:TextBox>
                                <asp:CompareValidator runat="server" ErrorMessage="Passwords do not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="small"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="col-12"><h4>Personal Information</h4></div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your full name" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Enter your address" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Mobile Number</label>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter your phone number" required></asp:TextBox>
                                <asp:RegularExpressionValidator runat="server" ErrorMessage="Mobile number must have 11 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="small" ValidationExpression="^[0-9]{11}$" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Email Address</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email address" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Country</label> <br />
                                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" AppendDataBoundItems="true" 
                                    DataTextField="CountryName" DataValueField="CountryName">
                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country Is Required" 
                                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="small" InitialValue="0" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Freelancing_Job_BoardConnectionString %>"
                                    SelectCommand="SELECT [CountryName] FROM [Country]" ProviderName="<%$ ConnectionStrings:Freelancing_Job_BoardConnectionString.ProviderName %>">
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="form-group mt-3">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button button-contactForm btn_4 boxed-btn" OnClick="btnRegister_Click" />
                        <span class="ClickLink ml-5"> <a href="../User/Login.aspx">  Already Registered? Click Here....</a>></span>
                    </div>

                </div>
            </div>
        </div>
    </div>
</section>
    </main>
</asp:Content>

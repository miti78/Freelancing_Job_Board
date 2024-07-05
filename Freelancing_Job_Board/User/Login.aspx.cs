using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Any initial loading logic can be added here
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlLoginType.SelectedValue == "Admin")
                {
                    string username = ConfigurationManager.AppSettings["username"];
                    string password = ConfigurationManager.AppSettings["password"];
                    if (username == txtUserName.Text.Trim() && password == txtPassword.Text.Trim())
                    {
                        Session["admin"] = username;
                        Response.Redirect("../Admin/Dashboard.aspx", false);
                    }
                    else
                    {
                        ShowErrorMsg("Admin");
                    }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username=@Username AND Password=@Password", con);
                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            Session["user"] = sdr["Username"].ToString();
                            Session["userId"] = sdr["UserId"].ToString();
                            Response.Redirect("Default.aspx", false);
                        }
                        else
                        {
                            ShowErrorMsg("User");
                        }
                        sdr.Close();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void ShowErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "<b>" + userType + "</b> credentials are incorrect.";
        }
    }
}

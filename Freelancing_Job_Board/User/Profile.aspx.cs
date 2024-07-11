using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class Profile : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                showUserProfile();
            }
        }

        private void showUserProfile()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    string query = "SELECT UserId, Username, Name, Address, Mobile, Email, Country, Resume FROM [User] WHERE Username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", Session["user"].ToString());
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dlProfile.DataSource = dt;
                            dlProfile.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., log error, display user-friendly message
            }
        }

        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditUserProfile")
            {
                string username = e.CommandArgument.ToString();
                Session["Username"] = username; // Set the session variable
                Response.Redirect($"ResumeBuild.aspx?username={username}", false); // Ensure false to avoid thread abort exception
            }
            else if (e.CommandName == "Delete")
            {
                // Code to delete user profile
            }
            // ... other command handlers
        }
    }
}

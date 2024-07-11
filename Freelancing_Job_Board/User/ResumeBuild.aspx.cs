using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class ResumeBuild : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;
            System.Diagnostics.Debug.WriteLine("Connection String: " + connectionString);

            if (!IsPostBack)
            {
                PopulateCountryDropDown();

                // Retrieve username from session or query string
                string username = "";
                if (Session["Username"] != null)
                {
                    username = Session["Username"].ToString();
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["username"]))
                {
                    username = Request.QueryString["username"].ToString();
                }
                else
                {
                    // Handle case where username is not found in session or query string
                    Response.Redirect("ResumeBuild.aspx");
                }

                // Now use 'username' for further operations like loading user data
                LoadUserData(username);
            }
        }

        private void PopulateCountryDropDown()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT CountryName FROM Country", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ddlCountry.DataSource = rdr;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryName";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error loading countries: " + ex.Message;
                lblMsg.Visible = true;
            }
        }

        private void LoadUserData(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username = @Username", con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        txtFullName.Text = rdr["FullName"].ToString();
                        txtUserName.Text = username; // Set username if needed
                        txtAddress.Text = rdr["Address"].ToString();
                        txtMobile.Text = rdr["Mobile"].ToString();
                        txtEmail.Text = rdr["Email"].ToString();
                        ddlCountry.SelectedValue = rdr["Country"].ToString();
                        txtTenth.Text = rdr["TenthPercentage"].ToString();
                        txtTwelve.Text = rdr["TwelvePercentage"].ToString();
                        txtGraduation.Text = rdr["GraduationCGPA"].ToString();
                        txtWork.Text = rdr["JobProfile"].ToString();
                        txtExperience.Text = rdr["WorkExperience"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error loading user data: " + ex.Message;
                lblMsg.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [User] SET FullName = @FullName, Address = @Address, Mobile = @Mobile, Email = @Email, Country = @Country, TenthPercentage = @TenthPercentage, TwelvePercentage = @TwelvePercentage, GraduationCGPA = @GraduationCGPA, JobProfile = @JobProfile, WorkExperience = @WorkExperience WHERE Username = @Username", con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@TenthPercentage", txtTenth.Text);
                    cmd.Parameters.AddWithValue("@TwelvePercentage", txtTwelve.Text);
                    cmd.Parameters.AddWithValue("@GraduationCGPA", txtGraduation.Text);
                    cmd.Parameters.AddWithValue("@JobProfile", txtWork.Text);
                    cmd.Parameters.AddWithValue("@WorkExperience", txtExperience.Text);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMsg.Text = "Profile updated successfully!";
                        lblMsg.Visible = true;
                    }
                    else
                    {
                        lblMsg.Text = "Failed to update profile.";
                        lblMsg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error updating user data: " + ex.Message;
                lblMsg.Visible = true;
            }
        }
    }
}

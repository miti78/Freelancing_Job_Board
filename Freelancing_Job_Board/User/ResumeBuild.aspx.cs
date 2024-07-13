

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class ResumeBuild : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;

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

                // Load user data
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
                        txtFullName.Text = rdr["Name"].ToString();
                        txtUserName.Text = username; // Set username if needed
                        txtAddress.Text = rdr["Address"].ToString();
                        txtMobile.Text = rdr["Mobile"].ToString();
                        txtEmail.Text = rdr["Email"].ToString();
                        ddlCountry.SelectedValue = rdr["Country"].ToString();
                        txtTenth.Text = rdr["SSC_Result"].ToString();
                        txtTwelve.Text = rdr["HSC_Result"].ToString();
                        txtGraduation.Text = rdr["GraduationGrade"].ToString();
                        txtWork.Text = rdr["WorksOn"].ToString();
                        txtExperience.Text = rdr["Experience"].ToString();

                        // Handle resume status (not downloading)
                        if (rdr["Resume"] != DBNull.Value)
                        {
                            lblResumeLink.Text = "Resume uploaded.";
                            lblResumeLink.Visible = true;
                        }
                        else
                        {
                            lblResumeLink.Text = "No resume uploaded.";
                            lblResumeLink.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error loading user data: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
                lblMsg.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string resumeFileContent = null;

                if (fuResume.HasFile)
                {
                    // Read the file content and convert it to base64 string
                    using (Stream fileStream = fuResume.PostedFile.InputStream)
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            byte[] fileBytes = binaryReader.ReadBytes((int)fileStream.Length);
                            resumeFileContent = Convert.ToBase64String(fileBytes);
                        }
                    }
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE [User] 
                             SET Name = @Name, Address = @Address, Mobile = @Mobile, Email = @Email, Country = @Country, 
                                 SSC_Result = @SSC_Result, HSC_Result = @HSC_Result, GraduationGrade = @GraduationGrade, 
                                 WorksOn = @WorksOn, Experience = @Experience, Resume = @Resume 
                             WHERE Username = @Username";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@SSC_Result", txtTenth.Text);
                    cmd.Parameters.AddWithValue("@HSC_Result", txtTwelve.Text);
                    cmd.Parameters.AddWithValue("@GraduationGrade", txtGraduation.Text);
                    cmd.Parameters.AddWithValue("@WorksOn", txtWork.Text);
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text);
                    cmd.Parameters.AddWithValue("@Resume", (object)resumeFileContent ?? DBNull.Value);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMsg.Text = "Profile updated successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        lblMsg.Visible = true;
                    }
                    else
                    {
                        lblMsg.Text = "Failed to update profile.";
                        lblMsg.CssClass = "alert alert-danger";
                        lblMsg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and display error
                System.Diagnostics.Debug.WriteLine("Exception details: " + ex.ToString());
                lblMsg.Text = "Error updating user data: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
                lblMsg.Visible = true;
            }
        }
    }
}

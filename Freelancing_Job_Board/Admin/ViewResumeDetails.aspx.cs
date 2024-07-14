using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Freelancing_Job_Board.Admin
{
    public partial class ViewResumeDetails : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int userId;
                    if (int.TryParse(Request.QueryString["id"], out userId))
                    {
                        ShowResume(userId);
                    }
                    else
                    {
                        lblMsg.Text = "Invalid user ID.";
                        lblMsg.CssClass = "alert alert-warning";
                        lblMsg.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Text = "User ID is required.";
                    lblMsg.CssClass = "alert alert-warning";
                    lblMsg.Visible = true;
                }
            }
        }

        private void ShowResume(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT Resume FROM [User] WHERE UserId = @UserId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && !string.IsNullOrEmpty(result.ToString()))
                        {
                            string resumeBase64 = result.ToString();

                            // Decode the base64 string
                            byte[] resumeBytes = Convert.FromBase64String(resumeBase64);
                            string resumeFileName = "resume.pdf"; // Adjust filename or type as needed
                            string resumeFileType = "application/pdf"; // Adjust MIME type based on file format

                            // Set up the response to download the file
                            Response.Clear();
                            Response.ContentType = resumeFileType;
                            Response.AddHeader("Content-Disposition", $"attachment; filename={resumeFileName}");
                            Response.BinaryWrite(resumeBytes);
                            Response.End();
                        }
                        else
                        {
                            lblMsg.Text = "No resume available for this user.";
                            lblMsg.CssClass = "alert alert-warning";
                            lblMsg.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
                lblMsg.Visible = true;
            }
        }
    }
}

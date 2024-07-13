using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.Admin
{
    public partial class ViewResume : System.Web.UI.Page
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
                ShowResumes();
            }
        }

        private void ShowResumes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            ROW_NUMBER() OVER(ORDER BY UserId DESC) AS [SrNo],
                            UserId,
                            Username,
                            Name,
                            Email,
                            Mobile,
                            Resume
                        FROM [User]
                        WHERE Resume IS NOT NULL";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            // Debugging output
                            System.Diagnostics.Debug.WriteLine($"DataTable Rows Count: {dt.Rows.Count}");

                            if (dt.Rows.Count > 0)
                            {
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                lblMsg.Visible = false;
                            }
                            else
                            {
                                lblMsg.Text = "No resumes to display.";
                                lblMsg.CssClass = "alert alert-warning";
                                lblMsg.Visible = true;
                            }
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowResumes();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewResume")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
                {
                    int userId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["UserId"]);
                    Response.Redirect("ViewResumeDetails.aspx?id=" + userId);
                }
            }
            else if (e.CommandName == "DeleteResume")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["UserId"]);
                DeleteResume(userId);
            }
        }

        private void DeleteResume(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string deleteQuery = "UPDATE [User] SET Resume = NULL WHERE UserId = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblMsg.Text = "Resume deleted successfully.";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Text = "Failed to delete the resume.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
                ShowResumes();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
            lblMsg.Visible = true;
        }
    }
}

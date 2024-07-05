using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.Admin
{
    public partial class JobList : System.Web.UI.Page
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
                ShowJob();
            }
        }

        private void ShowJob()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
                                        ROW_NUMBER() OVER(ORDER BY CreateDate DESC) AS [SrNo],
                                        JobId,
                                        Title,
                                        NoOfPost,
                                        Qualification,
                                        Experience,
                                        LastDateToApply,
                                        CompanyName,
                                        Country,
                                        State,
                                        CreateDate
                                     FROM Jobs";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
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
            ShowJob();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditJob")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
                {
                    int jobId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["JobId"]);
                    Response.Redirect("NewJob.aspx?id=" + jobId);
                }
            }
            else if (e.CommandName == "DeleteJob")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int jobId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values["JobId"]);
                DeleteJob(jobId);
            }
        }

        private void DeleteJob(int jobId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Jobs WHERE JobId = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", jobId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblMsg.Text = "Job deleted successfully.";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Text = "Failed to delete the job.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
                ShowJob();
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

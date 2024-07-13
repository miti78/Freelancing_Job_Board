using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class Job_Details : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public string jobTitle = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ShowJobDetails();
                }
                else
                {
                    Response.Redirect("JobListing.aspx");
                }
            }
        }

        private void ShowJobDetails()
        {
            using (con = new SqlConnection(str))
            {
                string query = @"SELECT * FROM Jobs WHERE JobId = @id";
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    try
                    {
                        con.Open();
                        using (sda = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                JobDetailsDataList.DataSource = dt;
                                JobDetailsDataList.DataBind();

                                JobSummaryDataList.DataSource = dt;
                                JobSummaryDataList.DataBind();

                                JobDetailsDataListSummary.DataSource = dt;
                                JobDetailsDataListSummary.DataBind();

                                jobTitle = dt.Rows[0]["Title"].ToString();
                                Page.Title = jobTitle; // Set page title to job title for SEO
                            }
                            else
                            {
                                lblMsg.Text = "No job details found.";
                                lblMsg.Visible = true;
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        lblMsg.Text = "SQL Error: " + sqlEx.Message;
                        lblMsg.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "Error retrieving job details: " + ex.Message;
                        lblMsg.Visible = true;
                    }
                }
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ApplyJob")
            {
                if (Session["userId"] != null)
                {
                    try
                    {
                        int userId = Convert.ToInt32(Session["userId"]);
                        int jobId = Convert.ToInt32(Request.QueryString["id"]);

                        using (SqlConnection con = new SqlConnection(str))
                        {
                            string query = @"INSERT INTO AppliedJobs (JobId, UserId) VALUES (@JobId, @UserId)";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@JobId", jobId);
                                cmd.Parameters.AddWithValue("@UserId", userId);

                                con.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "Job applied successfully!";
                                    lblMsg.CssClass = "alert alert-success";
                                    // Inject JavaScript alert for debugging
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Job applied successfully!');", true);
                                }
                                else
                                {
                                    lblMsg.Visible = true;
                                    lblMsg.Text = "No rows affected. Job application might have failed.";
                                    lblMsg.CssClass = "alert alert-danger";
                                    // Inject JavaScript alert for debugging
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No rows affected. Job application might have failed.');", true);
                                }
                            }
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "SQL Error: " + sqlEx.Message;
                        lblMsg.CssClass = "alert alert-danger";
                        // Inject JavaScript alert for debugging
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('SQL Error: " + sqlEx.Message.Replace("'", "\\'") + "');", true);
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Error: " + ex.Message;
                        lblMsg.CssClass = "alert alert-danger";
                        // Inject JavaScript alert for debugging
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message.Replace("'", "\\'") + "');", true);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["userId"] != null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("LinkButton1") as LinkButton;
                int jobId = Convert.ToInt32(Request.QueryString["id"]);
                int userId = Convert.ToInt32(Session["userId"]);

                if (isApplied(jobId, userId))
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Applied";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "Apply Now";
                }
            }
        }

        bool isApplied(int jobId, int userId)
        {
            using (con = new SqlConnection(str))
            {
                string query = @"SELECT COUNT(*) FROM AppliedJobs WHERE UserId = @UserId AND JobId = @JobId";
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@JobId", jobId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Return true if already applied
                }
            }
        }
    }
}

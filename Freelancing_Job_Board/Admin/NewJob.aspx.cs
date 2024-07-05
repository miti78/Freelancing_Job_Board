using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Freelancing_Job_Board.Admin
{
    public partial class NewJob : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;
        SqlConnection con;
        String Query;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                FillData();
            }
        }

        private void FillData()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(connectionString);
                Query = "Select * from Jobs where JobId='" + Request.QueryString["id"] + "'";
                cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtNumPost.Text = sdr["NoOfPost"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specialization"].ToString();
                        DateTime lastDate;
                        if (DateTime.TryParseExact(sdr["LastDateToApply"].ToString(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out lastDate))
                        {
                            txtLastDate.Text = lastDate.ToString("yyyy-MM-dd");
                        }
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddlJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompanyName.Text = sdr["CompanyName"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        txtState.Text = sdr["State"].ToString();
                        btnAdd.Text = "Update";
                    }
                }
                else
                {
                    lblMsg.Text = "Job Not Found";
                    lblMsg.CssClass = "alert alert-danger";
                    lblMsg.Visible = true;
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query;
                    SqlCommand cmd;

                    if (Request.QueryString["id"] != null)
                    {
                        // Update existing job
                        query = @"UPDATE Jobs SET 
                            Title = @Title, 
                            NoOfPost = @NoOfPost, 
                            Description = @Description, 
                            Qualification = @Qualification, 
                            Experience = @Experience, 
                            Specialization = @Specialization, 
                            LastDateToApply = @LastDateToApply, 
                            Salary = @Salary, 
                            JobType = @JobType, 
                            CompanyName = @CompanyName, 
                            Website = @Website, 
                            Email = @Email, 
                            Address = @Address, 
                            Country = @Country, 
                            State = @State 
                          WHERE JobId = @JobId";

                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@JobId", Convert.ToInt32(Request.QueryString["id"]));
                    }
                    else
                    {
                        // Insert new job
                        query = @"INSERT INTO Jobs 
                            (Title, NoOfPost, Description, Qualification, Experience, Specialization, LastDateToApply, 
                             Salary, JobType, CompanyName, Website, Email, Address, Country, State, CreateDate) 
                          VALUES 
                            (@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply, 
                             @Salary, @JobType, @CompanyName, @Website, @Email, @Address, @Country, @State, @CreateDate)";

                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    }

                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", Convert.ToInt32(txtNumPost.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());

                    DateTime lastDate;
                    if (DateTime.TryParseExact(txtLastDate.Text.Trim(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out lastDate))
                    {
                        cmd.Parameters.AddWithValue("@LastDateToApply", lastDate);
                    }
                    else
                    {
                        lblMsg.Text = "Invalid date format for Last Date to Apply.";
                        lblMsg.CssClass = "alert alert-danger";
                        lblMsg.Visible = true;
                        return;
                    }

                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                    {
                        string action = (Request.QueryString["id"] != null) ? "updated" : "added";
                        lblMsg.Text = "Job " + action + " successfully";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Text = "Failed to " + ((Request.QueryString["id"] != null) ? "update" : "add") + " job";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                    lblMsg.Visible = true;
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
                lblMsg.Visible = true;
            }
        }

        private void ClearFields()
        {
            txtJobTitle.Text = "";
            txtNumPost.Text = "";
            txtDescription.Text = "";
            txtQualification.Text = "";
            txtExperience.Text = "";
            txtSpecialization.Text = "";
            txtLastDate.Text = "";
            txtSalary.Text = "";
            ddlJobType.SelectedIndex = 0;
            txtCompanyName.Text = "";
            txtWebsite.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            ddlCountry.SelectedIndex = 0;
            txtState.Text = "";
            btnAdd.Text = "Add";
        }
    }
}

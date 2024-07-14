using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowUsers();
            }
        }

        private void ShowUsers()
        {
            string query = @"SELECT ROW_NUMBER() OVER (ORDER BY UserId) AS [Sr.No], UserId, Name, Email, Mobile, Country FROM [User]";
            using (SqlConnection con = new SqlConnection(str))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowUsers();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                using (SqlConnection con = new SqlConnection(str))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE UserId = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    con.Open();

                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Text = "User deleted successfully!";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Text = "Cannot delete this record!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }

                GridView1.EditIndex = -1;
                ShowUsers();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }
    }
}

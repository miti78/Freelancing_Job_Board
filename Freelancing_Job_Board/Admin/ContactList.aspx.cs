using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.Admin
{
    public partial class ContactList : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowContact();
            }
        }

        public void ShowContact()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(str))
                {
                    string query = @"SELECT 
                                ROW_NUMBER() OVER(ORDER BY ContactId DESC) AS [SrNo],
                                ContactId,
                                Name,
                                Email,
                                Subject,
                                Message
                             FROM Contact";
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
            ShowContact();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int contactId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                using (SqlConnection con = new SqlConnection(str))
                {
                    string deleteQuery = "DELETE FROM Contact WHERE ContactId = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", contactId);
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            lblMsg.Text = "Contact deleted successfully.";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Text = "Failed to delete the contact.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
                ShowContact();
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

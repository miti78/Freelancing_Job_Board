using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Freelancing_Job_Board.Admin
{
    public partial class Dashboard : System.Web.UI.Page
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
                Users();
                Jobs();
                AppliedJobs();
                ContactCount();
            }
        }

        private void Users()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [User]", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Session["Users"] = dt.Rows.Count > 0 ? dt.Rows[0][0] : 0;
                }
            }
        }

        private void Jobs()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Jobs", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Session["Jobs"] = dt.Rows.Count > 0 ? dt.Rows[0][0] : 0;
                }
            }
        }

        private void AppliedJobs()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM AppliedJobs", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Session["AppliedJobs"] = dt.Rows.Count > 0 ? dt.Rows[0][0] : 0;
                }
            }
        }

        private void ContactCount()
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Contact", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Session["Contact"] = dt.Rows.Count > 0 ? dt.Rows[0][0] : 0;
                }
            }
        }
    }
}

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class Registration : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCountries();
            }
        }

        protected void LoadCountries()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT CountryID, CountryName FROM Country", con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlCountry.DataSource = reader;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataBind();
                    reader.Close();
                }
                ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error loading countries: " + ex.Message;
                lblMsg.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            string email = txtEmail.Text.Trim();
            string country = ddlCountry.SelectedValue;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO [User](Username, Password, Name, Address, Mobile, Email, Country) " +
                                                    "VALUES (@Username, @Password, @FullName, @Address, @Mobile, @Email, @Country)", con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.Text.Trim());

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMsg.Text = "Registration successful!";
                        lblMsg.Visible = true;
                        ClearFields();
                    }
                    else
                    {
                        lblMsg.Text = "Registration failed. Please try again.";
                        lblMsg.Visible = true;
                    }
                }
            }
            catch(SqlException ex)
            {
                if(ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text ="<b>"+txtUserName.Text.Trim()+"<b> username already exist,try new one.. " ;

                }
                else
                {
                    Response.Write("<script> alert('" + ex.Message + "');</script>");
                }
            }
            catch (Exception ex)
            {
               Response.Write("<script> alert('"+ex.Message+"');</script>");
            }
        }

        private void ClearFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            ddlCountry.SelectedIndex = 0;
        }
    }
}

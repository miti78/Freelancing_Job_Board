using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Freelancing_Job_Board.User
{
    public partial class contact : System.Web.UI.Page
    {
        // Get the connection string from the Web.config file
        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Any logic to execute on page load can be added here
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Create and open a connection to the database
                using (SqlConnection con = new SqlConnection(str))
                {
                    // Define the SQL query to insert data into the Contact table
                    string query = @"INSERT INTO Contact (Name, Email, Subject, Message) VALUES (@Name, @Email, @Subject, @Message)";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters to the SqlCommand
                        cmd.Parameters.AddWithValue("@Name", name.Value.Trim());
                        cmd.Parameters.AddWithValue("@Email", email.Value.Trim());
                        cmd.Parameters.AddWithValue("@Subject", subject.Value.Trim());
                        cmd.Parameters.AddWithValue("@Message", message.Value.Trim());

                        // Open the connection and execute the query
                        con.Open();
                        int r = cmd.ExecuteNonQuery();

                        // Check if the query was successful
                        if (r > 0)
                        {
                            // Display a success message
                            lblMsg.Visible = true;
                            lblMsg.Text = "Thanks for reaching out, we will look into your query!";
                            lblMsg.CssClass = "alert alert-success";

                            // Clear the input fields
                            ClearFields();
                        }
                        else
                        {
                            // Display an error message
                            lblMsg.Visible = true;
                            lblMsg.Text = "There was an issue submitting your query, please try again.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        // Method to clear the input fields
        private void ClearFields()
        {
            name.Value = string.Empty;
            email.Value = string.Empty;
            subject.Value = string.Empty;
            message.Value = string.Empty;
        }
    }
}

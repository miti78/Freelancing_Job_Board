using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace Freelancing_Job_Board.User
{
    public partial class BrowseJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountryData(); // Bind country dropdown on initial load
                BindJobData(); // Bind job data on initial load
                LoadJobCount();
            }
        }
        private void LoadJobCount()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Freelancing_Job_BoardConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Jobs"; // Ensure 'Jobs' is the correct table name
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    int jobCount = (int)command.ExecuteScalar();
                    lblJobCount.Text = jobCount + " Jobs Available"; // Ensure lblJobCount is the ID of your label
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception or display an error message
                // Example: lblJobCount.Text = "Error loading job count.";
                // Console.WriteLine(ex.Message); // For debugging purposes
            }
        }

        private void BindCountryData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Country AS CountryName FROM Jobs"; // Adjusted to get distinct countries
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    ddCountry.DataSource = rdr;
                    ddCountry.DataTextField = "CountryName";
                    ddCountry.DataValueField = "CountryName";
                    ddCountry.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exceptions (logging, displaying message, etc.)
                }
            }

            ddCountry.Items.Insert(0, new ListItem("Select Country", "0")); // Add default item
        }

        private void BindJobData(string country = null, string jobTypes = null, string postedWithin = null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Jobs WHERE 1=1"; // Base query

                if (!string.IsNullOrEmpty(country) && country != "0")
                {
                    query += " AND Country = @Country";
                }

                if (!string.IsNullOrEmpty(jobTypes))
                {
                    query += " AND JobType IN (" + jobTypes + ")"; // Example for multiple types
                }

                if (!string.IsNullOrEmpty(postedWithin))
                {
                    DateTime cutoffDate = DateTime.Now.AddDays(-Convert.ToInt32(postedWithin));
                    query += " AND CreateDate >= @CutoffDate";
                }

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters
                if (!string.IsNullOrEmpty(country) && country != "0")
                {
                    cmd.Parameters.AddWithValue("@Country", country);
                }

                if (!string.IsNullOrEmpty(postedWithin))
                {
                    cmd.Parameters.AddWithValue("@CutoffDate", DateTime.Now.AddDays(-Convert.ToInt32(postedWithin)));
                }

                try
                {
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DataList1.DataSource = rdr;
                    DataList1.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exceptions (logging, displaying message, etc.)
                }
            }
        }

        protected void ddCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = ddCountry.SelectedValue;
            string selectedJobTypes = GetSelectedJobTypes();
            string selectedPostedWithin = GetSelectedPostedWithin();

            BindJobData(selectedCountry, selectedJobTypes, selectedPostedWithin); // Rebind data after filtering
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedJobTypes = GetSelectedJobTypes();
            string selectedCountry = ddCountry.SelectedValue;
            string selectedPostedWithin = GetSelectedPostedWithin();

            BindJobData(selectedCountry, selectedJobTypes, selectedPostedWithin); // Rebind data after filtering
        }
        protected string RelativeDate(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;
            if (timeSpan.Days > 0)
                return $"{timeSpan.Days} days ago";
            else if (timeSpan.Hours > 0)
                return $"{timeSpan.Hours} hours ago";
            else
                return "Just now";
        }
        protected string GetImageUrl(object imagePath)
        {
            if (imagePath == null || string.IsNullOrEmpty(imagePath.ToString().Trim()))
            {
                return ResolveUrl("~/images/tr.png"); // Path to your default image
            }

            string path = imagePath.ToString().Trim();

            // Assuming images are stored as filenames, adjust as necessary
            return ResolveUrl("~/Images/" + path); // Adjust the path as necessary
        }



        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPostedWithin = GetSelectedPostedWithin();
            string selectedCountry = ddCountry.SelectedValue;
            string selectedJobTypes = GetSelectedJobTypes();

            BindJobData(selectedCountry, selectedJobTypes, selectedPostedWithin); // Rebind data after filtering
        }

        protected void lbFilter_Click(object sender, EventArgs e)
        {
            string selectedCountry = ddCountry.SelectedValue;
            string selectedJobTypes = GetSelectedJobTypes();
            string selectedPostedWithin = GetSelectedPostedWithin();

            BindJobData(selectedCountry, selectedJobTypes, selectedPostedWithin); // Rebind data after filtering
        }

        protected void lbReset_Click(object sender, EventArgs e)
        {
            ddCountry.SelectedIndex = 0; // Reset dropdown
            // Reset checkboxes and radio buttons
            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = false;
            }
            foreach (ListItem item in RadioButtonList1.Items)
            {
                item.Selected = false;
            }

            BindJobData(); // Rebind all job data
        }

        private string GetSelectedJobTypes()
        {
            // Get selected job types from CheckBoxList
            var selectedValues = CheckBoxList1.Items.Cast<ListItem>()
                                .Where(i => i.Selected)
                                .Select(i => $"'{i.Text}'");
            return string.Join(", ", selectedValues);
        }

        private string GetSelectedPostedWithin()
        {
            // Get selected posted date from RadioButtonList
            return RadioButtonList1.SelectedValue;
        }
        protected void ApplyJob_Command(object sender, CommandEventArgs e)
        {
            int jobId = Convert.ToInt32(e.CommandArgument);
            // Handle the application logic here
        }

    }
}

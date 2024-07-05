using System;
using System.Web.UI;

namespace Freelancing_Job_Board.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            if (Session["user"] != null)
            {
                lbRegisterOrProfile.Text = "Profile";
                lblLoginOrLogout.Text = "LogOut";
            }
            else
            {
                lbRegisterOrProfile.Text = "Register";
                lblLoginOrLogout.Text = "Login";
            }
        }

        protected void lbRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (lbRegisterOrProfile.Text == "Profile")
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void lblLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (lblLoginOrLogout.Text == "Login")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("LogOut.aspx");
            }
        }
    }
}

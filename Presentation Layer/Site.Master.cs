using System;

namespace StudentRegistrationSystem.Presentation_Layer
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                lblUser.Text =
                    "Welcome: " +
                    Session["UserName"].ToString();
            }
        }
    }
}
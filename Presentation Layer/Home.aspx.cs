using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_9.Presentation_Layer
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                lblWelcome.Text =
                    "Welcome " +
                    Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
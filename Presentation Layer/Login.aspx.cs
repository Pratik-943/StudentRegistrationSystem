using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab_9.Business_Access_Layer;
using Lab_9.Entity_Layer;

namespace Lab_9.Presentation_Layer
{
    public partial class Login : System.Web.UI.Page
    {
        UserService service =
            new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user =
                service.Login(
                    txtEmail.Text,
                    txtPassword.Text);

            if (user != null)
            {
                Session["UserName"] =
                    user.Name;

                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write(
                    "<script>alert('Invalid Email or Password');</script>");
            }
        }
    }
}
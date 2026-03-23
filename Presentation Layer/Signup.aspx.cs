using Lab_9.Business_Access_Layer;
using Lab_9.Entity_Layer;
using System;
using System.Xml.Linq;
using System.Web.UI.WebControls;

namespace Lab_9.Presentation_Layer
{
    public partial class Signup : System.Web.UI.Page
    {
        UserService service =
            new UserService();

        protected TextBox txtName;
        protected TextBox txtEmail;
        protected TextBox txtPassword;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            User u = new User();

            u.Name = txtName.Text;
            u.Email = txtEmail.Text;
            u.Password = txtPassword.Text;

            service.Register(u);

            Response.Write(
                "<script>alert('Signup Successful');</script>");

            Response.Redirect("Login.aspx");
        }
    }
}
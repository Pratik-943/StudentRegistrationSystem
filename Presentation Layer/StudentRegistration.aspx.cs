using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lab_9.Business_Access_Layer;
using Lab_9.Entity_Layer;

namespace Lab_9.Presentation_Layer
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        StudentService studentService =
            new StudentService();

        StateService stateService =
            new StateService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Session Protection
            if (Session["UserName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadStates();
                BindGrid();
            }
        }

        // =============================
        // LOAD STATES
        // =============================

        private void LoadStates()
        {
            ddlState.DataSource =
                stateService.GetStates();

            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";

            ddlState.DataBind();

            ddlState.Items.Insert(0,
                new ListItem("--Select State--", "0"));
        }

        // =============================
        // LOAD CITIES
        // =============================

        protected void ddlState_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            int stateId =
                Convert.ToInt32(
                    ddlState.SelectedValue);

            ddlCity.DataSource =
                stateService.GetCities(stateId);

            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";

            ddlCity.DataBind();

            ddlCity.Items.Insert(0,
                new ListItem("--Select City--", "0"));
        }

        // =============================
        // BIND GRID
        // =============================

        private void BindGrid()
        {
            gvStudent.DataSource =
                studentService.GetStudents();

            gvStudent.DataBind();
        }

        // =============================
        // SAVE (INSERT + UPDATE)
        // =============================

        protected void btnSave_Click(
            object sender,
            EventArgs e)
        {
            Student s = new Student();

            s.Name = txtName.Text;
            s.Phone = txtPhone.Text;
            s.Email = txtEmail.Text;
            s.Address = txtAddress.Text;

            s.Gender =
                rblGender.SelectedValue;

            // LANGUAGE
            string lang = "";

            foreach (ListItem item
                     in cblLanguage.Items)
            {
                if (item.Selected)
                {
                    lang += item.Text + ",";
                }
            }

            s.Language = lang;

            s.StateId =
                Convert.ToInt32(
                    ddlState.SelectedValue);

            s.CityId =
                Convert.ToInt32(
                    ddlCity.SelectedValue);

            // PHOTO UPLOAD

            if (fuPhoto.HasFile)
            {
                string folder =
                    Server.MapPath("~/Uploads/");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName =
                    fuPhoto.FileName;

                string path =
                    folder + fileName;

                fuPhoto.SaveAs(path);

                s.Photo =
                    "~/Uploads/" + fileName;
            }

            // INSERT OR UPDATE

            if (hfStudentId.Value == "")
            {
                studentService.AddStudent(s);
            }
            else
            {
                s.StudentId =
                    Convert.ToInt32(
                        hfStudentId.Value);

                studentService.UpdateStudent(s);

                hfStudentId.Value = "";
            }

            BindGrid();

            ClearForm();

            Response.Write(
                "<script>alert('Saved Successfully');</script>");
        }

        // =============================
        // GRID COMMAND
        // =============================

        protected void gvStudent_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    e.CommandArgument);

            // DELETE

            if (e.CommandName == "DeleteRecord")
            {
                studentService.DeleteStudent(id);

                BindGrid();
            }

            // EDIT

            else if (e.CommandName == "EditRecord")
            {
                Student s =
                    studentService.GetStudentById(id);

                hfStudentId.Value =
                    s.StudentId.ToString();

                txtName.Text = s.Name;
                txtPhone.Text = s.Phone;
                txtEmail.Text = s.Email;
                txtAddress.Text = s.Address;

                rblGender.SelectedValue =
                    s.Gender;

                ddlState.SelectedValue =
                    s.StateId.ToString();

                ddlState_SelectedIndexChanged(null, null);

                ddlCity.SelectedValue =
                    s.CityId.ToString();

                // LOAD LANGUAGE
                string[] langs = s.Language.Split(',');

                foreach (ListItem item in cblLanguage.Items)
                {
                    if (Array.IndexOf(langs, item.Text) >= 0)
                    {
                        item.Selected = true;
                    }
                }

                btnSave.Text = "Update";
                btnCancel.Visible = true;
            }
        }

        // =============================
        // CLEAR FORM
        // =============================

        private void ClearForm()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

            rblGender.ClearSelection();
            cblLanguage.ClearSelection();

            ddlState.SelectedIndex = 0;
            ddlCity.Items.Clear();

            hfStudentId.Value = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
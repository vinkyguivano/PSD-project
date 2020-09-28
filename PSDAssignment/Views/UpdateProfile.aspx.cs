using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                User user = UserController.getUserByID(Convert.ToInt32(Session["auth_user"]));
                if(!IsPostBack) {
                    NameTxt.Text = user.Name;
                    EmailTxt.Text = user.Email;
                    GenderList.SelectedIndex = user.Gender == "Male" ? 0:1;
                }
                
            }
            else Response.Redirect("Home.aspx");
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            User user = UserController.getUserByID(Convert.ToInt32(Session["auth_user"]));
            int id = user.Id;
            String name = NameTxt.Text;
            String email = EmailTxt.Text;
            String gender = GenderList.SelectedValue;
            clearLabel();
            if(!UserController.userValidation(email,name,gender,user.Email))
            {
                if (UserController.isEmpty(name)) NameLabel.Text = "Username must be filled";
                if (!UserController.emailValidation(email,user.Email))
                {
                    if (UserController.isEmpty(email)) EmailLabel.Text = "Email must be filled and unique";
                    else EmailLabel.Text = "Email must be unique";
                }

            }
            else
            {
                UserController.update(id, name, email, gender);
                Response.Redirect("Profile.aspx");
            }
            
        }

        protected void PasswordBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePassword.aspx");
        }

        protected void clearLabel()
        {
            EmailLabel.Text = "";
            NameLabel.Text = "";
        }
    }
}
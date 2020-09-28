using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            String gender = GenderList.SelectedValue;
            String name = NameTxt.Text;
            String password = PasswordTxt.Text;
            PasswordTxt.Attributes.Add("value", password);
            String repassword = ConfirmedPasswordTxt.Text;
            String email = EmailTxt.Text;
            int roleID = 2;
            String status = "Active";
            clearLabel();
            if (!RegisterController.register(name, email, password, status, gender, roleID, repassword)) {
                if (!RegisterController.EmailValidation(email)) {
                    if (RegisterController.isEmpty(email)) EmailLabel.Text = "Email must be filled and unique";
                    else EmailLabel.Text = "Email must be unique";
                }
                if (RegisterController.isEmpty(name)) NameLabel.Text = "Name must be filled";
                if (RegisterController.isEmpty(password)) PWLabel.Text = "Password must be filled";        
                if (!RegisterController.RePasswordValidation(password, repassword)) RePWLabel.Text = "Must be same with password";             
                if (RegisterController.isEmpty(gender)) GenderLabel.Text = "Gender must be choosen";
            }
            else
            {
               Response.Redirect("Login.aspx");
            }
        }

        protected void clearLabel()
        {
            EmailLabel.Text = "";
            NameLabel.Text = "";
            PWLabel.Text = "";
            RePWLabel.Text = "";
            GenderLabel.Text = "";
        }
    }
}
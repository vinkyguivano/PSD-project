using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;


namespace PSDAssignment.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["auth_user"] != null) {
                Response.Redirect("Home.aspx");
            }
            if(Request.Cookies["auth_user"]!=null) {
                User user = UserController.getUserByID(Convert.ToInt32(Request.Cookies["auth_user"].Value));
                if(!IsPostBack) {
                    EmailTxt.Text = user.Email;
                    PasswordTxt.Attributes["TextMode"] = "SingleLine";
                    PasswordTxt.Text = user.Password;
                    PasswordTxt.Attributes["TextMode"] = "Password";
                }
            }

        }
        protected void Login_Check(object sender, EventArgs e)
        {
            String email = EmailTxt.Text;
            String password = PasswordTxt.Text;
            PasswordTxt.Attributes.Add("value", password);
            bool isRememberActive = CookieBox.Checked;
            clearLabel();
            if (!LoginController.LoginValidation(email, password))
            {
                if (LoginController.isEmpty(email)) EmailLabel.Text = "Email must be filled";
                if (LoginController.isEmpty(password)) PasswordLabel.Text = "Password must be filled";
            
            }
            else
            { 
                int Login = LoginController.Login(email, password, isRememberActive);
                if(Login != 1)
                {
                    if (Login == -1)
                    {
                        MessageFailText.Text = "This user is curently inactive";
                    }
                     if (Login == -2)
                    {
                        MessageFailText.Text = "Email and Password do not match";
                    }
                }
                else 
                {
                    Response.Redirect("./Home.aspx");
                }
            }
        }

        protected void clearLabel()
        {
            EmailLabel.Text = "";
            PasswordLabel.Text = "";
            MessageFailText.Text = "";
        }
    }
}
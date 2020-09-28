using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["auth_user"] !=null)
            {
                 User user = UserController.getUserByID(Convert.ToInt32(Session["auth_user"]));
                 LabelName.Text = user.Name;
                 LabelEmail.Text = user.Email;
                 LabelGender.Text = user.Gender;
            }
            else {
                Response.Redirect("Login.aspx");
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }
    }
}
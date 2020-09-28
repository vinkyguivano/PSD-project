using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

            String oldPass = OldTxt.Text;
            OldTxt.Attributes.Add("value", oldPass);
            String newPass = NewTxt.Text;
            NewTxt.Attributes.Add("value", newPass);
            String confirm = ConfirmTxt.Text;
            ConfirmTxt.Attributes.Add("value", confirm);
            int check = UserController.passwordValidation(oldPass, newPass, confirm);
            clearLabel();
            if (check != 1)
            {
                if (check == -1) OldPassLbl.Text = "Must be same with current password";
                if (check == -2) NewPassLbl.Text = "Must be filled and cannot be same with old password";
                if (check == -3) NewPassLbl.Text = "Cannot be same with old password";
                if (check == -4) ConfirmLabel.Text = "Must be same with new password";
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void clearLabel()
        {
            OldPassLbl.Text = "";
            NewPassLbl.Text = "";
            ConfirmLabel.Text = "";
        }
    }
}
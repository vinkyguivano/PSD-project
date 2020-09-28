using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;


namespace PSDAssignment.Views
{
    public partial class AddPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                if (UserController.getUserByID(Convert.ToInt32(Session["auth_user"])).RoleID != 3)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else Response.Redirect("Home.aspx");
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            String type = PaymentTypeTxt.Text;
            int isValid = PaymentTypeController.PaymentTypeValidation(type);
            if (isValid == -1) TypeLabel.Text = "Type must be filled, unique and consist of 3 chars or more";
            else if (isValid == -2) TypeLabel.Text = "Type must consist of 3 chars or more and unique";
            else if (isValid == -3) TypeLabel.Text = "Type must be unique";
            else
            {
                PaymentTypeController.add(type);
                Response.Redirect("ViewPaymentType.aspx");
            }
        }
    }
}
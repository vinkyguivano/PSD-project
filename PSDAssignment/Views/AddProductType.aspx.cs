using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class AddProductType : System.Web.UI.Page
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

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            String name = TypeNameTxt.Text;
            String desc = TypeDescriptionTxt.Text;
            clearLabel();
            if(ProductTypeController.PTValidation(name,desc)) {
                ProductTypeController.addProductType(name, desc);
                Response.Redirect("ProductType.aspx");
            }
            else {
                int error = ProductTypeController.NameValidation(name);
                if (error == -1) TypeTxt.Text = "Name must be filled, unique and consists of 5 characters or more";
                else if (error == -2) TypeTxt.Text = "Name must consists of 5 characters or more and unique";
                else if (error == -3 )TypeTxt.Text = "Name must be unique";
                if (ProductTypeController.DescValidation(desc) == -1)
                {
                    DescLabel.Text = "Description must be filled";
                }
            }
        }

        protected void clearLabel()
        {
            TypeTxt.Text = "";
            DescLabel.Text = "";
        }
    }
}
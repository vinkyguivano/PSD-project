using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class AddProduct : System.Web.UI.Page
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

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            String productName = ProductNameTxt.Text;
            int productPrice =  ProductController.inttypecheck(ProdcutPriceTxt.Text);
            int productStock = ProductController.inttypecheck(ProductStockTxt.Text);
            int productTypeID = Convert.ToInt32(ProductTypeList.SelectedItem.Value);
            clearLabel();
            if(!ProductController.newProductValidation(productName, productPrice, productStock, productTypeID))
            {
                if (!ProductController.NameValidation(productName)) NameLabel.Text = "Product Name must be filled";
                if (!ProductController.StockValidation(productStock)) StockLabel.Text = "Product stock must be 1 or more";
                if (!ProductController.PriceValidation(productPrice) && productPrice <=1000 ) PriceLabel.Text = "Price must be more than 1000 and multiply of 1000";
                else if (!ProductController.PriceValidation(productPrice) && productPrice % 1000 != 0 ) PriceLabel.Text = "Price must be multiply of 1000 ";
            }
            else
            {
                ProductController.addProduct(productName, productPrice, productStock, productTypeID);
                Response.Redirect("ViewProduct.aspx");
            }
           
        }

        protected void clearLabel()
        {
            NameLabel.Text = "";
            StockLabel.Text = "";
            PriceLabel.Text = "";
        }
    }
}
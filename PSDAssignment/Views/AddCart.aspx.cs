using PSDAssignment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDAssignment.Views
{
    public partial class AddCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                if (UserController.getUserByID(Convert.ToInt32(Session["auth_user"])).RoleID == 2)
                {
                    if (Request.QueryString["productID"] == null)
                    {
                        Response.Redirect("Home.aspx");
                    }
                    Product product = ProductController.getProductByID(Convert.ToInt32(Request.QueryString["productID"]));
                    if (product == null)
                    {
                        Response.Redirect("Home.aspx");
                    }
                    if (!IsPostBack)
                    {
                        ProductNameTxt.Text = product.Name;
                        ProductPriceTxt.Text = Convert.ToString(product.Price);
                        ProductStockTxt.Text = Convert.ToString(product.Stock);
                        ProductTypeTxt.Text = product.ProductType.Name;
                    }
                }

            }
            else Response.Redirect("Home.aspx");
        }

        protected void BtnAddCart_Click(object sender, EventArgs e)
        {
            int stock = Convert.ToInt32(ProductStockTxt.Text);
            int quantity = ProductController.inttypecheck(QuantityTxt.Text);
            int productid = Convert.ToInt32(Request.QueryString["productID"]);

            if (CartController.QtyValidation(quantity, stock))
            {
                if (CartController.add(productid, quantity)){
                    Response.Redirect("ViewCart.aspx");
                }
                else
                {
                    ValidateQty.Text = "New Quantity exceed product stock(" + ProductStockTxt.Text.ToString() + ")";
                }
                    
            }
            else
            {
                ValidateQty.Text = "Quantity must between 1 and " + ProductStockTxt.Text.ToString();
            }
        }
    }
}
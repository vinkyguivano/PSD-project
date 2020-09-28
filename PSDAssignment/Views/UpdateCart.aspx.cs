using PSDAssignment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDAssignment.Views
{
    public partial class UpdateCart : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(Request.QueryString["productID"]);
            int userid = Convert.ToInt32(Session["auth_user"]);
            Cart cart = CartController.getCart(productid,userid);
            if  (cart == null)
            {
                Response.Redirect("Home.aspx");
            }
            if (!IsPostBack)
            {
                ProductNameTxt.Text = cart.Product.Name;
                ProductPriceTxt.Text = Convert.ToString(cart.Product.Price);
                ProductStockTxt.Text = Convert.ToString(cart.Product.Stock);
                ProductTypeTxt.Text = cart.Product.ProductType.Name;
                QuantityTxt.Text = cart.Quantity.ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(Request.QueryString["productID"]);
            int userid = Convert.ToInt32(Session["auth_user"]);
            int qty = ProductController.inttypecheck(QuantityTxt.Text);
            int stock = Convert.ToInt32(ProductStockTxt.Text);
            if (CartController.QtyValidation2(qty,stock))
            {
                CartController.update(userid, productid, qty);
                Response.Redirect("ViewCart.aspx");
            }
            else
            {
                ValidateQty.Text = "Item must between 0 and " + ProductStockTxt.Text.ToString();
            }
        }
    }
}
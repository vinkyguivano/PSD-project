using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                if (UserController.getUserByID(Convert.ToInt32(Session["auth_user"])).RoleID == 3)
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
                        ProductNameTxtss.Text = product.Name;
                        ProdcutPriceTxts.Text = Convert.ToString(product.Price);
                        ProductStockTxts.Text = Convert.ToString(product.Stock);
                        ProductTypeLists.SelectedValue = Convert.ToString(product.ProductTypeID);

                    }
                }

            }
            else Response.Redirect("Home.aspx");
                
            
        }

        protected void BtnEdit_Click(object sender, EventArgs e) { 
            int productID = Convert.ToInt32(Request.QueryString["productID"]);
            String productName = ProductNameTxtss.Text;
            System.Diagnostics.Debug.WriteLine(productName);
             int productPrice =  ProductController.inttypecheck(ProdcutPriceTxts.Text);
            int productStock = ProductController.inttypecheck(ProductStockTxts.Text);
            int productTypeID = Convert.ToInt32(ProductTypeLists.SelectedValue);
            clearLabel();
            if (!ProductController.newProductValidation(productName, productPrice, productStock, productTypeID))
            {
                if (!ProductController.NameValidation(productName)) NameLabel.Text = "Product Name must be filled";
                if (!ProductController.StockValidation(productStock)) StockLabel.Text = "Product stock must be 1 or more";
                if (!ProductController.PriceValidation(productPrice) && productPrice <= 1000) PriceLabel.Text = "Price must be more than 1000 and multiply of 1000 ";
                else if (!ProductController.PriceValidation(productPrice) && productPrice % 1000 != 0) PriceLabel.Text = "Price must be multiply of 1000";
            }
            else
            {
                ProductController.updateProduct(productID, productName, productPrice, productStock, productTypeID);
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
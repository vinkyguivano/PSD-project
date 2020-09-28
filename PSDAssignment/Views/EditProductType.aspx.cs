using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class EditProductType : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productTypeID"] == null)
            {
                Response.Redirect("ProductType.aspx");
            }
            PSDAssignment.ProductType productType = ProductTypeController.getProductTypeByID(Convert.ToInt32(Request.QueryString["productTypeID"]));
            if (productType == null)
            {
                Response.Redirect("ProductType.aspx");
            }
            if(!IsPostBack)
            {
             TypeNameTxts.Text = productType.Name;
             TypeDescriptionTxts.Text = productType.Description;
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            PSDAssignment.ProductType productType = ProductTypeController.getProductTypeByID(Convert.ToInt32(Request.QueryString["productTypeID"]));
            int productTypeID = productType.Id;
            String productTypeName = TypeNameTxts.Text;
            String productTypeDesc = TypeDescriptionTxts.Text;
            clearLabel();
            if (ProductTypeController.PTUpdateValidation(productTypeName, productTypeDesc, productType))
            {
                ProductTypeController.updateProductType(productTypeID, productTypeName, productTypeDesc);
                Response.Redirect("ProductType.aspx");
            }
            else
            {
                int error = ProductTypeController.NameUpdateValidation(productTypeName,productType.Name);
                if (error == -1) TypeTxt.Text = "Name must be filled, unique and consists of 5 characters or more";
                else if (error == -2) TypeTxt.Text = "Name must consists of 5 characters or more and unique";
                else if(error == -3 )TypeTxt.Text = "Name must be unique";
                if (ProductTypeController.DescValidation(productTypeDesc) == -1)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;
using PSDAssignment.Handler;

namespace PSDAssignment.Views
{
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                List<Product> productList = ProductController.getRandomProduct();
                for (int i = 0; i < productList.Count; i++)
                {
                    TableRow newRow = new TableRow();
                    ProductTable.Controls.Add(newRow);

                    TableCell productIdCell = new TableCell();
                    productIdCell.Controls.Add(new Label()
                    {
                        Text = productList.ElementAt(i).Id.ToString()
                    });
                    newRow.Cells.Add(productIdCell);

                    TableCell productNameCell = new TableCell();
                    productNameCell.Controls.Add(new Label()
                    {
                        Text = productList.ElementAt(i).Name.ToString()
                    });
                    newRow.Cells.Add(productNameCell);

                    TableCell productPriceCell = new TableCell();
                    productPriceCell.Controls.Add(new Label()
                    {
                        Text = "Rp" + productList.ElementAt(i).Price.ToString()
                    });
                    newRow.Cells.Add(productPriceCell);
                    TableCell productStockCell = new TableCell();
                    productStockCell.Controls.Add(new Label()
                    {
                        Text = productList.ElementAt(i).Stock.ToString()
                    });
                    newRow.Cells.Add(productStockCell);

                    TableCell productTypeCell = new TableCell();
                    int productTypeID = Convert.ToInt32(productList.ElementAt(i).ProductTypeID);
                    if (productTypeID != null)
                    {
                        if (ProductTypeController.getProductTypeByID(productTypeID) != null)
                        {
                            String productTypeName = ProductTypeController.getProductTypeByID(productTypeID).Name;
                            productTypeCell.Controls.Add(new Label()
                            {
                                Text = productTypeName
                            });
                    }

                    }
                    newRow.Cells.Add(productTypeCell);
                    if (Session["auth_user"] != null)
                    {
                        if (UserHandler.findUserByID(Convert.ToInt32(Session["auth_user"])).RoleID == 2)
                        {

                            TableCell ActionCell = new TableCell();
                            int id = productList.ElementAt(i).Id;
                            if (productList.ElementAt(i).Stock != 0)
                            {
                            
                                Button text = new Button() { CssClass = "btn-primary", Text = "Add To Cart", ID = id.ToString() };
                                text.Click += new EventHandler(AddToCart);
                                ActionCell.Controls.Add(text);
                                newRow.Cells.Add(ActionCell);
                            }
                            else
                            {
                                ActionCell.Controls.Add(new Label()
                                {
                                    Text = "Stock is empty"
                                });
                                newRow.Cells.Add(ActionCell);
                            }
                        }
                    }
                
            }
        }

        protected void AddToCart(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int id = Int32.Parse(currentButton.ID);

        
            Response.Redirect("AddCart.aspx?productid=" + id);
        }
    }
}
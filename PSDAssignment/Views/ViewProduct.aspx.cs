using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Load_Products() {
            List<Product> productList = ProductController.getAllProducts();
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
                    Text = "Rp." + productList.ElementAt(i).Price.ToString()
                });
                newRow.Cells.Add(productPriceCell);
                TableCell productStockCell = new TableCell();
                productStockCell.Controls.Add(new Label()
                {
                    Text = productList.ElementAt(i).Stock.ToString()
                });
                newRow.Cells.Add(productStockCell);

                TableCell productTypeCell = new TableCell();
                int productID = Convert.ToInt32(productList.ElementAt(i).ProductTypeID);
                String productTypeName = ProductTypeController.getProductTypeByID(productID).Name;
                productTypeCell.Controls.Add(new Label()
                {
                    Text = productTypeName
                });

                newRow.Cells.Add(productTypeCell);

                User user = UserController.getUserByID(Convert.ToInt32(Session["auth_user"]));
               if (user!=null) {
                    
                        TableCell ActionCell = new TableCell();
                        int id = productList.ElementAt(i).Id;
                    if (user.RoleID == 3)
                    {
                        Button btnEdit = new Button { CssClass = "btn-primary", Text = "Edit", ID = id.ToString() };
                        Button btnDelete = new Button { CssClass = "btn-danger", Text = "Delete", ID = id.ToString() + "delete" };
                        btnEdit.Click += new EventHandler(Btn_Edit_Click);
                        btnDelete.Click += new EventHandler(DeleteProduct);
                        ActionCell.Controls.Add(btnEdit);
                        ActionCell.Controls.Add(btnDelete);
                        newRow.Cells.Add(ActionCell);

                    }
                    else
                    {
                        if (productList.ElementAt(i).Stock != 0)
                        {
                            Button text = new Button() { CssClass = "btn-primary", Text = "Add To Cart", ID = id.ToString() };
                            text.Click += new EventHandler(BtnBuy_Click);
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

        protected void DeleteProduct(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            String id = currentButton.ID.Substring(0, currentButton.ID.IndexOf('d'));
            int selectedRowID = Int32.Parse(id);
            ProductController.deleteProduct(selectedRowID);
            Response.Redirect("ViewProduct.aspx");
        }

        protected void Btn_Edit_Click(object sender, EventArgs e) {
            Button currentButton = (Button)sender;
            int selectedRowID = Int32.Parse(currentButton.ID);
            Response.Redirect("EditProduct.aspx?productID=" + selectedRowID);
        }

        protected void BtnBuy_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int id = Int32.Parse(currentButton.ID);
            Response.Redirect("AddCart.aspx?productID=" + id);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Products();
        }
    }
}
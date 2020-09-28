using PSDAssignment.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDAssignment.Views
{
    public partial class ViewCart : System.Web.UI.Page
    {
                            
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Carts();
        }

        protected void Load_Carts()
        {
            List<Cart> carts = CartController.getCartsById(Convert.ToInt32(HttpContext.Current.Session["auth_user"]));
            if (carts.Count() != 0)
            {
                long grandtotal = 0, subtotal = 0;
                foreach (Cart i in carts)
                {
                    TableRow newRow = new TableRow();
                    CartTable.Controls.Add(newRow);

                    TableCell productIdCell = new TableCell();
                    productIdCell.Controls.Add(new Label()
                    {
                        Text = i.ProductID.ToString()
                    });
                    newRow.Controls.Add(productIdCell);

                    TableCell productNameCell = new TableCell();
                    productNameCell.Controls.Add(new Label()
                    {
                        Text = i.Product.Name.ToString()
                    });
                    newRow.Controls.Add(productNameCell);

                    TableCell productPriceCell = new TableCell();
                    productPriceCell.Controls.Add(new Label()
                    {
                        Text = "Rp." + i.Product.Price.ToString()
                    });
                    newRow.Controls.Add(productPriceCell);

                    TableCell QuantityCell = new TableCell();
                    QuantityCell.Controls.Add(new Label()
                    {
                        Text = i.Quantity.ToString() 
                    });
                    newRow.Controls.Add(QuantityCell);

                    subtotal = i.Quantity * i.Product.Price;
                    TableCell SubTotalCell = new TableCell();
                    SubTotalCell.Controls.Add(new Label()
                    {
                        Text = "Rp." + subtotal.ToString()
                    });
                    newRow.Controls.Add(SubTotalCell);

                    grandtotal += subtotal;

                    TableCell ActionCell = new TableCell();
                    int iD = i.ProductID;
                    Button btnEdit = new Button { CssClass = "btn-primary", Text = "Edit", ID = iD.ToString() };
                    Button btnDelete = new Button { CssClass = "btn-danger", Text = "Delete", ID = iD.ToString() + "delete" };
                    btnEdit.Click += new EventHandler(Btn_Edit_Click);
                    btnDelete.Click += new EventHandler(DeleteCart);
                    ActionCell.Controls.Add(btnEdit);
                    ActionCell.Controls.Add(btnDelete);
                    newRow.Cells.Add(ActionCell);
                }
                
                TableRow newRow2 = new TableRow();
                CartTable.Controls.Add(newRow2);

                TableCell GrandTotalCell = new TableCell();
                GrandTotalCell.ColumnSpan = 6;
                GrandTotalCell.Controls.Add(new Label()
                {
                    Text = "GrandTotal = Rp." + grandtotal.ToString()
                });
                newRow2.Controls.Add(GrandTotalCell);
            }
            else
            {
                validate.Text = "My Cart is Empty!";
                Select.Visible = false;
                PaymentTypeList.Visible = false;
                CheckoutBtn.Visible = false;
            }
        }

        protected void Btn_Edit_Click(Object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedRowID = Int32.Parse(currentButton.ID);
            Response.Redirect("UpdateCart.aspx?ProductID=" + selectedRowID);
        }

        protected void DeleteCart(Object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            String id = currentButton.ID.Substring(0, currentButton.ID.IndexOf('d'));
            System.Diagnostics.Debug.WriteLine(id);
            int selectedRowID = Int32.Parse(id);
            CartController.delete(selectedRowID,Convert.ToInt32(Session["auth_user"]));
            Response.Redirect("ViewCart.aspx");
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["auth_user"]);
            int paymenttypeid = Convert.ToInt32(PaymentTypeList.SelectedValue);
            List<Cart> carts = CartController.getCartsById(Convert.ToInt32(HttpContext.Current.Session["auth_user"]));
            TransactionController.checkout(userid, paymenttypeid, carts);
            Response.Redirect("Home.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class ViewTransactionHistory : System.Web.UI.Page
    {

        protected void fillAdminData()
        {
            List<HeaderTransaction> headerTransactionList = TransactionController.getAllHeaderTransaction();
            renderTable(headerTransactionList);
        }

        protected void renderTable(List<HeaderTransaction> headerTransactionList) {
            for (int i = 0; i < headerTransactionList.Count; i++)
            {
                TableRow newRow = new TableRow();
                TransactionHistoryTable.Controls.Add(newRow);

                TableCell transactionDateCell = new TableCell();
                transactionDateCell.Controls.Add(new Label()
                {
                    Text = headerTransactionList.ElementAt(i).Date.ToString()
                });
                newRow.Cells.Add(transactionDateCell);

                TableCell transactionTypeCell = new TableCell();
                transactionTypeCell.Controls.Add(new Label()
                {
                    Text = headerTransactionList.ElementAt(i).PaymentType.Type.ToString()
                });
                newRow.Cells.Add(transactionTypeCell);

                List<DetailTransaction> detailTransactionList = TransactionController.getAllDetailTransactionById(headerTransactionList.ElementAt(i).Id);
  
                DetailTransaction detailTransaction = detailTransactionList.ElementAt(0);
                Product product = ProductController.getProductByID(detailTransaction.ProductID);
                 

                TableCell productNameCell = new TableCell();
                productNameCell.Controls.Add(new Label()
                {
                    Text = product.Name
                });
                newRow.Cells.Add(productNameCell);

                TableCell productQuantityCell = new TableCell();
                productQuantityCell.Controls.Add(new Label()
                {
                    Text = detailTransaction.Quantity.ToString()
                });
                newRow.Cells.Add(productQuantityCell);

                TableCell subTotalCell = new TableCell();
                subTotalCell.Controls.Add(new Label()
                {
                    Text = "Rp " + TransactionController.getSubTotal(detailTransaction).ToString()
                });
                newRow.Cells.Add(subTotalCell);

                TableCell actionButtonCell = new TableCell();
                Button text = new Button() { CssClass = "btn-primary", Text = "ViewReport", ID = headerTransactionList.ElementAt(i).Id.ToString() };
                text.Click += new EventHandler(Btn_View_Click);
                actionButtonCell.Controls.Add(text);
                newRow.Cells.Add(actionButtonCell);


                if (detailTransactionList.Count > 1)
                {
                    for (int j = 1; j < detailTransactionList.Count; j++)
                    {
                        TableRow newRows = new TableRow();
                        TransactionHistoryTable.Controls.Add(newRows);
                        DetailTransaction detailTransaction1 = detailTransactionList.ElementAt(j);
                        Product product1 = ProductController.getProductByID(detailTransaction1.ProductID);
                        TableCell cell1 = new TableCell();
                        newRows.Cells.Add(cell1);
                        TableCell cell2 = new TableCell();
                        newRows.Cells.Add(cell2);
                        TableCell productNameCells = new TableCell();
                        productNameCells.Controls.Add(new Label()
                        {
                            Text = product1.Name
                        });
                        newRows.Cells.Add(productNameCells);

                        TableCell productQuantityCells = new TableCell();
                        productQuantityCells.Controls.Add(new Label()
                        {
                            Text = detailTransaction1.Quantity.ToString()
                        });
                        newRows.Cells.Add(productQuantityCells);

                        TableCell subTotalCells = new TableCell();
                        subTotalCells.Controls.Add(new Label()
                        {
                            Text = "Rp " + TransactionController.getSubTotal(detailTransaction1).ToString()
                        });
                        newRows.Cells.Add(subTotalCells);

                        TableCell cell4 = new TableCell();
                        newRows.Cells.Add(cell4);

                    }
                }
            }
        }

        protected void fillUserData()
        {
            User user = UserController.getUserByID(Convert.ToInt32(Session["auth_user"]));
            List<HeaderTransaction> headerTransactionList = TransactionController.getHeaderTransactionsByID(user.Id);
            renderTable(headerTransactionList);
        }

        protected void Btn_View_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedRowID = Int32.Parse(currentButton.ID);
            Response.Redirect("UserReportTransaction.aspx?transactionID=" + selectedRowID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                if (UserController.getUserByID(Convert.ToInt32(Session["auth_user"])).RoleID == 3)
                {
                    fillAdminData();
                }
                else fillUserData();
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}
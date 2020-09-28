using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_PaymentTypes();
        }

        protected void Load_PaymentTypes()
        {
            List<PaymentType> paymentTypeList = PaymentTypeController.getAllPaymentTypes();

            for (int i = 0; i < paymentTypeList.Count; i++)
            {
                TableRow newRow = new TableRow();
                PaymentTypeTable.Controls.Add(newRow);

                TableCell paymentTypeIdCell = new TableCell();
                paymentTypeIdCell.Controls.Add(new Label()
                {
                    Text = paymentTypeList.ElementAt(i).ID.ToString()
                });
                newRow.Cells.Add(paymentTypeIdCell);

                TableCell typeCell = new TableCell();
                typeCell.Controls.Add(new Label()
                {
                    Text = paymentTypeList.ElementAt(i).Type
                });
                newRow.Cells.Add(typeCell);

                User user = UserController.getUserByID(Convert.ToInt32(Session["auth_user"]));
                if (user != null)
                {
                    TableCell ActionCell = new TableCell();
                    int id = paymentTypeList.ElementAt(i).ID;
                    if (user.RoleID == 3)
                    {
                        Button btnUpdate = new Button { CssClass = "btn-primary", Text = "Update", ID = id.ToString() };
                        Button btnDelete = new Button { CssClass = "btn-danger", Text = "Delete", ID = id.ToString() + "delete" };
                        btnUpdate.Click += new EventHandler(Btn_Update_Click);
                        btnDelete.Click += new EventHandler(Btn_Delete_Click);
                        ActionCell.Controls.Add(btnUpdate);
                        ActionCell.Controls.Add(btnDelete);
                        newRow.Cells.Add(ActionCell);
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
            }
        }

        protected void Btn_Insert_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            Response.Redirect("AddPaymentType.aspx");
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedRowID = Int32.Parse(currentButton.ID);
            Response.Redirect("UpdatePaymentType.aspx?paymentTypeID=" + selectedRowID);
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            String id = currentButton.ID.Substring(0, currentButton.ID.IndexOf('d'));
            int selectedRowID = Int32.Parse(id);
            PaymentTypeController.delete(selectedRowID);
            Response.Redirect("ViewPaymentType.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class ProductType : System.Web.UI.Page
    {

        protected void Load_Types() {
            List<PSDAssignment.ProductType> productTypeList = ProductTypeController.getAllProductType();
            for (int i = 0; i < productTypeList.Count; i++)
            {
                TableRow newRow = new TableRow();
                ProductTable.Controls.Add(newRow);

                TableCell typeIDCell = new TableCell();
                typeIDCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).Id.ToString()
                });
                newRow.Cells.Add(typeIDCell);
                TableCell typeNameCell = new TableCell();
                typeNameCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).Name.ToString()
                });
                newRow.Cells.Add(typeNameCell);
                TableCell typeDescCell = new TableCell();
                typeDescCell.Controls.Add(new Label()
                {
                    Text = productTypeList.ElementAt(i).Description.ToString()
                });
                newRow.Cells.Add(typeDescCell);

                TableCell ActionCell = new TableCell();
                Button btnEdit = new Button { CssClass = "btn-primary", Text = "Edit", ID = productTypeList.ElementAt(i).Id.ToString() };
                Button btnDelete = new Button { CssClass = "btn-danger", Text = "Delete", ID = productTypeList.ElementAt(i).Id.ToString()+"delete" };
                int id = productTypeList.ElementAt(i).Id;
                btnDelete.Click += new EventHandler(DeleteProductType);
                btnEdit.Click += new EventHandler(Btn_Edit_Click);
                ActionCell.Controls.Add(btnEdit);
                ActionCell.Controls.Add(btnDelete);
                newRow.Cells.Add(ActionCell);
            }
        }

        protected void DeleteProductType(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            String id = currentButton.ID.Substring(0, currentButton.ID.IndexOf('d'));
            int selectedRowID = Int32.Parse(id);
            ProductTypeController.deleteProductType(selectedRowID);
            Response.Redirect("ProductType.aspx");
        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int selectedRowID = Int32.Parse(currentButton.ID);
            Response.Redirect("EditProductType.aspx?productTypeID=" + selectedRowID);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Types();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Helper;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class ReportTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (UserController.getUserByID(Convert.ToInt32(Session["auth_user"])).RoleID == 3)
                {
                    TransactionReport reportTransaction = new TransactionReport();
                    CrystalReportViewer1.ReportSource = reportTransaction;
                    reportTransaction.SetDataSource(ReportHelper.GenerateData(TransactionController.getAllHeaderTransaction()));
                }
                else {
                    Response.Redirect("Home.aspx");
                }
        }


    }
}
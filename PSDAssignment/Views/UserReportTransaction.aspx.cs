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
    public partial class UserReportTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["transactionID"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            if (Session["auth_user"] != null)
            {
                TransactionReport reportTransaction = new TransactionReport();
                CrystalReportViewer1.ReportSource = reportTransaction;
                List<HeaderTransaction> headerTransactionList = TransactionController.getHeaderTransactionsByHTID(Convert.ToInt32(Request.QueryString["transactionID"]));
                reportTransaction.SetDataSource(ReportHelper.GenerateData(headerTransactionList));
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}
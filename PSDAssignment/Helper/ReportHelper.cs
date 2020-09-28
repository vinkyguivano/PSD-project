using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDAssignment.Handler;
namespace PSDAssignment.Helper
{
    public class ReportHelper
    {
        public static DataSet1 GenerateData(List<HeaderTransaction> transactionList)
        {
            DataSet1 dataSet = new DataSet1();
            var headerTransactionTable = dataSet.HeaderTransaction;
            var detailTransactionTable = dataSet.DetailTransaction;

            foreach (var ht in transactionList)
            {
                var headerTransactionRow = headerTransactionTable.NewRow();
                headerTransactionRow["TransactionId"] = ht.Id;
                User user = UserHandler.findUserByID(ht.UserID.GetValueOrDefault());
                String paymentTypeName = PaymentTypeHandler.getPaymentTypeByID(ht.PaymentTypeID).Type;
                headerTransactionRow["UserName"] = user.Name;
                headerTransactionRow["Date"] = ht.Date;
                headerTransactionRow["PaymentTypeName"] = paymentTypeName;

                long grandTotal = 0;
                foreach (var dt in ht.DetailTransactions)
                {
                    var detailTransactionRow = detailTransactionTable.NewRow();
                    Product product = ProductHandler.getProductByID(dt.ProductID);
                    detailTransactionRow["TransactionId"] = dt.TransactionID;
                    detailTransactionRow["ProductName"] = product.Name;
                    detailTransactionRow["ProductPrice"] = "Rp "+product.Price;
                    detailTransactionRow["Quantity"] = dt.Quantity;
                    int subTotal = dt.Quantity * product.Price;
                    detailTransactionRow["SubTotal"] = "Rp " + subTotal;
                    grandTotal += subTotal;
                    detailTransactionTable.Rows.Add(detailTransactionRow);
                }
                headerTransactionRow["GrandTotal"] = "Rp " + grandTotal;
                headerTransactionTable.Rows.Add(headerTransactionRow);
            }
            return dataSet;
        }

    }
}
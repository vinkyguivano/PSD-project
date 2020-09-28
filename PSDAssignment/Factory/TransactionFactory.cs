using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Factory
{
    public class TransactionFactory
    {
        public static HeaderTransaction headerTransaction(int userId, int paymentTypeId, DateTime date)
        {
            return new HeaderTransaction()
            {
                UserID = userId,
                PaymentTypeID = paymentTypeId,
                Date = date
            };
        }

        public static DetailTransaction detailTransaction (int transactionId, int productId, int quantity)
        {
            return new DetailTransaction()
            {
                TransactionID = transactionId,
                ProductID = productId,
                Quantity = quantity
            };
        }
    }
}
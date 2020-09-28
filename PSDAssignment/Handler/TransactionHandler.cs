using PSDAssignment.Factory;
using PSDAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Handler
{
    public class TransactionHandler
    {
        public static void checkout(int userid, int paymentTypeid, List<Cart> carts)
        {
            HeaderTransaction headerTransaction = TransactionFactory.headerTransaction(userid, paymentTypeid, DateTime.Now);
            int TrID = TransactionRepository.addHT(headerTransaction).Id;

            foreach (Cart i in carts)
            {
                DetailTransaction detailTransaction = TransactionFactory.detailTransaction(TrID, i.ProductID, i.Quantity);
                TransactionRepository.addDT(detailTransaction);
                ProductRepository.decreaseproduct(i.ProductID, i.Quantity);
            }

            CartRepository.deleteCarts(carts);
        }

        public static List<HeaderTransaction> getHeaderTransactionsByID(int userId) {
            return TransactionRepository.getHTByID(userId).ToList();
        }
        public static List<HeaderTransaction> getHeaderTransactionsByHTID(int htId)
        {
            return TransactionRepository.getHTByHTID(htId);
        }
        public static List<HeaderTransaction> getAllHeaderTransaction() {
            return TransactionRepository.getAllHeaderTransaction();
        }

        public static List<DetailTransaction> getAllDetailTransactionById(int headerTransactionId) {
            return TransactionRepository.getAllDetailTransactionById(headerTransactionId);
        }

        public static long getSubTotal(DetailTransaction dt) {
            long subTotal = 0;
            subTotal = dt.Quantity * dt.Product.Price;
                return subTotal;
        }
    }
}
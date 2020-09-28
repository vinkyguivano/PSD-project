using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class TransactionController
    {
        public static void checkout(int userid, int paymenttypeid, List<Cart> carts)
        {
            TransactionHandler.checkout(userid, paymenttypeid, carts);
        }

        public static List<HeaderTransaction> getHeaderTransactionsByID(int userId)
        {
            return TransactionHandler.getHeaderTransactionsByID(userId).ToList();
        }
        public static List<HeaderTransaction> getHeaderTransactionsByHTID(int htId)
        {
            return TransactionHandler.getHeaderTransactionsByHTID(htId);
        }
        public static List<HeaderTransaction> getAllHeaderTransaction()
        {
            return TransactionHandler.getAllHeaderTransaction();
        }

        public static List<DetailTransaction> getAllDetailTransactionById(int headerTransactionId)
        {
            return TransactionHandler.getAllDetailTransactionById(headerTransactionId);
        }

        public static long getSubTotal(DetailTransaction detailtransaction)
        {
            return TransactionHandler.getSubTotal(detailtransaction);
        }
    }
}
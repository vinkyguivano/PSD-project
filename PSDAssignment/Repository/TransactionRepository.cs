using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class TransactionRepository
    {
        private static MyDBEntities db = DBSingleton.GetInstance();

        public static HeaderTransaction addHT(HeaderTransaction HT)
        {
            db.HeaderTransactions.Add(HT);
            db.SaveChanges();
            return HT;
        }

        public static DetailTransaction addDT(DetailTransaction DT)
        {
            db.DetailTransactions.Add(DT);
            db.SaveChanges();
            return DT;
        }

        public static List<HeaderTransaction> getHTByID(int userId) {
            return (from x in db.HeaderTransactions
                    where x.UserID == userId
                    select x).ToList();
        }
        public static List<HeaderTransaction> getHTByHTID(int htID)
        {
            return (from x in db.HeaderTransactions
                    where x.Id == htID
                    select x).ToList();
        }

        public static List<HeaderTransaction> getAllHeaderTransaction() {
            return db.HeaderTransactions.ToList();
        }

        public static List<DetailTransaction> getAllDetailTransactionById(int headerTransactionId) {
            return (from x in db.DetailTransactions
                    where x.TransactionID == headerTransactionId
                    select x
            ).ToList();
        }
    }
}
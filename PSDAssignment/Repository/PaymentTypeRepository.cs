using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class PaymentTypeRepository
    {
        private static MyDBEntities db = DBSingleton.GetInstance();

        public static void add(PaymentType paymentType)
        {
            db.PaymentTypes.Add(paymentType);
            db.SaveChanges();
        }

        public static void delete(int paymentTypeID)
        {
            PaymentType paymentType = getPaymentTypeByID(paymentTypeID);
            db.PaymentTypes.Remove(paymentType);
            db.SaveChanges();
        }

        public static void update(int paymentTypeID, String type)
        {
            PaymentType paymentType = PaymentTypeRepository.getPaymentTypeByID(paymentTypeID);
            paymentType.Type = type;
            db.SaveChanges();
        }

        public static List<PaymentType> getAllPaymentTypes()
        {
            List<PaymentType> paymentTypeList = db.PaymentTypes.ToList();
            if (paymentTypeList.Count != 0)
            {
                return db.PaymentTypes.ToList();
            }
            return paymentTypeList;
        }

        public static PaymentType getPaymentTypeByID(int paymentTypeID)
        {
            return (from x in db.PaymentTypes
                    where x.ID == paymentTypeID
                    select x).FirstOrDefault();
        }

        //public static paymenttype getpaymenttype(int paymenttypeid)
        //{
        //    return db.PaymentTypes.where(x => x.id == paymenttypeid).firstordefault();
        //}

        public static PaymentType getPaymentTypeByName(String type)
        {
            return db.PaymentTypes.Where(x => x.Type.Equals(type)).FirstOrDefault();
            
        }
    }
}
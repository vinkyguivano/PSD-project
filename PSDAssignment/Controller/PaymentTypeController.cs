using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class PaymentTypeController
    {
        public static List<PaymentType> getAllPaymentTypes()
        {
            return PaymentTypeHandler.getAllPaymentTypes();
        }

        public static PaymentType getPaymentTypeByID(int paymentTypeID)
        {
            return PaymentTypeHandler.getPaymentTypeByID(paymentTypeID);
        }

        public static void delete(int paymentTypeID)
        {
            PaymentTypeHandler.delete(paymentTypeID);
        }

        public static void add(String type)
        {
            PaymentTypeHandler.add(type);
        }

        public static void update(int paymentTypeID, String type)
        {
            PaymentTypeHandler.update(paymentTypeID, type);
        }

        public static int PaymentTypeValidation(String type)
        {
            PaymentType Type = PaymentTypeHandler.getPaymentTypeByName(type);
            if (type == "") return -1;
            else if (type.Length < 3) return -2;
            else if (Type != null) return -3;
            return 1;
        }

    }
}
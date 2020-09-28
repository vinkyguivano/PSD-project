using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDAssignment.Factory;
using PSDAssignment.Repository;

namespace PSDAssignment.Handler
{
    public class PaymentTypeHandler
    {
        public static void add(String type)
        {
            PaymentType paymentType = PaymentTypeFactory.createPaymentType(type);
            PaymentTypeRepository.add(paymentType);
        }

        public static void delete(int paymentTypeID)
        {
            PaymentTypeRepository.delete(paymentTypeID);
        }

        public static void update(int paymentTypeID, String type)
        {
            PaymentTypeRepository.update(paymentTypeID, type);
        }

        public static PaymentType getPaymentTypeByID(int paymentTypeID)
        {
            return PaymentTypeRepository.getPaymentTypeByID(paymentTypeID);
        }

        public static List<PaymentType> getAllPaymentTypes()
        {
            return PaymentTypeRepository.getAllPaymentTypes();
        }

        public static PaymentType getPaymentTypeByName (String type)
        {
            return PaymentTypeRepository.getPaymentTypeByName(type);
        }
    }
}
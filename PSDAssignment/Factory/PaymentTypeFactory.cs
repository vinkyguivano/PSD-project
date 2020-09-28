using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Factory
{
    public class PaymentTypeFactory
    {
        public static PaymentType createPaymentType(String type)
        {
            return new PaymentType()
            {
                Type = type
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int UserId, int ProductId, int quantity)
        {
            return new Cart()
            {
                UserID = UserId,
                ProductID = ProductId,
                Quantity = quantity
            };
        }
    }
}
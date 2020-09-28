using PSDAssignment.Factory;
using PSDAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Handler
{
    public class CartHandler
    {
        public static void Add(int UserId, int ProductId, int quantity)
        {
            Cart newitem = CartFactory.createCart(UserId, ProductId, quantity);
            CartRepository.add(newitem);
        }

        public static List<Cart> getCartsById(int id)
        {
            return CartRepository.getCartsById(id);
        }

        public static Cart getCart(int productid, int userid)
        {
            return CartRepository.getCart(productid, userid);
        }

        public static void delete(Cart cart)
        {
             CartRepository.delete(cart);
        }

        public static void update(Cart cart, int qty)
        {
            CartRepository.update(cart, qty);
        }

    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class CartRepository
    {
        private static MyDBEntities db = DBSingleton.GetInstance();
         public static void add(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static List<Cart> getCartsById(int id)
        {
            return db.Carts.Where(x => x.UserID == id).ToList();
        }

        public static Cart getCart(int productid, int userid)
        {
            return db.Carts.Where(x => x.ProductID == productid && x.UserID==userid).FirstOrDefault();
        }

        public static void delete(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public static void update(Cart cart , int qty)
        {
            cart.Quantity = qty;
            db.SaveChanges();
        }

        public static void deleteCarts (List<Cart> carts)
        {
            foreach(Cart i in carts)
            {
                db.Carts.Remove(i);
            }
            db.SaveChanges();
        }

    }
}
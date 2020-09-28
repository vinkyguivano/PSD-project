using PSDAssignment.Handler;
using PSDAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class CartController
    {
        public static List<Cart> getCartsById(int id)
        {
            return CartHandler.getCartsById(id);
        }

        public static Cart getCart(int productid, int userid)
        {
            return CartHandler.getCart(productid, userid);
        }

        public static bool QtyValidation(int qty, int stock)
        {
            if (qty < 1 || qty > stock)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool QtyValidation2(int qty, int stock)
        {
            if (qty < 0 || qty > stock)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool add(int productid, int qty)
        {
            int userid = Convert.ToInt32(HttpContext.Current.Session["auth_user"]);
            List<Cart> carts = CartHandler.getCartsById(userid);
            bool exist = false, exceed=false;

            if (carts.Count != 0)
            {
                foreach (Cart product in carts)
                {
                    if (product.ProductID == productid)
                    {
                        int newqty = qty + product.Quantity;
                        Product Product = ProductHandler.getProductByID(productid);
                        if(newqty>Product.Stock)
                        {
                            exceed = true;
                        }
                        else
                        {
                            Cart cart = getCart(productid, userid);
                            CartHandler.update(cart, newqty);
                        }
                        exist = true;
                        break;
                    }
                }
            }
            if (!exist || carts.Count == 0)
            {
                CartHandler.Add(userid, productid, qty);
            }

            if (exceed)
            {
                return false;
            }

            else return true;
        }

      

        public static void delete (int productid,int userid)
        {
            Cart cart = getCart(productid, userid);
            CartHandler.delete(cart);
        }

        public static void update(int userid, int productid, int qty)
        {
            Cart cart = getCart(productid, userid);
            if(qty==0)
            {
                CartHandler.delete(cart);
            }
            else
            {
                CartHandler.update(cart, qty);
            }
        }
    }
}
using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class ProductController
    {
        public static List<Product> getRandomProduct()
        {
            return ProductHandler.getRandomProduct();
        }

        public static List<Product> getAllProducts()
        {
            return ProductHandler.getAllProduct();
        }

        public static Product getProductByID(int id)
        {
            return ProductHandler.getProductByID(id);
        }

        public static void deleteProduct(int id)
        {
            ProductHandler.deleteProduct(id);
        }

        public static void addProduct(string productName, int productPrice, int productStock, int productTypeID)
        {
            ProductHandler.addProduct(productName,productPrice,productStock,productTypeID);
        }

        public static void updateProduct(int productID, string productName, int productPrice, int productStock, int productTypeID)
        {
            ProductHandler.updateProduct(productID, productName, productPrice, productStock, productTypeID);
        }
        public static Boolean NameValidation(String name)
        {
            if (name != "") return true;
            return false;
        }

        public static Boolean StockValidation(int stock)
        {
            if (stock > 0) return true;
             return false;
        }

        public static Boolean PriceValidation(int price)
        {
            if (price > 1000 && price % 1000 == 0) return true;
            return false;
        }
        public static Boolean newProductValidation(String name, int price, int stock,  int productTypeID)
        {
            if(!NameValidation(name)|| !StockValidation(stock) || !PriceValidation(price))
            {
                return false;
            }
            
                return true;
        }

        public static int inttypecheck(String input)
        {
            if (input == "")
            {
                input = "-1";
            }
            int convertint = Convert.ToInt32(input);
            return convertint;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSDAssignment.Repository;
using PSDAssignment.Factory;

namespace PSDAssignment.Handler
{
    public class ProductHandler
    {
        public static Product getProductByID(int productId) {
            return ProductRepository.getProductByID(productId);
        }

        public static List<Product> getRandomProduct()
        {
            return ProductRepository.getRandomProduct();
        }

        public static List<Product> getAllProduct()
        {
            return ProductRepository.getAllProducts();
        }

        public static void deleteProduct(int id)
        {
            ProductRepository.deleteProduct(id);
        }

        public static void addProduct(string productName, int productPrice, int productStock, int productTypeID)
        {
            Product product = ProductFactory.createProduct(productName, productPrice, productStock, productTypeID);
            ProductRepository.createProduct(product);
        }

        public static void updateProduct(int productID, string productName, int productPrice, int productStock, int productTypeID)
        {
            ProductRepository.updateProduct(productID, productName, productPrice, productStock, productTypeID);
        }
    }
}
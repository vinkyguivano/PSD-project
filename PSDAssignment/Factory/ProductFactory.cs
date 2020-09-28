using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Factory
{
    public class ProductFactory
    {
        public static Product createProduct(String productName, int productPrice, int productStock, int productTypeID) {
            return new Product() {
                Name = productName,
                Price = productPrice,
                Stock = productStock,
                ProductTypeID = productTypeID
             };

        }
    }
}
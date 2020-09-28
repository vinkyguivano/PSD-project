using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class ProductRepository
    {
        private static MyDBEntities DB = DBSingleton.GetInstance();
        public static void createProduct(Product product)
        {
            DB.Products.Add(product);
            DB.SaveChanges();
        }

        public static List<Product> getAllProducts()
        {
            List<Product> productList = DB.Products.ToList();
            if (productList.Count !=0) {
                return DB.Products.ToList();
            }
            return productList;
        }

        public static void deleteProduct(Product product) {
            DB.Products.Remove(product);
            DB.SaveChanges();
        }

        public static Product getProductByID(int productID) {
            return (from x in DB.Products
                    where x.Id == productID
                    select x).FirstOrDefault();
        }

        public static void updateProduct(int productID, String productName, int productPrice, int productStock, int productTypeID) {
            Product product = ProductRepository.getProductByID(productID);
            product.Name = productName;
            product.Price = productPrice;
            product.Stock = productStock;
            product.ProductTypeID = productTypeID;
            DB.SaveChanges();
        }

        public static void deleteProduct(int productID) {
            Product product = ProductRepository.getProductByID(productID);
            DB.Products.Remove(product);
            DB.SaveChanges();
        }

        public static List<Product> getRandomProduct() {
            List<Product> list = ProductRepository.getAllProducts();
            Random rand = new Random();
            HashSet<int> numbers = new HashSet<int>();

            List<Product> product = new List<Product>();
            int count = list.Count < 5 ? list.Count : 5;
            while (numbers.Count < count)
            {
                numbers.Add(rand.Next(0,list.Count));
            }
            for (int i= 0;i < numbers.Count;i++) {
                product.Add(list.ElementAt(numbers.ElementAt(i)));
            }
            return product;
        }

        public static void decreaseproduct(int productid, int qty)
        {
            Product product = DB.Products.Where(x => x.Id == productid).FirstOrDefault();
            product.Stock -= qty;
            DB.SaveChanges();
        }
    }
}
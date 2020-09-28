using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Repository
{
    public class ProductTypeRepository
    {
        private static MyDBEntities DB = DBSingleton.GetInstance();
        public static ProductType getProductTypeByID(int productTypeID) {
            return DB.ProductTypes.Where(x => x.Id.Equals(productTypeID)).FirstOrDefault();
        }
        public static void createProductType(ProductType productType) {
            DB.ProductTypes.Add(productType);
            DB.SaveChanges();
        }
        public static void deleteProductType(int productTypeID) {
            PSDAssignment.ProductType type = getProductTypeByID(productTypeID);
            System.Diagnostics.Debug.WriteLine(type.Name);
            DB.ProductTypes.Remove(type);
            DB.SaveChanges();
        }
        public static void updateProductType(int productTypeID, String name, String description) {
            ProductType productType = ProductTypeRepository.getProductTypeByID(productTypeID);
            productType.Name = name;
            productType.Description = description;
            DB.SaveChanges();
        }
        public static List<ProductType> getAllProductType() {
            return DB.ProductTypes.ToList();
        }
        public static ProductType getByName(String name) {
            return DB.ProductTypes.Where(x => x.Name.Equals(name)).FirstOrDefault();
            
        }

    }
}
using PSDAssignment.Factory;
using PSDAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Handler
{
    public class ProductTypeHandler
    {
        public static ProductType getProductTypeByID(int id)
        {
            return ProductTypeRepository.getProductTypeByID(id);
        }

        public static List<ProductType> getAllProductType()
        {
            return ProductTypeRepository.getAllProductType();
        }

        public static ProductType getByName(String name)
        {
            return ProductTypeRepository.getByName(name);
        }

        public static void deleteProductType (int id)
        {
            ProductTypeRepository.deleteProductType(id);
        }

        public static void addProductType(String name, String desc)
        {
            ProductType type = ProductTypeFactory.createProductType(name, desc);
            ProductTypeRepository.createProductType(type);
        }

        public static void updateProductType(int id, String name, String desc)
        {
            ProductTypeRepository.updateProductType(id, name, desc);
        }
    }
}
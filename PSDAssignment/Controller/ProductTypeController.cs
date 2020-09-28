using PSDAssignment.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Controller
{
    public class ProductTypeController
    {
        public static ProductType getProductTypeByID(int id)
        {
            return ProductTypeHandler.getProductTypeByID(id);
        }

        public static List<ProductType> getAllProductType()
        {
            return ProductTypeHandler.getAllProductType();
        }

        public static void deleteProductType(int id)
        {
            ProductTypeHandler.deleteProductType(id);
        }

        public static void addProductType (String name, String desc)
        {
            ProductTypeHandler.addProductType(name, desc);
        }

        public static void updateProductType(int id, String name, String desc)
        {
            ProductTypeHandler.updateProductType(id, name, desc);
        }

        public static int NameValidation(String name)
        {
            ProductType pt = ProductTypeHandler.getByName(name);
            if (name == "") return -1;
            else if (name.Length < 5) return -2;
            else if (pt != null) return -3;
            return 1; 
        }

        public static int DescValidation(String desc)
        {
            if (desc == "") return -1;
            return 1;
        }

        public static Boolean PTValidation(String name, String desc)
        {
            if (NameValidation(name) != 1 || DescValidation(desc) != 1) return false;
            return true;
        }

        public static int NameUpdateValidation(String name, String ptname)
        {
            if(name != ptname)
            {
                return NameValidation(name);
            }
            return 1;
        }

        public static Boolean PTUpdateValidation (String name, String desc, ProductType pt)
        {
                if (NameUpdateValidation(name,pt.Name) != 1 || DescValidation(desc) != 1) return false;
                return true;
        }
    }
}
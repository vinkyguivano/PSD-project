using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDAssignment.Factory
{
    public class ProductTypeFactory
    {
        public static ProductType createProductType(String productTypeName, String description) {
            return new ProductType()
            {
                Name = productTypeName,
                Description = description
            };
        }
    }
}
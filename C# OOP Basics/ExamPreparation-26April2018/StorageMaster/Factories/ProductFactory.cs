using StorageMaster.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product product = null;
            type = type.ToLower();

            switch (type)
            {
                case "ram":
                    product = new Ram(price);
                    break;
                case "gpu":
                    product = new Gpu(price);
                    break;
                case "harddrive":
                    product = new HardDrive(price);
                    break;
                case "solidstatedrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}

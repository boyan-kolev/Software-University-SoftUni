using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                //Problem 1. Import Users
                //string inputJson = File.ReadAllText("./../../../Datasets/users.json");
                //string importedUsers = ImportUsers(context, inputJson);
                //Console.WriteLine(importedUsers);

                //Problem 2. Import Products
                //string inputJson = File.ReadAllText("./../../../Datasets/products.json");
                //string importedProducts = ImportProducts(context, inputJson);
                //Console.WriteLine(importedProducts);

                //Problem 3. Import Categories
                //string inputJson = File.ReadAllText("./../../../Datasets/categories.json");
                //string importedCategories = ImportCategories(context, inputJson);
                //Console.WriteLine(importedCategories);

                //Problem 4. Import Categories and Products
                //string inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");
                //string importedCategoryProducts = ImportCategoryProducts(context, inputJson);
                //Console.WriteLine(importedCategoryProducts);

                //Problem 5. Export Products In Range
                //string result = GetProductsInRange(context);
                //Console.WriteLine(result);

                //Problem 6. Export Successfully Sold Products
                //string result = GetSoldProducts(context);
                //Console.WriteLine(result);

                //Problem 7. Export Categories By Products Count
                //string result = GetCategoriesByProductsCount(context);
                //Console.WriteLine(result);

                //Problem 8. Export Users and Products
                string result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        //Problem 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            DefaultContractResolver resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            });

            return json;
        }

        //Problem 6. Export Successfully Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(x => x.Buyer != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        //Problem 7. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):F2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):F2}",
                })
                .ToList();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //Problem 8. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(x => x.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(x => x.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(x => x.Buyer !=null),
                        products = u.ProductsSold
                        .Where(x => x.Buyer != null)
                        .Select(sp => new
                        {
                            sp.Name,
                            sp.Price
                        })
                        .ToList()
                    }

                })
                .ToList();

            var result = new
            {
                usersCount = users.Count,
                users = users
            };

            DefaultContractResolver resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;

        }
    }
}
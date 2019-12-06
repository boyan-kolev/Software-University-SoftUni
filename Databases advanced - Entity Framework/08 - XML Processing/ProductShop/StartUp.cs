using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

using AutoMapper;

using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using ProductShop.Dtos.Export;
using System.Text;
using System.Xml;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

                //Problem 1. Import Users
                //string inputXml = File.ReadAllText("./../../../Datasets/users.xml");
                //string result = ImportUsers(context, inputXml);
                //Console.WriteLine(result);

                //Problem 2. Import Products
                //string inputXml = File.ReadAllText("./../../../Datasets/products.xml");
                //string result = ImportProducts(context, inputXml);
                //Console.WriteLine(result);

                //Problem 3. Import Categories
                //string inputXml = File.ReadAllText("./../../../Datasets/categories.xml");
                //string result = ImportCategories(context, inputXml);
                //Console.WriteLine(result);

                //Problem 4. Import Categories and Products
                //string inputXml = File.ReadAllText("./../../../Datasets/categories-products.xml");
                //string result = ImportCategoryProducts(context, inputXml);
                //Console.WriteLine(result);

                //Problem 5. Products In Range
                //string result = GetProductsInRange(context);
                //Console.WriteLine(result);

                //Problem 6. Sold Products
                //string result = GetSoldProducts(context);
                //Console.WriteLine(result);

                //Problem 7. Categories By Products Count
                //string result = GetCategoriesByProductsCount(context);
                //Console.WriteLine(result);

                //Problem 8. Users and Products
                string result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        //Problem 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]),
                new XmlRootAttribute("Users"));

            User[] users;

            using (StringReader reader = new StringReader(inputXml))
            {
                ImportUserDto[] usersDtos = (ImportUserDto[])serializer.Deserialize(reader);

                users = Mapper.Map<User[]>(usersDtos);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Problem 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]),
                new XmlRootAttribute("Products"));

            Product[] products;

            using (StringReader reader = new StringReader(inputXml))
            {
                ImportProductDto[] productsDtos = (ImportProductDto[])xmlSerializer.Deserialize(reader);

                products = Mapper.Map<Product[]>(productsDtos);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportCategoryDto>),
                new XmlRootAttribute("Categories"));

            List<Category> categories;

            using (StringReader reader = new StringReader(inputXml))
            {
                List<ImportCategoryDto> categoriesDtos = ((List<ImportCategoryDto>)xmlSerializer
                    .Deserialize(reader))
                    .Where(c => c.Name != null)
                    .ToList();

                categories = Mapper.Map<List<Category>>(categoriesDtos);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportCategoryProductDto>),
                new XmlRootAttribute("CategoryProducts"));

            List<ImportCategoryProductDto> categoryProductsDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                categoryProductsDtos = ((List<ImportCategoryProductDto>)xmlSerializer
                    .Deserialize(reader))
                    .Where(dtos => context.Categories.Any(x => x.Id == dtos.CategoryId)
                    && context.Products.Any(x => x.Id == dtos.ProductId))
                    .ToList();
            }

            List<CategoryProduct> categoryProducts = Mapper.Map<List<CategoryProduct>>(categoryProductsDtos);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            List<ExportProductInRangeDto> productsDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductInRangeDto>()
                .ToList();

            StringBuilder sb = new StringBuilder();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportProductInRangeDto>),
                new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, productsDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            List<ExportUserDto> usersDtos = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserDto>()
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportUserDto>),
                new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, usersDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 7. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            List<ExportCategoryDto> categoriesDtos = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .ThenBy(x => x.CategoryProducts.Sum(p => p.Product.Price))
                .ProjectTo<ExportCategoryDto>()
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCategoryDto>),
                new XmlRootAttribute("Categories"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, categoriesDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //var users = context.Users
            //    .Where(x => x.ProductsSold.Any())
            //    .Select(x => new ExportUsersAndCountDto()
            //    {
            //        Count = context.Users
            //        .Where(ps => ps.ProductsSold.Any())
            //        .Count(),

            //        Users = context.Users.Select(y => new ExportUserAndProductsDto()
            //        {
            //            FirstName = y.FirstName,
            //            LastName = y.LastName,
            //            Age = y.Age,
            //            SoldProducts = new SoldProduct()
            //            {
            //                Count = y.ProductsSold.Count,
            //                Products = y.ProductsSold.Select(z => new ExportProductDto()
            //                {
            //                    Name = z.Name,
            //                    Price = z.Price
            //                })
            //                .OrderByDescending(p => p.Price)
            //                .ToArray()
            //            } 
            //        })
            //        .OrderByDescending(sp => sp.SoldProducts.Count)
            //        .Take(10)
            //        .ToArray()
            //    });

            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(y => new ExportUserAndProductsDto()
                {
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                    Age = y.Age,
                    SoldProducts = new SoldProduct()
                    {
                        Count = y.ProductsSold.Count,
                        Products = y.ProductsSold.Select(z => new ExportProductDto()
                        {
                            Name = z.Name,
                            Price = z.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(sp => sp.SoldProducts.Count)
                .Take(10)
                .ToArray();

            ExportUsersAndCountDto usersWithProducts = new ExportUsersAndCountDto()
            {
                Count = context.Users
                        .Where(ps => ps.ProductsSold.Any())
                        .Count(),

                Users = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUsersAndCountDto),
                new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, usersWithProducts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                //problem 9.Import Suppliers
                //string inputJson = File.ReadAllText("./../../../Datasets/suppliers.json");
                //string result = ImportSuppliers(context, inputJson);
                //Console.WriteLine(result);

                //problem 10. Import Parts
                //string inputJson = File.ReadAllText("./../../../Datasets/parts.json");
                //string result = ImportParts(context, inputJson);
                //Console.WriteLine(result);

                //problem 11.Import Cars
                //string inputJson = File.ReadAllText("./../../../Datasets/cars.json");
                //string result = ImportCars(context, inputJson);
                //Console.WriteLine(result);

                //problem 12. Import Customers
                //string inputJson = File.ReadAllText("./../../../Datasets/customers.json");
                //string result = ImportCustomers(context, inputJson);
                //Console.WriteLine(result);

                //problem 13. Import Sales
                //string inputJson = File.ReadAllText("./../../../Datasets/sales.json");
                //string result = ImportSales(context, inputJson);
                //Console.WriteLine(result);

                //problem 14.Export Ordered Customers
                //string result = GetOrderedCustomers(context);
                //Console.WriteLine(result);

                //problem 15. Export Cars from make Toyota
                //string result = GetCarsFromMakeToyota(context);
                //Console.WriteLine(result);

                //problem 16.Export Local Suppliers
                //string result = GetLocalSuppliers(context);
                //Console.WriteLine(result);

                //problem 17. Export Cars with Their List of Parts
                //string result = GetCarsWithTheirListOfParts(context);
                //Console.WriteLine(result);

                //problem 18. Export Total Sales by Customer
                //string result = GetTotalSalesByCustomer(context);
                //Console.WriteLine(result);

                //problem 19. Export Sales with Applied Discount
                string result = GetSalesWithAppliedDiscount(context);
                Console.WriteLine(result);
            }
        }

        //problem 9.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => context.Suppliers.Any(x => x.Id == p.SupplierId))
                .ToList();
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }


        //problem 11.Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var json = JsonConvert.DeserializeObject<ImortCarDto[]>(inputJson);

            foreach (var carDto in json)
            {
                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {json.Count()}.";
        }

        //problem 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //problem 14.Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //problem 15. Export Cars from make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //problem 16.Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //problem 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                    .ToList()
                })
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //problem 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any(x => x.Car != null))
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(xc => xc.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //problem 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(x => x.Part.Price):F2}",
                    priceWithDiscount = $"{(s.Car.PartCars.Sum(x => x.Part.Price) - s.Car.PartCars.Sum(x => x.Part.Price) * s.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}
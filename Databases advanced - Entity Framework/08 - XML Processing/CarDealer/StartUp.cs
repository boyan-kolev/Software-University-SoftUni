using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using CarDealer.Dtos.Export;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                //Problem 9. Import Suppliers
                //string inputXml = File.ReadAllText("./../../../Datasets/suppliers.xml");
                //string result = ImportSuppliers(context, inputXml);
                //Console.WriteLine(result);

                //Problem 10. Import Parts
                //string inputXml = File.ReadAllText("./../../../Datasets/parts.xml");
                //string result = ImportParts(context, inputXml);
                //Console.WriteLine(result);

                //Problem 11. Import Cars
                //string inputXml = File.ReadAllText("./../../../Datasets/cars.xml");
                //string result = ImportCars(context, inputXml);
                //Console.WriteLine(result);

                //Problem 12. Import Customers
                //string inputXml = File.ReadAllText("./../../../Datasets/customers.xml");
                //string result = ImportCustomers(context, inputXml);
                //Console.WriteLine(result);

                //Problem 13. Import Sales
                //string inputXml = File.ReadAllText("./../../../Datasets/sales.xml");
                //string result = ImportSales(context, inputXml);
                //Console.WriteLine(result);

                //Problem 14. Cars With Distance
                //string result = GetCarsWithDistance(context);
                //Console.WriteLine(result);

                //Problem 15. Cars from make BMW
                //string result = GetCarsFromMakeBmw(context);
                //Console.WriteLine(result);

                //Problem 16. Local Suppliers
                string result = GetLocalSuppliers(context);
                Console.WriteLine(result);
            }
        }

        //Problem 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                new XmlRootAttribute("Suppliers"));

            ImportSupplierDto[] suppliersDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                suppliersDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);
            }

            List<Supplier> suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDtos)
            {
                Supplier supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //Problem 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                new XmlRootAttribute("Parts"));

            ImportPartDto[] partsDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                partsDtos = ((ImportPartDto[])xmlSerializer
                    .Deserialize(reader))
                    .Where(dto => context.Suppliers.Any(x => x.Id == dto.SupplierId))
                    .ToArray();
            }

            List<Part> parts = new List<Part>();

            foreach (var partDto in partsDtos)
            {
                Part part = new Part()
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Problem 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]),
                new XmlRootAttribute("Cars"));

            ImportCarDto[] carsDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                carsDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);
            }

            List<PartCar> partsCars = new List<PartCar>();

            foreach (var carDto in carsDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                };

                context.Cars.Add(car);

                int[] partsIds = carDto.PartsCars
                    .Where(x => context.Parts.Any(y => y.Id == x.Id))
                    .Select(x => x.Id)
                    .Distinct()
                    .ToArray();

                foreach (int partId in partsIds)
                {
                    PartCar partCar = new PartCar()
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    partsCars.Add(partCar);

                }
            }

            context.PartCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }

        //Problem 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                new XmlRootAttribute("Customers"));

            ImportCustomerDto[] customersDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                customersDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(reader);
            }

            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in customersDtos)
            {
                Customer customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]),
                new XmlRootAttribute("Sales"));

            ImportSaleDto[] salesDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                salesDtos = ((ImportSaleDto[])xmlSerializer
                    .Deserialize(reader))
                    .Where(dto => context.Cars.Any(x => x.Id == dto.CarId))
                    .ToArray();
            }

            List<Sale> sales = new List<Sale>();

            foreach (var saleDto in salesDtos)
            {
                Sale sale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            List<Car> cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            List<ExportCarsWithDistanceDto> carsDtos = new List<ExportCarsWithDistanceDto>();

            foreach (var car in cars)
            {
                ExportCarsWithDistanceDto carDto = new ExportCarsWithDistanceDto()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                carsDtos.Add(carDto);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCarsWithDistanceDto>),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, carsDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            List<Car> cars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            List<ExportCarsFromMakeBMWDto> carsDto = new List<ExportCarsFromMakeBMWDto>();

            foreach (var car in cars)
            {
                ExportCarsFromMakeBMWDto carDto = new ExportCarsFromMakeBMWDto()
                {
                    Id = car.Id,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                carsDto.Add(carDto);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCarsFromMakeBMWDto>),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, carsDto, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 16. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            List<Supplier> suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ToList();

            List<ExportLocalSuppliersDto> suppliersDtos = new List<ExportLocalSuppliersDto>();

            foreach (var supplier in suppliers)
            {
                ExportLocalSuppliersDto supplierDto = new ExportLocalSuppliersDto()
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    PartsCount = supplier.Parts.Count
                };

                suppliersDtos.Add(supplierDto);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportLocalSuppliersDto>),
                new XmlRootAttribute("suppliers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, suppliersDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
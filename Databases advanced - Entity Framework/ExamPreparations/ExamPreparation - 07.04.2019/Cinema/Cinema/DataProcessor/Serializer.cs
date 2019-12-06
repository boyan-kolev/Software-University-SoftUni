namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            List<ExportMovieDto> moviesDtos = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Count > 0))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(t => t.Tickets.Sum(p => p.Price)))
                .Select(x => new ExportMovieDto
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                    Customers = x.Projections
                    .SelectMany(p => p.Tickets
                    .Select(t => new CustomerDto
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = t.Customer.Balance.ToString("F2")
                    }))
                    .OrderByDescending(b => b.Balance)
                    .ThenBy(fn => fn.FirstName)
                    .ThenBy(ln => ln.LastName)
                    .ToList()
                })
                .Take(10)
                .ToList();

            string jsonString = JsonConvert.SerializeObject(moviesDtos, Formatting.Indented);

            return jsonString;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            List<ExportCustomerDto> customersDtos = context.Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(p => p.Price))
                .Select(x => new ExportCustomerDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(p => p.Price).ToString("F2"),
                    SpentTime = TimeSpan
                    .FromMilliseconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalMilliseconds))
                    .ToString("hh\\:mm\\:ss")
                })
                .Take(10)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCustomerDto>),
                new XmlRootAttribute("Customers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, customersDtos, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
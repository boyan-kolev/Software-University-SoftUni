namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            ExportAthorDto[] authorsDtos = context.Authors
                .Select(x => new ExportAthorDto()
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks.Select(b => new ExportAuthorbookDto()
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("F2")
                    })
                    .OrderByDescending(p => decimal.Parse(p.BookPrice))
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(b => b.Books.Count)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string json = JsonConvert.SerializeObject(authorsDtos, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            ExportBookDto[] booksDtos = context.Books
                .Where(x => x.PublishedOn < date && (int)x.Genre == 3)
                .Select(x => new ExportBookDto()
                {
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = x.Pages
                })
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => DateTime.ParseExact(x.Date, "d", CultureInfo.InvariantCulture))
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]),
                new XmlRootAttribute("Books"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, booksDtos, namespaces);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
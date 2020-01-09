namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]),
                new XmlRootAttribute("Books"));

            ImportBookDto[] booksDtos;

            using (StringReader reader = new StringReader(xmlString))
            {
                booksDtos = (ImportBookDto[])xmlSerializer.Deserialize(reader);
            }

            List<Book> books = new List<Book>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in booksDtos)
            {
                Genre genre;
                Enum.TryParse<Genre>(dto.Genre, out genre);

                int genreInt = (int)genre;
                bool isExists = Enum.IsDefined(typeof(Genre), genreInt);

                DateTime publishedOn;
                bool isValidPublishedOn = DateTime.TryParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out publishedOn);

                if (IsValid(dto) && isExists && isValidPublishedOn)
                {
                    Book book = new Book()
                    {
                        Name = dto.Name,
                        Genre = genre,
                        Price = dto.Price,
                        Pages = dto.Pages,
                        PublishedOn = publishedOn
                    };

                    books.Add(book);

                    sb.AppendLine($"Successfully imported book {dto.Name} for {dto.Price:F2}.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            ImportAuthorDto[] authorsDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var dto in authorsDtos)
            {
                bool isValidEmail = context.Authors.Any(x => x.Email == dto.Email);
                bool isHaveValidBooks = haveBooksValid(dto.Books, context);

                if (IsValid(dto) && isValidEmail == false && isHaveValidBooks)
                {
                    Author author = new Author()
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Email = dto.Email,
                        Phone = dto.Phone
                    };

                    context.Authors.Add(author);
                    List<AuthorBook> authorsBooks = new List<AuthorBook>();

                    foreach (var book in dto.Books)
                    {
                        bool isExistBook = context.Books.Any(x => x.Id == book.Id);

                        if (isExistBook)
                        {
                            AuthorBook authorBook = new AuthorBook()
                            {
                                AuthorId = author.Id,
                                BookId = (int)book.Id
                            };

                            authorsBooks.Add(authorBook);
                        }
                    }

                    context.AuthorsBooks.AddRange(authorsBooks);
                    sb.AppendLine($"Successfully imported author - {author.FirstName + " " + author.LastName} with {author.AuthorsBooks.Count} books.");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }

            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool haveBooksValid(ICollection<ImportCustomBookDto> books, BookShopContext context)
        {
            bool isValid = false;

            foreach (var book in books)
            {
                if (context.Books.Any(x => x.Id == book.Id))
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
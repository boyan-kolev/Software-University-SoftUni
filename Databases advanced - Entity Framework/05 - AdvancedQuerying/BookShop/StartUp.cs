namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Z.EntityFramework.Plus;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //string command = Console.ReadLine();
                //string BookTitles = GetBooksByAgeRestriction(db, command);
                //Console.WriteLine(BookTitles);

                //string goldenBooks = GetGoldenBooks(db);
                //Console.WriteLine(goldenBooks);

                //string books = GetBooksByPrice(db);
                //Console.WriteLine(books);

                //int year = int.Parse(Console.ReadLine());
                //string bookTitle = GetBooksNotReleasedIn(db, year);
                //Console.WriteLine(bookTitle);

                //string input = Console.ReadLine();
                //string bookTitles = GetBooksByCategory(db, input);
                //Console.WriteLine(bookTitles);

                //string date = Console.ReadLine();
                //string bookTitles = GetBooksReleasedBefore(db, date);
                //Console.WriteLine(bookTitles);

                //string input = Console.ReadLine();
                //string authors = GetAuthorNamesEndingIn(db, input);
                //Console.WriteLine(authors);

                //string input = Console.ReadLine();
                //string books = GetBookTitlesContaining(db, input);
                //Console.WriteLine(books);

                //string input = Console.ReadLine();
                //string authorsBooks = GetBooksByAuthor(db, input);
                //Console.WriteLine(authorsBooks);

                //int checkLength = int.Parse(Console.ReadLine());
                //int result = CountBooks(db, checkLength);
                //Console.WriteLine(result);

                //string result = CountCopiesByAuthor(db);
                //Console.WriteLine(result);

                //string result = GetTotalProfitByCategory(db);
                //Console.WriteLine(result);

                //string result = GetMostRecentBooks(db);
                //Console.WriteLine(result);

                //IncreasePrices(db);

                int numOfDeletedBooks = RemoveBooks(db);
                Console.WriteLine(numOfDeletedBooks);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            List<string> BookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, BookTitles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> goldenBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] bookCategories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> bookTitles = context.Books
                .Where(b => b.BookCategories.Any(bc => bookCategories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(book => new
                {
                    book.Title,
                    book.EditionType,
                    book.Price
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    fullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.fullName)
                .ToList();

            string result = string.Join(Environment.NewLine, authors.Select(a => a.fullName));

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            List<string> books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var authorsBooks = context.Books
                .Where(b => EF.Functions.Like(b.Author.LastName.ToLower(), $"{input.ToLower()}%"))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Author.FirstName,
                    b.Author.LastName,
                    b.Title
                })
                .ToList();

            string result = string.Join(Environment.NewLine, authorsBooks.Select(a => $"{a.Title} ({a.FirstName} {a.LastName})"));
            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int countOfBooks = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return countOfBooks;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var countOfBookCopies = context.Authors
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BooksCount = a.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(a => a.BooksCount)
                .ToList();

            string result = string.Join(Environment.NewLine, countOfBookCopies.Select(a => $"{a.FirstName} {a.LastName} - {a.BooksCount}"));
            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalprofit = context.Categories
                .Select(c => new
                {
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies),
                    Category = c.Name
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Category);

            string result = string.Join(Environment.NewLine, totalprofit.Select(x => $"{x.Category} ${x.TotalProfit}"));

            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks.Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        RelaseDate = b.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.RelaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(p => p.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.RelaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .Update(x => new Book() { Price = x.Price + 5 });
        }

        public static int RemoveBooks(BookShopContext context)
        {
            int deletedBooks = context.Books
                .Where(b => b.Copies < 4200)
                .Delete();

            return deletedBooks;
        }

    }
}

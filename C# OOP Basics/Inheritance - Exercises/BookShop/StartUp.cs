﻿using System;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            try
            {
                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book + Environment.NewLine);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
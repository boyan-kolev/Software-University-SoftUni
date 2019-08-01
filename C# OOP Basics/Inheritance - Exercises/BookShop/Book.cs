using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }


        public virtual string Author
        {
            get { return author; }
            set
            {
                string[] names = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if ((names.Length > 1) && (char.IsDigit(names[1][0])))
                {
                    throw new ArgumentException("Author not valid!");
                }

                author = value;
            }
        }
        public virtual string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                title = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Type: {this.GetType().Name}");
            stringBuilder.AppendLine($"Title: {this.Title}");
            stringBuilder.AppendLine($"Author: {this.Author}");
            stringBuilder.AppendLine($"Price: {this.Price:f2}");

            string result = stringBuilder.ToString().TrimEnd();
            return result;
        }

    }
}

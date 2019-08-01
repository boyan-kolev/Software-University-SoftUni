using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

        public int Year
        {
            get { return year; }
            private set { year = value; }
        }

        public IReadOnlyList<string> Authors
        {
            get { return this.authors.AsReadOnly(); }
            private set { }
        }

    }
}

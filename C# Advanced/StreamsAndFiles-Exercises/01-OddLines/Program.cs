using System;
using System.IO;

namespace _01_OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader(@"D:\SoftUni\C# Advanced\StreamsAndFiles-Exercises\text.txt"))
            {
                string line;
                int counterLine = 0;

                while ((line = stream.ReadLine()) != null)
                {
                    if (counterLine % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counterLine++;
                }
            }
        }
    }
}

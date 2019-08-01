using System;
using System.IO;

namespace _02_LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counterLine = 1;
            using (StreamReader streamReader = new StreamReader(@"D:\SoftUni\C# Advanced\StreamsAndFiles-Exercises\text.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter(@"..\..\..\text-copy.txt"))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"line {counterLine}: {line}");
                        counterLine++;
                    }
                }

            }
        }
    }
}

using System;
using System.Linq;

namespace _06_ReverseAnArrayOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] inputStr = Console.ReadLine()
                .Split(' ')
                .Reverse()
                .ToArray();

            Console.WriteLine(String.Join(' ' ,inputStr));
        }
    }
}

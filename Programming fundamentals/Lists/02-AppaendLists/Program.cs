using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AppaendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNums = Console.ReadLine()
                .Split('|')
                .ToList();

            inputNums.Reverse();

            List<string> listOfNums = new List<string>();

            for (int i = 0; i < inputNums.Count; i++)
            {
                string text = inputNums[i];
                string[] splited = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string merged = string.Join(' ', splited);
                listOfNums.Add(merged);
            }

            Console.WriteLine(string.Join(' ',listOfNums));
         }
    }
}

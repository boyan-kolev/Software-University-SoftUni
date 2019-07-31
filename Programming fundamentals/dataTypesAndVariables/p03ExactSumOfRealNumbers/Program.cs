using System;

namespace p03ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            decimal sumOfNumbers = 0m;
            for (int i = 0; i < numbers; i++)
            {
                sumOfNumbers += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sumOfNumbers);
        }
    }
}

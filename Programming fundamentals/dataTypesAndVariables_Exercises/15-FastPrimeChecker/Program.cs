using System;

namespace _15_FastPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int tempNum = 2; tempNum <= number; tempNum++)
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(tempNum); i++)
                {
                    if (tempNum % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{tempNum} -> {isPrime}");
            }

        }
    }
}

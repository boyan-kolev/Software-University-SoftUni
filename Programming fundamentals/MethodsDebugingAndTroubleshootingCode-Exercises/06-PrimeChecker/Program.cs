using System;

namespace _06_PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            bool isPrime = IsPrime(number);
            Console.WriteLine(isPrime);
        }

        static bool IsPrime(long num)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(num));
            if (num == 0 || num == 1)
            {
                return false;
            }
            else
            {
                for (int a = 2; a <= boundary; a++)
                {
                    if (num % a == 0)
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}

using System;
using System.Numerics;

namespace _05_FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            BigInteger fibNum = GetFibonacciNumber(number);
            Console.WriteLine(fibNum);
        }

        static BigInteger GetFibonacciNumber(BigInteger number)
        {
            BigInteger f1 = 0;
            BigInteger f2 = 1;
            BigInteger fTemp = 0;

            if (number == 0)
            {
                fTemp = 1;
            }

            for (int i = 0; i < number; i++)
            {

                fTemp = f1 + f2;
                f1 = f2;
                f2 = fTemp;

            }
            return fTemp;
        }
    }
}

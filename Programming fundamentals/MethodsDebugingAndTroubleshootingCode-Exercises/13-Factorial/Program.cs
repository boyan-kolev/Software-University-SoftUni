using System;
using System.Numerics;

namespace _13_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintFactorialNum(number);
        }

        static BigInteger GetFactorialNum(int number)
        {
            BigInteger factorial = 1;
            for (int currNum = 1; currNum <= number; currNum++)
            {
                factorial = factorial * currNum;
            }

            return factorial;
        }

        static void PrintFactorialNum(int number)
        {
            BigInteger factorial = GetFactorialNum(number);
            Console.WriteLine(factorial);
        }
    }
}

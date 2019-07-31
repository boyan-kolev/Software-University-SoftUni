using System;
using System.Numerics;

namespace _14_FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int countOfZeros = GetCountOfZeros(number);
            Console.WriteLine(countOfZeros);

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

        static int GetCountOfZeros(int number)
        {
            BigInteger factorial = GetFactorialNum(number);
            BigInteger lastDig = 0;
            int countOfZeros = 0;
            bool isZero = true;
            while (isZero)
            {
                lastDig = factorial % 10;
                if (lastDig == 0)
                {
                    countOfZeros++;
                }
                else
                {
                    isZero = false;
                }
                factorial /= 10;
            }

            return countOfZeros;
        }
    }
}

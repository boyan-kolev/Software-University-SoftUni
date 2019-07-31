using System;

namespace _09_MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nAbs = Math.Abs(n);
            int multEvensOdds = GetMultipleOfEvensAndOdds(nAbs);
            Console.WriteLine(multEvensOdds);
        }

        static int GetMultipleOfEvensAndOdds(int number)
        {
            int multOfEvensByOdds = GetSumOfEvensDigits(number) * GetSumOfOddsDigits(number);
            return multOfEvensByOdds;
        }

        static int GetSumOfEvensDigits(int num)
        {
            int sumOfEvens = 0;
            while (num > 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 == 0)
                {
                    sumOfEvens += lastDigit;
                }
                num /= 10;
            }

            return sumOfEvens;
        }

        static int GetSumOfOddsDigits(int num)
        {
            int sumOfOdds = 0;
            while (num > 0)
            {
                int lastDigit = num % 10;
                if (lastDigit % 2 != 0)
                {
                    sumOfOdds += lastDigit;
                }
                num /= 10;
            }

            return sumOfOdds;
        }
    }
}

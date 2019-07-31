using System;
using System.Numerics;

namespace _02_ConvertFromBaseNToBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int @base = int.Parse(input[0]);
            BigInteger baseNNumber = BigInteger.Parse(input[1]);
            BigInteger base10Number = new BigInteger();

            for (int i = 0; i < input[1].Length; i++)
            {
                BigInteger lastDig = baseNNumber % 10;
                base10Number += lastDig * BigInteger.Pow(@base, i);
                baseNNumber /= 10;
            }

            Console.WriteLine(base10Number);
        }
    }
}

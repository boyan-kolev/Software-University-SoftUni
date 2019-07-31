using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _01_ConvertFromBase_10ToBase_N
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int baseN = int.Parse(input[0]);
            BigInteger base10Num = BigInteger.Parse(input[1]);
            StringBuilder baseNNumber = new StringBuilder();

            while (base10Num > 0)
            {
                BigInteger remainder = base10Num % baseN;
                baseNNumber.Append(remainder);
                base10Num /= baseN;
            }

            //char[] digits = baseNNumber.Reverse().ToArray();
            string revNum = new string(baseNNumber.ToString().Reverse().ToArray());

            Console.WriteLine(revNum);
        }
    }
}

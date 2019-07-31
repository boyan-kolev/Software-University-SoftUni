using System;

namespace _04_NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            PrintReversedNumber(number);
        }

        static void PrintReversedNumber(decimal number)
        {
            String numberString = number.ToString();
            char[] charOfNumber = numberString.ToCharArray();
            Array.Reverse(charOfNumber);
            String reversedNumber = new string(charOfNumber);
            Console.WriteLine(reversedNumber);
        }
    }
}

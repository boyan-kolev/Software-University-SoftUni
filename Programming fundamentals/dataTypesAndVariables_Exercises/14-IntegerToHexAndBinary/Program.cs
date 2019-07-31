using System;

namespace _14_IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            String hexNumber = Convert.ToString(decimalNumber, 16).ToUpper();
            String binaryNumber = Convert.ToString(decimalNumber, 2);
            Console.WriteLine(hexNumber);
            Console.WriteLine(binaryNumber);
        }
    }
}

using System;

namespace _04_VariableInHexadecimalFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            String numInHexadecimal = Console.ReadLine();
            int numInDecimal = Convert.ToInt32(numInHexadecimal, 16);
            Console.WriteLine(numInDecimal);
        }
    }
}

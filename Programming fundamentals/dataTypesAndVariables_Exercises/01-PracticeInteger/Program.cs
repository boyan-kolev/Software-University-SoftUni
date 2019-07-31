using System;

namespace _01_PracticeInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte number1 = -100;
            byte number2 = 128;
            short number3 = -3540;
            ushort number4 = 64876;
            uint number5 = 2147483648;
            int number6 = -1141583228;
            long number7 = -1223372036854775808;

            Console.WriteLine(number1 + Environment.NewLine + number2 + Environment.NewLine
                + number3 + Environment.NewLine + number4 + Environment.NewLine + number5 
                + Environment.NewLine + number6 + Environment.NewLine + number7);
        }
    }
}

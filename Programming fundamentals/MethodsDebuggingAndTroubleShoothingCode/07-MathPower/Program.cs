using System;

namespace _07_MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double mathToPower = RaiseToPower(number, power);
            Console.WriteLine(mathToPower);

        }
        static double RaiseToPower(double num, int pow)
        {
            double startNum = num;
            for (int i = 0; i < pow - 1; i++)
            {
                num *= startNum ;
            }
            return num;
        }
    }
}

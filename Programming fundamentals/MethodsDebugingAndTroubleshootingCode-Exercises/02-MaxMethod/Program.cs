using System;

namespace _02_MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int max1 = GetMax(number1, number2);
            int max2 = GetMax(max1, number3);
            Console.WriteLine(max2);
        }

        static int GetMax(int num1 ,int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            return num2;
        }
    }
}

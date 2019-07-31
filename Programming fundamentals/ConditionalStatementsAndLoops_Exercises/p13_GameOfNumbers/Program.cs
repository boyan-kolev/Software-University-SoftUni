using System;

namespace p13_GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());
            int currentNum1 = 0;
            int currentNum2 = 0;
            int count = 0;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = firstNumber; j <= secondNumber; j++)
                {
                    if (i + j == magicalNumber)
                    {
                        currentNum1 = i;
                        currentNum2 = j;
                    }
                    count++;
                }
            }
            if (currentNum1 > 0)
            {
                Console.WriteLine($"Number found! {currentNum1} + {currentNum2} = {magicalNumber}");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magicalNumber}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _03_DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNum = int.Parse(Console.ReadLine());

            if (decimalNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            Stack<int> binaryNum = new Stack<int>();

            while (decimalNum > 0)
            {
                binaryNum.Push(decimalNum % 2);
                decimalNum /= 2;
            }

            while (binaryNum.Count > 0)
            {
                Console.Write(binaryNum.Pop());
            }

            Console.WriteLine();
        }
    }
}

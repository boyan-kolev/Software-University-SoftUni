using System;

namespace _06_ReverseAnArrayOfString2
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] inputStr = Console.ReadLine()
                .Split(' ');

            for (int i = 0; i < inputStr.Length / 2; i++)
            {
                String temp = inputStr[i];
                inputStr[i] = inputStr[inputStr.Length - 1 - i];
                inputStr[inputStr.Length - 1 - i] = temp;
            }

            foreach (String item in inputStr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }
    }
}

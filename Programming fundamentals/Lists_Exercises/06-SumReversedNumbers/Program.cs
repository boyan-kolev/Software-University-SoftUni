using System;
using System.Collections.Generic;

namespace _06_SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split();
            List<char[]> digits = new List<char[]>();

            for (int i = 0; i < numbers.Length; i++)
            {
                digits.Add(numbers[i].ToCharArray());
            }
            Console.WriteLine();

            for (int num = 0; num < digits.Count; num++)
            {
                for (int dig = 0; dig < digits[dig].Length / 2; dig++)
                {
                    int lastDigit = (digits[dig].Length) - 1;
                    char temp = digits[num][dig];
                    digits[num][dig] = digits[num][lastDigit - dig];
                    digits[num][lastDigit - dig] = temp;
                }
            }
            string[] reverseNum = new string[digits.Count];

            for (int i = 0; i < reverseNum.Length; i++)
            {
                reverseNum[i] = new string(digits[i]);
            }

            int[] numb = new int[reverseNum.Length];

            for (int i = 0; i < numb.Length; i++)
            {
                numb[i] = int.Parse(reverseNum[i]);
            }

            int sumOfNums = 0;

            for (int i = 0; i < numb.Length; i++)
            {
                sumOfNums += numb[i];
            }

            Console.WriteLine(sumOfNums);

            //int[] reverseNum = new int[digits.Count];
             
            //for (int i = 0; i < reverseNum.Length; i++)
            //{
            //    reverseNum[i] = int.Parse(digits[i].ToString());
            //}

            //double sumOfNumber = 0;

            //for (int num = 0; num < reverseNum.Length; num++)
            //{
            //    sumOfNumber += reverseNum[num];
            //}

            //Console.WriteLine(sumOfNumber);
        }
    }
}

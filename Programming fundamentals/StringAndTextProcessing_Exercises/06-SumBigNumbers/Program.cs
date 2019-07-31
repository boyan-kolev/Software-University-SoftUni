using System;
using System.Linq;

namespace _06_SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');
            string totalSum = string.Empty;
            int onMind = 0;

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int digit1 = int.Parse(num1[i].ToString());
                int digit2 = int.Parse(num2[i].ToString());
                int sum = digit1 + digit2 + onMind;

                onMind = 0;
                int currSum = sum;

                if (sum > 9)
                {
                    currSum = sum % 10;
                    onMind = sum / 10;
                }

                totalSum += currSum;
            }

            totalSum += onMind;
            totalSum = totalSum.TrimEnd('0');
            totalSum = new string(totalSum.Reverse().ToArray());

            Console.WriteLine(totalSum);
        }
    }
}

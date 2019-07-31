using System;

namespace _12_MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int currNum = 1; currNum <= number; currNum++)
            {
                if (IsPalindrome(currNum) && IsDivisibleBy7(currNum) && IsEvenDigit(currNum))
                {
                    Console.WriteLine(currNum);
                }
            }
        }

        static bool IsPalindrome(int number)
        {
            int n = number;
            int reverseNum = 0;
            int digit = 0;
            while (number > 0)
            {
                digit = number % 10;
                reverseNum = reverseNum * 10 + digit;
                number = number / 10;
            }
            bool isValid = false;

            if (reverseNum == n)
            {
                isValid = true;
            }

            return isValid;
        }

        static bool IsDivisibleBy7(int number)
        {
            int lastDigit = 0;
            int sumOfDigits = 0;
            while (number > 0)
            {
                lastDigit = number % 10;
                sumOfDigits += lastDigit;
                number /= 10;
            }
            bool isValid = false;

            if (sumOfDigits % 7 == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        static bool IsEvenDigit(int number)
        {
            int lastNum = 0;
            bool isValid = false;
            while (number > 0)
            {
                lastNum = number % 10;
                if (lastNum % 2 == 0)
                {
                    isValid = true;
                    break;
                }
                number /= 10;
            }

            return isValid;
        }
    }
}

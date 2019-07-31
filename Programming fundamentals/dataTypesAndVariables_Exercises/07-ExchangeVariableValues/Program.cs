using System;

namespace _07_ExchangeVariableValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 5;
            int num2 = 10;
            Console.WriteLine("Before:\r\na = " + num1 + "\r\nb = " + num2);

            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("After:\r\na = " + num1 + "\r\nb = " + num2);
        }
    }
}

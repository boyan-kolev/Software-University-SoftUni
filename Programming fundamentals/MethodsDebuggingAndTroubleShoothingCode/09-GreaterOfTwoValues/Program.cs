using System;

namespace _08_GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            String type = Console.ReadLine();

            if (type == "int")
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());
                int maxValue = GetMax(firstNum, secondNum);
                Console.WriteLine(maxValue);
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                char maxValue = GetMax(firstChar, secondChar);
                Console.WriteLine(maxValue);

            }
            else if (type == "string")
            {
                String firstStr = Console.ReadLine();
                String secondStr = Console.ReadLine();
                String maxValue = GetMax(firstStr, secondStr);
                Console.WriteLine(maxValue);
                
            }
        }

        static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static char GetMax(char first, char second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static String GetMax(String first, String second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}

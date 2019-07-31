using System;
using System.Collections.Generic;

namespace _05_MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split();
            string str1 = input[0];
            string str2 = input[1];

            bool isExchangeable = IsExchangeable(str1, str2);

            if (isExchangeable)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

        }

        static bool IsExchangeable(string str1 ,string str2)
        {
            Dictionary<char, char> mappedChars = new Dictionary<char, char>();
            int minLength = Math.Min(str1.Length, str2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (mappedChars.ContainsKey(str1[i]) == false)
                {
                    mappedChars.Add(str1[i],str2[i]);
                }
                else if (mappedChars[str1[i]] == str2[i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            if (str1.Length > str2.Length)
            {
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    if (mappedChars.ContainsValue(str1[i]) == false)
                    {
                        return false;
                    }
                }

            }
            else if (str2.Length > str1.Length)
            {
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    if (mappedChars.ContainsValue(str2[i]) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

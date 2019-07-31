using System;

namespace _03_LastKNumbersSumsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] numbers = new long[n];
            numbers[0] = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (i >= k)
                {
                    for (int j = i - k; j < i; j++)
                    {
                        numbers[i] += numbers[j];
                    }
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        numbers[i] += numbers[j];
                    }
                }
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}

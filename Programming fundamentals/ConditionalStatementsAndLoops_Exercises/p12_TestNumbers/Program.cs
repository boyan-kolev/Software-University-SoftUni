using System;

namespace p12_TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maximumSumBoundary = int.Parse(Console.ReadLine());
            int combinationSum = 0;
            int count = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    combinationSum += (3 * (i * j));
                    count++;
                    if (combinationSum >= maximumSumBoundary)
                    {
                        Console.WriteLine($"{count} combinations");
                        Console.WriteLine($"Sum: {combinationSum} >= {maximumSumBoundary}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{count} combinations");
            Console.WriteLine($"Sum: {combinationSum}");
        }
    }
}


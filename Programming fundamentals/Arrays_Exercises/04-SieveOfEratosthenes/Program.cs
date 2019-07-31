using System;

namespace _04_SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool[] primeArr = new bool[num];

            for (int i = 2; i < primeArr.Length; i++)
            {
                primeArr[i] = true;
            }
            primeArr[1] = false;

            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                if (primeArr[i])
                {
                    for (int j = i * i; j < num; j += i)
                    {
                        primeArr[j] = false;
                    }
                }
            }
            for (int i = 0; i < primeArr.Length; i++)
            {
                if (primeArr[i])
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

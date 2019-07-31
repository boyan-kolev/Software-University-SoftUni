using System;
using System.Collections.Generic;

namespace _07_PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            List<int> primeNumbers = FindPrimesInRange(startNumber, endNumber);
            int count = 0;
            foreach (int currNum in primeNumbers)
            {
                if (count == primeNumbers.Count - 1)
                {
                    Console.WriteLine(currNum);
                }
                else
                {
                    Console.Write(currNum + ", ");
                }
                count++;
            }
            Console.WriteLine();
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primeNum = new List<int>();
            for (int currNum = startNum; currNum <= endNum; currNum++)
            {
                bool isPrime = true;
                if (currNum == 0 || currNum == 1)
                {
                    isPrime = false;
                }
                else
                {
                    int boundary = (int)Math.Floor(Math.Sqrt(currNum));
                    for (int a = 2; a <= boundary; a++)
                    {
                        if (currNum % a == 0)
                        {
                            isPrime = false;
                        }
                    }

                }

                if (isPrime)
                {
                    primeNum.Add(currNum);
                }
            }
            return primeNum;
        }
    }
}

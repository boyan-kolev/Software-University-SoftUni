using System;
using System.Collections.Generic;

namespace _09_StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            Queue<long> fibonacciQueue = new Queue<long>();
            fibonacciQueue.Enqueue(0);
            fibonacciQueue.Enqueue(1);

            for (long numOfFibonacci = 1; numOfFibonacci < input; numOfFibonacci++)
            {
                long f1 = fibonacciQueue.Dequeue();
                long f2 = fibonacciQueue.Dequeue();
                long f3 = f1 + f2;

                fibonacciQueue.Enqueue(f2);
                fibonacciQueue.Enqueue(f3);
            }

            fibonacciQueue.Dequeue();
            Console.WriteLine(fibonacciQueue.Dequeue());
        }
    }
}

using System;
using System.Collections.Generic;

namespace _05_CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long s1 = long.Parse(Console.ReadLine());
            Queue<long> sequence = new Queue<long>();
            Queue<long> queue = new Queue<long>();
            sequence.Enqueue(s1);
            queue.Enqueue(s1);

            for (long seq = 2; seq < 50; seq+=3)
            {
                long s2 = queue.Peek() + 1;
                long s3 = 2 * queue.Peek() + 1;
                long s4 = queue.Dequeue() + 2;
                sequence.Enqueue(s2);
                sequence.Enqueue(s3);
                sequence.Enqueue(s4);
                
                queue.Enqueue(s2);
                queue.Enqueue(s3);
                queue.Enqueue(s4);
            }

            sequence.Enqueue(queue.Peek() + 1);
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}

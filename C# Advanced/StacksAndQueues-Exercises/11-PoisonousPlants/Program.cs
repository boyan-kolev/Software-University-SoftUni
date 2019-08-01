using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfPlants = new Queue<int>(plants);
            bool isDie = true;
            int counterOfDays = 1;

            while (isDie)
            {
                int plant = queueOfPlants.Peek();
                queueOfPlants.Enqueue(queueOfPlants.Dequeue());
                isDie = false;

                for (int counter = 1; counter < numberOfPlants; counter++)
                {
                    if (plant >= queueOfPlants.Peek())
                    {
                        plant = queueOfPlants.Peek();
                        queueOfPlants.Enqueue(queueOfPlants.Dequeue());
                    }
                    else if (plant < queueOfPlants.Peek())
                    {
                        plant = queueOfPlants.Dequeue();
                        isDie = true;
                    }
                }

                if (isDie)
                {
                    counterOfDays++;
                }

            }

            if (counterOfDays == 0)
            {
                counterOfDays++;
            }

            Console.WriteLine(counterOfDays);
        }
    }
}

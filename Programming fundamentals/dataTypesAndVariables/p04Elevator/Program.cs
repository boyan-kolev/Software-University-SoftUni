using System;

namespace p04Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            uint numberOfPeople = uint.Parse(Console.ReadLine());
            uint capacityOfTheElevator = uint.Parse(Console.ReadLine());
            if (numberOfPeople <= capacityOfTheElevator)
            {
                Console.WriteLine(1);
                return;
            }
            uint courses = numberOfPeople / capacityOfTheElevator;
            if (numberOfPeople % capacityOfTheElevator != 0)
            {
                courses++;
            }
            Console.WriteLine(courses);
        }
    }
}

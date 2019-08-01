using System;
using System.Collections.Generic;

namespace _06_ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(", ");
                string directions = tokens[0];
                string carNumber = tokens[1];

                if (directions == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else if (directions == "OUT")
                {
                    carNumbers.Remove(carNumber);
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}

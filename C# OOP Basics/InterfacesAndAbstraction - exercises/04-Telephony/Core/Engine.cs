using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            foreach (string number in numbers)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            foreach (string site in sites)
            {
                Console.WriteLine(smartphone.Browse(site));
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _01_PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();


            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command == "A")
                {
                    string name = input[1];
                    string phone = input[2];

                    if (phoneBook.ContainsKey(name) == false)
                    {
                        phoneBook.Add(name, "");
                    }
                    phoneBook[name] = phone;
                }
                else if (command == "S")
                {
                    string searchName = input[1];

                    if (phoneBook.ContainsKey(searchName))
                    {
                        Console.WriteLine($"{searchName} -> {phoneBook[searchName]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {searchName} does not exist.");
                    }

                }
                else if (command == "END")
                {
                    return;
                }
            }
        }
    }
}

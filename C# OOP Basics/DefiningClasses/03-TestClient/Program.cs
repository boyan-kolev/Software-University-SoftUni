using System;
using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Create":
                        CreateAccount(accounts, tokens);
                        break;
                    case "Deposit":
                        Deposit(accounts, tokens);
                        break;
                    case "Withdraw":
                        Withdraw(accounts, tokens);
                        break;
                    case "Print":
                        Print(accounts, tokens[1]);
                        break;
                }


            }
        }

        private static void Print(Dictionary<int, BankAccount> accounts, string strId)
        {
            int id = int.Parse(strId);

            if (accounts.ContainsKey(id))
            {
                BankAccount account = accounts[id];

                Console.WriteLine(account);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }

        }

        private static void Withdraw(Dictionary<int, BankAccount> accounts, string[] tokens)
        {
            int id = int.Parse(tokens[1]);
            decimal amount = int.Parse(tokens[2]);
            if (accounts.ContainsKey(id))
            {
                decimal balance = accounts[id].Balance;
                if (balance >= amount)
                {
                    accounts[id].Withdraw(amount);
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(Dictionary<int, BankAccount> accounts, string[] tokens)
        {
            int id = int.Parse(tokens[1]);
            decimal amount = int.Parse(tokens[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void CreateAccount(Dictionary<int, BankAccount> accounts, string[] tokens)
        {
            int id = int.Parse(tokens[1]);
            if (accounts.ContainsKey(id) == false)
            {
                BankAccount account = new BankAccount();
                account.Id = id;
                accounts.Add(id, account);
            }
            else
            {
                Console.WriteLine("Account already exists");
            }
        }
    }

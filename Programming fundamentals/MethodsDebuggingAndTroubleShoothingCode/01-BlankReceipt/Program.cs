using System;

namespace _01_BlankReceipt
{
    class Program
    {
        static void Main(string[] args)
        {
            printCashReceipt();
        }

        static void printCashReceipt()
        {
            printHeader();
            printBody();
            printFooter();
        }

        static void printHeader()
        {
            Console.WriteLine("CASH RECEIPT\r\n------------------------------");
        }

        static void printBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        static void printFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9" + " SoftUni");
        }
    }
}

using System;

namespace _18_DifferentIntegerSize
{
    class Program
    {
        static void Main(string[] args)
        {
            String number = Console.ReadLine();
            String messaege = "";
            bool canFit = false;
            try
            {
                sbyte num = sbyte.Parse(number);
                messaege += "* sbyte\r\n";
                canFit = true;
            }
            catch { }

            try
            {
                byte num = byte.Parse(number);
                messaege += "* byte\r\n";
                canFit = true;
            }
            catch { }

            try
            {
                short num = short.Parse(number);
                messaege += "* short\r\n";
                canFit = true;
            }
            catch { }

            try
            {
                ushort num = ushort.Parse(number);
                messaege += "* ushort\r\n";
                canFit = true;
            }
            catch { }

            try
            {
                int num = int.Parse(number);
                messaege += "* int\r\n";
                canFit = true;
            }
            catch { }

            try
            {
                uint num = uint.Parse(number);
                messaege += "* uint\r\n";
                canFit = true;
            }
            catch { }

            try
            {
                long num = long.Parse(number);
                messaege += "* long\r\n";
                canFit = true;
            }
            catch { }
            if (canFit)
            {
                Console.WriteLine(number + " can fit in:");
                Console.WriteLine(messaege);
            }
            else
            {
                Console.WriteLine(number + " can't fit in any type");
            }
        }
    }
}

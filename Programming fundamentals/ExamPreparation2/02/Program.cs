using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> listOfDnk = new List<string>();

            while (true)
            {
                string dnk = Console.ReadLine();

                if (dnk == "Clone them!")
                {
                    break;
                }

                listOfDnk.Add(dnk);
            }

            int total = 0;
            int pos = 0;
            int posLast = 0;

            for (int i = 0; i < listOfDnk.Count; i++)
            {
                string[] ff = listOfDnk[i].Split("!", StringSplitOptions.RemoveEmptyEntries);
                string gg = string.Join("", ff);
                string[] row = gg.Split("0".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string strRow = string.Join(" ", row);

                var strMax = row.Max();
                int max = strMax.Length;
                pos = strRow.IndexOf(strMax);

                if (max > total)
                {
                    total = max;
                    posLast = pos;
                }




            }
        }
    }
}


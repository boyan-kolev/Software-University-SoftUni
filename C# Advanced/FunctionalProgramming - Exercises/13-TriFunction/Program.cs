using System;
using System.Linq;

namespace _13_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            var filter = CreateFilter(sum);

            Console.WriteLine(names.FirstOrDefault(filter));
        }

        static Func<string, bool> CreateFilter(int sum)
        {
            return name => name.ToCharArray().Sum(c => c) >= sum;
        }
    }
}

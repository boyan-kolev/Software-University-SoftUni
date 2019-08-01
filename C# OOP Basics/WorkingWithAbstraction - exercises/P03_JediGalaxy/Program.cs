using System;
using System.Linq;

namespace JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimestions[0];
            int columns = dimestions[1];

            Board board = new Board(rows, columns);

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] player = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Point pointEvil = new Point(evil[0], evil[1]);

                while (pointEvil.X >= 0 && pointEvil.Y >= 0)
                {
                    if (board.IsInMatrix(pointEvil))
                    {
                        board.Matrix[pointEvil.X, pointEvil.Y] = 0;
                    }
                    pointEvil.X--;
                    pointEvil.Y--;
                }

                Point pointPlayer = new Point(player[0], player[1]);

                while (pointPlayer.X >= 0 && pointPlayer.Y < board.Matrix.GetLength(1))
                {
                    if (board.IsInMatrix(pointPlayer))
                    {
                        sum += board.Matrix[pointPlayer.X, pointPlayer.Y];
                    }

                    pointPlayer.Y++;
                    pointPlayer.X--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}

using System;
using System.Linq;

namespace _08_RadioactiveMutantVampireBunnies
{
    class Program
    {
        static char[,] board;
        static int rows;
        static int columns;

        static int playerRow;
        static int playerColumn;

        static bool isDie;
        static bool isWon;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            rows = dimensions[0];
            columns = dimensions[1];

            board = new char[rows, columns];
            board = ReadAndFillMatrix();

            char[] moves = Console.ReadLine().ToCharArray();
            isDie = false;

            foreach (char move in moves)
            {
                MovementPlayer(move);

                MultiplyBunnies();


                if (isWon)
                {
                    string wonOrDead = "won";
                    PrintMatrix(wonOrDead);
                    break;
                }
                else if (board[playerRow, playerColumn] == 'B' || isDie)
                {
                    string wonOrDead = "dead";
                    PrintMatrix(wonOrDead);
                    break;
                }
            }
        }

        private static void PrintMatrix(string wonOrDead)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (board[row, column] == 'P')
                    {
                        board[row, column] = '.';
                    }

                    Console.Write(board[row, column]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"{wonOrDead}: {playerRow} {playerColumn}");
        }

        private static void MultiplyBunnies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (board[row, column] == 'B')
                    {
                        if (row > 0)
                        {
                            NewBunny(row - 1, column);
                        }

                        if (row < rows - 1)
                        {
                            NewBunny(row + 1, column);
                        }

                        if (column > 0)
                        {
                            NewBunny(row, column - 1);
                        }

                        if (column < columns - 1)
                        {
                            NewBunny(row, column + 1);
                        }

                    }

                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (board[row, column] == 'X')
                    {
                        board[row, column] = 'B';
                    }
                }
            }

        }

        private static void NewBunny(int row, int column)
        {
            if (board[row, column] != 'B')
            {
                board[row, column] = 'X';
            }

            if (row == playerRow && column == playerColumn)
            {
                isDie = true;
            }
        }

        private static void MovementPlayer(char move)
        {

            int row = playerRow;
            int column = playerColumn;

            switch (move)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerColumn--;
                    break;
                case 'R':
                    playerColumn++;
                    break;
            }

            isWon = playerRow < 0 || playerRow > rows - 1 || playerColumn < 0 || playerColumn > columns - 1;

            if (isWon)
            {
                playerRow = row;
                playerColumn = column;
            }


        }
        private static char[,] ReadAndFillMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int column = 0; column < columns; column++)
                {
                    board[row, column] = currRow[column];

                    if (currRow[column] == 'P')
                    {
                        playerRow = row;
                        playerColumn = column;
                    }
                }
            }

            return board;
        }
    }

}

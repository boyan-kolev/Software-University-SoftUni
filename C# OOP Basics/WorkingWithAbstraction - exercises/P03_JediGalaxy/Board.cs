using System;
using System.Collections.Generic;
using System.Text;

namespace JediGalaxy
{
    class Board
    {
        public int[,] Matrix { get; set; }

        public Board(int rows, int columns)
        {
            Matrix = new int[rows, columns];
            InitializeMatrix();
        }
        private void InitializeMatrix()
        {
            int value = 0;
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int column = 0; column < Matrix.GetLength(1); column++)
                {
                    Matrix[row, column] = value++;
                }
            }
        }

        public bool IsInMatrix(Point point)
        {
            return point.X >= 0
                && point.X < Matrix.GetLength(0)
                && point.Y >= 0
                && point.Y < Matrix.GetLength(1);
        }
    }
}

using System;

namespace ArraysAndStrings
{
    internal class Matrix
    {
        internal static int[,] Rotate90(int[,] matrix)
        {
            if (matrix.Rank != 2)
            {
                throw new ArgumentException("Arry rank should be 2");
            }
            int[,] result = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int srcRows = 0; srcRows < matrix.GetLength(0); srcRows++)
            {
                int destCol = matrix.GetLength(1)-1;
                for (int srcCol = 0; srcCol < matrix.GetLength(1); srcCol++)
                {
                    result[destCol--, srcRows] = matrix[srcRows, srcCol];
                }
            }
            return result;
        }
    }
}
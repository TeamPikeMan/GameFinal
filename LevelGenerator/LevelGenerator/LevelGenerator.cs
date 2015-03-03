using System;
using System.IO;

class Levels
{
    // Game field 
    static int[,] matrix = new int[21, 40];

    // Write the matrix to text file in directory ../../level{level number}.txt
    static void WriteMatrixToFile(int[,] matrix, string level)
    {
        string lvl = level;

        StreamWriter aliens = new StreamWriter(lvl);

        using (aliens)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y] != 0)
                    {
                        aliens.WriteLine("{0},{1},{2}", x, y, matrix[x, y]);
                    }

                }
            }
        }
    }

    // Main
    static void Main()
    {
        FillLevelOne(matrix);
        CleraMatrix(matrix);
        FillLevelTwo(matrix);
        CleraMatrix(matrix);
        FillLevelThree();
        CleraMatrix(matrix);
        FillLevelFour(matrix);
    }

    // Level 4
    static void FillLevelFour(int[,] matrix)
    {
        int start = 1;
        int end = matrix.GetLength(1) - 1;
        for (int i = 0; i < 9; i++)
        {
            for (int j = start; j < end; j++)
            {
                if (j % 5 != 0 && j % 4 != 0)
                {
                    if (i == 1 || i == 2)
                    {
                        matrix[i, j] = 3;
                    }
                    if (i == 4)
                    {
                        matrix[i, j] = 2;
                    }
                    if (i == 6)
                    {
                        matrix[i, j] = 1;
                    }
                }

                if (i == 8 && j % 2 != 0)
                {
                    matrix[i, j] = 3;
                }
            }
        }

        WriteMatrixToFile(matrix, "..\\..\\Level4.txt");
    }

    // Level 3
    static void FillLevelThree()
    {
        int start = 1;
        int end = matrix.GetLength(1) - 1;
        for (int i = 0; i < 6; i++)
        {
            for (int j = start; j < end; j++)
            {
                if (j % 5 != 0)
                {
                    if (i == 0 || i == 1)
                    {
                        matrix[i, j] = 3;
                    }
                    if (i == 3)
                    {
                        matrix[i, j] = 2;
                    }
                    if (i == 5)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        WriteMatrixToFile(matrix, "..\\..\\Level3.txt");
    }

    // Level 2
    static void FillLevelTwo(int[,] matrix)
    {
        int start = 5;
        int end = 15;
        for (int i = 1; i < 6; i++)
        {
            for (int j = start; j < end; j++)
            {
                if (i == 1 || i == 5)
                {
                    matrix[i, j] = 1;
                }
                if (i == 2 || i == 4)
                {
                    matrix[i, j] = 2;
                }
                if (i == 3)
                {
                    matrix[i, j] = 3;
                }
            }
        }

        for (int i = 1; i < 6; i++)
        {
            for (int j = end + 10; j < end + 20; j++)
            {
                if (i == 1 || i == 5)
                {
                    matrix[i, j] = 1;
                }
                if (i == 2 || i == 4)
                {
                    matrix[i, j] = 2;
                }
                if (i == 3)
                {
                    matrix[i, j] = 3;
                }
            }
        }

        WriteMatrixToFile(matrix, "..\\..\\Level2.txt");
    }

    // Level 1 
    static void FillLevelOne(int[,] matrix)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 1; j < matrix.GetLength(1) - 1; j++)
            {
                if (j % 5 != 0 && i == 2)
                {
                    matrix[i, j] = 1;
                }
                if (j % 5 != 0 && i == 1)
                {
                    matrix[i, j] = 2;
                }
                if (j % 5 != 0 && i == 0)
                {
                    matrix[i, j] = 3;
                }
            }

            WriteMatrixToFile(matrix, "..\\..\\Level1.txt");
        }
    }

    // Clear Matrix for the next level
    static void CleraMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 1; j < matrix.GetLength(1) - 1; j++)
            {
                matrix[i, j] = 0;
            }
        }
    }
}


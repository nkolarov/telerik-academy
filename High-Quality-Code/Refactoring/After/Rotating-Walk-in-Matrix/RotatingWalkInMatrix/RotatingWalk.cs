namespace RotatingWalkInMatrix
{
    using System;

    /// <summary>
    /// Represents the Generation of Rotating Walk in Matrix.
    /// </summary>
    public class RotatingWalk
    {
        private static readonly int[] DirectionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] DirectionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private static int counter;
        private static int currentDirectionX;
        private static int currentDirectionY;
        public const int MIN_MATRIX_SIZE = 0;
        public const int MAX_MATRIX_SIZE = 100;

        /// <summary>
        /// Generates the rotating walk matrix.
        /// </summary>
        /// <param name="matrixSize">Size of the matrix.</param>
        /// <returns>The generated matrix.</returns>
        public static int[,] GenerateRotatingWalkMatrix(int matrixSize)
        {
            if (!IsInValidRange(matrixSize))
            {
                throw new ArgumentOutOfRangeException("Matrix size: " + matrixSize + "must be in range [0,100]!");
            }

            int[,] matrix = new int[matrixSize, matrixSize];
            counter = 1;
            int col = 0;
            int row = 0;

            FillWakiInMatrix(matrix, matrixSize, col, row);
            FindFirstEmptyCell(matrix, out col, out row);
            counter++;

            // If matrix is smaller than 3x3 we dont have to repeat the filling.
            if (matrixSize > 3)
            {
                FillWakiInMatrix(matrix, matrixSize, col, row);
            }

            return matrix;
        }

        /// <summary>
        /// Determines whether [is in valid range] [the specified matrix size].
        /// </summary>
        /// <param name="matrixSize">Size of the matrix.</param>
        /// <returns>True if is in valid range.</returns>
        private static bool IsInValidRange(int matrixSize)
        {
            if (matrixSize < MIN_MATRIX_SIZE || matrixSize > MAX_MATRIX_SIZE)
            {
                return false;
            }

            return true;
        }

        private static void CorrectDirection()
        {
            int currentIndex = 0;

            for (int i = 0; i < DirectionX.Length; i++)
            {
                if (DirectionX[i] == currentDirectionX && DirectionY[i] == currentDirectionY)
                {
                    currentIndex = i;
                    break;
                }
            }

            if (currentIndex == 7)
            {
                currentDirectionX = DirectionX[0];
                currentDirectionY = DirectionY[0];
                return;
            }

            currentDirectionX = DirectionX[currentIndex + 1];
            currentDirectionY = DirectionY[currentIndex + 1];
        }

        private static bool HasPossibleTurn(int[,] arr, int x, int y)
        {
            int[] possibleDirrectionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + possibleDirrectionX[i] >= arr.GetLength(0) || x + possibleDirrectionX[i] < 0)
                {
                    possibleDirrectionX[i] = 0;
                }

                if (y + possibleDirectionY[i] >= arr.GetLength(0) || y + possibleDirectionY[i] < 0)
                {
                    possibleDirectionY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + possibleDirrectionX[i], y + possibleDirectionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindFirstEmptyCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[row, j] == 0)
                    {
                        x = row;
                        y = j;
                        return;
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            // int matrixSize = 0;
            int matrixSize = ReadMatrixSize();
            bool isInRange = IsInValidRange(matrixSize);
            if (!isInRange)
            {
                throw new ArgumentOutOfRangeException("Matrix size: " + matrixSize + "must be in range [0,100]!");
            }
            
            int[,] matrix = GenerateRotatingWalkMatrix(matrixSize);

            PrintMatrix(matrix, matrixSize);
        }
  
        private static int ReadMatrixSize()
        {
            Console.WriteLine("Enter matrix size [0,100]:");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            return n;
        }

        private static void PrintMatrix(int[,] matrix, int matrixSize)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
  
        private static void FillWakiInMatrix(int[,] matrix, int matrixSize, int row, int col)
        {
            currentDirectionX = 1;
            currentDirectionY = 1;

            for (int i = 0; i < matrixSize * matrixSize; i++)
            {
                matrix[row, col] = counter;

                if (!HasPossibleTurn(matrix, row, col))
                {
                    break;
                }

                while (row + currentDirectionX >= matrixSize || row + currentDirectionX < 0 ||
                       col + currentDirectionY >= matrixSize || col + currentDirectionY < 0 ||
                       matrix[row + currentDirectionX, col + currentDirectionY] != 0)
                {
                    CorrectDirection();
                }
                
                row += currentDirectionX;
                col += currentDirectionY;
                counter++;
            }
        }
    }
}
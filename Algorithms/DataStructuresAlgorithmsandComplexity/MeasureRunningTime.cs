// ********************************
// <copyright file="MeasureRunningTime.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DSAandComplexity
{
    using System;

    /// <summary>
    /// Demonstrates the calculation of elementary steps and running time for given piece of code.
    /// </summary>
    public class MeasureRunningTime
    {
        /* Task 01: What is the expected running time of the following C# code? Explain why. Assume the array's size is n.*/
        public static long Compute(int[] arr)
        {
            // Explanation:
            // Running time O(n^2), number of elementary steps ~(n*(n-1)). 
            // Outer loop "for" will make n cycles. Inner loop "while" will make n-1 cycles because start will allways lower than end. 
            long count = 0;

            // First cycle with n steps.
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                
                // Second cycle with n-1 steps.
                while (start < end)
                {
                    if (arr[start] < arr[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }
            return count;
        }

        /* Task 02: What is the expected running time of the following C# code? Explain why. Assume the input matrix has size of n * m. */
        public static long CalcCount(int[,] matrix)
        {
            // Running time average and worst O(n*m), best O(n).
            // Number of elementary steps is ~(n + x*m) where x is the number of cells in the first column of the matrix holding value divisible by 2.
            // Outer loop "for" will make n cycles. Inside we have a conditional branch with m operations that run every time when the value of the current first column is divisible by 2. 
            // Best case is when none of them is divisible by 2.
            long count = 0;

            // First cycle with n steps.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                // Conditional branch
                if (matrix[row, 0] % 2 == 0)
                {
                    // Second cycle with m steps.
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /* Task 03: * What is the expected running time of the following C# code? Explain why. Assume the input matrix has size of n * m.*/
        public static long CalcSum(int[,] matrix, int row)
        {
            // Runing time O(n*m). 
            // Number of elementary steps is ~(m + (m*(n-row)))
            // The algorithm passes recursively through each of the rows of the matrix with (n - row) steps.
            // For each row we nake m steps to calculate the sum. 
            long sum = 0;

            // Bug -> matrix.GetLenght(0) must be changed with matrix.GetLenght(1) -> second dimension lenght -> columns.
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                sum += matrix[row, col];
            }

            // Bug -> matrix.GetLenght(1) must be changed with matrix.GetLenght(0) -> rows.
            if (row + 1 < matrix.GetLength(1))
            {
                sum += CalcSum(matrix, row + 1);
            }
                
            return sum;
        }

        public static void Main()
        {
            // int[] testArray = new int[] { 1, 2, 3 };
            // Compute(testArray);
        }
    }
}
// ********************************
// <copyright file="FindAllPathsInMatrix.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace FindAllPathsInMatrix
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates the finding of all paths in matrix;
    /// </summary>
    public class FindAllPathsInMatrix
    {
        /* 07. We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two cells in the matrix.*/

        /// <summary>
        /// Stores the matrix;
        /// </summary>
        private static char[,] matrix = new char[,]
        {
            { ' ', ' ', ' ', '*', ' ', ' ', 'e' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
        };

        /// <summary>
        /// Stores the current path.
        /// </summary>
        private static List<Tuple<int, int>> currentPath = new List<Tuple<int, int>>();

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            FindAllPaths(0, 0);
        }

        /// <summary>
        /// Finds all paths.
        /// </summary>
        /// <param name="startX">The start X.</param>
        /// <param name="startY">The start Y.</param>
        private static void FindAllPaths(int startX, int startY)
        {
            // Check if out of matrix.
            if (startX < 0 || startY < 0 || startX >= matrix.GetLength(0) || startY >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[startX, startY] == '*' || matrix[startX, startY] == 'v')
            {
                return;
            }

            if (matrix[startX, startY] == 'e')
            {
                currentPath.Add(new Tuple<int, int>(startX, startY));
                PrintPath(currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
                return;
            }

            // Add to path and mark as visited.
            currentPath.Add(new Tuple<int, int>(startX, startY));
            matrix[startX, startY] = 'v';

            // Go up
            FindAllPaths(startX - 1, startY);

            // Go down
            FindAllPaths(startX + 1, startY);

            // Go left
            FindAllPaths(startX, startY - 1);

            // Go right
            FindAllPaths(startX, startY + 1);

            matrix[startX, startY] = ' ';
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        /// <summary>
        /// Prints the path.
        /// </summary>
        /// <param name="currentPath">The current path.</param>
        private static void PrintPath(List<Tuple<int, int>> currentPath)
        {
            Console.WriteLine("Path to the exit:");
            foreach (var step in currentPath)
            {
                Console.Write("({0}, {1})", step.Item1, step.Item2);
            }

            Console.WriteLine();
        }
    }
}
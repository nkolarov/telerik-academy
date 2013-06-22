// ********************************
// <copyright file="CheckIfPathExists.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Recursion
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates the finding of all paths in matrix;
    /// </summary>
    public class CheckIfPathExists
    {
        /* 08. Modify the above program to check whether a path exists between two cells without finding all possible paths. Test it over an empty 100 x 100 matrix.*/
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
        /// Stores the has exit state.
        /// </summary>
        private static bool hasExit = false;

        /// <summary>
        /// Stores the current path.
        /// </summary>
        private static List<Tuple<int, int>> currentPath = new List<Tuple<int, int>>();

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            // To test with an empty matrix just uncomment the nex two rows.
            // matrix = new char[100, 100];
            // matrix[99, 99] = 'e';
            FindPath(0, 0);

            if (hasExit)
            {
                Console.WriteLine("Path exists!");
            }
            else
            {
                Console.WriteLine("Path does not exists!");
            }
        }

        /// <summary>
        /// Finds the path.
        /// </summary>
        /// <param name="startX">The start X.</param>
        /// <param name="startY">The start Y.</param>
        private static void FindPath(int startX, int startY)
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

            // Path found!
            if (matrix[startX, startY] == 'e')
            {
                hasExit = true;
                currentPath.Add(new Tuple<int, int>(startX, startY));
            }

            // Add to path and mark as visited.
            currentPath.Add(new Tuple<int, int>(startX, startY));
            matrix[startX, startY] = 'v';

            // Go up
            FindPath(startX - 1, startY);

            // Go down
            FindPath(startX + 1, startY);

            // Go left
            FindPath(startX, startY - 1);

            // Go right
            FindPath(startX, startY + 1);
        }
    }
}
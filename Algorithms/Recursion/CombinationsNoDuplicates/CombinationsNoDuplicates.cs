// ********************************
// <copyright file="CombinationsNoDuplicates.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Recursion
{
    using System;

    /// <summary>
    /// Demonstrates the generation of combinations with duplicates.
    /// </summary>
    public class CombinationsNoDuplicates
    {
        /* 03. Modify the previous program to skip duplicates:
        * n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
        */

        /// <summary>
        /// Stores the size of n-element set.
        /// </summary>
        private static int n;
        
        /// <summary>
        /// Stores elements count(class).
        /// </summary>
        private static int k;

        /// <summary>
        /// Stores the current combination.
        /// </summary>
        private static int[] combination;

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Please enter n:");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter k:");
            k = int.Parse(Console.ReadLine());

            combination = new int[k];

            GenerateCombinations(1, 0);
        }

        /// <summary>
        /// Generates all combinations without duplicates.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="next">The next.</param>
        private static void GenerateCombinations(int level, int next)
        {
            if (level > k)
            {
                return;
            }

            for (int i = next + 1; i <= n; i++)
            {
                combination[level - 1] = i;
                if (level == k)
                {
                    Console.WriteLine(string.Join(" ", combination));
                }

                GenerateCombinations(level + 1, i);
            }
        }
    }
}
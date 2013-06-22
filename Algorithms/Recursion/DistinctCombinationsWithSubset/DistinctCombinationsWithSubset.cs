// ********************************
// <copyright file="DistinctCombinationsWithSubset.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Recursion
{
    using System;

    /// <summary>
    /// Demonstrates the generation of combinations without duplicates.
    /// </summary>
    public class DistinctCombinationsWithSubset
    {
        /* 06. Write a program for generating and printing all subsets of k strings from given set of strings.
        Example: s = {test, rock, fun}, k=2
        (test rock),  (test fun),  (rock fun)
        */

        /// <summary>
        /// Stores elements count(class).
        /// </summary>
        private static int k = 2;
        
        /// <summary>
        /// Stores the set.
        /// </summary>
        private static string[] set = new string[] { "test", "rock", "fun" };
        
        // private static string[] set = new string[] { "test", "rock", "fun", "pesho" };

        /// <summary>
        /// Stores the current combination.
        /// </summary>
        private static string[] combination = new string[k];

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
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

            for (int i = next + 1; i <= set.Length; i++)
            {
                combination[level - 1] = set[i - 1];
                if (level == k)
                {
                    Console.WriteLine(string.Join(" ", combination));
                }

                GenerateCombinations(level + 1, i);
            }
        }
    }
}
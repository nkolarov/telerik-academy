// ********************************
// <copyright file="PermutationGeneration.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Recursion
{
    using System;

    /// <summary>
    /// Demonstrates the generation of permutations for given n.
    /// </summary>
    public class PermutationGeneration
    {
        /* 04. Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. 
        * Example: n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}*/

        /// <summary>
        /// Stores the size of n.
        /// </summary>
        private static int n;

        /// <summary>
        /// Stores the current permutation.
        /// </summary>
        private static int[] permutation;
        
        /// <summary>
        /// Tracks which element is used in the current permutation.
        /// </summary>
        private static bool[] used;

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Please enter n:");
            n = int.Parse(Console.ReadLine());

            permutation = new int[n];
            used = new bool[n];
            
            Permute(0);
        }

        /// <summary>
        /// Generates permutations recursively.
        /// </summary>
        /// <param name="currentindex">The current index.</param>
        private static void Permute(int currentindex)
        {
            if (currentindex >= n)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[currentindex] = i + 1;
                    Permute(currentindex + 1);
                    used[i] = false;
                }
            }
        }
    }
}
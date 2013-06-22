// ********************************
// <copyright file="CombinationsWithSubset.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Recursion
{
    using System;

    /// <summary>
    /// Demonstrates the generation of combinations with duplicates.
    /// </summary>
    public class CombinationsWithSubset
    {
        /* 05. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
        Example: n=3, k=2, set = {hi, a, b} =>
        (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
        */

        /// <summary>
        /// Stores the set.
        /// </summary>
        private static string[] set = new string[] { "hi", "a", "b" };

        /// <summary>
        /// Stores the size of n-element set.
        /// </summary>
        private static int n = 3;
        
        /// <summary>
        /// Stores elements count(class).
        /// </summary>
        private static int k = 2;
        
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            string[] array = new string[n];

            GenerateSubSets(array, 0);
        }

        /// <summary>
        /// Generates the subsets.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="currentindex">The current index.</param>
        private static void GenerateSubSets(string[] array, int currentindex)
        {
            if (currentindex == k)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                array[currentindex] = set[i];
                GenerateSubSets(array, currentindex + 1);
            }
        }
    }
}
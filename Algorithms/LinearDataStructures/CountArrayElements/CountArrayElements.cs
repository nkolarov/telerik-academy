// ********************************
// <copyright file="CountArrayElements.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace CountArrayElements
{
    using System;
    using CountElements;

    /// <summary>
    /// Demonstrates the counting of array elements. To pass over the restriction of creating static array with 1001 elements i prefer using dictionary.
    /// </summary>
    public class CountArrayElements
    {
        /* 07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
        Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        2 -> 2 times
        3 -> 4 times
        4 -> 3 times */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            int[] elements = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var elementsCounts = CountElements.CountElementsOccurrence(elements);

            Console.WriteLine("Elements: " + string.Join(", ", elements));

            foreach (var element in elementsCounts)
            {
                Console.WriteLine("{0} -> {1} {2}", element.Key, element.Value, element.Value == 1 ? "time" : "times");
            }
        }
    }
}
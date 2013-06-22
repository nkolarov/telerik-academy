// ********************************
// <copyright file="SimulateNestedLoops.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Recursion
{
    using System;

    /// <summary>
    /// Demonstrates nested loops simulation.
    /// </summary>
    public class SimulateNestedLoops
    {
        /* 01. Write a recursive program that simulates the execution of n nested loops from 1 to n.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Please enter n:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            SimulateNestedLoop(array, n, 0);
        }

        /// <summary>
        /// Simulates nested loops.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="count">The count of loops.</param>
        /// <param name="currentindex">The current index.</param>
        private static void SimulateNestedLoop(int[] array, int count, int currentindex)
        {
            if (currentindex == count)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 0; i < count; i++)
            {
                array[currentindex] = i + 1;
                SimulateNestedLoop(array, count, currentindex + 1);
            }
        }
    }
}
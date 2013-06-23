// ********************************
// <copyright file="KnapsackProblem.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DynamicProgramming
{
    using System;
    using System.Text;

    /// <summary>
    /// Demonstrates the solving of knapsack problem.
    /// </summary>
    public class KnapsackProblem
    {
        /* 01. 
        Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products, 
        each has weight Wi and costs Ci and a knapsack of capacity M and you want to put inside a subset of the products with highest cost and weight ≤ M. 
        The numbers N, M, Wi and Ci are integers in the range [1..500]. Example: M=10 kg, N=6, products:
        beer – weight=3, cost=2
        vodka – weight=8, cost=12
        cheese – weight=4, cost=5
        nuts – weight=1, cost=4
        ham – weight=2, cost=3
        whiskey – weight=8, cost=13
        Optimal solution:
        nuts + whiskey
        weight = 9
        cost = 17
        */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            string[] names = new string[] { "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
            int[] weights = new int[] { 3, 8, 4, 1, 2, 8 };
            int[] costs = new int[] { 2, 12, 5, 4, 3, 13 };
            int knapsackCapacity = 10;

            GetOptimalSackFilling(names, costs, weights, knapsackCapacity);
        }

        /// <summary>
        /// Gets the optimal knapsack filling.
        /// Uses parts of this algorithm: http://www.8bitavenue.com/2011/12/dynamic-programming-integer-knapsack/
        /// </summary>
        /// <param name="names">The names.</param>
        /// <param name="weights">The weights.</param>
        /// <param name="costs">The costs.</param>
        /// <param name="knapsackCapacity">The knapsack capacity.</param>
        private static void GetOptimalSackFilling(string[] names, int[] weights, int[] costs, int knapsackCapacity)
        {
            int itemsCount = weights.Length;
            bool[,] usedItems = new bool[knapsackCapacity + 1, itemsCount];
            int[] maxCosts = new int[knapsackCapacity + 1];

            // Trivial case when (j=0) 
            // the value we get is also zero
            maxCosts[0] = 0;

            // For each slot in the knapsack do
            for (int slot = 1; slot <= knapsackCapacity; slot++)
            {
                // M[slot] will be max1 (or M[slot-1]) 
                // if the slot is empty
                int max1 = maxCosts[slot - 1];

                // M[slot] will be max2 if the 
                // slot is occupied by some item
                int max2 = int.MinValue;

                // This is used to mark the previous 
                // slot if the jth slot is occupied
                int mark = 0;

                // Stores the last candidate index that can be put in the knapsack.
                int lastUsedCandidateIndex = 0;

                // Search for an item to occupy the 
                // slot such that it gives us maximum value
                for (int item = 0; item < itemsCount; item++)
                {
                    // For each item (i) calculate (V[i] + M[j - S[i]]) 
                    // then compare it to the current max. If it is greater 
                    // then update the current max. Only those items satisfying 
                    // the condition (j - S[i] >= 0) are checked because capacity 
                    // should not be negative
                    if (slot - costs[item] >= 0 &&
                        !usedItems[slot - costs[item], item] &&
                        weights[item] + maxCosts[slot - costs[item]] > max2)
                    {
                        // Update the max
                        max2 = weights[item] + maxCosts[slot - costs[item]];

                        // Save the previous (j) position 
                        // that gives us the maximum value
                        mark = slot - costs[item];

                        // Update the last candidate
                        lastUsedCandidateIndex = item;
                    }
                }

                if (max1 > max2)
                {
                    // Case1: jth slot is empty
                    maxCosts[slot] = max1;

                    for (int k = 0; k < itemsCount; k++)
                    {
                        usedItems[slot, k] = usedItems[slot - 1, k];
                    }
                }
                else
                {
                    // Case 2: jth slot is occupied
                    maxCosts[slot] = max2;

                    for (int k = 0; k < itemsCount; k++)
                    {
                        usedItems[slot, k] = usedItems[mark, k];
                    }

                    // The candidate is used
                    usedItems[slot, lastUsedCandidateIndex] = true;
                }
            }

            // Print result
            StringBuilder itemsAsString = new StringBuilder();
            long totalWeight = 0;
            long totalCost = 0;

            // Count and sum result statitstics.
            for (int i = 0; i < itemsCount; i++)
            {
                if (usedItems[knapsackCapacity, i])
                {
                    itemsAsString.Append(names[i] + " + ");
                    totalWeight += weights[i];
                    totalCost += costs[i];
                }
            }

            itemsAsString.Length -= 3;

            Console.WriteLine("Optimal solution:");
            Console.WriteLine(itemsAsString);
            Console.WriteLine("Weight: " + totalWeight);
            Console.WriteLine("Cost: " + totalCost);
        }
    }
}
// ********************************
// <copyright file="ColorBalls.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Combinatorics
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// Demonstrates the solving of task color balls.
    /// </summary>
    public class ColorBalls
    {
        /* http://bgcoder.com/Contest/Practice/59 04. Редица цветни топчета. */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            string line = Console.ReadLine();
            int n = line.Length;

            BigInteger nominator = Factorial(n);
            BigInteger denominator = 1;

            // Count all balls and store their count to a dictionary.
            Dictionary<char, int> letters = new Dictionary<char, int>();

            for (int i = 0; i < line.Length; i++)
            {
                if (letters.ContainsKey(line[i]))
                {
                    letters[line[i]]++;
                }
                else
                {
                    letters[line[i]] = 1;
                }
            }

            // Calculate the factorials for all different balls.
            foreach (var item in letters)
            {
                denominator *= Factorial(item.Value);
            }

            Console.WriteLine(nominator / denominator);
        }

        /// <summary>
        /// Calculate the factorial for specified n.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>The calculated factorial.</returns>
        public static BigInteger Factorial(BigInteger n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
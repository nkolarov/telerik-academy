// ********************************
// <copyright file="FirstApproach.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Combinatorics
{
    using System;

    /// <summary>
    /// Demonstrates the generation of all binary passwords.
    /// </summary>
    public class FirstApproach
    {
        /* http://bgcoder.com/Contest/Practice/59 Task: 01. Двоични пароли. */

        private static int count = 0;
        private static char[] input;

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void OldMain()
        {
            string line = Console.ReadLine();
            input = new char[line.Length];
            int[] password = new int[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                input[i] = line[i];
            }

            int k = input.Length;
            int n = 2;
            GeneratePasswords(password, k, n, 0);
            Console.WriteLine(count);
        }

        /// <summary>
        /// Generates all combinations including duplicates.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="k">The k.</param>
        /// <param name="n">The n.</param>
        /// <param name="currentindex">The current index.</param>
        private static void GeneratePasswords(int[] array, int k, int n, int currentindex)
        {
            if (currentindex == k)
            {
                count++;
                return;
            }

            if (input[currentindex] != '*')
            {
                array[currentindex] = input[currentindex] - '0';
                GeneratePasswords(array, k, n, currentindex + 1);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    array[currentindex] = i;
                    GeneratePasswords(array, k, n, currentindex + 1);
                }
            }
        }
    }
}
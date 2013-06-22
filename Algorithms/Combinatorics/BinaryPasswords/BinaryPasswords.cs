// ********************************
// <copyright file="BinaryPasswords.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Combinatorics
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Demonstrates the solving of task binary passwords.
    /// </summary>
    public class BinaryPasswords
    {
        /* http://bgcoder.com/Contest/Practice/59 Task: 01. Двоични пароли. */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            int count = 0;
            string line = Console.ReadLine();
            
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '*')
                {
                    count++;
                }
            }

            if (line.Length == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine((BigInteger)Math.Pow(2, count));
            }
        }
    }
}
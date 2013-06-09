// ********************************
// <copyright file="ListDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ListDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Demonstrates List usage.
    /// </summary>
    public class ListDemo
    {
        /* 01. Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. 
        *      Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.
        */
        
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            bool isEmptyLine = false;
            bool isPositiveInteger = false;
            List<int> sequence = new List<int>();

            // Read input until empty line is reached.
            do
            {
                Console.WriteLine("Enter a positive integer number. Leave blank for end:");
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    isEmptyLine = true;
                    break;
                }

                int currentNumber = int.Parse(line);
                if (currentNumber > 0)
                {
                    isPositiveInteger = true;
                    sequence.Add(currentNumber);
                }
                else
                {
                    Console.WriteLine("Error! Please enter a positive integer number:");
                    isPositiveInteger = false;
                }
            }
            while (!isEmptyLine || !isPositiveInteger);

            // Print result
            if (sequence.Count > 0)
            {
                Console.WriteLine("Sum:" + sequence.Sum());
                Console.WriteLine("Average:" + sequence.Average());
            }
            else
            {
                Console.WriteLine("The sequence is empty!");
            }
        }
    }
}
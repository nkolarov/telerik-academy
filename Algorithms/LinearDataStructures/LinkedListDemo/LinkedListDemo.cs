// ********************************
// <copyright file="LinkedListDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace LinkedListDemo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates Linked List usage.
    /// </summary>
    public class LinkedListDemo
    {
        /* 05. Write a program that removes from given sequence all negative numbers.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            bool isEmptyLine = false;
            LinkedList<int> sequence = new LinkedList<int>();

            // Read input until empty line is reached.
            do
            {
                Console.WriteLine("Enter an integer number. Leave blank for end:");
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    isEmptyLine = true;
                    break;
                }

                int currentNumber = int.Parse(line);

                sequence.AddLast(currentNumber);
            }
            while (!isEmptyLine);

            // Print result
            Console.WriteLine("Before: " + string.Join(", ", sequence));
            sequence = RemoveNegativeNumbers(sequence);
            Console.WriteLine("After: " + string.Join(", ", sequence));
        }

        /// <summary>
        /// Removes the negative numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>A linked list with removed negative numbers.</returns>
        public static LinkedList<int> RemoveNegativeNumbers(LinkedList<int> numbers)
        {
            var node = numbers.First;

            while (node != null)
            {
                // When we remove the current element we will loose the pointer to the next element.
                // Thats why we need to save the next node.
                var next = node.Next;

                if (node.Value < 0)
                {
                    numbers.Remove(node);
                }

                node = next;
            }

            return numbers;
        }
    }
}
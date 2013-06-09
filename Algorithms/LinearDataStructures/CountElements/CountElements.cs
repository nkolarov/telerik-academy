// ********************************
// <copyright file="CountElements.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace CountElements
{
    using System;
    using System.Collections.Generic;

    public static class CountElements
    {
        /* 06. Write a program that removes from given sequence all numbers that occur odd number of times. Example:*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            LinkedList<int> sequence = ReadInputSequence();

            var numbersCounts = CountElementsOccurrence(sequence);
            Console.WriteLine("Before: " + string.Join(", ", sequence));
            sequence = RemoveNumbersOccuringOddTimes(sequence, numbersCounts);
            Console.WriteLine("After: " + string.Join(", ", sequence));
        }
  
        /// <summary>
        /// Reads the input sequence.
        /// </summary>
        /// <returns>The sequence.</returns>
        private static LinkedList<int> ReadInputSequence()
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
            return sequence;
        }
  
        /// <summary>
        /// Counts the elements occurrence.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns>Map for each element, containing the count.</returns>
        public static Dictionary<int, int> CountElementsOccurrence(IEnumerable<int> elements)
        {
            Dictionary<int, int> elementsCount = new Dictionary<int, int>();
            // Count elements and store their count to dictionary.
            foreach (var num in elements)
            {
                if (elementsCount.ContainsKey(num))
                {
                    elementsCount[num] += 1;
                }
                else
                {
                    elementsCount.Add(num, 1);
                }
            }

            return elementsCount;
        }

        /// <summary>
        /// Removes the numbers occuring odd times.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="numbersCounts">The numbers counts.</param>
        /// <returns>The cleaned sequence.</returns>
        public static LinkedList<int> RemoveNumbersOccuringOddTimes(LinkedList<int> numbers, Dictionary<int, int> numbersCounts)
        {
            var node = numbers.First;

            while (node != null)
            {
                // When we remove the current element we will loose the pointer to the next element.
                // Thats why we need to save the next node.
                var next = node.Next;
                
                if (numbersCounts[node.Value] % 2 != 0)
                {
                    numbers.Remove(node);
                }

                node = next;
            }

            return numbers;
        }
    }
}
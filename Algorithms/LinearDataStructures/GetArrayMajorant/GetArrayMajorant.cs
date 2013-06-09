// ********************************
// <copyright file="GetArrayMajorant.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace GetArrayMajorant
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates how to find sequence majorant.
    /// </summary>
    public class GetArrayMajorant
    {
        /*08. * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). 
        * Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3*/
        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            List<int> elements = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            elements.Sort();

            if (elements.Count > 0)
            {
                int current = elements[0];
                int currentCount = 1;
                int majorant = current;
                int majorantCount = 1;

                // Walk through list and find the max occuring element.
                for (int i = 1; i < elements.Count; i++)
                {
                    if (current == elements[i]) 
                    {
                        currentCount++;
                    }
                    else
                    {
                        if (currentCount > majorantCount)
                        {
                            majorantCount = currentCount;
                            majorant = current;
                        }

                        current = elements[i];
                        currentCount = 1;
                    }
                }

                Console.WriteLine("Elements: " + string.Join(", ", elements));
                if (majorantCount >= (elements.Count / 2) + 1)
                {
                    Console.WriteLine("Majorant: {0}, occuring {1} {2}.", majorant, majorantCount, majorantCount == 1 ? "time" : "times");
                }
                else
                {
                    Console.WriteLine("Majorant not found!");
                }
            }
            else
            {
                Console.WriteLine("Majorant not found!");
            }
        }
    }
}
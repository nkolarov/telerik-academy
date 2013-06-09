// ********************************
// <copyright file="QueueDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace QueueDemo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Demonstrates Queue usage.
    /// </summary>
    public class QueueDemo
    {
        /* 09. We are given the following sequence:
        S1 = N;
        S2 = S1 + 1;
        S3 = 2*S1 + 1;
        S4 = S1 + 2;
        S5 = S2 + 1;
        S6 = 2*S2 + 1;
        S7 = S2 + 2;
        ...
        Using the Queue<T> class write a program to print its first 50 members for given N.
        Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
        */

        /// <summary>
        /// Mains this instance.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Please enter n: ");
            int n = int.Parse(Console.ReadLine());
            Queue<int> sequenceElements = new Queue<int>();
            sequenceElements.Enqueue(n);

            Console.WriteLine("Result: ");
            for (int i = 0; i < 50; i++)
            {
                int currentElement = sequenceElements.Dequeue();
                Console.WriteLine(currentElement);

                sequenceElements.Enqueue(currentElement + 1);
                sequenceElements.Enqueue(currentElement * 2 + 1);
                sequenceElements.Enqueue(currentElement + 2);
            }
        }
    }
}
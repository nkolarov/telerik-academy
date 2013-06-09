// ********************************
// <copyright file="LinkedListDemoImplementation.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace LinkedListDemoImplementation
{
    using System;

    /// <summary>
    /// Demonstrates Linked list usage.
    /// </summary>
    public class LinkedListDemoImplementation
    {
        /* 11. Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). 
         * Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).*/

        /// <summary>
        /// Mains the specified args.
        /// </summary>
        public static void Main()
        {
            LinkedList<int> testList = new LinkedList<int>();
            // Console.WriteLine(testList);
            testList.AddFirst(1);
            testList.AddFirst(2);
            testList.AddFirst(8);
            testList.AddFirst(1);
            testList.AddLast(3);
            testList.AddLast(5);
            testList.Remove(1);
            testList.Remove(5);
            Console.Write(testList);
        }
    }
}
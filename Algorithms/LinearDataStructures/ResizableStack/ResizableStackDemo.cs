// ********************************
// <copyright file="ResizeableStackDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ResizableStack
{
    using System;

    /// <summary>
    /// Demonstates resizable stack.
    /// </summary>
    public class ResizableStackDemo
    {
        /* 12. Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            ResizableStack<int> testStack = new ResizableStack<int>();

            testStack.Push(1);
            testStack.Push(2);
            testStack.Push(3);

            testStack.Pop();
            Console.WriteLine(testStack.Peek());

        }
    }
}
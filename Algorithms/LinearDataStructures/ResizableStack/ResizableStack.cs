// ********************************
// <copyright file="ResizableStack.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ResizableStack
{
    using System;

    /// <summary>
    /// Represents resizable stack.
    /// </summary>
    public class ResizableStack<T>
    {
        private static readonly int initialStackCapacity = 1;
        private T[] innerArray = new T[initialStackCapacity];
        private int elementsCount = initialStackCapacity;
        private int index = 0;

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return this.index;
            }
        }

        /// <summary>
        /// Pushes the specified value to the stack.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Push(T value)
        {
            if (this.Count == this.elementsCount)
            {
                this.elementsCount *= 2;

                T[] doubleSizeArray = new T[elementsCount];

                Array.Copy(this.innerArray, doubleSizeArray, this.index);

                this.innerArray = doubleSizeArray;
            }

            this.innerArray[this.index] = value;
            this.index++;
        }

        /// <summary>
        /// Pops the last inserted value.
        /// </summary>
        public void Pop()
        {
            if (this.innerArray == null)
            {
                throw new InvalidOperationException("The Stack is empty!");
            }

            T[] largerArray = new T[elementsCount];

            Array.Copy(this.innerArray, largerArray, this.index - 1);

            this.innerArray = largerArray;

            this.index--;
        }

        /// <summary>
        /// Peeks the last inserted value.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return this.innerArray[index - 1];
        }

        /// <summary>
        /// Toes the array.
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] newArray = new T[this.index];

            Array.Copy(this.innerArray, newArray, this.index);

            this.innerArray = newArray;

            return newArray;
        }

        /// <summary>
        /// Trims the array.
        /// </summary>
        public void TrimExcess()
        {
            T[] trimedArray = new T[index];

            Array.Copy(this.innerArray, trimedArray, this.index);

            this.innerArray = trimedArray;
        }
    }
}
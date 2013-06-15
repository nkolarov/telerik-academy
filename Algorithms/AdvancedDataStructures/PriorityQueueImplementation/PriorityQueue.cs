// ********************************
// <copyright file="PriorityQueue.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace PriorityQueueImplementation
{
    using System;

    /// <summary>
    /// Represents a Priority Queue.
    /// </summary>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        /// <summary>
        /// Defines initial queue array size.
        /// </summary>
        private static int DEFAULT_ARRAY_SIZE = 16;

        /// <summary>
        /// Stores queue elements.
        /// </summary>
        private T[] queue;

        /// <summary>
        /// Sores last occupied element index.
        /// When we initialize the queue we don`t have occupied elements. 
        /// So we start from -1. When we add the first element the index becomes 0 and so on.
        /// </summary>
        private int lastElementIndex = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue" /> class.
        /// </summary>
        public PriorityQueue()
        {
            this.queue = new T[DEFAULT_ARRAY_SIZE];
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get
            {
                return this.lastElementIndex;
            }
        }

        /// <summary>
        /// Gets the next free index.
        /// </summary>
        /// <value>The next free index.</value>
        private int NextFreeIndex
        {
            get
            {
                return this.lastElementIndex + 1;
            }
        }

        /// <summary>
        /// Enqueues the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Enqueue(T element)
        {
            if (this.Count == this.queue.Length - 1)
            {
                this.AutoGrow();
            }

            this.queue[this.NextFreeIndex] = element;
            this.lastElementIndex = this.NextFreeIndex;
            this.ShiftUp(this.lastElementIndex);
        }
  
        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        /// <returns>The dequeued element.</returns>
        public T Dequeue()
        {
            var element = this.queue[0];
            this.queue[0] = this.queue[this.lastElementIndex];
            this.queue[this.lastElementIndex] = (dynamic)null;
            this.lastElementIndex--;
            this.ShiftDown(0);
            return element;
        }

        /// <summary>
        /// Peeks the first element.
        /// </summary>
        /// <returns>The first element.</returns>
        public T Peek()
        {
            return this.queue[0];
        }

        /// <summary>
        /// Shifts down the current element while possible.
        /// </summary>
        /// <param name="index">The index.</param>
        public void ShiftDown(int index) 
        {
            // Until we reach the last element with chiclds.
            while (index <= this.lastElementIndex)
            {
                // Check if right child exists
                if (GetRightChildIndex(index) <= this.lastElementIndex)
                {
                    T biggerChild = this.GetBiggerChild(index);
                    T currentElement = this.queue[index];

                    // Checks if is bigger than child and if so breaks, else swaps and continues for the next element.
                    if (currentElement.CompareTo(biggerChild) <= 0)
                    {
                        var biggerChildIndex = this.GetBiggerChildIndex(index);
                        this.Swap(biggerChildIndex, index);
                        index = biggerChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Gets the index of the parent.
        /// </summary>
        /// <param name="childIndex">Index of the child.</param>
        /// <returns>The index of the parent.</returns>
        private static int GetParentIndex(int childIndex)
        {
            var parentIndex = (childIndex - 1) / 2;
            return parentIndex;
        }

        /// <summary>
        /// Gets the index of the left child.
        /// </summary>
        /// <param name="parentIndex">Index of the parent.</param>
        /// <returns>The index of the left child.</returns>
        private static int GetLeftChildIndex(int parentIndex)
        {
            var leftChildIndex = (parentIndex * 2) + 1;
            return leftChildIndex;
        }

        /// <summary>
        /// Gets the index of the right child.
        /// </summary>
        /// <param name="parentIndex">Index of the parent.</param>
        /// <returns>The index of the right child.</returns>
        private static int GetRightChildIndex(int parentIndex)
        {
            var rightChildIndex = (parentIndex * 2) + 2;
            return rightChildIndex;
        }

        /// <summary>
        /// Gets the bigger child.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The bigger child.</returns>
        private T GetBiggerChild(int index)
        {
            int biggerChildIndex = this.GetBiggerChildIndex(index);
            return this.queue[biggerChildIndex];
        }

        /// <summary>
        /// Gets the index of the bigger child.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The bigger child index.</returns>
        private int GetBiggerChildIndex(int index)
        {
            int biggerChildIndex = GetLeftChildIndex(index);
            if (this.GetLeftChild(index).CompareTo(this.GetRightChild(index)) < 0)
            {
                biggerChildIndex = GetRightChildIndex(index);
            }

            return biggerChildIndex;
        }

        /// <summary>
        /// Shifts up the current element.
        /// </summary>
        /// <param name="index">The index.</param>
        private void ShiftUp(int index)
        {
            while (index != 0)
            {
                if (this.queue[index].CompareTo(this.GetParent(index)) > 0)
                {
                    this.Swap(index, GetParentIndex(index));
                    index = GetParentIndex(index);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Swaps the specified elements by given indexes.
        /// </summary>
        /// <param name="sourceIndex">Index of the source.</param>
        /// <param name="destinationIndex">Index of the destination.</param>
        private void Swap(int sourceIndex, int destinationIndex)
        {
            T tempElement = this.queue[destinationIndex];
            this.queue[destinationIndex] = this.queue[sourceIndex];
            this.queue[sourceIndex] = tempElement;
        }

        /// <summary>
        /// Gets the parent element.
        /// </summary>
        /// <param name="childIndex">Index of the child.</param>
        /// <returns>The parent element.</returns>
        private T GetParent(int childIndex)
        {
            return this.queue[GetParentIndex(childIndex)];
        }

        /// <summary>
        /// Gets the left child.
        /// </summary>
        /// <param name="parentIndex">Index of the parent.</param>
        /// <returns>The left child.</returns>
        private T GetLeftChild(int parentIndex)
        {
            return this.queue[GetLeftChildIndex(parentIndex)];
        }

        /// <summary>
        /// Gets the right child.
        /// </summary>
        /// <param name="parentIndex">Index of the parent.</param>
        /// <returns>The right child.</returns>
        private T GetRightChild(int parentIndex)
        {
            return this.queue[GetRightChildIndex(parentIndex)];
        }

        /// <summary>
        /// Doubles the size of the queue array.
        /// </summary>
        private void AutoGrow()
        {
            T[] largerQueue = new T[this.lastElementIndex * 2];
            Array.Copy(this.queue, largerQueue, this.queue.Length);
            this.queue = largerQueue;
        }
    }
}
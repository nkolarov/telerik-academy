// ********************************
// <copyright file="SortableCollection.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using SortingAndSearchingAlgorithms;

    /// <summary>
    /// Represents a Sortable collection.
    /// </summary>
    public class SortableCollection<T> where T : IComparable<T>
    {
        /// <summary>
        /// Stores the items.
        /// </summary>
        private readonly IList<T> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableCollection" /> class.
        /// </summary>
        public SortableCollection()
        {
            this.items = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableCollection" /> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter.</param>
        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        /// <summary>
        /// Searches through collection using linear search algorithm.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if item exists.</returns>
        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Searches through collection using binary search algorithm.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>True if item exists.</returns>
        public bool BinarySearch(T item)
        {
            var elements = this.Items;
            int startIndex = 0;
            int endIndex = elements.Count;

            while (endIndex > startIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (elements[midIndex].CompareTo(item) < 0)
                {
                    startIndex = midIndex;
                }
                else if (elements[midIndex].CompareTo(item) < 0)
                {
                    endIndex = midIndex;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Shuffles the items using Fisher–Yates algorithm.
        /// </summary>
        public void Shuffle()
        {
            var n = this.Items.Count;
            var randomGenerator = new Random();
            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                int r = i + randomGenerator.Next(0, n - i);

                this.Swap(i, r);
            }
        }
  
        /// <summary>
        /// Prints all items on the console.
        /// </summary>
        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Swaps the specified elements by given indexes.
        /// </summary>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        private void Swap(int oldIndex, int newIndex)
        {
            var temp = this.Items[oldIndex];
            this.Items[oldIndex] = this.Items[newIndex];
            this.Items[newIndex] = temp;
        }
    }
}
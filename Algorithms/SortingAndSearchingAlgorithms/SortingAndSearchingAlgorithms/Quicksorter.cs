// ********************************
// <copyright file="Quicksorter.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Quick Sorter implementing quick sort algorithm.
    /// </summary>
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void Sort(IList<T> collection)
        {
            // TODO: If u have free time rewrite and use the reference to save memory from creating another collection.
            var orderedCollection = this.QuickSort(collection);

            collection.Clear();
            foreach (T item in orderedCollection)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Quick sorts the collection recursively.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>The sorted collection.</returns>
        public IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count < 1)
            {
                return collection;
            }

            // TODO: Smart pivot choosing.
            int pivotIndex = collection.Count / 2;
            T pivot = collection[pivotIndex];

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                // We will add the pivot at the end.
                if (i == pivotIndex)
                {
                    continue;
                }

                if (collection[i].CompareTo(pivot) <= 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            return this.ConcatenateResult(this.QuickSort(left), pivot, this.QuickSort(right));
        }

        /// <summary>
        /// Concatenates the result.
        /// </summary>
        /// <param name="leftList">The left list.</param>
        /// <param name="pivot">The pivot.</param>
        /// <param name="rightList">The right list.</param>
        /// <returns>The result.</returns>
        private IList<T> ConcatenateResult(IList<T> leftList, T pivot, IList<T> rightList)
        {
            List<T> result = new List<T>();

            result.AddRange(leftList);
            result.Add(pivot);
            result.AddRange(rightList);

            return result;
        }
    }
}
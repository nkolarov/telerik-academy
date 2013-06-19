// ********************************
// <copyright file="MergeSorter.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Merge Sorter implementing merge sort algorithm.
    /// </summary>
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void Sort(IList<T> collection)
        {
            // TODO: If u have free time rewrite and use the reference to save memory from creating another collection.
            var orderedCollection = this.MergeSort(collection);

            collection.Clear();
            foreach (T item in orderedCollection)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Does the merge sort.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>The sorted collection.</returns>
        public IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            int pivotIndex = collection.Count / 2;

            for (int i = 0; i < pivotIndex; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = pivotIndex; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = this.MergeSort(left);
            right = this.MergeSort(right);

            var a = 5;
            return Merge(left, right);
        }

        /// <summary>
        /// Merges the specified lists.
        /// </summary>
        /// <param name="left">The left list.</param>
        /// <param name="right">The right list.</param>
        /// <returns>The merged list.</returns>
        private static IList<T> Merge(IList<T> left, IList<T> right)
        {
            List<T> result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
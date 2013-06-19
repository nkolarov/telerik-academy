// ********************************
// <copyright file="SelectionSorter.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Represents a Selection Sorter implementing Selection sort algorithm.
    /// </summary>
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void Sort(IList<T> collection)
        {
            if (collection.Count == 0)
            {
                return;
            }
            
            for (int i = 0; i < collection.Count; i++)
            {
                T minElement = collection[i];
                int minElementIndex = i;

                // Find current min
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(minElement) < 0)
                    {
                        minElement = collection[j];
                        minElementIndex = j;
                    }
                }

                // Swap
                if (minElementIndex != i)
                {
                    var temp = collection[i];
                    collection[i] = collection[minElementIndex];
                    collection[minElementIndex] = temp;
                }
            }
        }
    }
}
// ********************************
// <copyright file="ISorter.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an ISorter.
    /// </summary>
    public interface ISorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        void Sort(IList<T> collection);
    }
}

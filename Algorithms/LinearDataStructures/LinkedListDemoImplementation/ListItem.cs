// ********************************
// <copyright file="ListItem.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace LinkedListDemoImplementation
{
    using System;

    /// <summary>
    /// Represents List Item.
    /// </summary>
    public class ListItem<T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; private set; }

        /// <summary>
        /// Gets or sets the next item.
        /// </summary>
        /// <value>The next item.</value>
        public ListItem<T> NextItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListItem" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ListItem(T value)
        {
            this.Value = value;
        }
    }
}
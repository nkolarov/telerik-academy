// ********************************
// <copyright file="Node.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TreeDemo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a node.
    /// </summary>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Node(T value) : this()
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public List<Node<T>> Children { get; set; }

        /// <summary>
        /// Gets or sets the has parent.
        /// </summary>
        /// <value>The has parent.</value>
        public bool HasParent { get; set; }
    }
}
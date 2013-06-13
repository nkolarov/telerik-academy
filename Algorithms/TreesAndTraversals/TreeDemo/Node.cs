// ********************************
// <copyright file="Node.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TreeDemo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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

        public dynamic GetSum()
        {
            dynamic sum = 0;

            if (this.Children.Count == 0)
            {
                return this.Value;
            }

            sum += this.Value;

            foreach (var node in this.Children)
            {
                sum += node.GetSum();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.Children.Count == 0)
            {
                result.AppendFormat("{{{0}}}", this.Value);
                return result.ToString();
            }

            result.AppendFormat("{{{0}->", this.Value);
            foreach (var node in this.Children)
            {
                result.Append(node.ToString());
            }
            result.Append("}");

            return result.ToString();
        }
    }
}
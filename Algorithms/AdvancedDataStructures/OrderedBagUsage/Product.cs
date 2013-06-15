// ********************************
// <copyright file="Product.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace OrderedBagUsage
{
    using System;

    /// <summary>
    /// Represents a Product
    /// </summary>
    public class Product : IComparable<Product>
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="price">The price.</param>
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>The price.</value>
        public decimal Price { get; private set; }

        /// <summary>
        /// Compares this instance to a specified other Product and returns
        /// an indication of their relative values.
        /// </summary>
        /// <param name="other">The other Person.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and
        /// <paramref name="other" />.Return Value Description Less than zero This instance
        /// is less than <paramref name="other" />. Zero This instance is equal to <paramref name="other" />.
        /// Greater than zero This instance is greater than <paramref name="other" />.
        /// </returns>
        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
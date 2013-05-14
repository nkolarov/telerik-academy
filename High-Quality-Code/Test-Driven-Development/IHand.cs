// ********************************
// <copyright file="IHand.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Poker
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an IHand interface.
    /// </summary>
    public interface IHand
    {
        /// <summary>
        /// Gets the cards.
        /// </summary>
        /// <value>The cards.</value>
        IList<ICard> Cards { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        string ToString();
    }
}
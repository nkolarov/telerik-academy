// ********************************
// <copyright file="Figure.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Figures
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a Figure.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Calculates the perimeter.
        /// </summary>
        /// <returns>The calculated perimeter.</returns>
        public abstract double CalculatePerimeter();

        /// <summary>
        /// Calculates the surface.
        /// </summary>
        /// <returns>The calculated surface.</returns>
        public abstract double CalculateSurface();

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendFormat("I am a {0}. ", this.GetType());
            info.AppendFormat("My perimeter is {0:f2}. ", this.CalculatePerimeter());
            info.AppendFormat("My surface is {0:f2}.", this.CalculateSurface());
            
            return info.ToString();
        }
    }
}
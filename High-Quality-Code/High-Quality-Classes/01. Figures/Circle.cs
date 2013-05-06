// ********************************
// <copyright file="Circle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Figures
{
    using System;

    /// <summary>
    /// Represents the figure Circle.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Stores the radius of an instance of the <see cref="Circle"/> class.
        /// </summary>
        private double radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle" /> class.
        /// </summary>
        /// <param name="radius">The radius.</param>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>The radius.</value>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be positive!");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Calculates the perimeter.
        /// </summary>
        /// <returns>The calculated perimeter.</returns>
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface.
        /// </summary>
        /// <returns>The calculated surface.</returns>
        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
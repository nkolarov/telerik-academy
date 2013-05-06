// ********************************
// <copyright file="Rectangle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Figures
{
    using System;

    /// <summary>
    /// Represents the figure Rectangle.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Stores the width of an instance of the <see cref="Rectangle"/> class.
        /// </summary>
        private double width;

        /// <summary>
        /// Stores the height of an instance of the <see cref="Rectangle"/> class.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle" /> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be positive!");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be positive!");
                }

                this.height = value;
            }
        }
        
        /// <summary>
        /// Calculates the perimeter.
        /// </summary>
        /// <returns>The calculated perimeter.</returns>
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface.
        /// </summary>
        /// <returns>The calculated surface.</returns>
        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
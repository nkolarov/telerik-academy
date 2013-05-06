// ********************************
// <copyright file="FiguresExample.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Figures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Just an example. Shows Figures usage.
    /// </summary>
    internal class FiguresExample
    {
        /// <summary>
        /// Mains this instance.
        /// </summary>
        private static void Main()
        {
            List<Figure> figures = new List<Figure> { new Circle(5), new Rectangle(2, 3) };
            foreach (var figure in figures)
            {
                Console.WriteLine(figure.ToString());
            }
        }
    }
}
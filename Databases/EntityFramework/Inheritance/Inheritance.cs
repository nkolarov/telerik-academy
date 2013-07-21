// ********************************
// <copyright file="TwoContexts.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Inheritance
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using Northwind.Model;

    /// <summary>
    /// Demonstrates how to clone existing database.
    /// </summary>
    public class Inheritance
    {
        /* 08. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                foreach (var territory in northwindDbContext.Employees.First().TerritoriesSet)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }
            }
        }
    }
}

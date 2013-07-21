// ********************************
// <copyright file="TwoContexts.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TwoContexts
{
    using System;
    using Northwind.Model;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// Demonstrates how to clone existing database.
    /// </summary>
    public class TwoContexts
    {
        /* 07. Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()? How to deal with it?*/
        // EF executes everything in transactions by default. We don`t need to worry about it.

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                using (var secondNorthwindDbContext = new NorthwindEntities())
                {
                    var order = northwindDbContext.Orders.Find(10248);
                    var sameOrder = secondNorthwindDbContext.Orders.Find(10248);

                    // Mark for delete
                    northwindDbContext.Orders.Remove(order);

                    // Update some stuff
                    sameOrder.ShipCountry = "Bulgaria";

                    // Make update
                    try
                    {
                        secondNorthwindDbContext.SaveChanges();
                        Console.WriteLine("Updating complete!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Updating failed!");
                    }
                    

                    // Delete -> Produces an exception because of data integrity.
                    try
                    {
                        northwindDbContext.SaveChanges();
                        Console.WriteLine("Deleting complete!");
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Delete cannot be executed!");
                    }
                    
                }
            }

            Console.WriteLine("Done!");
        }
    }
}

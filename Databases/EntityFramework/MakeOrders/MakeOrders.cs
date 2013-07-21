// ********************************
// <copyright file="MakeOrders.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace MakeOrders
{
    using System;
    using System.Linq;
    using Northwind.Model;

    /// <summary>
    /// Demonstrates the power of transactions.
    /// </summary>
    public class MakeOrders
    {
        /* 09. Create a method that places a new order in the Northwind database. The order should contain several order items. Use transaction to ensure the data consistency.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            var order = new Order
            {
                CustomerID = "TOMSP",
                EmployeeID = 1,
                Freight = 5M,
                OrderDate = new DateTime(1995, 12, 11),
                RequiredDate = new DateTime(1995, 12, 30),
                ShipAddress = "Ship Address",
                ShipCity = "Ship City",
                ShipCountry = "Ship Country",
                ShipName = "Ship Name"
            };

            AddOrderMultipleTimes(order);
            Console.WriteLine("DONE!");
        }

        /// <summary>
        /// Adds an order multiple times to the db. Transaction demo.
        /// </summary>
        /// <param name="order">The order.</param>
        private static void AddOrderMultipleTimes(Order order)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                northwindDbContext.Orders.Add(order);
                northwindDbContext.Orders.Add(order);
                northwindDbContext.Orders.Add(order);

                //// Uncomment to see transaction power!
                // order.CustomerID = "PESHO_ZLIA";
                northwindDbContext.Orders.Add(order);
                northwindDbContext.Orders.Add(order);

                try
                {
                    northwindDbContext.SaveChanges();
                }
                catch (Exception)
                {
                    Console.WriteLine("Error! Orders not confirmed!");
                }
            }
        }
    }
}

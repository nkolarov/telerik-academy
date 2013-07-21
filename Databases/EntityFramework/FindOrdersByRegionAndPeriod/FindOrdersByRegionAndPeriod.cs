// ********************************
// <copyright file="FindOrdersByRegionAndPeriod.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace FindOrdersByRegionAndPeriod
{
    using System;
    using Northwind.DAO;
    using Northwind.Model;

    /// <summary>
    /// Demonstrates searching in db customers.
    /// </summary>
    public class FindOrdersByRegionAndPeriod
    {
        /* 05. Write a method that finds all the sales by specified region and period (start / end dates).*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            var region = "Québec";
            var startDate = new DateTime(1997, 6, 1);
            var endDate = new DateTime(1997, 8, 30);
            var orders = DAO.GetOrdersByRegionAndPeriod(region, startDate, endDate);

            foreach (var order in orders)
            {
                var orderData = order as Order;
                if (orderData != null)
                {
                    Console.WriteLine("Order N: {0}, Date: {1}, ShipRegion: {2}", orderData.OrderID, orderData.OrderDate, orderData.ShipRegion);
                }
            }
        }
    }
}

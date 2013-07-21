// ********************************
// <copyright file="FindCustomersPlainSQL.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace FindCustomersPlainSQL
{
    using System;
    using Northwind.DAO;

    /// <summary>
    /// Demonstrates searching in db customers.
    /// </summary>
    public class FindCustomersPlainSQL
    {
        /* 04. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
         * Implement previous by using native SQL query and executing it through the DbContext.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            var customers = DAO.FindCustomersWithOrdersFromCanadaIn1997SQL();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}

// ********************************
// <copyright file="FindCustomers.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace FindCustomers
{
    using System;
    using Northwind.DAO;

    /// <summary>
    /// Demonstrates searching in db customers.
    /// </summary>
    public class FindCustomers
    {
        /* 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.*/
        public static void Main()
        {
            // First way
            Console.WriteLine("First way:");
            var customers = DAO.FindCustomersWithOrdersFromCanadaIn1997();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

            // Second way
            Console.WriteLine("Another way:");
            var anotherCustomers = DAO.AnotherFindCustomersWithOrdersFromCanadaIn1997();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}

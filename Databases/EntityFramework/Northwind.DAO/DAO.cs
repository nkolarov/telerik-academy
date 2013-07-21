// ********************************
// <copyright file="DAO.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace Northwind.DAO
{
    using System;
    using System.Linq;
    using Northwind.Model;
using System.Collections;
    using System.Collections.Generic;

    public class DAO
    {
        /* 02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.*/

        /// <summary>
        /// Deletes a customer identified by CustomerID.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public static void DeleteCustomer(Customer customer)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var customerForDelete = northwindDbContext.Customers.First(c => c.CustomerID == customer.CustomerID);
                northwindDbContext.Customers.Remove(customerForDelete);

                northwindDbContext.SaveChanges();
                Console.WriteLine("Customer successfully deleted!");
            }
        }

        /// <summary>
        /// Updates a customer identified by CustomerID.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public static void UpdateCustomer(Customer customer)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var customerForUpdate = northwindDbContext.Customers.First(c => c.CustomerID == customer.CustomerID);

                customerForUpdate.CompanyName = customer.CompanyName ?? customerForUpdate.CompanyName;
                customerForUpdate.ContactName = customer.ContactName ?? customerForUpdate.ContactName;
                customerForUpdate.ContactTitle = customer.ContactTitle ?? customerForUpdate.ContactTitle;
                customerForUpdate.Address = customer.Address ?? customerForUpdate.Address;
                customerForUpdate.City = customer.City ?? customerForUpdate.City;
                customerForUpdate.Region = customer.Region ?? customerForUpdate.Region;
                customerForUpdate.PostalCode = customer.PostalCode ?? customerForUpdate.PostalCode;
                customerForUpdate.Country = customer.Country ?? customerForUpdate.Country;
                customerForUpdate.Phone = customer.Phone ?? customerForUpdate.Phone;
                customerForUpdate.Fax = customer.Fax ?? customerForUpdate.Fax;

                northwindDbContext.SaveChanges();
                Console.WriteLine("The customer is Updated!");
            }
        }

        /// <summary>
        /// Adds a customer to customers table.
        /// </summary>
        /// <param name="customer">The customer to be added.</param>
        public static void AddCustomer(Customer customer)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                northwindDbContext.Customers.Add(customer);
                northwindDbContext.SaveChanges();
                Console.WriteLine("Customer successfully added!");
            }
        }

        /// <summary>
        /// Finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        /// <returns>The customers.</returns>
        public static IEnumerable FindCustomersWithOrdersFromCanadaIn1997()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var customers = northwindDbContext.Orders.Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada").Join(northwindDbContext.Customers, o => o.CustomerID, c => c.CustomerID, (o,c) => c.ContactName).Distinct().ToList();

                return customers;
            }
        }

        /// <summary>
        /// Finds all customers who have orders made in 1997 and shipped to Canada.
        /// </summary>
        /// <returns>The customers.</returns>
        public static IEnumerable AnotherFindCustomersWithOrdersFromCanadaIn1997()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var customers = northwindDbContext.Orders.Include("Customer").Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada").GroupBy(o => o.Customer.ContactName).Select(c =>  c.Key).ToList();

                return customers;
            }
        }

        /// <summary>
        /// Finds all customers who have orders made in 1997 and shipped to Canada using plain SQL.
        /// </summary>
        /// <returns>The customers.</returns>
        public static IEnumerable FindCustomersWithOrdersFromCanadaIn1997SQL()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var query =
                    "SELECT "+
	                    "DISTINCT(cust.ContactName) "+
                    "FROM "+
	                    "dbo.Orders ord "+
                    "INNER JOIN dbo.Customers cust "+
	                    "ON cust.CustomerID = ord.CustomerID "+
                    "WHERE DATEPART(YEAR, ord.OrderDate) = 1997 "+
	                    "AND ord.ShipCountry = 'Canada'";
                var customers = northwindDbContext.Database.SqlQuery<string>(query).ToList();

                return customers;
            }
        }

        /// <summary>
        /// Finds all customers who have orders made in 1997 and shipped to Canada using plain SQL.
        /// </summary>
        /// <returns>The customers.</returns>
        public static IEnumerable GetOrdersByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var orders = northwindDbContext.Orders.Where(o => o.ShipRegion == region && o.ShippedDate > startDate && o.ShippedDate < endDate).ToList();

                return orders;
            }
        }
    }
}

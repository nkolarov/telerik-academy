// ********************************
// <copyright file="CallStoredProcedure.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace CallStoredProcedure
{
    using System;
    using System.Linq;
    using Northwind.Model;

    /// <summary>
    /// Demonstrates how to call sp from EF.
    /// </summary>
    public class CallStoredProcedure
    {
        /* 10. Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period (start date, end date). 
         * Implement a C# method that calls the stored procedure and returns the retuned record set.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            var supplierName = "Tokyo Traders";
            var startDate = new DateTime(1995, 01, 01);
            var endDate = new DateTime(1998, 01, 01);
            
            var totalIncome = FindTotalIncome(supplierName, startDate, endDate);
            Console.WriteLine(totalIncome);
        }

        /// <summary>
        /// Finds Total Income.
        /// </summary>
        /// <param name="supplierName">The supplier name.</param>
        /// <param name="startDate">Period start date.</param>
        /// <param name="endDate">Period end date.</param>
        /// <returns>The total income.</returns>
        private static decimal? FindTotalIncome(string supplierName, DateTime startDate, DateTime endDate)
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var totalIncome = northwindDbContext.usp_FindTotalIncome(supplierName, startDate, endDate).First();

                return totalIncome;
            }
        }
    }
}


// ********************************
// <copyright file="ToListProblem.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ToListProblem
{
    using System;
    using System.Linq;
    using TelerikAcademy.Model;

    /// <summary>
    /// Demonstrates how to solve multiple to list problem.
    /// </summary>
    public class ToListProblem
    {
        /* 02. Using Entity Framework write a query that selects all employees from the Telerik Academy database, 
         * then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, 
         * then invokes ToList() and finally checks whether the town is "Sofia". 
         * Rewrite the same in more optimized way and compare the performance.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            SelectWithMultipleToList(); // Produces 645 queries.
            SelectWithOptimizedToList(); // Produces only one query.
        }

        /// <summary>
        /// Demonstrates slow multiple to list execution.
        /// </summary>
        private static void SelectWithMultipleToList()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var result = telerikAcademyDBContext.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == "Sofia").ToList();
            }
            Console.WriteLine("Done!");
        }

        /// <summary>
        /// Demonstrates optimized query execution.
        /// </summary>
        private static void SelectWithOptimizedToList()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var result = telerikAcademyDBContext.Employees.Select(e => e.Address).Select(a => a.Town).Where(t => t.Name == "Sofia").ToList();
            }
            Console.WriteLine("Done!");
        }
    }
}

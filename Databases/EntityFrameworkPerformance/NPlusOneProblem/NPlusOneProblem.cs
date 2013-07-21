// ********************************
// <copyright file="NPlusOneProblem.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace NPlusOneProblem
{
    using System;
    using TelerikAcademy.Model;

    /// <summary>
    /// Demonstrates how to solve n+1 problem.
    /// </summary>
    public class NPlusOneProblem
    {
        /* 01. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. 
         * Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            PrintEmployeesWithoutInclude(); // Result: 339 qqueries.
            PrintEmployeesOptimized(); // Result: 1 query
        }

        /// <summary>
        /// Prints employees without using include.
        /// </summary>
        private static void PrintEmployeesWithoutInclude()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyDBContext.Employees;
                foreach (var employee in employees)
                {
                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", employee.FirstName + ' ' + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }

        /// <summary>
        /// Prints employees faster using include.
        /// </summary>
        private static void PrintEmployeesOptimized()
        {
            using (var telerikAcademyDBContext = new TelerikAcademyEntities())
            {
                var employees = telerikAcademyDBContext.Employees.Include("Department").Include("Address.Town");
                foreach (var employee in employees)
                {
                    Console.WriteLine("Name: {0}, Department: {1}, Town: {2}", employee.FirstName + ' ' + employee.LastName, employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }
    }
}

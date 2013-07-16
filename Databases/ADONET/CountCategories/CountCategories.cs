// ********************************
// <copyright file="CountCategories.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace CountCategories
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Demonstrates how to connect to MSSQL server.
    /// </summary>
    public class CountCategories
    {
        /* 01.Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            // Define connection properties.
            SqlConnection dbCon = new SqlConnection(
                "Server=localhost; " +
                "Database=northwind; " +
                "Integrated Security=true");
            dbCon.Open();

            // Count all elements in categories.
            using (dbCon)
            {
                SqlCommand query = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                Console.WriteLine(query.ExecuteScalar());
            }
        }
    }
}

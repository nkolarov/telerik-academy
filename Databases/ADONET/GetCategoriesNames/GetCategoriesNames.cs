// ********************************
// <copyright file="GetCategoriesNames.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace GetCategoriesNames
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Demonstrates how to get all categories names from northwind at MSSQL server.
    /// </summary>
    public class GetCategoriesNames
    {
        /* 02. Write a program that retrieves the name and description of all categories in the Northwind DB.*/

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

            // Read and print all categories.
            using (dbCon)
            {
                SqlCommand query = new SqlCommand("SELECT Categories.CategoryName, Categories.Description FROM Categories", dbCon);
                SqlDataReader reader = query.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Category: {0}, Description: {1}", 
                            (string)reader["CategoryName"], 
                            (string)reader["Description"]);
                    }
                }
            }

        }
    }
}

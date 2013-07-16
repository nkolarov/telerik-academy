// ********************************
// <copyright file="GetCategoryProducts.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace GetCategoryProducts
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    /// <summary>
    /// Demonstrates how to get all products in categories from northwind at MSSQL server.
    /// </summary>
    public class GetCategoryProducts
    {
        /* 03. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. 
         * Can you do this with a single SQL query (with table join)? */

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

            // Read and print all categories and products.
            using (dbCon)
            {
                string query = "SELECT cat.CategoryName, prod.ProductName FROM Categories cat INNER JOIN Products prod ON prod.CategoryID = cat.CategoryID";
                SqlCommand command = new SqlCommand(query, dbCon);
                SqlDataReader reader = command.ExecuteReader();
                StringBuilder output = new StringBuilder();

                using (reader)
                {
                    while (reader.Read())
                    {
                        output.AppendFormat("Category: {0}, Description: {1}{2}",
                            (string)reader["CategoryName"],
                            (string)reader["ProductName"],
                            Environment.NewLine);
                    }

                    Console.WriteLine(output);
                }
            }
        }
    }
}

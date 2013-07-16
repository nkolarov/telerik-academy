// ********************************
// <copyright file="SearchProducts.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SearchProducts
{
    using System;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Demonstrates how to search products from northwind at MSSQL server.
    /// </summary>
    public class SearchProducts
    {
        /* 08. Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Please enter your search string: ");
            string input = Console.ReadLine();
            // Define connection properties.
            SqlConnection dbCon = new SqlConnection(
                "Server=localhost; " +
                "Database=northwind; " +
                "Integrated Security=true");
            dbCon.Open();

            // Read and print all categories.
            using (dbCon)
            {
                // Sanitize input
                input = input.Replace("%", "[%]");
                input = input.Replace("_", "[_]");
                input = input.Replace("\\", "[\\]");
                input = input.Replace("[", "[[");
                input = input.Replace("]", "]] ");

                SqlCommand query = new SqlCommand("SELECT prod.ProductName FROM Products prod WHERE prod.ProductName LIKE '%" + @input + "%' ", dbCon);
                query.Parameters.AddWithValue("@input", input);

                SqlDataReader reader = query.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Product:" + (string)reader["ProductName"]);
                    }
                }
            }

        }
    }
}

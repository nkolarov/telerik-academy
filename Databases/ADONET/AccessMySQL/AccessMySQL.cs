// ********************************
// <copyright file="AccessMySQL.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace AccessMySQL
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Demonstrates how to connect to MySQL server.
    /// </summary>
    public class AccessMySQL
    {
        /* 09. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . 
         * Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book.*/

        private static MySqlConnection dbCon;

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            string user = "root";
            string pass = "";
            dbCon = new MySqlConnection("Server=localhost; Port=3306; Database=Books; Uid=" + user + "; Pwd=" + pass + "; pooling=true");

            dbCon.Open();

            // Read and print all categories.
            using (dbCon)
            {
                // Find books
                string search = "%";
                FindBooks(search);

                // List all books
                ListAllBooks();

                // Insert Book
                InsertBook("Test Book Number One", "Pesho Petrov", "123435", new DateTime(2013,07,01));
            }

        }

        /// <summary>
        /// Inserts a book to the db.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="isbn">The isbn.</param>
        /// <param name="publishDate">The publish date.</param>
        private static void InsertBook(string title, string author, string isbn, DateTime publishDate)
        {
            MySqlCommand query = new MySqlCommand("Insert Into Books(Title, Author, ISBN, PublishDate) VALUES(@Title, @Author, @ISBN, @PublishDate)", dbCon);
            query.Parameters.AddWithValue("@Title", title);
            query.Parameters.AddWithValue("@Author", author);
            query.Parameters.AddWithValue("@ISBN", isbn);
            query.Parameters.AddWithValue("@PublishDate", publishDate);

            query.ExecuteNonQuery();
            Console.WriteLine("Book: {0}, Successfully added!", title);

        }

        /// <summary>
        /// Lists all books.
        /// </summary>
        /// <param name="dbCon">Database Connection</param>
        private static void ListAllBooks()
        {
            MySqlCommand query = new MySqlCommand("SELECT Books.Title FROM Books", dbCon);

            MySqlDataReader reader = query.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("All Books:");
                while (reader.Read())
                {
                    Console.WriteLine("Book:" + (string)reader["Title"]);
                }
            }
        }

        /// <summary>
        /// Finds All Books matching given search string.
        /// </summary>
        /// <param name="dbCon">Connection to DB.</param>
        /// <param name="searchedString"></param>
        /// <param name="escapeString"></param>
        private static void FindBooks(string searchedString)
        {
            string escapeString = "/";
            // Sanitize input
            searchedString = searchedString.Replace("%", escapeString + "%");
            searchedString = searchedString.Replace("_", escapeString + "_");
            searchedString = searchedString.Replace("\\", escapeString + "\\");

            MySqlCommand query = new MySqlCommand("SELECT Books.Title FROM Books WHERE Books.Title LIKE '%" + searchedString + "%' ESCAPE '" + escapeString + "' ", dbCon);
            query.Parameters.AddWithValue("@input", searchedString);

            MySqlDataReader reader = query.ExecuteReader();

            using (reader)
            {
                Console.WriteLine("Books Found:");
                while (reader.Read())
                {
                    Console.WriteLine("Book:" + (string)reader["Title"]);
                }
            }
        }
    }
}

// ********************************
// <copyright file="CloneDatabase.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace CloneDatabase
{
    using System;
    using Northwind.Model;
    using System.Data.SqlClient;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// Demonstrates how to clone existing database.
    /// </summary>
    public class CloneDatabase
    {
        /* 06. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.*/

        /// <summary>
        /// Stores the path to the DB.
        /// </summary>
        private static string dbPath = "D:\\Test\\";

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("To get this working fix dbPath and db connection string if required!");
            // Get DB structure.
            string createClone = string.Empty;
            using (var northwindDbContext = new NorthwindEntities())
            {
                createClone = (northwindDbContext as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();
            }

            string createDBScript = "" +
                "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'NorthwindTwin')"+
                "DROP DATABASE NorthwindTwin;" +
                "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                "(NAME = NorthwindTwin, FILENAME = '" + dbPath + "NorthwindTwin.mdf', SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = NorthwindTwinLog, FILENAME = '" + dbPath + "NorthwindTwin.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%);";

            using (var db = new SqlConnection("Server=.; Database=master; Integrated Security=true"))
            {
                // Create empty DB
                db.Open();
                var initializeEmptyDB = new SqlCommand(createDBScript, db);
                initializeEmptyDB.ExecuteNonQuery();
                db.ChangeDatabase("NorthwindTwin");

                // Create twin structure.
                SqlCommand createTwin = new SqlCommand(createClone, db);
                createTwin.ExecuteNonQuery();
            }

            Console.WriteLine("Cloning Done!");
        }
    }
}

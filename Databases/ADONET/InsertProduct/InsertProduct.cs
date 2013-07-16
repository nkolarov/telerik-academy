// ********************************
// <copyright file="InsertProduct.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace InsertProduct
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    /// <summary>
    /// Demonstrates how to use parametric query and inserty data.
    /// </summary>
    public class InsertProduct
    {
        /* 04. Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command. */

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
                Product testProduct = new Product(1, "Test Product", "100", false);
                Product anotherTestProduct = new Product(2, "Test Product Two", "200", false, 1, 1, 10, 2, 20, 1);

                AddProduct(testProduct, dbCon);
                AddProduct(anotherTestProduct, dbCon);
                Console.WriteLine("Done! Check The Table!");
            }
        }

        /// <summary>
        /// Inserts a product in Nortwind.Products table.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="dbCon">The database connection.</param>
        private static void AddProduct(Product product, SqlConnection dbCon)
        {
            string query = "INSERT " +
                "INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)" +
                " VALUES(" +
                "@ProductName," +
                "@SupplierID," +
                "@CategoryID," +
                "@QuantityPerUnit," +
                "@UnitPrice," +
                "@UnitsInStock," +
                "@UnitsOnOrder," +
                "@ReorderLevel," +
                "@Discontinued)";
            SqlCommand command = new SqlCommand(query, dbCon);

            // Add Parameters
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
            command.Parameters.AddWithValue("@Discontinued", product.Discontinued == true ? 1 : 0);

            // Nullable params
            SqlParameter sqlParameterSupplierID = new SqlParameter("@SupplierID", product.SupplierID);
            if (product.SupplierID == null) sqlParameterSupplierID.Value = DBNull.Value;
            command.Parameters.Add(sqlParameterSupplierID);

            SqlParameter sqlParameterCategoryID = new SqlParameter("@CategoryID", product.CategoryID);
            if (product.CategoryID == null) sqlParameterCategoryID.Value = DBNull.Value;
            command.Parameters.Add(sqlParameterCategoryID);
            
            SqlParameter sqlParameterUnitPrice = new SqlParameter("@UnitPrice", product.UnitPrice);
            if (product.UnitPrice == null) sqlParameterUnitPrice.Value = DBNull.Value;
            command.Parameters.Add(sqlParameterUnitPrice);

            SqlParameter sqlParameterUnitsInStock = new SqlParameter("@UnitsInStock", product.UnitsInStock);
            if (product.UnitsInStock == null) sqlParameterUnitsInStock.Value = DBNull.Value;
            command.Parameters.Add(sqlParameterUnitsInStock);

            SqlParameter sqlParameterUnitsOnOrder = new SqlParameter("@UnitsOnOrder", product.UnitsOnOrder);
            if (product.UnitsOnOrder == null) sqlParameterUnitsOnOrder.Value = DBNull.Value;
            command.Parameters.Add(sqlParameterUnitsOnOrder);

            SqlParameter sqlParameterReorderLevel = new SqlParameter("@ReorderLevel", product.ReorderLevel);
            if (product.ReorderLevel == null) sqlParameterReorderLevel.Value = DBNull.Value;
            command.Parameters.Add(sqlParameterReorderLevel);
            
            command.ExecuteNonQuery();
        }
    }
}

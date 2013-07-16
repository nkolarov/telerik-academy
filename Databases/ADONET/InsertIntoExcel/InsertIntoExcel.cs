// ********************************
// <copyright file="InsertIntoExcel.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace InsertIntoExcel
{
    using System;
    using System.Data.OleDb;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Demonstrates how to insert data in excel files.
    /// </summary>
    public class ReadFromExcel
    {
        /* 07. Implement appending new rows to the Excel file.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            // Setup connection. Try OleDbConnectionStringBuilder
            OleDbConnectionStringBuilder excelConnectionString = new OleDbConnectionStringBuilder();
            excelConnectionString.Provider = "Microsoft.Jet.OLEDB.4.0"; ;
            excelConnectionString.DataSource = "..\\..\\test.xls";
            excelConnectionString.Add("Extended Properties", "Excel 8.0;HDR=Yes;IMEX=2");
            OleDbConnection excelConnection = new OleDbConnection(excelConnectionString.ConnectionString);

            excelConnection.Open();

            // Insert new row
            using (excelConnection)
            {
                OleDbCommand command = new OleDbCommand("INSERT INTO [Sheet1$](Name, Score) VALUES(@Name, @Score)", excelConnection);
                command.Parameters.AddWithValue("@Name", "Pesho Zlia Ide v Excel");
                command.Parameters.AddWithValue("@Score", "12");

                command.ExecuteNonQuery();
                Console.WriteLine("Done! Check the file!");
            }
        }
    }
}

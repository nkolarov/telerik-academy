// ********************************
// <copyright file="ReadFromExcel.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ReadFromExcel
{
    using System;
    using System.Data.OleDb;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Demonstrates how to read excel files.
    /// </summary>
    public class ReadFromExcel
    {
        /* 06. Create an Excel file with 2 columns: name and score. Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Old xls:");
            DemoReadFromOldExcel();
            Console.WriteLine("New xls:");
            DemoReadFromNewExcel();
        }

        /// <summary>
        /// Demonstrates the reading from a new excel file.
        /// </summary>
        private static void DemoReadFromNewExcel()
        {
            string pathToFile = "..\\..\\test.xlsx";
            string provider = "Microsoft.ACE.OLEDB.12.0";
            string properties = "Excel 12.0;HDR=Yes;IMEX=2";
            string connectionString = String.Format("Provider = {0}; Data Source={1}; Extended Properties = \"{2}\"", provider, pathToFile, properties);
            OleDbConnection excelConnection = new OleDbConnection(connectionString);

            excelConnection.Open();

            // Open 03++ xlsx
            // It provides backward compatibility and reads old excel files.
            using (excelConnection)
            {
                OleDbCommand command = new OleDbCommand("select * from [Лист1$]", excelConnection);
                OleDbDataReader data = command.ExecuteReader();

                while (data.Read())
                {
                    Console.WriteLine("Name: {0}, Score: {1}", data["Name"], data["Score"]);
                }

            }
        }

        /// <summary>
        /// Demonstrates the reading from an old excel file.
        /// </summary>
        private static void DemoReadFromOldExcel()
        {
            // Define connection properties.
            string pathToFile = "..\\..\\test.xls";
            string provider = "Microsoft.Jet.OLEDB.4.0"; // Microsoft.ACE.OLEDB.12.0";
            string properties = "Excel 8.0;HDR=Yes;IMEX=2"; // "Excel 12.0;HDR=Yes;IMEX=2";
            string connectionString = String.Format("Provider = {0}; Data Source={1}; Extended Properties = \"{2}\"", provider, pathToFile, properties);
            OleDbConnection excelConnection = new OleDbConnection(connectionString);

            excelConnection.Open();

            // Open 97-03 xls
            using (excelConnection)
            {
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", excelConnection);
                OleDbDataReader data = command.ExecuteReader();

                while (data.Read())
                {
                    Console.WriteLine("Name: {0}, Score: {1}", data["Name"], data["Score"]);
                }

            }
        }
    }
}

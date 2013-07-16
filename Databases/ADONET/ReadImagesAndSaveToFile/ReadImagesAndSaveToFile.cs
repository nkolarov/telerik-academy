// ********************************
// <copyright file="ReadImagesAndSaveToFile.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ReadImagesAndSaveToFile
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Demonstrates how to read images and save them as JPEG files.
    /// </summary>
    public class ReadImagesAndSaveToFile
    {
        /* 05. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.*/

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
                string query = "SELECT cat.Picture, cat.CategoryName FROM Categories cat";
                SqlCommand command = new SqlCommand(query, dbCon);
                SqlDataReader reader = command.ExecuteReader();
                StringBuilder output = new StringBuilder();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"].ToString().Replace('/', '_');
                        byte[] imageRawData = (byte[])reader["Picture"];
                        string imagePath = "..\\..\\" + name + ".JPG";

                        byte[] imageData = SkipImageMetadata(imageRawData);
                        SaveImageToFile(imagePath, imageData);
                    }

                }

                Console.WriteLine("Done! Check the project`s folder!");
            }
        }

        /// <summary>
        /// Skips the image metadata.
        /// </summary>
        /// <param name="imageRawData">The image data.</param>
        /// <returns>The new binary data without the metadata.</returns>
        private static byte[] SkipImageMetadata(byte[] imageRawData)
        {
            int len = imageRawData.Length;
            int header = 78;
            byte[] imageData = new byte[len - header];
            Array.Copy(imageRawData, 78, imageData, 0, len - header);
            return imageData;
        }

        /// <summary>
        /// Saves the image to a file.
        /// </summary>
        /// <param name="imagePath">Path to file.</param>
        /// <param name="imageData">Image binary data.</param>
        private static void SaveImageToFile(string imagePath, byte[] imageData)
        {
            using (FileStream imageFile = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter sr = new BinaryWriter(imageFile))
                {
                    sr.Write(imageData);
                }
            }
        }
    }
}

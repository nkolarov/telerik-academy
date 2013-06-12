// ********************************
// <copyright file="TraverseDirectories.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TraverseDirectories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Demonstrates directory traverse using Queue.
    /// </summary>
    public class TraverseDirectories
    {
        /* 02. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.*/

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            const string ROOT_DIRECTORY = "C:\\Windows";

            List<string> directories = new List<string>();
            List<string> executables = new List<string>();
            StringBuilder errorLog = new StringBuilder();
            Queue<string> rootDirectories = new Queue<string>();
            
            // Dig down recursively through directories using queue. 
            rootDirectories.Enqueue(ROOT_DIRECTORY);
            while (rootDirectories.Count > 0)
            {
                var currentDirectory = rootDirectories.Peek();
                try
                {
                    // Save all directories.
                    foreach (var dir in Directory.GetDirectories(currentDirectory))
                    {
                        rootDirectories.Enqueue(dir);
                        directories.Add(dir);
                    }

                    // Save all files.
                    var files = Directory.GetFiles(currentDirectory, "*.exe");
                    executables.AddRange(files);
                }
                catch (UnauthorizedAccessException ex) 
                {
                    errorLog.AppendLine(ex.Message);
                }

                rootDirectories.Dequeue();
            }

            // Print results
            if (errorLog.Length > 0)
            {
                Console.WriteLine("Errors:");
                Console.WriteLine(errorLog);    
            }

            Console.WriteLine("Directories:");
            PrintCollection(directories);    

            Console.WriteLine("Executables:");
            PrintCollection(executables);
        }
  
        /// <summary>
        /// Prints an enumerable collection.
        /// </summary>
        /// <param name="elements">The elements.</param>
        private static void PrintCollection(IEnumerable<string> elements)
        {
            StringBuilder elementsAsString = new StringBuilder();
            foreach (var element in elements)
            {
                elementsAsString.AppendLine(element);
            }

            Console.WriteLine(elementsAsString);
        }
    }
}
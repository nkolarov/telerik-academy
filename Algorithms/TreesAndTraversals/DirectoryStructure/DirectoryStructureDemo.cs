// ********************************
// <copyright file="DirectoryStructure.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DirectoryStructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Demonstrates directory structure creation.
    /// </summary>
    public class DirectoryStructureDemo
    {
        public const string SEARCH_PATTERN = "*.*";
        public const string ROOT_DIRECTORY = "C:\\Windows";
        private static StringBuilder errorLog = new StringBuilder();

        /// <summary>
        /// Mains this instance.
        /// </summary>
        public static void Main()
        {
            // Console.WriteLine("The folder is big. Wait a moment...");
            Folder root = new Folder(ROOT_DIRECTORY);
            GenerateFolders(root);

            Console.WriteLine("Folder: " + root.Name);
            // Console.WriteLine(errorLog);
            Console.WriteLine("Size in bytes: " + root.GetSize());
        }

        /// <summary>
        /// Generates the folders.
        /// </summary>
        /// <param name="folder">The folder.</param>
        public static void GenerateFolders(Folder folder)
        {
            try
            {
                var dirs = Directory.GetDirectories(folder.Name);
                var fileNames = Directory.GetFiles(folder.Name, SEARCH_PATTERN);
                var files = GenerateFiles(fileNames);

                folder.Files.AddRange(files);

                // Walk recuresively through all sub folders.
                foreach (var dir in dirs)
                {
                    Folder currentFolder = new Folder(dir);
                    folder.ChildFolders.Add(currentFolder);
                    GenerateFolders(currentFolder);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                errorLog.AppendLine(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Generates file object by given array of fileNames.
        /// </summary>
        /// <param name="filesNames">The files names.</param>
        /// <returns>List of file oblects.</returns>
        private static List<File> GenerateFiles(string[] filesNames)
        {
            List<File> files = new List<File>();

            for (int i = 0; i < filesNames.Length; i++)
            {
                FileInfo newFileInfo = new FileInfo(filesNames[i]);
                long fileSize = newFileInfo.Length;
                files.Add(new File(filesNames[i], fileSize));
            }

            return files;
        }
    }
}
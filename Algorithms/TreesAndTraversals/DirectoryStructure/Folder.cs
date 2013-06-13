// ********************************
// <copyright file="File.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DirectoryStructure
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a folder.
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Folder" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Folder(string name) 
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>The files.</value>
        public List<File> Files { get; set; }

        /// <summary>
        /// Gets or sets the child folders.
        /// </summary>
        /// <value>The child folders.</value>
        public List<Folder> ChildFolders { get; set; }

        /// <summary>
        /// Gets the size of the folder.
        /// </summary>
        /// <returns>The size of the folder in bytes.</returns>
        public long GetSize()
        {
            long sum = 0;

            // Get files sizes for current directory.
            foreach (var file in this.Files)
            {
                sum += file.Size;
            }

            // Get childs folders size recuresively.
            foreach (var childFolder in this.ChildFolders)
            {
                sum += childFolder.GetSize();
            }

            return sum;
        }
    }
}
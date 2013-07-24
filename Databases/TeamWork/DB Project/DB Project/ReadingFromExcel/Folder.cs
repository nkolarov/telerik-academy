// ********************************
// <copyright file="File.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DirectoryStructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Represents a folder.
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Folder" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public Folder(string path) 
        {
            this.Path = path;
            this.Info = new DirectoryInfo(path);
            this.Files = new List<ReportFile>();
            this.ChildFolders = new List<Folder>();
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; private set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>The files.</value>
        public List<ReportFile> Files { get; set; }

        /// <summary>
        /// Gets or sets the child folders.
        /// </summary>
        /// <value>The child folders.</value>
        public List<Folder> ChildFolders { get; set; }

        /// <summary>
        /// Gets or sets the directory info.
        /// </summary>
        /// <value>The info.</value>
        public DirectoryInfo Info { get; private set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.Info.Name;
            }
        }

        /// <summary>
        /// Gets the size of the folder.
        /// </summary>
        /// <returns>The size of the folder in bytes.</returns>
        //public long GetSize()
        //{
        //    long sum = 0;

        //    // Get files sizes for current directory.
        //    foreach (var file in this.Files)
        //    {
        //        sum += file.Size;
        //    }

        //    // Get childs folders size recuresively.
        //    foreach (var childFolder in this.ChildFolders)
        //    {
        //        sum += childFolder.GetSize();
        //    }

        //    return sum;
        //}
    }
}
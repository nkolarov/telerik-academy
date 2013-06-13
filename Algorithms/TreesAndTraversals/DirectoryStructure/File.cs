// ********************************
// <copyright file="File.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace DirectoryStructure
{
    /// <summary>
    /// Represents a File.
    /// </summary>
    public class File
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="File" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="size">The size.</param>
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public long Size { get; set; }
    }
}
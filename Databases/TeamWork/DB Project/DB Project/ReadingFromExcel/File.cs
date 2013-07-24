// ********************************
// <copyright file="File.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

using System.IO;
namespace DirectoryStructure
{
    /// <summary>
    /// Represents a File.
    /// </summary>
    public class ReportFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportFile" /> class.
        /// </summary>
        /// <param name="path">The name.</param>
        /// <param name="size">The path.</param>
        public ReportFile(string path)
        {
            this.Path = path;
            this.Info = new FileInfo(path);
        }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the info.
        /// </summary>
        /// <value>The info.</value>
        public FileInfo Info { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                //var dirSeparator = this.Name.LastIndexOf("\\") + 1;
                //var fileSeparator = this.Name.IndexOf("Report") - 1;

                //return this.Name.Substring(dirSeparator, fileSeparator - dirSeparator);

                return this.Info.Name;
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public long Size
        {
            get
            {
                return this.Info.Length;
            }
        }
    }
}
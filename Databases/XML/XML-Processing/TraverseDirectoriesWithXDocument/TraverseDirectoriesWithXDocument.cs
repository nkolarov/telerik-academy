// ********************************
// <copyright file="TraverseDirectoriesWithXDocument.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace TraverseDirectoriesWithXDocument
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Demonstrates how to write recursively XML using XDocument.
    /// </summary>
    public class TraverseDirectoriesWithXDocument
    {
        /* 10. Rewrite the last exercises using XDocument, XElement and XAttribute. 
         * (Last exercise: Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files. 
         * Use tags <file> and <dir> with appropriate attributes. For the generation of the XML document use the class XmlWriter.)*/
        static void Main(string[] args)
        {
            // var xmlInfo = new XElement("..\\..\\directoryStructure.xml");
            DirectoryInfo sourceDir = new DirectoryInfo("..\\..\\");

            var xmlInfo = new XElement("directoryStructure");
            WriteDirectoryXML(xmlInfo, sourceDir);
            xmlInfo.Save("..\\..\\directoryStructure.xml");
        }

        /// <summary>
        /// Writes the current directoy XML. Walks recursively through its childs.
        /// </summary>
        /// <param name="parentElement">The XML writer.</param>
        /// <param name="rootDirectory">The root directory.</param>
        private static void WriteDirectoryXML(XElement parentElement, DirectoryInfo rootDirectory)
        {
            var currentFolder = new XElement("directory", new XAttribute("name", rootDirectory.Name));

            foreach (var file in rootDirectory.GetFiles())
            {
                currentFolder.Add(new XElement("file", file.Name));
            }

            foreach (var subDir in rootDirectory.GetDirectories())
            {
                WriteDirectoryXML(currentFolder, subDir);
            }

            parentElement.Add(currentFolder);
        }
    }
}

// ********************************
// <copyright file="ReadWriteXML.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ReadWriteXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Demonstrates how to read from XML document and write in another one.
    /// </summary>
    public class ReadWriteXML
    {
        /* 08. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
         * in which stores in appropriate way the names of all albums and their authors.*/
        public static void Main()
        {
            using (XmlReader sr = XmlReader.Create("..\\..\\..\\catalog.xml"))
            {
                using (XmlTextWriter writer = new XmlTextWriter("..\\..\\album.xml", Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;
                    writer.WriteStartElement("albums");
                    var name = string.Empty;
                    var artist = string.Empty;

                    while (sr.Read())
                    {
                        if ((sr.NodeType == XmlNodeType.Element) && (sr.Name == "name"))
                        {
                            name = sr.ReadElementString().Trim();
                        }
                        else if ((sr.NodeType == XmlNodeType.Element) && (sr.Name == "artist"))
                        {
                            artist = sr.ReadElementString().Trim();
                            WriteAlbumInnerXML(writer, name, artist);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Writes the album inner XML.
        /// </summary>
        /// <param name="writer">The xml writer.</param>
        /// <param name="name">The album name.</param>
        /// <param name="artist">The album artist.</param>
        private static void WriteAlbumInnerXML(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}

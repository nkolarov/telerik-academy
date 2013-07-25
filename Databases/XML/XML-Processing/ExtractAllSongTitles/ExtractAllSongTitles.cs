// ********************************
// <copyright file="ExtractAllSongTitles.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace ExtractAllSongTitles
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Demonstrates how to parse XML document using XmlReader.
    /// </summary>
    public class ExtractAllSongTitles
    {
        /* 05. Write a program, which using XmlReader extracts all song titles from catalog.xml.*/
        public static void Main()
        {
            List<string> songTitles = new List<string>();
            
            // Reat the file and store songs name into a list.
            using (XmlReader reader = XmlReader.Create("..\\..\\..\\catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        songTitles.Add(reader.ReadInnerXml());
                    }
                }
            }

            // Print result
            foreach (var songTitle in songTitles)
            {
                Console.WriteLine(songTitle);
            }
        }
    }
}
